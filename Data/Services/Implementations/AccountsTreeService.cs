using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class AccountsTreesService : IAccountsTreeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountsTreesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountsTreeDto>> GetAllAccountsAsync(CancellationToken cts)
        {
            var accounts = await _unitOfWork.AccountsTrees
                .NoTrackingSelect()
                .OrderByDescending(a => a.AccountCode)
                .ToListAsync(cts);

            return accounts
                .Select(a => new AccountsTreeDto
                {
                    Id = a.Id,
                    ParentGuid = a.ParentGuid,
                    AccountCode = a.AccountCode,
                    AccountName = a.AccountName,
                    IsLeaf = a.IsLeaf,
                    IsActive = a.IsActive,
                    Notes = a.Notes
                })
                .ToList();
        }

        public async Task<AccountsTreeDto> GetAccountByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.AccountsTrees
                .NoTrackingSelect()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (entity == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الحساب بالمعرّف '{id}'.");

            return new AccountsTreeDto
            {
                Id = entity.Id,
                ParentGuid = entity.ParentGuid,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                IsLeaf = entity.IsLeaf,
                IsActive = entity.IsActive,
                Notes = entity.Notes
            };
        }

        public async Task<bool> CreateAccountAsync(CreateAccountsTreeDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات الحساب مطلوبة.");

            var parentIsActive = true;

            // التحقق من الحساب الأب قبل إضافة الحساب الجديد.
            if (model.ParentGuid.HasValue)
            {
                var parent = await _unitOfWork.AccountsTrees
                    .Select()
                    .FirstOrDefaultAsync(a => a.Id == model.ParentGuid.Value);

                if (parent == null)
                    throw new InvalidOperationException("الحساب الأب غير موجود.");

                // لا يمكن تحويل حساب مرتبط بحركات مالية إلى حساب أب.
                await EnsureCanBecomeParentAsync(parent.Id);

                parentIsActive = parent.IsActive;

                parent.IsLeaf = false;
                _unitOfWork.AccountsTrees.Update(parent);
            }

            var account = new AccountsTree
            {
                ParentGuid = model.ParentGuid,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,

                // لا يمكن تفعيل حساب إذا كان حسابه الأب غير فعال.
                IsActive = model.IsActive && parentIsActive,

                Notes = model.Notes,
                IsLeaf = true
            };

            _unitOfWork.AccountsTrees.Add(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAccountAsync(UpdateAccountsTreeDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات الحساب مطلوبة.");

            var account = await _unitOfWork.AccountsTrees
                .Select()
                .FirstOrDefaultAsync(a => a.Id == model.Id);

            if (account == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الحساب بالمعرّف '{model.Id}'.");

            var oldParentGuid = account.ParentGuid;
            var newParentGuid = model.ParentGuid;

            AccountsTree newParent = null;

            if (newParentGuid.HasValue)
            {
                // منع تكوين دورة في شجرة الحسابات.
                await EnsureNoCycleAsync(account.Id, newParentGuid.Value);

                newParent = await _unitOfWork.AccountsTrees
                    .Select()
                    .FirstOrDefaultAsync(a => a.Id == newParentGuid.Value);

                if (newParent == null)
                    throw new InvalidOperationException("الحساب الأب الجديد غير موجود.");
            }

            // عند تغيير الحساب الأب، نتحقق من إمكانية تحويل الأب الجديد
            // إلى حساب أب قبل إجراء أي تعديلات.
            if (oldParentGuid != newParentGuid && newParent != null)
            {
                await EnsureCanBecomeParentAsync(newParent.Id);
            }

            if (oldParentGuid != newParentGuid)
            {
                // تحديث حالة الأب القديم.
                if (oldParentGuid.HasValue)
                {
                    await RefreshParentLeafAsync(
                        oldParentGuid.Value,
                        excludedChildId: account.Id);
                }

                // تحديث حالة الأب الجديد.
                if (newParent != null)
                {
                    newParent.IsLeaf = false;
                    _unitOfWork.AccountsTrees.Update(newParent);
                }
            }

            account.ParentGuid = newParentGuid;
            account.AccountCode = model.AccountCode;
            account.AccountName = model.AccountName;
            account.Notes = model.Notes;

            // لا يمكن تفعيل الحساب إذا كان الأب غير فعال.
            account.IsActive = model.IsActive &&
                               (newParent == null || newParent.IsActive);

            _unitOfWork.AccountsTrees.Update(account);

            // عند إيقاف الحساب، يتم إيقاف جميع الحسابات التابعة له.
            if (!account.IsActive)
                await DeactivateDescendantAccountsAsync(account.Id);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private async Task DeactivateDescendantAccountsAsync(Guid accountId)
        {
            var accounts = await _unitOfWork.AccountsTrees
                .Select()
                .ToListAsync();

            var childrenLookup = accounts.ToLookup(a => a.ParentGuid);

            var stack = new Stack<Guid>();
            var visited = new HashSet<Guid>();

            stack.Push(accountId);

            while (stack.Count > 0)
            {
                var parentId = stack.Pop();

                foreach (var child in childrenLookup[parentId])
                {
                    if (!visited.Add(child.Id))
                        continue;

                    if (child.IsActive)
                    {
                        child.IsActive = false;
                        _unitOfWork.AccountsTrees.Update(child);
                    }

                    stack.Push(child.Id);
                }
            }
        }

        public async Task<bool> DeleteAccountAsync(Guid modelId)
        {
            var account = await _unitOfWork.AccountsTrees
                .Select()
                .FirstOrDefaultAsync(a => a.Id == modelId);

            if (account == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الحساب بالمعرّف '{modelId}'.");

            var hasChildren = await _unitOfWork.AccountsTrees
                .NoTrackingSelect()
                .AnyAsync(a => a.ParentGuid == modelId);

            if (hasChildren)
                throw new InvalidOperationException(
                    "لا يمكن حذف حساب لديه حسابات فرعية.");

            // التحقق من ارتباط الحساب بالفواتير.
            var isUsedInBills = await _unitOfWork.Bills
                .NoTrackingSelect()
                .AnyAsync(b => b.AccountTreeGuid == modelId);

            if (isUsedInBills)
                return false;

            // التحقق من ارتباط الحساب بالسندات.
            var isUsedInVouchers = await _unitOfWork.Vouchers
                .NoTrackingSelect()
                .AnyAsync(v => v.AccountTreeGuid == modelId);

            if (isUsedInVouchers)
                return false;

            if (account.ParentGuid.HasValue)
            {
                await RefreshParentLeafAsync(
                    account.ParentGuid.Value,
                    excludedChildId: modelId);
            }

            _unitOfWork.AccountsTrees.Delete(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private async Task RefreshParentLeafAsync(
            Guid parentId,
            Guid excludedChildId)
        {
            var parent = await _unitOfWork.AccountsTrees
                .Select()
                .FirstOrDefaultAsync(a => a.Id == parentId);

            if (parent == null)
                return;

            parent.IsLeaf = !await _unitOfWork.AccountsTrees
                .NoTrackingSelect()
                .AnyAsync(a => a.ParentGuid == parentId &&
                               a.Id != excludedChildId);

            _unitOfWork.AccountsTrees.Update(parent);
        }

        /// <summary>
        /// يمنع تحويل حساب مرتبط بفواتير أو سندات إلى حساب أب.
        /// </summary>
        private async Task EnsureCanBecomeParentAsync(Guid accountId)
        {
            var isUsedInBills = await _unitOfWork.Bills
                .NoTrackingSelect()
                .AnyAsync(b => b.AccountTreeGuid == accountId);

            var isUsedInVouchers = await _unitOfWork.Vouchers
                .NoTrackingSelect()
                .AnyAsync(v => v.AccountTreeGuid == accountId);

            if (isUsedInBills || isUsedInVouchers)
            {
                throw new InvalidOperationException(
                    "لا يمكن تحويل هذا الحساب إلى حساب أب لارتباطه بفواتير أو سندات مالية.");
            }
        }

        /// <summary>
        /// يمنع جعل الحساب أباً لنفسه أو لأحد أحفاده.
        /// </summary>
        private async Task EnsureNoCycleAsync(
            Guid accountId,
            Guid newParentId)
        {
            Guid? current = newParentId;

            while (current.HasValue)
            {
                if (current.Value == accountId)
                {
                    throw new InvalidOperationException(
                        "لا يمكن نقل الحساب تحت نفسه أو تحت أحد حساباته الفرعية.");
                }

                var id = current.Value;

                current = await _unitOfWork.AccountsTrees
                    .NoTrackingSelect()
                    .Where(a => a.Id == id)
                    .Select(a => a.ParentGuid)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
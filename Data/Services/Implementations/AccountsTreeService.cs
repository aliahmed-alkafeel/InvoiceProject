using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
                .OrderBy(a => a.AccountCode)
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
                .Select()
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
                // تُحسب الحالة من الشجرة نفسها بدلاً من العمود المخزّن (IsLeaf).
                IsLeaf = !await _unitOfWork.AccountsTrees
                    .Select()
                    .AnyAsync(a => a.ParentGuid == entity.Id),
                IsActive = entity.IsActive,
                Notes = entity.Notes
            };
        }

        public async Task<bool> CreateAccountAsync(CreateAccountsTreeDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات الحساب مطلوبة.");

            // التحقق من الأب قبل إضافة الحساب إلى الـ Context
            if (model.ParentGuid.HasValue)
            {
                var parent = await _unitOfWork.AccountsTrees
                    .Select()
                    .FirstOrDefaultAsync(a => a.Id == model.ParentGuid.Value);

                if (parent == null)
                    throw new InvalidOperationException("الحساب الأب غير موجود.");

                parent.IsLeaf = false;
                _unitOfWork.AccountsTrees.Update(parent);
            }

            var account = new AccountsTree
            {
                ParentGuid = model.ParentGuid,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                IsActive = model.IsActive,
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

            if (oldParentGuid != newParentGuid)
            {
                if (newParentGuid.HasValue)
                    await EnsureNoCycleAsync(account.Id, newParentGuid.Value);

                // الأب القديم: يصبح ورقة إذا لم يبقَ له أبناء غير هذا الحساب
                if (oldParentGuid.HasValue)
                    await RefreshParentLeafAsync(oldParentGuid.Value, excludedChildId: account.Id);

                // الأب الجديد: لم يعد ورقة
                if (newParentGuid.HasValue)
                {
                    var newParent = await _unitOfWork.AccountsTrees
                        .Select()
                        .FirstOrDefaultAsync(a => a.Id == newParentGuid.Value);

                    if (newParent == null)
                        throw new InvalidOperationException("الحساب الأب الجديد غير موجود.");

                    newParent.IsLeaf = false;
                    _unitOfWork.AccountsTrees.Update(newParent);
                }
            }

            account.ParentGuid = newParentGuid;
            account.AccountCode = model.AccountCode;
            account.AccountName = model.AccountName;
            account.IsActive = model.IsActive;
            account.Notes = model.Notes;

            _unitOfWork.AccountsTrees.Update(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
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
                .Select()
                .AnyAsync(a => a.ParentGuid == modelId);

            if (hasChildren)
                throw new InvalidOperationException("لا يمكن حذف حساب لديه حسابات فرعية.");

            if (account.ParentGuid.HasValue)
                await RefreshParentLeafAsync(account.ParentGuid.Value, excludedChildId: modelId);

            _unitOfWork.AccountsTrees.Delete(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        private async Task RefreshParentLeafAsync(Guid parentId, Guid excludedChildId)
        {
            var parent = await _unitOfWork.AccountsTrees
                .Select()
                .FirstOrDefaultAsync(a => a.Id == parentId);

            if (parent == null)
                return;

            parent.IsLeaf = !await _unitOfWork.AccountsTrees
                .Select()
                .AnyAsync(a => a.ParentGuid == parentId && a.Id != excludedChildId);

            _unitOfWork.AccountsTrees.Update(parent);
        }

        /// <summary>
        /// يمنع جعل الحساب أباً لنفسه أو لأحد أحفاده.
        /// </summary>
        private async Task EnsureNoCycleAsync(Guid accountId, Guid newParentId)
        {
            Guid? current = newParentId;

            while (current.HasValue)
            {
                if (current.Value == accountId)
                    throw new InvalidOperationException(
                        "لا يمكن نقل الحساب تحت نفسه أو تحت أحد حساباته الفرعية.");

                var id = current.Value;
                current = await _unitOfWork.AccountsTrees
                    .Select()
                    .Where(a => a.Id == id)
                    .Select(a => a.ParentGuid)
                    .FirstOrDefaultAsync();
            }
        }
        }
}
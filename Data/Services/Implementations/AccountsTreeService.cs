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
                .Select()
                .OrderBy(a => a.AccountCode)
                .ToListAsync(cts);

            // الحساب النهائي هو الذي لا يحتوي على حسابات فرعية.
            // تُحسب الحالة من الشجرة نفسها بدلاً من العمود المخزّن (IsLeaf)
            // لأنه يصبح قديماً عند إضافة حساب فرعي لاحقاً.
            var parentIds = new HashSet<Guid>(accounts
                .Where(a => a.ParentGuid.HasValue)
                .Select(a => a.ParentGuid.Value));

            return accounts
                .Select(a => new AccountsTreeDto
                {
                    Id = a.Id,
                    ParentGuid = a.ParentGuid,
                    AccountCode = a.AccountCode,
                    AccountName = a.AccountName,
                    IsLeaf = !parentIds.Contains(a.Id),
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

            var account = new AccountsTree
            {
                ParentGuid = model.ParentGuid,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                IsLeaf = model.IsLeaf,
                IsActive = model.IsActive,
                Notes = model.Notes
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

            account.ParentGuid = model.ParentGuid;
            account.AccountCode = model.AccountCode;
            account.AccountName = model.AccountName;
            account.IsLeaf = model.IsLeaf;
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

            _unitOfWork.AccountsTrees.Delete(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
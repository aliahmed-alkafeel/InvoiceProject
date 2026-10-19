using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

        public async Task<List<AccountsTreeDto>> GetAllAccountsAsync()
        {
            return await _unitOfWork.AccountsTrees
                .Select()
                .OrderBy(a => a.AccountCode)
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
                .ToListAsync();
        }

        public async Task<AccountsTreeDto> GetAccountByIdAsync(Guid id)
        {
            var account = await _unitOfWork.AccountsTrees
                .Select()
                .Where(a => a.Id == id)
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
                .FirstOrDefaultAsync();

            return account ?? throw new InvalidOperationException(
                $"لم يتم العثور على الحساب بالمعرّف '{id}'.");
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
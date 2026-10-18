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
    public class VoucherService : IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VoucherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<VoucherDto>> GetAllVouchersAsync()
        {
            return await _unitOfWork.Vouchers
                .Select()
                .OrderByDescending(v => v.Date)
                .Select(v => new VoucherDto
                {
                    Id = v.Id,
                    VoucherNumber = v.VoucherNumber,
                    VoucherType = v.VoucherType,
                    AccountTreeGuid = v.AccountTreeGuid,
                    Amount = v.Amount,
                    CurrencyGuid = v.CurrencyGuid,
                    CurrencyEqualValue = v.CurrencyEqualValue,
                    Date = v.Date,
                    Notes = v.Notes,
                    AccountTree = new AccountsTreeDto
                    {
                        Id = v.AccountTree.Id,
                        AccountCode = v.AccountTree.AccountCode,
                        AccountName = v.AccountTree.AccountName
                    },
                    Currency = new CurrencyDto
                    {
                        Id = v.Currency.Id,
                        CurrencyName = v.Currency.CurrencyName,
                        CurrencySymbol = v.Currency.CurrencySymbol
                    }
                })
                .ToListAsync();
        }

        public async Task<VoucherDto> GetVoucherByIdAsync(Guid id)
        {
            var voucher = await _unitOfWork.Vouchers
                .Select()
                .Where(v => v.Id == id)
                .Select(v => new VoucherDto
                {
                    Id = v.Id,
                    VoucherNumber = v.VoucherNumber,
                    VoucherType = v.VoucherType,
                    AccountTreeGuid = v.AccountTreeGuid,
                    Amount = v.Amount,
                    CurrencyGuid = v.CurrencyGuid,
                    CurrencyEqualValue = v.CurrencyEqualValue,
                    Date = v.Date,
                    Notes = v.Notes
                })
                .FirstOrDefaultAsync();

            return voucher ?? throw new InvalidOperationException(
                $"لم يتم العثور على السند بالمعرّف '{id}'.");
        }

        public async Task<bool> CreateVoucherAsync(VoucherDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات السند مطلوبة.");

            var voucher = new Voucher
            {
                VoucherNumber = model.VoucherNumber,
                VoucherType = model.VoucherType,
                AccountTreeGuid = model.AccountTreeGuid,
                Amount = model.Amount,
                CurrencyGuid = model.CurrencyGuid,
                CurrencyEqualValue = model.CurrencyEqualValue,
                Date = model.Date,
                Notes = model.Notes
            };

            _unitOfWork.Vouchers.Add(voucher);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateVoucherAsync(VoucherDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات السند مطلوبة.");

            var voucher = await _unitOfWork.Vouchers
                .Select()
                .FirstOrDefaultAsync(v => v.Id == model.Id);

            if (voucher == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على السند بالمعرّف '{model.Id}'.");

            voucher.VoucherNumber = model.VoucherNumber;
            voucher.VoucherType = model.VoucherType;
            voucher.AccountTreeGuid = model.AccountTreeGuid;
            voucher.Amount = model.Amount;
            voucher.CurrencyGuid = model.CurrencyGuid;
            voucher.CurrencyEqualValue = model.CurrencyEqualValue;
            voucher.Date = model.Date;
            voucher.Notes = model.Notes;

            _unitOfWork.Vouchers.Update(voucher);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteVoucherAsync(Guid modelId)
        {
            var voucher = await _unitOfWork.Vouchers
                .Select()
                .FirstOrDefaultAsync(v => v.Id == modelId);

            if (voucher == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على السند بالمعرّف '{modelId}'.");

            _unitOfWork.Vouchers.Delete(voucher);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
using Data.Repositories.Interfaces;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<List<VoucherDto>> GetAllVouchersAsync(CancellationToken cts)
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
                .ToListAsync(cts);
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

        public async Task<bool> CreateVoucherAsync(CreateVoucherDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات السند مطلوبة");
            var currency = await _unitOfWork.Currencies
                          .Select()
                          .FirstOrDefaultAsync(c => c.Id == model.CurrencyGuid);

            if (currency == null)
                throw new InvalidOperationException("العملة المحددة غير موجودة");

            if (currency.CurrencyEqual <= 0)
                throw new InvalidOperationException(
                    "قيمة تحويل العملة يجب أن تكون أكبر من صفر");
            var voucherNumber = await GenerateVoucherNumberAsync(
            model.VoucherType,
            DateTime.Now.Year);
            var voucher = new Voucher
            {
                VoucherNumber = voucherNumber,
                VoucherType = model.VoucherType,
                AccountTreeGuid = model.AccountTreeGuid.Value,
                Amount = model.Amount.Value,
                CurrencyGuid = model.CurrencyGuid,
                CurrencyEqualValue = currency.CurrencyEqual,
                Date = DateTime.Now,
                Notes = model.Notes
            };

            _unitOfWork.Vouchers.Add(voucher);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateVoucherAsync(UpdateVoucherDto model)
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
            voucher.AccountTreeGuid = model.AccountTreeGuid.Value;
            voucher.Amount = model.Amount.Value;
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

private async Task<string> GenerateVoucherNumberAsync(
    string voucherType,
    int year)
        {
            if (string.IsNullOrWhiteSpace(voucherType))
                throw new ArgumentException(
                    "نوع السند مطلوب.",
                    nameof(voucherType));

            string typeCode;

            if (voucherType.Trim() == VoucherType.Receipt)
            {
                typeCode = "REC";
            }
            else if (voucherType.Trim() == VoucherType.Payment)
            {
                typeCode = "PAY";
            }
            else
            {
                throw new ArgumentException(
                    "نوع السند غير صالح.",
                    nameof(voucherType));
            }

            var prefix = $"{typeCode}-{year}-";

            var lastVoucherNumber = await _unitOfWork.Vouchers
                .Select(DeletedStatus.All)
                .Where(v => v.VoucherNumber.StartsWith(prefix))
                .OrderByDescending(v => v.VoucherNumber)
                .Select(v => v.VoucherNumber)
                .FirstOrDefaultAsync();

            var lastSequence = 0;

            if (!string.IsNullOrEmpty(lastVoucherNumber))
            {
                var sequencePart = lastVoucherNumber.Substring(prefix.Length);

                if (!int.TryParse(
                        sequencePart,
                        NumberStyles.None,
                        CultureInfo.InvariantCulture,
                        out lastSequence))
                {
                    throw new InvalidOperationException(
                        $"رقم السند غير صالح: {lastVoucherNumber}");
                }
            }

            var nextSequence = lastSequence + 1;

            return $"{prefix}{nextSequence:D6}";
        }
    }
}
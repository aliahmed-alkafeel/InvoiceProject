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
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CurrencyDto>> GetAllCurrenciesAsync(CancellationToken cts)
        {
            return await _unitOfWork.Currencies
                .NoTrackingSelect()
                .Select(c => new CurrencyDto
                {
                    Id = c.Id,
                    CurrencyName = c.CurrencyName,
                    CurrencySymbol = c.CurrencySymbol,
                    CurrencyEqual = c.CurrencyEqual,
                    IsMain = c.IsMain,
                    IsActive = c.IsActive,
                    Notes = c.Notes
                })
                .ToListAsync(cts);
        }

        public async Task<CurrencyDto> GetCurrencyByIdAsync(Guid id)
        {
            var currency = await _unitOfWork.Currencies
                .Select()
                .Where(c => c.Id == id)
                .Select(c => new CurrencyDto
                {
                    Id = c.Id,
                    CurrencyName = c.CurrencyName,
                    CurrencySymbol = c.CurrencySymbol,
                    CurrencyEqual = c.CurrencyEqual,
                    IsMain = c.IsMain,
                    IsActive = c.IsActive,
                    Notes = c.Notes
                })
                .FirstOrDefaultAsync();

            return currency ?? throw new InvalidOperationException(
                $"لم يتم العثور على العملة بالمعرّف '{id}'.");
        }

        public async Task<bool> CreateCurrencyAsync(CreateCurrencyDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات العملة مطلوبة.");

            // حماية العملة الرئيسية الحالية عند تعيين عملة جديدة كرئيسية.
            if (model.IsMain &&
                await DemoteCurrentMainCurrencyAsync(
                    null, "تعيين عملة جديدة كعملة رئيسية"))
            {
                // حفظ إلغاء الرئاسة أولاً لتجنب تعارض الفهرس الفريد.
                await _unitOfWork.SaveChangesAsync();
            }

            var currency = new Currency
            {
                CurrencyName = model.CurrencyName,
                CurrencySymbol = model.CurrencySymbol,
                CurrencyEqual = model.CurrencyEqual,
                IsMain = model.IsMain,
                IsActive = model.IsActive,
                Notes = model.Notes
            };

            _unitOfWork.Currencies.Add(currency);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCurrencyAsync(UpdateCurrencyDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات العملة مطلوبة.");

            var currency = await _unitOfWork.Currencies
                .Select()
                .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (currency == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على العملة بالمعرّف '{model.Id}'.");

            // حماية العملة الرئيسية:
            if (currency.IsMain)
            {
                // نتحقق فقط من التغييرات الحساسة، وليس البيانات التعريفية.
                var hasChangedProtectedData =
                    currency.CurrencyEqual != model.CurrencyEqual ||
                    currency.IsMain != model.IsMain ||
                    currency.IsActive != model.IsActive;

                if (hasChangedProtectedData &&
                    await HasTransactionsAsync(currency.Id))
                {
                    throw new InvalidOperationException(
                        "لا يمكن تغيير معامل التحويل أو حالة التفعيل أو صفة العملة الرئيسية " +
                        "لأن العملة مرتبطة بمعاملات سابقة (فواتير أو سندات).");
                }
            }
            else if (model.IsMain)
            {
                // تعيين عملة أخرى كرئيسية.
                // يجب التأكد من إمكانية إلغاء رئاسة العملة الرئيسية الحالية.
                if (await DemoteCurrentMainCurrencyAsync(
                        model.Id, "تعيين عملة أخرى كعملة رئيسية"))
                {
                    // حفظ إلغاء الرئاسة أولاً لتجنب تعارض الفهرس الفريد.
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            // تحديث بيانات العملة.
            // تغيير الاسم والرمز والملاحظات مسموح حتى للعملة الرئيسية المرتبطة بمعاملات.
            currency.CurrencyName = model.CurrencyName;
            currency.CurrencySymbol = model.CurrencySymbol;
            currency.CurrencyEqual = model.CurrencyEqual;
            currency.IsMain = model.IsMain;
            currency.IsActive = model.IsActive;
            currency.Notes = model.Notes;

            _unitOfWork.Currencies.Update(currency);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// يلغي صفة العملة الرئيسية الحالية إذا لم تكن مرتبطة بمعاملات سابقة.
        /// </summary>
        private async Task<bool> DemoteCurrentMainCurrencyAsync(
            Guid? excludedCurrencyId,
            string operation)
        {
            var currentMain = await _unitOfWork.Currencies
                .Select()
                .FirstOrDefaultAsync(c => c.IsMain &&
                    (!excludedCurrencyId.HasValue ||
                     c.Id != excludedCurrencyId.Value));

            if (currentMain == null)
                return false;

            if (await HasTransactionsAsync(currentMain.Id))
            {
                throw new InvalidOperationException(
                    $"لا يمكن {operation} لأن العملة الرئيسية الحالية مرتبطة " +
                    "بمعاملات سابقة (فواتير أو سندات).");
            }

            currentMain.IsMain = false;

            _unitOfWork.Currencies.Update(currentMain);

            return true;
        }

        /// <summary>
        /// يتحقق مما إذا كانت العملة مستخدمة في فواتير أو سندات.
        /// </summary>
        private async Task<bool> HasTransactionsAsync(Guid currencyId)
        {
            var isUsedInBills = await _unitOfWork.Bills
                .NoTrackingSelect()
                .AnyAsync(b => b.CurrencyGuid == currencyId);

            if (isUsedInBills)
                return true;

            return await _unitOfWork.Vouchers
                .NoTrackingSelect()
                .AnyAsync(v => v.CurrencyGuid == currencyId);
        }

        public async Task<bool> DeleteCurrencyAsync(Guid modelId)
        {
            var currency = await _unitOfWork.Currencies
                .Select()
                .FirstOrDefaultAsync(c => c.Id == modelId);

            if (currency == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على العملة بالمعرّف '{modelId}'.");

            // منع حذف العملة الرئيسية.
            if (currency.IsMain)
                return false;

            // منع حذف العملة المرتبطة بمعاملات سابقة.
            if (await HasTransactionsAsync(modelId))
                return false;

            _unitOfWork.Currencies.Delete(currency);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task EnsureExactlyOneMainCurrencyAsync(string operation)
        {
            var mainCurrencyCount = await _unitOfWork.Currencies
                .NoTrackingSelect()
                .CountAsync(c => c.IsMain);

            if (mainCurrencyCount != 1)
            {
                throw new InvalidOperationException(
                    $"لا يمكن {operation}، يجب أن توجد عملة رئيسية واحدة بالضبط في النظام.\n" +
                    "يرجى تحديد العملة الرئيسية من شاشة العملات.");
            }
        }
    }
}
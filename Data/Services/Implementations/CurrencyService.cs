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
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CurrencyDto>> GetAllCurrenciesAsync()
        {
            return await _unitOfWork.Currencies
                .Select()
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
                .ToListAsync();
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

        public async Task<bool> CreateCurrencyAsync(CurrencyDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات العملة مطلوبة.");

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

        public async Task<bool> UpdateCurrencyAsync(CurrencyDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات العملة مطلوبة.");

            var currency = await _unitOfWork.Currencies
                .Select()
                .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (currency == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على العملة بالمعرّف '{model.Id}'.");

            currency.CurrencyName = model.CurrencyName;
            currency.CurrencySymbol = model.CurrencySymbol;
            currency.CurrencyEqual = model.CurrencyEqual;
            currency.IsMain = model.IsMain;
            currency.IsActive = model.IsActive;
            currency.Notes = model.Notes;

            _unitOfWork.Currencies.Update(currency);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCurrencyAsync(Guid modelId)
        {
            var currency = await _unitOfWork.Currencies
                .Select()
                .FirstOrDefaultAsync(c => c.Id == modelId);

            if (currency == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على العملة بالمعرّف '{modelId}'.");

            _unitOfWork.Currencies.Delete(currency);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
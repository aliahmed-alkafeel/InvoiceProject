using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<CurrencyDto>> GetAllCurrenciesAsync();
        Task<CurrencyDto> GetCurrencyByIdAsync(Guid id);
        Task<bool> CreateCurrencyAsync(CurrencyDto model);
        Task<bool> UpdateCurrencyAsync(CurrencyDto model);
        Task<bool> DeleteCurrencyAsync(Guid modelId);
    }
}
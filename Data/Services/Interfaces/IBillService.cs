using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.Services.Interfaces
{
    public interface IBillService
    {
        Task<List<BillDto>> GetAllBillsAsync();
        Task<BillDto> GetBillByIdAsync(Guid id);
        Task<BillDto> GetBillByNumberAsync(string billNumber);
        Task<bool> CreateBillAsync(CreateBillDto model);
        Task<bool> UpdateBillAsync(UpdateBillDto model);
        Task<bool> DeleteBillAsync(Guid modelId);
    }
}
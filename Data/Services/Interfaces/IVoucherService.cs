using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IVoucherService
    {
        Task<List<VoucherDto>> GetAllVouchersAsync();
        Task<VoucherDto> GetVoucherByIdAsync(Guid id);
        Task<bool> CreateVoucherAsync(VoucherDto model);
        Task<bool> UpdateVoucherAsync(VoucherDto model);
        Task<bool> DeleteVoucherAsync(Guid modelId);
    }
}
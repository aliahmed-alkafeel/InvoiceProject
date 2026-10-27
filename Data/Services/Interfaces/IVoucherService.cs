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
        Task<List<VoucherDto>> GetAllVouchersAsync(System.Threading.CancellationToken cts);
        Task<VoucherDto> GetVoucherByIdAsync(Guid id);
        Task<bool> CreateVoucherAsync(CreateVoucherDto model);
        Task<bool> UpdateVoucherAsync(UpdateVoucherDto model);
        Task<bool> DeleteVoucherAsync(Guid modelId);
    }
}
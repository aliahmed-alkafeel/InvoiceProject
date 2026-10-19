using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.Services.Interfaces
{
    public interface IAccountsTreeService
    {
        Task<List<AccountsTreeDto>> GetAllAccountsAsync();
        Task<AccountsTreeDto> GetAccountByIdAsync(Guid id);
        Task<bool> CreateAccountAsync(CreateAccountsTreeDto model);
        Task<bool> UpdateAccountAsync(UpdateAccountsTreeDto model);
        Task<bool> DeleteAccountAsync(Guid modelId);
    }
}
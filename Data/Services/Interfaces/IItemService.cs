using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IItemService
    {
        Task<List<ItemDto>> GetAllItemsAsync();
        Task<ItemDto> GetItemByIdAsync(Guid id);
        Task<bool> CreateItemAsync(ItemDto model);
        Task<bool> UpdateItemAsync(ItemDto model);
        Task<bool> DeleteItemAsync(Guid modelId);
    }
}

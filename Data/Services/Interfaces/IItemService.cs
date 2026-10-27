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
        Task<List<ItemDto>> GetAllItemsAsync(CancellationToken cts);
        Task<ItemDto> GetItemByIdAsync(Guid id);
        Task<bool> CreateItemAsync(CreateItemDto model);
        Task<bool> UpdateItemAsync(UpdateItemDto model);
        Task<bool> DeleteItemAsync(Guid modelId);
    }
}

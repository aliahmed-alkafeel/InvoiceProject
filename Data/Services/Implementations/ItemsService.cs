using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class ItemsService : IItemsService
    {
        private readonly IUnitOfWork _unitOfWork;

    public ItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            return await _unitOfWork.Items
                .Select()
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsActive = i.IsActive,
                    Notes = i.Notes,
                    CategoryGuid = i.CategoryGuid,
                })
                .ToListAsync();
        }

        public async Task<ItemDto> GetItemByIdAsync(Guid id)
        {
            var item = await _unitOfWork.Items
                .Select()
                .Where(i => i.Id == id)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsActive = i.IsActive,
                    Notes = i.Notes,
                    CategoryGuid = i.CategoryGuid
                })
                .FirstOrDefaultAsync();

            return item ?? throw new InvalidOperationException(
                $"Item with ID '{id}' was not found.");
        }

        public async Task<bool> CreateItemAsync(ItemDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var item = new Item
            {
                Name = model.Name,
                Price = model.Price,
                IsActive = model.IsActive,
                Notes = model.Notes,
                CategoryGuid = model.CategoryGuid
            };

            _unitOfWork.Items.Add(item);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(ItemDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var item = await _unitOfWork.Items
                .Select()
                .FirstOrDefaultAsync(i => i.Id == model.Id);

            if (item == null)
                throw new InvalidOperationException(
                    $"Item with ID '{model.Id}' was not found.");

            item.Name = model.Name;
            item.Price = model.Price;
            item.IsActive = model.IsActive;
            item.Notes = model.Notes;
            item.CategoryGuid = model.CategoryGuid;

            _unitOfWork.Items.Update(item);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(Guid modelId)
        {
            var item = await _unitOfWork.Items
                .Select()
                .FirstOrDefaultAsync(i => i.Id == modelId);

            if (item == null)
                throw new InvalidOperationException(
                    $"Item with ID '{modelId}' was not found.");

            _unitOfWork.Items.Delete(item);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }


}

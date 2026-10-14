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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;


    public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.Categories
                .Select()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    Notes = c.Notes
                })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.Categories
                .Select()
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    Notes = c.Notes
                })
                .FirstOrDefaultAsync();

            return category ?? throw new KeyNotFoundException(
                $"Category with ID '{id}' was not found.");
        }

        public async Task<bool> CreateCategoryAsync(CategoryDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var category = new Category
            {
                Name = model.Name,
                IsActive = model.IsActive,
                Notes = model.Notes
            };

            _unitOfWork.Categories.Add(category);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var category = await _unitOfWork.Categories
                .Select()
                .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (category == null)
                throw new InvalidOperationException(
                    $"Category with ID '{model.Id}' was not found.");

            category.Name = model.Name;
            category.IsActive = model.IsActive;
            category.Notes = model.Notes;

            _unitOfWork.Categories.Update(category);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategoryAsync(Guid modelId)
        {
            var category = await _unitOfWork.Categories
                .Select()
                .FirstOrDefaultAsync(c => c.Id == modelId);

            if (category == null)
                throw new InvalidOperationException(
                    $"Category with ID '{modelId}' was not found.");

            _unitOfWork.Categories.Delete(category);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }


}

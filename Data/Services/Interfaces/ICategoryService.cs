using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<bool> CreateCategoryAsync(CategoryDto model);
        Task<bool> UpdateCategoryAsync(CategoryDto model);
        Task<bool> DeleteCategoryAsync(Guid modelId);
    }
}

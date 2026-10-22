using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync(CancellationToken cts);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<bool> CreateCategoryAsync(CreateCategoryDto model);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto model);
        Task<bool> DeleteCategoryAsync(Guid modelId);
    }
}

using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrencyService _currencyService;

        public ItemService(IUnitOfWork unitOfWork, ICurrencyService currencyService)
        {
            _unitOfWork = unitOfWork;
            _currencyService = currencyService;
        }

        public async Task<List<ItemDto>> GetAllItemsAsync(System.Threading.CancellationToken cts)
        {
            return await _unitOfWork.Items
                .NoTrackingSelect().Include(i => i.Category)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    IsActive = i.IsActive,
                    Notes = i.Notes,
                    Category = new CategoryDto
                    {
                        Id = i.Category.Id,
                        Name = i.Category.Name,
                        IsActive = i.Category.IsActive
                    },
                })
                .ToListAsync(cts);
        }

        public async Task<ItemDto> GetItemByIdAsync(Guid id)
        {
            var item = await _unitOfWork.Items
                .NoTrackingSelect()
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
                $"لم يتم العثور على المادة بالمعرّف '{id}'.");
        }

        public async Task<bool> CreateItemAsync(CreateItemDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات المادة مطلوبة.");

            // لا يُضاف أي سجل جديد ما لم توجد عملة رئيسية واحدة بالضبط.
            await _currencyService.EnsureExactlyOneMainCurrencyAsync("إضافة المادة");

            var item = new Item
            {
                Name = model.Name,
                Price = model.Price.Value,
                IsActive = model.IsActive,
                Notes = model.Notes,
                CategoryGuid = model.CategoryGuid
            };

            _unitOfWork.Items.Add(item);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(UpdateItemDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات المادة مطلوبة.");

            var item = await _unitOfWork.Items
                .Select()
                .FirstOrDefaultAsync(i => i.Id == model.Id);

            if (item == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على المادة بالمعرّف '{model.Id}'.");

            await EnsureCategoryCanBeAssignedAsync(
              model.CategoryGuid,
              model.IsActive);
            item.Name = model.Name;
            item.Price = model.Price.Value;
            item.IsActive = model.IsActive;
            item.Notes = model.Notes;
            item.CategoryGuid = model.CategoryGuid;

            _unitOfWork.Items.Update(item);

            // الحفظ بدون تغيير فعلي لا يُعد فشلاً؛ الأخطاء الحقيقية تُرمى كاستثناءات.
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private async Task EnsureCategoryCanBeAssignedAsync(
            Guid categoryGuid,
            bool activateItem)
        {
            var category = await _unitOfWork.Categories
                .NoTrackingSelect()
                .Where(c => c.Id == categoryGuid)
                .Select(c => new
                {
                    c.Id,
                    c.IsActive
                })
                .FirstOrDefaultAsync();

            if (category == null)
                throw new InvalidOperationException(
                    "التصنيف المحدد غير موجود أو تم حذفه. يرجى اختيار تصنيف صالح.");

            if (activateItem && !category.IsActive)
                throw new InvalidOperationException(
                    "لا يمكن تفعيل المادة لأن التصنيف المرتبط بها غير فعال. يرجى تفعيل التصنيف أولاً.");
        }

        public async Task<bool> DeleteItemAsync(Guid modelId)
        {
            var item = await _unitOfWork.Items
                .Select()
                .FirstOrDefaultAsync(i => i.Id == modelId);

            if (item == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على المادة بالمعرّف '{modelId}'.");

            // التحقق من ارتباط المادة بأي بند فاتورة.
            var isUsedInBills = await _unitOfWork.BillItems
                .NoTrackingSelect()
                .AnyAsync(bi => bi.ItemGuid == modelId);

            if (isUsedInBills)
                throw new InvalidOperationException(
                    "لا يمكن حذف المادة لأنها مرتبطة بفاتورة أو أكثر.");

            _unitOfWork.Items.Delete(item);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
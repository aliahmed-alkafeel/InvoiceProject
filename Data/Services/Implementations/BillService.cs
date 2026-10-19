using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BillDto>> GetAllBillsAsync()
        {
            return await _unitOfWork.Bills
                .Select()
                .OrderByDescending(b => b.Date)
                .Select(b => new BillDto
                {
                    Id = b.Id,
                    BillNumber = b.BillNumber,
                    BillType = b.BillType,
                    AccountTreeGuid = b.AccountTreeGuid,
                    CurrencyGuid = b.CurrencyGuid,
                    CurrencyEqualValue = b.CurrencyEqualValue,
                    Date = b.Date,
                    Notes = b.Notes,
                    AccountTree = new AccountsTreeDto
                    {
                        Id = b.AccountTree.Id,
                        AccountCode = b.AccountTree.AccountCode,
                        AccountName = b.AccountTree.AccountName
                    },
                    Currency = new CurrencyDto
                    {
                        Id = b.Currency.Id,
                        CurrencyName = b.Currency.CurrencyName,
                        CurrencySymbol = b.Currency.CurrencySymbol
                    }
                })
                .ToListAsync();
        }

        public async Task<BillDto> GetBillByIdAsync(Guid id)
        {
            var bill = await _unitOfWork.Bills
                .Select()
                .Where(b => b.Id == id)
                .Select(b => new BillDto
                {
                    Id = b.Id,
                    BillNumber = b.BillNumber,
                    BillType = b.BillType,
                    AccountTreeGuid = b.AccountTreeGuid,
                    CurrencyGuid = b.CurrencyGuid,
                    CurrencyEqualValue = b.CurrencyEqualValue,
                    Date = b.Date,
                    Notes = b.Notes
                })
                .FirstOrDefaultAsync();

            if (bill == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الفاتورة بالمعرّف '{id}'.");

            bill.BillItems = await _unitOfWork.BillItems
                .Select()
                .Where(bi => bi.BillGuid == id)
                .Select(bi => new BillItemDto
                {
                    Id = bi.Id,
                    BillGuid = bi.BillGuid,
                    ItemGuid = bi.ItemGuid,
                    Qty = bi.Qty,
                    Price = bi.Price,
                    Notes = bi.Notes,
                    Item = new ItemDto
                    {
                        Id = bi.Item.Id,
                        Name = bi.Item.Name
                    }
                })
                .ToListAsync();

            return bill;
        }

        public async Task<bool> CreateBillAsync(CreateBillDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات الفاتورة مطلوبة.");

            var bill = new Bill
            {
                BillNumber = model.BillNumber,
                BillType = model.BillType,
                AccountTreeGuid = model.AccountTreeGuid,
                CurrencyGuid = model.CurrencyGuid,
                CurrencyEqualValue = model.CurrencyEqualValue,
                Date = model.Date,
                Notes = model.Notes
            };

            foreach (var item in model.BillItems)
            {
                bill.BillItems.Add(new BillItem
                {
                    ItemGuid = item.ItemGuid,
                    Qty = item.Qty,
                    Price = item.Price,
                    Notes = item.Notes
                });
            }

            _unitOfWork.Bills.Add(bill);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBillAsync(UpdateBillDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "بيانات الفاتورة مطلوبة.");

            var bill = await _unitOfWork.Bills
                .Select()
                .Include(b => b.BillItems)
                .FirstOrDefaultAsync(b => b.Id == model.Id);

            if (bill == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الفاتورة بالمعرّف '{model.Id}'.");

            bill.BillNumber = model.BillNumber;
            bill.BillType = model.BillType;
            bill.AccountTreeGuid = model.AccountTreeGuid;
            bill.CurrencyGuid = model.CurrencyGuid;
            bill.CurrencyEqualValue = model.CurrencyEqualValue;
            bill.Date = model.Date;
            bill.Notes = model.Notes;

            // استبدال المواد القديمة بالجديدة
            foreach (var old in bill.BillItems.ToList())
                _unitOfWork.BillItems.Delete(old);

            foreach (var item in model.BillItems)
            {
                bill.BillItems.Add(new BillItem
                {
                    ItemGuid = item.ItemGuid,
                    Qty = item.Qty,
                    Price = item.Price,
                    Notes = item.Notes
                });
            }

            _unitOfWork.Bills.Update(bill);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBillAsync(Guid modelId)
        {
            var bill = await _unitOfWork.Bills
                .Select()
                .Include(b => b.BillItems)
                .FirstOrDefaultAsync(b => b.Id == modelId);

            if (bill == null)
                throw new InvalidOperationException(
                    $"لم يتم العثور على الفاتورة بالمعرّف '{modelId}'.");

            foreach (var item in bill.BillItems.ToList())
                _unitOfWork.BillItems.Delete(item);

            _unitOfWork.Bills.Delete(bill);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
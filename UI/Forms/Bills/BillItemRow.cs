using Models.DTOs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI.Forms.Bills
{
    /// <summary>
    /// صف بند فاتورة يُعرض ويُعدَّل مباشرة داخل الشبكة (Inline Edit).
    /// </summary>
    public class BillItemRow : INotifyPropertyChanged
    {
        private Guid _itemGuid;
        private decimal _qty;
        private decimal _price;
        private decimal _total;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid Id { get; set; }

        public Guid BillGuid { get; set; }

        public string Notes { get; set; }

        /// <summary>
        /// المادة المختارة، تُحدَّث تلقائياً عند تغيير المادة داخل الشبكة.
        /// </summary>
        public ItemDto Item { get; set; }

        public Guid ItemGuid
        {
            get { return _itemGuid; }
            set
            {
                if (_itemGuid == value)
                    return;

                _itemGuid = value;
                OnPropertyChanged(nameof(ItemGuid));
            }
        }

        public decimal Qty
        {
            get { return _qty; }
            set
            {
                if (_qty == value)
                    return;

                _qty = value;
                UpdateTotal();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price == value)
                    return;

                _price = value;
                UpdateTotal();
            }
        }

        /// <summary>
        /// إجمالي البند (الكمية × السعر).
        /// </summary>
        public decimal Total
        {
            get { return _total; }
            set
            {
                if (_total == value)
                    return;

                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        /// <summary>
        /// تطبيق بيانات المادة المختارة على الصف (الاسم والسعر الافتراضي).
        /// </summary>
        public void ApplyItem(ItemDto item)
        {
            Item = item;

            if (item != null && item.Price.HasValue)
                Price = item.Price.Value;
        }

        public static BillItemRow FromDto(BillItemDto dto)
        {
            if (dto == null)
                return null;

            return new BillItemRow
            {
                Id = dto.Id,
                BillGuid = dto.BillGuid,
                ItemGuid = dto.ItemGuid,
                Qty = dto.Qty,
                Price = dto.Price,
                Notes = dto.Notes,
                Item = dto.Item
            };
        }

        public BillItemDto ToDto()
        {
            return new BillItemDto
            {
                Id = Id,
                BillGuid = BillGuid,
                ItemGuid = ItemGuid,
                Qty = Qty,
                Price = Price,
                Notes = Notes,
                Item = Item
            };
        }

        private void UpdateTotal()
        {
            Total = Qty * Price;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

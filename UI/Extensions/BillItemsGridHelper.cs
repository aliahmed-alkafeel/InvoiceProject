using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Extensions
{
    /// <summary>
    /// إعداد شبكة بنود الفاتورة للتعديل المباشر (Inline Edit).
    /// </summary>
    public static class BillItemsGridHelper
    {
        /// <summary>
        /// إعداد أعمدة الشبكة كاملة (المادة، الكمية، السعر، الإجمالي) وإرجاع قاموس المواد.
        /// </summary>
        public static IDictionary<Guid, ItemDto> ConfigureGrid(
            GridColumn colItem,
            GridColumn colQty,
            GridColumn colPrice,
            GridColumn colTotal,
            IEnumerable<ItemDto> items)
        {
            var list = items.Where(i => i != null).ToList();

            colItem.ColumnEdit = new RepositoryItemGridLookUpEdit
            {
                DataSource = list,
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoComplete = true,
                NullText = "اختر المادة"
            };
            colItem.OptionsColumn.AllowEdit = true;

            ConfigureNumericColumn(colQty);
            ConfigureNumericColumn(colPrice);

            // عمود غير مرتبط يحسب الإجمالي تلقائياً (اسم الحقل غير موجود في الـ DTO).
            colTotal.FieldName = "Total";
            colTotal.UnboundType = UnboundColumnType.Decimal;
            colTotal.UnboundExpression = "[Qty] * [Price]";
            colTotal.OptionsColumn.AllowEdit = false;
            colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotal.DisplayFormat.FormatString = "N2";

            return list.ToDictionary(i => i.Id);
        }

        private static void ConfigureNumericColumn(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = true;
            column.ColumnEdit = new RepositoryItemSpinEdit
            {
                IsFloatValue = true,
                MinValue = 0m,
                MaxValue = 1000000m
            };
        }

        /// <summary>
        /// تطبيق المادة المختارة على الصف (المادة والسعر الافتراضي).
        /// </summary>
        public static void ApplyItemToRow(BillItemDto row, IDictionary<Guid, ItemDto> lookup)
        {
            ItemDto item = null;
            lookup?.TryGetValue(row.ItemGuid, out item);

            row.Item = item;

            if (item?.Price != null)
                row.Price = item.Price.Value;
        }
    }
}
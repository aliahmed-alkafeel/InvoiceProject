using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Forms.Bills;

namespace UI.Extensions
{
    /// <summary>
    /// أدوات مشتركة لإعداد شبكة بنود الفاتورة للتعديل المباشر داخل الشبكة (Inline Edit).
    /// </summary>
    public static class BillItemsGridHelper
    {
        /// <summary>
        /// إعداد عمود المادة (قائمة بحث) وإرجاع قاموس المواد للربط السريع.
        /// </summary>
        public static IDictionary<Guid, ItemDto> ConfigureItemColumn(GridColumn column, IEnumerable<ItemDto> items)
        {
            var list = (items ?? Enumerable.Empty<ItemDto>())
                .Where(i => i != null)
                .ToList();

            var lookup = new Dictionary<Guid, ItemDto>();

            foreach (var item in list)
                lookup[item.Id] = item;

            var itemLookup = new RepositoryItemGridLookUpEdit
            {
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoComplete = true,
                NullText = "اختر المادة"
            };

            itemLookup.DataSource = list;

            column.ColumnEdit = itemLookup;
            column.OptionsColumn.AllowEdit = true;

            return lookup;
        }

        /// <summary>
        /// إعداد عمود رقمي (الكمية / السعر) للتعديل المباشر.
        /// </summary>
        public static void ConfigureNumericColumn(GridColumn column, decimal minValue, decimal maxValue)
        {
            column.OptionsColumn.AllowEdit = true;

            var editor = new RepositoryItemSpinEdit
            {
                IsFloatValue = true,
                MinValue = minValue,
                MaxValue = maxValue
            };

            column.ColumnEdit = editor;
        }

        /// <summary>
        /// تحديث بيانات المادة في الصف عند تغييرها داخل الشبكة.
        /// </summary>
        public static bool ApplyItemToRow(BillItemRow row, IDictionary<Guid, ItemDto> lookup)
        {
            if (row == null)
                return false;

            ItemDto item;

            if (row.ItemGuid == Guid.Empty || lookup == null || !lookup.TryGetValue(row.ItemGuid, out item))
            {
                row.Item = null;
                return false;
            }

            row.ApplyItem(item);

            return true;
        }
    }
}

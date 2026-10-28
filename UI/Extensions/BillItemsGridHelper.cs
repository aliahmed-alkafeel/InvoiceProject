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
    public static class BillItemsGridHelper
    {
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
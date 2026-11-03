using Models.DTOs;
using System;
using System.Collections.Generic;

namespace UI.Extensions
{
    internal static class BillItemsGridHelper
    {
        public static void ApplyItemToRow(
            BillItemDto row,
            IDictionary<Guid, ItemDto> lookup,
            decimal currencyEqualValue)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            if (currencyEqualValue <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(currencyEqualValue),
                    "معامل تحويل العملة يجب أن يكون أكبر من صفر.");

            ItemDto item = null;
            lookup?.TryGetValue(row.ItemGuid, out item);

            row.Item = item;

            if (item?.Price != null)
            {
                row.Price = Math.Round(
                    item.Price.Value / currencyEqualValue,
                    6,
                    MidpointRounding.AwayFromZero);
            }
            else
            {
                row.Price = 0m;
            }
        }
    }
}
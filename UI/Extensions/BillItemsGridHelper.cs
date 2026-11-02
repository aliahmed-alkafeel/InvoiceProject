using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Extensions
{
    internal static class BillItemsGridHelper
    {
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

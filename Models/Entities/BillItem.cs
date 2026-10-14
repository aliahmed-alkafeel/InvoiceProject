using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BillItem : BaseEntity
    {
        public Guid BillGuid { get; set; }

        public Guid ItemGuid { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }
        [ForeignKey(nameof(BillGuid))]
        public Bill Bill { get; set; }
        [ForeignKey(nameof(ItemGuid))]
        public Item Item { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateBillItemDto : BaseDto
    {
        public Guid BillGuid { get; set; }

        public Guid ItemGuid { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }
    }
}

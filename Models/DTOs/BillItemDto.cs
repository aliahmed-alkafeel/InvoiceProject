using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class BillItemDto : BaseDto
    {
        public Guid BillGuid { get; set; }

        public Guid ItemGuid { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }
        public BillDto Bill { get; set; }
        public ItemDto Item { get; set; }
    }
}

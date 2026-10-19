using Models.DTOs;
using Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class BillDto : BaseDto
    {
        public string BillNumber { get; set; }
        public BillType BillType { get; set; } 
        public Guid AccountTreeGuid { get; set; }
        public Guid CurrencyGuid { get; set; }
        public decimal CurrencyEqualValue { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public AccountsTreeDto AccountTree { get; set; }
        public CurrencyDto Currency { get; set; }
        public ICollection<BillItemDto> BillItems { get; set; } = new HashSet<BillItemDto>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CurrencyDto : BaseDto
    {
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        public decimal CurrencyEqual { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BillDto> Bills { get; set; } = new HashSet<BillDto>(); 
        public ICollection<VoucherDto> Vouchers { get; set; } = new HashSet<VoucherDto>();
    }
}

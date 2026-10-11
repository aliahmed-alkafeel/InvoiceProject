using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Currency : BaseEntity
    {
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        public decimal CurrencyEqual { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>(); 
        public ICollection<Voucher> Vouchers { get; set; } = new HashSet<Voucher>();
    }
}

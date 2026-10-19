using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class VoucherDto : BaseDto
    {
        public Guid AccountTreeGuid { get; set; }

        public string VoucherNumber { get; set; }

        public VoucherType VoucherType { get; set; }

        public decimal Amount { get; set; }

        public Guid CurrencyGuid { get; set; }

        public decimal CurrencyEqualValue { get; set; }

        public DateTime Date { get; set; }
        public AccountsTreeDto AccountTree { get; set; }
        public CurrencyDto Currency { get; set; }
    }

}

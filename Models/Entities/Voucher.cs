using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Voucher : BaseEntity
    {
        public Guid AccountTreeGuid { get; set; }

        public string VoucherNumber { get; set; }

        public VoucherType VoucherType { get; set; }

        public decimal Amount { get; set; }

        public Guid CurrencyGuid { get; set; }

        public decimal CurrencyEqualValue { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey(nameof(AccountTreeGuid))]
        public AccountsTree AccountTree { get; set; }
        [ForeignKey(nameof(CurrencyGuid))]
        public Currency Currency { get; set; }
    }
    public enum VoucherType
    {
        Receipt = 0,
        Payment = 1
    }
}

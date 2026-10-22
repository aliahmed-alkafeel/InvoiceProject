using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Bill : BaseEntity
    {
        public int BillNumber { get; set; }

        public string BillType { get; set; } 

        public Guid AccountTreeGuid { get; set; }

        public Guid CurrencyGuid { get; set; }

        public decimal CurrencyEqualValue { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey(nameof(AccountTreeGuid))]
        public AccountsTree AccountTree { get; set; }

        [ForeignKey(nameof(CurrencyGuid))]
        public Currency Currency { get; set; }
        public ICollection<BillItem> BillItems { get; set; } = new HashSet<BillItem>();
    }
    public static class BillType
    {
        public const string In = "وارد";
        public const string Out = "صادر";

        public static readonly string[] All = { In, Out };
    }
}

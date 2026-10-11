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
    public class AccountsTree : BaseEntity
    {
        public Guid? ParentGuid { get; set; }

        public string AccountCode { get; set; }

        public string AccountName { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey(nameof(ParentGuid))]
        public AccountsTree Parent { get; set; }

        public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
        public ICollection<Voucher> Vouchers { get; set; } = new HashSet<Voucher>();
    }
}

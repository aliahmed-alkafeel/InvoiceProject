using Models.DTOs;
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
    public class AccountsTreeDto : BaseDto
    {
        public Guid? ParentGuid { get; set; }

        public string AccountCode { get; set; }

        public string AccountName { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsActive { get; set; }
        public AccountsTreeDto Parent { get; set; }

        public ICollection<BillDto> Bills { get; set; } = new HashSet<BillDto>();
        public ICollection<VoucherDto> Vouchers { get; set; } = new HashSet<VoucherDto>();
    }
}

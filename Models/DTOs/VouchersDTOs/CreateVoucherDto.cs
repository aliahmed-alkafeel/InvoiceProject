using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateVoucherDto : BaseDto
    {
        public Guid? AccountTreeGuid { get; set; }
        public VoucherType? VoucherType { get; set; }
        public decimal? Amount { get; set; }
        public Guid CurrencyGuid { get; set; }
    }
}


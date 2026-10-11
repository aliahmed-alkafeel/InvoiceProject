using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations
{
    internal class BillConfiguration : EntityTypeConfiguration<Bill>
    {
        public BillConfiguration()
        {
            Property(x => x.BillNumber)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.CurrencyEqualValue)
                .IsRequired()
                .HasPrecision(18, 6);
        }
    }
}

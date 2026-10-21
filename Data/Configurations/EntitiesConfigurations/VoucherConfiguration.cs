using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class VoucherConfiguration : EntityTypeConfiguration<Voucher>
    {
        public VoucherConfiguration()
        {
            Property(x => x.VoucherNumber)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.VoucherType)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Amount)
                .IsRequired()
                .HasPrecision(18, 2);


            Property(x => x.CurrencyEqualValue)
                .IsRequired()
                .HasPrecision(18, 6); 
    
        }
    }
}

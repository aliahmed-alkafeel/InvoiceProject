using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            Property(x => x.CurrencyName)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.CurrencySymbol)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.CurrencyEqual)
                .IsRequired()
                .HasPrecision(18, 6);
        }
    }
}

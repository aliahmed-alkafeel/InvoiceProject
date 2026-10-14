using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class BillItemsConfiguration : EntityTypeConfiguration<BillItem>
    {
        public BillItemsConfiguration()
        {
            Property(x => x.Qty)
                .IsRequired()
                .HasPrecision(18, 3);  

            Property(x => x.Price)
                .IsRequired()
                .HasPrecision(18, 2); 
        }
    }
}

using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    internal class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            Property(x => x.Price).IsRequired().HasPrecision(18, 2);
        }
    }
}

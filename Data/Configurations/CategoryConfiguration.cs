using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations
{
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}

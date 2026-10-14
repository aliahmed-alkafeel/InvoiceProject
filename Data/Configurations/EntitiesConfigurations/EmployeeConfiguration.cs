using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {

            Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(512);

        }
    }
}

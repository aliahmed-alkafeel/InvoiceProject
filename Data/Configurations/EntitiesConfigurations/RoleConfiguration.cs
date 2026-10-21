using System.Data.Entity.ModelConfiguration;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(x => x.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

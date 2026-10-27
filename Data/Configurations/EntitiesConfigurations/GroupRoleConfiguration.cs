using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Configurations.EntitiesConfigurations
{
    internal class GroupRoleConfiguration : EntityTypeConfiguration<GroupRole>
    {
        public GroupRoleConfiguration()
        {
            Property(gr => gr.GroupGuid)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_GroupRole_Group_Role_Del", 1) { IsUnique = true }));

            Property(gr => gr.RoleGuid)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_GroupRole_Group_Role_Del", 2) { IsUnique = true }));

            Property(gr => gr.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_GroupRole_Group_Role_Del", 3) { IsUnique = true }));

            Property(gr => gr.DeletedAt)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_GroupRole_Group_Role_Del", 4) { IsUnique = true }));
        }
    }
}

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
                .HasMaxLength(20)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Employee_Phone_Del", 1) { IsUnique = true }));

            Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Employee_Email_Del", 1) { IsUnique = true }));

            Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Employee_Username_Del", 1) { IsUnique = true }));

            Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(512);

            var phoneIsDeletedIndex = new IndexAttribute("UX_Employee_Phone_Del", 2) { IsUnique = true };
            var phoneDeletedAtIndex = new IndexAttribute("UX_Employee_Phone_Del", 3) { IsUnique = true };
            var emailIsDeletedIndex = new IndexAttribute("UX_Employee_Email_Del", 2) { IsUnique = true };
            var emailDeletedAtIndex = new IndexAttribute("UX_Employee_Email_Del", 3) { IsUnique = true };
            var usernameIsDeletedIndex = new IndexAttribute("UX_Employee_Username_Del", 2) { IsUnique = true };
            var usernameDeletedAtIndex = new IndexAttribute("UX_Employee_Username_Del", 3) { IsUnique = true };

            Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[] { phoneIsDeletedIndex, emailIsDeletedIndex, usernameIsDeletedIndex }));

            Property(e => e.DeletedAt)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[] { phoneDeletedAtIndex, emailDeletedAtIndex, usernameDeletedAtIndex }));

        }
    }
}

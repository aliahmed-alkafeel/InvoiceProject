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
    internal class BillConfiguration : EntityTypeConfiguration<Bill>
    {
        public BillConfiguration()
        {
            Property(x => x.BillType)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.BillNumber)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Bill_Number_Del", 1) { IsUnique = true }));

            Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Bill_Number_Del", 2) { IsUnique = true }));

            Property(x => x.DeletedAt)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Bill_Number_Del", 3) { IsUnique = true }));

            Property(x => x.CurrencyEqualValue)
                .IsRequired()
                .HasPrecision(18, 6);
        }
    }
}

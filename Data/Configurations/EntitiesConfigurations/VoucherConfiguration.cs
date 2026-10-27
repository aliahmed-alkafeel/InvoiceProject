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
    internal class VoucherConfiguration : EntityTypeConfiguration<Voucher>
    {
        public VoucherConfiguration()
        {
            Property(x => x.VoucherType)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.VoucherNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Voucher_Number_Del", 1) { IsUnique = true }));

            Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Voucher_Number_Del", 2) { IsUnique = true }));

            Property(x => x.DeletedAt)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Voucher_Number_Del", 3) { IsUnique = true }));

            Property(x => x.Amount)
                .IsRequired()
                .HasPrecision(18, 2);


            Property(x => x.CurrencyEqualValue)
                .IsRequired()
                .HasPrecision(18, 6);

        }
    }
}

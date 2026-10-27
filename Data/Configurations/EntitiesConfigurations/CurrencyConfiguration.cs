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
    internal class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            Property(x => x.CurrencyName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Currency_Name_Del", 1) { IsUnique = true }));

            Property(x => x.CurrencySymbol)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UX_Currency_Symbol_Del", 1) { IsUnique = true }));

            Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("UX_Currency_Name_Del", 2) { IsUnique = true },
                        new IndexAttribute("UX_Currency_Symbol_Del", 2) { IsUnique = true }
                    }));

            Property(x => x.DeletedAt)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("UX_Currency_Name_Del", 3) { IsUnique = true },
                        new IndexAttribute("UX_Currency_Symbol_Del", 3) { IsUnique = true }
                    }));

            Property(x => x.CurrencyEqual)
                .IsRequired()
                .HasPrecision(18, 6);
        }
    }
}

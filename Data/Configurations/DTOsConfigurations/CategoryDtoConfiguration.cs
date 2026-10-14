using FluentValidation;
using Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CategoryDtoConfiguration : BaseDtoConfiguration<CategoryDto>
    {
        public CategoryDtoConfiguration()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم التصنيف مطلوب")
                .MaximumLength(100).WithMessage("اسم التصنيف لا يزيد عن 100 حرف");
        }
    }
}
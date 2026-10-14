using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public abstract class BaseDtoConfiguration<T> : AbstractValidator<T> where T : BaseDto
    {
        protected BaseDtoConfiguration()
        {
            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("الملاحظات لا تزيد عن 500 حرف");
        }
    }
}
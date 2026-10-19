using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Extensions
{
    public static class ValidationHelper
    {
        public static bool IsValid<T>(AbstractValidator<T> validator, T dto, out string errors)
        {
            var result = validator.Validate(dto);
            errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage));
            return result.IsValid;
        }
    }
}

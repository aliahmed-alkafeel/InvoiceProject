using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateCategoryDtoConfiguration : BaseDtoConfiguration<UpdateCategoryDto>
    {
        public UpdateCategoryDtoConfiguration()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم التصنيف مطلوب")
                .MaximumLength(100).WithMessage("اسم التصنيف لا يزيد عن 100 حرف");
        }
    }
}

using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateCategoryDtoConfiguration : BaseDtoConfiguration<CreateCategoryDto>
    {
        public CreateCategoryDtoConfiguration()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم التصنيف مطلوب")
                .MaximumLength(100).WithMessage("اسم التصنيف لا يزيد عن 100 حرف");
        }
    }
}

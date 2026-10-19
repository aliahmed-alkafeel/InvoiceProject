using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateItemDtoConfiguration : BaseDtoConfiguration<UpdateItemDto>
    {
        public UpdateItemDtoConfiguration()
        {
            RuleFor(x => x.CategoryGuid)
                .NotEmpty().WithMessage("اختر التصنيف");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم المنتج مطلوب")
                .MaximumLength(150).WithMessage("اسم المنتج لا يزيد عن 150 حرف");

            RuleFor(x => x.Price).NotNull().WithMessage("السعر مطلوب")
                .GreaterThanOrEqualTo(0).WithMessage("السعر لا يكون سالبًا");
        }
    }
}

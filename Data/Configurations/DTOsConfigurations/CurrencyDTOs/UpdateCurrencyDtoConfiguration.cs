using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateCurrencyDtoConfiguration : BaseDtoConfiguration<UpdateCurrencyDto>
    {
        public UpdateCurrencyDtoConfiguration()
        {
            RuleFor(x => x.CurrencyName)
                .NotEmpty().WithMessage("اسم العملة مطلوب")
                .MaximumLength(50).WithMessage("اسم العملة لا يزيد عن 50 حرف");

            RuleFor(x => x.CurrencySymbol)
                .NotEmpty().WithMessage("رمز العملة مطلوب")
                .MaximumLength(10).WithMessage("رمز العملة لا يزيد عن 10 أحرف");

            RuleFor(x => x.CurrencyEqual)
                .GreaterThan(0).WithMessage("سعر الصرف يجب أن يكون أكبر من صفر");

            RuleFor(x => x.CurrencyEqual)
                .Equal(1).When(x => x.IsMain)
                .WithMessage("العملة الرئيسية سعر صرفها 1");
        }
    }
}

using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateVoucherDtoConfiguration : BaseDtoConfiguration<UpdateVoucherDto>
    {
        public UpdateVoucherDtoConfiguration()
        {
            RuleFor(x => x.VoucherNumber)
                .NotEmpty().WithMessage("رقم السند مطلوب")
                .MaximumLength(50).WithMessage("الحد الاقصى لطول رقم السند هو 50");

            RuleFor(x => x.VoucherType).NotNull().WithMessage("نوع السند مطلوب").IsInEnum().WithMessage("نوع السند غير صحيح");

            RuleFor(x => x.AccountTreeGuid).NotEmpty().WithMessage("اختر الحساب");
            RuleFor(x => x.CurrencyGuid).NotEmpty().WithMessage("اختر العملة");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("المبلغ يجب أن يكون أكبر من صفر");

            RuleFor(x => x.CurrencyEqualValue)
                .GreaterThan(0).WithMessage("سعر الصرف يجب أن يكون أكبر من صفر");

            RuleFor(x => x.Date).NotEmpty().WithMessage("التاريخ مطلوب");
        }
    }
}

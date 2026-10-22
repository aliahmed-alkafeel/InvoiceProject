using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateBillDtoConfiguration : BaseDtoConfiguration<CreateBillDto>
    {
        public CreateBillDtoConfiguration()
        {
            RuleFor(x => x.BillNumber)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.BillType).NotEmpty().WithMessage("نوع الفاتورة مطلوب")
                .Must(v => v == BillType.In || v == BillType.Out).WithMessage("نوع الفاتورة غير صحيح");

            RuleFor(x => x.AccountTreeGuid).NotEmpty().WithMessage("اختر الحساب");
            RuleFor(x => x.CurrencyGuid).NotEmpty().WithMessage("اختر العملة");

            RuleFor(x => x.CurrencyEqualValue).NotEmpty().WithMessage("سعر الصرف مطلوب")
                .GreaterThan(0).WithMessage("سعر الصرف يجب أن يكون أكبر من صفر");

            RuleFor(x => x.Date).NotEmpty().WithMessage("التاريخ مطلوب");

            RuleFor(x => x.BillItems)
                .NotEmpty().WithMessage("الفاتورة يجب أن تحتوي مادة واحدة على الأقل");

            RuleForEach(x => x.BillItems)
                .SetValidator(new BillItemDtoConfiguration());
        }
    }
}

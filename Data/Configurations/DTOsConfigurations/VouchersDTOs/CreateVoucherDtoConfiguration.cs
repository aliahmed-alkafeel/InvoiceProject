using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateVoucherDtoConfiguration : BaseDtoConfiguration<CreateVoucherDto>
    {
        public CreateVoucherDtoConfiguration() 
        { 
            RuleFor(x => x.VoucherType).NotNull().WithMessage("نوع السند مطلوب")
                .Must(v => v == VoucherType.Receipt || v == VoucherType.Payment).WithMessage("نوع السند غير صحيح");

            RuleFor(x => x.AccountTreeGuid).NotEmpty().WithMessage("اختر الحساب");
            RuleFor(x => x.CurrencyGuid).NotEmpty().WithMessage("اختر العملة");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("المبلغ يجب أن يكون أكبر من صفر");

        }
    }
}

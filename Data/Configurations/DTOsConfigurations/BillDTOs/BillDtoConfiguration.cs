using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations.DTOsConfigurations
{
    public class BillDtoConfiguration : BaseDtoConfiguration<BillDto>
    {
        public BillDtoConfiguration()
        {
            RuleFor(x => x.BillNumber)
                .NotEmpty().WithMessage("رقم الفاتورة مطلوب")
                .MaximumLength(50).WithMessage("الحد الاقصى لطول رقم الفاتورة هو 50");

            RuleFor(x => x.BillType).NotEmpty().WithMessage("نوع الفاتورة مطلوب")
                .IsInEnum().WithMessage("نوع الفاتورة غير صحيح");

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

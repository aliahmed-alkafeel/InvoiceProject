using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateBillItemDtoConfiguration : BaseDtoConfiguration<CreateBillItemDto>
    {
        public CreateBillItemDtoConfiguration()
        {
            RuleFor(x => x.ItemGuid).NotEmpty().WithMessage("اختر المادة");

            RuleFor(x => x.Qty).NotEmpty().WithMessage("الكمية مطلوبة")
                .GreaterThan(0).WithMessage("الكمية يجب أن تكون أكبر من صفر");

            RuleFor(x => x.Price).NotEmpty().WithMessage("السعر مطلوب")
                .GreaterThanOrEqualTo(0).WithMessage("السعر لا يكون سالبًا");
        }
    }
}

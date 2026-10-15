using FluentValidation;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models.DTOs
{
    public class BillItemDtoConfiguration : BaseDtoConfiguration<BillItemDto>
    {
        public BillItemDtoConfiguration()
        {
            RuleFor(x => x.ItemGuid).NotEmpty().WithMessage("اختر المادة");

            RuleFor(x => x.Qty).NotEmpty().WithMessage("الكمية مطلوبة")
                .GreaterThan(0).WithMessage("الكمية يجب أن تكون أكبر من صفر");

            RuleFor(x => x.Price).NotEmpty().WithMessage("السعر مطلوب")
                .GreaterThanOrEqualTo(0).WithMessage("السعر لا يكون سالبًا");
        }
    }
}
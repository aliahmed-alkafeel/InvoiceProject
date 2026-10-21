using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateEmployeeDtoConfiguration : BaseDtoConfiguration<UpdateEmployeeDto>
    {
        public UpdateEmployeeDtoConfiguration()
        {
            RuleFor(x => x.GroupGuid).NotEmpty().WithMessage("اختر المجموعة");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("الاسم الأول مطلوب")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("اسم العائلة مطلوب")
                .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20)
                .Matches(@"^[0-9+\-\s]+$").When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("رقم الهاتف غير صحيح");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("الإيميل غير صحيح")
                .MaximumLength(100);

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("اسم المستخدم مطلوب")
                .MinimumLength(3).WithMessage("اسم المستخدم 3 أحرف على الأقل")
                .MaximumLength(50);

            RuleFor(x => x.Password)
                .MinimumLength(6).When(x => !string.IsNullOrWhiteSpace(x.Password))
                .WithMessage("كلمة المرور 6 أحرف على الأقل");

            RuleFor(x => x.EmployeeStartingDate).NotEmpty().WithMessage("تاريخ التعيين مطلوب");

            RuleFor(x => x.EmployeeEndingDate)
                .GreaterThanOrEqualTo(x => x.EmployeeStartingDate)
                .When(x => x.EmployeeEndingDate.HasValue)
                .WithMessage("تاريخ الانتهاء قبل تاريخ التعيين");
        }
    }
}

using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateAccountsTreeDtoConfiguration : BaseDtoConfiguration<UpdateAccountsTreeDto>
    {
        public UpdateAccountsTreeDtoConfiguration()
        {
            RuleFor(x => x.AccountCode)
                .NotEmpty().WithMessage("رمز الحساب مطلوب")
                .MaximumLength(50).WithMessage("رمز الحساب لا يتعدى 50 رقم")
                .Matches(@"^\d+$").WithMessage("رمز الحساب غير صحيح");

            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("اسم الحساب مطلوب")
                .MaximumLength(200).WithMessage("اسم الحساب لا يتعدى 200 حرف");
        }
    }
}

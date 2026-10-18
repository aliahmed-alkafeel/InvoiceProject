using FluentValidation;
using Models.DTOs;
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
    public class AccountsTreeDtoConfiguration : BaseDtoConfiguration<AccountsTreeDto>
    {
        public AccountsTreeDtoConfiguration()
        {
            RuleFor(x => x.AccountCode)
                .NotEmpty().WithMessage("رمز الحساب مطلوب")
                .MaximumLength(50).WithMessage("رمز الحساب لا يزيد عن 50 حرف")
                .Matches(@"^\d+$").WithMessage("رمز الحساب أرقام فقط");

            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("اسم الحساب مطلوب")
                .MaximumLength(200).WithMessage("اسم الحساب لا يزيد عن 200 حرف");

            RuleFor(x => x.ParentGuid)
                .NotEqual(x => (Guid?)x.Id).When(x => x.ParentGuid.HasValue)
                .WithMessage("الحساب لا يمكن أن يكون أبًا لنفسه");
        }
    }
}
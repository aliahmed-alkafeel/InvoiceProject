using Data.Configurations.DTOsConfigurations;
using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Configurations.DTOsConfigurations
{
    public class RoleDtoConfiguration : BaseDtoConfiguration<RoleDto>
    {
        public RoleDtoConfiguration()
        {
            RuleFor(x => x.RoleName).NotNull().WithMessage("اسم الصلاحية مطلوب")
                .IsInEnum().WithMessage("الصلاحية غير صحيحة");
        }
    }
}
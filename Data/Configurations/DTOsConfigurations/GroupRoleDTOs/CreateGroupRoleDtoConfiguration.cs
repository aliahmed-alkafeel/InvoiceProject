using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateGroupRoleDtoConfiguration : BaseDtoConfiguration<CreateGroupRoleDto>
    {
        public CreateGroupRoleDtoConfiguration()
        {
            RuleFor(x => x.GroupGuid).NotEmpty().WithMessage("اختر المجموعة");
            RuleFor(x => x.RoleGuid).NotEmpty().WithMessage("اختر الصلاحية");
        }
    }
}

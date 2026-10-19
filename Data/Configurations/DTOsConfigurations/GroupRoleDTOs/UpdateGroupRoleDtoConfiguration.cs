using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateGroupRoleDtoConfiguration : BaseDtoConfiguration<UpdateGroupRoleDto>
    {
        public UpdateGroupRoleDtoConfiguration()
        {
            RuleFor(x => x.GroupGuid).NotEmpty().WithMessage("اختر المجموعة");
            RuleFor(x => x.RoleGuid).NotEmpty().WithMessage("اختر الصلاحية");
        }
    }
}

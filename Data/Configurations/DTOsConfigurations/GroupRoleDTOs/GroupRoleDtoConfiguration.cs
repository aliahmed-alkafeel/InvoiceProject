using Data.Configurations.DTOsConfigurations;
using FluentValidation;
using Models.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Configurations.DTOsConfigurations
{
    public class GroupRoleDtoConfiguration : BaseDtoConfiguration<GroupRoleDto>
    {
        public GroupRoleDtoConfiguration()
        {
            RuleFor(x => x.GroupGuid).NotEmpty().WithMessage("اختر المجموعة");
            RuleFor(x => x.RoleGuid).NotEmpty().WithMessage("اختر الصلاحية");
        }
    }
}
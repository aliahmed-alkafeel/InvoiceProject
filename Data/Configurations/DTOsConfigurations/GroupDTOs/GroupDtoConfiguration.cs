using Data.Configurations.DTOsConfigurations;
using FluentValidation;
using Models.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Configurations.DTOsConfigurations
{
    public class GroupDtoConfiguration : BaseDtoConfiguration<GroupDto>
    {
        public GroupDtoConfiguration()
        {
            RuleFor(x => x.GroupName)
                .NotEmpty().WithMessage("اسم المجموعة مطلوب")
                .MaximumLength(100);
        }
    }
}

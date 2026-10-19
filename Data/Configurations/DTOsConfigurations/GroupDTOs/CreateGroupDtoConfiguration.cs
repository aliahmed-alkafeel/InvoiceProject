using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateGroupDtoConfiguration : BaseDtoConfiguration<CreateGroupDto>
    {
        public CreateGroupDtoConfiguration()
        {
            RuleFor(x => x.GroupName)
                .NotEmpty().WithMessage("اسم المجموعة مطلوب")
                .MaximumLength(100);
        }
    }
}

using FluentValidation;
using Models.DTOs;
using System;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateGroupDtoConfiguration : BaseDtoConfiguration<UpdateGroupDto>
    {
        public UpdateGroupDtoConfiguration()
        {
            RuleFor(x => x.GroupName)
                .NotEmpty().WithMessage("اسم المجموعة مطلوب")
                .MaximumLength(100);
        }
    }
}

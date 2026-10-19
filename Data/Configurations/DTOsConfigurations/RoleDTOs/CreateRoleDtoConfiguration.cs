using FluentValidation;
using Models.DTOs;
using Models.Entities;

namespace Data.Configurations.DTOsConfigurations
{
    public class CreateRoleDtoConfiguration : BaseDtoConfiguration<CreateRoleDto>
    {
        public CreateRoleDtoConfiguration()
        {
            RuleFor(x => x.RoleName).NotNull().WithMessage("اسم الصلاحية مطلوب")
                .IsInEnum().WithMessage("الصلاحية غير صحيحة");
        }
    }
}

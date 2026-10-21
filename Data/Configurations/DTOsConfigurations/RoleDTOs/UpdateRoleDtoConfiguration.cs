using FluentValidation;
using Models.DTOs;
using Models.Entities;
using System.Linq;

namespace Data.Configurations.DTOsConfigurations
{
    public class UpdateRoleDtoConfiguration : BaseDtoConfiguration<UpdateRoleDto>
    {
        public UpdateRoleDtoConfiguration()
        {
            RuleFor(x => x.RoleName).NotNull().WithMessage("اسم الصلاحية مطلوب")
                .Must(v => UserRole.All.Contains(v)).WithMessage("الصلاحية غير صحيحة");
        }
    }
}

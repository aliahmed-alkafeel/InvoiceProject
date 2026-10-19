using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class UpdateGroupDto : BaseDto
    {
        public string GroupName { get; set; }
        public ICollection<GroupRoleDto> GroupRoles { get; set; } = new HashSet<GroupRoleDto>();
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class GroupDto : BaseDto
    {
        public string GroupName { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new HashSet<EmployeeDto>();
        public ICollection<GroupRoleDto> GroupRoles { get; set; } = new HashSet<GroupRoleDto>();
    }

}

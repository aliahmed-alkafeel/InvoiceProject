using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models.DTOs
{
    public class GroupDto : BaseDto
    {
        public string GroupName { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new HashSet<EmployeeDto>();
        public ICollection<GroupRoleDto> GroupRoles { get; set; } = new HashSet<GroupRoleDto>();

        public string RolesText =>
            string.Join("، ",
                GroupRoles
                    .Where(gr => gr.Role != null)
                    .Select(gr => gr.Role.RoleName)
                    .Distinct());
    }

}

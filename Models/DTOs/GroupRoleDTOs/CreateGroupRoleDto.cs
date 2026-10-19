using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTOs
{
    public class CreateGroupRoleDto : BaseDto
    {
        public Guid RoleGuid { get; set; }
        public Guid GroupGuid { get; set; }
    }
}

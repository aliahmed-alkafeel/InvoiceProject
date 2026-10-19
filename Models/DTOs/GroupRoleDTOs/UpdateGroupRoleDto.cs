using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTOs
{
    public class UpdateGroupRoleDto : BaseDto
    {
        public Guid RoleGuid { get; set; }
        public Guid GroupGuid { get; set; }
    }
}

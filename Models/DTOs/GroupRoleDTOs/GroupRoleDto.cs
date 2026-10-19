using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.DTOs
{
    public class GroupRoleDto : BaseDto
    {
        public Guid RoleGuid { get; set; }  
        public Guid GroupGuid { get; set; }
        [ForeignKey(nameof(GroupGuid))]
        public GroupDto Group { get; set; }
        [ForeignKey(nameof(RoleGuid))]
        public RoleDto Role { get; set; } 
    }
}

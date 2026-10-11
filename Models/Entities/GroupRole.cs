using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Entities
{
    public class GroupRole : BaseEntity
    {
        public Guid RoleGuid { get; set; }  
        public Guid GroupGuid { get; set; }
        [ForeignKey(nameof(GroupGuid))]
        public Group Group { get; set; }
        [ForeignKey(nameof(RoleGuid))]
        public Role Role { get; set; } 
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public ICollection<GroupRole> GroupRoles { get; set; } = new HashSet<GroupRole>();
    }
    public enum InitUserGroup
    {
        Unclassified = 0,
        Administrator,
        Manager,
        Cashier,
        Accountant
    }

}

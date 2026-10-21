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
    public static class InitUserGroup
    {
        public const string Unclassified = "غير مصنف";
        public const string Administrator = "المسؤول";
        public const string Manager = "المدير";
        public const string Cashier = "الكاشير";
        public const string Accountant = "المحاسب";

        public static readonly string[] All =
        {
            Unclassified,
            Administrator,
            Manager,
            Cashier,
            Accountant
        };
    }

}

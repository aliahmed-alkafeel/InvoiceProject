using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Employee : BaseEntity
    {
        public Guid GroupGuid { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime EmployeeStartingDate { get; set; }
        public DateTime? EmployeeEndingDate { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
         
        public string Password { get; set; }
        [ForeignKey(nameof(GroupGuid))]
        public Group Group { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DTOs
{
    public class EmployeeDto : BaseDto
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
        public GroupDto Group { get; set; }
    }
}

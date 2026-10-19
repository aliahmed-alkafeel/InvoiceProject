using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.DTOs;
using Models.Entities;

namespace Models.DTOs
{
    public class CreateRoleDto : BaseDto
    {
        public UserRole RoleName { get; set; }
    }
}

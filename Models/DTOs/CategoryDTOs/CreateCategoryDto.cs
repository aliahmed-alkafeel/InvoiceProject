using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
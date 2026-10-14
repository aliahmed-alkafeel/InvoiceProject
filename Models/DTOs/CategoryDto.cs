using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ItemDto> Items { get; set; } = new HashSet<ItemDto>();
    }
}

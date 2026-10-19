using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ItemDto : BaseDto
    {
        public Guid CategoryGuid { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; } 
        public bool IsActive { get; set; }
        [ForeignKey(nameof(CategoryGuid))]
        public CategoryDto Category { get; set; }
        public ICollection<BillItemDto> BillItems { get; set; } = new HashSet<BillItemDto>();
    }
}

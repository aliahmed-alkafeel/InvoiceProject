using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UpdateItemDto : BaseDto
    {
        public Guid CategoryGuid { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

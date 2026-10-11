using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}

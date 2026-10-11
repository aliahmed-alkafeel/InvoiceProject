using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Item : BaseEntity
    {
        public Guid CategoryGuid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(CategoryGuid))]
        public Category Category { get; set; }
        public ICollection<BillItem> BillItems { get; set; } = new HashSet<BillItem>();
    }
}
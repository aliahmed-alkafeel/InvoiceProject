using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CreatedById { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsUpdated { get; set; }

        public Guid? UpdatedById { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? DeletedById { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string Notes { get; set; }
    }
}

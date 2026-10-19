using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateAccountsTreeDto : BaseDto
    {
        public Guid? ParentGuid { get; set; }

        public string AccountCode { get; set; }

        public string AccountName { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

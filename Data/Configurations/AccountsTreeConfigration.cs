using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
namespace Data.Configurations
{
    internal class AccountsTreeConfiguration : EntityTypeConfiguration<AccountsTree>
    {
        public AccountsTreeConfiguration()
        {
            Property(x=> x.AccountCode).IsRequired().HasMaxLength(50);
            Property(x=> x.AccountName).IsRequired().HasMaxLength(200);
        }
    }
}

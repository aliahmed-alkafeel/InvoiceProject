using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class InvoiceDbContext : DbContext   
    {
        public InvoiceDbContext() : base("name=InvoiceDbConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<AccountsTree> AccountTrees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Where(p => p.Name == "Notes")
                .Configure(p => p.IsOptional().HasMaxLength(500));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(InvoiceDbContext).Assembly);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Context;
using Data.Repositories.Interfaces;
using Models.Entities;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvoiceDbContext _context;
        public IGenericRepository<AccountsTree> AccountsTrees { get; }
        public IGenericRepository<Bill> Bills { get; }
        public IGenericRepository<BillItem> BillItems { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Currency> Currencies { get; }
        public IGenericRepository<Item> Items { get; }
        public IGenericRepository<Voucher> Vouchers { get; }
        public IGenericRepository<Employee> Employees { get; }
        public IGenericRepository<Group> Groups { get; }
        public IGenericRepository<Role> Roles { get; }
        public IGenericRepository<GroupRole> GroupRoles { get; }

        public UnitOfWork(
            InvoiceDbContext context,
        IGenericRepository<AccountsTree> accountsTrees,
        IGenericRepository<Bill> bills,
        IGenericRepository<BillItem> billItems,
        IGenericRepository<Category> categories,
        IGenericRepository<Currency> currencies,
        IGenericRepository<Item> items,
        IGenericRepository<Voucher> vouchers,
        IGenericRepository<Employee> employees,
        IGenericRepository<Group> groups,
        IGenericRepository<Role> roles,
        IGenericRepository<GroupRole> groupRoles
            )
        {
            _context = context;
            AccountsTrees = accountsTrees;
            Bills = bills;
            BillItems = billItems;
            Categories = categories;
            Currencies = currencies;
            Items = items;
            Vouchers = vouchers;
            Employees = employees;
            Groups = groups;
            Roles = roles;
            GroupRoles = groupRoles;

        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

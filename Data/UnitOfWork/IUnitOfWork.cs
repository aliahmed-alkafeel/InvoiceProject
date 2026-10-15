using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Models.Entities;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<AccountsTree> AccountsTree { get; }
        IGenericRepository<Bill> Bills { get; }
        IGenericRepository<BillItem> BillItems { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Currency> Currencies { get; }
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Voucher> Vouchers { get; }
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Group> Groups { get; }
        IGenericRepository<Role> Roles { get; }
        IGenericRepository<GroupRole> GroupRoles { get; }
        Task<int> SaveChangesAsync();
    }
}

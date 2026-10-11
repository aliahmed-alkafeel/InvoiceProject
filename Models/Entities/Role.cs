using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Entities;

namespace Models.Entities
{
    public class Role : BaseEntity
    {
        public UserRole RoleName { get; set; }
    }
    public enum UserRole
    {
        Unclassified = 0,
        ManageBills,
        AccessBills,

        AccessVoucher,
        ManageVoucher,

        AccessCategories,
        ManageCategories,

        AccessItems,
        ManageItems,

        AccessAccountsTree,
        ManageAccountsTree,
        AccessCurrency,
        ManageCurrency,
    }
}
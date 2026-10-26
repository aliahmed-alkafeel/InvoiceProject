using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Entities;

namespace Models.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
    }
    public static class UserRole
    {
        public const string Unclassified = "غير مصنف";
        public const string ManageBills = "إدارة الفواتير";
        public const string AccessBills = "عرض الفواتير";

        public const string AccessVoucher = "عرض السندات";
        public const string ManageVoucher = "إدارة السندات";

        public const string AccessCategories = "عرض الفئات";
        public const string ManageCategories = "إدارة الفئات";

        public const string AccessItems = "عرض الأصناف";
        public const string ManageItems = "إدارة الأصناف";

        public const string AccessAccountsTree = "عرض شجرة الحسابات";
        public const string ManageAccountsTree = "إدارة شجرة الحسابات";
        public const string AccessCurrency = "عرض العملات";
        public const string ManageCurrency = "إدارة العملات";

        public const string AccessGroups = "عرض المجموعات";
        public const string ManageGroups = "إدارة المجموعات";

        public const string AccessEmployees = "عرض الموظفين";
        public const string ManageEmployees = "إدارة الموظفين";

        public static readonly string[] All =
        {
            Unclassified,

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

            AccessGroups,
            ManageGroups,

            AccessEmployees,    
            ManageEmployees
        };
    }
}
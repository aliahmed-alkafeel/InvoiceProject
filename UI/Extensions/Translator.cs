using Models.Entities;
using System;
using System.Collections.Generic;

namespace UI.Extensions
{
    internal static class Translator
    {
        private static readonly Dictionary<UserRole, string> _roleNames =
            new Dictionary<UserRole, string>
            {
                [UserRole.Unclassified] = "غير مصنف",
                [UserRole.ManageBills] = "إدارة الفواتير",
                [UserRole.AccessBills] = "عرض الفواتير",
                [UserRole.AccessVoucher] = "عرض السندات",
                [UserRole.ManageVoucher] = "إدارة السندات",
                [UserRole.AccessCategories] = "عرض الفئات",
                [UserRole.ManageCategories] = "إدارة الفئات",
                [UserRole.AccessItems] = "عرض الأصناف",
                [UserRole.ManageItems] = "إدارة الأصناف",
                [UserRole.AccessAccountsTree] = "عرض شجرة الحسابات",
                [UserRole.ManageAccountsTree] = "إدارة شجرة الحسابات",
                [UserRole.AccessCurrency] = "عرض العملات",
                [UserRole.ManageCurrency] = "إدارة العملات"
            };

        private static readonly Dictionary<VoucherType, string> _voucherTypeNames =
            new Dictionary<VoucherType, string>
            {
                [VoucherType.Receipt] = "سند قبض",
                [VoucherType.Payment] = "سند صرف"
            };

        private static readonly Dictionary<BillType, string> _billTypeNames =
            new Dictionary<BillType, string>
            {
                [BillType.In] = "وارد",
                [BillType.Out] = "صادر"
            };

        private static readonly Dictionary<InitUserGroup, string> _groupNames =
            new Dictionary<InitUserGroup, string>
            {
                [InitUserGroup.Unclassified] = "غير مصنف",
                [InitUserGroup.Administrator] = "المسؤول",
                [InitUserGroup.Manager] = "المدير",
                [InitUserGroup.Cashier] = "الكاشير",
                [InitUserGroup.Accountant] = "المحاسب"
            };

        /// <summary>
        /// ترجمة اسم الصلاحية إلى العربية.
        /// </summary>
        public static string Translate(UserRole role)
        {
            return _roleNames.TryGetValue(role, out var name)
                ? name
                : role.ToString();
        }

        /// <summary>
        /// ترجمة اسم صلاحية نصي، إذا لم يكن الاسم معروفاً يُرجع كما هو.
        /// </summary>
        public static string Translate(string roleName)
        {
            return Enum.TryParse(roleName, out UserRole role)
                ? Translate(role)
                : roleName;
        }

        /// <summary>
        /// ترجمة نوع السند (قبض / صرف).
        /// </summary>
        public static string Translate(VoucherType type)
        {
            return _voucherTypeNames.TryGetValue(type, out var name)
                ? name
                : type.ToString();
        }

        /// <summary>
        /// ترجمة نوع الفاتورة (وارد / صادر).
        /// </summary>
        public static string Translate(BillType type)
        {
            return _billTypeNames.TryGetValue(type, out var name)
                ? name
                : type.ToString();
        }

        /// <summary>
        /// ترجمة اسم مجموعة النظام المخزنة كنص،
        /// والمجموعات غير المعروفة (المخصصة) تُرجع كما هي.
        /// </summary>
        public static string TranslateGroup(string groupName)
        {
            return Enum.TryParse(groupName, out InitUserGroup group)
                ? Translate(group)
                : groupName;
        }

        /// <summary>
        /// ترجمة اسم مجموعة النظام.
        /// </summary>
        public static string Translate(InitUserGroup group)
        {
            return _groupNames.TryGetValue(group, out var name)
                ? name
                : group.ToString();
        }
    }
}

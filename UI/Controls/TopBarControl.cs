using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.CurrentUserDetails;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using UI.Extensions;
using UI.Forms;
using UI.Forms.Categories;
using UI.Forms.Vouchers;


namespace UI.Base.TopBar
{
    public partial class TopBarControl : DevExpress.XtraEditors.XtraUserControl
    {
        private NavElement _activeElement;
        private static readonly Color ActiveBackColor = Color.FromArgb(8, 47, 82);
        public TopBarControl()
        {
            InitializeComponent();
            ApplyRoles();
            SetActiveElement(btnItems);
        }

        private void tileNavPane1_Click(object sender, EventArgs e)
        {
        }

        private void btnItems_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<ItemsForm>();
        }

        private void btnCategories_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<CategoriesForm>();
        }

        private void btnCurrencies_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<CurrenciesForm>();
        }

        private void btnAccountsTree_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<AccountsTreeForm>();
        }

        private void btnBills_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<BillsForm>();
        }

        private void btnVouchers_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<VouchersForm>();
        }

        private void navButton7_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<ItemBillsForm>();
        }

        private void btnGroups_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<GroupsForm>();
        }

        private void btnEmployees_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            Navigator.NavigateTo<EmployeesForm>();
        }
        private void SetActiveElement(NavElement element)
        {
            if (element == null || element == _activeElement)
                return;

            if (_activeElement != null)
            {
                _activeElement.Appearance.BackColor = Color.Empty;
                _activeElement.Appearance.Options.UseBackColor = false;
            }

            element.Appearance.BackColor = ActiveBackColor;
            element.Appearance.Options.UseBackColor = true;

            _activeElement = element;
        }

        public void ApplyRoles()
        {
            btnItems.Visible = CurrentUser.HasRole(UserRole.AccessItems);
            btnCategories.Visible = CurrentUser.HasRole(UserRole.AccessCategories);
            btnCurrencies.Visible = CurrentUser.HasRole(UserRole.AccessCurrency);
            btnAccountsTree.Visible = CurrentUser.HasRole(UserRole.AccessAccountsTree);
            btnBills.Visible = CurrentUser.HasRole(UserRole.AccessBills);
            btnItemBills.Visible = CurrentUser.HasRole(UserRole.AccessBills);   
            btnVouchers.Visible = CurrentUser.HasRole(UserRole.AccessVoucher);
            btnGroups.Visible = CurrentUser.HasRole(UserRole.AccessGroups);
            btnEmployees.Visible = CurrentUser.HasRole(UserRole.AccessEmployees);
        }
    }
}

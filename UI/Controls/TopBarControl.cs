using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using UI.Forms.Categories;
using UI.Forms.Items;
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
            SetActiveElement(btnItems);
        }

        private void tileNavPane1_Click(object sender, EventArgs e)
        {
        }

        private void btnItems_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var itemsForm =
                Program.CurrentScopeProvider.GetRequiredService<ItemsForm>();

            itemsForm.LoadPage();
        }

        private void btnCategories_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var categoriesForm =
                Program.CurrentScopeProvider.GetRequiredService<CategoriesForm>();

            categoriesForm.LoadPage();
        }

        private void btnCurrencies_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var currenciesForm =
                Program.CurrentScopeProvider.GetRequiredService<CurrenciesForm>();

            currenciesForm.LoadPage();
        }

        private void btnAccountsTree_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var accountsTreeForm =
                Program.CurrentScopeProvider.GetRequiredService<AccountsTreeForm>();

            accountsTreeForm.LoadPage();
        }

        private void btnBills_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var billsForm =
                Program.CurrentScopeProvider.GetRequiredService<BillsForm>();

            billsForm.LoadPage();
        }

        private void btnVouchers_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var vouchersForm =
                Program.CurrentScopeProvider.GetRequiredService<VouchersForm>();

            vouchersForm.LoadPage();
        }

        private void navButton7_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var itemBillsForm =
                Program.CurrentScopeProvider.GetRequiredService<ItemBillsForm>();

            itemBillsForm.LoadPage();
        }

        private void btnGroups_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var groupsForm =
                Program.CurrentScopeProvider.GetRequiredService<GroupsForm>();

            groupsForm.LoadPage();
        }

        private void btnEmployees_Click(object sender, NavElementEventArgs e)
        {
            SetActiveElement(e.Element);

            var employeesForm =
                Program.CurrentScopeProvider.GetRequiredService<EmployeesForm>();

            employeesForm.LoadPage();
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
    }
}

using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.CurrentUserDetails;
using Models.Entities;
using System;
using System.Windows.Forms;
using UI.Forms;
using UI.Forms.Categories;
using UI.Forms.Vouchers;

namespace UI
{
    internal static class Navigator
    {
        private static IServiceProvider _rootProvider;
        private static XtraForm _hostForm;
        private static XtraForm _currentPage;
        private static IServiceScope _currentPageScope;
        public static void Initialize(IServiceProvider rootProvider, XtraForm hostForm)
        {
            _rootProvider = rootProvider;
            _hostForm = hostForm;
        }

        public static void NavigateTo<TPage>() where TPage : XtraForm
        {
            if (_hostForm == null || _rootProvider == null)
                throw new InvalidOperationException(
                    "لم يتم تهيئة Navigator. استدعِ Initialize أولاً");

            if (_currentPage != null &&
                _currentPage.GetType() == typeof(TPage))
            {
                return;
            }

            var newScope = _rootProvider.CreateScope();

            TPage newPage;

            try
            {
                newPage = newScope.ServiceProvider
                    .GetRequiredService<TPage>();

                newPage.TopLevel = false;
                newPage.FormBorderStyle = FormBorderStyle.None;
                newPage.Dock = DockStyle.Fill;
            }
            catch
            {
                newScope.Dispose();
                throw new Exception($"فشل انشاء {typeof(TPage).Name}");
            }

            var previousScope = _currentPageScope;

            if (_currentPage != null)
                _hostForm.Controls.Remove(_currentPage);

            _hostForm.Controls.Add(newPage);
            _currentPage = newPage;
            _currentPageScope = newScope;
            _hostForm.Text = newPage.Text;
            newPage.Show();
            newPage.BringToFront();

            previousScope?.Dispose();
        }


        public static DialogResult ShowScopedDialog<TDialog>(
            params object[] parameters)
            where TDialog : Form
        {
            using (var scope = _rootProvider.CreateScope())
            using (var dialog = ActivatorUtilities.CreateInstance<TDialog>(
                scope.ServiceProvider,
                parameters))
            {
                return dialog.ShowDialog();
            }
        }

        public static bool NavigateToFirstAllowedForm()
        {
            if (CurrentUser.HasRole(UserRole.AccessItems))
                NavigateTo<ItemsForm>();
            else if (CurrentUser.HasRole(UserRole.AccessCategories))
                NavigateTo<CategoriesForm>();
            else if (CurrentUser.HasRole(UserRole.AccessBills))
                NavigateTo<BillsForm>();
            else if (CurrentUser.HasRole(UserRole.AccessVoucher))
                NavigateTo<VouchersForm>();
            else if (CurrentUser.HasRole(UserRole.AccessAccountsTree))
                NavigateTo<AccountsTreeForm>();
            else if (CurrentUser.HasRole(UserRole.AccessCurrency))
                NavigateTo<CurrenciesForm>();
            else if (CurrentUser.HasRole(UserRole.AccessEmployees))
                NavigateTo<EmployeesForm>();
            else if (CurrentUser.HasRole(UserRole.AccessGroups))
                NavigateTo<GroupsForm>();
            else
                return false;

            return true;
        }

        public static void Shutdown()
        {
            _currentPageScope?.Dispose();
            _currentPageScope = null;
            _currentPage = null;
            _hostForm = null;
            _rootProvider = null;
        }


    }
}
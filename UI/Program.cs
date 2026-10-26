using Data.Context;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Data.Seed;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Areas.Dashboard.Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Extensions;
using UI.Forms;
using UI.Forms.AccountsTree;
using UI.Forms.Bills;
using UI.Forms.Categories;
using UI.Forms.Currencies;
using UI.Forms.Employees;
using UI.Forms.Groups;
using UI.Forms.Items;
using UI.Forms.Vouchers;
using UI.Screens;

namespace UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceProvider CurrentScopeProvider { get; private set; }
        private static XtraForm _hostForm;
        private static XtraForm _currentPage;
        private static IServiceScope _currentPageScope;

        [STAThread]
        static void Main()
        {
            GlobalExceptionHandler.UseGlobalExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("WXI");

            WindowsFormsSettings.DefaultFont = new Font("Segoe UI", 10f);


            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            try
            {
                DbInitializer.SeedAsync(ServiceProvider).Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إدخال البيانات الأولية:\n{ex.Message}",
                    "خطأ في النظام",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
//            // del this line and if
//            var rememberedUsernam =
//Properties.Settings.Default.RememberedUsername;
//            if (rememberedUsernam == null)
//            {
                using (var loginScope = ServiceProvider.CreateScope())
                {
                    var loginForm =
                        loginScope.ServiceProvider.GetRequiredService<LogInForm>();

                    var result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                        return;
                }
            //}

            using (var mainScope = ServiceProvider.CreateScope())
            {
                // النافذة الرئيسية تبقى طوال فترة تشغيل التطبيق.
                _hostForm = mainScope.ServiceProvider
                    .GetRequiredService<MainForm>();

                _currentPage = null;
                _currentPageScope = null;

                try
                {
                    // فتح الشاشة الأولى باستخدام Scope مستقل.
                    NavigateTo<ItemsForm>();

                    Application.Run(_hostForm);
                }
                finally
                {
                    // التخلص من Scope آخر شاشة عند إغلاق التطبيق.
                    _currentPageScope?.Dispose();

                    _currentPageScope = null;
                    _currentPage = null;
                    CurrentScopeProvider = null;
                    _hostForm = null;
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<InvoiceDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IAccountsTreeService, AccountsTreesService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IGroupService, GroupService>(); 
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddTransient<MainForm>();
            services.AddTransient<LogInForm>();
            services.AddTransient<ItemsForm>();
            services.AddTransient<ItemsEditForm>();
            services.AddTransient<CategoriesForm>();
            services.AddTransient<CategoriesManageForm>();
            services.AddTransient<CurrenciesForm>();
            services.AddTransient<CurrenciesManageForm>();
            services.AddTransient<AccountsTreeForm>();
            services.AddTransient<AccountsTreeManageForm>();
            services.AddTransient<BillsForm>();
            services.AddTransient<BillsManageForm>();
            services.AddTransient<ItemBillsForm>();
            services.AddTransient<VouchersForm>();
            services.AddTransient<VouchersManageForm>();
            services.AddTransient<VouchersCreateForm>();
            services.AddTransient<GroupsForm>();
            services.AddTransient<GroupsManageForm>();
            services.AddTransient<EmployeesForm>();
            services.AddTransient<EmployeesManageForm>();
        }

        public static void NavigateTo<TPage>()
    where TPage : XtraForm
        {
            if (_hostForm == null)
                throw new InvalidOperationException(
                    "لم يتم تحديد الفورم الرئيسي");

            // إذا كانت الشاشة المطلوبة هي الشاشة الحالية، فلا تفعل شيئًا.
            if (_currentPage != null &&
              _currentPage.GetType() == typeof(TPage))
            {
                return;
            }

            // 1. إنشاء Scope جديد للشاشة.
            var newScope = ServiceProvider.CreateScope();

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
            CurrentScopeProvider = newScope.ServiceProvider;
            _hostForm.Text = newPage.Text;
            newPage.Show();
            newPage.BringToFront();
            previousScope?.Dispose();
        }
    }
}
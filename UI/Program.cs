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
            using (var rootProvider = services.BuildServiceProvider())
            {
                ServiceProvider = rootProvider;
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


                    using (var loginScope = ServiceProvider.CreateScope())
                {
                    var loginForm =
                        loginScope.ServiceProvider.GetRequiredService<LogInForm>();

                    var result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                        return;
                
            }
            using (var mainScope = ServiceProvider.CreateScope())
                {
                    var hostForm = mainScope.ServiceProvider
                        .GetRequiredService<MainForm>();

                    Navigator.Initialize(ServiceProvider, hostForm);

                    try
                    {
                        Navigator.NavigateTo<ItemsForm>();
                        Application.Run(hostForm);
                    }
                    finally
                    {
                        Navigator.Shutdown();
                    }
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

    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Context;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Data.Seed;
using Data.Services;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using UI.Base.TopBar;
using UI.Forms;
using UI.Forms.Items;
using UI.Screens;

namespace UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceProvider CurrentScopeProvider { get; private set; }
        private static XtraForm _hostForm;
        private static XtraForm _currentPage;

        public static void LoadPage(this XtraForm page)
        {
            if (_hostForm == null)
                throw new InvalidOperationException("لم يتم تحديد الفورم الرئيسي.");

            if (_currentPage != null &&
                _currentPage.GetType() == page.GetType())
            {
                page.Dispose();
                return;
            }
            if (_currentPage != null)
            {
                _hostForm.Controls.Remove(_currentPage);
                _currentPage.Dispose();
            }
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;

            _hostForm.Controls.Add(page);

            page.Show();
            page.BringToFront();

            _currentPage = page;

            _hostForm.Text = page.Text;
        }
        [STAThread]
        static void Main()
        {
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
            // del this line and if
            var rememberedUsernam =
Properties.Settings.Default.RememberedUsername;
            if (rememberedUsernam == null)
            {
                using (var loginScope = ServiceProvider.CreateScope())
                {
                    var loginForm =
                        loginScope.ServiceProvider.GetRequiredService<LogInForm>();

                    var result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                        return;
                }
            }
            using (var mainScope = ServiceProvider.CreateScope())
            {
                CurrentScopeProvider = mainScope.ServiceProvider;

                var mainForm =
                    CurrentScopeProvider.GetRequiredService<MainForm>();

                var firstForm =
                    CurrentScopeProvider.GetRequiredService<ItemsForm>();

                _hostForm = mainForm;

                _currentPage = null;

                firstForm.LoadPage();

                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<InvoiceDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddTransient <ItemsForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<LogInForm>();
            services.AddTransient<ItemsEditForm>();
            services.AddTransient<CategoriesForm>();
        }
    }
}
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
using UI.Forms;
using UI.Screens;

namespace UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
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
                var mainForm =
                    mainScope.ServiceProvider.GetRequiredService<ItemsForm>();

                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<InvoiceDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ILoginService, LoginService>();
            services.AddTransient<ItemsForm>();
            services.AddTransient<LogInForm>();
        }
    }
}
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI
{
    internal static class Navigator
    {
        private static IServiceProvider _rootProvider;
        private static XtraForm _hostForm;
        private static XtraForm _currentPage;
        private static IServiceScope _currentPageScope;

        public static IServiceProvider CurrentScopeProvider { get; private set; }

        public static void Initialize(IServiceProvider rootProvider, XtraForm hostForm)
        {
            _rootProvider = rootProvider
                ?? throw new ArgumentNullException(nameof(rootProvider));
            _hostForm = hostForm
                ?? throw new ArgumentNullException(nameof(hostForm));

            _currentPage = null;
            _currentPageScope = null;
            CurrentScopeProvider = null;
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
            CurrentScopeProvider = newScope.ServiceProvider;
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



        public static void Shutdown()
        {
            _currentPageScope?.Dispose();
            _currentPageScope = null;
            _currentPage = null;
            CurrentScopeProvider = null;
            _hostForm = null;
            _rootProvider = null;
        }


    }
}
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

        /// <summary>
        /// الـ Provider الخاص بالشاشة الحالية (Scope الشاشة).
        /// </summary>
        public static IServiceProvider CurrentScopeProvider { get; private set; }

        /// <summary>
        /// تهيئة الـ Navigator بالـ Provider الرئيسي والفورم المضيف.
        /// </summary>
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

            // إذا كانت الشاشة المطلوبة هي الشاشة الحالية، فلا تفعل شيئًا.
            if (_currentPage != null &&
                _currentPage.GetType() == typeof(TPage))
            {
                return;
            }

            // 1. إنشاء Scope جديد للشاشة.
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

        /// <summary>
        /// تنظيف الموارد عند إغلاق التطبيق.
        /// </summary>
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
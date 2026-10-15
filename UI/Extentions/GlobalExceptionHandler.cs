using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Extentions
{
    public static class GlobalExceptionHandler
    {
        public static void UseGlobalExceptionHandler()
        {
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
            {
                ShowError(e.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception exception = e.ExceptionObject as Exception;

                ShowError(exception);
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                ShowError(e.Exception);

                e.SetObserved();
            };
        }

        private static void ShowError(Exception exception)
        {
            string message = exception?.GetBaseException().Message
                             ?? "حدث خطأ غير معروف.";

            MessageBox.Show(
                "حدث خطأ غير متوقع!\n" + message,
                "خطأ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
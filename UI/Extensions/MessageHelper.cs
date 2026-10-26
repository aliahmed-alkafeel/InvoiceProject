using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace UI.Extensions
{
    public static class MessageHelper
    {
        public static void Info(string message, string title = "تنبيه") =>
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Success(string message) =>
            XtraMessageBox.Show(message, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Error(string message) =>
            XtraMessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
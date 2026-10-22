using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UI.Forms
{
    public partial class LoadingForm : XtraForm
    {
        private readonly CancellationTokenSource _cts;
        private bool _allowClose;

        public LoadingForm(CancellationTokenSource cts, string message)
        {
            InitializeComponent();
            _cts = cts;
            lblMessage.Text = message;
        }

        private void CancelOperation()
        {
            if (_cts.IsCancellationRequested)
                return;
            btnCancel.Enabled = false;
            lblMessage.Text = "...يتم الغاء التحميل";
            _cts.Cancel();
        }

        public void CloseAfterOperation()
        {
            _allowClose = true;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                e.Cancel = true;
                CancelOperation();
                return;
            }

            base.OnFormClosing(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelOperation();
        }
    }
}
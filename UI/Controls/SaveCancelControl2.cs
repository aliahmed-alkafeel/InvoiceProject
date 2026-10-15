using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class SaveCancelControl2 : DevExpress.XtraEditors.XtraUserControl
    {
        public SaveCancelControl2()
        {
            InitializeComponent();
        }
        public event Action SaveClicked;
        public event Action CancelClicked;

        private void btnSave_Click(object sender, EventArgs e)
        {
         SaveClicked?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke();

        }
        public string SaveText
        {
            get => btnSave.Text;
            set => btnSave.Text = value;
        }

    }
}

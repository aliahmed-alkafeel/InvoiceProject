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
        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;

        private void btnSave_Click(object sender, EventArgs e)
        {
         SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);

        }
    }
}

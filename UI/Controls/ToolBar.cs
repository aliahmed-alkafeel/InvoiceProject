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
    public partial class ToolBar : DevExpress.XtraEditors.XtraUserControl
    {
        public ToolBar()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }


        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchControl1.Properties.NullValuePrompt = "بحث...";
        }

        public event EventHandler CreateClicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler RefreshClicked;
        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
    }
}

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
    public partial class TopBarV2Control : DevExpress.XtraEditors.XtraUserControl
    {
        public TopBarV2Control()
        {
            InitializeComponent();
        }

    private void btnAdd_Click(object sender, EventArgs e)
        { 
            CreateClicked?.Invoke(this, EventArgs.Empty);
        } 
    private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        } 
    private void btnDelete_Click(object sender, EventArgs e)
        { 
            DeleteClicked?.Invoke(this, EventArgs.Empty); 
        }

        public event EventHandler CreateClicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   
    }
}

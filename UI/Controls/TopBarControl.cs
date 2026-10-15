using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using UI.Forms.Categories;
using UI.Forms.Items;

namespace UI.Base.TopBar
{
    public partial class TopBarControl : DevExpress.XtraEditors.XtraUserControl
    {
        public TopBarControl()
        {
            InitializeComponent();
        }

        private void tileNavPane1_Click(object sender, EventArgs e)
        {
        }

        private void btnItems_Click(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            var itemsForm =
    Program.CurrentScopeProvider.GetRequiredService<ItemsForm>();

            itemsForm.LoadPage();
        }

        private void btnCategories_Click(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            var categoriesForm =
                Program.CurrentScopeProvider.GetRequiredService<CategoriesForm>();

            categoriesForm.LoadPage();
        }
    }
}

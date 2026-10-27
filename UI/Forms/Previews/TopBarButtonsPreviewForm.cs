using System;
using DevExpress.XtraEditors;
using UI.Controls;

namespace UI.Forms.Previews
{
    /// <summary>
    /// Standalone preview for <see cref="TopBarButtonsControl"/>. This form is not
    /// referenced by the application's startup path or by any production screen.
    /// </summary>
    public partial class TopBarButtonsPreviewForm : XtraForm
    {
        public TopBarButtonsPreviewForm()
        {
            InitializeComponent();

            BuildSampleItems();

            topBarButtonsControl1.SelectedItemChanged += TopBarButtonsControl1_SelectedItemChanged;
            topBarButtonsControl1.ItemClick += TopBarButtonsControl1_ItemClick;

            topBarButtonsControl1.SelectedKey = "Categories";
            UpdateSelectionLabel();
        }

        private void BuildSampleItems()
        {
            topBarButtonsControl1.AddItem("Home", "Home", "images/navigation/home_32x32.png");
            topBarButtonsControl1.AddItem("Categories", "Categories", "images/xaf/bo_category_32x32.png");
            topBarButtonsControl1.AddItem("Items", "Items", "images/xaf/bo_product_32x32.png");
            topBarButtonsControl1.AddItem("Bills", "Bills", "images/xaf/bo_invoice_32x32.png");
            topBarButtonsControl1.AddItem("BillItems", "Bill Items", "images/xaf/bo_list_32x32.png");
            topBarButtonsControl1.AddItem("Vouchers", "Vouchers", "images/xaf/bo_document_32x32.png");
            topBarButtonsControl1.AddItem("AccountsTree", "Accounts Tree", "images/filter%20elements/treeview_32x32.png");
            topBarButtonsControl1.AddItem("Currency", "Currency", "images/miscellaneous/currency_32x32.png");
        }

        private void TopBarButtonsControl1_SelectedItemChanged(
            object sender,
            TopBarButtonItemEventArgs e)
        {
            UpdateSelectionLabel();
        }

        private void TopBarButtonsControl1_ItemClick(
            object sender,
            TopBarButtonItemEventArgs e)
        {
            if (e.Item != null)
                lblLastClick.Text = "Last click: " + e.Item.Text;
        }

        private void UpdateSelectionLabel()
        {
            TopBarButtonItem selectedItem = topBarButtonsControl1.SelectedItem;

            lblSelection.Text = selectedItem == null
                ? "Selected: (none)"
                : "Selected: " + selectedItem.Text;
        }
    }
}

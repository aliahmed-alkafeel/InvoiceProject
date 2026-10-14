using Data.UnitOfWork;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Utils;
using DevExpress.XtraGrid.Views.Base;
using Models.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms.Items;

namespace UI.Forms
{
    public partial class ItemsForm : XtraForm
    {
        private readonly IUnitOfWork _unitOfWork;

        private Item _selectedItem;

 
        private bool _isCreating;
        private bool _isEditing;
        private bool _isLoadingItems;

        public Guid CurrentUserId { get; set; }

        public ItemsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            topBarV2Control1.CreateClicked += ItemsToolbar_CreateClicked;
            topBarV2Control1.EditClicked += ItemsToolbar_EditClicked;
            topBarV2Control1.DeleteClicked += ItemsToolbar_DeleteClicked;

        }
     
        // =========================================================
        // 1. Load
        // =========================================================

        private async void ItemsForm_LoadAsync(
            object sender,
            EventArgs e)
        {
            try
            {
                await LoadItemsAsync();

                SetDetailsEditable(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Failed to load items.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        //    var categories = await _unitOfWork.Categories
        //.Select()
        //.Select(c => new
        //{
        //    c.Id,
        //    c.Name
        //})
        //.ToListAsync();

            //cmbCategories.Properties.DataSource = categories;
            //cmbCategories.Properties.DisplayMember = "Name";
            //cmbCategories.Properties.ValueMember = "Name";
            //cmbCategories.Properties.NullText = "اختر التصنيف";

        }



        private async Task LoadItemsAsync()
        {
            _isLoadingItems = true;

            try
            {
                var items = await _unitOfWork.Items
                    .Select().Include(i => i.Category)
                    .ToListAsync();

                gridControl1.DataSource = items;

                if (gridView1.RowCount > 0)
                {
                    // تحديد أول صف.
                    gridView1.FocusedRowHandle = 0;

                    var item = gridView1.GetFocusedRow() as Item;

                    //LoadItemDetails(item);
                }
                else
                {
                    //LoadItemDetails(null);
                }
            }
            finally
            {
                _isLoadingItems = false;
            }
        }

        // =========================================================
        // 3. When selected row changes
        // =========================================================

        private void gridView1_FocusedRowChanged(
            object sender,
            FocusedRowChangedEventArgs e)
        {
            // لا تغيّر الحقول أثناء التحميل أو الإضافة أو التعديل.
            //if (_isLoadingItems || _isCreating || _isEditing)
            //    return;

            var selectedItem = gridView1.GetFocusedRow() as Item;

            //LoadItemDetails(selectedItem);
        }

        // =========================================================
        // 4. Display selected item in the right panel
        // =========================================================



        // =========================================================
        // 5. Clear detail fields
        // =========================================================



        // =========================================================
        // 6. Enable / Disable editing
        // =========================================================

        private void SetDetailsEditable(bool editable)
        {
            //txtName.Properties.ReadOnly = !editable;
            //txtPrice.Properties.ReadOnly = !editable;
        }

        // =========================================================
        // 7. Create
        // =========================================================

        private void ItemsToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (!ConfirmDiscardChanges())
                return;

            var editForm = Program.ServiceProvider.GetService(typeof(ItemsEditForm)) as ItemsEditForm;
                editForm.ShowDialog(this);

            
            
            
            _isCreating = true;
            _isEditing = false;

            _selectedItem = null;

            //ClearDetails();

            SetDetailsEditable(true);

            //txtName.Focus();
        }

        // =========================================================
        // 8. Edit
        // =========================================================

        private void ItemsToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            var selectedItem = gridView1.GetFocusedRow() as Item;

            if (selectedItem == null)
            {
                XtraMessageBox.Show(
                    "Please select an item first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
            using (var editForm = Program.ServiceProvider.GetService(typeof(ItemsEditForm)) as ItemsEditForm)
            {
                editForm.ShowDialog(this);
               
            }

            
            if (_isCreating || _isEditing)
            {
                XtraMessageBox.Show(
                    "Save or cancel the current operation first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }



            _isCreating = false;
            _isEditing = true;

            //LoadItemDetails(selectedItem);

            SetDetailsEditable(true);

            //txtName.Focus();
        }

        // =========================================================
        // 9. Save - Create or Update
        // =========================================================

        private async void ItemsToolbar_SaveClicked(
            object sender,
            EventArgs e)
        {
            if (!_isCreating && !_isEditing)
            {
                XtraMessageBox.Show(
                    "Click Create or Edit before saving.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Validate Name.
            //string name = txtName.Text.Trim();

            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    XtraMessageBox.Show(
            //        "Name is required.",
            //        "Validation",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);

            //    txtName.Focus();
            //    return;
            }

            // Validate Price.
        //    if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
        //        price < 0)
        //    {
        //        XtraMessageBox.Show(
        //            "Please enter a valid price.",
        //            "Validation",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);

        //        txtPrice.Focus();
        //        return;
        //    }

        //    try
        //    {
        //        if (_isCreating)
        //        {
        //            await CreateItemAsync(name, price);
        //        }
        //        else if (_isEditing)
        //        {
        //            await UpdateItemAsync(name, price);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(
        //            $"Failed to save the item.\n{ex.Message}",
        //            "Error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}

        // =========================================================
        // 10. Create item
        // =========================================================

        private async Task CreateItemAsync(
            string name,
            decimal price)
        {
            // CreatedById is required by your database.
            if (CurrentUserId == Guid.Empty)
            {
                XtraMessageBox.Show(
                    "CurrentUserId must contain the ID of the logged-in user.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var item = new Item
            {
                Name = name,
                Price = price,
                CreatedById = CurrentUserId,
                IsDeleted = false
            };

            // Assumes your repository has Add(Item).
            _unitOfWork.Items.Add(item);

            await _unitOfWork.SaveChangesAsync();

            _isCreating = false;
            _isEditing = false;

            SetDetailsEditable(false);

            await LoadItemsAsync();

            XtraMessageBox.Show(
                "Item created successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // 11. Update item
        // =========================================================

        private async Task UpdateItemAsync(
            string name,
            decimal price)
        {
            if (_selectedItem == null)
            {
                XtraMessageBox.Show(
                    "No item is selected.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Update the selected tracked entity.
            _selectedItem.Name = name;
            _selectedItem.Price = price;

            // Audit fields inherited from BaseModel.
            _selectedItem.IsUpdated = true;

            _selectedItem.UpdatedById =
                CurrentUserId == Guid.Empty
                    ? (Guid?)null
                    : CurrentUserId;

            await _unitOfWork.SaveChangesAsync();

            _isCreating = false;
            _isEditing = false;

            SetDetailsEditable(false);

            await LoadItemsAsync();

            XtraMessageBox.Show(
                "Item updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // 12. Delete - Soft Delete
        // =========================================================

        private async void ItemsToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (_isCreating || _isEditing)
            {
                XtraMessageBox.Show(
                    "Save or cancel the current operation first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var item = gridView1.GetFocusedRow() as Item;

            if (item == null)
            {
                XtraMessageBox.Show(
                    "Please select an item first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var result = XtraMessageBox.Show(
                $"Are you sure you want to delete '{item.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Soft delete: do not physically remove the record.
                item.IsDeleted = true;
                item.DeletedAt = DateTime.UtcNow;

                item.DeletedById =
                    CurrentUserId == Guid.Empty
                        ? (Guid?)null
                        : CurrentUserId;

                await _unitOfWork.SaveChangesAsync();

                await LoadItemsAsync();

                SetDetailsEditable(false);

                XtraMessageBox.Show(
                    "Item deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Failed to delete the item.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // 13. Refresh
        // =========================================================

        private async void ItemsToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (!ConfirmDiscardChanges())
                return;

            _isCreating = false;
            _isEditing = false;

            try
            {
                await LoadItemsAsync();

                SetDetailsEditable(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Failed to refresh items.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // 14. Cancel
        // =========================================================

        //private void ItemsToolbar_CancelClicked(
        //    object sender,
        //    EventArgs e)
        //{
        //    _isCreating = false;
        //    _isEditing = false;

        //    SetDetailsEditable(false);

        //    // Restore the values from the selected grid row.
        //    var selectedItem = gridView1.GetFocusedRow() as Item;

        //    LoadItemDetails(selectedItem);
        //}

        // =========================================================
        // 15. Confirm before discarding changes
        // =========================================================

        private bool ConfirmDiscardChanges()
        {
            if (!_isCreating && !_isEditing)
                return true;

            var result = XtraMessageBox.Show(
                "Discard the current unsaved changes?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategories_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void saveCancelControl21_Load(object sender, EventArgs e)
        {

        }

        private void topBarV2Control1_Load(object sender, EventArgs e)
        {

        }
    }
}
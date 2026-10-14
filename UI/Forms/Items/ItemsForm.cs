using Data.UnitOfWork;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms.Items;

namespace UI.Forms
{
    public partial class ItemsForm : XtraForm
    {
        private readonly IUnitOfWork _unitOfWork;

        public Guid CurrentUserId { get; set; }
        private bool _isLoadingItems;
        public ItemsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            ToolBarControl1.CreateClicked += ItemsToolbar_CreateClicked;
            ToolBarControl1.EditClicked += ItemsToolbar_EditClicked;
            ToolBarControl1.DeleteClicked += ItemsToolbar_DeleteClicked;
            ToolBarControl1.RefreshClicked += ItemsToolbar_RefreshClicked;
        }

        private async void ItemsForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadItemsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Failed to load items.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadItemsAsync()
        {
            if (CheckItemsLoading())
                return;

            _isLoadingItems = true;

            try
            {
                var items = await _unitOfWork.Items
                    .Select()
                    .Include(i => i.Category)
                    .ToListAsync();

                gridControl1.DataSource = items;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingItems = false;
            }
        }

        private void gridView1_FocusedRowChanged(
            object sender,
            FocusedRowChangedEventArgs e)
        {
        }

        private async void ItemsToolbar_CreateClicked(object sender, EventArgs e)
        {
            if (CheckItemsLoading())
                return;
            var editForm = Program.ServiceProvider
                .GetService(typeof(ItemsEditForm)) as ItemsEditForm;
            var result = editForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await LoadItemsAsync();
            }

        }

        private async void ItemsToolbar_EditClicked(object sender, EventArgs e)
        {
            if (CheckItemsLoading())
                return;
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

            using (var editForm =
                ActivatorUtilities.CreateInstance<ItemsEditForm>(
                    Program.CurrentScopeProvider,
                    selectedItem))
            {
                var result = editForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    await LoadItemsAsync();
                }
            }
        }

        private async void ItemsToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckItemsLoading())
                return;
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
                item.IsDeleted = true;
                item.DeletedAt = DateTime.UtcNow;

                item.DeletedById = CurrentUserId == Guid.Empty
                    ? (Guid?)null
                    : CurrentUserId;

                await _unitOfWork.SaveChangesAsync();

                await LoadItemsAsync();

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

        private async void ItemsToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckItemsLoading())
                return;
            UseWaitCursor = true;
            
            try
            {
                await LoadItemsAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Failed to refresh items.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                await Task.Delay(300);
                UseWaitCursor = false;
            }
        }
        private bool CheckItemsLoading()
        {
            if (!_isLoadingItems)
                return false;

            XtraMessageBox.Show(
                "جاري تحميل المنتجات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل المنتجات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

    }
}
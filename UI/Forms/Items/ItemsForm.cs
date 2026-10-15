using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
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
        private readonly IItemService _itemsService;

        //public Guid CurrentUserId { get; set; }
        private bool _isLoadingItems;

        public ItemsForm(IItemService itemsService)
        {
            _itemsService = itemsService;
            InitializeComponent();


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
                    $"فشل تحميل المنتجات.\n{ex.Message}",
                    "خطأ",
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
                var items = await _itemsService.GetAllItemsAsync();

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



        private async void ItemsToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckItemsLoading())
                return;

            using (var editForm = Program.ServiceProvider
                .GetService(typeof(ItemsEditForm)) as ItemsEditForm)
            {

                var result = editForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                await LoadItemsAsync();
            }
            }
        }

        private async void ItemsToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckItemsLoading())
                return;

            var selectedItem = gridView1.GetFocusedRow() as ItemDto;

            if (selectedItem == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار منتج لتعديله.",
                    "اختيار منتج",
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

            var item = gridView1.GetFocusedRow() as ItemDto;

            if (item == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار منتج أولاً.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var result = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف المنتج '{item.Name}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                
               await  _itemsService.DeleteItemAsync(item.Id);

                await LoadItemsAsync();

                XtraMessageBox.Show(
                    "تم حذف المنتج بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف المنتج.\n{ex.Message}",
                    "خطأ",
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
                    $"فشل تحديث قائمة المنتجات.\n{ex.Message}",
                    "خطأ",
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
                "جارٍ تحميل المنتجات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل المنتجات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }
}

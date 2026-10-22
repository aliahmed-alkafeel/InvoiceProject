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
using UI.Extensions;


namespace UI.Forms.Categories
{
    public partial class CategoriesForm : XtraForm
    {
        private readonly ICategoryService _categoryService;

        //public Guid CurrentUserId { get; set; }
        private bool _isLoadingCategories;

        public CategoriesForm(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            InitializeComponent();


            toolBarControl1.CreateClicked += CategoriesToolbar_CreateClicked;
            toolBarControl1.EditClicked += CategoriesToolbar_EditClicked;
            toolBarControl1.DeleteClicked += CategoriesToolbar_DeleteClicked;
            toolBarControl1.RefreshClicked += CategoriesToolbar_RefreshClicked;
        }

        private async void CategoriesForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل الفئات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadCategoriesAsync()
        {
            if (CheckCategoriesLoading())
                return;

            _isLoadingCategories = true;
            try
            {
                var categorys =  this.WithLoading(
                    cts => _categoryService.GetAllCategoriesAsync(cts),
                    "جارٍ تحميل الفئات، يرجى الانتظار...");

                gridControl1.DataSource = categorys;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingCategories = false;
            }
        }



        private async void CategoriesToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCategoriesLoading())
                return;

            using (var editForm = Program.ServiceProvider
                .GetService(typeof(CategoriesManageForm)) as CategoriesManageForm)
            {

                var result = editForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadCategoriesAsync();
                }
            }
        }

        private async void CategoriesToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCategoriesLoading())
                return;

            var selectedCategory = gridView1.GetFocusedRow() as CategoryDto;

            if (selectedCategory == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار فئة لتعديله.",
                    "اختيار فئة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (var editForm =
                ActivatorUtilities.CreateInstance<CategoriesManageForm>(
                    Program.CurrentScopeProvider,
                    selectedCategory))
            {
                var result = editForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadCategoriesAsync();
                }
            }
        }

        private async void CategoriesToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCategoriesLoading())
                return;

            var category = gridView1.GetFocusedRow() as CategoryDto;

            if (category == null)
            {
                XtraMessageBox.Show(
                    ".يرجى اختيار فئة أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var result = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف الفئة '{category.Name}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {

                await _categoryService.DeleteCategoryAsync(category.Id);

                await LoadCategoriesAsync();

                XtraMessageBox.Show(
                    ".تم حذف الفئة بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف الفئة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void CategoriesToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCategoriesLoading())
                return;
  
            UseWaitCursor = true;

            try
            {
                await LoadCategoriesAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة الفئات.\n{ex.Message}",
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

        private bool CheckCategoriesLoading()
        {
            if (!_isLoadingCategories)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل الفئات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل الفئات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }
}

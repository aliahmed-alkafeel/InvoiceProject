using Data.Configurations.DTOsConfigurations;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.XtraEditors;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extentions;

namespace UI.Forms.Categories
{
    public partial class CategoriesManageForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ICategoryService _categoryService;
        private CategoryDto _selectedCategory;
        private bool isEdit => _selectedCategory != null;
        public CategoriesManageForm(IUnitOfWork unitOfWork,
            ICategoryService categorysService, ICategoryService categoryService, CategoryDto selectedCategory = null)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _selectedCategory = selectedCategory;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var newCategory = new CategoryDto()
            {
                Id = isEdit ? _selectedCategory.Id : Guid.NewGuid(),
                Name = txtName.Text,
                IsActive = chkIsActive.Checked,
                Notes = txtNotes.Text
            };
            if (!ValidationHelper.IsValid(new CategoryDtoConfiguration(), newCategory, out var errors))
            {
                XtraMessageBox.Show(errors);
                return;
            }
            if (!isEdit)
            {
                var result = await _categoryService.CreateCategoryAsync(newCategory);
                if (result)
                {
                    MessageBox.Show("تم إضافة الفئة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في إضافة الفئة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var result = await _categoryService.UpdateCategoryAsync(newCategory);
                if (result)
                {
                    MessageBox.Show("تم تعديل الفئة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في تعديل الفئة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveCancelControl_CancelClicked()
        {
            Close();
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
        }

        private void CategoriesManageForm_Load(object sender, EventArgs e)
        {
            LoadCategoryDetails(_selectedCategory);
        }
        private void LoadCategoryDetails(CategoryDto category)
        {
            _selectedCategory = category;
            if (category == null)
            {
                ClearDetails();
                return;
            }
            txtName.Text = category.Name;
            chkIsActive.Checked = category.IsActive;
            txtNotes.Text = category.Notes;

        }
        private void ClearDetails()
        {
            txtName.Text = string.Empty;
            chkIsActive.Checked = false;
            txtNotes.Text = string.Empty;

        }
    }
}
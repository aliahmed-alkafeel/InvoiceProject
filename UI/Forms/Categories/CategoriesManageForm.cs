using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Categories
{
    public partial class CategoriesManageForm : XtraForm
    {
        private readonly ICategoryService _categoryService;
        private readonly BindingSource _categoryBindingSource = new BindingSource();
        private CategoryDto _selectedCategory;
        private bool isEdit => _selectedCategory != null;

        public CategoriesManageForm(
            ICategoryService categoryService, CategoryDto selectedCategory = null)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _selectedCategory = selectedCategory;

            _categoryBindingSource.DataSource = typeof(CategoryDto);
            BindControls();

            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private void BindControls()
        {
            txtName.DataBindings.Add(
                nameof(txtName.Text), _categoryBindingSource, nameof(CategoryDto.Name),
                true, DataSourceUpdateMode.OnPropertyChanged);

            chkIsActive.DataBindings.Add(
                nameof(chkIsActive.Checked), _categoryBindingSource, nameof(CategoryDto.IsActive),
                true, DataSourceUpdateMode.OnPropertyChanged);

            txtNotes.DataBindings.Add(
                nameof(txtNotes.Text), _categoryBindingSource, nameof(CategoryDto.Notes),
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private async void SaveCancelControl_SaveClicked()
        {
            _categoryBindingSource.EndEdit();
            var current = _categoryBindingSource.Current as CategoryDto;

            if (!isEdit)
            {
                var newCategory = new CreateCategoryDto()
                {
                    Id = Guid.NewGuid(),
                    Name = current.Name,
                    IsActive = current.IsActive,
                    Notes = current.Notes
                };

                if (!ValidationHelper.IsValid(new CreateCategoryDtoConfiguration(), newCategory, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

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
                var newCategory = new UpdateCategoryDto()
                {
                    Id = _selectedCategory.Id,
                    Name = current.Name,
                    IsActive = current.IsActive,
                    Notes = current.Notes
                };

                if (!ValidationHelper.IsValid(new UpdateCategoryDtoConfiguration(), newCategory, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

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

            if (!isEdit)
            {
                lblTitle.Text = "إضافة فئة";
                saveCancelControl21.SaveText = "إضافة";
                _categoryBindingSource.DataSource = new CategoryDto
                {
                    IsActive = chkIsActive.Checked
                };
                return;
            }

            _categoryBindingSource.DataSource = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                IsActive = category.IsActive,
                Notes = category.Notes
            };
        }
    }
}
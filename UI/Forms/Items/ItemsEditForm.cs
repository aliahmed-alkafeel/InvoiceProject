using Data.Configurations.DTOsConfigurations;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.XtraEditors;
using Models.DTOs;
using Models.Entities;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Items
{
    public partial class ItemsEditForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IItemService _itemsService;
        private readonly ICategoryService _categoryService;
        private ItemDto _selectedItem;
        private bool isEdit => _selectedItem != null;
        public ItemsEditForm(
            IItemService itemsService, ICategoryService categoryService, ItemDto selectedItem = null)
        {
            InitializeComponent();
            _itemsService = itemsService;
            _categoryService = categoryService;
            _selectedItem = selectedItem;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void SaveCancelControl_SaveClicked()
        {
            if(!isEdit)
            {
                var newItem = new CreateItemDto()
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text,
                    Price = string.IsNullOrWhiteSpace(spnPrice.Text) ? (decimal?)null : Convert.ToDecimal(spnPrice.EditValue),
                    CategoryGuid = cmbCategories.EditValue is Guid categoryId ? categoryId : Guid.Empty,
                    IsActive = chkIsActive.Checked,
                    Notes = txtNotes.Text
                };

                if (!ValidationHelper.IsValid(new CreateItemDtoConfiguration(), newItem, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _itemsService.CreateItemAsync(newItem);
                if(result)
                {
                    MessageBox.Show("تم إضافة المنتج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في إضافة المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var newItem = new UpdateItemDto()
                {
                    Id = _selectedItem.Id,
                    Name = txtName.Text,
                    Price = string.IsNullOrWhiteSpace(spnPrice.Text) ? (decimal?)null : Convert.ToDecimal(spnPrice.EditValue),
                    CategoryGuid = cmbCategories.EditValue is Guid categoryId ? categoryId : Guid.Empty,
                    IsActive = chkIsActive.Checked,
                    Notes = txtNotes.Text
                };

                if (!ValidationHelper.IsValid(new UpdateItemDtoConfiguration(), newItem, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _itemsService.UpdateItemAsync(newItem);
                if (result)
                {
                    MessageBox.Show("تم تعديل المنتج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في تعديل المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void ItemsEditForm_Load(object sender, EventArgs e)
        {
            var categories = ( this.WithLoading(
            cts => _categoryService.GetAllCategoriesAsync(cts)))
                .Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToList();

            cmbCategories.Properties.DataSource = categories;
            cmbCategories.Properties.DisplayMember = "Name";
            cmbCategories.Properties.ValueMember = "Id";
            cmbCategories.Properties.NullText = "اختر التصنيف";
            if (!isEdit)
            {
                lblTitle.Text = "إضافة منتج";
                saveCancelControl21.SaveText = "إضافة";
            }

            LoadItemDetails(_selectedItem);
        }
        private void LoadItemDetails(ItemDto item)
        {
            _selectedItem = item;
            if (item == null)
            {
                ClearDetails();
                return;
            }
            txtName.Text = item.Name;
            spnPrice.EditValue = item.Price;
            cmbCategories.EditValue = item.Category.Id;
            chkIsActive.Checked = item.IsActive;
            txtNotes.Text = item.Notes;
        }
        private void ClearDetails()
        {
            txtName.Text = string.Empty;
            cmbCategories.EditValue = null;
            spnPrice.EditValue = null;
            chkIsActive.Checked = false;
            txtNotes.Text = string.Empty;

        }
    }
}
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms.Items
{
    public partial class ItemsEditForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IItemsService _itemsService;
        private readonly ICategoryService _categoryService;
        private Item _selectedItem;
        public ItemsEditForm(IUnitOfWork unitOfWork,
            IItemsService itemsService, ICategoryService categoryService, Item selectedItem = null)
        {
            InitializeComponent();
            _itemsService = itemsService;
            _categoryService = categoryService;
            _selectedItem = selectedItem;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void SaveCancelControl_SaveClicked(object sender, EventArgs e)
        {
            if(_selectedItem == null)
            {
                var newItem = new ItemDto()
                {
                Name = txtName.Text,
                Price = Convert.ToDecimal(txtPrice.EditValue),
                CategoryGuid = (Guid) cmbCategories.EditValue,
                IsActive = chkIsActive.Checked,
                Notes = txtNotes.Text
                };
                var result = await _itemsService.CreateItemAsync(newItem);
                if(result)
                {
                    MessageBox.Show("تم إضافة المنتج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في إضافة المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void SaveCancelControl_CancelClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
        }

        private async void ItemsEditForm_Load(object sender, EventArgs e)
        {

            var categories = (await _categoryService.GetAllCategoriesAsync())
        .Select(c => new
        {
            c.Id,
            c.Name
        });
            cmbCategories.Properties.DataSource = categories;
            cmbCategories.Properties.DisplayMember = "Name";
            cmbCategories.Properties.ValueMember = "Id";
            cmbCategories.Properties.NullText = "اختر التصنيف";
            if (_selectedItem == null)
            {
                lblTitle.Text = "إضافة منتج";
            }
            LoadItemDetails(_selectedItem);
        }
        private void LoadItemDetails(Item item)
        {
            _selectedItem = item;

            if (item == null)
            {
                ClearDetails();
                return;
            }

            txtName.Text = item.Name;
            txtPrice.EditValue = item.Price;
            cmbCategories.EditValue = item.Category?.Name;
            chkIsActive.Checked = item.IsActive;
            txtNotes.Text = item.Notes;

        }
        private void ClearDetails()
        {
            txtName.Text = string.Empty;
            cmbCategories.EditValue = null;
            txtPrice.EditValue = null;
            chkIsActive.Checked = false;
            txtNotes.Text = string.Empty;

        }
    }
}
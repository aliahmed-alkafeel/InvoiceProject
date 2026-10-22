using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Bills
{
    public partial class BillsManageForm : XtraForm
    {
        private readonly IBillService _billService;
        private readonly IAccountsTreeService _accountsTreeService;
        private readonly ICurrencyService _currencyService;
        private readonly IItemService _itemService;
        private readonly BindingList<BillItemRow> _billItems = new BindingList<BillItemRow>();
        private IDictionary<Guid, ItemDto> _itemLookup = new Dictionary<Guid, ItemDto>();
        private BillDto _selectedBill;

        private bool isEdit => _selectedBill != null;

        public BillsManageForm(
            IBillService billService,
            IAccountsTreeService accountsTreeService,
            ICurrencyService currencyService,
            IItemService itemService,
            BillDto selectedBill = null)
        {
            InitializeComponent();

            _billService = billService;
            _accountsTreeService = accountsTreeService;
            _currencyService = currencyService;
            _itemService = itemService;
            _selectedBill = selectedBill;

            gridControlItems.DataSource = _billItems;

            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void BillsManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadLookupsAsync();

                LoadBillDetails(_selectedBill);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل بيانات الفاتورة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookupsAsync()
        {
            var accounts = (await _accountsTreeService.GetAllAccountsAsync())
                .Where(a => a.IsLeaf && a.IsActive)
                .Select(a => new
                {
                    a.Id,
                    a.AccountName
                })
                .ToList();

            cmbAccountTree.Properties.DataSource = accounts;
            cmbAccountTree.Properties.DisplayMember = "AccountName";
            cmbAccountTree.Properties.ValueMember = "Id";
            cmbAccountTree.Properties.NullText = "اختر الحساب";

            var currencies = (await _currencyService.GetAllCurrenciesAsync())
                .Select(c => new
                {
                    c.Id,
                    c.CurrencyName
                })
                .ToList();

            cmbCurrency.Properties.DataSource = currencies;
            cmbCurrency.Properties.DisplayMember = "CurrencyName";
            cmbCurrency.Properties.ValueMember = "Id";
            cmbCurrency.Properties.NullText = "اختر العملة";

            cmbBillType.Properties.Items.Clear();
            cmbBillType.Properties.Items.AddRange(new object[] { BillType.In, BillType.Out });
            cmbBillType.Properties.NullText = "اختر نوع الفاتورة";

            var items = (await _itemService.GetAllItemsAsync())
                .Where(i => i.IsActive)
                .ToList();

            _itemLookup = BillItemsGridHelper.ConfigureItemColumn(colItem, items);

            BillItemsGridHelper.ConfigureNumericColumn(colQty, 0m, 1000000m);
            BillItemsGridHelper.ConfigureNumericColumn(colPrice, 0m, 1000000m);
        }

        private void LoadBillDetails(BillDto bill)
        {
            _selectedBill = bill;

            if (bill == null)
            {
                lblTitle.Text = "إضافة فاتورة";
                saveCancelControl21.SaveText = "إضافة";

                spinBillNumber.EditValue = null;
                cmbBillType.EditValue = null;
                cmbAccountTree.EditValue = null;
                cmbCurrency.EditValue = null;
                spnCurrencyEqualValue.EditValue = null;
                deDate.EditValue = DateTime.Now;
                txtNotes.Text = string.Empty;

                _billItems.Clear();
                UpdateTotal();

                return;
            }

            lblTitle.Text = "تعديل الفاتورة";
            saveCancelControl21.SaveText = "تعديل";

            spinBillNumber.EditValue = bill.BillNumber;
            cmbBillType.EditValue = bill.BillType;
            cmbAccountTree.EditValue = bill.AccountTreeGuid;
            cmbCurrency.EditValue = bill.CurrencyGuid;
            spnCurrencyEqualValue.EditValue = bill.CurrencyEqualValue;
            deDate.EditValue = bill.Date;
            txtNotes.Text = bill.Notes ?? string.Empty;

            _billItems.Clear();

            if (bill.BillItems != null)
            {
                foreach (var billItem in bill.BillItems)
                {
                    var row = BillItemRow.FromDto(billItem);

                    if (row != null)
                        _billItems.Add(row);
                }
            }

            UpdateTotal();
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var billItems = _billItems
                .Where(bi => bi.ItemGuid != Guid.Empty)
                .Select(bi => bi.ToDto())
                .ToList();

            var accountTreeGuid = cmbAccountTree.EditValue is Guid accountGuid ? accountGuid : Guid.Empty;
            var currencyGuid = cmbCurrency.EditValue is Guid currencyGuidValue ? currencyGuidValue : Guid.Empty;
            var billDate = deDate.EditValue is DateTime dateValue ? dateValue : DateTime.Now;
            var currencyEqualValue = spnCurrencyEqualValue.EditValue == null
                ? 0m
                : Convert.ToDecimal(spnCurrencyEqualValue.EditValue);
            var billType = cmbBillType.EditValue as string;
            var billNumber = GetBillNumberFromInput();

            if (!isEdit)
            {
                var newBill = new CreateBillDto
                {
                    Id = Guid.NewGuid(),
                    BillNumber = billNumber,
                    BillType = billType,
                    AccountTreeGuid = accountTreeGuid,
                    CurrencyGuid = currencyGuid,
                    CurrencyEqualValue = currencyEqualValue,
                    Date = billDate,
                    Notes = txtNotes.Text,
                    BillItems = billItems
                };

                if (!ValidationHelper.IsValid(
                    new CreateBillDtoConfiguration(),
                    newBill,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _billService.CreateBillAsync(newBill);

                if (result)
                {
                    XtraMessageBox.Show(
                        "تم إضافة الفاتورة بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    XtraMessageBox.Show(
                        "فشل في إضافة الفاتورة",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            var updateBill = new UpdateBillDto
            {
                Id = _selectedBill.Id,
                BillNumber = billNumber,
                BillType = billType,
                AccountTreeGuid = accountTreeGuid,
                CurrencyGuid = currencyGuid,
                CurrencyEqualValue = currencyEqualValue,
                Date = billDate,
                Notes = txtNotes.Text,
                BillItems = billItems
            };

            if (!ValidationHelper.IsValid(
                new UpdateBillDtoConfiguration(),
                updateBill,
                out var updateErrors))
            {
                XtraMessageBox.Show(updateErrors);
                return;
            }

            var updateResult = await _billService.UpdateBillAsync(updateBill);

            if (updateResult)
            {
                XtraMessageBox.Show(
                    "تم تعديل الفاتورة بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                XtraMessageBox.Show(
                    "فشل في تعديل الفاتورة",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveCancelControl_CancelClicked()
        {
            Close();
        }

        /// <summary>
        /// قراءة رقم الفاتورة من حقل الإدخال (0 عند تركه فارغاً).
        /// </summary>
        private int GetBillNumberFromInput()
        {
            var value = spinBillNumber.EditValue;

            if (value == null)
                return 0;

            if (value is int number)
                return number;

            if (value is long longNumber)
                return (int)longNumber;

            if (value is decimal decimalNumber)
                return (int)decimalNumber;

            int parsed;
            return int.TryParse(value.ToString(), out parsed) ? parsed : 0;
        }

        private void gridViewItems_CellValueChanged(
            object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridViewItems.GetRow(e.RowHandle) as BillItemRow;

            if (row != null && e.Column == colItem)
            {
                // عند تغيير المادة داخل الشبكة: تحديث اسم المادة والسعر الافتراضي.
                BillItemsGridHelper.ApplyItemToRow(row, _itemLookup);
            }

            UpdateTotal();
        }

        private void gridViewItems_RowCountChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        /// <summary>
        /// إضافة بند جديد إلى الشبكة وفتح خلية المادة للتعديل المباشر.
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            gridViewItems.AddNewRow();
            gridViewItems.ShowEditor();
        }

        /// <summary>
        /// حذف البند المحدد من الشبكة.
        /// </summary>
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridViewItems.FocusedRowHandle < 0)
                return;

            gridViewItems.DeleteRow(gridViewItems.FocusedRowHandle);
        }

        private void UpdateTotal()
        {
            var total = _billItems.Sum(bi => bi.Qty * bi.Price);

            lblTotal.Text = $"الإجمالي: {total:N2}";
        }
    }
}

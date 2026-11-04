using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        private readonly BillDto _selectedBill;

        private readonly BindingList<BillItemDto> _billItems = new BindingList<BillItemDto>();
        private IDictionary<Guid, ItemDto> _itemLookup = new Dictionary<Guid, ItemDto>();

        private bool _isLoadingBillDetails;
        private bool _isMainCurrency;
        private int _currencySelectionVersion;
        private decimal _currentCurrencyEqualValue = 1m;

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

            gridViewItems.InitNewRow += gridViewItems_InitNewRow;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += Close;
            cmbCurrency.EditValueChanged += CmbCurrency_EditValueChanged;
            spnCurrencyEqualValue.Validated += SpnCurrencyEqualValue_Validated;
        }


        private async void BillsManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadLookupsAsync();
                LoadBillDetails(_selectedBill);

                if (_selectedBill != null)
                    await ApplyLoadedCurrencyRulesAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل بيانات الفاتورة.\n{ex.Message}");
            }
        }

        private async Task LoadLookupsAsync()
        {
            cmbAccountTree.Properties.DataSource =
                (await this.WithLoading(
                    cts => _accountsTreeService.GetAllAccountsAsync(cts),
                    "جارٍ تحميل الحسابات، يرجى الانتظار..."))
                .Where(a => a.IsLeaf && a.IsActive)
                .Select(a => new { a.Id, a.AccountName })
                .ToList();

            cmbCurrency.Properties.DataSource =
                (await this.WithLoading(
                    cts => _currencyService.GetAllCurrenciesAsync(cts),
                    "جارٍ تحميل العملات، يرجى الانتظار..."))
                .Select(c => new { c.Id, c.CurrencyName })
                .ToList();

            cmbBillType.Properties.DataSource = BillType.All
                .Select(type => new { Value = type, Text = type })
                .ToList();

            var items = (await this.WithLoading(
                cts => _itemService.GetAllItemsAsync(cts),
                "جارٍ تحميل المواد، يرجى الانتظار..."))
                .Where(i => i.IsActive)
                .ToList();

            repositoryItemGridLookUpEdit.DataSource = items;
            _itemLookup = items.ToDictionary(i => i.Id);
        }

        private void LoadBillDetails(BillDto bill)
        {
            _isLoadingBillDetails = true;

            try
            {
                _isMainCurrency = false;
                spnCurrencyEqualValue.Properties.ReadOnly = true;

                if (bill == null)
                {
                    cmbCurrency.EditValue = null;
                    lblTitle.Text = "إضافة فاتورة";
                    saveCancelControl21.SaveText = "إضافة";

                    spinBillNumber.Enabled = false;
                    spinBillNumber.Properties.AllowNullInput = DefaultBoolean.True;
                    spinBillNumber.EditValue = null;
                    spinBillNumber.Properties.NullText = "يتم توليده تلقائياً عند الإنشاء";

                    _currentCurrencyEqualValue = 1m;
                    spnCurrencyEqualValue.EditValue = 1m;
                    deDate.EditValue = DateTime.Now;
                }
                else
                {
                    lblTitle.Text = "تعديل فاتورة";
                    saveCancelControl21.SaveText = "تعديل";

                    spinBillNumber.Enabled = true;
                    _currentCurrencyEqualValue = bill.CurrencyEqualValue;
                    spnCurrencyEqualValue.EditValue = bill.CurrencyEqualValue;

                    spinBillNumber.EditValue = bill.BillNumber;
                    cmbBillType.EditValue = bill.BillType;
                    cmbAccountTree.EditValue = bill.AccountTreeGuid;
                    cmbCurrency.EditValue = bill.CurrencyGuid;
                    deDate.EditValue = bill.Date;
                    txtNotes.Text = bill.Notes;

                    foreach (var item in bill.BillItems)
                        _billItems.Add(item);
                }

                UpdateTotal();
            }
            finally
            {
                _isLoadingBillDetails = false;
            }
        }

        private async Task ApplyLoadedCurrencyRulesAsync()
        {
            if (!(cmbCurrency.EditValue is Guid currencyGuid) ||
                currencyGuid == Guid.Empty)
                throw new InvalidOperationException("العملة المحددة غير صالحة.");

            var currency = await _currencyService.GetCurrencyByIdAsync(currencyGuid);

            if (currency == null)
                throw new InvalidOperationException("العملة المحددة غير موجودة.");

            if (_currentCurrencyEqualValue <= 0)
                throw new InvalidOperationException("معامل تحويل الفاتورة غير صالح.");

            _isMainCurrency = currency.IsMain;

            if (_isMainCurrency)
            {
                RecalculateItemPrices(_currentCurrencyEqualValue, 1m);
                _currentCurrencyEqualValue = 1m;
                spnCurrencyEqualValue.EditValue = 1m;
                spnCurrencyEqualValue.Properties.ReadOnly = true;
            }
            else
            {
                spnCurrencyEqualValue.EditValue = _currentCurrencyEqualValue;
                spnCurrencyEqualValue.Properties.ReadOnly = false;
            }

            gridViewItems.RefreshData();
            UpdateTotal();
        }



        private async void SaveCancelControl_SaveClicked()
        {
            try
            {
                gridViewItems.CloseEditor();
                gridViewItems.UpdateCurrentRow();

                var billItems = _billItems
                    .Where(bi => bi.ItemGuid != Guid.Empty)
                    .ToList();

                var accountGuid = cmbAccountTree.EditValue is Guid account
                    ? account : Guid.Empty;

                var currencyGuid = cmbCurrency.EditValue is Guid currency
                    ? currency : Guid.Empty;

                var billDate = deDate.EditValue is DateTime date
                    ? date : DateTime.Now;

                var billType = cmbBillType.EditValue as string;

                var currencyEqualValue = _isMainCurrency
                    ? 1m
                    : Convert.ToDecimal(spnCurrencyEqualValue.EditValue ?? 0m);

                if (!isEdit)
                {
                    var newBill = new CreateBillDto
                    {
                        Id = Guid.NewGuid(),
                        BillNumber = 0,
                        BillType = billType,
                        AccountTreeGuid = accountGuid,
                        CurrencyGuid = currencyGuid,
                        CurrencyEqualValue = currencyEqualValue,
                        Date = billDate,
                        Notes = txtNotes.Text,
                        BillItems = billItems
                    };

                    if (!ValidationHelper.IsValid(
                        new CreateBillDtoConfiguration(), newBill, out var errors))
                    {
                        MessageHelper.Error(errors);
                        return;
                    }

                    OnSaved(await _billService.CreateBillAsync(newBill), "إضافة");
                    return;
                }

                var updateBill = new UpdateBillDto
                {
                    Id = _selectedBill.Id,
                    BillNumber = Convert.ToInt32(spinBillNumber.EditValue ?? 0),
                    BillType = billType,
                    AccountTreeGuid = accountGuid,
                    CurrencyGuid = currencyGuid,
                    CurrencyEqualValue = currencyEqualValue,
                    Date = billDate,
                    Notes = txtNotes.Text,
                    BillItems = billItems
                };

                if (!ValidationHelper.IsValid(
                    new UpdateBillDtoConfiguration(), updateBill, out var updateErrors))
                {
                    MessageHelper.Error(updateErrors);
                    return;
                }

                OnSaved(await _billService.UpdateBillAsync(updateBill), "تعديل");
            }
            catch (Exception ex)
            {
                MessageHelper.Error(ex.Message);
            }
        }

        private void OnSaved(bool success, string action)
        {
            if (!success)
            {
                MessageHelper.Error($"فشل في {action} الفاتورة");
                return;
            }

            MessageHelper.Success($"تم {action} الفاتورة بنجاح");
            DialogResult = DialogResult.OK;
            Close();
        }



        private void gridViewItems_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (gridViewItems.GetRow(e.RowHandle) is BillItemDto row &&
                row.Id == Guid.Empty)
                row.Id = Guid.NewGuid();
        }

        private void gridViewItems_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colItem &&
                gridViewItems.GetRow(e.RowHandle) is BillItemDto row)
            {
                BillItemsGridHelper.ApplyItemToRow(row, _itemLookup, _currentCurrencyEqualValue);
                gridViewItems.RefreshRow(e.RowHandle);
            }

            UpdateTotal();
        }

        private void gridViewItems_RowCountChanged(object sender, EventArgs e)
            => UpdateTotal();

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbCurrency.EditValue == null)
            {
                MessageBox.Show("يرجى تحديد العملة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gridViewItems.AddNewRow();
            gridViewItems.ShowEditor();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridViewItems.FocusedRowHandle >= 0)
                gridViewItems.DeleteRow(gridViewItems.FocusedRowHandle);
        }


        private void RecalculateItemPrices(decimal oldRate, decimal newRate)
        {
            if (oldRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(oldRate), "معامل التحويل السابق غير صالح.");

            if (newRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(newRate), "معامل التحويل الجديد غير صالح.");

            foreach (var row in _billItems)
            {
                row.Price = Math.Round(
                    row.Price * oldRate / newRate, 6, MidpointRounding.AwayFromZero);
            }
        }

        private void SpnCurrencyEqualValue_Validated(object sender, EventArgs e)
        {
            if (_isLoadingBillDetails)
                return;

            if (!(cmbCurrency.EditValue is Guid currencyGuid) ||
                currencyGuid == Guid.Empty)
                return;

            if (_isMainCurrency)
            {
                spnCurrencyEqualValue.EditValue = 1m;
                _currentCurrencyEqualValue = 1m;
                return;
            }

            if (!decimal.TryParse(
                Convert.ToString(spnCurrencyEqualValue.EditValue),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out var newRate) || newRate <= 0)
            {
                MessageHelper.Error("معامل تحويل العملة يجب أن يكون أكبر من صفر.");
                spnCurrencyEqualValue.EditValue = _currentCurrencyEqualValue;
                return;
            }

            var oldRate = _currentCurrencyEqualValue;

            if (oldRate <= 0)
            {
                MessageHelper.Error("معامل التحويل السابق غير صالح.");
                return;
            }

            if (newRate == oldRate)
                return;

            RecalculateItemPrices(oldRate, newRate);
            _currentCurrencyEqualValue = newRate;

            gridViewItems.RefreshData();
            UpdateTotal();
        }

        private async void CmbCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (_isLoadingBillDetails)
                return;

            var requestVersion = ++_currencySelectionVersion;

            if (!(cmbCurrency.EditValue is Guid currencyGuid) ||
                currencyGuid == Guid.Empty)
            {
                _isMainCurrency = false;
                spnCurrencyEqualValue.EditValue = 0m;
                spnCurrencyEqualValue.Properties.ReadOnly = true;
                return;
            }

            _isMainCurrency = false;
            spnCurrencyEqualValue.Properties.ReadOnly = true;

            try
            {
                var currency = await _currencyService.GetCurrencyByIdAsync(currencyGuid);

                if (requestVersion != _currencySelectionVersion ||
                    !(cmbCurrency.EditValue is Guid currentGuid) ||
                    currentGuid != currencyGuid)
                    return;

                if (currency == null)
                {
                    MessageHelper.Error("العملة المحددة غير موجودة.");
                    return;
                }

                var newRate = currency.IsMain ? 1m : currency.CurrencyEqual;

                if (newRate <= 0)
                {
                    MessageHelper.Error("سعر صرف العملة غير صالح.");
                    return;
                }

                var oldRate = _currentCurrencyEqualValue;

                if (oldRate <= 0)
                {
                    MessageHelper.Error("معامل التحويل السابق غير صالح.");
                    return;
                }

                if (oldRate != newRate)
                    RecalculateItemPrices(oldRate, newRate);

                _currentCurrencyEqualValue = newRate;
                _isMainCurrency = currency.IsMain;

                spnCurrencyEqualValue.EditValue = newRate;
                spnCurrencyEqualValue.Properties.ReadOnly = currency.IsMain;

                gridViewItems.RefreshData();
                UpdateTotal();
            }
            catch (Exception ex)
            {
                if (requestVersion == _currencySelectionVersion)
                    MessageHelper.Error($"فشل تحميل بيانات العملة.\n{ex.Message}");
            }
        }


        private void UpdateTotal()
        {
            lblTotal.Text = $"الإجمالي: {_billItems.Sum(bi => bi.Qty * bi.Price):N2}";
        }
    }
}
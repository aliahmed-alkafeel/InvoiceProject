using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
        private readonly BindingList<BillItemDto> _billItems = new BindingList<BillItemDto>();
        private IDictionary<Guid, ItemDto> _itemLookup = new Dictionary<Guid, ItemDto>();
        private readonly BillDto _selectedBill;
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
        }

        private async void BillsManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadLookupsAsync();
                await LoadBillDetails(_selectedBill);
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل بيانات الفاتورة.\n{ex.Message}");
            }
        }

        private async Task LoadLookupsAsync()
        {
            cmbAccountTree.Properties.DataSource = (await this.WithLoading(async cts =>
                await _accountsTreeService.GetAllAccountsAsync(cts),
                "جارٍ تحميل الحسابات، يرجى الانتظار..."))
                .Where(a => a.IsLeaf && a.IsActive)
                .Select(a => new { a.Id, a.AccountName })
                .ToList();


            cmbCurrency.Properties.DataSource = (await this.WithLoading(async cts =>
                await _currencyService.GetAllCurrenciesAsync(cts),
                "جارٍ تحميل العملات، يرجى الانتظار..."))
                .Select(c => new { c.Id, c.CurrencyName })
                .ToList();


            cmbBillType.Properties.DataSource = BillType.All
                .Select(type => new
                {
                    Value = type,
                    Text = type
                })
                .ToList();


            var items = (await this.WithLoading(async cts => await _itemService.GetAllItemsAsync(cts), "جارٍ تحميل المواد، يرجى الانتظار...")).Where(i => i.IsActive);

            _itemLookup = BillItemsGridHelper.ConfigureGrid(colItem, colQty, colPrice, colTotal, items);
        }

        private async Task LoadBillDetails(BillDto bill)
        {
            var isNew = bill == null;

            lblTitle.Text = isNew ? "إضافة فاتورة" : "تعديل الفاتورة";
            saveCancelControl21.SaveText = isNew ? "إضافة" : "تعديل";

            spinBillNumber.Enabled = !isNew;
            spinBillNumber.Properties.NullText = isNew ? "يتم التوليد تلقائياً" : "أدخل رقم الفاتورة";
            spinBillNumber.EditValue = bill?.BillNumber;
            cmbBillType.EditValue = bill?.BillType;
            cmbAccountTree.EditValue = bill?.AccountTreeGuid;
            cmbCurrency.EditValue = bill?.CurrencyGuid;
            if (isNew)
            {
                spnCurrencyEqualValue.Enabled = false;
                spnCurrencyEqualValue.Properties.ReadOnly = true;
                if (bill?.CurrencyGuid != null && bill.CurrencyGuid != Guid.Empty)
                {
                    try
                    {
                        var currency = await _currencyService.GetCurrencyByIdAsync(bill.CurrencyGuid);
                        spnCurrencyEqualValue.EditValue = currency?.CurrencyEqual ?? 1m;
                    }
                    catch
                    {
                        spnCurrencyEqualValue.EditValue = 1m;
                    }
                }
                else
                {
                    spnCurrencyEqualValue.EditValue = 1m;
                }
            }
            else
            {
                spnCurrencyEqualValue.Enabled = true;
                spnCurrencyEqualValue.Properties.ReadOnly = false;
                spnCurrencyEqualValue.EditValue = bill?.CurrencyEqualValue;
            }
            deDate.EditValue = bill?.Date ?? DateTime.Now;
            txtNotes.Text = bill?.Notes ?? string.Empty;

            _billItems.Clear();

            foreach (var billItem in bill?.BillItems ?? new HashSet<BillItemDto>())
                _billItems.Add(billItem);

            UpdateTotal();
        }

        private async void SaveCancelControl_SaveClicked()
        {
            // إنهاء تحرير الخلية الحالية حتى لا تضيع آخر قيمة مكتوبة.
            gridViewItems.CloseEditor();
            gridViewItems.UpdateCurrentRow();

            var billItems = _billItems.Where(bi => bi.ItemGuid != Guid.Empty).ToList();
            var accountTreeGuid = cmbAccountTree.EditValue is Guid account ? account : Guid.Empty;
            var currencyGuid = cmbCurrency.EditValue is Guid currency ? currency : Guid.Empty;
            var billDate = deDate.EditValue is DateTime date ? date : DateTime.Now;
            var billType = cmbBillType.EditValue as string;
            var currencyEqualValue = Convert.ToDecimal(spnCurrencyEqualValue.EditValue ?? 0m);

            if (!isEdit)
            {
                var newBill = new CreateBillDto
                {
                    Id = Guid.NewGuid(),
                    BillNumber = 0,
                    BillType = billType,
                    AccountTreeGuid = accountTreeGuid,
                    CurrencyGuid = currencyGuid,
                    CurrencyEqualValue = 1m,
                    Date = billDate,
                    Notes = txtNotes.Text,
                    BillItems = billItems
                };

                if (!ValidationHelper.IsValid(new CreateBillDtoConfiguration(), newBill, out var errors))
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
                AccountTreeGuid = accountTreeGuid,
                CurrencyGuid = currencyGuid,
                CurrencyEqualValue = currencyEqualValue,
                Date = billDate,
                Notes = txtNotes.Text,
                BillItems = billItems
            };

            if (!ValidationHelper.IsValid(new UpdateBillDtoConfiguration(), updateBill, out var updateErrors))
            {
                MessageHelper.Error(updateErrors);
                return;
            }

            OnSaved(await _billService.UpdateBillAsync(updateBill), "تعديل");
        }

        /// <summary>
        /// عرض نتيجة الحفظ وإغلاق النموذج عند النجاح.
        /// </summary>
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

        /// <summary>
        /// إعطاء البند الجديد معرّفاً فريداً.
        /// </summary>
        private void gridViewItems_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (gridViewItems.GetRow(e.RowHandle) is BillItemDto row && row.Id == Guid.Empty)
                row.Id = Guid.NewGuid();
        }

        private void gridViewItems_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colItem && gridViewItems.GetRow(e.RowHandle) is BillItemDto row)
            {
                BillItemsGridHelper.ApplyItemToRow(row, _itemLookup);

                // ضروري: الـ DTO لا يُبلغ الشبكة بتغيّر السعر.
                gridViewItems.RefreshRow(e.RowHandle);
            }

            UpdateTotal();
        }

        private void gridViewItems_RowCountChanged(object sender, EventArgs e) => UpdateTotal();

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            gridViewItems.AddNewRow();
            gridViewItems.ShowEditor();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridViewItems.FocusedRowHandle >= 0)
                gridViewItems.DeleteRow(gridViewItems.FocusedRowHandle);
        }

        private async void CmbCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.EditValue is Guid currencyGuid && currencyGuid != Guid.Empty)
            {
                try
                {
                    var currency = await _currencyService.GetCurrencyByIdAsync(currencyGuid);
                    if (currency != null)
                    {
                        spnCurrencyEqualValue.EditValue = currency.CurrencyEqual;
                    }
                }
                catch
                {
                }
            }
        }

        private void UpdateTotal()
        {
            lblTotal.Text = $"الإجمالي: {_billItems.Sum(bi => bi.Qty * bi.Price):N2}";
        }
    }
}
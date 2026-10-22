using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using UI.Forms.Bills;

namespace UI.Forms
{
    public partial class ItemBillsForm : XtraForm
    {
        private readonly IBillService _billService;
        private readonly IItemService _itemService;

        /// <summary>
        /// بنود الفاتورة المعروضة، قابلة للتعديل مباشرة داخل الشبكة.
        /// </summary>
        private readonly BindingList<BillItemRow> _billItems = new BindingList<BillItemRow>();

        /// <summary>
        /// قاموس المواد المستخدمة في قائمة اختيار المادة داخل الشبكة.
        /// </summary>
        private IDictionary<Guid, ItemDto> _itemLookup = new Dictionary<Guid, ItemDto>();

        /// <summary>
        /// الفاتورة المعروضة حالياً (تُستخدم عند حفظ تعديلات البنود).
        /// </summary>
        private BillDto _currentBill;

        /// <summary>
        /// قائمة الفواتير مرتبة من الأقدم إلى الأحدث (تُستخدم للتنقل بين الفواتير).
        /// </summary>
        private readonly List<BillDto> _bills = new List<BillDto>();

        /// <summary>
        /// فهرس الفاتورة الحالية داخل <see cref="_bills"/>، و -1 عند عدم وجود فاتورة معروضة.
        /// </summary>
        private int _currentIndex = -1;

        private bool _isLoading;

        /// <summary>
        /// رقم الفاتورة التي سيتم تحميلها عند فتح النموذج، و null لعرض أول فاتورة تلقائياً.
        /// </summary>
        public int? BillNumber { get; set; }

        public ItemBillsForm(IBillService billService, IItemService itemService)
        {
            _billService = billService;
            _itemService = itemService;
            InitializeComponent();

            gridControl1.DataSource = _billItems;
        }

        private async void ItemBillsForm_Load(object sender, EventArgs e)
        {
            ClearBillDetails();

            await LoadItemsLookupAsync();

            await LoadBillsListAsync();

            if (BillNumber.HasValue && BillNumber.Value > 0)
            {
                spinBillNumber.EditValue = BillNumber.Value;
            }
            else if (_bills.Count > 0)
            {
                // عرض أول فاتورة تلقائياً عند فتح النموذج
                spinBillNumber.EditValue = _bills[0].BillNumber;
            }
            else
            {
                spinBillNumber.Focus();
                return;
            }

            await LoadBillAsync();
        }

        /// <summary>
        /// تحميل قائمة المواد لتهيئة قائمة اختيار المادة داخل شبكة البنود.
        /// </summary>
        private async Task LoadItemsLookupAsync()
        {
            try
            {
                var items = (await _itemService.GetAllItemsAsync())
                    .Where(i => i.IsActive)
                    .ToList();

                _itemLookup = BillItemsGridHelper.ConfigureItemColumn(colItem, items);

                BillItemsGridHelper.ConfigureNumericColumn(colQty, 0m, 1000000m);
                BillItemsGridHelper.ConfigureNumericColumn(colPrice, 0m, 1000000m);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل قائمة المواد.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// تحميل قائمة الفواتير (بدون البنود) لترتيبها ولتحديد الفاتورة السابقة والتالية.
        /// </summary>
        private async Task LoadBillsListAsync()
        {
            try
            {
                var bills = await _billService.GetAllBillsAsync();

                _bills.Clear();
                _bills.AddRange((bills ?? new List<BillDto>())
                    .OrderBy(b => b.Date)
                    .ThenBy(b => b.BillNumber));
            }
            catch (Exception ex)
            {
                _bills.Clear();

                XtraMessageBox.Show(
                    $"فشل تحميل قائمة الفواتير.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            UpdateNavigationButtons();
        }

        /// <summary>
        /// زر الفاتورة السابقة (الأقدم).
        /// </summary>
        private async void btnPrev_Click(object sender, EventArgs e)
        {
            await NavigateAsync(-1);
        }

        /// <summary>
        /// زر الفاتورة التالية (الأحدث).
        /// </summary>
        private async void btnNext_Click(object sender, EventArgs e)
        {
            await NavigateAsync(1);
        }

        /// <summary>
        /// التنقل بين الفواتير: -1 للفاتورة السابقة و 1 للفاتورة التالية.
        /// </summary>
        private async Task NavigateAsync(int offset)
        {
            if (_currentIndex < 0 || _bills.Count == 0)
                return;

            if (_bills.Count == 0)
                return;

            var targetIndex = _currentIndex + offset;

            if (targetIndex < 0)
                targetIndex = _bills.Count - 1;
            else if (targetIndex >= _bills.Count)
                targetIndex = 0;

            var target = _bills[targetIndex];

            spinBillNumber.EditValue = target.BillNumber;

            await LoadBillAsync();
        }

        /// <summary>
        /// زر إضافة مواد: يفتح نموذج إدارة الفاتورة للفاتورة الحالية في وضع التعديل.
        /// </summary>
        private async void btnAddItems_Click(object sender, EventArgs e)
        {
            if (_currentIndex < 0 || _currentIndex >= _bills.Count)
            {
                XtraMessageBox.Show(
                    "يرجى عرض فاتورة أولاً قبل إضافة المواد",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var currentBillId = _bills[_currentIndex].Id;

            BillDto billToEdit;

            try
            {
                billToEdit = await _billService.GetBillByIdAsync(currentBillId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل بيانات الفاتورة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (billToEdit == null)
            {
                XtraMessageBox.Show(
                    "لا توجد فاتورة لعرضها",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (var manageForm = ActivatorUtilities.CreateInstance<BillsManageForm>(Program.CurrentScopeProvider, billToEdit))
            {
                if (manageForm.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            await ReloadCurrentBillAsync();
        }

        /// <summary>
        /// إعادة تحميل قائمة الفواتير ثم تحديث الفاتورة المعروضة بعد تعديلها.
        /// </summary>
        private async Task ReloadCurrentBillAsync()
        {
            var currentBillId = _currentIndex >= 0 && _currentIndex < _bills.Count
                ? _bills[_currentIndex].Id
                : Guid.Empty;

            await LoadBillsListAsync();

            var newIndex = _bills.FindIndex(b => b.Id == currentBillId);

            if (newIndex < 0)
            {
                ClearBillDetails();
                return;
            }

            _currentIndex = newIndex;

            spinBillNumber.EditValue = _bills[newIndex].BillNumber;

            await LoadBillAsync();
        }

        private async void spinBillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            await LoadBillAsync();
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

        private async Task LoadBillAsync()
        {
            if (_isLoading)
                return;

            var billNumber = GetBillNumberFromInput();

            if (billNumber <= 0)
            {
                ClearBillDetails();

                XtraMessageBox.Show(
                    "يرجى إدخال رقم الفاتورة",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _isLoading = true;
            UseWaitCursor = true;

            try
            {
                var bill = await _billService.GetBillByNumberAsync(billNumber);

                if (bill == null)
                {
                    ClearBillDetails();

                    XtraMessageBox.Show(
                        $"لا توجد فاتورة بالرقم '{billNumber}'.",
                        "فاتورة غير موجودة",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                ShowBillDetails(bill);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل بيانات الفاتورة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                _isLoading = false;
            }
        }

        private void ShowBillDetails(BillDto bill)
        {
            _currentIndex = _bills.FindIndex(b => b.Id == bill.Id);
            _currentBill = bill;
            UpdateNavigationButtons();

            lblTypeValue.Text = bill.BillType ?? string.Empty;
            lblDateValue.Text = bill.Date.ToString("yyyy/MM/dd");
            lblAccountValue.Text = bill.AccountTree?.AccountName ?? string.Empty;
            lblCurrencyValue.Text = bill.Currency?.CurrencyName ?? string.Empty;
            lblEqualValue.Text = bill.CurrencyEqualValue.ToString("N2");
            lblNotesValue.Text = bill.Notes ?? string.Empty;

            _billItems.Clear();

            foreach (var billItem in bill.BillItems ?? new HashSet<BillItemDto>())
            {
                var row = BillItemRow.FromDto(billItem);

                if (row != null)
                    _billItems.Add(row);
            }

            UpdateTotal();
        }

        private void ClearBillDetails()
        {
            _currentIndex = -1;
            _currentBill = null;
            UpdateNavigationButtons();

            lblTypeValue.Text = string.Empty;
            lblDateValue.Text = string.Empty;
            lblAccountValue.Text = string.Empty;
            lblCurrencyValue.Text = string.Empty;
            lblEqualValue.Text = string.Empty;
            lblNotesValue.Text = string.Empty;

            _billItems.Clear();

            lblTotal.Text = "إجمالي الفاتورة: 0";
        }

        /// <summary>
        /// عند تغيير المادة داخل الشبكة: تحديث اسم المادة والسعر الافتراضي.
        /// </summary>
        private void gridView1_CellValueChanged(
            object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as BillItemRow;

            if (row != null && e.Column == colItem)
            {
                BillItemsGridHelper.ApplyItemToRow(row, _itemLookup);
            }

            UpdateTotal();
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        /// <summary>
        /// إضافة بند جديد إلى شبكة بنود الفاتورة الحالية.
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (_currentBill == null)
            {
                XtraMessageBox.Show(
                    "يرجى عرض فاتورة أولاً قبل إضافة المواد",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            gridView1.AddNewRow();
            gridView1.ShowEditor();
        }

        /// <summary>
        /// حذف البند المحدد من شبكة بنود الفاتورة الحالية.
        /// </summary>
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        /// <summary>
        /// حفظ تعديلات بنود الفاتورة الحالية.
        /// </summary>
        private async void btnSaveItems_Click(object sender, EventArgs e)
        {
            if (_currentBill == null)
            {
                XtraMessageBox.Show(
                    "يرجى عرض فاتورة أولاً قبل حفظ التعديلات",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var billItems = _billItems
                .Where(bi => bi.ItemGuid != Guid.Empty)
                .Select(bi => bi.ToDto())
                .ToList();

            var errors = new List<string>();

            foreach (var billItem in billItems)
            {
                if (!ValidationHelper.IsValid(
                    new BillItemDtoConfiguration(),
                    billItem,
                    out var itemErrors))
                {
                    errors.Add(itemErrors);
                }
            }

            if (errors.Count > 0)
            {
                XtraMessageBox.Show(string.Join(Environment.NewLine, errors));
                return;
            }

            var updateBill = new UpdateBillDto
            {
                Id = _currentBill.Id,
                BillNumber = _currentBill.BillNumber,
                BillType = _currentBill.BillType,
                AccountTreeGuid = _currentBill.AccountTreeGuid,
                CurrencyGuid = _currentBill.CurrencyGuid,
                CurrencyEqualValue = _currentBill.CurrencyEqualValue,
                Date = _currentBill.Date,
                Notes = _currentBill.Notes,
                BillItems = billItems
            };

            UseWaitCursor = true;

            try
            {
                var result = await _billService.UpdateBillAsync(updateBill);

                if (!result)
                {
                    XtraMessageBox.Show(
                        "فشل في حفظ تعديلات بنود الفاتورة",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حفظ تعديلات بنود الفاتورة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            finally
            {
                UseWaitCursor = false;
            }

            XtraMessageBox.Show(
                "تم حفظ تعديلات بنود الفاتورة بنجاح",
                "نجاح",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await ReloadCurrentBillAsync();
        }

        /// <summary>
        /// تحديث إجمالي الفاتورة المعروضة.
        /// </summary>
        private void UpdateTotal()
        {
            var total = _billItems.Sum(bi => bi.Qty * bi.Price);

            lblTotal.Text = $"إجمالي الفاتورة: {total:N2}";
        }

        /// <summary>
        /// تفعيل/تعطيل أزرار التنقل حسب موقع الفاتورة الحالية من القائمة.
        /// </summary>
        private void UpdateNavigationButtons()
        {
            var hasCurrentBill = _currentIndex >= 0 && _currentIndex < _bills.Count;

            btnPrev.Enabled = _bills.Count > 1 && hasCurrentBill;
            btnNext.Enabled = _bills.Count > 1 && hasCurrentBill;
            btnAddItems.Enabled = hasCurrentBill;

            btnAddItem.Enabled = hasCurrentBill;
            btnDeleteItem.Enabled = hasCurrentBill;
            btnSaveItems.Enabled = hasCurrentBill;
        }
    }
}

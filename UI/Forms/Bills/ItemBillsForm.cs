using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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

        /// <summary>بنود الفاتورة المعروضة، قابلة للتعديل مباشرة داخل الشبكة.</summary>
        private readonly BindingList<BillItemDto> _billItems = new BindingList<BillItemDto>();

        /// <summary>قاموس المواد المستخدم في اختيار المادة داخل الشبكة.</summary>
        private IDictionary<Guid, ItemDto> _itemLookup = new Dictionary<Guid, ItemDto>();

        /// <summary>الفاتورة المعروضة حالياً.</summary>
        private BillDto _currentBill;

        /// <summary>الفواتير مرتبة من الأقدم إلى الأحدث (للتنقل).</summary>
        private readonly List<BillDto> _bills = new List<BillDto>();

        /// <summary>فهرس الفاتورة الحالية داخل _bills، و -1 عند عدم وجودها.</summary>
        private int _currentIndex = -1;

        private bool _isLoading;

        /// <summary>رقم الفاتورة المطلوب عرضها عند الفتح، و null لعرض أول فاتورة.</summary>
        public int? BillNumber { get; set; }

        public ItemBillsForm()
        {
            InitializeComponent();

            gridControl1.DataSource = _billItems;
            gridView1.InitNewRow += gridView1_InitNewRow;
        }

        public ItemBillsForm(IBillService billService, IItemService itemService) : this()
        {
            _billService = billService;
            _itemService = itemService;
        }

        private async void ItemBillsForm_Load(object sender, EventArgs e)
        {
            Display(null);

            await LoadItemsLookupAsync();
            await LoadBillsListAsync();

            var number = BillNumber > 0 ? BillNumber : _bills.FirstOrDefault()?.BillNumber;

            if (number == null)
            {
                spinBillNumber.Focus();
                return;
            }

            spinBillNumber.EditValue = number;
            await LoadBillAsync();
        }

        private async Task LoadItemsLookupAsync()
        {
            try
            {
                var items = (await _itemService.GetAllItemsAsync()).Where(i => i.IsActive);

                _itemLookup = BillItemsGridHelper.ConfigureGrid(colItem, colQty, colPrice, colTotal, items);
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل قائمة المواد.\n{ex.Message}");
            }
        }

        private async Task LoadBillsListAsync()
        {
            _bills.Clear();

            try
            {
                var bills = await _billService.GetAllBillsAsync() ?? new List<BillDto>();

                _bills.AddRange(bills.OrderBy(b => b.Date).ThenBy(b => b.BillNumber));
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل قائمة الفواتير.\n{ex.Message}");
            }

            UpdateNavigationButtons();
        }

        private async void btnPrev_Click(object sender, EventArgs e) => await NavigateAsync(-1);

        private async void btnNext_Click(object sender, EventArgs e) => await NavigateAsync(1);

        /// <summary>
        /// التنقل بين الفواتير بشكل دائري: -1 للسابقة و 1 للتالية.
        /// </summary>
        private async Task NavigateAsync(int offset)
        {
            if (_currentIndex < 0)
                return;

            var count = _bills.Count;

            spinBillNumber.EditValue = _bills[(_currentIndex + offset + count) % count].BillNumber;

            await LoadBillAsync();
        }

        /// <summary>
        /// فتح نموذج إدارة الفاتورة للفاتورة الحالية في وضع التعديل.
        /// </summary>
        private async void btnAddItems_Click(object sender, EventArgs e)
        {
            BillDto billToEdit;

            try
            {
                billToEdit = await _billService.GetBillByIdAsync(_currentBill.Id);
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل بيانات الفاتورة.\n{ex.Message}");
                return;
            }

            if (billToEdit == null)
            {
                MessageHelper.Info("لا توجد فاتورة لعرضها");
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
        /// إعادة تحميل قائمة الفواتير ثم تحديث الفاتورة المعروضة.
        /// </summary>
        private async Task ReloadCurrentBillAsync()
        {
            var currentId = _currentBill?.Id;

            await LoadBillsListAsync();

            var bill = _bills.FirstOrDefault(b => b.Id == currentId);

            if (bill == null)
            {
                Display(null);
                return;
            }

            spinBillNumber.EditValue = bill.BillNumber;
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

        private async Task LoadBillAsync()
        {
            if (_isLoading)
                return;

            var number = Convert.ToInt32(spinBillNumber.EditValue ?? 0);

            if (number <= 0)
            {
                Display(null);
                MessageHelper.Info("يرجى إدخال رقم الفاتورة");
                return;
            }

            _isLoading = true;
            UseWaitCursor = true;

            try
            {
                var bill = await _billService.GetBillByNumberAsync(number);

                Display(bill);

                if (bill == null)
                    MessageHelper.Info($"لا توجد فاتورة بالرقم '{number}'.", "فاتورة غير موجودة");
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل تحميل بيانات الفاتورة.\n{ex.Message}");
            }
            finally
            {
                UseWaitCursor = false;
                _isLoading = false;
            }
        }

        /// <summary>
        /// عرض الفاتورة وبنودها، أو تفريغ الشاشة عند تمرير null.
        /// </summary>
        private void Display(BillDto bill)
        {
            _currentBill = bill;
            _currentIndex = bill == null ? -1 : _bills.FindIndex(b => b.Id == bill.Id);

            lblTypeValue.Text = bill?.BillType ?? string.Empty;
            lblDateValue.Text = bill?.Date.ToString("yyyy/MM/dd") ?? string.Empty;
            lblAccountValue.Text = bill?.AccountTree?.AccountName ?? string.Empty;
            lblCurrencyValue.Text = bill?.Currency?.CurrencyName ?? string.Empty;
            lblEqualValue.Text = bill?.CurrencyEqualValue.ToString("N2") ?? string.Empty;
            lblNotesValue.Text = bill?.Notes ?? string.Empty;

            _billItems.Clear();

            foreach (var billItem in bill?.BillItems ?? new HashSet<BillItemDto>())
                _billItems.Add(billItem);

            UpdateTotal();
            UpdateNavigationButtons();
        }

        /// <summary>
        /// إعطاء البند الجديد معرّفاً فريداً.
        /// </summary>
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) is BillItemDto row && row.Id == Guid.Empty)
                row.Id = Guid.NewGuid();
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colItem && gridView1.GetRow(e.RowHandle) is BillItemDto row)
            {
                BillItemsGridHelper.ApplyItemToRow(row, _itemLookup);

                // ضروري: الـ DTO لا يُبلغ الشبكة بتغيّر السعر.
                gridView1.RefreshRow(e.RowHandle);
            }

            UpdateTotal();
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e) => UpdateTotal();

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
            gridView1.ShowEditor();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        /// <summary>
        /// حفظ تعديلات بنود الفاتورة الحالية.
        /// </summary>
        private async void btnSaveItems_Click(object sender, EventArgs e)
        {
            // إنهاء تحرير الخلية الحالية حتى لا تضيع آخر قيمة مكتوبة.
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            var billItems = _billItems.Where(bi => bi.ItemGuid != Guid.Empty).ToList();

            var errors = billItems
                .Select(bi => ValidationHelper.IsValid(new BillItemDtoConfiguration(), bi, out var itemErrors) ? null : itemErrors)
                .Where(err => err != null)
                .ToList();

            if (errors.Count > 0)
            {
                MessageHelper.Error(string.Join(Environment.NewLine, errors));
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

            string error = null;
            UseWaitCursor = true;

            try
            {
                if (!await _billService.UpdateBillAsync(updateBill))
                    error = "فشل في حفظ تعديلات بنود الفاتورة";
            }
            catch (Exception ex)
            {
                error = $"فشل حفظ تعديلات بنود الفاتورة.\n{ex.Message}";
            }
            finally
            {
                UseWaitCursor = false;
            }

            if (error != null)
            {
                MessageHelper.Error(error);

                // الشبكة تعدّل كائنات الـ DTO نفسها، فنعيد التحميل لإلغاء التعديلات غير المحفوظة.
                await LoadBillAsync();
                return;
            }

            MessageHelper.Success("تم حفظ تعديلات بنود الفاتورة بنجاح");

            await ReloadCurrentBillAsync();
        }

        private void UpdateTotal()
        {
            lblTotal.Text = $"إجمالي الفاتورة: {_billItems.Sum(bi => bi.Qty * bi.Price):N2}";
        }

        /// <summary>
        /// تفعيل/تعطيل الأزرار حسب وجود فاتورة معروضة وموقعها في القائمة.
        /// </summary>
        private void UpdateNavigationButtons()
        {
            var hasCurrentBill = _currentIndex >= 0;

            btnPrev.Enabled = btnNext.Enabled = hasCurrentBill && _bills.Count > 1;

            btnAddItems.Enabled = btnAddItem.Enabled = btnDeleteItem.Enabled = btnSaveItems.Enabled = hasCurrentBill;
        }
    }
}
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class ItemBillsForm : XtraForm
    {
        private readonly IBillService _billService;
        private bool _isLoading;

        /// <summary>
        /// رقم الفاتورة التي سيتم تحميلها عند فتح النموذج.
        /// </summary>
        public string BillNumber { get; set; }

        public ItemBillsForm(IBillService billService)
        {
            _billService = billService;
            InitializeComponent();

            btnSearch.Click += btnSearch_Click;
            txtBillNumber.KeyDown += txtBillNumber_KeyDown;
        }

        private async void ItemBillsForm_Load(object sender, EventArgs e)
        {
            ClearBillDetails();

            if (string.IsNullOrWhiteSpace(BillNumber))
            {
                txtBillNumber.Focus();
                return;
            }

            txtBillNumber.Text = BillNumber;

            await LoadBillAsync();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadBillAsync();
        }

        private async void txtBillNumber_KeyDown(object sender, KeyEventArgs e)
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

            var billNumber = txtBillNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(billNumber))
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
            lblTypeValue.Text = bill.BillType ?? string.Empty;
            lblDateValue.Text = bill.Date.ToString("yyyy/MM/dd");
            lblAccountValue.Text = bill.AccountTree?.AccountName ?? string.Empty;
            lblCurrencyValue.Text = bill.Currency?.CurrencyName ?? string.Empty;
            lblEqualValue.Text = bill.CurrencyEqualValue.ToString("N2");
            lblNotesValue.Text = bill.Notes ?? string.Empty;

            var rows = (bill.BillItems ?? new HashSet<BillItemDto>())
                .Select(bi => new
                {
                    ItemName = bi.Item?.Name ?? string.Empty,
                    bi.Qty,
                    bi.Price,
                    Total = bi.Qty * bi.Price
                })
                .ToList();

            gridControl1.DataSource = rows;

            lblTotal.Text = $"إجمالي الفاتورة: {rows.Sum(r => r.Total):N2}";
        }

        private void ClearBillDetails()
        {
            lblTypeValue.Text = string.Empty;
            lblDateValue.Text = string.Empty;
            lblAccountValue.Text = string.Empty;
            lblCurrencyValue.Text = string.Empty;
            lblEqualValue.Text = string.Empty;
            lblNotesValue.Text = string.Empty;

            gridControl1.DataSource = null;
            gridView1.RefreshData();

            lblTotal.Text = "إجمالي الفاتورة: 0";
        }
    }
}

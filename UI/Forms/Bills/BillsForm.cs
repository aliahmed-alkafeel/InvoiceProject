using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms.Bills;

namespace UI.Forms
{
    public partial class BillsForm : XtraForm
    {
        private readonly IBillService _billService;
        private List<BillDto> _bills = new List<BillDto>();
        private bool _isLoadingBills;

        public BillsForm(IBillService billService)
        {
            _billService = billService;
            InitializeComponent();

            toolBarControl1.CreateClicked += BillsToolbar_CreateClicked;
            toolBarControl1.EditClicked += BillsToolbar_EditClicked;
            toolBarControl1.DeleteClicked += BillsToolbar_DeleteClicked;
            toolBarControl1.RefreshClicked += BillsToolbar_RefreshClicked;
        }

        private async void BillsForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadBillsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل الفواتير.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadBillsAsync()
        {
            if (CheckBillsLoading())
                return;

            _isLoadingBills = true;
            try
            {
                _bills = await _billService.GetAllBillsAsync();

                gridControl1.DataSource = _bills;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingBills = false;
            }
        }

        private async void BillsToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckBillsLoading())
                return;

            using (var manageForm = Program.CurrentScopeProvider
                .GetService(typeof(BillsManageForm)) as BillsManageForm)
            {
                if (manageForm == null)
                    return;

                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadBillsAsync();
                }
            }
        }

        private async void BillsToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckBillsLoading())
                return;

            var selectedBill = gridView1.GetFocusedRow() as BillDto;

            if (selectedBill == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار فاتورة لتعديلها.",
                    "اختيار فاتورة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            BillDto billToEdit;

            try
            {
                billToEdit = await _billService.GetBillByIdAsync(selectedBill.Id);
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

            using (var manageForm =
                ActivatorUtilities.CreateInstance<BillsManageForm>(
                    Program.CurrentScopeProvider,
                    billToEdit))
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadBillsAsync();
                }
            }
        }

        private async void BillsToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckBillsLoading())
                return;

            var bill = gridView1.GetFocusedRow() as BillDto;

            if (bill == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار فاتورة أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var result = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف الفاتورة '{bill.BillNumber}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                await _billService.DeleteBillAsync(bill.Id);

                await LoadBillsAsync();

                XtraMessageBox.Show(
                    "تم حذف الفاتورة بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف الفاتورة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void BillsToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckBillsLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadBillsAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة الفواتير.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                await Task.Delay(300);
                UseWaitCursor = false;
            }
        }

        private void btnShowItems_Click(object sender, EventArgs e)
        {
            ShowBillItems(GetSelectedBill()?.BillNumber);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowBillItems(GetSelectedBill()?.BillNumber);
        }

        private void ShowBillItems(string billNumber)
        {
            if (string.IsNullOrWhiteSpace(billNumber))
            {
                XtraMessageBox.Show(
                    "يرجى اختيار فاتورة أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (var itemBillsForm = Program.CurrentScopeProvider
                .GetService(typeof(ItemBillsForm)) as ItemBillsForm)
            {
                if (itemBillsForm == null)
                    return;

                itemBillsForm.BillNumber = billNumber;

                itemBillsForm.ShowDialog(this);
            }
        }

        private BillDto GetSelectedBill()
        {
            return gridView1.GetFocusedRow() as BillDto;
        }

        private bool CheckBillsLoading()
        {
            if (!_isLoadingBills)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل الفواتير، يرجى الانتظار حتى اكتمال التحميل",
                "تحميل الفواتير",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }
}

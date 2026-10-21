using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls;

namespace UI.Forms.Vouchers
{
    public partial class VouchersForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IVoucherService _vouchersService;
        //public Guid CurrentUserId { get; set; }
        private bool _isLoadingVouchers;

        public VouchersForm(IVoucherService vouchersService)
        {
            _vouchersService = vouchersService;
            InitializeComponent();


            toolBarControl1.CreateClicked += VouchersToolbar_CreateClicked;
            toolBarControl1.EditClicked += VouchersToolbar_EditClicked;
            toolBarControl1.DeleteClicked += VouchersToolbar_DeleteClicked;
            toolBarControl1.RefreshClicked += VouchersToolbar_RefreshClicked;
        }

        private async void VouchersForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadVouchersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل السندات\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadVouchersAsync()
        {
            if (CheckVouchersLoading())
                return;

            _isLoadingVouchers = true;
            try
            {
                var vouchers = await _vouchersService.GetAllVouchersAsync();

                gridControl1.DataSource = vouchers;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingVouchers = false;
            }
        }

        private async void VouchersToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckVouchersLoading())
                return;

            using (var editForm = Program.ServiceProvider
                .GetService(typeof(VouchersCreateForm)) as VouchersCreateForm)
            {

                var result = editForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadVouchersAsync();
                }
            }
        }

        private async void VouchersToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckVouchersLoading())
                return;

            var selectedRow = gridView1.GetFocusedRow() as VoucherDto;

            if (selectedRow == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار سند لتعديله",
                    "اختيار سند",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (var editForm =
                ActivatorUtilities.CreateInstance<VouchersManageForm>(
                    Program.CurrentScopeProvider,
                    selectedRow))
            {
                var result = editForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadVouchersAsync();
                }
            }
        }

        private async void VouchersToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckVouchersLoading())
                return;

            var selectedRow = gridView1.GetFocusedRow() as VoucherDto;

            if (selectedRow == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار سند أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var voucher = selectedRow;

            var result = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف السند؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                await _vouchersService.DeleteVoucherAsync(voucher.Id);

                await LoadVouchersAsync();

                XtraMessageBox.Show(
                    "تم حذف السند بنجاح",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف السند.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void VouchersToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckVouchersLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadVouchersAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة السندات.\n{ex.Message}",
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

        private bool CheckVouchersLoading()
        {
            if (!_isLoadingVouchers)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل السندات، يرجى الانتظار حتى اكتمال التحميل",
                "تحميل السندات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

    }
}
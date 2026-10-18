using Data.Configurations.DTOsConfigurations;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Extentions;

namespace UI.Forms.Vouchers
{
    public partial class VouchersManageForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IVoucherService _voucherService;
        private readonly IAccountsTreeService _accountsTreeService;
        private VoucherDto _selectedVoucher;
        private bool isEdit => _selectedVoucher != null;

        public VouchersManageForm(
            IVoucherService vouchersService, IAccountsTreeService accountsTreeService,
            VoucherDto selectedVoucher = null)
        {
            InitializeComponent();

            _voucherService = vouchersService;
            _accountsTreeService = accountsTreeService;
            _selectedVoucher = selectedVoucher;

            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var newVoucher = new VoucherDto()
            {
                Id = isEdit ? _selectedVoucher.Id : Guid.NewGuid()
            };

            if (!ValidationHelper.IsValid(
                new VoucherDtoConfiguration(),
                newVoucher,
                out var errors))
            {
                XtraMessageBox.Show(errors);
                return;
            }

            if (!isEdit)
            {
                var result = await _voucherService.CreateVoucherAsync(newVoucher);

                if (result)
                {
                    MessageBox.Show(
                        "تم إضافة السند بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في إضافة السند",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                var result = await _voucherService.UpdateVoucherAsync(newVoucher);

                if (result)
                {
                    MessageBox.Show(
                        "تم تعديل السند بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في تعديل السند",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveCancelControl_CancelClicked()
        {
            Close();
        }

        private void VouchersManageForm_Load(object sender, EventArgs e)
        {
            LoadVoucherDetails(_selectedVoucher);
        }

        private async void LoadVoucherDetails(VoucherDto voucher)
        {
            _selectedVoucher = voucher;

            if (voucher == null)
            {
                ClearDetails();
                return;
            }

            var categories = (await _accountsTreeService.GetAllAccountsAsync())
                .Select(c => new
                {
                    c.Id,
                    c.AccountName
                }).ToList();

            cmbAccounts.Properties.DataSource = categories;
            cmbAccounts.Properties.DisplayMember = "AccountName";
            cmbAccounts.Properties.ValueMember = "Id";
            cmbAccounts.Properties.NullText = "اختر الحساب";
            if (!isEdit)
            {
                lblTitle.Text = "إضافة سند";
                saveCancelControl21.SaveText = "إضافة";
            }
        }

        private void ClearDetails()
        {
            // مسح حقول السند هنا بحسب عناصر الواجهة
        }
    }
}


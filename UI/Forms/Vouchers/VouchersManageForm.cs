using Data.Configurations.DTOsConfigurations;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using DevExpress.XtraEditors;
using Models.DTOs;
using Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Vouchers
{
    public partial class VouchersManageForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IVoucherService _voucherService;
        private readonly IAccountsTreeService _accountsTreeService;
        private readonly ICurrencyService _currencyService;
        private VoucherDto _selectedVoucher;
        public VouchersManageForm(
            IVoucherService vouchersService, IAccountsTreeService accountsTreeService, ICurrencyService currencyService,
            VoucherDto selectedVoucher = null)
        {
            InitializeComponent();
            _currencyService = currencyService;
            _voucherService = vouchersService;
            _accountsTreeService = accountsTreeService;
            _selectedVoucher = selectedVoucher;

            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var newVoucher = new UpdateVoucherDto()
            {
                Id = _selectedVoucher.Id,

                AccountTreeGuid = cmbAccounts.EditValue == null
            ? Guid.Empty
            : (Guid)cmbAccounts.EditValue,

                VoucherNumber = txtVoucherNumber.EditValue == null ? "" : txtVoucherNumber.EditValue.ToString(),

                Amount = spnAmount.EditValue == null
            ? 0m
            : Convert.ToDecimal(spnAmount.EditValue),

                VoucherType = cmbVoucherTypes.EditValue == null
            ? default(VoucherType)
            : (VoucherType)cmbVoucherTypes.EditValue,

                CurrencyGuid = cmbCurrencies.EditValue == null
            ? Guid.Empty
            : (Guid)cmbCurrencies.EditValue,

                CurrencyEqualValue = _selectedVoucher.CurrencyEqualValue,

                Date = _selectedVoucher.Date,

                Notes = txtNotes.Text
            };

            if (!ValidationHelper.IsValid(
                new UpdateVoucherDtoConfiguration(),
                newVoucher,
                out var errors))
            {
                XtraMessageBox.Show(errors);
                return;
            }

          
         
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

        private void SaveCancelControl_CancelClicked()
        {
            Close();
        }

        private async void VouchersManageForm_Load(object sender, EventArgs e)
        {
            await LoadVoucherDetailsAsync(_selectedVoucher);
        }

        private async Task LoadVoucherDetailsAsync(VoucherDto voucher)
        {
            _selectedVoucher = voucher;

            var accounts = (await _accountsTreeService.GetAllAccountsAsync())
         .Where(a => a.IsLeaf && a.IsActive)
         .Select(a => new
         {
             a.Id,
             a.AccountName
         })
         .ToList();

            cmbAccounts.Properties.DataSource = accounts;
            cmbAccounts.Properties.DisplayMember = "AccountName";
            cmbAccounts.Properties.ValueMember = "Id";
            cmbAccounts.Properties.NullText = "اختر الحساب";

            cmbAccounts.Properties.View.Columns.Clear();
            cmbAccounts.Properties.View.Columns
                .AddVisible("AccountName", "الحساب المحاسبي");

            cmbAccounts.EditValue = null;

            var currencies = (await _currencyService.GetAllCurrenciesAsync())
         .Select(a => new
         {
             a.Id,
             a.CurrencyName
         })
         .ToList();

            cmbCurrencies.Properties.DataSource = currencies;
            cmbCurrencies.Properties.DisplayMember = "CurrencyName";
            cmbCurrencies.Properties.ValueMember = "Id";
            cmbCurrencies.Properties.NullText = "اختر العملة";

            cmbCurrencies.Properties.View.Columns.Clear();
            cmbCurrencies.Properties.View.Columns
                .AddVisible("CurrencyName", "العملة");
            cmbCurrencies.EditValue = null;

            var voucherTypes = Enum.GetValues(typeof(VoucherType))
                .Cast<VoucherType>()
                .Select(type => new
                {
                    Value = type,
                    Text = type.ToString()
                })
                .ToList();

            cmbVoucherTypes.Properties.DataSource = voucherTypes;
            cmbVoucherTypes.Properties.DisplayMember = "Text";
            cmbVoucherTypes.Properties.ValueMember = "Value";
            cmbVoucherTypes.Properties.NullText = "اختر نوع السند";

            cmbVoucherTypes.Properties.View.Columns.Clear();
            cmbVoucherTypes.Properties.View.Columns
                .AddVisible("Text", "نوع السند");

            cmbVoucherTypes.EditValue = null;

            txtVoucherNumber.Text = voucher.VoucherNumber.ToString();

            dateEditVoucherDate.EditValue = voucher.Date;

            cmbAccounts.EditValue = voucher.AccountTreeGuid;

            spnAmount.EditValue = voucher.Amount;
            cmbVoucherTypes.EditValue = voucher.VoucherType;
            txtNotes.Text = voucher.Notes;
        }
    }
}


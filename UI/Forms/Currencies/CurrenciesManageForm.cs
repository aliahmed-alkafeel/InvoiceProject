using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Currencies
{
    public partial class CurrenciesManageForm : XtraForm
    {
        private readonly ICurrencyService _currencyService;
        private CurrencyDto _selectedCurrency;
        private bool isEdit => _selectedCurrency != null;
        private bool _isLoadingDetails;

        public CurrenciesManageForm(
            ICurrencyService currencyService, CurrencyDto selectedCurrency = null)
        {
            InitializeComponent();
            _currencyService = currencyService;
            _selectedCurrency = selectedCurrency;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private void CurrenciesManageForm_Load(object sender, EventArgs e)
        {
            LoadCurrencyDetails(_selectedCurrency);
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var currencyName = txtCurrencyName.Text.Trim();
            var currencySymbol = txtCurrencySymbol.Text.Trim();
            var currencyEqual = GetCurrencyEqualValue();
            var isMain = chkIsMain.Checked;
            var isActive = chkIsActive.Checked;
            var notes = txtNotes.Text;

            if (!isEdit)
            {
                var newCurrency = new CreateCurrencyDto()
                {
                    Id = Guid.NewGuid(),
                    CurrencyName = currencyName,
                    CurrencySymbol = currencySymbol,
                    CurrencyEqual = currencyEqual,
                    IsMain = isMain,
                    IsActive = isActive,
                    Notes = notes
                };

                if (!ValidationHelper.IsValid(
                    new CreateCurrencyDtoConfiguration(),
                    newCurrency,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _currencyService.CreateCurrencyAsync(newCurrency);

                if (result)
                {
                    MessageBox.Show(
                        "تم إضافة العملة بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في إضافة العملة، قد يكون الاسم أو الرمز مكرراً",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                var updatedCurrency = new UpdateCurrencyDto()
                {
                    Id = _selectedCurrency.Id,
                    CurrencyName = currencyName,
                    CurrencySymbol = currencySymbol,
                    CurrencyEqual = currencyEqual,
                    IsMain = isMain,
                    IsActive = isActive,
                    Notes = notes
                };

                if (!ValidationHelper.IsValid(
                    new UpdateCurrencyDtoConfiguration(),
                    updatedCurrency,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _currencyService.UpdateCurrencyAsync(updatedCurrency);

                if (result)
                {
                    MessageBox.Show(
                        "تم تعديل العملة بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في تعديل العملة، قد يكون الاسم أو الرمز مكرراً",
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

        private decimal GetCurrencyEqualValue()
        {
            if (spinCurrencyEqual.EditValue == null)
                return 0m;
            return spinCurrencyEqual.Value;
        }

        private void chkIsMain_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingDetails)
                return;

            UpdateCurrencyEqualEditor();
        }

        private void UpdateCurrencyEqualEditor()
        {
            if (chkIsMain.Checked)
            {
                spinCurrencyEqual.EditValue = 1m;
                spinCurrencyEqual.Enabled = false;
            }
            else
            {
                spinCurrencyEqual.Enabled = true;
            }
        }

        private void LoadCurrencyDetails(CurrencyDto currency)
        {
            _isLoadingDetails = true;

            try
            {
                if (currency == null)
                {
                    lblTitle.Text = "إضافة عملة";
                    saveCancelControl21.SaveText = "إضافة";
                    return;
                }

                lblTitle.Text = "تعديل العملة";
                saveCancelControl21.SaveText = "حفظ";

                txtCurrencyName.Text = currency.CurrencyName;
                txtCurrencySymbol.Text = currency.CurrencySymbol;
                txtNotes.Text = currency.Notes;
                chkIsActive.Checked = currency.IsActive;
                spinCurrencyEqual.EditValue = currency.CurrencyEqual;
                chkIsMain.Checked = currency.IsMain;
            }
            finally
            {
                _isLoadingDetails = false;
            }

            UpdateCurrencyEqualEditor();
        }
    }
}

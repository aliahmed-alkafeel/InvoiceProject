using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using Models.CurrentUserDetails;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using UI.Forms.Currencies;

namespace UI.Forms
{
    public partial class CurrenciesForm : XtraForm
    {
        private readonly ICurrencyService _currencyService;
        private bool _isLoadingCurrencies;

        public CurrenciesForm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            InitializeComponent();
            if (toolBarControl1.SetManageVisible(CurrentUser.HasRole(UserRole.ManageCurrency)))
            {
                toolBarControl1.CreateClicked += CurrenciesToolbar_CreateClicked;
                toolBarControl1.EditClicked += CurrenciesToolbar_EditClicked;
                toolBarControl1.DeleteClicked += CurrenciesToolbar_DeleteClicked;
            }
            toolBarControl1.RefreshClicked += CurrenciesToolbar_RefreshClicked;
        }

        private async void CurrenciesForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadCurrenciesAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل العملات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadCurrenciesAsync()
        {
            if (CheckCurrenciesLoading())
                return;

            _isLoadingCurrencies = true;
            try
            {
                var currencies = await _currencyService.GetAllCurrenciesAsync();

                gridControl1.DataSource = currencies;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingCurrencies = false;
            }
        }

        private async void CurrenciesToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCurrenciesLoading())
                return;

            using (var manageForm = Program.CurrentScopeProvider
                .GetService(typeof(CurrenciesManageForm)) as CurrenciesManageForm)
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadCurrenciesAsync();
                }
            }
        }

        private async void CurrenciesToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCurrenciesLoading())
                return;

            var selectedCurrency = gridView1.GetFocusedRow() as CurrencyDto;

            if (selectedCurrency == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار عملة لتعديلها.",
                    "اختيار عملة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            CurrencyDto currencyToEdit;

            try
            {
                currencyToEdit =
                    await _currencyService.GetCurrencyByIdAsync(selectedCurrency.Id);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل بيانات العملة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using (var manageForm =
                ActivatorUtilities.CreateInstance<CurrenciesManageForm>(
                    Program.CurrentScopeProvider,
                    currencyToEdit))
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadCurrenciesAsync();
                }
            }
        }

        private async void CurrenciesToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCurrenciesLoading())
                return;

            var currency = gridView1.GetFocusedRow() as CurrencyDto;

            if (currency == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار عملة أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (currency.IsMain)
            {
                XtraMessageBox.Show(
                    "لا يمكن حذف العملة الرئيسية.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var confirmResult = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف العملة '{currency.CurrencyName}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                var result = await _currencyService.DeleteCurrencyAsync(currency.Id);

                if (result)
                {
                    await LoadCurrenciesAsync();

                    XtraMessageBox.Show(
                        "تم حذف العملة بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(
                        "لا يمكن حذف العملة.\nقد تكون العملة الرئيسية أو مستخدمة في الفواتير أو السندات.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف العملة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void CurrenciesToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckCurrenciesLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadCurrenciesAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة العملات.\n{ex.Message}",
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

        private bool CheckCurrenciesLoading()
        {
            if (!_isLoadingCurrencies)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل العملات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل العملات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }
}

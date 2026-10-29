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
using UI.Forms.AccountsTree;

namespace UI.Forms
{
    public partial class AccountsTreeForm : XtraForm
    {
        private readonly IAccountsTreeService _accountsTreeService;
        private List<AccountsTreeDto> _accounts = new List<AccountsTreeDto>();
        private bool _isLoadingAccounts;

        public AccountsTreeForm(IAccountsTreeService accountsTreeService)
        {
            _accountsTreeService = accountsTreeService;
            InitializeComponent();

            if(toolBarControl1.SetManageVisible(CurrentUser.HasRole(UserRole.ManageAccountsTree)))
            {
                toolBarControl1.CreateClicked += AccountsToolbar_CreateClicked;
                toolBarControl1.EditClicked += AccountsToolbar_EditClicked;
                toolBarControl1.DeleteClicked += AccountsToolbar_DeleteClicked;
            }
                toolBarControl1.RefreshClicked += AccountsToolbar_RefreshClicked;
        }

        private async void AccountsTreeForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadAccountsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل شجرة الحسابات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadAccountsAsync()
        {
            if (CheckAccountsLoading())
                return;

            _isLoadingAccounts = true;
            try
            {
                _accounts = await this.WithLoading(cts =>
                    _accountsTreeService.GetAllAccountsAsync(cts),
                    "جارٍ تحميل شجرة الحسابات، يرجى الانتظار...");

                treeListControl1.DataSource = _accounts;
                treeListControl1.ExpandAll();

                if (treeListControl1.Nodes.Count > 0)
                {
                    treeListControl1.SetFocusedNode(treeListControl1.Nodes[0]);
                }
            }
            finally
            {
                _isLoadingAccounts = false;
            }
        }

        private async void AccountsToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckAccountsLoading())
                return;

            if (Navigator.ShowScopedDialog<AccountsTreeManageForm>() == DialogResult.OK)
            {
                await LoadAccountsAsync();
            }
        }

        private async void AccountsToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckAccountsLoading())
                return;

            var selectedAccount = GetSelectedAccount();

            if (selectedAccount == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار حساب لتعديله.",
                    "اختيار حساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (Navigator.ShowScopedDialog<AccountsTreeManageForm>(
                selectedAccount) == DialogResult.OK)
            {
                await LoadAccountsAsync();
            }
        }

        private async void AccountsToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckAccountsLoading())
                return;

            var account = GetSelectedAccount();

            if (account == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار حساب أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var childrenCount = GetChildrenCount(account);

            var message = childrenCount > 0
                ? $"هل أنت متأكد من حذف الحساب '{account.AccountName}'؟\nسيتم إلغاء ارتباط {childrenCount} من الحسابات الفرعية به."
                : $"هل أنت متأكد من حذف الحساب '{account.AccountName}'؟";

            var confirmResult = XtraMessageBox.Show(
                message,
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                var result = await _accountsTreeService.DeleteAccountAsync(account.Id);

                if (result)
                {
                    await LoadAccountsAsync();

                    XtraMessageBox.Show(
                        "تم حذف الحساب بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(
                        "لا يمكن حذف الحساب، قد يكون مستخدماً في الفواتير أو السندات.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف الحساب.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void AccountsToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckAccountsLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadAccountsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث شجرة الحسابات.\n{ex.Message}",
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

        private AccountsTreeDto GetSelectedAccount()
        {
            return treeListControl1.GetFocusedRow() as AccountsTreeDto;
        }

        private int GetChildrenCount(AccountsTreeDto account)
        {
            if (account == null)
                return 0;

            return _accounts.Count(a => a.ParentGuid == account.Id);
        }

        private bool CheckAccountsLoading()
        {
            if (!_isLoadingAccounts)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل الحسابات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل الحسابات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }
}

using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.AccountsTree
{
    public partial class AccountsTreeManageForm : XtraForm
    {
        private readonly IAccountsTreeService _accountsTreeService;
        private AccountsTreeDto _selectedAccount;
        private List<AccountsTreeDto> _accounts = new List<AccountsTreeDto>();
        private bool isEdit => _selectedAccount != null;

        public AccountsTreeManageForm(
            IAccountsTreeService accountsTreeService, AccountsTreeDto selectedAccount = null)
        {
            InitializeComponent();
            _accountsTreeService = accountsTreeService;
            _selectedAccount = selectedAccount;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void AccountsTreeManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadParentAccountsAsync();
                LoadAccountDetails(_selectedAccount);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل الحسابات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadParentAccountsAsync()
        {
            _accounts = await _accountsTreeService.GetAllAccountsAsync();

            var parents = GetParentCandidates()
                .OrderBy(a => a.AccountCode)
                .Select(a => new
                {
                    a.Id,
                    a.AccountCode,
                    a.AccountName
                })
                .ToList();

            cmbParent.Properties.DataSource = parents;
        }


        private List<AccountsTreeDto> GetParentCandidates()
        {
            var excludedIds = new HashSet<Guid>();

            if (_selectedAccount != null)
            {
                excludedIds.Add(_selectedAccount.Id);

                bool foundChild = true;
                while (foundChild)
                {
                    foundChild = false;

                    foreach (var account in _accounts)
                    {
                        if (account.ParentGuid.HasValue &&
                            excludedIds.Contains(account.ParentGuid.Value) &&
                            !excludedIds.Contains(account.Id))
                        {
                            excludedIds.Add(account.Id);
                            foundChild = true;
                        }
                    }
                }
            }

            return _accounts
                .Where(a => !excludedIds.Contains(a.Id))
                .ToList();
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var accountCode = txtAccountCode.Text.Trim();
            var accountName = txtAccountName.Text.Trim();
            var isLeaf = chkIsLeaf.Checked;
            var isActive = chkIsActive.Checked;
            var notes = txtNotes.Text;
            var parentGuid = cmbParent.EditValue as Guid?;

            if (!isEdit)
            {
                var newAccount = new CreateAccountsTreeDto()
                {
                    Id = Guid.NewGuid(),
                    ParentGuid = parentGuid,
                    AccountCode = accountCode,
                    AccountName = accountName,
                    IsLeaf = isLeaf,
                    IsActive = isActive,
                    Notes = notes
                };

                if (!ValidationHelper.IsValid(
                    new CreateAccountsTreeDtoConfiguration(),
                    newAccount,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _accountsTreeService.CreateAccountAsync(newAccount);

                if (result)
                {
                    MessageBox.Show(
                        "تم إضافة الحساب بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في إضافة الحساب، قد يكون رمز الحساب مكرراً",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                var updatedAccount = new UpdateAccountsTreeDto()
                {
                    Id = _selectedAccount.Id,
                    ParentGuid = parentGuid,
                    AccountCode = accountCode,
                    AccountName = accountName,
                    IsLeaf = isLeaf,
                    IsActive = isActive,
                    Notes = notes
                };

                if (!ValidationHelper.IsValid(
                    new UpdateAccountsTreeDtoConfiguration(),
                    updatedAccount,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _accountsTreeService.UpdateAccountAsync(updatedAccount);

                if (result)
                {
                    MessageBox.Show(
                        "تم تعديل الحساب بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في تعديل الحساب، قد يكون رمز الحساب مكرراً",
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

        private void LoadAccountDetails(AccountsTreeDto account)
        {
            if (account == null)
            {
                lblTitle.Text = "إضافة حساب";
                saveCancelControl21.SaveText = "إضافة";
                ClearDetails();
                return;
            }

            lblTitle.Text = "تعديل الحساب";
            saveCancelControl21.SaveText = "حفظ";

            txtAccountCode.Text = account.AccountCode;
            txtAccountName.Text = account.AccountName;
            chkIsLeaf.Checked = account.IsLeaf;
            chkIsActive.Checked = account.IsActive;
            txtNotes.Text = account.Notes;
            cmbParent.EditValue = account.ParentGuid;
        }

        private void ClearDetails()
        {
            txtAccountCode.Text = string.Empty;
            txtAccountName.Text = string.Empty;
            chkIsLeaf.Checked = false;
            chkIsActive.Checked = true;
            txtNotes.Text = string.Empty;
            cmbParent.EditValue = null;
        }
    }
}

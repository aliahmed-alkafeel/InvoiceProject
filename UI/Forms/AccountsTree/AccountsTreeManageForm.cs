using Data.Configurations.DTOsConfigurations;
using Data.Services.Implementations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            _accounts = await this.WithLoading(async cts =>
                await _accountsTreeService.GetAllAccountsAsync(cts),
                "جارٍ تحميل شجرة الحسابات، يرجى الانتظار...");

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
            if (_selectedAccount == null)
                return _accounts.ToList();

            var childrenByParent = _accounts
                .Where(a => a.ParentGuid.HasValue)
                .ToLookup(a => a.ParentGuid.Value);

            var excludedIds = new HashSet<Guid>();
            var stack = new Stack<Guid>();

            stack.Push(_selectedAccount.Id);

            while (stack.Count > 0)
            {
                var id = stack.Pop();

                if (!excludedIds.Add(id))
                    continue;

                foreach (var child in childrenByParent[id])
                    stack.Push(child.Id);
            }

            return _accounts
                .Where(a => !excludedIds.Contains(a.Id))
                .ToList();
        }



        private async void SaveCancelControl_SaveClicked()
        {
            try
            {
                await SaveAccountAsync();
            }
            catch (DbUpdateException)
            {
                MessageHelper.Error(isEdit
                    ? "فشل في تعديل الحساب، رمز الحساب أو اسم الحساب مستخدم بالفعل."
                    : "فشل في إضافة الحساب، رمز الحساب أو اسم الحساب مستخدم بالفعل.");
            }
            catch (Exception ex)
            {
                MessageHelper.Error($"فشل في حفظ الحساب.\n{ex.Message}");
            }
        }

        private async Task SaveAccountAsync()
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
                    MessageHelper.Error(errors);
                    return;
                }

                if (!await _accountsTreeService.CreateAccountAsync(newAccount))
                {
                    MessageHelper.Error("فشل في إضافة الحساب.");
                    return;
                }

                MessageHelper.Success("تم إضافة الحساب بنجاح");
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
                    MessageHelper.Error(errors);
                    return;
                }

                if (!await _accountsTreeService.UpdateAccountAsync(updatedAccount))
                {
                    MessageHelper.Error("فشل في تعديل الحساب.");
                    return;
                }

                MessageHelper.Success("تم تعديل الحساب بنجاح");
            }

            DialogResult = DialogResult.OK;
            Close();
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

        private void cmbParent_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

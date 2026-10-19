using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Groups
{
    public partial class GroupsManageForm : XtraForm
    {
        private readonly IGroupService _groupService;
        private GroupDto _selectedGroup;
        private bool isEdit => _selectedGroup != null;

        public GroupsManageForm(
            IGroupService groupService, GroupDto selectedGroup = null)
        {
            InitializeComponent();
            _groupService = groupService;
            _selectedGroup = selectedGroup;
            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void GroupsManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadRolesAsync();
                LoadGroupDetails(_selectedGroup);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل الصلاحيات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadRolesAsync()
        {
            var roles = await _groupService.GetAllRolesAsync();

            checkedListBoxControl1.BeginUpdate();
            try
            {
                checkedListBoxControl1.Items.Clear();

                foreach (var role in roles)
                {
                    checkedListBoxControl1.Items.Add(
                        new CheckedListBoxItem(
                            role.Id,
                            role.RoleName.ToString()));
                }
            }
            finally
            {
                checkedListBoxControl1.EndUpdate();
            }
        }

        private List<GroupRoleDto> GetCheckedRoles()
        {
            return checkedListBoxControl1.CheckedItems
                .Cast<CheckedListBoxItem>()
                .Select(item => new GroupRoleDto
                {
                    Id = Guid.NewGuid(),
                    RoleGuid = (Guid)item.Value
                })
                .ToList();
        }

        private async void SaveCancelControl_SaveClicked()
        {
            if (!isEdit)
            {
                var newGroup = new CreateGroupDto()
                {
                    Id = Guid.NewGuid(),
                    GroupName = txtName.Text,
                    Notes = txtNotes.Text,
                    GroupRoles = GetCheckedRoles()
                };

                if (!ValidationHelper.IsValid(new CreateGroupDtoConfiguration(), newGroup, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _groupService.CreateGroupAsync(newGroup);
                if (result)
                {
                    MessageBox.Show("تم إضافة المجموعة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في إضافة المجموعة، قد يكون الاسم مكرراً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var updatedGroup = new UpdateGroupDto()
                {
                    Id = _selectedGroup.Id,
                    GroupName = txtName.Text,
                    Notes = txtNotes.Text,
                    GroupRoles = GetCheckedRoles()
                };

                if (!ValidationHelper.IsValid(new UpdateGroupDtoConfiguration(), updatedGroup, out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _groupService.UpdateGroupAsync(updatedGroup);
                if (result)
                {
                    MessageBox.Show("تم تعديل المجموعة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("فشل في تعديل المجموعة، لا يمكن استخدام اسم مجموعة المسؤول أو اسم مكرر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveCancelControl_CancelClicked()
        {
            Close();
        }

        private void LoadGroupDetails(GroupDto group)
        {
            if (group == null)
            {
                lblTitle.Text = "إضافة مجموعة";
                saveCancelControl21.SaveText = "إضافة";
                ClearDetails();
                return;
            }

            lblTitle.Text = "تعديل المجموعة";
            saveCancelControl21.SaveText = "حفظ";

            txtName.Text = group.GroupName;
            txtNotes.Text = group.Notes;

            var roleIds = (group.GroupRoles ?? new List<GroupRoleDto>())
                .Where(gr => gr.Role != null)
                .Select(gr => gr.RoleGuid)
                .ToList();

            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                var item = (CheckedListBoxItem)checkedListBoxControl1.Items[i];

                checkedListBoxControl1.SetItemChecked(
                    i,
                    roleIds.Contains((Guid)item.Value));
            }
        }

        private void ClearDetails()
        {
            txtName.Text = string.Empty;
            txtNotes.Text = string.Empty;

            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                checkedListBoxControl1.SetItemChecked(i, false);
            }
        }
    }
}

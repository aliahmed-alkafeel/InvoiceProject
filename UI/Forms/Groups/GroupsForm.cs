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
using UI.Forms.Groups;

namespace UI.Forms
{
    public partial class GroupsForm : XtraForm
    {
        private readonly IGroupService _groupService;
        private bool _isLoadingGroups;

        public GroupsForm(IGroupService groupService)
        {
            _groupService = groupService;
            InitializeComponent();
            if (toolBarControl1.SetManageVisible(CurrentUser.HasRole(UserRole.ManageGroups)))
            {
            toolBarControl1.CreateClicked += GroupsToolbar_CreateClicked;
            toolBarControl1.EditClicked += GroupsToolbar_EditClicked;
            toolBarControl1.DeleteClicked += GroupsToolbar_DeleteClicked;
            }
            toolBarControl1.RefreshClicked += GroupsToolbar_RefreshClicked;
        }

        private async void GroupsForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل المجموعات.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadGroupsAsync()
        {
            if (CheckGroupsLoading())
                return;

            _isLoadingGroups = true;
            try
            {
                var groups = await this.WithLoading(cts =>
                    _groupService.GetAllGroupsAsync(cts),
                    "جارٍ تحميل المجموعات، يرجى الانتظار...");

                gridControl1.DataSource = groups;

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingGroups = false;
            }
        }

        private async void GroupsToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckGroupsLoading())
                return;

            using (var manageForm = Program.ServiceProvider
                .GetService(typeof(GroupsManageForm)) as GroupsManageForm)
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadGroupsAsync();
                }
            }
        }

        private async void GroupsToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckGroupsLoading())
                return;

            var selectedGroup = gridView1.GetFocusedRow() as GroupDto;

            if (selectedGroup == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار مجموعة لتعديلها.",
                    "اختيار مجموعة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (var manageForm =
                ActivatorUtilities.CreateInstance<GroupsManageForm>(
                    Program.CurrentScopeProvider,
                    selectedGroup))
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadGroupsAsync();
                }
            }
        }
        
        private async void GroupsToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckGroupsLoading())
                return;

            var group = gridView1.GetFocusedRow() as GroupDto;

            if (group == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار مجموعة أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var confirmResult = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف المجموعة '{group.GroupName}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                var result = await _groupService.DeleteGroupAsync(group.Id);

                if (result)
                {
                    await LoadGroupsAsync();

                    XtraMessageBox.Show(
                        ".تم حذف المجموعة بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(
                        "لا يمكن حذف المجموعة.\nقد تكون مجموعة المسؤول أو توجد موظفون مرتبطون بها.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف المجموعة.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void GroupsToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckGroupsLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadGroupsAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة المجموعات.\n{ex.Message}",
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

        private bool CheckGroupsLoading()
        {
            if (!_isLoadingGroups)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل المجموعات، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل المجموعات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

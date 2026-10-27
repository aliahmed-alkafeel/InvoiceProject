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
using UI.Forms.Employees;

namespace UI.Forms
{
    public partial class EmployeesForm : XtraForm
    {
        private readonly IEmployeeService _employeeService;
        private bool _isLoadingEmployees;

        public EmployeesForm(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
            if(toolBarControl1.SetManageVisible(CurrentUser.HasRole(UserRole.ManageEmployees)))
            {

            toolBarControl1.CreateClicked += EmployeesToolbar_CreateClicked;
            toolBarControl1.EditClicked += EmployeesToolbar_EditClicked;
            toolBarControl1.DeleteClicked += EmployeesToolbar_DeleteClicked;
            }
            toolBarControl1.RefreshClicked += EmployeesToolbar_RefreshClicked;
        }

        private async void EmployeesForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await LoadEmployeesAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحميل الموظفين.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployeesAsync()
        {
            if (CheckEmployeesLoading())
                return;

            _isLoadingEmployees = true;
            try
            {
                var employees = await this.WithLoading(cts =>
                    _employeeService.GetAllEmployeesAsync(cts),
                    "جارٍ تحميل الموظفين، يرجى الانتظار...");

                gridControl1.DataSource = employees;
                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            finally
            {
                _isLoadingEmployees = false;
            }
        }

        private async void EmployeesToolbar_CreateClicked(
            object sender,
            EventArgs e)
        {
            if (CheckEmployeesLoading())
                return;

            using (var manageForm = Program.CurrentScopeProvider
                .GetService(typeof(EmployeesManageForm)) as EmployeesManageForm)
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadEmployeesAsync();
                }
            }
        }

        private async void EmployeesToolbar_EditClicked(
            object sender,
            EventArgs e)
        {
            if (CheckEmployeesLoading())
                return;

            var selectedEmployee = gridView1.GetFocusedRow() as EmployeeDto;

            if (selectedEmployee == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار موظف لتعديله.",
                    "اختيار موظف",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (var manageForm =
                ActivatorUtilities.CreateInstance<EmployeesManageForm>(
                    Program.CurrentScopeProvider,
                    selectedEmployee))
            {
                var result = manageForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    await LoadEmployeesAsync();
                }
            }
        }

        private async void EmployeesToolbar_DeleteClicked(
            object sender,
            EventArgs e)
        {
            if (CheckEmployeesLoading())
                return;

            var selectedEmployee = gridView1.GetFocusedRow() as EmployeeDto;

            if (selectedEmployee == null)
            {
                XtraMessageBox.Show(
                    "يرجى اختيار موظف أولاً",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var confirmResult = XtraMessageBox.Show(
                $"هل أنت متأكد من حذف الموظف '{selectedEmployee.FullName}'؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                var result = await _employeeService.DeleteEmployeeAsync(selectedEmployee.Id);

                if (result)
                {
                    await LoadEmployeesAsync();
                    XtraMessageBox.Show(
                        "تم حذف الموظف بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(
                        "لا يمكن حذف الموظف.\nقد يكون موظف مجموعة الإدارة.",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل حذف الموظف.\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void EmployeesToolbar_RefreshClicked(
            object sender,
            EventArgs e)
        {
            if (CheckEmployeesLoading())
                return;

            UseWaitCursor = true;

            try
            {
                await LoadEmployeesAsync();
                gridView1.ClearGrouping();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"فشل تحديث قائمة الموظفين.\n{ex.Message}",
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

        private bool CheckEmployeesLoading()
        {
            if (!_isLoadingEmployees)
                return false;

            XtraMessageBox.Show(
                "جارٍ تحميل الموظفين، يرجى الانتظار حتى اكتمال التحميل.",
                "تحميل الموظفين",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

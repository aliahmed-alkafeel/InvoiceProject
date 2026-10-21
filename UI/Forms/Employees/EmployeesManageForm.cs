using Data.Configurations.DTOsConfigurations;
using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using Models.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace UI.Forms.Employees
{
    public partial class EmployeesManageForm : XtraForm
    {
        private readonly IEmployeeService _employeeService;
        private readonly IGroupService _groupService;
        private EmployeeDto _selectedEmployee;
        private bool isEdit => _selectedEmployee != null;

        public EmployeesManageForm(
            IEmployeeService employeeService,
            IGroupService groupService,
            EmployeeDto selectedEmployee = null)
        {
            InitializeComponent();

            _employeeService = employeeService;
            _groupService = groupService;
            _selectedEmployee = selectedEmployee;

            saveCancelControl21.SaveClicked += SaveCancelControl_SaveClicked;
            saveCancelControl21.CancelClicked += SaveCancelControl_CancelClicked;
        }

        private async void EmployeesManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadGroupsAsync();
                LoadEmployeeDetails(_selectedEmployee);
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
            var groups = (await _groupService.GetAllGroupsAsync())
                .Select(g => new
                {
                    g.Id,
                    g.GroupName
                })
                .ToList();

            cmbGroups.Properties.DataSource = groups;
            cmbGroups.Properties.DisplayMember = "GroupName";
            cmbGroups.Properties.ValueMember = "Id";
            cmbGroups.Properties.NullText = "اختر المجموعة";
        }

        private Guid GetSelectedGroupId()
        {
            return cmbGroups.EditValue is Guid groupId
                ? groupId
                : Guid.Empty;
        }

        private DateTime? GetDateValue(DateEdit editor)
        {
            if (editor.EditValue is DateTime date)
                return date;

            if (editor.EditValue is DateTimeOffset dateTimeOffset)
                return dateTimeOffset.DateTime;

            return null;
        }

        private async void SaveCancelControl_SaveClicked()
        {
            var startingDate = GetDateValue(deStartingDate) ?? DateTime.Now;
            var endingDate = GetDateValue(deEndingDate);

            if (!isEdit)
            {
                var newEmployee = new CreateEmployeeDto()
                {
                    Id = Guid.NewGuid(),
                    GroupGuid = GetSelectedGroupId(),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhone.Text,
                    EmployeeStartingDate = startingDate,
                    EmployeeEndingDate = endingDate
                };

                if (!ValidationHelper.IsValid(
                    new CreateEmployeeDtoConfiguration(),
                    newEmployee,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _employeeService.CreateEmployeeAsync(newEmployee);
                if (result)
                {
                    MessageBox.Show(
                        "تم إضافة الموظف بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }

                else
                {
                    MessageBox.Show(
                        "فشل في إضافة الموظف، قد يكون الإيميل أو اسم المستخدم مكرراً",
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                var updatedEmployee = new UpdateEmployeeDto()
                {
                    Id = _selectedEmployee.Id,
                    GroupGuid = GetSelectedGroupId(),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhone.Text,
                    EmployeeStartingDate = startingDate,
                    EmployeeEndingDate = endingDate
                };

                if (!ValidationHelper.IsValid(
                    new UpdateEmployeeDtoConfiguration(),
                    updatedEmployee,
                    out var errors))
                {
                    XtraMessageBox.Show(errors);
                    return;
                }

                var result = await _employeeService.UpdateEmployeeAsync(updatedEmployee);

                if (result)
                {
                    MessageBox.Show(
                        "تم تعديل الموظف بنجاح",
                        "نجاح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "فشل في تعديل الموظف، قد يكون الإيميل أو اسم المستخدم مكرراً",
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

        private void LoadEmployeeDetails(EmployeeDto employee)
        {
            if (employee == null)
            {
                lblTitle.Text = "إضافة موظف";
                saveCancelControl21.SaveText = "إضافة";
                lblPasswordHint.Visible = false;
                ClearDetails();
                return;
            }

            lblTitle.Text = "تعديل الموظف";
            saveCancelControl21.SaveText = "حفظ";
            lblPasswordHint.Visible = true;

            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtUsername.Text = employee.Username;
            txtPassword.Text = string.Empty;
            txtEmail.Text = employee.Email;
            txtPhone.Text = employee.PhoneNumber;
            cmbGroups.EditValue = employee.GroupGuid;
            deStartingDate.EditValue = employee.EmployeeStartingDate;
            deEndingDate.EditValue = employee.EmployeeEndingDate;
        }

        private void ClearDetails()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cmbGroups.EditValue = null;
            deStartingDate.EditValue = DateTime.Now;
            deEndingDate.EditValue = null;
        }
    }
}

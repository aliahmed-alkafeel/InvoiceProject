using Data.Services.Interfaces;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Screens
{
    public partial class LogInForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoginService _loginService;

        public LogInForm(ILoginService loginService)
        {
            InitializeComponent();
            _loginService = loginService;
            this.AcceptButton = this.btnLogIn;
            var rememberedUsername =
            Properties.Settings.Default.RememberedUsername;
            if (!string.IsNullOrWhiteSpace(rememberedUsername))
            {
                txtUsername.Text = rememberedUsername;
                checkRememberMe.Checked = true;
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void UsernameTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void WelcomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void PassTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            //string password = txtPassword.Text;
            string password = "admin";
            var loginResult = await _loginService.LoginAsync(username, password);
            if (!loginResult)
            {
                XtraMessageBox.Show(
                    "Username or password is incorrect.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (checkRememberMe.Checked)
            {
                Properties.Settings.Default.RememberedUsername = txtUsername.Text;
            }
            else
            {
                Properties.Settings.Default.RememberedUsername = string.Empty;
            }

            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
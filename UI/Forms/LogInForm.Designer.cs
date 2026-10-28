namespace UI.Screens
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.PassLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnLogIn = new DevExpress.XtraEditors.SimpleButton();
            this.checkRememberMe = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRememberMe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabelControl
            // 
            this.UsernameLabelControl.Location = new System.Drawing.Point(228, 64);
            this.UsernameLabelControl.Name = "UsernameLabelControl";
            this.UsernameLabelControl.Size = new System.Drawing.Size(78, 13);
            this.UsernameLabelControl.TabIndex = 0;
            this.UsernameLabelControl.Text = ":اسم المستخدم";
            // 
            // PassLabelControl
            // 
            this.PassLabelControl.Location = new System.Drawing.Point(244, 100);
            this.PassLabelControl.Name = "PassLabelControl";
            this.PassLabelControl.Size = new System.Drawing.Size(62, 13);
            this.PassLabelControl.TabIndex = 1;
            this.PassLabelControl.Text = ":الرمز السري";
            this.PassLabelControl.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.EditValue = "";
            this.txtUsername.Location = new System.Drawing.Point(89, 61);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(133, 20);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.EditValueChanged += new System.EventHandler(this.UsernameTextEdit_EditValueChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(133, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.EditValueChanged += new System.EventHandler(this.PassTextEdit_EditValueChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(165, 161);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(85, 26);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "تسجيل الدخول";
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // checkRememberMe
            // 
            this.checkRememberMe.EditValue = true;
            this.checkRememberMe.Location = new System.Drawing.Point(179, 129);
            this.checkRememberMe.Name = "checkRememberMe";
            this.checkRememberMe.Properties.Caption = "تذكر اسم المستخدم";
            this.checkRememberMe.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkRememberMe.Size = new System.Drawing.Size(127, 20);
            this.checkRememberMe.TabIndex = 6;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 245);
            this.Controls.Add(this.checkRememberMe);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.PassLabelControl);
            this.Controls.Add(this.UsernameLabelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRememberMe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl UsernameLabelControl;
        private DevExpress.XtraEditors.LabelControl PassLabelControl;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogIn;
        private DevExpress.XtraEditors.CheckEdit checkRememberMe;
    }
}
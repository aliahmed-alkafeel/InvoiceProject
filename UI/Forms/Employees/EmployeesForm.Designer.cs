namespace UI.Forms
{
    partial class EmployeesForm
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
            this.toolBarControl1 = new UI.Controls.ToolBarControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(976, 55);
            this.toolBarControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 55);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(976, 412);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colGroup,
            this.colUsername,
            this.colPhone,
            this.colEmail,
            this.colStartingDate,
            this.colEndingDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "الاسم الكامل";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            this.colFullName.Width = 200;
            // 
            // colGroup
            // 
            this.colGroup.Caption = "المجموعة";
            this.colGroup.FieldName = "GroupName";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 1;
            this.colGroup.Width = 160;
            // 
            // colUsername
            // 
            this.colUsername.Caption = "اسم المستخدم";
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 2;
            this.colUsername.Width = 140;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "رقم الهاتف";
            this.colPhone.FieldName = "PhoneNumber";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 3;
            this.colPhone.Width = 140;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "البريد الإلكتروني";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 220;
            // 
            // colStartingDate
            // 
            this.colStartingDate.Caption = "تاريخ التعيين";
            this.colStartingDate.FieldName = "EmployeeStartingDate";
            this.colStartingDate.Name = "colStartingDate";
            this.colStartingDate.Visible = true;
            this.colStartingDate.VisibleIndex = 5;
            this.colStartingDate.Width = 130;
            // 
            // colEndingDate
            // 
            this.colEndingDate.Caption = "تاريخ الانتهاء";
            this.colEndingDate.FieldName = "EmployeeEndingDate";
            this.colEndingDate.Name = "colEndingDate";
            this.colEndingDate.Visible = true;
            this.colEndingDate.VisibleIndex = 6;
            this.colEndingDate.Width = 130;
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 467);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "EmployeesForm";
            this.Text = "الموظفين";
            this.Load += new System.EventHandler(this.EmployeesForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ToolBarControl toolBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colStartingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndingDate;
    }
}

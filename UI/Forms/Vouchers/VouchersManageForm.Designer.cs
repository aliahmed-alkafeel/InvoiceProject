namespace UI.Forms.Vouchers
{
    partial class VouchersManageForm
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
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            this.spnPrice = new DevExpress.XtraEditors.SpinEdit();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.cmbAccounts = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbVoucherTypes = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeOffsetEdit1 = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoucherTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeOffsetEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // saveCancelControl21
            // 
            this.saveCancelControl21.Location = new System.Drawing.Point(105, 394);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.SaveText = "حفظ";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 0;
            // 
            // spnPrice
            // 
            this.spnPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnPrice.Location = new System.Drawing.Point(150, 191);
            this.spnPrice.Name = "spnPrice";
            this.spnPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnPrice.Size = new System.Drawing.Size(89, 20);
            this.spnPrice.TabIndex = 77;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(148, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(91, 27);
            this.lblTitle.TabIndex = 76;
            this.lblTitle.Text = "تعديل المنتج";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.Location = new System.Drawing.Point(56, 152);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccounts.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbAccounts.Size = new System.Drawing.Size(183, 20);
            this.cmbAccounts.TabIndex = 75;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colId});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "اسم الفئة";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.Caption = "gridColumn1";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(256, 318);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 17);
            this.labelControl5.TabIndex = 74;
            this.labelControl5.Text = ":الملاحظات";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(256, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 17);
            this.labelControl4.TabIndex = 73;
            this.labelControl4.Text = ":رقم السند";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 20);
            this.txtName.TabIndex = 72;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.7F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(256, 152);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 16);
            this.labelControl2.TabIndex = 71;
            this.labelControl2.Text = ":الحساب المحاسبي";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(56, 315);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(194, 59);
            this.txtNotes.TabIndex = 69;
            this.txtNotes.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(256, 195);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 17);
            this.labelControl3.TabIndex = 68;
            this.labelControl3.Text = ":الكمية";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(150, 233);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Size = new System.Drawing.Size(89, 20);
            this.spinEdit1.TabIndex = 79;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(256, 237);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 17);
            this.labelControl1.TabIndex = 78;
            this.labelControl1.Text = ":قيمة العملة";
            // 
            // cmbVoucherTypes
            // 
            this.cmbVoucherTypes.Location = new System.Drawing.Point(56, 115);
            this.cmbVoucherTypes.Name = "cmbVoucherTypes";
            this.cmbVoucherTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVoucherTypes.Properties.PopupView = this.gridView1;
            this.cmbVoucherTypes.Size = new System.Drawing.Size(183, 20);
            this.cmbVoucherTypes.TabIndex = 81;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "اسم الفئة";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn1";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.7F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(256, 115);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 16);
            this.labelControl6.TabIndex = 80;
            this.labelControl6.Text = ":نوع السند";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(256, 281);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 17);
            this.labelControl7.TabIndex = 82;
            this.labelControl7.Text = ":التاريخ";
            // 
            // dateTimeOffsetEdit1
            // 
            this.dateTimeOffsetEdit1.EditValue = null;
            this.dateTimeOffsetEdit1.Location = new System.Drawing.Point(56, 278);
            this.dateTimeOffsetEdit1.Name = "dateTimeOffsetEdit1";
            this.dateTimeOffsetEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeOffsetEdit1.Size = new System.Drawing.Size(183, 20);
            this.dateTimeOffsetEdit1.TabIndex = 84;
            // 
            // VouchersManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 486);
            this.Controls.Add(this.dateTimeOffsetEdit1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.cmbVoucherTypes);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spnPrice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.saveCancelControl21);
            this.Name = "VouchersManageForm";
            this.Text = "VouchersManageForm";
            this.Load += new System.EventHandler(this.VouchersManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoucherTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeOffsetEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SaveCancelControl2 saveCancelControl21;
        private DevExpress.XtraEditors.SpinEdit spnPrice;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbAccounts;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox txtNotes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbVoucherTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateTimeOffsetEdit dateTimeOffsetEdit1;
    }
}
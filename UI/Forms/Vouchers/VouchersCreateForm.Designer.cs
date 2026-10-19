namespace UI.Forms.Vouchers
{
    partial class VouchersCreateForm
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
            this.cmbVoucherTypes = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.spnAmount = new DevExpress.XtraEditors.SpinEdit();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.cmbAccounts = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            this.cmbCurrencies = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoucherTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrencies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVoucherTypes
            // 
            this.cmbVoucherTypes.Location = new System.Drawing.Point(55, 79);
            this.cmbVoucherTypes.Name = "cmbVoucherTypes";
            this.cmbVoucherTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVoucherTypes.Properties.PopupView = this.gridView1;
            this.cmbVoucherTypes.Size = new System.Drawing.Size(183, 20);
            this.cmbVoucherTypes.TabIndex = 98;
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
            this.labelControl6.Location = new System.Drawing.Point(255, 79);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 16);
            this.labelControl6.TabIndex = 97;
            this.labelControl6.Text = ":نوع السند";
            // 
            // spnAmount
            // 
            this.spnAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnAmount.Location = new System.Drawing.Point(147, 193);
            this.spnAmount.Name = "spnAmount";
            this.spnAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnAmount.Size = new System.Drawing.Size(91, 20);
            this.spnAmount.TabIndex = 94;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(147, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 27);
            this.lblTitle.TabIndex = 93;
            this.lblTitle.Text = "اضافة سند";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.Location = new System.Drawing.Point(55, 116);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccounts.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbAccounts.Size = new System.Drawing.Size(183, 20);
            this.cmbAccounts.TabIndex = 92;
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
            this.labelControl5.Location = new System.Drawing.Point(255, 240);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 17);
            this.labelControl5.TabIndex = 91;
            this.labelControl5.Text = ":الملاحظات";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.7F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(255, 116);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 16);
            this.labelControl2.TabIndex = 88;
            this.labelControl2.Text = ":الحساب المحاسبي";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(55, 237);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(194, 59);
            this.txtNotes.TabIndex = 87;
            this.txtNotes.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(255, 197);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 17);
            this.labelControl3.TabIndex = 86;
            this.labelControl3.Text = ":المبلغ";
            // 
            // saveCancelControl21
            // 
            this.saveCancelControl21.Location = new System.Drawing.Point(104, 316);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.SaveText = "اضافة";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 85;
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Location = new System.Drawing.Point(55, 157);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCurrencies.Properties.PopupView = this.gridView2;
            this.cmbCurrencies.Size = new System.Drawing.Size(183, 20);
            this.cmbCurrencies.TabIndex = 100;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "اسم الفئة";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn1";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(255, 160);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 17);
            this.labelControl1.TabIndex = 99;
            this.labelControl1.Text = ":العملة";
            // 
            // VouchersCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 402);
            this.Controls.Add(this.cmbCurrencies);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbVoucherTypes);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.spnAmount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.saveCancelControl21);
            this.Name = "VouchersCreateForm";
            this.Text = "اضافة سند";
            this.Load += new System.EventHandler(this.VouchersCreateFormAsync_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoucherTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrencies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cmbVoucherTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit spnAmount;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbAccounts;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox txtNotes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Controls.SaveCancelControl2 saveCancelControl21;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbCurrencies;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
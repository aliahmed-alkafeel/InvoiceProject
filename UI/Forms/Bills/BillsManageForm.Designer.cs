namespace UI.Forms.Bills
{
    partial class BillsManageForm
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelBillNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelBillType = new DevExpress.XtraEditors.LabelControl();
            this.labelAccountTree = new DevExpress.XtraEditors.LabelControl();
            this.labelCurrency = new DevExpress.XtraEditors.LabelControl();
            this.labelCurrencyEqualValue = new DevExpress.XtraEditors.LabelControl();
            this.labelDate = new DevExpress.XtraEditors.LabelControl();
            this.labelNotes = new DevExpress.XtraEditors.LabelControl();
            this.labelItems = new DevExpress.XtraEditors.LabelControl();
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.cmbBillType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbAccountTree = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridViewAccountTree = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbCurrency = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridViewCurrency = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spnCurrencyEqualValue = new DevExpress.XtraEditors.SpinEdit();
            this.deDate = new DevExpress.XtraEditors.DateEdit();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountTree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccountTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCurrencyEqualValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(330, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إضافة فاتورة";
            //
            // labelBillNumber
            //
            this.labelBillNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelBillNumber.Appearance.Options.UseFont = true;
            this.labelBillNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelBillNumber.AutoSize = false;
            this.labelBillNumber.Location = new System.Drawing.Point(730, 70);
            this.labelBillNumber.Name = "labelBillNumber";
            this.labelBillNumber.Size = new System.Drawing.Size(150, 20);
            this.labelBillNumber.TabIndex = 1;
            this.labelBillNumber.Text = ":رقم الفاتورة";
            //
            // labelBillType
            //
            this.labelBillType.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelBillType.Appearance.Options.UseFont = true;
            this.labelBillType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelBillType.AutoSize = false;
            this.labelBillType.Location = new System.Drawing.Point(730, 106);
            this.labelBillType.Name = "labelBillType";
            this.labelBillType.Size = new System.Drawing.Size(150, 20);
            this.labelBillType.TabIndex = 2;
            this.labelBillType.Text = ":نوع الفاتورة";
            //
            // labelAccountTree
            //
            this.labelAccountTree.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelAccountTree.Appearance.Options.UseFont = true;
            this.labelAccountTree.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelAccountTree.AutoSize = false;
            this.labelAccountTree.Location = new System.Drawing.Point(730, 142);
            this.labelAccountTree.Name = "labelAccountTree";
            this.labelAccountTree.Size = new System.Drawing.Size(150, 20);
            this.labelAccountTree.TabIndex = 3;
            this.labelAccountTree.Text = ":الحساب المحاسبي";
            //
            // labelCurrency
            //
            this.labelCurrency.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelCurrency.Appearance.Options.UseFont = true;
            this.labelCurrency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelCurrency.AutoSize = false;
            this.labelCurrency.Location = new System.Drawing.Point(730, 178);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(150, 20);
            this.labelCurrency.TabIndex = 4;
            this.labelCurrency.Text = ":العملة";
            //
            // labelCurrencyEqualValue
            //
            this.labelCurrencyEqualValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelCurrencyEqualValue.Appearance.Options.UseFont = true;
            this.labelCurrencyEqualValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelCurrencyEqualValue.AutoSize = false;
            this.labelCurrencyEqualValue.Location = new System.Drawing.Point(730, 214);
            this.labelCurrencyEqualValue.Name = "labelCurrencyEqualValue";
            this.labelCurrencyEqualValue.Size = new System.Drawing.Size(150, 20);
            this.labelCurrencyEqualValue.TabIndex = 5;
            this.labelCurrencyEqualValue.Text = ":سعر الصرف";
            //
            // labelDate
            //
            this.labelDate.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelDate.Appearance.Options.UseFont = true;
            this.labelDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelDate.AutoSize = false;
            this.labelDate.Location = new System.Drawing.Point(730, 250);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(150, 20);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = ":التاريخ";
            //
            // labelNotes
            //
            this.labelNotes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelNotes.Appearance.Options.UseFont = true;
            this.labelNotes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelNotes.AutoSize = false;
            this.labelNotes.Location = new System.Drawing.Point(730, 290);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(150, 20);
            this.labelNotes.TabIndex = 7;
            this.labelNotes.Text = ":الملاحظات";
            //
            // labelItems
            //
            this.labelItems.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelItems.Appearance.Options.UseFont = true;
            this.labelItems.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelItems.AutoSize = false;
            this.labelItems.Location = new System.Drawing.Point(730, 356);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(150, 20);
            this.labelItems.TabIndex = 8;
            this.labelItems.Text = ":مواد الفاتورة";
            //
            // txtBillNumber
            //
            this.txtBillNumber.Location = new System.Drawing.Point(420, 68);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(290, 22);
            this.txtBillNumber.TabIndex = 9;
            //
            // cmbBillType
            //
            this.cmbBillType.Location = new System.Drawing.Point(420, 104);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBillType.Size = new System.Drawing.Size(290, 22);
            this.cmbBillType.TabIndex = 10;
            //
            // cmbAccountTree
            //
            this.cmbAccountTree.Location = new System.Drawing.Point(420, 140);
            this.cmbAccountTree.Name = "cmbAccountTree";
            this.cmbAccountTree.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountTree.Properties.PopupView = this.gridViewAccountTree;
            this.cmbAccountTree.Size = new System.Drawing.Size(290, 22);
            this.cmbAccountTree.TabIndex = 11;
            //
            // gridViewAccountTree
            //
            this.gridViewAccountTree.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccountName,
            this.colAccountId});
            this.gridViewAccountTree.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewAccountTree.Name = "gridViewAccountTree";
            this.gridViewAccountTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewAccountTree.OptionsView.ShowGroupPanel = false;
            //
            // colAccountName
            //
            this.colAccountName.Caption = "اسم الحساب";
            this.colAccountName.FieldName = "AccountName";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Visible = true;
            this.colAccountName.VisibleIndex = 0;
            //
            // colAccountId
            //
            this.colAccountId.Caption = "Id";
            this.colAccountId.FieldName = "Id";
            this.colAccountId.Name = "colAccountId";
            //
            // cmbCurrency
            //
            this.cmbCurrency.Location = new System.Drawing.Point(420, 176);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCurrency.Properties.PopupView = this.gridViewCurrency;
            this.cmbCurrency.Size = new System.Drawing.Size(290, 22);
            this.cmbCurrency.TabIndex = 12;
            //
            // gridViewCurrency
            //
            this.gridViewCurrency.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrencyName,
            this.colCurrencyId});
            this.gridViewCurrency.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewCurrency.Name = "gridViewCurrency";
            this.gridViewCurrency.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCurrency.OptionsView.ShowGroupPanel = false;
            //
            // colCurrencyName
            //
            this.colCurrencyName.Caption = "اسم العملة";
            this.colCurrencyName.FieldName = "CurrencyName";
            this.colCurrencyName.Name = "colCurrencyName";
            this.colCurrencyName.Visible = true;
            this.colCurrencyName.VisibleIndex = 0;
            //
            // colCurrencyId
            //
            this.colCurrencyId.Caption = "Id";
            this.colCurrencyId.FieldName = "Id";
            this.colCurrencyId.Name = "colCurrencyId";
            //
            // spnCurrencyEqualValue
            //
            this.spnCurrencyEqualValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnCurrencyEqualValue.Location = new System.Drawing.Point(420, 212);
            this.spnCurrencyEqualValue.Name = "spnCurrencyEqualValue";
            this.spnCurrencyEqualValue.Properties.IsFloatValue = true;
            this.spnCurrencyEqualValue.Properties.MinValue = 0m;
            this.spnCurrencyEqualValue.Properties.MaxValue = 1000000m;
            this.spnCurrencyEqualValue.Properties.Increment = 0.01m;
            this.spnCurrencyEqualValue.Size = new System.Drawing.Size(290, 22);
            this.spnCurrencyEqualValue.TabIndex = 13;
            //
            // deDate
            //
            this.deDate.EditValue = null;
            this.deDate.Location = new System.Drawing.Point(420, 248);
            this.deDate.Name = "deDate";
            this.deDate.Size = new System.Drawing.Size(290, 22);
            this.deDate.TabIndex = 14;
            //
            // txtNotes
            //
            this.txtNotes.Location = new System.Drawing.Point(420, 286);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(290, 60);
            this.txtNotes.TabIndex = 15;
            this.txtNotes.Text = "";
            //
            // gridControlItems
            //
            this.gridControlItems.Dock = System.Windows.Forms.DockStyle.None;
            this.gridControlItems.Location = new System.Drawing.Point(40, 380);
            this.gridControlItems.MainView = this.gridViewItems;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControlItems.Size = new System.Drawing.Size(840, 170);
            this.gridControlItems.TabIndex = 16;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            //
            // gridViewItems
            //
            this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem,
            this.colQty,
            this.colPrice});
            this.gridViewItems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewItems.GridControl = this.gridControlItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsBehavior.Editable = true;
            this.gridViewItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            this.gridViewItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewItems_CellValueChanged);
            this.gridViewItems.RowCountChanged += new System.EventHandler(this.gridViewItems_RowCountChanged);
            //
            // colItem
            //
            this.colItem.Caption = "المادة";
            this.colItem.FieldName = "ItemGuid";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            this.colItem.Width = 320;
            //
            // colQty
            //
            this.colQty.Caption = "الكمية";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            this.colQty.Width = 140;
            //
            // colPrice
            //
            this.colPrice.Caption = "السعر";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 140;
            //
            // lblTotal
            //
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotal.AutoSize = false;
            this.lblTotal.Location = new System.Drawing.Point(60, 560);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(300, 24);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "الإجمالي: 0";
            //
            // saveCancelControl21
            //
            this.saveCancelControl21.Location = new System.Drawing.Point(375, 555);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.SaveText = "حفظ";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 18;
            //
            // BillsManageForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.labelBillNumber);
            this.Controls.Add(this.labelBillType);
            this.Controls.Add(this.labelAccountTree);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.labelCurrencyEqualValue);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.cmbBillType);
            this.Controls.Add(this.cmbAccountTree);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.spnCurrencyEqualValue);
            this.Controls.Add(this.deDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.gridControlItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.saveCancelControl21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillsManageForm";
            this.Text = "الفواتير";
            this.Load += new System.EventHandler(this.BillsManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountTree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccountTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCurrencyEqualValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl labelBillNumber;
        private DevExpress.XtraEditors.LabelControl labelBillType;
        private DevExpress.XtraEditors.LabelControl labelAccountTree;
        private DevExpress.XtraEditors.LabelControl labelCurrency;
        private DevExpress.XtraEditors.LabelControl labelCurrencyEqualValue;
        private DevExpress.XtraEditors.LabelControl labelDate;
        private DevExpress.XtraEditors.LabelControl labelNotes;
        private DevExpress.XtraEditors.LabelControl labelItems;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBillType;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbAccountTree;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAccountTree;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountId;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbCurrency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyId;
        private DevExpress.XtraEditors.SpinEdit spnCurrencyEqualValue;
        private DevExpress.XtraEditors.DateEdit deDate;
        private System.Windows.Forms.RichTextBox txtNotes;
        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private Controls.SaveCancelControl2 saveCancelControl21;
    }
}

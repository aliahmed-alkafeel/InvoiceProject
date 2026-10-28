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
            this.spinBillNumber = new DevExpress.XtraEditors.SpinEdit();
            this.cmbBillType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridViewBillType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBillType = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.repositoryItemGridLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteItem = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            this.colLookupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLookupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBillType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountTree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccountTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCurrencyEqualValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Location = new System.Drawing.Point(330, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(99, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إضافة فاتورة";
            // 
            // labelBillNumber
            // 
            this.labelBillNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelBillNumber.Appearance.Options.UseFont = true;
            this.labelBillNumber.Appearance.Options.UseTextOptions = true;
            this.labelBillNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelBillNumber.Location = new System.Drawing.Point(730, 53);
            this.labelBillNumber.Name = "labelBillNumber";
            this.labelBillNumber.Size = new System.Drawing.Size(70, 17);
            this.labelBillNumber.TabIndex = 1;
            this.labelBillNumber.Text = ":رقم الفاتورة";
            // 
            // labelBillType
            // 
            this.labelBillType.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelBillType.Appearance.Options.UseFont = true;
            this.labelBillType.Appearance.Options.UseTextOptions = true;
            this.labelBillType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelBillType.Location = new System.Drawing.Point(730, 89);
            this.labelBillType.Name = "labelBillType";
            this.labelBillType.Size = new System.Drawing.Size(67, 17);
            this.labelBillType.TabIndex = 2;
            this.labelBillType.Text = ":نوع الفاتورة";
            // 
            // labelAccountTree
            // 
            this.labelAccountTree.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelAccountTree.Appearance.Options.UseFont = true;
            this.labelAccountTree.Appearance.Options.UseTextOptions = true;
            this.labelAccountTree.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelAccountTree.Location = new System.Drawing.Point(730, 125);
            this.labelAccountTree.Name = "labelAccountTree";
            this.labelAccountTree.Size = new System.Drawing.Size(119, 17);
            this.labelAccountTree.TabIndex = 3;
            this.labelAccountTree.Text = ":الحساب المحاسبي";
            // 
            // labelCurrency
            // 
            this.labelCurrency.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelCurrency.Appearance.Options.UseFont = true;
            this.labelCurrency.Appearance.Options.UseTextOptions = true;
            this.labelCurrency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelCurrency.Location = new System.Drawing.Point(730, 161);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(41, 17);
            this.labelCurrency.TabIndex = 4;
            this.labelCurrency.Text = ":العملة";
            // 
            // labelCurrencyEqualValue
            // 
            this.labelCurrencyEqualValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelCurrencyEqualValue.Appearance.Options.UseFont = true;
            this.labelCurrencyEqualValue.Appearance.Options.UseTextOptions = true;
            this.labelCurrencyEqualValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelCurrencyEqualValue.Location = new System.Drawing.Point(730, 197);
            this.labelCurrencyEqualValue.Name = "labelCurrencyEqualValue";
            this.labelCurrencyEqualValue.Size = new System.Drawing.Size(72, 17);
            this.labelCurrencyEqualValue.TabIndex = 5;
            this.labelCurrencyEqualValue.Text = ":سعر الصرف";
            // 
            // labelDate
            // 
            this.labelDate.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelDate.Appearance.Options.UseFont = true;
            this.labelDate.Appearance.Options.UseTextOptions = true;
            this.labelDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelDate.Location = new System.Drawing.Point(730, 233);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(40, 17);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = ":التاريخ";
            // 
            // labelNotes
            // 
            this.labelNotes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelNotes.Appearance.Options.UseFont = true;
            this.labelNotes.Appearance.Options.UseTextOptions = true;
            this.labelNotes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelNotes.Location = new System.Drawing.Point(730, 273);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(65, 17);
            this.labelNotes.TabIndex = 7;
            this.labelNotes.Text = ":الملاحظات";
            // 
            // labelItems
            // 
            this.labelItems.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelItems.Appearance.Options.UseFont = true;
            this.labelItems.Appearance.Options.UseTextOptions = true;
            this.labelItems.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelItems.Location = new System.Drawing.Point(730, 356);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(72, 17);
            this.labelItems.TabIndex = 8;
            this.labelItems.Text = ":مواد الفاتورة";
            // 
            // spinBillNumber
            // 
            this.spinBillNumber.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinBillNumber.Location = new System.Drawing.Point(420, 51);
            this.spinBillNumber.Name = "spinBillNumber";
            this.spinBillNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinBillNumber.Properties.IsFloatValue = false;
            this.spinBillNumber.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinBillNumber.Properties.NullText = "أدخل رقم الفاتورة";
            this.spinBillNumber.Size = new System.Drawing.Size(290, 20);
            this.spinBillNumber.TabIndex = 9;
            // 
            // cmbBillType
            // 
            this.cmbBillType.Location = new System.Drawing.Point(420, 87);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBillType.Properties.DisplayMember = "Text";
            this.cmbBillType.Properties.NullText = "اختر نوع الفاتورة";
            this.cmbBillType.Properties.PopupView = this.gridViewBillType;
            this.cmbBillType.Properties.ValueMember = "Value";
            this.cmbBillType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBillType.Size = new System.Drawing.Size(290, 20);
            this.cmbBillType.TabIndex = 10;
            // 
            // gridViewBillType
            // 
            this.gridViewBillType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBillType});
            this.gridViewBillType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewBillType.Name = "gridViewBillType";
            this.gridViewBillType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewBillType.OptionsView.ShowGroupPanel = false;
            // 
            // colBillType
            // 
            this.colBillType.Caption = "نوع الفاتورة";
            this.colBillType.FieldName = "Text";
            this.colBillType.Name = "colBillType";
            this.colBillType.Visible = true;
            this.colBillType.VisibleIndex = 0;
            // 
            // cmbAccountTree
            // 
            this.cmbAccountTree.Location = new System.Drawing.Point(420, 123);
            this.cmbAccountTree.Name = "cmbAccountTree";
            this.cmbAccountTree.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountTree.Properties.DisplayMember = "AccountName";
            this.cmbAccountTree.Properties.NullText = "اختر الحساب";
            this.cmbAccountTree.Properties.PopupView = this.gridViewAccountTree;
            this.cmbAccountTree.Properties.ValueMember = "Id";
            this.cmbAccountTree.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccountTree.Size = new System.Drawing.Size(290, 20);
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
            this.cmbCurrency.Location = new System.Drawing.Point(420, 159);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCurrency.Properties.DisplayMember = "CurrencyName";
            this.cmbCurrency.Properties.NullText = "اختر العملة";
            this.cmbCurrency.Properties.PopupView = this.gridViewCurrency;
            this.cmbCurrency.Properties.ValueMember = "Id";
            this.cmbCurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCurrency.Size = new System.Drawing.Size(290, 20);
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
            this.spnCurrencyEqualValue.Location = new System.Drawing.Point(420, 195);
            this.spnCurrencyEqualValue.Name = "spnCurrencyEqualValue";
            this.spnCurrencyEqualValue.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.spnCurrencyEqualValue.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spnCurrencyEqualValue.Size = new System.Drawing.Size(290, 20);
            this.spnCurrencyEqualValue.TabIndex = 13;
            // 
            // deDate
            // 
            this.deDate.EditValue = null;
            this.deDate.Location = new System.Drawing.Point(420, 231);
            this.deDate.Name = "deDate";
            this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate.Size = new System.Drawing.Size(290, 20);
            this.deDate.TabIndex = 14;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(420, 269);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(290, 60);
            this.txtNotes.TabIndex = 15;
            this.txtNotes.Text = "";
            // 
            // gridControlItems
            // 
            this.gridControlItems.Location = new System.Drawing.Point(40, 380);
            this.gridControlItems.MainView = this.gridViewItems;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit,
            this.repositoryItemSpinEditPrice,
            this.repositoryItemSpinEditQty});
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
            this.colPrice,
            this.colTotal});
            this.gridViewItems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewItems.GridControl = this.gridControlItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewItems.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            this.gridViewItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewItems_CellValueChanged);
            this.gridViewItems.RowCountChanged += new System.EventHandler(this.gridViewItems_RowCountChanged);
            // 
            // colItem
            // 
            this.colItem.AppearanceCell.Options.UseTextOptions = true;
            this.colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colItem.Caption = "المنتج";
            this.colItem.ColumnEdit = this.repositoryItemGridLookUpEdit;
            this.colItem.FieldName = "ItemGuid";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            this.colItem.Width = 320;
            // 
            // repositoryItemGridLookUpEdit
            // 
            this.repositoryItemGridLookUpEdit.AutoHeight = false;
            this.repositoryItemGridLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit.DisplayMember = "Name";
            this.repositoryItemGridLookUpEdit.Name = "repositoryItemGridLookUpEdit";
            this.repositoryItemGridLookUpEdit.NullText = "اختر المنتج";
            this.repositoryItemGridLookUpEdit.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit.ValueMember = "Id";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLookupName,
            this.colLookupCategory,
            this.colLookupPrice});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colQty.Caption = "الكمية";
            this.colQty.ColumnEdit = this.repositoryItemSpinEditQty;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            this.colQty.Width = 140;
            // 
            // repositoryItemSpinEditQty
            // 
            this.repositoryItemSpinEditQty.AutoHeight = false;
            this.repositoryItemSpinEditQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditQty.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.repositoryItemSpinEditQty.Name = "repositoryItemSpinEditQty";
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPrice.Caption = "السعر";
            this.colPrice.ColumnEdit = this.repositoryItemSpinEditPrice;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 140;
            // 
            // repositoryItemSpinEditPrice
            // 
            this.repositoryItemSpinEditPrice.AutoHeight = false;
            this.repositoryItemSpinEditPrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditPrice.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.repositoryItemSpinEditPrice.Name = "repositoryItemSpinEditPrice";
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotal.Caption = "الإجمالي";
            this.colTotal.DisplayFormat.FormatString = "N2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.UnboundDataType = typeof(decimal);
            this.colTotal.UnboundExpression = "[Qty] * [Price]";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            this.colTotal.Width = 140;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItem.Appearance.Options.UseFont = true;
            this.btnAddItem.Location = new System.Drawing.Point(610, 352);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(110, 24);
            this.btnAddItem.TabIndex = 17;
            this.btnAddItem.Text = "إضافة مادة";
            this.btnAddItem.ToolTip = "إضافة بند جديد إلى الفاتورة";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDeleteItem.Appearance.Options.UseFont = true;
            this.btnDeleteItem.Location = new System.Drawing.Point(490, 352);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteItem.TabIndex = 18;
            this.btnDeleteItem.Text = "حذف المادة";
            this.btnDeleteItem.ToolTip = "حذف البند المحدد من الفاتورة";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Appearance.Options.UseTextOptions = true;
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotal.Location = new System.Drawing.Point(60, 560);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 18);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "الإجمالي: 0";
            // 
            // saveCancelControl21
            // 
            this.saveCancelControl21.Location = new System.Drawing.Point(375, 577);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.SaveText = "حفظ";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 20;
            // 
            // colLookupName
            // 
            this.colLookupName.AppearanceCell.Options.UseTextOptions = true;
            this.colLookupName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLookupName.Caption = "اسم المنتج";
            this.colLookupName.FieldName = "Name";
            this.colLookupName.Name = "colLookupName";
            this.colLookupName.Visible = true;
            this.colLookupName.VisibleIndex = 0;
            // 
            // colLookupCategory
            // 
            this.colLookupCategory.AppearanceCell.Options.UseTextOptions = true;
            this.colLookupCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLookupCategory.Caption = "الفئة";
            this.colLookupCategory.FieldName = "Category.Name";
            this.colLookupCategory.Name = "colLookupCategory";
            this.colLookupCategory.Visible = true;
            this.colLookupCategory.VisibleIndex = 1;
            // 
            // colLookupPrice
            // 
            this.colLookupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colLookupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLookupPrice.Caption = "السعر";
            this.colLookupPrice.FieldName = "Price";
            this.colLookupPrice.Name = "colLookupPrice";
            this.colLookupPrice.Visible = true;
            this.colLookupPrice.VisibleIndex = 2;
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
            this.Controls.Add(this.spinBillNumber);
            this.Controls.Add(this.cmbBillType);
            this.Controls.Add(this.cmbAccountTree);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.spnCurrencyEqualValue);
            this.Controls.Add(this.deDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.gridControlItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.saveCancelControl21);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDeleteItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillsManageForm";
            this.Text = "الفواتير";
            this.Load += new System.EventHandler(this.BillsManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBillType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountTree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccountTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCurrencyEqualValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditPrice)).EndInit();
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
        private DevExpress.XtraEditors.SpinEdit spinBillNumber;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbBillType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBillType;
        private DevExpress.XtraGrid.Columns.GridColumn colBillType;
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
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItem;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private Controls.SaveCancelControl2 saveCancelControl21;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupName;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colLookupPrice;
    }
}

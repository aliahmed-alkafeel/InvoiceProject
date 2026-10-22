namespace UI.Forms
{
    partial class ItemBillsForm
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
            DevExpress.XtraLayout.LayoutControlItem itemBillNumber;
            DevExpress.XtraLayout.LayoutControlItem itemPrev;
            DevExpress.XtraLayout.LayoutControlItem itemNext;
            DevExpress.XtraLayout.LayoutControlItem itemAddItems;
            DevExpress.XtraLayout.LayoutControlItem itemHint;
            DevExpress.XtraLayout.LayoutControlItem itemType;
            DevExpress.XtraLayout.LayoutControlItem itemDate;
            DevExpress.XtraLayout.LayoutControlItem itemAccount;
            DevExpress.XtraLayout.LayoutControlItem itemCurrency;
            DevExpress.XtraLayout.LayoutControlItem itemEqual;
            DevExpress.XtraLayout.LayoutControlItem itemNotes;
            DevExpress.XtraLayout.LayoutControlItem itemAddItem;
            DevExpress.XtraLayout.LayoutControlItem itemDeleteItem;
            DevExpress.XtraLayout.LayoutControlItem itemSaveItems;
            // NOTE: the (allowUseSplitters, allowUseTabbedGroups) constructor overload is used
            // on purpose. The parameterless constructor defers the creation of the root group
            // when it is called from a designer "InitializeComponent" method, which leaves
            // LayoutControl.Root null and breaks every layout operation done below.
            this.layoutSearch = new DevExpress.XtraLayout.LayoutControl(true, true);
            this.spinBillNumber = new DevExpress.XtraEditors.SpinEdit();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItems = new DevExpress.XtraEditors.SimpleButton();
            this.lblHint = new DevExpress.XtraEditors.LabelControl();
            this.layoutBillInfo = new DevExpress.XtraLayout.LayoutControl(true, true);
            this.lblTypeValue = new DevExpress.XtraEditors.LabelControl();
            this.lblDateValue = new DevExpress.XtraEditors.LabelControl();
            this.lblAccountValue = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrencyValue = new DevExpress.XtraEditors.LabelControl();
            this.lblEqualValue = new DevExpress.XtraEditors.LabelControl();
            this.lblNotesValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.layoutItemsActions = new DevExpress.XtraLayout.LayoutControl(true, true);
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveItems = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutSearch
            // 
            this.layoutSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutSearch.Location = new System.Drawing.Point(0, 0);
            this.layoutSearch.Name = "layoutSearch";
            this.layoutSearch.Size = new System.Drawing.Size(1000, 84);
            this.layoutSearch.TabIndex = 0;
            this.layoutSearch.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutSearch.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutSearch.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutSearch.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 100;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 110;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[2].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[2].Width = 40;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[3].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[3].Width = 40;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[4].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutSearch.Root.OptionsTableLayoutGroup.ColumnDefinitions[4].Width = 380;
            this.layoutSearch.Root.OptionsTableLayoutGroup.RowDefinitions[0].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutSearch.Root.OptionsTableLayoutGroup.RowDefinitions[0].Height = 40;
            this.layoutSearch.Root.OptionsTableLayoutGroup.RowDefinitions[1].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutSearch.Root.OptionsTableLayoutGroup.RowDefinitions[1].Height = 100;
            // 
            // spinBillNumber
            // 
            this.spinBillNumber.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinBillNumber.Name = "spinBillNumber";
            this.spinBillNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinBillNumber.Properties.IsFloatValue = false;
            this.spinBillNumber.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinBillNumber.Properties.NullText = "أدخل رقم الفاتورة";
            this.spinBillNumber.Size = new System.Drawing.Size(300, 20);
            this.spinBillNumber.TabIndex = 0;
            this.spinBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spinBillNumber_KeyDown);
            // 
            // btnPrev
            // 
            this.btnPrev.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 24);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "►";
            this.btnPrev.ToolTip = "الفاتورة السابقة";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "◄";
            this.btnNext.ToolTip = "الفاتورة التالية";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItems.Appearance.Options.UseFont = true;
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(110, 24);
            this.btnAddItems.TabIndex = 3;
            this.btnAddItems.Text = "إضافة مواد";
            this.btnAddItems.ToolTip = "إضافة مواد إلى الفاتورة الحالية";
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // lblHint
            // 
            this.lblHint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHint.Appearance.Options.UseFont = true;
            this.lblHint.Appearance.Options.UseTextOptions = true;
            this.lblHint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(599, 14);
            this.lblHint.TabIndex = 4;
            this.lblHint.Text = "أدخل رقم الفاتورة ثم اضغط Enter لعرضها، واستخدم الأسهم للتنقل بين الفواتير، و«إضا" +
    "فة مواد» لإضافة بنود للفاتورة الحالية";
            // 
            // layoutSearch items
            // 
            itemBillNumber = this.layoutSearch.AddItem(":رقم الفاتورة", this.spinBillNumber);
            itemBillNumber.TextVisible = true;
            itemBillNumber.TextLocation = DevExpress.Utils.Locations.Right;
            itemBillNumber.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemBillNumber.AppearanceItemCaption.Options.UseFont = true;
            itemBillNumber.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemBillNumber.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemBillNumber.OptionsTableLayoutItem.ColumnIndex = 4;
            itemBillNumber.OptionsTableLayoutItem.RowIndex = 0;
            itemPrev = this.layoutSearch.AddItem("", this.btnPrev);
            itemPrev.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemPrev.OptionsTableLayoutItem.ColumnIndex = 3;
            itemPrev.OptionsTableLayoutItem.RowIndex = 0;
            itemNext = this.layoutSearch.AddItem("", this.btnNext);
            itemNext.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemNext.OptionsTableLayoutItem.ColumnIndex = 2;
            itemNext.OptionsTableLayoutItem.RowIndex = 0;
            itemAddItems = this.layoutSearch.AddItem("", this.btnAddItems);
            itemAddItems.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemAddItems.OptionsTableLayoutItem.ColumnIndex = 1;
            itemAddItems.OptionsTableLayoutItem.RowIndex = 0;
            itemHint = this.layoutSearch.AddItem("", this.lblHint);
            itemHint.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemHint.OptionsTableLayoutItem.ColumnIndex = 0;
            itemHint.OptionsTableLayoutItem.RowIndex = 1;
            itemHint.OptionsTableLayoutItem.ColumnSpan = 5;
            // 
            // layoutBillInfo
            // 
            this.layoutBillInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutBillInfo.Location = new System.Drawing.Point(0, 84);
            this.layoutBillInfo.Name = "layoutBillInfo";
            this.layoutBillInfo.Size = new System.Drawing.Size(1000, 110);
            this.layoutBillInfo.TabIndex = 1;
            this.layoutBillInfo.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 100;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions.Add(new DevExpress.XtraLayout.RowDefinition(this.layoutBillInfo.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[0].Height = 100;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[1].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[1].Height = 100;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[2].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutBillInfo.Root.OptionsTableLayoutGroup.RowDefinitions[2].Height = 100;
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTypeValue.Appearance.Options.UseFont = true;
            this.lblTypeValue.Appearance.Options.UseTextOptions = true;
            this.lblTypeValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(0, 16);
            this.lblTypeValue.TabIndex = 0;
            // 
            // lblDateValue
            // 
            this.lblDateValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDateValue.Appearance.Options.UseFont = true;
            this.lblDateValue.Appearance.Options.UseTextOptions = true;
            this.lblDateValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(0, 16);
            this.lblDateValue.TabIndex = 1;
            // 
            // lblAccountValue
            // 
            this.lblAccountValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAccountValue.Appearance.Options.UseFont = true;
            this.lblAccountValue.Appearance.Options.UseTextOptions = true;
            this.lblAccountValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAccountValue.Name = "lblAccountValue";
            this.lblAccountValue.Size = new System.Drawing.Size(0, 16);
            this.lblAccountValue.TabIndex = 2;
            // 
            // lblCurrencyValue
            // 
            this.lblCurrencyValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCurrencyValue.Appearance.Options.UseFont = true;
            this.lblCurrencyValue.Appearance.Options.UseTextOptions = true;
            this.lblCurrencyValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrencyValue.Name = "lblCurrencyValue";
            this.lblCurrencyValue.Size = new System.Drawing.Size(0, 16);
            this.lblCurrencyValue.TabIndex = 3;
            // 
            // lblEqualValue
            // 
            this.lblEqualValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblEqualValue.Appearance.Options.UseFont = true;
            this.lblEqualValue.Appearance.Options.UseTextOptions = true;
            this.lblEqualValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblEqualValue.Name = "lblEqualValue";
            this.lblEqualValue.Size = new System.Drawing.Size(0, 16);
            this.lblEqualValue.TabIndex = 4;
            // 
            // lblNotesValue
            // 
            this.lblNotesValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNotesValue.Appearance.Options.UseFont = true;
            this.lblNotesValue.Appearance.Options.UseTextOptions = true;
            this.lblNotesValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblNotesValue.Name = "lblNotesValue";
            this.lblNotesValue.Size = new System.Drawing.Size(0, 16);
            this.lblNotesValue.TabIndex = 5;
            // 
            // layoutBillInfo items
            // 
            itemType = this.layoutBillInfo.AddItem(":نوع الفاتورة", this.lblTypeValue);
            itemType.TextVisible = true;
            itemType.TextLocation = DevExpress.Utils.Locations.Right;
            itemType.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemType.AppearanceItemCaption.Options.UseFont = true;
            itemType.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemType.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemType.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemType.OptionsTableLayoutItem.ColumnIndex = 1;
            itemType.OptionsTableLayoutItem.RowIndex = 0;
            itemAccount = this.layoutBillInfo.AddItem(":الحساب المحاسبي", this.lblAccountValue);
            itemAccount.TextVisible = true;
            itemAccount.TextLocation = DevExpress.Utils.Locations.Right;
            itemAccount.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemAccount.AppearanceItemCaption.Options.UseFont = true;
            itemAccount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemAccount.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemAccount.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemAccount.OptionsTableLayoutItem.ColumnIndex = 1;
            itemAccount.OptionsTableLayoutItem.RowIndex = 1;
            itemEqual = this.layoutBillInfo.AddItem(":سعر الصرف", this.lblEqualValue);
            itemEqual.TextVisible = true;
            itemEqual.TextLocation = DevExpress.Utils.Locations.Right;
            itemEqual.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemEqual.AppearanceItemCaption.Options.UseFont = true;
            itemEqual.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemEqual.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemEqual.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemEqual.OptionsTableLayoutItem.ColumnIndex = 1;
            itemEqual.OptionsTableLayoutItem.RowIndex = 2;
            itemDate = this.layoutBillInfo.AddItem(":التاريخ", this.lblDateValue);
            itemDate.TextVisible = true;
            itemDate.TextLocation = DevExpress.Utils.Locations.Right;
            itemDate.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemDate.AppearanceItemCaption.Options.UseFont = true;
            itemDate.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemDate.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemDate.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemDate.OptionsTableLayoutItem.ColumnIndex = 0;
            itemDate.OptionsTableLayoutItem.RowIndex = 0;
            itemCurrency = this.layoutBillInfo.AddItem(":العملة", this.lblCurrencyValue);
            itemCurrency.TextVisible = true;
            itemCurrency.TextLocation = DevExpress.Utils.Locations.Right;
            itemCurrency.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemCurrency.AppearanceItemCaption.Options.UseFont = true;
            itemCurrency.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemCurrency.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemCurrency.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemCurrency.OptionsTableLayoutItem.ColumnIndex = 0;
            itemCurrency.OptionsTableLayoutItem.RowIndex = 1;
            itemNotes = this.layoutBillInfo.AddItem(":الملاحظات", this.lblNotesValue);
            itemNotes.TextVisible = true;
            itemNotes.TextLocation = DevExpress.Utils.Locations.Right;
            itemNotes.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            itemNotes.AppearanceItemCaption.Options.UseFont = true;
            itemNotes.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            itemNotes.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            itemNotes.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemNotes.OptionsTableLayoutItem.ColumnIndex = 0;
            itemNotes.OptionsTableLayoutItem.RowIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Appearance.Options.UseTextOptions = true;
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Location = new System.Drawing.Point(0, 582);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(126, 18);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "إجمالي الفاتورة: 0";
            // 
            // layoutItemsActions
            // 
            this.layoutItemsActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutItemsActions.Location = new System.Drawing.Point(0, 546);
            this.layoutItemsActions.Name = "layoutItemsActions";
            this.layoutItemsActions.Size = new System.Drawing.Size(1000, 36);
            this.layoutItemsActions.TabIndex = 3;
            this.layoutItemsActions.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutItemsActions.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutItemsActions.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutItemsActions.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new DevExpress.XtraLayout.ColumnDefinition(this.layoutItemsActions.Root, 100, System.Windows.Forms.SizeType.Percent));
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 100;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 130;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[2].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[2].Width = 110;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[3].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[3].Width = 110;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[4].SizeType = System.Windows.Forms.SizeType.Absolute;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.ColumnDefinitions[4].Width = 20;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.RowDefinitions.RemoveAt(1, false);
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.RowDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutItemsActions.Root.OptionsTableLayoutGroup.RowDefinitions[0].Height = 100;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItem.Appearance.Options.UseFont = true;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(110, 26);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "إضافة مادة";
            this.btnAddItem.ToolTip = "إضافة بند جديد إلى الفاتورة الحالية";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDeleteItem.Appearance.Options.UseFont = true;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(110, 26);
            this.btnDeleteItem.TabIndex = 1;
            this.btnDeleteItem.Text = "حذف المادة";
            this.btnDeleteItem.ToolTip = "حذف البند المحدد من الفاتورة الحالية";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnSaveItems
            // 
            this.btnSaveItems.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSaveItems.Appearance.Options.UseFont = true;
            this.btnSaveItems.Name = "btnSaveItems";
            this.btnSaveItems.Size = new System.Drawing.Size(130, 26);
            this.btnSaveItems.TabIndex = 2;
            this.btnSaveItems.Text = "حفظ التعديلات";
            this.btnSaveItems.ToolTip = "حفظ تعديلات بنود الفاتورة الحالية";
            this.btnSaveItems.Click += new System.EventHandler(this.btnSaveItems_Click);
            // 
            // layoutItemsActions items
            // 
            itemAddItem = this.layoutItemsActions.AddItem("", this.btnAddItem);
            itemAddItem.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemAddItem.OptionsTableLayoutItem.ColumnIndex = 3;
            itemAddItem.OptionsTableLayoutItem.RowIndex = 0;
            itemDeleteItem = this.layoutItemsActions.AddItem("", this.btnDeleteItem);
            itemDeleteItem.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemDeleteItem.OptionsTableLayoutItem.ColumnIndex = 2;
            itemDeleteItem.OptionsTableLayoutItem.RowIndex = 0;
            itemSaveItems = this.layoutItemsActions.AddItem("", this.btnSaveItems);
            itemSaveItems.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            itemSaveItems.OptionsTableLayoutItem.ColumnIndex = 1;
            itemSaveItems.OptionsTableLayoutItem.RowIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 194);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1000, 352);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem,
            this.colQty,
            this.colPrice,
            this.colTotal});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
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
            // colTotal
            // 
            this.colTotal.Caption = "الإجمالي";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            this.colTotal.Width = 160;
            // 
            // ItemBillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutItemsActions);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.layoutBillInfo);
            this.Controls.Add(this.layoutSearch);
            this.Name = "ItemBillsForm";
            this.Text = "تفاصيل الفاتورة";
            this.Load += new System.EventHandler(this.ItemBillsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutSearch;
        private DevExpress.XtraEditors.SpinEdit spinBillNumber;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnAddItems;
        private DevExpress.XtraEditors.LabelControl lblHint;
        private DevExpress.XtraLayout.LayoutControl layoutBillInfo;
        private DevExpress.XtraEditors.LabelControl lblTypeValue;
        private DevExpress.XtraEditors.LabelControl lblDateValue;
        private DevExpress.XtraEditors.LabelControl lblAccountValue;
        private DevExpress.XtraEditors.LabelControl lblCurrencyValue;
        private DevExpress.XtraEditors.LabelControl lblEqualValue;
        private DevExpress.XtraEditors.LabelControl lblNotesValue;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraLayout.LayoutControl layoutItemsActions;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItem;
        private DevExpress.XtraEditors.SimpleButton btnSaveItems;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
    }
}

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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.labelBillNumber = new DevExpress.XtraEditors.LabelControl();
            this.spinBillNumber = new DevExpress.XtraEditors.SpinEdit();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItems = new DevExpress.XtraEditors.SimpleButton();
            this.lblHint = new DevExpress.XtraEditors.LabelControl();
            this.panelBillInfo = new System.Windows.Forms.Panel();
            this.labelTypeCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblTypeValue = new DevExpress.XtraEditors.LabelControl();
            this.labelDateCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblDateValue = new DevExpress.XtraEditors.LabelControl();
            this.labelAccountCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblAccountValue = new DevExpress.XtraEditors.LabelControl();
            this.labelCurrencyCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrencyValue = new DevExpress.XtraEditors.LabelControl();
            this.labelEqualCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblEqualValue = new DevExpress.XtraEditors.LabelControl();
            this.labelNotesCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblNotesValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.panelItemsActions = new System.Windows.Forms.Panel();
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
            // panelSearch
            //
            this.panelSearch.Controls.Add(this.labelBillNumber);
            this.panelSearch.Controls.Add(this.spinBillNumber);
            this.panelSearch.Controls.Add(this.btnPrev);
            this.panelSearch.Controls.Add(this.btnNext);
            this.panelSearch.Controls.Add(this.btnAddItems);
            this.panelSearch.Controls.Add(this.lblHint);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1000, 84);
            this.panelSearch.TabIndex = 0;
            //
            // labelBillNumber
            //
            this.labelBillNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelBillNumber.Appearance.Options.UseFont = true;
            this.labelBillNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelBillNumber.AutoSize = false;
            this.labelBillNumber.Location = new System.Drawing.Point(860, 22);
            this.labelBillNumber.Name = "labelBillNumber";
            this.labelBillNumber.Size = new System.Drawing.Size(120, 20);
            this.labelBillNumber.TabIndex = 0;
            this.labelBillNumber.Text = ":رقم الفاتورة";
            //
            // spinBillNumber
            //
            this.spinBillNumber.Location = new System.Drawing.Point(540, 20);
            this.spinBillNumber.Name = "spinBillNumber";
            this.spinBillNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinBillNumber.Properties.IsFloatValue = false;
            this.spinBillNumber.Properties.MaxValue = 2147483647m;
            this.spinBillNumber.Properties.MinValue = 0m;
            this.spinBillNumber.Properties.NullText = "أدخل رقم الفاتورة";
            this.spinBillNumber.Size = new System.Drawing.Size(300, 22);
            this.spinBillNumber.TabIndex = 1;
            this.spinBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spinBillNumber_KeyDown);
            //
            // btnPrev
            //
            this.btnPrev.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Location = new System.Drawing.Point(440, 19);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 24);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "►";
            this.btnPrev.ToolTip = "الفاتورة السابقة";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            //
            // btnNext
            //
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(395, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "◄";
            this.btnNext.ToolTip = "الفاتورة التالية";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnAddItems
            //
            this.btnAddItems.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItems.Appearance.Options.UseFont = true;
            this.btnAddItems.Location = new System.Drawing.Point(275, 19);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(110, 24);
            this.btnAddItems.TabIndex = 4;
            this.btnAddItems.Text = "إضافة مواد";
            this.btnAddItems.ToolTip = "إضافة مواد إلى الفاتورة الحالية";
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            //
            // lblHint
            //
            this.lblHint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHint.Appearance.Options.UseFont = true;
            this.lblHint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblHint.AutoSize = false;
            this.lblHint.Location = new System.Drawing.Point(20, 56);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(960, 20);
            this.lblHint.TabIndex = 5;
            this.lblHint.Text = "أدخل رقم الفاتورة ثم اضغط Enter لعرضها، واستخدم الأسهم للتنقل بين الفواتير، و«إضافة مواد» لإضافة بنود للفاتورة الحالية";
            //
            // panelBillInfo
            //
            this.panelBillInfo.Controls.Add(this.labelTypeCaption);
            this.panelBillInfo.Controls.Add(this.lblTypeValue);
            this.panelBillInfo.Controls.Add(this.labelDateCaption);
            this.panelBillInfo.Controls.Add(this.lblDateValue);
            this.panelBillInfo.Controls.Add(this.labelAccountCaption);
            this.panelBillInfo.Controls.Add(this.lblAccountValue);
            this.panelBillInfo.Controls.Add(this.labelCurrencyCaption);
            this.panelBillInfo.Controls.Add(this.lblCurrencyValue);
            this.panelBillInfo.Controls.Add(this.labelEqualCaption);
            this.panelBillInfo.Controls.Add(this.lblEqualValue);
            this.panelBillInfo.Controls.Add(this.labelNotesCaption);
            this.panelBillInfo.Controls.Add(this.lblNotesValue);
            this.panelBillInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBillInfo.Location = new System.Drawing.Point(0, 84);
            this.panelBillInfo.Name = "panelBillInfo";
            this.panelBillInfo.Size = new System.Drawing.Size(1000, 110);
            this.panelBillInfo.TabIndex = 1;
            //
            // labelTypeCaption
            //
            this.labelTypeCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelTypeCaption.Appearance.Options.UseFont = true;
            this.labelTypeCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelTypeCaption.AutoSize = false;
            this.labelTypeCaption.Location = new System.Drawing.Point(860, 12);
            this.labelTypeCaption.Name = "labelTypeCaption";
            this.labelTypeCaption.Size = new System.Drawing.Size(120, 20);
            this.labelTypeCaption.TabIndex = 0;
            this.labelTypeCaption.Text = ":نوع الفاتورة";
            //
            // lblTypeValue
            //
            this.lblTypeValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTypeValue.Appearance.Options.UseFont = true;
            this.lblTypeValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTypeValue.AutoSize = false;
            this.lblTypeValue.Location = new System.Drawing.Point(640, 12);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(200, 20);
            this.lblTypeValue.TabIndex = 1;
            this.lblTypeValue.Text = "";
            //
            // labelDateCaption
            //
            this.labelDateCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelDateCaption.Appearance.Options.UseFont = true;
            this.labelDateCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelDateCaption.AutoSize = false;
            this.labelDateCaption.Location = new System.Drawing.Point(470, 12);
            this.labelDateCaption.Name = "labelDateCaption";
            this.labelDateCaption.Size = new System.Drawing.Size(120, 20);
            this.labelDateCaption.TabIndex = 2;
            this.labelDateCaption.Text = ":التاريخ";
            //
            // lblDateValue
            //
            this.lblDateValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDateValue.Appearance.Options.UseFont = true;
            this.lblDateValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateValue.AutoSize = false;
            this.lblDateValue.Location = new System.Drawing.Point(260, 12);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(190, 20);
            this.lblDateValue.TabIndex = 3;
            this.lblDateValue.Text = "";
            //
            // labelAccountCaption
            //
            this.labelAccountCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelAccountCaption.Appearance.Options.UseFont = true;
            this.labelAccountCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelAccountCaption.AutoSize = false;
            this.labelAccountCaption.Location = new System.Drawing.Point(860, 42);
            this.labelAccountCaption.Name = "labelAccountCaption";
            this.labelAccountCaption.Size = new System.Drawing.Size(120, 20);
            this.labelAccountCaption.TabIndex = 4;
            this.labelAccountCaption.Text = ":الحساب المحاسبي";
            //
            // lblAccountValue
            //
            this.lblAccountValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAccountValue.Appearance.Options.UseFont = true;
            this.lblAccountValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAccountValue.AutoSize = false;
            this.lblAccountValue.Location = new System.Drawing.Point(580, 42);
            this.lblAccountValue.Name = "lblAccountValue";
            this.lblAccountValue.Size = new System.Drawing.Size(260, 20);
            this.lblAccountValue.TabIndex = 5;
            this.lblAccountValue.Text = "";
            //
            // labelCurrencyCaption
            //
            this.labelCurrencyCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelCurrencyCaption.Appearance.Options.UseFont = true;
            this.labelCurrencyCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelCurrencyCaption.AutoSize = false;
            this.labelCurrencyCaption.Location = new System.Drawing.Point(400, 42);
            this.labelCurrencyCaption.Name = "labelCurrencyCaption";
            this.labelCurrencyCaption.Size = new System.Drawing.Size(120, 20);
            this.labelCurrencyCaption.TabIndex = 6;
            this.labelCurrencyCaption.Text = ":العملة";
            //
            // lblCurrencyValue
            //
            this.lblCurrencyValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCurrencyValue.Appearance.Options.UseFont = true;
            this.lblCurrencyValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrencyValue.AutoSize = false;
            this.lblCurrencyValue.Location = new System.Drawing.Point(250, 42);
            this.lblCurrencyValue.Name = "lblCurrencyValue";
            this.lblCurrencyValue.Size = new System.Drawing.Size(130, 20);
            this.lblCurrencyValue.TabIndex = 7;
            this.lblCurrencyValue.Text = "";
            //
            // labelEqualCaption
            //
            this.labelEqualCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelEqualCaption.Appearance.Options.UseFont = true;
            this.labelEqualCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelEqualCaption.AutoSize = false;
            this.labelEqualCaption.Location = new System.Drawing.Point(860, 72);
            this.labelEqualCaption.Name = "labelEqualCaption";
            this.labelEqualCaption.Size = new System.Drawing.Size(120, 20);
            this.labelEqualCaption.TabIndex = 8;
            this.labelEqualCaption.Text = ":سعر الصرف";
            //
            // lblEqualValue
            //
            this.lblEqualValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblEqualValue.Appearance.Options.UseFont = true;
            this.lblEqualValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblEqualValue.AutoSize = false;
            this.lblEqualValue.Location = new System.Drawing.Point(640, 72);
            this.lblEqualValue.Name = "lblEqualValue";
            this.lblEqualValue.Size = new System.Drawing.Size(200, 20);
            this.lblEqualValue.TabIndex = 9;
            this.lblEqualValue.Text = "";
            //
            // labelNotesCaption
            //
            this.labelNotesCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelNotesCaption.Appearance.Options.UseFont = true;
            this.labelNotesCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelNotesCaption.AutoSize = false;
            this.labelNotesCaption.Location = new System.Drawing.Point(470, 72);
            this.labelNotesCaption.Name = "labelNotesCaption";
            this.labelNotesCaption.Size = new System.Drawing.Size(120, 20);
            this.labelNotesCaption.TabIndex = 10;
            this.labelNotesCaption.Text = ":الملاحظات";
            //
            // lblNotesValue
            //
            this.lblNotesValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNotesValue.Appearance.Options.UseFont = true;
            this.lblNotesValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblNotesValue.AutoSize = false;
            this.lblNotesValue.Location = new System.Drawing.Point(40, 72);
            this.lblNotesValue.Name = "lblNotesValue";
            this.lblNotesValue.Size = new System.Drawing.Size(410, 20);
            this.lblNotesValue.TabIndex = 11;
            this.lblNotesValue.Text = "";
            //
            // lblTotal
            //
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotal.AutoSize = false;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Location = new System.Drawing.Point(0, 568);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(1000, 32);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "إجمالي الفاتورة: 0";
            //
            // panelItemsActions
            //
            this.panelItemsActions.Controls.Add(this.btnAddItem);
            this.panelItemsActions.Controls.Add(this.btnDeleteItem);
            this.panelItemsActions.Controls.Add(this.btnSaveItems);
            this.panelItemsActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelItemsActions.Location = new System.Drawing.Point(0, 532);
            this.panelItemsActions.Name = "panelItemsActions";
            this.panelItemsActions.Size = new System.Drawing.Size(1000, 36);
            this.panelItemsActions.TabIndex = 3;
            //
            // btnAddItem
            //
            this.btnAddItem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItem.Appearance.Options.UseFont = true;
            this.btnAddItem.Location = new System.Drawing.Point(870, 5);
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
            this.btnDeleteItem.Location = new System.Drawing.Point(750, 5);
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
            this.btnSaveItems.Location = new System.Drawing.Point(610, 5);
            this.btnSaveItems.Name = "btnSaveItems";
            this.btnSaveItems.Size = new System.Drawing.Size(130, 26);
            this.btnSaveItems.TabIndex = 2;
            this.btnSaveItems.Text = "حفظ التعديلات";
            this.btnSaveItems.ToolTip = "حفظ تعديلات بنود الفاتورة الحالية";
            this.btnSaveItems.Click += new System.EventHandler(this.btnSaveItems_Click);
            //
            // gridControl1
            //
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 194);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1000, 374);
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
            this.gridView1.OptionsBehavior.Editable = true;
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
            this.Controls.Add(this.panelItemsActions);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelBillInfo);
            this.Controls.Add(this.panelSearch);
            this.Name = "ItemBillsForm";
            this.Text = "تفاصيل الفاتورة";
            this.Load += new System.EventHandler(this.ItemBillsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private DevExpress.XtraEditors.LabelControl labelBillNumber;
        private DevExpress.XtraEditors.SpinEdit spinBillNumber;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnAddItems;
        private DevExpress.XtraEditors.LabelControl lblHint;
        private System.Windows.Forms.Panel panelBillInfo;
        private DevExpress.XtraEditors.LabelControl labelTypeCaption;
        private DevExpress.XtraEditors.LabelControl lblTypeValue;
        private DevExpress.XtraEditors.LabelControl labelDateCaption;
        private DevExpress.XtraEditors.LabelControl lblDateValue;
        private DevExpress.XtraEditors.LabelControl labelAccountCaption;
        private DevExpress.XtraEditors.LabelControl lblAccountValue;
        private DevExpress.XtraEditors.LabelControl labelCurrencyCaption;
        private DevExpress.XtraEditors.LabelControl lblCurrencyValue;
        private DevExpress.XtraEditors.LabelControl labelEqualCaption;
        private DevExpress.XtraEditors.LabelControl lblEqualValue;
        private DevExpress.XtraEditors.LabelControl labelNotesCaption;
        private DevExpress.XtraEditors.LabelControl lblNotesValue;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private System.Windows.Forms.Panel panelItemsActions;
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

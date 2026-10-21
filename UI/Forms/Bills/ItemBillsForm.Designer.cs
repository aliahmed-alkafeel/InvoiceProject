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
            this.txtBillNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            //
            // panelSearch
            //
            this.panelSearch.Controls.Add(this.labelBillNumber);
            this.panelSearch.Controls.Add(this.txtBillNumber);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.lblHint);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1000, 60);
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
            // txtBillNumber
            //
            this.txtBillNumber.Location = new System.Drawing.Point(540, 20);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Properties.NullText = "أدخل رقم الفاتورة";
            this.txtBillNumber.Size = new System.Drawing.Size(300, 22);
            this.txtBillNumber.TabIndex = 1;
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(440, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "عرض";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // lblHint
            //
            this.lblHint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHint.Appearance.Options.UseFont = true;
            this.lblHint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblHint.AutoSize = false;
            this.lblHint.Location = new System.Drawing.Point(20, 24);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(400, 20);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "أدخل رقم الفاتورة ثم اضغط Enter لعرض الفاتورة وموادها";
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
            this.panelBillInfo.Location = new System.Drawing.Point(0, 60);
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
            // gridControl1
            //
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 170);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1000, 398);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // gridView1
            //
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colQty,
            this.colPrice,
            this.colTotal});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            //
            // colItemName
            //
            this.colItemName.Caption = "المادة";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 320;
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
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panelBillInfo);
            this.Controls.Add(this.panelSearch);
            this.Name = "ItemBillsForm";
            this.Text = "تفاصيل الفاتورة";
            this.Load += new System.EventHandler(this.ItemBillsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private DevExpress.XtraEditors.LabelControl labelBillNumber;
        private DevExpress.XtraEditors.TextEdit txtBillNumber;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
    }
}

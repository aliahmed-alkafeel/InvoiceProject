namespace UI.Forms
{
    partial class BillsForm
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
            this.colBillNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountTree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyEqualValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnShowBillItems = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(1000, 55);
            this.toolBarControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 55);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1000, 485);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBillNumber,
            this.colBillType,
            this.colAccountTree,
            this.colCurrency,
            this.colCurrencyEqualValue,
            this.colDate,
            this.colNotes});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colBillNumber
            // 
            this.colBillNumber.Caption = "رقم الفاتورة";
            this.colBillNumber.FieldName = "BillNumber";
            this.colBillNumber.Name = "colBillNumber";
            this.colBillNumber.Visible = true;
            this.colBillNumber.VisibleIndex = 0;
            this.colBillNumber.Width = 140;
            // 
            // colBillType
            // 
            this.colBillType.Caption = "نوع الفاتورة";
            this.colBillType.FieldName = "BillType";
            this.colBillType.Name = "colBillType";
            this.colBillType.Visible = true;
            this.colBillType.VisibleIndex = 1;
            this.colBillType.Width = 100;
            // 
            // colAccountTree
            // 
            this.colAccountTree.Caption = "الحساب المحاسبي";
            this.colAccountTree.FieldName = "AccountTree.AccountName";
            this.colAccountTree.Name = "colAccountTree";
            this.colAccountTree.Visible = true;
            this.colAccountTree.VisibleIndex = 2;
            this.colAccountTree.Width = 220;
            // 
            // colCurrency
            // 
            this.colCurrency.Caption = "العملة";
            this.colCurrency.FieldName = "Currency.CurrencyName";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Visible = true;
            this.colCurrency.VisibleIndex = 3;
            this.colCurrency.Width = 110;
            // 
            // colCurrencyEqualValue
            // 
            this.colCurrencyEqualValue.Caption = "سعر الصرف";
            this.colCurrencyEqualValue.FieldName = "CurrencyEqualValue";
            this.colCurrencyEqualValue.Name = "colCurrencyEqualValue";
            this.colCurrencyEqualValue.Visible = true;
            this.colCurrencyEqualValue.VisibleIndex = 4;
            this.colCurrencyEqualValue.Width = 110;
            // 
            // colDate
            // 
            this.colDate.Caption = "التاريخ";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 5;
            this.colDate.Width = 120;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "الملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 6;
            this.colNotes.Width = 200;
            // 
            // btnShowBillItems
            // 
            this.btnShowBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowBillItems.Location = new System.Drawing.Point(466, 10);
            this.btnShowBillItems.Name = "btnShowBillItems";
            this.btnShowBillItems.Size = new System.Drawing.Size(160, 33);
            this.btnShowBillItems.TabIndex = 5;
            this.btnShowBillItems.Text = "عرض مواد الفاتورة";
            this.btnShowBillItems.Click += new System.EventHandler(this.btnShowItems_Click);
            // 
            // BillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.btnShowBillItems);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "BillsForm";
            this.Text = "الفواتير";
            this.Load += new System.EventHandler(this.BillsForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ToolBarControl toolBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colBillNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colBillType;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountTree;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyEqualValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraEditors.SimpleButton btnShowBillItems;
    }
}

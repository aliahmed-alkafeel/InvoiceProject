namespace UI.Forms.Vouchers
{
    partial class VouchersForm
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
            this.components = new System.ComponentModel.Container();
            this.toolBarControl1 = new UI.Controls.ToolBarControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccountTree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyEqualValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vouchersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceDbDataSet2 = new UI.InvoiceDbDataSet2();
            this.vouchersTableAdapter = new UI.InvoiceDbDataSet2TableAdapters.VouchersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vouchersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDbDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(998, 50);
            this.toolBarControl1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(998, 339);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccountTree,
            this.colVoucherNumber,
            this.colVoucherType,
            this.colAmount,
            this.colCurrencyEqualValue,
            this.colDate,
            this.colNotes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colAccountTree
            // 
            this.colAccountTree.Caption = "الحساب المحاسبي";
            this.colAccountTree.FieldName = "AccountTree.AccountName";
            this.colAccountTree.Name = "colAccountTree";
            this.colAccountTree.Visible = true;
            this.colAccountTree.VisibleIndex = 2;
            this.colAccountTree.Width = 139;
            // 
            // colVoucherNumber
            // 
            this.colVoucherNumber.Caption = "رقم السند";
            this.colVoucherNumber.FieldName = "VoucherNumber";
            this.colVoucherNumber.Name = "colVoucherNumber";
            this.colVoucherNumber.Visible = true;
            this.colVoucherNumber.VisibleIndex = 0;
            this.colVoucherNumber.Width = 98;
            // 
            // colVoucherType
            // 
            this.colVoucherType.Caption = "نوع السند";
            this.colVoucherType.FieldName = "VoucherType";
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.Visible = true;
            this.colVoucherType.VisibleIndex = 1;
            this.colVoucherType.Width = 103;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "المبلغ";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            this.colAmount.Width = 74;
            // 
            // colCurrencyEqualValue
            // 
            this.colCurrencyEqualValue.Caption = "القيمة بالعملة الرئيسية";
            this.colCurrencyEqualValue.FieldName = "CurrencyEqualValue";
            this.colCurrencyEqualValue.Name = "colCurrencyEqualValue";
            this.colCurrencyEqualValue.Visible = true;
            this.colCurrencyEqualValue.VisibleIndex = 4;
            this.colCurrencyEqualValue.Width = 183;
            // 
            // colDate
            // 
            this.colDate.Caption = "تاريخ السند";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 5;
            this.colDate.Width = 105;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "الملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 6;
            this.colNotes.Width = 271;
            // 
            // vouchersBindingSource
            // 
            this.vouchersBindingSource.DataMember = "Vouchers";
            this.vouchersBindingSource.DataSource = this.invoiceDbDataSet2;
            // 
            // invoiceDbDataSet2
            // 
            this.invoiceDbDataSet2.DataSetName = "InvoiceDbDataSet2";
            this.invoiceDbDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vouchersTableAdapter
            // 
            this.vouchersTableAdapter.ClearBeforeFill = true;
            // 
            // VouchersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 389);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "VouchersForm";
            this.Text = "السندات";
            this.Load += new System.EventHandler(this.VouchersForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vouchersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDbDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ToolBarControl toolBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private InvoiceDbDataSet2 invoiceDbDataSet2;
        private System.Windows.Forms.BindingSource vouchersBindingSource;
        private InvoiceDbDataSet2TableAdapters.VouchersTableAdapter vouchersTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountTree;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherType;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyEqualValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
    }
}
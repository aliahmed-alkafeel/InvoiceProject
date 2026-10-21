namespace UI.Forms
{
    partial class CurrenciesForm
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
            this.colCurrencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencySymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyEqual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
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
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrencyName,
            this.colCurrencySymbol,
            this.colCurrencyEqual,
            this.colIsMain,
            this.colIsActive,
            this.colNotes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCurrencyName
            // 
            this.colCurrencyName.Caption = "اسم العملة";
            this.colCurrencyName.FieldName = "CurrencyName";
            this.colCurrencyName.Name = "colCurrencyName";
            this.colCurrencyName.Visible = true;
            this.colCurrencyName.VisibleIndex = 0;
            this.colCurrencyName.Width = 200;
            // 
            // colCurrencySymbol
            // 
            this.colCurrencySymbol.Caption = "الرمز";
            this.colCurrencySymbol.FieldName = "CurrencySymbol";
            this.colCurrencySymbol.Name = "colCurrencySymbol";
            this.colCurrencySymbol.Visible = true;
            this.colCurrencySymbol.VisibleIndex = 1;
            this.colCurrencySymbol.Width = 120;
            // 
            // colCurrencyEqual
            // 
            this.colCurrencyEqual.Caption = "سعر الصرف";
            this.colCurrencyEqual.FieldName = "CurrencyEqual";
            this.colCurrencyEqual.Name = "colCurrencyEqual";
            this.colCurrencyEqual.Visible = true;
            this.colCurrencyEqual.VisibleIndex = 2;
            this.colCurrencyEqual.Width = 130;
            // 
            // colIsMain
            // 
            this.colIsMain.Caption = "العملة الرئيسية";
            this.colIsMain.FieldName = "IsMain";
            this.colIsMain.Name = "colIsMain";
            this.colIsMain.Visible = true;
            this.colIsMain.VisibleIndex = 3;
            this.colIsMain.Width = 120;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "فعالة";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 4;
            this.colIsActive.Width = 90;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "الملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 5;
            this.colNotes.Width = 300;
            // 
            // CurrenciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 467);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "CurrenciesForm";
            this.Text = "العملة";
            this.Load += new System.EventHandler(this.CurrenciesForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ToolBarControl toolBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencySymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyEqual;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMain;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
    }
}

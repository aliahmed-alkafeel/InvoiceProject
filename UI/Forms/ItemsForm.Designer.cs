using System;

namespace UI.Forms
{
    partial class ItemsForm
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
            this.topBarControl1 = new UI.Base.TopBar.TopBarControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceDbDataSet2 = new UI.InvoiceDbDataSet2();
            this.itemsTableAdapter = new UI.InvoiceDbDataSet2TableAdapters.ItemsTableAdapter();
            this.itemsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.topBarV2Control1 = new UI.Controls.TopBarV2Control();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriesTableAdapter = new UI.InvoiceDbDataSet2TableAdapters.CategoriesTableAdapter();
            this.cmbCategories = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDbDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // topBarControl1
            // 
            this.topBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarControl1.Location = new System.Drawing.Point(0, 0);
            this.topBarControl1.Name = "topBarControl1";
            this.topBarControl1.Size = new System.Drawing.Size(898, 60);
            this.topBarControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(327, 121);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(571, 423);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNotes,
            this.colIsActive,
            this.colPrice,
            this.colCategory,
            this.colName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colNotes
            // 
            this.colNotes.Caption = "الملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 4;
            this.colNotes.Width = 43;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "فعال";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            this.colIsActive.Width = 42;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "السعر";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 42;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "الفئة";
            this.colCategory.FieldName = "Category.Name";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "المنتج";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 42;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.invoiceDbDataSet2;
            // 
            // invoiceDbDataSet2
            // 
            this.invoiceDbDataSet2.DataSetName = "InvoiceDbDataSet2";
            this.invoiceDbDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // itemsBindingSource1
            // 
            this.itemsBindingSource1.DataMember = "Items";
            this.itemsBindingSource1.DataSource = this.invoiceDbDataSet2;
            // 
            // itemsBindingSource2
            // 
            this.itemsBindingSource2.DataMember = "Items";
            this.itemsBindingSource2.DataSource = this.invoiceDbDataSet2;
            // 
            // topBarV2Control1
            // 
            this.topBarV2Control1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarV2Control1.Location = new System.Drawing.Point(0, 60);
            this.topBarV2Control1.Name = "topBarV2Control1";
            this.topBarV2Control1.Size = new System.Drawing.Size(898, 55);
            this.topBarV2Control1.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(234, 323);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 17);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = ":الملاحظات";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(234, 200);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 17);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = ":اسم العنصر";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemsBindingSource1, "Name", true));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource2, "Name", true));
            this.txtName.Location = new System.Drawing.Point(34, 197);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 20);
            this.txtName.TabIndex = 30;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(234, 243);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 17);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = ":الفئة";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(47, 284);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkIsActive.Properties.Appearance.Options.UseFont = true;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(75, 21);
            this.chkIsActive.TabIndex = 27;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(34, 320);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(194, 59);
            this.txtNotes.TabIndex = 26;
            this.txtNotes.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(234, 287);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 17);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = ":السعر";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(151, 284);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(66, 20);
            this.txtPrice.TabIndex = 24;
            // 
            // saveCancelControl21
            // 
            this.saveCancelControl21.Location = new System.Drawing.Point(56, 398);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 22;
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.invoiceDbDataSet2;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // cmbCategories
            // 
            this.cmbCategories.Location = new System.Drawing.Point(34, 243);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCategories.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbCategories.Size = new System.Drawing.Size(183, 20);
            this.cmbCategories.TabIndex = 33;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 538);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.saveCancelControl21);
            this.Controls.Add(this.topBarV2Control1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.topBarControl1);
            this.Name = "ItemsForm";
            this.Text = "ItemsForm";
            this.Load += new System.EventHandler(this.ItemsForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDbDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  

        #endregion

        private Base.TopBar.TopBarControl topBarControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private InvoiceDbDataSet2 invoiceDbDataSet2;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private InvoiceDbDataSet2TableAdapters.ItemsTableAdapter itemsTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private System.Windows.Forms.BindingSource itemsBindingSource1;
        private System.Windows.Forms.BindingSource itemsBindingSource2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Controls.TopBarV2Control topBarV2Control1;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private System.Windows.Forms.RichTextBox txtNotes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private Controls.SaveCancelControl2 saveCancelControl21;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private InvoiceDbDataSet2TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbCategories;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}
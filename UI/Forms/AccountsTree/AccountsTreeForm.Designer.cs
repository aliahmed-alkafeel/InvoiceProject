namespace UI.Forms
{
    partial class AccountsTreeForm
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
            this.treeListControl1 = new DevExpress.XtraTreeList.TreeList();
            this.colAccountCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsLeaf = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNotes = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            // treeListControl1
            // 
            this.treeListControl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colAccountCode,
            this.colAccountName,
            this.colIsLeaf,
            this.colIsActive,
            this.colNotes});
            this.treeListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListControl1.HierarchyColumn = this.colAccountName;
            this.treeListControl1.KeyFieldName = "Id";
            this.treeListControl1.Location = new System.Drawing.Point(0, 55);
            this.treeListControl1.Name = "treeListControl1";
            this.treeListControl1.OptionsBehavior.AutoPopulateColumns = false;
            this.treeListControl1.OptionsBehavior.Editable = false;
            this.treeListControl1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListControl1.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeListControl1.ParentFieldName = "ParentGuid";
            this.treeListControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeListControl1.Size = new System.Drawing.Size(976, 412);
            this.treeListControl1.TabIndex = 1;
            // 
            // colAccountCode
            // 
            this.colAccountCode.Caption = "رمز الحساب";
            this.colAccountCode.FieldName = "AccountCode";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.Visible = true;
            this.colAccountCode.VisibleIndex = 0;
            this.colAccountCode.Width = 150;
            // 
            // colAccountName
            // 
            this.colAccountName.Caption = "اسم الحساب";
            this.colAccountName.FieldName = "AccountName";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Visible = true;
            this.colAccountName.VisibleIndex = 1;
            this.colAccountName.Width = 300;
            // 
            // colIsLeaf
            // 
            this.colIsLeaf.Caption = "حساب نهائي";
            this.colIsLeaf.FieldName = "IsLeaf";
            this.colIsLeaf.Name = "colIsLeaf";
            this.colIsLeaf.Visible = true;
            this.colIsLeaf.VisibleIndex = 2;
            this.colIsLeaf.Width = 100;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "فعالة";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            this.colIsActive.Width = 90;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "الملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 4;
            this.colNotes.Width = 336;
            // 
            // AccountsTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 467);
            this.Controls.Add(this.treeListControl1);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "AccountsTreeForm";
            this.Text = "شجرة الحسابات";
            this.Load += new System.EventHandler(this.AccountsTreeForm_LoadAsync);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ToolBarControl toolBarControl1;
        private DevExpress.XtraTreeList.TreeList treeListControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsLeaf;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNotes;
    }
}

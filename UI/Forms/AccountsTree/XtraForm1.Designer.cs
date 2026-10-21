namespace UI.Forms.AccountsTree
{
    partial class XtraForm1
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.coltreeListColumn0 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coltreeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coltreeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.coltreeListColumn0,
            this.coltreeListColumn1,
            this.coltreeListColumn2});
            this.treeList1.Location = new System.Drawing.Point(301, 140);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "ng",
            "ghgh",
            "ghggh"}, -1);
            this.treeList1.AppendNode(new object[] {
            "vv",
            "vv",
            "bbb"}, 0);
            this.treeList1.AppendNode(new object[] {
            "ghgh",
            "d",
            "ghghhg"}, -1);
            this.treeList1.EndUnboundLoad();
            this.treeList1.Size = new System.Drawing.Size(400, 200);
            this.treeList1.TabIndex = 1;
            // 
            // coltreeListColumn0
            // 
            this.coltreeListColumn0.Caption = "gg";
            this.coltreeListColumn0.FieldName = "bnv";
            this.coltreeListColumn0.Name = "coltreeListColumn0";
            this.coltreeListColumn0.Visible = true;
            this.coltreeListColumn0.VisibleIndex = 0;
            // 
            // coltreeListColumn1
            // 
            this.coltreeListColumn1.Caption = "hh";
            this.coltreeListColumn1.FieldName = "treeListColumn1";
            this.coltreeListColumn1.Name = "coltreeListColumn1";
            this.coltreeListColumn1.Visible = true;
            this.coltreeListColumn1.VisibleIndex = 1;
            // 
            // coltreeListColumn2
            // 
            this.coltreeListColumn2.Caption = "coltreeListColumn2";
            this.coltreeListColumn2.FieldName = "treeListColumn2";
            this.coltreeListColumn2.Name = "coltreeListColumn2";
            this.coltreeListColumn2.Visible = true;
            this.coltreeListColumn2.VisibleIndex = 2;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 562);
            this.Controls.Add(this.treeList1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coltreeListColumn0;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coltreeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coltreeListColumn2;
    }
}
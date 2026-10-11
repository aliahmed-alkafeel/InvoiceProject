namespace UI.Controls
{
    partial class TopBarV2Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopBarV2Control));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 1F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 90F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 90F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 90F)});
            this.tablePanel1.Controls.Add(this.btnEdit);
            this.tablePanel1.Controls.Add(this.btnDelete);
            this.tablePanel1.Controls.Add(this.btnAdd);
            this.tablePanel1.Controls.Add(this.searchControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45F)});
            this.tablePanel1.Size = new System.Drawing.Size(900, 55);
            this.tablePanel1.TabIndex = 1;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnEdit, 2);
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnEdit.ImageOptions.ImageToTextIndent = 5;
            this.btnEdit.Location = new System.Drawing.Point(102, 11);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdit.Name = "btnEdit";
            this.tablePanel1.SetRow(this.btnEdit, 0);
            this.btnEdit.Size = new System.Drawing.Size(85, 32);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnDelete, 3);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnDelete.ImageOptions.ImageToTextIndent = 5;
            this.btnDelete.Location = new System.Drawing.Point(12, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.btnDelete.Name = "btnDelete";
            this.tablePanel1.SetRow(this.btnDelete, 0);
            this.btnDelete.Size = new System.Drawing.Size(85, 32);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnAdd, 1);
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAdd.ImageOptions.ImageToTextIndent = 5;
            this.btnAdd.Location = new System.Drawing.Point(192, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.tablePanel1.SetRow(this.btnAdd, 0);
            this.btnAdd.Size = new System.Drawing.Size(85, 32);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "اضافة";
            // 
            // searchControl1
            // 
            this.tablePanel1.SetColumn(this.searchControl1, 0);
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchControl1.Location = new System.Drawing.Point(587, 12);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tablePanel1.SetRow(this.searchControl1, 0);
            this.searchControl1.Size = new System.Drawing.Size(300, 30);
            this.searchControl1.TabIndex = 4;
            // 
            // TopBarV2Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Name = "TopBarV2Control";
            this.Size = new System.Drawing.Size(900, 55);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}
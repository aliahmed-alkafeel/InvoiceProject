namespace UI.Controls
{
    partial class SaveCancelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveCancelControl));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 92F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 1F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 92F)});
            this.tablePanel1.Controls.Add(this.btnSave);
            this.tablePanel1.Controls.Add(this.btnCancel);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(230, 60);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnCancel, 2);
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnCancel.ImageOptions.ImageToTextIndent = 5;
            this.btnCancel.Location = new System.Drawing.Point(129, 12);
            this.btnCancel.Name = "btnCancel";
            this.tablePanel1.SetRow(this.btnCancel, 0);
            this.btnCancel.Size = new System.Drawing.Size(88, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "الغاء";
            this.btnCancel.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnSave, 0);
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnSave.ImageOptions.ImageToTextIndent = 5;
            this.btnSave.Location = new System.Drawing.Point(13, 12);
            this.btnSave.Name = "btnSave";
            this.tablePanel1.SetRow(this.btnSave, 0);
            this.btnSave.Size = new System.Drawing.Size(88, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "حفظ";
            // 
            // SaveCancelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Name = "SaveCancelControl";
            this.Size = new System.Drawing.Size(230, 60);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}

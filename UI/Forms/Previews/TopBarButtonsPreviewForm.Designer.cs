namespace UI.Forms.Previews
{
    partial class TopBarButtonsPreviewForm
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
            this.topBarButtonsControl1 = new UI.Controls.TopBarButtonsControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblSelection = new DevExpress.XtraEditors.LabelControl();
            this.lblLastClick = new DevExpress.XtraEditors.LabelControl();
            this.lblHint = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // topBarButtonsControl1
            // 
            this.topBarButtonsControl1.AccessibleName = "Navigation";
            this.topBarButtonsControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.topBarButtonsControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.topBarButtonsControl1.Appearance.Options.UseFont = true;
            this.topBarButtonsControl1.AutoScroll = true;
            this.topBarButtonsControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(226)))));
            this.topBarButtonsControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarButtonsControl1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.topBarButtonsControl1.Location = new System.Drawing.Point(0, 0);
            this.topBarButtonsControl1.Name = "topBarButtonsControl1";
            this.topBarButtonsControl1.Padding = new System.Windows.Forms.Padding(4);
            this.topBarButtonsControl1.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.topBarButtonsControl1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.topBarButtonsControl1.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.topBarButtonsControl1.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.topBarButtonsControl1.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.topBarButtonsControl1.Size = new System.Drawing.Size(860, 64);
            this.topBarButtonsControl1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Location = new System.Drawing.Point(12, 98);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TopBarButtonsControl preview";
            // 
            // lblSelection
            // 
            this.lblSelection.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelection.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.lblSelection.Appearance.Options.UseFont = true;
            this.lblSelection.Appearance.Options.UseForeColor = true;
            this.lblSelection.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSelection.Location = new System.Drawing.Point(24, 132);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(420, 20);
            this.lblSelection.TabIndex = 2;
            this.lblSelection.Text = "Selected: Categories";
            // 
            // lblLastClick
            // 
            this.lblLastClick.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastClick.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(108)))), ((int)(((byte)(122)))));
            this.lblLastClick.Appearance.Options.UseFont = true;
            this.lblLastClick.Appearance.Options.UseForeColor = true;
            this.lblLastClick.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLastClick.Location = new System.Drawing.Point(24, 158);
            this.lblLastClick.Name = "lblLastClick";
            this.lblLastClick.Size = new System.Drawing.Size(420, 20);
            this.lblLastClick.TabIndex = 3;
            this.lblLastClick.Text = "Last click: (none)";
            // 
            // lblHint
            // 
            this.lblHint.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.lblHint.Appearance.Options.UseFont = true;
            this.lblHint.Appearance.Options.UseForeColor = true;
            this.lblHint.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHint.Location = new System.Drawing.Point(24, 196);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(740, 42);
            this.lblHint.TabIndex = 4;
            this.lblHint.Text = "Preview only. These buttons are not connected to application navigation or busine" +
    "ss operations.\r\nClick an item to change the selection; use the arrow keys when t" +
    "he bar has focus.";
            // 
            // TopBarButtonsPreviewForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 420);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblLastClick);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.topBarButtonsControl1);
            this.MinimumSize = new System.Drawing.Size(620, 320);
            this.Name = "TopBarButtonsPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معاينة أزرار الشريط";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.TopBarButtonsControl topBarButtonsControl1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSelection;
        private DevExpress.XtraEditors.LabelControl lblLastClick;
        private DevExpress.XtraEditors.LabelControl lblHint;
    }
}

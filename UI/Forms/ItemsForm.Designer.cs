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
            this.topBarV2Control1 = new UI.Controls.TopBarV2Control();
            this.topBarControl1 = new UI.Base.TopBar.TopBarControl();
            this.SuspendLayout();
            // 
            // topBarV2Control1
            // 
            this.topBarV2Control1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarV2Control1.Location = new System.Drawing.Point(0, 60);
            this.topBarV2Control1.Name = "topBarV2Control1";
            this.topBarV2Control1.Size = new System.Drawing.Size(898, 55);
            this.topBarV2Control1.TabIndex = 1;
            // 
            // topBarControl1
            // 
            this.topBarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarControl1.Location = new System.Drawing.Point(0, 0);
            this.topBarControl1.Name = "topBarControl1";
            this.topBarControl1.Size = new System.Drawing.Size(898, 60);
            this.topBarControl1.TabIndex = 0;
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 468);
            this.Controls.Add(this.topBarV2Control1);
            this.Controls.Add(this.topBarControl1);
            this.Name = "ItemsForm";
            this.Text = "ItemsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Base.TopBar.TopBarControl topBarControl1;
        private Controls.TopBarV2Control topBarV2Control1;
    }
}
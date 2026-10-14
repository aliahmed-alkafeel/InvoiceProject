namespace UI.Forms
{
    partial class CategoriesForm
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
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 467);
            this.Controls.Add(this.toolBarControl1);
            this.Name = "CategoriesForm";
            this.Text = "CategoriesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ToolBarControl toolBarControl1;
    }
}
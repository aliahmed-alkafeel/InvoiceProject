namespace UI.Base.TopBar
{
    partial class TopBarControl
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
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navButton8 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton6 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton5 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton7 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton4 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton9 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton3 = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Buttons.Add(this.navButton8);
            this.tileNavPane1.Buttons.Add(this.navButton2);
            this.tileNavPane1.Buttons.Add(this.navButton6);
            this.tileNavPane1.Buttons.Add(this.navButton5);
            this.tileNavPane1.Buttons.Add(this.navButton7);
            this.tileNavPane1.Buttons.Add(this.navButton4);
            this.tileNavPane1.Buttons.Add(this.navButton9);
            this.tileNavPane1.Buttons.Add(this.navButton3);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Margin = new System.Windows.Forms.Padding(0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.Size = new System.Drawing.Size(900, 60);
            this.tileNavPane1.TabIndex = 2;
            this.tileNavPane1.Text = "tileNavPane1";
            this.tileNavPane1.ToolTipShowMode = DevExpress.XtraBars.Navigation.ToolTipShowMode.NavBarItems;
            this.tileNavPane1.Click += new System.EventHandler(this.tileNavPane1_Click);
            // 
            // navButton8
            // 
            this.navButton8.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton8.Caption = "الموظفين";
            this.navButton8.Name = "navButton8";
            // 
            // navButton2
            // 
            this.navButton2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton2.Caption = "العملة";
            this.navButton2.Name = "navButton2";
            // 
            // navButton6
            // 
            this.navButton6.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton6.Caption = "شجرة الحسابات";
            this.navButton6.Name = "navButton6";
            // 
            // navButton5
            // 
            this.navButton5.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton5.Caption = "السندات";
            this.navButton5.Name = "navButton5";
            // 
            // navButton7
            // 
            this.navButton7.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton7.Caption = "تفاصيل الفواتير";
            this.navButton7.Name = "navButton7";
            // 
            // navButton4
            // 
            this.navButton4.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton4.Caption = "الفواتير";
            this.navButton4.Name = "navButton4";
            // 
            // navButton9
            // 
            this.navButton9.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton9.Caption = "الاصناف";
            this.navButton9.Name = "navButton9";
            // 
            // navButton3
            // 
            this.navButton3.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton3.Caption = "المنتجات";
            this.navButton3.Name = "navButton3";
            // 
            // TopBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileNavPane1);
            this.Name = "TopBarControl";
            this.Size = new System.Drawing.Size(900, 60);
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavButton navButton8;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton navButton6;
        private DevExpress.XtraBars.Navigation.NavButton navButton5;
        private DevExpress.XtraBars.Navigation.NavButton navButton7;
        private DevExpress.XtraBars.Navigation.NavButton navButton4;
        private DevExpress.XtraBars.Navigation.NavButton navButton9;
        private DevExpress.XtraBars.Navigation.NavButton navButton3;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
    }
}

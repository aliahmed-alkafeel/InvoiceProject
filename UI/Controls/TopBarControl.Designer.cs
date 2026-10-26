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
            this.btnGroups = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEmployees = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnCurrencies = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnAccountsTree = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnVouchers = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnItemBills = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnBills = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnCategories = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnItems = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.tileNavPane1.Appearance.Options.UseBackColor = true;
            this.tileNavPane1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.tileNavPane1.Buttons.Add(this.btnGroups);
            this.tileNavPane1.Buttons.Add(this.btnEmployees);
            this.tileNavPane1.Buttons.Add(this.btnCurrencies);
            this.tileNavPane1.Buttons.Add(this.btnAccountsTree);
            this.tileNavPane1.Buttons.Add(this.btnVouchers);
            this.tileNavPane1.Buttons.Add(this.btnItemBills);
            this.tileNavPane1.Buttons.Add(this.btnBills);
            this.tileNavPane1.Buttons.Add(this.btnCategories);
            this.tileNavPane1.Buttons.Add(this.btnItems);
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
            this.tileNavPane1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tileNavPane1.Size = new System.Drawing.Size(900, 45);
            this.tileNavPane1.TabIndex = 2;
            this.tileNavPane1.Text = "tileNavPane1";
            this.tileNavPane1.ToolTipShowMode = DevExpress.XtraBars.Navigation.ToolTipShowMode.NavBarItems;
            this.tileNavPane1.Click += new System.EventHandler(this.tileNavPane1_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnGroups.Caption = "المجموعات";
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnGroups_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnEmployees.Caption = "الموظفين";
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEmployees_Click);
            // 
            // btnCurrencies
            // 
            this.btnCurrencies.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnCurrencies.Caption = "العملة";
            this.btnCurrencies.Name = "btnCurrencies";
            this.btnCurrencies.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnCurrencies_Click);
            // 
            // btnAccountsTree
            // 
            this.btnAccountsTree.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnAccountsTree.Caption = "شجرة الحسابات";
            this.btnAccountsTree.Name = "btnAccountsTree";
            this.btnAccountsTree.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnAccountsTree_Click);
            // 
            // btnVouchers
            // 
            this.btnVouchers.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnVouchers.Caption = "السندات";
            this.btnVouchers.Name = "btnVouchers";
            this.btnVouchers.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnVouchers_Click);
            // 
            // btnItemBills
            // 
            this.btnItemBills.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnItemBills.Caption = "تفاصيل الفواتير";
            this.btnItemBills.Name = "btnItemBills";
            this.btnItemBills.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButton7_Click);
            // 
            // btnBills
            // 
            this.btnBills.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnBills.Caption = "الفواتير";
            this.btnBills.Name = "btnBills";
            this.btnBills.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnBills_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnCategories.Caption = "الاصناف";
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnCategories_Click);
            // 
            // btnItems
            // 
            this.btnItems.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnItems.Caption = "المنتجات";
            this.btnItems.Name = "btnItems";
            this.btnItems.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnItems_Click);
            // 
            // TopBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileNavPane1);
            this.Name = "TopBarControl";
            this.Size = new System.Drawing.Size(900, 45);
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavButton btnEmployees;
        private DevExpress.XtraBars.Navigation.NavButton btnCurrencies;
        private DevExpress.XtraBars.Navigation.NavButton btnAccountsTree;
        private DevExpress.XtraBars.Navigation.NavButton btnVouchers;
        private DevExpress.XtraBars.Navigation.NavButton btnItemBills;
        private DevExpress.XtraBars.Navigation.NavButton btnBills;
        private DevExpress.XtraBars.Navigation.NavButton btnCategories;
        private DevExpress.XtraBars.Navigation.NavButton btnItems;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnGroups;
    }
}

namespace UI.Forms.Currencies
{
    partial class CurrenciesManageForm
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrencyName = new DevExpress.XtraEditors.TextEdit();
            this.txtCurrencySymbol = new DevExpress.XtraEditors.TextEdit();
            this.spinCurrencyEqual = new DevExpress.XtraEditors.SpinEdit();
            this.chkIsMain = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.saveCancelControl21 = new UI.Controls.SaveCancelControl2();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencySymbol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCurrencyEqual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Location = new System.Drawing.Point(185, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 27);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "تعديل العملة";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.Location = new System.Drawing.Point(380, 248);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(65, 17);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = ":الملاحظات";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.Location = new System.Drawing.Point(380, 212);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(34, 17);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = ":فعالة";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.Location = new System.Drawing.Point(380, 140);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(95, 17);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = ":العملة الرئيسية";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Location = new System.Drawing.Point(380, 173);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 17);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = ":سعر الصرف";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Location = new System.Drawing.Point(380, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 17);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = ":رمز العملة";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Location = new System.Drawing.Point(380, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 17);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = ":اسم العملة";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(70, 66);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(285, 20);
            this.txtCurrencyName.TabIndex = 13;
            // 
            // txtCurrencySymbol
            // 
            this.txtCurrencySymbol.Location = new System.Drawing.Point(70, 102);
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.Size = new System.Drawing.Size(285, 20);
            this.txtCurrencySymbol.TabIndex = 12;
            // 
            // spinCurrencyEqual
            // 
            this.spinCurrencyEqual.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinCurrencyEqual.Location = new System.Drawing.Point(70, 171);
            this.spinCurrencyEqual.Name = "spinCurrencyEqual";
            this.spinCurrencyEqual.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinCurrencyEqual.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinCurrencyEqual.Size = new System.Drawing.Size(285, 20);
            this.spinCurrencyEqual.TabIndex = 11;
            // 
            // chkIsMain
            // 
            this.chkIsMain.Location = new System.Drawing.Point(233, 136);
            this.chkIsMain.Name = "chkIsMain";
            this.chkIsMain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkIsMain.Properties.Appearance.Options.UseFont = true;
            this.chkIsMain.Properties.Caption = "العملة الرئيسية";
            this.chkIsMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsMain.Size = new System.Drawing.Size(122, 21);
            this.chkIsMain.TabIndex = 10;
            this.chkIsMain.CheckedChanged += new System.EventHandler(this.chkIsMain_CheckedChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(250, 208);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkIsActive.Properties.Appearance.Options.UseFont = true;
            this.chkIsActive.Properties.Caption = "فعالة";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(105, 21);
            this.chkIsActive.TabIndex = 9;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(70, 244);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(285, 59);
            this.txtNotes.TabIndex = 8;
            this.txtNotes.Text = "";
            // 
            // saveCancelControl21
            // 
            this.saveCancelControl21.Location = new System.Drawing.Point(184, 330);
            this.saveCancelControl21.Name = "saveCancelControl21";
            this.saveCancelControl21.SaveText = "حفظ";
            this.saveCancelControl21.Size = new System.Drawing.Size(191, 45);
            this.saveCancelControl21.TabIndex = 7;
            // 
            // CurrenciesManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtCurrencyName);
            this.Controls.Add(this.txtCurrencySymbol);
            this.Controls.Add(this.spinCurrencyEqual);
            this.Controls.Add(this.chkIsMain);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.saveCancelControl21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrenciesManageForm";
            this.Text = "إدارة العملة";
            this.Load += new System.EventHandler(this.CurrenciesManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencySymbol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCurrencyEqual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCurrencyName;
        private DevExpress.XtraEditors.TextEdit txtCurrencySymbol;
        private DevExpress.XtraEditors.SpinEdit spinCurrencyEqual;
        private DevExpress.XtraEditors.CheckEdit chkIsMain;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private System.Windows.Forms.RichTextBox txtNotes;
        private Controls.SaveCancelControl2 saveCancelControl21;
    }
}

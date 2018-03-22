namespace PengLang
{
    partial class FrmFinance
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
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpAccountCash = new DevExpress.XtraTab.XtraTabPage();
            this.tpCommission = new DevExpress.XtraTab.XtraTabPage();
            this.tpInvoice = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTab
            // 
            this.xtraTab.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.xtraTab.Appearance.Options.UseBackColor = true;
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpAccountCash;
            this.xtraTab.Size = new System.Drawing.Size(733, 343);
            this.xtraTab.TabIndex = 1;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpAccountCash,
            this.tpCommission,
            this.tpInvoice});
            // 
            // tpAccountCash
            // 
            this.tpAccountCash.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpAccountCash.Appearance.PageClient.Options.UseBackColor = true;
            this.tpAccountCash.Name = "tpAccountCash";
            this.tpAccountCash.Size = new System.Drawing.Size(727, 314);
            this.tpAccountCash.Text = "收款 && 认领";
            // 
            // tpCommission
            // 
            this.tpCommission.Name = "tpCommission";
            this.tpCommission.Size = new System.Drawing.Size(727, 314);
            this.tpCommission.Text = "  佣  金  ";
            // 
            // tpInvoice
            // 
            this.tpInvoice.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpInvoice.Appearance.PageClient.Options.UseBackColor = true;
            this.tpInvoice.Name = "tpInvoice";
            this.tpInvoice.Size = new System.Drawing.Size(727, 314);
            this.tpInvoice.Text = "  发  票  ";
            // 
            // FrmFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 343);
            this.Controls.Add(this.xtraTab);
            this.Name = "FrmFinance";
            this.Text = "财务管理";
            this.Load += new System.EventHandler(this.FrmFinance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpAccountCash;
        private DevExpress.XtraTab.XtraTabPage tpInvoice;
        private DevExpress.XtraTab.XtraTabPage tpCommission;
    }
}
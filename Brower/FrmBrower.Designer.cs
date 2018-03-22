namespace PengLang
{
    partial class FrmBrower
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
            this.tpOutbound = new DevExpress.XtraTab.XtraTabPage();
            this.tpCash = new DevExpress.XtraTab.XtraTabPage();
            this.tpUnPaid = new DevExpress.XtraTab.XtraTabPage();
            this.tpInventory = new DevExpress.XtraTab.XtraTabPage();
            this.tpSale = new DevExpress.XtraTab.XtraTabPage();
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
            this.xtraTab.SelectedTabPage = this.tpOutbound;
            this.xtraTab.Size = new System.Drawing.Size(429, 255);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpOutbound,
            this.tpCash,
            this.tpUnPaid,
            this.tpInventory,
            this.tpSale});
            this.xtraTab.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTab_SelectedPageChanged);
            // 
            // tpOutbound
            // 
            this.tpOutbound.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpOutbound.Appearance.PageClient.Options.UseBackColor = true;
            this.tpOutbound.Name = "tpOutbound";
            this.tpOutbound.Size = new System.Drawing.Size(423, 226);
            this.tpOutbound.Text = "出库统计";
            // 
            // tpCash
            // 
            this.tpCash.Name = "tpCash";
            this.tpCash.Size = new System.Drawing.Size(423, 226);
            this.tpCash.Text = "收款统计";
            // 
            // tpUnPaid
            // 
            this.tpUnPaid.Name = "tpUnPaid";
            this.tpUnPaid.Size = new System.Drawing.Size(423, 226);
            this.tpUnPaid.Text = "逾期未付";
            // 
            // tpInventory
            // 
            this.tpInventory.Name = "tpInventory";
            this.tpInventory.Size = new System.Drawing.Size(423, 226);
            this.tpInventory.Text = "库存统计";
            // 
            // tpSale
            // 
            this.tpSale.Name = "tpSale";
            this.tpSale.Size = new System.Drawing.Size(423, 226);
            this.tpSale.Text = "销售统计";
            // 
            // FrmBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 255);
            this.Controls.Add(this.xtraTab);
            this.Name = "FrmBrower";
            this.Text = "FrmBrower";
            this.Load += new System.EventHandler(this.FrmBrower_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpOutbound;
        private DevExpress.XtraTab.XtraTabPage tpInventory;
        private DevExpress.XtraTab.XtraTabPage tpSale;
        private DevExpress.XtraTab.XtraTabPage tpCash;
        private DevExpress.XtraTab.XtraTabPage tpUnPaid;
    }
}
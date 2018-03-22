namespace PengLang
{
    partial class FrmSalesCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesCash));
            this.gbTop = new DevExpress.XtraEditors.GroupControl();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labAmount = new DevExpress.XtraEditors.LabelControl();
            this.lblRcvdDate = new DevExpress.XtraEditors.LabelControl();
            this.rcvdGrid = new DevExpress.XtraGrid.GridControl();
            this.rcvdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).BeginInit();
            this.gbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.txtDate);
            this.gbTop.Controls.Add(this.txtAmount);
            this.gbTop.Controls.Add(this.btnPay);
            this.gbTop.Controls.Add(this.btnExport);
            this.gbTop.Controls.Add(this.labAmount);
            this.gbTop.Controls.Add(this.lblRcvdDate);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.ShowCaption = false;
            this.gbTop.Size = new System.Drawing.Size(570, 51);
            this.gbTop.TabIndex = 10;
            this.gbTop.Text = "检索";
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(76, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(111, 26);
            this.txtDate.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtAmount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.Location = new System.Drawing.Point(260, 12);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(95, 26);
            this.txtAmount.TabIndex = 2;
            // 
            // btnPay
            // 
            this.btnPay.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.Image")));
            this.btnPay.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(373, 11);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(72, 31);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "确认";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(478, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.Visible = false;
            // 
            // labAmount
            // 
            this.labAmount.Location = new System.Drawing.Point(197, 20);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new System.Drawing.Size(60, 14);
            this.labAmount.TabIndex = 7;
            this.labAmount.Text = "收款金额：";
            // 
            // lblRcvdDate
            // 
            this.lblRcvdDate.Location = new System.Drawing.Point(10, 18);
            this.lblRcvdDate.Name = "lblRcvdDate";
            this.lblRcvdDate.Size = new System.Drawing.Size(60, 14);
            this.lblRcvdDate.TabIndex = 7;
            this.lblRcvdDate.Text = "收款日期：";
            // 
            // rcvdGrid
            // 
            this.rcvdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.rcvdGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.rcvdGrid.Location = new System.Drawing.Point(0, 51);
            this.rcvdGrid.MainView = this.rcvdView;
            this.rcvdGrid.Name = "rcvdGrid";
            this.rcvdGrid.Size = new System.Drawing.Size(570, 327);
            this.rcvdGrid.TabIndex = 14;
            this.rcvdGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.rcvdView});
            // 
            // rcvdView
            // 
            this.rcvdView.GridControl = this.rcvdGrid;
            this.rcvdView.Name = "rcvdView";
            this.rcvdView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmSalesCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 378);
            this.Controls.Add(this.rcvdGrid);
            this.Controls.Add(this.gbTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalesCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收款认领";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSalesCash_FormClosing);
            this.Load += new System.EventHandler(this.FrmSalesCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).EndInit();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcvdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTop;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl lblRcvdDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtAmount;
        private DevExpress.XtraEditors.LabelControl labAmount;
        private DevExpress.XtraGrid.GridControl rcvdGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView rcvdView;
    }
}
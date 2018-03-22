namespace PengLang
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panForm = new System.Windows.Forms.Panel();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpWarn = new DevExpress.XtraTab.XtraTabPage();
            this.tpWelcome = new DevExpress.XtraTab.XtraTabPage();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.tpInventory = new DevExpress.XtraTab.XtraTabPage();
            this.tpInbound = new DevExpress.XtraTab.XtraTabPage();
            this.tpOutbound = new DevExpress.XtraTab.XtraTabPage();
            this.tpInvoice = new DevExpress.XtraTab.XtraTabPage();
            this.tpTranbound = new DevExpress.XtraTab.XtraTabPage();
            this.tpManage = new DevExpress.XtraTab.XtraTabPage();
            this.tpBackBound = new DevExpress.XtraTab.XtraTabPage();
            this.tpSearch = new DevExpress.XtraTab.XtraTabPage();
            this.panFooter = new System.Windows.Forms.Panel();
            this.pboxFooterLogo = new System.Windows.Forms.PictureBox();
            this.panTop = new System.Windows.Forms.Panel();
            this.pbtnLogout = new System.Windows.Forms.PictureBox();
            this.pbtnManageSel = new System.Windows.Forms.PictureBox();
            this.pbtnInvoiceSel = new System.Windows.Forms.PictureBox();
            this.pbtnInvoice = new System.Windows.Forms.PictureBox();
            this.pbtnManage = new System.Windows.Forms.PictureBox();
            this.pbtnTranboundSel = new System.Windows.Forms.PictureBox();
            this.pbtnOutboundSel = new System.Windows.Forms.PictureBox();
            this.pbtnTranbound = new System.Windows.Forms.PictureBox();
            this.pbtnBackSel = new System.Windows.Forms.PictureBox();
            this.pbtnSearchSel = new System.Windows.Forms.PictureBox();
            this.pbtnBack = new System.Windows.Forms.PictureBox();
            this.pbtnSearch = new System.Windows.Forms.PictureBox();
            this.pbtnInventorySel = new System.Windows.Forms.PictureBox();
            this.pbtnOutbound = new System.Windows.Forms.PictureBox();
            this.pbtnInboundSel = new System.Windows.Forms.PictureBox();
            this.pbtnInventory = new System.Windows.Forms.PictureBox();
            this.pbtnInbound = new System.Windows.Forms.PictureBox();
            this.pboxTopClient = new System.Windows.Forms.PictureBox();
            this.pboxLogo = new System.Windows.Forms.PictureBox();
            this.panForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.tpWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.panFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFooterLogo)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnManageSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInvoiceSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnTranboundSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOutboundSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnTranbound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnBackSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearchSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInventorySel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOutbound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInboundSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInbound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panForm
            // 
            this.panForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panForm.BackgroundImage")));
            this.panForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panForm.Controls.Add(this.xtraTab);
            this.panForm.Controls.Add(this.panFooter);
            this.panForm.Controls.Add(this.panTop);
            this.panForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panForm.Location = new System.Drawing.Point(0, 0);
            this.panForm.Name = "panForm";
            this.panForm.Size = new System.Drawing.Size(1268, 529);
            this.panForm.TabIndex = 2;
            // 
            // xtraTab
            // 
            this.xtraTab.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTab.Appearance.Options.UseBackColor = true;
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTab.Location = new System.Drawing.Point(0, 73);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpWarn;
            this.xtraTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTab.Size = new System.Drawing.Size(1264, 421);
            this.xtraTab.TabIndex = 5;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpWelcome,
            this.tpWarn,
            this.tpInventory,
            this.tpInbound,
            this.tpOutbound,
            this.tpInvoice,
            this.tpTranbound,
            this.tpManage,
            this.tpBackBound,
            this.tpSearch});
            // 
            // tpWarn
            // 
            this.tpWarn.Name = "tpWarn";
            this.tpWarn.Size = new System.Drawing.Size(1258, 392);
            this.tpWarn.Text = "预警";
            // 
            // tpWelcome
            // 
            this.tpWelcome.Controls.Add(this.pictureBoxWelcome);
            this.tpWelcome.Name = "tpWelcome";
            this.tpWelcome.Size = new System.Drawing.Size(1258, 392);
            this.tpWelcome.Text = "欢迎";
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWelcome.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWelcome.Image")));
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(1258, 392);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            // 
            // tpInventory
            // 
            this.tpInventory.Name = "tpInventory";
            this.tpInventory.Size = new System.Drawing.Size(1258, 392);
            this.tpInventory.Text = "库存";
            // 
            // tpInbound
            // 
            this.tpInbound.Name = "tpInbound";
            this.tpInbound.Size = new System.Drawing.Size(1258, 392);
            this.tpInbound.Text = "入库";
            // 
            // tpOutbound
            // 
            this.tpOutbound.Name = "tpOutbound";
            this.tpOutbound.Size = new System.Drawing.Size(1258, 392);
            this.tpOutbound.Text = "  出库  ";
            // 
            // tpInvoice
            // 
            this.tpInvoice.Name = "tpInvoice";
            this.tpInvoice.Size = new System.Drawing.Size(1258, 392);
            this.tpInvoice.Text = "发票";
            // 
            // tpTranbound
            // 
            this.tpTranbound.Name = "tpTranbound";
            this.tpTranbound.Size = new System.Drawing.Size(1258, 392);
            this.tpTranbound.Text = "转库";
            // 
            // tpManage
            // 
            this.tpManage.Name = "tpManage";
            this.tpManage.Size = new System.Drawing.Size(1258, 392);
            this.tpManage.Text = "管理";
            // 
            // tpBackBound
            // 
            this.tpBackBound.Name = "tpBackBound";
            this.tpBackBound.Size = new System.Drawing.Size(1258, 392);
            this.tpBackBound.Text = "退货";
            // 
            // tpSearch
            // 
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Size = new System.Drawing.Size(1258, 392);
            this.tpSearch.Text = "查询";
            // 
            // panFooter
            // 
            this.panFooter.BackColor = System.Drawing.Color.Transparent;
            this.panFooter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panFooter.BackgroundImage")));
            this.panFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panFooter.Controls.Add(this.pboxFooterLogo);
            this.panFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFooter.Location = new System.Drawing.Point(0, 494);
            this.panFooter.Name = "panFooter";
            this.panFooter.Size = new System.Drawing.Size(1264, 31);
            this.panFooter.TabIndex = 2;
            this.panFooter.Resize += new System.EventHandler(this.panFooter_Resize);
            // 
            // pboxFooterLogo
            // 
            this.pboxFooterLogo.BackColor = System.Drawing.Color.Transparent;
            this.pboxFooterLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboxFooterLogo.Image")));
            this.pboxFooterLogo.Location = new System.Drawing.Point(384, 2);
            this.pboxFooterLogo.Name = "pboxFooterLogo";
            this.pboxFooterLogo.Size = new System.Drawing.Size(214, 27);
            this.pboxFooterLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboxFooterLogo.TabIndex = 1;
            this.pboxFooterLogo.TabStop = false;
            // 
            // panTop
            // 
            this.panTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panTop.BackgroundImage")));
            this.panTop.Controls.Add(this.pbtnLogout);
            this.panTop.Controls.Add(this.pbtnManageSel);
            this.panTop.Controls.Add(this.pbtnInvoiceSel);
            this.panTop.Controls.Add(this.pbtnInvoice);
            this.panTop.Controls.Add(this.pbtnManage);
            this.panTop.Controls.Add(this.pbtnTranboundSel);
            this.panTop.Controls.Add(this.pbtnOutboundSel);
            this.panTop.Controls.Add(this.pbtnTranbound);
            this.panTop.Controls.Add(this.pbtnBackSel);
            this.panTop.Controls.Add(this.pbtnSearchSel);
            this.panTop.Controls.Add(this.pbtnBack);
            this.panTop.Controls.Add(this.pbtnSearch);
            this.panTop.Controls.Add(this.pbtnInventorySel);
            this.panTop.Controls.Add(this.pbtnOutbound);
            this.panTop.Controls.Add(this.pbtnInboundSel);
            this.panTop.Controls.Add(this.pbtnInventory);
            this.panTop.Controls.Add(this.pbtnInbound);
            this.panTop.Controls.Add(this.pboxTopClient);
            this.panTop.Controls.Add(this.pboxLogo);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1264, 73);
            this.panTop.TabIndex = 1;
            // 
            // pbtnLogout
            // 
            this.pbtnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnLogout.BackColor = System.Drawing.Color.Transparent;
            this.pbtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("pbtnLogout.Image")));
            this.pbtnLogout.Location = new System.Drawing.Point(1180, 41);
            this.pbtnLogout.Name = "pbtnLogout";
            this.pbtnLogout.Size = new System.Drawing.Size(69, 26);
            this.pbtnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnLogout.TabIndex = 2;
            this.pbtnLogout.TabStop = false;
            this.pbtnLogout.Click += new System.EventHandler(this.pbtnLogout_Click);
            // 
            // pbtnManageSel
            // 
            this.pbtnManageSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnManageSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnManageSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnManageSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnManageSel.Image")));
            this.pbtnManageSel.Location = new System.Drawing.Point(1105, 41);
            this.pbtnManageSel.Name = "pbtnManageSel";
            this.pbtnManageSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnManageSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnManageSel.TabIndex = 2;
            this.pbtnManageSel.TabStop = false;
            this.pbtnManageSel.Click += new System.EventHandler(this.pbtnManage_Click);
            // 
            // pbtnInvoiceSel
            // 
            this.pbtnInvoiceSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInvoiceSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInvoiceSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInvoiceSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInvoiceSel.Image")));
            this.pbtnInvoiceSel.Location = new System.Drawing.Point(1030, 41);
            this.pbtnInvoiceSel.Name = "pbtnInvoiceSel";
            this.pbtnInvoiceSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnInvoiceSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInvoiceSel.TabIndex = 2;
            this.pbtnInvoiceSel.TabStop = false;
            this.pbtnInvoiceSel.Click += new System.EventHandler(this.pbtnInvoice_Click);
            // 
            // pbtnInvoice
            // 
            this.pbtnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInvoice.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInvoice.Image")));
            this.pbtnInvoice.Location = new System.Drawing.Point(1031, 41);
            this.pbtnInvoice.Name = "pbtnInvoice";
            this.pbtnInvoice.Size = new System.Drawing.Size(69, 26);
            this.pbtnInvoice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInvoice.TabIndex = 2;
            this.pbtnInvoice.TabStop = false;
            this.pbtnInvoice.Click += new System.EventHandler(this.pbtnInvoice_Click);
            // 
            // pbtnManage
            // 
            this.pbtnManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnManage.BackColor = System.Drawing.Color.Transparent;
            this.pbtnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnManage.Image = ((System.Drawing.Image)(resources.GetObject("pbtnManage.Image")));
            this.pbtnManage.Location = new System.Drawing.Point(1105, 41);
            this.pbtnManage.Name = "pbtnManage";
            this.pbtnManage.Size = new System.Drawing.Size(69, 26);
            this.pbtnManage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnManage.TabIndex = 2;
            this.pbtnManage.TabStop = false;
            this.pbtnManage.Click += new System.EventHandler(this.pbtnManage_Click);
            // 
            // pbtnTranboundSel
            // 
            this.pbtnTranboundSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnTranboundSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnTranboundSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnTranboundSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnTranboundSel.Image")));
            this.pbtnTranboundSel.Location = new System.Drawing.Point(884, 41);
            this.pbtnTranboundSel.Name = "pbtnTranboundSel";
            this.pbtnTranboundSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnTranboundSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnTranboundSel.TabIndex = 2;
            this.pbtnTranboundSel.TabStop = false;
            this.pbtnTranboundSel.Click += new System.EventHandler(this.pbtnTranbound_Click);
            // 
            // pbtnOutboundSel
            // 
            this.pbtnOutboundSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnOutboundSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnOutboundSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnOutboundSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnOutboundSel.Image")));
            this.pbtnOutboundSel.Location = new System.Drawing.Point(809, 41);
            this.pbtnOutboundSel.Name = "pbtnOutboundSel";
            this.pbtnOutboundSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnOutboundSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnOutboundSel.TabIndex = 2;
            this.pbtnOutboundSel.TabStop = false;
            this.pbtnOutboundSel.Click += new System.EventHandler(this.pbtnOutbound_Click);
            // 
            // pbtnTranbound
            // 
            this.pbtnTranbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnTranbound.BackColor = System.Drawing.Color.Transparent;
            this.pbtnTranbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnTranbound.Image = ((System.Drawing.Image)(resources.GetObject("pbtnTranbound.Image")));
            this.pbtnTranbound.Location = new System.Drawing.Point(884, 41);
            this.pbtnTranbound.Name = "pbtnTranbound";
            this.pbtnTranbound.Size = new System.Drawing.Size(69, 26);
            this.pbtnTranbound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnTranbound.TabIndex = 2;
            this.pbtnTranbound.TabStop = false;
            this.pbtnTranbound.Click += new System.EventHandler(this.pbtnTranbound_Click);
            // 
            // pbtnBackSel
            // 
            this.pbtnBackSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnBackSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnBackSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnBackSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnBackSel.Image")));
            this.pbtnBackSel.Location = new System.Drawing.Point(957, 41);
            this.pbtnBackSel.Name = "pbtnBackSel";
            this.pbtnBackSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnBackSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnBackSel.TabIndex = 2;
            this.pbtnBackSel.TabStop = false;
            this.pbtnBackSel.Click += new System.EventHandler(this.pbtnBackSel_Click);
            // 
            // pbtnSearchSel
            // 
            this.pbtnSearchSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnSearchSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnSearchSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearchSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnSearchSel.Image")));
            this.pbtnSearchSel.Location = new System.Drawing.Point(584, 41);
            this.pbtnSearchSel.Name = "pbtnSearchSel";
            this.pbtnSearchSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnSearchSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnSearchSel.TabIndex = 2;
            this.pbtnSearchSel.TabStop = false;
            this.pbtnSearchSel.Click += new System.EventHandler(this.pbtnSearch_Click);
            // 
            // pbtnBack
            // 
            this.pbtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnBack.BackColor = System.Drawing.Color.Transparent;
            this.pbtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnBack.Image = ((System.Drawing.Image)(resources.GetObject("pbtnBack.Image")));
            this.pbtnBack.Location = new System.Drawing.Point(957, 41);
            this.pbtnBack.Name = "pbtnBack";
            this.pbtnBack.Size = new System.Drawing.Size(69, 26);
            this.pbtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnBack.TabIndex = 2;
            this.pbtnBack.TabStop = false;
            this.pbtnBack.Click += new System.EventHandler(this.pbtnBackSel_Click);
            // 
            // pbtnSearch
            // 
            this.pbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.pbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbtnSearch.Image")));
            this.pbtnSearch.Location = new System.Drawing.Point(584, 41);
            this.pbtnSearch.Name = "pbtnSearch";
            this.pbtnSearch.Size = new System.Drawing.Size(69, 26);
            this.pbtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnSearch.TabIndex = 2;
            this.pbtnSearch.TabStop = false;
            this.pbtnSearch.Click += new System.EventHandler(this.pbtnSearch_Click);
            // 
            // pbtnInventorySel
            // 
            this.pbtnInventorySel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInventorySel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInventorySel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInventorySel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInventorySel.Image")));
            this.pbtnInventorySel.Location = new System.Drawing.Point(659, 41);
            this.pbtnInventorySel.Name = "pbtnInventorySel";
            this.pbtnInventorySel.Size = new System.Drawing.Size(69, 26);
            this.pbtnInventorySel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInventorySel.TabIndex = 2;
            this.pbtnInventorySel.TabStop = false;
            this.pbtnInventorySel.Click += new System.EventHandler(this.pbtnInventory_Click);
            // 
            // pbtnOutbound
            // 
            this.pbtnOutbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnOutbound.BackColor = System.Drawing.Color.Transparent;
            this.pbtnOutbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnOutbound.Image = ((System.Drawing.Image)(resources.GetObject("pbtnOutbound.Image")));
            this.pbtnOutbound.Location = new System.Drawing.Point(809, 41);
            this.pbtnOutbound.Name = "pbtnOutbound";
            this.pbtnOutbound.Size = new System.Drawing.Size(69, 26);
            this.pbtnOutbound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnOutbound.TabIndex = 2;
            this.pbtnOutbound.TabStop = false;
            this.pbtnOutbound.Click += new System.EventHandler(this.pbtnOutbound_Click);
            // 
            // pbtnInboundSel
            // 
            this.pbtnInboundSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInboundSel.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInboundSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInboundSel.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInboundSel.Image")));
            this.pbtnInboundSel.Location = new System.Drawing.Point(734, 41);
            this.pbtnInboundSel.Name = "pbtnInboundSel";
            this.pbtnInboundSel.Size = new System.Drawing.Size(69, 26);
            this.pbtnInboundSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInboundSel.TabIndex = 2;
            this.pbtnInboundSel.TabStop = false;
            this.pbtnInboundSel.Click += new System.EventHandler(this.pbtnInbound_Click);
            // 
            // pbtnInventory
            // 
            this.pbtnInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInventory.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInventory.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInventory.Image")));
            this.pbtnInventory.Location = new System.Drawing.Point(659, 41);
            this.pbtnInventory.Name = "pbtnInventory";
            this.pbtnInventory.Size = new System.Drawing.Size(69, 26);
            this.pbtnInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInventory.TabIndex = 2;
            this.pbtnInventory.TabStop = false;
            this.pbtnInventory.Click += new System.EventHandler(this.pbtnInventory_Click);
            // 
            // pbtnInbound
            // 
            this.pbtnInbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnInbound.BackColor = System.Drawing.Color.Transparent;
            this.pbtnInbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInbound.Image = ((System.Drawing.Image)(resources.GetObject("pbtnInbound.Image")));
            this.pbtnInbound.Location = new System.Drawing.Point(734, 41);
            this.pbtnInbound.Name = "pbtnInbound";
            this.pbtnInbound.Size = new System.Drawing.Size(69, 26);
            this.pbtnInbound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnInbound.TabIndex = 2;
            this.pbtnInbound.TabStop = false;
            this.pbtnInbound.Click += new System.EventHandler(this.pbtnInbound_Click);
            // 
            // pboxTopClient
            // 
            this.pboxTopClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxTopClient.Image = ((System.Drawing.Image)(resources.GetObject("pboxTopClient.Image")));
            this.pboxTopClient.Location = new System.Drawing.Point(384, 0);
            this.pboxTopClient.Name = "pboxTopClient";
            this.pboxTopClient.Size = new System.Drawing.Size(880, 73);
            this.pboxTopClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxTopClient.TabIndex = 1;
            this.pboxTopClient.TabStop = false;
            // 
            // pboxLogo
            // 
            this.pboxLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboxLogo.Image")));
            this.pboxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pboxLogo.InitialImage")));
            this.pboxLogo.Location = new System.Drawing.Point(0, 0);
            this.pboxLogo.Name = "pboxLogo";
            this.pboxLogo.Size = new System.Drawing.Size(384, 73);
            this.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboxLogo.TabIndex = 0;
            this.pboxLogo.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 529);
            this.Controls.Add(this.panForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "鹏斓服装库存管理系统 V3.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.tpWelcome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.panFooter.ResumeLayout(false);
            this.panFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFooterLogo)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnManageSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInvoiceSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnTranboundSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOutboundSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnTranbound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnBackSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearchSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInventorySel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOutbound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInboundSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInbound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panForm;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.PictureBox pboxLogo;
        private System.Windows.Forms.PictureBox pboxTopClient;
        private System.Windows.Forms.Panel panFooter;
        private System.Windows.Forms.PictureBox pboxFooterLogo;
        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpOutbound;
        private System.Windows.Forms.PictureBox pbtnManage;
        private System.Windows.Forms.PictureBox pbtnTranbound;
        private System.Windows.Forms.PictureBox pbtnOutbound;
        private System.Windows.Forms.PictureBox pbtnInbound;
        private System.Windows.Forms.PictureBox pbtnInventory;
        private System.Windows.Forms.PictureBox pbtnManageSel;
        private System.Windows.Forms.PictureBox pbtnTranboundSel;
        private System.Windows.Forms.PictureBox pbtnOutboundSel;
        private System.Windows.Forms.PictureBox pbtnInventorySel;
        private System.Windows.Forms.PictureBox pbtnInboundSel;
        private DevExpress.XtraTab.XtraTabPage tpInbound;
        private DevExpress.XtraTab.XtraTabPage tpTranbound;
        private DevExpress.XtraTab.XtraTabPage tpInventory;
        private DevExpress.XtraTab.XtraTabPage tpManage;
        private DevExpress.XtraTab.XtraTabPage tpWelcome;
        private DevExpress.XtraTab.XtraTabPage tpWarn;
        private System.Windows.Forms.PictureBox pbtnLogout;
        private System.Windows.Forms.PictureBox pbtnInvoiceSel;
        private System.Windows.Forms.PictureBox pbtnInvoice;
        private DevExpress.XtraTab.XtraTabPage tpInvoice;
        private System.Windows.Forms.PictureBox pbtnSearchSel;
        private System.Windows.Forms.PictureBox pbtnSearch;
        private System.Windows.Forms.PictureBox pbtnBackSel;
        private System.Windows.Forms.PictureBox pbtnBack;
        private DevExpress.XtraTab.XtraTabPage tpBackBound;
        private DevExpress.XtraTab.XtraTabPage tpSearch;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;



    }
}


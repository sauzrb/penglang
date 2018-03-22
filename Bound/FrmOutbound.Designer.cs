namespace PengLang
{
    partial class FrmOutbound
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutbound));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gbTop = new DevExpress.XtraEditors.GroupControl();
            this.panMasterBtn = new System.Windows.Forms.Panel();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnOutbound = new DevExpress.XtraEditors.SimpleButton();
            this.panSearch = new System.Windows.Forms.Panel();
            this.cboArtNoFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.txtOrderNoFilter = new DevExpress.XtraEditors.TextEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerFilter = new DevExpress.XtraEditors.TextEdit();
            this.lblBeginDate = new DevExpress.XtraEditors.LabelControl();
            this.lblArtFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomerFilter = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderNoFilter = new DevExpress.XtraEditors.LabelControl();
            this.btnCompleteOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintOut = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.panOutbundBtn = new System.Windows.Forms.Panel();
            this.panPerSellBtn = new System.Windows.Forms.Panel();
            this.btnCancelSell = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompleteSell = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextSell = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevSell = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSell = new DevExpress.XtraEditors.SimpleButton();
            this.outboundGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuMaster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMasterExportDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterPrintDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMasterExportReocrd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterPrintRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMasterExportInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterPrintInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMasterSetOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterEditOutbound = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMasterBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMasterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.outboundView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpDetail = new DevExpress.XtraTab.XtraTabPage();
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.detailView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.detailBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.tpRecord = new DevExpress.XtraTab.XtraTabPage();
            this.recordGrid = new DevExpress.XtraGrid.GridControl();
            this.ctxMenuRecord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNoCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.recordView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpProperty = new DevExpress.XtraTab.XtraTabPage();
            this.groupOutbound = new DevExpress.XtraEditors.GroupControl();
            this.btnNextCustomer = new System.Windows.Forms.Button();
            this.btnPrevCustomer = new System.Windows.Forms.Button();
            this.btnTip = new System.Windows.Forms.Button();
            this.btnRereshCustomer = new System.Windows.Forms.Button();
            this.rbSample = new System.Windows.Forms.RadioButton();
            this.rbAmazon = new System.Windows.Forms.RadioButton();
            this.rbSale = new System.Windows.Forms.RadioButton();
            this.cboSales = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboCustomerNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.nudTerm = new System.Windows.Forms.NumericUpDown();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.cboShipway = new System.Windows.Forms.ComboBox();
            this.txtOutboundNo = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtSellTo = new System.Windows.Forms.TextBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.txtShipTo = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.txtShipBy = new System.Windows.Forms.TextBox();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.labShipBy = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labCustomer = new DevExpress.XtraEditors.LabelControl();
            this.labAgent = new DevExpress.XtraEditors.LabelControl();
            this.lblSellTo = new DevExpress.XtraEditors.LabelControl();
            this.labOrder = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labTerm = new DevExpress.XtraEditors.LabelControl();
            this.labAddress = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblShipTo = new DevExpress.XtraEditors.LabelControl();
            this.labelPayment = new DevExpress.XtraEditors.LabelControl();
            this.labSellTo = new DevExpress.XtraEditors.LabelControl();
            this.tpInvoice = new DevExpress.XtraTab.XtraTabPage();
            this.invoiceGrid = new DevExpress.XtraGrid.GridControl();
            this.invoiceView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.nvoiceBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panPrintBg = new DevExpress.XtraEditors.PanelControl();
            this.btnPacking = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.tpBackDetail = new DevExpress.XtraTab.XtraTabPage();
            this.backGrid = new DevExpress.XtraGrid.GridControl();
            this.backView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ctxMenuDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).BeginInit();
            this.gbTop.SuspendLayout();
            this.panMasterBtn.SuspendLayout();
            this.panSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArtNoFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNoFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.panOutbundBtn.SuspendLayout();
            this.panPerSellBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundGrid)).BeginInit();
            this.ctxMenuMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outboundView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            this.tpRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordGrid)).BeginInit();
            this.ctxMenuRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordView)).BeginInit();
            this.tpProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupOutbound)).BeginInit();
            this.groupOutbound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomerNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerm)).BeginInit();
            this.tpInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panPrintBg)).BeginInit();
            this.panPrintBg.SuspendLayout();
            this.tpBackDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backView)).BeginInit();
            this.ctxMenuDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.panMasterBtn);
            this.gbTop.Controls.Add(this.panSearch);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.Location = new System.Drawing.Point(0, 0);
            this.gbTop.Name = "gbTop";
            this.gbTop.ShowCaption = false;
            this.gbTop.Size = new System.Drawing.Size(1263, 50);
            this.gbTop.TabIndex = 5;
            this.gbTop.Text = "检索";
            // 
            // panMasterBtn
            // 
            this.panMasterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panMasterBtn.Controls.Add(this.btnConfirm);
            this.panMasterBtn.Controls.Add(this.btnPrint);
            this.panMasterBtn.Controls.Add(this.btnOutbound);
            this.panMasterBtn.Location = new System.Drawing.Point(850, 2);
            this.panMasterBtn.Name = "panMasterBtn";
            this.panMasterBtn.Size = new System.Drawing.Size(401, 44);
            this.panMasterBtn.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(205, 7);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 31);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(297, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 31);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOutbound
            // 
            this.btnOutbound.Image = ((System.Drawing.Image)(resources.GetObject("btnOutbound.Image")));
            this.btnOutbound.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOutbound.Location = new System.Drawing.Point(111, 7);
            this.btnOutbound.Name = "btnOutbound";
            this.btnOutbound.Size = new System.Drawing.Size(86, 31);
            this.btnOutbound.TabIndex = 6;
            this.btnOutbound.Text = "Pre-Sell";
            this.btnOutbound.Click += new System.EventHandler(this.btnPreSell_Click);
            // 
            // panSearch
            // 
            this.panSearch.Controls.Add(this.cboArtNoFilter);
            this.panSearch.Controls.Add(this.btnSearch);
            this.panSearch.Controls.Add(this.dateEnd);
            this.panSearch.Controls.Add(this.txtOrderNoFilter);
            this.panSearch.Controls.Add(this.dateBegin);
            this.panSearch.Controls.Add(this.txtCustomerFilter);
            this.panSearch.Controls.Add(this.lblBeginDate);
            this.panSearch.Controls.Add(this.lblArtFilter);
            this.panSearch.Controls.Add(this.lblEndDate);
            this.panSearch.Controls.Add(this.lblCustomerFilter);
            this.panSearch.Controls.Add(this.lblOrderNoFilter);
            this.panSearch.Location = new System.Drawing.Point(0, 2);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(826, 44);
            this.panSearch.TabIndex = 7;
            // 
            // cboArtNoFilter
            // 
            this.cboArtNoFilter.Location = new System.Drawing.Point(634, 13);
            this.cboArtNoFilter.Name = "cboArtNoFilter";
            this.cboArtNoFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArtNoFilter.Size = new System.Drawing.Size(105, 20);
            this.cboArtNoFilter.TabIndex = 4;
            this.cboArtNoFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(745, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(189, 13);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 1;
            // 
            // txtOrderNoFilter
            // 
            this.txtOrderNoFilter.Location = new System.Drawing.Point(340, 13);
            this.txtOrderNoFilter.Name = "txtOrderNoFilter";
            this.txtOrderNoFilter.Size = new System.Drawing.Size(90, 20);
            this.txtOrderNoFilter.TabIndex = 2;
            this.txtOrderNoFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(65, 13);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 0;
            // 
            // txtCustomerFilter
            // 
            this.txtCustomerFilter.Location = new System.Drawing.Point(515, 13);
            this.txtCustomerFilter.Name = "txtCustomerFilter";
            this.txtCustomerFilter.Size = new System.Drawing.Size(74, 20);
            this.txtCustomerFilter.TabIndex = 3;
            this.txtCustomerFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(5, 15);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(61, 14);
            this.lblBeginDate.TabIndex = 1;
            this.lblBeginDate.Text = "ShipDate：";
            // 
            // lblArtFilter
            // 
            this.lblArtFilter.Location = new System.Drawing.Point(595, 16);
            this.lblArtFilter.Name = "lblArtFilter";
            this.lblArtFilter.Size = new System.Drawing.Size(38, 14);
            this.lblArtFilter.TabIndex = 1;
            this.lblArtFilter.Text = "Art#：";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(168, 15);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(15, 14);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "To";
            // 
            // lblCustomerFilter
            // 
            this.lblCustomerFilter.Location = new System.Drawing.Point(437, 16);
            this.lblCustomerFilter.Name = "lblCustomerFilter";
            this.lblCustomerFilter.Size = new System.Drawing.Size(73, 14);
            this.lblCustomerFilter.TabIndex = 1;
            this.lblCustomerFilter.Text = "Customer#：";
            // 
            // lblOrderNoFilter
            // 
            this.lblOrderNoFilter.Location = new System.Drawing.Point(296, 16);
            this.lblOrderNoFilter.Name = "lblOrderNoFilter";
            this.lblOrderNoFilter.Size = new System.Drawing.Size(41, 14);
            this.lblOrderNoFilter.TabIndex = 1;
            this.lblOrderNoFilter.Text = "P.O#：";
            // 
            // btnCompleteOut
            // 
            this.btnCompleteOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleteOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteOut.Image")));
            this.btnCompleteOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCompleteOut.Location = new System.Drawing.Point(205, 7);
            this.btnCompleteOut.Name = "btnCompleteOut";
            this.btnCompleteOut.Size = new System.Drawing.Size(86, 31);
            this.btnCompleteOut.TabIndex = 10;
            this.btnCompleteOut.Text = "Complete";
            this.btnCompleteOut.Click += new System.EventHandler(this.btnCompleteOut_Click);
            // 
            // btnNextOut
            // 
            this.btnNextOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextOut.Image = ((System.Drawing.Image)(resources.GetObject("btnNextOut.Image")));
            this.btnNextOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNextOut.Location = new System.Drawing.Point(205, 7);
            this.btnNextOut.Name = "btnNextOut";
            this.btnNextOut.Size = new System.Drawing.Size(86, 31);
            this.btnNextOut.TabIndex = 9;
            this.btnNextOut.Text = "Next";
            this.btnNextOut.Click += new System.EventHandler(this.btnNextOut_Click);
            // 
            // btnPrevOut
            // 
            this.btnPrevOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevOut.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevOut.Image")));
            this.btnPrevOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrevOut.Location = new System.Drawing.Point(111, 7);
            this.btnPrevOut.Name = "btnPrevOut";
            this.btnPrevOut.Size = new System.Drawing.Size(86, 31);
            this.btnPrevOut.TabIndex = 8;
            this.btnPrevOut.Text = "Prev";
            this.btnPrevOut.Click += new System.EventHandler(this.btnPrevOut_Click);
            // 
            // btnCancelOut
            // 
            this.btnCancelOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelOut.Image")));
            this.btnCancelOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelOut.Location = new System.Drawing.Point(297, 7);
            this.btnCancelOut.Name = "btnCancelOut";
            this.btnCancelOut.Size = new System.Drawing.Size(86, 31);
            this.btnCancelOut.TabIndex = 11;
            this.btnCancelOut.Text = "Cancel";
            this.btnCancelOut.Click += new System.EventHandler(this.btnCancelOut_Click);
            // 
            // btnPrintOut
            // 
            this.btnPrintOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintOut.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintOut.Image")));
            this.btnPrintOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrintOut.Location = new System.Drawing.Point(18, 7);
            this.btnPrintOut.Name = "btnPrintOut";
            this.btnPrintOut.Size = new System.Drawing.Size(86, 31);
            this.btnPrintOut.TabIndex = 12;
            this.btnPrintOut.Text = "Print";
            this.btnPrintOut.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer.Horizontal = false;
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.panOutbundBtn);
            this.splitContainer.Panel1.Controls.Add(this.panPerSellBtn);
            this.splitContainer.Panel1.Controls.Add(this.outboundGrid);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.xtraTab);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(1263, 549);
            this.splitContainer.SplitterPosition = 188;
            this.splitContainer.TabIndex = 10;
            // 
            // panOutbundBtn
            // 
            this.panOutbundBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panOutbundBtn.Controls.Add(this.btnPrevOut);
            this.panOutbundBtn.Controls.Add(this.btnCompleteOut);
            this.panOutbundBtn.Controls.Add(this.btnNextOut);
            this.panOutbundBtn.Controls.Add(this.btnCancelOut);
            this.panOutbundBtn.Controls.Add(this.btnPrintOut);
            this.panOutbundBtn.Location = new System.Drawing.Point(850, 57);
            this.panOutbundBtn.Name = "panOutbundBtn";
            this.panOutbundBtn.Size = new System.Drawing.Size(401, 44);
            this.panOutbundBtn.TabIndex = 5;
            // 
            // panPerSellBtn
            // 
            this.panPerSellBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panPerSellBtn.Controls.Add(this.btnCancelSell);
            this.panPerSellBtn.Controls.Add(this.btnCompleteSell);
            this.panPerSellBtn.Controls.Add(this.btnNextSell);
            this.panPerSellBtn.Controls.Add(this.btnPrevSell);
            this.panPerSellBtn.Controls.Add(this.btnPrintSell);
            this.panPerSellBtn.Location = new System.Drawing.Point(850, 6);
            this.panPerSellBtn.Name = "panPerSellBtn";
            this.panPerSellBtn.Size = new System.Drawing.Size(401, 44);
            this.panPerSellBtn.TabIndex = 4;
            // 
            // btnCancelSell
            // 
            this.btnCancelSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSell.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelSell.Image")));
            this.btnCancelSell.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelSell.Location = new System.Drawing.Point(297, 7);
            this.btnCancelSell.Name = "btnCancelSell";
            this.btnCancelSell.Size = new System.Drawing.Size(86, 31);
            this.btnCancelSell.TabIndex = 11;
            this.btnCancelSell.Text = "Cancel";
            this.btnCancelSell.Click += new System.EventHandler(this.btnCancelSell_Click);
            // 
            // btnCompleteSell
            // 
            this.btnCompleteSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleteSell.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteSell.Image")));
            this.btnCompleteSell.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCompleteSell.Location = new System.Drawing.Point(205, 7);
            this.btnCompleteSell.Name = "btnCompleteSell";
            this.btnCompleteSell.Size = new System.Drawing.Size(86, 31);
            this.btnCompleteSell.TabIndex = 10;
            this.btnCompleteSell.Text = "Complete";
            this.btnCompleteSell.Click += new System.EventHandler(this.btnCompleteSell_Click);
            // 
            // btnNextSell
            // 
            this.btnNextSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSell.Image = ((System.Drawing.Image)(resources.GetObject("btnNextSell.Image")));
            this.btnNextSell.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNextSell.Location = new System.Drawing.Point(205, 7);
            this.btnNextSell.Name = "btnNextSell";
            this.btnNextSell.Size = new System.Drawing.Size(86, 31);
            this.btnNextSell.TabIndex = 9;
            this.btnNextSell.Text = "Next";
            this.btnNextSell.Click += new System.EventHandler(this.btnNextSell_Click);
            // 
            // btnPrevSell
            // 
            this.btnPrevSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevSell.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevSell.Image")));
            this.btnPrevSell.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrevSell.Location = new System.Drawing.Point(111, 7);
            this.btnPrevSell.Name = "btnPrevSell";
            this.btnPrevSell.Size = new System.Drawing.Size(86, 31);
            this.btnPrevSell.TabIndex = 8;
            this.btnPrevSell.Text = "Prev";
            this.btnPrevSell.Click += new System.EventHandler(this.btnPrevSell_Click);
            // 
            // btnPrintSell
            // 
            this.btnPrintSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSell.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSell.Image")));
            this.btnPrintSell.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrintSell.Location = new System.Drawing.Point(18, 7);
            this.btnPrintSell.Name = "btnPrintSell";
            this.btnPrintSell.Size = new System.Drawing.Size(86, 31);
            this.btnPrintSell.TabIndex = 12;
            this.btnPrintSell.Text = "Print";
            this.btnPrintSell.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // outboundGrid
            // 
            this.outboundGrid.ContextMenuStrip = this.ctxMenuMaster;
            this.outboundGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.outboundGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.outboundGrid.Location = new System.Drawing.Point(0, 0);
            this.outboundGrid.MainView = this.outboundView;
            this.outboundGrid.Name = "outboundGrid";
            this.outboundGrid.Size = new System.Drawing.Size(1263, 188);
            this.outboundGrid.TabIndex = 3;
            this.outboundGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.outboundView});
            // 
            // ctxMenuMaster
            // 
            this.ctxMenuMaster.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasterExportDetail,
            this.mnuMasterPrintDetail,
            this.toolStripSeparator3,
            this.mnuMasterExportReocrd,
            this.mnuMasterPrintRecord,
            this.toolStripSeparator4,
            this.mnuMasterExportInvoice,
            this.mnuMasterPrintInvoice,
            this.toolStripSeparator2,
            this.mnuMasterSetOperator,
            this.mnuMasterEditOutbound,
            this.mnuMasterComplete,
            this.toolStripSeparator5,
            this.mnuMasterBack,
            this.toolStripSeparator1,
            this.mnuMasterDelete});
            this.ctxMenuMaster.Name = "ctxMenuMaster";
            this.ctxMenuMaster.Size = new System.Drawing.Size(149, 276);
            this.ctxMenuMaster.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuMaster_Opening);
            // 
            // mnuMasterExportDetail
            // 
            this.mnuMasterExportDetail.Name = "mnuMasterExportDetail";
            this.mnuMasterExportDetail.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterExportDetail.Text = "导出出库明细";
            this.mnuMasterExportDetail.Click += new System.EventHandler(this.mnuMasterExportDetail_Click);
            // 
            // mnuMasterPrintDetail
            // 
            this.mnuMasterPrintDetail.Name = "mnuMasterPrintDetail";
            this.mnuMasterPrintDetail.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterPrintDetail.Text = "打印出库明细";
            this.mnuMasterPrintDetail.Click += new System.EventHandler(this.mnuMasterPrintDetail_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuMasterExportReocrd
            // 
            this.mnuMasterExportReocrd.Name = "mnuMasterExportReocrd";
            this.mnuMasterExportReocrd.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterExportReocrd.Text = "导出操作单";
            this.mnuMasterExportReocrd.Click += new System.EventHandler(this.mnuMasterExportReocrd_Click);
            // 
            // mnuMasterPrintRecord
            // 
            this.mnuMasterPrintRecord.Name = "mnuMasterPrintRecord";
            this.mnuMasterPrintRecord.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterPrintRecord.Text = "打印操作单";
            this.mnuMasterPrintRecord.Click += new System.EventHandler(this.mnuMasterPrintRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuMasterExportInvoice
            // 
            this.mnuMasterExportInvoice.Name = "mnuMasterExportInvoice";
            this.mnuMasterExportInvoice.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterExportInvoice.Text = "导出发票";
            this.mnuMasterExportInvoice.Click += new System.EventHandler(this.mnuMasterExportInvoice_Click);
            // 
            // mnuMasterPrintInvoice
            // 
            this.mnuMasterPrintInvoice.Name = "mnuMasterPrintInvoice";
            this.mnuMasterPrintInvoice.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterPrintInvoice.Text = "打印发票";
            this.mnuMasterPrintInvoice.Click += new System.EventHandler(this.mnuMasterPrintInvoice_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuMasterSetOperator
            // 
            this.mnuMasterSetOperator.Name = "mnuMasterSetOperator";
            this.mnuMasterSetOperator.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterSetOperator.Text = "重设操作员";
            this.mnuMasterSetOperator.Click += new System.EventHandler(this.mnuMasterSetOperator_Click);
            // 
            // mnuMasterEditOutbound
            // 
            this.mnuMasterEditOutbound.Name = "mnuMasterEditOutbound";
            this.mnuMasterEditOutbound.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterEditOutbound.Text = "修改出库单";
            this.mnuMasterEditOutbound.Click += new System.EventHandler(this.mnuMasterEditOutbound_Click);
            // 
            // mnuMasterComplete
            // 
            this.mnuMasterComplete.Name = "mnuMasterComplete";
            this.mnuMasterComplete.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterComplete.Text = "完成出库单";
            this.mnuMasterComplete.Click += new System.EventHandler(this.mnuMasterComplete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuMasterBack
            // 
            this.mnuMasterBack.Name = "mnuMasterBack";
            this.mnuMasterBack.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterBack.Text = "退货";
            this.mnuMasterBack.Click += new System.EventHandler(this.mnuMasterBack_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuMasterDelete
            // 
            this.mnuMasterDelete.Name = "mnuMasterDelete";
            this.mnuMasterDelete.Size = new System.Drawing.Size(148, 22);
            this.mnuMasterDelete.Text = "删除";
            this.mnuMasterDelete.Click += new System.EventHandler(this.mnuMasterDelete_Click);
            // 
            // outboundView
            // 
            this.outboundView.GridControl = this.outboundGrid;
            this.outboundView.Name = "outboundView";
            this.outboundView.OptionsView.ShowGroupPanel = false;
            this.outboundView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.outboundView_FocusedRowChanged);
            // 
            // xtraTab
            // 
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Close | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTab.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Never;
            this.xtraTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpDetail;
            this.xtraTab.Size = new System.Drawing.Size(1263, 356);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDetail,
            this.tpRecord,
            this.tpProperty,
            this.tpInvoice,
            this.tpBackDetail});
            this.xtraTab.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTab_SelectedPageChanged);
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.detailGrid);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(1257, 327);
            this.tpDetail.Text = "出库明细表";
            // 
            // detailGrid
            // 
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.Location = new System.Drawing.Point(0, 0);
            this.detailGrid.MainView = this.detailView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(1257, 327);
            this.detailGrid.TabIndex = 0;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailView});
            // 
            // detailView
            // 
            this.detailView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.detailBand});
            this.detailView.ColumnPanelRowHeight = 10;
            this.detailView.GridControl = this.detailGrid;
            this.detailView.Name = "detailView";
            this.detailView.OptionsView.ShowGroupPanel = false;
            this.detailView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.detailView_KeyUp);
            // 
            // detailBand
            // 
            this.detailBand.Name = "detailBand";
            this.detailBand.VisibleIndex = 0;
            // 
            // tpRecord
            // 
            this.tpRecord.Controls.Add(this.recordGrid);
            this.tpRecord.Name = "tpRecord";
            this.tpRecord.Size = new System.Drawing.Size(1257, 327);
            this.tpRecord.Text = "出库操作单";
            // 
            // recordGrid
            // 
            this.recordGrid.ContextMenuStrip = this.ctxMenuRecord;
            this.recordGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordGrid.Location = new System.Drawing.Point(0, 0);
            this.recordGrid.MainView = this.recordView;
            this.recordGrid.Name = "recordGrid";
            this.recordGrid.Size = new System.Drawing.Size(1257, 327);
            this.recordGrid.TabIndex = 0;
            this.recordGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.recordView});
            // 
            // ctxMenuRecord
            // 
            this.ctxMenuRecord.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuRecord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckAll,
            this.mnuNoCheck});
            this.ctxMenuRecord.Name = "ctxMenuDetail";
            this.ctxMenuRecord.Size = new System.Drawing.Size(101, 48);
            this.ctxMenuRecord.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuRecord_Opening);
            // 
            // mnuCheckAll
            // 
            this.mnuCheckAll.Name = "mnuCheckAll";
            this.mnuCheckAll.Size = new System.Drawing.Size(100, 22);
            this.mnuCheckAll.Text = "全选";
            this.mnuCheckAll.Click += new System.EventHandler(this.mnuCheckAll_Click);
            // 
            // mnuNoCheck
            // 
            this.mnuNoCheck.Name = "mnuNoCheck";
            this.mnuNoCheck.Size = new System.Drawing.Size(100, 22);
            this.mnuNoCheck.Text = "不选";
            this.mnuNoCheck.Click += new System.EventHandler(this.mnuNoCheck_Click);
            // 
            // recordView
            // 
            this.recordView.GridControl = this.recordGrid;
            this.recordView.Name = "recordView";
            this.recordView.OptionsView.ShowGroupPanel = false;
            // 
            // tpProperty
            // 
            this.tpProperty.Controls.Add(this.groupOutbound);
            this.tpProperty.Name = "tpProperty";
            this.tpProperty.Size = new System.Drawing.Size(1257, 327);
            this.tpProperty.Text = "出库单信息";
            this.tpProperty.Resize += new System.EventHandler(this.tpPrintSet_Resize);
            // 
            // groupOutbound
            // 
            this.groupOutbound.Controls.Add(this.btnNextCustomer);
            this.groupOutbound.Controls.Add(this.btnPrevCustomer);
            this.groupOutbound.Controls.Add(this.btnTip);
            this.groupOutbound.Controls.Add(this.btnRereshCustomer);
            this.groupOutbound.Controls.Add(this.rbSample);
            this.groupOutbound.Controls.Add(this.rbAmazon);
            this.groupOutbound.Controls.Add(this.rbSale);
            this.groupOutbound.Controls.Add(this.cboSales);
            this.groupOutbound.Controls.Add(this.cboCustomerNo);
            this.groupOutbound.Controls.Add(this.nudTerm);
            this.groupOutbound.Controls.Add(this.cboPayment);
            this.groupOutbound.Controls.Add(this.cboShipway);
            this.groupOutbound.Controls.Add(this.txtOutboundNo);
            this.groupOutbound.Controls.Add(this.txtAddr);
            this.groupOutbound.Controls.Add(this.txtSellTo);
            this.groupOutbound.Controls.Add(this.txtOrderNo);
            this.groupOutbound.Controls.Add(this.txtShipTo);
            this.groupOutbound.Controls.Add(this.txtFreight);
            this.groupOutbound.Controls.Add(this.txtShipBy);
            this.groupOutbound.Controls.Add(this.txtTrackingNo);
            this.groupOutbound.Controls.Add(this.labShipBy);
            this.groupOutbound.Controls.Add(this.labelControl5);
            this.groupOutbound.Controls.Add(this.labCustomer);
            this.groupOutbound.Controls.Add(this.labAgent);
            this.groupOutbound.Controls.Add(this.lblSellTo);
            this.groupOutbound.Controls.Add(this.labOrder);
            this.groupOutbound.Controls.Add(this.labelControl4);
            this.groupOutbound.Controls.Add(this.labelControl2);
            this.groupOutbound.Controls.Add(this.labTerm);
            this.groupOutbound.Controls.Add(this.labAddress);
            this.groupOutbound.Controls.Add(this.labelControl3);
            this.groupOutbound.Controls.Add(this.lblShipTo);
            this.groupOutbound.Controls.Add(this.labelPayment);
            this.groupOutbound.Controls.Add(this.labSellTo);
            this.groupOutbound.Location = new System.Drawing.Point(236, 23);
            this.groupOutbound.Name = "groupOutbound";
            this.groupOutbound.Size = new System.Drawing.Size(765, 301);
            this.groupOutbound.TabIndex = 2;
            this.groupOutbound.Text = "请填写出库单信息";
            // 
            // btnNextCustomer
            // 
            this.btnNextCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnNextCustomer.Image")));
            this.btnNextCustomer.Location = new System.Drawing.Point(358, 196);
            this.btnNextCustomer.Name = "btnNextCustomer";
            this.btnNextCustomer.Size = new System.Drawing.Size(27, 25);
            this.btnNextCustomer.TabIndex = 15;
            this.btnNextCustomer.UseVisualStyleBackColor = true;
            this.btnNextCustomer.Click += new System.EventHandler(this.btnNextCustomer_Click);
            // 
            // btnPrevCustomer
            // 
            this.btnPrevCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevCustomer.Image")));
            this.btnPrevCustomer.Location = new System.Drawing.Point(358, 152);
            this.btnPrevCustomer.Name = "btnPrevCustomer";
            this.btnPrevCustomer.Size = new System.Drawing.Size(27, 25);
            this.btnPrevCustomer.TabIndex = 15;
            this.btnPrevCustomer.UseVisualStyleBackColor = true;
            this.btnPrevCustomer.Click += new System.EventHandler(this.btnPrevCustomer_Click);
            // 
            // btnTip
            // 
            this.btnTip.Image = ((System.Drawing.Image)(resources.GetObject("btnTip.Image")));
            this.btnTip.Location = new System.Drawing.Point(330, 60);
            this.btnTip.Name = "btnTip";
            this.btnTip.Size = new System.Drawing.Size(27, 25);
            this.btnTip.TabIndex = 15;
            this.btnTip.UseVisualStyleBackColor = true;
            this.btnTip.Click += new System.EventHandler(this.btnTip_Click);
            // 
            // btnRereshCustomer
            // 
            this.btnRereshCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnRereshCustomer.Image")));
            this.btnRereshCustomer.Location = new System.Drawing.Point(328, 119);
            this.btnRereshCustomer.Name = "btnRereshCustomer";
            this.btnRereshCustomer.Size = new System.Drawing.Size(27, 25);
            this.btnRereshCustomer.TabIndex = 15;
            this.btnRereshCustomer.UseVisualStyleBackColor = true;
            this.btnRereshCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // rbSample
            // 
            this.rbSample.AutoSize = true;
            this.rbSample.Location = new System.Drawing.Point(328, 36);
            this.rbSample.Name = "rbSample";
            this.rbSample.Size = new System.Drawing.Size(69, 18);
            this.rbSample.TabIndex = 3;
            this.rbSample.Text = "SAMPLE";
            this.rbSample.UseVisualStyleBackColor = true;
            this.rbSample.CheckedChanged += new System.EventHandler(this.rbSaleMode_CheckedChanged);
            // 
            // rbAmazon
            // 
            this.rbAmazon.AutoSize = true;
            this.rbAmazon.Location = new System.Drawing.Point(242, 36);
            this.rbAmazon.Name = "rbAmazon";
            this.rbAmazon.Size = new System.Drawing.Size(74, 18);
            this.rbAmazon.TabIndex = 2;
            this.rbAmazon.Text = "AMAZON";
            this.rbAmazon.UseVisualStyleBackColor = true;
            this.rbAmazon.CheckedChanged += new System.EventHandler(this.rbSaleMode_CheckedChanged);
            // 
            // rbSale
            // 
            this.rbSale.AutoSize = true;
            this.rbSale.Checked = true;
            this.rbSale.Location = new System.Drawing.Point(113, 36);
            this.rbSale.Name = "rbSale";
            this.rbSale.Size = new System.Drawing.Size(117, 18);
            this.rbSale.TabIndex = 1;
            this.rbSale.TabStop = true;
            this.rbSale.Text = "SOLD TO BUYER";
            this.rbSale.UseVisualStyleBackColor = true;
            this.rbSale.CheckedChanged += new System.EventHandler(this.rbSaleMode_CheckedChanged);
            // 
            // cboSales
            // 
            this.cboSales.Location = new System.Drawing.Point(465, 65);
            this.cboSales.Name = "cboSales";
            this.cboSales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSales.Size = new System.Drawing.Size(276, 20);
            this.cboSales.TabIndex = 4;
            // 
            // cboCustomerNo
            // 
            this.cboCustomerNo.Location = new System.Drawing.Point(113, 94);
            this.cboCustomerNo.Name = "cboCustomerNo";
            this.cboCustomerNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomerNo.Size = new System.Drawing.Size(243, 20);
            this.cboCustomerNo.TabIndex = 8;
            // 
            // nudTerm
            // 
            this.nudTerm.Location = new System.Drawing.Point(268, 229);
            this.nudTerm.Name = "nudTerm";
            this.nudTerm.Size = new System.Drawing.Size(55, 22);
            this.nudTerm.TabIndex = 21;
            // 
            // cboPayment
            // 
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Items.AddRange(new object[] {
            "FAC",
            "CHECK",
            "CREDET",
            "CASH"});
            this.cboPayment.Location = new System.Drawing.Point(113, 257);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(108, 22);
            this.cboPayment.TabIndex = 20;
            // 
            // cboShipway
            // 
            this.cboShipway.FormattingEnabled = true;
            this.cboShipway.Items.AddRange(new object[] {
            "Standing box",
            "Regular box"});
            this.cboShipway.Location = new System.Drawing.Point(113, 229);
            this.cboShipway.Name = "cboShipway";
            this.cboShipway.Size = new System.Drawing.Size(108, 22);
            this.cboShipway.TabIndex = 20;
            this.cboShipway.Text = "Regular box";
            // 
            // txtOutboundNo
            // 
            this.txtOutboundNo.Location = new System.Drawing.Point(44, 32);
            this.txtOutboundNo.Name = "txtOutboundNo";
            this.txtOutboundNo.ReadOnly = true;
            this.txtOutboundNo.Size = new System.Drawing.Size(48, 22);
            this.txtOutboundNo.TabIndex = 0;
            this.txtOutboundNo.TabStop = false;
            this.txtOutboundNo.Visible = false;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(113, 150);
            this.txtAddr.Multiline = true;
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(243, 71);
            this.txtAddr.TabIndex = 10;
            // 
            // txtSellTo
            // 
            this.txtSellTo.Location = new System.Drawing.Point(113, 121);
            this.txtSellTo.Name = "txtSellTo";
            this.txtSellTo.Size = new System.Drawing.Size(210, 22);
            this.txtSellTo.TabIndex = 9;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(113, 63);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(210, 22);
            this.txtOrderNo.TabIndex = 3;
            // 
            // txtShipTo
            // 
            this.txtShipTo.Location = new System.Drawing.Point(465, 150);
            this.txtShipTo.Multiline = true;
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(276, 71);
            this.txtShipTo.TabIndex = 13;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(465, 229);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(95, 22);
            this.txtFreight.TabIndex = 22;
            this.txtFreight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreight_KeyPress);
            // 
            // txtShipBy
            // 
            this.txtShipBy.Location = new System.Drawing.Point(465, 121);
            this.txtShipBy.Name = "txtShipBy";
            this.txtShipBy.Size = new System.Drawing.Size(276, 22);
            this.txtShipBy.TabIndex = 12;
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(465, 94);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(276, 22);
            this.txtTrackingNo.TabIndex = 11;
            // 
            // labShipBy
            // 
            this.labShipBy.Location = new System.Drawing.Point(405, 125);
            this.labShipBy.Name = "labShipBy";
            this.labShipBy.Size = new System.Drawing.Size(57, 14);
            this.labShipBy.TabIndex = 3;
            this.labShipBy.Text = "SHIP BY：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(384, 99);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(78, 14);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "TRACKING#：";
            // 
            // labCustomer
            // 
            this.labCustomer.Location = new System.Drawing.Point(26, 97);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new System.Drawing.Size(83, 14);
            this.labCustomer.TabIndex = 3;
            this.labCustomer.Text = "CUSTOMER#：";
            // 
            // labAgent
            // 
            this.labAgent.Location = new System.Drawing.Point(415, 67);
            this.labAgent.Name = "labAgent";
            this.labAgent.Size = new System.Drawing.Size(47, 14);
            this.labAgent.TabIndex = 3;
            this.labAgent.Text = "SALES：";
            // 
            // lblSellTo
            // 
            this.lblSellTo.Location = new System.Drawing.Point(50, 125);
            this.lblSellTo.Name = "lblSellTo";
            this.lblSellTo.Size = new System.Drawing.Size(59, 14);
            this.lblSellTo.TabIndex = 3;
            this.lblSellTo.Text = "SELL TO：";
            // 
            // labOrder
            // 
            this.labOrder.Location = new System.Drawing.Point(68, 66);
            this.labOrder.Name = "labOrder";
            this.labOrder.Size = new System.Drawing.Size(41, 14);
            this.labOrder.TabIndex = 3;
            this.labOrder.Text = "P.O#：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(565, 232);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "( $ )";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(326, 232);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "DAYS";
            // 
            // labTerm
            // 
            this.labTerm.Location = new System.Drawing.Point(225, 232);
            this.labTerm.Name = "labTerm";
            this.labTerm.Size = new System.Drawing.Size(43, 14);
            this.labTerm.TabIndex = 3;
            this.labTerm.Text = "TERM：";
            // 
            // labAddress
            // 
            this.labAddress.Location = new System.Drawing.Point(45, 152);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(64, 14);
            this.labAddress.TabIndex = 3;
            this.labAddress.Text = "ADDRESS：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(397, 232);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "SHIPPING：";
            // 
            // lblShipTo
            // 
            this.lblShipTo.Location = new System.Drawing.Point(403, 152);
            this.lblShipTo.Name = "lblShipTo";
            this.lblShipTo.Size = new System.Drawing.Size(59, 14);
            this.lblShipTo.TabIndex = 3;
            this.lblShipTo.Text = "SHIP TO：";
            // 
            // labelPayment
            // 
            this.labelPayment.Location = new System.Drawing.Point(12, 263);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Size = new System.Drawing.Size(104, 14);
            this.labelPayment.TabIndex = 3;
            this.labelPayment.Text = "PAYMENT MODE：";
            // 
            // labSellTo
            // 
            this.labSellTo.Location = new System.Drawing.Point(12, 234);
            this.labSellTo.Name = "labSellTo";
            this.labSellTo.Size = new System.Drawing.Size(97, 14);
            this.labSellTo.TabIndex = 3;
            this.labSellTo.Text = "SHIPPING WAY：";
            // 
            // tpInvoice
            // 
            this.tpInvoice.Controls.Add(this.invoiceGrid);
            this.tpInvoice.Controls.Add(this.panPrintBg);
            this.tpInvoice.Name = "tpInvoice";
            this.tpInvoice.Size = new System.Drawing.Size(1257, 327);
            this.tpInvoice.Text = "发票明细";
            // 
            // invoiceGrid
            // 
            this.invoiceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceGrid.Location = new System.Drawing.Point(0, 46);
            this.invoiceGrid.MainView = this.invoiceView;
            this.invoiceGrid.Name = "invoiceGrid";
            this.invoiceGrid.Size = new System.Drawing.Size(1257, 281);
            this.invoiceGrid.TabIndex = 1;
            this.invoiceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.invoiceView});
            // 
            // invoiceView
            // 
            this.invoiceView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.nvoiceBand});
            this.invoiceView.GridControl = this.invoiceGrid;
            this.invoiceView.Name = "invoiceView";
            this.invoiceView.OptionsView.ShowGroupPanel = false;
            // 
            // nvoiceBand
            // 
            this.nvoiceBand.Caption = "invoiceBand";
            this.nvoiceBand.Name = "nvoiceBand";
            this.nvoiceBand.VisibleIndex = 0;
            // 
            // panPrintBg
            // 
            this.panPrintBg.Controls.Add(this.btnPacking);
            this.panPrintBg.Controls.Add(this.btnSaveInvoice);
            this.panPrintBg.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPrintBg.Location = new System.Drawing.Point(0, 0);
            this.panPrintBg.Name = "panPrintBg";
            this.panPrintBg.Size = new System.Drawing.Size(1257, 46);
            this.panPrintBg.TabIndex = 0;
            // 
            // btnPacking
            // 
            this.btnPacking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPacking.Image = ((System.Drawing.Image)(resources.GetObject("btnPacking.Image")));
            this.btnPacking.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPacking.Location = new System.Drawing.Point(1086, 7);
            this.btnPacking.Name = "btnPacking";
            this.btnPacking.Size = new System.Drawing.Size(79, 31);
            this.btnPacking.TabIndex = 4;
            this.btnPacking.Text = "Packing";
            this.btnPacking.Click += new System.EventHandler(this.btnPacking_Click);
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveInvoice.Image")));
            this.btnSaveInvoice.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSaveInvoice.Location = new System.Drawing.Point(1174, 7);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(79, 31);
            this.btnSaveInvoice.TabIndex = 4;
            this.btnSaveInvoice.Text = "Save";
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // tpBackDetail
            // 
            this.tpBackDetail.Controls.Add(this.backGrid);
            this.tpBackDetail.Name = "tpBackDetail";
            this.tpBackDetail.Size = new System.Drawing.Size(1257, 327);
            this.tpBackDetail.Text = "退货明细";
            // 
            // backGrid
            // 
            this.backGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backGrid.Location = new System.Drawing.Point(0, 0);
            this.backGrid.MainView = this.backView;
            this.backGrid.Name = "backGrid";
            this.backGrid.Size = new System.Drawing.Size(1257, 327);
            this.backGrid.TabIndex = 2;
            this.backGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.backView});
            // 
            // backView
            // 
            this.backView.GridControl = this.backGrid;
            this.backView.Name = "backView";
            this.backView.OptionsView.ShowGroupPanel = false;
            // 
            // ctxMenuDetail
            // 
            this.ctxMenuDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertRow,
            this.mnuDeleteRow});
            this.ctxMenuDetail.Name = "ctxMenu";
            this.ctxMenuDetail.Size = new System.Drawing.Size(101, 48);
            // 
            // mnuInsertRow
            // 
            this.mnuInsertRow.Name = "mnuInsertRow";
            this.mnuInsertRow.Size = new System.Drawing.Size(100, 22);
            this.mnuInsertRow.Text = "插入";
            this.mnuInsertRow.Click += new System.EventHandler(this.mnuInsertRow_Click);
            // 
            // mnuDeleteRow
            // 
            this.mnuDeleteRow.Name = "mnuDeleteRow";
            this.mnuDeleteRow.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteRow.Text = "删除";
            this.mnuDeleteRow.Click += new System.EventHandler(this.mnuDeleteRow_Click);
            // 
            // FrmOutbound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 599);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.gbTop);
            this.Name = "FrmOutbound";
            this.Text = "出库";
            this.Load += new System.EventHandler(this.FrmOutbound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbTop)).EndInit();
            this.gbTop.ResumeLayout(false);
            this.panMasterBtn.ResumeLayout(false);
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArtNoFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNoFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panOutbundBtn.ResumeLayout(false);
            this.panPerSellBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outboundGrid)).EndInit();
            this.ctxMenuMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outboundView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            this.tpRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordGrid)).EndInit();
            this.ctxMenuRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordView)).EndInit();
            this.tpProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupOutbound)).EndInit();
            this.groupOutbound.ResumeLayout(false);
            this.groupOutbound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomerNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTerm)).EndInit();
            this.tpInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panPrintBg)).EndInit();
            this.panPrintBg.ResumeLayout(false);
            this.tpBackDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backView)).EndInit();
            this.ctxMenuDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTop;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.SimpleButton btnCompleteOut;
        private DevExpress.XtraEditors.SimpleButton btnCancelOut;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnOutbound;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblOrderNoFilter;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblBeginDate;
        private DevExpress.XtraEditors.TextEdit txtOrderNoFilter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpDetail;
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView detailView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand detailBand;
        private DevExpress.XtraTab.XtraTabPage tpRecord;
        private DevExpress.XtraGrid.GridControl recordGrid;
        private DevExpress.XtraGrid.GridControl outboundGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView outboundView;
        private DevExpress.XtraEditors.SimpleButton btnPrevOut;
        private DevExpress.XtraEditors.SimpleButton btnNextOut;
        private DevExpress.XtraGrid.Views.Grid.GridView recordView;
        private DevExpress.XtraTab.XtraTabPage tpProperty;
        private DevExpress.XtraEditors.GroupControl groupOutbound;
        private System.Windows.Forms.TextBox txtOutboundNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private DevExpress.XtraEditors.LabelControl labOrder;
        private DevExpress.XtraEditors.LabelControl labSellTo;
        private DevExpress.XtraTab.XtraTabPage tpInvoice;
        private DevExpress.XtraGrid.GridControl invoiceGrid;
        private DevExpress.XtraEditors.PanelControl panPrintBg;
        private DevExpress.XtraEditors.LabelControl lblCustomerFilter;
        private DevExpress.XtraEditors.TextEdit txtCustomerFilter;
        private System.Windows.Forms.ContextMenuStrip ctxMenuMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterExportDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterPrintDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterExportReocrd;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterPrintRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterSetOperator;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckAll;
        private System.Windows.Forms.ToolStripMenuItem mnuNoCheck;
        private System.Windows.Forms.ContextMenuStrip ctxMenuDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertRow;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRow;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView invoiceView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand nvoiceBand;
        private DevExpress.XtraEditors.SimpleButton btnSaveInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterExportInvoice;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterPrintInvoice;
        private System.Windows.Forms.TextBox txtShipTo;
        private DevExpress.XtraEditors.LabelControl lblShipTo;
        private System.Windows.Forms.TextBox txtAddr;
        private DevExpress.XtraEditors.LabelControl lblSellTo;
        private System.Windows.Forms.ComboBox cboShipway;
        private DevExpress.XtraEditors.LabelControl labTerm;
        private System.Windows.Forms.NumericUpDown nudTerm;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labAddress;
        private System.Windows.Forms.TextBox txtFreight;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterEditOutbound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterBack;
        private DevExpress.XtraTab.XtraTabPage tpBackDetail;
        private DevExpress.XtraGrid.GridControl backGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView backView;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterComplete;
        private System.Windows.Forms.RadioButton rbSale;
        private DevExpress.XtraEditors.LabelControl lblArtFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cboArtNoFilter;
        private System.Windows.Forms.ToolStripMenuItem mnuMasterDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnPrintOut;
        private DevExpress.XtraEditors.ComboBoxEdit cboSales;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labAgent;
        private System.Windows.Forms.Button btnRereshCustomer;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomerNo;
        private DevExpress.XtraEditors.LabelControl labCustomer;
        private System.Windows.Forms.TextBox txtShipBy;
        private DevExpress.XtraEditors.LabelControl labShipBy;
        private DevExpress.XtraEditors.SimpleButton btnPacking;
        private System.Windows.Forms.TextBox txtSellTo;
        private System.Windows.Forms.Button btnNextCustomer;
        private System.Windows.Forms.Button btnPrevCustomer;
        private System.Windows.Forms.Button btnTip;
        private System.Windows.Forms.Panel panPerSellBtn;
        private DevExpress.XtraEditors.SimpleButton btnCancelSell;
        private DevExpress.XtraEditors.SimpleButton btnCompleteSell;
        private DevExpress.XtraEditors.SimpleButton btnNextSell;
        private DevExpress.XtraEditors.SimpleButton btnPrevSell;
        private DevExpress.XtraEditors.SimpleButton btnPrintSell;
        private System.Windows.Forms.Panel panMasterBtn;
        private System.Windows.Forms.Panel panOutbundBtn;
        private System.Windows.Forms.Panel panSearch;
        private DevExpress.XtraEditors.LabelControl labelPayment;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.RadioButton rbSample;
        private System.Windows.Forms.RadioButton rbAmazon;
    }
}
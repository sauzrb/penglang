namespace PengLang
{
    partial class FrmManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManage));
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupSystem = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemSystemCode = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupShelf = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemInventroy = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemShelf = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupClothes = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemClothes = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemStyle = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupCustomer = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemCustomer = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupUser = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemChangePsw = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemUserManage = new DevExpress.XtraNavBar.NavBarItem();
            this.panLeftTop = new DevExpress.XtraEditors.PanelControl();
            this.lblBase = new System.Windows.Forms.Label();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.tpUser = new DevExpress.XtraTab.XtraTabPage();
            this.tpShelf = new DevExpress.XtraTab.XtraTabPage();
            this.tpClothes = new DevExpress.XtraTab.XtraTabPage();
            this.tpSystemCode = new DevExpress.XtraTab.XtraTabPage();
            this.tpInventory = new DevExpress.XtraTab.XtraTabPage();
            this.tpCustomer = new DevExpress.XtraTab.XtraTabPage();
            this.tpStyle = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLeftTop)).BeginInit();
            this.panLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.navBar);
            this.splitContainer.Panel1.Controls.Add(this.panLeftTop);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel1.Resize += new System.EventHandler(this.splitContainer_Panel1_Resize);
            this.splitContainer.Panel2.Controls.Add(this.xtraTab);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(1120, 496);
            this.splitContainer.SplitterPosition = 133;
            this.splitContainer.TabIndex = 0;
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = this.navBarGroupSystem;
            this.navBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.navBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupSystem,
            this.navBarGroupShelf,
            this.navBarGroupClothes,
            this.navBarGroupCustomer,
            this.navBarGroupUser});
            this.navBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemShelf,
            this.navBarItemClothes,
            this.navBarItemChangePsw,
            this.navBarItemSystemCode,
            this.navBarItemInventroy,
            this.navBarItemCustomer,
            this.navBarItemStyle,
            this.navBarItemUserManage});
            this.navBar.Location = new System.Drawing.Point(0, 43);
            this.navBar.Name = "navBar";
            this.navBar.OptionsNavPane.ExpandedWidth = 133;
            this.navBar.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBar.Size = new System.Drawing.Size(133, 453);
            this.navBar.TabIndex = 1;
            // 
            // navBarGroupSystem
            // 
            this.navBarGroupSystem.Caption = "系统管理";
            this.navBarGroupSystem.Expanded = true;
            this.navBarGroupSystem.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemSystemCode)});
            this.navBarGroupSystem.Name = "navBarGroupSystem";
            this.navBarGroupSystem.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupSystem.SmallImage")));
            // 
            // navBarItemSystemCode
            // 
            this.navBarItemSystemCode.Caption = "系统代码";
            this.navBarItemSystemCode.Name = "navBarItemSystemCode";
            this.navBarItemSystemCode.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemSystemCode.SmallImage")));
            this.navBarItemSystemCode.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemSystemCode_LinkClicked);
            // 
            // navBarGroupShelf
            // 
            this.navBarGroupShelf.Caption = "库存及货架";
            this.navBarGroupShelf.Expanded = true;
            this.navBarGroupShelf.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemInventroy),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemShelf)});
            this.navBarGroupShelf.Name = "navBarGroupShelf";
            this.navBarGroupShelf.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupShelf.SmallImage")));
            // 
            // navBarItemInventroy
            // 
            this.navBarItemInventroy.Caption = "修改库存";
            this.navBarItemInventroy.Name = "navBarItemInventroy";
            this.navBarItemInventroy.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemInventroy.SmallImage")));
            this.navBarItemInventroy.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemInventroy_LinkClicked);
            // 
            // navBarItemShelf
            // 
            this.navBarItemShelf.Caption = "货架查询";
            this.navBarItemShelf.Name = "navBarItemShelf";
            this.navBarItemShelf.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemShelf.SmallImage")));
            this.navBarItemShelf.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemShelf_LinkClicked);
            // 
            // navBarGroupClothes
            // 
            this.navBarGroupClothes.Caption = "服装管理";
            this.navBarGroupClothes.Expanded = true;
            this.navBarGroupClothes.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemClothes),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemStyle)});
            this.navBarGroupClothes.Name = "navBarGroupClothes";
            this.navBarGroupClothes.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupClothes.SmallImage")));
            // 
            // navBarItemClothes
            // 
            this.navBarItemClothes.Caption = "服装信息";
            this.navBarItemClothes.Name = "navBarItemClothes";
            this.navBarItemClothes.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemClothes.SmallImage")));
            this.navBarItemClothes.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemClothes_LinkClicked);
            // 
            // navBarItemStyle
            // 
            this.navBarItemStyle.Caption = "服装款式";
            this.navBarItemStyle.Name = "navBarItemStyle";
            this.navBarItemStyle.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemStyle.SmallImage")));
            this.navBarItemStyle.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemStyle_LinkClicked);
            // 
            // navBarGroupCustomer
            // 
            this.navBarGroupCustomer.Caption = "销售及顾客";
            this.navBarGroupCustomer.Expanded = true;
            this.navBarGroupCustomer.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemCustomer)});
            this.navBarGroupCustomer.Name = "navBarGroupCustomer";
            this.navBarGroupCustomer.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupCustomer.SmallImage")));
            // 
            // navBarItemCustomer
            // 
            this.navBarItemCustomer.Caption = "顾客管理";
            this.navBarItemCustomer.Name = "navBarItemCustomer";
            this.navBarItemCustomer.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemCustomer.SmallImage")));
            this.navBarItemCustomer.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemCustomer_LinkClicked);
            // 
            // navBarGroupUser
            // 
            this.navBarGroupUser.Caption = "用户管理";
            this.navBarGroupUser.Expanded = true;
            this.navBarGroupUser.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemChangePsw),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemUserManage)});
            this.navBarGroupUser.Name = "navBarGroupUser";
            this.navBarGroupUser.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupUser.SmallImage")));
            // 
            // navBarItemChangePsw
            // 
            this.navBarItemChangePsw.Caption = "修改密码";
            this.navBarItemChangePsw.Name = "navBarItemChangePsw";
            this.navBarItemChangePsw.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemChangePsw.SmallImage")));
            this.navBarItemChangePsw.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemChangePsw_LinkClicked);
            // 
            // navBarItemUserManage
            // 
            this.navBarItemUserManage.Caption = "员工管理";
            this.navBarItemUserManage.Name = "navBarItemUserManage";
            this.navBarItemUserManage.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemUserManage.SmallImage")));
            this.navBarItemUserManage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemUserManage_LinkClicked);
            // 
            // panLeftTop
            // 
            this.panLeftTop.Controls.Add(this.lblBase);
            this.panLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panLeftTop.Name = "panLeftTop";
            this.panLeftTop.Size = new System.Drawing.Size(133, 43);
            this.panLeftTop.TabIndex = 0;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(28, 18);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(77, 12);
            this.lblBase.TabIndex = 0;
            this.lblBase.Text = "基础数据维护";
            // 
            // xtraTab
            // 
            this.xtraTab.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTab.Appearance.Options.UseBackColor = true;
            this.xtraTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTab.Location = new System.Drawing.Point(0, 0);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.tpUser;
            this.xtraTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTab.Size = new System.Drawing.Size(982, 496);
            this.xtraTab.TabIndex = 0;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUser,
            this.tpShelf,
            this.tpClothes,
            this.tpSystemCode,
            this.tpInventory,
            this.tpCustomer,
            this.tpStyle});
            // 
            // tpUser
            // 
            this.tpUser.Name = "tpUser";
            this.tpUser.Size = new System.Drawing.Size(976, 467);
            this.tpUser.Text = "员工管理";
            // 
            // tpShelf
            // 
            this.tpShelf.Name = "tpShelf";
            this.tpShelf.Size = new System.Drawing.Size(976, 467);
            this.tpShelf.Text = "货架管理";
            // 
            // tpClothes
            // 
            this.tpClothes.Name = "tpClothes";
            this.tpClothes.Size = new System.Drawing.Size(976, 467);
            this.tpClothes.Text = "服装信息";
            // 
            // tpSystemCode
            // 
            this.tpSystemCode.Name = "tpSystemCode";
            this.tpSystemCode.Size = new System.Drawing.Size(976, 467);
            this.tpSystemCode.Text = "系统代码";
            // 
            // tpInventory
            // 
            this.tpInventory.Name = "tpInventory";
            this.tpInventory.Size = new System.Drawing.Size(976, 467);
            this.tpInventory.Text = "修改库存";
            // 
            // tpCustomer
            // 
            this.tpCustomer.Name = "tpCustomer";
            this.tpCustomer.Size = new System.Drawing.Size(976, 467);
            this.tpCustomer.Text = "顾客管理";
            // 
            // tpStyle
            // 
            this.tpStyle.Name = "tpStyle";
            this.tpStyle.Size = new System.Drawing.Size(976, 467);
            this.tpStyle.Text = "代理商";
            // 
            // FrmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 496);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmManage";
            this.Text = "管理";
            this.Load += new System.EventHandler(this.FrmManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLeftTop)).EndInit();
            this.panLeftTop.ResumeLayout(false);
            this.panLeftTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraNavBar.NavBarControl navBar;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupShelf;
        private DevExpress.XtraEditors.PanelControl panLeftTop;
        private DevExpress.XtraNavBar.NavBarItem navBarItemShelf;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupClothes;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItemClothes;
        private DevExpress.XtraNavBar.NavBarItem navBarItemChangePsw;
        private System.Windows.Forms.Label lblBase;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupSystem;
        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private DevExpress.XtraTab.XtraTabPage tpUser;
        private DevExpress.XtraTab.XtraTabPage tpShelf;
        private DevExpress.XtraTab.XtraTabPage tpClothes;
        private DevExpress.XtraTab.XtraTabPage tpSystemCode;
        private DevExpress.XtraNavBar.NavBarItem navBarItemSystemCode;
        private DevExpress.XtraNavBar.NavBarItem navBarItemInventroy;
        private DevExpress.XtraTab.XtraTabPage tpInventory;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupCustomer;
        private DevExpress.XtraNavBar.NavBarItem navBarItemCustomer;
        private DevExpress.XtraTab.XtraTabPage tpCustomer;
        private DevExpress.XtraTab.XtraTabPage tpStyle;
        private DevExpress.XtraNavBar.NavBarItem navBarItemStyle;
        private DevExpress.XtraNavBar.NavBarItem navBarItemUserManage;
    }
}
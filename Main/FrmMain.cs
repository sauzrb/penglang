using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using Sau.Util;

namespace PengLang
{
    public partial class FrmMain : Form
    {
        #region 窗体构造及初始化

        public FrmMain()
        {
            InitializeComponent();

            xtraTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            InitTabButton();

            innerForm = new InnerForm[8];

            innerForm[0] = inventoryForm;
            innerForm[1] = inboundForm;
            innerForm[2] = outboundForm;
            innerForm[3] = tranboundForm;
            innerForm[4] = manageForm;
            innerForm[5] = financeForm;
            innerForm[6] = browerForm;
            innerForm[7] = backForm;
        }

        private void ResizeWindow()
        {
           
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppEditStatus.InboundCurrentStatus != 0 && AppEditStatus.InboundCurrentStatus != 4)
            {
                e.Cancel = true;

                MsgBox.Error("您尚未完成入库单操作，请先完成入库单！");
                return;
            }
            if (AppEditStatus.OutboundCurrentStatus != 0 && AppEditStatus.OutboundCurrentStatus != 4)
            {
                e.Cancel = true;

                MsgBox.Error("您尚未完成出库单操作，请先完成出库单！");
                return;
            }

            if (MsgBox.Confirm("您确定要退出系统?") == false)
            {
                e.Cancel = true;
                return;
            }
            ClearZeroInventory();
            AppConfig.DeleteTempDirectory();
            Database.CloseDB();

        }

        private void ClearZeroInventory()
        {
            string sql = "delete from t_inventory where quantity = 0 ";
            Database.ExecuteSQL(sql, "FrmMain-ClearZeroInventory");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            AppConfig.GetCompanyInfo(); 
            xtraTab.SelectedTabPage = tpWelcome;
             
        }
         
        private void pbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panFooter_Resize(object sender, EventArgs e)
        {
            int left = 0;

            left = (this.Width - pboxFooterLogo.Width) / 2;
            pboxFooterLogo.Left = left;
        }

        //初始化标签按钮的可见性
        private void InitTabButton()
        {
            
            pbtnInventory.Visible = true;
            pbtnInventorySel.Visible = false;

            pbtnInbound.Visible = true;
            pbtnInboundSel.Visible = false;

            pbtnOutbound.Visible = true;
            pbtnOutboundSel.Visible = false;

            pbtnInvoice.Visible = true;
            pbtnInvoiceSel.Visible = false;

            pbtnTranbound.Visible = true;
            pbtnTranboundSel.Visible = false;

            pbtnManage.Visible = true;
            pbtnManageSel.Visible = false;

            pbtnBack.Visible = true;
            pbtnBackSel.Visible = false;

            pbtnSearch.Visible = true;
            pbtnSearchSel.Visible = false;
        }
       
        #endregion

        #region 切换功能标签

        private void ClearSelectioin()
        {
            
            pbtnInventory.Visible = true;
            pbtnInventorySel.Visible = false;

            pbtnInbound.Visible = true;
            pbtnInboundSel.Visible = false;

            pbtnOutbound.Visible = true;
            pbtnOutboundSel.Visible = false;

            pbtnTranbound.Visible = true;
            pbtnTranboundSel.Visible = false;

            pbtnManage.Visible = true;
            pbtnManageSel.Visible = false;

            pbtnInvoice.Visible = true;
            pbtnInvoiceSel.Visible = false;

            pbtnSearch.Visible = true;
            pbtnSearchSel.Visible = false;

            pbtnBack.Visible = true;
            pbtnBackSel.Visible = false;
        }
        
        //锁屏
        private void pbtnLogout_Click(object sender, EventArgs e)
        { 

            FrmLockScreen dlg = new FrmLockScreen();
            dlg.ShowDialog();
        }
       
        
        //库存
        private void pbtnInventory_Click(object sender, EventArgs e)
        {
           
            ClearSelectioin();

            pbtnInventory.Visible = false;
            pbtnInventorySel.Visible = true;

            if (inventoryForm == null)
                inventoryForm = LoadChildForm(tpInventory, "PengLang.FrmInventory") as FrmInventory;
           
            xtraTab.SelectedTabPage = tpInventory;
             
        }
        //入库
        private void pbtnInbound_Click(object sender, EventArgs e)
        {
           
            ClearSelectioin();
            pbtnInbound.Visible = false;
            pbtnInboundSel.Visible = true;
            if (inboundForm == null)
                inboundForm = LoadChildForm(tpInbound, "PengLang.FrmInbound") as FrmInbound;
            xtraTab.SelectedTabPage = tpInbound;
        }
        //出库
        private void pbtnOutbound_Click(object sender, EventArgs e)
        {
           
            ClearSelectioin();
            pbtnOutbound.Visible = false;
            pbtnOutboundSel.Visible = true;
            if (outboundForm == null)
                outboundForm = LoadChildForm(tpOutbound, "PengLang.FrmOutbound") as FrmOutbound;
            xtraTab.SelectedTabPage = tpOutbound;
        }
        //转库
        private void pbtnTranbound_Click(object sender, EventArgs e)
        {
           
            ClearSelectioin();
            pbtnTranbound.Visible = false;
            pbtnTranboundSel.Visible = true;
            if (tranboundForm == null)
                tranboundForm = LoadChildForm(tpTranbound, "PengLang.FrmTranbound") as FrmTranbound;
            xtraTab.SelectedTabPage = tpTranbound;
        }
        //管理
        private void pbtnManage_Click(object sender, EventArgs e)
        {
            ClearSelectioin();
            pbtnManage.Visible = false;
            pbtnManageSel.Visible = true;
            if (manageForm == null)
                manageForm = LoadChildForm(tpManage, "PengLang.FrmManage") as FrmManage;
            xtraTab.SelectedTabPage = tpManage;
        }
       //发票
        private void pbtnInvoice_Click(object sender, EventArgs e)
        {
          
            ClearSelectioin();
            pbtnInvoice.Visible = false;
            pbtnInvoiceSel.Visible = true;
            if (financeForm == null)
                financeForm = LoadChildForm(tpInvoice, "PengLang.FrmFinance") as FrmFinance;
            xtraTab.SelectedTabPage = tpInvoice;
        }

        //查询
        private void pbtnSearch_Click(object sender, EventArgs e)
        {
            ClearSelectioin();
            pbtnSearch.Visible = false;
            pbtnSearchSel.Visible = true;
            if (browerForm == null)
                browerForm = LoadChildForm(tpSearch, "PengLang.FrmBrower") as FrmBrower;
            xtraTab.SelectedTabPage = tpSearch;
        }

        //退货
        private void pbtnBackSel_Click(object sender, EventArgs e)
        {
            ClearSelectioin();
            pbtnBack.Visible = false;
            pbtnBackSel.Visible = true;
            if (backForm == null)
                backForm = LoadChildForm(tpBackBound, "PengLang.FrmBackbound") as FrmBackbound;
            xtraTab.SelectedTabPage = tpBackBound;
        }

        #endregion

        #region 子窗体

        private InnerForm []innerForm;
        private FrmInventory inventoryForm; //库存窗体
        private FrmInbound inboundForm;     //入库窗体
        private FrmOutbound outboundForm;   //出库窗体
        private FrmTranbound tranboundForm; //转库窗体
        private FrmManage manageForm;       //管理窗体

        private FrmFinance financeForm;     //财务窗体
        private FrmBrower browerForm;       //查询窗体
        private FrmBackbound backForm;      //退货窗体
   
        private Form LoadChildForm(XtraTabPage tabPage, string frmName)
        {
            Form childForm;
            tabPage.Controls.Clear();
            Type t = Type.GetType(frmName);
            childForm = (Form)Activator.CreateInstance(t);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(childForm);

            childForm.Show();

            return childForm;
        }

        #endregion

        

      
        
    }
}

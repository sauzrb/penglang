using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraReports;
using Sau.Util;
using System.Reflection;


namespace PengLang
{
    public partial class FrmOutbound : DevExpress.XtraEditors.XtraForm,InnerForm
    {
        OutboundMasterView outboundMasterView;
        OutboundDetailView outboundDetailView;
        OutboundRecordView outboundRecordView;
        OutboundInvoiceView invoiceDetailView;
        BackBoundDetailView backDetailView;
     
        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 窗体构造与初始化

        public FrmOutbound()
        {
            InitializeComponent();

            this.cboCustomerNo.TextChanged += new System.EventHandler(this.ComboBoxCustomerNo_TextChanged);

            splitContainer.Collapsed = false;
            outboundMasterView = new OutboundMasterView(this.outboundView);
            outboundDetailView = new OutboundDetailView(this.detailView);
            outboundRecordView = new OutboundRecordView(this.recordView);
            invoiceDetailView = new OutboundInvoiceView(this.invoiceView);

            backDetailView = new BackBoundDetailView(this.backView);

            btnPacking.Visible = true;
        }

        private void FrmOutbound_Load(object sender, EventArgs e)
        { 
            InitUI_FormLoad();
            cboArtNoFilter.Properties.Items.Clear();
            for (int i = 0; i < MemoryTable.Instance.ListClothes.Count; i++)
            {
                cboArtNoFilter.Properties.Items.Add(MemoryTable.Instance.ListClothes[i].LotNo);
            }

            outboundMasterView.Initialize();
            outboundDetailView.Initialize();
            outboundRecordView.Initialize();
            invoiceDetailView.Initialize();
            backDetailView.Initialize();

            CurrentOutboundStatus = 0;

            if (Database.IsConnected())
            {
                outboundView.BeginUpdate();
                outboundMasterView.Loading();
                outboundView.EndUpdate();
            }
             
        }
        
        private void tpPrintSet_Resize(object sender, EventArgs e)
        { 
            groupOutbound.Left = tpProperty.Width / 2 - groupOutbound.Width / 2;
            groupOutbound.Top = tpProperty.Height / 2 - groupOutbound.Height / 2;
            
        }

       
        #endregion

        #region 销售模式切换
        
        private void rbSaleMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSale.Checked == true)
            {
                cboPayment.Visible = true;
                labelPayment.Visible = true;
            }
            else
            {
                labelPayment.Visible = false;
                cboPayment.Visible = false;
            }
        }
        
        #endregion

        #region 设置界面状态

        private int OutboundKind = 0;  
        
        private int CurrentOutboundStatus = 0;
        const int Status_None = 0; //查询  
        const int Status_Property = 1;//填写属性 
        const int Status_Detail = 2;  //编辑明细 
        const int Status_Invoice = 3;//打印发票

        const int Status_Record = 4;  //操作单 
        const int Status_Complete = 5;//完成
        const int Status_Back = 11;   //退货
     
        //加载窗体时初始化界面
        private void InitUI_FormLoad()
        {
            panSearch.Left = 0;
            panSearch.Top = 2;

            panMasterBtn.Left =  gbTop.Right - panMasterBtn.Width;
            panMasterBtn.Top = 2;

            panPerSellBtn.Left = panMasterBtn.Left;
            panPerSellBtn.Top = panMasterBtn.Top;

            panOutbundBtn.Left = panOutbundBtn.Left;
            panOutbundBtn.Top = panMasterBtn.Top;

            panPerSellBtn.Parent = panMasterBtn.Parent;
            panOutbundBtn.Parent = panMasterBtn.Parent;

            panSearch.Visible = true;
            panMasterBtn.Visible = true;
            panPerSellBtn.Visible = false;
            panOutbundBtn.Visible = false;

            gbTop.Visible = true;

            splitContainer.Collapsed = false;
            splitContainer.IsSplitterFixed = false;

            xtraTab.ShowTabHeader = DefaultBoolean.True;
            tpRecord.PageVisible = true;
            tpDetail.PageVisible = true;
            tpBackDetail.PageVisible = true;
            tpProperty.PageVisible = false;
            tpInvoice.PageVisible = true;
            xtraTab.SelectedTabPage = tpDetail;

        }

        //编辑状态
        private void InitUI_Edit()
        {
            splitContainer.IsSplitterFixed = true;
            splitContainer.Collapsed = true;
            xtraTab.ShowTabHeader = DefaultBoolean.False;
           
            tpRecord.PageVisible = false;
            tpDetail.PageVisible = false;
            tpInvoice.PageVisible = false;
            tpProperty.PageVisible = false;
            tpBackDetail.PageVisible = false;

            panSearch.Visible = false;
            panMasterBtn.Visible = false;

          
        }

        private void InitUI_Search() 
        {
            panOutbundBtn.Visible = false;
            panPerSellBtn.Visible = false;

            panSearch.Visible = true;

            panMasterBtn.Visible = true; 
            panPrintBg.Visible = true;

            detailGrid.ContextMenuStrip = null;
            recordGrid.ContextMenuStrip = ctxMenuRecord;

            gbTop.Visible = true;

            splitContainer.Collapsed = false;
            splitContainer.IsSplitterFixed = false;

            xtraTab.ShowTabHeader = DefaultBoolean.True;
            tpRecord.PageVisible = true;
            tpDetail.PageVisible = true;
            tpBackDetail.PageVisible = true;
            tpProperty.PageVisible = false;
            tpInvoice.PageVisible = true;
            xtraTab.SelectedTabPage = tpDetail;

            outboundDetailView.SetGridEditStatus(false);
            outboundRecordView.SetGridEditStatus(true);
            backDetailView.SetGridEditStatus(false);


        }
        
        private void InitUI_PropertySell()
        {
            InitUI_Edit();

            tpProperty.PageVisible = true;
            panPerSellBtn.Visible = true;

            btnPrintSell.Visible = false;

            btnPrevSell.Visible = true;
            btnPrevSell.Enabled = false;

            btnNextSell.Visible = true;
            btnNextSell.Enabled = true;

            btnCompleteSell.Visible = false;
            btnCompleteSell.Enabled = false;

            btnCancelSell.Visible = true;
            btnCancelSell.Enabled = true; 
        }
         
        //编辑明细
        private void InitUI_DetailSell()
        {
            InitUI_Edit(); 
            tpDetail.PageVisible = true;


            btnPrintSell.Visible = true;
            btnPrevSell.Enabled = true;

            btnNextSell.Visible = true;
            btnNextSell.Enabled = true;

            btnCompleteSell.Visible = false;
            btnCompleteSell.Enabled = false;
            btnCancelSell.Enabled = true;
            
            detailGrid.ContextMenuStrip = ctxMenuDetail;

            outboundDetailView.CustomerNo = cboCustomerNo.Text.Trim();
            outboundDetailView.bCommission = HasCommission();

        }
        
        //编辑发票
        private void InitUI_InvoicePreSell()
        {
            InitUI_Edit();  
            panPrintBg.Visible = false;
           
            tpInvoice.PageVisible = true;

            btnPrintSell.Visible = true;
            btnPrevSell.Enabled = true;

            btnNextSell.Visible = false;
            btnNextSell.Enabled = false;

            btnCompleteSell.Visible = true;
            btnCompleteSell.Enabled = true;
            btnCancelSell.Enabled = true; 
            invoiceDetailView.CustomerNo = cboCustomerNo.Text.Trim();
            invoiceDetailView.bCommission = HasCommission();
        }
        
        //编辑明细
        private void InitUI_DetailOut()
        {
            InitUI_Edit();
            tpDetail.PageVisible = true;


            btnPrintOut.Visible = true;
            btnPrevOut.Enabled = false;

            btnNextOut.Visible = true;
            btnNextOut.Enabled = true;
            btnNextOut.Text = "Next";

            btnCompleteOut.Visible = false;
            btnCompleteOut.Enabled = false;

            btnCancelOut.Enabled = true;

            detailGrid.ContextMenuStrip = ctxMenuDetail;

            outboundDetailView.CustomerNo = cboCustomerNo.Text.Trim();

            Object obj = outboundView.GetFocusedRowCellValue("Sales");
            string comm = "";
            if (obj != null)
                comm = obj.ToString();

            outboundDetailView.ResetView();
            outboundDetailView.bCommission = HasCommission(comm);
            invoiceDetailView.bCommission = HasCommission(comm);
        }
        
        private void InitUI_InvoiceOut()
        {
            InitUI_Edit();

            tpInvoice.PageVisible = true;
            panPrintBg.Visible = false;

            btnPrevOut.Enabled = true;

            btnNextOut.Enabled = true;
            btnNextOut.Visible = true;
            btnNextOut.Text = "Distribute";

            btnCompleteOut.Enabled = false;
            btnCompleteOut.Visible = false;

            btnCancelOut.Enabled = true;
            btnPrintOut.Visible = true;

            Object obj = "";
            obj = outboundView.GetFocusedRowCellValue("CustomerNo");
            string cust ="";
            if (obj != null)
                cust = obj.ToString();

            invoiceDetailView.CustomerNo = cust;
            obj =  outboundView.GetFocusedRowCellValue("Sales");
            string comm = "";
            if (obj != null)
                comm = obj.ToString();

            invoiceDetailView.bCommission = HasCommission();
        }

        private void InitUI_RecordOut()
        {
            InitUI_Edit();
            tpRecord.PageVisible = true;
            
            btnPrevOut.Enabled = true;

            btnNextOut.Visible = true;
            btnNextOut.Enabled = true;
            btnNextOut.Text = "Next";

            btnCompleteOut.Visible = true;
            btnCompleteOut.Enabled = true;


            btnCancelOut.Enabled = true;
            btnPrintOut.Visible = true;

            recordGrid.ContextMenuStrip = null;

        }

        private void InitUI_Complete()
        {
            InitUI_FormLoad();
            outboundDetailView.SetGridEditStatus(false);
            outboundRecordView.SetGridEditStatus(true);
            backDetailView.SetGridEditStatus(false);
        }

        private void InitUI_Backbound()
        {
            InitUI_Edit(); 
            tpBackDetail.PageVisible = true;
            panOutbundBtn.Visible = true;

            btnPrevOut.Visible = false;
            btnPrevOut.Enabled = false;

            btnNextOut.Visible = false;
            btnNextOut.Enabled = false;

            btnCompleteOut.Visible = true;
            btnCompleteOut.Enabled = true;

            btnCancelOut.Visible = true;
            btnCancelOut.Enabled = true;
              
            btnPrintOut.Visible = false;
             
        }
    
        #endregion

        #region 商品预售 按钮事件
                
        //商品预售
        private void btnPreSell_Click(object sender, EventArgs e)
        { 
            NewOutbound();
        }
        
        //出库
        private void NewOutbound()
        {
            txtOutboundNo.Text = Database.GetDataTimekey(2);
            txtOrderNo.Text = "";
               
            cboSales.Properties.Items.Clear();
            MemoryTable.Instance.LoadSales();
            cboSales.Properties.Items.AddRange(MemoryTable.Instance.SalesList);
             
            txtTrackingNo.Text = "";
            
            cboCustomerNo.Text = "";
            txtSellTo.Text = "";
            txtCustomerFilter.Text = "";
            txtAddr.Text = "";
            txtShipTo.Text = "";
            txtFreight.Text = "";
            nudTerm.Value = 60;
            cboShipway.Text = "Regular box";
            cboPayment.Text = "FAC";

            cboCustomerNo.Properties.Items.Clear();
            CustomerHelper ch = new CustomerHelper();
            cboCustomerNo.Properties.Items.AddRange(ch.GetCustomerList());
            nTempCutomerIndex = -1;
            SwitchCustomer(nTempCutomerIndex);

            InitUI_PropertySell();

            CurrentOutboundStatus = Status_Property;
            txtOrderNo.Focus();

            outboundDetailView.SetGridEditStatus(true);
            outboundRecordView.SetGridEditStatus(false);

            outboundDetailView.OutboundID = txtOutboundNo.Text;
            
            outboundRecordView.OutboundID = txtOutboundNo.Text;

            invoiceDetailView.OutboundID = txtOutboundNo.Text;


            outboundRecordView.ClearRows();
            outboundDetailView.ClearRows();
            invoiceDetailView.ClearRows();
            backDetailView.ClearRows();
        }

        //上一步
        private void btnPrevSell_Click(object sender, EventArgs e)
        {

            if (CurrentOutboundStatus <= Status_Property)
                return;
            if (CurrentOutboundStatus == Status_Detail)
            {
                DeleteOutboundItem(outboundDetailView.OutboundID);
                CurrentOutboundStatus = Status_Property;
                InitUI_PropertySell(); 
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

                return;
            }
            if (CurrentOutboundStatus == Status_Invoice)
            {
                ClearDetail(invoiceDetailView.OutboundID);
                CurrentOutboundStatus = Status_Detail;
                InitUI_DetailSell(); 
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

                return;
            }
        }
       
        //下一步
        private void btnNextSell_Click(object sender, EventArgs e)
        {

            if (CanNext() == false)
                return;
            
            #region  转入明细编辑

            if (CurrentOutboundStatus == Status_Property)
            {
                CurrentOutboundStatus = Status_Detail;
                outboundDetailView.OutboundID = txtOutboundNo.Text;

                if (rbSale.Checked == true)
                    OutboundKind = MemoryTable.Outbound_Kind_Gel;
                else if (rbAmazon.Checked == true)
                    OutboundKind = MemoryTable.Outbound_Kind_Amazon;
                else if (rbSample.Checked == true)
                    OutboundKind = MemoryTable.Outbound_Kind_Sample;

                InitUI_DetailSell(); 
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;
                 
                return;
            }

            #endregion

            #region 转入发票编辑

            if (CurrentOutboundStatus == Status_Detail)
            {
                WaitingService.BeginLoading("正在分解出库明细，请稍等......");
               
                //保存明细
                SaveOutbound();

                //加载发票
                InitUI_InvoicePreSell();
                if (Database.IsConnected())
                {
                    invoiceDetailView.OutboundID = txtOutboundNo.Text;
                    invoiceDetailView.Loading();
                }

                CurrentOutboundStatus = Status_Invoice; 
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

                return;
            }

            #endregion
             

        }
        
        //完成预售
        private void btnCompleteSell_Click(object sender, EventArgs e)
        {
            WaitingService.BeginLoading("正在保存出库明细，请稍等......");


            //保存发票单价
            invoiceDetailView.SavePrice();

    
            MissionAssign missionAssign = new MissionAssign();
            //虚拟出库从77S77减库存
            missionAssign.VirtualOutboundAssign(txtOutboundNo.Text);
           

            WaitingService.EndLoading();

            CurrentOutboundStatus =  Status_None;
            AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

            outboundMasterView.InsertOutbound(0, newOutBound);
            SetConfirmButtonVisible();
            
            InitUI_Search();
   
            this.Refresh(); 

            newOutBound = null;
            
            SaveCustomer();

        }
        
        //取消预售
        private void btnCancelSell_Click(object sender, EventArgs e)
        {
            string tip = "您确定要放弃本次预售操作吗？";
             
            if (MsgBox.Confirm(tip) == false)
                return;

            CancelNewOutbound(txtOutboundNo.Text);

            InitUI_Complete();

            CurrentOutboundStatus = Status_None; 
            AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

            SwitchOutbound();

        }


        private void txtFreight_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            if ((int)e.KeyChar != 46)                           //小数点
                return;
            //小数点的处理。
            if (textbox.Text.Length <= 0)
                e.Handled = true;   //小数点不能在第一位
            else                                             //处理不规则的小数点
            {
                float f;
                float oldf;
                bool b1 = false, b2 = false;
                b1 = float.TryParse(textbox.Text, out oldf);
                b2 = float.TryParse(textbox.Text + e.KeyChar.ToString(), out f);
                if (b2 == false)
                {
                    if (b1 == true)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }

        }
        
        private bool CanNext()
        {
            bool bres = true;

            if (CurrentOutboundStatus == Status_Property)
            {

                if (txtOrderNo.Text.Trim().Length == 0)
                {
                    MsgBox.Error(" 'P.O# 'can not be empty！");
                    return false;
                }
                 
                if (cboCustomerNo.Text.Trim().Length == 0)
                {
                    MsgBox.Error(" 'CUSTOMER#' can not be empty！");
                    return false;
                }

                if (txtSellTo.Text.Trim().Length == 0)
                {
                    MsgBox.Error(" 'SELL TO' can not be empty！");
                    return false;
                }

                if (cboPayment.Text.Trim().Length == 0)
                {
                    MsgBox.Error(" 'Payment Mode' can not be empty！");
                    return false;
                }
                if (ValidPayment() == false)
                {
                    MsgBox.Error(" 'Payment Mode' must be  one of 'FAC,CHECK,CREDET,CASH.'！");
                    return false;
                }
             
            }

            return bres;

        }
      
        //验证付款方式是否合法
        bool ValidPayment()
        { 
            //"FAC CHECK CREDET CASH ";
            string mode = cboPayment.Text.Trim().ToUpper();

            if (mode == "FAC") return true;
            if (mode == "CHECK") return true;
            if (mode == "CREDET") return true;
            if (mode == "CASH") return true;
            return false;
        }
     
        #endregion

        #region 真实出库 按钮事件

        private void btnPrevOut_Click(object sender, EventArgs e)
        {
            if (CurrentOutboundStatus <= Status_Property)
            { 
                return;
            }
            if (CurrentOutboundStatus == Status_Detail)
            {
                return;
            }

            if (CurrentOutboundStatus == Status_Invoice)
            {
                InitUI_DetailOut();
                CurrentOutboundStatus = Status_Detail;
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;
                return;
            }

            if (CurrentOutboundStatus == Status_Record)
            {
                //首先删除出库明细
                ClearRecord(outboundRecordView.OutboundID);
                outboundRecordView.ClearRows();
                InitUI_InvoiceOut();
                CurrentOutboundStatus = Status_Invoice;
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;


                //3恢复入库单的虚拟属性
               string sql = string.Format("Update T_Outbound Set Status = '{0}' where OutboundID = '{1}' and Status = '{2}'",
                    DealStatus.PreSell,
                    outboundRecordView.OutboundID,
                    DealStatus.Outbound);

                Database.ExecuteSQL(sql);

                outboundView.SetFocusedRowCellValue("Status", DealStatus.PreSell);

                return;
            }
        }

        private void btnNextOut_Click(object sender, EventArgs e)
        {
            if (CurrentOutboundStatus == Status_Record)
                return;
                         
            #region 分解明细

            if (CurrentOutboundStatus == Status_Detail)
            {
                //保存明细
                outboundDetailView.SaveOutboundDetail();

                //2017-05-29
                //删除虚拟库存
                DeleteVirtualInvenotry(outboundDetailView.OutboundID);

                //虚拟出库从77S77减库存
                MissionAssign missionAssign = new MissionAssign(); 
                missionAssign.VirtualOutboundAssign(outboundDetailView.OutboundID);

                //加载发票
                InitUI_InvoiceOut();
                invoiceDetailView.Loading();
                 
                CurrentOutboundStatus = Status_Invoice;
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;
                return;
            }
            
            #endregion

            #region 发票结束，开始分解

            if (CurrentOutboundStatus == Status_Invoice)
            {
                //保存发票单价
                invoiceDetailView.SavePrice();


                //如果真实货架上的服装不够，不允许出库
                if (CanActualOutbound() == false)
                    return;

                WaitingService.BeginLoading("正在生成出库操作单，请稍等......");

                MissionAssign missionAssign = new MissionAssign();
                missionAssign.OutboundAssign(outboundDetailView.OutboundID);

                //加载明细
                outboundRecordView.OutboundID = outboundDetailView.OutboundID;
                outboundRecordView.LoadOutboundRecord(outboundDetailView.OutboundID);

                InitUI_RecordOut();

                outboundView.SetFocusedRowCellValue("Status", DealStatus.Outbound);
                  
                CurrentOutboundStatus = Status_Record;
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

                WaitingService.EndLoading();

                return;
            }

            #endregion
            
        }

        private void btnCompleteOut_Click(object sender, EventArgs e)
        {
             //发票金额
            if (CurrentOutboundStatus == Status_Record)
            {
                InitUI_Search();
                 
                CurrentOutboundStatus = Status_None;
                                
                WaitingService.BeginLoading("正在保存数据，请稍等......");
                       
                MissionAssign missionAssign = new MissionAssign(); 
                missionAssign.OutboundComplete(txtOutboundNo.Text);
                 
                WaitingService.EndLoading();

                this.Refresh();

                CurrentOutboundStatus = Status_None;

                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;
                outboundView.SetFocusedRowCellValue("Status", DealStatus.Outbound);
                SetConfirmButtonVisible();
                return;
            }
             
            //退货
            if (CurrentOutboundStatus == Status_Back)
            {
                SaveBackbound();

                InitUI_Complete();

                CurrentOutboundStatus = Status_None;
                AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

                SwitchOutbound();

                xtraTab.SelectedTabPage = tpBackDetail;
            }
              
        }
        
        private void btnCancelOut_Click(object sender, EventArgs e)
        {
            string tip = "您确定要放弃本次出库操作吗？";

            if (MsgBox.Confirm(tip) == false)
                return;
              
            InitUI_Complete();

            CurrentOutboundStatus = Status_None;
            AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;

            CancelVirtualToActual(txtOutboundNo.Text);

            SwitchOutbound();
        }

        #endregion
                
        #region 检索

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = GetFilterSql();
            outboundView.BeginUpdate();
            outboundMasterView.FilterSql = sql;
            outboundMasterView.Loading();
            outboundView.EndUpdate();
            SwitchOutbound();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            string sql = GetFilterSql();
            outboundView.BeginUpdate();
            outboundMasterView.FilterSql = sql;
            outboundMasterView.Loading();
            outboundView.EndUpdate();
            SwitchOutbound();
        }

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and ShipDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and ShipDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            if (txtOrderNoFilter.Text.Trim().Length > 0)
            {
                sql += String.Format(" and OrderNo like '%{0}%'", txtOrderNoFilter.Text.Trim());
            }
            if (txtCustomerFilter.Text.Trim().Length > 0)
            {
                //sql += String.Format(" and Customer like '%{0}%'", txtCustomerFilter.Text);
                //sql += String.Format(" and SellTo = '{0}'", txtCustomerFilter.Text.Trim());
                sql += String.Format(" and (SellTo like '{0}%' or CustomerNo like '{0}%')", txtCustomerFilter.Text.Trim());
            }

            if (cboArtNoFilter.Text.Trim().Length > 0)
            {
                sql += " and " + GetOutboundIDContainLotNo(cboArtNoFilter.Text.Trim());
            }

            return sql;
        }

        private string GetOutboundIDContainLotNo(string lotNo)
        {
            string res = " ";
            string sql = string.Format("select distinct outboundID from T_OutboundDetail where lotNo = '{0}'", lotNo);
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return " 1 = 0 ";
            int cnt = dt.Rows.Count;
            res = "OutboundID in ( '" + dt.Rows[0][0].ToString() + "'"; 
            for (int i = 1; i < cnt; i++)
            {
                res += String.Format(", '{0}'", dt.Rows[i][0]);
            }
            res += ")";
            dt.Clear();
            return res;
        }

        private void SwitchOutbound()
        {
            outboundDetailView.ClearRows();
            outboundRecordView.ClearRows();
            invoiceDetailView.ClearRows();
            backDetailView.ClearRows();
            splitContainer.Collapsed = false;

            //刷新明细表格
            if (outboundView.GetFocusedRowCellValue("OutboundID") == null)
                return;
            string boundno = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            outboundRecordView.LoadOutboundRecord(boundno);

            outboundDetailView.OutboundID = boundno;
            outboundDetailView.Loading();

            string comm = outboundView.GetFocusedRowCellValue("Sales").ToString().ToLower();
            invoiceDetailView.OutboundID = boundno;
            invoiceDetailView.bCommission =  HasCommission(comm) ;

            invoiceDetailView.Loading();

            backDetailView.OutboundID = boundno;
            backDetailView.Loading();
            SetConfirmButtonVisible();
        }

        private void SetConfirmButtonVisible()
        {
            Object obj = outboundView.GetFocusedRowCellValue("Status");
            if (obj == null)
                return;
            string status = obj.ToString();

            if(status == DealStatus.PreSell)
            {
                btnConfirm.Text = "Outbound";
                btnConfirm.ForeColor = Color.Blue;
                btnConfirm.Enabled = true;
            }
            else if (status == DealStatus.Outbound)
            {
                btnConfirm.ForeColor = Color.Black;
                btnConfirm.Text = "Confirm";
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.ForeColor = Color.Black;
                btnConfirm.Text = "Confirm";
                btnConfirm.Enabled = false;
            }
        }
       
        #endregion
        
        #region 打印、导出
     
        //打印发票
        private void PrintInvoice(string id)
        {  
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
           
            ExportOutboundInvoice.Export(invoiceView, id, tempFile);

            outboundView.SetFocusedRowCellValue("InvoiceStatus", 1);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile); //保存
        }

        //打印出库单明细
        private void PrintDetail(string id)
        {  
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            ExportGridView.ExportDetail(this.detailView, tempFile); 
            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile); //保存v
        }
       
        //打印出库操作明细
        private void PrintRecord(string id)
        {
            string orderNo = outboundView.GetFocusedRowCellValue("OrderNo").ToString();
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            ExportGridView.ExportRecord(orderNo, this.recordView, tempFile);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile); //保存v
        }

        //打印退货名称
        private void PrintBackDetial(string id)
        {  
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            backGrid.ExportToXls(tempFile);

            if (System.IO.File.Exists(tempFile))
            {
                try
                {
                    System.Diagnostics.Process.Start(tempFile);
                }
                catch 
                {
                }
            }
        }

        private void ExportRecord(GridControl grid)
        {            
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string orderNo = outboundView.GetFocusedRowCellValue("OrderNo").ToString();
                ExportGridView.ExportRecord(orderNo, this.recordView, fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void ExportDetail(GridControl grid)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                ExportGridView.ExportDetail(this.detailView, fileDialog.FileName);
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void ExportInvoice(GridControl grid)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            { 
                string outboundID = outboundView.GetFocusedRowCellValue("OutboundID").ToString();

                ExportOutboundInvoice.Export(invoiceView, outboundID, fileDialog.FileName);
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            string outboundID = outboundView.GetFocusedRowCellValue("OutboundID").ToString();

            if (xtraTab.SelectedTabPage == tpDetail)
                PrintDetail(outboundID);

            else if (xtraTab.SelectedTabPage == tpRecord)
                PrintRecord(outboundID);

            else if (xtraTab.SelectedTabPage == tpInvoice)
                PrintInvoice(outboundID);

            else if (xtraTab.SelectedTabPage == tpBackDetail)
                PrintBackDetial(outboundID);
             
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            string outboundID = txtOutboundNo.Text;

            if (CurrentOutboundStatus == Status_Detail)
                PrintDetail(outboundID);

            else if (CurrentOutboundStatus == Status_Record)
                PrintRecord(outboundID);

            else if (CurrentOutboundStatus == Status_Invoice)
                PrintInvoice(outboundID);
        }

        private void mnuMasterExportDetail_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            ExportDetail(detailGrid);
        }

        private void mnuMasterPrintDetail_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            string id = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            PrintDetail(id);
        }

        private void mnuMasterExportReocrd_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            ExportRecord(recordGrid);
        }

        private void mnuMasterPrintRecord_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            string id = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            PrintRecord(id);
        }

        private void mnuMasterExportInvoice_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            ExportInvoice(invoiceGrid);
        }

        private void mnuMasterPrintInvoice_Click(object sender, EventArgs e)
        {
            if (outboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择出库单！");
                return;
            }
            
            string id = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            PrintInvoice(id );
          
        }

        #endregion
        
        #region 更改操作人

        private void mnuMasterSetOperator_Click(object sender, EventArgs e)
        {
            int rowID = outboundView.FocusedRowHandle;

            string status = outboundView.GetFocusedRowCellValue("Status").ToString();
            if (status == DealStatus.Complete)
            {
                MsgBox.Infometion("已经完成的出库单，不能修改操作人！");
                return;
            }
            FrmSelectOperator dlg = new FrmSelectOperator();

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string id = outboundView.GetRowCellValue(rowID, "OutboundID").ToString();
            UpdateOperator(id, dlg.OperatorName);

            outboundView.SetRowCellValue(rowID, "Operator", dlg.OperatorName);

            outboundRecordView.LoadOutboundRecord(id);
        }

        private void UpdateOperator(string boundID, string oper)
        {
            string sql = "";

            sql = String.Format("Update T_OutboundRecord Set DealUser = '{0}' where OutboundID = '{1}'", oper.Replace("'","''"), boundID);

            Database.ExecuteSQL(sql, "FrmOutbound-UpdateOperator");

            sql = String.Format("Update T_Outbound Set Operator = '{0}' where OutboundID = '{1}'", oper.Replace("'", "''"), boundID);

            Database.ExecuteSQL(sql, "FrmOutbound-UpdateOperator");

        }

        #endregion
        
        #region 删除出库单

        //删除出库单
        private void mnuMasterDelete_Click(object sender, EventArgs e)
        {
            
            string boundno = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            string outBoundKind = outboundView.GetFocusedRowCellValue("OutboundKind").ToString();
            string status = outboundView.GetFocusedRowCellValue("Status").ToString();

            if (string.IsNullOrEmpty(boundno))
            {
                MsgBox.Error("请先选择要删除的出库单！");
                return;
            }

            if (MsgBox.Confirm("您确定要删除选中的出库单？（删除后将恢复库存）") == false)
                return;

            if (status == DealStatus.PreSell)
            {
                //删除虚拟入库
                MissionAssign missionAssign = new MissionAssign();
                missionAssign.DeleteVirtualOutbound( boundno );
            }
            else if (CancelOutbound(boundno, outBoundKind) == false)
            {
                MsgBox.Error("删除出库单失败！");
                return;
            }

            outboundView.DeleteRow(outboundView.FocusedRowHandle);

            SwitchOutbound();

            FrmTip.ShowTip("删除出库单成功！");
        }
 
        //取消出库操作
        private bool CancelOutbound(string boundID, string outBoundKind)
        {
            //从出库操作单表中提取所有的实际出库单

            bool bres = true;
            string sql = String.Format("Select recordID, LotNo, SizeNo, ShelfNo, NumOfReal from T_OutboundRecord where OutboundID = '{0}'", boundID);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;

            int cnt = dt.Rows.Count;
            string recordid, lotno, sizeno, shelfno, qnt;

            for (int i = 0; i < cnt; i++)
            {
                recordid = dt.Rows[i][0].ToString();
                lotno = dt.Rows[i][1].ToString();
                sizeno = dt.Rows[i][2].ToString();
                shelfno = dt.Rows[i][3].ToString();
                qnt = dt.Rows[i][4].ToString();
                if (string.IsNullOrEmpty(qnt) == true)
                    qnt = "0";

                if (RestoreInventory(lotno, sizeno, shelfno, qnt, outBoundKind) == true)
                    DeleteOutboundRecord(recordid);
                else
                    bres &= false;
             }

            if (bres == true)
            {
                ClearDetail(boundID);
                DeleteOutboundItem(boundID);
            }

            return bres;
        }

        //取消新建出库单
        private bool CancelNewOutbound(string boundID)
        {
            string sql = string.Format("delete from T_OutboundDetail where OutboundID = '{0}'", boundID);
            int nres = Database.ExecuteSQL(sql, "FrmOutbound-CancelNewOutbound");

            sql = string.Format("delete from T_OutboundRecord where OutboundID = '{0}'", boundID);
            nres = Database.ExecuteSQL(sql, "FrmOutbound-CancelNewOutbound");

            sql = string.Format("delete from T_Outbound where OutboundID = '{0}'", boundID);
            nres = Database.ExecuteSQL(sql, "FrmOutbound-CancelNewOutbound");
            return nres > 0 ? true : false;
        }
      
        //删除出库单基础条码，不包括明细、出库操作单等信息
        private bool DeleteOutboundItem(string boundID)
        {
            string sql = string.Format("delete from T_Outbound where OutboundID = '{0}'", boundID);
            int nres = Database.ExecuteSQL(sql, "FrmOutbound-DeleteOutboundItem");

            
            return nres > 0 ? true : false;
        }
         
        //删除出库明细
        private void ClearDetail(string boundID)
        {
            string sql = string.Format("delete from T_OutboundDetail where OutboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmOutbound-ClearDetail");

        }
        
        //删除出库操作单
        private void ClearRecord(string boundID)
        {
            string sql = String.Format("Delete from T_OutboundRecord where OutboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmOutbound-ClearRecord");
        }
       
        //恢复库存
        private bool RestoreInventory(string lotno, string sizeno, string shelfno, string qnt, string outBoundKind)
        {
            bool bres = false;
            string sql, id ;
            id =  FindInventory(shelfno, lotno, sizeno) ;

            if (string.IsNullOrEmpty(id) == false )
            {
                sql = String.Format("update T_Inventory Set Quantity = Quantity + {0} where lotno = '{1}' "
                               + " and sizeno = '{2}' and shelfno = '{3}' ",
                               qnt,
                               lotno,
                               sizeno,
                               shelfno);
                bres = Database.ExecuteSQL(sql, "FrmOutbound-RestoreInventory") > 0 ? true : false;
            }
            else
            {
               bres = InsertInventory(shelfno, lotno, sizeno, qnt);
            }

            if (bres == true && outBoundKind == MemoryTable.Outbound_Kind_99T.ToString() )
            {

                sql =  " UPDATE T_Inventory SET Quantity = Quantity - " + qnt 
                                + " WHERE ShelfNo ='" + MemoryTable.Shelf_99T99 + "' AND LotNo ='" + lotno + "' AND SizeNo = '" + sizeno + "'";

                bres = Database.ExecuteSQL(sql, "FrmOutbound-RestoreInventory") > 0 ? true : false;

            }

            return bres;
        }
       
        //删除单条出库操作单
        private bool DeleteOutboundRecord(string recordId)
        {
            string sql = string.Format("delete from t_outboundrecord where recordId = '{0}'", recordId);
            int res = Database.ExecuteSQL(sql, "FrmOutbound-DeleteOutboundRecord");
            return res > 0 ? true : false;
        }

        //查找库存
        private string FindInventory(string shelfNo, string lotNo, string sizeNo)
        {
            string sql = String.Format("Select InventoryID From T_Inventory where shelfNo = '{0}' and LotNo = '{1}' and sizeNo = '{2}'",
                shelfNo,
                lotNo,
                sizeNo);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return String.Empty;

            string id = dt.Rows[0][0].ToString();
            dt.Clear();
            return id;
        }
        
        //插入库存
        private bool InsertInventory(string shelfNo, string lotNo, string sizeNo, string qnt )
        {
            string id = Database.GetGlobalKey();

            string sql = String.Format("Insert into T_Inventory (InventoryID, ShelfNo, LotNo, SizeNo, Quantity ) "
                + "Values('{0}', '{1}', '{2}', '{3}', {4})",
                id,
                shelfNo,
                lotNo,
                sizeNo,
                qnt );

            int nres = Database.ExecuteSQL(sql, "FrmOutbound-InsertInventory");
            return nres == 1 ? true : false;
        }
         
        #endregion

        #region 完成出库单

        private void UpdateDealStatus(string status)
        {

            int rowcnt = recordView.RowCount;
            string recordID = "";
            string  time = "";
            for (int i = 0; i < rowcnt; i++)
            {
                if (GetChecked(i) == false)
                    continue;
                recordID = recordView.GetRowCellValue(i, "RecordID").ToString();
                time = Database.GetDateTimeString();
                UpdateDealStatus(recordID, time, status);
               
                //修改实际出库数量
                UpdateNumOfReal(i);

                recordView.SetRowCellValue(i, "DealStatus", status);
                recordView.SetRowCellValue(i, "DealDateTime", time);
            }
        }

        private bool GetChecked(int rowHandle)
        {
            string value = recordView.GetRowCellValue(rowHandle, "CheckStatus").ToString();
            if (value == "True")
                return true;
            return false;
        }

        private void UpdateDealStatus(string recordID, string time, string status)
        { 
            string sql = string.Format("Update T_OutboundRecord set DealStatus = '{0}',DealDateTime='{1}' where recordID='{2}'",
                status,
                time,
                recordID);
            Database.ExecuteSQL(sql, "FrmOutbound-UpdateDealStatus");
        }

        private void UpdateOutboundStatus(string boundID, DateTime dtConfirm, string status)
        {
            string sql = "";

            if (status != DealStatus.Finish )
                sql = String.Format("update T_Outbound Set Status = '{0}'  where OutboundID='{1}'", status, boundID);
            else
            { 
                sql = String.Format("update T_Outbound Set Status = '{0}'  , ConfirmTime = '{1}', ShipDate = '{2}'  where OutboundID='{3}'", 
                    status,
                    dtConfirm.ToString("yyyy-MM-dd HH:mm:ss"),
                    dtConfirm.ToString("yyyy-MM-dd"),
                    boundID);
            }
            Database.ExecuteSQL(sql, "FrmOutbound-UpdateOutboundStatus");
              
        }

        private bool HasCompleteOutbound(string boundID)
        {
            string sql = String.Format("select recordId,DealStatus From T_OutboundRecord where OutboundID = '{0}' and DealStatus <> '{1}'",
                boundID,
                MemoryTable.BackBound );
            System.Data.DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;

            int cnt = 0;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][1] == null || dt.Rows[i][1].ToString() != DealStatus.Complete)
                    continue;
                cnt++;
            }

            if (cnt == dt.Rows.Count)
                return true;
            return false;
        }

        private void UpdateNumOfReal(int rowHandle )
        {
            string recordID = "", detailID, shelfNo="";
            recordID = recordView.GetRowCellValue(rowHandle, "RecordID").ToString();
            detailID = recordView.GetRowCellValue(rowHandle, "DetailID").ToString();
            shelfNo = recordView.GetRowCellValue(rowHandle, "ShelfNo").ToString();
         
            Object obj = null;
            int numOfPlan = 0, numOfReal = 0;

            obj = recordView.GetRowCellValue(rowHandle, "NumOfPlan");
            if (obj != null)
                numOfPlan = Convert.ToInt32(obj);

            obj = recordView.GetRowCellValue(rowHandle, "NumOfReal");
            if (obj != null)
                numOfReal = Convert.ToInt32(obj);

            if (numOfReal == numOfPlan)
                return;

            //更新库存表，操作明细，出库明细等.
            string sql = String.Format("Update T_OutboundRecord Set  NumofReal =  {0}  Where recordID = '{1}' ",numOfReal,recordID);
            Database.ExecuteSQL(sql, "FrmOutbound-UpdateNumOfReal");

            string lotNo = recordView.GetRowCellValue(rowHandle, "LotNo").ToString();
            string sizeNo = recordView.GetRowCellValue(rowHandle, "SizeNo").ToString();

            int outboundKind = MemoryTable.Outbound_Kind_Gel;
            obj = outboundView.GetFocusedRowCellValue("OutboundKind");
            if (obj == null || obj.ToString().Trim().Length == 0)
                outboundKind = MemoryTable.Outbound_Kind_Gel;
            else
                outboundKind = Convert.ToInt32( obj );

            //出库明细
            sql = String.Format("Update T_OutboundDetail Set  NumofReal =  {0}  Where detailID = '{1}' and lotNo = '{2}' and SizeNo = '{3}' ", 
                numOfReal, 
                detailID,
                lotNo,
                sizeNo );

            Database.ExecuteSQL(sql, "FrmOutbound-UpdateNumOfReal");

            //修改库存表
            sql = String.Format("Update T_Inventory Set Quantity = Quantity + {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                numOfPlan - numOfReal, 
                shelfNo,
                lotNo,
                sizeNo);

            Database.ExecuteSQL(sql, "FrmOutbound-UpdateNumOfReal");

            if ( outboundKind  == MemoryTable.Outbound_Kind_99T)
            {
                sql = String.Format("Update T_Inventory Set Quantity = Quantity - {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                numOfPlan - numOfReal,
                MemoryTable.Shelf_99T99,
                lotNo,
                sizeNo);

                Database.ExecuteSQL(sql, "FrmOutbound-UpdateNumOfReal");
            }

        }

        #endregion

        #region 保存出库单

        private void SaveOutbound()
        {
            //保存顺序不能颠倒
            if (IsExistOutbound(txtOutboundNo.Text))
            {
                CancelNewOutbound(txtOutboundNo.Text);
                ClearDetail(txtOutboundNo.Text);

            }
          
            outboundDetailView.SaveOutboundDetail();

            if (InsertOutbound() == false)
            {
                MsgBox.Error("保存出库库单失败！");
                return;
            }
        }
 
        private OutBound newOutBound = null ;

        private bool UpdateOutbound(OutBound bound)
        {
            OutBound outbound = Replace(bound);

            String sql = String.Format("Update T_Outbound Set Operator='{0}' ,Sales = '{1}',ShipDate= '{2}',"
                      + " Address = '{3}', ShipTo = '{4}', SellTo = '{5}', Shippingway = '{6}',Term = '{7}' , Freight = '{8}', "
                      + " TrackingNo = '{9}', ShipBy = '{10}',OrderNo = '{11}', CustomerNo = '{12}',PaymentMode = '{13}' "
                      + " where OutboundID = '{14}'",
                outbound.Operator,
                outbound.Sales,
                outbound.ShipDate,
                outbound.Address,
                outbound.ShipTo,
                outbound.SellTo,
                outbound.Shippingway,
                outbound.Term,
                outbound.Freight,
                outbound.TrackingNo,
                outbound.ShipBy,
                outbound.OrderNo,
                outbound.CustomerNo,
                outbound.PaymentMode,
                outbound.OutboundID );

            int nres = Database.ExecuteSQL(sql, "FrmOutbound-UpdateOutbound");
            return nres > 0 ? true : false ;
        }

        private bool InsertOutbound()
        {
            bool bres = false;
            string time = Database.GetDateTimeString();
            string invoice = "1";
            string freight = "0";
            string oper = "";

            if (string.IsNullOrEmpty(txtFreight.Text.Trim()) == false )
                freight = txtFreight.Text.Trim();
            string term = "0";
            if (string.IsNullOrEmpty(nudTerm.Value.ToString()) == false)
                term = nudTerm.Value.ToString();

            string dtShip =  "";
            string sql = String.Format("Insert into T_Outbound (OutboundID, CreateTime, Operator ,OrderNo, ShipDate, "
                + " Sales, Commission, CustomerNo, SellTo, Address, TrackingNo, ShipBy, ShipTo, Shippingway, Term, Freight, InvoiceStatus, Status, OutboundKind,PaymentMode ) "
                + "Values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}' )", 
                txtOutboundNo.Text,
                time,
                oper ,
                txtOrderNo.Text.Replace("'","''"),
                dtShip,
                cboSales.Text.Replace("'","''"),
                "",//commission
                cboCustomerNo.Text.Replace("'", "''"),
                txtSellTo.Text.Replace("'", "''"),
                txtAddr.Text.Replace("'", "''"),
                txtTrackingNo.Text.Replace("'", "''"),
                "",//shipby
                txtShipTo.Text.Replace("'", "''"), 
                cboShipway.Text.Replace("'", "''"),
                nudTerm.Value.ToString(),
                freight,
                invoice, 
                DealStatus.PreSell,
                OutboundKind,
                cboPayment.Text.Replace("'", "''")
                );

            bres = Database.ExecuteSQL(sql, "FrmOutbound-InsertOutbound") == 1 ? true : false;
            if (bres)
            {
                newOutBound = new OutBound();
                newOutBound.OutboundID = txtOutboundNo.Text;
                newOutBound.OrderNo = txtOrderNo.Text;
                newOutBound.ShipDate = dtShip;
                newOutBound.Sales = cboSales.Text;
                newOutBound.Commission = "";
                newOutBound.CustomerNo = cboCustomerNo.Text.Trim();
                newOutBound.InvoiceStatus = invoice;
                newOutBound.CreateTime = time;
                newOutBound.ShipTo = txtShipTo.Text;
                newOutBound.SellTo = txtSellTo.Text;
                newOutBound.Address = txtAddr.Text;
                newOutBound.TrackingNo = txtTrackingNo.Text;
                newOutBound.ShipBy = "";
                newOutBound.Shippingway = cboShipway.Text;
                newOutBound.Term = term;
                newOutBound.Freight = freight;
                newOutBound.Operator = oper;
                newOutBound.Status = DealStatus.No;
                newOutBound.OutBoundKind = OutboundKind;
                newOutBound.PaymentMode = cboPayment.Text.Trim();
            }

            return bres;
        }

        private bool IsExistOutbound(string id)
        {
            string sql = String.Format("select OutboundID from T_Outbound where OutboundID = '{0}'", id);
            System.Data.DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        private OutBound Replace(OutBound outbound)
        {
            OutBound res = new OutBound();
            res.CreateTime = outbound.CreateTime;
            res.OutboundID = outbound.OutboundID;
            res.OutBoundKind = outbound.OutBoundKind;
            res.ShipDate = outbound.ShipDate;
            res.Freight = outbound.Freight;
            res.InvoiceStatus = outbound.InvoiceStatus;
            res.Status = outbound.Status;
            res.Term = outbound.Term;
            res.Operator = outbound.Operator.Replace("'", "''");
            res.OrderNo = outbound.OrderNo.Replace("'", "''");
            res.Sales = outbound.Sales.Replace("'", "''");
            res.CustomerNo = outbound.CustomerNo.Replace("'", "''");
            res.ShipTo = outbound.ShipTo.Replace("'", "''");
            res.SellTo = outbound.SellTo.Replace("'", "''");
            res.Shippingway = outbound.Shippingway.Replace("'", "''");
            res.Commission = outbound.Commission;
            res.Address = outbound.Address.Replace("'", "''");
            res.TrackingNo = outbound.TrackingNo.Replace("'", "''");
            res.ShipBy = outbound.ShipBy.Replace("'", "''");
            res.PaymentMode = outbound.PaymentMode.Replace("'", "''");

             if (String.IsNullOrEmpty(res.Term) )
                res.Term = "0";
            if( String.IsNullOrEmpty(res.Freight) )
                res.Freight = "0";

            return res;
        }
   
        #endregion

        #region 主表操作、事件、出库单确认、修改出库单

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //将操作单状态设置为完成
            if (CurrentOutboundStatus != Status_None)
                return;

            #region 虚拟入库转真实入库
           
            if (btnConfirm.Text == "Outbound")
            {
                VirtualToActual(outboundView.FocusedRowHandle);
                return;
            }
            
            #endregion

            #region 将操作单状态设置为完成

            int cnt = outboundRecordView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Infometion("请先选择出库操作纪录！");
                return;
            }
            
            //已经都出完库了。
            Object obj = outboundView.GetFocusedRowCellValue("Status");
            if (obj != null)
            {
                if (obj.ToString() == DealStatus.Finish)
                {
                    outboundRecordView.UnCheck();
                    return;
                }
            }
                 

            UpdateDealStatus(DealStatus.Complete);

            string id = outboundView.GetFocusedRowCellValue("OutboundID").ToString();

            if (HasCompleteOutbound(id) == true)
            {
                DateTime dtConfirm = DateTime.Now;
                UpdateOutboundStatus(id,dtConfirm , DealStatus.Finish);

                outboundView.SetFocusedRowCellValue("Status", DealStatus.Finish);
                outboundView.SetFocusedRowCellValue("ShipDate", dtConfirm.ToString("yyyy-MM-dd"));
            }

            outboundRecordView.UnCheck();

            if (HasCompleteOutbound(id) == true)
                btnConfirm.Enabled = false;
            
            #endregion

        }
         
        private void mnuMasterEditOutbound_Click(object sender, EventArgs e)
        {
            string boundno = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            FrmEditOutbound dlg = new FrmEditOutbound();
            dlg.OutboundID = boundno;
            if (DialogResult.OK != dlg.ShowDialog())
                return;

            OutBound outbound = dlg.OutboundItem;
            if (UpdateOutbound(outbound) )
                UpdateFoucusedOutbound(outboundView.FocusedRowHandle, outbound);
                       
        }

        public void UpdateFoucusedOutbound(int pos, OutBound bound)
        {
            outboundView.BeginUpdate();
             
            outboundView.SetRowCellValue(pos,"OutboundID", bound.OutboundID);
            outboundView.SetRowCellValue(pos, "OrderNo", bound.OrderNo);
            outboundView.SetRowCellValue(pos, "ShipDate", bound.ShipDate);
            outboundView.SetRowCellValue(pos, "Sales", bound.Sales);
            outboundView.SetRowCellValue(pos, "CustomerNo", bound.CustomerNo);

            outboundView.SetRowCellValue(pos, "Commission", bound.Commission);
            outboundView.SetRowCellValue(pos, "SellTo", bound.SellTo);
            outboundView.SetRowCellValue(pos, "Address", bound.Address);
            outboundView.SetRowCellValue(pos, "TrackingNo", bound.TrackingNo);

            outboundView.SetRowCellValue(pos, "ShipBy", bound.ShipBy);
            outboundView.SetRowCellValue(pos, "ShipTo", bound.ShipTo);
            outboundView.SetRowCellValue(pos, "Shippingway", bound.Shippingway);
            outboundView.SetRowCellValue(pos, "Term", bound.Term);
            outboundView.SetRowCellValue(pos, "Freight", bound.Freight);

            outboundView.SetRowCellValue(pos, "Operator", bound.Operator);
            outboundView.SetRowCellValue(pos, "InvoiceStatus", bound.InvoiceStatus);
            outboundView.SetRowCellValue(pos, "Status", bound.Status);

            outboundView.SetRowCellValue(pos, "PaymentMode", bound.PaymentMode);

            outboundView.EndUpdate();
        }

        private void outboundView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SwitchOutbound();
        }

        private void xtraTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (CurrentOutboundStatus == Status_None)
                SetConfirmButtonVisible();
        }

        #endregion

        #region 明细表编辑、插入、删除、快捷键

        private void RemoveRows()
        {
            int[] rows = detailView.GetSelectedRows();

            if (MsgBox.Confirm("您确定要删除所有选中的数据吗？ ") == false)
                return;
            outboundDetailView.RemoveRows(rows);

        }

        private void InsertRow()
        {
            int pos = detailView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            System.Data.DataTable dt = detailGrid.DataSource as System.Data.DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        private void detailView_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentOutboundStatus == Status_None)
                return;
            if (e.KeyCode == Keys.Delete)
                RemoveRows();
            else if (e.KeyCode == Keys.Insert)
                InsertRow();
        }

        private void mnuInsertRow_Click(object sender, EventArgs e)
        {
            InsertRow();
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }

        #endregion
        
        #region 出库记录表操作、全选、不选等右键菜单

        private void mnuCheckAll_Click(object sender, EventArgs e)
        {
            outboundRecordView.CheckAll();
        }

        private void mnuNoCheck_Click(object sender, EventArgs e)
        {
            outboundRecordView.UnCheck();
        }

        private void ctxMenuRecord_Opening(object sender, CancelEventArgs e)
        {

        }

        #endregion

        #region 发票

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            invoiceDetailView.SavePrice();
            FrmTip.ShowTip("保存发票信息成功！");
        }

        #endregion

        #region  Customer客户管理等
       
        private List<Customer> TempCustomerList = null;
        private int nTempCutomerIndex = -1;
     
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            nTempCutomerIndex = -1;
            CustomerHelper ch = new CustomerHelper();
            string txt = txtSellTo.Text.Trim();
            TempCustomerList  = ch.GetCustomerBySellTo(txt);
            if (TempCustomerList == null || TempCustomerList.Count == 0)
                return;
            Customer obj = TempCustomerList[0];
            cboCustomerNo.Text = obj.CustomerNo;
            cboSales.Text = obj.Sales;
            txtSellTo.Text = obj.Company;
            txtShipTo.Text = obj.ShipTo;
            txtAddr.Text = obj.Address;
            cboShipway.Text = obj.ShippingWay;
            nudTerm.Value = Convert.ToDecimal(obj.Term);
            txtFreight.Text = obj.Freight;
            nTempCutomerIndex = 0;
            SwitchCustomer(nTempCutomerIndex);

        }

        private void ComboBoxCustomerNo_TextChanged(object sender, EventArgs e)
        {
            string txt = cboCustomerNo.Text;

            Customer obj = cboCustomerNo.SelectedItem as Customer;

            if (obj != null)
            {
                cboSales.Text = obj.Sales;
                txtSellTo.Text = obj.Company;
                txtShipTo.Text = obj.ShipTo;
                txtAddr.Text = obj.Address;
                cboShipway.Text = obj.ShippingWay;
                nudTerm.Value = Convert.ToDecimal(obj.Term);
                txtFreight.Text = obj.Freight;
            }
            else
            {
                cboSales.Text = "";
                txtSellTo.Text = "";
                txtAddr.Text = "";
                txtShipTo.Text = "";
            }

        }

        private void SaveCustomer()
        {
            Customer cus = new Customer();
            Customer sel = cboCustomerNo.SelectedItem as Customer;
            
            if (sel != null)
            { 
                cus.ID = sel.ID; 
            }

            cus.Sales = cboSales.Text.Trim();
            cus.CustomerNo = cboCustomerNo.Text.Trim();
            cus.Company = txtSellTo.Text.Trim();
            cus.Address = txtAddr.Text;
            cus.ShipTo = txtShipTo.Text;
            cus.ShippingWay = cboShipway.Text;
            cus.Term = nudTerm.Value.ToString();
            cus.Freight = txtFreight.Text.Trim();

            CustomerHelper ch = new CustomerHelper();
             
            if (ch.FindCustomer(cus.CustomerNo) )
                ch.UpdateCustomer(cus);

            else
                ch.InsertCustomer(cus);

        }


        private void btnPrevCustomer_Click(object sender, EventArgs e)
        {
            nTempCutomerIndex--;
            SwitchCustomer(nTempCutomerIndex);
        }

        private void btnNextCustomer_Click(object sender, EventArgs e)
        {
            nTempCutomerIndex++;
            SwitchCustomer(nTempCutomerIndex);
        }

        private void SwitchCustomer(int idx)
        {
            if ( idx < 0 || TempCustomerList == null || TempCustomerList.Count <= 1 )
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = false;

                return;
            }
            if (idx <= TempCustomerList.Count - 1)
            {
                Customer obj = TempCustomerList[idx];
                cboCustomerNo.Text = obj.CustomerNo;
                cboSales.Text = obj.Sales;
                txtSellTo.Text = obj.Company;
                txtShipTo.Text = obj.ShipTo;
                txtAddr.Text = obj.Address;
                cboShipway.Text = obj.ShippingWay;
                nudTerm.Value = Convert.ToDecimal(obj.Term);
                txtFreight.Text = obj.Freight;
            }
            if (idx == 0 && TempCustomerList.Count <= 1 )
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = false;

                return;
            }
            if (idx == 0 )
            {
                btnPrevCustomer.Enabled = false;
                btnNextCustomer.Enabled = true;
                return;
            }

            if (idx >= TempCustomerList.Count - 1)
            {
                btnNextCustomer.Enabled = false;
                btnPrevCustomer.Enabled = true;
                return;
            }

            btnNextCustomer.Enabled = true;
            btnPrevCustomer.Enabled = true;

        }

        #endregion

        #region 退货

        private void mnuMasterBack_Click(object sender, EventArgs e)
        { 
            Backbound();
        }

        private void Backbound()
        {
            string outboundID = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
             
            int outboundKind = MemoryTable.Outbound_Kind_Gel;
            Object obj = outboundView.GetFocusedRowCellValue("OutboundKind");
            if (obj == null || obj.ToString().Trim().Length == 0)
                outboundKind = MemoryTable.Outbound_Kind_Gel;
            else
                outboundKind = Convert.ToInt32(obj);

            CurrentOutboundStatus = Status_Back;
            backDetailView.OutboundID = outboundID;
            backDetailView.OutboundKind = outboundKind;
            backDetailView.ClearRows();
            backDetailView.SetGridEditStatus(true);
            backDetailView.LoadBackBoundCombobox();
            
            InitUI_Backbound();
        }

        private void SaveBackbound()
        {
            backDetailView.SaveBackbound();
        }

        #endregion

        #region 出库表右键菜单 ，包括强制完成订单

        private void mnuMasterComplete_Click(object sender, EventArgs e)
        {
            Object obj = outboundView.GetFocusedRowCellValue("OutboundID");
            if (obj == null)
                return;
            if (MsgBox.Confirm("您确定要完成选中的出库单？") == false)
                return;

            string outboundID = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            string sql = String.Format(" Update T_OutboundRecord Set DealStatus = 'complete' where OutboundID = '{0}' and DealStatus <> '{1}' ",
                outboundID,
                MemoryTable.BackBound );

            Database.ExecuteSQL(sql, "FrmOutbound-mnuMasterComplete_Click");

            obj = outboundView.GetFocusedRowCellValue("Status");
            if (obj != null)
            {
                if (obj.ToString() == DealStatus.Finish)
                    return;
            }
            DateTime dtConfirm = DateTime.Now;
            UpdateOutboundStatus(outboundID, dtConfirm, DealStatus.Finish);
            outboundView.SetFocusedRowCellValue("Status", DealStatus.Finish);
            outboundView.SetFocusedRowCellValue("ShipDate", dtConfirm.ToString("yyyy-MM-dd"));
            outboundRecordView.LoadOutboundRecord(outboundID);

        }
               
        private void ctxMenuMaster_Opening(object sender, CancelEventArgs e)
        {
            Object obj = outboundView.GetFocusedRowCellValue("OutboundID");
            if (obj == null)
            {
                e.Cancel = true;
                return;
            }
           
            mnuMasterComplete.Visible = true;
            
            //2016-07-29放开修改和删除操作，用户要求放开。
            mnuMasterDelete.Enabled = true;
            mnuMasterEditOutbound.Enabled = true; 
            mnuMasterSetOperator.Enabled = true;

            string status = outboundView.GetFocusedRowCellValue("Status").ToString();

            if (status == DealStatus.PreSell)
            {
                mnuMasterBack.Enabled = false;
                mnuMasterExportReocrd.Enabled = false;
                mnuMasterPrintRecord.Enabled = false;
            }
            else
            {
                mnuMasterBack.Enabled = true;
                mnuMasterExportReocrd.Enabled = true;
                mnuMasterPrintRecord.Enabled = true;
            }

            if (string.IsNullOrEmpty(status) || status == DealStatus.Finish || status == DealStatus.PreSell )
            {
                mnuMasterComplete.Enabled = false;
            }
            else
            { 
                mnuMasterComplete.Enabled = true; 
            }
        } 
        
        #endregion

        #region 佣金
        
        //获取佣金的状态
        private bool HasCommission(string sales = null )
        {
            string text = "";
            if (sales != null)
                text = sales.ToUpper();
            else
                text = cboSales.Text.Trim().ToUpper();

            if (text == "NO")
                return false;
            return true;
        }
                
        #endregion

        #region 拆箱

        private void btnPacking_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string orderNo = outboundView.GetFocusedRowCellValue("OrderNo").ToString();
                ExportOutboundPacking exp = new ExportOutboundPacking(invoiceView);
                exp.PoNo = orderNo;
                exp.Export(fileDialog.FileName);
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        } 
        #endregion

        #region 填写订单时，显示最后一个订单的编号

        private void btnTip_Click(object sender, EventArgs e)
        {
            string text = txtOrderNo.Text.Trim();
            if(string.IsNullOrEmpty(text)==false)
                txtOrderNo.Text = GetLastPoNo(text) ;
        }

        private string GetLastPoNo(string text)
        {
            string sql = string.Format("Select OrderNo ,CreateTime from T_Outbound where OrderNo like '{0}%' Order By CreateTime Desc Limit 1",text);

            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return text;
            string temp = dt.Rows[0][0].ToString();
            return  temp;
        }


        #endregion

        #region 真实出库
       
        //取消虚拟转真实操作
        private void CancelVirtualToActual(string outboundNo)
        {
            string sql = "";

            Cursor.Current = Cursors.WaitCursor;

            //1删除入库操作单
            ClearRecord(outboundNo);
            outboundRecordView.ClearRows();

            
            //2根据77S77库存恢复操作明细
            //用户要求保留更改，不要恢复删除新修改的明细
            //RestoreVirtualOutboundDetail(outboundNo);

            //3恢复入库单的虚拟属性
            sql = string.Format("Update T_Outbound Set Status = '{0}' where OutboundID = '{1}' and Status = '{2}'",
                DealStatus.PreSell, 
                outboundNo , 
                DealStatus.Outbound );

            Database.ExecuteSQL(sql);

            outboundView.SetFocusedRowCellValue("Status", DealStatus.PreSell);
            Cursor.Current = Cursors.Default;

        }

        private void RestoreVirtualOutboundDetail(string outboundNo)
        {
            string sqlInventory = string.Format("select lotno , sizeno , quantity, UserDefine2, UserDefine3 from t_inventory where shelfNo = '{0}' and userdefine1 = '{1}' order by lotno , sizeno ",
                MemoryTable.Shelf_77S77,
                outboundNo);

            DataTable dtInventory = Database.Select(sqlInventory);

            if (dtInventory == null || dtInventory.Rows.Count == 0)
                return;
            string lotno = "", sizeno = "", temp = "";
            string price = "0",woprice = "0";
            string sqlUpdate = "";
            int qnt = 0;
            for (int i = 0; i < dtInventory.Rows.Count; i++)
            {
                lotno = dtInventory.Rows[i][0].ToString();
                sizeno = dtInventory.Rows[i][1].ToString();
                temp = dtInventory.Rows[i][2].ToString();
                if (temp == "")
                    temp = "0";
                qnt = 0 - Convert.ToInt32(temp);
                price = dtInventory.Rows[i][3].ToString();
                woprice = dtInventory.Rows[i][4].ToString();

                sqlUpdate = string.Format("Update T_OutboundDetail Set NumOfPlan = '{0}' , NumOfReal = '{0}', funds = '{1}', woPrice='{2}' "
                          +" where OutboundID = '{3}' and LotNo = '{4}' and SizeNo = '{5}' ",
                    qnt,
                    price,
                    woprice, 
                    outboundNo,
                    lotno,
                    sizeno);

                Database.ExecuteSQL(sqlUpdate);

            }

            dtInventory.Clear();
        }
        
        private void VirtualToActual(int iRow)
        {
            if (iRow < 0)
                return;

            txtOutboundNo.Text = outboundView.GetFocusedRowCellValue("OutboundID").ToString();
            InitUI_Search();

            InitUI_Edit();
            panOutbundBtn.Visible = true;
         
            InitUI_DetailOut();

            CurrentOutboundStatus = Status_Detail;
            AppEditStatus.OutboundCurrentStatus = CurrentOutboundStatus;
            outboundDetailView.OutboundID = txtOutboundNo.Text;
            outboundDetailView.Loading();

            outboundDetailView.SetGridEditStatus(true);
        }

        //是否允许真正出库？
        private bool CanActualOutbound()
        {
            if (outboundDetailView.CanActualOutbound() == false)
            {
                MsgBox.Error(outboundDetailView.ErrorMsg);
                return false;
            }
            return true; 
        }

        #endregion

        #region 删除77S77中的数据

        private void DeleteVirtualInvenotry(string strOutboundID)
        {
            //删除虚拟库存
            string sqlDelete = string.Format("Delete from T_Inventory  WHERE UserDefine1='{0}' and ShelfNo = '{1}'", strOutboundID, MemoryTable.Shelf_77S77);
            Database.ExecuteSQL(sqlDelete);
        }
        #endregion

       
    }
}

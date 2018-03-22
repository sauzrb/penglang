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
    public partial class FrmInbound : DevExpress.XtraEditors.XtraForm,InnerForm
    {
        InboundMasterView inboundMasterView;
        InboundDetailView inboundDetailView;
        InboundRecordView inboundRecordView;

        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 窗体构造与初始化

        public FrmInbound()
        {
            InitializeComponent();
            
            splitContainer.Collapsed = false;

            inboundMasterView = new InboundMasterView(this.inboundView);
            inboundDetailView = new InboundDetailView(this.detailView);
            inboundRecordView = new InboundRecordView(this.recordView);
             
        }
              
        private void FrmInbound_Load(object sender, EventArgs e)
        {
            
            InitUI_FormLoad();
             
            inboundMasterView.Initialize();
             
            inboundDetailView.Initialize();
            inboundRecordView.Initialize();

            inboundDetailView.SetGridEditStatus(false);
            inboundRecordView.SetGridEditStatus(true);

            if (Database.IsConnected())
                inboundMasterView.Loading();
             
        }

        private void tpProperty_Resize(object sender, EventArgs e)
        { 
            groupInbound.Left = tpProperty.Width / 2 - groupInbound.Width / 2; 
            groupInbound.Top = tpProperty.Height / 2 - groupInbound.Height / 2;
            
        }

        #endregion

        #region 设置界面状态

        private int CurrentInboundStatus = 0;
        const int Status_None = 0; //查询  
        const int Status_Property = 1;//填写属性 
        const int Status_Detail = 2;  //编辑明细
        const int Status_Record = 3;  //操作单 
        const int Status_Complete = 4;//完成

        private void InitUI_Search(bool bFlag)
        {
            btnSearch.Visible = bFlag;
            btnInbound.Visible = bFlag;
            lblBeginDate.Visible = bFlag;
            lblEndDate.Visible = bFlag;
            dateBegin.Visible = bFlag;
            dateEnd.Visible = bFlag;
            lblKeyWords.Visible = bFlag;
            txtKeyWords.Visible = bFlag;
            btnPrint.Visible = bFlag;

            detailGrid.ContextMenuStrip = null;
            recordGrid.ContextMenuStrip = ctxMenuRecord;
        }
        
        private void InitUI_FormLoad()
        {
            btnCancel.Top = btnPrint.Top;
            btnCancel.Left = btnPrint.Left;

            btnComplete.Left = btnNext.Left;
            btnComplete.Top = btnNext.Top;

            btnConfirm.Top = btnComplete.Top;
            btnConfirm.Left = btnComplete.Left;


            splitContainer.Collapsed = false;
            splitContainer.IsSplitterFixed = false;

            xtraTab.ShowTabHeader = DefaultBoolean.True;
            tpRecord.PageVisible = true;
            tpDetail.PageVisible = true;
            tpProperty.PageVisible = false; 
            
            btnPrev.Visible = false;
            btnNext.Visible = false;
            btnComplete.Visible = false;
            btnPrint.Visible = false;
            btnCancel.Visible = false;
            btnConfirm.Visible = false;

            InitUI_Search(true);
        }
          
        private void InitUI_Property()
        {
            splitContainer.IsSplitterFixed = true;
            splitContainer.Collapsed = true;

            xtraTab.ShowTabHeader = DefaultBoolean.False;
            tpRecord.PageVisible = false;
            tpDetail.PageVisible = false; 
            tpProperty.PageVisible = true;
            

            btnPrev.Visible = true; 
            btnPrev.Enabled = false;

            btnNext.Visible = true; 
            btnNext.Enabled = true;
            
            btnNext.Text = "Next";

            btnComplete.Visible = false;
            btnComplete.Enabled = false;

            btnCancel.Visible = true;
            btnCancel.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;

            InitUI_Search(false);

           
        }
 
        private void InitUI_Detail( bool bVirtual = false )
        {
            xtraTab.ShowTabHeader = DefaultBoolean.False;
           
            tpDetail.PageVisible = true;
            tpProperty.PageVisible = false;
            tpRecord.PageVisible = false;  
            btnPrev.Enabled = true;

            if (bVirtual == false)
            {  //真实入库
                btnNext.Visible = true;
                btnNext.Enabled = true;
                btnNext.Text = "Distribute";
                btnComplete.Visible = false;
                btnComplete.Enabled = false;
                btnCancel.Enabled = true;
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;

                btnPrev.Visible = true;
                btnPrev.Enabled = false;
            }
            else 
            { //虚拟入库
                btnNext.Visible = false;
                btnNext.Enabled = false;
                btnComplete.Visible = true;
                btnComplete.Enabled = true;
                btnCancel.Enabled = true;
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;
            }
            detailGrid.ContextMenuStrip = ctxMenuDetail ;
        }
       
        private void InitUI_Record()
        {
            xtraTab.ShowTabHeader = DefaultBoolean.False;

            tpRecord.PageVisible = true;
            tpDetail.PageVisible = false;
            tpProperty.PageVisible = false; 

            btnPrev.Enabled = true;
                       
            btnNext.Visible = false;
            btnNext.Enabled = false;
            btnNext.Text = "Next";

            btnComplete.Visible = true;
            btnComplete.Enabled = true;
            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;

            detailGrid.ContextMenuStrip = null;
            btnCancel.Enabled = true;

            inboundRecordView.SetGridEditStatus(false);
        }
              
        private void InitUI_Complete()
        {
            InitUI_FormLoad();
            inboundDetailView.SetGridEditStatus(false);
            inboundRecordView.SetGridEditStatus(true);
        }
       
        #endregion
       
        #region 按钮事件

        //添加订单
        private void btnInbound_Click(object sender, EventArgs e)
        {
            txtInboundNo.Text = Database.GetDataTimekey(1);
            txtProductNo.Text = "";
            txtDealWorker.Text = "";

            if (string.IsNullOrEmpty(dateOrder.Text))
                dateOrder.Text = DateTime.Now.ToString("yyyy-MM-dd");

            InitUI_Property();

            CurrentInboundStatus = Status_Property;
            txtProductNo.Focus();
            
            cbVirtual.Checked = true;

            inboundDetailView.SetGridEditStatus(true);
            inboundRecordView.SetGridEditStatus(false);

            inboundDetailView.InboundID = txtInboundNo.Text;
            inboundRecordView.InboundID = txtInboundNo.Text;

            inboundRecordView.ClearRows();
            inboundDetailView.ClearRows();

            AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
            bVirtualToActual = false;
        }
               
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("您确定要放弃本次入库操作吗？") == false)
                return;

            InitUI_Complete();
            CurrentInboundStatus = Status_None;

            if (newInbound != null && bVirtualToActual == false )
            {
                RemoveNewInbound(newInbound.InboundID);
            }
            else if(newInbound  ==null && bVirtualToActual == false)
            {   //虚拟入库转正式入库的明细放弃
                FocusedMasterRow(inboundView.FocusedRowHandle);
                bVirtualToActual = false;
            }
            else if (newInbound == null && bVirtualToActual == true)
            {
                string inboundId = inboundDetailView.InboundID;
                CancelVirtualToActual(inboundId);
                FocusedMasterRow(inboundView.FocusedRowHandle);
                bVirtualToActual = false;
            }

            AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
        }
      
        //完成
        private void btnComplete_Click(object sender, EventArgs e)
        {
            #region 真实入库完成任务分解

            if (CurrentInboundStatus == Status_Record)
            {
                InitUI_Complete();

                AppEditStatus.InboundCurrentStatus = Status_Complete;

                CurrentInboundStatus = Status_None;
                MissionAssign missionAssign = new MissionAssign();
                missionAssign.InboundComplete(txtInboundNo.Text);

                if (newInbound != null)
                {
                    inboundMasterView.InsertInbound(0, newInbound);

                    inboundView.FocusedRowHandle = 0;

                    newInbound = null;

                    this.Refresh();

                    PrintGrid(recordGrid);

                }
                else
                {
                    //虚拟转真实
                    FocusedMasterRow( inboundView.FocusedRowHandle);
                    inboundView.SetFocusedRowCellValue("Status", DealStatus.Inbound);
                    this.Refresh(); 
                    PrintGrid(recordGrid);
                }
                return;
            }

            #endregion

            #region 虚拟入库,将入库明细分配到88T88

            if (CurrentInboundStatus == Status_Detail && cbVirtual.Checked == true )
            { //虚拟入库

                //保存明细
                SaveInbound();
                MissionAssign missionAssign = new MissionAssign();

                missionAssign.VirtualInboundAssign(txtInboundNo.Text);
                UpdateOperator(txtInboundNo.Text, txtDealWorker.Text);

                InitUI_Complete();

                AppEditStatus.InboundCurrentStatus = Status_Complete;

                CurrentInboundStatus = Status_None;

                if (newInbound != null)
                {
                    inboundMasterView.InsertInbound(0, newInbound);

                    inboundView.FocusedRowHandle = 0;

                    newInbound = null;

                    this.Refresh(); 

                }
                return ;
            }
            #endregion

        }

        //确认
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //将操作单状态设置为完成
            if (CurrentInboundStatus != Status_None)
                return;

            //虚拟入库转真实入库
            if (btnConfirm.Text == "Inbound")
            {
                VirtualToActual(inboundView.FocusedRowHandle);
                return;
            }

            int cnt = inboundRecordView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Infometion("请先选择入库操作纪录！");
                return;
            }

            #region 真实入库确认

            Object obj = inboundView.GetFocusedRowCellValue("Status");
            if (obj != null)
            {
                if (obj.ToString() == DealStatus.Finish)
                {
                    inboundRecordView.UnCheck();
                    return;
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            UpdateDealStatus( DealStatus.Complete );

            obj = inboundView.GetFocusedRowCellValue("InboundID");
            if (obj == null)
            {
                Cursor.Current = Cursors.Default;
                return;
            }

            string id = inboundView.GetFocusedRowCellValue("InboundID").ToString();

            if (HasCompleteInbound(id) == true)
            {

                UpdateInboundStatus(id, DealStatus.Finish );

                inboundView.SetFocusedRowCellValue("Status", DealStatus.Finish);
            }

            inboundRecordView.UnCheck();

            Cursor.Current = Cursors.Default;

            #endregion

        }
        
        //上一步
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentInboundStatus <= Status_Property)
            {
                AppEditStatus.InboundCurrentStatus = Status_None;
                return;
            }
            if (CurrentInboundStatus == Status_Detail)
            {
                InitUI_Property();
                CurrentInboundStatus = Status_Property;
                AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
                return;
            }

            if (CurrentInboundStatus == Status_Record)
            {
                ClearRecord(txtInboundNo.Text);
                InitUI_Detail(false);
                CurrentInboundStatus = Status_Detail;
                AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
                return;
            }
            
        }
      
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentInboundStatus == Status_Record )
                return;
            if (CanNext() == false)
                return;

            if (CurrentInboundStatus == Status_Property)
            {
                InitUI_Detail( cbVirtual.Checked );
                CurrentInboundStatus = Status_Detail;
                AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
                return;
            }
            
            if (CurrentInboundStatus == Status_Detail)
            {
                //真实入库 或者 虚拟转真实
                if (cbVirtual.Checked == false || bVirtualToActual == true )
                {
                    FrmSetShelfSize dlg = new FrmSetShelfSize();
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        MemoryTable.Instance.ShelfCapacity = dlg.ShelfCapacity;
                }

                WaitingService.BeginLoading("正在分解入库明细，请稍等......");
                //Cursor.Current = Cursors.WaitCursor;

                //保存明细
                SaveInbound();

                //2017-05-29客户要求随时更改入库明细并，保存新的虚拟入库。
                //首先删除原来的虚拟入库
                DeleteVirtualInvenotry(txtInboundNo.Text);
                 
                MissionAssign missionAssign = new MissionAssign(); 

                //重新虚拟入库
                missionAssign.VirtualInboundAssign(txtInboundNo.Text);

                //真实入库、虚拟转真实都要分解
                //分解
                missionAssign.InboundAssign(txtInboundNo.Text);

                UpdateOperator(txtInboundNo.Text, txtDealWorker.Text);
                //加载明细
                inboundRecordView.LoadInboundRecord(txtInboundNo.Text);

                InitUI_Record();

                if (bVirtualToActual == true)
                {
                    inboundView.SetFocusedRowCellValue("Status", DealStatus.Inbound); 
                }

                CurrentInboundStatus = Status_Record;
                //Cursor.Current = Cursors.Default;
                AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
               
                WaitingService.EndLoading();

                return;
            }
             
        }
        
        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = GetFilterSql();
            inboundMasterView.KeyWords = sql;
            inboundMasterView.Loading();
            SwitchInbound();
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string sql = GetFilterSql();
                inboundMasterView.KeyWords = sql;
                inboundMasterView.Loading();
                SwitchInbound();
            }
        }

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and OrderDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and OrderDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            if (txtKeyWords.Text.Trim().Length > 0)
            {
                sql += String.Format(" and ProductNo like '%{0}%'", txtKeyWords.Text);
            }
            return sql;
        }

        #endregion

        #region 主表操作、事件

        private void inboundView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SwitchInbound();
            FocusedMasterRow(inboundView.FocusedRowHandle);
        }

        private void SwitchInbound()
        {
            inboundDetailView.ClearRows();
            inboundRecordView.ClearRows();
            splitContainer.Collapsed = false;
            //刷新明细表格
            if (inboundView.GetFocusedRowCellValue("InboundID") == null)
                return;
            string inboundno = inboundView.GetFocusedRowCellValue("InboundID").ToString();
            inboundRecordView.LoadInboundRecord(inboundno);
            inboundDetailView.InboundID = inboundno;
            inboundDetailView.Loading();
            SetCompleteButtonVisible();
        }

        private void SetCompleteButtonVisible()
        {
            Object obj = inboundView.GetFocusedRowCellValue("Status");
            if (obj == null)
            { 
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;

                return;
            }

            string status = inboundView.GetFocusedRowCellValue("Status").ToString();

            if (status == DealStatus.Finish)
            {  
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;

            }
            else  
            { 
                btnConfirm.Visible = true;
                btnConfirm.Enabled = true;
            }
             
        }
       
        private void xtraTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if ( CurrentInboundStatus == Status_None )
                SetCompleteButtonVisible();
        }
        
        #endregion
          
        #region 打印、导出

        private void PrintGrid(GridControl grid)
        {
            string orderNo = inboundView.GetFocusedRowCellValue("ProductNo").ToString();
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";      
            if( grid == detailGrid )
                ExportGridView.ExportDetail(this.detailView, tempFile);
            else
                ExportGridView.ExportRecord(orderNo,this.recordView, tempFile);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile); //保存v
        }

        private void PrintGrid_ExA(GridControl grid)
        {
            PrintingSystem print = new DevExpress.XtraPrinting.PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(print);
            print.Links.Add(link);
            link.Component = grid;//这里可以是可打印的部件
            string _PrintHeader = "入库操作单";
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
            phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;
            link.CreateDocument(); //建立文档
            print.PreviewFormEx.Show();//进行预览
        }
        /// <summary>
        /// exoprt
        /// </summary>
        /// <param name="grid"></param>

        private void ExportDetail(GridControl grid)                                                   
        {
            SaveFileDialog fileDialog = new SaveFileDialog();       ///储存文件提示框类
            fileDialog.Title = "导出Excel";           ///标题
            fileDialog.Filter = "Excel (*.xls)|*.xls";      ///存储类型
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                ExportGridView.ExportDetail(this.detailView, fileDialog.FileName);

                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
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
                string orderNo = inboundView.GetFocusedRowCellValue("ProductNo").ToString();
                ExportGridView.ExportRecord( orderNo, this.recordView, fileDialog.FileName); 
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (inboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择入库单！");
                return;
            }

            if (xtraTab.SelectedTabPage == tpDetail)
                PrintGrid(detailGrid);
            else if (xtraTab.SelectedTabPage == tpRecord)
                PrintGrid(recordGrid);
        }

        private void mnuMasterExportDetail_Click(object sender, EventArgs e)
        {
            if (inboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择入库单！");
                return;
            }
            ExportDetail(detailGrid);
        }

        private void mnuMasterPrintDetail_Click(object sender, EventArgs e)
        {
            if (inboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择入库单！");
                return;
            }

            PrintGrid(detailGrid);
        }

        private void mnuMasterExportReocrd_Click(object sender, EventArgs e)
        {
            if (inboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择入库单！");
                return;
            }
            ExportRecord(recordGrid);
        }

        private void mnuMasterPrintRecord_Click(object sender, EventArgs e)
        {
            if (inboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择入库单！");
                return;
            }
            PrintGrid(recordGrid);
        }
        
        #endregion

        #region 明细表编辑

        private bool CanNext()
        {
            bool bres = true;

            if (CurrentInboundStatus == Status_Property)
            {
                 
                if (txtProductNo.Text.Trim().Length == 0)
                {
                    MsgBox.Error("请填写订单号！");
                    return false;
                }
                if (dateOrder.Text.Trim().Length == 0)
                {
                    MsgBox.Error("请填写订单日期！");
                    return false;
                }

            }

            return bres;

        }

        private void RemoveRows()
        {
            int[] rows = detailView.GetSelectedRows();
          
            if (MsgBox.Confirm("您确定要删除所有选中的数据吗？ ") == false)
                return;
            inboundDetailView.RemoveRows(rows);

        }

        private void InsertRow()
        {
            int pos = detailView.FocusedRowHandle;
            if (pos < -1)
                pos = 0;
            System.Data.DataTable dt = detailGrid.DataSource as System.Data.DataTable;
            if (dt == null)
                return;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }

        private void detailView_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentInboundStatus == Status_None)
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

        #region 保存入库单

        private void SaveInbound()
        {
            //保存顺序不能颠倒
            if (IsExistInbound(txtInboundNo.Text))
            {
                if(bVirtualToActual == false )
                    RemoveNewInbound(txtInboundNo.Text); 
                ClearDetail(txtInboundNo.Text);
            }

            inboundDetailView.SaveInboundDetail();

            if (bVirtualToActual == false)
            {
                if (InsertInbound() == false)
                {
                    MsgBox.Error("保存入库单失败！");
                    return;
                }
            }

        }
     
        private InBound newInbound = null;

        private bool InsertInbound()
        { 
            bool bres = false;
            string time = Database.GetDateTimeString();
            string sql = String.Format("Insert into T_Inbound (InboundID, ProductNo,OrderDate, CreateTime, Operator, Status ) "
                + "Values('{0}','{1}','{2}','{3}','{4}','{5}' )", 
                txtInboundNo.Text,
                txtProductNo.Text.Replace("'", "''"),
                dateOrder.DateTime.ToString("yyyy-MM-dd") ,
                time,
                txtDealWorker.Text.Replace("'", "''"),
                DealStatus.PreInput );

            bres = Database.ExecuteSQL(sql, "FrmInbound-InsertInbound") == 1 ? true : false;
            if (bres)
            {
                newInbound = new InBound();
                newInbound.InboundID = txtInboundNo.Text;
                newInbound.ProductNo = txtProductNo.Text.Replace("'", "''");
                newInbound.Operator = txtDealWorker.Text.Replace("'", "''");
                newInbound.CreateTime = time;
                newInbound.OrderDate = dateOrder.DateTime.ToString("yyyy-MM-dd");
                newInbound.Status = DealStatus.PreInput; 
            }
            return bres;
        }

        private bool IsExistInbound(string id)
        {
            string sql = String.Format("select inboundID from T_Inbound where InboundID = '{0}'", id);
            System.Data.DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }
        
        #endregion

        #region 更改操作人

        private void mnuMasterSetOperator_Click(object sender, EventArgs e)
        {
            int rowID = inboundView.FocusedRowHandle;

            string status = inboundView.GetFocusedRowCellValue("Status").ToString();
            if (status == DealStatus.Yes)
            {
                MsgBox.Infometion("已经完成的入库单，不能修改操作人！");
                return;
            }
            FrmSelectOperator dlg = new FrmSelectOperator();

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string id = inboundView.GetRowCellValue(rowID, "InboundID").ToString();
            UpdateOperator(id, dlg.OperatorName);

            inboundView.SetRowCellValue(rowID, "Operator", dlg.OperatorName);
             
            inboundRecordView.LoadInboundRecord(id);
        }

        private void UpdateOperator(string inboundID, string oper)
        {
            string sql = "";

            sql = String.Format("Update T_InboundRecord Set DealUser = '{0}' where InboundID = '{1}'", oper.Replace("'", "''"), inboundID);

            Database.ExecuteSQL(sql, "FrmInbound-UpdateOperator");

            sql = String.Format("Update T_Inbound Set Operator = '{0}' where InboundID = '{1}'", oper.Replace("'", "''"), inboundID);

            Database.ExecuteSQL(sql, "FrmInbound-UpdateOperator");

        }

        #endregion

        #region 删除入库单
         
        private void mnuMasterDelete_Click(object sender, EventArgs e)
        {
            string inboundID = inboundView.GetFocusedRowCellValue("InboundID").ToString();
            if (string.IsNullOrEmpty(inboundID))
            {
                MsgBox.Error("请先选择要删除的入库单！");
                return;
            }

            if (MsgBox.Confirm("您确定要完成选中的入库单？（删除后将恢复库存）") == false)
                return;

            Object obj = inboundView.GetFocusedRowCellValue("Status").ToString();
           
            if (obj != null && obj.ToString() ==  DealStatus.PreInput )
            {
                //删除虚拟入库
                MissionAssign missionAssign = new MissionAssign();
                missionAssign.DeleteVirtualInbound(inboundID);
            }
            else  if (CancelInbound(inboundID) == false)
            {
                //删除真实入库
                MsgBox.Error("删除入库单失败！");
                return;
            }

            inboundView.DeleteRow(inboundView.FocusedRowHandle);

            SwitchInbound();

            FrmTip.ShowTip("删除入库单成功！");
        }

        //取消入库操作
        private bool CancelInbound(string boundID)
        {
            //从出库操作单表中提取所有的实际出库单

            bool bres = true;
            string sql = String.Format("Select recordID, LotNo, SizeNo, ShelfNo, NumOfReal from T_InboundRecord where InboundID = '{0}'", boundID);
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

                if (RestoreInventory(lotno, sizeno, shelfno, qnt) == true)
                    DeleteInboundRecord(recordid);
                else
                    bres &= false;
            }

            if (bres == true)
            {
                ClearDetail(boundID);
                DeleteInboundItem(boundID);
            }

            return bres;
        }

        //删除入库单基础条码，不包括明细、出库操作单等信息
        private bool DeleteInboundItem(string boundID)
        {
            string sql = string.Format("delete from T_Inbound where InboundID = '{0}'", boundID);
            int nres = Database.ExecuteSQL(sql, "FrmInbound-DeleteInboundItem");


            return nres > 0 ? true : false;
        }
         
        //删除单条入库操作单
        private bool DeleteInboundRecord(string recordId)
        {
            string sql = string.Format("delete from t_inboundrecord where recordId = '{0}'", recordId);
            int res = Database.ExecuteSQL(sql, "FrmInbound-DeleteInboundRecord");
            return res > 0 ? true : false;
        }

        //恢复库存
        private bool RestoreInventory(string lotno, string sizeno, string shelfno, string qnt)
        {
            bool bres = false;
            string sql, id;
            id = FindInventory(shelfno, lotno, sizeno);

            if (string.IsNullOrEmpty(id) == false)
            {
                sql = String.Format("update T_Inventory Set Quantity = Quantity - {0} where lotno = '{1}' "
                               + " and sizeno = '{2}' and shelfno = '{3}' ",
                               qnt,
                               lotno,
                               sizeno,
                               shelfno);
                bres = Database.ExecuteSQL(sql, "FrmInbound-RestoreInventory") > 0 ? true : false;
            }
            else
            {
                bres = InsertInventory(shelfno, lotno, sizeno, qnt);
            } 

            return bres;
        }

        //插入库存
        private bool InsertInventory(string shelfNo, string lotNo, string sizeNo, string qnt)
        {
            string id = Database.GetGlobalKey();

            string sql = String.Format("Insert into T_Inventory (InventoryID, ShelfNo, LotNo, SizeNo, Quantity ) "
                + "Values('{0}', '{1}', '{2}', '{3}', {4})",
                id,
                shelfNo,
                lotNo,
                sizeNo,
                qnt);

            int nres = Database.ExecuteSQL(sql, "FrmInbound-InsertInventory");
            return nres == 1 ? true : false;
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
         
        ///////////////////// 
        public bool RemoveNewInbound(string inboundID)
        {
            string sql = string.Format("delete from T_InboundDetail where InboundID = '{0}'", inboundID);
            int nres = Database.ExecuteSQL(sql, "FrmInbound-RemoveNewInbound");

            sql = string.Format("delete from T_InboundRecord where InboundID = '{0}'", inboundID);
            nres = Database.ExecuteSQL(sql, "FrmInbound-RemoveNewInbound");

            sql = string.Format("delete from T_Inbound where InboundID = '{0}'", inboundID);
            nres = Database.ExecuteSQL(sql, "FrmInbound-RemoveNewInbound");
            return nres > 0 ? true : false;
        }

        //删除入库记录
        public void ClearRecord(string boundID)
        {
            string sql = String.Format("Delete from T_InboundRecord where InboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmInbound-ClearRecord");
        }
       
        //删除入库明细
        private void ClearDetail(string boundID)
        {
            string sql = string.Format("delete from T_InboundDetail where InboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmInbound-ClearRecord");

        }
        

        #endregion

        #region 完成入库单

        private void UpdateDealStatus(string status )
        {
            int rowcnt = recordView.RowCount;
            string recordID = "";
            string time = "";
            for (int i = 0; i < rowcnt; i++)
            {
                if (GetChecked(i) == false)
                    continue;
                recordID = recordView.GetRowCellValue(i, "RecordID").ToString();
                time = Database.GetDateTimeString();
                UpdateDealStatus(recordID, time, status);

                //修改实际入库数量
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
            string sql = string.Format("Update T_InboundRecord set DealStatus = '{0}',DealDateTime='{1}' where recordID='{2}'",
                status,
                time,
                recordID);
            Database.ExecuteSQL(sql, "FrmInbound-UpdateDealStatus");
        }

        private void UpdateInboundStatus(string inboundID, string status)
        { 
            string sql = String.Format("update T_Inbound Set Status = '{0}' where InboundID='{1}'", status, inboundID);

            Database.ExecuteSQL(sql, "FrmInbound-UpdateInboundStatus");

        }

        private bool HasCompleteInbound(string inboundID)
        {
            string sql = String.Format("select recordId,DealStatus From T_InboundRecord where InboundID = '{0}'", inboundID);
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

        private void UpdateNumOfReal(int rowHandle)
        {
            string recordID = "", detailID, shelfNo = "";
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
            string sql = String.Format("Update T_InboundRecord Set  NumofReal =  {0}  Where recordID = '{1}' ", numOfReal, recordID);
            Database.ExecuteSQL(sql, "FrmInbound-UpdateNumOfReal");

            string lotNo = recordView.GetRowCellValue(rowHandle, "LotNo").ToString();
            string sizeNo = recordView.GetRowCellValue(rowHandle, "SizeNo").ToString();

            //出库明细
            sql = String.Format("Update T_InboundDetail Set  NumofReal =  {0}  Where detailID = '{1}' and lotNo = '{2}' and SizeNo = '{3}' ",
                numOfReal,
                detailID,
                lotNo,
                sizeNo);

            Database.ExecuteSQL(sql, "FrmInbound-UpdateNumOfReal");

            //修改库存表
            sql = String.Format("Update T_Inventory Set Quantity = Quantity + {0} where shelfNo = '{1}' and LotNo = '{2}' and sizeNo = '{3}'",
                numOfReal -numOfPlan ,
                shelfNo,
                lotNo,
                sizeNo);

            Database.ExecuteSQL(sql, "FrmInbound-UpdateNumOfReal");
        }


        #endregion

        #region 入库记录表操作

        private void mnuCheckAll_Click(object sender, EventArgs e)
        {
            inboundRecordView.CheckAll();
        }

        private void mnuNoCheck_Click(object sender, EventArgs e)
        {
            inboundRecordView.UnCheck();
        }

        private void ctxMenuRecord_Opening(object sender, CancelEventArgs e)
        {
            if (recordView.RowCount == 0)
                e.Cancel = true;
        }

        #endregion

        #region  入库单--右键菜单

        private void mnuMasterComplete_Click(object sender, EventArgs e)
        {
            string inboundID = inboundView.GetFocusedRowCellValue("InboundID").ToString();
             
            if (MsgBox.Confirm("您确定要完成选中的入库单？") == false)
                return;
             
            Object obj = inboundView.GetFocusedRowCellValue("Status");
            if (obj != null)
            {
                if (obj.ToString() == DealStatus.Finish)
                    return;
            }

            string sql = String.Format(" Update T_InboundRecord Set DealStatus = 'complete' where InboundID = '{0}' and DealStatus <> '{1}' ",
                inboundID,
                MemoryTable.BackBound);

            Database.ExecuteSQL(sql, "FrmInbound-mnuMasterComplete_Click");

            UpdateInboundStatus(inboundID, DealStatus.Finish);
            inboundView.SetFocusedRowCellValue("Status", DealStatus.Finish);
            inboundRecordView.LoadInboundRecord(inboundID);
        }

        private void ctxMenuMaster_Opening(object sender, CancelEventArgs e)
        {
            Object obj = inboundView.GetFocusedRowCellValue("InboundID");
            if (obj == null)
            {
                e.Cancel = true;
                return;
            }
                       
            mnuMasterEditInbound.Visible = true;
            mnuMasterDelete.Visible = true;


            mnuMasterExportReocrd.Enabled = true;
            mnuMasterPrintRecord.Enabled = true;

            //2016-07-29放开修改和删除操作，用户要求放开。
            mnuMasterDelete.Enabled = true;
            mnuMasterEditInbound.Enabled = true;

            string status = inboundView.GetFocusedRowCellValue("Status").ToString();
            if (string.IsNullOrEmpty(status) || status == DealStatus.Finish  )
            { 
                mnuMasterComplete.Enabled = false;
                mnuMasterSetOperator.Enabled = false;
            }
            else if (status == DealStatus.PreInput)
            {
                mnuMasterComplete.Enabled = false;
                mnuMasterSetOperator.Enabled = true;

                mnuMasterExportReocrd.Enabled = false;
                mnuMasterPrintRecord.Enabled = false;
            }
            else
            {
                mnuMasterSetOperator.Enabled = true;
                mnuMasterComplete.Enabled = true;

            }

             

        }
     
        private void mnuMasterEditInbound_Click(object sender, EventArgs e)
        {
            string inboundID = inboundView.GetFocusedRowCellValue("InboundID").ToString();
            string orderDate = inboundView.GetFocusedRowCellValue("OrderDate").ToString();
            string productNo = inboundView.GetFocusedRowCellValue("ProductNo").ToString();

            InBound inbound = new InBound();
            inbound.InboundID = inboundID;
            inbound.ProductNo = productNo;
            inbound.OrderDate = orderDate;

            FrmEditInbound dlg = new FrmEditInbound();
            dlg.InboundID = inboundID;
            dlg.InboundItem = inbound;

            if (DialogResult.Cancel == dlg.ShowDialog())
                return;

            inboundView.SetFocusedRowCellValue("OrderDate", inbound.OrderDate);
            inboundView.SetFocusedRowCellValue("ProductNo", inbound.ProductNo);

            string sql = String.Format("update T_Inbound Set ProductNo = '{0}' , OrderDate = '{1}' Where inboundID = '{2}' ",
                inbound.ProductNo,
                inbound.OrderDate,
                inboundID);

            Database.ExecuteSQL(sql, "FrmInbound-mnuMasterEditInbound_Click");

        }

        #endregion
        
        #region 真实入库

        private bool bVirtualToActual = false;

        private void FocusedMasterRow(int iRow)
        {
            Object obj = inboundView.GetFocusedRowCellValue("Status");
            if(obj == null)
            { 
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;
                return;
            }
            string status = obj.ToString();

            btnConfirm.Visible = true;
            btnConfirm.Enabled = true;
           
            if ( status  == DealStatus.PreInput )
            {
                btnConfirm.Text = "Inbound";
                btnConfirm.ForeColor = Color.Blue;
            }
            else if (status == DealStatus.Inbound)
            {
                btnConfirm.Text = "Confirm";
                btnConfirm.ForeColor = Color.Black;
            }
            else {
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;
            }
        }

        private void VirtualToActual(int iRow)
        {
            if (iRow < 0)
                return;
            
            bVirtualToActual = true;

            txtInboundNo.Text = inboundView.GetFocusedRowCellValue("InboundID").ToString();

            splitContainer.IsSplitterFixed = true;
            splitContainer.Collapsed = true;

            xtraTab.ShowTabHeader = DefaultBoolean.False;
            tpRecord.PageVisible = false;
            tpDetail.PageVisible = true;
            tpProperty.PageVisible = false;

            InitUI_Search(false);

            btnPrev.Visible = true;
            btnPrev.Enabled = false;

            btnNext.Visible = true;
            btnNext.Enabled = true;
            btnNext.Text = "Distribute";
            btnComplete.Visible = false;
            btnComplete.Enabled = false;

            btnCancel.Enabled = true;
            btnCancel.Visible = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;
 
            CurrentInboundStatus = Status_Detail;
            AppEditStatus.InboundCurrentStatus = CurrentInboundStatus;
            inboundDetailView.InboundID = txtInboundNo.Text;
            inboundDetailView.Loading();

            inboundDetailView.SetGridEditStatus(true);
        }

        //取消虚拟转真实操作
        private void CancelVirtualToActual(string inboundNo)
        {
            string sql = "";
            
            Cursor.Current = Cursors.WaitCursor;

            //1删除入库操作单
            ClearRecord(inboundNo);
            inboundRecordView.ClearRows();

            //2根据88T88库存恢复操作明细
            RestoreVirtualInboundDetail(inboundNo);

            //3恢复入库单的虚拟属性
            sql = string.Format("Update T_Inbound Set Status = '{0}' where InboundID = '{1}' ",
                DealStatus.PreInput,
                inboundNo );
            Database.ExecuteSQL(sql);

            inboundView.SetFocusedRowCellValue("Status", DealStatus.PreInput ); 
            Cursor.Current = Cursors.Default;

        }

        private void RestoreVirtualInboundDetail(string inboundNo)
        {
            string sqlInventory = string.Format("select lotno , sizeno , quantity from t_inventory where shelfNo = '{0}' and userdefine1 = '{1}' order by lotno , sizeno ",
                MemoryTable.Shelf_88T88,
                inboundNo);

            DataTable dtInventory = Database.Select(sqlInventory);

            if (dtInventory == null || dtInventory.Rows.Count ==0 )
                return;
            string lotno = "", sizeno = "", temp = "";
            
            string sqlUpdate = "";
            for (int i = 0; i < dtInventory.Rows.Count; i++)
            {
                lotno = dtInventory.Rows[i][0].ToString();
                sizeno = dtInventory.Rows[i][1].ToString();
                temp = dtInventory.Rows[i][2].ToString();

                sqlUpdate = string.Format("Update T_InboundDetail Set NumOfPlan = '{0}' , NumOfReal = '{0}' where InboundID = '{1}' and LotNo = '{2}' and SizeNo = '{3}' ",
                    temp,
                    inboundNo,
                    lotno,
                    sizeno );

                Database.ExecuteSQL(sqlUpdate);

            }

            dtInventory.Clear();
        }

        #endregion

        #region 删除88T88中的数据

        private void DeleteVirtualInvenotry(string strInboundID)
        {
            //删除虚拟库存
            string sqlDelete = string.Format("Delete from T_Inventory  WHERE UserDefine1='{0}' and ShelfNo = '{1}'", strInboundID, MemoryTable.Shelf_88T88);
            Database.ExecuteSQL(sqlDelete);
        }
        #endregion
    }

        
}

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
using DevExpress.XtraGrid.Columns;
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
    public partial class FrmBackbound : Form, InnerForm
    {
        ReturnMasterView returnMasterView; 
        ReturnDetailView returnDetailView;
        ReturnRecordView returnRecordView;
        InventoryDetialView invtDetailView;

        #region 接口函数

        public void Save() { }
        public bool IsEdit() { return false; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 窗体构造与初始化
        
        public FrmBackbound()
        {
            InitializeComponent();

            returnMasterView = new ReturnMasterView(this.masterView);
            returnDetailView = new ReturnDetailView(this.detailView);
            returnRecordView = new ReturnRecordView(this.recordView);
            invtDetailView = new InventoryDetialView(this.invtView);

            returnRecordView.invtView = invtView;

            splitContainer.Collapsed = false;


            this.tpProperty.Resize += new System.EventHandler(this.tpProperty_Resize);
            this.masterView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.MasterView_FocusedRowChanged);
            this.masterView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.MasterView_CustomDrawCell);
            this.masterView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.MasterView_RowStyle);
            this.xtraTab.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTab_SelectedPageChanged);


            this.recordView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.RecordView_FocusedRowChanged);
            this.recordView.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.RecordView_FocusedColumnChanged);
           
        }
                
        private void FrmBackbound_Load(object sender, EventArgs e)
        {   
            InitUI_FormLoad();         
            returnRecordView.Initialize();
            returnDetailView.Initialize();
            returnMasterView.Initialize();
            invtDetailView.Initialize();

            InitInventoryView();

            if (Database.IsConnected())
                returnMasterView.Loading();


            returnRecordView.SetGridEditStatus(false);
        }

        private void tpProperty_Resize(object sender, EventArgs e)
        {
            groupInbound.Left = tpProperty.Width / 2 - groupInbound.Width / 2;
            groupInbound.Top = tpProperty.Height / 2 - groupInbound.Height / 2;

        }

        private void InitInventoryView()
        {
            invtView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", null, "")});
            invtView.GroupFormat = "( Shelf# = [#image]{1} ) ，{2}";

            invtView.Columns["ShelfNo"].GroupIndex = 0;
        }

        #endregion

        #region 设置界面状态

        private int CurrentBackboundStatus = 0;
    
        const int Status_None = 0; //查询  
        const int Status_Property = 1;//填写属性 
        const int Status_Detail = 2;  //编辑明细
        const int Status_Record = 3;  //操作单 
        const int Status_Complete = 4;//完成

        private void InitUI_Search(bool bFlag)
        {
            btnSearch.Visible = bFlag;
            btnBackbound.Visible = bFlag;
            lblBeginDate.Visible = bFlag;
            lblEndDate.Visible = bFlag;
            dateBegin.Visible = bFlag;
            dateEnd.Visible = bFlag;
            lblPONoFilter.Visible = bFlag;
            txtPONoFilter.Visible = bFlag;
            lblCustomerFilter.Visible = bFlag;
            txtSalesFilter.Visible = bFlag;

            btnPrint2.Visible = false;
            btnPrint.Visible = bFlag;
            detailGrid.ContextMenuStrip = null;
           // recordGrid.ContextMenuStrip = ctxMenuRecord;
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

            btnPrint2.Top = btnPrint.Top;
            btnPrint2.Visible = false;

            InitUI_Search(true);

            returnRecordView.SetGridEditStatus(false);
          
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

            btnComplete.Visible = false;
            btnComplete.Enabled = false;

            btnCancel.Visible = true;
            btnCancel.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;

            btnPrint2.Visible = false;

            InitUI_Search(false);


        }

        private void InitUI_Detail()
        {
            xtraTab.ShowTabHeader = DefaultBoolean.False;

            tpDetail.PageVisible = true;
            tpProperty.PageVisible = false;
            tpRecord.PageVisible = false;

            btnPrev.Enabled = true;
            btnNext.Visible = true;
            btnNext.Enabled = true;
           
            btnComplete.Visible = false;
            btnComplete.Enabled = false;
          
            btnCancel.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;
            btnPrint2.Visible = false;
            detailGrid.ContextMenuStrip = ctxMenuDetail;
        }

        private void InitUI_Record()
        {
            xtraTab.ShowTabHeader = DefaultBoolean.False;
            returnRecordView.SetGridEditStatus(true);

            tpRecord.PageVisible = true;
            tpDetail.PageVisible = false;
            tpProperty.PageVisible = false;

            btnPrev.Enabled = true;

            btnNext.Visible = false;
            btnNext.Enabled = false;

            btnComplete.Visible = true;
            btnComplete.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;

            detailGrid.ContextMenuStrip = null;
            btnCancel.Enabled = true;

            btnPrint2.Visible = true;
        }

        private void InitUI_Complete()
        {
            InitUI_FormLoad();
            //inboundDetailView.SetGridEditStatus(false);
            //inboundRecordView.SetGridEditStatus(true);
        }

        #endregion
        
        #region 按钮事件

        //添加订单
        private void btnBackbound_Click(object sender, EventArgs e)
        {
            txtBackboundNo.Text = Database.GetDataTimekey(4);
            txtPONo.Text = "";
            ReloadSales();
            cboSales.Text = "";
            cboCustomer.Text = "";
            txtMemo.Text = "";
            if(string.IsNullOrEmpty( dateOrder.Text ) )
                dateOrder.Text = DateTime.Now.ToString("yyyy-MM-dd");
            InitUI_Property();

            CurrentBackboundStatus = Status_Property;
            txtPONo.Focus();

            returnDetailView.SetGridEditStatus(true);

            returnDetailView.BackboundID = txtBackboundNo.Text;
            returnRecordView.BackboundID = txtBackboundNo.Text;

            returnRecordView.ClearRows();
            returnDetailView.ClearRows();
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("您确定要放弃本次退货操作吗？") == false)
                return;

            InitUI_Complete();
            CurrentBackboundStatus = Status_None;

            if (newBackBound != null)
            {
                RemoveBackbound(newBackBound.BackboundID);

            }
        }

        //完成
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (CurrentBackboundStatus != Status_Record)
                return;

            InitUI_Complete();
            returnDetailView.SetGridEditStatus(false);
            CurrentBackboundStatus = Status_None;
            MissionAssign missionAssign = new MissionAssign();
            missionAssign.BackboundComplete(txtBackboundNo.Text);

            if (newBackBound != null)
            {
                returnMasterView.InsertBackbound(0, newBackBound);

                masterView.FocusedRowHandle = 0;

                newBackBound = null;

                this.Refresh();

                PrintRecord();

            }

        }

        //确认退货操作单
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //将操作单状态设置为完成
            if (CurrentBackboundStatus != Status_None)
            {
                return;
            }

            int cnt = returnRecordView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Infometion("请先选择退货操作纪录！");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            UpdateDealStatus(true);
            Object obj = masterView.GetFocusedRowCellValue("BackboundID");
            if (obj == null)
            {
                Cursor.Current = Cursors.Default;
                return;
            }

            string id = masterView.GetFocusedRowCellValue("BackboundID").ToString();

            if (HasCompleteBackbound(id) == true)
            {
                UpdateBackboundStatus(id, true);
                masterView.SetFocusedRowCellValue("Status", DealStatus.Yes);
            }

            returnRecordView.UnCheck();

            Cursor.Current = Cursors.Default;
           
        }

        //上一步
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentBackboundStatus <= Status_Property)
                return;
            if (CurrentBackboundStatus == Status_Detail)
            {
                InitUI_Property();
                CurrentBackboundStatus = Status_Property;
                return;
            }

            if (CurrentBackboundStatus == Status_Record)
            {
                ClearRecord(txtBackboundNo.Text);
                InitUI_Detail();
                CurrentBackboundStatus = Status_Detail;

                return;
            }

        }

        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentBackboundStatus == Status_Record)
                return;
            if (CanNext() == false)
                return;

            if (CurrentBackboundStatus == Status_Property)
            {
                InitUI_Detail();
                CurrentBackboundStatus = Status_Detail;
                return;
            }

            if (CurrentBackboundStatus == Status_Detail)
            {

                WaitingService.BeginLoading("正在分解入库明细，请稍等......");
                Cursor.Current = Cursors.WaitCursor;

                //保存明细
                SaveBackbound();
                
                MissionAssign missionAssign = new MissionAssign();

                //分解
                missionAssign.BackboundAssign(txtBackboundNo.Text);
                 
                //加载明细
                returnRecordView.LoadRecord(txtBackboundNo.Text);

                InitUI_Record();

                CurrentBackboundStatus = Status_Record;
                
                Cursor.Current = Cursors.Default;

                WaitingService.EndLoading();
                return;
            }

        }

        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Loadding();
        }

        private void txtKeyWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Loadding();
            }
        }

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and OrderDate >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and OrderDate <= '{0}'", dateEnd.DateTime.ToString("yyyy-MM-dd"));

            if (txtPONoFilter.Text.Trim().Length > 0)
            {
                sql += String.Format(" and PONo like '{0}%'", txtPONoFilter.Text.Trim());
            }

            if (txtSalesFilter.Text.Trim().Length > 0)
            {
                sql += String.Format(" and Sales like '{0}%'", txtSalesFilter.Text.Trim());
            }

            return sql;
        }

        public void Loadding()
        {
            string sql = GetFilterSql();
            returnMasterView.KeyWords = sql;
            returnMasterView.Loading();
            SwitchBackbound();
        }
        
        #endregion

        #region 明细表编辑

        private bool CanNext()
        {
            bool bres = true;

            if (CurrentBackboundStatus == Status_Property)
            {

                if (txtPONo.Text.Trim().Length == 0)
                {
                    MsgBox.Error("请填写PO#！");
                    return false;
                }
                if (dateOrder.Text.Trim().Length == 0)
                {
                    MsgBox.Error("请填退货日期！");
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
            returnDetailView.RemoveRows(rows);

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
            if (CurrentBackboundStatus == Status_None)
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

        #region 删除退货单

        private void OnDeleteBackbound()
        {
            string boundID = masterView.GetFocusedRowCellValue("BackboundID").ToString();
            if (string.IsNullOrEmpty(boundID))
            {
                MsgBox.Error("请先选择要删除的退货单！");
                return;
            }

            if (MsgBox.Confirm("您确定要完成选中的退货单？（删除后将恢复库存）") == false)
                return;

            if (CancelBackbound(boundID) == false)
            {
                MsgBox.Error("删除退货单失败！");
                return;
            }
            masterView.DeleteRow(masterView.FocusedRowHandle);
            SwitchBackbound();

            FrmTip.ShowTip("删除退货单成功！");
        }

        //取消入库操作
        private bool CancelBackbound(string boundID)
        {
            //从出库操作单表中提取所有的实际出库单

            bool bres = true;
            string sql = String.Format("Select recordID, LotNo, SizeNo, ShelfNo, Quantity from T_BackboundRecord where BackboundID = '{0}'", boundID);
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
                    DeleteBackboundRecord(recordid);
                else
                    bres &= false;
            }

            if (bres == true)
            {
                ClearDetail(boundID);
                DeleteBackboundItem(boundID);
            }

            return bres;
        }

        //删除单条退货操作单
        private bool DeleteBackboundRecord(string recordId)
        {
            string sql = string.Format("delete from t_backboundrecord where recordId = '{0}'", recordId);
            int res = Database.ExecuteSQL(sql, "FrmBackbound-DeleteBackboundRecord");
            return res > 0 ? true : false;
        }

        //删除退货单单基础条码，不包括明细、出库操作单等信息
        private bool DeleteBackboundItem(string boundID)
        {
            string sql = string.Format("delete from T_Backbound where BackboundID = '{0}'", boundID);
            int nres = Database.ExecuteSQL(sql, "FrmBackbound-DeleteBackboundItem");

            return nres > 0 ? true : false;
        }
         
        //删除入库明细
        private void ClearDetail(string boundID)
        {
            string sql = string.Format("delete from T_BackboundDetail where BackboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmBackbound-ClearDetail");

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
                bres = Database.ExecuteSQL(sql, "FrmBackbound-RestoreInventory") > 0 ? true : false;
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

            int nres = Database.ExecuteSQL(sql, "FrmBackbound-InsertInventory");
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
         
        #endregion
        
        #region 保存退货单
       
        private BackBound newBackBound = null;

        private void SaveBackbound()
        {
            //保存顺序不能颠倒
            if (IsExistBackbound(txtBackboundNo.Text))
                RemoveBackbound(txtBackboundNo.Text);

            returnDetailView.SaveBackboundDetail();
            if (InsertBackbound() == false)
            {
                MsgBox.Error("保存退货单失败！");
                return;
            }

        } 
       
        private bool InsertBackbound()
        {
            bool bres = false;
             
            string sql = String.Format("Insert into T_Backbound (BackboundID, PONo, BackDate, Sales, Customer, Status ,Remark ) "
                + "Values('{0}','{1}','{2}','{3}','{4}' ,'{5}','{6}')",
                txtBackboundNo.Text,
                txtPONo.Text.Trim().Replace("'","''"),
                dateOrder.DateTime.ToString("yyyy-MM-dd"),
                cboSales.Text.Trim().Replace("'", "''"),
                cboCustomer.Text.Trim().Replace("'", "''"),
                DealStatus.No,
                txtMemo.Text.Replace("'", "''") );

            bres = Database.ExecuteSQL(sql, "FrmBackbound-InsertBackbound") == 1 ? true : false;
            if (bres)
            {
                newBackBound = new BackBound();
                newBackBound.BackboundID = txtBackboundNo.Text;
                newBackBound.PONo = txtPONo.Text;
                newBackBound.Sales = cboSales.Text.Trim();
                newBackBound.Customer = cboCustomer.Text.Trim(); 
                newBackBound.Status = DealStatus.No;
                newBackBound.OrderDate =  dateOrder.DateTime.ToString("yyyy-MM-dd");
                newBackBound.Memo = txtMemo.Text;
            }
            return bres;
        }

        private bool IsExistBackbound(string id)
        {
            string sql = String.Format("select BackboundID from T_Backbound where BackboundID = '{0}'", id);
            System.Data.DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool RemoveBackbound(string boundID)
        {
            string sql = string.Format("delete from T_BackboundDetail where BackboundID = '{0}'", boundID);
            int nres = Database.ExecuteSQL(sql, "FrmBackbound-RemoveBackbound");

            sql = string.Format("delete from T_BackboundRecord where BackboundID = '{0}'", boundID);
            nres = Database.ExecuteSQL(sql, "FrmBackbound-RemoveBackbound");

            sql = string.Format("delete from T_Backbound where BackboundID = '{0}'", boundID);
            nres = Database.ExecuteSQL(sql, "FrmBackbound-RemoveBackbound");
            return nres > 0 ? true : false;
        }

        public void ClearRecord(string boundID)
        {
            string sql = String.Format("Delete from T_BackboundRecord where BackboundID = '{0}'", boundID);
            Database.ExecuteSQL(sql, "FrmBackbound-ClearRecord");
        }

        #endregion

        #region 主表操作

        private void SwitchBackbound()
        {
            returnDetailView.ClearRows();
            returnRecordView.ClearRows();
             
            splitContainer.Collapsed = false;

            //刷新明细表格
            if (masterView.GetFocusedRowCellValue("BackboundID") == null)
                return;
            string boundno = masterView.GetFocusedRowCellValue("BackboundID").ToString();
            
            returnRecordView.LoadRecord(boundno);

            returnDetailView.BackboundID = boundno;
            returnDetailView.Loading();
            SetConfirmButtonVisible();
        }
 
        private void MasterView_FocusedRowChanged(object sender,FocusedRowChangedEventArgs e)
        {
            SwitchBackbound();
        }

        private void MasterView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (masterView.GetRowCellValue(e.RowHandle, "Status") == null)
                return;

            string status = masterView.GetRowCellValue(e.RowHandle, "Status").ToString();

            if (status != DealStatus.Yes)
                e.Appearance.ForeColor = Color.Red;
        }

        private void MasterView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            { 
                if ( e.CellValue.ToString() == DealStatus.Yes)
                    e.DisplayText = "完成";
                else
                    e.DisplayText = "未完成";
            }
             
        }

        private void xtraTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (CurrentBackboundStatus == Status_None)
                SetConfirmButtonVisible();
        }

        private void SetConfirmButtonVisible()
        {
            Object obj = masterView.GetFocusedRowCellValue("Status");
            if (obj == null)
                return;
            string status = obj.ToString();

            if (status == DealStatus.Yes)
            {
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;
            }
            else if (xtraTab.SelectedTabPage == tpRecord)
            {
                btnConfirm.Visible = true;
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Visible = false;
                btnConfirm.Enabled = false;
            }
        }
       
        #endregion

        #region 完成退货单

        private void UpdateDealStatus(bool bres)
        {
            int rowcnt = recordView.RowCount;
            string recordID = "";
            string status = "0", time = "";
            for (int i = 0; i < rowcnt; i++)
            {
                if (GetChecked(i) == false)
                    continue;
                recordID = recordView.GetRowCellValue(i, "RecordID").ToString();
                time = Database.GetDateTimeString();
                UpdateDealStatus(recordID, time, bres);
                 
                status = bres ? DealStatus.Complete : DealStatus.None;
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

        private void UpdateDealStatus(string recordID, string time, bool bres)
        {
            // string status = bres ? "1": "0";
            string status = bres ? DealStatus.Complete : DealStatus.None;

            string sql = string.Format("Update T_BackboundRecord set DealStatus = '{0}',DealDateTime='{1}' where recordID='{2}'",
                status,
                time,
                recordID);
            Database.ExecuteSQL(sql, "FrmBackbound-UpdateDealStatus");
        }

        private void UpdateBackboundStatus(string boundID, bool status)
        {
            string st = status ? DealStatus.Yes : DealStatus.No;
            string sql = String.Format("update T_Backbound Set Status = '{0}' where BackboundID='{1}'", st, boundID);

            Database.ExecuteSQL(sql, "FrmBackbound-UpdateBackboundStatus");
        }

        private bool HasCompleteBackbound(string boundID)
        {
            string sql = String.Format("select recordId,DealStatus From T_BackboundRecord where BackboundID = '{0}'", boundID);
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
         
        #endregion

        #region 打印、导出

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择退货单！");
                return;
            }
            string boundID = masterView.GetRowCellValue(masterView.FocusedRowHandle, "BackboundID").ToString();

            if (xtraTab.SelectedTabPage == tpDetail)
                PrintDetail(boundID);
            else if (xtraTab.SelectedTabPage == tpRecord)
                PrintRecord();
        }

        private void PrintDetail(string boundID)
        {
             
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            ExportBackbound.ExportDetail(detailView, boundID, tempFile);
              
            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile); //保存
        }
         
        private void PrintRecord()
        {
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";

            ExportBackbound.ExportRecord(recordView, tempFile);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile);  
            
        }

        private void ExportDetail(string boundID)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();       ///储存文件提示框类
            fileDialog.Title = "导出Excel";           ///标题
            fileDialog.Filter = "Excel (*.xls)|*.xls";      ///存储类型
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            { 
                ExportBackbound.ExportDetail(this.detailView, boundID, fileDialog.FileName);
                 
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        private void ExportRecord()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                 
                ExportBackbound.ExportRecord(recordView, fileDialog.FileName);
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }

        #endregion

        #region Master右键菜单

        private void mnuMasterComplete_Click(object sender, EventArgs e)
        {
            string boundID = masterView.GetFocusedRowCellValue("BackboundID").ToString();

            if (MsgBox.Confirm("您确定要完成选中的退货单？") == false)
                return;

            string sql = String.Format(" Update T_BackboundRecord Set DealStatus = 'complete' where BackboundID = '{0}'",boundID );

            Database.ExecuteSQL(sql, "FrmBackbound-mnuMasterComplete_Click");

            UpdateBackboundStatus(boundID, true);
            masterView.SetFocusedRowCellValue("Status", DealStatus.Yes);
            returnRecordView.LoadRecord(boundID);
        }
        
        private void ctxMenuMaster_Opening(object sender, CancelEventArgs e)
        {
            Object obj = masterView.GetFocusedRowCellValue("BackboundID");
            if (obj == null)
                e.Cancel = true;

            string status = masterView.GetFocusedRowCellValue("Status").ToString();
            if (string.IsNullOrEmpty(status) || status == DealStatus.Yes)
            {
                mnuMasterDelete.Enabled = false;
                mnuMasterEdit.Enabled = false;

                mnuMasterComplete.Enabled = false; 
            }
            else
            {
                mnuMasterDelete.Enabled = true;
                mnuMasterEdit.Enabled = true;

                mnuMasterComplete.Enabled = true; 
            }
        }

        private void mnuMasterEditBackbound_Click(object sender, EventArgs e)
        {
            string boundID = masterView.GetFocusedRowCellValue("BackboundID").ToString();
            string backDate = masterView.GetFocusedRowCellValue("BackDate").ToString();
            string poNo = masterView.GetFocusedRowCellValue("PONo").ToString();
            string customer = masterView.GetFocusedRowCellValue("Customer").ToString();

            BackBound bound = new BackBound();
            bound.BackboundID = boundID;
            bound.PONo = poNo;
            bound.OrderDate = backDate;
            bound.Customer = customer;

            FrmEditBackbound dlg = new FrmEditBackbound();
            dlg.BackboundID = boundID;
            dlg.BackboundItem = bound;
            
            if (DialogResult.Cancel == dlg.ShowDialog())
                return;

            masterView.SetFocusedRowCellValue("BackDate", bound.OrderDate);
            masterView.SetFocusedRowCellValue("PONo", bound.PONo);
            masterView.SetFocusedRowCellValue("Customer", bound.Customer);
            masterView.SetFocusedRowCellValue("Sales", bound.Sales);
            masterView.SetFocusedRowCellValue("Remark", bound.Memo);

            string sql = String.Format("update T_Backbound Set PONo = '{0}' , BackDate = '{1}',Sales = '{2}' ,Customer = '{3}', Remark = '{4}' Where BackboundID = '{5}' ",
                bound.PONo,
                bound.OrderDate,
                bound.Sales.Replace("'","''"),
                bound.Customer.Replace("'","''"),
                bound.Memo.Replace("'","''"),
                boundID);

            Database.ExecuteSQL(sql, "FrmBackbound-mnuMasterEditBackbound_Click");

        }
                
        private void mnuMasterExportDetail_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择退货单！");
                return;
            }
            string boundID = masterView.GetRowCellValue(masterView.FocusedRowHandle, "BackboundID").ToString();
            ExportDetail(boundID);
        }

        private void mnuMasterPrintDetail_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择退货单！");
                return;
            }

            string boundID = masterView.GetRowCellValue(masterView.FocusedRowHandle, "BackboundID").ToString();
            PrintDetail(boundID);

        }

        private void mnuMasterExportReocrd_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择退货单！");
                return;
            }
            ExportRecord();
        }

        private void mnuMasterPrintRecord_Click(object sender, EventArgs e)
        {
            if (masterView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择退货单！");
                return;
            }

            PrintRecord();
        }

        private void mnuMasterDelete_Click(object sender, EventArgs e)
        {
            OnDeleteBackbound();
        }

        #endregion

        #region 退货操作 库存明细查询

        private void RecordView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
             
            int rowHandle = recordView.FocusedRowHandle;
            if (rowHandle < 0)
                return;
            if (e.FocusedColumn == null)
                return;

            GridColumn FocusedColumn = e.FocusedColumn;

            string lotNo = recordView.GetFocusedRowCellValue("LotNo").ToString();
            if (e.FocusedColumn.FieldName == "SizeNo")
            {
                string sizeNo = recordView.GetFocusedRowCellValue("SizeNo").ToString();
                invtDetailView.LoadInventory(lotNo, sizeNo);
            }
            else if (e.FocusedColumn.FieldName == "LotNo")
                invtDetailView.LoadInventory(lotNo);
            else if (e.FocusedColumn.FieldName == "ShelfNo")
            {
                string shelfNo = recordView.GetFocusedRowCellValue("ShelfNo").ToString();
                invtDetailView.LoadShelfInventory(shelfNo);
            }
            else
                invtDetailView.ClearRows();
        }

        private void RecordView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        { 
            if (e.FocusedRowHandle < 0)
                return;
            int FocusedRowHandle = e.FocusedRowHandle;
            GridColumn FocusedColumn = recordView.FocusedColumn;

            if (FocusedColumn == null)
            {
                invtDetailView.ClearRows();
                return;
            }
            string lotNo = recordView.GetFocusedRowCellValue("LotNo").ToString();
            
            if (FocusedColumn.FieldName == "SizeNo")
            {
                string sizeNo = recordView.GetFocusedRowCellValue("SizeNo").ToString();
                invtDetailView.LoadInventory(lotNo, sizeNo);
            }
            else if (FocusedColumn.FieldName == "LotNo")
                invtDetailView.LoadInventory(lotNo);
            else if (FocusedColumn.FieldName == "ShelfNo")
            {
                string shelfNo = recordView.GetFocusedRowCellValue("ShelfNo").ToString();
                invtDetailView.LoadShelfInventory(shelfNo);
            }
            else
                invtDetailView.ClearRows();

        }

        #endregion

        #region 重新加载销售、客户

        private void ReloadSales()
        {
            cboCustomer.Properties.Items.Clear();
            cboSales.Properties.Items.Clear();

            MemoryTable.Instance.LoadSales();
            cboSales.Properties.Items.AddRange(MemoryTable.Instance.SalesList);

            CustomerHelper ch = new CustomerHelper();
            cboCustomer.Properties.Items.AddRange(ch.GetCustomerList());
        }

        #endregion

        #region 全选、不选右键菜单

        private void ctxMenuRecord_Opening(object sender, CancelEventArgs e)
        {
            GridColumn col = recordView.Columns.ColumnByFieldName("CheckStatus");

            if (col == null || col.Visible == false)
            {
                e.Cancel = true;
            }
        }
        
        private void mnuCheckAll_Click(object sender, EventArgs e)
        {
            returnRecordView.CheckAll();
        }

        private void mnuNoCheck_Click(object sender, EventArgs e)
        {
            returnRecordView.UnCheck();
        }

        #endregion

        #region 双击选中货架

        private void invtGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int invtRowHandle = invtView.FocusedRowHandle;

            if (invtRowHandle == -1)
                return;

            if ( CurrentBackboundStatus != Status_Record )
                return;

            int editRowHandle = recordView.FocusedRowHandle;
            if (editRowHandle == -1)
                return;
            string shelfNo = invtView.GetFocusedRowCellValue("ShelfNo").ToString();
            recordView.SetRowCellValue(editRowHandle, "ShelfNo", shelfNo);
        }

        #endregion

        #region 打印记录

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            PrintRecord();
        }

        #endregion
    }
}

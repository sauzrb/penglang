using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
namespace PengLang
{ 
    public partial class FrmTranbound : DevExpress.XtraEditors.XtraForm,InnerForm
    {
        
        //
        TranboundMasterView tranboundMasterView;
        TranboundDetailView tranboundDetailView;
        TranboundEditView tranboundEditView;
        ShelfInventoryView shelfInventoryView;

        string NewTranboundID = String.Empty;//

        #region 接口函数

        private bool bEdit = false;
        public void Save() { }
        public bool IsEdit() { return !bEdit; }
        public void HideForm() { this.Visible = false; }
        public void ShowForm() { this.Visible = true; }

        #endregion

        #region 窗体构造及初始化

        public FrmTranbound()
        {
            InitializeComponent();

            tranboundMasterView = new TranboundMasterView(this.tranboundView);
            tranboundDetailView = new TranboundDetailView(this.detailView);
            tranboundEditView = new TranboundEditView(this.editView);
            shelfInventoryView = new ShelfInventoryView(this.shelfView);


            this.detailView.RowCellClick += new RowCellClickEventHandler(detailView_RowCellClick);
            this.detailView.CustomDrawCell += new RowCellCustomDrawEventHandler(detailView_CustomDrawCell);
             
            this.editView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.editView_KeyUp);
        }
        
        private void FrmTranbound_Load(object sender, EventArgs e)
        {
            InitUI_FormLoad();
            tranboundMasterView.Initialize();
            tranboundDetailView.Initialize();
            tranboundEditView.Initialize();
            shelfInventoryView.Initialize();

            shelfInventoryView.Loading();
            InitComboBoxs();


            if (Database.IsConnected())
                tranboundMasterView.Loading();

            SwitchTranbound();

        }
          
        //编辑倒库明细用的Combobox
        protected void InitComboBoxs()
        {
            cboLotNo.Properties.Items.Clear();

            List<Clothes> list = MemoryTable.Instance.ListClothes;
            for (int i = 0; i < list.Count; i++)
                cboLotNo.Properties.Items.Add(list[i].LotNo);

            cboSizeNo.Properties.Items.Clear();
            cboSizeNo.Properties.Items.AddRange(MemoryTable.Instance.ListSizeNo);
            cboShelfNoTo.Properties.Items.Clear();
            cboShelfNoTo.Properties.Items.AddRange(MemoryTable.Instance.ListShelfNo);
            cboShelfNoFrom.Properties.Items.Clear();
            cboShelfNoFrom.Properties.Items.AddRange(MemoryTable.Instance.ListShelfNo);
        }
                
        #endregion

        #region 设置界面状态

        private int CurrentTranboundStatus = 0;
        const int Status_None = 0; //查询   
        const int Status_Detail = 1;//编辑明细 
        const int Status_Complete = 2;//完成

        private void InitUI_Search(bool bFlag)
        {
            btnSearch.Visible = bFlag;
            btnTranbound.Visible = bFlag;
            lblBeginDate.Visible = bFlag;
            lblEndDate.Visible = bFlag;
            dateBegin.Visible = bFlag;
            dateEnd.Visible = bFlag;
            lblOperator.Visible = bFlag;
            txtOperator.Visible = bFlag;
            btnPrint.Visible = bFlag;

        }

        private void InitUI_FormLoad()
        {
            //将隐藏的按钮对齐 
            btnCancel.Left = btnPrint.Left;
            btnCancel.Top = btnPrint.Top;
            btnCancel.Visible = false;
            btnComplete.Visible = false;
            btnConfirm.Visible = false;
            xtraTab.ShowTabHeader = DefaultBoolean.False;
            tpDetail.PageVisible = true; 
            tpEdit.PageVisible = false;

            splitContainer.Collapsed = false;
            splitContainer.IsSplitterFixed = false;
              
            InitUI_Search(true);

        }
                
        private void InitUI_Detail()
        {
            splitContainer.IsSplitterFixed = true;
            splitContainer.Collapsed = true;

            xtraTab.ShowTabHeader = DefaultBoolean.False;

            tpDetail.PageVisible = false; 
            tpEdit.PageVisible = true;
             
            btnComplete.Visible = true; 
            btnComplete.Enabled = true;

            btnCancel.Visible = true;
            btnCancel.Enabled = true;

            btnConfirm.Visible = false;

            btnPrint.Visible = false;
        }
        
        private void InitUI_Complete()
        {
            shelfInventoryView.ClearRows();
            tranboundEditView.ClearRows();
            InitUI_FormLoad(); 
            InitUI_Search(true);
        }
         
        #endregion
              
        #region 按钮事件
  
        private void btnTranbound_Click(object sender, EventArgs e)
        {
            InitUI_Detail();
            CurrentTranboundStatus = Status_Detail;
            NewTranboundID = Database.GetDataTimekey(3);
            tranboundEditView.TranboundID = NewTranboundID; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("您确定要放弃本次倒库操作吗？") == false)
                return;

            InitUI_Complete();
            NewTranboundID = string.Empty;
            tranboundEditView.ClearRows();
            bEdit = false;
            CurrentTranboundStatus = Status_None;
        }
               
        private void btnComplete_Click(object sender, EventArgs e)
        {
            //填写倒库单
            if (CurrentTranboundStatus == Status_Detail )
            {
                if (HasValitDetail() == false)
                {
                    MsgBox.Error("请填写倒库明细！");
                    return;
                }

                bool bres = SaveTranbond();

                
                FrmSelectOperator dlg = new FrmSelectOperator();

                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    //修改操作人
                    UpdateOperator(NewTranboundID, dlg.OperatorName);
                    tranboundView.SetFocusedRowCellValue("Operator", dlg.OperatorName);
                }
                
                //分解
                MissionAssign missionAssign = new MissionAssign();
                missionAssign.TranboundAssign(NewTranboundID);

                InitUI_Complete();
                CurrentTranboundStatus = Status_None;
                tranboundView.FocusedRowHandle = 0;

                LoadTranboundDetail(NewTranboundID);

                this.Refresh();
                 
                PrintDetail();

                return;
            }
             
        }

        //倒库单确认
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //明细表完成
            if (CurrentTranboundStatus != Status_None) 
                return;

            if (false == MsgBox.Confirm("您确定已经完成了倒库操作？"))
                return;


            string tranboundID = tranboundView.GetFocusedRowCellValue("TranboundID").ToString();
            if (string.IsNullOrEmpty(tranboundID) == true)
            {
                MsgBox.Error("请首先选择完成的倒库单！");
                return;
            }

            //修改倒库单状态
            UpdateTranboundStatus(tranboundID, true);
            tranboundView.SetFocusedRowCellValue("Status", DealStatus.Yes);
            UpdateDetailStatus(tranboundID, Database.GetDateTimeString(), true);

            tranboundDetailView.TranboundID = tranboundID;
            tranboundDetailView.LoadTranboundDetail(tranboundID);
          
        }
        #endregion

        #region EditView 编辑功能

        private void editView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveRows(); 
        }

        private void RemoveRows()
        {
            int[] rows = editView.GetSelectedRows(); 
            if (MsgBox.Confirm("您确定要删除所有选中的数据吗？ ") == false)
                return;
            tranboundEditView.RemoveRows(rows);

        }
  
        private void ctxMenuEdit_Opening(object sender, CancelEventArgs e)
        {
            int[] rows = editView.GetSelectedRows();
            if (rows == null || rows.Length == 0)
                mnuDeleteRow.Enabled = false;
            else
                mnuDeleteRow.Enabled = true;
        }
         
        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }
         
        private bool HasValitDetail()
        {
            int cnt = editView.RowCount;
            if (cnt == 0)
                return false;
            if (editView.GetRowCellValue(0, "DetailID") == null)
                return false;

            string lotno = editView.GetRowCellValue(0, "LotNo").ToString();
            if (string.IsNullOrEmpty(lotno))
                return false;

            return true;

        }
         
        #endregion

        #region  TranboundView 主表编辑

        private void mnuMasterDelete_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("您确定要删除所有选中的倒库单吗？ ") == false)
                return;
            string tranboundID = tranboundView.GetFocusedRowCellValue("TranboundID").ToString();
            if (tranboundMasterView.RemoveTranbound(tranboundID))
            {
                DataTable dt = detailGrid.DataSource as DataTable;
                dt.Rows.Clear();

                tranboundView.DeleteRow(tranboundView.FocusedRowHandle);
                tranboundView.FocusedRowHandle = -1;
            }
        }
       
        private void ctxMenuMaster_Opening(object sender, CancelEventArgs e)
        {
            if (tranboundView.FocusedRowHandle < 0)
            {
                e.Cancel = true;
                return;
            }
            string boundno = tranboundView.GetFocusedRowCellValue("TranboundID").ToString();
            string status = tranboundView.GetFocusedRowCellValue("Status").ToString();
            if ( String.IsNullOrEmpty( boundno) )
            {
                mnuMasterPrint.Enabled = false;
                mnuMasterSetOperator.Enabled = false;
            }
            else
            {
                mnuMasterPrint.Enabled = true;
                mnuMasterSetOperator.Enabled = true;
            }


            if (string.IsNullOrEmpty(status)==false && status == DealStatus.Yes)
            {
                mnuMasterDelete.Enabled = false;
            }
            else
            {
                mnuMasterDelete.Enabled = true;
            }
        }

        private void tranboundView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SwitchTranbound();
        }
     
        private void tranboundView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                e.DisplayText = GetStatusCaption(e.CellValue.ToString());
            }
        }
        
        private void tranboundView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (tranboundView.GetRowCellValue(e.RowHandle, "Status") == null)
                return;

            string status = tranboundView.GetRowCellValue(e.RowHandle, "Status").ToString();
             
            if (status != DealStatus.Yes )
                e.Appearance.ForeColor = Color.Red;

        }
        
        private string GetStatusCaption(string no )
        {
            if (no == DealStatus.Yes )
                return "完成";
            return "未完成";
  
        }

        //保存倒库信息
        private bool SaveTranbond()
        {
            WaitingService.BeginLoading("正在保存数据，请稍等...");
            bool bres = SaveTranboundMasterTable();
            if (bres == false)
            {
                WaitingService.EndLoading();
                return false;
            }

            tranboundEditView.SaveDetail();
             
            WaitingService.EndLoading();

            return true;
        }
         
        private bool SaveTranboundMasterTable()
        {
            int nres = 0;
            string tranboundID = NewTranboundID ;
            string datetime = Database.GetDateString();
            string sql;
            if (FindTranbound(tranboundID) ==  false )
            {
                sql = string.Format("insert into t_tranbound (tranboundID, CreateTime, Operator,Status ) values ('{0}','{1}','{2}','{3}')",
                                                    tranboundID,
                                                    datetime,
                                                    "",
                                                    "0");

                nres = Database.ExecuteSQL(sql, "FrmTranbound-SaveTranboundMasterTable");
               if (nres > 0)
               {
                   tranboundMasterView.InsertTranbound(0, tranboundID, datetime, "", DealStatus.No);
               }
            }
              
            return nres ==0 ? false:true;
        }

        private bool FindTranbound(string id)
        {
            string sql = String.Format("select tranboundID from t_tranbound where tranboundID = '{0}'", id);
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            return true;
        }
                
        private void mnuMasterSetOperator_Click(object sender, EventArgs e)
        {
            int rowID = tranboundView.FocusedRowHandle;

            string status = tranboundView.GetFocusedRowCellValue("Status").ToString();
            if (status == DealStatus.Yes)
            {
                MsgBox.Infometion("已经完成的倒库单，不能修改操作人！");
                return;
            }
            FrmSelectOperator dlg = new FrmSelectOperator();

            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string tranID = tranboundView.GetRowCellValue(rowID,"TranboundID").ToString();
            UpdateOperator(tranID, dlg.OperatorName);

            tranboundView.SetRowCellValue(rowID, "Operator", dlg.OperatorName);

            tranboundDetailView.TranboundID = tranID;
            tranboundDetailView.LoadTranboundDetail(tranID);
        }

        private void UpdateOperator(string tranboundID, string oper)
        {
            string sql = "";

            sql = String.Format("Update T_TranboundDetail Set DealUser = '{0}' where TranboundID = '{1}'", oper, tranboundID);

            Database.ExecuteSQL(sql, "FrmTranbound-UpdateOperator");

            sql = String.Format("Update T_Tranbound Set Operator = '{0}' where TranboundID = '{1}'", oper, tranboundID);

            Database.ExecuteSQL(sql, "FrmTranbound-UpdateOperator");

        }

        private void SwitchTranbound()
        {
            tranboundDetailView.ClearRows();
            //刷新明细表格
            if (tranboundView.GetFocusedRowCellValue("TranboundID") == null)
                return;
            string tranboundno = tranboundView.GetFocusedRowCellValue("TranboundID").ToString();
            string status = tranboundView.GetFocusedRowCellValue("Status").ToString();

            splitContainer.Collapsed = false;
            tranboundDetailView.TranboundID = tranboundno;
            tranboundDetailView.LoadTranboundDetail(tranboundno);
            tpDetail.PageVisible = true;
            tpEdit.PageVisible = false; 

            string tranboundStatus = tranboundView.GetFocusedRowCellValue("Status").ToString();

            if (tranboundStatus == DealStatus.Yes )
            {
                btnComplete.Visible = false; 
                btnConfirm.Visible = false; 
            }
            else
            {
                btnComplete.Visible = false;
                btnConfirm.Visible = true; 
            }
        }

        private void LoadTranboundDetail(string tranboundID)
        {
            tranboundDetailView.ClearRows();
            //刷新明细表格 
            splitContainer.Collapsed = false;
            tranboundDetailView.TranboundID = tranboundID;
            tranboundDetailView.LoadTranboundDetail(tranboundID);
            tpDetail.PageVisible = true;
            tpEdit.PageVisible = false;
              
            string tranboundStatus = tranboundView.GetFocusedRowCellValue("Status").ToString();

            if (tranboundStatus == DealStatus.Yes)
            {
                btnComplete.Visible = false;
                btnConfirm.Visible = false;
            }
            else
            {
                btnComplete.Visible = false;
                btnConfirm.Visible = true;
            }
        }
       
        #endregion

        #region TranboundDetailView 明细表
         
        private void detailView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "DealStatus")
            {
                string status = detailView.GetRowCellValue(e.RowHandle, "DealStatus").ToString();

                if (status == DealStatus.Complete)
                    e.DisplayText = DealStatus.Caption_Complete;
                else
                    e.DisplayText = "";
            }
        }
                
        //更新明细完成状态
        private void UpdateDetailStatus(string tranboundID, string time, bool bres)
        {
           // string status = bres ? "1": "0";
            string status = bres ? DealStatus.Complete: DealStatus.None ;

            string sql = string.Format("Update T_TranboundDetail set DealStatus = '{0}',DealDatetime='{1}' where TranboundID='{2}'",
                status, 
                time,
                tranboundID);
            Database.ExecuteSQL(sql, "FrmTranbound-UpdateDetailStatus");
        }

        //更新到库单的完成状态
        private void UpdateTranboundStatus(string tranboundID,bool status )
        {
            string st = status ? DealStatus.Yes : DealStatus.No;
            string sql = String.Format("update T_Tranbound Set Status = '{0}' where TranboundID='{1}'", st , tranboundID);

            Database.ExecuteSQL(sql, "FrmTranbound-UpdateTranboundStatus");
        }
                 
        private void detailView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //string tranboundID = tranboundView.GetFocusedRowCellValue("TranboundID").ToString();
            string status = tranboundView.GetFocusedRowCellValue("Status").ToString();

            if (e.Column.FieldName == "NumOfPlan" )
            { 
                if (status == DealStatus.Yes)
                    e.Column.OptionsColumn.AllowEdit = false;
                else
                    e.Column.OptionsColumn.AllowEdit = true;
            }
            


        }
         

        #endregion

        #region 检索

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if (dateBegin.Text.Length > 0)
                sql += String.Format(" and CreateTime >= '{0}' ", dateBegin.DateTime.ToString("yyyy-MM-dd"));
            if (dateEnd.Text.Length > 0)
                sql += String.Format(" and CreateTime <= '{0}'", dateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd"));

            if (txtOperator.Text.Trim().Length > 0)
            {
                sql += String.Format(" and Operator like '%{0}%'", txtOperator.Text);
            }
            return sql;
        }
              
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Loadding();
        }

        private void txtOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Loadding();
            }
        }

        private void Loadding()
        {
            if( dateBegin.Text.Trim().Length > 0)
                tranboundMasterView.BeginTime = dateBegin.DateTime.ToString("yyyy-MM-dd");
            else
                tranboundMasterView.BeginTime = "";
            if (dateEnd.Text.Trim().Length > 0)
                tranboundMasterView.EndTime = (dateEnd.DateTime.AddDays(1)).ToString("yyyy-MM-dd");
            else
                tranboundMasterView.EndTime = "";
            if (txtOperator.Text.Trim().Length > 0)
                tranboundMasterView.KeyWords = txtOperator.Text.Trim();
            else
                tranboundMasterView.KeyWords = "";

            tranboundMasterView.Loading();
            SwitchTranbound();
        }
        #endregion

        #region 打印、导出

        private void PrintDetail_ExA()
        {
            PrintingSystem print = new DevExpress.XtraPrinting.PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(print);
            print.Links.Add(link);
            link.Component = detailGrid;//这里可以是可打印的部件
            string _PrintHeader = "倒库明细表";
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
            phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;
            link.CreateDocument(); //建立文档
            print.PreviewFormEx.Show();//进行预览
        }

        private void PrintDetail()
        {
            string tempFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";
            detailGrid.ExportToXls(tempFile);

            if (System.IO.File.Exists(tempFile))
                System.Diagnostics.Process.Start(tempFile);  
            
        }
       
        private void ExportDetail()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel (*.xls)|*.xls"; 
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                detailGrid.ExportToXls(fileDialog.FileName);
                
                if (System.IO.File.Exists(fileDialog.FileName))
                    System.Diagnostics.Process.Start(fileDialog.FileName); //保存v
            }
        }
           
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tranboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择到库单！");
                return;
            } 

            PrintDetail();
        }
        
        private void mnuMasterExport_Click(object sender, EventArgs e)
        {
            if (tranboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择到库单！");
                return;
            }
            ExportDetail(); 
        }

        private void mnuMasterPrint_Click(object sender, EventArgs e)
        {
            if (tranboundView.FocusedRowHandle == -1)
            {
                MsgBox.Infometion("请先选择倒库单！");
                return;
            } 
            PrintDetail();
        }
        
        #endregion

        #region 检索货架库存

         
        private void txtKeyFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                shelfInventoryView.LotNo = this.cboLotNo.Text.Trim();
                shelfInventoryView.SizeNo = this.cboSizeNo.Text.Trim();
                shelfInventoryView.Loading();
            }
        }

        private void btnSearchFrom_Click(object sender, EventArgs e)
        {
            shelfInventoryView.LotNo = this.cboLotNo.Text.Trim();
            shelfInventoryView.SizeNo = this.cboSizeNo.Text.Trim();
            shelfInventoryView.ShelfNo = this.cboShelfNoFrom.Text.Trim();
            shelfInventoryView.Loading();
        }

        #endregion 

        #region ShelfGrid 右键菜单

        private void mnuCheckAllFrom_Click(object sender, EventArgs e)
        {
            shelfInventoryView.CheckAll();
        }

        private void mnuNoCheckFrom_Click(object sender, EventArgs e)
        {
            shelfInventoryView.UnCheck();
        }


        #endregion

        #region 添加倒库明细

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidTranRows() == false)
                return;
            if (ExistValidation() == false)
                return;

            int cnt = shelfView.RowCount;
            TranboundItem item = new TranboundItem();
            item.toShelfNo = cboShelfNoTo.Text.Trim();
         
            for (int i = 0; i < cnt; i++)
            {
                if (shelfInventoryView.IsRowChecked(i) == false)
                    continue; 
                shelfInventoryView.GetTranBoundItem(i, item);
               // if (tranboundEditView.FindTranDetail(item) == false)
               // {
                    tranboundEditView.AddTranBoundDetail(item);
               // }

                    shelfInventoryView.SetRowCheckedState(i, false);

            }//end for 
             
            //shelfInventoryView.ClearRows();
        }

        private bool ValidTranRows()
        {
            int cnt = shelfInventoryView.GetCheckedRowCount();
            if (cnt == 0)
            {
                MsgBox.Error("请先选择要倒库的数据行!");
                return false;
            }
            string shelfNoTo = cboShelfNoTo.Text.Trim();
            if (string.IsNullOrEmpty(shelfNoTo))
            {
                MsgBox.Error("请输入要转入的货架号!");
                return false ;
            }

            if (FindShelfNo(shelfNoTo) == false)
            {

                MsgBox.Error("Shelf# To does not exist.");
                return false;
            }

            return true;
        }

        private bool FindShelfNo(string shelfNo)
        {
            List<String> list = MemoryTable.Instance.ListShelfNo;

            for (int i = 0; i < list.Count; i++)
                if (shelfNo == list[i])
                    return true;

            return false;
        }

        private bool ExistValidation()
        {
            int cnt = shelfView.RowCount;
            TranboundItem item = new TranboundItem();
            item.toShelfNo = cboShelfNoTo.Text.Trim();
            string tip;
            for (int i = 0; i < cnt; i++)
            {
                if (shelfInventoryView.IsRowChecked(i) == false)
                    continue;
                shelfInventoryView.GetTranBoundItem(i, item); 
                if (tranboundEditView.FindTranDetail(item) == true)
                {
                
                    tip = string.Format("Row:{0}  From Shelf#: {1} , Art#: {2} , Size#: {3}  already exists.", i+1, item.fromShelfNo,item.lotNo, item.sizeNo );
                    MsgBox.Error(tip);
                    return false;
                }

            }//end for 

            return true;
        }

        #endregion
    }
}

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

using Sau.Util;

namespace PengLang 
{
    public class SalesCashView : BaseGridView
    {
        public double TotalAmount = 0.0;
        public string RcvdRecdID = String.Empty;
        public string RcvdKind = string.Empty;

        private List<OutboundRcvd> OutboundList = new List<OutboundRcvd>();

        public SalesCashView()
        {
      
        }

        public SalesCashView(GridView view)
        {
            base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colRecordID;
        protected DevExpress.XtraGrid.Columns.GridColumn colOutboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdID;
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colOutboundNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colRcvdAmount;
        protected DevExpress.XtraGrid.Columns.GridColumn colBalance;
        protected DevExpress.XtraGrid.Columns.GridColumn colRemark;
        protected DevExpress.XtraGrid.Columns.GridColumn colPayOff;

        protected override void CreateGridColumns()
        {
            this.colRecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutboundNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcvdAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayOff = new DevExpress.XtraGrid.Columns.GridColumn();
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colRecordID,
                        this.colOutboundID,
                        this.colRcvdID,
                        this.colSales,
                        this.colOutboundNo, 
                        this.colRcvdAmount,
                        this.colBalance,
                        this.colPayOff,
                        this.colRemark
            };

            // 
            // colRecordID
            // 
            this.colRecordID.Caption = "认领编号";
            this.colRecordID.FieldName = "RecordID";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRecordID.Visible = false;
            this.colRecordID.Width = 0;
            // 
            // colOutboundID
            // 
            this.colOutboundID.Caption = "出库编号";
            this.colOutboundID.FieldName = "OutboundID";
            this.colOutboundID.Name = "colOutboundID";
            this.colOutboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOutboundID.Visible = false;
            this.colOutboundID.Width = 0;
            // 
            // colRcvdID
            // 
            this.colRcvdID.Caption = "收款编号";
            this.colRcvdID.FieldName = "RcvdRecdID";
            this.colRcvdID.Name = "colRcvdID";
            this.colRcvdID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRcvdID.Visible = false;
            this.colRcvdID.Width = 80;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 80;

            // 
            // colOutboundNo
            // 
            this.colOutboundNo.Caption = "P.O#";
            this.colOutboundNo.FieldName = "OutboundNo";
            this.colOutboundNo.Name = "colOutboundNo";
            this.colOutboundNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOutboundNo.Visible = true;
            this.colOutboundNo.Width = 80;
            // 
            // colRcvdAmount
            // 
            this.colRcvdAmount.Caption = "Rcvd Amt";
            this.colRcvdAmount.FieldName = "RcvdAmount";
            this.colRcvdAmount.Name = "colRcvdAmount";
            this.colRcvdAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colRcvdAmount.Visible = true;
            this.colRcvdAmount.Width = 80;
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Inv Amt";
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBalance.Visible = true;
            this.colBalance.Width = 80;

            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colRemark.Visible = true;
            this.colRemark.Width = 120;

            // 
            // colPayOff
            // 
            this.colPayOff.Caption = "Pay Off";
            this.colPayOff.FieldName = "PayOff";
            this.colPayOff.Name = "colPayOff";
            this.colPayOff.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colPayOff.Visible = true;
            this.colPayOff.Width = 70;

            CreatePoNoCombo();
            CreateSalseCombo();
            CreatePayoffCombo();
        }

        #endregion

        #region Grid Repository

        private RepositoryItemComboBox comboPoNo;
        private RepositoryItemComboBox comboSales;
        private RepositoryItemComboBox comboPayoff;

        private List<OutboundRcvd> LoadOutbounds()
        {
            List<OutboundRcvd> list = new List<OutboundRcvd>();
            string  sql = "select OutboundID,Sales , OrderNo, (PriceAmount + Freight) as InvAmt, RcvdAmount from V_OutboundCash ";
            sql += " where PriceAmount > 0  and Sales <> 'NO' and (PayOff<>'YES' or PayOff is null) and ShipDate <>'' Order By OrderNo ";
            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return list;
            OutboundRcvd item = null;
            string temp = "";
            for (int i = 0,col=0; i < dt.Rows.Count; i++)
            {
                col = 0;
                temp = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(temp.Trim() ))
                    continue;

                item = new OutboundRcvd();
                item.OutboundId = dt.Rows[i][col++].ToString();
                item.Sales = dt.Rows[i][col++].ToString();
                item.OutboundNo = dt.Rows[i][col++].ToString();

                temp = dt.Rows[i][col++].ToString(); 
                if (string.IsNullOrEmpty(temp) == false)
                    item.InvoiceAmount = Convert.ToDouble(temp);

                temp = dt.Rows[i][col++].ToString();
                if (string.IsNullOrEmpty(temp) == false)
                    item.RcvdAmount = Convert.ToDouble(temp);

                item.BalanceAmount = item.InvoiceAmount - item.RcvdAmount;
                //靠PayOff = “yes”
                if (item.BalanceAmount <= 0.0)
                    continue;

                list.Add(item);
            }

            return list;
        }

        protected void CreateSalseCombo()
        {
            comboSales = new RepositoryItemComboBox();
            comboSales.Name = "comboSales";
            comboSales.AutoHeight = true;
            MemoryTable.Instance.LoadSales();
            List<string> list = MemoryTable.Instance.SalesList;

            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[i].Trim()))
                    continue;

                if (list[i].ToUpper() == "NO")
                    continue;
                comboSales.Items.Add(list[i]);
            }
            colSales.ColumnEdit = comboSales;
        }

        protected void CreatePoNoCombo()
        {
            comboPoNo = new RepositoryItemComboBox();
            comboPoNo.Name = "comboPoNo";
            comboPoNo.AutoHeight = true;  
            colOutboundNo.ColumnEdit = comboPoNo;
        }
       
        protected void CreatePayoffCombo()
        {
            comboPayoff = new RepositoryItemComboBox();
            comboPayoff.Name = "comboPayOff";
            comboPayoff.AutoHeight = true;
            colPayOff.ColumnEdit = comboPayoff;

            comboPayoff.Items.Add("YES");
            comboPayoff.Items.Add("NO");

        }
      
        protected void SelectSales(string sales)
        {
            comboPoNo.Items.Clear();

            for (int i = 0; i < OutboundList.Count; i++)
            {
                if (OutboundList[i].Sales == sales)
                    comboPoNo.Items.Add(OutboundList[i].OutboundNo);
            }
        }

        #endregion

        #region 视图初始化

        public override void Initialize(GridView view)
        {
            OutboundList =  LoadOutbounds();
            base.Initialize(view);

            //if (RcvdKind.ToUpper() == "FAC")
            //{
            //    this.colBalance.Caption = "Factor Fee";
            //}else
            //    this.colBalance.Caption = "Inv Amt";
        }

        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = true;  
            gridView.OptionsCustomization.AllowColumnMoving = false; 
            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsSelection.InvertSelection = true;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
            gridView.IndicatorWidth = 30;

            this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);
            gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.OnValidateRow);
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.OnCellValueChanged);
        }
        
        #endregion

        #region 编辑
         
        public void ClearRows()
        {
            if (dataTable != null)
                dataTable.Rows.Clear();
        }

        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
          
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                gridView.DeleteRow(rowHandles[i]);
            }
        }

        private void OnCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int nFind = -1;

            if (e.Column == colSales)
            {
                SelectSales(e.Value.ToString());
                return;
            }
            
            if (e.Column == colOutboundNo)
            {

                nFind = FindOutbound(e.Value.ToString());
                if (nFind < 0)
                    return;
                OutboundRcvd item = OutboundList[nFind];

                gridView.SetRowCellValue(e.RowHandle, colBalance, item.BalanceAmount.ToString("f2"));

                return;
            }

            if (e.Column == colRcvdAmount)
            {
                string poNo = gridView.GetRowCellValue(e.RowHandle, colOutboundNo).ToString();
                nFind = FindOutbound(poNo);
                if (nFind < 0)
                    return;
                OutboundRcvd item = OutboundList[nFind];
                double val = 0.0;

                double.TryParse(e.Value.ToString(), out val);

                gridView.SetRowCellValue(e.RowHandle, colBalance, (item.BalanceAmount-val).ToString("f2"));

                return;

            }
        }
    
        #endregion

        #region 合法校对

        public void OnValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
           
            if( e.Value == null) 
                 return;
             
            string tmp = e.Value.ToString().Trim() ;
             
            if( string.IsNullOrEmpty(tmp) )
                return;
             
            #region 金额校对
              
            if (gridView.FocusedColumn == colRcvdAmount)
            {
                double val = 0.0; 
                if (double.TryParse(tmp, out val) == false)
                {
                    e.ErrorText = "数据格式不正确！";
                    e.Valid = false;
                    return;
                }

                if (val < 0)
                {
                    e.ErrorText = "不能输入负数！";
                    e.Valid = false;
                    return;
                }

                Object obj = gridView.GetFocusedRowCellValue(colBalance);
                if (obj == null)
                    return;
                double balance = Convert.ToDouble(obj);

                if (val > balance)
                {
                    e.ErrorText = "输入的数值不正确.";
                    e.Valid = false;
                    return;
                }
            }
               
            #endregion

            #region 出库单验证

            if (gridView.FocusedColumn == colOutboundNo)
            {
                if (FindOutbound(tmp) == -1)
                {
                    e.ErrorText = "出库单号不存在！";
                    e.Valid = false;
                    return;
                }

                if (IsOutboundNoExist(e.Value.ToString(), gridView.FocusedRowHandle) == true)
                {
                    e.ErrorText = "出库单号已经存在！";
                    e.Valid = false;
                    return;
                }
            }
            #endregion

        }

        private int FindOutbound(string poNo)
        {
            if (OutboundList == null || OutboundList.Count == 0)
                return -1;

            for (int i = 0; i < OutboundList.Count; i++)
                if (OutboundList[i].OutboundNo == poNo)
                    return i;

            return -1;

        }
        
        private void OnValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Object obj = gridView.GetFocusedRowCellValue(colOutboundNo);
            if (obj == null)
            {
                e.ErrorText = "P.O#不能为空.";
                e.Valid = false;
                return; 
            }
            string tmp = gridView.GetFocusedRowCellValue(colOutboundNo).ToString();
            if (string.IsNullOrEmpty(tmp))
            {
                e.ErrorText = "P.O#不能为空.";
                e.Valid = false;
                return; 
            }
            
            obj = gridView.GetFocusedRowCellValue(colRcvdAmount);
            if (obj == null)
            {
                e.ErrorText = "收款金额不能为空.";
                e.Valid = false;
                return;
            }
        }
         
        private bool IsOutboundNoExist(string pono, int exceptRowHandle)
        {
            for (int i = gridView.RowCount - 1; i >= 0; i--)
            {
                object obj = gridView.GetRowCellValue(i, colOutboundNo);
                if (obj == null)
                    continue;
                if (obj.ToString() == pono && i != exceptRowHandle)
                    return true;
            }
            return false;
        }

        #endregion

        #region 保存

        private bool SaveRcvdItem(int iRow)
        {
           
            string recId = Database.GetGlobalKey();

            string outPo = gridView.GetRowCellValue(iRow, "OutboundNo").ToString();
            int iFind = FindOutbound(outPo);
            string outId = "";
            if (iFind > -1)
                outId = OutboundList[iFind].OutboundId;
            string amount = gridView.GetRowCellValue(iRow, "RcvdAmount").ToString();
            if (amount == "")
                amount = "0.0";
            string remark = "";
            Object obj = gridView.GetRowCellValue(iRow, "Remark");
            if (obj != null)
                remark = obj.ToString();
            string sql = string.Format("Insert into T_RcvdRecord (RecordID,RcvdRecdID ,outboundId ,outboundNo, DecmDate, RcvdAmount, Remark ) "
                    + "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}' )",
                    recId,
                    RcvdRecdID,
                    outId,
                    outPo,
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    amount,
                    remark.Replace("'","''")   );
            
            int nres = Database.ExecuteSQL(sql, "SalesCashView-SaveRcvdItem");
            if (nres > 0)
            {
                gridView.SetRowCellValue(iRow, "RecordID", recId);
                string payoff = gridView.GetRowCellValue(iRow, "PayOff").ToString();
                UpdateOutboundPayOff(outId, payoff);

            }
            return nres > 0 ? true :false ;
        }

        private bool DeleteRcvd(string rcvdId)
        {
            string sql = string.Format("delete from t_rcvdrecord where rcvdrecdId = '{0}'", rcvdId);

            return Database.ExecuteSQL(sql, "SalesCashView--DeleteRcvd") > 0 ? true : false;
        }

        private bool UpdateOutboundPayOff(string outboundId, string payoff)
        {
            string sql = string.Format("update t_outbound  set payoff = '{0}' where outboundid = '{1}'",
                payoff,
                outboundId);

            return Database.ExecuteSQL(sql, "SalesCashView--UpdateOutboundPayOff") > 0 ? true : false;
        }

        public bool Save()
        {
            int nCnt = 0;

            Cursor.Current = Cursors.WaitCursor;
            Object obj = null;
            for (int i = 0; i < gridView.RowCount; i++)
            {
                obj = gridView.GetRowCellValue(i, "OutboundNo");

                if (obj == null)
                    continue;
                if (false == SaveRcvdItem(i))
                {
                    nCnt++;
                    break;
                }
            }

            if (nCnt > 0)
            {
                DeleteRcvd(RcvdRecdID);
            }

            Cursor.Current = Cursors.Default;

            return nCnt > 0 ? false : true ;
           
        }

        #endregion

        
    }

    class OutboundRcvd
    {
        public string OutboundId  ="";
        public string OutboundNo = "";
        public string Sales = "";
        public double InvoiceAmount = 0;
        public double RcvdAmount = 0;
        public double BalanceAmount = 0;
    }
}

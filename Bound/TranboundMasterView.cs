using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Sau.Util;

namespace PengLang
{
    public class TranboundMasterView : BaseGridView
    {
        public string KeyWords = String.Empty;
        public string BeginTime = String.Empty;
        public string EndTime = String.Empty;

        public TranboundMasterView()
        {
            this.LoadData = this.LoadTranbound;
        }

        public TranboundMasterView(GridView view)
        {
            base.SetGridView(view);
            this.LoadData = this.LoadTranbound;
        }
        
        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colTranboundID;
        protected DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        protected DevExpress.XtraGrid.Columns.GridColumn colOperator;
        protected DevExpress.XtraGrid.Columns.GridColumn colStatus;

        #endregion

        protected override void CreateGridColumns()
        {
            this.colTranboundID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colTranboundID,
                        this.colCreateTime,
                        this.colOperator, 
                        this.colStatus  
            };

            // 
            // colTranboundID
            // 
            this.colTranboundID.Caption = "倒库单编号";
            this.colTranboundID.FieldName = "TranboundID";
            this.colTranboundID.Name = "colTranboundID";
            this.colTranboundID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTranboundID.Visible = false;
            this.colTranboundID.Width = 100;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "Date";//"倒库日期";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCreateTime.Visible = true;
            this.colCreateTime.Width = 100;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operator";//"操作人员";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOperator.Visible = true;
            this.colOperator.Width = 100;

            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";//"完成状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStatus.Visible = true;
            this.colStatus.Width = 100;

        }
        
        protected override void InitGridView()
        {
            base.InitGridView();
            gridView.OptionsBehavior.Editable = false;
        }
    
        public void LoadTranbound()
        {

            string sql = "Select TranboundID,  CreateTime, Operator,Status  From T_Tranbound";

            sql += GetFilterSql();

            sql += " Order by Status asc, CreateTime desc ";

            dataTable = Database.Select(sql);

            DataSource = dataTable;
        }

        private string GetFilterSql()
        {
            string sql = " where 1=1 ";

            if ( String.IsNullOrEmpty( BeginTime) == false)
                sql += String.Format(" and CreateTime >= '{0}' ", BeginTime);
            if (String.IsNullOrEmpty( EndTime) == false )
                sql += String.Format(" and CreateTime <= '{0}'", EndTime);

            if (String.IsNullOrEmpty( KeyWords ) == false)
            {
                sql += String.Format(" and Operator like '%{0}%'", KeyWords); 
            }
            return sql;
        }

        public bool RemoveTranbound(string tranboundID)
        {
            string sql = string.Format("delete from T_TranboundDetail where tranboundID = '{0}'", tranboundID);
            int nres = Database.ExecuteSQL(sql, "TranboundMasterView-RemoveTranbound");
 
            sql = string.Format("delete from T_Tranbound where TranboundID = '{0}'",tranboundID);
            nres = Database.ExecuteSQL(sql, "TranboundMasterView-RemoveTranbound");
            return nres >0 ? true : false;
        }
    
        public void InsertTranbound(int pos, string id, string datetime, string oper, string status)
        {
            DataRow dr = dataTable.NewRow();
            dr["TranboundID"] = id;
            dr["CreateTime"] = datetime;
            dr["Operator"] = oper;
            dr["Status"] = status;

            dataTable.Rows.InsertAt(dr,pos);
        }
    }
}

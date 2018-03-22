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
using DevExpress.XtraEditors.Controls;
using Sau.Util;

namespace PengLang
{
    public class UserGridView : BaseGridView
    {
        public string KeyWords = String.Empty;
        private IEncrypt encrypt = new DESEncrypt();
        private RepositoryItemComboBox comboKind;

        public UserGridView() { }

        public UserGridView(GridView view)
        {
            base.SetGridView(view);
        }

        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colUserCode;
        protected DevExpress.XtraGrid.Columns.GridColumn colUserName;
        protected DevExpress.XtraGrid.Columns.GridColumn colUserPsw;
        protected DevExpress.XtraGrid.Columns.GridColumn colUserKind; 
 
        #endregion

        #region 表格初始化

        protected override void InitGridView()
        {
            base.InitGridView();

            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsCustomization.AllowColumnMoving = true;
            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;

            //this.gridView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(OnValidatingEditor);

        }

        protected override void CreateGridColumns()
        {
            this.colUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserPsw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserKind = new DevExpress.XtraGrid.Columns.GridColumn(); 
            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
            this.colUserCode, 
            this.colUserName,
            this.colUserPsw, 
            this.colUserKind };

            // 
            // colUserCode
            // 
            this.colUserCode.Caption = "LoginCode";
            this.colUserCode.FieldName = "UserCode";
            this.colUserCode.Name = "colUserCode";
            this.colUserCode.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUserCode.Visible = false;
            this.colUserCode.Width = 0;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Name";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUserName.Visible = true;
            this.colUserName.Width = 150;
            // 
            // colUserKind
            // 
            this.colUserKind.Caption = "Role";
            this.colUserKind.FieldName = "UserRight";
            this.colUserKind.Name = "colUserKind";
            this.colUserKind.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUserKind.Visible = true;
            this.colUserKind.Width = 100;
            // 
            // colUserPsw
            // 
            this.colUserPsw.Caption = "Password";
            this.colUserPsw.FieldName = "UserPsw";
            this.colUserPsw.Name = "colUserPsw";
            this.colUserPsw.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colUserPsw.Visible = true;
            this.colUserPsw.Width = 100;
                       
            CreateUserKindCombo();
        }

        protected void CreateUserKindCombo()
        {
            comboKind = new RepositoryItemComboBox();
            comboKind.Name = "comboKind";
            comboKind.AutoHeight = true;
            comboKind.Items.Add("管理员");
            comboKind.Items.Add("销售");
            comboKind.Items.Add("财务"); 
            comboKind.Items.Add("其它");
            colUserKind.ColumnEdit = comboKind;
        }

        #endregion

        #region 加载数据

        public override void Loading()
        {
            if (dataTable == null)
                return;
            if (gridView == null)
                return;

            WaitingService.BeginLoading();
            dataTable.Rows.Clear();

            if (LoadData != null)
                LoadData();

            string sql = String.Format("Select UserCode, UserName, UserPsw, UserRight From T_User  ");

            if (String.IsNullOrEmpty(KeyWords) == false)
            {
                sql += GetSqlWhere(KeyWords);
            }
            sql += " order by UserName ";

            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            DataTable dt = Database.Select(sql);
            Object obj = null;
            gridView.GridControl.DataSource = dt;
            int cnt = dt.Rows.Count;
            int no = 0;
            for (int i = 0; i < cnt; i++)
            {
                no = 0;
                obj = dt.Rows[i]["UserPsw"];
                if( string.IsNullOrEmpty(obj.ToString() ) == false )
                    dt.Rows[i]["UserPsw"] = encrypt.DecryptString(obj.ToString() );

                obj = dt.Rows[i]["UserRight"];
                if (string.IsNullOrEmpty(obj.ToString()) == false)
                {
                    int.TryParse(obj.ToString(), out no);
                    dt.Rows[i]["UserRight"] = User.GetUserKindName(no);
                }

            }
            gridView.EndDataUpdate();

            if (dt.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dt.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }

        private string GetSqlWhere(string keywords)
        {
            String sql = " where ";
            if (keywords.Length > 0)
            {
                sql = String.Format(" where UserName like '{0}%' or UserCode like  '{0}%' ",
                    keywords.Trim().Replace("'", "''"));

            }
            return sql;
        }

        #endregion

        #region 编辑数据

        public void RemoveRows(int[] rowHandles)
        {
            if (rowHandles == null)
                return;
            string userCode = "";
            for (int i = rowHandles.Length - 1; i >= 0; i--)
            {
                userCode = gridView.GetRowCellValue(rowHandles[i], colUserCode).ToString();
                if (RemoveUser(userCode) == true)
                    gridView.DeleteRow(rowHandles[i]);
            }

        }

        private bool RemoveUser(string userCode)
        {
            if (userCode == AppConfig.LoginUser.UserCode)
            {
                return false;
            }
            string sql = String.Format("delete from T_User where UserCode = '{0}'", userCode);
            return Database.ExecuteSQL(sql, "UserGridView-RemoveUser") == 0 ? false : true;
        }
        
        public void InsertRow(int pos)
        {

            DataTable dt = gridView.GridControl.DataSource as DataTable;
            DataRow dataRow = dt.NewRow();
            dt.Rows.InsertAt(dataRow, pos);

        }
        
        public bool UpdateUser(int rowHandle)
        {
            string sql = "";
            string userCode = gridView.GetRowCellValue(rowHandle, colUserCode).ToString();
            string userName = gridView.GetRowCellValue(rowHandle, colUserName).ToString();
            string userPsw = gridView.GetRowCellValue(rowHandle, colUserPsw).ToString();
            string userKind = gridView.GetRowCellValue(rowHandle, colUserKind).ToString(); 
            int userKindNo = User.GetUserKindNo(userKind);

            if (string.IsNullOrEmpty(userName))
                return false;
            userPsw = encrypt.EncryptString(userPsw); 
            sql = String.Format("Update T_User Set UserCode = '{0}', UserName='{1}', UserPsw='{2}',UserRight='{3}'  where UserCode = '{4}'",
                userCode.Replace("'","''"),
                userName.Replace("'", "''"),
                userPsw.Replace("'", "''"),
                userKindNo, 
                userCode.Replace("'", "''")   );
            return Database.ExecuteSQL(sql, "UserGridView-UpdateUser") == 1 ? true : false;
        }

        public string AddUser(int rowHandle)
        {
            string sql = "";
            string userCode = gridView.GetRowCellValue(rowHandle, colUserCode).ToString();
            string userName = gridView.GetRowCellValue(rowHandle, colUserName).ToString();
            string userPsw = gridView.GetRowCellValue(rowHandle, colUserPsw).ToString();
            string userKind = gridView.GetRowCellValue(rowHandle, colUserKind).ToString(); 
            int userKindNo = User.GetUserKindNo(userKind);
            if (string.IsNullOrEmpty(userName))
                return string.Empty;
            
            userPsw = encrypt.EncryptString(userPsw);

            sql = String.Format("Insert into T_User (UserCode, UserName, UserPsw, UserRight  ) "
                + "Values('{0}','{1}','{2}','{3}' )",
                userName.Replace("'", "''"),
                userName.Replace("'", "''"),
                userPsw.Replace("'", "''"),
                userKindNo );

            if (Database.ExecuteSQL(sql, "UserGridView-AddUser") <= 0)
                return string.Empty ;
             
            return userName;
        }
        
        public bool FindUserName(string userName)
        {
            string sql = String.Format("select UserCode from T_User where UserName = '{0}'", userName.Replace("'", "''") );
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public bool FindUserNameExcept(string userName, string excpetUserCode)
        {
            string sql = String.Format("select UserCode from T_User where UserName = '{0}' and UserCode <> '{1}' ", 
                userName.Replace("'","''"),
                excpetUserCode.Replace("'", "''"));
            DataTable dt = Database.Select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
       
        #endregion

        public string EncryptPsw(string psw)
        {
            return encrypt.EncryptString(psw);
        }

        public string DecryptPsw(string psw)
        {
            return encrypt.DecryptString(psw);
        }
    }
}

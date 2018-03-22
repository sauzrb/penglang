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

using Sau.Util;

namespace PengLang
{
    public class CustomerGridView : BaseGridView
    {
        public string KeyWords = String.Empty;

        public CustomerGridView() { }
        public CustomerGridView(GridView view)
        {
            base.SetGridView(view);
        }
         
        #region GridColumn

        protected DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        protected DevExpress.XtraGrid.Columns.GridColumn colSales;
        protected DevExpress.XtraGrid.Columns.GridColumn colCustomerNo;
        protected DevExpress.XtraGrid.Columns.GridColumn colCompany;
        protected DevExpress.XtraGrid.Columns.GridColumn colAddress;
        protected DevExpress.XtraGrid.Columns.GridColumn colTel;
        protected DevExpress.XtraGrid.Columns.GridColumn colFax;
        protected DevExpress.XtraGrid.Columns.GridColumn colEmail;
        protected DevExpress.XtraGrid.Columns.GridColumn colShipTo; 
        protected DevExpress.XtraGrid.Columns.GridColumn colShippingWay;
        protected DevExpress.XtraGrid.Columns.GridColumn colTerm;
        protected DevExpress.XtraGrid.Columns.GridColumn colFreight;

        #endregion

        #region 初始化

        protected override void InitGridView()
        {
            base.InitGridView();

            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsBehavior.Editable = false;
           // gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
           // gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
           // gridView.OptionsCustomization.AllowColumnMoving = true;
           // gridView.OptionsNavigation.AutoFocusNewRow = true;
           // gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;

            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsMenu.EnableFooterMenu = false;
             
        }

        protected override void CreateGridColumns()
        {
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();

            this.colShipTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingWay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreight = new DevExpress.XtraGrid.Columns.GridColumn();

            Columns = new DevExpress.XtraGrid.Columns.GridColumn[] { 
            this.colCustomerID, 
            this.colCustomerNo, 
            this.colCompany, 
            this.colAddress,
            this.colSales,
            this.colTel,
            this.colFax,
            this.colEmail,
            this.colShipTo,
            this.colShippingWay,
            this.colTerm,
            this.colFreight };

            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "ID";
            this.colCustomerID.FieldName = "ID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerID.Visible = false;
            this.colCustomerID.Width = 1;
            // 
            // colCustomerNo
            // 
            this.colCustomerNo.Caption = "Customer#";
            this.colCustomerNo.FieldName = "CustomerNo";
            this.colCustomerNo.Name = "colCustomerNo";
            this.colCustomerNo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerNo.Visible = true;
            this.colCustomerNo.Width = 80;
            // 
            // colSales
            // 
            this.colSales.Caption = "Sales";
            this.colSales.FieldName = "Sales";
            this.colSales.Name = "colSales";
            this.colSales.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colSales.Visible = true;
            this.colSales.Width = 100; 
            // 
            // colCompany
            // 
            this.colCompany.Caption = "SellTo";
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCompany.Visible = true;
            this.colCompany.Width = 200; 
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colAddress.Visible = true;
            this.colAddress.Width = 300;
            // 
            // colTel
            // 
            this.colTel.Caption = "TEL";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTel.Visible = true;
            this.colTel.Width = 100;

            // 
            // colFax
            // 
            this.colFax.Caption = "FAX";
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFax.Visible = true;
            this.colFax.Width = 100;

            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEmail.Visible = true;
            this.colEmail.Width = 130;

            // 
            // colShipTo
            // 
            this.colShipTo.Caption = "ShipTo";;
            this.colShipTo.FieldName = "ShipTo";
            this.colShipTo.Name = "colShipTo";
            this.colShipTo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShipTo.Visible = true;
            this.colShipTo.Width = 300;
            // 
            // colShippingWay
            // 
            this.colShippingWay.Caption = "Shipping Way";
            this.colShippingWay.FieldName = "Shippingway";
            this.colShippingWay.Name = "colShippingWay";
            this.colShippingWay.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colShippingWay.Visible = false;
            this.colShippingWay.Width = 150;
            // 
            // colTerm
            // 
            this.colTerm.Caption = "Term(days)";
            this.colTerm.FieldName = "Term";
            this.colTerm.Name = "colTerm";
            this.colTerm.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTerm.Visible = false;
            this.colTerm.Width = 80;
            // 
            // colTerm
            // 
            this.colFreight.Caption = "Shipping($)";
            this.colFreight.FieldName = "freight";
            this.colFreight.Name = "colFreight";
            this.colFreight.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFreight.Visible = false;
            this.colFreight.Width = 80;
        }

        #endregion

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

            string sql = String.Format("Select ID,Sales, CustomerNo, Company, Address, Tel, Fax, Email, ShipTo , ShippingWay,Term,freight  From T_Customer ");

            if (String.IsNullOrEmpty(KeyWords) == false)
            {
                sql += GetSqlWhere(KeyWords);
            }
            sql += " order by CustomerNo ";

            gridView.BeginUpdate();
            gridView.BeginDataUpdate();

            dataTable= Database.Select(sql);
            gridView.GridControl.DataSource = dataTable;

            gridView.EndDataUpdate();

            if (dataTable.Rows.Count > 0)
                gridView.IndicatorWidth = 25 + (dataTable.Rows.Count.ToString().Length + 1) * 5;

            gridView.EndUpdate();

            WaitingService.EndLoading();
        }
  
        private string GetSqlWhere(string keywords)
        {
            String sql = " where ", temp = "";
            if (keywords.Length > 0)
            {
                string[] keys = keywords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int cnt = keys.Length;

                for (int i = 0; i < cnt; i++)
                {
                    temp = String.Format(" ( CustomerNo like '%{0}%' or Company like  '%{0}%' or Address like '%{0}%' ) ", keys[i].Replace("'","''") );
                    //temp = String.Format(" ( LotNo = '{0}' or StyleNo =  '{0}' or SizeNo = '{0}' ) ", keys[i]);
                    if (i > 0)
                        sql += " and " + temp;
                    else
                        sql += temp;
                }
            }
            return sql;
        }

        public void InsertCustomer(int pos, Customer obj)
        {
            DataRow dr = dataTable.NewRow();

            dr["ID"] = obj.ID;
            dr["Sales"] = obj.Sales;
            dr["CustomerNo"] = obj.CustomerNo; 
            dr["Company"] = obj.Company;
            dr["Address"] = obj.Address;
            dr["Tel"] = obj.Tel;
            dr["Fax"] = obj.Fax;
            dr["Email"] = obj.Email;
            dr["ShipTo"] = obj.ShipTo;

            dr["ShippingWay"] = obj.ShippingWay;
            dr["Term"] = obj.Term;
            dr["freight"] = obj.Freight;
            dataTable.Rows.InsertAt(dr,pos);
        }

        public void UpdateCustomer(int pos, Customer obj)
        { 
            DataRow dr = dataTable.Rows[pos];
            if (dr == null || dr.RowState == DataRowState.Deleted)
                return;
            dr["ID"] = obj.ID;
            dr["Sales"] = obj.Sales;
            dr["CustomerNo"] = obj.CustomerNo; 
            dr["Company"] = obj.Company;
            dr["Address"] = obj.Address;
            dr["Tel"] = obj.Tel;
            dr["Fax"] = obj.Fax;
            dr["Email"] = obj.Email;
            dr["ShipTo"] = obj.ShipTo;
            dr["ShippingWay"] = obj.ShippingWay;
            dr["Term"] = obj.Term;
            dr["freight"] = obj.Freight;
        }
    }
}

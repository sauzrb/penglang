using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;

namespace PengLang
{
    public class ExportOutboundInvoice : ExportToExcel
    { 
        public static void Export(GridView detailView, string outboundID, string exportFile )
        {
            string templetFile = GetTempletFile( detailView.RowCount );

            templetFile = string.Format("{0}\\templet\\{1}", Application.StartupPath , templetFile);

            if (File.Exists(templetFile) == false)
            {
                MsgBox.Error("模版文件不存在，请跟管理员联系！");
                return;
            }

            FileStream file = new FileStream(templetFile, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
           
            //导出数据

            OutBound outbound = GetOutBound(outboundID);
            GetData(sheet, outbound, detailView);

            //保存文件
            sheet.ForceFormulaRecalculation = true; 
            using (FileStream filess = File.OpenWrite(exportFile))
            {
                hssfworkbook.Write(filess);
                filess.Close();
                filess.Dispose();
            }
            
            //file.Close();
            //file.Dispose();

            GC.Collect();
            
        }

        public static void GetData(ISheet sheet, OutBound outbound, GridView grid)
        {
            IRow eRow = null;
            ICell eCell = null;

            //导出日期
            eRow = sheet.GetRow(1);
            eCell = eRow.GetCell(35);
            eCell.SetCellValue(GetEinglishDate(outbound.CreateTime));
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

            //导出订单编号 
            eRow = sheet.GetRow(2);
            eCell = eRow.GetCell(35);
            eCell.SetCellValue(outbound.OrderNo);
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
             
           
            //导出客户编号 
            eRow = sheet.GetRow(3);
            eCell = eRow.GetCell(35);
            eCell.SetCellValue(outbound.CustomerNo);
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

            //导出shell To 
            eRow = sheet.GetRow(5);
            eCell = eRow.GetCell(2);
            eCell.SetCellValue(outbound.SellTo);
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

            //地址
            eRow = sheet.GetRow(6);
            eCell = eRow.GetCell(2);
            eCell.SetCellValue(outbound.ShipAddress);
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Top;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            eCell.CellStyle.WrapText = true;

            //导出ship to 
            eRow = sheet.GetRow(5);
            eCell = eRow.GetCell(28);
            eCell.SetCellValue(outbound.ShipTo);
            eCell.CellStyle.VerticalAlignment = VerticalAlignment.Top;
            eCell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            eCell.CellStyle.WrapText = true;
            
            //导出 Shipway
            sheet.GetRow(9).GetCell(2).SetCellValue(outbound.Shippingway);

            //导出 Terms
            sheet.GetRow(9).GetCell(28).SetCellValue(outbound.Term);

            int begRow = 13, begCol = 0;

            int ssRow = grid.RowCount;
            int ssCol = grid.Columns.Count;

            string artNo = string.Empty;
            Clothes clothes = null;
            Object obj = null;

            for (int i = 0,j=1; i < ssRow; i++)
            {
                artNo = grid.GetRowCellDisplayText(i, "LotNo");
                clothes = GetClothes(artNo);
                if (clothes == null)
                    continue;

                j = 0;//Lot#
                sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue( clothes.ShellNo );

                j++;//Art#
                sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue( artNo );

                j++;//Color
                sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue( clothes.Color );

                for (j = 3; j < ssCol - 3; j++)
                {
                    obj = grid.GetRowCellValue(i, grid.Columns[j]);

                    if(obj != null && string.IsNullOrEmpty( obj.ToString() ) == false )
                        sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue(Convert.ToInt32( obj ));
                }

                obj = grid.GetRowCellValue(i, grid.Columns[j]);
                if (obj != null && string.IsNullOrEmpty(obj.ToString() ) == false)
                    sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue(Convert.ToDouble( obj ) ) ;

                j++;
                obj = grid.GetRowCellValue(i, grid.Columns[j]);
                if (obj != null && string.IsNullOrEmpty(obj.ToString() ) == false)
                    sheet.GetRow(begRow + i).GetCell(begCol + j).SetCellValue(Convert.ToDouble( obj ));
            }

            int idxShipping = GetShippingRowNo(grid.RowCount);
            //导出 Shipping
            if( string.IsNullOrEmpty( outbound.Freight) == false )
                sheet.GetRow(idxShipping).GetCell(39).SetCellValue(Convert.ToDouble(outbound.Freight));
        }

        private static  OutBound GetOutBound(string id)
        {
            OutBound bound = new OutBound();
            string sql = String.Format("Select OrderNo, ShipDate, Sales,CustomerNo, Operator, ShipTo, SellTo, Address,Shippingway, Term, Freight, InvoiceStatus, Status, "
                                    + " CreateTime, ConfirmTime From T_Outbound  where OutboundID = '{0}' ", id);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return bound;
            DataRow dr = dt.Rows[0];
            int col = 0;
            bound.OutboundID = id;
            bound.OrderNo = dr[col++].ToString();
            bound.ShipDate = dr[col++].ToString();
            bound.Sales = dr[col++].ToString();
            bound.CustomerNo = dr[col++].ToString();
            bound.Operator = dr[col++].ToString();
            bound.ShipTo = dr[col++].ToString();
            bound.SellTo = dr[col++].ToString();
            bound.Address = dr[col++].ToString();
            bound.Shippingway = dr[col++].ToString();
            bound.Term = dr[col++].ToString();
            bound.Freight = dr[col++].ToString();
            bound.InvoiceStatus = dr[col++].ToString();
            bound.Status = dr[col++].ToString();
            bound.CreateTime = dr[col++].ToString();
            bound.ConfirmTime = dr[col++].ToString();
            return bound;
        }

        private  static string GetEinglishDate(string cnDate)
        {
            string enDate = "";
            DateTime dt = DateTime.Now;
            bool bres = DateTime.TryParse(cnDate, out dt);
            if( bres == true)
                enDate = dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            return enDate;
        }

        private static Clothes GetClothes(string artNo)
        {
            if (MemoryTable.Instance.ListClothes == null)
                MemoryTable.Instance.LoadClothes();
            List<Clothes> list = MemoryTable.Instance.ListClothes;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].LotNo == artNo)
                    return list[i];
            }

            return null;
        }

        private static string GetTempletFile(int count)
        {
            
            if (count < 18)  return  "InvoiceTemplet.xls";

            for (int i = 20; i < 1000; i += 10)
            { 
                if( count <= i && count > i-10 )
                   return string.Format("InvoiceTemplet{0}.xls",i);
            }

            return "InvoiceTemplet.xls";
        }

        private static int GetShippingRowNo(int count)
        {
            if (count < 18) return 33;

            for (int i = 20; i < 1000; i += 10)
            {
                if (count <= i && count > i - 10)
                    return 16 + i;
            }

            return 33;
        }
    }
}

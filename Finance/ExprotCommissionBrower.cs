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
    public class ExportCommissionBrower
    {
        public string BeginDate;
        public string EndDate;

        public void Export(GridView detailView, string exportFile)
        {
            string templetFile = Application.StartupPath + "\\templet\\CommissionTemplet.xls";
            // string exportFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";

            FileStream file = new FileStream(templetFile, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");

            //导出数据

            GetData(sheet, detailView);

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

        public void GetData(ISheet sheet, GridView grid)
        {
            //统计开始日期
            sheet.GetRow(1).GetCell(1).SetCellValue(BeginDate);

            //统计结束日期
            sheet.GetRow(2).GetCell(1).SetCellValue(EndDate);
             
            int begRow = 5, col = 0;
             

            IRow eRow = null;
            ICell eCell = null;
            ICellStyle valStyle = GetValueCellStyle(sheet.Workbook);
            ICellStyle fStyle = GetValueCellStyle(sheet.Workbook);
            fStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            string temp = string.Empty;
            Object obj = null;
            int i = 0;

            for ( i = 0; i < grid.RowCount; i++)
            {
                col = 0;
                eRow = sheet.CreateRow(begRow + i);
                eRow.HeightInPoints = 19.5f;

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("Sales")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("SellTo")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("OrderNo")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("ShipDate")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("DueDate")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                temp = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("TrackingNo")).ToString();
                eRow.CreateCell(col++).SetCellValue(temp);

                //Quantity
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("Quantity") );
                if(obj == null || obj.ToString().Length>0 )
                    eRow.CreateCell(col++).SetCellValue(Convert.ToInt32(obj));

                //InvoiceAmount
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("InvoiceAmount"));
                if (obj == null || obj.ToString().Length > 0)
                {
                    eCell = eRow.CreateCell(col++);
                    eCell.SetCellValue(Convert.ToDouble(obj));
                    eCell.CellStyle = fStyle;
                }
                //Freight
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("Freight"));
                if (obj == null || obj.ToString().Length > 0)
                {
                    eCell = eRow.CreateCell(col++);
                    eCell.SetCellValue(Convert.ToDouble(obj));
                    eCell.CellStyle = fStyle;
                }
                //Commission Amt
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("PriceAmount"));
                if (obj == null || obj.ToString().Length > 0)
                {
                    eCell = eRow.CreateCell(col++);
                    eCell.SetCellValue(Convert.ToDouble(obj));
                    eCell.CellStyle = fStyle;
                }
                // %
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("CommPercent"));
                if (obj == null || obj.ToString().Length > 0)
                {
                    eCell = eRow.CreateCell(col++);
                    eCell.SetCellValue(Convert.ToDouble(obj));
                    eCell.CellStyle = fStyle;
                }
                // Commission
                obj = grid.GetRowCellValue(i, grid.Columns.ColumnByFieldName("CommissionAmount"));
                if (obj == null || obj.ToString().Length > 0)
                {
                    eCell = eRow.CreateCell(col++);
                    eCell.SetCellValue(Convert.ToDouble(obj));
                    eCell.CellStyle = fStyle;
                }

                for (int cc = 0; cc < 7; cc++)
                {
                    eCell = eRow.GetCell(cc) ;
                    if (eCell == null)
                        eCell = eRow.CreateCell(cc);
                    eCell.CellStyle = valStyle;
                }
            }
             

            eRow = sheet.CreateRow(begRow + i);
            eRow.HeightInPoints = 30f;

            eCell = eRow.CreateCell(10);
            eCell.SetCellValue("合计");
            eCell.CellStyle = valStyle;
              
            //Commisssion Amount 
            eCell = eRow.CreateCell(11);
            eCell.SetCellFormula(string.Format("SUM(IL{0}:L{1})", begRow + 1, begRow + i));
            eCell.CellStyle = fStyle ;
        }
       
        protected ICellStyle GetValueCellStyle(IWorkbook hWorkBook)
        {
            IFont font = hWorkBook.CreateFont();
            font.FontName = "Tahoma";
            font.FontHeightInPoints = 9;

            ICellStyle style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.SetFont(font);

            return style;
        }
    }
}

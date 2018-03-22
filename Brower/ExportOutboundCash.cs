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
    public class ExportOutboundCash
    {
        public GridView gridView;
        private ISheet sheet = null;
        private IWorkbook workbook = null;

        #region 构造函数

        public ExportOutboundCash()
        {
            workbook = new HSSFWorkbook();
        }

        public ExportOutboundCash(GridView view)
        {
            workbook = new HSSFWorkbook();
            gridView = view;
        }

        #endregion

        public void Export(string FilePath)
        {

            sheet = workbook.CreateSheet("Sheet1");
            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            /////
            // 列宽
            for (int i = 0; i < 4; i++)
                sheet.SetColumnWidth(i, 15 * 256);
            for (int i = 5; i < 12; i++)
                sheet.SetColumnWidth(i, 12 * 256);
            sheet.SetColumnWidth(4, 25 * 256);
            sheet.SetColumnWidth(12, 15 * 256);
            sheet.SetColumnWidth(13, 25 * 256);
            /////

            AddTableHeader();
            int cnt = gridView.RowCount;
            int beg = 1;
            IRow row = null;
            ICell cell = null;
            ICellStyle cellStyle = GetValueCellStyle(sheet.Workbook);
            ICellStyle cellStyle2 = GetValueCellStyle(sheet.Workbook);
            cellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            for (int i = 0, col = 0; i < cnt; i++)
            {
                col = 0;
                row = sheet.CreateRow(beg + i);
                row.HeightInPoints = (float)19.5;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "Sales").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "ShipDate").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "DueDate").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "OrderNo").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "Receiver").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "Quantity").ToString() != "")
                    cell.SetCellValue(Convert.ToInt32(gridView.GetRowCellValue(i, "Quantity")));
                cell.CellStyle = cellStyle2;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "InvoiceAmount").ToString() != "")
                    cell.SetCellValue(Convert.ToDouble(gridView.GetRowCellValue(i, "InvoiceAmount")));
                cell.CellStyle = cellStyle2;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "PriceAmount").ToString() != "")
                    cell.SetCellValue(Convert.ToDouble(gridView.GetRowCellValue(i, "PriceAmount")));
                cell.CellStyle = cellStyle2;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "Comm").ToString() != "")
                    cell.SetCellValue(Convert.ToDouble(gridView.GetRowCellValue(i, "Comm")));
                cell.CellStyle = cellStyle2;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "RcvdAmount").ToString() != "")
                    cell.SetCellValue(Convert.ToDouble(gridView.GetRowCellValue(i, "RcvdAmount")));
                cell.CellStyle = cellStyle2;


                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "RcvdDate").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                if (gridView.GetRowCellValue(i, "Balance").ToString() != "")
                    cell.SetCellValue(Convert.ToDouble(gridView.GetRowCellValue(i, "Balance")));
                cell.CellStyle = cellStyle2;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "PayOff").ToString().ToUpper());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "CommPaid").ToString().ToUpper() );
                cell.CellStyle = cellStyle;


                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "PaymentMode").ToString());
                cell.CellStyle = cellStyle;
            }

            ////
            //保存文件
            sheet.ForceFormulaRecalculation = true;
            sheet.FitToPage = false;
            sheet.PrintSetup.PaperSize = (short)NPOI.SS.UserModel.PaperSize.A4;
            sheet.PrintSetup.Landscape = true;//(横向)

            workbook.Write(file);
            file.Close();
            file.Dispose();
            GC.Collect();
        }

        private void AddTableHeader()
        {
            IFont font = null;
            ICellStyle cStyle = null;
            IRow eRow = null;
            ICell eCell = null;
            IDataFormat format = workbook.CreateDataFormat();

            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.SetFont(font);

            eRow = sheet.CreateRow(0);
            int col = 0;
            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Sales");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Ship Date");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Due Date");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("P.O#");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Receiver");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("qty");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Inv Amt");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Comm Amt");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Comm");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Rcvd Amt");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Rcvd Date");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Balance");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Pay Off");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Comm Paid");
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(col++);
            eCell.SetCellValue("Payment Mode");
            eCell.CellStyle = cStyle;
        }

        static ICellStyle GetValueCellStyle(IWorkbook hWorkBook)
        {
            IFont font = hWorkBook.CreateFont();
            font.FontName = "Tahoma";
            font.FontHeightInPoints = 9;

            ICellStyle style9Value = hWorkBook.CreateCellStyle();
            style9Value.VerticalAlignment = VerticalAlignment.Center;
            style9Value.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style9Value.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style9Value.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style9Value.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style9Value.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style9Value.SetFont(font);

            return style9Value;
        }
    }
}

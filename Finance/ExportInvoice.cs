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
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;

namespace PengLang
{
    public class ExportInvoice : ExportToExcel
    {
       static public void ExportInvioceTotal(GridView detailView, string customerNo,string strDate, string fileName)
        {
            string[,] ss = GetGridCell(detailView);
            Customer customer = GetCustomer(customerNo);

            HSSFWorkbook hWorkBook = new HSSFWorkbook();
            ISheet sheet1 = hWorkBook.CreateSheet("Sheet1");
            ISheet sheet2 = hWorkBook.CreateSheet("Sheet2");
            ISheet sheet3 = hWorkBook.CreateSheet("Sheet3");
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            IFont font;
            ICellStyle style;
            IRow roww;
            ICell celll;
            IDataFormat format = hWorkBook.CreateDataFormat();

            /// P&L Import Corp
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));
            font = hWorkBook.CreateFont();            /// font
            font.FontName = "Arial";
            font.FontHeightInPoints = 22;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;            /// style
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style.SetFont(font);
            roww = sheet1.CreateRow(0);            /// row1
            celll = roww.CreateCell(0);
            celll.SetCellValue("P&L Import Corp");
            celll.CellStyle = style;


            /// 218 South 5th Ave., La Puente, CA 91746
            sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 0, 5));
            font = hWorkBook.CreateFont();          /// font
            font.FontName = "Arial";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style.SetFont(font);
            /// row2
            roww = sheet1.CreateRow(1);
            celll = roww.CreateCell(0);
            celll.SetCellValue(AppConfig.CompanyInfo.Address);
            celll.CellStyle = style;


            /// CUSTOMER STATMENT
            sheet1.AddMergedRegion(new CellRangeAddress(1, 2, 6, 10));
            /// font
            font = hWorkBook.CreateFont();
            font.FontName = "Arial";
            font.FontHeightInPoints = 18;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Top;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            style.SetFont(font);
            celll = roww.CreateCell(6);
            celll.SetCellValue("CUSTOMER STATMENT");
            celll.CellStyle = style;


            /// Bill To
            sheet1.AddMergedRegion(new CellRangeAddress(3, 3, 0, 1));
            font = hWorkBook.CreateFont();          ///font
            font.FontName = "Arial";
            font.FontHeightInPoints = 10;
            font.Color = HSSFColor.White.Index;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            style = hWorkBook.CreateCellStyle();            ///style
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.SetFont(font);
            style.FillForegroundColor = HSSFColor.Black.Index;
            style.FillPattern = FillPattern.SolidForeground;
            /// row 4
            roww = sheet1.CreateRow(3);
            celll = roww.CreateCell(0);
            celll.SetCellValue("BILL TO");
            celll.CellStyle = style;

            /// Adress
            sheet1.AddMergedRegion(new CellRangeAddress(4, 6, 2, 3));
            ///font
            font = hWorkBook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "Arial";
            ///style
            /// 
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Top;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style.SetFont(font);
            style.WrapText = true;
            /// row 5
            roww = sheet1.CreateRow(4);
            celll = roww.CreateCell(2);
            celll.SetCellValue(customer.Company);         ////发票地址
            celll.CellStyle = style;


            style = hWorkBook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            //Statement Period
            sheet1.AddMergedRegion(new CellRangeAddress(4, 4, 7, 8));
            celll = roww.CreateCell(7);
            celll.SetCellValue("Statement Period ");
            celll.CellStyle = style;


            style = hWorkBook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            //Date
            sheet1.AddMergedRegion(new CellRangeAddress(4, 4, 9, 10));
            celll = roww.CreateCell(9);
            celll.SetCellValue(GetEngilistDate( strDate ));
            celll.CellStyle = style;


            style = hWorkBook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            //Invoice Count
            sheet1.AddMergedRegion(new CellRangeAddress(5, 5, 7, 8));
            /// row 6
            roww = sheet1.CreateRow(5);
            celll = roww.CreateCell(7);
            celll.SetCellValue("Invoice Count ");
            celll.CellStyle = style;


            style = hWorkBook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            //Invoice Count
            sheet1.AddMergedRegion(new CellRangeAddress(5, 5, 9, 10));
            celll = roww.CreateCell(9);
            celll.SetCellValue(detailView.RowCount - 1);
            celll.CellStyle = style;

            /// Title
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 0, 0));
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 1, 1));
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 2, 2));
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 3, 3));
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 4, 4));
            sheet1.AddMergedRegion(new CellRangeAddress(9, 10, 5, 5));
            /// font
            font = hWorkBook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "Arial";
            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Bottom;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.SetFont(font);
            style.WrapText = true;


            roww = sheet1.CreateRow(9);
            celll = roww.CreateCell(1);/// Date
            celll.SetCellValue("Date");
            celll.CellStyle = style;
            celll = roww.CreateCell(2);/// Order#
            celll.SetCellValue("Order#");
            celll.CellStyle = style;
            celll = roww.CreateCell(3);/// Qty
            celll.SetCellValue("Qty");
            celll.CellStyle = style;
            celll = roww.CreateCell(4);/// Invoice Amount
            celll.SetCellValue("Invoice Amount");
            celll.CellStyle = style;
            celll = roww.CreateCell(5);/// Amount Due
            celll.SetCellValue("Amount Due");
            celll.CellStyle = style;


            roww = sheet1.CreateRow(10);
            for (int i = 0; i < 6; i++)
            {
                celll = roww.CreateCell(i);
                celll.CellStyle = style;
            }

            /// font
            font = hWorkBook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "Arial";
            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.SetFont(font);

            ICellStyle styledot = hWorkBook.CreateCellStyle();
            styledot.VerticalAlignment = VerticalAlignment.Center;
            styledot.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            styledot.DataFormat = format.GetFormat("#,###,##0.00");
            styledot.SetFont(font);

            int totalQTY = 0, bottomRow = detailView.RowCount + 12;
            double totalTotal = 0;
            int qnt = 0;
            for (int exr = 11, r = 0; r < detailView.RowCount - 1; exr++, r++)
            {
                IRow rrow = sheet1.CreateRow(exr);
                ICell cell = rrow.CreateCell(0);
                cell.SetCellValue(r + 1);
                cell.CellStyle = style;
                for (int exc = 1, c = 0; c < 5; exc++, c++)
                {
                    cell = rrow.CreateCell(exc);
                    if ( c == 2 )
                    {
                        if (String.IsNullOrEmpty(ss[r, c]) == false)
                            cell.SetCellValue( Convert.ToInt32( ss[r, c]) ); 
                        cell.CellStyle = styledot;
                    }
                    else if ( c == 3 || c == 4)
                    {
                        if (String.IsNullOrEmpty(ss[r, c]) == false)
                             cell.SetCellValue(Convert.ToDouble( ss[r, c]) );
                        
                        cell.CellStyle = styledot;
                    }
                    else
                    {
                        cell.SetCellValue(ss[r, c]);
                        cell.CellStyle = style;
                    }
                    if (c == 2)
                    {
                        qnt = Convert.ToInt32(ss[r, c]);
                        totalQTY += qnt;
                    }
                    else if (c == 4)
                    {
                        totalTotal += Convert.ToDouble(ss[r, c]);
                    }

                    
                }
                if (qnt < 0)
                {
                    cell = rrow.CreateCell(6);
                    cell.SetCellValue("(Return)");
                }
            }
            /// row n
            roww = sheet1.CreateRow(bottomRow);

            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.SetFont(font);
            celll = roww.CreateCell(0);
            celll.CellStyle = style;
            celll = roww.CreateCell(1);
            celll.CellStyle = style;
            celll = roww.CreateCell(2);
            celll.SetCellValue("TOTAL");
            celll.CellStyle = style;

            //总数量
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.DataFormat = format.GetFormat("#,###,##0.00");
            style.SetFont(font);
            celll = roww.CreateCell(3);
            celll.SetCellValue( totalQTY) ;

            //总金额 
            celll.CellStyle = style;
            celll = roww.CreateCell(4);
            celll.SetCellValue("$");
            celll.CellStyle = style;
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.DataFormat = format.GetFormat("#,###,##0.00");
            style.SetFont(font);
            celll = roww.CreateCell(5);
            celll.SetCellValue( totalTotal );
            celll.CellStyle = style;


            sheet1.AddMergedRegion(new CellRangeAddress(7, 7, 6, 8));
            sheet1.AddMergedRegion(new CellRangeAddress(7, 7, 9, 9));
            sheet1.AddMergedRegion(new CellRangeAddress(7, 7, 10, 10));
            /// font
            font = hWorkBook.CreateFont();
            font.FontName = "Arial";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            /// row 8
            roww = sheet1.CreateRow(7);
            IRow row8 = sheet1.CreateRow(8);
            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            style.SetFont(font);

            celll = roww.CreateCell(6);
            celll.SetCellValue("Total Statement Amount");
            celll.CellStyle = style;
            celll = roww.CreateCell(7);
            celll.CellStyle = style;
            celll = roww.CreateCell(8);
            celll.CellStyle = style;


            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.SetFont(font);

            celll = roww.CreateCell(9);
            celll.SetCellValue("$");
            celll.CellStyle = style;


            /// style
            style = hWorkBook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            style.SetFont(font);
            style.DataFormat = format.GetFormat("#,###,##0.00");

            celll = roww.CreateCell(10);
            celll.SetCellValue(totalTotal );
            celll.CellStyle = style;

            /// 列宽
            sheet1.SetColumnWidth(0, Convert.ToInt32(4 * 256));
            sheet1.SetColumnWidth(1, Convert.ToInt32(12 * 256));
            sheet1.SetColumnWidth(2, Convert.ToInt32(9 * 256));
            sheet1.SetColumnWidth(3, Convert.ToInt32(10 * 256));
            sheet1.SetColumnWidth(4, Convert.ToInt32(13 * 256));
            sheet1.SetColumnWidth(5, Convert.ToInt32(10 * 256));
            sheet1.SetColumnWidth(6, Convert.ToInt32(12 * 256));
            sheet1.SetColumnWidth(7, Convert.ToInt32(9 * 256));
            sheet1.SetColumnWidth(8, Convert.ToInt32(8.4 * 256));
            sheet1.SetColumnWidth(9, Convert.ToInt32(3.5 * 256));
            sheet1.SetColumnWidth(10, Convert.ToInt32(12.3 * 256));


            hWorkBook.Write(file);
            file.Close();
            file.Dispose();
            GC.Collect();

        }

       static private Customer GetCustomer(string no)
        {
            CustomerHelper helper = new CustomerHelper();
            Customer cus = helper.GetCustomer(no);
            if (cus == null)
                return new Customer();

            return cus;
        }

       static private string GetEngilistDate(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            date = dt.ToString("yyyy-MM-dd");

            string[] dateNeed = date.Split(new string[] { "-", "-" }, StringSplitOptions.RemoveEmptyEntries);
            string mounth = dateNeed[1];
            string year = dateNeed[0];
            switch (dateNeed[1])
            {
                case "1":
                case "01":
                    mounth = "JANUARY";
                    break;
                case "2":
                case "02":
                    mounth = "FEBRUARY";
                    break;
                case "3":
                case "03":
                    mounth = "MARCH";
                    break;
                case "4":
                case "04":
                    mounth = "APRIL";
                    break;
                case "5":
                case "05":
                    mounth = "MAY";
                    break;
                case "6":
                case "06":
                    mounth = "JUNE";
                    break;
                case "7":
                case "07":
                    mounth = "JULY";
                    break;
                case "8":
                case "08":
                    mounth = "AUGUST";
                    break;
                case "9":
                case "09":
                    mounth = "SEPTEMBER";
                    break;
                case "10":
                    mounth = "OCTOBER";
                    break;
                case "11":
                    mounth = "NOVEMBER";
                    break;
                case "12":
                    mounth = "DECEMBER";
                    break;
            }

            return mounth + " " + year;
        }

       static public void ExportInvoiceSelection(GridView detailView, string fileName)
       {
           string[,] ss = GetGridCell(detailView);



           HSSFWorkbook hWorkBook = new HSSFWorkbook();
           ISheet sheet1 = hWorkBook.CreateSheet("Sheet1");
           ISheet sheet2 = hWorkBook.CreateSheet("Sheet2");
           ISheet sheet3 = hWorkBook.CreateSheet("Sheet3");
           FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);

           IFont font = hWorkBook.CreateFont();
           font.FontName = "Tahoma";
           font.FontHeightInPoints = 9;

           ICellStyle style9Title = hWorkBook.CreateCellStyle();
           style9Title.VerticalAlignment = VerticalAlignment.Center;
           style9Title.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
           style9Title.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Title.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Title.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Title.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Title.FillForegroundColor = HSSFColor.Grey25Percent.Index;
           style9Title.FillPattern = FillPattern.SolidForeground;
           style9Title.SetFont(font);

           ICellStyle style9Value = hWorkBook.CreateCellStyle();
           style9Value.VerticalAlignment = VerticalAlignment.Center;
           style9Value.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
           style9Value.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Value.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Value.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Value.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
           style9Value.SetFont(font);

           IRow row1 = sheet1.CreateRow(0);

           row1.HeightInPoints = (float)16.2;

           ICell cell1_1 = row1.CreateCell(0);
           cell1_1.SetCellValue("Selection");
           cell1_1.CellStyle = style9Title;

           ICell cell1_2 = row1.CreateCell(1);
           cell1_2.SetCellValue("Date");
           cell1_2.CellStyle = style9Title;

           ICell cell1_3 = row1.CreateCell(2);
           cell1_3.SetCellValue("Order# / P.O#");
           cell1_3.CellStyle = style9Title;

           ICell cell1_4 = row1.CreateCell(3);
           cell1_4.SetCellValue("Customer#");
           cell1_4.CellStyle = style9Title;

           ICell cell1_5 = row1.CreateCell(4);
           cell1_5.SetCellValue("Quantity");
           cell1_5.CellStyle = style9Title;

           ICell cell1_6 = row1.CreateCell(5);
           cell1_6.SetCellValue("Invoice Amount");
           cell1_6.CellStyle = style9Title;

           ICell cell1_7 = row1.CreateCell(6);
           cell1_7.SetCellValue("Amount Due");
           cell1_7.CellStyle = style9Title;

           ICell cell1_8 = row1.CreateCell(7);
           cell1_8.SetCellValue("Payment Date");
           cell1_8.CellStyle = style9Title;

           ICell cell1_9 = row1.CreateCell(8);
           cell1_9.SetCellValue("Catogery");
           cell1_9.CellStyle = style9Title;


           for (int exr = 1, r = 0; r < detailView.RowCount; exr++, r++)
           {
               IRow rrow = sheet1.CreateRow(exr);
               rrow.HeightInPoints = (float)19.8;

               for (int exc = 0, c = 0; c < detailView.Columns.Count-1 ; exc++, c++)
               {
                   ICell cell = rrow.CreateCell(exc);
                   if (exc != 0)
                   {
                       if (exc == 4 && String.IsNullOrEmpty(ss[r, c]) == false)
                           cell.SetCellValue(Convert.ToInt32(ss[r, c]));
                       else if ( (exc == 5 || exc ==6) &&  String.IsNullOrEmpty(ss[r, c]) == false )
                           cell.SetCellValue(Convert.ToDouble(ss[r, c]));
                       else 
                            cell.SetCellValue( ss[r, c] );
                   }
                   cell.CellStyle = style9Value;
               }
           }

           sheet1.SetColumnWidth(0, Convert.ToInt32(10 * 256));
           sheet1.SetColumnWidth(1, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(2, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(3, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(4, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(5, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(6, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(7, Convert.ToInt32(16 * 256));
           sheet1.SetColumnWidth(8, Convert.ToInt32(16 * 256));
           hWorkBook.Write(file);
           file.Close();
           file.Dispose();
           GC.Collect();
           
       }
         
    }
}

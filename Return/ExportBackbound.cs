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
   public class ExportBackbound : ExportToExcel
   {
       #region 导出操作记录

       static public void ExportRecord(GridView gridView, string fileName)
        {
            string[,] ss = GetGridCell(gridView);

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
            //IRow row2 = sheet1.CreateRow(1);
            
            row1.HeightInPoints = (float)16.2;
            //row2.HeightInPoints = (float)16.2;


            ICell cell1_1 = row1.CreateCell(0);
            cell1_1.SetCellValue("选择");
            cell1_1.CellStyle = style9Title;

            ICell cell1_2 = row1.CreateCell(1);
            cell1_2.SetCellValue("货架号");
            cell1_2.CellStyle = style9Title;

            ICell cell1_3 = row1.CreateCell(2);
            cell1_3.SetCellValue("Lot#");
            cell1_3.CellStyle = style9Title;

            ICell cell1_4 = row1.CreateCell(3);
            cell1_4.SetCellValue("尺寸");
            cell1_4.CellStyle = style9Title;

            ICell cell1_5 = row1.CreateCell(4);
            cell1_5.SetCellValue("数量");
            cell1_5.CellStyle = style9Title;

            ICell cell1_6 = row1.CreateCell(5);
            cell1_6.SetCellValue("完成时间");
            cell1_6.CellStyle = style9Title;

            ICell cell1_7 = row1.CreateCell(6);
            cell1_7.SetCellValue("完成状态");
            cell1_7.CellStyle = style9Title;

            ICell cell1_8 = row1.CreateCell(7);
            cell1_8.SetCellValue("备注");
            cell1_8.CellStyle = style9Title;

            for (int exr = 1, r = 0; r < gridView.RowCount; exr++, r++)
            {
                IRow rrow = sheet1.CreateRow(exr);
                rrow.HeightInPoints = (float)19.8;

                for (int exc = 0, c = 2; c <= gridView.Columns.Count - 1; exc++, c++)
                {
                    ICell cell = rrow.CreateCell(exc);
                    if (exc != 0)
                        cell.SetCellValue(ss[r, c]);
                    cell.CellStyle = style9Value;
                }
            }

            sheet1.SetColumnWidth(0, Convert.ToInt32(4.4 * 256));
            sheet1.SetColumnWidth(1, Convert.ToInt32(16.8 * 256));
            sheet1.SetColumnWidth(2, Convert.ToInt32(16.8 * 256));
            sheet1.SetColumnWidth(3, Convert.ToInt32(7.4 * 256));
            sheet1.SetColumnWidth(4, Convert.ToInt32(7.4 * 256));
            sheet1.SetColumnWidth(5, Convert.ToInt32(20 * 256));
            sheet1.SetColumnWidth(6, Convert.ToInt32(13.4 * 256));
            sheet1.SetColumnWidth(7, Convert.ToInt32(13.4 * 256));

            hWorkBook.Write(file);
            file.Close();
            file.Dispose();
            GC.Collect();
           
        }

       #endregion


       static public void ExportDetail(GridView detailView, string boundID, string fileName)
        {
            string templetFile = Application.StartupPath + "\\templet\\ReturnTemplet.xls";
            // string exportFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";

            FileStream file = new FileStream(templetFile, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");

            BackBound bound = GetBackBound(boundID);
            
            #region 导出退货单属性

            sheet.GetRow(1).GetCell(34).SetCellValue(bound.OrderDate);
            sheet.GetRow(2).GetCell(34).SetCellValue(bound.PONo);
            sheet.GetRow(3).GetCell(34).SetCellValue(bound.Sales);

            #endregion

            //导出数据

            GetData(sheet, detailView);

            //保存文件
            sheet.ForceFormulaRecalculation = true;
            using (FileStream filess = File.OpenWrite(fileName))
            {
                hssfworkbook.Write(filess);
                filess.Close();
                filess.Dispose();
            }

            //file.Close();
            //file.Dispose();

            GC.Collect();
        
        }
 
       static public void GetData(ISheet sheet, GridView grid)
       {
            string[,] ss = GetGridCell(grid);

            int ssRow = ss.GetLength(0);
            int ssCol = ss.GetLength(1)-1;

            int begRow = 13, begCol = 0;
                      
            IRow eRow = null;
            ICell eCell = null; 
            
            for (int i = 0, j = 0; i < ssRow; i++)
            {
                eRow = sheet.GetRow(begRow + i);
                j = 0; //Art#
                eCell = eRow.GetCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Style #
                eCell = eRow.GetCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Color
                eCell = eRow.GetCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                for (j = 3; j < ssCol-2; j++)
                {
                    if (string.IsNullOrEmpty(ss[i, j]) == false)
                        eRow.GetCell(begCol + j).SetCellValue(Convert.ToInt32(ss[i, j]));

                }

                if (string.IsNullOrEmpty(ss[i, j]) == false)
                    eRow.GetCell(begCol + j).SetCellValue(Convert.ToDouble(ss[i, j]));

                j++;
                if (string.IsNullOrEmpty(ss[i, j]) == false)
                    eRow.GetCell(begCol + j).SetCellValue(Convert.ToDouble(ss[i, j]));
            }
            
        }
         
       static protected new string[,] GetGridCell(GridView gridView)
        {
            int r = gridView.RowCount;
            int c = gridView.Columns.Count;
            string[,] ss = new string[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 1, k = 0; j < c; j++, k++)
                {
                    ss[i, k] = gridView.GetRowCellDisplayText(i, gridView.Columns[j]);
                }
            return ss;
        }
  
       static private BackBound GetBackBound(string id)
        {
            BackBound bound = new BackBound();
            string sql = String.Format("Select PONo, BackDate, Customer, status  From T_Backbound "
                                      + " where BackboundID = '{0}' ", id);

            DataTable dt = Database.Select(sql);
            if (dt == null || dt.Rows.Count == 0)
                return bound;
            DataRow dr = dt.Rows[0];
            int col = 0;
            bound.BackboundID = id;
            bound.PONo = dr[col++].ToString();
            bound.OrderDate = dr[col++].ToString();
            bound.Customer = dr[col++].ToString(); 
            bound.Status = dr[col++].ToString();

            return bound;
        }


    }
}

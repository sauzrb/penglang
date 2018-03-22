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
    public class ExportGridView : ExportToExcel
    {
        #region 导出库存、出入库明细表

        static public void ExportDetail(GridView detailView,  string exportFile )
        {
            string templetFile = Application.StartupPath + "\\templet\\InventoryTemplet.xls";
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

        static public void GetData(ISheet sheet,  GridView grid)
        { 
            int begRow = 2, begCol = 0; 
            string[,] ss = GetGridCell(grid);
            int ssRow = ss.GetLength(0) ;
            int ssCol = ss.GetLength(1) ;
             
            ICellStyle cellStyle =  GetValueCellStyle(sheet.Workbook);

            IRow eRow = null;
            ICell eCell = null;
            for (int i = 0, j=0 ; i < ssRow; i++)
            {
                eRow = sheet.CreateRow(begRow + i); 
                j = 0; //Art#
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Style #
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Color
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                for (j = 3; j < ssCol ; j++ )
                { 
                    if( string.IsNullOrEmpty(ss[i,j]) == false )
                        eRow.CreateCell(begCol + j).SetCellValue(Convert.ToInt32(ss[i, j]));

                }

            }


            for (int i = 2, j = 0, cnt = ssRow + 2; i < cnt; i++)
            {
                eRow = sheet.GetRow(i);
                if (eRow == null)
                    continue;
                eRow.HeightInPoints = (float)19.5;
                
                for (j = 0; j < ssCol; j++)
                {
                    eCell = eRow.GetCell(j);
                    if (eCell == null)
                        eCell = eRow.CreateCell(j);
                    eCell.CellStyle = cellStyle;
                }
            }
        }

        static private string GetEinglishDate(string cnDate)
        {
            string enDate = "";
            DateTime dt = DateTime.Now;
            bool bres = DateTime.TryParse(cnDate, out dt);
            if (bres == true)
                enDate = dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            return enDate;
        }

        static protected new string[,] GetGridCell(GridView gridView)
        {
            int cntRow = gridView.RowCount;
            int cntCol = gridView.Columns.Count;
              
            string[,] ss = new string[cntRow, cntCol - 2 ];

            int row = 0, col = 0, k = 0;
            for (row = 0,col=0; row < cntRow; row++)
            {
                for (col = 2, k = 0; col < cntCol; col++, k++)
                {
                    ss[row, k] = gridView.GetRowCellDisplayText(row, gridView.Columns[col] );
                }
            }
            return ss;
        }

        #endregion

        #region 导出操作单

        static public void ExportRecord(string orderNo, GridView gridView, string fileName)
        {
            string templetFile = Application.StartupPath + "\\templet\\RecordTemplet.xls";
            // string exportFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";

            FileStream file = new FileStream(templetFile, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
            ICellStyle cellStyle = GetValueCellStyle(sheet.Workbook);

            IRow row = null;
            ICell cell = null;

            row = sheet.GetRow(1);
            cell = row.CreateCell(1);
            cell.SetCellValue( orderNo );
            cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;

            int cnt = gridView.RowCount;
            int beg = 3;
            for(int i=0 ,col = 0;i<cnt;i++)
            {
                col = 0;
                row = sheet.CreateRow( beg+i);
                row.HeightInPoints = (float)19.5;
                cell = row.CreateCell(col++);
                cell.SetCellValue( gridView.GetRowCellValue(i, "ShelfNo").ToString() );
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "LotNo").ToString());
                cell.CellStyle = cellStyle;
                 
                cell = row.CreateCell(col++);
                cell.SetCellValue(gridView.GetRowCellValue(i, "SizeNo").ToString());
                cell.CellStyle = cellStyle;

                cell = row.CreateCell(col++);
                cell.SetCellValue( Convert.ToInt32( gridView.GetRowCellValue(i, "NumOfPlan") ) );
                cell.CellStyle = GetValueCellStyle(sheet.Workbook); 
                cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            }

            //Commisssion Amount 
            row = sheet.CreateRow( beg + cnt );
            row.HeightInPoints = (float)19.5;

            cell = row.CreateCell(2);
            cell.SetCellValue("Total：");
            cell.CellStyle = GetValueCellStyle(sheet.Workbook);
            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;

            cell = row.CreateCell(3);
            cell.SetCellFormula(string.Format("SUM(D{0}:D{1})", beg, beg + cnt));
            cell.CellStyle = GetValueCellStyle(sheet.Workbook);
            cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;

            //保存文件
            sheet.ForceFormulaRecalculation = true;
            using (FileStream filess = File.OpenWrite( fileName ))
            {
                hssfworkbook.Write(filess);
                filess.Close();
                filess.Dispose();
            }

            //file.Close();
            //file.Dispose();

            GC.Collect();

        }

        #endregion
    }
}

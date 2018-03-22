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
    public class ExportInventoryBrowerView : ExportToExcel
    {
        #region 导出库存、出入库明细表

        static public void Export(GridView detailView,  string exportFile )
        {
            string templetFile = Application.StartupPath + "\\templet\\InventoryBrowerTemplet.xls";
           // string exportFile = AppConfig.GetTempDirectory() + Database.GetGlobalKey() + ".xls";

            FileStream file = new FileStream(templetFile, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
           
            //导出数据
            LoadClothesStyle();
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
                j = 0; //Style#
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Lot #
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Art#
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                j++; //Color
                eCell = eRow.CreateCell(begCol + j);
                eCell.SetCellValue(ss[i, j ]);

                for (j = 4; j < ssCol-1 ; j++ )
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

            MergeCell(ss, 0, sheet);
             
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
              
            string[,] ss = new string[cntRow, cntCol - 1 ];

            int row = 0, col = 0, k = 0;
            for (row = 0,col=0; row < cntRow; row++)
            {
                for (col = 1, k = 0; col < cntCol; col++, k++)
                {
                    ss[row, k] = gridView.GetRowCellDisplayText(row, gridView.Columns[col] );
                }
            }
            return ss;
        }

        static protected void MergeCell(string[,] data, int col,ISheet sheet)
        { 
            int cnt = data.GetLength(0);
            CellRangeAddress cellAddr = null;
            string val1 = "1", val2 = "2";
            double val3 = 0.0;

            int colPrice = 39;

            int i = 0,j = i+1;
            while( i < cnt )
            {
               
               val1 = data[i, col];

               if (i == cnt - 1)
               {
                    sheet.GetRow(i+2).GetCell(col).SetCellValue(GetStyleRemark(val1));
                    break;
                }

                double.TryParse( data[i, colPrice],out val3);
                
                for (j = i + 1; j < cnt; j++ )
                {
                    val2 = data[j, col];

                    if (val1 == val2)
                    {
                        if(j < cnt-1) 
                            continue;
                        cellAddr = new CellRangeAddress(i + 2, j + 2 , col, col);
                        sheet.AddMergedRegion(cellAddr);
                        sheet.GetRow(i + 2).GetCell(col).SetCellValue( GetStyleRemark(val1) );
                        sheet.GetRow(i + 2).GetCell(col).CellStyle.WrapText = true;

                        cellAddr = new CellRangeAddress(i + 2, j + 2, colPrice, colPrice);
                        sheet.AddMergedRegion(cellAddr);
                        sheet.GetRow(i + 2).GetCell(colPrice).SetCellValue( val3 );

                        return;
                    }

                    if (j == i + 1)
                    {
                        i = j; 
                        sheet.GetRow(i+1).GetCell(colPrice).SetCellValue(val3);
                        sheet.GetRow(i+1).GetCell(col).SetCellValue(GetStyleRemark(val1));
                        break;
                    }

                    cellAddr = new CellRangeAddress(i+2, j+2-1, col, col);
                    sheet.AddMergedRegion(cellAddr);
                    sheet.GetRow(i + 2).GetCell(col).SetCellValue(GetStyleRemark(val1));
                    sheet.GetRow(i + 2).GetCell(col).CellStyle.WrapText = true;

                    cellAddr = new CellRangeAddress(i + 2, j + 2-1, colPrice, colPrice);
                    sheet.AddMergedRegion(cellAddr);
                    sheet.GetRow(i + 2).GetCell(colPrice).SetCellValue(val3);


                    i = j ;
                    break;
                }
                

            }

        }

        static private string GetStyleRemark(string styleNo)
        { 
            if (ListStyle == null || ListStyle.Count == 0)
                return  styleNo;

            for (int i = 0; i < ListStyle.Count; i++)
            {
                if (ListStyle[i].Key == styleNo)
                    return ListStyle[i].Caption;
            }
            return styleNo;
        }

        static private void LoadClothesStyle()
        {
            string sql = "Select distinct StyleNo, StyleRemark from t_clothes Order By StyleNo ";

            DataTable dt = Database.Select(sql); 
            ListStyle.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStyle.Add(new ItemTag(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
            }
 
        }

        static private List<ItemTag> ListStyle = new List<ItemTag>();

        #endregion

         
    }
}

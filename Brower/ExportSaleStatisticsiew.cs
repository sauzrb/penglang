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
    public class ExportSaleStatisticsiew 
    {
        #region 导出库存、出入库明细表

        public string ArtNo = string.Empty;
        public string BeginDate = string.Empty;
        public string EndDate = string.Empty;

        public void Export(GridView detailView,  string exportFile )
        {
            string templetFile = Application.StartupPath + "\\templet\\SaleBrowerTemplet.xls";
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

        public void GetData(ISheet sheet,  GridView grid)
        { 
            int begRow = 5, begCol = 0; 
            string[,] ss = GetGridCell(grid);
            int ssRow = ss.GetLength(0) ;
            int ssCol = ss.GetLength(1) ;
             
            ICellStyle cellStyle =  GetValueCellStyle(sheet.Workbook);

            IRow eRow = null;
            ICell eCell = null;

            eRow = sheet.GetRow(1);
            eCell = eRow.GetCell(1);
            eCell.SetCellValue(ArtNo);

            for (int i = 0, j=0 ; i < ssRow; i++)
            {
                eRow = sheet.GetRow(begRow + i); 

                j = 0; //Category
                eCell = eRow.GetCell(begCol + j);
                eCell.SetCellValue(ss[i, j]);

                eCell.SetCellValue(ss[i, j]);

                for (j = 1 ; j < ssCol ; j++ )
                { 
                    if( string.IsNullOrEmpty(ss[i,j]) == false && ss[i,j].IndexOf('%') == -1 )
                        eRow.GetCell(begCol + j).SetCellValue(Convert.ToInt32(ss[i, j]));
                    else
                        eRow.GetCell(begCol + j).SetCellValue(ss[i, j]);
                }

            }


        }

        private string GetEinglishDate(string cnDate)
        {
            string enDate = "";
            DateTime dt = DateTime.Now;
            bool bres = DateTime.TryParse(cnDate, out dt);
            if (bres == true)
                enDate = dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            return enDate;
        }

        protected string[,] GetGridCell(GridView gridView)
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
        
        protected ICellStyle GetValueCellStyle(IWorkbook hWorkBook)
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
        
        #endregion
         
    }
}

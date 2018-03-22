using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
    public class ExportOutboundPacking
    {
        #region 数据成员

        public GridView gridView;
        public int CartonSize = 10;

        public string PoNo = string.Empty;
        public string Date = DateTime.Now.ToShortDateString();
        public int CartonNo = 1;
        public int CartonCount = 1;

        private ISheet sheet = null;
        private IWorkbook workbook = null;

        #endregion

        #region 构造函数

        public ExportOutboundPacking()
        {
            workbook = new HSSFWorkbook();
        }
       
        public ExportOutboundPacking(GridView view)
        {
            workbook = new HSSFWorkbook();
            gridView = view;
        }

        #endregion

        public void Export( string FilePath )
        {
            
            sheet = workbook.CreateSheet("Sheet1"); 
            FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            /////
            // 列宽
            for (int i = 0; i < 3; i++)
                sheet.SetColumnWidth(i, 15*256); 
            for(int i=3;i<37;i++)
                 sheet.SetColumnWidth(i, 4 * 256);
            sheet.SetColumnWidth(37, 8 * 256); 

            /////

            CartonCount = GetCartonCount();
            for (int i = 0; i < CartonCount; i++)
            {
                CartonNo = i + 1;
                CreateCartonTable(CartonNo);
                 
            }

            /////
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

        private int GetExcelBeginRow(int cartonNo)
        {
            return ( cartonNo-1 ) * 30;
        }

        private void CreateCartonTable(int cartonNo)
        {
            int nBegin = 0;
            nBegin = GetExcelBeginRow(CartonNo);
            AddReportTitle(nBegin);
            AddReportTable(nBegin + 11);
             
            List<string []> data = GetCartonData(cartonNo);

            ExportTableData( data, nBegin + 13);
        }
      
        //添加报表的头部
        private void AddReportTitle(int begRow)
        {
            IFont font = null ;
            ICellStyle cStyle = null;
            IRow eRow = null ;
            ICell eCell = null ;
            //IDataFormat format = workbook.CreateDataFormat();

            int nRow = begRow;
            //添加10行空白行
            for(int i=0;i<11;i++)
            {
                eRow = sheet.CreateRow(begRow+i);
                eRow.HeightInPoints = 25.0f;
            }
            

            //厂家信息
            nRow = begRow + 3;
            eRow = sheet.GetRow(nRow);
            eRow.HeightInPoints = 28.0f;
            eCell = eRow.CreateCell(0);
            eCell.SetCellValue(AppConfig.CompanyInfo.Name);
            //font
            font = workbook.CreateFont();            
            font.FontName = "Calibri";
            font.FontHeightInPoints = 22;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;           
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;

            //日期 
            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 25, 28));
            eCell = eRow.CreateCell(25);
            eCell.SetCellValue("DATE:");
            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 14;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;

            //日期值
            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 29, 37));
            eCell = eRow.CreateCell(29);
            eCell.SetCellValue(Date);
            eCell.CellStyle = cStyle;

            //公司地址
            nRow = begRow + 5;
            eRow = sheet.GetRow(nRow); 
            eCell = eRow.CreateCell(0);
            eCell.SetCellValue(AppConfig.CompanyInfo.Address); 
            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;

            //联系方式
            nRow = begRow + 6;
            eRow = sheet.GetRow(nRow);
            eCell = eRow.CreateCell(0);
            eCell.SetCellValue("Contact:      Silvia  " + AppConfig.CompanyInfo.Tell);
            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold; 
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;

            //发票编号
            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 25, 28));
            eCell = eRow.CreateCell(25);
            eCell.SetCellValue("Invoice #");
            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold; 
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;
            //发票号值
            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 29, 37));
            eCell = eRow.CreateCell(29);
            eCell.SetCellValue(PoNo);
            eCell.CellStyle = cStyle;

            //Carton
            nRow = begRow + 9;
            eRow = sheet.GetRow(nRow); 
            eCell = eRow.CreateCell(0);
            eCell.SetCellValue("Carton #");
            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 16;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cStyle.SetFont(font);
            eCell.CellStyle = cStyle;

            eCell = eRow.CreateCell(2);
            eCell.SetCellValue( string.Format("{0}-{1}",CartonNo, CartonCount) );
            eCell.CellStyle = cStyle;
        }
        //建空表
        private void AddReportTable(int begRow)
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
           
            int nRow = begRow;
            //添加10行空白行
            for (int i = 0; i < 2; i++)
            {
                nRow = begRow + i;
                eRow = sheet.CreateRow(nRow);
                eRow.HeightInPoints = 22.0f;

                for (int j = 0; j < 38; j++)
                {
                    eCell = eRow.CreateCell(j);
                    eCell.CellStyle = cStyle;
                }
            }

            //赋值表头
            nRow = begRow;
            eRow = sheet.GetRow(nRow);

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow+1, 0, 0));
            eCell = eRow.CreateCell(0);
            eCell.SetCellValue("LOT #");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow + 1,1, 1));
            eCell = eRow.CreateCell(1);
            eCell.SetCellValue("Art #");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow + 1, 2, 2));
            eCell = eRow.CreateCell(2);
            eCell.SetCellValue("COLOR ");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 3, 16));
            eCell = eRow.CreateCell(3);
            eCell.SetCellValue("REGULAR ");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 17, 29));
            eCell = eRow.CreateCell(17);
            eCell.SetCellValue("LONG ");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow, 30, 36));
            eCell = eRow.CreateCell(30);
            eCell.SetCellValue("SHORT ");
            eCell.CellStyle = cStyle;

            sheet.AddMergedRegion(new CellRangeAddress(nRow, nRow + 1, 37, 37));
            eCell = eRow.CreateCell(37);
            eCell.SetCellValue("QTY ");
            eCell.CellStyle = cStyle;

            nRow = begRow + 1;
            eRow = sheet.GetRow(nRow);
            for (int i = 3, k = 0; i <= 16; i++)
            {
                eCell = eRow.GetCell(i);
                eCell.SetCellValue(36 + k);
                k += 2;
            }

            for (int i = 17, k = 0; i <= 29; i++)
            {
                eCell = eRow.GetCell(i);
                eCell.SetCellValue(38 + k);
                k += 2;
            }

            for (int i = 30, k = 0; i <= 36; i++)
            {
                eCell = eRow.GetCell(i);
                eCell.SetCellValue(34 + k);
                k += 2;
            }

            //font
            font = workbook.CreateFont();
            font.FontName = "Calibri";
            font.FontHeightInPoints = 10;
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Normal;
            //style
            cStyle = workbook.CreateCellStyle();
            cStyle.VerticalAlignment = VerticalAlignment.Center;
            cStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cStyle.SetFont(font);
             
            for (int i = 0; i < 10; i++)
            {
                nRow ++;
                eRow = sheet.CreateRow(nRow);
                eRow.HeightInPoints = 25.0f;

                for (int j = 0; j < 38; j++)
                {
                    eCell = eRow.CreateCell(j);
                    eCell.CellStyle = cStyle;

                }
            }

            //添加空行
            for (int i = 0; i < 7; i++)
            {
                nRow++;
                eRow = sheet.CreateRow(nRow);
                eRow.HeightInPoints = 20.0f;

                for (int j = 0; j < 38; j++)
                {
                    eCell = eRow.CreateCell(j); 

                }
            }

        }

        //导出数据
        private void ExportTableData( List<string []>data, int begRow)
        {
            if (data == null || data.Count == 0 )
                return;
            int rowCnt = data.Count;
            int colCnt = data[0].Length;

            IRow eRow = null;  
            
            for (int i = 0, j=0; i < rowCnt; i++)
            {
                j = 0;
                eRow = sheet.GetRow( i + begRow);
                                
                eRow.GetCell(j).SetCellValue( data[i][j++] );//Lot#
                                
                eRow.GetCell(j).SetCellValue( data[i][j++] );//Art#

                eRow.GetCell(j).SetCellValue(data[i][j++]);//Color

                for (j = 3; j < colCnt; j++)
                {
                    if (string.IsNullOrEmpty(data[i][j]) == false)
                        eRow.GetCell(j).SetCellValue(Convert.ToInt32(data[i][j]));
                }

                eRow.GetCell(37).SetCellFormula(string.Format("SUM(D{0}:AK{0})", i + 1 + begRow));
                
            }
        }

        private List<string[]>  GetCartonData(int cartonNo)
        {
            List<string[]> list = new List<string[]>();
            string[] data = null;
            string artNo = string.Empty;
            Clothes clothes = null;

            #region 开始找第一SizeNo的行号及列号

            int  nBegSizeNoCol = 3, nEndSizeNoCol=36 ,nTotalCol = 37;
            int sumBefore = (cartonNo - 1) * CartonSize;
            int sumTemp = 0, nTemp = 0;
            int nRow = 0, nCol = 3, nDif = 0 ;

            bool bFind = false;
            //首先定位第一个元素的位置 
            Object obj = null;

            if (sumBefore == 0)
            { 
                goto start;
            }
            for (int i = 0; i < gridView.RowCount; i++)
            { 
                //直接加 小计 
                obj = gridView.GetRowCellValue(i, gridView.Columns[nTotalCol]);
                if (obj != null)
                {
                    nTemp = Convert.ToInt32(obj); 
                }
                if (sumTemp + nTemp <= sumBefore)
                {
                    sumTemp += nTemp;
                    continue;
                }

                nRow = i;//开始行号

                //按列加
                for (int j = nBegSizeNoCol; j <= nEndSizeNoCol; j++)
                { 
                    obj = gridView.GetRowCellValue(i, gridView.Columns[j]);
                    if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim() ))
                        continue;
                    nTemp = Convert.ToInt32(obj);

                    if (sumTemp + nTemp < sumBefore)
                    {
                        sumTemp += nTemp;
                        continue; 
                    }

                    //正好找到了
                    if (sumTemp + nTemp == sumBefore)
                    {
                        if (j < nEndSizeNoCol)
                            nCol = j + 1;
                        else
                        {
                            nRow += 1;
                            nCol = nBegSizeNoCol;
                        }

                    }
                    else
                    {
                        nCol = j;
                        nDif = nTemp - (sumBefore - sumTemp);
                    }

                    bFind = true; 
                    break;

                }//end for j 

                if (bFind == true)
                    break;

            }//end for i 

            #endregion

            #region  nDif >= CartonSize

            if (nDif >= CartonSize)
            { 
                data = new string[37];
                data[nCol] = CartonSize.ToString() ;
                artNo = gridView.GetRowCellValue(nRow,"LotNo").ToString();
                clothes = GetClothes(artNo);
                if (clothes != null)
                {
                    data[0] = clothes.ShellNo;
                    data[1] = artNo;
                    data[2] = clothes.Color;
                }
                list.Add(data);
                return list; 
            }
            
            #endregion

            #region 只有一行

   start:   data = new string[37];
            artNo = gridView.GetRowCellValue(nRow, "LotNo").ToString();
            clothes = GetClothes(artNo);
            if (clothes != null)
            {
                data[0] = clothes.ShellNo;
                data[1] = artNo;
                data[2] = clothes.Color;

                nTemp = 0;
                if (nDif == 0)
                {
                    obj = gridView.GetRowCellValue(nRow, gridView.Columns[nCol]);
                    if (obj != null && string.IsNullOrEmpty(obj.ToString().Trim()) == false)
                        nTemp = Convert.ToInt32(obj);
                    if (nTemp <= CartonSize)
                    {
                        if(nTemp>0)
                            data[nCol] = nTemp.ToString();
                        nDif = nTemp;
                    }
                    else
                    {
                        data[nCol] = CartonSize.ToString();
                        nDif = nTemp - Convert.ToInt32(obj);
                        sumTemp = CartonSize;

                        list.Add(data);
                        return list;
                    }
                }
                else
                    data[nCol] = nDif.ToString();
            }

            sumTemp = nDif;
            int nEndCol = nCol;
            for (int j = nCol+1; j <= nEndSizeNoCol; j++)
            { 
                obj = gridView.GetRowCellValue(nRow, gridView.Columns[j]);
                if (obj == null || string.IsNullOrEmpty( obj.ToString().Trim() ) )
                    continue;
                nTemp = Convert.ToInt32(obj);
                if (sumTemp + nTemp < CartonSize)
                {
                    sumTemp += nTemp;
                    data[j] = nTemp.ToString(); 
                    continue;
                } 
                else   
                {
                    data[j] = (CartonSize - sumTemp).ToString();
                    sumTemp += nTemp;
                    break;
                }
            }

            list.Add(data);

            if (sumTemp >= CartonSize)
                return list;
            
            #endregion

            #region 大于一行
           
            for (int i = nRow+1; i < gridView.RowCount; i++)
            { 
                data = new string[37];
                artNo = gridView.GetRowCellValue(i, "LotNo").ToString();
                clothes = GetClothes(artNo);
                if (clothes != null)
                {
                    data[0] = clothes.ShellNo;
                    data[1] = artNo;
                    data[2] = clothes.Color;
                }
                if(sumTemp < CartonSize)
                    list.Add(data);

                for (int j = nBegSizeNoCol; j <= nEndSizeNoCol; j++)
                {
                    obj = gridView.GetRowCellValue(i, gridView.Columns[j]);
                    if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                        continue;
                    nTemp = Convert.ToInt32(obj);
                    if (sumTemp + nTemp < CartonSize)
                    {
                        sumTemp += nTemp;
                        data[j] = nTemp.ToString();
                        continue;
                    }
                    else
                    {
                        data[j] = (CartonSize - sumTemp).ToString();
                        sumTemp += nTemp;
                        break;
                    }
                }
            }
            
            #endregion

            return list;
        }

        private int GetCartonCount()
        {
            int cnt = 0;
            int sum = 0;
            Object obj = null;
            GridColumn column = gridView.Columns[37];
            for (int i = 0; i < gridView.RowCount; i++)
            {
                obj = gridView.GetRowCellValue(i, column);
                if (obj != null && string.IsNullOrEmpty(obj.ToString()) == false)
                {
                    sum += Convert.ToInt32( obj );
                }
            }
            cnt = sum / CartonSize;
            if (sum % CartonSize > 0)
                cnt += 1;
            return cnt;
        }
         
        private Clothes GetClothes(string artNo)
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
    }

    

}

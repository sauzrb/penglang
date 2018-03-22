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
	public class ExportToExcel
	{
        static protected string[,] GetGridCell(GridView gridView)
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

        static protected ICellStyle GetValueCellStyle(IWorkbook hWorkBook)
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

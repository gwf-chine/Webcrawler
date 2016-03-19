using NPOI.HPSF;
using NPOI.HSSF.Extractor;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Common
{
    public static class ExcelUtility
    {
        public static HSSFWorkbook workbook;
        [Flags]
        public enum LinkType
        {
            網址,
            檔案,
            郵件,
            內文
        };
        public static void InitializeWorkbook()
        {
            ////create a entry of DocumentSummaryInformation
            if (workbook == null)
                workbook = new HSSFWorkbook();
            //HSSFFont font1 = workbook.CreateFont();
            //HSSFCellStyle Style = workbook.CreateCellStyle();
            //font1.FontHeightInPoints = 10;
            //font1.FontName = "新細明體";
            //Style.SetFont(font1);
            //for (int i = 0; i < workbook.NumberOfSheets; i++)
            //{
            //    HSSFSheet Sheets = workbook.GetSheetAt(0);
            //    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
            //    {
            //        HSSFRow row = Sheets.GetRow(k);
            //        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
            //        {
            //            HSSFCell Cell = row.GetCell(l);
            //            Cell.CellStyle = Style;
            //        }
            //    }
            //}
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "測試公司";
            workbook.DocumentSummaryInformation = dsi;
            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "測試公司Excel檔案";
            si.Title = "測試公司Excel檔案";
            si.Author = "killysss";
            si.Comments = "謝謝您的使用！";
            workbook.SummaryInformation = si;

        }



        public static string GetCellPosition(int row, int col)
        {
            col = Convert.ToInt32('A') + col;
            row = row + 1;
            return ((char)col) + row.ToString();
        }
        public static void WriteSteamToFile(MemoryStream ms, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            data = null;
            ms = null;
            fs = null;
        }
        public static void WriteSteamToFile(byte[] data, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            data = null;
            fs = null;
        }
        public static Stream WorkBookToStream(HSSFWorkbook InputWorkBook)
        {
            MemoryStream ms = new MemoryStream();
            InputWorkBook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }
        public static HSSFWorkbook StreamToWorkBook(Stream InputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(InputStream);
            return WorkBook;
        }
        public static HSSFWorkbook MemoryStreamToWorkBook(MemoryStream InputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(InputStream as Stream);
            return WorkBook;
        }
        public static MemoryStream WorkBookToMemoryStream(HSSFWorkbook InputStream)
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            InputStream.Write(file);
            return file;
        }
        public static Stream FileToStream(string FileName)
        {
            FileInfo fi = new FileInfo(FileName);
            if (fi.Exists == true)
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                return fs;
            }
            else return null;
        }
        public static Stream MemoryStreamToStream(MemoryStream ms)
        {
            return ms as Stream;
        }
        /// <summary>
        /// 將DataTable轉成Stream輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static Stream RenderDataTableToExcel(DataTable SourceTable)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }
        /// <summary>
        /// 將DataTable轉成Workbook(自定資料型態)輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static HSSFWorkbook RenderDataTableToWorkBook(DataTable SourceTable)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }
            return workbook;
        }

        /// <summary>
        /// 將DataTable資料輸出成檔案.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <param name="FileName">Name of the file.</param>
        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            var sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            var headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (HaveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            var sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            var headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (HaveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                HSSFRow row =(HSSFRow) sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }


        /// <summary>
        /// 建立datatable
        /// </summary>
        /// <param name="ColumnName">欄位名用逗號分隔</param>
        /// <param name="value">data陣列 , rowmajor</param>
        /// <returns>DataTable</returns>
        public static DataTable CreateDataTable(string ColumnName, string[,] value)
        {
            /*  輸入範例
            string cname = " name , sex ";
            string[,] aaz = new string[4, 2];
            for (int q = 0; q < 4; q++)
                for (int r = 0; r < 2; r++)
                    aaz[q, r] = "1";
            dataGridView1.DataSource = NewMediaTest1.Model.Utility.DataSetUtil.CreateDataTable(cname, aaz);
            */
            int i, j;
            DataTable ResultTable = new DataTable();
            string[] sep = new string[] { "," };

            string[] TempColName = ColumnName.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            DataColumn[] CName = new DataColumn[TempColName.Length];
            for (i = 0; i < TempColName.Length; i++)
            {
                DataColumn c1 = new DataColumn(TempColName[i].ToString().Trim(), typeof(object));
                ResultTable.Columns.Add(c1);
            }
            if (value != null)
            {
                for (i = 0; i < value.GetLength(0); i++)
                {
                    DataRow newrow = ResultTable.NewRow();
                    for (j = 0; j < TempColName.Length; j++)
                    {
                        newrow[j] = string.Copy(value[i, j].ToString());

                    }
                    ResultTable.Rows.Add(newrow);
                }
            }
            return ResultTable;
        }
        /// <summary>
        /// Creates the string array.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string[,] CreateStringArray(DataTable dt)
        {
            int ColumnNum = dt.Columns.Count;
            int RowNum = dt.Rows.Count;
            string[,] result = new string[RowNum, ColumnNum];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    result[i, j] = string.Copy(dt.Rows[i][j].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// 將陣列輸出成位元流.
        /// </summary>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static Stream RenderArrayToExcel(string ColumnName, string[,] SourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, SourceTable);
            return RenderDataTableToExcel(dt);
        }
        /// <summary>
        /// 將陣列輸出成檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="SourceTable">The source table.</param>
        public static void RenderArrayToExcel(string FileName, string ColumnName, string[,] SourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, SourceTable);
            RenderDataTableToExcel(dt, FileName);
        }
        /// <summary>
        /// 將陣列輸出成WorkBook(自訂資料型態).
        /// </summary>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static HSSFWorkbook RenderArrayToWorkBook(string ColumnName, string[,] SourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, SourceTable);
            return RenderDataTableToWorkBook(dt);
        }

        /// <summary>
        /// 將位元流資料輸出成陣列.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static string[,] RenderArrayFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            var sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            var headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return CreateStringArray(table);
        }

        /// <summary>
        /// 將位元流資料輸出成陣列.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static string[,] RenderArrayFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            HSSFSheet sheet =(HSSFSheet) workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return CreateStringArray(table);
        }


        /// <summary>
        /// 在位元流儲存格中建立超連結.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="LinkName">Name of the link.</param>
        /// <param name="LinkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="CellIndex">Index of the cell.</param>
        /// <returns></returns>
        public static Stream MakeLink(Stream InputStream, string SheetNameOrIndex, string LinkName, string LinkValueOrIndex, LinkType s1, int RowIndex, int CellIndex)
        {

            workbook = new HSSFWorkbook(InputStream);
            //HSSFSheet sheet = hssfworkbook.CreateSheet("Hyperlinks");
            ////cell style for hyperlinks
            ////by default hyperlinks are blue and underlined        
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var hlink_style = workbook.CreateCellStyle();
            var hlink_font = workbook.CreateFont();
            hlink_font.Underline =FontUnderlineType.Single;
            hlink_font.Color =  HSSFColor.Blue.Index;
            hlink_style.SetFont(hlink_font);
            string ResultLinkValue = string.Empty;
            int ResultSheet;
            ISheet sheet;
            if (int.TryParse(SheetNameOrIndex, out ResultSheet) == true)
                sheet = workbook.GetSheetAt(ResultSheet);
            else
                sheet = workbook.GetSheet(SheetNameOrIndex);
            var cell = sheet.CreateRow(RowIndex).CreateCell(CellIndex);
            cell.SetCellValue(LinkName);
            HSSFHyperlink link;
            switch (s1.ToString())
            {
                case "網址":
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    ResultLinkValue = string.Copy(LinkValueOrIndex);
                    break;
                case "檔案":
                    link = new HSSFHyperlink(HyperlinkType.File);
                    ResultLinkValue = string.Copy(LinkValueOrIndex);
                    break;
                case "郵件":
                    link = new HSSFHyperlink(HyperlinkType.Email);
                    // ResultLinkValue = string.Copy(LinkValue);   
                    ResultLinkValue = "mailto:" + LinkValueOrIndex;
                    break;
                case "內文":
                    int result;
                    link = new HSSFHyperlink(HyperlinkType.Document);
                    if (int.TryParse(LinkValueOrIndex, out result) == true)
                        ResultLinkValue = "'" + workbook.GetSheetName(result) + "'!A1";
                    else
                        ResultLinkValue = "'" + LinkValueOrIndex + "'!A1";
                    break;
                default:
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    break;
            }
            link.Address = (ResultLinkValue);
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 在檔案儲存格中建立超連結.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="LinkName">Name of the link.</param>
        /// <param name="LinkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="CellIndex">Index of the cell.</param>
        public static void MakeLink(string FileName, Stream InputStream, string SheetNameOrIndex, string LinkName, string LinkValueOrIndex, LinkType s1, int RowIndex, int CellIndex)
        {
            MemoryStream ms = MakeLink(InputStream, SheetNameOrIndex, LinkName, LinkValueOrIndex, s1, RowIndex, CellIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 建立新位元流並在儲存格中建立超連結.
        /// </summary>
        /// <param name="SheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="LinkName">Name of the link.</param>
        /// <param name="LinkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="CellIndex">Index of the cell.</param>
        /// <returns></returns>
        public static Stream MakeLinkFromEmpty(string SheetNameOrIndex, string LinkName, string LinkValueOrIndex, LinkType s1, int RowIndex, int CellIndex)
        {

            workbook = new HSSFWorkbook();
            HSSFSheet sheet1 =(HSSFSheet) workbook.CreateSheet();
            //HSSFSheet sheet = hssfworkbook.CreateSheet("Hyperlinks");
            ////cell style for hyperlinks
            ////by default hyperlinks are blue and underlined        
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFCellStyle hlink_style = (HSSFCellStyle)workbook.CreateCellStyle();
            var hlink_font =workbook.CreateFont();
            hlink_font.Underline = FontUnderlineType.Single;
            hlink_font.Color =  HSSFColor.Blue.Index;
            hlink_style.SetFont(hlink_font);
            string ResultLinkValue = string.Empty;
            int ResultSheet;
            ISheet sheet;
            if (int.TryParse(SheetNameOrIndex, out ResultSheet) == true)
                sheet = workbook.GetSheetAt(ResultSheet);
            else
                sheet = workbook.GetSheet(SheetNameOrIndex);
            var cell = sheet.CreateRow(RowIndex).CreateCell(CellIndex);
            cell.SetCellValue(LinkName);
            HSSFHyperlink link;
            switch (s1.ToString())
            {
                case "網址":
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    ResultLinkValue = string.Copy(LinkValueOrIndex);
                    break;
                case "檔案":
                    link = new HSSFHyperlink(HyperlinkType.File);
                    ResultLinkValue = string.Copy(LinkValueOrIndex);
                    break;
                case "郵件":
                    link = new HSSFHyperlink(HyperlinkType.Email);
                    // ResultLinkValue = string.Copy(LinkValue);   
                    ResultLinkValue = "mailto:" + LinkValueOrIndex;
                    break;
                case "內文":
                    int result;
                    link = new HSSFHyperlink(HyperlinkType.Document);
                    if (int.TryParse(LinkValueOrIndex, out result) == true)
                        ResultLinkValue = "'" + workbook.GetSheetName(result) + "'!A1";
                    else
                        ResultLinkValue = "'" + LinkValueOrIndex + "'!A1";
                    break;
                default:
                    link = new HSSFHyperlink(HyperlinkType.Unknown);
                    break;
            }
            link.Address = (ResultLinkValue);
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新檔案並在儲存格中建立超連結.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="SheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="LinkName">Name of the link.</param>
        /// <param name="LinkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="CellIndex">Index of the cell.</param>
        public static void MakeLinkFromEmpty(string FileName, string SheetNameOrIndex, string LinkName, string LinkValueOrIndex, LinkType s1, int RowIndex, int CellIndex)
        {
            MemoryStream ms = MakeLinkFromEmpty(SheetNameOrIndex, LinkName, LinkValueOrIndex, s1, RowIndex, CellIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        public static HSSFCellStyle SetCellStyle(HSSFFont InputFont)
        {
            InitializeWorkbook();
            var style1 = workbook.CreateCellStyle();
            style1.SetFont(InputFont);
            return (HSSFCellStyle)style1;
        }
        /// <summary>
        /// 設定字體顏色大小到位元流.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="FontName">Name of the font.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="IsAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream ApplyStyleToFile(Stream InputStream, string FontName, short FontSize, bool IsAllSheet, params string[] SheetName)
        {
            workbook = new HSSFWorkbook(InputStream);
            InitializeWorkbook();
            var font = workbook.CreateFont();
            var Style = workbook.CreateCellStyle();
            font.FontHeightInPoints = FontSize;
            font.FontName = FontName;
            Style.SetFont(font);
            MemoryStream ms = new MemoryStream();
            int i;
            if (IsAllSheet == true)
            {
                for (i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var Sheets = workbook.GetSheetAt(0);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        var row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            var Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            else
            {
                for (i = 0; i < SheetName.Length; i++)
                {
                    var Sheets = workbook.GetSheet(SheetName[i]);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        var row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            var Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 設定字體顏色大小到位元流.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="FontName">Name of the font.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="IsAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <returns></returns>
        public static Stream ApplyStyleToFile(Stream InputStream, string FontName, short FontSize, bool IsAllSheet, params int[] SheetIndex)
        {
            workbook = new HSSFWorkbook(InputStream);
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var font = workbook.CreateFont();
            var Style = workbook.CreateCellStyle();
            font.FontHeightInPoints = FontSize;
            font.FontName = FontName;
            Style.SetFont(font);
            int i;
            if (IsAllSheet == true)
            {
                for (i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var Sheets = workbook.GetSheetAt(0);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        var row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            var Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            else
            {
                for (i = 0; i < SheetIndex.Length; i++)
                {
                    var Sheets = workbook.GetSheetAt(SheetIndex[i]);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        var row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            var Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 設定字體顏色大小到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="FontName">Name of the font.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="IsAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="SheetName">Name of the sheet.</param>
        public static void ApplyStyleToFile(string FileName, Stream InputStream, string FontName, short FontSize, bool IsAllSheet, params string[] SheetName)
        {
            MemoryStream ms = ApplyStyleToFile(InputStream, FontName, FontSize, IsAllSheet, SheetName) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 設定字體顏色大小到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="FontName">Name of the font.</param>
        /// <param name="FontSize">Size of the font.</param>
        /// <param name="IsAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        public static void ApplyStyleToFile(string FileName, Stream InputStream, string FontName, short FontSize, bool IsAllSheet, params int[] SheetIndex)
        {
            MemoryStream ms = ApplyStyleToFile(InputStream, FontName, FontSize, IsAllSheet, SheetIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        /// <summary>
        /// 建立空白excel檔到位元流.
        /// </summary>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream CreateEmptyFile(params string[] SheetName)
        {
            MemoryStream ms = new MemoryStream();
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            if (SheetName == null)
            {
                workbook.CreateSheet();
            }
            else
            {
                foreach (string temp in SheetName)
                    workbook.CreateSheet(temp);
            }
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立空白excel檔到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        public static void CreateEmptyFile(string FileName, params string[] SheetName)
        {
            MemoryStream ms = CreateEmptyFile(SheetName) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        /// <summary>
        /// 設定格線到位元流.
        /// </summary>
        /// <param name="InputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream SetGridLine(Stream InputSteam, bool haveGridLine, params string[] SheetName)
        {
            workbook = new HSSFWorkbook(InputSteam);
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            if (SheetName == null)
            {
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var s1 = workbook.GetSheetAt(i);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            else
            {
                foreach (string TempSheet in SheetName)
                {
                    var s1 = workbook.GetSheet(TempSheet);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 設定格線到位元流.
        /// </summary>
        /// <param name="InputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <returns></returns>
        public static Stream SetGridLine(Stream InputSteam, bool haveGridLine, params int[] SheetIndex)
        {
            workbook = new HSSFWorkbook(InputSteam);
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            if (SheetIndex == null)
            {
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var s1 = workbook.GetSheetAt(i);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            else
            {
                foreach (int TempSheet in SheetIndex)
                {
                    var s1 = workbook.GetSheetAt(TempSheet);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 設定格線到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        public static void SetGridLine(string FileName, Stream InputSteam, bool haveGridLine, params int[] SheetIndex)
        {
            MemoryStream ms = SetGridLine(InputSteam, haveGridLine, SheetIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 設定格線到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="SheetName">Name of the sheet.</param>
        public static void SetGridLine(string FileName, Stream InputSteam, bool haveGridLine, params string[] SheetName)
        {
            MemoryStream ms = SetGridLine(InputSteam, haveGridLine, SheetName) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 從位元流將資料轉成字串輸出
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <returns></returns>
        public static string ExtractStringFromFileStream(Stream InputStream)
        {
            HSSFWorkbook HBook = new HSSFWorkbook(InputStream);
            ExcelExtractor extractor = new ExcelExtractor(HBook);
            return extractor.Text;
        }
        /// <summary>
        /// 從檔案將資料轉成字串輸出
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns></returns>
        public static string ExtractStringFromFileStream(string FileName)
        {
            FileInfo fi = new FileInfo(FileName);
            if (fi.Exists == true)
            {
                using (FileStream fs = fi.Open(FileMode.Open))
                {
                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ExcelExtractor extractor = new ExcelExtractor(HBook);
                    return extractor.Text;
                }
            }
            else return null;
        }
        /// <summary>
        /// 設定群組到位元流.
        /// </summary>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="IsRow">if set to <c>true</c> [is row].</param>
        /// <param name="From">From.</param>
        /// <param name="End">The end.</param>
        /// <returns></returns>
        public static Stream CreateGroup(string SheetName, bool IsRow, int From, int End)
        {
            MemoryStream ms = new MemoryStream();
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            HSSFSheet sh =(HSSFSheet) workbook.CreateSheet(SheetName);
            for (int i = 0; i <= End; i++)
            {
                sh.CreateRow(i);
            }
            if (IsRow == true)
                sh.GroupRow(From, End);
            else
                sh.GroupColumn((short)From, (short)End);

            workbook.Write(ms);
            ms.Flush();
            return ms;

        }
        /// <summary>
        /// 建立群組到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="IsRow">if set to <c>true</c> [is row].</param>
        /// <param name="From">From.</param>
        /// <param name="End">The end.</param>
        public static void CreateGroup(string FileName, string SheetName, bool IsRow, int From, int End)
        {
            MemoryStream ms = CreateGroup(SheetName, IsRow, From, End) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 從樣板建立位元流.
        /// </summary>
        /// <param name="TemplateFileName">Name of the template file.</param>
        /// <returns></returns>
        public static Stream CreateFileStreamFromTemplate(string TemplateFileName)
        {
            FileInfo fi = new FileInfo(TemplateFileName);
            if (fi.Exists == true)
            {
                MemoryStream ms = new MemoryStream();
                FileStream file = new FileStream(TemplateFileName, FileMode.Open, FileAccess.Read);
                workbook = new HSSFWorkbook(file);
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "測試公司";
                workbook.DocumentSummaryInformation = dsi;
                ////create a entry of SummaryInformation
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Subject = "測試公司Excel檔案";
                si.Title = "測試公司Excel檔案";
                si.Author = "killysss";
                si.Comments = "謝謝您的使用！";
                workbook.SummaryInformation = si;
                workbook.Write(ms);
                ms.Flush();
                return ms;
            }
            else return null;
        }

        /// <summary>
        /// 從樣板建立檔案.
        /// </summary>
        /// <param name="TemplateFileName">Name of the template file.</param>
        /// <param name="OutputFileName">Name of the output file.</param>
        public static void CreateFileFromTemplate(string TemplateFileName, string OutputFileName)
        {
            FileInfo fi = new FileInfo(TemplateFileName);
            if (fi.Exists == true)
            {
                MemoryStream ms = CreateFileStreamFromTemplate(TemplateFileName) as MemoryStream;
                WriteSteamToFile(ms, OutputFileName);
            }
            else;
        }
        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="wb">The wb.</param>
        /// <returns></returns>
        public static int LoadImage(string path, HSSFWorkbook wb)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, (int)file.Length);
            return wb.AddPicture(buffer, PictureType.JPEG );

        }
        /// <summary>
        /// 嵌入圖片到位元流.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="PicFileName">Name of the pic file.</param>
        /// <param name="IsOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="RowPosition">The row position.</param>
        /// <returns></returns>
        public static Stream EmbedImage(Stream InputStream, int SheetIndex, string PicFileName, bool IsOriginalSize, int[] RowPosition)
        {
            workbook = new HSSFWorkbook(InputStream);
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet1 = workbook.GetSheetAt(SheetIndex);
            var patriarch = sheet1.CreateDrawingPatriarch();
            //create the anchor
            HSSFClientAnchor anchor;
            anchor = new HSSFClientAnchor(0, 0, 0, 0,
                RowPosition[0], RowPosition[1], RowPosition[2], RowPosition[3]);
            anchor.AnchorType = 2;
            //load the picture and get the picture index in the workbook
            HSSFPicture picture =(HSSFPicture) patriarch.CreatePicture(anchor, LoadImage(PicFileName, workbook));
            //Reset the image to the original size.
            if (IsOriginalSize == true)
                picture.Resize();
            //Line Style
            picture.LineStyle = (LineStyle)HSSFPicture.LINESTYLE_NONE;
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 嵌入圖片到檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="PicFileName">Name of the pic file.</param>
        /// <param name="IsOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="RowPosition">The row position.</param>
        public static void EmbedImage(string FileName, int SheetIndex, Stream InputStream, string PicFileName, bool IsOriginalSize, int[] RowPosition)
        {
            MemoryStream ms = EmbedImage(InputStream, SheetIndex, PicFileName, IsOriginalSize, RowPosition) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 建立新位元流並嵌入圖片.
        /// </summary>
        /// <param name="PicFileName">Name of the pic file.</param>
        /// <param name="IsOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="RowPosition">The row position.</param>
        /// <returns></returns>
        public static Stream EmbedImage(string PicFileName, bool IsOriginalSize, int[] RowPosition)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet1 = workbook.CreateSheet();
            var patriarch = sheet1.CreateDrawingPatriarch();
            //create the anchor
            HSSFClientAnchor anchor;
            anchor = new HSSFClientAnchor(0, 0, 0, 0,
                RowPosition[0], RowPosition[1], RowPosition[2], RowPosition[3]);
            anchor.AnchorType = 2;
            //load the picture and get the picture index in the workbook
            HSSFPicture picture = (HSSFPicture)patriarch.CreatePicture(anchor, LoadImage(PicFileName, workbook));
            //Reset the image to the original size.
            if (IsOriginalSize == true)
                picture.Resize();
            //Line Style
            picture.LineStyle =(LineStyle) HSSFShape.LINESTYLE_NONE;
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新檔案並嵌入圖片.
        /// </summary>
        /// <param name="ExcelFileName">Name of the excel file.</param>
        /// <param name="PicFileName">Name of the pic file.</param>
        /// <param name="IsOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="RowPosition">The row position.</param>
        public static void EmbedImage(string ExcelFileName, string PicFileName, bool IsOriginalSize, int[] RowPosition)
        {
            MemoryStream ms = EmbedImage(PicFileName, IsOriginalSize, RowPosition) as MemoryStream;
            WriteSteamToFile(ms, ExcelFileName);
        }
        /// <summary>
        /// 合併儲存格於位元流.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="RowFrom">The row from.</param>
        /// <param name="ColumnFrom">The column from.</param>
        /// <param name="RowTo">The row to.</param>
        /// <param name="ColumnTo">The column to.</param>
        /// <returns></returns>
        public static Stream MergeCell(Stream InputStream, int SheetIndex, int RowFrom, int ColumnFrom, int RowTo, int ColumnTo)
        {
            workbook = new HSSFWorkbook(InputStream);
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            InitializeWorkbook();
            var sheet1 = workbook.GetSheetAt(SheetIndex);
            sheet1.AddMergedRegion(new CellRangeAddress(RowFrom, ColumnFrom, RowTo, ColumnTo));
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 合併儲存格於檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="RowFrom">The row from.</param>
        /// <param name="ColumnFrom">The column from.</param>
        /// <param name="RowTo">The row to.</param>
        /// <param name="ColumnTo">The column to.</param>
        public static void MergeCell(string FileName, Stream InputStream, int SheetIndex, int RowFrom, int ColumnFrom, int RowTo, int ColumnTo)
        {
            MemoryStream ms = MergeCell(InputStream, SheetIndex, RowFrom, ColumnFrom, RowTo, ColumnTo) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 建立新位元流並合併儲存格.
        /// </summary>
        /// <param name="RowFrom">The row from.</param>
        /// <param name="ColumnFrom">The column from.</param>
        /// <param name="RowTo">The row to.</param>
        /// <param name="ColumnTo">The column to.</param>
        /// <returns></returns>
        public static Stream MergeCell(int RowFrom, int ColumnFrom, int RowTo, int ColumnTo)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            InitializeWorkbook();
            var sheet1 = workbook.CreateSheet();
            sheet1.AddMergedRegion(new CellRangeAddress(RowFrom, ColumnFrom, RowTo, ColumnTo) );
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新檔案並合併儲存格.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="RowFrom">The row from.</param>
        /// <param name="ColumnFrom">The column from.</param>
        /// <param name="RowTo">The row to.</param>
        /// <param name="ColumnTo">The column to.</param>
        public static void MergeCell(string FileName, int RowFrom, int ColumnFrom, int RowTo, int ColumnTo)
        {
            MemoryStream ms = MergeCell(RowFrom, ColumnFrom, RowTo, ColumnTo) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 設定儲存格公式於位元流.
        /// </summary>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="Formula">The formula.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="ColumnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetFormula(Stream InputStream, int SheetIndex, string Formula, int RowIndex, int ColumnIndex)
        {
            //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
            //So we insert three sheet just like what Excel does
            workbook = new HSSFWorkbook(InputStream);
            InitializeWorkbook();
            var ms = new MemoryStream();
            var sheet1 = workbook.GetSheetAt(SheetIndex);
            sheet1.CreateRow(RowIndex).CreateCell(ColumnIndex).SetCellFormula(Formula);
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 設定儲存格公式於檔案.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="InputStream">The input stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="Formula">The formula.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="ColumnIndex">Index of the column.</param>
        public static void SetFormula(string FileName, Stream InputStream, int SheetIndex, string Formula, int RowIndex, int ColumnIndex)
        {
            MemoryStream ms = SetFormula(InputStream, SheetIndex, Formula, RowIndex, ColumnIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
        /// <summary>
        /// 建立新位元流並設定儲存格公式.
        /// </summary>
        /// <param name="Formula">The formula.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="ColumnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetFormula(string Formula, int RowIndex, int ColumnIndex)
        {
            //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
            //So we insert three sheet just like what Excel does
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            var ms = new MemoryStream();
            var sheet1 = workbook.CreateSheet();
            sheet1.CreateRow(RowIndex).CreateCell(ColumnIndex).SetCellFormula(Formula);
            workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新檔案並設定儲存格公式.
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="Formula">The formula.</param>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="ColumnIndex">Index of the column.</param>
        public static void SetFormula(string FileName, string Formula, int RowIndex, int ColumnIndex)
        {
            MemoryStream ms = SetFormula(Formula, RowIndex, ColumnIndex) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Threading;


namespace SaleMTCommon
{
    /// <summary>
    /// Người tạo Luannv – 10/11/2013 : Xử lý export dữ liệu ra file excel .
    /// </summary>
    public class ExportExcel
    {
        #region Declaration
        private BackgroundWorker _BackgroundWorker = new BackgroundWorker();
        private frmProgressBar progressExcel;


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Members
        private bool infoStore;
        private bool infoCompany;
        private string strTitle;
        private string strDate;
        private int caseEx;

        public int CaseEx
        {
            get { return caseEx; }
            set { caseEx = value; }
        }

        public bool InfoCompany
        {
            get { return infoCompany; }
            set { infoCompany = value; }
        }
        public bool InfoStore
        {
            get { return infoStore; }
            set { infoStore = value; }
        }
        public string StrTitle
        {
            get { return strTitle; }
            set { strTitle = value; }
        }
        public string StrDate
        {
            get { return strDate; }
            set { strDate = value; }
        }
        #endregion

        #region paramater
        private DataTable dt;
        private string fileNames;
        private int colFind;
        private int lenMer;
        private DataGridView dgv;
        private int[] arrSum;
        private int rSumQuantity;

        public int RSumQuantity
        {
            get { return rSumQuantity; }
            set { rSumQuantity = value; }
        }

        public int[] ArrSum
        {
            get { return arrSum; }
            set { arrSum = value; }
        }

        public DataGridView Dgv
        {
            get { return dgv; }
            set { dgv = value; }
        }

        public int LenMer
        {
            get { return lenMer; }
            set { lenMer = value; }
        }

        public int ColFind
        {
            get { return colFind; }
            set { colFind = value; }
        }

        public string FileNames
        {
            get { return fileNames; }
            set { fileNames = value; }
        }

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        #endregion

        #region const

        private const int ROW_TITLE = 9;
        private const int ROW_DATA = 10;
        private const string DEFAULT_FORDER = "SALEMT";
        private const string COL_IDENTITY = "STT";
        #endregion
        #endregion

        #region Contructor
        public ExportExcel()
        {
            _BackgroundWorker.ProgressChanged += BackgroundWorker_HandleProgressChanged;
            _BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            _BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            _BackgroundWorker.WorkerReportsProgress = true;
            _BackgroundWorker.WorkerSupportsCancellation = true;
        }
        #endregion

        #region Progress
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Sự kiện thay đổi giá trị process .
        /// </summary>
        private void BackgroundWorker_HandleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressExcel.Message = "Exporting " + e.ProgressPercentage.ToString() + " of 100%";
                progressExcel.Progress = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Sự kiện hoàn thành process .
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                progressExcel.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Sự kiện xử lý export .
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CallMethod();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Sự kiện xử lý khi nhấn cancel process .
        /// </summary>
        private void BackgroundWorker_Cancel(object sender, EventArgs e)
        {
            if (_BackgroundWorker.WorkerSupportsCancellation == true)
            {
                _BackgroundWorker.CancelAsync();
                progressExcel.Close();
            }
        }

        #endregion

        #region Method

        #region private method file forder
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Tạo forder SaleMT nếu chưa có .
        /// </summary>
        private string CreateFoder(string pathForder, string forderName)
        {
            string pathString = "";
            try
            {
                pathString = Path.Combine(pathForder, forderName);
                // Create a file name for the file you want to create.  
                if (!System.IO.Directory.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error:" + ex.Message);
            }
            return pathString;
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Mở file excel  .
        /// </summary>
        public void OpenFile(string f)
        {
            try
            {
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = "EXCEL.EXE";
                //startInfo.Arguments = f;
                //Process.Start(startInfo);
                string[] splitdot = f.Split(new char[1] { '.' });
                string dot = splitdot[splitdot.Length - 1].ToLower();
                if (dot == "" || dot == null)
                {
                    f = f + ".xls";
                }
                FileInfo fi = new FileInfo(f);
                if (fi.Exists)
                    System.Diagnostics.Process.Start(f);
            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenFile': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Release các obj .
        /// </summary>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                log.Error("Error 'releaseObject': " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region Private method set style file excel

        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set style cho tên cty hoặc tên cửa hàng .
        /// </summary>
        private void SetStyle(Excel.Range range)
        {
            try
            {
                range.HorizontalAlignment = Excel.Constants.xlLeft;
                range.Font.Name = "Times New Roman";
                range.Font.Bold = true;
                range.VerticalAlignment = Excel.Constants.xlCenter;
                range.Font.Size = 15;
                range.Font.Italic = 2;
                range.RowHeight = 22;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set style cho các dòng địa chỉ hoặc số điện thoại .
        /// </summary>
        private void SetCellStyle(Excel.Range range)
        {
            try
            {
                range.Font.Name = "Times New Roman";
                range.Font.Italic = 2;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetCellStyle': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : tạo mới 1 cell và set giá trị .
        /// </summary>
        private Excel.Range SetCellValue(Excel.Worksheet xlSheet, string value, string cel1, string cel2)
        {
            Excel.Range range = xlSheet.get_Range(cel1, cel2);
            try
            {
                xlSheet.get_Range(cel1, cel2).Merge(false);
                range.Select();
                range.FormulaR1C1 = value;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return range;
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set tiêu đề báo cáo xuất nhập tồn .
        /// </summary>
        private void SetTitle(Excel.Worksheet xlSheet)
        {
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    char c = Convert.ToChar(i + 65);
                    if (i < 5)
                        xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).Merge(false);

                    xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).Interior.ColorIndex = 15;
                    xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).Font.Bold = true;
                    xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).Borders.Value = 1;
                    xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).HorizontalAlignment = Excel.Constants.xlCenter;
                    xlSheet.get_Range(c + ROW_TITLE.ToString(), c + (ROW_TITLE + 1).ToString()).VerticalAlignment = Excel.Constants.xlCenter;
                }
                // đầu kỳ
                xlSheet.get_Range("F" + ROW_TITLE.ToString(), "H" + (ROW_TITLE).ToString()).Merge(false);
                xlSheet.get_Range("F" + ROW_TITLE.ToString(), "H" + (ROW_TITLE).ToString()).Interior.ColorIndex = 36;
                xlSheet.get_Range("F" + (ROW_TITLE + 1).ToString(), "H" + (ROW_TITLE + 1).ToString()).Interior.ColorIndex = 36;
                xlSheet.Cells[9, 6] = "ĐẦU KỲ";
                xlSheet.Cells[10, 6] = "SL";
                xlSheet.Cells[10, 7] = "Giá";
                xlSheet.Cells[10, 8] = "Thành tiền";
                // nhập trong kỳ
                xlSheet.get_Range("I" + ROW_TITLE.ToString(), "M" + (ROW_TITLE).ToString()).Merge(false);
                xlSheet.get_Range("I" + ROW_TITLE.ToString(), "M" + (ROW_TITLE).ToString()).Interior.ColorIndex = 44;
                xlSheet.get_Range("I" + (ROW_TITLE + 1).ToString(), "M" + (ROW_TITLE + 1).ToString()).Interior.ColorIndex = 44;
                xlSheet.Cells[9, 9] = "NHẬP TRONG KỲ";
                xlSheet.Cells[10, 9] = "Tổng SL";
                xlSheet.Cells[10, 10] = "Nhập hàng";
                xlSheet.Cells[10, 11] = "Tiền nhập hàng";
                xlSheet.Cells[10, 12] = "SL điều chỉnh";
                xlSheet.Cells[10, 13] = "Tiền điều chỉnh";
                //xlSheet.Cells[10, 14] = "SL trả lại";
                //xuất trong kỳ
                xlSheet.get_Range("N" + ROW_TITLE.ToString(), "T" + (ROW_TITLE).ToString()).Merge(false);
                xlSheet.get_Range("N" + ROW_TITLE.ToString(), "T" + (ROW_TITLE).ToString()).Interior.ColorIndex = 42;
                xlSheet.get_Range("N" + (ROW_TITLE + 1).ToString(), "T" + (ROW_TITLE).ToString()).Interior.ColorIndex = 42;
                xlSheet.Cells[9, 14] = "XUẤT TRONG KỲ";
                xlSheet.Cells[10, 14] = "Tổng SL";
                xlSheet.Cells[10, 15] = "SL bán hàng";
                xlSheet.Cells[10, 16] = "Tiền bán hàng";
                xlSheet.Cells[10, 17] = "KM ( bán hàng )";
                xlSheet.Cells[10, 18] = "Tiền KM";
                xlSheet.Cells[10, 19] = "SL điều chỉnh";
                xlSheet.Cells[10, 20] = "Tiền điều chỉnh";

                //tồn cuối kỳ
                xlSheet.get_Range("U" + ROW_TITLE.ToString(), "W" + (ROW_TITLE).ToString()).Merge(false);
                xlSheet.get_Range("U" + ROW_TITLE.ToString(), "W" + (ROW_TITLE).ToString()).Interior.ColorIndex = 15;
                xlSheet.get_Range("U" + (ROW_TITLE + 1).ToString(), "W" + (ROW_TITLE).ToString()).Interior.ColorIndex = 15;
                xlSheet.Cells[9, 21] = "CUỐI KỲ";
                xlSheet.Cells[10, 21] = "SL";
                xlSheet.Cells[10, 22] = "Giá";
                xlSheet.Cells[10, 23] = "Thành tiền";

            }
            catch (Exception ex)
            {
                log.Error("Error 'SetTitle': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set dữ liệu thông tin cty,cửa hàng, tiêu đề file excel .
        /// </summary>
        private void SetDataInfo(Excel.Worksheet xlSheet, int merge, int colCount)
        {
            try
            {
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty
                if (infoCompany)
                {
                    Excel.Range ranComName = SetCellValue(xlSheet, UserImformation.CompanyName, Convert.ToChar(merge + 66) + "1", Convert.ToChar(merge + merge + 65) + "1");
                    SetStyle(ranComName);
                    Excel.Range ranComAdress = SetCellValue(xlSheet, UserImformation.CompanyAdress, Convert.ToChar(merge + 66) + "2", Convert.ToChar(merge + merge + 65) + "2");
                    SetCellStyle(ranComAdress);
                    Excel.Range ranComTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.CompanyTelePhone + "  Fax: " + UserImformation.CompanyFax, Convert.ToChar(merge + 66) + "3", Convert.ToChar(merge + merge + 65) + "3");
                    SetCellStyle(ranComTelFax);
                }
                // Tên info cửa hàng
                if (InfoStore)
                {
                    Excel.Range ranStoName = SetCellValue(xlSheet, UserImformation.DeptName, Convert.ToChar(65) + "1", Convert.ToChar(merge + 65) + "1");
                    SetStyle(ranStoName);
                    Excel.Range ranStoAdress = SetCellValue(xlSheet, UserImformation.StoreAdress, Convert.ToChar(65) + "2", Convert.ToChar(merge + 65) + "2");
                    SetCellStyle(ranStoAdress);
                    Excel.Range ranStoTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.StoreTelePhone + "  Fax: " + UserImformation.StoreFax, Convert.ToChar(65) + "3", Convert.ToChar(merge + 65) + "3");
                    SetCellStyle(ranStoTelFax);
                }
                //set tiêu đề
                if (strTitle != null && strTitle != "")
                {
                    xlSheet.get_Range("A6", cEnd + "6").Merge(false);
                    Excel.Range title = xlSheet.get_Range("A6", Convert.ToChar(merge + 65) + "6");
                    title.Select();
                    title.FormulaR1C1 = strTitle;

                    title.HorizontalAlignment = Excel.Constants.xlLeft;
                    title.Font.Bold = true;
                    title.VerticalAlignment = Excel.Constants.xlCenter;
                    title.Font.Size = 15;
                    title.RowHeight = 22;
                    title.Font.Name = "Times New Roman";
                }
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A" + ROW_TITLE.ToString(), cEnd + ROW_TITLE.ToString());
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlLeft;
                header.VerticalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.Interior.ColorIndex = 15;
                header.RowHeight = 17;
                header.Borders.Value = 1;
                header.Font.Name = "Times New Roman";
                //set từ ngày đến ngày
                if (strDate != null && strDate != "")
                {
                    xlSheet.get_Range("A8", cEnd + "8").Merge(false);
                    Excel.Range date = xlSheet.get_Range("A8", Convert.ToChar(merge + 65) + "8");
                    date.Select();
                    date.FormulaR1C1 = strDate;

                    date.HorizontalAlignment = Excel.Constants.xlLeft;
                    date.Font.Bold = false;
                    date.VerticalAlignment = Excel.Constants.xlCenter;
                    date.Font.Size = 12;
                    date.RowHeight = 17;
                    date.Font.Italic = 2;
                    date.Font.Name = "Times New Roman";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set chữ ký file excel .
        /// </summary>
        private void SetSignature(Excel.Worksheet xlSheet, int rowcount)
        {
            try
            {
                //set từ ngày đến ngày
                if (strDate != null && strDate != "")
                {
                    Excel.Range sign1 = xlSheet.get_Range(Convert.ToChar(65) + (ROW_DATA + rowcount + 2).ToString(), Convert.ToChar(2 + 65) + (ROW_DATA + rowcount + 2).ToString());
                    sign1.Merge(false);
                    sign1.Select();
                    sign1.FormulaR1C1 = "Người lập";

                    sign1.HorizontalAlignment = Excel.Constants.xlCenter;
                    sign1.Font.Bold = true;
                    sign1.VerticalAlignment = Excel.Constants.xlCenter;
                    sign1.Font.Size = 12;
                    sign1.Font.Name = "Times New Roman";

                    Excel.Range sign2 = xlSheet.get_Range(Convert.ToChar(3 + 65) + (ROW_DATA + rowcount + 2).ToString(), Convert.ToChar(5 + 65) + (ROW_DATA + rowcount + 2).ToString());
                    sign2.Merge(false);
                    sign2.Select();
                    sign2.FormulaR1C1 = "Xác nhận của ngân hàng";

                    sign2.HorizontalAlignment = Excel.Constants.xlCenter;
                    sign2.Font.Bold = true;
                    sign2.VerticalAlignment = Excel.Constants.xlCenter;
                    sign2.Font.Size = 12;
                    sign2.Font.Name = "Times New Roman";

                    Excel.Range sign3 = xlSheet.get_Range(Convert.ToChar(6 + 65) + (ROW_DATA + rowcount + 2).ToString(), Convert.ToChar(8 + 65) + (ROW_DATA + rowcount + 2).ToString());
                    sign3.Merge(false);
                    sign3.Select();
                    sign3.FormulaR1C1 = "Xác nhận của cửa hàng trưởng";

                    sign3.HorizontalAlignment = Excel.Constants.xlCenter;
                    sign3.Font.Bold = true;
                    sign3.VerticalAlignment = Excel.Constants.xlCenter;
                    sign3.Font.Size = 12;
                    sign3.Font.Name = "Times New Roman";
                    // Tên cửa hàng trưởng
                    Excel.Range sign4 = xlSheet.get_Range(Convert.ToChar(6 + 65) + (ROW_DATA + rowcount + 8).ToString(), Convert.ToChar(8 + 65) + (ROW_DATA + rowcount + 8).ToString());
                    sign4.Merge(false);
                    sign4.Select();
                    sign4.FormulaR1C1 = DefaultCustomer.PersonPtrint;

                    sign4.HorizontalAlignment = Excel.Constants.xlCenter;
                    sign4.Font.Bold = true;
                    sign4.VerticalAlignment = Excel.Constants.xlCenter;
                    sign4.Font.Size = 12;
                    sign4.Font.Name = "Times New Roman";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Set style dòng tổng cộng file excel .
        /// </summary>
        private void SetStyleSum(Excel.Worksheet xlSheet, int col, int colCount, int r, int len)
        {
            try
            {
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(col + 65) + (ROW_DATA + r).ToString(), cEnd + (ROW_DATA + r).ToString());
                rowSum1.Select();
                xlSheet.get_Range(Convert.ToChar(col + 66) + (ROW_DATA + r).ToString(), Convert.ToChar(col + len + 65) + (ROW_DATA + r).ToString()).Merge(false);
                rowSum1.Font.Size = 10;
                rowSum1.Interior.ColorIndex = 6;
                rowSum1.RowHeight = 17;
                rowSum1.Borders.Value = 1;
                rowSum1.Font.Bold = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void SetStyleRank(Excel.Range rank)
        {
            try
            {
                rank.Font.Name = "Times New Roman";
                rank.Font.Size = 9;
                rank.Borders.Value = 1;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region private method export
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 :Case xử lý gọi các hàm export theo biến caseEx truyền vào.
        /// </summary>
        private void CallMethod()
        {
            try
            {
                switch (this.caseEx)
                {
                    case 1:
                        {
                            ExportToExcelWithSign(this.dt, this.fileNames, this.colFind, this.lenMer);
                            return;
                        }
                    case 2:
                        {
                            ExportInventoryToExcel(this.dgv, this.fileNames);
                            return;
                        }
                    case 3:
                        {
                            ExportTableReportToExcel(this.dt, this.fileNames, this.arrSum);
                            return;
                        }
                    case 4:
                        {
                            ExportGridReportToExcel(this.dgv, this.fileNames, this.arrSum);
                            return;
                        }
                    case 5:
                        {
                            ExportToExcel(this.dt, this.fileNames);
                            return;
                        }
                    case 6:
                        {
                            ExportToExcelCompare(this.dt, this.fileNames, this.colFind, this.lenMer);
                            return;
                        }
                    case 7:
                        {
                            ExportGridToExcel(this.dgv, this.fileNames);
                            return;
                        }
                    case 8:
                        {
                            ExportToExcelColor(this.dt, this.fileNames);
                            return;
                        }
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel từ dữ liệu lưới báo cáo đầu vào datatable.
        /// </summary>
        private void ExportToExcelCompare(DataTable dt, string fileName, int colFindTextSum, int lenMerge)
        {
            try
            {
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                //set info công ty
                if (infoCompany)
                {
                    Excel.Range ranComName = SetCellValue(xlSheet, UserImformation.CompanyName, Convert.ToChar(merge + 66) + "1", Convert.ToChar(merge + merge + 65) + "1");
                    SetStyle(ranComName);
                    Excel.Range ranComAdress = SetCellValue(xlSheet, UserImformation.CompanyAdress, Convert.ToChar(merge + 66) + "2", Convert.ToChar(merge + merge + 65) + "2");
                    SetCellStyle(ranComAdress);
                    Excel.Range ranComTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.CompanyTelePhone + "  Fax: " + UserImformation.CompanyFax, Convert.ToChar(merge + 66) + "3", Convert.ToChar(merge + merge + 65) + "3");
                    SetCellStyle(ranComTelFax);
                }
                // Tên info cửa hàng
                if (InfoStore)
                {
                    Excel.Range ranStoName = SetCellValue(xlSheet, UserImformation.DeptName, Convert.ToChar(65) + "1", Convert.ToChar(merge + 65) + "1");
                    SetStyle(ranStoName);
                    Excel.Range ranStoAdress = SetCellValue(xlSheet, UserImformation.StoreAdress, Convert.ToChar(65) + "2", Convert.ToChar(merge + 65) + "2");
                    SetCellStyle(ranStoAdress);
                    Excel.Range ranStoTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.StoreTelePhone + "  Fax: " + UserImformation.StoreFax, Convert.ToChar(65) + "3", Convert.ToChar(merge + 65) + "3");
                    SetCellStyle(ranStoTelFax);
                }
                //set tiêu đề
                if (strTitle != null && strTitle != "")
                {
                    xlSheet.get_Range("A6", cEnd + "6").Merge(false);
                    Excel.Range title = xlSheet.get_Range("A6", Convert.ToChar(merge + 65) + "6");
                    title.Select();
                    title.FormulaR1C1 = strTitle;

                    title.HorizontalAlignment = Excel.Constants.xlLeft;
                    title.Font.Bold = true;
                    title.VerticalAlignment = Excel.Constants.xlCenter;
                    title.Font.Size = 15;
                    title.RowHeight = 22;
                    title.Font.Name = "Times New Roman";
                }
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A" + ROW_TITLE.ToString(), Convert.ToChar(colCount + 64) + ROW_TITLE.ToString());
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlLeft;
                header.VerticalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.Interior.ColorIndex = 15;
                header.RowHeight = 17;
                header.Borders.Value = 1;
                header.Font.Name = "Times New Roman";
                //set từ ngày đến ngày
                if (strDate != null && strDate != "")
                {
                    xlSheet.get_Range("A8", cEnd + "8").Merge(false);
                    Excel.Range date = xlSheet.get_Range("A8", Convert.ToChar(merge + 65) + "8");
                    date.Select();
                    date.FormulaR1C1 = strDate;

                    date.HorizontalAlignment = Excel.Constants.xlLeft;
                    date.Font.Bold = false;
                    date.VerticalAlignment = Excel.Constants.xlCenter;
                    date.Font.Size = 12;
                    date.RowHeight = 17;
                    date.Font.Italic = 2;
                    date.Font.Name = "Times New Roman";
                }
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                {
                    xlSheet.Cells[ROW_TITLE, i + 1] = dt.Columns[i].ColumnName.ToUpper();
                }
                //dien du lieu vao sheet
                for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);

                    // điền dữ liệu export excel
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i][j] != null) ? dt.Rows[i][j].ToString() : "";
                        if (Conversion.IsNumber(value.Trim()) && Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell
                            ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 1]).NumberFormat = "#,##";
                        else
                            ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 1]).NumberFormat = "@";

                        // kiểm tra có row hiện tại có phải là dòng tổng cộng không
                        if (j == colFindTextSum)
                        {
                            string index = value.ToLower();
                            if (index.IndexOf("số hđ:") != -1)
                            {
                                Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(65) + (ROW_DATA + i).ToString(), Convert.ToChar(colCount + 64) + (ROW_DATA + i).ToString());
                                rowSum1.Select();
                                xlSheet.get_Range(Convert.ToChar(66) + (ROW_DATA + i).ToString(), Convert.ToChar(lenMerge + 65) + (ROW_DATA + i).ToString()).Merge(false);
                                rowSum1.Font.Size = 10;
                                rowSum1.RowHeight = 17;
                                rowSum1.Borders.Value = 1;
                                rowSum1.Font.Bold = true;
                            }
                        }
                        if (this.arrSum != null)
                        {
                            if (j == arrSum[0])
                            {
                                string index = value.ToLower();
                                if (index.IndexOf("tổng cộng") != -1)
                                {
                                    xlSheet.get_Range(Convert.ToChar(j + 65) + (ROW_DATA + i).ToString(), Convert.ToChar(colCount + 64) + (ROW_DATA + i).ToString()).Interior.ColorIndex = 40;
                                    xlSheet.get_Range(Convert.ToChar(j + 65) + (ROW_DATA + i).ToString(), Convert.ToChar(colCount + 64) + (ROW_DATA + i).ToString()).Font.Bold = true;
                                }
                            }
                        }
                        xlSheet.Cells[i + ROW_DATA, j + 1] = value;
                        SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 1]));
                    }
                    //autofit độ rộng cho cột
                    ((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                }

                //get path file
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel từ dữ liệu lưới báo cáo đầu vào datatable.
        /// </summary>
        private void ExportToExcelWithSign(DataTable dt, string fileName, int colFindTextSum, int lenMerge)
        {
            try
            {
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;

                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                {
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].ColumnName.ToUpper();
                }
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //Biến kiểm tra dòng tổng cộng
                List<int> lstSum = new List<int>();
                //dien du lieu vao sheet
                object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    // điền cột thứ tự
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    obj[i, 0] = i + 1;
                    //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]));
                    // điền dữ liệu export excel
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i][j] != null) ? dt.Rows[i][j].ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()) && Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";
                        //else
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "@";

                        // kiểm tra có row hiện tại có phải là dòng tổng cộng không
                        if (j == colFindTextSum)
                        {
                            string index = value.ToLower();
                            if (index.IndexOf("tổng cộng") != -1)
                                SetStyleSum(xlSheet, colFindTextSum, colCount, i, lenMerge);
                        }
                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho cột
                    //((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);
                    if (Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dt.Columns[j].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "@";
                }
                // set Sign
                SetSignature(xlSheet, rowCount);
                //get path file
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel từ dữ liệu báo cáo xuất nhập tồn .
        /// </summary>
        private void ExportInventoryToExcel(DataGridView dt, string fileName)
        {
            try
            {

                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);

                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                {
                    if (i < 4)
                        xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].HeaderText.ToUpper();
                    else
                        xlSheet.Cells[ROW_TITLE + 1, i + 2] = dt.Columns[i].HeaderText.ToUpper();
                }
                SetTitle(xlSheet);
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //for (i = 0; i < rowCount; i++)
                //{
                //    xlSheet.Cells[i + ROW_DATA + 1, 1] = i + 1;
                //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA + 1, 1]).Font.Name = "Times New Roman";
                //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA + 1, 1]).Font.Size = 9;
                //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA + 1, 1]).Borders.Value = 1;
                //}
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    //điền cột stt
                    //điền cột stt
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    obj[i, 1] = i + 1;
                    //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA + 1, 1]));
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i].Cells[j].Value != null) ? dt.Rows[i].Cells[j].Value.ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";

                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho các cột 
                    //((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));*/
                DataTable dtTemp = (DataTable)dt.DataSource;                
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);
                    //DataTable dtTemp = (DataTable)dt.DataSource;
                    if (Conversion.IsColumnNumber(dtTemp.Columns[dt.Columns[j].DataPropertyName]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA+1).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA+1 + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dtTemp.Columns[dt.Columns[j].DataPropertyName].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA+1).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA+1 + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA+1).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA+1 + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA+1).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA+1 + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                object[,] stt = (object[,])obj[0];
                stt[0, 0] = "";
                stt[rowCount-1, 0] = "";
                for (int r = 1; r < rowCount - 1;r++ )
                {
                    stt[r, 0] = int.Parse(stt[r, 0].ToString()) - 1;
                }
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA+1).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + 1 + rowCount - 1), missValue).Value2 = stt;
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA+1 + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA+1 + rowCount - 1), missValue));

                // Điền dữ liệu dòng tổng

                Excel.Range rowSum = xlSheet.get_Range(Convert.ToChar(3 + 66) + (ROW_DATA + 1).ToString(), cEnd + (ROW_DATA + 1).ToString());
                rowSum.Select();
                rowSum.Font.Size = 10;
                rowSum.Interior.ColorIndex = 19;
                rowSum.RowHeight = 17;
                rowSum.Borders.Value = 1;
                rowSum.Font.Bold = true;

                Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(3 + 66) + (ROW_DATA + rowCount).ToString(), cEnd + (ROW_DATA + rowCount).ToString());
                rowSum1.Select();
                rowSum1.Font.Size = 10;
                rowSum1.Interior.ColorIndex = 19;
                rowSum1.RowHeight = 17;
                rowSum1.Borders.Value = 1;
                rowSum1.Font.Bold = true;


                //autofit độ rộng cho các cột 
                //for (i = 0; i < rowCount; i++)
                //    ((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                //
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel từ dữ liệu lưới báo cáo đầu vào datatable.
        /// </summary>
        private void ExportTableReportToExcel(DataTable dt, string fileName, int[] arr)
        {
            try
            {
                int rAdd = (arr == null) ? 0 : 1;
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                {
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].ColumnName.ToUpper();
                }
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;                
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);

                    // điền cột số thứ tự
                    //xlSheet.Cells[i + ROW_DATA + rAdd, 1] = i + 1;
                    obj[i, 0] = i + 1;
                    //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA + rAdd, 1]));
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i][j] != null) ? dt.Rows[i][j].ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()) && Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA + rAdd, j + 2]).NumberFormat = "#,##";                            
                        //else
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA + rAdd, j + 2]).NumberFormat = "@";


                        //xlSheet.Cells[i + ROW_DATA + rAdd, j + 2] = value;
                        obj[i, j + 1] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA + rAdd, j + 2]));
                    }
                    //autofit độ rộng cho cột
                    //((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount+1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue));*/
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j+1 > colCharsetLen)
                    {
                        int idx = (j+1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j+1) % colCharsetLen, 1);
                    if (Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dt.Columns[j].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue).Value2 = obj[0];
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + ROW_TITLE.ToString() + ":{0}{1}",
                    finalColLetter, ROW_TITLE), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA + rAdd).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rAdd + rowCount - 1), missValue));

                // Điền dữ liệu dòng tổng
                if (arr != null && arr.Length > 0)
                {
                    Excel.Range rowSum = xlSheet.get_Range(Convert.ToChar(arr[0] + 66) + ROW_DATA.ToString(), cEnd + ROW_DATA.ToString());
                    rowSum.Select();
                    rowSum.Font.Size = 10;
                    rowSum.Interior.ColorIndex = 40;
                    rowSum.RowHeight = 17;
                    rowSum.Borders.Value = 1;
                    rowSum.Font.Bold = true;

                    Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(arr[0] + 66) + (ROW_DATA + rowCount + 1).ToString(), cEnd + (ROW_DATA + rowCount + 1).ToString());
                    rowSum1.Select();
                    rowSum1.Font.Size = 10;
                    rowSum1.Interior.ColorIndex = 40;
                    rowSum1.RowHeight = 17;
                    rowSum1.Borders.Value = 1;
                    rowSum1.Font.Bold = true;

                    xlSheet.Cells[ROW_DATA, arr[0] + 2] = "Tổng:";
                    xlSheet.Cells[ROW_DATA + rowCount + 1, arr[0] + 2] = "Tổng:";

                    for (j = 1; j < arr.Length; j++)
                    {
                        string xSum1 = (ROW_DATA + 1).ToString();
                        string xSum2 = (ROW_DATA + rowCount).ToString();
                        char xCol = Convert.ToChar(arr[j] + 66);
                        Excel.Range rSumOn = xlSheet.get_Range(xCol + ROW_DATA.ToString(), xCol + ROW_DATA.ToString());
                        rSumOn.Formula = "=sum(" + xCol + xSum1 + ":" + xCol + xSum2 + ")";

                        Excel.Range rSumDown = xlSheet.get_Range(xCol + (ROW_DATA + rowCount + 1).ToString(), xCol + (ROW_DATA + rowCount + 1).ToString());
                        rSumDown.Formula = "=sum(" + xCol + xSum1 + ":" + xCol + xSum2 + ")";
                    }
                }
                //get path file
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel từ dữ liệu lưới báo cáo đầu vào datagridview .
        /// </summary>
        private void ExportGridReportToExcel(DataGridView dt, string fileName, int[] arr)
        {
            try
            {

                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty
                if (infoCompany)
                {
                    Excel.Range ranComName = SetCellValue(xlSheet, UserImformation.CompanyName, Convert.ToChar(merge + 66) + "1", Convert.ToChar(merge + merge + 65) + "1");
                    SetStyle(ranComName);
                    Excel.Range ranComAdress = SetCellValue(xlSheet, UserImformation.CompanyAdress, Convert.ToChar(merge + 66) + "2", Convert.ToChar(merge + merge + 65) + "2");
                    SetCellStyle(ranComAdress);
                    Excel.Range ranComTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.CompanyTelePhone + "  Fax: " + UserImformation.CompanyFax, Convert.ToChar(merge + 66) + "3", Convert.ToChar(merge + merge + 65) + "3");
                    SetCellStyle(ranComTelFax);
                }
                // Tên info cửa hàng
                if (InfoStore)
                {
                    Excel.Range ranStoName = SetCellValue(xlSheet, UserImformation.DeptName, Convert.ToChar(65) + "1", Convert.ToChar(merge + 65) + "1");
                    SetStyle(ranStoName);
                    Excel.Range ranStoAdress = SetCellValue(xlSheet, UserImformation.StoreAdress, Convert.ToChar(65) + "2", Convert.ToChar(merge + 65) + "2");
                    SetCellStyle(ranStoAdress);
                    Excel.Range ranStoTelFax = SetCellValue(xlSheet, "Tel: " + UserImformation.StoreTelePhone + "  Fax: " + UserImformation.StoreFax, Convert.ToChar(65) + "3", Convert.ToChar(merge + 65) + "3");
                    SetCellStyle(ranStoTelFax);
                }
                //set tiêu đề
                if (strTitle != null && strTitle != "")
                {
                    xlSheet.get_Range("A6", cEnd + "6").Merge(false);
                    Excel.Range title = xlSheet.get_Range("A6", Convert.ToChar(merge + 65) + "6");
                    title.Select();
                    title.FormulaR1C1 = strTitle;

                    title.HorizontalAlignment = Excel.Constants.xlLeft;
                    title.Font.Bold = true;
                    title.VerticalAlignment = Excel.Constants.xlCenter;
                    title.Font.Size = 15;
                    title.RowHeight = 22;
                    title.Font.Name = "Times New Roman";
                }

                //set từ ngày đến ngày
                if (strDate != null && strDate != "")
                {
                    xlSheet.get_Range("A8", cEnd + "8").Merge(false);
                    Excel.Range date = xlSheet.get_Range("A8", Convert.ToChar(merge + 65) + "8");
                    date.Select();
                    date.FormulaR1C1 = strDate;

                    date.HorizontalAlignment = Excel.Constants.xlLeft;
                    date.Font.Bold = false;
                    date.VerticalAlignment = Excel.Constants.xlCenter;
                    date.Font.Size = 12;
                    date.RowHeight = 17;
                    date.Font.Italic = 2;
                    date.Font.Name = "Times New Roman";
                }

                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A" + ROW_TITLE.ToString(), cEnd + ROW_TITLE.ToString());
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlLeft;
                header.VerticalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.Interior.ColorIndex = 15;
                header.RowHeight = 20;
                header.Borders.Value = 1;
                header.Font.Name = "Times New Roman";
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                {
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].HeaderText.ToUpper();
                }
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    //điền cột stt
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    obj[i, 1] = i + 1;
                    //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA + 1, 1]));
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i].Cells[j].Value != null) ? dt.Rows[i].Cells[j].Value.ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";

                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho các cột 
                    //((Excel.Range)xlSheet.Cells[1, i + 2]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));*/
                DataTable dtTemp = (DataTable)dt.DataSource;
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);
                    //DataTable dtTemp = (DataTable)dt.DataSource;
                    if (Conversion.IsColumnNumber(dtTemp.Columns[dt.Columns[j].DataPropertyName]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dtTemp.Columns[dt.Columns[j].DataPropertyName].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[0];
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));

                if (arr != null && arr.Length > 0)
                {
                    int colSum = arr[0];
                    // set style dòng tổng
                    if (colSum > 0)
                    {
                        if (this.rSumQuantity != 1)
                        {
                            Excel.Range rowSum = xlSheet.get_Range(Convert.ToChar(colSum + 66) + ROW_DATA.ToString(), cEnd + ROW_DATA.ToString());
                            rowSum.Select();
                            rowSum.Font.Size = 10;
                            rowSum.Interior.ColorIndex = 40;
                            rowSum.RowHeight = 17;
                            rowSum.Borders.Value = 1;
                            rowSum.Font.Bold = true;
                        }

                        Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(colSum + 66) + (ROW_DATA + rowCount - 1).ToString(), cEnd + (ROW_DATA + rowCount - 1).ToString());
                        rowSum1.Select();
                        rowSum1.Font.Size = 10;
                        rowSum1.Interior.ColorIndex = 40;
                        rowSum1.RowHeight = 17;
                        rowSum1.Borders.Value = 1;
                        rowSum1.Font.Bold = true;
                    }
                }

                //get path file
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Xử lý export dữ liệu ra file excel .
        /// </summary>
        private void ExportToExcel(DataTable dt, string fileName)
        {
            try
            {
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;

                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].ColumnName.ToUpper();
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    //điền cột stt
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Name = "Times New Roman";
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Size = 9;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Borders.Value = 1;
                    obj[i, 0] = i + 1;
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i][j] != null) ? dt.Rows[i][j].ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()) && Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";
                        //else
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "@";


                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho các cột 
                    //((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA  + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA  + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA  + rowCount - 1), missValue));*/                
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);
                    if (Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dt.Columns[j].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[0];
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));

                //get path rank
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo thanhdh – 2/12/2013 : Xử lý export datagridview ra file excel .
        /// </summary>
        private void ExportGridToExcel(DataGridView dt, string fileName)
        {
            try
            {
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;

                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].HeaderText.ToUpper();
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    //điền cột stt
                    obj[i, 0] = i+1;
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Name = "Times New Roman";
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Size = 9;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Borders.Value = 1;
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i].Cells[j].Value != null) ? dt.Rows[i].Cells[j].Value.ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";

                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho các cột 
                    //((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));*/
                DataTable dtTemp = (DataTable)dt.DataSource;
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);

                    if (Conversion.IsColumnNumber(dtTemp.Columns[dt.Columns[j].DataPropertyName]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dtTemp.Columns[dt.Columns[j].DataPropertyName].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[0];
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));

                //get path rank
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        //Đổi màu cho dòng tổng không cộng tổng theo tất cả các cột
        private void ExportToExcelColor(DataTable dt, string fileName)
        {
            try
            {

                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int merge = (colCount < 8) ? colCount : 8;
                int i, j;
                string cEnd = (colCount <= 25) ? Convert.ToChar(colCount + 65).ToString() : "A" + Convert.ToChar(colCount + 39).ToString();
                //set info công ty, cửa hàng , tiêu đề,từ ngày đến ngày và header
                SetDataInfo(xlSheet, merge, colCount);
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                    xlSheet.Cells[ROW_TITLE, i + 2] = dt.Columns[i].ColumnName.ToUpper();
                //dien cot stt
                xlSheet.Cells[ROW_TITLE, 1] = COL_IDENTITY;
                //dien du lieu vao sheet
                //object[,] obj = new object[rowCount, colCount + 1];
                string finalColLetter = "";
                string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int colCharsetLen = colCharset.Length;
                /*for (i = 0; i < rowCount; i++)
                {
                    if (_BackgroundWorker.CancellationPending == true)
                        return;
                    //gán giá trị process
                    decimal t = i * 100 / dt.Rows.Count;
                    if (i == dt.Rows.Count - 1)
                        t = 100;
                    int pCess = int.Parse(Math.Round(t, 0).ToString());
                    _BackgroundWorker.ReportProgress(pCess);
                    //điền cột stt
                    //xlSheet.Cells[i + ROW_DATA, 1] = i + 1;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Name = "Times New Roman";
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Font.Size = 9;
                    //((Excel.Range)xlSheet.Cells[i + ROW_DATA, 1]).Borders.Value = 1;
                    obj[i, 0] = i + 1;
                    // gán dữ liệu export
                    for (j = 0; j < colCount; j++)
                    {
                        string value = (dt.Rows[i][j] != null) ? dt.Rows[i][j].ToString() : "";
                        //if (Conversion.IsNumber(value.Trim()) && Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "#,##";
                        //else
                        //    ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).NumberFormat = "@";


                        //xlSheet.Cells[i + ROW_DATA, j + 2] = value;
                        //SetStyleRank(((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]));
                        obj[i, j + 1] = value;
                    }
                    //autofit độ rộng cho các cột 
                    //((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();
                }
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                /*finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj;
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));*/
                object[] obj = getValue(dt);
                for (j = 0; j < colCount; j++)
                {
                    finalColLetter = "";
                    if (j + 1 > colCharsetLen)
                    {
                        int idx = (j + 1) / (colCharsetLen) - 1;
                        finalColLetter = colCharset.Substring(idx, 1);
                    }
                    finalColLetter += colCharset.Substring((j + 1) % colCharsetLen, 1);
                    if (Conversion.IsColumnNumber(dt.Columns[j]))// nếu là số thì định dạng lại cell                        
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "#,##";
                    else if (dt.Columns[j].DataType.FullName.ToLower().Contains("date"))
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "dd/MM/yyyy HH:mm:ss";
                    else
                        xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).NumberFormat = "@";

                    xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA + rowCount - 1), missValue).Value2 = obj[j + 1];
                }
                finalColLetter = "A";
                xlSheet.get_Range(String.Format(finalColLetter + (ROW_DATA  ).ToString() + ":{0}{1}",
                            finalColLetter, ROW_DATA  + rowCount - 1), missValue).Value2 = obj[0];
                finalColLetter = "";
                if (colCount + 1 > colCharsetLen)
                {
                    int idx = (colCount) / (colCharsetLen) - 1;
                    finalColLetter = colCharset.Substring(idx, 1);
                }
                finalColLetter += colCharset.Substring((colCount) % colCharsetLen, 1);
                xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue).EntireColumn.AutoFit();
                SetStyleRank(xlSheet.get_Range(String.Format("A" + (ROW_DATA).ToString() + ":{0}{1}",
                    finalColLetter, ROW_DATA + rowCount - 1), missValue));

                Excel.Range rowSum = xlSheet.get_Range(Convert.ToChar(3 + 66) + ROW_DATA.ToString(), cEnd + ROW_DATA.ToString());
                rowSum.Select();
                rowSum.Font.Size = 10;
                rowSum.Interior.ColorIndex = 40;
                rowSum.RowHeight = 17;
                rowSum.Borders.Value = 1;
                rowSum.Font.Bold = true;

                Excel.Range rowSum1 = xlSheet.get_Range(Convert.ToChar(3 + 66) + (ROW_DATA + rowCount - 1).ToString(), cEnd + (ROW_DATA + rowCount - 1).ToString());
                rowSum1.Select();
                rowSum1.Font.Size = 10;
                rowSum1.Interior.ColorIndex = 40;
                rowSum1.RowHeight = 17;
                rowSum1.Borders.Value = 1;
                rowSum1.Font.Bold = true;

                //get path rank
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;
                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportToExcel': " + ex.Message);
            }
        }
        private object[] getValue(DataTable dt)
        {
            int col, row;
            col = dt.Columns.Count;
            row = dt.Rows.Count;
            object[] re = new object[col + 1];
            int[,] stt = new int[row,1];
            for (int i = 0; i < col; i++)
            {
                if (_BackgroundWorker.CancellationPending == true)
                    return re;
                //gán giá trị process
                decimal t = i * 100 / dt.Columns.Count;
                if (i == dt.Columns.Count - 1)
                    t = 100;
                int pCess = int.Parse(Math.Round(t, 0).ToString());
                _BackgroundWorker.ReportProgress(pCess);
                object[,] iV = null;
                string[,] sV = null;
                if (Conversion.IsColumnNumber(dt.Columns[i])
                    || dt.Columns[i].DataType.FullName.ToLower().Contains("date"))
                    iV = new object[row,1];
                else
                    sV = new string[row,1];
                for (int j = 0; j < row; j++)
                {
                    if (iV != null)
                    {
                        iV[j,0] = (dt.Rows[j][i] != null) ? dt.Rows[j][i].ToString() : "";
                    }
                    else
                    {
                        sV[j,0] = (dt.Rows[j][i] != null) ? dt.Rows[j][i].ToString() : "";
                    }
                    if(i==0) stt[j,0] = j + 1;
                }
                re[i + 1] = iV == null ? sV : iV;
            }
            re[0] = stt;
            return re;
        }
        private object[] getValue(DataGridView dt)
        {
            int col, row;
            col = dt.ColumnCount;
            row = dt.RowCount;
            object[] re = new object[col + 1];
            object[,] stt = new object[row, 1];
            DataTable dtTemp = (DataTable)dt.DataSource;
            for (int i = 0; i < col; i++)
            {
                if (_BackgroundWorker.CancellationPending == true)
                    return re;
                //gán giá trị process
                decimal t = i * 100 / dt.Columns.Count;
                if (i == dt.Columns.Count - 1)
                    t = 100;
                int pCess = int.Parse(Math.Round(t, 0).ToString());
                _BackgroundWorker.ReportProgress(pCess);
                object[,] iV = null;
                string[,] sV = null;
                if (Conversion.IsColumnNumber(dtTemp.Columns[dt.Columns[i].DataPropertyName])
                    || dtTemp.Columns[dt.Columns[i].DataPropertyName].DataType.FullName.ToLower().Contains("date"))
                    iV = new object[row, 1];
                else
                    sV = new string[row, 1];
                for (int j = 0; j < row; j++)
                {
                    string value = (dt.Rows[j].Cells[i].Value != null) ? dt.Rows[j].Cells[i].Value.ToString() : "";
                    if (iV != null)
                    {
                        iV[j, 0] = value;
                    }
                    else
                    {
                        sV[j, 0] = value;
                    }
                    if (i == 0) stt[j, 0] = j + 1;
                }
                re[i + 1] = iV == null ? sV : iV;
            }
            re[0] = stt;
            return re;
        }
        #endregion

        #region public method
        /// <summary>
        /// Người tạo Luannv – 23/10/2013 : Gọi sự kiện xử lý export .
        /// </summary>
        public void ExportExcels()
        {
            try
            {
                if (_BackgroundWorker.IsBusy != true)
                {
                    _BackgroundWorker.RunWorkerAsync();
                    progressExcel = new frmProgressBar();
                    progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundWorker_Cancel);
                    progressExcel.StartPosition = FormStartPosition.CenterScreen;
                    progressExcel.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Xử lý export mẫu excel .
        /// </summary>
        public void ExportSample(DataTable dt, string fileName)
        {
            try
            {
                // Kiểm tra file sample đã tồn tại chưa
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;

                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                //FileInfo fi = new FileInfo(path);
                //if (fi.Exists)
                //    OpenFile(path);
                //else
                //{
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                xlSheet.Name = "Import";

                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int i;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A1", Convert.ToChar(colCount + 64) + "1");
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlLeft;
                header.VerticalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.RowHeight = 20;
                header.Interior.ColorIndex = 15;
                header.Borders.Value = 1;
                header.Font.Name = "Times New Roman";
                // row mẫu
                Excel.Range rSample = xlSheet.get_Range("A2", Convert.ToChar(colCount + 64) + "2");
                header.Select();

                rSample.HorizontalAlignment = Excel.Constants.xlLeft;
                rSample.Font.Bold = true;
                rSample.Font.Size = 10;
                rSample.RowHeight = 18;
                rSample.Borders.Value = 1;
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                    xlSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                //autofit độ rộng cho các cột 
                for (i = 0; i < colCount; i++)
                    ((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();

                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);
                //}

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportSample': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/11/2013 : Xử lý export mẫu excel .
        /// </summary>
        public void ExportSampleAndData(DataTable dt, string fileName)
        {
            try
            {
                // Kiểm tra file sample đã tồn tại chưa
                string foder = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string direct = CreateFoder(foder, DEFAULT_FORDER);
                string path = direct + "\\" + fileName;

                if (File.Exists(path))
                {
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                //FileInfo fi = new FileInfo(path);
                //if (fi.Exists)
                //    OpenFile(path);
                //else
                //{
                //khoi tao cac doi tuong Com Excel de lam viec
                Excel.Application xlApp;
                Excel.Worksheet xlSheet;
                Excel.Workbook xlBook;
                //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
                object missValue = System.Reflection.Missing.Value;
                //khoi tao doi tuong Com Excel moi
                xlApp = new Excel.Application();
                xlBook = xlApp.Workbooks.Add(missValue);
                //su dung Sheet dau tien de thao tac
                xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
                //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
                xlApp.Visible = false;
                // các biến số dòng số cột
                int colCount = dt.Columns.Count;
                int rowCount = dt.Rows.Count;
                int i, j;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A1", Convert.ToChar(colCount + 64) + "1");
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlLeft;
                header.VerticalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.RowHeight = 20;
                header.Interior.ColorIndex = 15;
                header.Borders.Value = 1;
                header.Font.Name = "Times New Roman";
                // row mẫu
                Excel.Range rSample = xlSheet.get_Range("A2", Convert.ToChar(colCount + 64) + "2");
                rSample.Select();

                rSample.HorizontalAlignment = Excel.Constants.xlLeft;
                rSample.Font.Bold = true;
                rSample.Font.Size = 10;
                rSample.RowHeight = 18;
                rSample.Borders.Value = 1;
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < colCount; i++)
                    xlSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                //dien du lieu vao sheet
                for (i = 0; i < rowCount; i++)
                    for (j = 0; j < colCount; j++)
                    {
                        xlSheet.Cells[i + ROW_DATA, j + 2] = dt.Rows[i][j];
                        ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).Font.Name = "Times New Roman";
                        ((Excel.Range)xlSheet.Cells[i + ROW_DATA, j + 2]).Font.Size = 9;
                    }
                //autofit độ rộng cho các cột 
                for (i = 0; i < colCount; i++)
                    ((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();

                //save file
                xlBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlApp.Quit();


                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                // mở file excel vừa tạo
                OpenFile(path);
                //}

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportSampleAndData': " + ex.Message);
            }
        }
        #endregion

        #endregion
    }
}

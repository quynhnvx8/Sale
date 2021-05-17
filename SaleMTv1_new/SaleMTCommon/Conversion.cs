using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/// <summary>
/// Created by Luannv – 20/09/2013: All functions conversion of the data type.
/// </summary>

namespace SaleMTCommon
{
    public class Conversion
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        #region Constructors
        public Conversion()
        {

        }
        #endregion

        #region Conversion Methods

        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }  

        public static string NumFormat(int de)
        {
            string re = ".";
            for (int i = 2; i < de && i <= 9; i++)
            {
                re += "#";
            }
            re = de == 0 ? "" : re + "0";
            return re + "0";
        }
        public static bool IsNumber(string pText)
        {
            bool t = false;
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                t = regex.IsMatch(pText);
            }
            catch
            {
                t = false;
            }
            return t;
        }
        public static bool IsColumnNumber(DataColumn column)
        {
            bool t = false;
            try
            {
                if (column.DataType == typeof(double) || column.DataType == typeof(int) || column.DataType == typeof(decimal))
                    t = true;
            }
            catch
            {
                t = false;
            }
            return t;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Conversion string to datetime returns datetime.
        /// </summary>        
        public static DateTime stringToDateTime(string sDate)
        {
            CultureInfo customCulture = CultureInfo.CreateSpecificCulture("vi-VN");
            DateTime date = DateTime.Now;
            try
            {
                if (sDate != "")
                {
                    date = Convert.ToDateTime(sDate, customCulture);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'stringToDateTime': " + ex.Message);
            }
            return date;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Replace chuỗi số tiền có các ký tự '.' hoặc ',' thành chuỗi số.
        /// </summary>        
        public static string Replaces(string str)
        {
            try
            {
                str = str.Replace(",", "").Replace(".", "");
            }
            catch (Exception ex)
            {
                log.Error("Error 'Replaces': " + ex.Message);
            }
            return str;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Convert chuỗi số thành chuỗi số tiền có dấu phân cách.
        /// </summary> 
        public static string GetCurrency(string money)
        {
            string mReturn = "";
            try
            {
                if (money.Trim().Length > 0)
                {
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    mReturn = double.Parse(money).ToString("###,###,###,###,###", cul.NumberFormat);
                }
                mReturn = (mReturn.Length > 0) ? mReturn : "0";
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetCurrency': " + ex.Message);
            }
            return mReturn;
        }
        /// <summary>
        /// Created by thanhnh – 20/09/2013: Đọc số tiền bằng chữ.
        /// </summary> 
        public static string ToString(double number)
        {
            string str = " ";
            try
            {
                string s = number.ToString("#");
                string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
                int i, j, donvi, chuc, tram;

                bool booAm = false;
                double decS = 0;
                //Tung addnew
                try
                {
                    decS = Convert.ToDouble(s.ToString());
                }
                catch
                {
                }
                if (decS < 0)
                {
                    decS = -decS;
                    s = decS.ToString();
                    booAm = true;
                }
                i = s.Length;
                if (i == 0)
                    str = so[0] + str;
                else
                {
                    j = 0;
                    while (i > 0)
                    {
                        donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                        i--;
                        if (i > 0)
                            chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                        else
                            chuc = -1;
                        i--;
                        if (i > 0)
                            tram = Convert.ToInt32(s.Substring(i - 1, 1));
                        else
                            tram = -1;
                        i--;
                        if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                            str = hang[j] + str;
                        j++;
                        if (j > 3) j = 1;
                        if ((donvi == 1) && (chuc > 1))
                            str = "một " + str;
                        else
                        {
                            if ((donvi == 5) && (chuc > 0))
                                str = "lăm " + str;
                            else if (donvi > 0)
                                str = so[donvi] + " " + str;
                        }
                        if (chuc < 0)
                            break;
                        else
                        {
                            if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                            if (chuc == 1) str = "mười " + str;
                            if (chuc > 1) str = so[chuc] + " mươi " + str;
                        }
                        if (tram < 0) break;
                        else
                        {
                            if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                        }
                        str = " " + str;
                    }
                }
                if (booAm) str = "Âm " + str;
                str = str + "đồng chẵn";
            }
            catch (Exception ex)
            {
                log.Error("Error 'ToString': " + ex.Message);
            }
            return str;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Chuyển chuỗi có dấu thành không dấu.
        /// </summary> 
        public static string ConvertVN(string strVN)
        {
            try
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = strVN.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(strVN[index]);
                    strVN = strVN.Replace(strVN[index], ReplText[index2]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ConvertVN': " + ex.Message);
            }
            return strVN;
        }
        /// <summary>
        /// Created by huynv – 20/09/2013: Chuyển chuỗi có dấu thành không dấu.
        /// </summary> 
        public static string GetDateFormat(DateTime date)
        {
            string mReturn = "";
            try
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                mReturn = date.ToString("yyyy/MM/dd", cul.DateTimeFormat);

            }
            catch (Exception ex)
            {
                log.Error("Error 'GetDateFormat': " + ex.Message);
            }
            return mReturn;
        }
        /// <summary>
        /// Lấy ra ngày đầu tiên trong tháng có chứa 
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtDate">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            try
            {
                dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetDateFormat': " + ex.Message);
            }
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            try
            {
                int year = dtInput.Year;
                int month = dtInput.Month;
                dtResult = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetDateFormat': " + ex.Message);
            }
            return dtResult;
        }
        /// <summary>
        /// Người tạo Luannv - 06/11/2013 : Convert DataGridView to Datatable
        /// </summary>
        public static DataTable ConvertDataGridVewToDataTable(DataGridView dgv)
        {
            DataTable dtFinal = new DataTable();
            try
            {
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    dtFinal.Columns.Add(dgv.Columns[i].HeaderText.ToUpper(), System.Type.GetType("System.String"));
                }
                for (int j = 0; j <= dgv.RowCount - 1; j++)
                {
                    DataRow dr = dtFinal.NewRow();
                    for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                    {
                        dr[i] = dgv.Rows[j].Cells[i].Value;
                    }
                    dtFinal.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'ConvertDataGridVewToDataTable': " + ex.Message);
            }
            return dtFinal;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: trả về ngày với time 00:00:00.
        /// </summary> 
        public static DateTime FirstDayTime(DateTime date)
        {
            DateTime dateStart = DateTime.Now;
            try
            {
                dateStart = Convert.ToDateTime(date.ToString("yyyy/MM/dd") + " 00:00:00");
            }
            catch (Exception ex)
            {
                log.Error("Error 'FirstDayTime': " + ex.Message);
            }
            return dateStart;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: trả về ngày với time 00:00:00.
        /// </summary> 
        public static DateTime LastDayTime(DateTime date)
        {
            DateTime dateEnd = DateTime.Now;
            try
            {
                dateEnd = Convert.ToDateTime(date.ToString("yyyy/MM/dd") + " 23:59:59");
            }
            catch (Exception ex)
            {
                log.Error("Error 'LastDayTime': " + ex.Message);
            }
            return dateEnd;
        }
        #endregion

    }

}

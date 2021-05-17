using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTCommon
{
    public class ImportEx
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Người tạo Luannv – 11/11/2013 : Lấy về  sheetname của file excel theo đúng thứ tự các sheet 
        /// </summary>
        public static List<string> GetSheet(string fileName)
        {            
            List<string> sheetlist = new List<string>();
            try
            {
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

                foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in wb.Sheets)
                {
                    sheetlist.Add(sheet.Name);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return sheetlist;
        }
    }
}

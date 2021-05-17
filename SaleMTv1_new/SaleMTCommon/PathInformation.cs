using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaleMTCommon
{
    public class PathInformation
    {
        private const string IMPORT_PATH = @"\IMPORT";
        private const string EXPORT_PATH = @"\EXPORT";
        private const string UPDATE_PATH = @"\";

        public static string getUpdatePath()
        {
            string re = Application.StartupPath + UPDATE_PATH;
            if (!Directory.Exists(re))
            {
                Directory.CreateDirectory(re);
            }
            return re;
        }
        public static string getImportPath()
        {
            string re = Application.StartupPath + IMPORT_PATH;
            if (! Directory.Exists(re)) {
                Directory.CreateDirectory(re);
            }
            return re;
        }
        public static string getExportPath()
        {
            string re = Application.StartupPath + EXPORT_PATH;
            if (!Directory.Exists(re))
            {
                Directory.CreateDirectory(re);
            }
            return re;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace SaleMT
{
    public static class LayoutLanguage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Dictionary<string, string> getLanguage()
        {
            Dictionary<string, string> data = new Dictionary<string,string>();
            String configLanguage =  ConfigurationSettings.AppSettings["Language"].ToString();
            if (configLanguage.Contains(":"))
            {
                string [] language = configLanguage.Split(':');
                configLanguage = language[0];
            }

            String fileNameFrm = "Language_" + configLanguage + ".txt";
            String fileNameRpt = "Report_" + configLanguage + ".txt";
            var CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string FileNameFrm = string.Format("{0}Resources\\" + fileNameFrm, Path.GetFullPath(Path.Combine(CurrentDirectory, "")));
            string FileNameRpt = string.Format("{0}Resources\\" + fileNameRpt, Path.GetFullPath(Path.Combine(CurrentDirectory, "")));
            
            if (!File.Exists(FileNameFrm))
            {
                //File.Create(fileNameFrm);
                log.Error("Error : Khong tìm thay file");
            }
            
            string[] allLines = File.ReadAllLines(FileNameFrm);

            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i] != null)
                {
                    string line = allLines[i];
                    if (line == null || line == "")
                        continue;
                    if (line.Contains("#") || line.Contains("//") || line.Contains("/*"))
                        continue;
                    if (line.Contains("\t"))
                    {
                        line = line.Replace("\t", "");
                    }
                    string[] str = line.Split(':');
                    data.Add(str[0].Trim(), str[1].Trim());
                }
            }

            //Add Translate report
            allLines = File.ReadAllLines(FileNameRpt);

            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i] != null)
                {
                    string line = allLines[i];
                    if (line == null || line == "")
                        continue;
                    if (line.Contains("#") || line.Contains("//") || line.Contains("/*"))
                        continue;
                    if (line.Contains("\t"))
                    {
                        line = line.Replace("\t", "");
                    }
                    string[] str = line.Split(':');
                    data.Add(str[0].Trim(), str[1].Trim());
                }
            }
            return data;
        }

      
    }
}

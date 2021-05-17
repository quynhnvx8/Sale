using System.Configuration;
using System.Xml;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SaleMTDataAccessLayer.SaleMTDAL
{
    public static class AppConfigFileSettings
    {
        private const string APP_SETTING_ELEMENT_NAME = "appSettings";
        private const int APP_SETTING_KEY_INDEX = 0;
        private const int APP_SETTING_VALUE_INDEX = 1;

        private static string debugConfigPath;

        public static void UpdateAppSettings(string keyName, string keyValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in xmlDoc.DocumentElement)
            {
                if (APP_SETTING_ELEMENT_NAME.Equals(xElement.Name))
                {
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        if (keyName.Equals(xNode.Attributes[APP_SETTING_KEY_INDEX].Value))
                        {
                            xNode.Attributes[APP_SETTING_VALUE_INDEX].Value = keyValue;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        public static void UpdateAppSettings(SortedList<string, string> appSettings)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string strConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            GetFileInDebug();
            if (debugConfigPath != null)
            {
                strConfigPath = debugConfigPath;
            }
            xmlDoc.Load(strConfigPath);
            foreach (XmlElement xElement in xmlDoc.DocumentElement)
            {
                if (APP_SETTING_ELEMENT_NAME.Equals(xElement.Name))
                {
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        foreach (var applist in appSettings)
                        {
                            if (applist.Key.Equals(xNode.Attributes[APP_SETTING_KEY_INDEX].Value))
                            {
                                xNode.Attributes[APP_SETTING_VALUE_INDEX].Value = applist.Value;
                            }
                        }
                        
                    }
                }
            }
            xmlDoc.Save(strConfigPath);
        }
        [Conditional("DEBUG")]
        private static void GetFileInDebug()
        {
            try
            {
                if (Debugger.IsAttached)
                {
                    debugConfigPath = Environment.CurrentDirectory;
                    debugConfigPath = Directory.GetParent(debugConfigPath).Parent.FullName + @"\app.config";
                }
            }
            catch (Exception)
            {

            }
        }
        
        public static NameValueCollection appSaleMTSetting = ConfigurationManager.AppSettings;
        public static string strConnectionSql;
        public static string strConnectionSync;
        public static string isPrintPreview, printerReport1, printerReport2, printerBill1, printerBill2;
        public static string strOptDate, strOptHour, strOptNumber, strOptDec, strOptCurency;
        public static string strPw,strChkPw;
        public static bool isReg;
        public static int Client_ID;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTCommon;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Net.NetworkInformation;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace SaleMTSync
{
    public class Sync
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        SaleMTSync.SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();
        private string strEndPointSync = UserImformation.WebServiceAddress;
        private string strUser = UserImformation.WebServiceUsername;
        private string strPass = UserImformation.WebServicePassword;

        string filename = "";
        UpdateProgress progressUpdate = null;
        #endregion

        public Sync()
        {
            c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
            //c.ClientCredentials.Windows.AllowNtlm = true;
            c.ClientCredentials.UserName.UserName = strUser;
            c.ClientCredentials.UserName.Password = strPass;
        }

        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Lưu XML vào thư mục Export
        /// </summary>
        public void ExportXML(string objName)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@TranferShift", UserImformation.ShiftCode);
            sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Date", sqlDac.GetDateTimeServer());
            DataTable dt = sqlDac.GetDataTable("GetXML_" + objName + "_Read", sqlPara);
            if (dt.Rows.Count > 0)
            {
                StringWriter sw = new StringWriter();
                dt.TableName = objName;
                dt.WriteXml(sw);
                string s = sw.ToString();
                string filepath = PathInformation.getExportPath() + "\\" + UserImformation.DeptCode + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";
                //string filepath = PathInformation.getExportPath() + "\\" + "123ABC" + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";

                s = s.Replace("DocumentElement", ToLowerFirstLetter(objName) + "Xml");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(s);
                doc.Save(filepath);
            }
        }
        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Upload XML lên server
        /// </summary>
        public bool UploadXML(string fileName)
        {
            if (File.Exists(fileName))
            {
                Byte[] fileContent = File.ReadAllBytes(fileName);
                MemoryStream mStream = new MemoryStream(fileContent);

                string objName = "";
                using (XmlReader reader = XmlReader.Create(mStream))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            objName = reader.Name;
                            break;
                        }
                    }
                }

                fileName = Path.GetFileName(fileName);
                objName = ToUpperFirstLetter(objName.Replace("Xml", ""));

                //return c.uploadFile("123ABC", objName, fileName, fileContent, null);
                c.uploadFile(UserImformation.DeptCode, objName, fileName, fileContent, null);
                return true;
            }
            else
                return false;
        }

        private string getMac()
        {
            string re = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in nics)
            {
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                        nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                nic.OperationalStatus == OperationalStatus.Up)
                {
                    re = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return re;
        }
        private static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        private string ToLowerFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToLower(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
        private string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        public void CheckUpdate()
        {
            //Tạm thời bỏ check update này
            /*
            try
            {
                string ver = File.Exists(Application.StartupPath + @"\version.txt") ? File.ReadAllText(Application.StartupPath + @"\version.txt").Trim() : "1.0";
                string[] version = c.getLastVersion(ver);
                if (version != null && version.Length == 4 && version[0] == "True")
                {
                    var result = MessageBox.Show("A new version of SaleMT is available!" + Environment.NewLine + "Do you want to update now?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.OK)
                    {                        
                        string url = version[3];
                        string file = PathInformation.getUpdatePath() + Path.GetFileName(url);
                        if(File.Exists(file))
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            File.Delete(file);
                        }
                        //SortedList<string, string> appSetting = new SortedList<string, string>();
                        //appSetting.Add("Version", version[1]);
                        //AppConfigFileSettings.UpdateAppSettings(appSetting);

                        filename = Path.GetFileName(url);
                        WebClient wClient = new WebClient();
                        wClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.wClient_DownloadFileCompleted);
                        wClient.DownloadProgressChanged +=new DownloadProgressChangedEventHandler(this.wClient_DownloadProgressChanged);
                        wClient.DownloadFileAsync(new Uri(url.Replace("localhost", "192.168.1.89")), file);
                        progressUpdate = new UpdateProgress();
                        progressUpdate.StartPosition = FormStartPosition.CenterScreen;
                        progressUpdate.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckUpdate' : " + ex.Message);
            }
            */
        }

        private void wClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            progressUpdate.Close();

            if (e.Error == null)
            {
                string ApplicationPath = PathInformation.getUpdatePath() + "Updater.exe";
                string ApplicationArguments = filename;
                //ApplicationArguments = "Debug.rar";

                // Create a new process object
                Process ProcessObj = new Process();

                // StartInfo contains the startup information of
                // the new process
                ProcessObj.StartInfo.FileName = ApplicationPath;
                ProcessObj.StartInfo.Arguments = ApplicationArguments;

                // These two optional flags ensure that no DOS window
                // appears
                ProcessObj.StartInfo.UseShellExecute = false;
                ProcessObj.StartInfo.CreateNoWindow = true;

                // If this option is set the DOS window appears again :-/
                // ProcessObj.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // This ensures that you get the output from the DOS application
                //ProcessObj.StartInfo.RedirectStandardOutput = true;

                // Start the process
                ProcessObj.Start();
                Process.GetCurrentProcess().Kill();
            }

        }
        private void wClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressUpdate.Progress = int.Parse(Math.Truncate(percentage).ToString());
            //progressUpdate.Progress = e.ProgressPercentage;
        }

    }
}

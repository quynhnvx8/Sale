using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace SaleMTSync
{
    /// <summary>
    /// Người tạo Thanvn – 18/11/2013 : Form xử lý, hiển thị việc đồng bộ.
    /// Chạy khi cùng form Main sau khi đăng nhập.
    /// Sử dụng SOAP webservice và http client.
    /// </summary>
    public partial class frmSync : Form
    {
        public frmSync()
        {
            InitializeComponent();
        }
        #region Declaration
        //private string strEndPointSync = "http://192.168.1.88:8080/GetExportDataWs";
        private string strEndPointSync = UserImformation.WebServiceAddress;
        private string strUser = UserImformation.WebServiceUsername;
        private string strPass = UserImformation.WebServicePassword;
        //private string strUser = "vinamilk";
        //private string strPass = "123456@";
        //private string fileName= @"\test.xml";
        private bool completed = true;
        private int t;
        private bool firstDL =true;
        private bool contDL = false;
        private int countDL = 0;
        List<XMLObject> listXML = new List<XMLObject>();
        List<XMLObject> deleteXML = new List<XMLObject>();
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();                
        #endregion
        
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Khai báo địa chỉ server đồng bộ
        /// </summary>
        public string EndPointSync
        {
            set { value = strEndPointSync; }
            get { return strEndPointSync; }
        }
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Khai báo User truy cập server đồng bộ
        /// </summary>
        public string UserSync
        {
            set { value = strUser; }
            get { return strUser; }
        }
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Khai báo mật khẩu truy cập server đồng bộ
        /// </summary>
        public string PasswordSync
        {
            set { value = strPass; }
            get { return strPass; }
        }        
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Lấy địa chỉ MAC của client
        /// </summary>
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
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Test đồng bộ.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bgWorkerGetupdate.IsBusy != true && completed == true)
                {
                    txtLog.Text = "";
                    bgWorkerGetupdate.RunWorkerAsync();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Download xml từ server.
        /// </summary>
        private WebClient wClient;        
        private void downloadXml(string url,string objName)
        {
            try
            {
                string fileName = "\\" + Path.GetFileName(url);
                string filePath = PathInformation.getImportPath() + "\\" + objName;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (File.Exists(filePath + fileName))
                {
                    File.SetAttributes(filePath + fileName, FileAttributes.Normal);
                    File.Delete(filePath + fileName);
                }

                wClient = new System.Net.WebClient();
                wClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.wClient_DownloadFileCompleted);
                wClient.DownloadFileAsync(new Uri(url.Replace("localhost", "192.168.1.89")), filePath + fileName);
            }
            catch (Exception ex)
            {
                log.Error("Error 'downloadXml' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Xử lý gọi lệnh xóa file từ webservice sau khi download xong.
        /// </summary>
        private void wClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                contDL = true;
                countDL += 1;
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Downloading: " + countDL + " file completed"); });
                //txtLog.Text += Environment.NewLine + ">Downloading: " + countDL + " file completed";
                if (e.Error == null)
                {
                    deleteXML.Add(listXML[0]);
                }
                listXML.RemoveAt(0);
                if (listXML.Count > 0)
                {
                    var xmlObj = listXML[0];
                    downloadXml(xmlObj.FileName, xmlObj.ObjName);
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Download Completed"); });
                    if (deleteXML.Count > 0)
                    {
                        //SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();
                        //c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
                        //c.ClientCredentials.Windows.AllowNtlm = true;
                        //c.ClientCredentials.UserName.UserName = strUser;
                        //c.ClientCredentials.UserName.Password = strPass;

                        this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Delete request sent: "+deleteXML.Count.ToString()+" files"); });
                        
                        string[] objArray = new string[] { "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice","CategoryData" };
                        foreach (string objName in objArray)
                        {
                            List<string> fileList = new List<string>();
                            foreach (XMLObject xmlObj in deleteXML)
                            {
                                if (xmlObj.ObjName == objName)
                                    fileList.Add(Path.GetFileName(xmlObj.FileName));
                            }
                            if (fileList.Count > 0)
                            {
                                string[] fileArray = fileList.ToArray();
                                try
                                {
                                    c.deleteFile(UserImformation.DeptCode, objName, fileArray, getMac());
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Error 'ImportXML' : " + ex.Message);
                                }
                            }
                        }
                    }
                    ImportXML();
                    Export();
                    completed = true;
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'wClient_DownloadFileCompleted' : " + ex.Message);
            }
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void Export()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + "---------"); });
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Export Begin"); });

                string[] objArray = new string[] { "ExportDetail", "ExportProducts", "ExportProductStore", "ExportProductStoreDetail", "ItemReturnDetail", "SalePromotion", "SalePromotionGifts", "SalesExportItems", "SalesExport", "ItemReturn", "InventoryTemp", "Customers", "OrderProductDetail", "OrderProducts" };
                foreach (string objName in objArray)
                {
                    ExportXML(objName);
                }
                string[] xmlFiles = System.IO.Directory.GetFiles(PathInformation.getExportPath(), "*.xml");
                foreach (string file in xmlFiles)
                {
                    if (UploadXML(file))
                    {
                        File.Delete(file);
                        this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Upload file: " + Path.GetFileName(file)); });
                    }
                }

                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Export Completed"); });
            }
            catch (Exception ex)
            {
                log.Error("Error 'Export' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Lưu XML vào thư mục Export
        /// </summary>
        private void ExportXML(string objName)
        {
            try
            {
                SqlParameter[] sqlPara = new SqlParameter[2];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@TranferShift", UserImformation.ShiftCode);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Date", sqlDac.GetDateTimeServer());
                DataTable dt = sqlDac.GetDataTable("GetXML_" + objName + "_Read", sqlPara);
                if (dt.Rows.Count > 0)
                {
                    //StringWriter sw = new StringWriter();
                    //dt.TableName = objName;
                    //dt.WriteXml(sw);
                    //string s = sw.ToString();
                    //string filepath = PathInformation.getExportPath() + "\\" + UserImformation.DeptCode + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";
                    ////string filepath = PathInformation.getExportPath() + "\\" + "123ABC" + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";

                    //s = s.Replace("DocumentElement", ToLowerFirstLetter(objName) + "Xml");
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(s);
                    //doc.Save(filepath);

                    //string sqlQuery = "insert into SyncTimestamp values (@SyncObjectName,@SyncDateTime)";
                    //sqlPara = new SqlParameter[2];
                    //sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SyncObjectName", objName);
                    //sqlPara[1] = posdb_vnmSqlDAC.newInParam("@SyncDateTime", sqlDac.GetDateTimeServer());                    
                    //sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);

                    //this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Export file: " + Path.GetFileName(filepath)); });

                    if (dt.Rows.Count <= 5000)
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
                        //doc.Save(filepath);

                        using (TextWriter tw = new StreamWriter(filepath, false, Encoding.UTF8)) //Set encoding
                        {
                            doc.Save(tw);
                        }

                        string sqlQuery = "insert into SyncTimestamp values (@SyncObjectName,@SyncDateTime)";
                        sqlPara = new SqlParameter[2];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SyncObjectName", objName);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@SyncDateTime", sqlDac.GetDateTimeServer());
                        sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);

                        this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Export file: " + Path.GetFileName(filepath)); });
                    }
                    else
                    {
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {                            
                            DataTable dt2 = dt.Clone();
                            dt.AsEnumerable().Skip(i).Take(5000).CopyToDataTable(dt2,LoadOption.OverwriteChanges);
                            i += 5000;

                            StringWriter sw = new StringWriter();
                            dt2.TableName = objName;
                            dt2.WriteXml(sw);
                            string s = sw.ToString();
                            string filepath = PathInformation.getExportPath() + "\\" + UserImformation.DeptCode + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";
                            //string filepath = PathInformation.getExportPath() + "\\" + "123ABC" + "_" + objName + "_" + (sqlDac.GetDateTimeServer() - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString() + ".xml";

                            s = s.Replace("DocumentElement", ToLowerFirstLetter(objName) + "Xml");
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(s);
                            //doc.Save(filepath);

                            using (TextWriter tw = new StreamWriter(filepath, false, Encoding.UTF8)) //Set encoding
                            {
                                doc.Save(tw);
                            }

                            string sqlQuery = "insert into SyncTimestamp values (@SyncObjectName,@SyncDateTime)";
                            sqlPara = new SqlParameter[2];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SyncObjectName", objName);
                            sqlPara[1] = posdb_vnmSqlDAC.newInParam("@SyncDateTime", sqlDac.GetDateTimeServer());
                            sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);

                            this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Export file: " + Path.GetFileName(filepath)); });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportXML' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Upload XML lên server
        /// </summary>
        private bool UploadXML(string fileName)
        {
            bool b = false;
            try
            {
                if (File.Exists(fileName))
                {
                    Byte[] fileContent = File.ReadAllBytes(fileName);

                    //XmlDocument xmlDoc = new XmlDocument();
                    MemoryStream mStream = new MemoryStream(fileContent);
                    //xmlDoc.Load(mStream);

                    //StringWriter sw = new StringWriter();
                    //XmlTextWriter tw = new XmlTextWriter(sw);
                    //xmlDoc.WriteTo(tw);
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

                    //SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();
                    //c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
                    //c.ClientCredentials.Windows.AllowNtlm = true;
                    //c.ClientCredentials.UserName.UserName = strUser;
                    //c.ClientCredentials.UserName.Password = strPass;

                    //return c.uploadFile("123ABC", objName, fileName, fileContent, null);
                    b = c.uploadFile(UserImformation.DeptCode, objName, fileName, fileContent, getMac());
                    //b = c.uploadFile(UserImformation.DeptCode, objName, fileName, fileContent, null);
                    //b = true;
                }
                else
                    b = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'UploadXML' : " + ex.Message);
            }
            return b;
        }
        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Download XML từ server
        /// </summary>
        private void DownloadXML()
        {
            firstDL = true;
            contDL = false;
            countDL = 0;
            this.Invoke((MethodInvoker)delegate() { SetLog(">Download Begin"); });
            //txtLog.Text = ">Download Begin";

            //SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();
            //c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
            //c.ClientCredentials.Windows.AllowNtlm = true;
            //c.ClientCredentials.UserName.UserName = strUser;
            //c.ClientCredentials.UserName.Password = strPass;

            string[] objArray = new string[] { "Product", "Price", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice" };

            foreach (string objName in objArray)
            {
                List<string> fileList = new List<string>();
                SaleMTSync.SaleOnline.synObject[] res = c.getUpdateData("TEST", objName, getMac());               
                foreach (SaleMTSync.SaleOnline.synObject re in res)
                {
                    //downloadXml(re.fileName, objName);
                    //fileList.Add(Path.GetFileName(re.fileName));
                    while (true)
                    {
                        if (firstDL == true || contDL == true)
                        {
                            firstDL = false;
                            contDL = false;
                            downloadXml(re.fileName, objName);
                            fileList.Add(Path.GetFileName(re.fileName));
                            break;
                        }
                    }
                }
                while (true)
                {
                    if (contDL == true)
                    {
                        string[] fileArray = fileList.ToArray();
                        //c.deleteFile(UserImformation.DeptCode, objName, fileArray, getMac());
                        break;
                    }
                }
            }
            this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Download Completed"); });
            //txtLog.Text += Environment.NewLine + ">Download Completed";
        }
        /// <summary>
        /// Người tạo thanhd – 20/11/2013 : Lưu XML vào database
        /// </summary>
        private void ImportXML()
        {
            try
            {
                bool promo = false;
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + "---------"); });
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Import Begin"); });
                //txtLog.Text += Environment.NewLine + ">Import Begin";
                string[] objArray = new string[] { "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice","CategoryData" };

                foreach (string objName in objArray)
                {
                    string folderPath = PathInformation.getImportPath() + "\\" + objName;
                    if (Directory.Exists(folderPath))
                    {
                        string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");
                        //Edit always delete temp tables >=
                        if (xmlFiles.Length >= 0)
                        {
                            string sqlQuery = "delete from SaleOnline_" + objName;
                            if (objName == "MTPrice")
                            {
                                sqlQuery = "delete from SaleOnline_MTPrice where productCode in (select PRODUCT_ID from PRODUCTS)";
                            }
                            sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, null);
                            if (objName == "PromotionProgram")
                            {
                                promo = true;
                            }
                        }
                        foreach (string filePath in xmlFiles)
                        {
                            try
                            {
                                byte[] fileContent = ReadFile(filePath);
                                MemoryStream mStream = new MemoryStream(fileContent);
                                //string sXML = "";
                                //using (StreamReader reader = new StreamReader(mStream))
                                //{
                                //    sXML = reader.ReadToEnd();
                                //}                                

                                DataSet ds = new DataSet();
                                ds.ReadXml(mStream);                                
                                //ds.ReadXml(new StringReader(SanitizeXmlString(sXML)));
                                
                                string dtn = ds.Tables[0].TableName;
                                sqlDac.Copy_To_ClientDB(ds.Tables[0], "SaleOnline_" + objName);
                                File.Delete(filePath);
                                mStream.Close();
                            }
                            catch (Exception ex)
                            {
                                log.Error("Error 'ReadnSave XML' : " + ex.Message);
                            }
                        }
                    }
                }
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Import Completed"); });
                //txtLog.Text += Environment.NewLine + ">Import Completed";

                SqlParameter[] sqlPara;

                sqlPara = new SqlParameter[1] { posdb_vnmSqlDAC.newInParam("@StoreCode", UserImformation.DeptCode) };
                sqlDac.Execute("SyncFromTempToData", sqlPara);

                if (promo == true)
                {
                    string sqlQuery = "insert into SyncTimestamp values (@SyncObjectName,@SyncDateTime)";
                    sqlPara = new SqlParameter[2];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SyncObjectName", "Promotions");
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@SyncDateTime", sqlDac.GetDateTimeServer());
                    sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'ImportXML' : " + ex.Message);
            }
        }
        public static byte[] ReadFile(string filePath)
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
        private void SetLog(string log)
        {
            txtLog.Text += log;
            txtLog.Select(txtLog.Text.Length, 0);
            txtLog.ScrollToCaret();
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
        private void DownloadXMLQueue()
        {
            try
            {
                completed = false;
                //SaleOnline.GetExportDataWsClient c = new SaleMTSync.SaleOnline.GetExportDataWsClient();
                //c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
                //c.ClientCredentials.Windows.AllowNtlm = true;
                //c.ClientCredentials.UserName.UserName = strUser;
                //c.ClientCredentials.UserName.Password = strPass;

                string[] objArray = new string[] { "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice", "CategoryData" };
                listXML.Clear();
                deleteXML.Clear();
                countDL = 0;
                foreach (string objName in objArray)
                {
                    List<string> fileList = new List<string>();
                    SaleMTSync.SaleOnline.synObject[] res = c.getUpdateData(UserImformation.DeptCode, objName, getMac());
                    foreach (SaleMTSync.SaleOnline.synObject re in res)
                    {
                        XMLObject xmlObj = new XMLObject();
                        xmlObj.FileName = re.fileName;                        
                        xmlObj.ObjName = objName;
                        listXML.Add(xmlObj);
                    }
                }
                if (listXML.Count > 0)
                {
                    this.Invoke((MethodInvoker)delegate() { SetLog(">Download Begin"); });

                    var xmlObj = listXML[0];
                    downloadXml(xmlObj.FileName, xmlObj.ObjName);
                }
                else
                {
                    ImportXML();
                    Export();
                    completed = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'DownloadXMLQueue' : " + ex.Message);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal == this.WindowState ? FormWindowState.Minimized : FormWindowState.Normal;
            this.Activate();
        }
        /// <summary>
        /// Người tạo Thanvn – 18/11/2013 : Xử lý luồng đồng bộ.
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //DownloadXMLQueue();


                ////Export();
                ImportXML();
            }
            catch (Exception ex)
            {
                log.Error(" Error 'Worker getupdate': " + ex.Message);
            }
        }

        private void frmSync_Load(object sender, EventArgs e)
        {
            c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
            c.ClientCredentials.Windows.AllowNtlm = true;
            c.ClientCredentials.UserName.UserName = strUser;
            c.ClientCredentials.UserName.Password = strPass;           

            if (UserImformation.OpenSynData == true)
            {
                t = int.Parse(UserImformation.SysDataAfter);
                syncTimer.Start();
            }
                        
        }

        private void bgWorkerGetupdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            t--;
            if (t == 0)
            {
                //txtLog.Text = "";
                //DownloadXMLQueue();
                //Export();
                if (bgWorkerGetupdate.IsBusy != true && completed == true)
                {
                    txtLog.Text = "";
                    bgWorkerGetupdate.RunWorkerAsync();
                }
                t = int.Parse(UserImformation.SysDataAfter);
            }            
        }

        public string SanitizeXmlString(string xml)
        {
            StringBuilder buffer = new StringBuilder(xml.Length);

            foreach (char c in xml)
            {
                if (IsLegalXmlChar(c))
                {
                    buffer.Append(c);
                }
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Whether a given character is allowed by XML 1.0.
        /// </summary>
        public bool IsLegalXmlChar(int character)
        {
            return
            (
                 character == 0x9 /* == '\t' == 9   */          ||
                 character == 0xA /* == '\n' == 10  */          ||
                 character == 0xD /* == '\r' == 13  */          ||
                (character >= 0x20 && character <= 0xD7FF) ||
                (character >= 0xE000 && character <= 0xFFFD) ||
                (character >= 0x10000 && character <= 0x10FFFF)
            );
        }

    }

    public class XMLObject
    {
        private string fileName;
        private string objName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public string ObjName
        {
            get { return objName; }
            set { objName = value; }
        }
    }
}

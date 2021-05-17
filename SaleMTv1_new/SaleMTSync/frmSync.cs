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
                    //ImportXML();
                    ImportFromDatabase();
                    //Export(); //Bo phan nay
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

                  
                    b = c.uploadFile(UserImformation.DeptCode, objName, fileName, fileContent, getMac());
                
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
        /// Người tạo thanhd – 20/11/2013 : Lưu XML vào database
        /// </summary>
        private void ImportXML()
        {
            try
            {
                bool promo = false;
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + "---------"); });
                this.Invoke((MethodInvoker)delegate() { SetLog(Environment.NewLine + ">Import Begin"); });
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
                               
                                DataSet ds = new DataSet();
                                ds.ReadXml(mStream);                                
                                
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
             
                //ImportXML();
                ImportFromDatabase();
            }
            catch (Exception ex)
            {
                log.Error(" Error 'Worker getupdate': " + ex.Message);
            }
        }

        private void frmSync_Load(object sender, EventArgs e)
        {
            c.Endpoint.Address = new System.ServiceModel.EndpointAddress(strEndPointSync);
            //c.ClientCredentials.Windows.AllowNtlm = true;
            c.ClientCredentials.UserName.UserName = strUser;
            c.ClientCredentials.UserName.Password = strPass;           

            if (UserImformation.OpenSynData == true)
            {
                if (bgWorkerGetupdate.IsBusy != true && completed == true)
                {
                    txtLog.Text = "";
                    bgWorkerGetupdate.RunWorkerAsync();
                }
                t = int.Parse(UserImformation.SysDataAfter);
                syncTimer.Start();
            }
                        
        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            t--;
            if (t == 0)
            {
                
                if (bgWorkerGetupdate.IsBusy != true && completed == true)
                {
                    txtLog.Text = "";
                    bgWorkerGetupdate.RunWorkerAsync();
                }
                t = int.Parse(UserImformation.SysDataAfter);
            }            
        }

        //{ "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", 
        //"PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", 
        //"Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", 
        //"Parameters", "Shop", "MTPrice","CategoryData" };
        #region QUYNHNV.X8: SERVER => CLIENT

        private void ImportFromDatabase()
        {
            SaveUser();
            SaveRole();
            SaveDept();
            SavePermission();
            SaveMembers();
            SaveCustomer();
            SaveProduct();
            SavePrice();
            SavePromotion();
            SavePromotionLine();
        }

        private int client_ID = AppConfigFileSettings.Client_ID;
        private void SaveUser()
        {
            string listAccount = posdb_vnmSqlDAC.getListKey("USERS", "ACCOUNT", true, "ID > 0");
            List<USERS> listUser = new List<USERS>();
            List<USER_DEPT> listDept = new List<USER_DEPT>();
            string sql = "Select u.AD_User_ID, u.Value, u.Name, u.Password, u.Created, o.AD_Department_ID, Coalesce(u.IsChangePrice,0) IsChangePrice " +
                " From AD_User u Inner Join AD_Department o On o.AD_Department_ID = u.AD_Department_ID And o.IsAutoCreate = 'Y' " +
                " Where u.AD_Client_ID = " + client_ID + " And u.IsActive = 'Y' And u.Updated >= current_date - 10";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                USERS user = new USERS();
               
                user.ACCOUNT = r["Value"].ToString();
                user.FIRSTNAME = r["Name"].ToString();
                user.PASSWORD = r["Password"].ToString();
                user.ID = int.Parse(r["AD_User_ID"].ToString());
                user.CREATEDATE = (DateTime)r["Created"];
                user.DISCOUNT = false;
                user.CHANGE_PRICE = r["IsChangePrice"].ToString().Equals("Y") ? true : false;
                listUser.Add(user);
                if (!listAccount.Contains(user.ACCOUNT))
                {
                    USER_DEPT u = new USER_DEPT();
                    u.ID = Guid.NewGuid();
                    u.ACCOUNT = r["Value"].ToString();
                    u.DEPT_CODE = int.Parse(r["AD_Department_ID"].ToString());
                    listDept.Add(u);
                }
            }
            foreach (USERS u in listUser)
            {
                if (listAccount.Contains(u.ACCOUNT))
                    u.Save(false);
                else
                {
                    u.Save(true);                    
                }                    
            }

            foreach (USER_DEPT u in listDept)
            {
                u.Save(true);
            }
        }

        private void SaveRole()
        {
            string listAccount = posdb_vnmSqlDAC.getListKey("ROLES", "IDROLE", true, null);
            List<ROLES> listUser = new List<ROLES>();
            string sql = "Select u.AD_ROLE_ID, u.Name " +
                " From AD_ROLE u" +
                " Where u.AD_Client_ID = " + client_ID + " And u.IsActive = 'Y' And u.Updated >= current_date - 10";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                ROLES lineNew = new ROLES();

                lineNew.IDROLE = r["AD_ROLE_ID"].ToString();
                lineNew.DESCRIPTION = r["Name"].ToString();
                
                listUser.Add(lineNew);
                
            }
            foreach (ROLES u in listUser)
            {
                if (listAccount.Contains(u.IDROLE))
                    u.Save(false);
                else
                {
                    u.Save(true);
                }
            }

            
        }

        private void SaveDept()
        {
            string listDept = posdb_vnmSqlDAC.getListKey("DEPT", "DEPT_CODE", true, null);
            List<DEPT> listImport = new List<DEPT>();
            string sql = "Select o.AD_Org_ID, o.Parent_ID, o.Value, o.Name, o.Address, o.Description,  "+
                "   (Select Value From C_SalesRegion s Where o.C_SalesRegion_ID = s.C_SalesRegion_ID) as locationCode," +
                "  COALESCE(oi.Phone, oi.Phone2) Phone, oi.Fax" +
                " From AD_Org o Inner Join AD_OrgInfo oi On o.AD_Org_ID = oi.AD_Org_ID "+
                " Where o.AD_Client_ID = " + client_ID + " And o.IsActive = 'Y' And oi.IsActive = 'Y' "+
                "   and o.Updated >= current_date - 10 ";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                DEPT lineNew = new DEPT();
                lineNew.DEPT_CODE = int.Parse(r["AD_Org_ID"].ToString());
                lineNew.DEPT_NAME = r["Name"].ToString();
                lineNew.DEPT_PARENT = int.Parse(r["Parent_ID"].ToString());
                lineNew.STORE_CODE = r["Value"].ToString();
                lineNew.FAX = r["Fax"].ToString();
                lineNew.TEL = r["Phone"].ToString();
                lineNew.ADDRESS = r["Address"].ToString();
                lineNew.REMARK = r["Description"].ToString();
                lineNew.STORE_LOCATION_CODE = r["locationCode"].ToString();
                listImport.Add(lineNew);
            }
            foreach (DEPT item in listImport)
            {
                if (listDept.Contains(item.DEPT_CODE.ToString()))
                    item.Save(false);
                else
                    item.Save(true);
            }
        }

        private void SavePermission()
        {
            string listDept = posdb_vnmSqlDAC.getListKey("PERMISSIONS", "IDROLE + '_AND_' + IDRESOURCE", true, null);
            List<PERMISSIONS> listImport = new List<PERMISSIONS>();
            string sql = "Select p.AD_Role_ID, f.Name, p.IsPrinted, p.IsInsertRecord, p.IsDeleteable, p.IsUpdateable  " +
                " From AD_Permission p Inner Join AD_Form_Sale f On p.AD_Form_Sale_ID = f.AD_Form_Sale_ID " +
                " Where p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' And f.IsActive = 'Y' " +
                "   and p.Updated >= current_date - 10 ";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PERMISSIONS lineNew = new PERMISSIONS();
                lineNew.IDROLE = r["AD_Role_ID"].ToString();
                lineNew.IDRESOURCE = r["Name"].ToString();
                lineNew.PER_PRINT = r["IsPrinted"].ToString().Equals("Y") ? true : false;
                lineNew.PER_INSERT = r["IsInsertRecord"].ToString().Equals("Y") ? true : false;
                lineNew.PER_DELETE = r["IsDeleteable"].ToString().Equals("Y") ? true : false;
                lineNew.PER_UPDATE = r["IsUpdateable"].ToString().Equals("Y") ? true : false;
                listImport.Add(lineNew);
            }
            foreach (PERMISSIONS item in listImport)
            {
                string key = item.IDROLE + "_AND_" + item.IDRESOURCE;
                if (listDept.Contains(key))
                    item.Save(false);
                else
                    item.Save(true);
            }
        }

        private void SaveMembers()
        {
            string listDept = posdb_vnmSqlDAC.getListKey("MEMBERS", "IDROLE + '_AND_' + ACCOUNT", true, null);
            List<MEMBERS> listImport = new List<MEMBERS>();
            string sql = "Select p.AD_Role_ID, f.Value  " +
                " From AD_User_Roles p Inner Join AD_User f On p.AD_User_ID = f.AD_User_ID " +
                " Where p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' And f.IsActive = 'Y' " +
                "   and p.Updated >= current_date - 10 ";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                MEMBERS lineNew = new MEMBERS();
                lineNew.IDROLE = r["AD_Role_ID"].ToString();
                lineNew.ACCOUNT = r["Value"].ToString();
                listImport.Add(lineNew);
            }
            foreach (MEMBERS item in listImport)
            {
                string key = item.IDROLE + "_AND_" + item.ACCOUNT;
                if (listDept.Contains(key))
                    item.Save(false);
                else
                    item.Save(true);
            }
        }

        private void SaveCustomer()
        {
            string listDept = posdb_vnmSqlDAC.getListKey("CUSTOMERS", "CUSTOMER_ID", true, null);
            List<CUSTOMERS> listImport = new List<CUSTOMERS>();
            string sql =
                " select b.C_Bpartner_ID, b.Name, i.BirthDay, i.BirthPlace, i.Gender, i.CardID, i.DateIssue, i.PlaceIssue, " +
                " 	i.Phone, i.Address, i.TaxID, b.Created, b.CreatedBy, b.Updated, b.UpdatedBy, b.AD_Department_ID	 " +
                " from c_bpartner b " +
                " 	Inner Join c_bpartnerinfo i On b.C_BPartner_ID = i.C_BPartner_ID  " +
                " Where b.AD_Client_ID = " + client_ID + " And b.IsActive = 'Y' And i.IsActive = 'Y' " +
                "   and b.Updated >= current_date - 10 ";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                CUSTOMERS lineNew = new CUSTOMERS();
                lineNew.CUSTOMER_ID = r["C_BPartner_ID"].ToString();
                lineNew.DEPT_CODE = int.Parse(r["AD_Department_ID"].ToString());
                lineNew.FIRST_NAME = r["Name"].ToString();
                lineNew.LAST_NAME = null;
                lineNew.DATE_OF_BIRTH = DateTime.Parse(r["BirthDay"].ToString());
                lineNew.PLACE_OF_BIRTH = r["BirthPlace"].ToString();
                lineNew.SEX_CODE = r["Gender"].ToString();
                lineNew.ID_NO = r["CardID"].ToString();
                lineNew.ID_NO_ISSUED_DATE = DateTime.Parse(r["DateIssue"].ToString());
                lineNew.ID_NO_ISSUED_PLACE = r["PlaceIssue"].ToString();
                lineNew.MOBILE_PHONE = r["Phone"].ToString();
                lineNew.ADDRESS = r["Address"].ToString();
                lineNew.TAX_CODE = r["TaxID"].ToString();
                lineNew.CREATE_DATE = DateTime.Parse(r["Created"].ToString());
                lineNew.UPDATE_DATE = DateTime.Parse(r["Updated"].ToString());
                lineNew.CREATE_BY = r["CreatedBy"].ToString();
                lineNew.LAST_UPDATE_BY = r["UpdatedBy"].ToString();
                listImport.Add(lineNew);
            }
            foreach (CUSTOMERS item in listImport)
            {
                if (listDept.Contains(item.DEPT_CODE.ToString()))
                    item.Save(false);
                else
                    item.Save(true);
            }
        }
        private void SaveProduct()
        {
            string listProduct = posdb_vnmSqlDAC.getListKey("PRODUCTS", "PRODUCT_ID", true, null);
            List<PRODUCTS> listImport = new List<PRODUCTS>();
            string sql = "Select p.Value ProductCode, p.Name ProductName, p.Barcode, "+
                "   u.UOMSymbol unitCode, u.Name unitName, c.Value catCode, c.Name catName, p.PackageStd, " +
                "   ("+
                "       Select Price From M_Price r "+
                "       Where p.M_Product_ID = r.M_Product_ID And DocStatus = 'CO' "+
                "       And validfrom < current_date and current_date <= validto order by validfrom desc limit 1 " +
                "   ) as Price " +
                " From M_Product p " +
                "       Inner Join C_UOM u On p.C_UOM_ID = u.C_UOM_ID " +
                "       Inner Join M_Product_Category c On c.M_Product_Category_ID = p.M_Product_Category_ID " +
                " Where p.AD_Client_ID = "+ client_ID + " And p.IsActive = 'Y'";// and p.Updated >= current_date - 10
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PRODUCTS lineNew = new PRODUCTS();
                lineNew.PRODUCT_ID = r["ProductCode"].ToString();
                lineNew.PRODUCT_NAME = r["ProductName"].ToString();
                lineNew.PRODUCT_NAME_PRINT = r["ProductName"].ToString();
                lineNew.SHORT_NAME = r["ProductName"].ToString();
                lineNew.ACTIVE = true;
                lineNew.UNIT = r["unitCode"].ToString();
                lineNew.UNIT_NAME = r["unitName"].ToString();
                lineNew.UNIT1 = r["unitCode"].ToString();
                lineNew.UNIT_NAME1 = r["unitName"].ToString();
                lineNew.CATEGORY = r["catCode"].ToString();
                lineNew.BARCODE = r["Barcode"].ToString();
                if (r["Price"].ToString() != "")
                    lineNew.PRICE = float.Parse(r["Price"].ToString());
                lineNew.CONV_FACT = float.Parse(r["PackageStd"].ToString());
                lineNew.CAT = "";
                
                listImport.Add(lineNew);
            }
            foreach (PRODUCTS item in listImport)
            {
                if (listProduct.Contains(item.PRODUCT_ID))
                    item.Save(false);
                else
                    item.Save(true);
            }
        }


        private void SavePrice()
        {
           
            List<DEV_PRICEITEMS> listImport = new List<DEV_PRICEITEMS>();
            string sql = 
                " Select r.Price, p.Value, r.M_Price_ID, r.ValidFrom, r.Created, r.CreatedBy "+
                " From M_Price r Inner Join M_Product p On r.M_Product_ID = p.M_Product_ID " +
                " Where r.DocStatus = 'CO' " +
                "       And r.validfrom < current_date and current_date <= r.validto " +
                "       And p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y'";// and p.Updated >= current_date - 10
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                DEV_PRICEITEMS lineNew = new DEV_PRICEITEMS();
                lineNew.Product = r["Value"].ToString();
                lineNew.PRICE1 = decimal.Parse(r["Price"].ToString());
                lineNew.StartDate = DateTime.Parse(r["ValidFrom"].ToString());
                lineNew.START_DATE1 = DateTime.Parse(r["ValidFrom"].ToString());
                lineNew.CREATE_DATE1 = DateTime.Parse(r["Created"].ToString());
                lineNew.USER_CREATE1 = r["CreatedBy"].ToString();
               
                listImport.Add(lineNew);
            }
            foreach (DEV_PRICEITEMS item in listImport)
            {
                item.Save(true);
            }
        }
        private void SavePromotion()
        {
            string listKey = posdb_vnmSqlDAC.getListKey("PROMOTIONS", "PROMOTION_NO", false, null);
            List<PROMOTIONS> listImport = new List<PROMOTIONS>();
            string sql = "Select M_Promotion_ID, Value, ValidFrom, ValidTo, Description " +
                " From M_Promotion " +
                " Where AD_Client_ID = " + client_ID + " And IsActive = 'Y' And DocStatus = 'CO'" +
                "   And M_Promotion_ID not in ("+ listKey +")";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PROMOTIONS lineNew = new PROMOTIONS();
                lineNew.PROMOTION_NO = r["M_Promotion_ID"].ToString();
                lineNew.PROMOTION_DATE = (DateTime)r["ValidFrom"];
                lineNew.INPUT_DATE = (DateTime)r["ValidFrom"];
                lineNew.FROM_DATE = (DateTime) r["ValidFrom"];
                lineNew.TO_DATE = (DateTime) r["ValidTo"];
                lineNew.REMARK = r["Description"].ToString();
                listImport.Add(lineNew);
            }
            foreach (PROMOTIONS item in listImport)
            {
                item.Save(true);
            }
        }

        private void SavePromotionLine()
        {
            string listKey = posdb_vnmSqlDAC.getListKey("PROMOTION_DETAIL", "PROMOTION_DETAIL_NO", false, null);
            List<PROMOTION_DETAIL> listImport = new List<PROMOTION_DETAIL>();
            string sql = "Select M_Promotion_ID, Value, ValidFrom, ValidTo, Description " +
                " From M_Promotion " +
                " Where AD_Client_ID = " + client_ID + " And IsActive = 'Y' And DocStatus = 'CO'" +
                "   And M_Promotion_ID not in (" + listKey + ")";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PROMOTION_DETAIL lineNew = new PROMOTION_DETAIL();
                lineNew.PROMOTION_NO = r["Value"].ToString();
                lineNew.PROMOTION_DETAIL_NO = r["Name"].ToString();
                lineNew.PROMOTION_DETAIL_NAME = r["Name"].ToString();
                lineNew.QUANTITY_BUY = 0;
                lineNew.QUANTITY_MIN = 0;
                lineNew.QUANTITY_MAX = 0;
                listImport.Add(lineNew);
            }
            foreach (PROMOTION_DETAIL item in listImport)
            {
                item.Save(true);
            }
        }

        #endregion SERVER => CLIENT

        //"ExportDetail", "ExportProducts", "ExportProductStore", "ExportProductStoreDetail", 
        //"ItemReturnDetail", "SalePromotion", "SalePromotionGifts", "SalesExportItems", "SalesExport", 
        //"ItemReturn", "InventoryTemp", "Customers", "OrderProductDetail", "OrderProducts"
        #region QUYNHNV.X8: CLIENT => SERVER
        //Phan nay se khong phai day len server ma server tro vao db de lay ve luon.
        #endregion QUYNHNV.X8: CLIENT => SERVER
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

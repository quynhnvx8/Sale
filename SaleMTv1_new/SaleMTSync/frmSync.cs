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
        private void downloadXml(string url, string objName)
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
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Downloading: " + countDL + " file completed"); });
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
                    this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Download Completed"); });
                    if (deleteXML.Count > 0)
                    {

                        this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Delete request sent: " + deleteXML.Count.ToString() + " files"); });

                        string[] objArray = new string[] { "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice", "CategoryData" };
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
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + "---------"); });
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Export Begin"); });

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
                        this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Upload file: " + Path.GetFileName(file)); });
                    }
                }

                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Export Completed"); });
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

                        this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Export file: " + Path.GetFileName(filepath)); });
                    }
                    else
                    {
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            DataTable dt2 = dt.Clone();
                            dt.AsEnumerable().Skip(i).Take(5000).CopyToDataTable(dt2, LoadOption.OverwriteChanges);
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

                            this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Export file: " + Path.GetFileName(filepath)); });
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
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + "---------"); });
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Import Begin"); });
                string[] objArray = new string[] { "Product", "ProductInfo", "PromotionProgram", "PromotionProgramDetail", "PromotionShopMap", "PromotionCustAttr", "PromotionCustAttrDetail", "Customer", "User", "UserShop", "GroupUser", "Members", "Permissions", "Parameters", "Shop", "MTPrice", "CategoryData" };

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
                this.Invoke((MethodInvoker)delegate () { SetLog(Environment.NewLine + ">Import Completed"); });
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
            SaveProductCategory();
            SaveProduct();
            SavePrice();
            SavePromotion();
            
        }

        private int client_ID = AppConfigFileSettings.Client_ID;
        private int numDayScan = AppConfigFileSettings.NumberDayScan;
        private void SaveUser()
        {
            String listId = "";
            string listAccount = posdb_vnmSqlDAC.getListKey("USERS", "ACCOUNT", true, "ID > 0");
            List<USERS> listUser = new List<USERS>();
            List<USER_DEPT> listDept = new List<USER_DEPT>();
            string sql = "Select u.AD_User_ID, u.Value, u.Name, u.Password, u.Created, o.AD_Department_ID, Coalesce(u.IsChangePrice,'0') IsChangePrice " +
                " From AD_User u Inner Join AD_Department o On o.AD_Department_ID = u.AD_Department_ID And o.IsAutoCreate = 'Y' " +
                " Where u.AD_Client_ID = " + client_ID + " And u.IsActive = 'Y' And u.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                USERS user = new USERS();

                user.ACCOUNT = r["Value"].ToString();
                user.FIRSTNAME = r["Name"].ToString();
                user.PASSWORD = r["Password"].ToString();
                user.AD_USER_ID = int.Parse(r["AD_User_ID"].ToString());
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
                if ("".Equals(listId))
                    listId = r["AD_User_ID"].ToString();
                else
                    listId = listId + "," + r["AD_User_ID"].ToString();

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete USERS Where ID in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (USERS u in listUser)
                {
                    u.Save(true);
                }

                foreach (USER_DEPT u in listDept)
                {
                    u.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void SaveRole()
        {
            String listId = "";
            List<ROLES> listUser = new List<ROLES>();
            string sql = "Select u.AD_ROLE_ID, u.Name " +
                " From AD_ROLE u" +
                " Where u.AD_Client_ID = " + client_ID + " And u.IsActive = 'Y' And u.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                ROLES lineNew = new ROLES();

                lineNew.IDROLE = r["AD_ROLE_ID"].ToString();
                lineNew.DESCRIPTION = r["Name"].ToString();

                listUser.Add(lineNew);

                if ("".Equals(listId))
                    listId = "'" + r["AD_Role_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["AD_Role_ID"].ToString() + "'";

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete ROLES Where IDROLE in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (ROLES u in listUser)
                {
                    u.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void SaveDept()
        {
            String listId = "";

            List<DEPT> listImport = new List<DEPT>();
            string sql = "Select o.AD_Org_ID, Coalesce(o.Parent_ID,0) Parent_ID, o.Value, o.Name, o.Address, o.Description,  " +
                "   (Select Value From C_SalesRegion s Where o.C_SalesRegion_ID = s.C_SalesRegion_ID) as locationCode," +
                "  COALESCE(oi.Phone, oi.Phone2) Phone, oi.Fax" +
                " From AD_Org o Inner Join AD_OrgInfo oi On o.AD_Org_ID = oi.AD_Org_ID " +
                " Where o.AD_Client_ID = " + client_ID + " And o.IsActive = 'Y' And oi.IsActive = 'Y' " +
                "   and o.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                DEPT lineNew = new DEPT();
                lineNew.DEPT_CODE = int.Parse(r["AD_Org_ID"].ToString());
                lineNew.DEPT_NAME = r["Name"].ToString();
                if (!r["Parent_ID"].ToString().Equals("0"))
                    lineNew.DEPT_PARENT = int.Parse(r["Parent_ID"].ToString());
                lineNew.STORE_CODE = r["Value"].ToString();
                lineNew.FAX = r["Fax"].ToString();
                lineNew.TEL = r["Phone"].ToString();
                lineNew.ADDRESS = r["Address"].ToString();
                lineNew.REMARK = r["Description"].ToString();
                lineNew.STORE_LOCATION_CODE = r["locationCode"].ToString();
                listImport.Add(lineNew);
                if ("".Equals(listId))
                    listId = "'" + r["AD_Org_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["AD_Org_ID"].ToString() + "'";

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete DEPT Where DEPT_CODE in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (DEPT item in listImport)
                {
                    item.Save(true);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void SavePermission()
        {
            String listId = "";
            List<PERMISSIONS> listImport = new List<PERMISSIONS>();
            string sql = "Select p.AD_Role_ID, f.Name, p.IsPrinted, p.IsInsertRecord, p.IsDeleteable, p.IsUpdateable  " +
                " From AD_Permission p Inner Join AD_Form_Sale f On p.AD_Form_Sale_ID = f.AD_Form_Sale_ID " +
                " Where p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' And f.IsActive = 'Y' " +
                "   and p.Updated >= current_date - " + numDayScan;
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
                if ("".Equals(listId))
                    listId = "'" + r["AD_Role_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["AD_Role_ID"].ToString() + "'";

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete PERMISSIONS Where IDROLE in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (PERMISSIONS item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void SaveMembers()
        {
            string listDept = posdb_vnmSqlDAC.getListKey("MEMBERS", "IDROLE + '_AND_' + ACCOUNT", true, null);
            List<MEMBERS> listImport = new List<MEMBERS>();
            string sql = "Select p.AD_Role_ID, f.Value  " +
                " From AD_User_Roles p Inner Join AD_User f On p.AD_User_ID = f.AD_User_ID " +
                " Where p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' And f.IsActive = 'Y' " +
                "   and p.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                MEMBERS lineNew = new MEMBERS();
                lineNew.IDROLE = r["AD_Role_ID"].ToString();
                lineNew.ACCOUNT = r["Value"].ToString();
                listImport.Add(lineNew);
            }
            try
            {

                foreach (MEMBERS item in listImport)
                {
                    string key = item.IDROLE + "_AND_" + item.ACCOUNT;
                    if (listDept.Contains(key))
                        item.Save(false);
                    else
                        item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
}

        private void SaveCustomer()
        {
            String listId = "";
            List<CUSTOMERS> listImport = new List<CUSTOMERS>();
            string sql =
                " select b.C_Bpartner_ID, b.Name, i.BirthDay, i.BirthPlace, i.Gender, i.CardID, i.DateIssue, i.PlaceIssue, " +
                " 	i.Phone, i.Address, i.TaxID, b.Created, b.CreatedBy, b.Updated, b.UpdatedBy, b.AD_Department_ID	 " +
                " from c_bpartner b " +
                " 	Inner Join c_bpartnerinfo i On b.C_BPartner_ID = i.C_BPartner_ID  " +
                " Where b.AD_Client_ID = " + client_ID + " And b.IsActive = 'Y' And i.IsActive = 'Y' " +
                "   and b.Updated >= current_date - " + numDayScan;
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
                if ("".Equals(listId))
                    listId = "'" + r["C_BPartner_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["C_BPartner_ID"].ToString() + "'";

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete CUSTOMERS Where CUSTOMER_ID in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (CUSTOMERS item in listImport)
                {
                    item.Save(true);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void SaveProduct()
        {
            String listId = "";

            List<PRODUCTS> listImport = new List<PRODUCTS>();
            string sql = "Select p.M_Product_ID, p.Value ProductCode, p.Name ProductName, p.Barcode, " +
                "   u.UOMSymbol unitCode, u.Name unitName, c.Value catCode, c.Name catName, p.PackageStd, " +
                "   (" +
                "       Select Price From M_Price r " +
                "       Where p.M_Product_ID = r.M_Product_ID And DocStatus = 'CO' " +
                "       And validfrom < current_date and current_date <= validto order by validfrom desc limit 1 " +
                "   ) as Price " +
                " From M_Product p " +
                "       Inner Join C_UOM u On p.C_UOM_ID = u.C_UOM_ID " +
                "       Inner Join M_Product_Category c On c.M_Product_Category_ID = p.M_Product_Category_ID " +
                " Where p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' and p.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PRODUCTS lineNew = new PRODUCTS();
                lineNew.M_PRODUCT_ID = float.Parse(r["M_Product_ID"].ToString());
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
                if ("".Equals(listId))
                    listId = "'" + r["ProductCode"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["ProductCode"].ToString() + "'";

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete PRODUCTS Where PRODUCT_ID in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (PRODUCTS item in listImport)
                {
                    item.Save(true);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void SaveProductCategory()
        {
            String listId = "";
            string listProduct = posdb_vnmSqlDAC.getListKey("DEV_IN_DM_NHOMVATTU", "NhomVT_ID", true, null);
            List<DEV_IN_DM_NHOMVATTU> listImport = new List<DEV_IN_DM_NHOMVATTU>();
            string sql = "Select M_Product_Category_ID, Value, Name " +
                " From M_Product_Category  " +
                " Where AD_Client_ID = " + client_ID + " And IsActive = 'Y' and Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                DEV_IN_DM_NHOMVATTU lineNew = new DEV_IN_DM_NHOMVATTU();
                lineNew.MaNhom = r["Value"].ToString();
                lineNew.TenNhom = r["Name"].ToString();
                lineNew.Id = int.Parse(r["M_Product_Category_ID"].ToString());
                lineNew.Active = "1";

                listImport.Add(lineNew);
                if ("".Equals(listId))
                    listId = r["M_Product_Category_ID"].ToString() ;
                else
                    listId = listId + "," + r["M_Product_Category_ID"].ToString();

            }

            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete DEV_IN_DM_NHOMVATTU Where ID in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (DEV_IN_DM_NHOMVATTU item in listImport)
                {
                    if (listProduct.Contains(item.Id.ToString()))
                        item.Save(false);
                    else
                        item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void SavePrice()
        {
            String listId = "";
            List<DEV_PRICEITEMS> listImport = new List<DEV_PRICEITEMS>();
            string sql =
                " Select r.Price, p.Value, r.M_Price_ID, r.ValidFrom, r.Created, r.CreatedBy " +
                " From M_Price r Inner Join M_Product p On r.M_Product_ID = p.M_Product_ID " +
                " Where r.DocStatus = 'CO' " +
                "       And r.validfrom < current_date and current_date <= r.validto " +
                "       And p.AD_Client_ID = " + client_ID + " And p.IsActive = 'Y' and r.Updated >= current_date - " + numDayScan;
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
                lineNew.ID = Int16.Parse(r["M_Price_ID"].ToString());
                listImport.Add(lineNew);
                if ("".Equals(listId))
                    listId =r["M_Price_ID"].ToString();
                else
                    listId = listId + "," + r["M_Price_ID"].ToString();
            }
            try
            {
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete DEV_PRICEITEMS Where ID in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (DEV_PRICEITEMS item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        
        private void SavePromotion()
        {
            String listId = "";
            List<PROMOTIONS> listImport = new List<PROMOTIONS>();
            string sql = "Select M_Promotion_ID, ValidFrom, ValidTo, Description, isPending " +
                " From M_Promotion " +
                " Where AD_Client_ID = " + client_ID + " And IsActive = 'Y' And DocStatus = 'CO' "+
                "   And Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PROMOTIONS lineNew = new PROMOTIONS();
                lineNew.PROMOTION_NO = r["M_Promotion_ID"].ToString();
                lineNew.PROMOTION_DATE = (DateTime)r["ValidFrom"];
                lineNew.INPUT_DATE = (DateTime)r["ValidFrom"];
                lineNew.FROM_DATE = (DateTime)r["ValidFrom"];
                lineNew.TO_DATE = (DateTime)r["ValidTo"];
                lineNew.REMARK = r["Description"].ToString();
                lineNew.ISPENDING = false;
                if ("Y".Equals(r["isPending"].ToString()))
                {
                    lineNew.ISPENDING = true;
                }
                if ("".Equals(listId))
                    listId = "'" + r["M_Promotion_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["M_Promotion_ID"].ToString() + "'";
                listImport.Add(lineNew);
            }
            try
            {
                //Xóa bản ghi cũ đi.
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete PROMOTIONS Where PROMOTION_NO in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }
                foreach (PROMOTIONS item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            SavePromotionLine();
            SaveProgramProduct();
            SavePromotionCus();
            SaveCouponShop();

        }

        private void SavePromotionLine()
        {
            List<PROMOTION_DETAIL> listImport = new List<PROMOTION_DETAIL>();
            string sql =
                " select M_PromotionLine_ID, M_Promotion_ID, Coalesce(Sum(Amount::float),0) Amount, Coalesce(Sum(Qty::integer),0) Qty, "+
                "   Coalesce(DiscountAmt,0) DiscountAmt, " +
                    " Coalesce(DiscountPercent,0) DiscountPercent, PromotionType, Name, By_Cus, By_Shop, By_Gift " +
                " From " +
                " ( " +
                " 	Select l.M_PromotionLine_ID, l.M_Promotion_ID, unnest(string_to_array(l.Amount,',')) Amount,  " +
                " 		unnest(string_to_array(QtyMultiplier,',')) Qty, l.DiscountAmt, Round(l.DiscountPercent/100,4) DiscountPercent," +
                "       t.Name, t.PromotionType,  " +
                "       Case when Coalesce(AD_Department_Multi_ID,'') = '' then 0 else 1 end  by_Shop, " +
                "       Case when Coalesce(C_BP_Group_ID,'') = '' then 0 else 1 end by_Cus, " +
                "       Case when Coalesce(M_Product_Free_ID,'') = '' Then 0 Else 1 End by_Gift" +
                " 	From M_PromotionLine l " +
                " 		inner Join M_Promotion p On l.M_Promotion_ID = p.M_Promotion_ID  " +
                " 		inner Join M_PromotionType t On t.M_PromotionType_ID = p.M_PromotionType_ID " +
                " 	Where l.AD_Client_ID = " + client_ID + " And p.DocStatus = 'CO' " +
                "       And l.Updated >= current_date - " + numDayScan +
                " )B  " +
                " Group by M_PromotionLine_ID, M_Promotion_ID, DiscountAmt, DiscountPercent, PromotionType, Name, By_Cus, By_Shop, By_Gift";
            
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            String listId = "";
            foreach (DataRow r in dt.Rows)
            {
                PROMOTION_DETAIL lineNew = new PROMOTION_DETAIL();
                lineNew.PROMOTION_NO = r["M_Promotion_ID"].ToString();
                lineNew.PROMOTION_DETAIL_NO = r["M_PromotionLine_ID"].ToString();
                lineNew.QUANTITY_MIN = Int16.Parse(r["Qty"].ToString());
                lineNew.DISCOUNT_VALUE = float.Parse(r["DiscountPercent"].ToString());
                lineNew.PROMOTION_DETAIL_NAME = r["Name"].ToString();
                float discountAmt = float.Parse(r["DiscountAmt"].ToString());
                if (discountAmt > 0)
                {
                    lineNew.DISCOUNT_ON = "AMOUNT";
                    lineNew.DISCOUNT_VALUE = float.Parse(r["DiscountAmt"].ToString());
                }
                float discountPer = float.Parse(r["DiscountPercent"].ToString());
                if (discountPer > 0)
                {
                    lineNew.DISCOUNT_ON = "PERCENT";
                    lineNew.DISCOUNT_VALUE = float.Parse(r["DiscountPercent"].ToString());
                }
                int byGift = Int16.Parse(r["by_Gift"].ToString());
                if(byGift == 1)
                {
                    lineNew.DISCOUNT_ON = "GIFTS";                    
                }
                lineNew.AMOUNT_MIN = float.Parse(r["Amount"].ToString());
                lineNew.PROMOTION_TYPE = r["PromotionType"].ToString();
                lineNew.IS_BUNDLE = false;
                if ("BUNDLE".Equals(r["PromotionType"].ToString()))
                    lineNew.IS_BUNDLE = true;
                lineNew.BY_SHOP = Int16.Parse(r["by_Shop"].ToString());
                lineNew.BY_CUS = Int16.Parse(r["by_Cus"].ToString());
                if ("".Equals(listId))
                    listId = "'" + r["M_PromotionLine_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["M_PromotionLine_ID"].ToString() + "'";
                listImport.Add(lineNew);
            }
            try
            {
                //Xóa bản ghi cũ đi.
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete PROMOTION_DETAIL Where PROMOTION_DETAIL_NO in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (PROMOTION_DETAIL item in listImport)
                {
                    item.Save(true);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        private void SaveProgramProduct()
        {
            String listId = "";
            List<PROGRAM_PRODUCT> listImport = new List<PROGRAM_PRODUCT>();
            string sql = "with tmp as( "+
                " Select l.M_PromotionLine_ID, "+
                "       unnest(string_to_array(l.M_Product_ID,','))::integer M_Product_ID, " +
                "       unnest(string_to_array(l.M_Product_Free_ID,','))::integer M_Product_Free_ID, " +
                "       unnest(string_to_array(l.QtyMultiplier,',')) Qty," +
                "       unnest(string_to_array(l.QtyFree,',')) QtyFree," +
                "       unnest(string_to_array(l.Amount,',')) Amt" +
                " From M_PromotionLine l " +
                "       inner Join M_Promotion p On l.M_Promotion_ID = p.M_Promotion_ID " +
                " Where l.AD_Client_ID = " + client_ID + " And p.DocStatus = 'CO'" +
                "   and l.Updated >= current_date - " + numDayScan +
                ")"+
                " Select tmp.*, p.Value, pf.Value ValueFree "+
                " From tmp Left Join M_Product p On tmp.M_Product_ID = p.M_Product_ID"+
                "   Left Join M_Product pf On tmp.M_Product_Free_ID = pf.M_Product_ID";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PROGRAM_PRODUCT lineNew = new PROGRAM_PRODUCT();
                lineNew.PRODUCT_ID = r["Value"].ToString();
                lineNew.PROGRAM_NO = r["M_PromotionLine_ID"].ToString();
                if ("".Equals(listId))
                    listId = "'" + r["M_PromotionLine_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["M_PromotionLine_ID"].ToString() + "'";
                if (r["Qty"] != null && !"".Equals(r["Qty"].ToString()))
                    lineNew.QTY = Int32.Parse(r["Qty"].ToString());
                if(r["Amt"] != null && !"".Equals(r["Amt"].ToString()))
                    lineNew.AMT = float.Parse(r["Amt"].ToString());
                if (r["M_Product_Free_ID"] != null && !"".Equals(r["M_Product_Free_ID"].ToString()))
                {
                    lineNew.PRODUCT_GIF_ID = r["ValueFree"].ToString();
                    lineNew.QTY_GIF = Int32.Parse(r["QtyFree"].ToString());
                }
                listImport.Add(lineNew);
            }
            try
            {
                //Xóa bản ghi cũ đi.
                String sqlDelete = "Delete PROGRAM_PRODUCT Where Program_No in (" + listId + ")";
                posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                foreach (PROGRAM_PRODUCT item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        private void SavePromotionCus()
        {
            String listId = "";
            List<PROGRAM_MASTER_DATA> listImport = new List<PROGRAM_MASTER_DATA>();
            string sql = "With tmp as ("+
                " Select l.M_PromotionLine_ID, UNNEST(string_to_array(l.C_BP_Group_ID,','))::integer CusList " +
                " From M_PromotionLine l " +
                "       inner Join M_Promotion p On l.M_Promotion_ID = p.M_Promotion_ID " +
                " Where l.AD_Client_ID = " + client_ID + "  And p.DocStatus = 'CO'" +
                "   And l.Updated >= current_date - " + numDayScan +
                 ")" +
                " Select tmp.M_PromotionLine_ID, tmp.CusList, g.Value " +
                " From tmp Inner Join C_BP_Group g On tmp.CusList = g.C_BP_Gropu_ID ";
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                PROGRAM_MASTER_DATA lineNew = new PROGRAM_MASTER_DATA();
                lineNew.PROGRAM_NO = r["M_PromotionLine_ID"].ToString();
                if (r["CusList"] != null)
                    lineNew.GROUP_ID = Int32.Parse(r["CusList"].ToString());
                if (r["Value"] != null)
                    lineNew.MASTER_CODE = r["Value"].ToString();
                lineNew.ISPENDING = false;
                
                if ("".Equals(listId))
                    listId = "'" + r["M_PromotionLine_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'" + r["M_PromotionLine_ID"].ToString() + "'";
                listImport.Add(lineNew);
            }
            try
            {
                //Xóa bản ghi cũ đi.
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete PROGRAM_MASTER_DATA Where PROGRAM_NO in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);

                }

                foreach (PROGRAM_MASTER_DATA item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void SaveCouponShop()
        {
            String listId = "";
            List<COUPON_STORES> listImport = new List<COUPON_STORES>();
            string sql = "Select l.M_PromotionLine_ID, UNNEST(string_to_array(l.AD_Department_Multi_ID,',')) ShopList " +
                " From M_PromotionLine l " +
                "       inner Join M_Promotion p On l.M_Promotion_ID = p.M_Promotion_ID " +
                " Where l.AD_Client_ID = " + client_ID + " And p.DocStatus = 'CO'" +
                "   And l.Updated >= current_date - " + numDayScan;
            DataTable dt = posdb_vnmSqlDAC.SelectData_Npgsql(sql, null, null);
            foreach (DataRow r in dt.Rows)
            {
                COUPON_STORES lineNew = new COUPON_STORES();
                lineNew.COUPON_NO = r["M_PromotionLine_ID"].ToString();
                if (r["ShopList"] != null && !"".Equals(r["ShopList"].ToString()))
                    lineNew.DEPT_CODE = Int32.Parse(r["ShopList"].ToString());
                lineNew.ISPENDING = false;
                if ("".Equals(listId))
                    listId = "'" + r["M_PromotionLine_ID"].ToString() + "'";
                else
                    listId = listId + "," + "'"  + r["M_PromotionLine_ID"].ToString() + "'";
                listImport.Add(lineNew);
            }
            try
            {
                //Xóa bản ghi cũ đi.
                if (!"".Equals(listId))
                {
                    String sqlDelete = "Delete COUPON_STORES Where COUPON_NO in (" + listId + ")";
                    posdb_vnmSqlDAC excu = new posdb_vnmSqlDAC();
                    excu.InlineSql_ExecuteNonQuery(sqlDelete, null);
                }

                foreach (COUPON_STORES item in listImport)
                {
                    item.Save(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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

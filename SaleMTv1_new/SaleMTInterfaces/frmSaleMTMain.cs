using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using SaleMTInterfaces.FrmCustomerEmployee;
using SaleMTInterfaces.FrmInventoryManagement;
using SaleMTInterfaces.FrmLiablityManagement;
using SaleMTInterfaces.FrmSaleManagement;
using SaleMTInterfaces.FrmSystem;
using SaleMTInterfaces.FrmUtilities;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleAD.FrmSystem;
using SaleMTBusiness.SystemManagement;
using SaleMTSync;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Npgsql;
using System.Security.Cryptography;
namespace SaleMTInterfaces
{
    public partial class frmSaleMTMain : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private bool checkPrint = false;
        private const string COM_NAME = "00";
        #endregion

        #region Contructor
        public frmSaleMTMain(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }

        private void initLanguage() 
        {
            mnuSystem.Text                  = translate[mnuSystem.Name];
            mnuLogin.Text                   = translate[mnuLogin.Name];
            mnuDatabaseConfig.Text          = translate[mnuDatabaseConfig.Name];
            mnuChangePassword.Text          = translate[mnuChangePassword.Name];

            this.mnuCustomizeFormat.Text    = translate[mnuCustomizeFormat.Name];
            this.mnuSetupPrinter.Text       = translate[mnuSetupPrinter.Name];
            this.mnuOptionSynData.Text      = translate[mnuOptionSynData.Name];
            this.mnuFtpConfig.Text          = translate[mnuFtpConfig.Name];
            this.mnuQuitApp.Text            = translate[mnuQuitApp.Name];
            this.mnuInvenManagement.Text    = translate[mnuInvenManagement.Name];
            this.mnuOrder.Text              = translate[mnuOrder.Name];
            this.mnuGoodsReceipt.Text       = translate[mnuGoodsReceipt.Name];
            this.mnuGoodsDelivery.Text      = translate[mnuGoodsDelivery.Name];
            this.mnuCheckInventory.Text     = translate[mnuCheckInventory.Name];
            this.mnuInputStock.Text         = translate[mnuInputStock.Name];
            this.mnuSaleManage.Text         = translate[mnuSaleManage.Name];
            this.mnuSale.Text               = translate[mnuSale.Name];
            this.mnuReturnItems.Text        = translate[mnuReturnItems.Name];
            this.mnuCash.Text               = translate[mnuCash.Name];
            this.mnuCashPay.Text            = translate[mnuCashPay.Name];
            this.mnuCashReceipt.Text        = translate[mnuCashReceipt.Name];
            this.mnuManageReceipt.Text      = translate[mnuManageReceipt.Name];
            this.tsmCusManager.Text         = translate[tsmCusManager.Name];
            this.mnuShiftReport.Text        = translate[mnuShiftReport.Name];
            this.mnuCloseShift.Text         = translate[mnuCloseShift.Name];
            this.tsmnuQuanLyKHNV.Text       = translate[tsmnuQuanLyKHNV.Name];
            this.mnuCustomersManage.Text    = translate[mnuCustomersManage.Name];
            this.mnuEmployeeInfor.Text      = translate[mnuEmployeeInfor.Name];
            this.mnuShiftmanage.Text        = translate[mnuShiftmanage.Name];
            this.mnuTimeAttendance.Text     = translate[mnuTimeAttendance.Name];
            this.mnuLiabilityManage.Text    = translate[mnuLiabilityManage.Name];
            this.mnuCashDepo.Text           = translate[mnuCashDepo.Name];
            this.mnuInvoicePay.Text         = translate[mnuInvoicePay.Name];
            this.mnuInputLiability.Text     = translate[mnuInputLiability.Name];
            this.mnuLiablityReport.Text     = translate[mnuLiablityReport.Name];
            this.mnuReport.Text             = translate[mnuReport.Name];
            this.mnuRReport.Text            = translate[mnuRReport.Name];
            this.mnuUtilities.Text          = translate[mnuUtilities.Name];
            this.mnuBarcodeScaner.Text      = translate[mnuBarcodeScaner.Name];
            this.mnuCalculator.Text         = translate[mnuCalculator.Name];
            this.mnuNotepad.Text            = translate[mnuNotepad.Name];
            this.mnuCompareExcel.Text       = translate[mnuCompareExcel.Name];
            this.mnuGoodsInventory.Text     = translate[mnuGoodsInventory.Name];
            this.mnuHelp.Text               = translate[mnuHelp.Name];
            this.mnuUserGuide.Text          = translate[mnuUserGuide.Name];
            this.mnuAppInfo.Text            = translate[mnuAppInfo.Name];
            this.mnuAbout.Text              = translate[mnuAbout.Name];
            this.mnuWindow.Text             = translate[mnuWindow.Name];
            this.mnuExitWindow.Text         = translate[mnuExitWindow.Name];
            this.testToolStripMenuItem.Text = translate[testToolStripMenuItem.Name];
            
            
            this.btnAdd.Text                = translate[btnAdd.Name];
            this.btnSave.Text               = translate[btnSave.Name];
            this.btnEdit.Text               = translate[btnEdit.Name];
            this.btnCancel.Text             = translate[btnCancel.Name];
            this.btnDelete.Text             = translate[btnDelete.Name];
            this.btnPrint.Text              = translate[btnPrint.Name];
            this.btnExport.Text             = translate[btnExport.Name];
            this.btnViewReport.Text         = translate[btnViewReport.Name];
            this.btnSearch.Text             = translate[btnSearch.Name];
            this.btnLogin.Text              = translate[btnLogin.Name];
            this.btnLogout.Text             = translate[btnLogout.Name];
            this.btnExit.Text               = translate[btnExit.Name];
            this.lblStore.Text              = translate[lblStore.Name];
            this.Text                       = translate["frmSaleMTMain.Text"];
        }


        #endregion
         
        #region Method
        public void mnuNewActive()
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSearch.Enabled = false;
            btnCancel.Enabled = false;
        }
        public void mnuNonActive()
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSearch.Enabled = false;
            btnCancel.Enabled = false;
            btnExport.Enabled = false;
        }
        public void SetLogin(bool login)
        {
            try
            {
                mnuInvenManagement.Visible = login;
                mnuSaleManage.Visible = login;
                //tsmnuQuanLyKHNV.Visible = false;
                //mnuLiabilityManage.Visible = false;
                mnuReport.Visible = login;
                mnuUtilities.Visible = login;
                mnuChangePassword.Visible = login;
                mnuCustomizeFormat.Visible = login;
                mnuSetupPrinter.Visible = login;
                mnuFtpConfig.Visible = login;
                btnLogin.Enabled = !login;
                btnLogout.Enabled = login;
                mnuLogin.Enabled = !login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 2/11/2013 : Kiểm tra kết ca   
        /// </summary>
        private bool CheckShifts()
        {
            bool check = false;
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                DateTime date = Convert.ToDateTime(sqlDac.GetDateTimeServer().Date);

                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", UserImformation.DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@Date", date);
                para[2] = posdb_vnmSqlDAC.newInParam("@Computername", COM_NAME);
                DataTable dtShifts = sqlDac.GetDataTable("TRANSFER_SHIFT_Check", para);
                if (dtShifts.Rows.Count > 0)
                {
                    frmShifts shift = new frmShifts(translate);
                    shift.StartPosition = FormStartPosition.CenterScreen;
                    shift.DtShifts = dtShifts;
                    shift.ShowDialog();
                    //if (shift.ShiftChecked != null)
                    //{
                    check = shift.ShiftChecked;
                    //}
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckShifts': " + ex.Message);
            }
            return check;
        }

        /// <summary>
        /// Người tạo Luannv – 09/10/2013 : Set enable menu theo mảng truyền vào từ form con theo đúng thứ tự menu button.
        /// </summary>
        public void ActiveMenu(bool[] active)
        {
            try
            {
                btnAdd.Enabled = active[0];
                btnSave.Enabled = active[1];
                btnEdit.Enabled = active[2];
                btnCancel.Enabled = active[3];
                btnDelete.Enabled = active[4];
                btnPrint.Enabled = active[5];
                btnExport.Enabled = active[6];
                btnViewReport.Enabled = active[7];
                btnSearch.Enabled = active[8];
                btnLogin.Enabled = active[9];
                btnLogout.Enabled = active[10];
                btnExit.Enabled = active[11];
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Created by Thanvn – 26/09/2013: Kiểm tra trạng thái của form, cho phép mỗi form chỉ được hiển thị một lần
        /// </summary>
        private bool checkForm(SaleMTTabForm.TabForm frmChk)
        {
            bool blIsExist = false;
            //Kiểm tra xem form đã khởi tạo chưa
            blIsExist = frmChk != null;
            //Nếu là form bán hàng thì được mở nhiều form
            if (blIsExist)
                if (frmChk.Name == "frmSale")
                    blIsExist = false;
            //Nếu đã khởi tạo kiểm tra trạng thái đóng hay chưa
            if (blIsExist)
                blIsExist = !frmChk.IsDisposed;
            return blIsExist;
        }

        private void activeChildForm(SaleMTTabForm.TabForm frmChk)
        {
            frmChk.Activate();
        }

        #endregion

        #region Event
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Application.StartupPath+@"\version.txt"))
                {
                    string s = File.ReadAllText(Application.StartupPath + @"\version.txt").Trim();
                    this.Text = "Quản lý bán hàng - Version " + s;

                    //this.Text = "Quản lý bán hàng - Version " + ConfigurationManager.AppSettings["Version"];
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadVersion' : " + ex.Message);
            }
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnExport.Enabled = false;
            btnSearch.Enabled = false;
            btnViewReport.Enabled = false;
            btnLogin.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnPrint.Enabled = false;            

            // Login
            SetLogin(false);
            getComputerINF();
            if (!SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.isReg){
                System.Environment.Exit(0);
            }

            isOdbcConnectionSync();
            

            if (!checkSqlConnection())
            {
                MessageBox.Show(Properties.Resources.OptionDatabase4.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmOptionDatabase frmOpDb = new frmOptionDatabase(translate);
                frmOpDb.ShowDialog();
            }
            else
            {
                //btnSave.Enabled = false;
                //btnEdit.Enabled = false;
                //btnCancel.Enabled = false;
                //btnExport.Enabled = false;
                //btnSearch.Enabled = false;
                //btnViewReport.Enabled = false;
                //btnLogin.Enabled = false;
                //btnDelete.Enabled = false;
                //btnAdd.Enabled = false;
                //btnPrint.Enabled = false;
                //// Login
                //SetLogin(false);
                frmLogin dlgLogin = new frmLogin(translate);
                dlgLogin.StartPosition = FormStartPosition.CenterScreen;
                dlgLogin.ShowDialog(this);
                if (dlgLogin.Logined)
                {
                    // enable menu
                    SetLogin(dlgLogin.Logined);
                    // kiểm tra kết ca
                    bool checkShift = CheckShifts();
                    if (checkShift)
                    {
                        frmLogin login = new frmLogin(translate);
                        login.StartPosition = FormStartPosition.CenterScreen;
                        login.ShowDialog(this);
                    }

                }
                // Khai bao các biến thông tin login
                //UserImformation.UserName = "POS060_01";
                //UserImformation.DeptNumber = 327;fdsf ds fsd
                //UserImformation.DeptCode = "CH40171";
                //UserImformation.DeptName = "CH GTSP Phú Mỹ Hưng  fds "; fsdsd 
                //UserImformation.StoreCode = "STO.0001";
                //UserImformation.BusinessTypeCode = "LOC.0002"; fdsfs fsd sfd
                //UserImformation.StoreAdress = "Số 10 - Tân Trào - Q7 - TPHCM";
                //UserImformation.StoreTelePhone = "(84.8)541 61 333";
                //UserImformation.StoreFax = "08 541 61 333";
                //UserImformation.CompanyName = "Công ty cổ phần sữa Việt Nam";
                //UserImformation.CompanyAdress = "Số 10 - Tân Trào - Q7 - TPHCM";
                //UserImformation.CompanyTelePhone = "(84.8)541 61 333";
                //UserImformation.CompanyFax = "08 541 61 333";

                // default customer 
                //DefaultCustomer.CusCode = "CUS.CH40171.00010";
                //DefaultCustomer.CusName = "CTY TNHH Thiên Gia Bảo";
                //DefaultCustomer.CusAdress = "65 Hưng Thái 2, P.Tân Phong,Q7";
                //DefaultCustomer.CusGroup = "CUG.0001";
                //DefaultCustomer.PersonPtrint = "Nguyễn Thị Thu Vân";
                string strCusCode = DefaultCustomer.CusCode == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultCode"] : DefaultCustomer.CusCode;
                string strCusName = DefaultCustomer.CusName == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultName"] : DefaultCustomer.CusName;
                string strCusAdress = DefaultCustomer.CusAdress == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultAdress"] : DefaultCustomer.CusAdress;
                string strCusGroup = DefaultCustomer.CusGroup == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultGroup"] : DefaultCustomer.CusGroup;
                double CusPurchase = 0;
                if (AppConfigFileSettings.appSaleMTSetting["CustomerDefaultPurchase"].ToString() != "")
                    CusPurchase = DefaultCustomer.Purchase == 0 ? Convert.ToDouble(AppConfigFileSettings.appSaleMTSetting["CustomerDefaultPurchase"]) : DefaultCustomer.Purchase;

                string strCusPersonPrint = DefaultCustomer.PersonPtrint == null ? AppConfigFileSettings.appSaleMTSetting["PersonPrintRed"] : DefaultCustomer.PersonPtrint;
                DefaultCustomer.CusCode = strCusCode;
                DefaultCustomer.CusName = strCusName;
                DefaultCustomer.CusAdress = strCusAdress;
                DefaultCustomer.CusGroup = strCusGroup;
                //DefaultCustomer.Purchase = CusPurchase;
                DefaultCustomer.PersonPtrint = strCusPersonPrint;

                string isPrintPreview, printerReport1, printerReport2, printerBill1, printerBill2;

                isPrintPreview = AppConfigFileSettings.appSaleMTSetting["isPrintPreview"];
                printerReport1 = AppConfigFileSettings.appSaleMTSetting["printerReport1"];
                printerReport2 = AppConfigFileSettings.appSaleMTSetting["printerReport2"];
                printerBill1 = AppConfigFileSettings.appSaleMTSetting["printerBill1"];
                printerBill2 = AppConfigFileSettings.appSaleMTSetting["printerBill2"];
                AppConfigFileSettings.isPrintPreview = isPrintPreview;
                AppConfigFileSettings.printerReport1 = printerReport1;
                AppConfigFileSettings.printerReport2 = printerReport2;
                AppConfigFileSettings.printerBill1 = printerBill1;
                AppConfigFileSettings.printerBill2 = printerBill2;

                AppConfigFileSettings.strOptDate = AppConfigFileSettings.appSaleMTSetting["otpDate"];
                AppConfigFileSettings.strOptNumber = AppConfigFileSettings.appSaleMTSetting["otpNumber"];
                AppConfigFileSettings.strOptDec = AppConfigFileSettings.appSaleMTSetting["otpDec"];
                AppConfigFileSettings.strOptCurency = AppConfigFileSettings.appSaleMTSetting["otpCurency"];
                AppConfigFileSettings.strOptHour = AppConfigFileSettings.appSaleMTSetting["otpHour"];

                if (UserImformation.CheckSyn == true)
                {
                    SaleMTSync.frmSync fSync = new SaleMTSync.frmSync();
                    fSync.Show();
                }
                try
                {
                    Sync s = new Sync();
                    s.CheckUpdate();
                }
                catch (Exception ex)
                {
                    log.Error("Error 'AutoUpdate' : " + ex.Message);
                }

                try
                {
                    if (Directory.Exists(Application.StartupPath + @"\SqlUpdate"))
                    {
                        //string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
                        SqlConnection conn = new SqlConnection(AppConfigFileSettings.strConnectionSql);
                        Server server = new Server(new ServerConnection(conn));

                        string[] sqlFiles = System.IO.Directory.GetFiles(Application.StartupPath + @"\SqlUpdate", "*.sql");
                        foreach (string file in sqlFiles)
                        {
                            try
                            {
                                string script = File.ReadAllText(file);
                                server.ConnectionContext.ExecuteNonQuery(script);

                                File.SetAttributes(file, FileAttributes.Normal);
                                File.Delete(file);
                            }
                            catch (Exception ex)
                            {
                                log.Error("Error 'SqlExecute' : " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error 'SqlUpdate' : " + ex.Message);
                }
            }
        }
        private bool checkSqlConnection()
        {
            bool blReValue = false;
            using (System.Data.SqlClient.SqlConnection cnnSql = new System.Data.SqlClient.SqlConnection())
            {
                try
                {
                    string strCnn;
                    string serverName = AppConfigFileSettings.appSaleMTSetting["ServerName"];
                    string dataBaseName = AppConfigFileSettings.appSaleMTSetting["DataBaseName"];
                    string userName = SaleMTEncrypt.Decrypt(AppConfigFileSettings.appSaleMTSetting["User"]);
                    string password = SaleMTEncrypt.Decrypt(AppConfigFileSettings.appSaleMTSetting["Password"]);
                    strCnn = @"Server=" + serverName + "; database=" + dataBaseName +
                            "; User ID=" + userName + "; Pwd=" + password + "; Connection Timeout=300;";
                    AppConfigFileSettings.strConnectionSql = AppConfigFileSettings.strConnectionSql == null ? strCnn : AppConfigFileSettings.strConnectionSql;
                    cnnSql.ConnectionString = AppConfigFileSettings.strConnectionSql.Replace("Connection Timeout=300;", "Connection Timeout=10;");
                    cnnSql.Open();
                    cnnSql.Close();
                    blReValue = true;
                }
                catch (Exception)
                {
                    blReValue = false;
                }
            }
            return blReValue;
        }

        private bool isOdbcConnectionSync()
        {
            bool blReValue = false;
            using (NpgsqlConnection cnnSql = new NpgsqlConnection())
            {
                try
                {
                    string strCnnSync = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                    AppConfigFileSettings.Client_ID = int.Parse(ConfigurationManager.AppSettings["Client_ID"].ToString());
                    AppConfigFileSettings.NumberDayScan = int.Parse(ConfigurationManager.AppSettings["NumberDayScan"].ToString());
                    
                    //string pass = SaleMTEncrypt.GetMd5Hash(MD5.Create(), "1");
                    AppConfigFileSettings.strConnectionSync = AppConfigFileSettings.strConnectionSync == null ? strCnnSync : AppConfigFileSettings.strConnectionSync;
                    cnnSql.ConnectionString = AppConfigFileSettings.strConnectionSync.Replace("Connection Timeout=300;", "Connection Timeout=10;");
                    cnnSql.Open();
                    cnnSql.Close();
                    blReValue = true;
                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show("Connection Synchonize Error: " + e.ToString(),"", MessageBoxButtons.OKCancel);
                    blReValue = false;
                }
            }
            return blReValue;
        }

        //Create by Hieppd - 26/09/2013: Show Form Đặt hàng, hiển thị trên Tab

        frmOrder frmOrder;
        private void mnuOrder_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesReport' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmOrder))
                    {
                        //frmOrder

                        frmOrder = new frmOrder(translate);
                        frmOrder.MdiParent = this;
                        frmOrder.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmOrder.DSSMenuTab);
                        frmOrder.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmOrder.Show();
                        frmOrder.DSSMenuTab.Text = frmOrder.Text;
                    }
                    else
                        activeChildForm(frmOrder);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        private void showDialog()
        {
            MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //Create by Hieppd - 26/09/2013: Show Form Nhập hàng, hiển thị trên Tab

        frmGoodsReceipt frmGoodsReceipt;
        private void mnuGoodsReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmImportProducts' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmGoodsReceipt))
                    {
                        //frmGoodsReceipt = new frmGoodsReceipt();
                        //frmGoodsReceipt.MdiParent = this;
                        //frmGoodsReceipt.DSSMenuBar = this.tlsTab;
                        //this.tlsTab.Items.Add(frmGoodsReceipt.DSSMenuTab);
                        //frmGoodsReceipt.Show();
                        //frmGoodsReceipt.ListButton = tlsTabbar.Items;
                        //frmGoodsReceipt.DSSMenuTab.Text = frmGoodsReceipt.Text;
                        frmGoodsReceipt = new frmGoodsReceipt(translate);
                        frmGoodsReceipt.MdiParent = this;
                        frmGoodsReceipt.DSSMenuBar = this.tlsTab;
                        this.tlsTab.Items.Add(frmGoodsReceipt.DSSMenuTab);
                        frmGoodsReceipt.ListButton = tlsTabbar.Items;
                        frmGoodsReceipt.Show();
                        frmGoodsReceipt.DSSMenuTab.Text = frmGoodsReceipt.Text;
                    }
                    else
                        activeChildForm(frmGoodsReceipt);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Xuất hàng, hiển thị trên Tab

        frmGoodsDelivery frmGoodsDelivery;
        private void mnuGoodsDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmExportToStore' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmGoodsDelivery))
                    {
                        //frmGoodsDelivery = new frmGoodsDelivery();
                        //frmGoodsDelivery.MdiParent = this;
                        //frmGoodsDelivery.DSSMenuBar = this.tlsTab;
                        //this.tlsTab.Items.Add(frmGoodsDelivery.DSSMenuTab);
                        //frmGoodsDelivery.Show();
                        //frmGoodsDelivery.ListButton = tlsTabbar.Items;
                        //frmGoodsDelivery.DSSMenuTab.Text = frmGoodsDelivery.Text;
                        frmGoodsDelivery = new frmGoodsDelivery(translate);
                        frmGoodsDelivery.MdiParent = this;
                        frmGoodsDelivery.DSSMenuBar = this.tlsTab;
                        this.tlsTab.Items.Add(frmGoodsDelivery.DSSMenuTab);
                        frmGoodsDelivery.ListButton = tlsTabbar.Items;
                        frmGoodsDelivery.Show();
                        frmGoodsDelivery.DSSMenuTab.Text = frmGoodsDelivery.Text;
                    }
                    else
                        activeChildForm(frmGoodsDelivery);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form kiểm tra tồn kho

        private void mnuCheckInventory_Click(object sender, EventArgs e)
        {
            frmCheckInventory frmCheckInven = new frmCheckInventory(translate);
            frmCheckInven.StartPosition = FormStartPosition.CenterScreen;
            frmCheckInven.ShowDialog();
        }

        //Create by Hieppd - 26/09/2013: Show Form Nhập tồn kho đầu kỳ

        private void mnuInputStock_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmImportInventory' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    //frmInputOpeningLiablity frmInput = new frmInputOpeningLiablity();
                    //frmInput.ShowDialog();
                    frmInputOpeningStock frmInput = new frmInputOpeningStock(translate);
                    frmInput.StartPosition = FormStartPosition.CenterScreen;
                    frmInput.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Nhập phiếu tặng và hiển thị trên Tab

        //frmGiftReceipt frmGiftReceipt;
        //private void tsmnuGiftReceipt_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmGiftReceipt))
        //    {
        //        frmGiftReceipt = new frmGiftReceipt();
        //        frmGiftReceipt.MdiParent = this;
        //        frmGiftReceipt.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmGiftReceipt.DSSMenuTab);
        //        frmGiftReceipt.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmGiftReceipt.Show();
        //        //frmGiftReceipt.ListButton = tlsTabbar.Items;
        //        frmGiftReceipt.DSSMenuTab.Text = frmGiftReceipt.Text;
        //    }
        //    else
        //        activeChildForm(frmGiftReceipt);
        //}

        //Create by Hieppd - 26/09/2013: Show from Xuất phiếu tặng và hiển thị trên Tab

        //frmGiftDelivery frmGiftDelivery;
        //private void mnuGiftDelivery_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmGiftDelivery))
        //    {
        //        frmGiftDelivery = new frmGiftDelivery();
        //        frmGiftDelivery.MdiParent = this;
        //        frmGiftDelivery.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmGiftDelivery.DSSMenuTab);
        //        frmGiftDelivery.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmGiftDelivery.Show();
        //        //frmGiftDelivery.ListButton = tlsTabbar.Items;
        //        frmGiftDelivery.DSSMenuTab.Text = frmGiftDelivery.Text;
        //    }
        //    else
        //        activeChildForm(frmGiftDelivery);

        //}

        //Create by Hieppd - 26/09/2013: Show Form Nhập phiếu giảm giá, hiển thị trên Tab

        //frmDiscountVoucherReceipt frmDisVoucher;
        //private void mnuDisReceipt_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmDisVoucher))
        //    {
        //        frmDisVoucher = new frmDiscountVoucherReceipt();
        //        frmDisVoucher.MdiParent = this;
        //        frmDisVoucher.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmDisVoucher.DSSMenuTab);
        //        frmDisVoucher.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmDisVoucher.Show();
        //        //frmDisVoucher.ListButton = tlsTabbar.Items;
        //        frmDisVoucher.DSSMenuTab.Text = frmDisVoucher.Text;
        //    }
        //    else
        //        activeChildForm(frmDisVoucher);
        //}

        //Create by Hieppd - 26/09/2013: Show Form Xuất phiếu giảm giá, hiển thị trên Tab

        //frmDiscountVoucherDelivery frmDisVoucherDeli;
        //private void mnuDisDelivery_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmDisVoucherDeli))
        //    {
        //        frmDisVoucherDeli = new frmDiscountVoucherDelivery();
        //        frmDisVoucherDeli.MdiParent = this;
        //        frmDisVoucherDeli.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmDisVoucherDeli.DSSMenuTab);
        //        frmDisVoucherDeli.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmDisVoucherDeli.Show();
        //        frmDisVoucherDeli.DSSMenuTab.Text = frmDisVoucherDeli.Text;
        //    }
        //    else
        //        activeChildForm(frmDisVoucherDeli);
        //}

        //Create by Hieppd - 26/09/2013: Show Form Bán hàng và hiển thị trên Tab

        frmSale frmSale;
        private void mnuSale_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'Sale Management' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmSale))
                    {
                        frmSale = new frmSale(translate);
                        frmSale.MdiParent = this;
                        frmSale.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmSale.DSSMenuTab);
                        frmSale.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmSale.Show();
                        frmSale.DSSMenuTab.Text = frmSale.Text;
                    }
                    else
                        activeChildForm(frmSale);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Hàng trả lại và hiện thị trên Tab

        frmReturnItems frmReturnItems;
        private void mnuReturnItems_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReturnsProduct' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmReturnItems))
                    {
                        frmReturnItems = new frmReturnItems(translate);
                        frmReturnItems.MdiParent = this;
                        frmReturnItems.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmReturnItems.DSSMenuTab);
                        frmReturnItems.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmReturnItems.Show();
                        frmReturnItems.DSSMenuTab.Text = frmReturnItems.Text;
                    }
                    else
                        activeChildForm(frmReturnItems);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Bán phiếu tặng và hiển thị trên Tab

        //frmSellGiftVoucher frmSellGift;
        //private void mnuSellGift_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmSellGift))
        //    {
        //        frmSellGift = new frmSellGiftVoucher();
        //        frmSellGift.MdiParent = this;
        //        frmSellGift.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmSellGift.DSSMenuTab);
        //        frmSellGift.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmSellGift.Show();
        //        frmSellGift.DSSMenuTab.Text = frmSellGift.Text;
        //    }
        //    else
        //        activeChildForm(frmSellGift);
        //}

        //Create by Hieppd - 26/09/2013: Show Form Xuất phiếu giảm giá và hiển thị trên Tab

        //frmExportDiscountVoucher frmExportVoucher;
        //private void ExportDiscount_Click(object sender, EventArgs e)
        //{
        //    if (!checkForm(frmExportVoucher))
        //    {
        //        frmExportVoucher = new frmExportDiscountVoucher();
        //        frmExportVoucher.MdiParent = this;
        //        frmExportVoucher.DSSMenuBar = this.tlsTab;
        //        tlsTab.Items.Add(frmExportVoucher.DSSMenuTab);
        //        frmExportVoucher.ListButton = tlsTabbar.Items;
        //        mnuNewActive();
        //        frmExportVoucher.Show();
        //        frmExportVoucher.DSSMenuTab.Text = frmExportVoucher.Text;
        //    }
        //    else
        //        activeChildForm(frmExportVoucher);
        //}

        //Create by Hieppd - 26/09/2013: Show Form Quản lý chi tiền

        private void mnuCashPay_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCashPayment' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmCashPaymentVoucher frmCashPay = new frmCashPaymentVoucher(translate);
                    frmCashPay.StartPosition = FormStartPosition.CenterScreen;
                    frmCashPay.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Quản lý thu tiền

        private void mnuCashReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCashReceipt' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmCashReceiptVoucher frmCashRec = new frmCashReceiptVoucher(translate);
                    frmCashRec.StartPosition = FormStartPosition.CenterScreen;
                    frmCashRec.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Quản lý hóa đơn và hiển thị trên Tab

        frmManageReceipt frmManageReceipt;
        private void mnuManageReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmInvoiceManagement' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmManageReceipt))
                    {
                        frmManageReceipt = new frmManageReceipt(translate);
                        frmManageReceipt.MdiParent = this;
                        frmManageReceipt.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmManageReceipt.DSSMenuTab);
                        frmManageReceipt.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmManageReceipt.Show();
                        frmManageReceipt.DSSMenuTab.Text = frmManageReceipt.Text;
                    }
                    else
                        activeChildForm(frmManageReceipt);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 03/11/2013: In dữ liệu ca làm việc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShiftReport_Click(object sender, EventArgs e)
        {
            try
            {
                Shifts.PrintDataShift(UserImformation.ShiftCode);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 03/11/2013: kết ca làm việc.
        /// </summary>
        private void mnuCloseShift_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult re = MessageBox.Show(Properties.rsfSales.Shift1, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (re == DialogResult.Yes)
                {
                    Shifts.EndShift(UserImformation.ShiftCode);

                    DialogResult quest = MessageBox.Show(Properties.rsfSales.Shift2, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (quest == DialogResult.Yes)
                    {
                        UserImformation.ShiftCode = Shifts.CreateNewShift();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        //Create by Hieppd - 26/09/2013: Show From Quản lý khách hàng và hiển thị trên Tab

        //frmCustomerManagement frmCusMana;
        private void mnuCustomersManage_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCustomerInfo' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmCusMana))
                    {
                        frmCusMana = new frmCustomerManagement(translate);
                        frmCusMana.MdiParent = this;
                        frmCusMana.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmCusMana.DSSMenuTab);
                        frmCusMana.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmCusMana.Show();
                        frmCusMana.DSSMenuTab.Text = frmCusMana.Text;
                    }
                    else
                        activeChildForm(frmCusMana);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luanv: 26/11/2013 - mở tab quản lý khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        frmCustomerManagement frmCusMana;
        private void tsmCusManager_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCustomerInfo' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmCusMana))
                    {
                        frmCusMana = new frmCustomerManagement(translate);
                        frmCusMana.MdiParent = this;
                        frmCusMana.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmCusMana.DSSMenuTab);
                        frmCusMana.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmCusMana.Show();
                        frmCusMana.DSSMenuTab.Text = frmCusMana.Text;
                    }
                    else
                        activeChildForm(frmCusMana);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Thông tin nhân viên và hiển thị trên Tab

        frmEmployeeInformation frmInformationEm;
        private void mnuEmployeeInfor_Click(object sender, EventArgs e)
        {
            if (!checkForm(frmInformationEm))
            {
                frmInformationEm = new frmEmployeeInformation(translate);
                frmInformationEm.MdiParent = this;
                frmInformationEm.DSSMenuBar = this.tlsTab;
                tlsTab.Items.Add(frmInformationEm.DSSMenuTab);
                frmInformationEm.ListButton = tlsTabbar.Items;
                mnuNewActive();
                frmInformationEm.Show();
                frmInformationEm.DSSMenuTab.Text = frmInformationEm.Text;
            }
            else
                activeChildForm(frmInformationEm);
        }

        //Create by Hieppd - 26/09/2013: Show Form Xếp ca làm việc và hiển thị trên Tab

        frmShiftManagement frmShiftManagement;
        private void mnuShiftmanage_Click(object sender, EventArgs e)
        {
            
            if (!checkForm(frmShiftManagement))
            {
                frmShiftManagement = new frmShiftManagement(translate);
                frmShiftManagement.MdiParent = this;
                frmShiftManagement.DSSMenuBar = this.tlsTab;
                tlsTab.Items.Add(frmShiftManagement.DSSMenuTab);
                frmShiftManagement.ListButton = tlsTabbar.Items;
                mnuNewActive();
                frmShiftManagement.Show();
                frmShiftManagement.DSSMenuTab.Text = frmShiftManagement.Text;
            }
            else
                activeChildForm(frmShiftManagement);
        }

        //Create by Hieppd - 26/09/2013: Show Form Nhân viên quét thẻ

        private void mnuTimeAttendance_Click(object sender, EventArgs e)
        {
            frmTimeAndAttendance frmTimeAtt = new frmTimeAndAttendance(translate);
            frmTimeAtt.StartPosition = FormStartPosition.CenterScreen;
            frmTimeAtt.ShowDialog();
        }

        //Create by Hieppd - 26/09/2013: Show Form Bảng kê nộp tiền

        private void mnuCashDepo_Click(object sender, EventArgs e)
        {
            frmCashDeposit frmCashDeposit = new frmCashDeposit(translate);
            frmCashDeposit.StartPosition = FormStartPosition.CenterScreen;
            frmCashDeposit.Show();
        }

        //Create by Hieppd - 26/09/2013: Show Form Thanh toán đơn hàng và hiển thị trên Tab

        frmInvoicePayment frmPayment;
        private void mnuInvoicePay_Click(object sender, EventArgs e)
        {
            if (!checkForm(frmPayment))
            {
                frmPayment = new frmInvoicePayment(translate);
                frmPayment.MdiParent = this;
                frmPayment.DSSMenuBar = this.tlsTab;
                tlsTab.Items.Add(frmPayment.DSSMenuTab);
                frmPayment.ListButton = tlsTabbar.Items;
                mnuNewActive();
                frmPayment.Show();
                frmPayment.DSSMenuTab.Text = frmPayment.Text;
            }
            else
                activeChildForm(frmPayment);
        }

        //Create by Hieppd - 26/09/2013: Show Form Nhập công nợ đầu kỳ

        private void mnuInputLiability_Click(object sender, EventArgs e)
        {
            frmInputOpeningLiablity frmOpenLiablity = new frmInputOpeningLiablity(translate);
            frmOpenLiablity.StartPosition = FormStartPosition.CenterScreen;
            frmOpenLiablity.ShowDialog();
        }

        //Create by Hieppd - 26/09/2013: Show Form Báo cáo công nợ

        private void mnuLiablityReport_Click(object sender, EventArgs e)
        {
            frmLiablityView frmReport = new frmLiablityView(translate);
            frmReport.StartPosition = FormStartPosition.CenterScreen;
            frmReport.ShowDialog();
        }

        //Create by Hieppd - 26/09/2013: Show Form Quét mã vạch

        private void mnuBarcodeScaner_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmBarcodeScan' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmBarcodeScaner frmBarcode = new frmBarcodeScaner(translate);
                    frmBarcode.StartPosition = FormStartPosition.CenterScreen;
                    frmBarcode.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Chạy tiện ích máy tính Calculator

        private void mnuCalculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        //Create by Hieppd - 26/09/2013: Chạy tiện ích soạn thảo văn bản Notepad

        private void mnuNotepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        //Create by Hieppd - 26/09/2013: Show Form So sánh số lượng

        private void mnuCompareExcel_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCompareExcelFile' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmCompareExcelFile frmcomprare = new frmCompareExcelFile(translate);
                    frmcomprare.StartPosition = FormStartPosition.CenterScreen;
                    frmcomprare.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Show Form Kiểm kê hàng và hiển thị trên Tab

        frmGoodsInventory frmGoodsInventory;
        private void mnuGoodsInventory_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'Inventory Management' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    if (!checkForm(frmGoodsInventory))
                    {
                        frmGoodsInventory = new frmGoodsInventory(translate);
                        frmGoodsInventory.MdiParent = this;
                        frmGoodsInventory.DSSMenuBar = this.tlsTab;
                        tlsTab.Items.Add(frmGoodsInventory.DSSMenuTab);
                        frmGoodsInventory.ListButton = tlsTabbar.Items;
                        mnuNewActive();
                        frmGoodsInventory.Show();
                        frmGoodsInventory.DSSMenuTab.Text = frmGoodsInventory.Text;
                    }
                    else
                        activeChildForm(frmGoodsInventory);
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Create by Hieppd - 26/09/2013: Đóng các cửa sổ đang chạy

        private void mnuExitWindow_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }


        //Show form đăng nhập
        FrmSystem.frmLogin frmLogin;
        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin = new frmLogin(translate);
            frmLogin.StartPosition = FormStartPosition.CenterScreen;
            frmLogin.ShowDialog(this);
        }

        //Show form Tùy chọn database
        FrmSystem.frmOptionDatabase frmOptionDaTa;
        private void mnuDatabaseConfig_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmConnectDB' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                frmOptionDaTa = new frmOptionDatabase(translate);
                frmOptionDaTa.StartPosition = FormStartPosition.CenterScreen;
                frmOptionDaTa.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //show form thay đổi pass
        FrmSystem.frmChangePassword frmChange;
        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmShowreport' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                frmChange = new frmChangePassword(translate);
                frmChange.StartPosition = FormStartPosition.CenterScreen;
                frmChange.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //show form định dạng
        FrmSystem.frmOptionFormat frmFormat;
        private void mnuCustomizeFormat_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCustomizeFormat' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmFormat = new frmOptionFormat(translate);
                    frmFormat.StartPosition = FormStartPosition.CenterScreen;
                    frmFormat.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //show form tùy chọn máy in
        FrmSystem.frmSetupPrinter frmPrinter;
        private void mnuSetupPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSetupPrint' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmPrinter = new frmSetupPrinter(translate);
                    frmPrinter.StartPosition = FormStartPosition.CenterScreen;
                    frmPrinter.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        //Thoát chương trình
        private void mnuQuitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Create by Hieppd - 26/09/2013: Thoát chương trình

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn thoát", "Chọn OK để thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
                this.Close();
        }



        private void tlsTab_VisibleChanged(object sender, EventArgs e)
        {
            if (!tlsTab.Visible)
            {
                mnuNonActive();
            }
        }

        private void frmSaleMTMain_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f != null)
                {
                    if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                    {
                        //int da = ((DssTabForm)f).ListButton.Count;
                        if (((SaleMTTabForm.TabForm)f).ListButton == null)
                        {
                            mnuNonActive();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnPrint.Enabled = true;
            btnDelete.Enabled = false;
            Form f = this.ActiveMdiChild;
            if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
            {
                ((SaleMTTabForm.TabForm)f).OnAddNew(e);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnSave(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnPrint.Enabled = true;
                btnDelete.Enabled = true;
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnEdit(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnPrint.Enabled = true;
                btnDelete.Enabled = true;
                Form f = this.ActiveMdiChild;
                if (f != null)
                {
                    if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                    {
                        ((SaleMTTabForm.TabForm)f).OnCancel(e);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnDelete(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnPrint(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnExportExcel(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = this.ActiveMdiChild;
                if (f.GetType().BaseType == typeof(SaleMTTabForm.TabForm))
                {
                    ((SaleMTTabForm.TabForm)f).OnSearch(e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                SetLogin(false);
                frmLogin dlgLogin = new frmLogin(translate);
                dlgLogin.StartPosition = FormStartPosition.CenterScreen;
                dlgLogin.ShowDialog(this);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin dlgLogin = new frmLogin(translate);
                dlgLogin.StartPosition = FormStartPosition.CenterScreen;
                dlgLogin.ShowDialog(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mnuRReport_Click(object sender, EventArgs e)
        {
            {
                FrmReporter.frmReport frm = new FrmReporter.frmReport(translate);
                //frm.IsMdiContainer = true;
                //frm.Show();
                frm.ShowDialog();
            }
        }

        private void mnuLogin_Click_1(object sender, EventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void mnuUserGuide_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dg = new DataGridView();
                dg.Dock = DockStyle.Fill;
                DataSet ds = new DataSet();
                //ds.ReadXml(@"D:\SaleMT\SVN\TEST\CategoryData\TEST_CategoryData_1383554280787.xml");
                string[] xmlPath = System.IO.Directory.GetFiles(@"D:\SaleMT\SVN\TEST", "*.xml", System.IO.SearchOption.AllDirectories);

                /*      
                string sqlCreateType = "Create Table SaleOnline_CategoryData(";
                foreach (DataColumn dc in ds.Tables[0].Columns) {
                    sqlCreateType += " " + dc.ColumnName + " nvarchar(50) null,";
                }
                sqlCreateType = sqlCreateType.Substring(0,sqlCreateType.Length-1) + ")";
                posdb_vnmSqlDAC dac = new posdb_vnmSqlDAC();                
                dac.InlineSql_Execute(sqlCreateType, null);*/
                posdb_vnmSqlDAC dac = new posdb_vnmSqlDAC();
                foreach (string xml in xmlPath)
                {
                    ds = new DataSet();
                    ds.ReadXml(xml);
                    //dac.Copy_To_ClientDB(ds.Tables[0], "SaleOnline_" + ds.Tables[0].TableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuFtpConfig_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmFTPMonitor' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    //OptionFTP option = new OptionFTP();
                    //option.StartPosition = FormStartPosition.CenterScreen;
                    //option.ShowDialog();
                    frmFTPMonitor ftpMon = new frmFTPMonitor(translate);
                    ftpMon.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }

        private void getComputerINF()
        {
            try
            {
                string inf, strChk;
                string reg = "";
                inf = SaleMTCommon.FingerPrint.Value();
                strChk = SaleMTDataAccessLayer.SaleMTDAL.SaleMTEncrypt.EncryptX2(inf);
                string licPath = Application.StartupPath + @"\smt.lic";
                if (System.IO.File.Exists(licPath))
                {
                    reg = System.IO.File.ReadAllText(licPath);
                }
                if (strChk != reg)
                {
                    frmRegister f = new frmRegister(translate);
                    f.LicPath = licPath;
                    f.ShowDialog();
                }
                else
                {
                    AppConfigFileSettings.isReg = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getComputerINF: " + ex.Message);
            }
        }

        private void mnuOptionSynData_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                checkPrint = false;
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesScreen' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    }
                }
                if (checkPrint)
                {
                    frmOptionData frm = new frmOptionData(translate);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
                else
                {
                    showDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoUpdate' : " + ex.Message);
            }
        }


        FrmHelp.frmAppInfo frmApp;
        private void mnuAppInfo_Click(object sender, EventArgs e)
        {
            frmApp = new SaleMTInterfaces.FrmHelp.frmAppInfo(translate);
            frmApp.ShowDialog();
        }

        FrmHelp.frmAbout frmAbout;
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout = new SaleMTInterfaces.FrmHelp.frmAbout(translate);
            frmAbout.ShowDialog();
        }

        private void quảnLýNgườiDùngNhómNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroupUser frmShow = new FrmGroupUser(translate);
            frmShow.StartPosition = FormStartPosition.CenterScreen;
            frmShow.ShowDialog();
        }
        #endregion

        


       

       

        
    }
}














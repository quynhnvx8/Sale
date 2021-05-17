using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using SaleMTBusiness.SystemManagement;
using System.IO;


namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmLogin : Form
    {
        #region Declaration
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private Ciphertext_AES aes = new Ciphertext_AES();
        private const string COM_NAME = "00";
        private bool loginAgain;

        public bool LoginAgain
        {
            get { return loginAgain; }
            set { loginAgain = value; }
        }
        private bool logined = false;

        public bool Logined
        {
            get { return logined; }
            set { logined = value; }
        }
        #endregion

        #region Contructor
        public frmLogin(Dictionary<String, String> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        #endregion

        Dictionary<String, String> translate = new Dictionary<string,string>();

        private void initLanguage()
        {
            this.label1.Text = translate["frmLogin.label1"];
            this.label2.Text = translate["frmLogin.label2"];
            this.btnLogin.Text = translate["frmLogin.btnLogin"];
            this.btnClose.Text = translate["frmLogin.btnClose"];
            this.chkRememberPass.Text = translate["frmLogin.chkRememberPass"];
            this.Text = translate["frmLogin.Text"];

        }

        #region Methods
        /// <summary>
        /// Người tạo Luannv – 2/11/2013 : Kiểm tra ca hiện tại đã tồn tại chưa 
        /// </summary>
        private string CheckShiftsCurrent()
        {
            string tranCode = "";
            try
            {
                DateTime date = Convert.ToDateTime(sqlDac.GetDateTimeServer().Date);
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", UserImformation.DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTime", date);
                para[2] = posdb_vnmSqlDAC.newInParam("@Computername", COM_NAME);
                DataTable dtShifts = sqlDac.GetDataTable("CheckIsExistTransferShiftCurrent", para);
                if (dtShifts.Rows.Count <= 0)
                {
                    tranCode = Shifts.CreateNewShift();
                }
                else
                {
                    tranCode = dtShifts.Rows[0]["TRANSFER_SHIFT_CODE"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckShiftsCurrent': " + ex.Message);
            }
            return tranCode;
        }
        /// <summary>
        /// Người tạo Hieppd – 28/10/2013 : Kiem tra thong tin dang nhap    
        /// </summary>
        private void Login()
        {

            string proc = "USERS_Read";
            SqlParameter[] paraLogin;
            paraLogin = new SqlParameter[2];//2. Nho sua ca Store
            paraLogin[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", txtUserName.Text.Trim());
            string pw = txtPassword.Text.Trim() + txtUserName.Text.ToLower().Trim();
            paraLogin[1] = posdb_vnmSqlDAC.newInParam("@Pw", SaleMTEncrypt.GetMd5Hash(System.Security.Cryptography.MD5.Create(), pw));
            DataTable dtLogin = new DataTable();
            dtLogin = sqlDac.GetDataTable(proc, paraLogin);

            if (dtLogin.Rows.Count > 0)
            {
                
                frmSaleMTMain parMain = (frmSaleMTMain)this.Owner;
                parMain.SetLogin(true);
                LoadLogin(txtUserName.Text.Trim());
                //Lay ngay hien tai cho lable ngay he thong
                parMain.lblDate.Text = "Date: " + DateTime.Now.ToString();

                //Doc thong tin server va database mac dinh tu lop userInformation gan vao cac lable he thong
                parMain.lblServer.Text = "Server: " + ConfigurationManager.AppSettings["ServerName"].ToString();
                parMain.lblDatabase.Text = "DB: " + ConfigurationManager.AppSettings["DataBaseName"].ToString();
                parMain.lblUser.Text = "User: " + txtUserName.Text.Trim();
                parMain.lblStore.Text = UserImformation.DeptCode;

                //Ghi thong tin user dang nhap
                CreateLoadLogin();
                //checkLogin();
                this.logined = true;
                this.Close();
            }
            else
            {
                frmSaleMTMain parMain = (frmSaleMTMain)(this.Owner);
                MessageBox.Show(Properties.rsfSales.Authentication2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
            }
        }

        //Ghi cac thong tin vao user dang nhap vao file he thong
        private void CreateLoadLogin()
        {
            SortedList<string, string> appSetting = new SortedList<string, string>();
            if (chkRememberPass.Checked)
            {                
                appSetting.Add("UserLogin", txtUserName.Text);
                appSetting.Add("PassLogin", SaleMTEncrypt.Encrypt(txtPassword.Text));
                appSetting.Add("checkLogin", chkRememberPass.Checked.ToString());
                //AppConfigFileSettings.chkSaveUserPass = chkRememberPass.Checked.ToString();
                AppConfigFileSettings.strPw = txtPassword.Text;
            }
            else {
                appSetting.Add("UserLogin", "");
                appSetting.Add("PassLogin", SaleMTEncrypt.Encrypt(""));
                appSetting.Add("checkLogin", chkRememberPass.Checked.ToString());
                //AppConfigFileSettings.chkSaveUserPass = null;
                AppConfigFileSettings.strPw = "";
            }
            AppConfigFileSettings.strChkPw = chkRememberPass.Checked.ToString();
            AppConfigFileSettings.UpdateAppSettings(appSetting);     
        }

        //Xu ly checkbox ghi nho thong tin dang nhap
        private void checkLogin()
        {
            if (chkRememberPass.Checked)
            {
                if (UserImformation.UserName == null) {
                    UserImformation.UserName = ConfigurationManager.AppSettings["UserLogin"].ToString();
                    AppConfigFileSettings.strPw = SaleMTEncrypt.Decrypt(ConfigurationManager.AppSettings["PassLogin"].ToString());
                }
                txtUserName.Text = UserImformation.UserName;
                txtPassword.Text = AppConfigFileSettings.strPw;
            }
        }

        /// /// 
        //load cac thong tin login
        private void LoadLogin(string acconut)
        {
            string proc = "LoadInformationEm";
            SqlParameter[] paraInfo;
            paraInfo = new SqlParameter[1];
            paraInfo[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", acconut);
            DataTable dtLogInfo = new DataTable();
            dtLogInfo = sqlDac.GetDataTable(proc, paraInfo);

            // add thong tin vao userInformation qua ten user truyen vao
            UserImformation.UserName = dtLogInfo.Rows[0][0].ToString();
            UserImformation.DeptNumber = Convert.ToInt32(dtLogInfo.Rows[0][1].ToString());
            UserImformation.DeptCode = dtLogInfo.Rows[0][8].ToString();
            UserImformation.DeptName = dtLogInfo.Rows[0][2].ToString();
            UserImformation.StoreAdress = dtLogInfo.Rows[0][11].ToString();
            UserImformation.StoreFax = dtLogInfo.Rows[0][10].ToString();
            UserImformation.StoreTelePhone = dtLogInfo.Rows[0][9].ToString();
            UserImformation.CompanyName = dtLogInfo.Rows[0][3].ToString();
            UserImformation.CompanyAdress = dtLogInfo.Rows[0][4].ToString();
            UserImformation.CompanyTelePhone = dtLogInfo.Rows[0][5].ToString();
            UserImformation.CompanyFax = dtLogInfo.Rows[0][6].ToString();
            UserImformation.BusinessTypeCode = dtLogInfo.Rows[0][13].ToString();
            UserImformation.StoreCode = dtLogInfo.Rows[0][12].ToString();
            UserImformation.ShiftCode = CheckShiftsCurrent();

            //UserImformation.FtpServer = AppConfigFileSettings.appSaleMTSetting["FtpServer"];
            //UserImformation.FtpUser = AppConfigFileSettings.appSaleMTSetting["FtpUser"];
            //UserImformation.FtpPassword = AppConfigFileSettings.appSaleMTSetting["FtpPassword"];
            //UserImformation.FtpImportPort = int.Parse(AppConfigFileSettings.appSaleMTSetting["FtpImportPort"]);
            //string ssl = AppConfigFileSettings.appSaleMTSetting["FtpImportSSL"];
            //UserImformation.FtpImportSSL = ssl=="True";

            //UserImformation.FtpExServer = AppConfigFileSettings.appSaleMTSetting["FtpExServer"];
            //UserImformation.FtpExUser = AppConfigFileSettings.appSaleMTSetting["FtpExUser"];
            //UserImformation.FtpExPassword = AppConfigFileSettings.appSaleMTSetting["FtpExPassword"];
            //UserImformation.FtpExportPort = int.Parse(AppConfigFileSettings.appSaleMTSetting["FtpExportPort"]);
            //string sslEx = AppConfigFileSettings.appSaleMTSetting["FtpExportSSL"];
            //UserImformation.FtpExportSSL = sslEx == "True"; ;

            //UserImformation.FtpImportPath = AppConfigFileSettings.appSaleMTSetting["FtpImportPath"];
            //UserImformation.FtpExportPath = AppConfigFileSettings.appSaleMTSetting["FtpExportPath"];
            //UserImformation.ClientExportPath = AppConfigFileSettings.appSaleMTSetting["ClientExportPath"];
            //UserImformation.ClientImportPath = AppConfigFileSettings.appSaleMTSetting["ClientImportPath"];

            //UserImformation.WebServiceAddress = AppConfigFileSettings.appSaleMTSetting["WebServiceAddress"];
            //UserImformation.WebServiceUsername = AppConfigFileSettings.appSaleMTSetting["WebServiceUsername"];
            //UserImformation.WebServicePassword = AppConfigFileSettings.appSaleMTSetting["WebServicePassword"];
            //UserImformation.OpenSynData = bool.Parse(AppConfigFileSettings.appSaleMTSetting["OpenSynData"]);
            //UserImformation.SysDataAfter = AppConfigFileSettings.appSaleMTSetting["SysDataAfter"];
            //UserImformation.CheckConectTime = AppConfigFileSettings.appSaleMTSetting["CheckConectTime"];
            //UserImformation.CheckSyn = bool.Parse(AppConfigFileSettings.appSaleMTSetting["CheckSyn"]);
            //UserImformation.SbtnExitSynText = AppConfigFileSettings.appSaleMTSetting["SbtnExitSynText"];

            //UserImformation.PortName = AppConfigFileSettings.appSaleMTSetting["PortName"];
            //UserImformation.BaudRate = Int32.Parse(AppConfigFileSettings.appSaleMTSetting["BaudRate"]);
            //UserImformation.ChekPole = bool.Parse(AppConfigFileSettings.appSaleMTSetting["ChekPole"]);
            try {
                UserImformation.FtpServer = AppConfigFileSettings.appSaleMTSetting["FtpServer"];
                UserImformation.FtpUser = AppConfigFileSettings.appSaleMTSetting["FtpUser"];
                UserImformation.FtpPassword = AppConfigFileSettings.appSaleMTSetting["FtpPassword"];
                UserImformation.FtpImportPort = int.Parse(AppConfigFileSettings.appSaleMTSetting["FtpImportPort"]);
                string ssl = AppConfigFileSettings.appSaleMTSetting["FtpImportSSL"];
                UserImformation.FtpImportSSL = ssl == "True";

                UserImformation.FtpExServer = AppConfigFileSettings.appSaleMTSetting["FtpExServer"];
                UserImformation.FtpExUser = AppConfigFileSettings.appSaleMTSetting["FtpExUser"];
                UserImformation.FtpExPassword = AppConfigFileSettings.appSaleMTSetting["FtpExPassword"];
                UserImformation.FtpExportPort = int.Parse(AppConfigFileSettings.appSaleMTSetting["FtpExportPort"]);
                string sslEx = AppConfigFileSettings.appSaleMTSetting["FtpExportSSL"];
                UserImformation.FtpExportSSL = sslEx == "True"; ;

                UserImformation.FtpImportPath = AppConfigFileSettings.appSaleMTSetting["FtpImportPath"];
                UserImformation.FtpExportPath = AppConfigFileSettings.appSaleMTSetting["FtpExportPath"];
                UserImformation.ClientExportPath = AppConfigFileSettings.appSaleMTSetting["ClientExportPath"];
                UserImformation.ClientImportPath = AppConfigFileSettings.appSaleMTSetting["ClientImportPath"];

                UserImformation.WebServiceAddress = AppConfigFileSettings.appSaleMTSetting["WebServiceAddress"];
                UserImformation.WebServiceUsername = AppConfigFileSettings.appSaleMTSetting["WebServiceUsername"];
                UserImformation.WebServicePassword = AppConfigFileSettings.appSaleMTSetting["WebServicePassword"];
                UserImformation.OpenSynData = bool.Parse(AppConfigFileSettings.appSaleMTSetting["OpenSynData"]);
                UserImformation.SysDataAfter = AppConfigFileSettings.appSaleMTSetting["SysDataAfter"];
                UserImformation.CheckConectTime = AppConfigFileSettings.appSaleMTSetting["CheckConectTime"];
                UserImformation.CheckSyn = bool.Parse(AppConfigFileSettings.appSaleMTSetting["CheckSyn"]);
                UserImformation.SbtnExitSynText = AppConfigFileSettings.appSaleMTSetting["SbtnExitSynText"];

                UserImformation.PortName = AppConfigFileSettings.appSaleMTSetting["PortName"];
                UserImformation.BaudRate = Int32.Parse(AppConfigFileSettings.appSaleMTSetting["BaudRate"]);
                UserImformation.ChekPole = bool.Parse(AppConfigFileSettings.appSaleMTSetting["ChekPole"]);
            }
            catch (Exception ex){
                log.Error("Error:LoadLogin " + ex.Message);
            }
            if (!Directory.Exists(UserImformation.ClientExportPath))
            {
                Directory.CreateDirectory(UserImformation.ClientExportPath);
            }
            if (!Directory.Exists(UserImformation.ClientImportPath))
            {
                Directory.CreateDirectory(UserImformation.ClientImportPath);
            }

            if (UserImformation.DeptCode != null && UserImformation.DeptCode != "")
            {
                sqlDac.InlineSql_ExecuteNonQuery("delete STORE", null);
                sqlDac.InlineSql_ExecuteNonQuery("insert into STORE values ('" + UserImformation.DeptCode + "')", null);
            }
        }
        #endregion

        #region Event
        //Su kien nut dang nhap
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                Login();
            }catch(Exception ex){
                log.Error("Error: " + ex.Message);
            }
        }

        //Su kien nut dong
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //kiem tra ghi nho thong tin dang nhap
                /*if (AppConfigFileSettings.chkSaveUserPass !=null && ConfigurationManager.AppSettings["UserLogin"].ToString() != null && ConfigurationManager.AppSettings["UserLogin"].ToString() != "")
                {
                    txtUserName.Text = ConfigurationManager.AppSettings["UserLogin"].ToString();
                    txtPassword.Text = SaleMTEncrypt.Decrypt(ConfigurationManager.AppSettings["PassLogin"].ToString());
                    chkRememberPass.Checked = true;
                }*/
                if (AppConfigFileSettings.strChkPw == null) {
                    AppConfigFileSettings.strChkPw = AppConfigFileSettings.appSaleMTSetting["checkLogin"];
                }
                chkRememberPass.Checked = AppConfigFileSettings.strChkPw == "True";
                checkLogin();                
                /*
                if (loginAgain)
                {
                    Login();
                }
                else
                {
                    logined = false;
                }*/
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            

        }

        private void chkRememberPass_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
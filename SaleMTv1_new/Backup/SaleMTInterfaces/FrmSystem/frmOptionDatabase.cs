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

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmOptionDatabase : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        //private static string connection = @"Server=192.168.1.90,1444; database=posdb_vnm; User ID=sa; Pwd=123; Connect Timeout=100;";
        #endregion

        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        public frmOptionDatabase(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }

        private void initLanguage()
        {
            this.label1.Text = translate["frmOptionDatabase.label1"];
            this.label2.Text = translate["frmOptionDatabase.label2"];
            this.label3.Text = translate["frmOptionDatabase.label3"];
            this.label4.Text = translate["frmOptionDatabase.label4"];
            this.btnSave.Text = translate["frmOptionDatabase.btnSave"];
            this.btnClose.Text = translate["frmOptionDatabase.btnClose"];
            this.Text = translate["frmOptionDatabase.Text"];
            
        }

        #region Methods

        //Show thông tin kết nối mặc định
        private void ShowConnect()
        {
            //Đọc tên server, database: Mặc định lấy từ file appConfig
            this.txtServerName.Text = ConfigurationManager.AppSettings["ServerName"].ToString();
            this.txtDatabase.Text = ConfigurationManager.AppSettings["DataBaseName"].ToString();
        }

        private void CreateConect()
        {
            if (checkNull() && checkSqlConnection())
            {
                //ghi thông tin vào file config                
                SortedList<string, string> appSetting = new SortedList<string, string>();
                appSetting.Add("ServerName", txtServerName.Text);
                appSetting.Add("DataBaseName", txtDatabase.Text);
                appSetting.Add("User", SaleMTEncrypt.Encrypt(txtUserName.Text));
                appSetting.Add("Password", SaleMTEncrypt.Encrypt(txtPassword.Text));
                AppConfigFileSettings.UpdateAppSettings(appSetting);
                MessageBox.Show(Properties.Resources.OptionDatabase3.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                MessageBox.Show(Properties.Resources.OptionDatabase4.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK);
            }
        }

        //Kiểm tra kết nối        
        private bool checkSqlConnection()
        {
            bool blReValue = false;
            using (System.Data.SqlClient.SqlConnection cnnSql = new System.Data.SqlClient.SqlConnection())
            {
                try
                {
                    string strCnn;
                    string serverName = txtServerName.Text;
                    string dataBaseName = txtDatabase.Text;
                    string userName = txtUserName.Text;
                    string password = txtPassword.Text;
                    strCnn = @"Server=" + serverName + "; database=" + dataBaseName +
                            "; User ID=" + userName + "; Pwd=" + password + "; Connect Timeout=10;";
                    cnnSql.ConnectionString = strCnn;
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

        // Bat loi cac truong null
        private bool checkNull()
        {
            if (txtUserName.Text.Trim() == "" || txtUserName.Text == null)
            {
                MessageBox.Show(Properties.Resources.OptionDatabase1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == "" || txtPassword.Text == null)
            {
                MessageBox.Show(Properties.Resources.OptionDatabase2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        #endregion
        private void frmOptionDatabase_Load(object sender, EventArgs e)
        {
            ShowConnect();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateConect();
        }


    }
}

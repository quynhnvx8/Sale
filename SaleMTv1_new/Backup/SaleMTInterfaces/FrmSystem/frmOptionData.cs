using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using System.Net;
using System.IO;
using SaleMTInterfaces;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmOptionData : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region const
        bool checkSyn;
        private const string S_TEXTOPEN = "Bật chức năng đồng bộ";
        private const string S_TEXTEXIT = "Tắt chức năng đồng bộ";
        #endregion

        #region Constructor
        
        public frmOptionData(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmOptionData.groupBox1.Text"];
            this.label6.Text = translate["frmOptionData.label6.Text"];
            this.lblPass.Text = translate["frmOptionData.lblPass.Text"];
            this.lblUserName.Text = translate["frmOptionData.lblUserName.Text"];
            this.label3.Text = translate["frmOptionData.label3.Text"];
            this.chkAccountDomain.Text = translate["frmOptionData.chkAccountDomain.Text"];
            this.lblServer.Text = translate["frmOptionData.lblServer.Text"];
            this.groupBox2.Text = translate["frmOptionData.groupBox2.Text"];
            this.chkHide.Text = translate["frmOptionData.chkHide.Text"];
            this.label8.Text = translate["frmOptionData.label8.Text"];
            this.label9.Text = translate["frmOptionData.label9.Text"];
            this.chkShowInfor.Text = translate["frmOptionData.chkShowInfor.Text"];
            this.chkOpenSynData.Text = translate["frmOptionData.chkOpenSynData.Text"];
            this.label1.Text = translate["frmOptionData.label1.Text"];
            this.label7.Text = translate["frmOptionData.label7.Text"];
            this.btnClose.Text = translate["frmOptionData.btnClose.Text"];
            this.btnSave.Text = translate["frmOptionData.btnSave.Text"];
            this.btnExit.Text = translate["frmOptionData.btnExit.Text"];
            this.label2.Text = translate["frmOptionData.label2.Text"];
            this.Text = translate["frmOptionData.Text"];
        }	

        #endregion

        #region Methods

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Kiểm tra trạng thái bật tắt đồng bộ dữ liệu
        /// </summary>
        private void CheckSyn()
        {
            if (btnExit.Text == S_TEXTEXIT)
            {
                checkSyn = false;

            }
            else
            {
                checkSyn = true;
            }

            SortedList<string, string> appSetting = new SortedList<string, string>();
            appSetting.Add("WebServiceAddress", txtServerName.Text);
            appSetting.Add("WebServiceUsername", txtUserName.Text);
            appSetting.Add("WebServicePassword", txtPassword.Text);
            appSetting.Add("OpenSynData", chkOpenSynData.Checked.ToString());
            appSetting.Add("SysDataAfter", txtDBDatabase.Text);
            appSetting.Add("CheckConectTime", txtCheckConectFalse.Text);
            appSetting.Add("CheckSyn", checkSyn.ToString());

            UserImformation.WebServiceAddress = txtServerName.Text;
            UserImformation.WebServiceUsername = txtUserName.Text;
            UserImformation.WebServicePassword = txtPassword.Text;
            UserImformation.OpenSynData = chkOpenSynData.Checked;
            UserImformation.SysDataAfter = txtDBDatabase.Text;
            UserImformation.CheckConectTime = txtCheckConectFalse.Text;
            UserImformation.CheckSyn = false;
            AppConfigFileSettings.UpdateAppSettings(appSetting);
        }
        #endregion 

        #region Event

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Load form Cấu hình đồng bộ dữ liệu
        /// </summary>
        private void frmOptionData_Load(object sender, EventArgs e)
        {
            try
            {
                string sServerName, sUser, sPass, sSynData, sConect;
                bool checkSynData;
                
                sServerName = UserImformation.WebServiceAddress;
                sUser = UserImformation.WebServiceUsername;
                sPass = UserImformation.WebServicePassword;
                checkSynData = UserImformation.OpenSynData;
                sSynData = UserImformation.SysDataAfter;
                sConect = UserImformation.CheckConectTime;
                checkSyn = UserImformation.CheckSyn;

                txtServerName.Text = sServerName;
                txtUserName.Text = sUser;
                txtPassword.Text = sPass;
                txtDBDatabase.Text = sSynData;
                txtCheckConectFalse.Text = sConect;
                chkOpenSynData.Checked = UserImformation.OpenSynData;

                if (checkSyn)
                {
                    btnExit.Text = S_TEXTEXIT;
                }
                else
                {
                    btnExit.Text = S_TEXTOPEN;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'frmOptionData': " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Lưu cấu hình đồng bộ dữ liệu
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SortedList<string, string> appSetting = new SortedList<string, string>();
                appSetting.Add("WebServiceAddress", txtServerName.Text);
                appSetting.Add("WebServiceUsername", txtUserName.Text);
                appSetting.Add("WebServicePassword", txtPassword.Text);
                appSetting.Add("OpenSynData", chkOpenSynData.Checked.ToString());
                appSetting.Add("SysDataAfter", txtDBDatabase.Text);
                appSetting.Add("CheckConectTime", txtCheckConectFalse.Text);

                UserImformation.WebServiceAddress = txtServerName.Text;
                UserImformation.WebServiceUsername = txtUserName.Text;
                UserImformation.WebServicePassword = txtPassword.Text;
                UserImformation.OpenSynData = chkOpenSynData.Checked;
                UserImformation.SysDataAfter = txtDBDatabase.Text;
                UserImformation.CheckConectTime = txtCheckConectFalse.Text;

                AppConfigFileSettings.UpdateAppSettings(appSetting);
                MessageBox.Show(Properties.rsfSales.OptionData1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SavesynData': " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error(" Error '': " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Tắt đồng bộ dữ liệu
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            CheckSyn();
            MessageBox.Show(Properties.rsfSales.OptionData1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();
        }

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Chỉ cho nhập số vào textbox 
        /// </summary>
        private void txtDBDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 03/12/2013: Chỉ cho nhập số vào textbox 
        /// </summary>
        private void txtCheckConectFalse_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion


    }
}

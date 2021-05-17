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
using System.IO.Ports;
using SaleMTInterfaces.FrmSaleManagement;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmOptionFormat : Form
    {
        #region Const
        private string TEXTDATE = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
        private string TEXTTIME = "HH:mm:ss";
        private string TEXTNUM = "#,##0";
        private string TEXTMONEY = "#,##0";
        private string TEXTSTP = "0";
        private const string TEXT_CHECK_POLE = "Sucessfull";
        private const string TEXT_CLEAR_POLE = "\x04\x01\x43\x31\x58\x17";
        private const int DATA_BIT = 8;
        SerialPort sp;
        bool CheckC ;
        #endregion

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        
        #endregion

        #region Contructor
       

        public frmOptionFormat(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboDate.Text = TEXTDATE;
            cboTime.Text = TEXTTIME;
            cboNum.Text = TEXTNUM;
            cboMoney.Text = TEXTMONEY;
            cboSTP.Text = TEXTSTP;
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.tabFormat.Text = translate["frmOptionFormat.tabFormat.Text"];
            this.groupBox2.Text = translate["frmOptionFormat.groupBox2.Text"];
            this.label6.Text = translate["frmOptionFormat.label6.Text"];
            this.label9.Text = translate["frmOptionFormat.label9.Text"];
            this.label7.Text = translate["frmOptionFormat.label7.Text"];
            this.label8.Text = translate["frmOptionFormat.label8.Text"];
            this.groupBox1.Text = translate["frmOptionFormat.groupBox1.Text"];
            this.label5.Text = translate["frmOptionFormat.label5.Text"];
            this.label4.Text = translate["frmOptionFormat.label4.Text"];
            this.label3.Text = translate["frmOptionFormat.label3.Text"];
            this.label2.Text = translate["frmOptionFormat.label2.Text"];
            this.label1.Text = translate["frmOptionFormat.label1.Text"];
            this.btnCheckDisplay.Text = translate["frmOptionFormat.btnCheckDisplay.Text"];
            this.label11.Text = translate["frmOptionFormat.label11.Text"];
            this.label10.Text = translate["frmOptionFormat.label10.Text"];
            this.chkChoose.Text = translate["frmOptionFormat.chkChoose.Text"];
            this.tabPrintInvoi.Text = translate["frmOptionFormat.tabPrintInvoi.Text"];
            this.label15.Text = translate["frmOptionFormat.label15.Text"];
            this.label14.Text = translate["frmOptionFormat.label14.Text"];
            this.label13.Text = translate["frmOptionFormat.label13.Text"];
            this.label12.Text = translate["frmOptionFormat.label12.Text"];
            this.btnSave.Text = translate["frmOptionFormat.btnSave.Text"];
            this.btnClose.Text = translate["frmOptionFormat.btnClose.Text"];
            this.Text = translate["frmOptionFormat.Text"];
        }	

        #endregion

        #region Methods

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : ghi thông tin vào defaultCustomer
        /// </summary>
        private void ShowCusDefault()
        {
            try
            {
                DefaultCustomer.CusCode = ConfigurationManager.AppSettings["CustomerDefaultCode"];
                DefaultCustomer.CusName = ConfigurationManager.AppSettings["CustomerDefaultName"];
                DefaultCustomer.CusAdress = ConfigurationManager.AppSettings["CustomerDefaultAdress"];
                DefaultCustomer.CusGroup = ConfigurationManager.AppSettings["CustomerDefaultGroup"];
                DefaultCustomer.Purchase = Convert.ToSingle(Conversion.Replaces(ConfigurationManager.AppSettings["CustomerDefaultPurchase"]));
                DefaultCustomer.PersonPtrint = ConfigurationManager.AppSettings["PersonPrintRed"];
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : ghi thông tin khách hàng sau khi tìm kiếm
        ///                  - 31/10/2013 : A Thân sửa: Lưu thông tin khách hàng tìm kiếm được vào AppConfigFileSettings
        /// </summary>
        private void CreateLoadLogin()
        {
            try
            {
                SortedList<string, string> appSetting = new SortedList<string, string>();
                appSetting.Add("CustomerDefaultCode", txtCustomerCode.Text);
                appSetting.Add("CustomerDefaultName", txtCustomerName.Text);
                appSetting.Add("CustomerDefaultAdress", txtCusAdress.Text);
                appSetting.Add("CustomerDefaultGroup", txtCusGroup.Text);
                appSetting.Add("CustomerDefaultPurchase", txtCusPurchase.Text);
                appSetting.Add("PersonPrintRed", txtName.Text);

                appSetting.Add("otpDate", cboDate.Text);
                appSetting.Add("otpNumber", cboNum.Text);
                appSetting.Add("otpDec", cboSTP.Text);
                appSetting.Add("otpCurency", cboMoney.Text);
                appSetting.Add("otpHour", cboTime.Text);

                //lưu thông tin pole
                appSetting.Add("PortName", cboComPort.Text);
                appSetting.Add("BaudRate", cboBRate.Text);
                appSetting.Add("DataBits", "8");
                appSetting.Add("ChekPole", chkChoose.Checked.ToString());


                AppConfigFileSettings.strOptDate = cboDate.Text;
                AppConfigFileSettings.strOptNumber = cboNum.Text;
                AppConfigFileSettings.strOptDec = cboSTP.Text;
                AppConfigFileSettings.strOptCurency = cboMoney.Text;
                AppConfigFileSettings.strOptHour = cboTime.Text;

                AppConfigFileSettings.UpdateAppSettings(appSetting);
                DefaultCustomer.CusCode = txtCustomerCode.Text;
                DefaultCustomer.CusName = txtCustomerName.Text;
                DefaultCustomer.CusAdress = txtCusAdress.Text;
                DefaultCustomer.CusGroup = txtCusGroup.Text.Trim();
                DefaultCustomer.Purchase = (txtCusPurchase.Text.Trim() != "" )?Convert.ToDouble(Conversion.Replaces(txtCusPurchase.Text.Trim())):0;
                DefaultCustomer.PersonPtrint = txtName.Text;

                //Lưu thông tin pole vào userImfomation
                
                UserImformation.PortName = cboComPort.Text;
                UserImformation.BaudRate = (cboBRate.Text.Trim() != "") ? int.Parse(cboBRate.Text) : 0;
                UserImformation.DataBits = 8;
                UserImformation.ChekPole = chkChoose.Checked;
                AppConfigFileSettings.UpdateAppSettings(appSetting);
                //ShowCusDefault();
                MessageBox.Show(Properties.Resources.SystemSetupPrinter.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

            
        }

        /// <summary>
        /// Người tạo Hieppd – 10/12/2013 : Hien thi thong tin khi an nut check HienThi
        /// </summary>
        private void PoleDisplay()
        {
            try
            {
                if (chkChoose.Checked)
                {
                    if (CheckCOM())
                    {
                        sp = new SerialPort();

                        sp.PortName = cboComPort.Text;
                        sp.BaudRate = Int32.Parse(cboBRate.Text);
                        sp.Parity = Parity.None;
                        sp.DataBits = DATA_BIT;
                        sp.StopBits = StopBits.One;
                        sp.Open();
                        sp.Write(TEXT_CLEAR_POLE);
                        sp.WriteLine(TEXT_CHECK_POLE);

                        sp.Close();
                    }
                    else
                        MessageBox.Show(SaleMTInterfaces.Properties.rsfSales.SCom.ToString(), SaleMTInterfaces.Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                               MessageBoxIcon.Asterisk); 

                }
                 
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Hieppd – 10/12/2013 : Load Cac cong COM tren may tinh vao combobox Port
        /// </summary> 
        private void LoadComTo()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string s in ports)
                {
                    cboComPort.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: LoadComTo" + ex.Message);
            }
               
        }
        /// <summary>
        /// Người tạo Hieppd – 10/12/2013 : Kiem tra xem co cong Pole khong
        /// </summary>
        private bool CheckCOM()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string s in ports)
                {
                    if (UserImformation.PortName == s)
                    {
                        CheckC = true;
                    }
                    else
                    {
                        CheckC = false;
                    }

                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error: CheckCom" + ex.Message);
            }
            return CheckC;
        }

        #endregion

        #region Event

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Bắt sự kiện thay đổi item trong combobox date    
        /// </summary>
        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDate.Text = DateTime.Now.ToString(cboDate.Text);
                txtDate.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Bắt sự kiện thay đổi item trong combobox time    
        /// </summary>
        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTime.Text = DateTime.Now.ToString(cboTime.Text);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Định dạng combobox number  
        /// </summary>
        private void cboNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNum.Text == "##0")
            {
                txtNum.Text = "123456789";
                txtNum.Enabled = false;
            }
            else
            {
                txtNum.Text = "123.456.789";
            }
        }

        //Bắt sự kiện đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Định dạng combobox money     
        /// </summary>
        private void cboMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoney.Text == "##0")
            {
                txtMoney.Text = "123456789";
            }
            else
                txtMoney.Text = "123.456.789";
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Định dạng số thập phân     
        /// </summary>
        private void cboSTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNum.Text == "##0")
            {
                switch (cboSTP.Text)
                {
                    case "0":
                        {
                            txtNum.Text = "123456789";
                            break;
                        }
                    case "1":
                        {
                            txtNum.Text = "123456789.1";
                            break;
                        }
                    case "2":
                        {

                            txtNum.Text = "123456789.12";
                            break;
                        }
                    case "3":
                        {
                            txtNum.Text = "123456789.123";
                            break;
                        }
                    case "4":
                        {
                            txtNum.Text = "123456789.1235";
                            break;
                        }
                    case "5":
                        {
                            txtNum.Text = "123456789.12346";
                            break;
                        }
                    case "6":
                        {
                            txtNum.Text = "123456789.123457";
                            break;
                        }
                    case "7":
                        {
                            txtNum.Text = "123456789.1234570";
                            break;
                        }
                    case "8":
                        {
                            txtNum.Text = "123456789.12345700";
                            break;
                        }
                    case "9":
                        {
                            txtNum.Text = "123456789.123457000";
                            break;
                        }
                }
            }
            else
            {
                switch (cboSTP.Text)
                {
                    case "0":
                        {
                            txtNum.Text = "123.456.789";
                            break;
                        }
                    case "1":
                        {
                            txtNum.Text = "123.456.789.1";
                            break;
                        }
                    case "2":
                        {

                            txtNum.Text = "123.456.789.12";
                            break;
                        }
                    case "3":
                        {
                            txtNum.Text = "123.456.789.123";
                            break;
                        }
                    case "4":
                        {
                            txtNum.Text = "123.456.789.1235";
                            break;
                        }
                    case "5":
                        {
                            txtNum.Text = "123.456.789.12346";
                            break;
                        }
                    case "6":
                        {
                            txtNum.Text = "123.456.789.123457";
                            break;
                        }
                    case "7":
                        {
                            txtNum.Text = "123.456.789.1234570";
                            break;
                        }
                    case "8":
                        {
                            txtNum.Text = "123.456.789.12345700";
                            break;
                        }
                    case "9":
                        {
                            txtNum.Text = "123.456.789.123457000";
                            break;
                        }
                }
            }
        }

        //Xử lý nút save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CreateLoadLogin();
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Xử lý nút tìm kiếm khách hàng   
        /// </summary>
        private void btnCustimerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int dept = UserImformation.DeptNumber;
                SaleEntities saleEn = Sale.SearchCustomer(txtCustomerCode.Text, dept, sqlDac, translate);
                if (saleEn != null)
                {
                    txtCustomerName.Text = saleEn.CusName;
                    txtCustomerCode.Text = saleEn.CusCode;
                    txtCusAdress.Text = saleEn.CusAdress;
                    txtCusGroup.Text = saleEn.CusGroup;
                    txtCusPurchase.Text = saleEn.CusPurchase.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 31/10/2013 : load thông tin khách hàng vừa tìm kiếm được vào các textbox sau trạng thái đóng/mở form Tùy chỉnh  
        /// </summary>
        private void frmOptionFormat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComTo();
                if (ConfigurationManager.AppSettings["CustomerDefaultCode"].ToString() != null && ConfigurationManager.AppSettings["CustomerDefaultCode"].ToString() != "")
                {
                    string strCusCode = DefaultCustomer.CusCode == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultCode"] : DefaultCustomer.CusCode;
                    string strCusName = DefaultCustomer.CusName == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultName"] : DefaultCustomer.CusName;
                    string strCusAdress = DefaultCustomer.CusAdress == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultAdress"] : DefaultCustomer.CusAdress;
                    string strCusGroup = DefaultCustomer.CusGroup == null ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultGroup"] : DefaultCustomer.CusGroup;
                    string strCusPurchase = DefaultCustomer.Purchase == 0 ? AppConfigFileSettings.appSaleMTSetting["CustomerDefaultPurchase"] : DefaultCustomer.Purchase.ToString();
                    string strCusPersonPrint = DefaultCustomer.PersonPtrint == null ? AppConfigFileSettings.appSaleMTSetting["PersonPrintRed"] : DefaultCustomer.PersonPtrint;
                    txtCustomerCode.Text = strCusCode;
                    txtCustomerName.Text = strCusName;
                    txtCusAdress.Text = strCusAdress;
                    txtCusGroup.Text = strCusGroup;
                    txtCusPurchase.Text = strCusPurchase;
                    txtName.Text = strCusPersonPrint;
                }
                string strOptDate, strOptHour, strOptNumber, strOptDec, strOptCurency;

                strOptDate = AppConfigFileSettings.strOptDate;
                strOptHour = AppConfigFileSettings.strOptHour;
                strOptNumber = AppConfigFileSettings.strOptNumber;
                strOptDec = AppConfigFileSettings.strOptDec;
                strOptCurency = AppConfigFileSettings.strOptCurency;
                if (strOptDate == null) {
                    strOptDate = AppConfigFileSettings.appSaleMTSetting["otpDate"];
                    strOptHour = AppConfigFileSettings.appSaleMTSetting["otpHour"];
                    strOptNumber = AppConfigFileSettings.appSaleMTSetting["otpNumber"];
                    strOptDec = AppConfigFileSettings.appSaleMTSetting["otpDec"];
                    strOptCurency = AppConfigFileSettings.appSaleMTSetting["otpCurency"];                    
                }
                cboDate.Text = strOptDate;
                cboNum.Text = strOptNumber;
                cboSTP.Text = strOptDec;
                cboMoney.Text = strOptCurency;
                cboTime.Text = strOptHour;

                //Load Pole
                
                if (UserImformation.ChekPole)
                {
                    string portName, baudRate;
                    
                    portName = UserImformation.PortName;
                    baudRate = UserImformation.BaudRate.ToString();

                    chkChoose.Checked = UserImformation.ChekPole;
                    cboComPort.Text = portName;
                    cboBRate.Text = baudRate;
                    btnCheckDisplay.Enabled = true;
                }
                else
                {
                    chkChoose.Checked = false;
                    cboComPort.Enabled = false;
                    cboBRate.Enabled = false;
                    btnCheckDisplay.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }

        /// <summary>
        /// Người tạo Hieppd – 30/10/2013 : Xử lý phím Enter sau khi nhập text tìm kiếm  
        /// </summary>
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int dept = UserImformation.DeptNumber;
                    SaleEntities saleEn = Sale.SearchCustomer(txtCustomerCode.Text, dept, sqlDac, translate);
                    if (saleEn != null)
                    {
                        txtCustomerName.Text = saleEn.CusName;
                        txtCustomerCode.Text = saleEn.CusCode;
                        txtCusAdress.Text = saleEn.CusAdress;
                        txtCusGroup.Text = saleEn.CusGroup;
                        txtCusPurchase.Text = saleEn.CusPurchase.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkChoose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkChoose.Checked)
                {
                    cboComPort.Enabled = true;
                    cboBRate.Enabled = true;
                    btnCheckDisplay.Enabled = true;
                }
                else
                {
                    cboComPort.Enabled = false;
                    cboBRate.Enabled = false;
                    btnCheckDisplay.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnCheckDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                PoleDisplay();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Poledisplay': " + ex.Message);
            }
        }

        #endregion
        
    }
}

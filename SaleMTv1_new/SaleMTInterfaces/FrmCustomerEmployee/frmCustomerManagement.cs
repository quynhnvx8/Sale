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
using SaleMTBusiness.CustomerManagement;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTInterfaces.FrmSaleManagement;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Diagnostics;

namespace SaleMTInterfaces.FrmCustomerEmployee
{
    /// <summary>
    /// Người tạo Luannv – 12/10/2013 : Quản lý khách hàng .
    /// </summary>
    public partial class frmCustomerManagement : TabForm
    {
        #region Declaration

        #region Variables
        private const string CUS_CODE = "CUS.";
        private string sexPrifix = Properties.rsfMasterCode.Sex.ToString().Trim();
        private string relPrifix = Properties.rsfMasterCode.Relligion.ToString().Trim();
        private string bloPrifix = Properties.rsfMasterCode.Blood.ToString().Trim();
        private string racPrefix = Properties.rsfMasterCode.Race.ToString().Trim();
        private string cugPrefix = Properties.rsfMasterCode.CustomerGroup.ToString().Trim();
        private string masPrefix = Properties.rsfMasterCode.Marrital.ToString().Trim();
        private string couPrefix = Properties.rsfMasterCode.Country.ToString().Trim();
        private string occPrefix = Properties.rsfMasterCode.Job.ToString().Trim();
        private string prcPrefix = Properties.rsfMasterCode.Province.ToString().Trim();
        private string disPrefix = Properties.rsfMasterCode.District.ToString().Trim();
        private string warPrefix = Properties.rsfMasterCode.Ward.ToString().Trim();
        private string cardPrefix = Properties.rsfMasterCode.CardType.ToString().Trim();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<CUSTOMERS> listCus = new List<CUSTOMERS>();
        private DataTable dtPro;
        private bool[] status;
        #endregion

        #region Const
        private const int HEIGHT_PANEL = 28;
        private const int HEIGHT_TRANFER_ITEM = 194;
        private const int HEIGHT_CONTACT = 368;
        private const int DISTANCE_TOP =0;
        private const int DISTANCE = 0;
        private const int WIDTH_PANEL = 782;

        private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        private string exCode = "";
        string customerId_Mail = "";
        #endregion

        #endregion

        #region Contructor
        public frmCustomerManagement(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label1.Text = translate["frmCustomerManagement.label1.Text"];
            this.gbxTim.Text = translate["frmCustomerManagement.gbxTim.Text"];
            this.btnCustomerSearch.Text = translate["frmCustomerManagement.btnCustomerSearch.Text"];
            this.gbxDanhSachKH.Text = translate["frmCustomerManagement.gbxDanhSachKH.Text"];
            this.columnHeader1.Text = translate["frmCustomerManagement.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmCustomerManagement.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmCustomerManagement.columnHeader3.Text"];
            this.tabCustomer.Text = translate["frmCustomerManagement.tabCustomer.Text"];
            this.gbxTTKhachhang.Text = translate["frmCustomerManagement.gbxTTKhachhang.Text"];
            this.label17.Text = translate["frmCustomerManagement.label17.Text"];
            this.label16.Text = translate["frmCustomerManagement.label16.Text"];
            this.label15.Text = translate["frmCustomerManagement.label15.Text"];
            this.label8.Text = translate["frmCustomerManagement.label8.Text"];
            this.label46.Text = translate["frmCustomerManagement.label46.Text"];
            this.label45.Text = translate["frmCustomerManagement.label45.Text"];
            this.label44.Text = translate["frmCustomerManagement.label44.Text"];
            this.label43.Text = translate["frmCustomerManagement.label43.Text"];
            this.label42.Text = translate["frmCustomerManagement.label42.Text"];
            this.label41.Text = translate["frmCustomerManagement.label41.Text"];
            this.label40.Text = translate["frmCustomerManagement.label40.Text"];
            this.label39.Text = translate["frmCustomerManagement.label39.Text"];
            this.label38.Text = translate["frmCustomerManagement.label38.Text"];
            this.label37.Text = translate["frmCustomerManagement.label37.Text"];
            this.label36.Text = translate["frmCustomerManagement.label36.Text"];
            this.label35.Text = translate["frmCustomerManagement.label35.Text"];
            this.label34.Text = translate["frmCustomerManagement.label34.Text"];
            this.label33.Text = translate["frmCustomerManagement.label33.Text"];
            this.label32.Text = translate["frmCustomerManagement.label32.Text"];
            this.label31.Text = translate["frmCustomerManagement.label31.Text"];
            this.label30.Text = translate["frmCustomerManagement.label30.Text"];
            this.label29.Text = translate["frmCustomerManagement.label29.Text"];
            this.label26.Text = translate["frmCustomerManagement.label26.Text"];
            this.label25.Text = translate["frmCustomerManagement.label25.Text"];
            this.label21.Text = translate["frmCustomerManagement.label21.Text"];
            this.label20.Text = translate["frmCustomerManagement.label20.Text"];
            this.label19.Text = translate["frmCustomerManagement.label19.Text"];
            this.chkCusOfStore.Text = translate["frmCustomerManagement.chkCusOfStore.Text"];
            this.label18.Text = translate["frmCustomerManagement.label18.Text"];
            this.chkOther.Text = translate["frmCustomerManagement.chkOther.Text"];
            this.label14.Text = translate["frmCustomerManagement.label14.Text"];
            this.label13.Text = translate["frmCustomerManagement.label13.Text"];
            this.label12.Text = translate["frmCustomerManagement.label12.Text"];
            this.label11.Text = translate["frmCustomerManagement.label11.Text"];
            this.label10.Text = translate["frmCustomerManagement.label10.Text"];
            this.label9.Text = translate["frmCustomerManagement.label9.Text"];
            this.label7.Text = translate["frmCustomerManagement.label7.Text"];
            this.label6.Text = translate["frmCustomerManagement.label6.Text"];
            this.label5.Text = translate["frmCustomerManagement.label5.Text"];
            this.label4.Text = translate["frmCustomerManagement.label4.Text"];
            this.label3.Text = translate["frmCustomerManagement.label3.Text"];
            this.label2.Text = translate["frmCustomerManagement.label2.Text"];
            this.tabCustomerHistory.Text = translate["frmCustomerManagement.tabCustomerHistory.Text"];
            this.label28.Text = translate["frmCustomerManagement.label28.Text"];
            this.btnPhone.Text = translate["frmCustomerManagement.btnPhone.Text"];
            this.label47.Text = translate["frmCustomerManagement.label47.Text"];
            this.label48.Text = translate["frmCustomerManagement.label48.Text"];
            this.label49.Text = translate["frmCustomerManagement.label49.Text"];
            this.label50.Text = translate["frmCustomerManagement.label50.Text"];
            this.btnSaveFeedback.Text = translate["frmCustomerManagement.btnSaveFeedback.Text"];
            this.label22.Text = translate["frmCustomerManagement.label22.Text"];
            this.label23.Text = translate["frmCustomerManagement.label23.Text"];
            this.label24.Text = translate["frmCustomerManagement.label24.Text"];
            this.label27.Text = translate["frmCustomerManagement.label27.Text"];
            this.btnEmail.Text = translate["frmCustomerManagement.btnEmail.Text"];
            this.button3.Text = translate["frmCustomerManagement.button3.Text"];
            this.button2.Text = translate["frmCustomerManagement.button2.Text"];
            this.groupBox4.Text = translate["frmCustomerManagement.groupBox4.Text"];
            this.dataGridViewTextBoxColumn3.HeaderText = translate["frmCustomerManagement.dataGridViewTextBoxColumn3.HeaderText"];
            this.dataGridViewTextBoxColumn4.HeaderText = translate["frmCustomerManagement.dataGridViewTextBoxColumn4.HeaderText"];
            this.dataGridViewTextBoxColumn5.HeaderText = translate["frmCustomerManagement.dataGridViewTextBoxColumn5.HeaderText"];
            this.Column6.HeaderText = translate["frmCustomerManagement.Column6.HeaderText"];
            this.Column7.HeaderText = translate["frmCustomerManagement.Column7.HeaderText"];
            this.Column8.HeaderText = translate["frmCustomerManagement.Column8.HeaderText"];
            this.Column9.HeaderText = translate["frmCustomerManagement.Column9.HeaderText"];
            this.Column10.HeaderText = translate["frmCustomerManagement.Column10.HeaderText"];
            this.dataGridViewTextBoxColumn1.HeaderText = translate["frmCustomerManagement.dataGridViewTextBoxColumn1.HeaderText"];
            this.dataGridViewTextBoxColumn2.HeaderText = translate["frmCustomerManagement.dataGridViewTextBoxColumn2.HeaderText"];
            this.groupBox2.Text = translate["frmCustomerManagement.groupBox2.Text"];
            this.Column3.HeaderText = translate["frmCustomerManagement.Column3.HeaderText"];
            this.Column4.HeaderText = translate["frmCustomerManagement.Column4.HeaderText"];
            this.Column5.HeaderText = translate["frmCustomerManagement.Column5.HeaderText"];
            this.groupBox1.Text = translate["frmCustomerManagement.groupBox1.Text"];
            this.Column1.HeaderText = translate["frmCustomerManagement.Column1.HeaderText"];
            this.colExportCode.HeaderText = translate["frmCustomerManagement.colExportCode.HeaderText"];
            this.Text = translate["frmCustomerManagement.Text"];
        }	

        #endregion

        #region Method/Function
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán giá trị thông tin khách hàng vào các control .
        /// </summary>
        private void SetValueControlText(CUSTOMERS cus)
        {
            try
            {
                // enable coltrol
                txtOldCode.Enabled = true;
                txtSurName.Enabled = true;
                txtName.Enabled = true;
                //set dữ liệu
                txtCustomerCode.Text = cus.CUSTOMER_ID;
                txtOldCode.Text = cus.MACU;
                txtSurName.Text = cus.LAST_NAME;
                txtName.Text = cus.FIRST_NAME;
                txtBarCode.Text = cus.BARCODE;
                if (cus.DATE_OF_BIRTH.HasValue)
                    dtpDateOfBirth.Value = cus.DATE_OF_BIRTH.Value;
                else
                    dtpDateOfBirth.Checked = false;
                txtBirthPlace.Text = cus.PLACE_OF_BIRTH;
                if(cus.SEX_CODE != null)
                    cboGender.SelectedValue = cus.SEX_CODE;    
                if (cus.OCCUPATION_CODE != null)
                    cboJob.SelectedValue = cus.OCCUPATION_CODE;
                else
                {
                    chkOther.Checked = true;                    
                    cboJob.Text = cus.OCCUPATION_OTHER;
                }
                if(cus.MARITAL_STATUS != null)
                    cboMarriage.SelectedValue = cus.MARITAL_STATUS;
                if (cus.CUSTOMER_GROUP_CODE != null)
                    cboCustomerGroup.SelectedValue = cus.CUSTOMER_GROUP_CODE;
                
                txtScore.Text = Conversion.GetCurrency(cus.MONEY.ToString());
                if(cus.IS_PRIVATE.HasValue)
                    chkCusOfStore.Checked = cus.IS_PRIVATE.Value;

                int deptCode = (cus.DEPT_CODE.HasValue) ? cus.DEPT_CODE.Value : 0;
                chkCusOfStore.Checked = (UserImformation.DeptNumber == deptCode) ? true : false;

                txtIdentityCard.Text = cus.ID_NO;
                if (cus.ID_NO_ISSUED_DATE.HasValue && cus.ID_NO_ISSUED_DATE > Convert.ToDateTime("01/01/1900"))
                    dtpDateOfIssue.Value = cus.ID_NO_ISSUED_DATE.Value;
                else
                    dtpDateOfIssue.Checked = false;
                txtIDNoPlaces.Text = cus.ID_NO_ISSUED_PLACE;                
                rtfRemarks.Text = cus.REMARK;
                //
                txtTelephone.Text = cus.TEL;
                txtFax.Text = cus.FAX;
                txtEmail.Text = cus.EMAIL_ADDRESS;
                txtMobilePhone.Text = cus.MOBILE_PHONE;
                if(cus.COUNTRY_CODE != null)
                    cboCountry.SelectedValue = cus.COUNTRY_CODE;
                if(cus.PROVINCE_CITY_CODE != null)
                cboProvince.SelectedValue = cus.PROVINCE_CITY_CODE;
                if (cus.DISTRICT_CODE != null)
                    cboDistrict.SelectedValue = cus.DISTRICT_CODE;
                else
                    cboDistrict.Text = cus.DISTRICT_OTHER;

                cboWard.Text = cus.COMMUNES_WARDS;
                // tách riêng HOUSE_STREET thành tên đường và số nhà
                if (cus.HOUSE_STREET != null)
                {
                    txtStreetName.Text = (cus.HOUSE_STREET.ToString().IndexOf("|") > 1) ? cus.HOUSE_STREET.Split('|')[0] : cus.HOUSE_STREET;
                    txtHouse.Text = (cus.HOUSE_STREET.ToString().IndexOf("|") != -1) ? cus.HOUSE_STREET.Split('|')[1] : "";
                }
                //
                if (cus.CUSTOMER_TYPE_CODE == null)
                    cus.CUSTOMER_TYPE_CODE = "";

                dtpCreateDateCard.Enabled = (cus.CUSTOMER_TYPE_CODE.ToString().Trim() == "");                
                cboCardType.Enabled = (cus.CUSTOMER_TYPE_CODE.ToString().Trim() == "");

                if (cus.CREATEDATECARD.HasValue)
                {
                    dtpCreateDateCard.Value = cus.CREATEDATECARD.Value;
                    dtpCreateDateCard.Checked = true;
                }
                else
                    dtpCreateDateCard.Checked = false;

                //dtpCreateDateCard.Checked = (cus.CUSTOMER_TYPE_CODE.ToString().Trim() == "");

                if(cus.CUSTOMER_TYPE_CODE != null)
                    cboCardType.SelectedValue = cus.CUSTOMER_TYPE_CODE;

                txtAdress.Text = cus.ADDRESS;
                txtWorkUnit.Text = cus.WORKING_OFFICE;
                txtWorkPlace.Text = cus.OFFICE_ADDRESS;
                txtTaxCode.Text = cus.TAX_CODE;

                //
                dtpDateCreate.Value = (cus.CREATE_DATE.HasValue) ? cus.CREATE_DATE.Value : sqlDac.GetDateTimeServer();
                dtpDateUpdate.Value = (cus.UPDATE_DATE.HasValue) ? cus.UPDATE_DATE.Value : sqlDac.GetDateTimeServer();
                txtCreateBy.Text = cus.CREATE_BY;
                txtUpdateBy.Text = cus.LAST_UPDATE_BY;
                txtCreatePlace.Text = ReturnItem.GetPlaceCreate(deptCode, sqlDac);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán giá trị thông tin khách hàng vào các control .
        /// </summary>
        private bool ValidateCustomer()
        {
            Properties.rsfEmployee manager = new SaleMTInterfaces.Properties.rsfEmployee();
            bool val = true;
            try
            {
                if (txtSurName.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer1,Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtSurName.Focus();
                }
                else if (txtName.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer1, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtName.Focus();
                }
                else if (cboCustomerGroup.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show("Vui lòng chọn nhóm khách hàng.", Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboCustomerGroup.Focus();
                }
                else if (txtMobilePhone.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer2, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtMobilePhone.Focus();
                }
                else if (cboCountry.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer3, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboCountry.Focus();
                }
                else if (cboProvince.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer4, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboProvince.Focus();
                }
                else if (cboDistrict.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer5, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboDistrict.Focus();
                }
                else if (cboWard.Text.Trim() == "")
                {
                    val = false;
                    MessageBox.Show(Properties.rsfEmployee.Customer6, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    cboWard.Focus();
                }
                //else if (cboCardType.Text.Trim() == "")
                //{
                //    val = false;
                //    MessageBox.Show(Properties.rsfEmployee.Customer10, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                //                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    cboCardType.Focus();
                //}
                //else if (dtpCreateDateCard.Checked != true && dtpCreateDateCard.Enabled == true)
                //{
                //    val = false;
                //    MessageBox.Show(Properties.rsfEmployee.Customer11, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                //                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    dtpCreateDateCard.Focus();
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error 'Validate': " + ex.Message);
            }
            return val;
        }               
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Làm rỗng các control .
        /// </summary>
        private void RessetControl()
        {
            try
            {
                txtCustomerCode.Text = "";
                txtOldCode.Text = "";
                txtSurName.Text = "";
                txtName.Text = "";
                txtBarCode.Text = "";
                dtpDateOfBirth.Value = sqlDac.GetDateTimeServer();
                dtpDateOfBirth.Checked = false;
                txtBirthPlace.Text = "";
                cboGender.SelectedIndex = -1;                
                chkOther.Checked = false;
                cboJob.SelectedIndex = -1;
                cboMarriage.SelectedIndex = -1;
                if(cboCustomerGroup.Items.Count > 1)
                    cboCustomerGroup.SelectedIndex = 1;
                else
                    cboCustomerGroup.SelectedIndex = -1;
                txtScore.Text = "";

                chkCusOfStore.Checked = false;

                txtIdentityCard.Text = "";
                dtpDateOfIssue.Value = sqlDac.GetDateTimeServer();
                dtpDateOfIssue.Checked = false;
                txtIDNoPlaces.Text = "";                
                rtfRemarks.Text = "";
                //
                txtTelephone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                txtMobilePhone.Text = "";                
                cboCountry.SelectedIndex = -1;
                cboProvince.SelectedIndex = -1;
                cboDistrict.SelectedIndex = -1;
                cboWard.SelectedIndex = -1;

                txtStreetName.Text = "";
                txtHouse.Text = "";
                txtAdress.Text = "";
                txtWorkUnit.Text = "";
                txtWorkPlace.Text = "";
                txtTaxCode.Text = "";
                //
                cboCardType.Enabled = true;
                dtpCreateDateCard.Enabled = true;
                dtpCreateDateCard.Checked = true;
                cboCardType.SelectedIndex = -1;
                dtpCreateDateCard.Text = string.Empty;
                //
                dtpDateCreate.Value = sqlDac.GetDateTimeServer();
                dtpDateUpdate.Value = sqlDac.GetDateTimeServer();
                txtCreateBy.Text = UserImformation.UserName;
                txtUpdateBy.Text = "";
                txtCreatePlace.Text = ReturnItem.GetPlaceCreate(UserImformation.DeptNumber, sqlDac);
                //                
            }
            catch (Exception ex)
            {
                log.Error("Error 'RessetControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load dữ liệu theo khách hàng .
        /// </summary>
        private void LoadData(CUSTOMERS cus)
        {
            try
            {
                //SetValueControlText(cus);
                //thêm khách hàng vào lưới
                bool check = true;
                for (int i = 0; i < listCus.Count; i++)
                {
                    if (listCus[i].CUSTOMER_ID == cus.CUSTOMER_ID)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    //thêm vào list<T>
                    listCus.Add(cus);
                    // thêm vào listview
                    int count = lvwCustomers.Items.Count;
                    lvwCustomers.Items.Add(cus.CUSTOMER_ID);
                    lvwCustomers.Items[count].SubItems.Add(cus.FIRST_NAME);
                    lvwCustomers.Items[count].SubItems.Add(cus.LAST_NAME);
                    lvwCustomers.Items[count].Selected = true;
                    if (count % 2 == 1)
                    {
                        lvwCustomers.Items[count].BackColor = Color.FromArgb(224, 223, 227);
                    }

                }
                if (lvwCustomers.Items.Count > 0)
                {
                    pnlProductBuy.Visible = true;
                    pnlProductReturn.Visible = true;
                    panContact.Visible = true;
                }
                else
                {
                    pnlProductBuy.Visible = false;
                    pnlProductReturn.Visible = false;
                    panContact.Visible = false;
                }
                
                //bind vào lưới danh sách các đợt trả hàng
                //BindItemReturn(cus);
                ////bind chi tiết trả hàng '
                //BindDetailsItemReturn();
                //

            }
            catch (Exception ex)
            {
                log.Error("Error 'BindToControl': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load chi tiết dữ liệu trả hàng theo khách hàng .
        /// </summary>
        private void LoadDetailsData()
        {
            try
            {
                // Load orders details of a orders.
                ListView.SelectedListViewItemCollection breakfast = lvwCustomers.SelectedItems;
                if (breakfast.Count > 0)
                {
                    SetMenu();
                    ListViewItem item = breakfast[0];
                    string cusCode = item.SubItems[0].Text;
                    for (int i = 0; i < listCus.Count; i++)
                    {
                        if (listCus[i].CUSTOMER_ID == cusCode)
                        {
                            CUSTOMERS cus = new CUSTOMERS();
                            cus = listCus[i];
                            //reset control
                            RessetControl();
                            // Gán thông tin khách hàng vào các control
                            SetValueControlText(cus);                            
                            break;
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadDetailsData': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Set menu điều khiển tại form main .
        /// </summary>
        private void SetMenu()
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool save = (lvwCustomers.SelectedItems.Count > 0) ? true : false;
                bool delete = (lvwCustomers.SelectedItems.Count > 0) ? true : false;
                bool[] active = { true, save, false, false, delete, false, false, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 14/10/2013 :Gán giá trị cho member Customers.
        /// </summary>
        private CUSTOMERS SetValueEntities(bool isNew)
        {
            CUSTOMERS cus = new CUSTOMERS();
            try
            {
                
                string cusCode = (isNew)? sqlDac.GetAutoCode("CUSTOMERS", "CUSTOMER_ID", CUS_CODE + UserImformation.DeptCode + "."):txtCustomerCode.Text.Trim();
                cus.CUSTOMER_ID = cusCode;
                cus.MACU = txtOldCode.Text.Trim();
                cus.LAST_NAME = txtSurName.Text.Trim();
                cus.FIRST_NAME = txtName.Text.Trim();
                cus.BARCODE = txtBarCode.Text.Trim();
                if (dtpDateOfBirth.Checked)
                    cus.DATE_OF_BIRTH = dtpDateOfBirth.Value;
                cus.PLACE_OF_BIRTH = txtBirthPlace.Text;
                if (cboGender.SelectedIndex != -1)
                    cus.SEX_CODE = cboGender.SelectedValue.ToString();                
                if (chkOther.Checked)
                {
                    cus.OCCUPATION_OTHER = cboJob.Text;
                }
                else
                {
                    if (cboJob.SelectedIndex != -1)
                        cus.OCCUPATION_CODE = cboJob.SelectedValue.ToString();
                }
                if (cboMarriage.SelectedIndex != -1)
                    cus.MARITAL_STATUS = cboMarriage.SelectedValue.ToString();
                if (cboCustomerGroup.SelectedIndex != -1)
                    cus.CUSTOMER_GROUP_CODE = cboCustomerGroup.SelectedValue.ToString();

                cus.NUMBER_MARK = 0;// (txtScore.Text.Trim() != "") ? Convert.ToInt32(Conversion.Replaces(txtScore.Text)) : 0;
                cus.ID_NO = txtIdentityCard.Text;
                if (dtpDateOfIssue.Checked)
                    cus.ID_NO_ISSUED_DATE = dtpDateOfIssue.Value;

                cus.ID_NO_ISSUED_PLACE = txtIDNoPlaces.Text;
                
                cus.REMARK = rtfRemarks.Text;
                //
                cus.TEL = txtTelephone.Text;
                cus.FAX = txtFax.Text;
                cus.EMAIL_ADDRESS = txtEmail.Text;
                cus.MOBILE_PHONE = txtMobilePhone.Text;
                if (cboCountry.SelectedIndex != -1)
                    cus.COUNTRY_CODE = cboCountry.SelectedValue.ToString();
                if(cboProvince.SelectedIndex != -1)
                    cus.PROVINCE_CITY_CODE= cboProvince.SelectedValue.ToString();
                if (cboDistrict.SelectedIndex != -1)
                    cus.DISTRICT_CODE = cboDistrict.SelectedValue.ToString();
                else
                    cus.DISTRICT_OTHER = cboDistrict.Text;

                cus.COMMUNES_WARDS = cboWard.Text;

                cus.HOUSE_STREET = txtStreetName.Text.Trim() + "|" + txtHouse.Text.Trim();
                try
                {
                    if (txtAdress.Text.Trim().Substring(0, 1) == ",")
                        txtAdress.Text = txtAdress.Text.Trim().Substring(1, txtAdress.Text.Trim().Length - 1);
                }
                catch (Exception)
                { 
                    
                }
                cus.ADDRESS = txtAdress.Text;
                cus.WORKING_OFFICE = txtWorkUnit.Text;
                cus.OFFICE_ADDRESS = txtWorkPlace.Text;
                cus.TAX_CODE = txtTaxCode.Text;
                //       
                if(cboCardType.Text.Trim() != "")
                    cus.CUSTOMER_TYPE_CODE = cboCardType.SelectedValue.ToString();
                if(dtpCreateDateCard.Checked)
                    cus.CREATEDATECARD = dtpCreateDateCard.Value;
                // neu chon loai card ma ko nhap ngay tao lay ngay hien hanh
                if (cboCardType.Text.Trim() != "" && dtpCreateDateCard.Checked != true)
                    cus.CREATEDATECARD = sqlDac.GetDateTimeServer();


                //
                cus.CREATE_DATE = dtpDateCreate.Value;
                cus.UPDATE_DATE = dtpDateUpdate.Value;
                cus.CREATE_BY = txtCreateBy.Text;
                cus.LAST_UPDATE_BY = txtUpdateBy.Text;
                cus.DEPT_CODE = UserImformation.DeptNumber;
                cus.IS_ACTIVE = true;
                cus.MONEY = (txtScore.Text.Trim() != "") ? Convert.ToSingle(Conversion.Replaces(txtScore.Text.Trim())) : 0; ;
                cus.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;               
                cus.COL_SEARCH = CreateColSearch(cusCode);
                cus.IS_PRIVATE = chkCusOfStore.Checked;
                cus.EVENT_ID = WriteLogEvent.SaveEventStack("CUSTOMERS", "", 1);
                    
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueEntities': " + ex.Message);
            }
            return cus;
        }
        /// <summary>
        /// Người tạo Luannv – 14/10/2013 :Gán giá trị txtAdress .
        /// </summary>
        private void SetAdress()
        {
            try
            {
                string province = "";
                string country = "";
               
                province = (cboProvince.Text !="") ? cboProvince.Text.ToString() : "";  
                country = (cboCountry.SelectedIndex != -1) ? cboCountry.Text.ToString() : "";
                txtAdress.Text = "";
                txtAdress.Text = (txtHouse.Text.Trim() != "") ? txtHouse.Text : txtAdress.Text;
                txtAdress.Text = (txtStreetName.Text.Trim() != "") ? txtAdress.Text + "," + txtStreetName.Text : txtAdress.Text;
                txtAdress.Text = (cboWard.Text.Trim() != "") ? txtAdress.Text + "," + cboWard.Text : txtAdress.Text;
                txtAdress.Text = (cboDistrict.Text.Trim() != "") ? txtAdress.Text + "," + cboDistrict.Text : txtAdress.Text;
                txtAdress.Text = (province.Trim() != "") ? txtAdress.Text + "," + province : txtAdress.Text;
                txtAdress.Text = (country.Trim() != "") ? txtAdress.Text + "," + country : txtAdress.Text;
                //+", " + txtWard.Text + ", " + txtDistrict.Text + ", " + province + ", " + country;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetAdress': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 14/10/2013 :Gán giá trị cột search khách hàng .
        /// </summary>
        private string CreateColSearch(string cusCode)
        {
            string strResult = "";
            try
            {
                strResult = strResult + cusCode;
                strResult = strResult + "|" + txtName.Text + "|" + txtSurName.Text;
                strResult = strResult + "|" + Conversion.ConvertVN(txtSurName.Text + " " + txtName.Text);
                strResult = strResult + "|" + txtSurName.Text + " " + txtName.Text;
                strResult = strResult + "|" + txtOldCode.Text;
                strResult = strResult + "|" + txtMobilePhone.Text;
                strResult = strResult + "|" + txtBarCode.Text;
                strResult = strResult + "|" + txtAdress.Text;
                strResult = strResult + "|" + Conversion.ConvertVN(txtAdress.Text);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetAdress': " + ex.Message);
            }
            return strResult;
        }

        //Thay đổi panel Feedback
        private void ResizeFeetbackD()
        {
            try
            {
                if (pnlFeedback.Visible == true)
                {
                    pnlFeedback.Visible = false;
                    pnlFeebackD.Visible = true;
                    btnFeeD.ImageIndex = 0;
                    btnFeedBack.ImageIndex = 1;
                }
                else
                {
                    pnlFeedback.Visible = true;
                    pnlFeebackD.Visible = false;
                    btnFeeD.ImageIndex = 1;
                    btnFeedBack.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        //Thay đổi panel Người gọi
        private void ResizePhoneD()
        {
            try
            {
                if (pnlPhone.Visible == true)
                {
                    pnlPhone.Visible = false;
                    pnlPhoneD.Visible = true;
                    btnPhoneD.ImageIndex = 1;
                    btnPhoneN.ImageIndex = 0;
                }
                else
                {
                    pnlPhone.Visible = true;
                    pnlPhoneD.Visible = false;
                    btnPhoneD.ImageIndex = 0;
                    btnPhoneN.ImageIndex = 1;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        //Load trạng thái ban đầu của các panel
        private void LoadPanel()
        {
            try
            {
                pnlProductBuy.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                lblProductBuy.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                pnlProductBuy.Location = new Point(0, 0);
                pnlProductReturn.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                lblProductReturn.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                pnlProductReturn.Location = new Point(0, pnlProductBuy.Height);
                panContact.Location = new Point(0, pnlProductBuy.Height+pnlProductReturn.Height);
                panContact.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                lblContact.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                pnlFeedback.Visible = false;
                pnlPhone.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Thay đổi kích thước panel MuaHang
        private void ResizeTranfer()
        {
            try
            {
                int hightTranfer = 0;
                int hightReItem = 0;
                if (pnlProductBuy.Size.Height == HEIGHT_PANEL)
                {
                    pnlProductBuy.Size = new Size(WIDTH_PANEL, HEIGHT_TRANFER_ITEM);
                    
                    hightTranfer = pnlProductBuy.Size.Height;
                    hightReItem = pnlProductReturn.Size.Height;
                    pnlProductReturn.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + DISTANCE);
                    panContact.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + (2 * DISTANCE) + hightReItem);
                    btnTranferResize.ImageIndex = 1;

                }
                else
                {
                    pnlProductBuy.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);

                    hightTranfer = pnlProductBuy.Size.Height;
                    hightReItem = pnlProductReturn.Size.Height;

                    pnlProductReturn.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + DISTANCE);
                    panContact.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + (2 * DISTANCE) + hightReItem);
                    btnTranferResize.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTranfer' : " + ex.Message);
            }
        }

        //Thay đổi kích thước panel Trahang
        private void ResizeItemReturn()
        {
            try
            {
                int hightTranfer = 0;
                int hightReItem = 0;
                if (pnlProductReturn.Size.Height == HEIGHT_PANEL)
                {
                    pnlProductReturn.Size = new Size(WIDTH_PANEL, HEIGHT_TRANFER_ITEM);

                    hightTranfer = pnlProductBuy.Size.Height;
                    hightReItem = pnlProductReturn.Size.Height;
                    panContact.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + (2 * DISTANCE) + hightReItem);
                    btnItemReturn.ImageIndex = 1;

                }
                else
                {
                    pnlProductReturn.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);

                    hightTranfer = pnlProductBuy.Size.Height;
                    hightReItem = pnlProductReturn.Size.Height;
                    panContact.Location = new Point(DISTANCE_TOP, DISTANCE_TOP + hightTranfer + (2 * DISTANCE) + hightReItem);
                    btnItemReturn.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTranfer' : " + ex.Message);
            }
        }
        
        //Thay đổi kích thước panel LienHe
        private void ResizeContact()
        {
            try
            {
                if (panContact.Size.Height == HEIGHT_PANEL)
                {
                    panContact.Size = new Size(WIDTH_PANEL, HEIGHT_CONTACT);
                    btnContactResize.ImageIndex = 1;
                    //ResizeFeetbackD();
                }
                else
                {
                    panContact.Size = new Size(WIDTH_PANEL, HEIGHT_PANEL);
                    btnContactResize.ImageIndex = 0;
                    //ResizeFeetbackD();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeContact' : " + ex.Message);
            }
        }

        //Lịch sử KH: Hóa đơn KH
        private void TranferProduct_invoi(string customer_Id)
        {
            try
            {
                string proc = "SALES_EXPORTS_Read_history";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@Customer_id", customer_Id);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                if (dt.Rows.Count > 0)
                {
                    dtPro = new DataTable();
                    dtPro = dt.Copy();
                    dgvInvoicher.AutoGenerateColumns = false;
                    dgvInvoicher.DataSource = dt;
                    exCode = dt.Rows[0]["EXPORT_CODE"].ToString();
                    //lấy mã khách hàng
                    customerId_Mail = dt.Rows[0]["CUSTOMER_ID"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }
        
        //Lịch sử KH: chi tiết sản phẩm
        private void TranferProduct_Detail(string export_Code)
        {
            try
            {
                string proc = "SALES_EXPORTS_Read_history_product";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@export_code", export_Code);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                if (dt.Rows.Count > 0)
                {
                    dgvProduct.AutoGenerateColumns = false;
                    dgvProduct.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        //Lịch sử KH: Hàng trả lại
        private void TranferProduct_Return(string Customer_Id)
        {
            try
            {
                string proc = "ITEM_RETURN_Read_customerId";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@Customer_id", Customer_Id);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                if (dt.Rows.Count > 0)
                {
                    dgvProductReturn.AutoGenerateColumns = false;
                    dgvProductReturn.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        //Load thông tin liên hệ
        private void ContactInfo()
        {
            string proc = "FeedbackInfo";
            SqlParameter[] para;
            para = new SqlParameter[2];
            para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber);
            para[1] = posdb_vnmSqlDAC.newInParam("@Account", UserImformation.UserName);

            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, para);
            if (dt.Rows.Count > 0)
            {
                dgvContact.AutoGenerateColumns = false;
                dgvContact.DataSource = dt;
            }
        }
        
        //Lấy chuỗi cửa hàng
        private string GetPlaceCreate(int deptCode)
        {
            string storeName = "";
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode) };
                DataTable dtTemp = new DataTable();
                dtTemp = sqlDac.GetDataTable("GetPlaceCreateCustomer", para);
                if (dtTemp.Rows.Count > 0)
                {
                    storeName = dtTemp.Rows[0]["Place"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetPlaceCreate': " + ex.Message);
            }
            return storeName;
        }

        //phản hổi KH
        private void CreateFeedback()
        {
            try
            {
                string storelist = GetPlaceCreate(UserImformation.DeptNumber);
                
                string proc = "FeedbackCreate";
                SqlParameter[] paraInsert;
                paraInsert = new SqlParameter[10];
                paraInsert[0] = posdb_vnmSqlDAC.newInParam("@Datefeedback", dtpFeedback.Value.ToString());
                paraInsert[1] = posdb_vnmSqlDAC.newInParam("@Customer_Name", txtCustomerF.Text);
                paraInsert[2] = posdb_vnmSqlDAC.newInParam("@Tittle", txtTittleF.Text);
                paraInsert[3] = posdb_vnmSqlDAC.newInParam("@Content", txtContentF.Text);
                paraInsert[4] = posdb_vnmSqlDAC.newInParam("@Account", UserImformation.UserName);
                paraInsert[5] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber);
                paraInsert[6] = posdb_vnmSqlDAC.newInParam("@Type", "0");
                paraInsert[7] = posdb_vnmSqlDAC.newInParam("@StoreCode", UserImformation.DeptName);
                paraInsert[8] = posdb_vnmSqlDAC.newInParam("@StoreList", storelist);
                paraInsert[9] = posdb_vnmSqlDAC.newInParam("@StorePlace", null);
                sqlDac.Execute(proc, paraInsert);

                MessageBox.Show(translate["Msg.UpdateSuccess"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Phản hồi cửa hàng: 
        private void CreateFeedbackStore()
        {
            try
            {
                string storelist = GetPlaceCreate(UserImformation.DeptNumber);

                string proc = "FeedbackCreate";
                SqlParameter[] paraInsert;
                paraInsert = new SqlParameter[10];
                paraInsert[0] = posdb_vnmSqlDAC.newInParam("@Datefeedback", dtpPhone.Value.ToString());
                paraInsert[1] = posdb_vnmSqlDAC.newInParam("@Customer_Name", txtCustomerF.Text);
                paraInsert[2] = posdb_vnmSqlDAC.newInParam("@Tittle", txtTitleP.Text);
                paraInsert[3] = posdb_vnmSqlDAC.newInParam("@Content", txtContentP.Text);
                paraInsert[4] = posdb_vnmSqlDAC.newInParam("@Account", UserImformation.UserName);
                paraInsert[5] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber);
                paraInsert[6] = posdb_vnmSqlDAC.newInParam("@Type", "1");
                paraInsert[7] = posdb_vnmSqlDAC.newInParam("@StoreCode", UserImformation.DeptName);
                paraInsert[8] = posdb_vnmSqlDAC.newInParam("@StoreList", storelist);
                paraInsert[9] = posdb_vnmSqlDAC.newInParam("@StorePlace", null);
                
                sqlDac.Execute(proc, paraInsert);
                MessageBox.Show(translate["Msg.UpdateSuccess"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Gửi mail 
        public void sendMail()
        {
            try
            {
                string strQuery = "select Email_address from company_info where Language = 'Vietnamese'";
                DataSet ds = new DataSet();
                ds = sqlDac.InlineSql_Execute(strQuery, null);
                string hostmail = ds.Tables[0].Rows[0]["Email_address"].ToString();
                 

                MailMessage mail = new MailMessage("emailfrom", "emailto");

                mail.From = new MailAddress("emailfrom");
                mail.Subject = txtTitleP.Text;
                string Body = txtContentP.Text;
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("youremail", "yourpassword");

                smtp.EnableSsl = true;
                smtp.Send(mail);
                //txtEmail.Text = "";
                //txtmsg.Text = "";
                //txtsbjct.Text = "";
                //Label1.Text = "your email has been send";
                mail = null;
                smtp = null;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Gửi email bằng outlook
        public void sendEMailThroughOUTLOOK()
        {
            try
            {
                //lấy email KH
                string strQuery = "select Email_Address from Customers where customer_id ='" + customerId_Mail + "' ";
                DataSet ds = new DataSet();
                ds = sqlDac.InlineSql_Execute(strQuery, null);
                string emailCus = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    emailCus = ds.Tables[0].Rows[0]["Email_Address"].ToString();
                }
                if (emailCus == "" || emailCus == null)
                {
                    MessageBox.Show(translate["Msg.EmailNotFound"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Process.Start(@"mailto:" + emailCus);
                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: sendEMailThroughOUTLOOK" + ex.Message);
            }

        }
       
        #endregion

        #region Event

        #region event form process
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : load form .
        /// </summary>
        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {
            try
            {
                if (lvwCustomers.Items.Count > 0)
                {
                    pnlProductBuy.Visible = true;
                    pnlProductReturn.Visible = true;
                    panContact.Visible = true;
                }
                else
                {
                    pnlProductBuy.Visible = false;
                    pnlProductReturn.Visible = false;
                    panContact.Visible = false;
                }
                LoadPanel();
               
                // load dữ liệu các combobox
                CustomerManager.LoadMasterCode(this.cboGender, sexPrifix);
                CustomerManager.LoadMasterCode(this.cboCustomerGroup, cugPrefix);
                CustomerManager.LoadMasterCode(this.cboCountry,couPrefix);
                CustomerManager.LoadMasterCode(this.cboMarriage,masPrefix);
                CustomerManager.LoadMasterCode(this.cboJob, occPrefix);
                CustomerManager.LoadCardType(this.cboCardType, cardPrefix);
                CustomerManager.LoadMasterCode(this.cboProvince, prcPrefix);
                CustomerManager.LoadMasterCode(this.cboDistrict, disPrefix);
                // set menu tab
                SetMenu();
                txtCustomersSearch.Focus();
                dtpDateOfIssue.Checked = false;

                //Check quyền
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCustomerInfo' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkInsert = checkInsert == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()) : checkInsert;
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                        checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : ghi file log form đã đóng .
        /// </summary>
        private void frmCustomerManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Tìm kiếm khách hàng.
        /// </summary>
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CUSTOMERS cus = new CUSTOMERS();
                int dept = (chkCustomer.Checked) ? 0 : UserImformation.DeptNumber;
                cus = CustomerManager.SearchCustomer(txtCustomersSearch.Text.Trim(), dept, sqlDac, translate);
                if (cus != null)
                {
                    LoadData(cus);
                    TranferProduct_invoi(cus.CUSTOMER_ID);
                    TranferProduct_Return(cus.CUSTOMER_ID);
                    txtCustomerF.Text = cus.LAST_NAME + " " + cus.FIRST_NAME;
                    txtPerPhone.Text = UserImformation.UserName;
                    txtPhoneP.Text = UserImformation.StoreTelePhone.Substring(3).Replace(".","0").Replace(")","").Trim();
                    
                    TranferProduct_Detail(exCode);
                    ContactInfo();
                }
                else
                {
                    MessageBox.Show(Properties.rsfEmployee.Customer9, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện thay đổi lựa chọn khách hàng.
        /// </summary>
        string idCus = "";
        private void lvwCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDetailsData();
                if (lvwCustomers.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection list = lvwCustomers.SelectedItems;
                    foreach (ListViewItem item in list)
                    {
                        idCus = item.Text;
                        TranferProduct_invoi(item.SubItems[0].Text);
                        TranferProduct_Return(item.SubItems[0].Text);

                        string strQuery = "select Last_name + ' ' + first_name as CusName from customers where customer_id = '" + item.SubItems[0].Text + "'";
                        DataSet ds = new DataSet();
                        ds = sqlDac.InlineSql_Execute(strQuery,null);
                        txtCustomerF.Text = ds.Tables[0].Rows[0]["CusName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }   
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện thay đổi lựa chọn quốc gia.
        /// </summary>
        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCountry.SelectedIndex != -1)
                {
                    CustomerManager.LoadMasterCodeByParent(this.cboProvince, prcPrefix,cboCountry.SelectedValue.ToString().Trim());
                }                
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện thay đổi lựa chọn tỉnh thành phố.
        /// </summary>
        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboProvince.SelectedIndex != -1)
                {
                    CustomerManager.LoadMasterCodeByParent(this.cboDistrict, disPrefix, cboProvince.SelectedValue.ToString().Trim());
                }
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện nhập dữ liệu quận/ huyện.
        /// </summary>
        private void txtDistrict_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện nhập dữ liệu phường xã.
        /// </summary>
        private void txtWard_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện nhập dữ liệu số nhà/ tên đường.
        /// </summary>
        private void txtHouse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }       
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện nhập dữ liệu tỉnh thành phố.
        /// </summary>
        private void cboProvince_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sự kiện chọn loại nghề nghiệp hoặc nhập nghề nghiệp khác không có trong list danh sách nghề nghiệp.
        /// </summary>
        private void chkOther_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkOther.Checked)
                    cboJob.DropDownStyle = ComboBoxStyle.Simple;
                else
                {
                    cboJob.DropDownStyle = ComboBoxStyle.DropDownList;
                    CustomerManager.LoadMasterCode(cboJob, occPrefix);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Chặn các ký tự không hợp lệ nhập vào textbox năm sinh.
        /// </summary>
        private void txtBirthYear_KeyPress(object sender, KeyPressEventArgs e)
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
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region event handler menu
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Tìm kiếm khách hàng nâng cao.
        /// </summary>
        private void frmCustomerManagement_evSearch(object sender, EventArgs e)
        {
            try
            {
                CUSTOMERS cus = new CUSTOMERS();
                frmCustomerSearch dlgCusSearch = new frmCustomerSearch(translate);
                dlgCusSearch.StartPosition = FormStartPosition.CenterScreen;
                dlgCusSearch.ShowDialog();
                if (dlgCusSearch.Customer != null)
                {
                    cus = CustomerManager.GetFullEntitiesCustomer(dlgCusSearch.Customer);
                    LoadData(cus);
                    TranferProduct_invoi(cus.CUSTOMER_ID);
                    TranferProduct_Return(cus.CUSTOMER_ID);
                    txtCustomerF.Text = cus.LAST_NAME + " " + cus.FIRST_NAME;
                    txtPerPhone.Text = UserImformation.UserName;
                    txtPhoneP.Text = UserImformation.StoreTelePhone.Substring(3).Replace(".", "0").Replace(")", "").Trim();
                    TranferProduct_Detail(exCode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Thêm mới khách hàng.
        /// </summary>
        private void frmCustomerManagement_evAddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    // set menu
                    frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                    bool[] active = { false, true, false, true, false, false, false, false, false, false, true, true };
                    parMain.ActiveMenu(active);
                    status = active;
                    // làm rỗng các control
                    RessetControl();
                    txtOldCode.Enabled = true;
                    txtSurName.Enabled = true;
                    txtName.Enabled = true;
                    txtSurName.Focus();
                }
                else
                {
                    MessageBox.Show(Properties.rsfSales.ItemReturn.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Hủy thao tác thêm mới.
        /// </summary>
        private void frmCustomerManagement_evCancel(object sender, EventArgs e)
        {
            try
            {
                SetMenu();
                LoadDetailsData();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Xóa khách hàng.
        /// </summary>
        private void frmCustomerManagement_evDelete(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    if (idCus != string.Empty)
                    {
                        //Lấy index của dòng được chọn
                        int selectedindex = lvwCustomers.SelectedIndices[0];
                        string cuscode = txtCustomerCode.Text;
                        if (MessageBox.Show(Properties.rsfPayment.CashPayment4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lvwCustomers.Items.Remove(lvwCustomers.Items[selectedindex]);

                            ListViewItem item = lvwCustomers.FocusedItem;
                            string proc = "CUSTOMERS_Delete";
                            SqlParameter[] para;
                            para = new SqlParameter[1];
                            para[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", SqlDbType.VarChar, cuscode);
                            sqlDac.Execute(proc, para);

                            MessageBox.Show(Properties.rsfPayment.CashPayment5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    if (lvwCustomers.Items.Count > 0)
                    {
                        lvwCustomers.Items[0].Selected = true;
                    }
                    else
                    {
                        RessetControl();
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: evDelete" + ex.Message);
            }    
        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Sửa khách hàng.
        /// </summary>
        private void frmCustomerManagement_evEdit(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Người tạo Luannv – 12/10/2013 : Lưu thông tin khách hàng.
        /// </summary>
        private void frmCustomerManagement_evSave(object sender, EventArgs e)
        {
            try
            {
                bool val = ValidateCustomer();
                if (val)
                {
                    
                    bool bol = (txtCustomerCode.Text.Trim() != "");
                    if (!bol)
                    {
                        CUSTOMERS cus = SetValueEntities(true);
                        cus.Save(true);
                        LoadData(cus);
                        MessageBox.Show(Properties.rsfEmployee.Customer7, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        CUSTOMERS cus = SetValueEntities(false);
                        cus.Save(false);
                        // lưu thông tin cập nhật vào list cus.
                        for (int i = 0; i < listCus.Count; i++)
                        {
                            if (listCus[i].CUSTOMER_ID == cus.CUSTOMER_ID)
                            {
                                listCus[i] = cus;
                            }
                        }
                        MessageBox.Show(Properties.rsfEmployee.Customer8, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDistrict.SelectedIndex != -1)
                {
                    CustomerManager.LoadMasterCodeByParent(this.cboWard, warPrefix, cboDistrict.SelectedValue.ToString().Trim());
                }
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboDistrict_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboWard_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void txtHouse_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                SetAdress();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void txtCustomersSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CUSTOMERS cus = new CUSTOMERS();
                    int dept = (chkCustomer.Checked) ? 0 : UserImformation.DeptNumber;
                    cus = CustomerManager.SearchCustomer(txtCustomersSearch.Text.Trim(), dept, sqlDac, translate);
                    if (cus != null)
                    {
                        LoadData(cus);
                        TranferProduct_invoi(cus.CUSTOMER_ID);
                        TranferProduct_Return(cus.CUSTOMER_ID);
                        txtCustomerF.Text = cus.LAST_NAME + " " + cus.FIRST_NAME;
                        txtPerPhone.Text = UserImformation.UserName;
                        txtPhoneP.Text = UserImformation.StoreTelePhone.Substring(3).Replace(".", "0").Replace(")", "").Trim();
                        TranferProduct_Detail(exCode);
                        ContactInfo();
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfEmployee.Customer9, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void frmCustomerManagement_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }

        private void cboCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCardType.Text.Trim() != "")
            {
                dtpCreateDateCard.Checked = true;
            }
        }

        private void btnTranferResize_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeTranfer();
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTranfer' : " + ex.Message);
            }
        }

        private void btnItemReturn_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeItemReturn();
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTranfer' : " + ex.Message);
            }
        }

        private void btnContactResize_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeContact();
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTranfer' : " + ex.Message);
            }
        }

        private void btnFeedBack_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeFeetbackD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void dgvInvoicher_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void dgvInvoicher_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvInvoicher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvR = dgvInvoicher.CurrentCell.OwningRow;
                string export_code = dgvR.Cells["colExportCode"].Value.ToString();
                TranferProduct_Detail(export_code);
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void dgvInvoicher_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvInvoicher.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvInvoicher.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvProduct.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvProduct.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvProductReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvProductReturn.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvProductReturn.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnFeeD_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeFeetbackD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void btnPhoneD_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePhoneD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void btnPhoneN_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePhoneD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }
                
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeFeetbackD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePhoneD();
            }
            catch (Exception ex)
            {
                log.Error("Error '': " + ex.Message);
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            sendEMailThroughOUTLOOK();
        }

        private void btnAttactment_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFeedbackStore();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnSaveFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFeedback();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        
        #endregion

        

        

        

        

        

        

        

        

        

        
    
    }
}

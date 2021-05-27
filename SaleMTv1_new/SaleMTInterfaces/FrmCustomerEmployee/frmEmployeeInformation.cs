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
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using SaleMTBusiness.CustomerManagement;

namespace SaleMTInterfaces.FrmCustomerEmployee
{
    public partial class frmEmployeeInformation : TabForm
    {
        #region Declaration
        private MenuProcess mnuProcess = new MenuProcess();
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private ListViewColumnSorter lvwSortter;
        public string textName;
        public string TextName
        {
            get { return textName; }
            set { textName = value; }
        }
        private bool[] status;

        private string sexPrifix = Properties.rsfMasterCode.Sex.ToString();
        private string relPrifix = Properties.rsfMasterCode.Relligion.ToString();
        private string posPrefix = Properties.rsfMasterCode.Position.ToString();
        private string masPrefix = Properties.rsfMasterCode.Marrital.ToString();
        private string emgPrefix = Properties.rsfMasterCode.GroupEm.ToString();
        private string occPrefix = Properties.rsfMasterCode.Job.ToString();
                
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        bool add = false;
        private List<EMPLOYEE_INFO> lisEm = new List<EMPLOYEE_INFO>();

        #endregion

        #region Contrustor
        public frmEmployeeInformation(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxTTNhanVien.Text = translate["frmEmployeeInfomation.gbxTTNhanVien.Text"];
            this.label45.Text = translate["frmEmployeeInfomation.label45.Text"];
            this.label27.Text = translate["frmEmployeeInfomation.label27.Text"];
            this.label25.Text = translate["frmEmployeeInfomation.label25.Text"];
            this.label24.Text = translate["frmEmployeeInfomation.label24.Text"];
            this.label42.Text = translate["frmEmployeeInfomation.label42.Text"];
            this.label23.Text = translate["frmEmployeeInfomation.label23.Text"];
            this.label22.Text = translate["frmEmployeeInfomation.label22.Text"];
            this.label21.Text = translate["frmEmployeeInfomation.label21.Text"];
            this.label19.Text = translate["frmEmployeeInfomation.label19.Text"];
            this.label18.Text = translate["frmEmployeeInfomation.label18.Text"];
            this.label16.Text = translate["frmEmployeeInfomation.label16.Text"];
            this.label14.Text = translate["frmEmployeeInfomation.label14.Text"];
            this.label15.Text = translate["frmEmployeeInfomation.label15.Text"];
            this.label12.Text = translate["frmEmployeeInfomation.label12.Text"];
            this.label11.Text = translate["frmEmployeeInfomation.label11.Text"];
            this.label9.Text = translate["frmEmployeeInfomation.label9.Text"];
            this.label8.Text = translate["frmEmployeeInfomation.label8.Text"];
            this.label26.Text = translate["frmEmployeeInfomation.label26.Text"];
            this.label20.Text = translate["frmEmployeeInfomation.label20.Text"];
            this.label6.Text = translate["frmEmployeeInfomation.label6.Text"];
            this.label4.Text = translate["frmEmployeeInfomation.label4.Text"];
            this.label10.Text = translate["frmEmployeeInfomation.label10.Text"];
            this.label17.Text = translate["frmEmployeeInfomation.label17.Text"];
            this.label7.Text = translate["frmEmployeeInfomation.label7.Text"];
            this.label44.Text = translate["frmEmployeeInfomation.label44.Text"];
            this.label5.Text = translate["frmEmployeeInfomation.label5.Text"];
            this.label1.Text = translate["frmEmployeeInfomation.label1.Text"];
            this.label13.Text = translate["frmEmployeeInfomation.label13.Text"];
            this.label3.Text = translate["frmEmployeeInfomation.label3.Text"];
            this.label31.Text = translate["frmEmployeeInfomation.label31.Text"];
            this.label2.Text = translate["frmEmployeeInfomation.label2.Text"];
            this.gbxDanhSachNV.Text = translate["frmEmployeeInfomation.gbxDanhSachNV.Text"];
            this.columnHeader1.Text = translate["frmEmployeeInfomation.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmEmployeeInfomation.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmEmployeeInfomation.columnHeader3.Text"];
            this.gbxTim.Text = translate["frmEmployeeInfomation.gbxTim.Text"];
            this.btnEmployeeSearch.Text = translate["frmEmployeeInfomation.btnEmployeeSearch.Text"];
            this.Text = translate["frmEmployeeInfomation.Text"];
        }	

        #endregion

        #region Method/Function

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Tìm kiếm nhân viên theo mã nhân viên     
        /// </summary>
        private void searchEmployee(string employeeSearch)
        {
            try
            {
                string proc = "EMPLOYEE_INFO_SearchEmployId";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", SqlDbType.VarChar, employeeSearch);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                //lvwEmployeeSearch.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(employeeSearch);
                        item.SubItems.Add(dt.Rows[i]["LAST_NAME"].ToString());
                        item.SubItems.Add(dt.Rows[i]["FIRST_NAME"].ToString());
                        item.SubItems.Add(dt.Rows[i]["DEPT_CODE"].ToString());
                        if (lvwEmployeeSearch.Items.Count > 0)
                        {
                            if (employeeSearch != lvwEmployeeSearch.Items[0].SubItems[0].Text)
                                {
                                    lvwEmployeeSearch.Items.Add(item);
                                    loadEmployeeInfor(employeeSearch);
                                }        

                        }
                        else
                        {
                            lvwEmployeeSearch.Items.Add(item);
                            loadEmployeeInfor(employeeSearch);
                        }    
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.DataNotFound"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    

            }
            catch (Exception ex)
            {
                log.Error("Error 'searchEmployee' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Load thông tin nhân viên vào các control theo mã nhân viên       
        /// </summary>
        private void loadEmployeeInfor(string employeeId)
        {
            try
            {
                if (lvwEmployeeSearch.Items.Count > 0)
                {
                    dtpDateOfBirth.Enabled = true;
                    dtpDateCreateIdCard.Enabled = true;
                    dtpDateOff.Enabled = true;
                    dtpDateStart.Enabled = true;
                }

                string proc = "EMPLOYEE_INFO_Read";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", SqlDbType.VarChar, employeeId);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);

                if (dt.Rows.Count > 0)
                {
                    txtEmployeeCode.Text = dt.Rows[0]["EMPLOYEE_ID"].ToString();
                    txtSurName.Text = dt.Rows[0]["LAST_NAME"].ToString();//ht
                    txtName.Text = dt.Rows[0]["FIRST_NAME"].ToString();//t
                    dtpDateOfBirth.Value = (DateTime)dt.Rows[0]["DATE_OF_BIRTH"];
                    txtBirthPlaces.Text = dt.Rows[0]["PLACE_OF_BIRTH"].ToString();
                    txtBarCode.Text = dt.Rows[0]["BARCODE"].ToString();
                    cboSex.SelectedValue = dt.Rows[0]["SEX"].ToString();
                    cboReligion.SelectedValue = dt.Rows[0]["REGION"].ToString();
                    cboMarriess.SelectedValue = dt.Rows[0]["MARRIED_STATUS"].ToString();
                    txtEducation.Text = dt.Rows[0]["KNOWLEDGE"].ToString();
                    txtIdentityCard.Text = dt.Rows[0]["ID_CARD"].ToString();
                    dtpDateCreateIdCard.Value = (DateTime)dt.Rows[0]["ID_CARD_ISSUED_DATE"];
                    txtPlacesCard.Text = dt.Rows[0]["ID_CARD_ISSUED_PLACE"].ToString();
                    txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                    txtMobile.Text = dt.Rows[0]["MOBILE"].ToString();
                    txtResidentPhone.Text = dt.Rows[0]["RESIDENT_PHONE"].ToString();
                    txtPernamentPhone.Text = dt.Rows[0]["PERNAMENT_PHONE"].ToString();
                    txtResidentAdress.Text = dt.Rows[0]["RESIDENT_ADDRESS"].ToString();
                    txtPernamentAdress.Text = dt.Rows[0]["PERNAMENT_ADDRESS"].ToString();
                    cboGroupStore.SelectedValue = dt.Rows[0]["EMPLOYEE_GROUP"].ToString();
                    cboPositions.SelectedValue = dt.Rows[0]["POSITION_CODE"].ToString();
                    dtpDateStart.Value = (DateTime)dt.Rows[0]["START_DATE"];
                    dtpDateOff.Value = (DateTime)dt.Rows[0]["DATE_OFF"];
                    txtSalary.Text = dt.Rows[0]["SALARY"].ToString();
                    txtWorkPlaces.Text = GetPlaceCreate(Convert.ToInt32(dt.Rows[0]["DEPT_CODE"]));
                    cboWorkStatus.ValueMember = dt.Rows[0]["WORKING_STATUS"].ToString();    
                }

                //gọi hàm load các combobox
                
                workStatus();
            }
            catch (Exception ex)
            {
                log.Error("Error 'loadEmployeeInfor' : " + ex.Message);
            }
        }
        //Ham hien thi chi tiet thong tin nhan vien
        private void showEmployeeInfo()
        {

        }
                
        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Fill dữ liệu vào combobox Tình trạng làm việc    
        /// </summary>
        private void workStatus()
        {
            try
            {
                string proc = "Em_WorkStatus";
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, null);
                cboWorkStatus.DataSource = dt;
                cboWorkStatus.Text = "";
                cboWorkStatus.DisplayMember = "workStatusName";
                cboWorkStatus.ValueMember = "WORKING_STATUS";  
            }
            catch (Exception ex)
            {
                log.Error("Error 'workStatus' : " + ex.Message);
            }
        }

        private void SetControl()
        { 
            
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Thêm mới nhân viên    
        /// </summary>
        private void createEmployee(string Emcode)
        {
            try
            {
                if (checkNull())
                {
                    //Tạo mã nhân viên tự động
                    List<EMPLOYEE_INFO> listEmployee = new List<EMPLOYEE_INFO>();
                    string autoID = add == false ? Emcode : GetAutoCode("EMPLOYEE_INFO", "EMPLOYEE_ID", "");
                    
                    //Tao event tu dong
                    List<EMPLOYEE_INFO> listEvent = new List<EMPLOYEE_INFO>();
                    string eventCode = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", "HIEPPHAMPC-CH40171-13.");
                    string sexcode = (cboSex.SelectedIndex != -1 && cboSex.Text.Trim() != "") ? cboSex.SelectedValue.ToString() : "-1";
                    string marriess = (cboMarriess.SelectedIndex != -1 && cboMarriess.Text.Trim() != "") ? cboMarriess.SelectedValue.ToString() : "-1";
                    string groupEm = (cboGroupStore.SelectedIndex != -1 && cboGroupStore.Text.Trim() != "") ? cboGroupStore.SelectedValue.ToString() : "-1";
                    string religion = (cboReligion.SelectedIndex != -1 && cboReligion.Text.Trim() != "") ? cboReligion.SelectedValue.ToString() : "-1";
                    string workStatus = (cboWorkStatus.SelectedIndex != -1 && cboWorkStatus.Text.Trim() != "") ? cboWorkStatus.SelectedValue.ToString() : "-1";
                    
                    EMPLOYEE_INFO employeeInfo = new EMPLOYEE_INFO();
                    if (add)
                    {
                        employeeInfo.EMPLOYEE_ID = autoID;
                        employeeInfo.DEPT_CODE = UserImformation.DeptNumber;
                        employeeInfo.FIRST_NAME = txtName.Text;
                        employeeInfo.LAST_NAME = txtSurName.Text;
                        employeeInfo.POSITION_CODE = cboPositions.SelectedValue.ToString();
                        employeeInfo.DATE_OF_BIRTH = dtpDateOfBirth.Value;
                        employeeInfo.MARRIED_STATUS = marriess;
                        employeeInfo.SEX = sexcode;
                        employeeInfo.PLACE_OF_BIRTH = txtBirthPlaces.Text;
                        employeeInfo.ID_CARD = txtIdentityCard.Text;
                        employeeInfo.ID_CARD_ISSUED_DATE = dtpDateCreateIdCard.Value;
                        employeeInfo.ID_CARD_ISSUED_PLACE = txtPlacesCard.Text;
                        employeeInfo.RESIDENT_ADDRESS = txtResidentAdress.Text;
                        employeeInfo.RESIDENT_PHONE = txtResidentPhone.Text;
                        employeeInfo.PERNAMENT_ADDRESS = txtPernamentAdress.Text;
                        employeeInfo.PERNAMENT_PHONE = txtPernamentPhone.Text;
                        employeeInfo.MOBILE = txtMobile.Text;
                        employeeInfo.EMAIL = txtEmail.Text;
                        employeeInfo.REGION = religion;
                        employeeInfo.KNOWLEDGE = txtEducation.Text;
                        employeeInfo.MORE_INFO = "";
                        employeeInfo.INPUT_DATE = dtpDateOff.Value;
                        employeeInfo.WORKING_STATUS = workStatus;
                        employeeInfo.START_DATE = dtpDateStart.Value;
                        employeeInfo.SALARY = txtSalary.Text != "" ? float.Parse(txtSalary.Text) : 0;
                        employeeInfo.DATE_OFF = dtpDateOff.Value;
                        employeeInfo.PICTURE_PATH = "";
                        employeeInfo.STORE_CODE = GetPlaceCreate(UserImformation.DeptNumber);
                        employeeInfo.BARCODE = txtBarCode.Text;
                        employeeInfo.NORMS_DEBT_FOR = 0;
                        employeeInfo.NORMS_DEBT_ALLOW = 0;
                        employeeInfo.EMPLOYEE_GROUP = groupEm;
                        employeeInfo.EVENT_ID = eventCode;

                        employeeInfo.Save(true);
                        MessageBox.Show(Properties.rsfSales.CreateSuccess.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        //add thông tin thêm vào listview
                        ListViewItem item = new ListViewItem(autoID);
                        item.SubItems.Add(txtSurName.Text);
                        item.SubItems.Add(txtName.Text);
                        lvwEmployeeSearch.Items.Add(item);
                        loadEmployeeInfor(autoID);
                    }
                    else
                    {
                        employeeInfo.EMPLOYEE_ID = txtEmployeeCode.Text;
                        employeeInfo.DEPT_CODE = UserImformation.DeptNumber;
                        employeeInfo.FIRST_NAME = txtName.Text;
                        employeeInfo.LAST_NAME = txtSurName.Text;
                        employeeInfo.POSITION_CODE = cboPositions.SelectedValue.ToString();
                        employeeInfo.DATE_OF_BIRTH = dtpDateOfBirth.Value;
                        employeeInfo.MARRIED_STATUS = marriess;
                        employeeInfo.SEX = sexcode;
                        employeeInfo.PLACE_OF_BIRTH = txtBirthPlaces.Text;
                        employeeInfo.ID_CARD = txtIdentityCard.Text;
                        employeeInfo.ID_CARD_ISSUED_DATE = dtpDateCreateIdCard.Value;
                        employeeInfo.ID_CARD_ISSUED_PLACE = txtPlacesCard.Text;
                        employeeInfo.RESIDENT_ADDRESS = txtResidentAdress.Text;
                        employeeInfo.RESIDENT_PHONE = txtResidentPhone.Text;
                        employeeInfo.PERNAMENT_ADDRESS = txtPernamentAdress.Text;
                        employeeInfo.PERNAMENT_PHONE = txtPernamentPhone.Text;
                        employeeInfo.MOBILE = txtMobile.Text;
                        employeeInfo.EMAIL = txtEmail.Text;
                        employeeInfo.REGION = religion;
                        employeeInfo.KNOWLEDGE = txtEducation.Text;
                        employeeInfo.MORE_INFO = "";
                        employeeInfo.INPUT_DATE = dtpDateOff.Value;
                        employeeInfo.WORKING_STATUS = workStatus;
                        employeeInfo.START_DATE = dtpDateStart.Value;
                        employeeInfo.SALARY = txtSalary.Text != "" ? float.Parse(txtSalary.Text) : 0;
                        employeeInfo.DATE_OFF = dtpDateOff.Value;
                        employeeInfo.PICTURE_PATH = "";
                        employeeInfo.STORE_CODE = txtWorkPlaces.Text;
                        employeeInfo.BARCODE = txtBarCode.Text;
                        employeeInfo.NORMS_DEBT_FOR = 0;
                        employeeInfo.NORMS_DEBT_ALLOW = 0;
                        employeeInfo.EMPLOYEE_GROUP = groupEm;
                        employeeInfo.EVENT_ID = eventCode;
                        
                        employeeInfo.Save(false);
                        MessageBox.Show(Properties.rsfSales.EditSuccess.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        //add thông tin cập nhật xuống lưới
                        foreach (ListViewItem item in lvwEmployeeSearch.Items)
                        {
                            if (item.Text == txtEmployeeCode.Text)
                            {
                                item.SubItems[1].Text = txtSurName.Text;
                                item.SubItems[2].Text = txtName.Text;
                            }
                        }
                        loadEmployeeInfor(txtEmployeeCode.Text);    
                    }
                    SetMenu();
                    add = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'createEmployee' : " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Bắt lỗi các trường null  
        /// </summary>
        private bool checkNull()
        {
            if (txtSurName.Text.Trim() == "" || txtSurName.Text == null)
            {
                MessageBox.Show(Properties.rsfEmployee.EmployeeInfo1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurName.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "" || txtName.Text == null)
            {
                MessageBox.Show(Properties.rsfEmployee.EmployeeInfo2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtBarCode.Text.Trim() == "" || txtBarCode.Text == null)
            {
                MessageBox.Show(Properties.rsfEmployee.EmployeeInfo3.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarCode.Focus();
                return false;
            }
            if (cboPositions.Text.ToString() == "")
            {
                MessageBox.Show(Properties.rsfEmployee.EmployeeInfo4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPositions.Focus();
                return false;
            }
            return true;                                     
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Reset control     
        /// </summary>
        protected void ResetControls()
        {
            try
            {
                txtEmployeeCode.Text = "";
                txtSurName.Text = "";
                txtName.Text = "";
                txtBarCode.Text = "";
                txtBirthPlaces.Text = "";
                txtEducation.Text = "";
                txtEmail.Text = "";
                txtIdentityCard.Text = "";
                txtMobile.Text = "";
                txtPernamentAdress.Text = "";
                txtPernamentPhone.Text = "";
                txtPlacesCard.Text = "";
                txtResidentAdress.Text = "";
                txtResidentPhone.Text = "";
                txtSalary.Text = "";
                txtWorkPlaces.Text = "";
                cboSex.SelectedIndex = -1;
                cboReligion.SelectedIndex = -1;
                cboPositions.SelectedIndex = -1;
                cboMarriess.SelectedIndex = -1;
                cboGroupStore.SelectedIndex = -1;
                cboWorkStatus.SelectedIndex = -1;
                dtpDateOfBirth.Enabled = true;
                dtpDateCreateIdCard.Enabled = true;
                dtpDateOff.Enabled = true;
                dtpDateStart.Enabled = true;
                dtpDateCreateIdCard.Value = sqlDac.GetDateTimeServer();
                dtpDateOfBirth.Value = sqlDac.GetDateTimeServer();
                dtpDateOff.Value = sqlDac.GetDateTimeServer();
                dtpDateStart.Value = sqlDac.GetDateTimeServer();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        // Tạo mã thu tiền tự động
        public string GetAutoCode(string table, string col, string prefix)
        {
            try
            {
                string result = "";
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@Col", col);
                para[1] = posdb_vnmSqlDAC.newInParam("@Table", table);
                para[2] = posdb_vnmSqlDAC.newInParam("@Prefix", prefix);
                DataTable dt = sqlDac.GetDataTable("GetAutoCode", para);
                result = dt.Rows[0]["code"].ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //set menu khi load form
        private void SetMenu()
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool save = (txtEmployeeCode.Text != "" && txtEmployeeCode!= null) ? true : false;
                bool delete = (lvwEmployeeSearch.Items.Count > 0) ? true : false;
                bool[] active = { true, save, false, false, delete, false, false, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
                lvwEmployeeSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //set menu khi click nut save
        private void setMenuSave()
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool save = (lvwEmployeeSearch.Items.Count > 0) ? true : false;
                bool delete = (lvwEmployeeSearch.Items.Count > 0) ? true : false;
                bool[] active = { true, true, false, true, delete, false, false, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }    
        }

        //Lay chuoi cua hang
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

        #endregion

        #region Event

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý các control khi click vào nút add trên tooltrip  
        /// </summary>
        private void AddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    mnuProcess.setControlAdd(this, "txtEmployeeCode", false);
                    mnuProcess.setControlAdd(this, "txtSurName", true);
                    mnuProcess.setControlAdd(this, "txtName", true);
                    mnuProcess.setControlAdd(this, "btnEmployeeSearch", true);
                    mnuProcess.setControlAdd(this, "lvwEmployee", false);
                    mnuProcess.setControlAdd(this, "btnDeleteImage", false);
                    mnuProcess.setControlAdd(this, "btnChooseImg", true);
                    mnuProcess.setControlAdd(this, "cboSex", true);
                    workStatus();
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddNew' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý các control khi click vào nút Cancel trên tooltrip  
        /// </summary>
        private void Cancel(object sender, EventArgs e)
        {
            try
            {
                mnuProcess.setControlAdd(this, "txtEmployeeCode", false);
                mnuProcess.setControlAdd(this, "txtSurName", true);
                mnuProcess.setControlAdd(this, "txtName", true);
                mnuProcess.setControlAdd(this, "btnEmployeeSearch", true);
                mnuProcess.setControlAdd(this, "lvwEmployee", false);
                mnuProcess.setControlAdd(this, "btnDeleteImage", false);
                mnuProcess.setControlAdd(this, "cboSex", true);   
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cancel' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý các control khi click vào nút Search trên tooltrip  
        /// </summary>
        private void Search(object sender, EventArgs e)
        {
            try
            {
                //
                mnuProcess.setControlAdd(this, "txtEmployeeCode", false);
                mnuProcess.setControlAdd(this, "txtSurName", true);
                mnuProcess.setControlAdd(this, "txtName", true);
                mnuProcess.setControlAdd(this, "btnEmployeeSearch", true);
                mnuProcess.setControlAdd(this, "lvwEmployee", false);
                mnuProcess.setControlAdd(this, "btnDeleteImage", false);
                mnuProcess.setControlAdd(this, "cboSex", true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Search' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Save nhân viên 
        /// </summary>
        private void Save(object sender, EventArgs e)
        {
            try
            {

                createEmployee(txtEmployeeCode.Text);
                MessageBox.Show(Properties.rsfSales.CreateSuccess.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Save' : " + ex.Message);
            }
        }


        private void gbxTTNhanVien_Enter(object sender, EventArgs e)
        {

        }

         /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Lấy thông tin nhân viên từ form frmEmployeeSearch  
        /// </summary>
        private void frmEmployeeInformation_evSearch(object sender, EventArgs e)
        {
            try
            {
                frmEmployeeSearch frmseach = new frmEmployeeSearch(translate);
                frmseach.StartPosition = FormStartPosition.CenterScreen;
                frmseach.ShowDialog();
                //frmseach.lvwEmployeeChoose.Items

                ListView.SelectedListViewItemCollection list = frmseach.lvwEmployeeChoose.SelectedItems;
                foreach (ListViewItem item in list)
                {
                    ListViewItem itemChoose = new ListViewItem(item.SubItems[0].Text);
                    itemChoose.SubItems.Add(item.SubItems[2].Text);
                    itemChoose.SubItems.Add(item.SubItems[1].Text);

                    if (lvwEmployeeSearch.Items.Count > 0)
                    {
                        if (item.SubItems[0].Text != lvwEmployeeSearch.Items[0].SubItems[0].Text)
                        {
                            lvwEmployeeSearch.Items.Add(itemChoose);
                            loadEmployeeInfor(item.SubItems[0].Text);
                        }
                    }
                    else
                    {
                        lvwEmployeeSearch.Items.Add(itemChoose);
                        loadEmployeeInfor(item.SubItems[0].Text);    
                    }
                }
                //if (list.Count > 1)
                //{
                //    loadEmployeeInfor(lvwEmployeeSearch.Items[0].Text);
                //}
                SetMenu();
            }
            catch (Exception ex)
            {
                log.Error("Error 'EmployeeInformation_evSearch' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Load thông tin nhân viên
        /// </summary>
        private void frmEmployeeInformation_Load(object sender, EventArgs e)
        {
            try
            {
                txtWorkPlaces.Text = GetPlaceCreate(UserImformation.DeptNumber);
                txtWorkPlaces.Enabled = false;
                txtEmployeeCode.ReadOnly = true;
                SetMenu();
                ResetControls();

                //gọi hàm load các combobox

                CustomerManager.LoadMasterCode(this.cboSex, sexPrifix);
                CustomerManager.LoadMasterCode(this.cboGroupStore, emgPrefix);
                //CustomerManager.LoadMasterCode(this.cboWorkStatus, cugPrefix);
                CustomerManager.LoadMasterCode(this.cboPositions, posPrefix);
                CustomerManager.LoadMasterCode(this.cboMarriess, masPrefix);
                CustomerManager.LoadMasterCode(this.cboReligion, relPrifix);
               
                workStatus();

                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmEmployeeInfo' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkInsert = checkInsert == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()) : checkInsert;
                        //checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                        checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error '' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý nút thêm mới nhân viên
        /// </summary>
        private void frmEmployeeInformation_evAddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                    bool[] active = { false, true, false, true, false, false, false, false, false, false, true, true };
                    parMain.ActiveMenu(active);
                    status = active;
                    add = true;
                    ResetControls();
                    //Tạo mã nhân viên tự động
                    List<EMPLOYEE_INFO> listEmployee = new List<EMPLOYEE_INFO>();
                    string autoID = GetAutoCode("EMPLOYEE_INFO", "EMPLOYEE_ID", "000");

                    txtEmployeeCode.ReadOnly = true;
                    txtEmployeeCode.Text = autoID;
                    lvwEmployeeSearch.Enabled = false;
                    //createEmployee();
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý nút Hủy
        /// </summary>
        private void frmEmployeeInformation_evCancel(object sender, EventArgs e)
        {
            try
            {
                if (lvwEmployeeSearch.Items.Count == 0)
                {
                    ResetControls();
                }
                else
                {
                    loadEmployeeInfor(lvwEmployeeSearch.Items[0].SubItems[0].Text);
                }
                SetMenu();
                dtpDateOfBirth.Enabled = false;
                dtpDateCreateIdCard.Enabled = false;
                dtpDateOff.Enabled = false;
                dtpDateStart.Enabled = false;
                lvwEmployeeSearch.Enabled = true;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý nút Save
        /// </summary>
        private void frmEmployeeInformation_evSave(object sender, EventArgs e)
        {
            try
            {
                if (checkUpdate)
                {
                    
                    createEmployee(txtEmployeeCode.Text);
                    if (lvwEmployeeSearch.Items.Count > 0)
                    {
                        dtpDateOfBirth.Enabled = true;
                        dtpDateCreateIdCard.Enabled = true;
                        dtpDateOff.Enabled = true;
                        dtpDateStart.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }
        
        //Xử lý nút xóa ảnh
        private void btnDeleteImg_Click(object sender, EventArgs e)
        {
                
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Sự kiện textchange của textbox tiền lương
        /// </summary>
        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSalary.Text = Conversion.GetCurrency(Conversion.Replaces(txtSalary.Text));
                txtSalary.SelectionStart = txtSalary.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Chỉ cho nhập số vào ô tiền lương  
        /// </summary>
        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
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
       
        private void btnEmployeeSearch_Enter(object sender, EventArgs e)
        {
            //searchEmployee(txtEmployeeSearch.Text);
        }

        //Sự kiện click nút thêm mới
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //createEmployee();
            //loadEmployeeInfor(txtEmployeeCode.Text);
        }
        
        //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetControls();
            loadEmployeeInfor("");
        }

        private void txtIdentityCard_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIdentityCard_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý nút tìm kiếm nhân viên:
        /// + Nếu text tìm kiếm là kí tự số thì gọi hàm search và load nhân viên
        /// + Nếu text tìm kiếm là kí tự chữ thì gọi dialog frmSearchEmployeeName để chọn nhân viên
        /// </summary>
        frmSearchEmployeeName frmSearchName;
        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                char c = Convert.ToChar(txtEmployeeSearch.Text.Substring(0, 1));
                textName = txtEmployeeSearch.Text;
                if (!char.IsDigit(c))
                {
                    frmSearchName = new frmSearchEmployeeName(translate);
                    frmSearchName.TextName = Conversion.ConvertVN(txtEmployeeSearch.Text);
                    frmSearchName.StartPosition = FormStartPosition.CenterScreen;
                    frmSearchName.ShowDialog();

                    ListView.SelectedListViewItemCollection list = frmSearchName.lvwSearchEmName.SelectedItems;
                    foreach (ListViewItem item in list)
                    {
                        ListViewItem itemName = new ListViewItem(item.SubItems[0].Text);
                        itemName.SubItems.Add(item.SubItems[2].Text);
                        itemName.SubItems.Add(item.SubItems[1].Text);

                        if (lvwEmployeeSearch.Items.Count > 0)
                        {
                            if (item.SubItems[0].Text != lvwEmployeeSearch.Items[0].SubItems[0].Text)
                            {
                                lvwEmployeeSearch.Items.Add(itemName);
                                loadEmployeeInfor(item.SubItems[0].Text);
                            }
                        }
                        else
                        {
                            lvwEmployeeSearch.Items.Add(itemName);
                            loadEmployeeInfor(item.SubItems[0].Text);
                        }
                    }  
                }
                else
                {
                    searchEmployee(txtEmployeeSearch.Text);
                    loadEmployeeInfor(txtEmployeeSearch.Text);
                    lvwEmployeeSearch.Enabled = true;
                }
                SetMenu();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Sự kiện thay đổi dòng trên listview
        /// </summary>
        string idEm = "";
        private void lvwEmployeeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwEmployeeSearch.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection list = lvwEmployeeSearch.SelectedItems;
                foreach (ListViewItem item in list)
                {
                    idEm = item.Text;
                    loadEmployeeInfor(item.SubItems[0].Text);
                }
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Sự kiện columnClick: Sắp xếp theo thứ thự tăng hoặc giảm của một cột bất kỳ trên listview
        /// </summary>
        private void lvwEmployeeSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (e.Column == lvwSortter.SortColumn)
            //{
            //    // Reverse the current sort direction for this column.
            //    if (lvwSortter.Order == System.Windows.Forms.SortOrder.Ascending)
            //    {
            //        lvwSortter.Order = System.Windows.Forms.SortOrder.Descending;
            //    }
            //    else
            //    {
            //        lvwSortter.Order = System.Windows.Forms.SortOrder.Ascending;
            //    }
            //}
            //else
            //{
            //    // Set the column number that is to be sorted; default to ascending.
            //    lvwSortter.SortColumn = e.Column;
            //    lvwSortter.Order = System.Windows.Forms.SortOrder.Ascending;
            //}

            //// Perform the sort with these new sort options.
            //this.lvwEmployeeSearch.Sort();
        }

        /// <summary>
        /// Người tạo Hieppd – 18/10/2013 : Xử lý Nhập text Tìm kiếm và nhấn phím Enter
        /// + Nếu text tìm kiếm là kí tự số thì gọi hàm search và load nhân viên
        /// + Nếu text tìm kiếm là kí tự chữ thì gọi dialog frmSearchEmployeeName để chọn nhân viên 
        /// </summary>
        private void txtEmployeeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    char c = Convert.ToChar(txtEmployeeSearch.Text.Substring(0, 1));
                    if (!char.IsDigit(c))
                    {
                        frmSearchName = new frmSearchEmployeeName(translate);
                        frmSearchName.TextName = Conversion.ConvertVN(txtEmployeeSearch.Text);
                        frmSearchName.StartPosition = FormStartPosition.CenterScreen;
                        frmSearchName.ShowDialog();
                        ListView.SelectedListViewItemCollection list = frmSearchName.lvwSearchEmName.SelectedItems;
                        foreach (ListViewItem item in list)
                        {
                            ListViewItem itemName = new ListViewItem(item.SubItems[0].Text);
                            itemName.SubItems.Add(item.SubItems[2].Text);
                            itemName.SubItems.Add(item.SubItems[1].Text);
                            //kiem tra neu manv chua co thi add vao listview
                            if (lvwEmployeeSearch.Items.Count > 0)
                            {
                                if (item.SubItems[0].Text != lvwEmployeeSearch.Items[0].SubItems[0].Text)
                                {
                                    lvwEmployeeSearch.Items.Add(itemName);
                                    loadEmployeeInfor(item.SubItems[0].Text);
                                }
                            }
                            else
                            {
                                lvwEmployeeSearch.Items.Add(itemName);
                                loadEmployeeInfor(item.SubItems[0].Text);
                            }
                        }
                        
                    }
                    else
                    {
                        searchEmployee(txtEmployeeSearch.Text);
                        loadEmployeeInfor(txtEmployeeSearch.Text);
                    }
                    SetMenu();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        private void txtEmployeeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        
        //hàm kiểm tra text tìm kiếm
      
        private void frmEmployeeInformation_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    frmSearchName = new frmSearchEmployeeName();
            //    frmSearchName.Close();    
            //}
        }

        private void frmEmployeeInformation_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmEmployeeInformation_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }

        private void frmEmployeeInformation_evDelete(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    if (idEm != string.Empty)
                    {
                        //Lấy index của dòng được chọn
                        int selectedindex = lvwEmployeeSearch.SelectedIndices[0];
                        string emcode = txtEmployeeCode.Text;
                        if (MessageBox.Show(Properties.rsfPayment.CashPayment4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lvwEmployeeSearch.Items.Remove(lvwEmployeeSearch.Items[selectedindex]);

                            ListViewItem item = lvwEmployeeSearch.FocusedItem;
                            string proc = "EMPLOYEE_INFO_Delete";
                            SqlParameter[] para;
                            para = new SqlParameter[1];
                            para[0] = posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", SqlDbType.VarChar, emcode);
                            sqlDac.Execute(proc, para);

                            MessageBox.Show(Properties.rsfPayment.CashPayment5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    if (lvwEmployeeSearch.Items.Count > 0)
                    {
                        lvwEmployeeSearch.Items[0].Selected = true;
                    }
                    else
                    {
                        ResetControls();
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        #endregion

    }
}

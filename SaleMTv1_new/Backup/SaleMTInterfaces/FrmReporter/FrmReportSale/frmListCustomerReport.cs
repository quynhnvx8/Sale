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

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmListCustomerReport : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<CUSTOMERS> listCus = new List<CUSTOMERS>();
        private int rows;
        #endregion

        #region Constructtor
        public frmListCustomerReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboRows.Text = "20";
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.lblPage.Text = translate["frmListCustomerReport.lblPage.Text"];
            this.lblSCount.Text = translate["frmListCustomerReport.lblSCount.Text"];
            this.btnChoosePage.Text = translate["frmListCustomerReport.btnChoosePage.Text"];
            this.label11.Text = translate["frmListCustomerReport.label11.Text"];
            this.groupBox1.Text = translate["frmListCustomerReport.groupBox1.Text"];
            this.chkNo.Text = translate["frmListCustomerReport.chkNo.Text"];
            this.chkYes.Text = translate["frmListCustomerReport.chkYes.Text"];
            this.chkToMoney.Text = translate["frmListCustomerReport.chkToMoney.Text"];
            this.label7.Text = translate["frmListCustomerReport.label7.Text"];
            this.label5.Text = translate["frmListCustomerReport.label5.Text"];
            this.label4.Text = translate["frmListCustomerReport.label4.Text"];
            this.label3.Text = translate["frmListCustomerReport.label3.Text"];
            this.label1.Text = translate["frmListCustomerReport.label1.Text"];
            this.groupBox2.Text = translate["frmListCustomerReport.groupBox2.Text"];
            this.label13.Text = translate["frmListCustomerReport.label13.Text"];
            this.label12.Text = translate["frmListCustomerReport.label12.Text"];
            this.btnSeach.Text = translate["frmListCustomerReport.btnSeach.Text"];
            this.btnExport.Text = translate["frmListCustomerReport.btnExport.Text"];
            this.groupBox5.Text = translate["frmListCustomerReport.groupBox5.Text"];
            this.btnExit.Text = translate["frmListCustomerReport.btnExit.Text"];
            this.CUSTOMER_ID.HeaderText = translate["frmListCustomerReport.CUSTOMER_ID.HeaderText"];
            this.FIRST_NAME.HeaderText = translate["frmListCustomerReport.FIRST_NAME.HeaderText"];
            this.LAST_NAME.HeaderText = translate["frmListCustomerReport.LAST_NAME.HeaderText"];
            this.DATE_OF_BIRTH.HeaderText = translate["frmListCustomerReport.DATE_OF_BIRTH.HeaderText"];
            this.YEAR_OF_BIRTH.HeaderText = translate["frmListCustomerReport.YEAR_OF_BIRTH.HeaderText"];
            this.PLACE_OF_BIRTH.HeaderText = translate["frmListCustomerReport.PLACE_OF_BIRTH.HeaderText"];
            this.TEL.HeaderText = translate["frmListCustomerReport.TEL.HeaderText"];
            this.MOBILE_PHONE.HeaderText = translate["frmListCustomerReport.MOBILE_PHONE.HeaderText"];
            this.EMAIL_ADDRESS.HeaderText = translate["frmListCustomerReport.EMAIL_ADDRESS.HeaderText"];
            this.FAX.HeaderText = translate["frmListCustomerReport.FAX.HeaderText"];
            this.ADDRESS.HeaderText = translate["frmListCustomerReport.ADDRESS.HeaderText"];
            this.Country.HeaderText = translate["frmListCustomerReport.Country.HeaderText"];
            this.City.HeaderText = translate["frmListCustomerReport.City.HeaderText"];
            this.DISTRICT_OTHER.HeaderText = translate["frmListCustomerReport.DISTRICT_OTHER.HeaderText"];
            this.COMMUNES_WARDS.HeaderText = translate["frmListCustomerReport.COMMUNES_WARDS.HeaderText"];
            this.HOUSE_STREET.HeaderText = translate["frmListCustomerReport.HOUSE_STREET.HeaderText"];
            this.WORKING_OFFICE.HeaderText = translate["frmListCustomerReport.WORKING_OFFICE.HeaderText"];
            this.OFFICE_ADDRESS.HeaderText = translate["frmListCustomerReport.OFFICE_ADDRESS.HeaderText"];
            this.Sex.HeaderText = translate["frmListCustomerReport.Sex.HeaderText"];
            this.Column21.HeaderText = translate["frmListCustomerReport.Column21.HeaderText"];
            this.RaceName.HeaderText = translate["frmListCustomerReport.RaceName.HeaderText"];
            this.RegionName.HeaderText = translate["frmListCustomerReport.RegionName.HeaderText"];
            this.OCCUPATION_OTHER.HeaderText = translate["frmListCustomerReport.OCCUPATION_OTHER.HeaderText"];
            this.Column25.HeaderText = translate["frmListCustomerReport.Column25.HeaderText"];
            this.Marital.HeaderText = translate["frmListCustomerReport.Marital.HeaderText"];
            this.Column27.HeaderText = translate["frmListCustomerReport.Column27.HeaderText"];
            this.ID_NO.HeaderText = translate["frmListCustomerReport.ID_NO.HeaderText"];
            this.ID_NO_ISSUED_DATE.HeaderText = translate["frmListCustomerReport.ID_NO_ISSUED_DATE.HeaderText"];
            this.ID_NO_ISSUED_PLACE.HeaderText = translate["frmListCustomerReport.ID_NO_ISSUED_PLACE.HeaderText"];
            this.PASSPORT_NO.HeaderText = translate["frmListCustomerReport.PASSPORT_NO.HeaderText"];
            this.PASSPORT_NO_EXPIRY_DATE.HeaderText = translate["frmListCustomerReport.PASSPORT_NO_EXPIRY_DATE.HeaderText"];
            this.PASSPORT_NO_ISSUED_DATE.HeaderText = translate["frmListCustomerReport.PASSPORT_NO_ISSUED_DATE.HeaderText"];
            this.PASSPORT_NO_ISSUED_PLACE.HeaderText = translate["frmListCustomerReport.PASSPORT_NO_ISSUED_PLACE.HeaderText"];
            this.REMARK.HeaderText = translate["frmListCustomerReport.REMARK.HeaderText"];
            this.CREATE_DATE.HeaderText = translate["frmListCustomerReport.CREATE_DATE.HeaderText"];
            this.CREATE_BY.HeaderText = translate["frmListCustomerReport.CREATE_BY.HeaderText"];
            this.UPDATE_DATE.HeaderText = translate["frmListCustomerReport.UPDATE_DATE.HeaderText"];
            this.LAST_UPDATE_BY.HeaderText = translate["frmListCustomerReport.LAST_UPDATE_BY.HeaderText"];
            this.Text = translate["frmListCustomerReport.Text"];
        }	

        #endregion

        #region Constant
        public string StoreName, Path, dateFrom, dateTo;
        private string sexPrifix = Properties.rsfMasterCode.Sex.ToString();
        //private string relPrifix = Properties.rsfMasterCode.Relligion.ToString();
        //private string bloPrifix = Properties.rsfMasterCode.Blood.ToString();
        //private string racPrefix = Properties.rsfMasterCode.Race.ToString();
        private string cugPrefix = Properties.rsfMasterCode.CustomerGroup.ToString();
        private string masPrefix = Properties.rsfMasterCode.Marrital.ToString();
        private string couPrefix = Properties.rsfMasterCode.Country.ToString();
        private string occPrefix = Properties.rsfMasterCode.Job.ToString();
        private string provincefix = Properties.rsfMasterCode.Province.ToString();

        private string sexcode, groupcus, marr, coun, job,province;

        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        #endregion

        #region Methods
        //gan gt
        private void GetGT()
        {
            try
            {
                if (cboSex.SelectedIndex == -1 || cboSex.SelectedIndex == 0)
                {
                    sexcode = null;
                }
                else
                    sexcode = cboSex.SelectedValue != null ? cboSex.SelectedValue.ToString() : "";

                if (cboGroupCus.SelectedIndex == -1 || cboGroupCus.SelectedIndex == 0)
                {
                    groupcus = null;
                }
                else
                    groupcus = cboGroupCus.SelectedValue != null ? cboGroupCus.SelectedValue.ToString() : "";

                if (cboJob.SelectedIndex == -1 || cboJob.SelectedIndex == 0)
                {
                    job = null;
                }
                else
                    job = cboJob.SelectedValue != null ? cboJob.SelectedValue.ToString() : "";

                if (cboMariess.SelectedIndex == -1 || cboMariess.SelectedIndex == 0)
                {
                    marr = null;
                }
                else
                    marr = cboMariess.SelectedValue != null ? cboMariess.SelectedValue.ToString() : "";

                if (cboCountry.SelectedIndex == -1 || cboCountry.SelectedIndex == 0)
                {
                    coun = null;
                }
                else
                    coun = cboCountry.SelectedValue != null ? cboCountry.SelectedValue.ToString() : "";

                if (cboTP.SelectedIndex == -1 || cboTP.SelectedIndex == 0)
                {
                    province = null;
                }
                else
                    province = cboTP.SelectedValue != null ? cboTP.SelectedValue.ToString() : "";
               
                if (chkYes.Checked)
                {
                    chkNo.Checked = false;
                }
                if (chkNo.Checked)
                {
                    chkYes.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: GetGT" + ex.Message);
            }
        }

        public void SetINFBC(string strStoreName, string strPath)
        {
            try
            {
                StoreName = strStoreName;
                Path = strPath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }

        }

        private void ExportExcel()
        {
            try
            {
                if (dgvCustomers.Rows.Count > 0)
                {
                    //DataTable dtEx = Conversion.ConvertDataGridVewToDataTable(dgvCustomers);

                    //string fileName = "" + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    //string date = "TỪ NGÀY: " + dateFrom + " ĐẾN NGÀY: " + dateTo;
                    //Export ex = new Export();
                    //ex.InfoCompany = true;
                    //ex.InfoStore = true;
                    //ex.StrTitle = "06.06.BÁO CÁO DANH SÁCH KHÁCH HÀNG".ToUpper();

                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = "06.06.BÁO CÁO DANH SÁCH KHÁCH HÀNG";
                    exN.Dgv = this.dgvCustomers;
                    exN.CaseEx = 3;
                    exN.FileNames = "" + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    int[] col = { 0 };
                    exN.ArrSum = col;
                    exN.RSumQuantity = 0;
                    //exN.StrDate = "TỪ NGÀY: " + dtp.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    exN.ExportExcels();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //load du lieu vao treview listShop
        private void LoadTreListStore()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", STO_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_LIST_STORE_CODE);
                    trNode.Expand();
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.StoreCode)
                        {
                            childNode.Checked = true;
                            //childNode.Expand();
                        }
                    }
                    this.treStoreList.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreListStore': " + ex.Message);
            }

        }

        private void LoadTrePlace()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", LOC_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_PALCE_CODE);
                    trNode.Expand();
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);

                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.BusinessTypeCode)
                        {
                            childNode.Checked = true;

                        }
                    }
                    this.trePlace.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTrePlace': " + ex.Message);
            }
            //node goc dau tien

        }

        private void LoadTreShop()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber) };
                DataTable dtMaster = sqlDac.GetDataTable("GetTreeDeptCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode[] childNode = new TreeNode[dtMaster.Rows.Count];

                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        childNode[i] = new TreeNode(dtMaster.Rows[i]["name"].ToString());
                        childNode[i].Expand();
                    }
                    for (int i = 0; i < childNode.Length - 1; i++)
                    {
                        childNode[i].Nodes.Add(childNode[i + 1]);
                        if (i >= childNode.Length - 2)
                        {
                            childNode[i].Checked = true;
                            childNode[i + 1].Checked = true;

                        }
                    }
                    this.treStore.Nodes.Add(childNode[0]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreShop': " + ex.Message);
            }
            //node goc dau tien

        }

        //Ham an hien cac tab
        private void DisplayTab()
        {
            try
            {
                if (pnlStoreList.Size.Height == 26)
                {
                    btnStoreList.ImageIndex = 0;
                    pnlStoreList.Size = new Size(217, 139);
                    pnlPlace.Location = new Point(3, 12 + 139);
                    pnlStore.Location = new Point(3, 12 + 139 + pnlStoreS.Size.Height);
                }
                else
                {
                    btnStoreList.ImageIndex = 1;
                    pnlStoreList.Size = new Size(217, 26);
                    pnlPlace.Location = new Point(3, 12 + 26);
                    pnlStore.Location = new Point(3, 12 + 26 + pnlPlace.Size.Height);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void ResizePlace()
        {
            try
            {
                if (pnlPlace.Size.Height == 26)
                {
                    btnPlace.ImageIndex = 0;
                    pnlPlace.Size = new Size(217, 139);
                    pnlStore.Location = new Point(3, 12 + pnlStoreList.Size.Height + 139);
                }
                else
                {
                    btnPlace.ImageIndex = 1;
                    pnlPlace.Size = new Size(217, 26);
                    pnlStore.Location = new Point(3, 12 + pnlStoreList.Size.Height + 26);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void ResizeShop()
        {
            try
            {
                if (pnlStore.Size.Height == 26)
                {
                    btnStore.ImageIndex = 0;
                    pnlStore.Size = new Size(217, 369);
                }
                else
                {
                    btnStore.ImageIndex = 1;
                    pnlStore.Size = new Size(217, 26);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void LoadControl()
        {
            try
            {
                pnlStoreList.Size = new Size(217, 26);
                pnlPlace.Size = new Size(217, 26);
                pnlPlace.Location = new Point(4, 38);
                pnlStore.Size = new Size(217, 26);
                pnlStore.Location = new Point(4, 64);
                treStoreList.Enabled = false;
                trePlace.Enabled = false;
                treStore.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }

        }
        //Load data vao cac combobox
        private void SetValueControlText(CUSTOMERS cus)
        {
            try
            {
                if (cus.SEX_CODE != null)
                    
                    cboSex.SelectedValue = cus.SEX_CODE;
                    
                if (cus.OCCUPATION_CODE != null)
                    cboJob.SelectedValue = cus.OCCUPATION_CODE;
                if (cus.MARITAL_STATUS != null)
                    cboMariess.SelectedValue = cus.MARITAL_STATUS;
                if (cus.CUSTOMER_GROUP_CODE != null)
                    cboGroupCus.SelectedValue = cus.CUSTOMER_GROUP_CODE;
                if (cus.COUNTRY_CODE != null)
                    cboCountry.SelectedValue = cus.COUNTRY_CODE;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        //phân trang
        private void DoPaning()
        {
            try
            {
                DataTable gridTable = (DataTable)dgvCustomers.DataSource;

                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

                int rowOnPage = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                gridTable.DefaultView.RowFilter = "STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString();
                if (currentPage == 0)
                {
                    btnTopPage.Enabled = false;
                    btnPrev.Enabled = false;
                }
                if (currentPage == pageCount)
                {
                    btnNext.Enabled = false;
                    btnEndPage.Enabled = false;
                }
                if (rows > pageSize)
                {
                    btnTopPage.Enabled = (currentPage > 1);
                    btnPrev.Enabled = (currentPage > 1);
                    btnNext.Enabled = (currentPage < pageCount);
                    btnEndPage.Enabled = (currentPage < pageCount);
                }
                if (dgvCustomers.Rows.Count > 0)
                {
                    dgvCustomers.Rows[0].Cells[0].Selected = true;
                    btnExport.Enabled = true;
                    btnChoosePage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: DoPaing" + ex.Message);
            }
        }

        //tim kiem thong tin khach hang
        DataTable dtExcel = new DataTable();
        private void SearchCustomers()
        {
            try
            {
                if (chkYes.Checked)
                {
                    GetGT();
                    string proc = "rptListCusTomer";
                    SqlParameter[] paraCus;
                    paraCus = new SqlParameter[7];
                    paraCus[0] = posdb_vnmSqlDAC.newInParam("@Sex", sexcode);
                    paraCus[1] = posdb_vnmSqlDAC.newInParam("@Job", job);
                    paraCus[2] = posdb_vnmSqlDAC.newInParam("@Marital", marr);
                    paraCus[3] = posdb_vnmSqlDAC.newInParam("@GroupCus", groupcus);
                    paraCus[4] = posdb_vnmSqlDAC.newInParam("@Country", coun);
                    paraCus[5] = posdb_vnmSqlDAC.newInParam("@Province", province);
                    paraCus[6] = posdb_vnmSqlDAC.newInParam("@deptCode", UserImformation.DeptNumber);
                    DataSet dtCus = new DataSet();

                    dtCus = sqlDac.GetDataSet(proc, paraCus);
                    dtExcel = dtCus.Tables[1].Copy();
                    if (dtCus.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(Properties.rsfReport.Coupon.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCustomers.DataSource = null;
                    }
                    DataTable tem = new DataTable();
                    tem = dtCus.Tables[0].Copy();
                    rows = dtCus.Tables[0].Rows.Count;
                    dgvCustomers.AutoGenerateColumns = false;
                    dgvCustomers.DataSource = tem;

                    lblSCount.Text = "Tổng: " + rows.ToString() + " dòng";
                    lblCurrentPage.Text = (rows > 0) ? "1" : "0";
                    int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                    int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                    lblTotalPage.Text = pageCount.ToString();
                }
                else
                {
                    MessageBox.Show(translate["Msg.DataNotFound"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvCustomers.DataSource = null;    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: SearchCus" + ex.Message);
            }
        }
        #endregion

        #region Event
        private void frmListCustomerReport_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerManager.LoadMasterCode(this.cboSex, sexPrifix);
                CustomerManager.LoadMasterCode(this.cboTP, provincefix);
                CustomerManager.LoadMasterCode(this.cboGroupCus, cugPrefix);
                CustomerManager.LoadMasterCode(this.cboCountry, couPrefix);
                CustomerManager.LoadMasterCode(this.cboMariess, masPrefix);
                CustomerManager.LoadMasterCode(this.cboJob, occPrefix);
                LoadControl();
                LoadTreListStore();
                LoadTrePlace();
                LoadTreShop();

                btnChoosePage.Enabled = false;
                btnEndPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnTopPage.Enabled = false;
                btnExport.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStoreList_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTab();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSex.SelectedValue != null)
                {
                    //SearchCustomers();
                    //DoPaning();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboRace_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboHp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJob.SelectedValue != null)
            {
                //SearchCustomers();
                //DoPaning();
            }
        }

        private void cboMariess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMariess.SelectedValue != null)
            {
                //SearchCustomers();
                //DoPaning();
            }
        }

        private void cboGroupCus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroupCus.SelectedValue != null)
            {
                //SearchCustomers();
                //DoPaning();
            }
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedValue != null)
            {
                //SearchCustomers();
                //DoPaning();
            }
        }

        private void cboRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.Rows.Count > 1)
                {
                    lblCurrentPage.Text = "1";
                    DoPaning();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCustomers();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel exN = new ExportExcel();
                exN.InfoCompany = true;
                exN.InfoStore = true;
                exN.StrTitle = "06.06.BÁO CÁO DANH SÁCH KHÁCH HÀNG";
                exN.Dt = this.dtExcel;
                exN.CaseEx = 3;
                exN.FileNames = "" + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                
                exN.ArrSum = null;
                
                //exN.StrDate = "TỪ NGÀY: " + dtp.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                exN.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        
        //    dgvCustomers.ColumnHeadersVisible = (dgvCustomers.Rows.Count > 0);
        //    btnExport.Enabled = (dgvCustomers.Rows.Count > 0);
        //}

        private void btnTopPage_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = "1";
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage - 1).ToString();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage + 1).ToString();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnEndPage_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = lblTotalPage.Text;
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnChoosePage_Click(object sender, EventArgs e)
        {
            try
            {
                int pageGo = Convert.ToInt32(txtGoPage.Text);
                int pageCount = Convert.ToInt32(lblTotalPage.Text);
                if (pageGo >= 1 && pageGo <= pageCount)
                {
                    lblCurrentPage.Text = txtGoPage.Text;
                    DoPaning();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvCustomers.Font, FontStyle.Bold);

                    int i = 0;

                    foreach (DataGridViewRow r in dgvCustomers.Rows)
                    {
                        if (r.Cells["CUSTOMER_ID"].Value != null)
                        {
                            string name = r.Cells["CUSTOMER_ID"].Value.ToString().Trim();
                            i++;
                            if (i % 2 == 0)
                            {
                                r.DefaultCellStyle = bgcolor;

                            }


                        }

                    }

                }
                dgvCustomers.ColumnHeadersVisible = (dgvCustomers.Rows.Count > 0);
                btnExport.Enabled = (dgvCustomers.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkYes.Checked)
                {
                    chkNo.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNo.Checked)
                {
                    chkYes.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void dgvCustomers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCustomers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                var rowIdx = (e.RowIndex + 1).ToString();

                var centerFormat = new StringFormat()
                {
                    // right alignment might actually make more sense for numbers
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTInterfaces.FrmSaleManagement;
using SaleMTBusiness.CustomerManagement;
using SaleMTCommon;
using SaleMTInterfaces.FrmInventoryManagement;
using SaleMTBusiness.InventoryManagement;


namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    
    public partial class frmSalesReportByCustomerSale : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<string> listPro = new List<string>();
        private int rows;
        private string CATEGORY;
      
        private string StoreName, Path;
        private const string REP_CODE = "||Segment01";
        private string sexPrifix = Properties.rsfMasterCode.Sex.ToString();
        private string relPrifix = Properties.rsfMasterCode.Relligion.ToString();
        private string bloPrifix = Properties.rsfMasterCode.Blood.ToString();
        private string racPrefix = Properties.rsfMasterCode.Race.ToString();
        private string cugPrefix = Properties.rsfMasterCode.CustomerGroup.ToString();
        private string masPrefix = Properties.rsfMasterCode.Marrital.ToString();
        private string couPrefix = Properties.rsfMasterCode.Country.ToString();
        private string occPrefix = Properties.rsfMasterCode.Job.ToString();
        private string strTP = Properties.rsfMasterCode.Province.ToString();
        #endregion

        #region Constructor
        public frmSalesReportByCustomerSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmSalesReportByCustomerSale.groupBox2.Text"];
            this.label18.Text = translate["frmSalesReportByCustomerSale.label18.Text"];
            this.label17.Text = translate["frmSalesReportByCustomerSale.label17.Text"];
            this.groupBox7.Text = translate["frmSalesReportByCustomerSale.groupBox7.Text"];
            this.label14.Text = translate["frmSalesReportByCustomerSale.label14.Text"];
            this.label15.Text = translate["frmSalesReportByCustomerSale.label15.Text"];
            this.groupBox6.Text = translate["frmSalesReportByCustomerSale.groupBox6.Text"];
            this.label13.Text = translate["frmSalesReportByCustomerSale.label13.Text"];
            this.label12.Text = translate["frmSalesReportByCustomerSale.label12.Text"];
            this.groupBox5.Text = translate["frmSalesReportByCustomerSale.groupBox5.Text"];
            this.label10.Text = translate["frmSalesReportByCustomerSale.label10.Text"];
            this.label11.Text = translate["frmSalesReportByCustomerSale.label11.Text"];
            this.chkToMoney.Text = translate["frmSalesReportByCustomerSale.chkToMoney.Text"];
            this.label3.Text = translate["frmSalesReportByCustomerSale.label3.Text"];
            this.label7.Text = translate["frmSalesReportByCustomerSale.label7.Text"];
            this.label4.Text = translate["frmSalesReportByCustomerSale.label4.Text"];
            this.label19.Text = translate["frmSalesReportByCustomerSale.label19.Text"];
            this.label2.Text = translate["frmSalesReportByCustomerSale.label2.Text"];
            this.label1.Text = translate["frmSalesReportByCustomerSale.label1.Text"];
            this.btnExit.Text = translate["frmSalesReportByCustomerSale.btnExit.Text"];
            this.btnExport.Text = translate["frmSalesReportByCustomerSale.btnExport.Text"];
            this.btnSeach.Text = translate["frmSalesReportByCustomerSale.btnSeach.Text"];
            this.groupBox1.Text = translate["frmSalesReportByCustomerSale.groupBox1.Text"];
            this.Column1.HeaderText = translate["frmSalesReportByCustomerSale.Column1.HeaderText"];
            this.Column2.HeaderText = translate["frmSalesReportByCustomerSale.Column2.HeaderText"];
            this.Column3.HeaderText = translate["frmSalesReportByCustomerSale.Column3.HeaderText"];
            this.CUSTOMER_ID.HeaderText = translate["frmSalesReportByCustomerSale.CUSTOMER_ID.HeaderText"];
            this.Column5.HeaderText = translate["frmSalesReportByCustomerSale.Column5.HeaderText"];
            this.Column6.HeaderText = translate["frmSalesReportByCustomerSale.Column6.HeaderText"];
            this.Column7.HeaderText = translate["frmSalesReportByCustomerSale.Column7.HeaderText"];
            this.Column8.HeaderText = translate["frmSalesReportByCustomerSale.Column8.HeaderText"];
            this.Column9.HeaderText = translate["frmSalesReportByCustomerSale.Column9.HeaderText"];
            this.Column10.HeaderText = translate["frmSalesReportByCustomerSale.Column10.HeaderText"];
            this.Column11.HeaderText = translate["frmSalesReportByCustomerSale.Column11.HeaderText"];
            this.Column12.HeaderText = translate["frmSalesReportByCustomerSale.Column12.HeaderText"];
            this.Column13.HeaderText = translate["frmSalesReportByCustomerSale.Column13.HeaderText"];
            this.Column14.HeaderText = translate["frmSalesReportByCustomerSale.Column14.HeaderText"];
            this.Column15.HeaderText = translate["frmSalesReportByCustomerSale.Column15.HeaderText"];
            this.Column16.HeaderText = translate["frmSalesReportByCustomerSale.Column16.HeaderText"];
            this.Column17.HeaderText = translate["frmSalesReportByCustomerSale.Column17.HeaderText"];
            this.Column18.HeaderText = translate["frmSalesReportByCustomerSale.Column18.HeaderText"];
            this.Column19.HeaderText = translate["frmSalesReportByCustomerSale.Column19.HeaderText"];
            this.Column20.HeaderText = translate["frmSalesReportByCustomerSale.Column20.HeaderText"];
            this.Column21.HeaderText = translate["frmSalesReportByCustomerSale.Column21.HeaderText"];
            this.Column22.HeaderText = translate["frmSalesReportByCustomerSale.Column22.HeaderText"];
            this.Column23.HeaderText = translate["frmSalesReportByCustomerSale.Column23.HeaderText"];
            this.label6.Text = translate["frmSalesReportByCustomerSale.label6.Text"];
            this.lblPage.Text = translate["frmSalesReportByCustomerSale.lblPage.Text"];
            this.btnChoosePage.Text = translate["frmSalesReportByCustomerSale.btnChoosePage.Text"];
            this.lblSumCount.Text = translate["frmSalesReportByCustomerSale.lblSumCount.Text"];
            this.btnPrint.Text = translate["frmSalesReportByCustomerSale.btnPrint.Text"];
            this.Text = translate["frmSalesReportByCustomerSale.Text"];

        }
        #endregion

        #region Constant
        

        
        #endregion

        #region Methods
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
                if (cus.PROVINCE_CITY_CODE != null)
                    cboTP.SelectedValue = cus.PROVINCE_CITY_CODE;

            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }        

        private void ResizeCenterCus()
        {
            try
            {
                if (panCenter.Size.Height == 198)
                {
                    btnCus.ImageIndex = 0;
                    btnCus.Location = new Point(736, 5);
                    panCenter.Size = new Size(758, 27);
                    pnlInforCus.Size = new Size(758, 27);
                    panCenter.AutoScroll = false;

                    LoadControlCenter();
                    pnlCenterEm.Visible = true;
                    pnlCenterProduct.Visible = true;
                }
                else
                {
                    btnCus.ImageIndex = 1;
                    btnCus.Location = new Point(716, 5);
                    panCenter.Size = new Size(758, 198);
                    pnlInforCus.Size = new Size(739, 27);

                    panCenter.AutoScroll = true;

                    pnlCenterEm.Visible = false;
                    pnlCenterProduct.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void ResizeCenterEm()
        {
            try
            {
                if (pnlCenterEm.Size.Height == 27)
                {
                    btnEm.ImageIndex = 1;
                    pnlCenterEm.Size = new Size(758, 90);
                    pnlCenterEm.Location = new Point(10, 97);
                    pnlCenterProduct.Location = new Point(10, 97 + 90);
                }
                else
                {
                    btnEm.ImageIndex = 0;
                    pnlCenterEm.Size = new Size(758, 27);
                    pnlCenterProduct.Location = new Point(10, 97 + 27);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void ResizeCenterPro()
        {
            try
            {
                if (pnlCenterProduct.Size.Height == 27)
                {
                    btnPro.ImageIndex = 1;
                    pnlCenterProduct.Size = new Size(758, 90);
                }
                else
                {
                    btnPro.ImageIndex = 0;
                    pnlCenterProduct.Size = new Size(758, 27);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void LoadCenterMax()
        {
            frmSalesReportByCustomerSale frm = new frmSalesReportByCustomerSale(translate);
            if (frm.MaximizeBox)
            {
                panCenter.Size = new Size(frm.Width - ctlInfoStore1.Width, 198);
            }
            else
            {
                panCenter.Size = new Size(758, 198);
                pnlCenterEm.Visible = false;
                pnlCenterProduct.Visible = false;
            }
        }

        private void LoadControlCenter()
        {
            try
            {
                pnlCenterEm.Size = new Size(758, 27);
                pnlCenterEm.Location = new Point(10, 97);
                pnlCenterProduct.Size = new Size(758, 27);
                pnlCenterProduct.Location = new Point(10, 124);
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }
     
        //fill dataset
        private DataSet FillDataset()
        {
            DataSet ds = new DataSet();
            try
            {
                string sexcode, groupcus, marr, coun, job, jobT,dateFrom, dateTo, province;
                int ageFrom, ageTo;
                sexcode = (cboSex.SelectedIndex != -1 && cboSex.Text.Trim() != "") ? cboSex.SelectedValue.ToString() : "-1";
                groupcus = (cboGroupCus.SelectedIndex != -1 && cboGroupCus.Text.Trim() != "") ? cboGroupCus.SelectedValue.ToString() : "-1";
                marr = (cboMariess.SelectedIndex != -1 && cboMariess.Text.Trim() != "") ? cboMariess.SelectedValue.ToString() : "-1";
                coun = (cboCountry.SelectedIndex != -1&&cboCountry.Text.Trim() !="") ? cboCountry.SelectedValue.ToString() : "";
                job = (cboJob.SelectedIndex != -1 && cboJob.Text.Trim() != "") ? cboJob.SelectedValue.ToString() : "-1";
                jobT = (cboJob.SelectedIndex != -1 && cboJob.Text.Trim() != "") ? cboJob.Text.ToString() : "";
                province = (cboTP.SelectedIndex != -1 && cboTP.Text.Trim() != "") ? cboTP.SelectedValue.ToString() : "-1";
                ageFrom =  Convert.ToInt32(nudAgeFrom.Value);
                ageTo = Convert.ToInt32(nudAgeTo.Value);
                dateFrom = (dtpFrom.Checked) ? Conversion.FirstDayTime(dtpFrom.Value).ToString("yyyy/MM/dd HH:mm:ss") : "";
                dateTo = (dtpTo.Checked) ? Conversion.LastDayTime(dtpTo.Value).ToString("yyyy/MM/dd HH:mm:ss") : "";
                SqlParameter[] para = new SqlParameter[26];
                para[0] = posdb_vnmSqlDAC.newInParam("@Product", txtProduct.Text.Trim());
                para[1] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptCode );
                para[2] = posdb_vnmSqlDAC.newInParam("@Sex", sexcode);
                para[3] = posdb_vnmSqlDAC.newInParam("@Blood", "-1");
                para[4] = posdb_vnmSqlDAC.newInParam("@Race","-1");
                para[5] = posdb_vnmSqlDAC.newInParam("@Religion", "-1");
                para[6] = posdb_vnmSqlDAC.newInParam("@OccupationCode", job);
                para[7] = posdb_vnmSqlDAC.newInParam("@OccupationOther", jobT);
                para[8] = posdb_vnmSqlDAC.newInParam("@MaritalStatus", marr);
                para[9] = posdb_vnmSqlDAC.newInParam("@CusGroup", groupcus);
                para[10] = posdb_vnmSqlDAC.newInParam("@AgeFrom", ageFrom);
                para[11] = posdb_vnmSqlDAC.newInParam("@AgeTo", ageTo);
                para[12] = posdb_vnmSqlDAC.newInParam("@CountryCode", coun);
                para[13] = posdb_vnmSqlDAC.newInParam("@ProvinceCityCode", province);
                para[14] = posdb_vnmSqlDAC.newInParam("@DateFrom", dateFrom);
                para[15] = posdb_vnmSqlDAC.newInParam("@DateTo", dateTo);
                para[16] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", "");
                para[17] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", "");
                para[18] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", "");
                para[19] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", "");
                para[20] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", "");
                para[21] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[22] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", false);
                para[23] = posdb_vnmSqlDAC.newInParam("@EmployeeList", "");
                para[24] = posdb_vnmSqlDAC.newInParam("@DateFromSales", Conversion.FirstDayTime(dtpdateFrom.Value));
                para[25] = posdb_vnmSqlDAC.newInParam("@DateToSales", Conversion.LastDayTime(dtpdateTo.Value));
                
                ds = sqlDac.GetDataSet("rptReport_Sales_Report_By_Customer_List", para);
                ds.DataSetName = "dsImportProductsSale";
                ////add thêm bảng date

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(Properties.rsfReport.Coupon, Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvListPro.DataSource = null;
                }
                //ds.Tables[0].TableName = "SalesReport";

                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));

                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = dtpdateFrom.Value.ToString("dd/MM/yyyy");
                drDate["ToDate"] = dtpdateTo.Value.ToString("dd/MM/yyyy");

                dtDate.Rows.Add(drDate);
                ds.Tables[0].TableName = "SalesReport";

                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                DataTable dtlogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtlogo);
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'FillDataset': " + ex.Message);
            }
            return ds;
        }
        //phan trang
        private void DoPaning()
        {
            try
            {
                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

                int s = Convert.ToInt32(cboRows.SelectedItem.ToString()) * Convert.ToInt32(lblCurrentPage.Text) + 1;
                int rowOnPage = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                DataTable gridTable = (DataTable)dgvListPro.DataSource;
                gridTable.DefaultView.RowFilter = "(STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString() + ") or (STT = 0 or STT = " + (rows + 1).ToString() + ")";

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

                btnChoosePage.Enabled = true;
                btnTopPage.Enabled = (currentPage > 1);
                btnPrev.Enabled = (currentPage > 1);
                btnNext.Enabled = (currentPage < pageCount);
                btnEndPage.Enabled = (currentPage < pageCount);
                if (dgvListPro.Rows.Count > 0)
                {
                    dgvListPro.Rows[0].Cells[0].Selected = true;
                    btnExport.Enabled = true;
                    btnChooseEm.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Dopaing': " + ex.Message);
            }
        }

        private void ExportExcel()
        {
            try
            {
                if (dgvListPro.Rows.Count > 0)
                {
                    DataTable dtTemp = FillDataset().Tables[3];
                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = this.Text.ToUpper();
                    exN.Dt = dtTemp;
                    exN.CaseEx = 3;
                    exN.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    int[] col = { 3,12,14,15,16,17,18,19 };
                    exN.ArrSum = col;
                    exN.RSumQuantity = 2;
                    exN.StrDate = "TỪ NGÀY: " + dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    exN.ExportExcels();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void frmSalesReportByCustomerSale_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.ProcessTabKey(true);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        private void frmSalesReportByCustomerSale_Load(object sender, EventArgs e)
        {
            try
            {
                frmSalesReportByCustomerSale frm = new frmSalesReportByCustomerSale(translate);
                if (frm.MaximizeBox)
                {
                    panCenter.Size = new Size(frm.Width - ctlInfoStore1.Width, 198);
                }
                panCenter.Size = new Size(758, 198);
                pnlCenterEm.Visible = false;
                pnlCenterProduct.Visible = false;
                CustomerManager.LoadMasterCode(this.cboSex, sexPrifix);
                //CustomerManager.LoadMasterCode(this.cboRegion, relPrifix);
                //CustomerManager.LoadMasterCode(this.cboHp, bloPrifix);
                //CustomerManager.LoadMasterCode(this.cboRace, racPrefix);
                CustomerManager.LoadMasterCode(this.cboGroupCus, cugPrefix);
                CustomerManager.LoadMasterCode(this.cboCountry, couPrefix);
                CustomerManager.LoadMasterCode(this.cboMariess, masPrefix);
                CustomerManager.LoadMasterCode(this.cboJob, occPrefix);
                CustomerManager.LoadMasterCode(this.cboTP, strTP);
                if (cboRows.Items.Count > 0)
                    cboRows.SelectedIndex = 0;
                btnChoosePage.Enabled = false;
                btnEndPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnTopPage.Enabled = false;
                btnExport.Enabled = false;
                dtpdateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpdateTo.Value = sqlDac.GetDateTimeServer();

            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        //load


        private void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FillDataset();
                rows = ds.Tables[0].Rows.Count;
                lblSumCount.Text = "Tổng: " + rows.ToString() + " dòng";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].NewRow();
                    r["STT"] = 0;
                    r["CUSTOMER_ID"] = "Tổng cộng:";
                    r["QUANTITY"] = ds.Tables[2].Rows[0]["QUANTITY"];
                    r["AMOUNT"] = ds.Tables[2].Rows[0]["AMOUNT"];
                    r["DISCOUNT"] = ds.Tables[2].Rows[0]["DISCOUNT"];
                    r["REBATE"] = ds.Tables[2].Rows[0]["REBATE"];
                    r["REBATE_BY_CUSTOMER_CARD"] = ds.Tables[2].Rows[0]["REBATE_BY_CUSTOMER_CARD"];
                    r["PROMOTION"] = ds.Tables[2].Rows[0]["PROMOTION"];
                    r["TOTAL_AMOUNT"] = ds.Tables[2].Rows[0]["TOTAL_AMOUNT"];
                    ds.Tables[0].Rows.InsertAt(r, 0);

                    DataRow rnew = ds.Tables[0].NewRow();
                    rnew["STT"] = Convert.ToInt32(rows + 1);
                    rnew["CUSTOMER_ID"] = "Tổng cộng:";
                    rnew["QUANTITY"] = ds.Tables[2].Rows[0]["QUANTITY"];
                    rnew["AMOUNT"] = ds.Tables[2].Rows[0]["AMOUNT"];
                    rnew["DISCOUNT"] = ds.Tables[2].Rows[0]["DISCOUNT"];
                    rnew["REBATE"] = ds.Tables[2].Rows[0]["REBATE"];
                    rnew["REBATE_BY_CUSTOMER_CARD"] = ds.Tables[2].Rows[0]["REBATE_BY_CUSTOMER_CARD"];
                    rnew["PROMOTION"] = ds.Tables[2].Rows[0]["PROMOTION"];
                    rnew["TOTAL_AMOUNT"] = ds.Tables[2].Rows[0]["TOTAL_AMOUNT"];
                    ds.Tables[0].Rows.Add(rnew);

                }
                dgvListPro.AutoGenerateColumns = false;
                dgvListPro.DataSource = ds.Tables[0];
                DoPaning();

            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

      
        private void dgvListPro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {

                    //dgvListPro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvListPro.Font, FontStyle.Bold);

                    foreach (DataGridViewColumn c in dgvListPro.Columns)
                    {
                        c.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    int i = 0;

                    foreach (DataGridViewRow r in dgvListPro.Rows)
                    {
                        if (r.Cells["CUSTOMER_ID"].Value != null)
                        {
                            string name = r.Cells["CUSTOMER_ID"].Value.ToString().Trim();
                            i++;
                            if (i % 2 == 0 && name != "Tổng cộng:")
                            {
                                r.DefaultCellStyle = bgcolor;

                            }
                            // nếu là dòng tổng cộng thì in đậm
                            if (name == "Tổng cộng:")
                            {
                                r.DefaultCellStyle = bgcolor1;
                            }
                        }

                    }

                }
                dgvListPro.ColumnHeadersVisible = (dgvListPro.Rows.Count > 0);
                btnExport.Enabled = (dgvListPro.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }
        #region Paging
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
        private void cboRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListPro.Rows.Count > 1)
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
        #endregion
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
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
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeCenterCus();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnEm_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeCenterEm();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeCenterPro();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnChooseEm_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReportSale.frmEmployeeSearchSale frmEm = new frmEmployeeSearchSale(translate);
                frmEm.StartPosition = FormStartPosition.CenterParent;
                frmEm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnChoosePro_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReportSale.frmProductReportSearch frm = new frmProductReportSearch(translate);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                frm.Close();
                txtAdProduct.Text = frm.listProGroup.ToString();

                CATEGORY = frm.listProGroupTag.ToString().Replace(REP_CODE, "");
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn = SOManagement.ShowChoseProduct(translate);
                txtProduct.Text = soEn.ListProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                txtProduct.Text = "";
                listPro.Clear();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC(StoreName, Path);
                frm.ds = FillDataset();
                frm.IsMdiContainer = true;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }

        private void dgvListPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpdateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodeProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCodeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    CheckInventoryEntities inventEn = CheckInventory.ShowProductSearch(txtCodeProduct.Text.Trim(), translate);
                    if (inventEn != null)
                    {
                        int check = listPro.FindIndex(s => s == inventEn.ProductID);
                        if (check == -1)
                        {
                            listPro.Add(inventEn.ProductID);
                            string listCode = (txtProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                            txtProduct.Text = txtProduct.Text.Trim() + listCode;
                        }
                    }
                    txtCodeProduct.Text = "";
                    txtCodeProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion

        //private void frmSalesReportByCustomerSale_MaximumSizeChanged(object sender, EventArgs e)
        //{
        //    frmSalesReportByCustomerSale frm = new frmSalesReportByCustomerSale();
        //    panCenter.Size = new Size(frm.Width - ctlInfoStore1.Width, 198);
        //    pnlInforCus.Size = new Size(frm.Width - ctlInfoStore1.Width, 198);
        //}

        private void dtpdateTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}

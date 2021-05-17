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
using SaleMTCommon;
using SaleMTBusiness.InventoryManagement;

namespace SaleMTInterfaces.FrmReporter.FrmReportDiscount
{
    /// <summary>
    /// Người tạo Luannv - 05/11/2013: Form báo cáo hàng khuyến mại
    /// </summary>
    public partial class frmCouponStatus : Form
    {
        #region Declaration
        private const string REPORT_TITLE = "Báo cáo danh sách phiếu giảm giá";
        private const string WAIT_CODE = "WAITING";
        private const string ACTIVE_CODE = "ACTIVED";
        private const string USE_CODE = "USED";
        private const string CAN_CODE = "CANCEL";
        private const string VND_CODE = "VNĐ";
        private const string PER_CODE = "%";
        private const string FROMVALUE_VND = "0";
        private const string TOVALUE_VND = "2000000";
        private const string FROMVALUE_PER = "0";
        private const string TOVALUE_PER = "100";
        private List<string> listPro = new List<string>();        
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        private int rows = 0;
        #endregion

        #region Contructor
        public frmCouponStatus(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmCouponStatus.groupBox2.Text"];
            this.label8.Text = translate["frmCouponStatus.label8.Text"];
            this.label1.Text = translate["frmCouponStatus.label1.Text"];
            this.label5.Text = translate["frmCouponStatus.label5.Text"];
            this.label3.Text = translate["frmCouponStatus.label3.Text"];
            this.label6.Text = translate["frmCouponStatus.label6.Text"];
            this.btnSearch.Text = translate["frmCouponStatus.btnSearch.Text"];
            this.btnExit.Text = translate["frmCouponStatus.btnExit.Text"];
            this.btnExport.Text = translate["frmCouponStatus.btnExport.Text"];
            this.groupBox4.Text = translate["frmCouponStatus.groupBox4.Text"];
            this.btnGoPage.Text = translate["frmCouponStatus.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmCouponStatus.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmCouponStatus.lblPage.Text"];
            this.label2.Text = translate["frmCouponStatus.label2.Text"];
            this.groupBox3.Text = translate["frmCouponStatus.groupBox3.Text"];
            this.rdbCancel.Text = translate["frmCouponStatus.rdbCancel.Text"];
            this.label4.Text = translate["frmCouponStatus.label4.Text"];
            this.rdbUsed.Text = translate["frmCouponStatus.rdbUsed.Text"];
            this.rdbActive.Text = translate["frmCouponStatus.rdbActive.Text"];
            this.label7.Text = translate["frmCouponStatus.label7.Text"];
            this.rdbWait.Text = translate["frmCouponStatus.rdbWait.Text"];
            this.groupBox1.Text = translate["frmCouponStatus.groupBox1.Text"];
            this.Column2.HeaderText = translate["frmCouponStatus.Column2.HeaderText"];
            this.Column1.HeaderText = translate["frmCouponStatus.Column1.HeaderText"];
            this.colAmount.HeaderText = translate["frmCouponStatus.colAmount.HeaderText"];
            this.Column7.HeaderText = translate["frmCouponStatus.Column7.HeaderText"];
            this.Column8.HeaderText = translate["frmCouponStatus.Column8.HeaderText"];
            this.Column6.HeaderText = translate["frmCouponStatus.Column6.HeaderText"];
            this.Column10.HeaderText = translate["frmCouponStatus.Column10.HeaderText"];
            this.Column5.HeaderText = translate["frmCouponStatus.Column5.HeaderText"];
            this.Column3.HeaderText = translate["frmCouponStatus.Column3.HeaderText"];
            this.Text = translate["frmCouponStatus.Text"];

        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        private void DoPaging()
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang","").Trim();
                string[] spl = page.Split('/');

                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                

                int rowOnPage = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
               

                lblPage.Text = currentPage.ToString() + "/" + pageCount.ToString() + " Trang";

                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                DataTable gridTable = (DataTable)dgvListItem.DataSource;
                gridTable.DefaultView.RowFilter = "(STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString() + ")";

                btnFirst.Enabled = (currentPage > 1);
                btnPrev.Enabled = (currentPage > 1);
                btnNext.Enabled = (currentPage < pageCount);
                btnLast.Enabled = (currentPage < pageCount);
                if (dgvListItem.Rows.Count > 0)
                {
                    dgvListItem.Rows[0].Cells[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'DoPaging': " + ex.Message);
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
                log.Error("Error: " + ex.Message);
            }

        }

        private DataSet FillDataset(string store)
        {
            DataSet ds = new DataSet();
            try
            {
                string status = "";
                if (rdbWait.Checked)
                    status = WAIT_CODE;
                else if (rdbActive.Checked)
                    status = ACTIVE_CODE;
                else if (rdbUsed.Checked)
                    status = USE_CODE;
                else if (rdbCancel.Checked)
                    status = CAN_CODE;
                //
                float fromValue = -1;
                float toValue = -1;
                if (txtFromValue.Text.Trim() != "")
                    fromValue = (float)Convert.ToDouble(Conversion.Replaces(txtFromValue.Text.Trim()));
                if (txtToValue.Text.Trim() != "")
                    toValue = (float)Convert.ToDouble(Conversion.Replaces(txtToValue.Text.Trim()));
                //
                DateTime fDate = (dtpDateFrom.Checked) ? dtpDateFrom.Value :Convert.ToDateTime("1900/01/01");
                DateTime tDate = (dtpDateTo.Checked) ? dtpDateTo.Value : Convert.ToDateTime("9999/01/01");
                //
                
                string couType = "";
                if (cboCouponType.Text.Trim().ToLower() == "số tiền")
                    couType = "AMOUNT";
                else
                    couType = "PERCENT";

                SqlParameter[] para = new SqlParameter[10];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", "*");
                para[1] = posdb_vnmSqlDAC.newInParam("@VoucherNo", txtCouponCode.Text.Trim());
                para[2] = posdb_vnmSqlDAC.newInParam("@VoucherName",txtCouponName.Text.Trim());
                para[3] = posdb_vnmSqlDAC.newInParam("@DiscountType", couType);
                para[4] = posdb_vnmSqlDAC.newInParam("@FromIssueDate",Conversion.FirstDayTime(fDate));
                para[5] = posdb_vnmSqlDAC.newInParam("@ToExpirationDate", Conversion.LastDayTime(tDate));                
                para[6] = posdb_vnmSqlDAC.newInParam("@FromValue", fromValue);
                para[7] = posdb_vnmSqlDAC.newInParam("@ToValue", toValue);
                para[8] = posdb_vnmSqlDAC.newInParam("@Status", status);
                para[9] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptCode);

                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsVoucherStatus";
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return ds;
        }
        #endregion

        #region Event   
    
        #region event form process
        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                rows = 0;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                //
                
                dgvListItem.ColumnHeadersVisible = false;
                //
                if (cboCouponType.Items.Count > 0)
                    cboCouponType.SelectedIndex = 0;
                //
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateTo.Value = Conversion.GetLastDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateFrom.Checked = false;
                dtpDateTo.Checked = false;

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;

                colAmount.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }

        private void frmReportSale_KeyDown(object sender, KeyEventArgs e)
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
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtList = FillDataset("Coupon_Actived_Cancel_List_Report_Page_New").Tables[0];
                if (dtList.Rows.Count > 0)
                {
                    dgvListItem.AutoGenerateColumns = false;
                    dgvListItem.DataSource = dtList;
                    rows = dtList.Rows.Count;
                    if (cboRowOnPage.Items.Count > 0)
                        cboRowOnPage.SelectedIndex = 0;

                    int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                    int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                    lblPage.Text = (rows > 0) ? "1/" + pageCount.ToString() + " Trang" : "0/0 Trang";
                    lblTotalRow.Text = "Tổng: " + rows.ToString() + " dòng";
                    DoPaging();
                }
                else
                {
                    MessageBox.Show(Properties.rsfReport.Coupon, Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    dgvListItem.DataSource = null;
                }
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
                string status = "";
                if (rdbWait.Checked)
                    status = rdbWait.Text;
                else if (rdbActive.Checked)
                    status = rdbActive.Text;
                else if (rdbUsed.Checked)
                    status = rdbUsed.Text;
                else if (rdbCancel.Checked)
                    status = rdbCancel.Text; 
                DataTable Temp = FillDataset("Coupon_Actived_Cancel_List_Report_Page_New").Tables[2];
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = REPORT_TITLE.ToUpper() + " " + status.ToUpper();
                ex.StrDate = "";
                ex.Dt = Temp;
                ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.CaseEx = 3;
                ex.ExportExcels();
                //ex.ExportTableReportToExcel(Temp, this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls",null);
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
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtFromValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFromValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFromValue.Text.Trim() != "")
                {
                    txtFromValue.Text = Conversion.GetCurrency(Conversion.Replaces(txtFromValue.Text.Trim()));
                    txtFromValue.SelectionStart = txtFromValue.Text.Trim().Length;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtToValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtToValue.Text.Trim() != "")
                {
                    txtToValue.Text = Conversion.GetCurrency(Conversion.Replaces(txtToValue.Text.Trim()));
                    txtToValue.SelectionStart = txtToValue.Text.Trim().Length;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtToValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvListItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgRed = new DataGridViewCellStyle();
                    bgRed.Font = new Font(dgvListItem.Font, FontStyle.Bold);
                    bgRed.BackColor = Color.FromArgb(210, 180, 140);

                    int i = 0;
                    foreach (DataGridViewRow r in dgvListItem.Rows)
                    {
                        string name = (r.Cells[3].Value != null) ? r.Cells[3].Value.ToString().Trim() : "";
                        i++;
                        if (i % 2 == 0)
                            r.DefaultCellStyle = bgcolor;

                        if (name.ToLower() == "tổng cộng:")
                            r.DefaultCellStyle = bgRed;

                    }
                }
                dgvListItem.ColumnHeadersVisible = (dgvListItem.Rows.Count > 0);
                btnExport.Enabled = (dgvListItem.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion

        #region event Paging
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblPage.Text = "1/" + pageCount.ToString() + " Trang";
                DoPaging();
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
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = (currentPage - 1).ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
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
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = (currentPage + 1).ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = pageCount.ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboRowOnPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListItem.Rows.Count > 1)
                {
                    int rowOnPage = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                    int pageCount = rows % rowOnPage != 0 ? rows / rowOnPage + 1 : rows / rowOnPage;
                    lblPage.Text = "1/" + pageCount.ToString() + " Trang";
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void txtPageGo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnGoPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPageGo.Text.Trim() != "")
                {
                    string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                    string[] spl = page.Split('/');
                    int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                    int cur = Convert.ToInt32(txtPageGo.Text.Trim());
                    lblPage.Text = cur.ToString() + "/" + pageCount.ToString() + " Trang";
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void cboCouponType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCouponType.Text.Trim().ToLower() == "số tiền")
                {
                    lblUnit1.Text = VND_CODE;
                    lblUnit2.Text = VND_CODE;
                    txtFromValue.Text = FROMVALUE_VND;
                    txtToValue.Text = Conversion.GetCurrency(TOVALUE_VND);
                }
                else
                {
                    lblUnit1.Text = PER_CODE;
                    lblUnit2.Text = PER_CODE;
                    txtFromValue.Text = FROMVALUE_PER;
                    txtToValue.Text = Conversion.GetCurrency(TOVALUE_PER);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #endregion

        

        
        
    }
}

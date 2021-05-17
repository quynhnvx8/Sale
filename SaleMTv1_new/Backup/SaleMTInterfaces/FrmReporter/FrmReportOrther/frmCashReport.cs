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

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    /// <summary>
    /// Người tạo Luannv - 05/11/2013: Form báo cáo thu chi
    /// </summary>
    public partial class frmCashReport : Form
    {
        #region Declaration
        #region const
        private const string PER_RE = "Người chi tiền";
        private const string PER_PAY = "Người nhận tiền";
        private const string TYPE_RE = "Tên loại thu tiền";
        private const string TYPE_PAY = "Tên loại chi tiền";
        #endregion
        private const string REPORT_TITLE = "Báo cáo hàng khuyến mãi";
        private List<string> listPro = new List<string>();        
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        private int rows = 0;

        #endregion

        #region Contructor
        public frmCashReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmCashReport.groupBox2.Text"];
            this.chkPayment.Text = translate["frmCashReport.chkPayment.Text"];
            this.chkReceipt.Text = translate["frmCashReport.chkReceipt.Text"];
            this.label3.Text = translate["frmCashReport.label3.Text"];
            this.label6.Text = translate["frmCashReport.label6.Text"];
            this.btnSearch.Text = translate["frmCashReport.btnSearch.Text"];
            this.btnExit.Text = translate["frmCashReport.btnExit.Text"];
            this.btnExport.Text = translate["frmCashReport.btnExport.Text"];
            this.groupBox4.Text = translate["frmCashReport.groupBox4.Text"];
            this.btnGoPage.Text = translate["frmCashReport.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmCashReport.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmCashReport.lblPage.Text"];
            this.label2.Text = translate["frmCashReport.label2.Text"];
            this.Column2.HeaderText = translate["frmCashReport.Column2.HeaderText"];
            this.Column1.HeaderText = translate["frmCashReport.Column1.HeaderText"];
            this.Column3.HeaderText = translate["frmCashReport.Column3.HeaderText"];
            this.clnCashPerson.HeaderText = translate["frmCashReport.clnCashPerson.HeaderText"];
            this.clnMasterName.HeaderText = translate["frmCashReport.clnMasterName.HeaderText"];
            this.colAmount.HeaderText = translate["frmCashReport.colAmount.HeaderText"];
            this.Column6.HeaderText = translate["frmCashReport.Column6.HeaderText"];
            this.Column10.HeaderText = translate["frmCashReport.Column10.HeaderText"];
            this.colTotal.HeaderText = translate["frmCashReport.colTotal.HeaderText"];
            this.Column5.HeaderText = translate["frmCashReport.Column5.HeaderText"];
            this.Column11.HeaderText = translate["frmCashReport.Column11.HeaderText"];
            this.Text = translate["frmCashReport.Text"];

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
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN","*");
                para[1] = posdb_vnmSqlDAC.newInParam("@DeptCode",UserImformation.DeptNumber.ToString());
                para[2] = posdb_vnmSqlDAC.newInParam("@DateFrom", dtpDateFrom.Value.ToString("yyyy/MM/dd") + " 00:00:00");
                para[3] = posdb_vnmSqlDAC.newInParam("@DateTo", dtpDateTo.Value.ToString("yyyy/MM/dd") + " 23:59:59");

                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "ds";               
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return ds;
        }
        #endregion

        #region Event       

        #region form process
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
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dgvListItem.ColumnHeadersVisible = false;

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;

                colAmount.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotal.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
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
                if (!chkReceipt.Checked && !chkPayment.Checked)
                {
                    MessageBox.Show(Properties.rsfReport.CashReport, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    string store = (chkReceipt.Checked) ? "CashReceipt_Search_Page" : "CashPayment_Search_Page_New";
                    DataTable dtList = FillDataset(store).Tables[0];
                    dgvListItem.AutoGenerateColumns = false;
                    dgvListItem.DataSource = dtList;

                    clnCashPerson.HeaderText = (chkReceipt.Checked) ? PER_RE : PER_PAY;
                    clnMasterName.HeaderText = (chkReceipt.Checked) ? TYPE_RE : TYPE_PAY;

                    rows = dtList.Rows.Count;
                    if (cboRowOnPage.Items.Count > 0)
                        cboRowOnPage.SelectedIndex = 0;

                    int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                    int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                    lblPage.Text = (rows > 0) ? "1/" + pageCount.ToString() + " Trang" : "0/0 Trang";
                    lblTotalRow.Text = "Tổng: " + rows.ToString() + " dòng";
                    DoPaging();
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
                string tit = (chkReceipt.Checked) ? chkReceipt.Text : chkPayment.Text;
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = tit.ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                ex.Dgv = dgvListItem;
                ex.FileNames = tit + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.CaseEx = 4;
                ex.ArrSum = null;
                ex.ExportExcels();
                //ex.ExportGridReportToExcel(dgvListItem, tit + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls", 0);
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
        private void dgvListItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void chkReceipt_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkReceipt.Checked)
                {
                    chkPayment.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkPayment.Checked)
                {
                    chkReceipt.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
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
        #region Paging
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
        #endregion
        #endregion
    }
}

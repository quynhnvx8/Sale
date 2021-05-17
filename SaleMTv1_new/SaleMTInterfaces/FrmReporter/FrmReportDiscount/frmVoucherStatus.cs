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
    /// Người tạo Luannv - 05/11/2013: Form báo cáo tình trạng phiếu tặng
    /// </summary>
    public partial class frmVoucherStatus : Form
    {
        #region Declaration
        private const string REPORT_TITLE = "BÁO CÁO DANH SÁCH PHIẾU QUÀ TẶNG";
        private const string WAIT_CODE = "WAITING";
        private const string ACTIVE_CODE = "ACTIVED";
        private const string USE_CODE = "USED";
        private const string CAN_CODE = "CANCEL";
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        private int rows = 0;
        #endregion

        #region Contructor
        public frmVoucherStatus(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmVoucherStatus.groupBox2.Text"];
            this.label3.Text = translate["frmVoucherStatus.label3.Text"];
            this.label6.Text = translate["frmVoucherStatus.label6.Text"];
            this.btnSearch.Text = translate["frmVoucherStatus.btnSearch.Text"];
            this.btnExit.Text = translate["frmVoucherStatus.btnExit.Text"];
            this.btnExport.Text = translate["frmVoucherStatus.btnExport.Text"];
            this.groupBox4.Text = translate["frmVoucherStatus.groupBox4.Text"];
            this.btnGoPage.Text = translate["frmVoucherStatus.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmVoucherStatus.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmVoucherStatus.lblPage.Text"];
            this.label2.Text = translate["frmVoucherStatus.label2.Text"];
            this.Column2.HeaderText = translate["frmVoucherStatus.Column2.HeaderText"];
            this.Column1.HeaderText = translate["frmVoucherStatus.Column1.HeaderText"];
            this.colItem_de.HeaderText = translate["frmVoucherStatus.colItem_de.HeaderText"];
            this.colItem_real.HeaderText = translate["frmVoucherStatus.colItem_real.HeaderText"];
            this.colBalance.HeaderText = translate["frmVoucherStatus.colBalance.HeaderText"];
            this.Column6.HeaderText = translate["frmVoucherStatus.Column6.HeaderText"];
            this.Column10.HeaderText = translate["frmVoucherStatus.Column10.HeaderText"];
            this.Column5.HeaderText = translate["frmVoucherStatus.Column5.HeaderText"];
            this.Text = translate["frmVoucherStatus.Text"];

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
                string status = USE_CODE;
                //if (rdbWait.Checked)
                //    status = WAIT_CODE;
                //else if (rdbActive.Checked)
                //    status = ACTIVE_CODE;
                //else if (rdbUsed.Checked)
                //    status = USE_CODE;
                //else if (rdbCancel.Checked)
                //    status = CAN_CODE; 
                //
                float fromValue = -1;
                float toValue = -1;
                float fromBalan = -1;
                float toBalan = -1;
                //if (txtFromDeno.Text.Trim() != "")
                //    fromValue = (float)Convert.ToDouble(Conversion.Replaces(txtFromDeno.Text.Trim()));
                //if(txtToDeno.Text.Trim()!="")
                //    toValue = (float)Convert.ToDouble(Conversion.Replaces(txtToDeno.Text.Trim()));
                //if (txtFromBalance.Text.Trim() != "")
                //    fromBalan = (float)Convert.ToDouble(Conversion.Replaces(txtFromBalance.Text.Trim()));
                //if (txtToBalance.Text.Trim() != "")
                //    toBalan = (float)Convert.ToDouble(Conversion.Replaces(txtToBalance.Text.Trim()));
                    
                SqlParameter[] para = new SqlParameter[9];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", "*");
                para[1] = posdb_vnmSqlDAC.newInParam("@StoreCode","");                
                para[2] = posdb_vnmSqlDAC.newInParam("@FromDate", Conversion.FirstDayTime(dtpDateFrom.Value));
                para[3] = posdb_vnmSqlDAC.newInParam("@ToDate", Conversion.LastDayTime(dtpDateTo.Value));
                para[4] = posdb_vnmSqlDAC.newInParam("@Status", status);
                para[5] = posdb_vnmSqlDAC.newInParam("@FromValue", fromValue);
                para[6] = posdb_vnmSqlDAC.newInParam("@ToValue", toValue);
                para[7] = posdb_vnmSqlDAC.newInParam("@FromBalance", fromBalan);
                para[8] = posdb_vnmSqlDAC.newInParam("@ToBalance", toBalan);

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
        #region Event form process
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
                dtpDateTo.Value = Conversion.GetLastDayOfMonth(sqlDac.GetDateTimeServer());
                dgvListItem.ColumnHeadersVisible = false;

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;

                colBalance.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colItem_de.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colItem_real.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
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

                DataTable dtList = FillDataset("Voucher_Gift_report_page").Tables[0];
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
                    MessageBox.Show(Properties.rsfReport.Voucher, Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
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
                string status = USE_CODE;
                //if (rdbWait.Checked)
                //    status = rdbWait.Text;
                //else if (rdbActive.Checked)
                //    status = rdbActive.Text;
                //else if (rdbUsed.Checked)
                //    status = rdbUsed.Text;
                //else if (rdbCancel.Checked)
                //    status = rdbCancel.Text; 
                DataTable Temp = FillDataset("Voucher_Gift_report_page").Tables[2];
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = REPORT_TITLE.ToUpper() + " " + status.ToUpper();
                ex.StrDate = "NGÀY BÁO CÁO: " + sqlDac.GetDateTimeServer().ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
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
        #region Event Paging
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
        #region event xử lý nhập giá trị mệnh giá và số dư
        //private void txtFromDeno_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtFromDeno.Text.Trim() != "")
        //        {
        //            txtFromDeno.Text = Conversion.GetCurrency(Conversion.Replaces(txtFromDeno.Text.Trim()));
        //            txtFromDeno.SelectionStart = txtFromDeno.Text.Trim().Length;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}
        //private void txtFromDeno_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtToDeno_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtToDeno_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtToDeno.Text.Trim() != "")
        //        {
        //            txtToDeno.Text = Conversion.GetCurrency(Conversion.Replaces(txtToDeno.Text.Trim()));
        //            txtToDeno.SelectionStart = txtToDeno.Text.Trim().Length;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtFromBalance_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtFromBalance.Text.Trim() != "")
        //        {
        //            txtFromBalance.Text = Conversion.GetCurrency(Conversion.Replaces(txtFromBalance.Text.Trim()));
        //            txtFromBalance.SelectionStart = txtFromBalance.Text.Trim().Length;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtFromBalance_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtToBalance_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}

        //private void txtToBalance_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtToBalance.Text.Trim() != "")
        //        {
        //            txtToBalance.Text = Conversion.GetCurrency(Conversion.Replaces(txtToBalance.Text.Trim()));
        //            txtToBalance.SelectionStart = txtToBalance.Text.Trim().Length;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error : " + ex.Message);
        //    }
        //}
        #endregion
        

        #endregion
        
    }
}

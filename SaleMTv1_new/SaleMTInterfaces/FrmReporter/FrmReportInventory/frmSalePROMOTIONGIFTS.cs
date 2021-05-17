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
    /// Người tạo Luannv - 05/11/2013: Form báo cáo hàng khuyến mại
    /// </summary>
    public partial class frmSalePromotionGifts : Form
    {
        #region Declaration
        private const string REPORT_TITLE = "Báo cáo hàng khuyến mãi";
        private List<string> listPro = new List<string>();        
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        private int rows = 0;
        #endregion

        #region Contructor
        public frmSalePromotionGifts(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmSalePromotionGifts.groupBox2.Text"];
            this.label1.Text = translate["frmSalePromotionGifts.label1.Text"];
            this.label3.Text = translate["frmSalePromotionGifts.label3.Text"];
            this.label5.Text = translate["frmSalePromotionGifts.label5.Text"];
            this.label6.Text = translate["frmSalePromotionGifts.label6.Text"];
            this.btnSearch.Text = translate["frmSalePromotionGifts.btnSearch.Text"];
            this.btnExit.Text = translate["frmSalePromotionGifts.btnExit.Text"];
            this.btnExport.Text = translate["frmSalePromotionGifts.btnExport.Text"];
            this.btnPrint.Text = translate["frmSalePromotionGifts.btnPrint.Text"];
            this.groupBox4.Text = translate["frmSalePromotionGifts.groupBox4.Text"];
            this.Column2.HeaderText = translate["frmSalePromotionGifts.Column2.HeaderText"];
            this.Column1.HeaderText = translate["frmSalePromotionGifts.Column1.HeaderText"];
            this.Column3.HeaderText = translate["frmSalePromotionGifts.Column3.HeaderText"];
            this.Column4.HeaderText = translate["frmSalePromotionGifts.Column4.HeaderText"];
            this.Column9.HeaderText = translate["frmSalePromotionGifts.Column9.HeaderText"];
            this.Column7.HeaderText = translate["frmSalePromotionGifts.Column7.HeaderText"];
            this.Column8.HeaderText = translate["frmSalePromotionGifts.Column8.HeaderText"];
            this.Column6.HeaderText = translate["frmSalePromotionGifts.Column6.HeaderText"];
            this.Column10.HeaderText = translate["frmSalePromotionGifts.Column10.HeaderText"];
            this.Column5.HeaderText = translate["frmSalePromotionGifts.Column5.HeaderText"];
            this.btnGoPage.Text = translate["frmSalePromotionGifts.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmSalePromotionGifts.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmSalePromotionGifts.lblPage.Text"];
            this.label2.Text = translate["frmSalePromotionGifts.label2.Text"];
            this.Text = translate["frmSalePromotionGifts.Text"];

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
                gridTable.DefaultView.RowFilter = "(STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString() + ") or (STT = 1 or STT = " + rows.ToString() + ")";

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

        private DataSet FillDataset(string store,int status)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] para = new SqlParameter[6];
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCodeList", UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@Product", txtListProduct.Text.Trim());
                para[2] = posdb_vnmSqlDAC.newInParam("@SaleCode", txtCodeInvoice.Text.Trim());
                para[3] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFrom.Value.ToString("yyyy/MM/dd") + " 00:00:00");
                para[4] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateTo.Value.ToString("yyyy/MM/dd") + " 23:59:59");
                para[5] = posdb_vnmSqlDAC.newInParam("@Status", status);

                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsSALE_PROMOTION_GIFTS";
                ds.Tables[0].TableName = "table_SALE_PROMOTION_GIFTS";
                // 
                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                //add thêm bảng date
                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));
                dtDate.Columns.Add("CuaHangTruong", typeof(string));
                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["ToDate"] = dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["CuaHangTruong"] = "";
                dtDate.Rows.Add(drDate);
                
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
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dgvListItem.ColumnHeadersVisible = false;

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;
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
                DataTable dtList = FillDataset("sp_SALE_PROMOTION_GIFTS_New", 0).Tables[0];
                if (dtList.Rows.Count == 2)
                {
                    lblTotalRow.Text = " Tổng: 0 dòng";
                    lblPage.Text = "Trang: 0/0 trang";
                }
                if (dtList.Rows.Count > 2)
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
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC(StoreName, Path);
                frm.ds = FillDataset("sp_SALE_PROMOTION_GIFTS_New",1);
                frm.IsMdiContainer = true;
                frm.ShowDialog();
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
                DataTable Temp = FillDataset("sp_SALE_PROMOTION_GIFTS_New", 1).Tables[2];
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = REPORT_TITLE.ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                int[] colSum = { 3, 6, 8 };
                ex.Dt = Temp;
                ex.CaseEx = 3;
                ex.ArrSum = colSum;
                ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.ExportExcels();
                //ex.ExportTableReportToExcel(Temp, this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls",colSum);
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn = SOManagement.ShowChoseProduct(translate);
                txtListProduct.Text = soEn.ListProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                txtListProduct.Text = "";
                listPro.Clear();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    CheckInventoryEntities inventEn = CheckInventory.ShowProductSearch(txtProduct.Text.Trim(), translate);
                    if (inventEn != null)
                    {
                        int check = listPro.FindIndex(s => s == inventEn.ProductID);
                        if (check == -1)
                        {
                            listPro.Add(inventEn.ProductID);
                            string listCode = (txtListProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                            txtListProduct.Text = txtListProduct.Text.Trim() + listCode;
                        }
                    }
                    txtProduct.Text = "";
                    txtProduct.Focus();
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

        #region event paging
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

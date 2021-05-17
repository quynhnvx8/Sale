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
    /// Người tạo Luannv - 05/11/2013: Form báo cáo hàng xuất nhập tồn
    /// </summary>
    public partial class frmEntryInventoryProductReportSale : Form
    {
        #region Declaration
        private const string REPORT_TITLE = "Báo cáo xuất nhập tồn";
        private List<string> listPro = new List<string>();        
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        #endregion

        #region Contructor
        public frmEntryInventoryProductReportSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox2.Text = translate["frmEntryInventoryProductReportSale.groupBox2.Text"];
            this.label3.Text = translate["frmEntryInventoryProductReportSale.label3.Text"];
            this.label5.Text = translate["frmEntryInventoryProductReportSale.label5.Text"];
            this.label6.Text = translate["frmEntryInventoryProductReportSale.label6.Text"];
            this.btnSearch.Text = translate["frmEntryInventoryProductReportSale.btnSearch.Text"];
            this.btnExit.Text = translate["frmEntryInventoryProductReportSale.btnExit.Text"];
            this.btnExport.Text = translate["frmEntryInventoryProductReportSale.btnExport.Text"];
            this.btnPrint.Text = translate["frmEntryInventoryProductReportSale.btnPrint.Text"];
            this.groupBox4.Text = translate["frmEntryInventoryProductReportSale.groupBox4.Text"];
            this.Column1.HeaderText = translate["frmEntryInventoryProductReportSale.Column1.HeaderText"];
            this.Column3.HeaderText = translate["frmEntryInventoryProductReportSale.Column3.HeaderText"];
            this.Column4.HeaderText = translate["frmEntryInventoryProductReportSale.Column4.HeaderText"];
            this.Column5.HeaderText = translate["frmEntryInventoryProductReportSale.Column5.HeaderText"];
            this.colDK.HeaderText = translate["frmEntryInventoryProductReportSale.colDK.HeaderText"];
            this.colPriceDK.HeaderText = translate["frmEntryInventoryProductReportSale.colPriceDK.HeaderText"];
            this.colTotalDK.HeaderText = translate["frmEntryInventoryProductReportSale.colTotalDK.HeaderText"];
            this.colImTotal.HeaderText = translate["frmEntryInventoryProductReportSale.colImTotal.HeaderText"];
            this.colSumImPro.HeaderText = translate["frmEntryInventoryProductReportSale.colSumImPro.HeaderText"];
            this.colToTalIm.HeaderText = translate["frmEntryInventoryProductReportSale.colToTalIm.HeaderText"];
            this.colQuanDC.HeaderText = translate["frmEntryInventoryProductReportSale.colQuanDC.HeaderText"];
            this.colMoneyDC.HeaderText = translate["frmEntryInventoryProductReportSale.colMoneyDC.HeaderText"];
            this.colTotalEx.HeaderText = translate["frmEntryInventoryProductReportSale.colTotalEx.HeaderText"];
            this.colExPro.HeaderText = translate["frmEntryInventoryProductReportSale.colExPro.HeaderText"];
            this.colTotalExPro.HeaderText = translate["frmEntryInventoryProductReportSale.colTotalExPro.HeaderText"];
            this.colPromotionPro.HeaderText = translate["frmEntryInventoryProductReportSale.colPromotionPro.HeaderText"];
            this.colPromotion.HeaderText = translate["frmEntryInventoryProductReportSale.colPromotion.HeaderText"];
            this.colQuanExDC.HeaderText = translate["frmEntryInventoryProductReportSale.colQuanExDC.HeaderText"];
            this.colTotalExDC.HeaderText = translate["frmEntryInventoryProductReportSale.colTotalExDC.HeaderText"];
            this.colTotalEnd.HeaderText = translate["frmEntryInventoryProductReportSale.colTotalEnd.HeaderText"];
            this.colEndPice.HeaderText = translate["frmEntryInventoryProductReportSale.colEndPice.HeaderText"];
            this.colSumTotalEnd.HeaderText = translate["frmEntryInventoryProductReportSale.colSumTotalEnd.HeaderText"];
            this.Text = translate["frmEntryInventoryProductReportSale.Text"];

        }
        #endregion

        #region Method
        
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
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCodeList", UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@Product", txtListProduct.Text.Trim());
                para[2] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFrom.Value.ToString("yyyy/MM/dd") + " 00:00:00");
                para[3] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateTo.Value.ToString("yyyy/MM/dd") + " 23:59:59");

                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsEntryInventoryProduct_Sale";
                ds.Tables[0].TableName = "table_NXT";
                ds.Tables[0].DefaultView.Sort = "Nhom,CAT";
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
                drDate["CuaHangTruong"] = DefaultCustomer.PersonPtrint;
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

        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dgvListItem.ColumnHeadersVisible = false;

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;

                colDK.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colEndPice.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colExPro.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colImTotal.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colMoneyDC.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colPriceDK.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colPromotion.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colPromotionPro.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colQuanDC.DefaultCellStyle.Format = AppConfigFileSettings.strOptNumber;
                colQuanExDC.DefaultCellStyle.Format = AppConfigFileSettings.strOptNumber;
                //colQuanReturn.DefaultCellStyle.Format = AppConfigFileSettings.strOptNumber;
                colSumImPro.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colSumTotalEnd.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotalDK.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotalEnd.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotalEx.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotalExDC.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colTotalExPro.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colToTalIm.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
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
                dgvListItem.AutoGenerateColumns = false;
                dgvListItem.DataSource = FillDataset("rptReport_EntryInventoryProduct_Sale_New_ChangePrice").Tables[0];
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
                frm.ds = FillDataset("sp_EntryInventoryProduct_Sale_New_ChangePrice");
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
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = REPORT_TITLE.ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                int[] colSum = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
                ex.Dgv = dgvListItem;
                ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.CaseEx = 2;
                ex.ExportExcels();
                //Export ex = new Export();
                //ex.InfoCompany = true;
                //ex.InfoStore = true;
                //ex.StrTitle = REPORT_TITLE.ToUpper();
                //ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);

                //ex.ExportInventoryToExcel(dgvListItem, this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls");
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
                            string listCode = (txtProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                            txtListProduct.Text = txtListProduct.Text.Trim() + listCode;
                        }
                        txtProduct.Text = "";
                        txtProduct.Focus();
                    }
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
                    //Hiệp thêm: Bỏ sort tự động
                    foreach (DataGridViewColumn col in dgvListItem.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    int i = 0;
                    foreach (DataGridViewRow r in dgvListItem.Rows)
                    {
                        string name = (r.Cells[3].Value != null) ? r.Cells[3].Value.ToString().Trim() : "";
                        i++;
                        if (i % 2 == 0)
                            r.DefaultCellStyle = bgcolor;

                        if (name == "Tổng cộng:")
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

        private void dgvListItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

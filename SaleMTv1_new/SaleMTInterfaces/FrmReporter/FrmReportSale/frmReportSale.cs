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
using SaleMTInterfaces.FrmInventoryManagement;
using SaleMTBusiness.InventoryManagement;


namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmReportSale : Form
    {

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int rows;
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<string> listPro = new List<string>();
        private string StoreName, Path, CATEGORY, LIST_COLUMN, LIST_COLUMN_NO_QUANTITY;
        private const string REP_CODE = "||Segment01";
        
        
        #endregion

        #region  Constructor
       
        public frmReportSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            cboRows.Text = "20";
        }
        static public Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnSeach.Text = translate["frmReportSale.btnSeach.Text"];
            this.btnExport.Text = translate["frmReportSale.btnExport.Text"];
            this.btnExit.Text = translate["frmReportSale.btnExit.Text"];
            this.label5.Text = translate["frmReportSale.label5.Text"];
            this.label4.Text = translate["frmReportSale.label4.Text"];
            this.label3.Text = translate["frmReportSale.label3.Text"];
            this.label2.Text = translate["frmReportSale.label2.Text"];
            this.label1.Text = translate["frmReportSale.label1.Text"];
            this.groupBox2.Text = translate["frmReportSale.groupBox2.Text"];
            this.Column1.HeaderText = translate["frmReportSale.Column1.HeaderText"];
            this.Column2.HeaderText = translate["frmReportSale.Column2.HeaderText"];
            this.Column3.HeaderText = translate["frmReportSale.Column3.HeaderText"];
            this.CAT.HeaderText = translate["frmReportSale.CAT.HeaderText"];
            this.Column5.HeaderText = translate["frmReportSale.Column5.HeaderText"];
            this.Column6.HeaderText = translate["frmReportSale.Column6.HeaderText"];
            this.Column7.HeaderText = translate["frmReportSale.Column7.HeaderText"];
            this.Column8.HeaderText = translate["frmReportSale.Column8.HeaderText"];
            this.Column9.HeaderText = translate["frmReportSale.Column9.HeaderText"];
            this.Column10.HeaderText = translate["frmReportSale.Column10.HeaderText"];
            this.Column11.HeaderText = translate["frmReportSale.Column11.HeaderText"];
            this.Column12.HeaderText = translate["frmReportSale.Column12.HeaderText"];
            this.Column13.HeaderText = translate["frmReportSale.Column13.HeaderText"];
            this.Column14.HeaderText = translate["frmReportSale.Column14.HeaderText"];
            this.Column15.HeaderText = translate["frmReportSale.Column15.HeaderText"];
            this.Column16.HeaderText = translate["frmReportSale.Column16.HeaderText"];
            this.Column17.HeaderText = translate["frmReportSale.Column17.HeaderText"];
            this.Column18.HeaderText = translate["frmReportSale.Column18.HeaderText"];
            this.Column19.HeaderText = translate["frmReportSale.Column19.HeaderText"];
            this.lblPage.Text = translate["frmReportSale.lblPage.Text"];
            this.lblScount.Text = translate["frmReportSale.lblScount.Text"];
            this.btnChoosePage.Text = translate["frmReportSale.btnChoosePage.Text"];
            this.btnPrint.Text = translate["frmReportSale.btnPrint.Text"];
            this.Text = translate["frmReportSale.Text"];

        }
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

        private DataSet FillDataset()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] para = new SqlParameter[14];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN_NO_QUANTITY", LIST_COLUMN_NO_QUANTITY);
                para[1] = posdb_vnmSqlDAC.newInParam("@Product", txtProduct.Text.Trim());
                para[2] = posdb_vnmSqlDAC.newInParam("@CreateFrom", Conversion.FirstDayTime(dtpdateFrom.Value));
                para[3] = posdb_vnmSqlDAC.newInParam("@CreateTo",Conversion.LastDayTime(dtpdateTo.Value));
                para[4] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", "");
                para[5] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", "");
                para[6] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", "");
                para[7] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", "");
                para[8] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", "");
                para[9] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[10] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", ","+UserImformation.StoreCode);
                para[11] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", "," + UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode);
                para[12] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", LIST_COLUMN);
                para[13] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", cboPersonRec.Text.ToString());
                ds = sqlDac.GetDataSet("Sales_Report_Pages_Report", para);
                

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


                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(Properties.rsfReport.Coupon,Properties.rsfSales.Notice , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvList.DataSource = null;
                }

                rows = ds.Tables[0].Rows.Count;
                lblScount.Text = "Tổng: " + rows.ToString() + " dòng";
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
                DataTable gridTable = (DataTable)dgvList.DataSource;
                gridTable.DefaultView.RowFilter = "(STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString() + ") or (STT = 0 or STT = " + (rows+1).ToString() + ")";

                //if (pageCount > 1)
                //{
                //    btnEndPage.Enabled = true;
                //    btnNext.Enabled = true;
                //    btnPrev.Enabled = true;
                //    btnTopPage.Enabled = true;
                //    btnChoosePage.Enabled = true;
                //    return;
                //}

                //tnChoosePage.Enabled = true;
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
                if (dgvList.Rows.Count > 0)
                {
                    dgvList.Rows[0].Cells[0].Selected = true;
                    btnExport.Enabled = true;
                    btnChoosePage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'DoPaing' : " + ex.Message);
            }
        }

        private void addPersonReceipt(int dept)
        {
            try
            {
                string proc = "USER_DEPT_Read1";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", dept);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                cboPersonRec.DataSource = dt;
                cboPersonRec.DisplayMember = "ACCOUNT";
                cboPersonRec.ValueMember = "DEPT_CODE";
                //cboPersonRec.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        private void ExportExcel()
        {
            try
            {
                if (dgvList.Rows.Count > 0)
                {
                    DataTable dtTemp = FillDataset().Tables[3];
                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = this.Text.ToUpper();
                    exN.Dt = dtTemp;
                    exN.CaseEx = 3;
                    exN.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    int[] col = { 3,8,10,11,12 };
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

        #region event form process
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
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        private void frmReportSale_Load(object sender, EventArgs e)
        {

            try
            {                
                LIST_COLUMN_NO_QUANTITY = "EXPORT_CODE,CUSTOMER_ID,CUSTOMER_NAME,CAT,PRODUCT_ID,PRODUCT_NAME,UNIT_NAME,EXPORT_DATE,QUANTITY,PRICE_SALES,AMOUNT,PROMOTION,TOTAL_AMOUNT,REMARK,EMPLOYEE_ID,EMPLOYEE_NAME,DEPT_NAME,STORE_TYPE,PRODUCT_GROUP";
                LIST_COLUMN = "EXPORT_CODE,CUSTOMER_ID,CUSTOMER_NAME,CAT,PRODUCT_ID,PRODUCT_NAME,UNIT_NAME,EXPORT_DATE,QUANTITY,PRICE_SALES,AMOUNT,PROMOTION,TOTAL_AMOUNT,REMARK,EMPLOYEE_ID,EMPLOYEE_NAME,DEPT_NAME,STORE_TYPE,PRODUCT_GROUP";
               

                addPersonReceipt(UserImformation.DeptNumber);
                
                btnChoosePage.Enabled = false;
                btnEndPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnTopPage.Enabled = false;
                btnExport.Enabled = false;
                dtpdateFrom.Value = sqlDac.GetDateTimeServer();
                dtpdateTo.Value = sqlDac.GetDateTimeServer();
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
                DataSet ds = FillDataset();
                rows = ds.Tables[0].Rows.Count;
                lblScount.Text = "Tổng: " + rows.ToString() + " dòng";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].NewRow();
                    r["STT"] = 0;
                    r["CAT"] = "Tổng cộng:";
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
                    rnew["CAT"] = "Tổng cộng:";
                    rnew["QUANTITY"] = ds.Tables[2].Rows[0]["QUANTITY"];
                    rnew["AMOUNT"] = ds.Tables[2].Rows[0]["AMOUNT"];
                    rnew["DISCOUNT"] = ds.Tables[2].Rows[0]["DISCOUNT"];
                    rnew["REBATE"] = ds.Tables[2].Rows[0]["REBATE"];
                    rnew["REBATE_BY_CUSTOMER_CARD"] = ds.Tables[2].Rows[0]["REBATE_BY_CUSTOMER_CARD"];
                    rnew["PROMOTION"] = ds.Tables[2].Rows[0]["PROMOTION"];
                    rnew["TOTAL_AMOUNT"] = ds.Tables[2].Rows[0]["TOTAL_AMOUNT"];
                    ds.Tables[0].Rows.Add(rnew);

                }
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = ds.Tables[0];

                DoPaning();
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchEvent' : " + ex.Message);
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
                log.Error("Error 'btnProduct_click' : " + ex.Message);
            }
        }     

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvList_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
            {
                //dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                bgcolor1.Font = new Font(dgvList.Font, FontStyle.Bold);

                foreach (DataGridViewColumn col in dgvList.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                int i = 0;
                
                foreach (DataGridViewRow r in dgvList.Rows)
                {
                    if (r.Cells[3].Value != null)
                    {
                        string name = r.Cells["CAT"].Value.ToString().Trim();
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
            dgvList.ColumnHeadersVisible = (dgvList.Rows.Count > 0);
            btnExport.Enabled = (dgvList.Rows.Count > 0);
        }        

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnproductattributes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReportSale.frmProductReportSearch frm = new frmProductReportSearch(translate);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                frm.Close();
                txtproductattributes.Text = frm.listProGroup.ToString();
                LIST_COLUMN_NO_QUANTITY = frm.ListResionTag.ToString();
                CATEGORY = frm.listProGroupTag.ToString().Replace(REP_CODE,"");
            }
            catch (Exception ex)
            {
                log.Error("Error '' : " + ex.Message);
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
                log.Error("Error: " + ex.Message);
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
                //loadInforPro();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
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
                if (dgvList.Rows.Count > 1)
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
        private void lblCurrentPage_Click(object sender, EventArgs e)
        {

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
        #endregion


        #endregion       

    }
}

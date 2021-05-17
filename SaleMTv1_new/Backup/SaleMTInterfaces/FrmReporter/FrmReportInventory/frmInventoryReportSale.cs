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
    public partial class frmInventoryReportSale : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private const string RE_TITLE = "BÁO CÁO TỒN KHO CỬA HÀNG";
        private const string REP_CODE = "||Segment01";
        private List<string> listPro = new List<string>();
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();
        DataSet ds = new DataSet();
        public string StoreName, Path, dateFrom, dateTo;
        //string DeptCode;//Mã cửa hàng
        //string ACCOUNT;//Tên đăng nhập
        string LIST_COLUMN_NO_QUANTITY, Product;//, CreateTo, 
        string CHAIN_CODE, LIST_STORE_CODE, LIST_COLOR, LIST_SIZE;
        string LIST_TRADEMARK, LIST_MANUFACTURE, LIST_ATTRIBUTE, CATEGORY, LIST_COLUMN;
        Boolean IsUsingOldProductCode;
        int PageSize, PageIndex;
        #endregion

        #region Contructor

        public frmInventoryReportSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label4.Text = translate["frmInventoryReportSale.label4.Text"];
            this.label3.Text = translate["frmInventoryReportSale.label3.Text"];
            this.label1.Text = translate["frmInventoryReportSale.label1.Text"];
            this.btnSeach.Text = translate["frmInventoryReportSale.btnSeach.Text"];
            this.btnExport.Text = translate["frmInventoryReportSale.btnExport.Text"];
            this.btnExit.Text = translate["frmInventoryReportSale.btnExit.Text"];
            this.Text = translate["frmInventoryReportSale.Text"];

        }


        #endregion
        
        #region Method
        private void ImportPara()
         {
             try
             {
                 LIST_COLUMN_NO_QUANTITY = "CAT,PRODUCT_ID,PRODUCT_NAME,SLQD,CONV_FACT,PRODUCT_PRICE,TOTALMONEY,UNIT1,UNIT,DEPT_NAME,STORE_TYPE,PRODUCT_GROUP";
                 Product = txtProduct.Text;
                 dateFrom = Conversion.LastDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss");
                 CHAIN_CODE = "," + UserImformation.StoreCode;///lấy theo user đăng nhập
                 LIST_STORE_CODE = "," + UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;//Lấy theo User đăng nhập
                 LIST_COLOR = "";
                 LIST_SIZE = "";
                 LIST_TRADEMARK = "";
                 LIST_MANUFACTURE = "";
                 LIST_ATTRIBUTE = "";                 
                 LIST_COLUMN = "CAT,PRODUCT_ID,PRODUCT_NAME,SUM(QUANTITY) AS QUANTITY,SLQD,CONV_FACT,PRODUCT_PRICE,TOTALMONEY,UNIT1,UNIT,DEPT_NAME,STORE_TYPE,PRODUCT_GROUP";
                IsUsingOldProductCode = false ;
                PageSize = 30;
                PageIndex = 1;
                 
             }
             catch (Exception ex)
             {
                 log.Error("Error: " + ex.Message);
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
        private DataTable dtColInfo;
        private DataSet dsGridVew;
        private void FillDataset(string store)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[15];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN_NO_QUANTITY", LIST_COLUMN_NO_QUANTITY);
                para[1] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                para[2] = posdb_vnmSqlDAC.newInParam("@CreateTo", dateFrom );
                para[3] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", CHAIN_CODE);
                para[4] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", LIST_STORE_CODE);
                para[5] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", LIST_COLOR);
                para[6] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", LIST_SIZE);
                para[7] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", LIST_TRADEMARK);
                para[8] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", LIST_MANUFACTURE);
                para[9] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", LIST_ATTRIBUTE);
                para[10] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[11] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", LIST_COLUMN);
                para[12] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", IsUsingOldProductCode);
                para[13] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                para[14] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);
                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsImportProductsInventoryImport";
                ds.Tables[0].TableName = "Inventory";
                //add thêm bảng date
                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("Date", typeof(string));
                dtDate.Columns.Add("UserPrint", typeof(string));
                dtDate.Columns.Add("StoreAdmin", typeof(string));
                DataRow drDate = dtDate.NewRow();
                drDate["Date"] = dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["UserPrint"] = DefaultCustomer.PersonPtrint;
                drDate["StoreAdmin"] = DefaultCustomer.PersonPtrint;
                dtDate.Rows.Add(drDate);
                // info store
                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                // logo
                DataTable dtLogo = ds.Tables.Add("StoreLogo");
                Print.AddUserInfo(dtLogo);

                SqlParameter[] paraInf = new SqlParameter[1];
                paraInf[0] = posdb_vnmSqlDAC.newInParam("@table", "Inventory_Store_GridView_VIT");
                dtColInfo = sqlDac.GetDataTable("getGridConfig", paraInf);


                SqlParameter[] paraGridView = new SqlParameter[15];
                paraGridView[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN_NO_QUANTITY", LIST_COLUMN_NO_QUANTITY);
                paraGridView[1] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                paraGridView[2] = posdb_vnmSqlDAC.newInParam("@CreateTo", dateFrom);
                paraGridView[3] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", CHAIN_CODE);
                paraGridView[4] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", LIST_STORE_CODE);
                paraGridView[5] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", LIST_COLOR);
                paraGridView[6] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", LIST_SIZE);
                paraGridView[7] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", LIST_TRADEMARK);
                paraGridView[8] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", LIST_MANUFACTURE);
                paraGridView[9] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", LIST_ATTRIBUTE);
                paraGridView[10] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                paraGridView[11] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", LIST_COLUMN);
                paraGridView[12] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", IsUsingOldProductCode);
                paraGridView[13] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                paraGridView[14] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);
                dsGridVew = sqlDac.GetDataSet("Inventory_Store_GridView_VTIT", paraGridView);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void btnSeach_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                ImportPara();
                FillDataset("rptReport_Inventory_Store_Report_Page");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridPageView1.dtTotal = dsGridVew.Tables[3];
                    gridPageView1.dtColInfo = dtColInfo;
                    gridPageView1.dtSource = dsGridVew.Tables[0];
                    gridPageView1.colTotal = "AA";
                    gridPageView1.GridPageView_Load();
                    btnExport.Enabled = (ds.Tables[0].Rows.Count > 0);
                }
                else
                {
                    MessageBox.Show(Properties.rsfReport.Coupon, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                dtpdateFrom.Value = sqlDac.GetDateTimeServer();
                dateFrom = Conversion.GetDateFormat(dtpdateFrom.Value);
                btnExport.Enabled = false;
                CATEGORY = "";

                dtpdateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                FillDataset("rptReport_Inventory_Store_Report_Page");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                    frm.SetINFBC(StoreName, Path);
                    frm.ds = ds;
                    frm.IsMdiContainer = true;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(Properties.rsfReport.Coupon, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
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
                log.Error("Error : " + ex.Message);
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
                log.Error("Error : " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                
                ImportPara();
                FillDataset("rptReport_Inventory_Store_Report_Page");
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtTemp = ds.Tables[2];
                    ExportExcel ex = new ExportExcel();

                    ex.InfoCompany = true;
                    ex.InfoStore = true;
                    ex.StrTitle = RE_TITLE.ToUpper();
                    ex.StrDate = "ĐẾN NGÀY: " + dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    ex.Dt = dtTemp;
                    ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    ex.CaseEx = 3;
                    int[] colSum = { 2, 3, 4, 5, 7};
                    ex.ArrSum = colSum;
                    ex.ExportExcels();
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
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
                CATEGORY = frm.listProGroupTag.ToString().Replace(REP_CODE, "");
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
    }
}

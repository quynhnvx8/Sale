using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using SaleMTBusiness.InventoryManagement;
using SaleMTBusiness.CustomerManagement;

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmReportProductsSale : Form
    {
        #region Declaration
        private DataSet dsGridVew;
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<string> listPro = new List<string>();
        Conversion sqlcommon = new Conversion();
        DataSet ds;
        public string StoreName, Path, dateFrom, dateTo;
        string Product,CHAIN_CODE, ListStoreCode, LIST_COLOR;
        private string LIST_SIZE, LIST_TRADEMARK, LIST_MANUFACTURE, LIST_ATTRIBUTE, CATEGORY;
        Boolean IsUsingOldProductCode;
        string ImportType, FromDateHD, ToDateHD, SoHD, SoPO, SoNB;
        private string imtCode = Properties.rsfMasterCode.Import;

        private const string REP_CODE = "||Segment01";
        private const string RE_TITLE = "BÁO CÁO NHẬP HÀNG CHI TIẾT";
        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Contructor
        public frmReportProductsSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label10.Text = translate["frmReportProductsSale.label10.Text"];
            this.label9.Text = translate["frmReportProductsSale.label9.Text"];
            this.label8.Text = translate["frmReportProductsSale.label8.Text"];
            this.label7.Text = translate["frmReportProductsSale.label7.Text"];
            this.label6.Text = translate["frmReportProductsSale.label6.Text"];
            this.label5.Text = translate["frmReportProductsSale.label5.Text"];
            this.label4.Text = translate["frmReportProductsSale.label4.Text"];
            this.label3.Text = translate["frmReportProductsSale.label3.Text"];
            this.label2.Text = translate["frmReportProductsSale.label2.Text"];
            this.label1.Text = translate["frmReportProductsSale.label1.Text"];
            this.btnSeach.Text = translate["frmReportProductsSale.btnSeach.Text"];
            this.btnExport.Text = translate["frmReportProductsSale.btnExport.Text"];
            this.btnExit.Text = translate["frmReportProductsSale.btnExit.Text"];
            this.Text = translate["frmReportProductsSale.Text"];

        }
        #endregion

        #region Method
        private void ImportPara()
         {
             try
             {
                 dateFrom = Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd");
                 dateTo = Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd");
                 Product = txtProduct.Text.Trim();
                 CHAIN_CODE = ","+UserImformation.StoreCode;//lấy theo user đăng nhập
                 ListStoreCode = "," + UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;//Lấy theo User đăng nhập
                 LIST_COLOR = "";
                 LIST_SIZE = "";
                 LIST_TRADEMARK = "";
                 LIST_MANUFACTURE = "";
                 LIST_ATTRIBUTE = "";
                 IsUsingOldProductCode = false ;
                 if (cboTypeInput.SelectedIndex == -1 || cboTypeInput.SelectedIndex == 0)
                 {
                     ImportType = "";
                 }
                 //ImportType = cboTypeInput.SelectedValue != null ? cboTypeInput.SelectedValue.ToString() : "";
                 ImportType = (cboTypeInput.SelectedIndex != -1 && cboTypeInput.Text.Trim() != "") ? cboTypeInput.SelectedValue.ToString() : "";
                 //ImportType = (cboTypeInput.SelectedIndex != -1) ? cboTypeInput.SelectedValue.ToString().Trim() : "";                 
                 FromDateHD = (dtpDateFromInvoice.Checked) ? Conversion.FirstDayTime(dtpDateFromInvoice.Value).ToString("yyyy/MM/dd") : "";
                 ToDateHD = (dtpDateToInvoice.Checked) ? Conversion.LastDayTime(dtpDateToInvoice.Value).ToString("yyyy/MM/dd") : "";
                
                 SoHD = txtCodeInvoice.Text.Trim();
                 SoPO = txtPO.Text.Trim();
                 SoNB = txtNB.Text.Trim();
                 
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
        private void FillDataset(string store)
        {
            try
            {
                ds = new DataSet();
                SqlParameter[] para = new SqlParameter[18];
                para[0] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                para[1] = posdb_vnmSqlDAC.newInParam("@FromDate", dateFrom );
                para[2] = posdb_vnmSqlDAC.newInParam("@ToDate", dateTo);
                para[3] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", CHAIN_CODE);
                para[4] = posdb_vnmSqlDAC.newInParam("@ListStoreCode", ListStoreCode);
                para[5] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", LIST_COLOR);
                para[6] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", LIST_SIZE);
                para[7] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", LIST_TRADEMARK);
                para[8] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", LIST_MANUFACTURE);
                para[9] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", LIST_ATTRIBUTE);
                para[10] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[11] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", IsUsingOldProductCode);
                para[12] = posdb_vnmSqlDAC.newInParam("@ImportType", ImportType);
                para[13] = posdb_vnmSqlDAC.newInParam("@FromDateHD", FromDateHD);
                para[14] = posdb_vnmSqlDAC.newInParam("@ToDateHD", ToDateHD);
                para[15] = posdb_vnmSqlDAC.newInParam("@SoHD", SoHD);
                para[16] = posdb_vnmSqlDAC.newInParam("@SoPO", SoPO);
                para[17] = posdb_vnmSqlDAC.newInParam("@SoNB", SoNB);
                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsImportProductsInventoryImport";
                ds.Tables[0].TableName = "InventoryImport";

                //add thêm bảng date
                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));
                dtDate.Columns.Add("CuaHangTruong", typeof(string));
                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["ToDate"] = dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["CuaHangTruong"] = DefaultCustomer.PersonPtrint;
                dtDate.Rows.Add(drDate);
                // info store
                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                // logo
                DataTable dtLogo= ds.Tables.Add("StoreLogo");
                Print.AddUserInfo(dtLogo);
                //

                SqlParameter[] paraInf = new SqlParameter[1];
                paraInf[0] = posdb_vnmSqlDAC.newInParam("@table", "Import_Product_Crystal_Report");
                dtColInfo =  sqlDac.GetDataTable("getGridConfig", paraInf);


                SqlParameter[] paraGridView = new SqlParameter[18];
                paraGridView[0] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                paraGridView[1] = posdb_vnmSqlDAC.newInParam("@FromDate", dateFrom);
                paraGridView[2] = posdb_vnmSqlDAC.newInParam("@ToDate", dateTo);
                paraGridView[3] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", CHAIN_CODE);
                paraGridView[4] = posdb_vnmSqlDAC.newInParam("@ListStoreCode", ListStoreCode);
                paraGridView[5] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", LIST_COLOR);
                paraGridView[6] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", LIST_SIZE);
                paraGridView[7] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", LIST_TRADEMARK);
                paraGridView[8] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", LIST_MANUFACTURE);
                paraGridView[9] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", LIST_ATTRIBUTE);
                paraGridView[10] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                paraGridView[11] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", IsUsingOldProductCode);
                paraGridView[12] = posdb_vnmSqlDAC.newInParam("@ImportType", ImportType);
                paraGridView[13] = posdb_vnmSqlDAC.newInParam("@FromDateHD", FromDateHD);
                paraGridView[14] = posdb_vnmSqlDAC.newInParam("@ToDateHD", ToDateHD);
                paraGridView[15] = posdb_vnmSqlDAC.newInParam("@SoHD", SoHD);
                paraGridView[16] = posdb_vnmSqlDAC.newInParam("@SoPO", SoPO);
                paraGridView[17] = posdb_vnmSqlDAC.newInParam("@SoNB", SoNB);
                dsGridVew = sqlDac.GetDataSet("rptReport_Import_Product_GridView_VIT", paraGridView);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion

        #region event
        private void btnSeach_Click(object sender, EventArgs e)
        {            
            try
            {
                ImportPara();
                FillDataset("Import_Product_Crystal_Report");
                gridPageView1.dtTotal = dsGridVew.Tables[2];
                gridPageView1.dtColInfo = dtColInfo;
                gridPageView1.dtSource = dsGridVew.Tables[0];
                gridPageView1.colTotal = "SoPO";
                gridPageView1.GridPageView_Load();
                btnExport.Enabled = (ds.Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                FillDataset("Import_Product_Crystal_Report");
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC(StoreName, Path);
                frm.ds = ds;
                frm.IsMdiContainer = true;
                frm.ShowDialog();
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
                dtpdateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpdateTo.Value = sqlDac.GetDateTimeServer();
                //dateFrom = Conversion.GetDateFormat(dtpdateFrom.Value);
                //dateTo = Conversion.GetDateFormat(dtpdateTo.Value);
                btnExport.Enabled = false;
                CATEGORY = "";
                CustomerManager.LoadMasterCode(this.cboTypeInput, imtCode);

                dtpdateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpdateTo.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateFromInvoice.CustomFormat = AppConfigFileSettings.strOptDate;
               
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
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
       
        private void btnproductattributes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReportSale.frmProductReportSearch frm = new frmProductReportSearch(translate);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                txtproductattributes.Text = frm.listProGroup.ToString();
                CATEGORY = frm.listProGroupTag.ToString().Replace(REP_CODE,"");
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                FillDataset("rptReport_Import_Product_Crystal_Excel");
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dtTemp = ds.Tables[0];
                    ExportExcel ex = new ExportExcel();

                    ex.InfoCompany = true;
                    ex.InfoStore = true;
                    ex.StrTitle = RE_TITLE.ToUpper();
                    ex.StrDate = "TỪ NGÀY: " + dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    ex.Dt = dtTemp;
                    ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    ex.CaseEx = 3;
                    int[] colSum = { 3, 9, 10, 11, 13, 14, 15 };
                    ex.ArrSum = colSum;
                    ex.ExportExcels();
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        

        

    }
}

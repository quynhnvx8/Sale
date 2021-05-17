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
    public partial class frmCompareImportProductReport : Form
    {
        #region Declaration
        private const string RE_TITLE = "BÁO CÁO CHÊNH LỆCH GIÁ";
        private const string REP_CODE = "||Segment01";
        private List<string> listPro = new List<string>();
        //posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();
        DataSet ds = new DataSet();
        public string StoreName, Path, dateFrom, dateTo;
        //string DeptCode;//Mã cửa hàng
        //string ACCOUNT;//Tên đăng nhập
        string Product, CHAIN_CODE, ListStoreCode, LIST_COLOR;//FromDate;
        string LIST_SIZE, LIST_TRADEMARK, LIST_MANUFACTURE, LIST_ATTRIBUTE;
        string CATEGORY;
        Boolean IsUsingOldProductCode = false;
        string ImportType, FromDateHD, ToDateHD, SoHD, SoPO, SoNB;

        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Contructor
        public frmCompareImportProductReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label10.Text = translate["frmCompareImportProductReport.label10.Text"];
            this.label9.Text = translate["frmCompareImportProductReport.label9.Text"];
            this.label8.Text = translate["frmCompareImportProductReport.label8.Text"];
            this.label7.Text = translate["frmCompareImportProductReport.label7.Text"];
            this.label6.Text = translate["frmCompareImportProductReport.label6.Text"];
            this.label4.Text = translate["frmCompareImportProductReport.label4.Text"];
            this.label3.Text = translate["frmCompareImportProductReport.label3.Text"];
            this.label2.Text = translate["frmCompareImportProductReport.label2.Text"];
            this.label1.Text = translate["frmCompareImportProductReport.label1.Text"];
            this.btnSeach.Text = translate["frmCompareImportProductReport.btnSeach.Text"];
            this.btnExport.Text = translate["frmCompareImportProductReport.btnExport.Text"];
            this.btnExit.Text = translate["frmCompareImportProductReport.btnExit.Text"];
            this.btnPrint.Text = translate["frmCompareImportProductReport.btnPrint.Text"];
            this.Text = translate["frmCompareImportProductReport.Text"];

        }
        #endregion

        #region Method
        private void ImportPara()
         {
             try
             {
                 dateFrom = Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss");
                 dateTo = Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd HH:mm:ss");
                 Product = txtProduct.Text.Trim();
                 CHAIN_CODE = "," + UserImformation.StoreCode;//lấy theo user đăng nhập
                 ListStoreCode = "," + UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                 LIST_COLOR = "";
                 LIST_SIZE = "";
                 LIST_TRADEMARK = "";
                 LIST_MANUFACTURE = "";
                 LIST_ATTRIBUTE = "";
                 IsUsingOldProductCode = false ;
                 ImportType = "";
                 FromDateHD = (dtpDateFromInvoice.Checked) ? Conversion.FirstDayTime(dtpDateFromInvoice.Value).ToString("yyyy/MM/dd HH:mm:ss") : "";
                 ToDateHD = (dtpDateToInvoice.Checked) ? Conversion.LastDayTime(dtpDateToInvoice.Value).ToString("yyyy/MM/dd HH:mm:ss") : "";
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
        private DataSet dsGridVew;
        private void FillDataset(string store)
        {
            try
            {
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
                DataTable dtLogo = ds.Tables.Add("StoreLogo");
                Print.AddUserInfo(dtLogo);
                //

                SqlParameter[] paraInf = new SqlParameter[1];
                paraInf[0] = posdb_vnmSqlDAC.newInParam("@table", "Compare_Import_Product_GridView_VIT");
                dtColInfo = sqlDac.GetDataTable("getGridConfig", paraInf);


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
                dsGridVew = sqlDac.GetDataSet("Compare_Import_Product_GridView_VIT", paraGridView);

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region event
        private void btnSeach_Click(object sender, EventArgs e)
        {
            ImportPara();
            FillDataset("Compare_Import_Product_Report");
            //FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew();
            //frm.SetINFBC(StoreName,Path);
            //frm.ds = ds;
            //frm.IsMdiContainer = true;
            //frm.ShowDialog();
            gridPageView1.dtTotal = dsGridVew.Tables[0];
            gridPageView1.dtColInfo = dtColInfo;
            gridPageView1.dtSource = dsGridVew.Tables[1];
            gridPageView1.colTotal = "SoNoiBo";
            gridPageView1.GridPageView_Load();
            btnExport.Enabled = (ds.Tables[0].Rows.Count > 0);
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

                dtpdateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpdateTo.CustomFormat = AppConfigFileSettings.strOptDate;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                FillDataset("Compare_Import_Product_Report");
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                FillDataset("Compare_Import_Product_Report_Excel");
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
                    ex.CaseEx = 6;
                    ex.ColFind = 1;
                    ex.LenMer = 3;
                    int[] colSum = { 3 };
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

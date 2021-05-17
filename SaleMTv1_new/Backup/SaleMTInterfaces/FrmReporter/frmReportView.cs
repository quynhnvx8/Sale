using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.ReportSource;
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTCommon;


namespace SaleMTInterfaces.FrmReporter
{
    public partial class frmReportView : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public frmReportView(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            

        }
        //Các biến khai báo
        
            //private cmdPara = collection
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();

        public string StoreName, Path, dateFrom, dateTo;
        public string DeptCode;//Mã cửa hàng
        public string ACCOUNT;//Tên đăng nhập
        DataSet ds = new DataSet();
        public string LIST_COLUMN_NO_QUANTITY, Product, CreateFrom, CreateTo, CATEGORY, CHAIN_CODE, LIST_STORE_CODE, LIST_COLUMN;
        public void SetINF(string strdateFrom, string strdateTo, string strLIST_COLUMN_NO_QUANTITY, string strProduct, string strCATEGORY, string strCHAIN_CODE, string strLIST_STORE_CODE, string strLIST_COLUMN, string strACCOUNT)
        {
            try
            { 
                dateFrom = strdateFrom;
                dateTo = strdateTo;
                LIST_COLUMN_NO_QUANTITY = strLIST_COLUMN_NO_QUANTITY;
                Product = strProduct;
                CATEGORY = strCATEGORY;
                CHAIN_CODE = strCHAIN_CODE;
                LIST_STORE_CODE = strLIST_STORE_CODE;
                LIST_COLUMN = strLIST_COLUMN;
                ACCOUNT = strACCOUNT;
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

        //static string strconn = @"Server=192.168.1.90,1444; database=posdb_vnmabc; User ID=sa; Pwd=123; Connect Timeout=100;";

        private void FillDataset()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[9];
                para[0] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN_NO_QUANTITY", LIST_COLUMN_NO_QUANTITY);
                para[1] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                para[2] = posdb_vnmSqlDAC.newInParam("@CreateFrom", dateFrom);
                para[3] = posdb_vnmSqlDAC.newInParam("@CreateTo", dateTo);
                para[4] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[5] = posdb_vnmSqlDAC.newInParam("@CHAIN_CODE", CHAIN_CODE);
                para[6] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", LIST_STORE_CODE);
                para[7] = posdb_vnmSqlDAC.newInParam("@LIST_COLUMN", LIST_COLUMN);
                para[8] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", ACCOUNT);
                ds = sqlDac.GetDataSet("rptBaoCaoBanHang", para);
                ds.DataSetName = "dsImportProductsSale";
                //ds.Tables[0].TableName = "Date";
                //ds.Tables[0].TableName = "SalesReport";
                //ds.Tables[2].TableName = "StoreInfo";
                //ds.Tables[3].TableName = "StoreLogo";
                DateTime sFrom, sTo;
                sFrom = Conversion.stringToDateTime(dateFrom);
                sTo = Conversion.stringToDateTime(dateTo);
                //MessageBox.Show(sFrom.ToString("dd/MM/yyyy"));   
                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));

                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = sFrom.ToString("dd/MM/yyyy");
                drDate["ToDate"] = sTo.ToString("dd/MM/yyyy");

                dtDate.Rows.Add(drDate);

                ds.Tables[0].TableName = "SalesReport";

                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                DataTable dtlogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtlogo);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        
        
     private void frmReportView_Load(object sender, EventArgs e)
        {
            try
            {
                Path = Application.StartupPath + Path;
                FillDataset();
                ShowReport(ds.Tables[0], Path);

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

     private void ShowReport(DataTable dt, string spath) 
     {
         try
         {
             ReportDocument rp = new ReportDocument();
             rp.Load(spath);
             
                rp.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rp;
         }
         catch (Exception ex)
         {
             log.Error("Error: " + ex.Message);
         }
     }

     private void frmReportView_KeyDown(object sender, KeyEventArgs e)
     {
         try
         {
             if (e.KeyCode == Keys.Escape)
             {
                 this.Close();
             }
         }
         catch (Exception ex)
         {
             log.Error("Error: " + ex.Message);
         }
     }
    

    }
}

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
using SaleMTInterfaces.FrmReporter.FrmReportSale;


namespace SaleMTInterfaces.FrmReporter.FrmReportView
{
    public partial class frmReportViewBy_CustomerListPage : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public frmReportViewBy_CustomerListPage(Dictionary<string, string> language)
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

        //@DeptCode truyen theo account

        public DataSet ds = new DataSet();
        string Product, DeptCode, Sex, Blood, Race, Religion, OccupationCode, OccupationOther, MaritalStatus, CusGroup;
        string ProvinceCityCode, DateFrom, DateTo, LIST_COLOR, LIST_SIZE, LIST_TRADEMARK, LIST_MANUFACTURE;
        string CountryCode = "";
        string LIST_ATTRIBUTE, CATEGORY, EmployeeList, DateFromSales, DateToSales;
        int AgeFrom, AgeTo;
        Boolean IsUsingOldProductCode;
        public string StoreName, Path;


        public void SetINF(string sProduct, string sDeptCode, string sSex, string sBlood, string sRace, string sReligion, string sOccupationCode, string sOccupationOther, string sMaritalStatus, string sCusGroup, int sAgeFrom, int sAgeTo, string sCountryCode, string sProvinceCityCode, string sDateFrom, string sDateTo, string sLIST_COLOR, string sLIST_SIZE, string sLIST_TRADEMARK, string sLIST_MANUFACTURE, string sLIST_ATTRIBUTE, string sCATEGORY, Boolean  sIsUsingOldProductCode, string sEmployeeList, string sDateFromSales, string sDateToSales)
        {
            try
            {
                SaleMTInterfaces.FrmReporter.FrmReportSale.frmSalesReportByCustomerSale frm = new frmSalesReportByCustomerSale(translate);
                Product = sProduct;
                DeptCode = sDeptCode;
                Sex = sSex;
                Blood = sBlood;
                Race = sRace;
                Religion = sReligion;
                OccupationCode = sOccupationCode;
                OccupationOther = sOccupationOther;
                MaritalStatus = sMaritalStatus;
                CusGroup = sCusGroup;
                AgeFrom = sAgeFrom;
                AgeTo = sAgeTo;
                //CountryCode = sCountryCode;
                //Sex = frm.sexcode;
                //OccupationCode = frm.job;
                //MaritalStatus = frm.marr;
                //CusGroup = frm.groupcus;
                //CountryCode = frm.coun;
                
                ProvinceCityCode = sProvinceCityCode;
                DateFrom = sDateFrom;
                DateTo = sDateTo;
                LIST_COLOR = sLIST_COLOR;
                LIST_SIZE = sLIST_SIZE;
                LIST_TRADEMARK = sLIST_TRADEMARK;
                LIST_MANUFACTURE = sLIST_MANUFACTURE;  
                LIST_ATTRIBUTE = sLIST_ATTRIBUTE;
                CATEGORY = sCATEGORY;
                IsUsingOldProductCode = sIsUsingOldProductCode;
                EmployeeList = sEmployeeList;
                DateFromSales = sDateFromSales;
                DateToSales = sDateToSales ;
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
        public DataTable dtColInfo;
        private void FillDataset()
        {
            try
            {                
                SqlParameter[] para = new SqlParameter[26];
                para[0] = posdb_vnmSqlDAC.newInParam("@Product", Product);
                para[1] = posdb_vnmSqlDAC.newInParam("@DeptCode", DeptCode);
                para[2] = posdb_vnmSqlDAC.newInParam("@Sex", Sex);
                para[3] = posdb_vnmSqlDAC.newInParam("@Blood", Blood);
                para[4] = posdb_vnmSqlDAC.newInParam("@Race", Race);
                para[5] = posdb_vnmSqlDAC.newInParam("@Religion", Religion);
                para[6] = posdb_vnmSqlDAC.newInParam("@OccupationCode", OccupationCode);
                para[7] = posdb_vnmSqlDAC.newInParam("@OccupationOther", OccupationOther);
                para[8] = posdb_vnmSqlDAC.newInParam("@MaritalStatus", MaritalStatus);
                para[9] = posdb_vnmSqlDAC.newInParam("@CusGroup", CusGroup);
                para[10] = posdb_vnmSqlDAC.newInParam("@AgeFrom", AgeFrom);
                para[11] = posdb_vnmSqlDAC.newInParam("@AgeTo", AgeTo);
                para[12] = posdb_vnmSqlDAC.newInParam("@CountryCode", CountryCode);
                para[13] = posdb_vnmSqlDAC.newInParam("@ProvinceCityCode", ProvinceCityCode);
                para[14] = posdb_vnmSqlDAC.newInParam("@DateFrom", DateFrom);
                para[15] = posdb_vnmSqlDAC.newInParam("@DateTo", DateTo);
                para[16] = posdb_vnmSqlDAC.newInParam("@LIST_COLOR", LIST_COLOR);
                para[17] = posdb_vnmSqlDAC.newInParam("@LIST_SIZE", LIST_SIZE);
                para[18] = posdb_vnmSqlDAC.newInParam("@LIST_TRADEMARK", LIST_TRADEMARK);
                para[19] = posdb_vnmSqlDAC.newInParam("@LIST_MANUFACTURE", LIST_MANUFACTURE);
                para[20] = posdb_vnmSqlDAC.newInParam("@LIST_ATTRIBUTE", LIST_ATTRIBUTE);
                para[21] = posdb_vnmSqlDAC.newInParam("@CATEGORY", CATEGORY);
                para[22] = posdb_vnmSqlDAC.newInParam("@IsUsingOldProductCode", IsUsingOldProductCode);
                para[23] = posdb_vnmSqlDAC.newInParam("@EmployeeList", EmployeeList);
                para[24] = posdb_vnmSqlDAC.newInParam("@DateFromSales", DateFromSales);
                para[25] = posdb_vnmSqlDAC.newInParam("@DateToSales", DateToSales);
                ds = sqlDac.GetDataSet("rptReport_Sales_Report_By_Customer_List_Page_Excel", para);

                SqlParameter[] paraInf = new SqlParameter[1];
                paraInf[0] = posdb_vnmSqlDAC.newInParam("@table", DateToSales);
                dtColInfo = sqlDac.GetDataTable("getGridConfig", paraInf);
                ds.DataSetName = "dsImportProductsSale";

                DateTime sFrom, sTo;
                sFrom = Conversion.stringToDateTime(DateFromSales);
                sTo = Conversion.stringToDateTime(DateToSales);

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

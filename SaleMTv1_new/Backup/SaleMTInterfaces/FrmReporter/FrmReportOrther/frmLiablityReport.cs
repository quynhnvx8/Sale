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
    /// Người tạo Luannv - 05/11/2013: Form báo cáo hàng khuyến mại
    /// </summary>
    public partial class frmLiablityReport : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataSet dsSource;
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        public string StoreName, Path;
        //private int rows = 0;
        #endregion

        #region Contructor
        public frmLiablityReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmLiablityReport.groupBox1.Text"];
            this.label6.Text = translate["frmLiablityReport.label6.Text"];
            this.label3.Text = translate["frmLiablityReport.label3.Text"];
            this.groupBox3.Text = translate["frmLiablityReport.groupBox3.Text"];
            this.rdbCancel.Text = translate["frmLiablityReport.rdbCancel.Text"];
            this.label4.Text = translate["frmLiablityReport.label4.Text"];
            this.rdbUsed.Text = translate["frmLiablityReport.rdbUsed.Text"];
            this.rdbActive.Text = translate["frmLiablityReport.rdbActive.Text"];
            this.label7.Text = translate["frmLiablityReport.label7.Text"];
            this.rdbWait.Text = translate["frmLiablityReport.rdbWait.Text"];
            this.groupBox2.Text = translate["frmLiablityReport.groupBox2.Text"];
            this.label8.Text = translate["frmLiablityReport.label8.Text"];
            this.label1.Text = translate["frmLiablityReport.label1.Text"];
            this.label5.Text = translate["frmLiablityReport.label5.Text"];
            this.btnExit.Text = translate["frmLiablityReport.btnExit.Text"];
            this.btnExport.Text = translate["frmLiablityReport.btnExport.Text"];
            this.btnSearch.Text = translate["frmLiablityReport.btnSearch.Text"];
            this.Text = translate["frmLiablityReport.Text"];

        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        

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

        private void fillDataSetHoaDonNhapHang()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateTo.Value.AddDays(1).ToString("yyyy/MM/dd"));
            para[2] = posdb_vnmSqlDAC.newInParam("@MACH", UserImformation.DeptCode);
            DataTable dtSource = sqlDac.GetDataTable("CN_HoaDon_NhapHang_Lst", para);
            dtSource.TableName = "CongNoHoaDon";
            dsSource = new DataSet();
            dsSource.Tables.Add(dtSource);
            DataTable dtDate = dsSource.Tables.Add("Date");
            dtDate.Columns.Add("FromDate");
            dtDate.Columns.Add("ToDate");
            dtDate.Columns.Add("CuaHangTruong");

            DataRow dtTemp = dtDate.NewRow();
            dtTemp["FromDate"] = dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["ToDate"] = dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["CuaHangTruong"] = DefaultCustomer.PersonPtrint;
            dtDate.Rows.Add(dtTemp);
            dtDate.AcceptChanges();

            DataTable dtStoreInfo = dsSource.Tables.Add("StoreInfo");
            dtStoreInfo.Columns.Add("StoreName");
            dtStoreInfo.Columns.Add("Address");

            dtTemp = dtStoreInfo.NewRow();
            dtTemp["StoreName"] = UserImformation.DeptName;
            dtTemp["Address"] = UserImformation.StoreAdress;
            dtStoreInfo.Rows.Add(dtTemp);
            dtStoreInfo.AcceptChanges();

            dsSource.Tables.Add("StoreLogo");
            dsSource.DataSetName = "dsImportProductsInventoryImport";
        }
        #endregion

        #region Event   
    
        #region event form process
        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                
                //
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateTo.Value = sqlDac.GetDateTimeServer();

                dtpDateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = AppConfigFileSettings.strOptDate;
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
                fillDataSetHoaDonNhapHang();
                if (dsSource.Tables["CongNoHoaDon"].Rows.Count <= 0)
                {
                    MessageBox.Show(Properties.Resources.CN, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                    frm.SetINFBC("", @"\Reports\rptHoaDonNhapHang.rpt");
                    frm.ds = dsSource;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnViewInvoices_Click' : " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateTo.Value.AddDays(1).ToString("yyyy/MM/dd"));
                para[2] = posdb_vnmSqlDAC.newInParam("@MACH", UserImformation.DeptCode);
                DataTable dtSource = sqlDac.GetDataTable("CN_HoaDon_NhapHang_Excel", para);
                ExportExcel ex = new ExportExcel();
                ex.StrTitle = "bảng kê chi tiết các hóa đơn nhập hàng".ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " - ĐẾN NGÀY:" + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.CaseEx = 3;
                ex.Dt = dtSource;
                ex.FileNames = "bảng kê chi tiết các hóa đơn nhập hàng_".ToUpper() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                int[] col = { 3, 5 };
                ex.ArrSum = col;
                ex.ExportExcels();
                //ex.ExportTableReportToExcel(dtSource, fileName, col);
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


        
        #endregion

        

        #endregion

        

        
        
    }
}

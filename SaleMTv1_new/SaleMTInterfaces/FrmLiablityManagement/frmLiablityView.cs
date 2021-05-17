using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using System.Data.SqlClient;


namespace SaleMTInterfaces.FrmLiablityManagement
{
    public partial class frmLiablityView : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataSet  dsSource;
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion
        public frmLiablityView(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.btnImport.Text = translate["frmLiablityView.btnImport.Text"];
            this.btnView.Text = translate["frmLiablityView.btnView.Text"];
            this.label8.Text = translate["frmLiablityView.label8.Text"];
            this.label9.Text = translate["frmLiablityView.label9.Text"];
            this.btnImportPay.Text = translate["frmLiablityView.btnImportPay.Text"];
            this.btnViewPay.Text = translate["frmLiablityView.btnViewPay.Text"];
            this.label4.Text = translate["frmLiablityView.label4.Text"];
            this.label5.Text = translate["frmLiablityView.label5.Text"];
            this.label6.Text = translate["frmLiablityView.label6.Text"];
            this.btnImportLiablity.Text = translate["frmLiablityView.btnImportLiablity.Text"];
            this.btnViewLiablity.Text = translate["frmLiablityView.btnViewLiablity.Text"];
            this.label1.Text = translate["frmLiablityView.label1.Text"];
            this.label2.Text = translate["frmLiablityView.label2.Text"];
            this.label3.Text = translate["frmLiablityView.label3.Text"];
            this.btnImportInvoices.Text = translate["frmLiablityView.btnImportInvoices.Text"];
            this.btnViewInvoices.Text = translate["frmLiablityView.btnViewInvoices.Text"];
            this.label27.Text = translate["frmLiablityView.label27.Text"];
            this.label42.Text = translate["frmLiablityView.label42.Text"];
            this.label31.Text = translate["frmLiablityView.label31.Text"];
            this.btnClose.Text = translate["frmLiablityView.btnClose.Text"];
            this.Text = translate["frmLiablityView.Text"];
        }	



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillDataSetHoaDonNhapHang()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromInvoices.Value.ToString("yyyy/MM/dd"));
            para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToInvoices.Value.AddDays(1).ToString("yyyy/MM/dd"));
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
            dtTemp["FromDate"] = dtpDateFromInvoices.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["ToDate"] = dtpDateToInvoices.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
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
        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            try {
                fillDataSetHoaDonNhapHang();
                if (dsSource.Tables["CongNoHoaDon"].Rows.Count <= 0)
                {
                    MessageBox.Show(Properties.Resources.CN, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }else{
                    FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                    frm.SetINFBC("", @"\Reports\rptHoaDonNhapHang.rpt");
                    frm.ds = dsSource;
                    frm.ShowDialog();
                }                
            }
            catch(Exception ex) {
                log.Error("Error 'btnViewInvoices_Click' : " + ex.Message);
            }
        }

        private void fillDataSetCN_HoaDon()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromLiablity.Value.ToString("yyyy/MM/dd"));
            para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToLiablity.Value.AddDays(1).ToString("yyyy/MM/dd"));
            para[2] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
            DataTable dtSource = sqlDac.GetDataTable("CN_HoaDon_Lst_New", para);
            dtSource.TableName = "CongNoHoaDon";
            dsSource = new DataSet();
            dsSource.Tables.Add(dtSource);
            DataTable dtDate = dsSource.Tables.Add("Date");
            dtDate.Columns.Add("FromDate");
            dtDate.Columns.Add("ToDate");
            dtDate.Columns.Add("CuaHangTruong");

            DataRow dtTemp = dtDate.NewRow();
            dtTemp["FromDate"] = dtpDateFromLiablity.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["ToDate"] = dtpDateToLiablity.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
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
        private void btnViewLiablity_Click(object sender, EventArgs e)
        {
            try
            {
                fillDataSetCN_HoaDon();
                if (dsSource.Tables["CongNoHoaDon"].Rows.Count <= 0)
                {
                    MessageBox.Show(Properties.Resources.CN, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else {
                    FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                    frm.SetINFBC("", @"\Reports\rptCongNoHoaDon.rpt");
                    frm.ds = dsSource;
                    frm.ShowDialog();
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnViewLiablity_Click' : " + ex.Message);
            }
        }

        private void fillDataSetCN_NopTienTT()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromPay.Value.ToString("yyyy/MM/dd"));
            para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToPay.Value.AddDays(1).ToString("yyyy/MM/dd"));
            para[2] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
            DataTable dtSource = sqlDac.GetDataTable("CN_NopTien_TT", para);
            dtSource.TableName = "table_CN_NopTien";
            dsSource = new DataSet();
            dsSource.Tables.Add(dtSource);
            DataTable dtDate = dsSource.Tables.Add("Date");
            dtDate.Columns.Add("FromDate");
            dtDate.Columns.Add("ToDate");
            dtDate.Columns.Add("UserPrint");

            DataRow dtTemp = dtDate.NewRow();
            dtTemp["FromDate"] = dtpDateFromPay.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["ToDate"] = dtpDateToPay.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["UserPrint"] = DefaultCustomer.PersonPtrint;
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
            dsSource.DataSetName = "CN_NopTienTT";
        }
        private void btnViewPay_Click(object sender, EventArgs e)
        {
            fillDataSetCN_NopTienTT();
            if (dsSource.Tables["table_CN_NopTien"].Rows.Count <= 0)
            {
                MessageBox.Show(Properties.Resources.CN, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC("", @"\Reports\rptInputMoneyPayment.rpt");
                frm.ds = dsSource;
                frm.ShowDialog();
            }
        }

        private void fillDataSetCN_HoaDonTT()
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = posdb_vnmSqlDAC.newInParam("@date", dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            para[1] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
            dsSource = sqlDac.GetDataSet("CN_ThanhToanByNgay", para);
            dsSource.Tables[0].TableName = "Table_1";
            dsSource.Tables[1].TableName = "Table_2";
            dsSource.Tables[2].TableName = "SumTableByDate"; 

            DataTable dtDate = dsSource.Tables.Add("Date");
            dtDate.Columns.Add("FromDate");
            dtDate.Columns.Add("ToDate");
            dtDate.Columns.Add("UserPrint");

            DataRow dtTemp = dtDate.NewRow();
            dtTemp["FromDate"] = UserImformation.DeptCode;
            dtTemp["ToDate"] = dtpDateToPay.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
            dtTemp["UserPrint"] = DefaultCustomer.PersonPtrint;
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

            dsSource.Tables.Add("SumTable_1");
            dsSource.Tables.Add("SumTable_2");
            DataTable dtSumTableByVisa = dsSource.Tables.Add("SumTableByVisa");
            dtSumTableByVisa.Columns.Add("STT");
            dtSumTableByVisa.Columns.Add("EXPORT_CODE");
            dtSumTableByVisa.Columns.Add("AMOUNT");

            dsSource.DataSetName = "CN_NopTienTT";
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            fillDataSetCN_HoaDonTT();
            if (dsSource.Tables["Table_1"].Rows.Count <= 0 && dsSource.Tables["Table_2"].Rows.Count <= 0)
            {
                MessageBox.Show(Properties.Resources.CN, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC("", @"\Reports\rptViewCN_ThanhToan.rpt");
                frm.ds = dsSource;
                frm.ShowDialog();
            }
        }

        private void frmLiablityReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDateFromInvoices.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateFromLiablity.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateFromPay.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnImportInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromInvoices.Value.ToString("yyyy/MM/dd"));
                para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToInvoices.Value.AddDays(1).ToString("yyyy/MM/dd"));
                para[2] = posdb_vnmSqlDAC.newInParam("@MACH", UserImformation.DeptCode);
                DataTable dtSource = sqlDac.GetDataTable("CN_HoaDon_NhapHang_Excel", para);
                ExportExcel ex = new ExportExcel();
                ex.StrTitle = "bảng kê chi tiết các hóa đơn nhập hàng".ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpDateFromInvoices.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " - ĐẾN NGÀY:" + dtpDateToInvoices.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
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

        private void btnImportLiablity_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromLiablity.Value.ToString("yyyy/MM/dd"));
                para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToLiablity.Value.AddDays(1).ToString("yyyy/MM/dd"));
                para[2] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
                DataTable dtSource = sqlDac.GetDataTable("CN_HoaDon_Lst_Excel", para);
                ExportExcel ex = new ExportExcel();
                ex.StrTitle = "BẢNG KÊ ĐỐI CHIẾU CÔNG NỢ CÔNG TY";
                ex.StrDate = "TỪ NGÀY: " + dtpDateFromLiablity.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " - ĐẾN NGÀY:" + dtpDateToLiablity.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.CaseEx = 3;
                ex.Dt = dtSource;
                ex.FileNames = "BẢNG KÊ ĐỐI CHIẾU CÔNG NỢ CÔNG TY_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                int[] arrSum =  { 3, 5 ,6,9,10};
                ex.ArrSum = arrSum;
                //ex.ExportTableReportToExcel(dtSource, fileName, col);
                ex.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnImportPay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@FROMDATE", dtpDateFromPay.Value.ToString("yyyy/MM/dd"));
                para[1] = posdb_vnmSqlDAC.newInParam("@TODATE", dtpDateToPay.Value.AddDays(1).ToString("yyyy/MM/dd"));
                para[2] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
                DataTable dtSource = sqlDac.GetDataTable("CN_NopTien_Excel", para);                
                ExportExcel ex = new ExportExcel();
                ex.StrTitle = "BẢNG KÊ NỘP TIỀN THANH TOÁN CÔNG TY";
                ex.StrDate = "TỪ NGÀY: " + dtpDateFromPay.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " - ĐẾN NGÀY:" + dtpDateToPay.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.CaseEx = 3;
                ex.Dt = dtSource;
                ex.FileNames = "BẢNG KÊ NỘP TIỀN THANH TOÁN CÔNG TY_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                //ex.ExportTableReportToExcel(dtSource, fileName, null);
                ex.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@date", dtpDateFrom.Value.ToString("yyyy/MM/dd"));
                para[1] = posdb_vnmSqlDAC.newInParam("@MA_CUA_HANG", UserImformation.DeptCode);
                dsSource = sqlDac.GetDataSet("CN_ThanhToanByNgay_Excel", para);
                ExportExcel ex = new ExportExcel();
                ex.StrTitle = "BẢNG KÊ CHI TIẾT CÁC HOÁ ĐƠN THANH TOÁN";
                ex.StrDate = "NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.CaseEx = 1;
                ex.ColFind = 0;
                ex.LenMer = 6;
                ex.Dt = dsSource.Tables[0];
                ex.FileNames = "BẢNG KÊ CHI TIẾT CÁC HOÁ ĐƠN THANH TOÁN_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                //ex.ExportToExcelWithSign(dsSource.Tables[0], fileName, 0,5);
                ex.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    }
}

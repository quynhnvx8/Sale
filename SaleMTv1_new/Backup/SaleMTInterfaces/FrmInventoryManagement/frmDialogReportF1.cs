using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.InventoryManagement;
using SaleMTInterfaces.PrintBill;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmDialogReportF1 : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtAutoPO;
        frmProgress progressExcel = new frmProgress();
        #endregion

        #region Constant
        private const string F1_REPORT_PATH = "\\Reports\\rptReportF1.rpt";
        #endregion

        #region Property
        public DataTable DTAutoPO
        {
            set { dtAutoPO = value; }
            get { return dtAutoPO; }
        }
        #endregion

        #region Constructors
        
        public frmDialogReportF1(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnPrint.Text = translate["frmDialogReportF1.btnPrint.Text"];
            this.btnExcel.Text = translate["frmDialogReportF1.btnExcel.Text"];
            this.btnPO.Text = translate["frmDialogReportF1.btnPO.Text"];
            this.btnClose.Text = translate["frmDialogReportF1.btnClose.Text"];
            this.PRODUCT_ID.HeaderText = translate["frmDialogReportF1.PRODUCT_ID.HeaderText"];
            this.PRODUCT_NAME.HeaderText = translate["frmDialogReportF1.PRODUCT_NAME.HeaderText"];
            this.DAUKY.HeaderText = translate["frmDialogReportF1.DAUKY.HeaderText"];
            this.NHAP.HeaderText = translate["frmDialogReportF1.NHAP.HeaderText"];
            this.XUAT.HeaderText = translate["frmDialogReportF1.XUAT.HeaderText"];
            this.TON.HeaderText = translate["frmDialogReportF1.TON.HeaderText"];
            this.LKTTT.HeaderText = translate["frmDialogReportF1.LKTTT.HeaderText"];
            this.KHTTT.HeaderText = translate["frmDialogReportF1.KHTTT.HeaderText"];
            this.DMKH.HeaderText = translate["frmDialogReportF1.DMKH.HeaderText"];
            this.DTKH.HeaderText = translate["frmDialogReportF1.DTKH.HeaderText"];
            this.DTTT.HeaderText = translate["frmDialogReportF1.DTTT.HeaderText"];
            this.TKMIN.HeaderText = translate["frmDialogReportF1.TKMIN.HeaderText"];
            this.TKNEXT.HeaderText = translate["frmDialogReportF1.TKNEXT.HeaderText"];
            this.TKLEAD.HeaderText = translate["frmDialogReportF1.TKLEAD.HeaderText"];
            this.YCTON.HeaderText = translate["frmDialogReportF1.YCTON.HeaderText"];
            this.POCONFIRM.HeaderText = translate["frmDialogReportF1.POCONFIRM.HeaderText"];
            this.PODVKH.HeaderText = translate["frmDialogReportF1.PODVKH.HeaderText"];
            this.QC.HeaderText = translate["frmDialogReportF1.QC.HeaderText"];
            this.SLT.HeaderText = translate["frmDialogReportF1.SLT.HeaderText"];
            this.THANHTIEN.HeaderText = translate["frmDialogReportF1.THANHTIEN.HeaderText"];
            this.CB.HeaderText = translate["frmDialogReportF1.CB.HeaderText"];
            this.Text = translate["frmDialogReportF1.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 28/10/2013 : Lấy báo cáo xuất nhập tồn
        /// </summary>
        private DataTable LoadData()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlPara = new SqlParameter[2];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@STORE_CODE", SqlDbType.VarChar, UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@OrderDate", SqlDbType.DateTime, SqlDAC.GetDateTimeServer());
                dt = SqlDAC.GetDataTable("Order_Product_ReportF1", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadData' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 28/10/2013 : Lấy đơn hàng tự động
        /// </summary>
        private DataTable LoadAutoPO()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlPara = new SqlParameter[2];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@STORE_CODE", SqlDbType.VarChar, UserImformation.StoreCode);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@OrderDate", SqlDbType.DateTime, SqlDAC.GetDateTimeServer());
                dt = SqlDAC.GetDataTable("Order_Product_CreateAutoPO", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadAutoPO' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 28/10/2013 : In báo cáo xuất nhập tồn
        /// </summary>
        private void PrintData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(LoadData());
                ds.Tables[0].TableName = "BaoCao";
                //DataTable dtReport = ds.Tables.Add("BaoCao");
                //dtReport = LoadData();

                DataTable dtStoreInfo = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStoreInfo);
                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);
                DataTable dtInfo = ds.Tables.Add("ThongTin");
                dtInfo.Columns.Add("NgayBanHangThucTe", typeof(DateTime));
                dtInfo.Columns.Add("NgayBanHangTrongThang", typeof(DateTime));
                dtInfo.Columns.Add("NguoiIn", typeof(string));
                DataRow rowInfo = dtInfo.NewRow();
                rowInfo["NgayBanHangThucTe"] = SqlDAC.GetDateTimeServer();
                rowInfo["NgayBanHangTrongThang"] = SqlDAC.GetDateTimeServer();
                rowInfo["NguoiIn"] = UserImformation.UserName;

                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = F1_REPORT_PATH;
                frm.ds = ds;
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintData' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 28/10/2013 : Ghi excel báo cáo xuất nhập tồn
        /// </summary>
        private void SaveExcel()
        {
            try
            {
                //float i = 100 / (float)dgvReport.Rows.Count;
                DataTable dt = new DataTable();
                dt.Columns.Add("MÃ HÀNG", typeof(string));
                dt.Columns.Add("TÊN HÀNG", typeof(string));
                dt.Columns.Add("ĐẦU KỲ", typeof(int));
                dt.Columns.Add("NHẬP", typeof(int));
                dt.Columns.Add("XUẤT", typeof(int));
                dt.Columns.Add("TỒN", typeof(int));
                dt.Columns.Add("LKTTT", typeof(int));
                dt.Columns.Add("KHTTT", typeof(int));
                dt.Columns.Add("DMKH", typeof(int));
                dt.Columns.Add("DTKH", typeof(string));
                dt.Columns.Add("DTTT", typeof(int));
                dt.Columns.Add("MIN", typeof(int));
                dt.Columns.Add("NEXT", typeof(int));
                dt.Columns.Add("LEAD", typeof(int));
                dt.Columns.Add("Y/C TỒN", typeof(string));
                dt.Columns.Add("POCONFIRM", typeof(int));
                dt.Columns.Add("PODVKH", typeof(int));
                dt.Columns.Add("QC", typeof(int));
                dt.Columns.Add("SLT", typeof(int));
                dt.Columns.Add("T.TIỀN", typeof(int));
                dt.Columns.Add("CB", typeof(string));
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    //if (backgroundWorker1.CancellationPending == true)
                    //    return;
                    DataRow dtRow = dt.NewRow();
                    dtRow["MÃ HÀNG"] = row.Cells["PRODUCT_ID"].Value != null ? row.Cells["PRODUCT_ID"].Value.ToString() : "";
                    dtRow["TÊN HÀNG"] = row.Cells["PRODUCT_NAME"].Value != null ? row.Cells["PRODUCT_NAME"].Value.ToString() : "";
                    dtRow["ĐẦU KỲ"] = row.Cells["DAUKY"].Value != null ? row.Cells["DAUKY"].Value.ToString() : "";
                    dtRow["NHẬP"] = row.Cells["NHAP"].Value != null ? row.Cells["NHAP"].Value.ToString() : "";
                    dtRow["XUẤT"] = row.Cells["XUAT"].Value != null ? row.Cells["XUAT"].Value.ToString() : "";
                    dtRow["TỒN"] = row.Cells["TON"].Value != null ? row.Cells["TON"].Value.ToString() : "";
                    dtRow["LKTTT"] = row.Cells["LKTTT"].Value != null ? row.Cells["LKTTT"].Value.ToString() : "";
                    dtRow["KHTTT"] = row.Cells["KHTTT"].Value != null ? row.Cells["KHTTT"].Value.ToString() : "";
                    dtRow["DMKH"] = row.Cells["DMKH"].Value != null ? row.Cells["DMKH"].Value.ToString() : "";
                    dtRow["DTKH"] = row.Cells["DTKH"].Value != null ? row.Cells["DTKH"].Value.ToString() : "";
                    dtRow["DTTT"] = row.Cells["DTTT"].Value != null ? row.Cells["DTTT"].Value.ToString() : "";
                    dtRow["MIN"] = row.Cells["TKMIN"].Value != null ? row.Cells["TKMIN"].Value.ToString() : "";
                    dtRow["NEXT"] = row.Cells["TKNEXT"].Value != null ? row.Cells["TKNEXT"].Value.ToString() : "";
                    dtRow["LEAD"] = row.Cells["TKLEAD"].Value != null ? row.Cells["TKLEAD"].Value.ToString() : "";
                    dtRow["Y/C TỒN"] = row.Cells["YCTON"].Value != null ? row.Cells["YCTON"].Value.ToString() : "";
                    dtRow["POCONFIRM"] = row.Cells["POCONFIRM"].Value != null ? row.Cells["POCONFIRM"].Value.ToString() : "";
                    dtRow["PODVKH"] = row.Cells["PODVKH"].Value != null ? row.Cells["PODVKH"].Value.ToString() : "";
                    dtRow["QC"] = row.Cells["QC"].Value != null ? row.Cells["QC"].Value.ToString() : "";
                    dtRow["SLT"] = row.Cells["SLT"].Value != null ? row.Cells["SLT"].Value.ToString() : "";
                    dtRow["T.TIỀN"] = row.Cells["THANHTIEN"].Value != null ? row.Cells["THANHTIEN"].Value.ToString() : "";
                    dtRow["CB"] = row.Cells["CB"].Value != null ? row.Cells["CB"].Value.ToString() : "";
                    dt.Rows.Add(dtRow);
                    //backgroundWorker1.ReportProgress(Convert.ToInt32(i * (float)(row.Index + 1)));
                    //System.Threading.Thread.Sleep(10);
                }
                //DateTime d = SqlDAC.GetDateTimeServer();
                //string filename = "BaoCaoF1_" + d.ToString("yyyyMMdd_HHmmss") + ".xls";
                //if (backgroundWorker1.CancellationPending != true)
                //{
                //    SaleMTCommon.Export expExcel = new SaleMTCommon.Export();
                //    expExcel.InfoCompany = true;
                //    expExcel.InfoStore = true;
                //    expExcel.StrTitle = "BÁO CÁO F1";
                //    expExcel.ExportToExcel(dt, filename);
                //}
                ExportExcel exN = new ExportExcel();
                exN.InfoCompany = true;
                exN.InfoStore = true;
                exN.StrTitle = "BÁO CÁO F1";
                exN.Dt = dt;
                exN.CaseEx = 5;
                exN.FileNames = "BaoCaoF1_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                exN.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveExcel' : " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void frmDialogReportF1_Load(object sender, EventArgs e)
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.DataSource = LoadData();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintData();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveExcel();
                //if (backgroundWorker1.IsBusy != true)
                //{
                //    backgroundWorker1.RunWorkerAsync();
                //    progressExcel = new frmProgress();
                //    progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundCancel);
                //    progressExcel.StartPosition = FormStartPosition.CenterScreen;
                //    progressExcel.ShowDialog(this);
                    
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnExcel_Click' : " + ex.Message);
            }
        }
        private void btnPO_Click(object sender, EventArgs e)
        {
            dtAutoPO = LoadAutoPO();
            this.DialogResult = DialogResult.OK;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvReport.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvReport.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvReport_DataBindingComplete' : " + ex.Message);
            }
        }
        private void BackgroundCancel(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                progressExcel.Close();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveExcel();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressExcel.Message = "Exporting " + e.ProgressPercentage.ToString() + " of 100%";
            progressExcel.Progress = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressExcel.Close();
        }
        #endregion        
        
    }
}

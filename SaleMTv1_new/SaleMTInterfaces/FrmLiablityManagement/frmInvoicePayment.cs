using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTInterfaces.FrmInventoryManagement;

namespace SaleMTInterfaces.FrmLiablityManagement
{
    public partial class frmInvoicePayment : TabForm
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static  string sMaTT, SoHD;
        frmProgress progressExcel;

        public frmInvoicePayment(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        
            this.evAddNew += new System.EventHandler(this.Add);
            this.evDelete += new System.EventHandler(this.Delete);
            this.evSearch += new System.EventHandler(this.Search);
            this.evExportExcel += new System.EventHandler(this.Excel);
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label28.Text = translate["frmInvoicePayment.label28.Text"];
            this.label27.Text = translate["frmInvoicePayment.label27.Text"];
            this.label42.Text = translate["frmInvoicePayment.label42.Text"];
            this.gbxDanhSach.Text = translate["frmInvoicePayment.gbxDanhSach.Text"];
            this.MaTT.HeaderText = translate["frmInvoicePayment.MaTT.HeaderText"];
            this.Ngay.HeaderText = translate["frmInvoicePayment.Ngay.HeaderText"];
            this.MASTER_NAME.HeaderText = translate["frmInvoicePayment.MASTER_NAME.HeaderText"];
            this.gbxChiTietTT.Text = translate["frmInvoicePayment.gbxChiTietTT.Text"];
            this.Column1.HeaderText = translate["frmInvoicePayment.Column1.HeaderText"];
            this.SoPO.HeaderText = translate["frmInvoicePayment.SoPO.HeaderText"];
            this.SoNoiBo.HeaderText = translate["frmInvoicePayment.SoNoiBo.HeaderText"];
            this.NgayHD.HeaderText = translate["frmInvoicePayment.NgayHD.HeaderText"];
            this.NgayTT.HeaderText = translate["frmInvoicePayment.NgayTT.HeaderText"];
            this.SoTien.HeaderText = translate["frmInvoicePayment.SoTien.HeaderText"];
            this.SoThanhToan.HeaderText = translate["frmInvoicePayment.SoThanhToan.HeaderText"];
            this.SoTienDaThanhToan.HeaderText = translate["frmInvoicePayment.SoTienDaThanhToan.HeaderText"];
            this.SoTienconLai.HeaderText = translate["frmInvoicePayment.SoTienconLai.HeaderText"];
            this.gbxThanhToanHD.Text = translate["frmInvoicePayment.gbxThanhToanHD.Text"];
            this.dataGridViewTextBoxColumn1.HeaderText = translate["frmInvoicePayment.dataGridViewTextBoxColumn1.HeaderText"];
            this.dataGridViewTextBoxColumn2.HeaderText = translate["frmInvoicePayment.dataGridViewTextBoxColumn2.HeaderText"];
            this.MASTERNAME.HeaderText = translate["frmInvoicePayment.MASTERNAME.HeaderText"];
            this.sSoThanhToan.HeaderText = translate["frmInvoicePayment.sSoThanhToan.HeaderText"];
            this.GhiChu.HeaderText = translate["frmInvoicePayment.GhiChu.HeaderText"];
            this.Text = translate["frmInvoicePayment.Text"];
        }	

        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Set menu điều khiển tại form main
        /// </summary>
        private void SetMenu(bool delete, bool excel)
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool[] active = { true, false, false, false, delete, false, excel, false, true, false, true, true };
                parMain.ActiveMenu(active);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #region method/function
        private void BillPayment()
        {
            try
            {
                DateTime datefrom = (dtpDateFrom.Checked) ? dtpDateFrom.Value.Date : Convert.ToDateTime("1900/01/01");
                DateTime dateto = (dtpDateTo.Checked) ? dtpDateTo.Value.Date.AddMinutes(1439) : Convert.ToDateTime("9999/01/01");
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@DateFrom", datefrom);
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTo", dateto);
                dTableNew = sqlDac.GetDataTable("Payment_Debit", para);
                dgvpayment.DataSource = dTableNew;
                if (dgvpayment.RowCount > 0)
                {
                    SetMenu(true, true);
                }
                else
                {
                    if (dgvDetailPayment.DataSource != null && dgvPaymentInvoince.DataSource != null)
                    {
                        (dgvPaymentInvoince.DataSource as DataTable).Rows.Clear();
                        (dgvDetailPayment.DataSource as DataTable).Rows.Clear();
                    }
                }
                
                //lvwPayment.Items.Clear();
                //for (int i = 0; i < dTableNew.Rows.Count; i++)
                //{
                    //ListViewItem lvi = new ListViewItem(dTableNew.Rows[i]["MaTT"].ToString());
                    
                    //lvi.SubItems.Add(dTableNew.Rows[i]["MaTT"].ToString());
                    //lvi.SubItems.Add(dTableNew.Rows[i]["Ngay"].ToString());
                    //lvi.SubItems.Add(dTableNew.Rows[i]["MASTER_NAME"].ToString());
                    //lvwPayment.Items.Add(lvi);
                    //lvwPayment.Items.Add(dTableNew.Rows[i]["MaTT"].ToString());
                    //lvwPayment.Items[i].SubItems.Add(dTableNew.Rows[i]["Ngay"].ToString());
                    //lvwPayment.Items[i].SubItems.Add(dTableNew.Rows[i]["MASTER_NAME"].ToString());
                    
                //}
                //lvwPayment.Items[0].Selected = true;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void BillPaymentDetail()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@MaTT", sMaTT );                
                dTableNew = sqlDac.GetDataTable("Payment_Detail_Debit", para);
                dgvDetailPayment.DataSource = dTableNew;
                dgvDetailPayment.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetailPayment.Columns["SoThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetailPayment.Columns["SoTienDaThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetailPayment.Columns["SoTienconLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvDetailPayment.Rows[0].Selected = true;
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(210, 180, 140);
                style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                dgvDetailPayment.Rows[0].DefaultCellStyle = style;
                dgvDetailPayment.Rows[dgvDetailPayment.RowCount - 1].DefaultCellStyle = style;                
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void BillPaymentDetailInvoice()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@SoHD", SoHD );
                dTableNew = sqlDac.GetDataTable("Payment_Detail_Invoice", para);
                if (dTableNew.Rows.Count > 0)
                {
                    float totalmoney = float.Parse(dTableNew.Rows[0]["SoThanhToan"].ToString());
                    float currentmoney = 0;
                    foreach (DataRow dr in dTableNew.Rows)
                    {
                        if (dr["SoHD"] != null && dr["SoHD"] != DBNull.Value && dr["SoHD"].ToString() != "")
                        {
                            currentmoney += float.Parse(dr["SoThanhToan"].ToString());                            
                        }
                    }
                    if (totalmoney - currentmoney != 0)
                    {
                        List<CN_HoaDon> hoadon = CN_HoaDon.ReadBySoHD(SoHD);
                        DateTime date = hoadon.Count > 0 ? hoadon[0].NgayHD : sqlDac.GetDateTimeServer();

                        DataRow dr = dTableNew.NewRow();
                        dr["SoHD"] = SoHD;
                        dr["NgayHD"] = date;
                        dr["MASTER_NAME"] = "";
                        dr["SoThanhToan"] = totalmoney - currentmoney;
                        dr["GhiChu"] = "Thanh toán đầu kỳ";
                        dTableNew.Rows.InsertAt(dr, 1);
                    }
                }

                dgvPaymentInvoince.DataSource = dTableNew;
                //dgvPaymentInvoince.Columns["sSoThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvPaymentInvoince.RowCount > 2)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.FromArgb(210, 180, 140);
                    style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                    dgvPaymentInvoince.Rows[0].DefaultCellStyle = style;
                    dgvPaymentInvoince.Rows[dgvPaymentInvoince.RowCount - 1].DefaultCellStyle = style;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }
        /// <summary>
        /// thanhdh – 12/10/2013 : Xóa hóa đơn thanh toán
        /// </summary>
        private void BillPaymentDelete()
        {
            try
            {
                if (dgvDetailPayment != null && dgvDetailPayment.RowCount > 2)
                {
                    var confirmMsg = MessageBox.Show(Properties.rsfInvoicePayment.DeleteConfirm, translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (confirmMsg == DialogResult.Yes)
                    {
                        string query;
                        SqlParameter[] para;
                        DataTable dt = dgvDetailPayment.DataSource as DataTable;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["SoHD"] != null && dr["SoHD"] != DBNull.Value && dr["SoHD"].ToString() != "")
                            {
                                float sotien = float.Parse(dr["SoThanhToan"].ToString());
                                float datt = float.Parse(dr["SoTienDaThanhToan"].ToString());
                                float conlai = float.Parse(dr["SoTienconLai"].ToString());

                                query = "update CN_HoaDon set DaTT = @DaTT, ConLai = @ConLai where SoHD = @SoHD";
                                para = new SqlParameter[3];
                                para[0] = posdb_vnmSqlDAC.newInParam("@SoHD", SqlDbType.VarChar, dr["SoHD"].ToString());
                                para[1] = posdb_vnmSqlDAC.newInParam("@DaTT", SqlDbType.Float, datt - sotien);
                                para[2] = posdb_vnmSqlDAC.newInParam("@ConLai", SqlDbType.Float, conlai + sotien);
                                sqlDac.InlineSql_ExecuteNonQuery(query, para);
                            }
                        }
                        query = "delete CN_ThanhToan where MaTT = @MaTT";
                        para = new SqlParameter[1] { posdb_vnmSqlDAC.newInParam("@MaTT", SqlDbType.VarChar, sMaTT) };
                        sqlDac.InlineSql_ExecuteNonQuery(query, para);
                        (dgvPaymentInvoince.DataSource as DataTable).Rows.Clear();
                        (dgvDetailPayment.DataSource as DataTable).Rows.Clear();
                        MessageBox.Show(Properties.rsfInvoicePayment.DeleteOK, translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        BillPayment();
                        if (dgvpayment.RowCount > 0)
                        {
                            dgvpayment.Rows[0].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BillPaymentDelete' : " + ex.Message);
            }
        }

        private void BillPaymentExcel()
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (backgroundWorker1.CancellationPending == true)
                        return;
                    backgroundWorker1.ReportProgress(i);
                    System.Threading.Thread.Sleep(5);
                    if (i == 100)
                    {
                        DateTime d = sqlDac.GetDateTimeServer();
                        string filename = "ThanhToanDonHang_Filled_" + d.ToString("yyyyMMdd_HHmmss") + ".xls";
                        SaleMTCommon.Export expExcel = new SaleMTCommon.Export();
                        expExcel.InfoCompany = true;
                        expExcel.InfoStore = true;
                        expExcel.StrTitle = "BẢNG KÊ CHI TIẾT CÁC HOÁ ĐƠN THANH TOÁN";
                        expExcel.StrDate = "HÓA ĐƠN "+ sMaTT;
                        expExcel.ExportGridReportToExcel(dgvDetailPayment, filename.Replace(@"/",@"_").Replace(":","_"),5);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BillPaymentExcel' : " + ex.Message);
            }
        }

        #endregion
        #region control event
        private void frmInvoicePayment_Load(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Notice: form started.");
                SetMenu(false,false);
                DateTime dt = sqlDac.GetDateTimeServer();
                dtpDateFrom.Value = new DateTime(dt.Year, dt.Month, 1);
                dtpDateTo.Value = dt;
                
            }            
            catch (Exception ex)
            {
                log.Error("Error 'Load Invoice Payment' : " + ex.Message);
            }
        }

        private void dgvpayment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sMaTT = dgvpayment.Rows[dgvpayment.CurrentRow.Index].Cells["MaTT"].Value.ToString();
                BillPaymentDetail();                
            }
            catch (Exception ex)
            {
                log.Error("Error 'Invoice payment' : " + ex.Message);
            }
        }

        private void dgvDetailPayment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailPayment.Rows.Count  > 0)
                {
                    int row = dgvDetailPayment.CurrentRow.Index > 1 ? dgvDetailPayment.CurrentRow.Index : 1;
                    if (dgvDetailPayment.Rows.Count > row)
                    {
                        SoHD = dgvDetailPayment.Rows[row].Cells["Column1"].Value.ToString();
                    }
                    BillPaymentDetailInvoice();
                }
                

            }
            catch (Exception ex)
            {
                log.Error("Error 'Invoice payment' : " + ex.Message);
            }
        }
        
        private void btnPaymentSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BillPayment();

            }
            catch (Exception ex)
            {
                log.Error("Error 'Invoice payment' : " + ex.Message);
            }
        }
        

        private void Add(object sender, EventArgs e)
        {
            //frmPaymentInvoice frm = new frmPaymentInvoice();
            //frm.ShowDialog();
            try
            {
                if (dgvpayment.RowCount > 0)
                {
                    SetMenu(true, true);
                }
                else
                {
                    SetMenu(false, false);
                }
                frmPaymentInvoice frm = new frmPaymentInvoice(translate);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmInvoicePayment_Activated' : " + ex.Message);
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            BillPaymentDelete();
        }
        private void Search(object sender, EventArgs e)
        {
            BillPayment();
        }
        private void Excel(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailPayment != null && dgvDetailPayment.RowCount > 2)
                {
                    backgroundWorker1.RunWorkerAsync();
                    progressExcel = new frmProgress();
                    progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundCancel);
                    progressExcel.StartPosition = FormStartPosition.CenterScreen;
                    progressExcel.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Excel' : " + ex.Message);
            }
        }

        private void dgvDetailPayment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 5 || e.ColumnIndex == 7 || e.ColumnIndex == 8) //Column ColB
            {
                if (e.Value != null && !double.Parse("0.0").Equals(e.Value))
                {
                    e.CellStyle.Format = "#,###";
                }
                else
                {
                    e.CellStyle.Format = "0";
                }
            }
        }

        private void dgvPaymentInvoince_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3) //Column ColB
            {
                if (e.Value != null && !double.Parse("0.0").Equals(e.Value))
                {
                    e.CellStyle.Format = "#,###";
                }
                else
                {
                    e.CellStyle.Format = "0";
                }
            }
        }

        private void dgvpayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvpayment.Rows)
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
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvDetailPayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvDetailPayment.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
                if (dgvDetailPayment.RowCount > 0)
                {
                    int row = dgvDetailPayment.CurrentRow.Index > 1 ? dgvDetailPayment.CurrentRow.Index : 1;
                    if (dgvDetailPayment.Rows.Count > row)
                    {
                        SoHD = dgvDetailPayment.Rows[row].Cells["Column1"].Value.ToString();
                    }
                    BillPaymentDetailInvoice();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvPaymentInvoince_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvPaymentInvoince.Rows)
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
                log.Error("Error: " + ex.Message);
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
            BillPaymentExcel();
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

        private void frmInvoicePayment_Activated(object sender, EventArgs e)
        {
            try {
                if (dgvpayment.RowCount > 0)
                {
                    SetMenu(true, true);
                }
                else {
                    SetMenu(false, false);
                }
            }
            catch (Exception ex) {
                log.Error("Error 'frmInvoicePayment_Activated' : " + ex.Message);
            }
        }

    }
}

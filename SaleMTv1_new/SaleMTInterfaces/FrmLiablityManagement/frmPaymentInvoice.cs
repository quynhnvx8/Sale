using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTBusiness.SaleManagement;

namespace SaleMTInterfaces.FrmLiablityManagement
{
    public partial class frmPaymentInvoice : Form
    {
        public frmPaymentInvoice(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnSearch.Text = translate["frmPaymentInvoice.btnSearch.Text"];
            this.label4.Text = translate["frmPaymentInvoice.label4.Text"];
            this.label3.Text = translate["frmPaymentInvoice.label3.Text"];
            this.label2.Text = translate["frmPaymentInvoice.label2.Text"];
            this.label1.Text = translate["frmPaymentInvoice.label1.Text"];
            this.groupBox2.Text = translate["frmPaymentInvoice.groupBox2.Text"];
            this.SoHD.HeaderText = translate["frmPaymentInvoice.SoHD.HeaderText"];
            this.SoPO.HeaderText = translate["frmPaymentInvoice.SoPO.HeaderText"];
            this.SoNoiBo.HeaderText = translate["frmPaymentInvoice.SoNoiBo.HeaderText"];
            this.NgayHD.HeaderText = translate["frmPaymentInvoice.NgayHD.HeaderText"];
            this.SoTien.HeaderText = translate["frmPaymentInvoice.SoTien.HeaderText"];
            this.SoTienDaThanhToan.HeaderText = translate["frmPaymentInvoice.SoTienDaThanhToan.HeaderText"];
            this.SoThanhToan.HeaderText = translate["frmPaymentInvoice.SoThanhToan.HeaderText"];
            this.SoTienconLai.HeaderText = translate["frmPaymentInvoice.SoTienconLai.HeaderText"];
            this.groupBox3.Text = translate["frmPaymentInvoice.groupBox3.Text"];
            this.btnPhanBo.Text = translate["frmPaymentInvoice.btnPhanBo.Text"];
            this.label7.Text = translate["frmPaymentInvoice.label7.Text"];
            this.label6.Text = translate["frmPaymentInvoice.label6.Text"];
            this.label5.Text = translate["frmPaymentInvoice.label5.Text"];
            this.btnTableStatementMoney.Text = translate["frmPaymentInvoice.btnTableStatementMoney.Text"];
            this.btnSave.Text = translate["frmPaymentInvoice.btnSave.Text"];
            this.btnClose.Text = translate["frmPaymentInvoice.btnClose.Text"];
            this.Text = translate["frmPaymentInvoice.Text"];
        }	

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        object DateFromInvoice, DateToInvoice, DatetFromPayment, DateToPayment;
        string LoaiTT, MaTT, MaCH;//GhiChu;
        string GhiChu = "";
        DateTime sNgayHD = DateTime.Now;
        float sConLai = 0; //sSoTien;
        //int row;
        private double oldPayment;
        #endregion
        #region method/function
        private void Reset()
        {
            DateFromInvoice = Convert.ToDateTime("1900/01/01");
            DateToInvoice = Convert.ToDateTime("1900/01/01");
            DatetFromPayment = Convert.ToDateTime("1900/01/01");
            DateToPayment = Convert.ToDateTime("1900/01/01");
            MaCH = UserImformation.DeptCode;
        }

        private void BillPaymentInvoice()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[4];
                DateFromInvoice = dtpDateFromInvoice.Checked ? (object)dtpDateFromInvoice.Value.ToString("yyyy/MM/dd") : Convert.ToDateTime("1900/01/01");
                DateToInvoice = dtpDateToInvoice.Checked ? (object)dtpDateToInvoice.Value.AddDays(1).ToString("yyyy/MM/dd") : Convert.ToDateTime("9999/01/01");
                DatetFromPayment = dtpDatetFromPayment.Checked ? (object)dtpDatetFromPayment.Value.ToString("yyyy/MM/dd") : Convert.ToDateTime("1900/01/01");
                DateToPayment = dtpDateToPayment.Checked ? (object)dtpDateToPayment.Value.AddDays(1).ToString("yyyy/MM/dd") : Convert.ToDateTime("9999/01/01");

                para[0] = posdb_vnmSqlDAC.newInParam("@DateFrom", DateFromInvoice);
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTo", DateToInvoice);
                para[2] = posdb_vnmSqlDAC.newInParam("@DateFromPayMent", DatetFromPayment);
                para[3] = posdb_vnmSqlDAC.newInParam("@DateToPayMent", DateToPayment);
                dTableNew = sqlDac.GetDataTable("Payment_Invoice", para);
                dgvPaymentInvoice.DataSource = dTableNew;
                //dgvPaymentInvoice.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvPaymentInvoice.Columns["SoTienDaThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvPaymentInvoice.Columns["SoThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvPaymentInvoice.Columns["SoTienconLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvPaymentInvoice.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                //DataGridViewCellStyle style = new DataGridViewCellStyle();
                //style.BackColor = Color.FromArgb(210, 180, 140);
                //style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                if (dgvPaymentInvoice.RowCount > 1)
                {
                    dgvPaymentInvoice.Rows[0].ReadOnly = true;
                    dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount - 1].ReadOnly = true;
                }
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(210, 180, 140);
                style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                dgvPaymentInvoice.Rows[0].DefaultCellStyle = style;
                dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount - 1].DefaultCellStyle = style;

                //dgvPaymentInvoice.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                //dgvPaymentInvoice.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);

                //dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount - 1].DefaultCellStyle.BackColor. = Color.FromArgb(255, 224, 192);
                //dgvPaymentInvoice.Rows[0].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);


                //dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount - 1].InheritedStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);

                //dgvPaymentInvoice.Columns["SoTienconLai"].DefaultCellStyle.Font  = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                //dgvPaymentInvoice.Columns["SoTienconLai"].DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, FontStyle.Bold);
                //dgvPaymentInvoice.Columns["SoTienconLai"].DefaultCellStyle.Format = "#,0";
                //dgvPaymentInvoice.Columns["SoTienDaThanhToan"].DefaultCellStyle.Format = "#,0";
                //dgvPaymentInvoice.Columns["SoTien"].DefaultCellStyle.Format = "#,0";
                //dgvPaymentInvoice.Columns["SoThanhToan"].DefaultCellStyle.Format = "#,0";

                if (dgvPaymentInvoice.DataSource != null && dgvPaymentInvoice.RowCount < 3)
                {
                    (dgvPaymentInvoice.DataSource as DataTable).Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Huynv – 01/10/2013 : Đẩy dữ liệu để lấy số tiền.
        /// </summary>
        private void BillDataTable()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@DateCreate", dtpDateCreate.Value);
                para[1] = posdb_vnmSqlDAC.newInParam("@LoaiTT", LoaiTT);
                dTableNew = sqlDac.GetDataTable("Money_Payment_Invoice", para);
                if (dTableNew.Rows.Count > 0)
                {
                    double money = 0;
                    double.TryParse(dTableNew.Rows[0]["ThanhTien"].ToString(), out money);
                    string s = dTableNew.Rows[0]["ThanhTien"].ToString();
                    txtMoney.Text = money > 0 ? money.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency) : "0";
                    //txtMoney.Text = Conversion.GetCurrency(Conversion.Replaces(txtMoney.Text));
                    //txtMoney.SelectionStart = txtMoney.Text.Trim().Length;
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Huynv – 01/10/2013 : đẩy dữ liệu vào combo .
        /// </summary>
        private void LoadDiscountType()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[0];
                dTableNew = sqlDac.GetDataTable("Money_Type", para);

                if (dTableNew.Rows.Count > 0)
                {
                    cboType.DataSource = dTableNew;
                    cboType.DisplayMember = "MASTER_NAME";
                    cboType.ValueMember = "MASTER_CODE";
                    cboType.SelectedIndex = 0;
                    LoaiTT = cboType.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadDiscountType': " + ex.Message);
            }

        }

        private void InsertPaymentInvoice()
        {
            try
            {
                MaTT = "CTT." + UserImformation.DeptCode + "." + dtpDateCreate.Value.ToString("yy") + ".";
                MaTT = sqlDac.GetAutoCode("CN_ThanhToan", "MaTT", MaTT);
                //float cash = (float)Convert.ToDouble(Conversion.Replaces(txtCash.Text.Trim()));
                //float cashPost = (float)Convert.ToDouble(Conversion.Replaces(txtCashPOS.Text.Trim()));  
                PaymentInvoice.PaymentInvoiceInsert(MaTT, MaCH, sNgayHD, SoHD, SoTien, GhiChu, LoaiTT, sConLai);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Insert payment invoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo thanhdh – 12/11/2013 : Kiểm tra nhập liệu.
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                double money = 0;
                double.TryParse(txtMoney.Text, out money);

                if (txtMoney.Text == "" || money <= 0)
                {
                    MessageBox.Show(Properties.rsfInvoicePayment.SavePaymentZero, translate["Msg.TitleDialog"],
                                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dgvPaymentInvoice.DataSource == null || dgvPaymentInvoice.RowCount < 3)
                {
                    MessageBox.Show(Properties.rsfInvoicePayment.SavePaymentDif1 + Environment.NewLine + Properties.rsfInvoicePayment.SavePaymentDif2, translate["Msg.TitleDialog"],
                                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dgvPaymentInvoice.RowCount > 2)
                {
                    double total = 0;
                    //DataRow[] drThanhToans = ((DataTable)dgvPaymentInvoice.DataSource).Select("[SoThanhToan] > 0 AND [SoHD]<>''");
                    //foreach (DataRow dr in drThanhToans)
                    //{
                    //    total += float.Parse(dr["SoThanhToan"].ToString());
                    //}
                    foreach (DataGridViewRow row in dgvPaymentInvoice.Rows)
                    {
                        if (row.Cells["SoHD"].Value != null && row.Cells["SoHD"].Value != DBNull.Value && row.Cells["SoHD"].Value.ToString() != ""
                            && row.Cells["SoThanhToan"].Value != null && row.Cells["SoThanhToan"].Value != DBNull.Value && row.Cells["SoThanhToan"].Value.ToString() != "")
                        {
                            //total += Math.Round(double.Parse(row.Cells["SoThanhToan"].Value.ToString()));
                            total += double.Parse(row.Cells["SoThanhToan"].Value.ToString());
                            //MessageBox.Show(float.Parse(row.Cells["SoThanhToan"].Value.ToString()).ToString());
                        }
                    }
                    if (total != money)
                    {
                        MessageBox.Show(Properties.rsfInvoicePayment.SavePaymentDif1 + Environment.NewLine + Properties.rsfInvoicePayment.SavePaymentDif2, translate["Msg.TitleDialog"],
                                                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //MessageBox.Show(total.ToString("#,0"));
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckValidate' : " + ex.Message);
            }
            return true;
        }
        #endregion
        #region control event
        private void frmPaymentInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Notice: form started.");
                Reset();
                BillPaymentInvoice();
                LoadDiscountType();
                BillDataTable();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }
        //
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BillPaymentInvoice();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void btnTableStatementMoney_Click(object sender, EventArgs e)
        {
            try
            {
                frmCashDeposit frm = new frmCashDeposit(translate);
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidate())
                {
                    MaTT = "CTT." + UserImformation.DeptCode + "." + dtpDateCreate.Value.ToString("yy") + ".";
                    MaTT = sqlDac.GetAutoCode("CN_ThanhToan", "MaTT", MaTT);
                    DataRow[] drThanhToans = ((DataTable)dgvPaymentInvoice.DataSource).Select("[SoThanhToan] > 0 AND [SoHD]<>''");
                    foreach (DataRow drTemp in drThanhToans)
                    {
                        float sSoThanhToan = 0;
                        float sSoTienConLai = 0;
                        DateTime sNgayHoaDon;
                        string sSoHoaDon;
                        sSoThanhToan = (float)Convert.ToDouble(drTemp["SoThanhToan"]);
                        sSoTienConLai = (float)Convert.ToDouble(drTemp["SoTienconLai"]);
                        sSoHoaDon = Convert.ToString(drTemp["SoHD"]).ToString();
                        sNgayHoaDon = dtpDateCreate.Value;
                        PaymentInvoice.PaymentInvoiceInsert(MaTT, MaCH, sNgayHoaDon, sSoHoaDon, sSoThanhToan, GhiChu, LoaiTT, sSoTienConLai);
                    }
                    MessageBox.Show(Properties.rsfInvoicePayment.SavePaymentOK, translate["Msg.TitleDialog"],
                                                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    BillPaymentInvoice();
                    BillDataTable();
                }
                /*
                if (MessageBox.Show("Bạn muốn lưu lại không!", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    if (dgvPaymentInvoice.RowCount > 0)
                    {
                        for (int i = 0; i <= dgvPaymentInvoice.RowCount; i++)
                        {
                            float sSoThanhToan = 0;
                            float sSoTienConLai = 0;
                            DateTime sNgayHoaDon;
                            string sSoHoaDon;
                            MaTT = "CTT." + UserImformation.DeptCode + "." + dtpDateCreate.Value.ToString("yy") + ".";
                            MaTT = sqlDac.GetAutoCode("CN_ThanhToan", "MaTT", MaTT);
                            sSoThanhToan = (float)Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value);
                            sSoTienConLai = (float)Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value);
                            sNgayHoaDon = Convert.ToDateTime(dgvPaymentInvoice.Rows[i].Cells["NgayHD"].Value.ToString());// Convert.ToDateTime("01/01/2013");
                            sSoHoaDon = Convert.ToString(dgvPaymentInvoice.Rows[i].Cells["SoHD"].Value).ToString();
                            sNgayHoaDon = Convert.ToDateTime("01/01/2013");
                            if (sSoThanhToan != 0 && sSoTienConLai != 0 && sSoTienConLai - sSoThanhToan >= 0)
                            {
                                sSoTienConLai = sSoTienConLai - sSoThanhToan;
                                PaymentInvoice.PaymentInvoiceInsert(MaTT, MaCH, sNgayHoaDon, sSoHoaDon, sSoThanhToan, GhiChu, LoaiTT, sSoTienConLai);

                            }

                        }

                    }

                }*/
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void dtpDateFromInvoice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateFromInvoice.Checked == false)
                    DateFromInvoice = Convert.ToDateTime("1900/01/01");

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void dtpDateToInvoice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateToInvoice.Checked == false)
                    DateToInvoice = Convert.ToDateTime("1900/01/01");

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void dtpDatetFromPayment_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDatetFromPayment.Checked == false)
                    DatetFromPayment = Convert.ToDateTime("1900/01/01");

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void dtpDateToPayment_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateToPayment.Checked == false)
                    DateToPayment = Convert.ToDateTime("1900/01/01");

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoaiTT = cboType.SelectedValue.ToString();
                BillDataTable();

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void dtpDateCreate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                BillDataTable();

            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            //txtMoney.Text = Conversion.GetCurrency(Conversion.Replaces(txtMoney.Text));
            //txtMoney.SelectionStart = txtMoney.Text.Trim().Length;
        }

        private void btnPhanBo_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                float sSoTienThanhToan = 0;
                try
                {
                    if (dgvPaymentInvoice.RowCount > 1)
                    {
                        for (int i = 1; i <= dgvPaymentInvoice.RowCount; i++)
                        {
                            float sSoThanhToan = 0;
                            sSoThanhToan = (float)Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value);
                            if (sSoThanhToan != 0)
                            {
                                sSoTienThanhToan = sSoTienThanhToan + sSoThanhToan;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
                }

                //
                sSoTien = (float )Convert.ToDouble(Conversion.Replaces(txtMoney.Text));// Convert.ToInt32(txtMoney.Text);
                if (sSoTienThanhToan != 0)
                {
                    sSoTien = sSoTien - sSoTienThanhToan;
                }
                if (dgvPaymentInvoice.RowCount > 0)
                {
                    for (int i = 0; i <=  dgvPaymentInvoice.RowCount ; i++)
                    {
                        if (sSoTien > 0)
                        {
                            float sSoconLai, sSoThanhToan;
                            sSoconLai = (float)Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value);
                            sSoThanhToan = (float)Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value);
                            if (sSoThanhToan == 0)
                            {
                                if (sSoTien >= sSoconLai)
                                {
                                    dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value = Convert.ToString(sSoconLai);
                                    dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value = Convert.ToString(0);
                                    sSoTien = sSoTien - sSoconLai;
                                }
                                else
                                {
                                    dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value = Convert.ToString(sSoTien);
                                    sSoTien = sSoTien - sSoconLai;
                                    dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value = Convert.ToString(sSoTien * (-1));
                                    
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    
                }*/
                if (dgvPaymentInvoice.RowCount > 2)
                {
                    double fSoTien = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                    double fSoConLai, fSoThanhToan, fTongThanhToan, fTongConLai;
                    fTongThanhToan = 0;
                    fTongConLai = 0;
                    for (int i = 1; i <= dgvPaymentInvoice.RowCount - 2; i++)
                    {
                        fSoConLai = Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value) + Convert.ToDouble(dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value);
                        if (fSoConLai > 0)
                        {
                            fSoThanhToan = fSoTien > fSoConLai ? fSoConLai : fSoTien;
                            dgvPaymentInvoice.Rows[i].Cells["SoThanhToan"].Value = fSoThanhToan;
                            dgvPaymentInvoice.Rows[i].Cells["SoTienconLai"].Value = fSoConLai - fSoThanhToan;
                            fSoTien = fSoTien - fSoThanhToan;
                            fTongThanhToan += fSoThanhToan;
                            fTongConLai += fSoConLai - fSoThanhToan;
                        }
                    }
                    txtMoney.Text = fTongThanhToan.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                    //fTongThanhToan = Convert.ToDouble(((DataTable)dgvPaymentInvoice.DataSource).Compute("Sum(SoThanhToan)", "SoHD<>''"));
                    //fTongConLai = Convert.ToDouble(((DataTable)dgvPaymentInvoice.DataSource).Compute("Sum(SoTienconLai)", "SoHD<>''"));
                    dgvPaymentInvoice.Rows[0].Cells["SoThanhToan"].Value = fTongThanhToan;
                    dgvPaymentInvoice.Rows[0].Cells["SoTienconLai"].Value = fTongConLai;
                    dgvPaymentInvoice.Rows[dgvPaymentInvoice.Rows.Count - 1].Cells["SoThanhToan"].Value = fTongThanhToan;
                    dgvPaymentInvoice.Rows[dgvPaymentInvoice.Rows.Count - 1].Cells["SoTienconLai"].Value = fTongConLai;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }
        
        private void dgvPaymentInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7) //Column ColB
            //{
            //    if (e.Value != null && !double.Parse("0.0").Equals(e.Value))
            //    {
            //        e.CellStyle.Format = "#,###";
            //    }
            //    else
            //    {
            //        e.CellStyle.Format = "0";
            //    }
            //}
        }

        private void dgvPaymentInvoice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType == ListChangedType.Reset)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    //bgcolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvPaymentInvoice.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;

                        }
                        //if (i == 1 || i == (int)Convert.ToInt16(dgvPaymentInvoice.RowCount))
                        //{
                        //    //r.DefaultCellStyle.BackColor = Color.YellowGreen;
                        //    dgvPaymentInvoice.Rows[1].DefaultCellStyle.BackColor = Color.YellowGreen;
                        //    dgvPaymentInvoice.Rows[dgvPaymentInvoice.RowCount].DefaultCellStyle.BackColor = Color.YellowGreen;

                        //}
                    }

                    //if ((int)Convert.ToInt16(dgvPaymentInvoice.CurrentRow.Index) == 1 || (int)Convert.ToInt16(dgvPaymentInvoice.CurrentRow.Index) == (int)Convert.ToInt16(dgvPaymentInvoice.RowCount))
                    //{
                    //    bgcolor.BackColor = Color.YellowGreen;
                    //}
                    
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvPaymentInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                object obj = dgvPaymentInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                double sSoTienThanhToan = obj!=DBNull.Value  ? Convert.ToDouble(obj):0;
                double fSoConLai = Convert.ToDouble(dgvPaymentInvoice.Rows[e.RowIndex].Cells["SoTienconLai"].Value) + oldPayment;

                //fSoConLai = fSoConLai > 0 ? fSoConLai : 0;
                //sSoTienThanhToan = fSoConLai > 0 ? sSoTienThanhToan : dSoTien - dSoDaTT;
                sSoTienThanhToan = sSoTienThanhToan < fSoConLai ? sSoTienThanhToan : fSoConLai;                

                dgvPaymentInvoice.Rows[e.RowIndex].Cells["SoThanhToan"].Value = sSoTienThanhToan;
                dgvPaymentInvoice.Rows[e.RowIndex].Cells["SoTienconLai"].Value = fSoConLai - sSoTienThanhToan;

                sSoTienThanhToan = 0;// Convert.ToDouble(((DataTable)dgvPaymentInvoice.DataSource).Compute("Sum(SoThanhToan)", "SoHD<>''"));
                fSoConLai = 0;//Convert.ToDouble(((DataTable)dgvPaymentInvoice.DataSource).Compute("Sum(SoTienconLai)", "SoHD<>''"));
                foreach (DataGridViewRow row in dgvPaymentInvoice.Rows)
                {
                    if (row.Cells["SoHD"].Value != null && row.Cells["SoHD"].Value != DBNull.Value && row.Cells["SoHD"].Value.ToString() != ""
                        && row.Cells["SoThanhToan"].Value != null && row.Cells["SoThanhToan"].Value != DBNull.Value && row.Cells["SoThanhToan"].Value.ToString() != ""
                        && row.Cells["SoTienconLai"].Value != null && row.Cells["SoTienconLai"].Value != DBNull.Value && row.Cells["SoTienconLai"].Value.ToString() != "")
                    {
                        sSoTienThanhToan += double.Parse(row.Cells["SoThanhToan"].Value.ToString());
                        fSoConLai += double.Parse(row.Cells["SoTienconLai"].Value.ToString()) > 0 ? double.Parse(row.Cells["SoTienconLai"].Value.ToString()) : 0;
                    }
                }

                dgvPaymentInvoice.Rows[0].Cells["SoThanhToan"].Value = sSoTienThanhToan;
                dgvPaymentInvoice.Rows[0].Cells["SoTienconLai"].Value = fSoConLai;
                dgvPaymentInvoice.Rows[dgvPaymentInvoice.Rows.Count-1].Cells["SoThanhToan"].Value = sSoTienThanhToan;
                dgvPaymentInvoice.Rows[dgvPaymentInvoice.Rows.Count - 1].Cells["SoTienconLai"].Value = fSoConLai;
            }

            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void dgvPaymentInvoice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldPayment = 0;
            double.TryParse(dgvPaymentInvoice[e.ColumnIndex, e.RowIndex].Value.ToString(), out oldPayment);
        }
        #endregion

        
    }
}

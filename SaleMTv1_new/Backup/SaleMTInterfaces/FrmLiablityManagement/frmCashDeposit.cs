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
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTBusiness.SaleManagement;
using SaleMTDataAccessLayer.SaleMTObj;



namespace SaleMTInterfaces.FrmLiablityManagement
{
    public partial class frmCashDeposit : Form
    {
        public frmCashDeposit(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.gbxThongTin.Text = translate["frmCashDeposit.gbxThongTin.Text"];
            this.label6.Text = translate["frmCashDeposit.label6.Text"];
            this.label5.Text = translate["frmCashDeposit.label5.Text"];
            this.label4.Text = translate["frmCashDeposit.label4.Text"];
            this.label3.Text = translate["frmCashDeposit.label3.Text"];
            this.label2.Text = translate["frmCashDeposit.label2.Text"];
            this.label1.Text = translate["frmCashDeposit.label1.Text"];
            this.groupBox2.Text = translate["frmCashDeposit.groupBox2.Text"];
            this.btnExport.Text = translate["frmCashDeposit.btnExport.Text"];
            this.btnClose.Text = translate["frmCashDeposit.btnClose.Text"];
            this.btnCashSearch.Text = translate["frmCashDeposit.btnCashSearch.Text"];
            this.label7.Text = translate["frmCashDeposit.label7.Text"];
            this.label8.Text = translate["frmCashDeposit.label8.Text"];
            this.btnInsert.Text = translate["frmCashDeposit.btnInsert.Text"];
            this.btnSave.Text = translate["frmCashDeposit.btnSave.Text"];
            this.btnDelete.Text = translate["frmCashDeposit.btnDelete.Text"];
            this.Ma.HeaderText = translate["frmCashDeposit.Ma.HeaderText"];
            this.Ngay.HeaderText = translate["frmCashDeposit.Ngay.HeaderText"];
            this.DienGiai.HeaderText = translate["frmCashDeposit.DienGiai.HeaderText"];
            this.SoTien.HeaderText = translate["frmCashDeposit.SoTien.HeaderText"];
            this.POS.HeaderText = translate["frmCashDeposit.POS.HeaderText"];
            this.TongCong.HeaderText = translate["frmCashDeposit.TongCong.HeaderText"];
            this.Text = translate["frmCashDeposit.Text"];
        }	

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        //CashDeposit cashdpsit = new CashDeposit();
        private DataTable dtCash = new DataTable();
        private const string EXPORT_TITLE = "NỘP TIỀN THANH TOÁN CÔNG TY";
        #endregion

        #region Constant
        private  string MaTT = "CNT.CH40171.";
        private const string TEXT_INSERT = "&Thêm mới";
        private const string TEXT_CANCEL = "&Hủy";
        private string MaCH = UserImformation.DeptCode;
        private const string TEXT_RATE = "1";
        private const int INDEX_IMAGE_1 = 0;
        private const int INDEX_IMAGE_2 = 1;
        #endregion
        #region Event button
        private void loadbutton()
        { 
            try
            {                
                    txtCash.Enabled = false;
                    txtCashPOS.Enabled = false;
                    txtContent.Enabled = false;
                    dtpDateCreate.Checked = false;
                    btnSave.Enabled = false;
                    btnExport.Enabled = false;
                    btnDelete.Enabled = false;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnInsert.Text = TEXT_INSERT;
                    MaCH = UserImformation.DeptCode;
                    groupBox2.Enabled = true;
                
                    //MaTT = "CNT." + UserImformation.DeptCode;
                    btnInsert.Focus();              
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void ReloadGrid()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@DateFrom", dtpDateFrom.Value);
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTo", dtpDateTo.Value);
                dtCash = sqlDac.GetDataTable("CashDeposit_ByDate", para);
                dgvCashDeposit.AutoGenerateColumns = false;
                dgvCashDeposit.DataSource = dtCash;
            }
            catch (Exception ex)
            {
                log.Error("Error 'ReloadGrid' : " + ex.Message);
            }
        }

        private void LoadButtonText()
        {
            try
            {
                MaTT = "CNT." + UserImformation.DeptCode + "."+ dtpDateCreate.Value.ToString("yy")+".";
                MaTT = sqlDac.GetAutoCode("CN_NopTienTT", "MaTT", MaTT);
                double cash = Convert.ToDouble(Conversion.Replaces(txtCash.Text.Trim()));
                
                double cashPost = Convert.ToDouble(Conversion.Replaces(txtCashPOS.Text.Trim()));
                
                //txtCash.Text = txtCash.Text.Replace(".", "");
                //txtCashPOS.Text = txtCashPOS.Text.Replace(".", "");
                //if (MessageBox.Show("Bạn muốn lưu lại không!", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    CashDeposit.CashdepositPayment(MaTT, dtpDateCreate.Value, false, cash, txtContent.Text, MaCH, cashPost); 
                //}              
                CashDeposit.CashdepositPayment(MaTT, dtpDateCreate.Value, false, cash, txtContent.Text, MaCH, cashPost); 
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void LoadButtonTextUpdate()
        {
            try
            {
                double cash = Convert.ToDouble(Conversion.Replaces(txtCash.Text.Trim()));
                double cashPost = Convert.ToDouble(Conversion.Replaces(txtCashPOS.Text.Trim()));

                //txtCash.Text = txtCash.Text.Replace(".", "");
                //txtCashPOS.Text = txtCashPOS.Text.Replace(".", "");
                //if (MessageBox.Show("Bạn muốn lưu lại không!", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    CashDeposit.CashdepositPayment(MaTT, dtpDateCreate.Value, false, cash, txtContent.Text, MaCH, cashPost); 
                //}              
                CashDeposit.CashdepositPaymentUpdate(MaTT, dtpDateCreate.Value, false, cash, txtContent.Text, MaCH, cashPost);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }
        private void BillDatagrid()
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@DateFrom", dtpDateFrom.Value );
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTo", dtpDateTo.Value);
                dTableNew = sqlDac.GetDataTable("CashDeposit_ById", para);
               
            }
            catch (Exception ex)
            {
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }      


        private void loadbuttonEvent()
        {
            try
            {
                if (btnInsert.Text == TEXT_INSERT)
                {
                    txtCash.Enabled = true;
                    txtCashPOS.Enabled = true;
                    txtContent.Enabled = true;
                    dtpDateCreate.Checked = true;
                    btnSave.Enabled = true;
                    btnExport.Enabled = true;
                    btnDelete.Enabled = false;
                    groupBox2.Enabled = false;
                    btnInsert.Text = TEXT_CANCEL;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_2];
                    MaTT = "";
                    // reset control
                    dtpDateCreate.Value = sqlDac.GetDateTimeServer();
                    txtCash.Text = "0";
                    txtCashPOS.Text = "0";
                    txtContent.Text = "";
                    txtCash.Focus();
                }
                else
                {
                    //btnSave.Enabled = true;
                    //btnExport.Enabled = true;
                    groupBox2.Enabled = true;
                    //btnDelete.Enabled = true;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnInsert.Text = TEXT_INSERT;
                    if (dgvCashDeposit.Rows.Count > 0)
                    {
                        dgvCashDeposit.CurrentCell = dgvCashDeposit[0, 0];
                        dgvCashDeposit.Focus();
                        MaTT = dgvCashDeposit.Rows[0].Cells["Ma"].Value.ToString();
                    }

                    btnDelete.Enabled = (dgvCashDeposit.Rows.Count > 0);
                    btnExport.Enabled = (dgvCashDeposit.Rows.Count > 0);
                    btnSave.Enabled = (dgvCashDeposit.Rows.Count > 0);
                    //txtCash.Focus();
                }
                

            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
            
        }
        private void buttonEventInsert()
        { 

        }
        #endregion

        private void frmCashDeposit_Load(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Notice: form started.");
                CashDeposit.CreateDatable(dtCash);
                loadbutton();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        #region Button click
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                loadbuttonEvent();
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (txtCash.Text == "" || txtCash.Text == "0")
                {
                    MessageBox.Show(translate["Msg.AmountNotEmpty"], translate["Msg.TitleDialog"]);
                    return;
                }
                if (MaTT == "")
                {                    
                    LoadButtonText();
                    //BillDatagrid();
                    dgvCashDeposit.DataSource = CashDeposit.AddRowDatatable(MaTT, dtCash, sqlDac);
                    btnInsert.Text = TEXT_INSERT;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnSave.Enabled = false;
                    MaTT = "";
                    MessageBox.Show(Properties.rsfSales.CreateSuccess, Properties.rsfSales.Notice,
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    LoadButtonTextUpdate();
                    //BillDatagrid();
                    dgvCashDeposit.DataSource = CashDeposit.AddRowDatatable(MaTT, dtCash, sqlDac);
                    //dgvCashDeposit.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvCashDeposit.Columns["POS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvCashDeposit.Columns["TongCong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    btnInsert.Text = TEXT_INSERT;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnSave.Enabled = false;
                    MaTT = "";
                    MessageBox.Show(Properties.rsfSales.EditSuccess, Properties.rsfSales.Notice,
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                groupBox2.Enabled = true;
                ReloadGrid();

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvCashDeposit.CurrentRow != null)
                {
                    MaTT = dgvCashDeposit.Rows[dgvCashDeposit.CurrentRow.Index].Cells["Ma"].Value.ToString();
                    CN_NopTienTT cntt = new CN_NopTienTT();
                    cntt.MaTT = this.MaTT;
                    cntt.Delete();
                    ReloadGrid();
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCashDeposit.Rows.Count > 0)
                {
                    ExportExcel ex = new ExportExcel();
                    ex.InfoCompany = true;
                    ex.InfoStore = true;
                    ex.StrTitle = EXPORT_TITLE;
                    ex.Dgv = this.dgvCashDeposit;
                    ex.CaseEx = 4;
                    ex.FileNames = EXPORT_TITLE + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    int[] col = { 2 };
                    ex.ArrSum = col;
                    ex.RSumQuantity = 1;
                    ex.StrDate = "TỪ NGÀY: " + dtpDateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " ĐẾN NGÀY: " + dtpDateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    ex.ExportExcels();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
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
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnCashSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ReloadGrid();
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCash.Text = Conversion.GetCurrency(Conversion.Replaces(txtCash.Text));
                txtCash.SelectionStart = txtCash.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
            
        }

        private void txtCashPOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCashPOS.Text = Conversion.GetCurrency(Conversion.Replaces(txtCashPOS.Text));
                txtCashPOS.SelectionStart = txtCashPOS.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void dgvCashDeposit_SelectionChanged(object sender, EventArgs e)
        {            
            try
            {
                if (dgvCashDeposit.CurrentRow != null)
                {
                    int i = dgvCashDeposit.CurrentRow.Index;
                    if (dgvCashDeposit.Rows[i].Cells["Ngay"].Value != null && dgvCashDeposit.Rows[i].Cells["Ngay"].Value.ToString().Trim() != "")
                    {
                        MaTT = dgvCashDeposit.Rows[i].Cells["Ma"].Value.ToString();
                        txtCash.Text = dgvCashDeposit.Rows[i].Cells["SoTien"].Value.ToString();
                        txtCashPOS.Text = dgvCashDeposit.Rows[i].Cells["POS"].Value.ToString();
                        txtContent.Text = dgvCashDeposit.Rows[i].Cells["DienGiai"].Value.ToString();
                        dtpDateCreate.Value = Convert.ToDateTime(dgvCashDeposit.Rows[i].Cells["Ngay"].Value.ToString());
                    }

                    if (dgvCashDeposit.CurrentRow.Index >= 0)
                    {
                        dtpDateCreate.Enabled = true;
                        txtCash.Enabled = true;
                        txtCashPOS.Enabled = true;
                        txtContent.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void dgvCashDeposit_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvCashDeposit.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;                            
                        }
                    }
                }
                btnDelete.Enabled = (dgvCashDeposit.Rows.Count > 0);
                btnExport.Enabled = (dgvCashDeposit.Rows.Count > 0);
                btnSave.Enabled = (dgvCashDeposit.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    }
}

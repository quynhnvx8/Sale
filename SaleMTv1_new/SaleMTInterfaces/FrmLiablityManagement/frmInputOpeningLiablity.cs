using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTBusiness;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using SaleMTBusiness.SaleManagement;
using System.Data.OleDb;
using System.IO;



namespace SaleMTInterfaces.FrmLiablityManagement
{
    public partial class frmInputOpeningLiablity : Form
    {
        public frmInputOpeningLiablity(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxThongTinCongNo.Text = translate["frmInputOpeningLiablity.gbxThongTinCongNo.Text"];
            this.label7.Text = translate["frmInputOpeningLiablity.label7.Text"];
            this.label4.Text = translate["frmInputOpeningLiablity.label4.Text"];
            this.label5.Text = translate["frmInputOpeningLiablity.label5.Text"];
            this.label6.Text = translate["frmInputOpeningLiablity.label6.Text"];
            this.label27.Text = translate["frmInputOpeningLiablity.label27.Text"];
            this.label42.Text = translate["frmInputOpeningLiablity.label42.Text"];
            this.label2.Text = translate["frmInputOpeningLiablity.label2.Text"];
            this.label1.Text = translate["frmInputOpeningLiablity.label1.Text"];
            this.label3.Text = translate["frmInputOpeningLiablity.label3.Text"];
            this.gbxDanhSach.Text = translate["frmInputOpeningLiablity.gbxDanhSach.Text"];
            this.SoHD.HeaderText = translate["frmInputOpeningLiablity.SoHD.HeaderText"];
            this.SoPO.HeaderText = translate["frmInputOpeningLiablity.SoPO.HeaderText"];
            this.SoNoiBo.HeaderText = translate["frmInputOpeningLiablity.SoNoiBo.HeaderText"];
            this.NgayHoaDon.HeaderText = translate["frmInputOpeningLiablity.NgayHoaDon.HeaderText"];
            this.SoTien.HeaderText = translate["frmInputOpeningLiablity.SoTien.HeaderText"];
            this.SoTienDaThanhToan.HeaderText = translate["frmInputOpeningLiablity.SoTienDaThanhToan.HeaderText"];
            this.SoTienConLai.HeaderText = translate["frmInputOpeningLiablity.SoTienConLai.HeaderText"];
            this.GhiChu.HeaderText = translate["frmInputOpeningLiablity.GhiChu.HeaderText"];
            this.NgayTT.HeaderText = translate["frmInputOpeningLiablity.NgayTT.HeaderText"];
            this.btnImport.Text = translate["frmInputOpeningLiablity.btnImport.Text"];
            this.btnInsert.Text = translate["frmInputOpeningLiablity.btnInsert.Text"];
            this.btnSave.Text = translate["frmInputOpeningLiablity.btnSave.Text"];
            this.btnDelete.Text = translate["frmInputOpeningLiablity.btnDelete.Text"];
            this.btnClose.Text = translate["frmInputOpeningLiablity.btnClose.Text"];
            this.gbxImport.Text = translate["frmInputOpeningLiablity.gbxImport.Text"];
            this.label10.Text = translate["frmInputOpeningLiablity.label10.Text"];
            this.lblSum.Text = translate["frmInputOpeningLiablity.lblSum.Text"];
            this.lblStatus.Text = translate["frmInputOpeningLiablity.lblStatus.Text"];
            this.btnSampleExcel.Text = translate["frmInputOpeningLiablity.btnSampleExcel.Text"];
            this.btnBegin.Text = translate["frmInputOpeningLiablity.btnBegin.Text"];
            this.label8.Text = translate["frmInputOpeningLiablity.label8.Text"];
            this.label9.Text = translate["frmInputOpeningLiablity.label9.Text"];
            this.Text = translate["frmInputOpeningLiablity.Text"];
        }	

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        DataTable dt;
        #region Constant
        //private string SoHoaDon;
        private const string TEXT_INSERT = "&Thêm mới";
        private const string TEXT_CANCEL = "&Hủy";
        private string MaCH = UserImformation.DeptCode;
        private const string TEXT_RATE = "1";
        private const int INDEX_IMAGE_1 = 0;
        private const int INDEX_IMAGE_2 = 1;
        int Check = 0;
        #endregion
        #region Event button
        private void loadbutton()
        {
            try
            {
                //gbxThongTinCongNo.Enabled  = false;
                btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                btnInsert.Text = TEXT_INSERT;
                btnInsert.Focus();

            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void loadbuttonEvent()
        {
            try
            {
                if (btnInsert.Text == TEXT_INSERT)
                {
                    gbxThongTinCongNo.Enabled = true;                    
                    btnSave.Enabled = true;                    
                    btnDelete.Enabled = false;
                    btnImport.Enabled = false;
                    gbxDanhSach.Enabled = false;
                    btnInsert.Text = TEXT_CANCEL;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_2];
                    Check = 1;
                    ResetButton();
                }
                else
                {
                    gbxThongTinCongNo.Enabled = true;
                    btnImport.Enabled = true;
                    gbxDanhSach.Enabled = true;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnInsert.Text = TEXT_INSERT;
                    Check = 2;
                    if (dgvOpenliabilities.Rows.Count > 0)
                    {
                        dgvOpenliabilities.CurrentCell = dgvOpenliabilities[0, 0];
                        dgvOpenliabilities.Focus();
                        EventGrid();
                    }
                    btnDelete.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                    btnSave.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                }


            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }

        }
        private void ResetButton()
        {
            try
            {
                txtInvoices.Text = "";
                dtpInvoicesDate.Value = DateTime.Now;
                dtpPaymentDate.Value = DateTime.Now;
                txtAmount.Text = "0";
                txtInternal.Text = "";
                txtPO.Text = "";
                txtPaymented.Text = "0";
                txtRest.Text = "0";
                txtInvoices.Focus();

            }

            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }
        private void EventFormat()
        {
            try
            {
                if (Check == 1)
                {
                    float Amount = (float)Convert.ToDouble(Conversion.Replaces(txtAmount.Text.Trim()));
                    float Payment = (float)Convert.ToDouble(Conversion.Replaces(txtPaymented.Text.Trim()));
                    float Rest = (float)Convert.ToDouble(Conversion.Replaces(txtRest.Text.Trim()));
                    InputOpeningLiablity.InputOpeningLiablityInSert(txtInvoices.Text, dtpInvoicesDate.Value, MaCH, dtpPaymentDate.Value, Amount, Payment, false, txtNote.Text,
                        txtPO.Text, txtInternal.Text, Rest, 0, "");
                    Check = 0;

                }
                else
                {
                    float Amount = (float)Convert.ToDouble(Conversion.Replaces(txtAmount.Text.Trim()));
                    float Payment = (float)Convert.ToDouble(Conversion.Replaces(txtPaymented.Text.Trim()));
                    float Rest = (float)Convert.ToDouble(Conversion.Replaces(txtRest.Text.Trim()));
                    InputOpeningLiablity.InputOpeningLiablityUpdate(txtInvoices.Text, dtpInvoicesDate.Value, MaCH, dtpPaymentDate.Value, Amount, Payment, false, txtNote.Text,
                        txtPO.Text, txtInternal.Text, Rest, 0, "");

                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }
        private void EventGrid()
        {
            try
            {
                if (dgvOpenliabilities.RowCount > 0)
                {
                    txtInvoices.Text = dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoHD"].Value.ToString();
                    txtInternal.Text = dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoNoiBo"].Value.ToString();
                    txtPO.Text = dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoPO"].Value.ToString();
                    txtAmount.Text = Convert.ToString(dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoTien"].Value.ToString());
                    txtPaymented.Text = Convert.ToString(dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoTienDaThanhToan"].Value.ToString());
                    txtRest.Text = Convert.ToString(dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["SoTienConLai"].Value.ToString());
                    dtpInvoicesDate.Value = Convert.ToDateTime(dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["NgayHoaDon"].Value.ToString());
                    txtNote.Text = dgvOpenliabilities.Rows[dgvOpenliabilities.CurrentRow.Index].Cells["GhiChu"].Value.ToString();

                }
                else
                {


                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
            
        }

        #endregion

        #region Methor/Event
        private void BillDataGrid()
        {
            try
            {
                dt = new DataTable();
                dt = InputOpeningLiablity.LoadDatable(sqlDac);
                dgvOpenliabilities.AutoGenerateColumns = false;
                dgvOpenliabilities.DataSource = dt;
                dgvOpenliabilities.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOpenliabilities.Columns["SoTienDaThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOpenliabilities.Columns["SoTienConLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                log.Error("Error 'bill data grid' : " + ex.Message);
            }
        }
        private void EventSave()
        {
            try
            {
                if (Check == 1)//Thêm mới
                {
                    if (txtInvoices.Text == "")
                    {
                        MessageBox.Show(translate["Msg.InvoiceNotEmpty"], translate["Msg.TitleDialog"]);
                        txtInvoices.Focus();
                        return;
                    }
                    else
                    {
                        DataTable dtCheck = new DataTable();
                        dtCheck = InputOpeningLiablity.LoadDatableCheckInvoice(txtInvoices.Text, sqlDac);
                        int kiemtra;
                        kiemtra = (int)Convert.ToInt16(dtCheck.Rows[0]["Dem"]);
                        if (kiemtra > 0)
                        {
                            MessageBox.Show(translate["Msg.InvoiceExists"], translate["Msg.TitleDialog"]);
                            return;
                        }
                    }
                    EventFormat();
                    BillDataGrid();

                }
                else
                {
                    if (txtInvoices.Text == "")
                    {
                        MessageBox.Show(translate["Msg.InvoiceNotEmpty"], translate["Msg.TitleDialog"]);
                        txtInvoices.Focus();
                        return;
                    }
                    else
                    {
                        EventFormat();
                        BillDataGrid();
                    }
                }
            }

            catch (Exception ex)
            {
                log.Error("Error 'save input opening liablity' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin file excel
        /// </summary>
        private void LoadExcel()
        {
            try
            {
                if (CheckValidate())
                {
                    lblStatus.Text = "Lấy dữ liệu";
                    this.Refresh();
                    string sqlQuery = string.Format("select * from [{0}$]", cboSheet.SelectedItem.ToString());
                    OleDbConnection objConnection = new OleDbConnection();
                    objConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtPath.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";");
                    objConnection.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, objConnection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //ds.Tables[0].DefaultView.RowFilter = "ProductCode <> '' AND ProductCode is not null";
                    lblStatus.Text = "Hoàn tất lấy dữ liệu";
                    this.Refresh();
                    DataTable dtImported = new DataTable();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // tạo table mới                        
                        dtImported.Columns.Add("SoHoaDon", typeof(string));
                        dtImported.Columns.Add("SoPO", typeof(string));
                        dtImported.Columns.Add("SoNoiBo", typeof(string));
                        dtImported.Columns.Add("NgayHoaDon", typeof(string));
                        dtImported.Columns.Add("SoTien", typeof(string));
                        dtImported.Columns.Add("SoTienDaThanhToan", typeof(string));
                        dtImported.Columns.Add("SoTienConLai", typeof(string));
                        dtImported.Columns.Add("GhiChu", typeof(string));
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i][0].ToString().Trim() != "" && ds.Tables[0].Rows[i][0] != null)
                            {
                                //ds.Tables[0].Rows[i][3] = ds.Tables[0].Rows[i][3].ToString() + "/" + ds.Tables[0].Rows[i][4].ToString() + "/" + ds.Tables[0].Rows[i][5].ToString();
                                double money;
                                double pay;
                                bool result1 = double.TryParse(ds.Tables[0].Rows[i][6].ToString().Trim(), out money);
                                bool result2 = double.TryParse(ds.Tables[0].Rows[i][7].ToString().Trim(), out pay);
                                if (!result1 || !result2)
                                    ds.Tables[0].Rows.RemoveAt(i);
                                else
                                {
                                    DataRow dr = dtImported.NewRow();
                                    dr["SoHoaDon"] = ds.Tables[0].Rows[i][0].ToString().Trim();
                                    dr["SoPO"] = ds.Tables[0].Rows[i][1].ToString().Trim();
                                    dr["SoNoiBo"] = ds.Tables[0].Rows[i][2].ToString().Trim();
                                    dr["NgayHoaDon"] = ds.Tables[0].Rows[i][3].ToString() + "/" + ds.Tables[0].Rows[i][4].ToString() + "/" + ds.Tables[0].Rows[i][5].ToString();
                                    dr["SoTien"] = money;
                                    dr["SoTienDaThanhToan"] = pay;
                                    dr["SoTienConLai"] = money - pay;
                                    dr["GhiChu"] = ds.Tables[0].Rows[i][8].ToString().Trim();
                                    dtImported.Rows.Add(dr);
                                }
                            }
                            else
                            {
                                ds.Tables[0].Rows.RemoveAt(i);
                                i = i - 1;
                            }
                        }
                    }                    
                    lblStatus.Text = "Hiền thị dữ liệu";
                    this.Refresh();
                    dgvOpenliabilities.AutoGenerateColumns = false;
                    dgvOpenliabilities.DataSource = dtImported;
                    if (dgvOpenliabilities.RowCount > 0)
                        lblCount.Text = dgvOpenliabilities.RowCount.ToString();
                    objConnection.Close();
                    objConnection.Dispose();
                    pbrProcess.Value = 100;
                    lblStatus.Text = "Hoàn tất";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadExcel' : " + ex.Message);
                MessageBox.Show(Properties.rsfInventoryImport.Inventory4, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm, lấy đường dẫn file excel
        /// </summary>
        private void OpenExcel()
        {
            try
            {
                OpenFileDialog openExcel = new OpenFileDialog();
                openExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openExcel.Multiselect = false;
                openExcel.ValidateNames = true;
                openExcel.DereferenceLinks = false; // Will return .lnk in shortcuts.
                openExcel.Filter = "Excel |*.xls|All files |*.*";
                openExcel.FileOk += new System.ComponentModel.CancelEventHandler(OpenKeywordsFileDialog_FileOk);
                var dialogResult = openExcel.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtPath.Text = openExcel.FileName;
                    List<string> sheet = ImportEx.GetSheet(openExcel.FileName);
                    cboSheet.Items.Clear();
                    foreach (string s in sheet)
                    {
                        cboSheet.Items.Add(s);
                    }
                    if (sheet.Count > 0)
                        cboSheet.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenExcel' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Kiểm tra nhập liệu
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                dgvOpenliabilities.DataSource = null;
                lblCount.Text = "0";
                lblStatus.Text = "";
                pbrProcess.Value = 0;
                if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (cboSheet.Items.Count <= 0)
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory3.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (!File.Exists(txtPath.Text.Trim()))
                {
                    MessageBox.Show(string.Format(Properties.rsfInventoryImport.Inventory1.ToString(), txtPath.Text.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckValidate' : " + ex.Message);
                return false;
            }
        }
        
        #endregion
        #region Event
        private void frmInputOpeningLiablity_KeyDown(object sender, KeyEventArgs e)
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
                log.Error("Error 'Load button text Cash deposit' : " + ex.Message);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = Conversion.GetCurrency(Conversion.Replaces(txtAmount.Text));
                txtAmount.SelectionStart = txtAmount.Text.Trim().Length;
                float srest;
                srest = (float)Convert.ToDouble(Conversion.Replaces(txtAmount.Text.Trim())) -
                    (float)Convert.ToDouble(Conversion.Replaces(txtPaymented.Text.Trim())); ;
                txtRest.Text = Convert.ToString(srest);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void txtPaymented_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPaymented.Text = Conversion.GetCurrency(Conversion.Replaces(txtPaymented.Text));
                txtPaymented.SelectionStart = txtPaymented.Text.Trim().Length;
                float srest;
                srest = (float)Convert.ToDouble(Conversion.Replaces(txtAmount.Text.Trim())) -
                    (float)Convert.ToDouble(Conversion.Replaces(txtPaymented.Text.Trim())); ;
                txtRest.Text = Convert.ToString(srest);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void txtRest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRest.Text = Conversion.GetCurrency(Conversion.Replaces(txtRest.Text));
                txtRest.SelectionStart = txtRest.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void dgvOpenliabilities_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EventGrid();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit' : " + ex.Message);
            }
        }

        private void frmInputOpeningLiablity_Load(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Notice: form started.");
                loadbutton();
                BillDataGrid();
                gbxThongTinCongNo.Visible = true;
                gbxImport.Visible = false;
            }
            
            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                loadbuttonEvent();
            }

            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // lưu dữ liệu nhập trực tiếp
                if (btnImport.ImageIndex == 0)
                {
                    EventSave();
                    gbxThongTinCongNo.Enabled = true;
                    btnImport.Enabled = true;
                    gbxDanhSach.Enabled = true;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnInsert.Text = TEXT_INSERT;
                    Check = 2;
                    if (dgvOpenliabilities.Rows.Count > 0)
                    {
                        dgvOpenliabilities.CurrentCell = dgvOpenliabilities[0, 0];
                        dgvOpenliabilities.Focus();
                        EventGrid();
                    }
                    btnDelete.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                    btnSave.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                }
                else // lưu dữ liệu import
                {
                    for (int i = 0; i < dgvOpenliabilities.Rows.Count; i++)
                    {
                        string soHD = dgvOpenliabilities.Rows[i].Cells["SoHD"].Value.ToString();
                        string soNB = dgvOpenliabilities.Rows[i].Cells["SoNoiBo"].Value.ToString();
                        string MaCH = UserImformation.DeptCode;                        
                        DateTime NgayHD = Convert.ToDateTime(dgvOpenliabilities.Rows[i].Cells["NgayHoaDon"].Value.ToString());
                        DateTime NgayTT = NgayHD.AddDays(15);
                        float amount = (float)Convert.ToDouble(dgvOpenliabilities.Rows[i].Cells["SoTien"].Value.ToString());
                        float payment = (float)Convert.ToDouble(dgvOpenliabilities.Rows[i].Cells["SoTienDaThanhToan"].Value.ToString());
                        string note = dgvOpenliabilities.Rows[i].Cells["GhiChu"].Value.ToString();
                        string soPO = dgvOpenliabilities.Rows[i].Cells["SoPO"].Value.ToString();                        
                        float rest = (float)Convert.ToDouble(dgvOpenliabilities.Rows[i].Cells["SoTienConLai"].Value.ToString());
                        InputOpeningLiablity.InputOpeningLiablityInSert(soHD, NgayHD, MaCH, NgayTT, amount, payment, false, note, soPO, soNB, rest, 0, "");                        
                    }
                    MessageBox.Show(Properties.rsfLiablity.SaveSuccess, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    btnImport.ImageIndex = 0;
                    btnImport.Text = "Import";
                    gbxThongTinCongNo.Visible = true;
                    gbxImport.Visible = false;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        BillDataGrid();
                        btnDelete.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                        btnInsert.Enabled = true;
                    }

                }
            }

            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoices.Text == "")
                {
                    MessageBox.Show(translate["Msg.MustBeSelected"], translate["Msg.TitleDialog"]);
                    txtInvoices.Focus();
                    return;
                }
                else
                {
                    InputOpeningLiablity.InputOpeningLiablityDelete(txtInvoices.Text);
                    BillDataGrid();
                }
            }

            catch (Exception ex)
            {
                log.Error("Error 'load input opening liablity' : " + ex.Message);
            }
        }
       

        private void dgvOpenliabilities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 5 || e.ColumnIndex == 4) //Column ColB
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
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOpenliabilities_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new  DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvOpenliabilities.Rows)
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

        private void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                LoadExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {                
                bool visi = gbxThongTinCongNo.Visible;
                gbxThongTinCongNo.Visible = (visi)?false:true;
                gbxImport.Visible = (visi)?true:false;
                if (btnImport.ImageIndex == 0)
                {
                    btnImport.ImageIndex = 1;
                    btnImport.Text = "Hủy bỏ";
                    btnInsert.Enabled = false;
                    btnDelete.Enabled = false;
                    dt = (DataTable)dgvOpenliabilities.DataSource;
                    dgvOpenliabilities.DataSource = null;

                }
                else
                {
                    btnImport.ImageIndex = 0;
                    btnImport.Text = "Import";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgvOpenliabilities.AutoGenerateColumns = false;
                        dgvOpenliabilities.DataSource = dt;
                        btnDelete.Enabled = (dgvOpenliabilities.Rows.Count > 0);
                        btnInsert.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void OpenKeywordsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog fileDialog = sender as OpenFileDialog;
            string selectedFile = fileDialog.FileName;
            if (string.IsNullOrEmpty(selectedFile) || selectedFile.Contains(".lnk"))
            {
                MessageBox.Show("Please select a valid Excel File", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
            }
            return;
        }

        private void btnSampleExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSample = new DataTable();
                dtSample.Columns.Add("Số hóa đơn".ToUpper(), typeof(string));
                dtSample.Columns.Add("Số PO".ToUpper(), typeof(string));
                dtSample.Columns.Add("Số nội bộ".ToUpper(), typeof(string));
                dtSample.Columns.Add("Ngày hóa đơn".ToUpper(), typeof(string));
                dtSample.Columns.Add("Tháng hóa đơn".ToUpper(), typeof(string));
                dtSample.Columns.Add("Năm hóa đơn".ToUpper(), typeof(string));
                dtSample.Columns.Add("Số tiền".ToUpper(), typeof(string));
                dtSample.Columns.Add("Đã thanh toán".ToUpper(), typeof(string));
                dtSample.Columns.Add("Ghi chú".ToUpper(), typeof(string));
                Export ex = new Export();
                ex.ExportSample(dtSample, "LIST_RECEIPT_PAYMENT_IMPORT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls");
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    }
}

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
using SaleMTBusiness.SaleManagement;
using SaleMTBusiness.CustomerManagement;

namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 01/10/2013 : Tìm kiếm khách hàng  .
    /// </summary>
    public partial class frmCustomerSearch : Form
    {
        #region Declaration
        private string sexPrifix = Properties.rsfMasterCode.Sex.ToString();
        private string relPrifix = Properties.rsfMasterCode.Relligion.ToString();
        private string bloPrifix = Properties.rsfMasterCode.Blood.ToString();
        private string racPrefix = Properties.rsfMasterCode.Race.ToString();
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private CUSTOMERS customer;
        private int rows;
        public CUSTOMERS Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        #endregion

        #region Contructor
      
        public frmCustomerSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxTimKiem.Text = translate["frmCustomerSearch.gbxTimKiem.Text"];
            this.btnSearch.Text = translate["frmCustomerSearch.btnSearch.Text"];
            this.label11.Text = translate["frmCustomerSearch.label11.Text"];
            this.label10.Text = translate["frmCustomerSearch.label10.Text"];
            this.label9.Text = translate["frmCustomerSearch.label9.Text"];
            this.label8.Text = translate["frmCustomerSearch.label8.Text"];
            this.label7.Text = translate["frmCustomerSearch.label7.Text"];
            this.label6.Text = translate["frmCustomerSearch.label6.Text"];
            this.label5.Text = translate["frmCustomerSearch.label5.Text"];
            this.chkActive.Text = translate["frmCustomerSearch.chkActive.Text"];
            this.label4.Text = translate["frmCustomerSearch.label4.Text"];
            this.label3.Text = translate["frmCustomerSearch.label3.Text"];
            this.label2.Text = translate["frmCustomerSearch.label2.Text"];
            this.label1.Text = translate["frmCustomerSearch.label1.Text"];
            this.gbxDanhSach.Text = translate["frmCustomerSearch.gbxDanhSach.Text"];
            this.clnSTT.HeaderText = translate["frmCustomerSearch.clnSTT.HeaderText"];
            this.clnCustomerCode.HeaderText = translate["frmCustomerSearch.clnCustomerCode.HeaderText"];
            this.clnOldCode.HeaderText = translate["frmCustomerSearch.clnOldCode.HeaderText"];
            this.clnFirstName.HeaderText = translate["frmCustomerSearch.clnFirstName.HeaderText"];
            this.clnLastName.HeaderText = translate["frmCustomerSearch.clnLastName.HeaderText"];
            this.clnPhoneNumber.HeaderText = translate["frmCustomerSearch.clnPhoneNumber.HeaderText"];
            this.clnBirthDate.HeaderText = translate["frmCustomerSearch.clnBirthDate.HeaderText"];
            this.clnIDNO.HeaderText = translate["frmCustomerSearch.clnIDNO.HeaderText"];
            this.clnTelephone.HeaderText = translate["frmCustomerSearch.clnTelephone.HeaderText"];
            this.clnEmail.HeaderText = translate["frmCustomerSearch.clnEmail.HeaderText"];
            this.clnAdress.HeaderText = translate["frmCustomerSearch.clnAdress.HeaderText"];
            this.clnPlace.HeaderText = translate["frmCustomerSearch.clnPlace.HeaderText"];
            this.btnOK.Text = translate["frmCustomerSearch.btnOK.Text"];
            this.btnClose.Text = translate["frmCustomerSearch.btnClose.Text"];
            this.btnGoPage.Text = translate["frmCustomerSearch.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmCustomerSearch.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmCustomerSearch.lblPage.Text"];
            this.label12.Text = translate["frmCustomerSearch.label12.Text"];
            this.Text = translate["frmCustomerSearch.Text"];
        }	

        #endregion

        #region Method/Function

        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        private void DoPaging()
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');

                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;


                int rowOnPage = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());


                lblPage.Text = currentPage.ToString() + "/" + pageCount.ToString() + " Trang";

                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                DataTable gridTable = (DataTable)dgvCustomer.DataSource;
                gridTable.DefaultView.RowFilter = "STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString();

                btnFirst.Enabled = (currentPage > 1);
                btnPrev.Enabled = (currentPage > 1);
                btnNext.Enabled = (currentPage < pageCount);
                btnLast.Enabled = (currentPage < pageCount);
                if (dgvCustomer.Rows.Count > 0)
                {
                    dgvCustomer.Rows[0].Cells[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'DoPaging': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        private void SetValueEntities()
        {
            try
            {
                DataGridViewRow row = dgvCustomer.CurrentCell.OwningRow;
                Customer.CUSTOMER_ID = row.Cells["clnCustomerCode"].Value.ToString();
                Customer.FIRST_NAME = row.Cells["clnFirstName"].Value.ToString();
                Customer.LAST_NAME = row.Cells["clnLastName"].Value.ToString();
                Customer.ADDRESS = row.Cells["clnAdress"].Value.ToString();
                Customer.MOBILE_PHONE = row.Cells["clnPhoneNumber"].Value.ToString();
                if (row.Cells["clnBirthDate"].Value.ToString() != "")
                {
                    Customer.DATE_OF_BIRTH = Conversion.stringToDateTime(row.Cells["clnBirthDate"].Value.ToString());
                }
                else
                { 
                    Customer.DATE_OF_BIRTH = null;
                }                
                Customer.ID_NO = row.Cells["clnIdNo"].Value.ToString();
                Customer.EMAIL_ADDRESS = row.Cells["clnEmail"].Value.ToString();
                Customer.DEPT_CODE = (int)row.Cells["clnPlace"].Value;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueEntities': " + ex.Message);
            }
        }
        
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 11/10/2013 : form load.
        /// </summary>
        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                CustomerManager.LoadMasterCode(cboBlood, bloPrifix);
                CustomerManager.LoadMasterCode(cboReligious, relPrifix);
                CustomerManager.LoadMasterCode(cboSex, sexPrifix);
                CustomerManager.LoadMasterCode(cboRace, racPrefix);
                txtFullName.Focus();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 11/10/2013 : Tìm kiếm khách hàng  .
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int year = (txtBirthYear.Text.Trim() != "") ? Convert.ToInt32(txtBirthYear.Text.Trim()) : 0;
                string sex = (cboSex.SelectedValue != null) ? cboSex.SelectedValue.ToString() : "";
                string rel = (cboReligious.SelectedValue != null) ? cboReligious.SelectedValue.ToString() : "";
                string blo = (cboBlood.SelectedValue != null) ? cboBlood.SelectedValue.ToString() : "";
                string rac = (cboRace.SelectedValue != null) ? cboRace.SelectedValue.ToString() : "";
                SqlParameter[] paraSearch = new SqlParameter[14];
                paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCustomerCode.Text.Trim());
                paraSearch[1] = posdb_vnmSqlDAC.newInParam("@FULLNAME", txtFullName.Text.Trim());
                paraSearch[2] = posdb_vnmSqlDAC.newInParam("@BIRTHYEAR", year);
                paraSearch[3] = posdb_vnmSqlDAC.newInParam("@SEX_CODE", sex.Trim());
                paraSearch[4] = posdb_vnmSqlDAC.newInParam("@RELIGION_CODE", rel.Trim());
                paraSearch[5] = posdb_vnmSqlDAC.newInParam("@BLOOD_CODE", blo.Trim());
                paraSearch[6] = posdb_vnmSqlDAC.newInParam("@RACE_CODE", rac.Trim());
                paraSearch[7] = posdb_vnmSqlDAC.newInParam("@ID_NO", txtIDNo.Text.Trim());
                paraSearch[8] = posdb_vnmSqlDAC.newInParam("@PASSPORT_NO", txtPassport.Text.Trim());
                paraSearch[9] = posdb_vnmSqlDAC.newInParam("@TEL", txtTel.Text.Trim());
                paraSearch[10] = posdb_vnmSqlDAC.newInParam("@MOBILE_PHONE", txtMobile.Text.Trim());
                paraSearch[11] = posdb_vnmSqlDAC.newInParam("@EMAIL_ADDRESS", txtEmail.Text.Trim());
                paraSearch[12] = posdb_vnmSqlDAC.newInParam("@ADDRESS", txtAdress.Text.Trim());
                paraSearch[13] = posdb_vnmSqlDAC.newInParam("@IS_ACTIVE", !chkActive.Checked);
                DataTable dtCus = sqlDac.GetDataTable("CUSTOMERS_SearchAdvanced", paraSearch);

                customer = new CUSTOMERS();
                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = dtCus;

                rows = dgvCustomer.Rows.Count;
                lblTotalRow.Text = "Tổng: " + rows.ToString() + " dòng";
                cboRowOnPage.SelectedIndex = 0;

                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblPage.Text = (rows > 0) ? "1/" + pageCount.ToString() + " Trang" : "0/0 Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xác nhận chọn khách hàng  .
        /// </summary>
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null)
                {
                    SetValueEntities();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xác nhận chọn khách hàng  .
        /// </summary>
        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SetValueEntities();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Thay đổi màu nền từng dòng trên Datagridview  .
        /// </summary>
        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvCustomer.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvCustomer.Rows)
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
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Đóng form tìm kiếm khách hàng  .
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Trở về trang đầu  .
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblPage.Text = "1/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Trở về trang trước  .
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = (currentPage - 1).ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chuyển sang trang kế tiếp  .
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int currentPage = (spl.Length > 0) ? Convert.ToInt32(spl[0]) : 1;
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = (currentPage + 1).ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chuyển đến trang cuối  .
        /// </summary>
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                string[] spl = page.Split('/');
                int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                lblPage.Text = pageCount.ToString() + "/" + pageCount.ToString() + " Trang";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn các ký tự không hợp lệ  .
        /// </summary>
        private void txtPageGo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtPageGo.Text.Trim().Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chuyển đến trang người dùng nhập vào  .
        /// </summary>
        private void btnGoPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPageGo.Text.Trim() != "")
                {
                    string page = lblPage.Text.Replace("Trang", "").Replace("trang", "").Trim();
                    string[] spl = page.Split('/');
                    int pageCount = (spl.Length > 1) ? Convert.ToInt32(spl[1]) : 1;
                    int cur = Convert.ToInt32(txtPageGo.Text.Trim());
                    lblPage.Text = cur.ToString() + "/" + pageCount.ToString() + " Trang";
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Định dạng lại số dòng trên 1 trang  .
        /// </summary>
        private void cboRowOnPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.Rows.Count > 1)
                {
                    int rowOnPage = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                    int pageCount = rows % rowOnPage != 0 ? rows / rowOnPage + 1 : rows / rowOnPage;
                    lblPage.Text = "1/" + pageCount.ToString() + " Trang";
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý khi nhấn phím ESC đóng form.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("ProcessCmdKey - error: " + ex.Message);
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Ghi file log đã đóng form.         
        /// </summary>
        private void frmCustomerSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SetValueEntities();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;




namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 01/10/2013 : Tìm kiếm khách hàng  .
    /// </summary>
    public partial class dlgSearchCustomer : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtCustormer;
        private CUSTOMERS customer;
        private int rows;
        public DataTable DtCustormer
        {
            get { return dtCustormer; }
            set { dtCustormer = value; }
        }
        
        public CUSTOMERS Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        #endregion

        #region Contructor
        
        public dlgSearchCustomer(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbListCustomer.Text = translate["dlgSearchCustomer.gbListCustomer.Text"];
            this.clnSTT.HeaderText = translate["dlgSearchCustomer.clnSTT.HeaderText"];
            this.clnCustomerCode.HeaderText = translate["dlgSearchCustomer.clnCustomerCode.HeaderText"];
            this.clnOldCode.HeaderText = translate["dlgSearchCustomer.clnOldCode.HeaderText"];
            this.clnFirstName.HeaderText = translate["dlgSearchCustomer.clnFirstName.HeaderText"];
            this.clnLastName.HeaderText = translate["dlgSearchCustomer.clnLastName.HeaderText"];
            this.clnPhoneNumber.HeaderText = translate["dlgSearchCustomer.clnPhoneNumber.HeaderText"];
            this.clnBirthDate.HeaderText = translate["dlgSearchCustomer.clnBirthDate.HeaderText"];
            this.clnIDNO.HeaderText = translate["dlgSearchCustomer.clnIDNO.HeaderText"];
            this.clnTelephone.HeaderText = translate["dlgSearchCustomer.clnTelephone.HeaderText"];
            this.clnEmail.HeaderText = translate["dlgSearchCustomer.clnEmail.HeaderText"];
            this.clnAdress.HeaderText = translate["dlgSearchCustomer.clnAdress.HeaderText"];
            this.clnGroup.HeaderText = translate["dlgSearchCustomer.clnGroup.HeaderText"];
            this.clnPlace.HeaderText = translate["dlgSearchCustomer.clnPlace.HeaderText"];
            this.clnPurchase.HeaderText = translate["dlgSearchCustomer.clnPurchase.HeaderText"];
            this.btnGoPage.Text = translate["dlgSearchCustomer.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["dlgSearchCustomer.lblTotalRow.Text"];
            this.lblPage.Text = translate["dlgSearchCustomer.lblPage.Text"];
            this.btnClose.Text = translate["dlgSearchCustomer.btnClose.Text"];
            this.Text = translate["dlgSearchCustomer.Text"];
        }	

        #endregion
        #region Method/function
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
                if (dgvCustomer.Rows.Count > 0)
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
                    Customer.CUSTOMER_GROUP_CODE = row.Cells["clnGroup"].Value.ToString();
                    Customer.EMAIL_ADDRESS = row.Cells["clnEmail"].Value.ToString();
                    Customer.DEPT_CODE = (int)row.Cells["clnPlace"].Value;
                    if (row.Cells["clnPurchase"].Value.ToString() != "")
                    {
                        Customer.MONEY = (float)Convert.ToDouble(row.Cells["clnPurchase"].Value.ToString());
                    }                     
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueEntities': " + ex.Message);
            }
        }
        #endregion
        #region Event
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : form load  .
        /// </summary>
        private void frmDialogSearchCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                customer = new CUSTOMERS();
                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = this.DtCustormer;

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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Người tạo Luannv – 01/10/2013 : chặn selected vào các dòng   .
        /// </summary>
        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.CurrentCell != null)
                {
                    if (dgvCustomer.CurrentCell.Value == null)
                    {
                        dgvCustomer.CurrentRow.Selected = false;
                    }
                    else if (dgvCustomer.CurrentCell.Value != null && dgvCustomer.CurrentCell.Value.ToString() == "")
                    {
                        dgvCustomer.CurrentRow.Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        

    }
}

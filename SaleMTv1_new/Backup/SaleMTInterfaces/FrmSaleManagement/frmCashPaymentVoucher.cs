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
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using SaleMTInterfaces.PrintBill;
using System.Text.RegularExpressions;
using System.Globalization;
using SaleMTBusiness.CustomerManagement;


namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmCashPaymentVoucher : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private CASH_PAYMENT cashPayment;
        bool add = false ;
        
        #endregion

        #region Constant
        private const string LABLE_DATE = "Ngày";
        private const string TEXT_INSERT = "Thêm mới";
        private const string TEXT_CANCEL = "Hủy";
        private const string TEXT_RECODE = "Tự tạo mã";
        private const string TEXT_RATE = "1";
        private const int INDEX_IMAGE_1 = 0;
        private const int INDEX_IMAGE_2 = 1;
        private const string RPT_PATH = "\\Reports\\rptCashPayment1.rpt";
        private string Type_Cat = Properties.rsfMasterCode.Cat_Rec.ToString();
        #endregion

        #region Contructor
       
        public frmCashPaymentVoucher(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboAmountType.Text = "VND";
            cboPaymentType.SelectedValue = 0;
            cboPerson.SelectedValue = 0;
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxTTChiTien.Text = translate["frmCashPaymentVoucher.gbxTTChiTien.Text"];
            this.label9.Text = translate["frmCashPaymentVoucher.label9.Text"];
            this.label8.Text = translate["frmCashPaymentVoucher.label8.Text"];
            this.lblDate.Text = translate["frmCashPaymentVoucher.lblDate.Text"];
            this.label6.Text = translate["frmCashPaymentVoucher.label6.Text"];
            this.label5.Text = translate["frmCashPaymentVoucher.label5.Text"];
            this.label4.Text = translate["frmCashPaymentVoucher.label4.Text"];
            this.label3.Text = translate["frmCashPaymentVoucher.label3.Text"];
            this.label2.Text = translate["frmCashPaymentVoucher.label2.Text"];
            this.label1.Text = translate["frmCashPaymentVoucher.label1.Text"];
            this.gbxDanhSach.Text = translate["frmCashPaymentVoucher.gbxDanhSach.Text"];
            this.columnHeader1.Text = translate["frmCashPaymentVoucher.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmCashPaymentVoucher.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmCashPaymentVoucher.columnHeader3.Text"];
            this.columnHeader4.Text = translate["frmCashPaymentVoucher.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmCashPaymentVoucher.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmCashPaymentVoucher.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmCashPaymentVoucher.columnHeader7.Text"];
            this.columnHeader8.Text = translate["frmCashPaymentVoucher.columnHeader8.Text"];
            this.btnPrintVoucher.Text = translate["frmCashPaymentVoucher.btnPrintVoucher.Text"];
            this.btnClose.Text = translate["frmCashPaymentVoucher.btnClose.Text"];
            this.btnDelete.Text = translate["frmCashPaymentVoucher.btnDelete.Text"];
            this.btnSave.Text = translate["frmCashPaymentVoucher.btnSave.Text"];
            this.btnInsert.Text = translate["frmCashPaymentVoucher.btnInsert.Text"];
            this.Text = translate["frmCashPaymentVoucher.Text"];
        }	

        #endregion
        
        #region Methods

        
        //Người tạo: hieppd - 09/10/2013: Hiển thị thông tin phiếu đặt hàng
        protected void ShowCashPayment()
        {
            try
            {
                string procedure = "CASH_PAYMENT_Read";
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(procedure, null);

                //txtPaymentCode.ReadOnly = true;
                lblDate.Text = LABLE_DATE + ":    " + DateTime.Now.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                txtPaymentCode.Enabled = false;

                //fill Dl vao listview
                lvwPayment.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvwPayment.Items.Add(dt.Rows[i]["EmployeeName"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CashtypeName"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CASH_PAYMENT_TO"].ToString());
                    lvwPayment.Items[i].SubItems.Add(GetCurrency(dt.Rows[i]["AMOUNT"].ToString()));
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CURRENCY_NAME"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["EXCHANGE_RATE"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["DATE_PAYMENT"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["REMARK"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CASH_TYPE_CODE"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CURRENCY_ID"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["CASH_PAYMENT_ID"].ToString());
                    lvwPayment.Items[i].SubItems.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());

                    if (i % 2 == 0)
                    {
                        lvwPayment.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                }
                //load giá trị vào các control
                if (lvwPayment.Items.Count == 0)
                {
                    btnSave.Enabled = false;
                    btnPrintVoucher.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnPrintVoucher.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                log.Error("Error 'ShowCashPayment' : " + ex.Message);
            }
        }

        //Hàm tạo mới phiếu chi
        private void CreateCashPayment(string casPayId)
        {
            try
            {
                if (checkNull())
                {
                    //Tạo mã chi tiền tự động
                    //List<CASH_PAYMENT> listDetail = new List<CASH_PAYMENT>();
                    //string autoID = GetAutoCode("CASH_PAYMENT", "CASH_PAYMENT_ID", "CPA.CH40171.");
                    string audoIdEvent = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", "HIEPPHAMPC-CH40171-13.");
                    string autoID = add == false ? casPayId : GetAutoCode("CASH_PAYMENT", "CASH_PAYMENT_ID", "CPA.CH40171.");

                    CASH_PAYMENT cashPay = new CASH_PAYMENT();
                    if (add == true)
                    {
                        cashPay.CASH_PAYMENT_ID = autoID;
                        cashPay.DEPT_CODE = 327;
                        cashPay.CASH_TYPE_CODE = cboPaymentType.SelectedValue != null ? cboPaymentType.SelectedValue.ToString() : "";
                        cashPay.CASH_PAYMENT_TO = txtPersonReceipt.Text;
                        cashPay.CURRENCY_ID = cboAmountType.SelectedValue != null ? cboAmountType.SelectedValue.ToString() : "";
                        cashPay.AMOUNT = float.Parse(Conversion.Replaces(txtAmount.Text));
                        cashPay.DATE_PAYMENT = DateTime.Now;
                        cashPay.EMPLOYEE_ID = cboPerson.SelectedValue != null ? cboPerson.SelectedValue.ToString() : "";
                        cashPay.REMARK = txtNote.Text;
                        cashPay.EVENT_ID = audoIdEvent;
                        cashPay.TRANSFER_SHIFT_CODE = "TRA.CH40171.01.02.13.01";
                        cashPay.EXCHANGE_RATE = float.Parse(Conversion.Replaces(txtRate.Text));
                        cashPay.Save(add);
                        MessageBox.Show(Properties.rsfPayment.CashPayment1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        cashPay.CASH_PAYMENT_ID = autoID;
                        cashPay.DEPT_CODE = 327;
                        cashPay.CASH_TYPE_CODE = cboPaymentType.SelectedValue != null ? cboPaymentType.SelectedValue.ToString() : "";
                        cashPay.CASH_PAYMENT_TO = txtPersonReceipt.Text;
                        cashPay.CURRENCY_ID = cboAmountType.SelectedValue != null ? cboAmountType.SelectedValue.ToString() : "";
                        cashPay.AMOUNT = float.Parse(Conversion.Replaces(txtAmount.Text));
                        cashPay.DATE_PAYMENT = DateTime.Now;
                        cashPay.EMPLOYEE_ID = cboPerson.SelectedValue != null ? cboPerson.SelectedValue.ToString() : "";
                        cashPay.REMARK = txtNote.Text;
                        cashPay.EVENT_ID = audoIdEvent;
                        cashPay.TRANSFER_SHIFT_CODE = "TRA.CH40171.01.02.13.01";
                        cashPay.EXCHANGE_RATE = float.Parse(Conversion.Replaces(txtRate.Text));
                        cashPay.Save(add);
                        MessageBox.Show(Properties.rsfPayment.CashPayment6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //ShowCashPayment(txtPaymentCode.Text);
                    }
                    add = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //load dong dau tien cua luoi
        private void LoadFirstRow()
        {
            //ListViewItem.ListViewSubItemCollection items = lvwPayment.SelectedItems;
            
        }

        //Người tạo: hieppd - 09/10/2013: add dữ liệu vào combobox Loại chi
        private void addPaymentType()
        {
            try
            {
                string proc = "CASH_RECEIPT_Read_Type_receipt";
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, null);
                cboPaymentType.DataSource = dt;
                cboPaymentType.DisplayMember = "CashTypeName";
                cboPaymentType.ValueMember = "CASH_TYPE_CODE";
                cboPaymentType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Người tạo: hieppd - 09/10/2013: add dữ liệu vào combobox Người chi
        private void addPersonPayment()
        {
            try
            {
                string proc = "CASH_RECEIPT_Read_Employee";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                cboPerson.DataSource = dt;
                cboPerson.DisplayMember = "EmployeeName";
                cboPerson.ValueMember = "EMPLOYEE_ID";
                cboPerson.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Người tạo: hieppd - 09/10/2013: add dữ liệu vào combobox Loại tiền
        private void addAmountType()
        {
            try
            {
                string proc = "CASH_RECEIPT_Read_Curentcy";
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, null);
                cboAmountType.DataSource = dt;
                cboAmountType.DisplayMember = "CurrencyName";
                cboAmountType.ValueMember = "CURRENCY_ID";
                cboAmountType.Text = "VND";
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Người tạo: hieppd - 09/10/2013: Bắt lỗi các trường null
        private bool checkNull()
        {
            if (txtPersonReceipt.Text.Trim() == "" || txtPersonReceipt.Text == null)
            {
                MessageBox.Show(Properties.rsfPayment.CashPayment2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPersonReceipt.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "" || txtAmount.Text == null)
            {
                MessageBox.Show(Properties.rsfPayment.CashPayment3.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            return true;
         }

        //Tạo EVENT
        private void CreateEvent(string id, string table, string col, int type)
        {
            try
            {
                string proc = "BK_EVENT_STACK_TABLE_Create";
                SqlParameter[] sqlPara = new SqlParameter[10];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EVENT_ID", SqlDbType.VarChar, id);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@EVENT_TYPE", SqlDbType.Int, type);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@TABLE_OBJECT", SqlDbType.VarChar, table);
                sqlPara[3] = posdb_vnmSqlDAC.newInParam("@TARGET_COLUMN", SqlDbType.Text, col);
                sqlPara[4] = posdb_vnmSqlDAC.newInParam("@DATE_CREATE", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                sqlPara[5] = posdb_vnmSqlDAC.newInParam("@RELATIVE_EVENT", SqlDbType.VarChar, "");
                sqlPara[6] = posdb_vnmSqlDAC.newInParam("@IS_SEND_SERVER", SqlDbType.Bit, 0);
                sqlPara[7] = posdb_vnmSqlDAC.newInParam("@DATE_SYNCHROUS", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                sqlPara[8] = posdb_vnmSqlDAC.newInParam("@QUERY_BUILDER", SqlDbType.NText, null);
                sqlPara[9] = posdb_vnmSqlDAC.newInParam("@QUERY_BUILDER_SERVER", SqlDbType.NText, null);
                sqlDac.Execute(proc, sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Xu ly su khi click nut themMoi
        private void changeButton()
        {
            try
            {
                if (btnInsert.Text == TEXT_INSERT)
                {
                    lvwPayment.Enabled = false;
                    txtPaymentCode.Text = TEXT_RECODE;
                    txtAmount.Text = "";
                    txtPersonReceipt.Text = "";
                    btnInsert.Text = TEXT_CANCEL;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_2];
                    btnPrintVoucher.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                    dtpPaymentTime.Focus();
                    ResetControl();
                }
                else
                {
                    lvwPayment.Enabled = true;
                    txtPaymentCode.Text = "";
                    btnInsert.Text = TEXT_INSERT;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnPrintVoucher.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnInsert.Focus();

                    if (lvwPayment.Items.Count > 0)
                    {
                        lvwPayment.Items[0].Selected = true;
                    }
                    else
                    {
                        ResetControl();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Hàm xử lý nút Delete
        protected void deletePayment()
        {
            
        }

        //Resetcontrol
        private void ResetControl()
        {
            txtAmount.Text = "";
            txtPersonReceipt.Text = "";
            txtRate.Text = TEXT_RATE;
            txtNote.Text = "";
            cboPerson.SelectedIndex = -1;
            cboAmountType.Text = "VND";
            cboPaymentType.SelectedIndex = -1;
        }

        private string GetCurrency(string money)
        {
            string mReturn = "";
            try
            {
                if (money.Trim().Length > 0)
                {
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    mReturn = double.Parse(money).ToString("###,###,###,###,###", cul.NumberFormat);
                }
                mReturn = (mReturn.Length > 0) ? mReturn : "";
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetCurrency': " + ex.Message);
            }
            return mReturn;
        }

        //Sinh ma tu dong
        public string GetAutoCode(string table, string col, string prefix)
        {
            try
            {
                string result = "";
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@Col", col);
                para[1] = posdb_vnmSqlDAC.newInParam("@Table", table);
                para[2] = posdb_vnmSqlDAC.newInParam("@Prefix", prefix);
                DataTable dt = sqlDac.GetDataTable("GetAutoCode", para);
                result = dt.Rows[0]["code"].ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        #region Events

        // Xử lý sự kiện chọn nút save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCashPayment(txtPaymentCode.Text);
                ShowCashPayment();
                btnInsert.Text = TEXT_INSERT;
                btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                btnDelete.Enabled = true;
                btnPrintVoucher.Enabled = true;
                lvwPayment.Enabled = true;

                //load thông tin các control
                
                //ResetControl();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Sự kiện đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sự kiện xóa 1 bản ghi
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id != string.Empty)
            {
                //Lấy index của dòng được chọn
                int selectedindex = lvwPayment.SelectedIndices[0];
                if (MessageBox.Show(Properties.rsfPayment.CashPayment4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePay = txtPaymentCode.Text;
                    lvwPayment.Items.Remove(lvwPayment.Items[selectedindex]);

                    string proc = "CASH_PAYMENT_Delete";
                    SqlParameter[] para;
                    para = new SqlParameter[1];
                    para[0] = posdb_vnmSqlDAC.newInParam("@CASH_PAYMENT_ID", SqlDbType.VarChar, deletePay);
                    sqlDac.Execute(proc, para);

                    MessageBox.Show(Properties.rsfPayment.CashPayment5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }
            if (lvwPayment.Items.Count > 0)
            {
                lvwPayment.Items[0].Selected = true;
            }
            else
            {
                ResetControl();
            }
            
        }

        //Sự kiện nút insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            changeButton();

            add = true;
               
        }

        //Người tạo: hieppd 09/10/13- Xử lý nút in phiếu chi
        private void btnPrintVoucher_Click(object sender, EventArgs e)
        {
            
             try
            {
                PrintBill.frmReportView frm = new PrintBill.frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;

                cashPayment = new CASH_PAYMENT();
                cashPayment.CASH_PAYMENT_ID = lvwPayment.FocusedItem.SubItems[10].Text;
                frm.ds = reCashPayment.GetDataSetBill(cashPayment, sqlDac);
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }   
        }

        //Sự kiện selectedindexChanged
        string id = "";
        private void lvwPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //id = lvwPayment.FocusedItem.Text;

                foreach (ListViewItem item in lvwPayment.SelectedItems)
                {
                    id = item.Text;
                    txtPaymentCode.Text = item.SubItems[10].Text.ToString();
                    cboPerson.SelectedValue = item.SubItems[11].Text.ToString();
                    cboAmountType.SelectedValue = item.SubItems[9].Text.ToString();
                    cboPaymentType.SelectedValue = item.SubItems[8].Text.ToString();
                    txtAmount.Text = item.SubItems[3].Text.ToString();
                    txtPersonReceipt.Text = item.SubItems[2].Text;
                    txtRate.Text = item.SubItems[5].Text;
                    txtNote.Text = item.SubItems[7].Text;
                    dtpPaymentTime.Value = Convert.ToDateTime(item.SubItems[6].Text);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Load form
        private void frmCashPaymentVoucher_Load(object sender, EventArgs e)
        {
            CustomerManager.LoadMasterCode(this.cboPaymentType, Type_Cat);
            addPersonPayment();
            //addPaymentType();
            addAmountType();
            ShowCashPayment();
            if (lvwPayment.Items.Count > 0)
            {
                lvwPayment.Items[0].Selected = true;
            }
            this.ActiveControl = btnInsert;
        }

        private void lvwPayment_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
        //Sự kiện textchanged
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = GetCurrency(Conversion.Replaces(txtAmount.Text));
                txtAmount.SelectionStart = txtAmount.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Bắt lỗi chỉ cho nhập số vào ô số tiền
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        //Bắt lỗi nhập liệu
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        //Sự kiện textchanged: 
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtRate.Text = Conversion.GetCurrency(Conversion.Replaces(txtRate.Text));
            txtRate.SelectionStart = txtRate.Text.Trim().Length;
        }
        #endregion

       
        
        
    }    
    }


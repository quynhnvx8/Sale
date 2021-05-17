using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTInterfaces.PrintBill;
using SaleMTBusiness.CustomerManagement;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmCashReceiptVoucher : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        bool add = false;
        private CASH_RECEIPT cashReceipt;
        public CASH_RECEIPT CashReceipt
        {
            get { return cashReceipt; }
            set { cashReceipt = value; }
        }
        #endregion

        #region Constant
        private const string LABLE_DATE = "Ngày";
        private const string TEXT_INSERT = "Thêm mới";
        private const string TEXT_CANCEL = "Hủy";
        private const string TEXT_RECODE = "Tự tạo mã";
        private const string TEXT_RATE = "1";
        private const int INDEX_IMAGE_1 = 0;
        private const int INDEX_IMAGE_2 = 1;
        private const string RPT_PATH = "\\Reports\\rptCashReceipt1.rpt";
        private string Cat_Rec = Properties.rsfMasterCode.Cat_Rec.ToString();
        #endregion

        #region Contructor
      
        public frmCashReceiptVoucher(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboAmountType.Text = "VND";
            cboPersonReceipt.SelectedValue = 0;
            cboReceiptType.SelectedValue = 0;
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxTTThuTien.Text = translate["frmCashReceiveVouche.gbxTTThuTien.Text"];
            this.label9.Text = translate["frmCashReceiveVouche.label9.Text"];
            this.lblDateReceipt.Text = translate["frmCashReceiveVouche.lblDateReceipt.Text"];
            this.label7.Text = translate["frmCashReceiveVouche.label7.Text"];
            this.label6.Text = translate["frmCashReceiveVouche.label6.Text"];
            this.label5.Text = translate["frmCashReceiveVouche.label5.Text"];
            this.label4.Text = translate["frmCashReceiveVouche.label4.Text"];
            this.label3.Text = translate["frmCashReceiveVouche.label3.Text"];
            this.label2.Text = translate["frmCashReceiveVouche.label2.Text"];
            this.label1.Text = translate["frmCashReceiveVouche.label1.Text"];
            this.gbxDanhSach.Text = translate["frmCashReceiveVouche.gbxDanhSach.Text"];
            this.columnHeader1.Text = translate["frmCashReceiveVouche.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmCashReceiveVouche.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmCashReceiveVouche.columnHeader3.Text"];
            this.columnHeader4.Text = translate["frmCashReceiveVouche.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmCashReceiveVouche.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmCashReceiveVouche.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmCashReceiveVouche.columnHeader7.Text"];
            this.columnHeader8.Text = translate["frmCashReceiveVouche.columnHeader8.Text"];
            this.btnInsert.Text = translate["frmCashReceiveVouche.btnInsert.Text"];
            this.btnSave.Text = translate["frmCashReceiveVouche.btnSave.Text"];
            this.btnDelete.Text = translate["frmCashReceiveVouche.btnDelete.Text"];
            this.btnClose.Text = translate["frmCashReceiveVouche.btnClose.Text"];
            this.btnPrint.Text = translate["frmCashReceiveVouche.btnPrint.Text"];
            this.Text = translate["frmCashReceiveVouche.Text"];
        }	

        #endregion

        #region methods

        //Người tạo: hieppd - 09/10/2013: Hiển thị thông tin phiếu thu tiền
        private void showCash()
        {
            
            try
            {
                string proc = "CASH_RECEIPT_Read";
                
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, null);

                
                txtReceiptCode.Enabled = false;
                lblDateReceipt.Text = LABLE_DATE + ":    " + DateTime.Now.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);

                //ResetControl();

                //Lấy dữ liệu vào Listview
                lvwReceipt.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvwReceipt.Items.Add(dt.Rows[i]["EmployeeName"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["TypeCast"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["CASH_RECEIPT_FROM"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(GetCurrency(dt.Rows[i]["AMOUNT"].ToString()));
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["CURRENCY_ID"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["EXCHANGE_RATE"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["DATE_RECEIPT"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["REMARK"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["CASH_RECEIPT_ID"].ToString());
                    lvwReceipt.Items[i].SubItems.Add(dt.Rows[i]["CASH_TYPE_CODE"].ToString());
                    if (i % 2 == 0)
                    {
                        lvwReceipt.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                }
                if (lvwReceipt.Items.Count == 0)
                {
                    btnSave.Enabled = false;
                    btnPrint.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnPrint.Enabled = true; 
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }
        
        //Người tạo: hieppd - 09/10/2013: Thêm mới phiếu thu tiền
        private void insertCashReceipt(string cashRecId)
        {
            try
            {
                //lvwReceipt.Items.Clear();
                if (checkNull())
                {
                    string audoIdEvent = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", "HIEPPHAMPC-CH40171-13.");
                    string autoID = add == false ? cashRecId : GetAutoCode("CASH_RECEIPT", "CASH_RECEIPT_ID", "CRE.CH40171.");

                    CASH_RECEIPT cashRec = new CASH_RECEIPT();
                    if (add == true)
                    {
                        //ResetControl();
                        cashRec.CASH_RECEIPT_ID = autoID;
                        cashRec.DEPT_CODE = 327;
                        cashRec.CASH_TYPE_CODE = cboReceiptType.SelectedValue != null ? cboReceiptType.SelectedValue.ToString() : "";
                        cashRec.CASH_RECEIPT_FROM = txtPlaces.Text;
                        cashRec.CURRENCY_ID = cboAmountType.SelectedValue != null ? cboAmountType.SelectedValue.ToString() : "";
                        cashRec.AMOUNT = float.Parse(Conversion.Replaces(txtAmount.Text));
                        cashRec.DATE_RECEIPT = DateTime.Now;
                        cashRec.EMPLOYEE_ID = cboPersonReceipt.SelectedValue != null ? cboPersonReceipt.SelectedValue.ToString() : "";
                        cashRec.REMARK = txtNote.Text;
                        cashRec.EVENT_ID = audoIdEvent;
                        cashRec.TRANSFER_SHIFT_CODE = "TRA.CH40171.01.02.13.01";
                        cashRec.EXCHANGE_RATE = float.Parse(Conversion.Replaces(txtRate.Text));
                        cashRec.Save(add);
                        MessageBox.Show(Properties.rsfPayment.CashPayment1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //showCash(txtReceiptCode.Text);
                    }
                    else
                    {
                        cashRec.CASH_RECEIPT_ID = autoID;
                        cashRec.DEPT_CODE = 327;
                        cashRec.CASH_TYPE_CODE = cboReceiptType.SelectedValue != null ? cboReceiptType.SelectedValue.ToString() : "";
                        cashRec.CASH_RECEIPT_FROM = txtPlaces.Text;
                        cashRec.CURRENCY_ID = cboAmountType.SelectedValue != null ? cboAmountType.SelectedValue.ToString() : "";
                        cashRec.AMOUNT = float.Parse(Conversion.Replaces(txtAmount.Text));
                        cashRec.DATE_RECEIPT = DateTime.Now;
                        cashRec.EMPLOYEE_ID = cboPersonReceipt.SelectedValue != null ? cboPersonReceipt.SelectedValue.ToString() : "";
                        cashRec.REMARK = txtNote.Text;
                        cashRec.EVENT_ID = audoIdEvent;
                        cashRec.TRANSFER_SHIFT_CODE = "TRA.CH40171.01.02.13.01";
                        cashRec.EXCHANGE_RATE = float.Parse(Conversion.Replaces(txtRate.Text));
                        cashRec.Save(add);
                        MessageBox.Show(Properties.rsfPayment.CashPayment6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //showCash(txtReceiptCode.Text);
                    }
                    add = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Người tạo: hieppd - 09/10/2013: Bắt lỗi các trường null
        private bool checkNull()
        {
            if (txtPlaces.Text.Trim() == "" || txtPlaces.Text == null)
            {
                MessageBox.Show(Properties.rsfPayment.CashPayment2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlaces.Focus();
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

        //Người tạo: hieppd - 09/10/2013: add dữ liệu vào combobox Loại thu
        private void addReceiptType()
        {
            try
            {
                string proc = "CASH_RECEIPT_Read_Type_receipt";
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, null);
                cboReceiptType.DataSource = dt;
                cboReceiptType.DisplayMember = "CashTypeName";
                cboReceiptType.ValueMember = "CASH_TYPE_CODE";
                cboReceiptType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Người tạo: hieppd - 09/10/2013: add dữ liệu vào combobox Người chi
        private void addPersonReceipt()
        {
            try
            {
                string proc = "CASH_RECEIPT_Read_Employee";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                cboPersonReceipt.DataSource = dt;
                cboPersonReceipt.DisplayMember = "EmployeeName";
                cboPersonReceipt.ValueMember = "EMPLOYEE_ID";
                cboPersonReceipt.SelectedIndex = -1;
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

        // Tạo mã thu tiền tự động
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

        //Người tạo: hieppd - 09/10/2013: Đổi tên và chức năng của nút Insert
        private void changeButton()
        {
            try
            {
                if (btnInsert.Text == TEXT_INSERT)
                {
                    lvwReceipt.Enabled = false;
                    txtReceiptCode.Text = TEXT_RECODE;
                    txtAmount.Text = "";
                    txtPlaces.Text = "";
                    btnInsert.Text = TEXT_CANCEL;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_2];
                    btnPrint.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                    dtpTimeReceipt.Focus();
                    ResetControl();
                }
                else
                {
                    lvwReceipt.Enabled = true;
                    txtReceiptCode.Text = "";
                    btnInsert.Text = TEXT_INSERT;
                    btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                    btnPrint.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnInsert.Focus();
                    if (lvwReceipt.Items.Count > 0)
                    {
                        lvwReceipt.Items[0].Selected = true;
                    }
                    //else
                    //{
                    //    ResetControl();
                    //}
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Resetcontrol
        private void ResetControl()
        {
            txtAmount.Text = "";
            txtPlaces.Text = "";
            txtRate.Text = TEXT_RATE;
            txtNote.Text = "";
            cboPersonReceipt.SelectedIndex = -1;
            cboAmountType.Text = "VND";
            cboReceiptType.SelectedIndex = -1;
        }
        #endregion
        
        #region Event
        private void cbxNguoiNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       
        //Bắt sự kiện Selected
        string id = "";
        private void lvwReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                foreach(ListViewItem item in lvwReceipt.SelectedItems)
                {
                    id = item.Text;
                    txtReceiptCode.Text = item.SubItems[9].Text.ToString();
                    cboPersonReceipt.SelectedValue = item.SubItems[8].Text.ToString();
                    cboAmountType.SelectedValue = item.SubItems[4].Text.ToString();
                    cboReceiptType.SelectedValue = item.SubItems[10].Text.ToString();
                    txtAmount.Text = item.SubItems[3].Text.ToString();
                    txtPlaces.Text = item.SubItems[2].Text;
                    txtRate.Text = item.SubItems[5].Text;
                    txtNote.Text = item.SubItems[7].Text;
                    dtpTimeReceipt.Value = Convert.ToDateTime(item.SubItems[6].Text);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }
        
        //Load form
        private void frmCashReceiptVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerManager.LoadMasterCode(this.cboReceiptType, Cat_Rec);
                addAmountType();
                addPersonReceipt();
                //addReceiptType();
                showCash();
                if (lvwReceipt.Items.Count > 0)
                {
                    lvwReceipt.Items[0].Selected = true;
                }
                this.ActiveControl = btnInsert;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Xử lý nút đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Xử lý nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                insertCashReceipt(txtReceiptCode.Text);
                showCash();
                
                btnInsert.Text = TEXT_INSERT;
                btnInsert.Image = imgInsert.Images[INDEX_IMAGE_1];
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
                lvwReceipt.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }

        //Bắt sự kiện nút insert
        private void btnInsert_Click(object sender, EventArgs e)
        { 
            changeButton();
            
            add = true;
            //showCash("");
        }

        //Người tạo: Hieppd- 09/10/13: Xử lý sự kiện in phiếu thu
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            try
            {
                PrintBill.frmReportView frm = new PrintBill.frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;

                cashReceipt = new CASH_RECEIPT();
                cashReceipt.CASH_RECEIPT_ID = lvwReceipt.FocusedItem.SubItems[9].Text;
                frm.ds = printCashRecipt.GetDataSetBill(cashReceipt, sqlDac);

                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        
        
        //Người tạo: hieppd - 09/10/2013: Xử lý nút xóa 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (id != string.Empty)
                {
                    //Lấy index của dòng được chọn
                    int selectedindex = lvwReceipt.SelectedIndices[0];
                    string CashRecDelete = txtReceiptCode.Text;
                    if (MessageBox.Show(Properties.rsfPayment.CashPayment4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lvwReceipt.Items.Remove(lvwReceipt.Items[selectedindex]);

                        ListViewItem item = lvwReceipt.FocusedItem;
                        string proc = "CASH_RECEIPT_Delete";
                        SqlParameter[] para;
                        para = new SqlParameter[1];
                        para[0] = posdb_vnmSqlDAC.newInParam("@CASH_RECEIPT_ID", SqlDbType.VarChar, CashRecDelete);
                        sqlDac.Execute(proc, para);

                        MessageBox.Show(Properties.rsfPayment.CashPayment5.ToString(),translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    } 
                }
                if (lvwReceipt.Items.Count > 0)
                {
                    lvwReceipt.Items[0].Selected = true;
                }
                else
                {
                    ResetControl();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cboAmountType_SelectedIndexChanged(object sender, EventArgs e)
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

        //Xử lý lỗi nhập liệu
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

        // sự kiện textchanged
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtRate.Text = Conversion.GetCurrency(Conversion.Replaces(txtRate.Text));
            txtRate.SelectionStart = txtRate.Text.Trim().Length;
        }

        //Xử lý lỗi nhập liệu
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
        #endregion
    }
}

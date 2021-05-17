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
using SaleMTCommon;
using SaleMTInterfaces.PrintBill;
using SaleMTBusiness.SaleManagement;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Printing;


namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 27/09/2013 : Form Thanh toán hóa đơn. 
    /// </summary>
    public partial class frmDialogPayment : Form
    {
        #region Declaration
        #region Const
        private const string RPT_PATH = "\\Reports\\rptSalesInvoice.rpt";
        private const string ACTIVE_GIF = "ACTIVED";
        private const string WAIT_GIF = "WAIT";
        private const string USED_GIF = "USED";
        #endregion
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private string cardCode = Properties.rsfMasterCode.PayCard.ToString();
        private string[] lstGiftCode;
        private bool paymented;
        private SalePaymentEntities salePayEn;
        SerialPort sp;
        bool CheckC;
        private string strTotalReturn;

        public bool Paymented
        {
            get { return paymented; }
            set { paymented = value; }
        }
        public SalePaymentEntities SalePayEn
        {
            get { return salePayEn; }
            set { salePayEn = value; }
        }

        #endregion

        #region Contructor
        
        public frmDialogPayment(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            dgvVoucherGift.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvVoucherGift_EditingControlShowing);
            dgvCurrencys.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvCurrencys_EditingControlShowing);
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.tpPayCard.Text = translate["frmDialogPayment.tpPayCard.Text"];
            this.label14.Text = translate["frmDialogPayment.label14.Text"];
            this.label15.Text = translate["frmDialogPayment.label15.Text"];
            this.label16.Text = translate["frmDialogPayment.label16.Text"];
            this.clnCurrency.HeaderText = translate["frmDialogPayment.clnCurrency.HeaderText"];
            this.clnExchangeRate.HeaderText = translate["frmDialogPayment.clnExchangeRate.HeaderText"];
            this.clnAmount.HeaderText = translate["frmDialogPayment.clnAmount.HeaderText"];
            this.clnIntoMoney.HeaderText = translate["frmDialogPayment.clnIntoMoney.HeaderText"];
            this.tpGift.Text = translate["frmDialogPayment.tpGift.Text"];
            this.clnCode.HeaderText = translate["frmDialogPayment.clnCode.HeaderText"];
            this.clnPar.HeaderText = translate["frmDialogPayment.clnPar.HeaderText"];
            this.clnBalance.HeaderText = translate["frmDialogPayment.clnBalance.HeaderText"];
            this.clnMaxPay.HeaderText = translate["frmDialogPayment.clnMaxPay.HeaderText"];
            this.clnPayment.HeaderText = translate["frmDialogPayment.clnPayment.HeaderText"];
            this.clnRemain.HeaderText = translate["frmDialogPayment.clnRemain.HeaderText"];
            this.tpPromotion.Text = translate["frmDialogPayment.tpPromotion.Text"];
            this.tpBill.Text = translate["frmDialogPayment.tpBill.Text"];
            this.label17.Text = translate["frmDialogPayment.label17.Text"];
            this.label18.Text = translate["frmDialogPayment.label18.Text"];
            this.label19.Text = translate["frmDialogPayment.label19.Text"];
            this.label20.Text = translate["frmDialogPayment.label20.Text"];
            this.chkRedBill.Text = translate["frmDialogPayment.chkRedBill.Text"];
            this.grbPayment.Text = translate["frmDialogPayment.grbPayment.Text"];
            this.label5.Text = translate["frmDialogPayment.label5.Text"];
            this.label4.Text = translate["frmDialogPayment.label4.Text"];
            this.label3.Text = translate["frmDialogPayment.label3.Text"];
            this.label2.Text = translate["frmDialogPayment.label2.Text"];
            this.label1.Text = translate["frmDialogPayment.label1.Text"];
            this.groupBox2.Text = translate["frmDialogPayment.groupBox2.Text"];
            this.label7.Text = translate["frmDialogPayment.label7.Text"];
            this.label6.Text = translate["frmDialogPayment.label6.Text"];
            this.groupBox3.Text = translate["frmDialogPayment.groupBox3.Text"];
            this.label11.Text = translate["frmDialogPayment.label11.Text"];
            this.label10.Text = translate["frmDialogPayment.label10.Text"];
            this.label9.Text = translate["frmDialogPayment.label9.Text"];
            this.label8.Text = translate["frmDialogPayment.label8.Text"];
            this.btnClose.Text = translate["frmDialogPayment.btnClose.Text"];
            this.btnPayment.Text = translate["frmDialogPayment.btnPayment.Text"];
            this.btnPayAndPrint.Text = translate["frmDialogPayment.btnPayAndPrint.Text"];
            this.btnPrintTemp.Text = translate["frmDialogPayment.btnPrintTemp.Text"];
            this.Text = translate["frmDialogPayment.Text"];
        }	

        #endregion

        #region Method/Function

        #region method process control

        /// <summary>
        /// Người tạo Hieppd – 10/12/2013 : Kiem tra xem co cong Pole khong
        /// </summary>
        private bool CheckCOM()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string s in ports)
                {
                    if (UserImformation.PortName == s)
                    {
                        CheckC = true;
                    }
                    else
                    {
                        CheckC = false;
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckCOM': " + ex.Message);
            }
            return CheckC;
        }

        /// <summary>
        /// Người tạo Hieppd – 10/12/2013 : Hien thi 1 dong tren PoleDisplay
        /// </summary>
        private void PoleDisplayOneRow(string strPole)
        {
            try
            {
                if (UserImformation.ChekPole)
                {
                    if (CheckCOM())
                    {
                        sp = new SerialPort();
                        sp.PortName = UserImformation.PortName.ToString();
                        sp.Parity = Parity.None;
                        sp.BaudRate = UserImformation.BaudRate;
                        sp.DataBits = 8;
                        sp.Open();

                        sp.Write("\x04\x01\x43\x31\x58\x17");
                        sp.Write(strPole.Substring(0, strPole.Length));
                        System.Threading.Thread.Sleep(50);
                        sp.Close();
                    }
                    else
                    {
                        MessageBox.Show(SaleMTInterfaces.Properties.rsfSales.SCom.ToString(), SaleMTInterfaces.Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                               MessageBoxIcon.Asterisk);
                    }

                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'PoleDisplay': " + ex.Message);
            }
        
        }

        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Load dữ liệu thông tin hóa đơn đỏ. 
        /// </summary>
        private void SetInfoRedInvoice()
        {
            try
            {
                DataRow dr = Payment.GetRedInvoice(salePayEn.Customer.CUSTOMER_ID, sqlDac);
                if (dr != null)
                {
                    txtCompanyName.Text = dr["OFFICE_WORKING"].ToString();
                    txtAdress.Text = dr["OFFICE_ADDRESS"].ToString();
                    txtTaxCode.Text = dr["TAX_CODE"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetInfoRedInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Load dữ liệu cho loại tiền tệ. 
        /// </summary>
        private void BindCurrency()
        {
            try
            {
                DataTable curen = Payment.GetCurrency(sqlDac);
                //bdsCurrency.DataSource = Payment.GetCurrency(sqlDac);
                clnCurrency.DataSource = curen;
                clnCurrency.DataPropertyName = "CURRENCY_ID";
                clnCurrency.DisplayMember = "CURRENCY_ID";
                clnCurrency.ValueMember = "CURRENCY_ID";
                dgvCurrencys.Rows[0].Cells["clnCurrency"].Value = curen.Rows[0]["CURRENCY_ID"].ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindCurrency' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Load dữ liệu loại thẻ thanh toán. 
        /// </summary>
        private void BindCardType()
        {
            try
            {
                BindingSource bincard = new BindingSource();
                bincard.DataSource = Payment.GetCardType(cardCode, sqlDac);
                cboTypeCard.DataSource = bincard.DataSource;
                cboTypeCard.DisplayMember = "MASTER_NAME";
                cboTypeCard.ValueMember = "MASTER_CODE";
                cboTypeCard.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindCardType' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Set số dư thanh toán vào control txtPayMissing. 
        /// </summary>
        private void SetBalance()
        {
            try
            {
                double totalReceived = Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                double amount = Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text));
                txtPayMissing.Text = (totalReceived > amount) ? "0" : Conversion.GetCurrency((amount - totalReceived).ToString());
                txtRefund.Text = (totalReceived > amount) ? Conversion.GetCurrency((totalReceived - amount).ToString()) : "0";

                //Hiển thị số tiền trả lại sau khi thanh toán:
                if (txtRefund.Text.Length > 0)
                { 
                    strTotalReturn = "Tra lai:"+ txtRefund.Text;
                    //PoleDisplayOneRow(TotalReturn);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'SetBalance' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Khởi tạo giá trị các control. 
        /// </summary>
        private void LoadValue()
        {
            try
            {
                double totalpay = SalePayEn.CashSales - SalePayEn.Discount - SalePayEn.SpecialDiscount - SalePayEn.Promotion;
                txtCashSales.Text = Conversion.GetCurrency(SalePayEn.CashSales.ToString());
                txtDiscounts.Text = Conversion.GetCurrency(SalePayEn.SpecialDiscount.ToString());
                txtSpacialDiscount.Text = Conversion.GetCurrency(SalePayEn.Discount.ToString());
                txtPromotion.Text = Conversion.GetCurrency(SalePayEn.Promotion.ToString());
                txtVND.Text = Conversion.GetCurrency(totalpay.ToString());
                txtTotalPay.Text = Conversion.GetCurrency(totalpay.ToString());
                txtTotalReceived.Text = Conversion.GetCurrency(totalpay.ToString());
                rtfPromotion.Text = salePayEn.StrXML.ToString();
                txtRefund.Text = "0";
                txtPayMissing.Text = "0";
                txtMoneyCard.Text = "0";
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadValue' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Khởi tạo vị trí các control thanh toán mở rộng . 
        /// </summary>
        private void SetControl()
        {
            try
            {
                pnlTop.Size = new Size(512, 24);
                grbPayment.Visible = true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetControl' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Thanh toán mở rộng . 
        /// </summary>
        private void OtherPayment()
        {
            try
            {
                double currency = 0;
                double visa = 0;
                double gift = 0;
                double totalpay = Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text));
                // tiền thanh toán bằng ngoại tệ
                if (dgvCurrencys.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvCurrencys.Rows.Count; i++)
                    {
                        if (dgvCurrencys.Rows[i].Cells[3].Value != null)
                        {
                            double cellMoney = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[i].Cells[3].Value.ToString()));
                            currency = currency + cellMoney;
                        }
                    }
                }
                //tiền thanh toán bằng thẻ
                visa = (txtMoneyCard.Text.Trim().Length > 0) ? Convert.ToDouble(Conversion.Replaces(txtMoneyCard.Text)) : 0;
                // tiền thanh toán bằng phiếu quà tặng                
                lstGiftCode = new string[dgvVoucherGift.Rows.Count];
                for (int i = 0; i < dgvVoucherGift.Rows.Count; i++)
                {   
                    // xử lý nếu gift > totalpay xóa các dòng xử dụng phiếu quà tặng tiếp theo
                    if (gift > totalpay)
                        dgvVoucherGift.Rows.RemoveAt(i);
                    else if (dgvVoucherGift.Rows[i].Cells["clnPayment"].Value != null)
                    {
                        double giftMoney = Convert.ToDouble(Conversion.Replaces(dgvVoucherGift.Rows[i].Cells["clnPayment"].Value.ToString()));
                        gift = gift + giftMoney;                        
                    }
                    if (dgvVoucherGift.Rows[i].Cells["clnCode"].Value != null)
                        lstGiftCode[i] = dgvVoucherGift.Rows[i].Cells["clnCode"].Value.ToString().Trim();
                }
                // nếu giá trị phiếu quà tặng lớn hơn tổng số tiền phải thanh toán set = giá trị thanh toán
                if (gift > totalpay)
                    gift = totalpay;

                txtOrtherMoney.Text = Conversion.GetCurrency((currency + visa + gift).ToString());
                // tính số tiền còn lại phải thanh toán
                double vnd = ((totalpay - currency - visa - gift) > 0) ? (totalpay - currency - visa - gift) : 0;
                txtVND.Text = Conversion.GetCurrency(vnd.ToString());
                txtTotalReceived.Text = Conversion.GetCurrency((currency + visa + gift + vnd).ToString());
                SetBalance();

            }
            catch (Exception ex)
            {
                log.Error("Error 'OtherPayment' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 :Ẩn hiện thanh toán mở rộng . 
        /// </summary>
        private void ResizeTop()
        {
            try
            {
                if (pnlTop.Size.Height == 24)
                {
                    pnlTop.Size = new Size(512, 208);
                    grbPayment.Visible = false;
                    tabPayment.Visible = true;
                    btnResizeTop.ImageIndex = 1;
                }
                else
                {
                    pnlTop.Size = new Size(512, 24);
                    grbPayment.Visible = true;
                    tabPayment.Visible = false;
                    btnResizeTop.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeTop' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Ẩn hiện ghi chú hóa đơn . 
        /// </summary>
        private void ResizeBottom()
        {
            try
            {
                if (pnlBottom.Size.Height == 24)
                {
                    pnlBottom.Location = new Point(10, 418);
                    pnlBottom.Size = new Size(512, 85);
                    rtfRemarks.Visible = true;
                    btnResize.ImageIndex = 0;
                    rtfRemarks.Focus();
                }
                else
                {
                    pnlBottom.Location = new Point(10, 479);
                    pnlBottom.Size = new Size(512, 24);
                    rtfRemarks.Visible = false;
                    btnResize.ImageIndex = 1;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResizeBottom' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Kiểm tra và xử lý thông tin phiếu quà tặng nhập vào . 
        /// </summary>
        private void CheckInputGift(int colIndex, int rowIndex)
        {
            try
            {
                if (colIndex == 0) // nhập mã phiếu quà tặng
                {
                    string vouCode = dgvVoucherGift.CurrentCell.EditedFormattedValue.ToString().Trim();
                    if (vouCode != "")
                    {
                        bool check = true;
                        for (int i = 0; i < dgvVoucherGift.Rows.Count; i++)
                        {
                            if (!dgvVoucherGift.Rows[i].IsNewRow && dgvVoucherGift.Rows[i].Cells["clnCode"].Value != null)
                            {
                                string code = dgvVoucherGift.Rows[i].Cells["clnCode"].Value.ToString();
                                if (vouCode == code)
                                {
                                    check = false;
                                    break;
                                }
                            }
                        }
                        if (check)
                        {
                            DataTable dtGift = Payment.GetVoucherGift(vouCode, sqlDac);

                            if (dtGift.Rows.Count > 0)
                            {
                                double amount = Convert.ToDouble(Conversion.Replaces(dtGift.Rows[0]["BALANCE"].ToString()));
                                double cash = Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text.Trim()));
                                if (amount > cash)
                                {
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnCode"].Value = vouCode;
                                    //MessageBox.Show(Properties.rsfSales.Payment5.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                    //                          MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnPar"].Value = Conversion.GetCurrency(dtGift.Rows[0]["ITEM_REAL_DENOMINATION"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnBalance"].Value = Conversion.GetCurrency(dtGift.Rows[0]["BALANCE"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnMaxPay"].Value = Conversion.GetCurrency(dtGift.Rows[0]["BALANCE"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnPayment"].Value = Conversion.GetCurrency(cash.ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnRemain"].Value = "0";
                                    OtherPayment();
                                }
                                else if (dtGift.Rows[0]["STATUS"].ToString() == ACTIVE_GIF)
                                {
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnCode"].Value = vouCode;
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnPar"].Value = Conversion.GetCurrency(dtGift.Rows[0]["ITEM_REAL_DENOMINATION"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnBalance"].Value = Conversion.GetCurrency(dtGift.Rows[0]["BALANCE"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnMaxPay"].Value = Conversion.GetCurrency(dtGift.Rows[0]["BALANCE"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnPayment"].Value = Conversion.GetCurrency(dtGift.Rows[0]["BALANCE"].ToString());
                                    dgvVoucherGift.Rows[rowIndex].Cells["clnRemain"].Value = "0";                                    
                                    OtherPayment();

                                }
                                else if (dtGift.Rows[0]["STATUS"].ToString() == WAIT_GIF)
                                {
                                    MessageBox.Show(Properties.rsfSales.Payment3.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                }
                                else if (dtGift.Rows[0]["STATUS"].ToString() == USED_GIF)
                                {
                                    MessageBox.Show(Properties.rsfSales.Payment4.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                }
                            }
                            else
                            {
                                MessageBox.Show(Properties.rsfSales.Payment2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                if (colIndex == 4)// nhập số tiền muốn thanh toán cho đơn hàng này
                {
                    if (dgvVoucherGift.Rows[rowIndex].Cells["clnBalance"].Value != null && dgvVoucherGift.Rows[rowIndex].Cells["clnPayment"].Value != null)
                    {
                        double balance = Convert.ToDouble(Conversion.Replaces(dgvVoucherGift.Rows[rowIndex].Cells["clnBalance"].Value.ToString().Trim()));
                        double pay = Convert.ToDouble(Conversion.Replaces(dgvVoucherGift.Rows[rowIndex].Cells["clnPayment"].Value.ToString().Trim()));

                        if (pay > balance)
                        {
                            MessageBox.Show(Properties.rsfSales.Payment1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                          MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            dgvVoucherGift.Rows[rowIndex].Cells["clnRemain"].Value = Conversion.GetCurrency((balance - pay).ToString());
                            dgvVoucherGift.Rows[rowIndex].Cells["clnPayment"].Value = Conversion.GetCurrency(pay.ToString());
                            OtherPayment();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'InputGift': " + ex.Message);
            }
        }
        #endregion

        #region event handling method

        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : lưu dữ liệu thanh toán mua hàng . 
        /// </summary>
        private void SetDataAndPay()
        {
            try
            {
                // Kiểm tra có sử dụng hóa đơn đỏ không
                if (chkRedBill.Checked)
                {
                    if (txtCompanyName.Text.Trim() == "")
                    {
                        MessageBox.Show(Properties.rsfSales.RedBill, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (txtAdress.Text.Trim() == "" || txtAdress.Text.Trim().Length < 10)
                    {
                        MessageBox.Show(Properties.rsfSales.RedBill2, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (txtTaxCode.Text.Trim() == "" || txtTaxCode.Text.Trim().Length < 10 || txtTaxCode.Text.Trim().Length > 15)
                    {
                        MessageBox.Show(Properties.rsfSales.RedBill1, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                
                PaymentEntities payEn = new PaymentEntities();
                payEn.TotalPay = (float)Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text));
                payEn.Refund = (float)Convert.ToDouble(Conversion.Replaces(txtRefund.Text));
                payEn.TotalReceived = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Remarks = rtfRemarks.Text;
                payEn.MoneyCard = (float)Convert.ToDouble(Conversion.Replaces(txtMoneyCard.Text));
                payEn.Amount = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Money = (float)Convert.ToDouble(Conversion.Replaces(txtVND.Text));
                payEn.CardType = cboTypeCard.SelectedValue.ToString();

                if (payEn.TotalPay > payEn.TotalReceived)
                {
                    MessageBox.Show(Properties.rsfSales.Sale7.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    
                    
                    if (salePayEn.SaleExport != null)
                    {
                        // Cập nhật dữ liệu thanh toán
                        salePayEn.SaleExport.USED_RED_INVOIDE = chkRedBill.Checked;
                        salePayEn.SaleExport.RED_INVOIDE_COMPANYNAME = txtCompanyName.Text;
                        salePayEn.SaleExport.RED_INVOICE_ADDRESS = txtAdress.Text;
                        salePayEn.SaleExport.RED_INVOICE_TAXCODE = txtTaxCode.Text;
                        salePayEn.SaleExport.RED_INVOICE_REMARK = rtfRemarkRed.Text;
                        // lưu dữ liệu chi tiết thanh toán
                        Payment.Pay(payEn, dgvCurrencys, SalePayEn.SaleExport);
                        // lưu dữ liệu hóa đơn bán hàng. 
                        
                        SalePayEn.SaleExport.Save(true);
                    }
                    //lưu thông tin bảng chiết khấu đặc biệt
                    if (salePayEn.SaleDiscount != null)
                    {
                        salePayEn.SaleDiscount.Save(true);
                    }

                    //lưu Chi tiết hóa đơn bán hàng
                    if (salePayEn.SaleExportItem != null)
                    {
                        for (int i = 0; i < SalePayEn.SaleExportItem.Length; i++)
                        {
                            if (SalePayEn.SaleExportItem[i] != null)
                                SalePayEn.SaleExportItem[i].Save(true);
                        }
                    }
                    // lưu tồn kho
                    if (salePayEn.Inventory != null)
                    {
                        for (int i = 0; i < SalePayEn.Inventory.Length; i++)
                        {
                            if (SalePayEn.Inventory[i] != null)
                                SalePayEn.Inventory[i].Save(true);
                        }
                    }
                    // Update dữ liệu phiếu giảm giá nếu có sử dụng phiếu giảm giá
                    if (salePayEn.Coupon != null)
                    {
                        for (int i = 0; i < salePayEn.Coupon.Length; i++)
                        {
                            if (salePayEn.Coupon[i] != null)
                                salePayEn.Coupon[i].Save(false);
                        }
                    }
                    // Update dữ liệu phiếu quà tặng nếu có sử dụng phiếu quà tặng
                    if (lstGiftCode != null)
                    {
                        Payment.UpdateVoucherGift(lstGiftCode, sqlDac);
                    }
                    // lưu dữ liệu khuyến mại giảm tiền hóa đơn
                    if (salePayEn.SalePromotion != null)
                    {
                        for (int i = 0; i < salePayEn.SalePromotion.Length; i++)
                        {
                            if(salePayEn.SalePromotion[i] != null)
                                salePayEn.SalePromotion[i].Save(true);
                        }
                    }
                    // lưu dữ liệu khuyến mại tặng phẩm

                        
                    if (salePayEn.SalePromotionGift != null)
                    {
                        // kiểm tra dòng trùng nhau
                        for (int i = 0; i < salePayEn.SalePromotionGift.Length;i++ )
                        {
                            for (int j = 0; j < salePayEn.SalePromotionGift.Length; j++)
                            {
                                if (i != j)
                                {
                                    if (salePayEn.SalePromotionGift[i] != null && salePayEn.SalePromotionGift[j] != null)
                                    {
                                        if (salePayEn.SalePromotionGift[i].PRODUCT_ID == salePayEn.SalePromotionGift[j].PRODUCT_ID && salePayEn.SalePromotionGift[i].QUANTITY != 0)
                                        {
                                            salePayEn.SalePromotionGift[i].QUANTITY = salePayEn.SalePromotionGift[i].QUANTITY + salePayEn.SalePromotionGift[j].QUANTITY;
                                            salePayEn.SalePromotionGift[j].QUANTITY = 0;
                                        }
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < salePayEn.SalePromotionGift.Length; i++)
                        {
                            if (salePayEn.SalePromotionGift[i] != null && salePayEn.SalePromotionGift[i].QUANTITY != 0)
                                salePayEn.SalePromotionGift[i].Save(true);

                            
                        }
                    }
                    this.Close();
                    Paymented = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : In hóa đơn tạm . 
        /// Người sửa Thanvn 1 – (18/11/2013): Kiểm tra có xem trước khi in không?
        /// </summary>
        private void PrintTemp()
        {
            try
            {
                /*
                DataSet dsSaleTemp = Payment.GetDataSetBill(SalePayEn, sqlDac);
                dsSaleTemp.DataSetName = "dsSaleInvoice";
                PrintBill.frmReportView frm = new PrintBill.frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;
                frm.ds = dsSaleTemp;                
                frm.Show();
                */
                PaymentEntities payEn = new PaymentEntities();
                payEn.TotalPay = (float)Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text));
                payEn.Refund = (float)Convert.ToDouble(Conversion.Replaces(txtRefund.Text));
                payEn.TotalReceived = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Remarks = rtfRemarks.Text;
                payEn.MoneyCard = (float)Convert.ToDouble(Conversion.Replaces(txtMoneyCard.Text));
                payEn.Amount = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Money = (float)Convert.ToDouble(Conversion.Replaces(txtVND.Text));
                payEn.CardType = cboTypeCard.SelectedValue.ToString();

                DataSet dsSaleTemp = Payment.GetDataSetBill(SalePayEn,payEn, sqlDac);
                dsSaleTemp.DataSetName = "dsSaleInvoice";
                PrintBill.frmReportView frm = new PrintBill.frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;
                frm.ds = dsSaleTemp;
                if ("0".Equals(AppConfigFileSettings.isPrintPreview))
                {                    
                    frm.Print((int)dudBill.Value);
                }
                else {
                    frm.Show();
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintTemp': " + ex.Message);
            }
        }
        private void PrintRaw()
        {
            try
            {
                PaymentEntities payEn = new PaymentEntities();
                payEn.TotalPay = (float)Convert.ToDouble(Conversion.Replaces(txtTotalPay.Text));
                payEn.Refund = (float)Convert.ToDouble(Conversion.Replaces(txtRefund.Text));
                payEn.TotalReceived = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Remarks = rtfRemarks.Text;
                payEn.MoneyCard = (float)Convert.ToDouble(Conversion.Replaces(txtMoneyCard.Text));
                payEn.Amount = (float)Convert.ToDouble(Conversion.Replaces(txtTotalReceived.Text));
                payEn.Money = (float)Convert.ToDouble(Conversion.Replaces(txtVND.Text));
                payEn.CardType = cboTypeCard.SelectedValue.ToString();

                DataSet dsSaleTemp = Payment.GetDataSetBill(SalePayEn, payEn, sqlDac);
                dsSaleTemp.DataSetName = "dsSaleInvoice";
                PrintBill.frmReportView frm = new PrintBill.frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;
                frm.ds = dsSaleTemp;

                string raw = "     CTY CP SUA VIET NAM - VINAMILK     " + Environment.NewLine
                        + ConvertVN(String40(dsSaleTemp.Tables["StoreInfo"].Rows[0]["StoreName"].ToString())) + Environment.NewLine
                        + ConvertVN(String40("Tel: " + dsSaleTemp.Tables["StoreInfo"].Rows[0]["Tel"].ToString())) + Environment.NewLine
                        + ConvertVN(String40(dsSaleTemp.Tables["StoreInfo"].Rows[0]["Address"].ToString())) + Environment.NewLine
                        + Environment.NewLine
                        + String40("HOA DON") + Environment.NewLine
                        + Environment.NewLine
                        + Last40("So HD: " + dsSaleTemp.Tables["Total"].Rows[0]["EXPORT_CODE"].ToString()) + Environment.NewLine
                        + ConvertVN(Last40("KH: " + dsSaleTemp.Tables["Total"].Rows[0]["FULL_NAME"].ToString())) + Environment.NewLine
                        + ConvertVN(Last40("DC: " + dsSaleTemp.Tables["Total"].Rows[0]["BARCODE_STRING"].ToString())) + Environment.NewLine
                        + Last40("Doanh so tich luy: " + Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL_AMOUNT"].ToString())) + Environment.NewLine
                        + Last40("Ngay: " + dsSaleTemp.Tables["Total"].Rows[0]["EXPORT_DATE"].ToString()) + Environment.NewLine
                        + ConvertVN(Last40("NV: " + dsSaleTemp.Tables["Total"].Rows[0]["EMPLOYEE"].ToString())) + Environment.NewLine
                        + "SP             SL      Gia        T.Tien" + Environment.NewLine
                        + "----------------------------------------" + Environment.NewLine;
                foreach (DataRow dr in dsSaleTemp.Tables["Invoice"].Rows)
                {
                    raw += ConvertVN(Last40(dr["PRODUCT_NAME"].ToString())) + Environment.NewLine;
                    string id = dr["PRODUCT_ID"].ToString();
                    string quantity = dr["QUANTITY"].ToString();
                    string price = Conversion.GetCurrency(dr["PRICE"].ToString());
                    string total = Conversion.GetCurrency(dr["TOTAL_AMOUNT"].ToString());
                    string line = id;
                    int n = 0;

                    for (int i = 0; i < (16 - id.Length) - quantity.Length; i++)
                    {
                        line = line + " ";
                    }
                    line = line + quantity;
                    n = line.Length;
                    for (int i = 0; i < (26 - n) - price.Length; i++)
                    {
                        line = line + " ";
                    }
                    line = line + price;
                    n = line.Length;
                    for (int i = 0; i < (40 - n) - total.Length; i++)
                    {
                        line = line + " ";
                    }
                    line = line + total;

                    line = line + Environment.NewLine;

                    string discount = Conversion.GetCurrency((double.Parse(dr["REBATE"].ToString()) + double.Parse(dr["PROMOTION"].ToString()) + double.Parse(dr["DISCOUNT"].ToString())).ToString());
                    if (double.Parse(dr["REBATE"].ToString()) + double.Parse(dr["PROMOTION"].ToString()) + double.Parse(dr["DISCOUNT"].ToString()) > 0)
                    {
                        line += "Chiet khau: ";
                        for (int i = 0; i < 28 - discount.Length; i++)
                        {
                            line += " ";
                        }
                        line += discount + Environment.NewLine;
                    }

                    raw += line;
                }
                raw += "----------------------------------------" + Environment.NewLine
                    + "KM                                 SL   " + Environment.NewLine;
                foreach (DataRow dr in dsSaleTemp.Tables["PROMOTION_GIFT"].Rows)
                {
                    string id = ConvertVN(dr["PRODUCT_NAME"].ToString());
                    string quantity = dr["QUANTITY"].ToString();
                    string line = id;
                    for (int i = 0; i < (40 - id.Length) - quantity.Length; i++)
                    {
                        line += " ";
                    }
                    line += quantity + Environment.NewLine;
                    raw += line;
                }
                raw += "----------------------------------------" + Environment.NewLine;
                raw += "                 Tong cong  :";
                for (int i = 0; i < 11 - Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["SUB_TOTAL"].ToString()).Length; i++)
                {
                    raw += " ";
                }
                raw += Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["SUB_TOTAL"].ToString()) + Environment.NewLine;

                raw += "                 Giam gia   :";
                for (int i = 0; i < 11 - Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL_DISCOUNT"].ToString()).Length; i++)
                {
                    raw += " ";
                }
                raw += Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL_DISCOUNT"].ToString()) + Environment.NewLine;

                raw += "                 Thanh toan :";
                for (int i = 0; i < 11 - Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL"].ToString()).Length; i++)
                {
                    raw += " ";
                }
                raw += Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL"].ToString()) + Environment.NewLine;

                raw += "                 KH dua     :";
                for (int i = 0; i < 11 - Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL_RECEIVED"].ToString()).Length; i++)
                {
                    raw += " ";
                }
                raw += Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["TOTAL_RECEIVED"].ToString()) + Environment.NewLine;

                raw += "                 Tra lai    :";
                for (int i = 0; i < 11 - Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["REFUND"].ToString()).Length; i++)
                {
                    raw += " ";
                }
                raw += Conversion.GetCurrency(dsSaleTemp.Tables["Total"].Rows[0]["REFUND"].ToString()) + Environment.NewLine;

                raw += "----------------------------------------" + Environment.NewLine
                    + String40("Cam on Quy khach. Hen gap lai");

                raw += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine
                    + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine
                    + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine
                    + Environment.NewLine + Environment.NewLine;


                if ("0".Equals(AppConfigFileSettings.isPrintPreview))
                {
                    string printer1, printer2;
                    printer1 = AppConfigFileSettings.printerBill1;
                    printer2 = AppConfigFileSettings.printerBill2;

                    string GS = Convert.ToString((char)29);
                    string ESC = Convert.ToString((char)27);

                    string COMMAND = "";
                    COMMAND = ESC + "@";
                    COMMAND += GS + "V" + (char)1;

                    if (!"".Equals(printer1))
                    {
                        RawPrinterHelper.SendStringToPrinter(printer1, raw);
                        RawPrinterHelper.SendStringToPrinter(printer1, COMMAND);
                    }
                    if (!"".Equals(printer2))
                    {
                        RawPrinterHelper.SendStringToPrinter(printer2, raw);
                        RawPrinterHelper.SendStringToPrinter(printer1, COMMAND);
                    }
                }
                else
                {
                    frm.Show();
                }
                
                //System.IO.File.WriteAllText(@"D:\test.txt", raw);
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintRaw': " + ex.Message);
            }
        }

        #endregion

        #endregion

        #region Event

        #region event load form và các event xử lý dữ liệu nhập vào
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Form load. 
        /// </summary>
        private void frmDialogPayment_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                SetControl();
                if (salePayEn.StrXML.ToString().Trim() != "")
                {
                    ResizeTop();
                    tabPayment.SelectedIndex = 2; 
                }                
                BindCurrency();
                BindCardType();
                LoadValue();
                SetInfoRedInvoice();
                paymented = false;
                txtVND.Focus();
                txtVND.Select();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 :Sự kiện nhập số tiền khách hàng đưa. Tính số tiền trả lại hoặc tiền còn thiếu. 
        /// </summary>
        private void txtVND_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVND.Text.Trim().Length > 0)
                {
                    txtVND.Text = Conversion.GetCurrency(Conversion.Replaces(txtVND.Text));
                    txtVND.SelectionStart = txtVND.Text.Trim().Length;
                    double vndReceived = (txtVND.Text.Trim() != "0") ? Convert.ToDouble(Conversion.Replaces(txtVND.Text)) : 0;
                    double ortherReceived = (txtOrtherMoney.Text.Trim() != "0") ? Convert.ToDouble(Conversion.Replaces(txtOrtherMoney.Text)) : 0;
                    txtTotalReceived.Text = Conversion.GetCurrency((vndReceived + ortherReceived).ToString());
                    SetBalance();
                }
                else
                {
                    txtVND.Text = "0";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : txtVND focus. 
        /// </summary>
        private void txtVND_Enter(object sender, EventArgs e)
        {
            txtVND.Select();
            //PoleDisplayOneRow(strTotalReturn);
        }

        #endregion

        #region event xử lý thanh toán ngoại tệ và thẻ thanh toán
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 :Khi nhập dữ liệu vào lưới thanh toán ngoại tệ thì định dạng lại chuỗi vừa nhập. 
        /// </summary>
        private void dgvCurrencys_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                    {
                        int r = e.RowIndex;
                        int c = e.ColumnIndex;
                        dgvCurrencys.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Conversion.GetCurrency(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Hủy tiêu điểm dgvVisaCard sẽ tính số tiền quy đổi.
        /// </summary>
        private void dgvCurrencys_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = 1;
                if (e.ColumnIndex == 1)
                    col = 2;
                if (e.ColumnIndex == 2)
                    col = 1;

                if (dgvCurrencys.CurrentCell.ColumnIndex == 1 || dgvCurrencys.CurrentCell.ColumnIndex == 2)
                {
                    if (dgvCurrencys.CurrentCell.EditedFormattedValue != null && dgvCurrencys.Rows[e.RowIndex].Cells[col].Value != null)
                    {
                        double x = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.CurrentCell.EditedFormattedValue.ToString()));
                        double y = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[col].Value.ToString()));
                        dgvCurrencys.Rows[e.RowIndex].Cells[3].Value = Conversion.GetCurrency((x * y).ToString());
                        OtherPayment();
                    }
                }
                else if (dgvCurrencys.Rows[e.RowIndex].Cells[1].Value != null && dgvCurrencys.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    double rate = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    double money = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    dgvCurrencys.Rows[e.RowIndex].Cells[3].Value = Conversion.GetCurrency((money * rate).ToString());
                    OtherPayment();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Định dạng lại chuỗi ký tự sang kiểu tiền tệ.
        /// </summary>
        private void txtMoneyCard_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMoneyCard.Text = Conversion.GetCurrency(Conversion.Replaces(txtMoneyCard.Text));
                txtMoneyCard.SelectionStart = txtMoneyCard.Text.Trim().Length;
                OtherPayment();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ.
        /// </summary>
        private void txtMoneyCard_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Tạo sự kiện Keypress cho datagirdview dgvCurrencys. 
        /// </summary>
        private void dgvCurrencys_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvCurrencysCell_KeyPress);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Chặn các ký tự không hợp lệ nhập vào cell tỷ giá và cell số tiền grid ngoại tệ. 
        /// </summary>
        private void dgvCurrencysCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvCurrencys.CurrentCell.ColumnIndex == 1 || dgvCurrencys.CurrentCell.ColumnIndex == 2)
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 :Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void dgvCurrencys_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 :. 
        /// </summary>
        private void dgvCurrencys_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = 1;
                if (e.ColumnIndex == 1)
                    col = 2;
                if (e.ColumnIndex == 2)
                    col = 1;

                if (dgvCurrencys.CurrentCell.ColumnIndex == 1 || dgvCurrencys.CurrentCell.ColumnIndex == 2)
                {
                    if (dgvCurrencys.CurrentCell.EditedFormattedValue != null && dgvCurrencys.Rows[e.RowIndex].Cells[col].Value != null)
                    {
                        double x = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.CurrentCell.EditedFormattedValue.ToString()));
                        double y = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[col].Value.ToString()));
                        dgvCurrencys.Rows[e.RowIndex].Cells[3].Value = Conversion.GetCurrency((x * y).ToString());
                        OtherPayment();
                    }
                }
                else if (dgvCurrencys.Rows[e.RowIndex].Cells[1].Value != null && dgvCurrencys.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    double rate = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    double money = Convert.ToDouble(Conversion.Replaces(dgvCurrencys.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    dgvCurrencys.Rows[e.RowIndex].Cells[3].Value = Conversion.GetCurrency((money * rate).ToString());
                    OtherPayment();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Khi đưa tiêu điểm vào Datagridview Currencys bắt đầu edit cell. 
        /// </summary>
        private void dgvCurrencys_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {                
                dgvCurrencys.Rows[e.RowIndex].Selected = true;
                dgvCurrencys.BeginEdit(true);                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region event chặn các ký tự đầu vào không phù hợp
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtVND_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtOrtherMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtCashSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtDiscounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtPromotion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtSpacialDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtTotalReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtTotalPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtRefund_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Chặn các ký tự không hợp lệ. 
        /// </summary>
        private void txtPayMissing_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        #endregion

        #region event đóng mở thanh toán mở rộng và ghi chú hóa đơn
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng ghi chú hóa đơn. 
        /// </summary>
        private void btnResize_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeBottom();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng ghi chú hóa đơn. 
        /// </summary>       
        private void pnlRemarks_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeBottom();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng ghi chú hóa đơn. 
        /// </summary>
        private void lblRemarks_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeBottom();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng thanh toán mở rộng. 
        /// </summary>
        private void btnResizeTop_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeTop();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng thanh toán mở rộng. 
        /// </summary>
        private void lblOtherPay_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeTop();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Mở hoặc đóng thanh toán mở rộng. 
        /// </summary>
        private void pnlOtherPay_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeTop();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion

        #region event xử lý các coltrol Phiếu quà tặng
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Xử lý lấy thông tin phiếu quà tặng. 
        /// </summary>
        private void dgvVoucherGift_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CheckInputGift(e.ColumnIndex, e.RowIndex);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Xử lý lấy thông tin phiếu quà tặng. 
        /// </summary>
        private void dgvVoucherGift_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CheckInputGift(e.ColumnIndex, e.RowIndex);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Tạo sự kiện Keypress cho datagirdview dgvVoucherGift. 
        /// </summary>
        private void dgvVoucherGift_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Chặn các ký tự không hợp lệ nhập vào cell thanh toán số tiền phiếu quà tặng. 
        /// </summary>
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvVoucherGift.CurrentCell.ColumnIndex == 4)
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Khi đưa tiêu điểm vào Datagridview Vouchergift bắt đầu edit cell. 
        /// </summary>
        private void dgvVoucherGift_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvVoucherGift.Rows[e.RowIndex].Selected = true;
                dgvVoucherGift.BeginEdit(true);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region event click button
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Sự kiện click nút thanh toán. 
        /// </summary>
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                SetDataAndPay();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Sự kiện click nút thanh toán và in. 
        /// </summary>
        private void btnPayAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SetDataAndPay();
                //PrintTemp();   
                PrintRaw();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : In hóa đơn tạm.
        /// </summary>
        private void btnPrintTemp_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintTemp();
                PrintRaw();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Bôi đen toàn bộ txtMoneyCard.
        /// </summary>
        private void txtMoneyCard_Enter(object sender, EventArgs e)
        {
            txtMoneyCard.Select();
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý các phím tắt trên form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F7)
            {
                try
                {
                    //PrintTemp();
                    PrintRaw();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.F7 error: " + ex.Message);
                }
            }
            if (keyData == Keys.F8)
            {
                try
                {
                    SetDataAndPay();
                    //PrintTemp();
                    PrintRaw();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.F8 error: " + ex.Message);
                }
            }
            if (keyData == Keys.F9)
            {
                try
                {
                    SetDataAndPay();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.F9 error: " + ex.Message);
                }
            }
            if (keyData == Keys.Escape)
            {
                try
                {
                    this.Close();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.ESC error: " + ex.Message);
                }
            }
            // sự dụng key Alt + row
            if (keyData == (Keys.Alt | Keys.N))
            {
                try
                {
                    //PrintTemp();
                    PrintRaw();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.N error: " + ex.Message);
                }
            }
            // sự dụng key Alt + row
            if (keyData == (Keys.Alt | Keys.I))
            {
                try
                {
                    SetDataAndPay();
                    //PrintTemp();
                    PrintRaw();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.I error: " + ex.Message);
                }
            }
            // sự dụng key Alt + row
            if (keyData == (Keys.Alt | Keys.T))
            {
                try
                {
                    SetDataAndPay();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.I error: " + ex.Message);
                }
            }
            // sự dụng key Alt + row
            if (keyData == (Keys.Alt | Keys.H))
            {
                try
                {
                    this.Close();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.H error: " + ex.Message);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Hỗ trợ nhập số tiền khách hàng đưa.
        /// </summary>
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                frmDialogSuportPayment dialogSuport = new frmDialogSuportPayment();
                dialogSuport.StartPosition = FormStartPosition.CenterScreen;
                dialogSuport.MinimizeBox = false;
                dialogSuport.MaximizeBox = false;
                dialogSuport.ShowIcon = true;
                dialogSuport.ShowDialog();
                if (dialogSuport.Money != "0" && dialogSuport.Money != null)
                {
                    txtVND.Text = dialogSuport.Money;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Đóng form thanh toán. 
        /// </summary>        
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintRaw();
                this.Close();
                paymented = false;
                salePayEn = null;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Ghi file log form đã đóng.
        /// </summary>
        private void frmDialogPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        #endregion

        #region Event hóa đơn đỏ
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Enable textbox thông tin hóa đơn đỏ. 
        /// </summary>
        private void chkRedBill_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.Enabled = chkRedBill.Checked;
                txtAdress.Enabled = chkRedBill.Checked;
                txtTaxCode.Enabled = chkRedBill.Checked;
                rtfRemarkRed.Enabled = chkRedBill.Checked;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void txtPromotion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (strTotalReturn.Length > 0)
                {
                    PoleDisplayOneRow(strTotalReturn);
                }
            }
        }
        
        #endregion


        private string String40(string raw)
        {
            if (raw.Length > 40)
            {
                string raw1 = raw.Substring(0, 40);
                string raw2 = raw.Substring(40);
                if (raw2.Length > 40)
                {
                    raw2 = raw2.Substring(0, 40);
                }
                else
                {
                    int n = (40 - raw2.Length);
                    for (int i = 0; i < n; i++)
                    {
                        raw2 = raw2 + " ";
                    }
                }
                raw = raw1 + Environment.NewLine + raw2;
            }
            else
            {
                int n = (40 - raw.Length) / 2;
                for (int i = 0; i < n; i++)
                {
                    raw = " " + raw;
                }
                for (int i = 0; i < (40 - raw.Length) - n; i++)
                {
                    raw = raw + " ";
                }
            }
            return raw;
        }

        private string Last40(string raw)
        {
            if (raw.Length > 40)
            {
                string raw1 = raw.Substring(0, 40);
                string raw2 = raw.Substring(40);
                if (raw2.Length > 40)
                {
                    raw2 = raw2.Substring(0, 40);
                }
                else
                {
                    int n = (40 - raw2.Length);
                    for (int i = 0; i < n; i++)
                    {
                        raw2 = raw2 + " ";
                    }
                }
                raw = raw1 + Environment.NewLine + raw2;
            }
            else
            {
                int n = (40 - raw.Length);
                for (int i = 0; i < n; i++)
                {
                    raw = raw + " ";
                }
            }
            return raw;
        }

        private string ConvertVN(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        } 
        
    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}

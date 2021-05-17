using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;

using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using SaleMTInterfaces.FrmCustomerEmployee;
using System.IO.Ports;
using System.Configuration;




namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmSale : TabForm
    {
        #region Declaration
        private const string TAB_TEXT = "Bán hàng";
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private float disPercent = 0;
        private float couPercent = 0;
        private bool boChangePrice = false;
        private DataTable dtSale = new DataTable();
        private DataTable dtChoseProduct = new DataTable();
        private List<string> lstCoupon = new List<string>();
        private bool[] status;
        SerialPort sp;
        bool CheckC;
        private string TEXT_END = "Cam on Quy khach !";
        
        public string strProduct, strQuantity, strDisplay, strCusName, strCusAdress, strTotal,strprice;
        #endregion

        #region Contructors
       
        public frmSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxBanHang.Text = translate["frmSale.gbxBanHang.Text"];
            this.label12.Text = translate["frmSale.label12.Text"];
            this.lblDate.Text = translate["frmSale.lblDate.Text"];
            this.label3.Text = translate["frmSale.label3.Text"];
            this.label2.Text = translate["frmSale.label2.Text"];
            this.label1.Text = translate["frmSale.label1.Text"];
            this.btnF2.Text = translate["frmSale.btnF2.Text"];
            this.btnF3.Text = translate["frmSale.btnF3.Text"];
            this.btnF8.Text = translate["frmSale.btnF8.Text"];
            this.btnF9.Text = translate["frmSale.btnF9.Text"];
            this.btnF10.Text = translate["frmSale.btnF10.Text"];
            this.btnF11.Text = translate["frmSale.btnF11.Text"];
            this.btnF12.Text = translate["frmSale.btnF12.Text"];
            this.btnEsc.Text = translate["frmSale.btnEsc.Text"];
            this.gbxDanhSach.Text = translate["frmSale.gbxDanhSach.Text"];
            this.clnBARCODE.HeaderText = translate["frmSale.clnBARCODE.HeaderText"];
            this.clnPRODUCT_ID.HeaderText = translate["frmSale.clnPRODUCT_ID.HeaderText"];
            this.clnPRODUCT_NAME.HeaderText = translate["frmSale.clnPRODUCT_NAME.HeaderText"];
            this.clnUNIT_NAME.HeaderText = translate["frmSale.clnUNIT_NAME.HeaderText"];
            this.clnQUANTITY.HeaderText = translate["frmSale.clnQUANTITY.HeaderText"];
            this.clnINVENTORY.HeaderText = translate["frmSale.clnINVENTORY.HeaderText"];
            this.clnPrice.HeaderText = translate["frmSale.clnPrice.HeaderText"];
            this.clnIntoMoney.HeaderText = translate["frmSale.clnIntoMoney.HeaderText"];
            this.clnCoupons.HeaderText = translate["frmSale.clnCoupons.HeaderText"];
            this.clnCustomerCard.HeaderText = translate["frmSale.clnCustomerCard.HeaderText"];
            this.clnPromotion.HeaderText = translate["frmSale.clnPromotion.HeaderText"];
            this.clnSpecialDiscount.HeaderText = translate["frmSale.clnSpecialDiscount.HeaderText"];
            this.clnPayment.HeaderText = translate["frmSale.clnPayment.HeaderText"];
            this.clnEmployee.HeaderText = translate["frmSale.clnEmployee.HeaderText"];
            this.clnRemarks.HeaderText = translate["frmSale.clnRemarks.HeaderText"];
            this.gbxKhachHang.Text = translate["frmSale.gbxKhachHang.Text"];
            this.label13.Text = translate["frmSale.label13.Text"];
            this.label4.Text = translate["frmSale.label4.Text"];
            this.label6.Text = translate["frmSale.label6.Text"];
            this.label5.Text = translate["frmSale.label5.Text"];
            this.gbxThanhToan.Text = translate["frmSale.gbxThanhToan.Text"];
            this.label7.Text = translate["frmSale.label7.Text"];
            this.label11.Text = translate["frmSale.label11.Text"];
            this.label10.Text = translate["frmSale.label10.Text"];
            this.label9.Text = translate["frmSale.label9.Text"];
            this.label8.Text = translate["frmSale.label8.Text"];
            this.Text = translate["frmSale.Text"];
        }	

        #endregion

        #region Method/Function

        #region Method process control
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Khởi tạo đồng hồ đếm thời gian. 
        /// </summary>
        private void Clock()
        {
            try
            {
                dtpTime.Value = sqlDac.GetDateTimeServer();
                timerSales.Start();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Clock' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 :Load khách hàng mặc định.
        /// </summary>
        private void LoadDefaultCustomer()
        {
            SaleEntities saleEnDefault = Sale.GetDefaultCustomer();
            try
            {
                txtCustomerCode.Text = saleEnDefault.CusCode;
                txtCustomerName.Text = saleEnDefault.CusName;
                rtfAdress.Text = saleEnDefault.CusAdress;
                lblCusGroup.Text = saleEnDefault.CusCode;
                txtPurchase.Text = Conversion.GetCurrency(saleEnDefault.CusPurchase.ToString());
                // Kiểm tra có tồn tại trong database ko
                try
                {
                    int dept = (!chkAllCustomer.Checked) ? UserImformation.DeptNumber : 0;
                    if (txtCustomerCode.Text.Trim() != "")
                    {
                        SaleEntities saleEn = Sale.CheckCustomerDefault(txtCustomerCode.Text.Trim(), dept, sqlDac);
                        if (saleEn != null)
                        {
                            txtCustomerName.Text = saleEn.CusName;
                            txtCustomerCode.Text = saleEn.CusCode;
                            rtfAdress.Text = saleEn.CusAdress;
                            lblCusGroup.Text = saleEn.CusCode;
                            txtPurchase.Text = Conversion.GetCurrency(saleEn.CusPurchase.ToString());
                            txtSalesCode.Focus();
                            this.Text = saleEn.CusName;
                            this.DSSMenuTab.Text = saleEn.CusName;
                        }
                        else
                        {
                            txtCustomerCode.Text = "";
                            txtCustomerName.Text = "";
                            rtfAdress.Text = "";
                            txtPurchase.Text = "0";
                        }

                        //Hiển thị thông tin ra pole

                        strCusName = (saleEn != null) ? saleEn.CusName : "";
                        strCusAdress = (saleEn != null) ? saleEn.CusAdress : "";
                        
                        string strDisCus = "KH:" + Conversion.convertToUnSign(strCusName);
                        PoleDisplayOneRow(strDisCus);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'LoadDefaultCustomer': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013 :Load giá trị 0 cho các control thanh toán.
        /// </summary>
        private void SetDefaultConrolPayment()
        {
            try
            {
                txtCashSales.Text = "0";
                txtDiscounts.Text = "0";
                txtPromotion.Text = "0";
                txtSpecialDiscount.Text = "0";
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetDefaultConrolPayment': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Get thông tin nhân viên đổ vào Combobox trên datagridview.
        /// </summary>
        private void SetEmployeeInfo()
        {
            try
            {
                DataTable dtEmployee = new DataTable();
                dtEmployee = Sale.GetEmployeeInfo(UserImformation.DeptNumber, sqlDac);
                if (dtEmployee.Rows.Count > 0)
                {
                    clnEmployee.DataSource = dtEmployee;
                    clnEmployee.DataPropertyName = "EMPLOYEE_ID";
                    clnEmployee.DisplayMember = "FULLNAME";
                    clnEmployee.ValueMember = "EMPLOYEE_ID";
                    //clnEmployee.DefaultCellStyle.NullValue = dtEmployee.Rows[0][4];
                    dgvListSales.Rows[dgvListSales.Rows.Count - 1].Cells["clnEmployee"].Value = dtEmployee.Rows[0]["EMPLOYEE_ID"].ToString(); // Should display "Two"

                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetEmployeeInfo': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : bind dữ liệu vào datagridview.
        /// </summary>
        private void BindToDataGridview(string salesCode, int quantity)
        {
            try
            {
                int count = dgvListSales.Rows.Count;
                dgvListSales.AutoGenerateColumns = false;

                dgvListSales.DataSource = Sale.AddRowDatatable(salesCode, quantity, dtSale, sqlDac);
                dgvListSales.ClearSelection();
                int countNew = dgvListSales.Rows.Count;
                if (countNew > 0 && count < countNew)
                {
                    dgvListSales.CurrentCell = dgvListSales[4, dgvListSales.Rows.Count - 1];
                    dgvListSales.Rows[dgvListSales.Rows.Count - 1].Selected = true;
                }
                BindToControl();
            }
            catch (Exception ex)
            {
                log.Error(" Error 'BindToDataGridview': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Bind dữ liệu vào các control thanh toán.
        /// </summary>
        private void BindToControl()
        {
            SaleEntities saleEn = Sale.CalPayment(dtSale,disPercent,couPercent,dtChoseProduct);
            try
            {
                txtCashSales.Text = (saleEn != null) ? saleEn.Amount : "0";
                txtDiscounts.Text = (saleEn != null) ? saleEn.Discount : "0";
                txtPromotion.Text = (saleEn != null) ? saleEn.Promotion : "0";
                txtSpecialDiscount.Text = (saleEn != null) ? saleEn.SpecialDiscount : "0";
                txtPayment.Text = (saleEn != null) ? saleEn.TotalPay : "0";
            }
            catch (Exception ex)
            {
                log.Error(" Error 'BindToControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Làm rỗng các control.
        /// </summary>
        private void ResetControl()
        {
            try
            {
                txtCashSales.Text = "0";
                txtSalesCode.Text = "";
                txtPromotion.Text = "0";
                txtDiscounts.Text = "0";
                txtPayment.Text = "0";
                txtSpecialDiscount.Text = "0";
                disPercent = 0;
                couPercent = 0;
                dtSale.Rows.Clear();
                boChangePrice = false;
                lstCoupon.Clear();
                Clock();
                LoadDefaultCustomer();
                if (dgvListSales.Rows.Count > 0)
                {
                    for (int i = dgvListSales.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvListSales.Rows[i].IsNewRow)
                        {
                            dgvListSales.Rows.RemoveAt(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'ResetControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Set menu điều khiển.
        /// </summary>
        private void SetMenu()
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool[] active = { false, false, false, false, false, false, false, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Event handling Method

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
        /// Người tạo Hieppd – 10/12/2013 : Hien thi 2 dong tren PoleDisplay
        /// </summary>
        private void PoleDisplay(string strPole, string strPice)
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


                        if (strPole.Length < 20)
                        {
                            strPole = strPole.Insert(strPole.Length, " ");
                            sp.Write(strPole.Substring(0, 20));

                        }
                        else
                        {
                            sp.Write(strPole.Substring(0, 20));
                        }

                        sp.Write(strPice.Substring(0));
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
                log.Error("Error 'PoleDisplayOneRow': " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Xử lý sự kiện click hoặc nhấn phím tắt F2 thay đổi số lượng.
        /// </summary>
        private void EventChangeQuantity()
        {
            try
            {
                if (dgvListSales.Rows.Count > 0)
                {
                    DataGridViewRow r = dgvListSales.CurrentRow;
                    DataGridViewRow rd;
                    if (r != null)
                    {
                        rd = (r != null) ? r : dgvListSales.Rows[dgvListSales.Rows.Count - 1];
                    }
                    else
                    {
                        dgvListSales.CurrentCell = dgvListSales[4, dgvListSales.Rows.Count - 1];
                        rd = dgvListSales.CurrentRow;
                    }
                    string salesCode = rd.Cells["clnPRODUCT_ID"].Value.ToString();
                    DataRow[] drSelected = dtSale.Select("PRODUCT_ID = '" + salesCode + "'");
                    int quantity = Sale.ShowInputQuantity(Convert.ToInt32(drSelected[0]["QUANTITY"].ToString()));
                    double price = Convert.ToDouble(Conversion.Replaces(drSelected[0]["PRICE"].ToString()));
                    drSelected[0]["QUANTITY"] = quantity;
                    //drSelected[0]["INTOMONEY"] = Conversion.GetCurrency((price * quantity).ToString());
                    //drSelected[0]["PAYMENT"] = Conversion.GetCurrency((price * quantity).ToString());
                    BindToControl();

                    //10/12: Hiển thị thông tin sản phẩm:
                    string strDiplay = Conversion.convertToUnSign(strProduct.Substring(0, 20));
                    string strPrice1 = "GIA: " + Conversion.GetCurrency(strprice);
                    PoleDisplay(strDiplay, strPrice1);
                        
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'EventChangeQuantity': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Xử lý sự kiện click hoặc nhấn phím tắt F8 thanh toán.
        /// </summary>
        private void EventPayment()
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                if (dgvListSales.Rows.Count > 0)
                {
                    // Kiểm tra ngày thực tế 
                    DateTime datenow = sqlDac.GetDateTimeServer();
                    string checkInvent = Sale.CheckInventory(dgvListSales);
                    if (checkInvent != "")
                    {
                        MessageBox.Show(Properties.rsfSales.Sale3.ToString() + " \n-------------------------------------------" + checkInvent,
                        Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    // Kiểm tra khuyến mại
                    bool promotion = false;                    
                    DataSet dsCheckPromotion = Sale.GetPromotion(sqlDac, dgvListSales, datenow, lblCusGroup.Text.Trim());
                    double discount = 0;
                    StringBuilder strXml = new StringBuilder();
                    if (dsCheckPromotion.Tables[0].Rows.Count > 0)
                    {
                        // set entities dữ liệu chương trình khuyến mại
                        saleEn.DtPromotionMoney = dsCheckPromotion.Tables[0].Copy();
                        // mở dialog khuyến mại
                        dlgPromotion dlgPro = new dlgPromotion(translate);
                        dlgPro.DsPromotion = dsCheckPromotion;
                        dlgPro.StartPosition = FormStartPosition.CenterScreen;
                        dlgPro.ShowDialog();
                        discount = dlgPro.Discount;
                        // xử lý nếu có chương trình khuyến mại bằng tiền hoặc %
                        if (discount > 0)
                        {
                            promotion = true;
                            //for (int i = 0; i < dlgPro.LstProPercent.Count; i++)
                            //{
                            //    DataRow[] rowDiscount = dsCheckPromotion.Tables[0].Select("PRODUCT_ID = '" + dlgPro.LstProPercent[i].ToString() + "'");
                                
                            //    string money = rowDiscount[0]["Discount_Amount"].ToString();
                            //    DataRow[] row = dtSale.Select("PRODUCT_ID = '" + dlgPro.LstProPercent[i].ToString() + "'");
                            //    row[0]["PROMOTION"] = Conversion.GetCurrency(money);



                            //    //// giảm số tiền phải thanh toán
                            //    //double intoMoney = Convert.ToDouble(Conversion.Replaces(row[0]["INTOMONEY"].ToString()));
                            //    //row[0]["PAYMENT"] = Conversion.GetCurrency((intoMoney - Convert.ToDouble(money)).ToString());
                            //    BindToControl();
                            //}
                            // gán giá trị khuyến mại tiền cho từng sản phẩm
                            for (int i = 0; i < dsCheckPromotion.Tables[2].Rows.Count; i++)
                            {
                                string proId = dsCheckPromotion.Tables[2].Rows[i]["ProductId"].ToString().Trim();
                                string money = dsCheckPromotion.Tables[2].Rows[i]["discount"].ToString();
                                DataRow[] row = dtSale.Select("PRODUCT_ID = '" + proId + "'");
                                if (row.Length > 0)
                                    row[0]["PROMOTION"] = Conversion.GetCurrency(money);
                                BindToControl();
                            }
                            
                        }
                        // xử lý nếu có chương trình khuyến mại tặng phẩm
                        if (dsCheckPromotion.Tables[1].Rows.Count > 0)
                        {
                            dlgChooseGift dlgChoose = new dlgChooseGift(translate);
                            dlgChoose.DtGift = dsCheckPromotion.Tables[1];
                            dlgChoose.StartPosition = FormStartPosition.CenterScreen;
                            dlgChoose.ShowDialog();
                            if (dlgChoose.StrXml != null && dlgChoose.StrXml.ToString() != "")
                            {
                                saleEn.DtPromotionGift = dlgChoose.DtGift;
                                // xóa các dòng khuyến mại tặng phẩm có số lượng bằng 0
                                for (int i = 0; i < saleEn.DtPromotionGift.Rows.Count; i++)
                                {
                                    int quan = Convert.ToInt32(saleEn.DtPromotionGift.Rows[i]["QUANTITY_GIFTS"]);
                                    if (quan == 0)
                                    {
                                        saleEn.DtPromotionGift.Rows.RemoveAt(i);
                                    }
                                }
                                //strXml = (saleEn.DtPromotionGift.Rows.Count > 0) ? dlgChoose.StrXml : strXml.Append("");
                                strXml = dlgChoose.StrXml;
                                promotion = true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtSale.Rows.Count; i++)
                        {
                            dtSale.Rows[i]["PROMOTION"] = "0";
                            BindToControl();
                        }
                        promotion = true;
                    }
                    //Kết thúc kiểm tra khuyên mại

                    if (promotion)
                    {
                        txtPromotion.Text = Conversion.GetCurrency(discount.ToString());

                        saleEn.Amount = txtCashSales.Text.Trim();
                        saleEn.Discount = txtDiscounts.Text.Trim();
                        saleEn.SpecialDiscount = txtSpecialDiscount.Text.Trim();
                        saleEn.Promotion = txtPromotion.Text.Trim();
                        saleEn.TotalPay = txtPayment.Text.Trim();
                        saleEn.Datetime = dtpTime.Value;
                        saleEn.CusName = txtCustomerName.Text;
                        saleEn.CusCode = lblCusGroup.Text.Trim();
                        saleEn.CusAdress = rtfAdress.Text;
                        saleEn.CusGroup = lblCusGroup.Text;
                        saleEn.CusPurchase = Convert.ToDouble(Conversion.Replaces(txtPurchase.Text));
                        saleEn.StrXml = strXml;
                        saleEn.ListCoupon = this.lstCoupon;

                        //10/12/13: hiển thị các thông tin thanh toán ra poledisplay:
                        //strCusName = saleEn.CusName;
                        //strCusAdress = saleEn.CusAdress;
                        strTotal = saleEn.TotalPay.ToString();

                        //strDisplay = "Mã sản phẩm: " + strProduct + " - Số lượng: " + strQuantity + " - Thành tiền: " + strTotal + " - Tên KH: " + strCusName + " - Địa chỉ: " + strCusAdress;
                        //strDisplay = strCusName.Substring(0,20) + " Đ/c: " + strCusAdress + " TT: " + strTotal;
                        string strTotalPayment = "Thanh tien:" + strTotal;
                        PoleDisplayOneRow(strTotalPayment);

                        bool paymented = Sale.Paymenting(saleEn, dgvListSales, sqlDac, translate);
                        if (paymented)
                        {
                            MessageBox.Show(Properties.rsfSales.Sale6.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            ResetControl();
                            txtCustomerCode.Focus();
                            txtCustomerCode.Select();
                            this.Text = TAB_TEXT;
                            this.DSSMenuTab.Text = TAB_TEXT;
                            disPercent = 0;
                            couPercent = 0;
                            boChangePrice = false;
                            dtSale.Rows.Clear();
                            lstCoupon.Clear();
                        }
                        PoleDisplayOneRow(TEXT_END);
                    }
                    

                }
                else
                {
                    MessageBox.Show(Properties.rsfSales.Sale.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                
            }
            catch (Exception ex)
            {
                log.Error("Error 'EventPayment': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Xử lý sự kiện click hoặc nhấn phím tắt F10 chiết khấu đặc biệt.
        /// </summary>
        private void EventSpecialDiscount()
        {
            try
            {
                // Làm rỗng control chiết khấu.
                txtSpecialDiscount.Text = "0";
                foreach (DataRow r in dtSale.Rows)
                {
                    r["SPECIALDISCOUNT"] = "0";
                }
                disPercent = 0;
                BindToControl();
                if (dgvListSales.Rows.Count > 0)
                {
                    float totalPay = (float)Convert.ToDouble(Conversion.Replaces(txtPayment.Text));
                    SaleEntities saleEn = Sale.SpecialDiscounting(dtSale, totalPay, translate);
                    if (saleEn != null)
                    {
                        if (totalPay < saleEn.Money)
                        {
                            MessageBox.Show(Properties.rsfSales.SpecialDiscount6.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            disPercent = saleEn.Percent;
                            txtSpecialDiscount.Text = saleEn.StringMoney;
                            dtChoseProduct = saleEn.DtspecialDiscount;
                            BindToControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Properties.rsfSales.SpecialDiscount8, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'EventSpecialDiscount': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 29/10/2013 : Xử lý sự kiện click hoặc nhấn phím tắt F11 phiếu giảm giá.
        /// </summary>
        private void EventCoupon()
        {
            try
            {
                dlgCoupon dlgCou = new dlgCoupon(translate);
                dlgCou.LstCoupon = this.lstCoupon;
                dlgCou.StartPosition = FormStartPosition.CenterScreen;
                dlgCou.ShowDialog();
                if (dlgCou.Percent != 0)
                {
                    couPercent = (float)dlgCou.Percent;
                    foreach (DataRow r in dtSale.Rows)
                    {
                        double moneys = Convert.ToDouble(Conversion.Replaces(r["INTOMONEY"].ToString()));
                        double coupon = Convert.ToDouble(dlgCou.Percent * (moneys / 100));
                        r["COUPONS"] = Conversion.GetCurrency(coupon.ToString());
                        //r["PAYMENT"] = Conversion.GetCurrency((moneys-coupon).ToString());
                        //BindToControl();
                    }
                    if (dlgCou.LstCoupon != null && dlgCou.LstCoupon.Count > 0)
                    {                        
                        this.lstCoupon = dlgCou.LstCoupon;
                    }
                }
                else
                {
                    couPercent = 0;
                    foreach (DataRow r in dtSale.Rows)
                    {
                        r["COUPONS"] = "0";
                    }
                    this.lstCoupon.Clear();
                }
                BindToControl();


            }
            catch (Exception ex)
            {
                log.Error("Error 'EventCoupon': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 29/10/2013 : Xử lý sự kiện thay đổi giá sản phẩm.
        /// </summary>
        private void EventChangePrice()
        {
            try
            {
                if (dgvListSales.Rows.Count > 0)
                {
                    DataGridViewRow rd = dgvListSales.CurrentRow;
                    string salesCode = rd.Cells["clnPRODUCT_ID"].Value.ToString();
                    boChangePrice = Sale.ChangePrice(dtSale, salesCode, boChangePrice, translate);
                    BindToControl();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: 'EventChangePrice'" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 29/10/2013 : Xử lý sự kiện mở form quản lý khách hàng.
        /// </summary>
        /// 
        frmCustomerManagement frmCusMana;
        private void OpenCusManage()
        {
            try
            {                
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool blIsExist = false;
                //Kiểm tra xem form đã khởi tạo chưa
                
                blIsExist = frmCusMana != null;
                //Nếu đã khởi tạo kiểm tra trạng thái đóng hay chưa
                if (blIsExist)
                    blIsExist = !frmCusMana.IsDisposed;
                if (!blIsExist)
                {
                    frmCusMana = new frmCustomerManagement(translate);
                    frmCusMana.MdiParent = parMain;
                    Control[] control = parMain.Controls.Find("tlsTab", false);
                    foreach (Control ctrol in control)
                    {
                        if (ctrol is ToolStrip)
                        {
                            ToolStrip toolStrip = (ToolStrip)ctrol;
                            frmCusMana.DSSMenuBar = toolStrip;
                            toolStrip.Items.Add(frmCusMana.DSSMenuTab);
                            frmCusMana.ListButton = toolStrip.Items;
                        }
                    }
                    parMain.mnuNewActive();
                    frmCusMana.Show();
                    frmCusMana.DSSMenuTab.Text = frmCusMana.Text;
                }
                else
                    frmCusMana.Activate();
            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenCusManage': " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Form load.
        /// </summary>
        private void frmSales_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: Form started !");
                lblDate.Text = sqlDac.GetDateTimeServer().ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                dtpTime.Format = DateTimePickerFormat.Time;
                boChangePrice = false;
                SetDefaultConrolPayment();
                txtCustomerCode.Focus();
                txtCustomerCode.Select();
                Sale.CreateDatable(dtSale);
                LoadDefaultCustomer();
                Clock();
                SetMenu();
                disPercent = 0;
                couPercent = 0;
                lstCoupon.Clear();
                boChangePrice = false;
                lblShifts.Text = UserImformation.ShiftCode.Substring(UserImformation.ShiftCode.Length-2,2);

                //load PoleDisplay
                if (sp != null)
                {                    
                    sp.PortName = UserImformation.PortName.ToString();
                    sp.Parity = Parity.None;
                    sp.BaudRate = UserImformation.BaudRate;
                    sp.DataBits = UserImformation.DataBits;
                    sp.Open();                    
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : KeyPress- Chặn các ký tự chữ không hợp lệ nhập vào datetimepicker.         
        /// </summary>
        private void dtpTime_KeyPress(object sender, KeyPressEventArgs e)
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
                log.Error("Error: " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Sự kiện timer .
        /// Người sửa Thanvn - 05/10/2013 : Cộng thêm 1s vào giờ hiện tại
        /// </summary>
        private void timerSales_Tick(object sender, EventArgs e)
        {
            try
            {
                dtpTime.Value = dtpTime.Value.AddSeconds(1);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Sự kiện enter tìm kiếm sản phẩm theo mã sản phẩm và thêm vào danh sách sản phẩm bán.
        /// </summary>
        private void txtSalesCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtCustomerName.Text.Trim() != "")
                    {                        
                        if (txtSalesCode.Text.Trim().Length > 3)
                        {
                            if (txtSalesCode.Text.Trim() != "")
                            {
                                SaleEntities saleEntities = Sale.showProducts(txtSalesCode.Text.Trim(), sqlDac, translate);
                                if (saleEntities != null)
                                {
                                    if (saleEntities.Quantity != 0)
                                    {
                                        BindToDataGridview(saleEntities.ProductCode, saleEntities.Quantity);
                                        // get thông tin nhân viên
                                        SetEmployeeInfo();
                                        //bind dữ liệu số tiền thanh toán vào các control
                                        BindToControl();
                                        //làm rỗng text box mã sản phẩm
                                        txtSalesCode.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(SaleMTInterfaces.Properties.rsfSales.Sale8.ToString(), SaleMTInterfaces.Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);                                    
                                    txtSalesCode.Select(0,txtSalesCode.Text.Length);
                                }
                                //10/12/13: Hiển thị thông tin sản phẩm
                                //strProduct = saleEntities.ProductCode.ToString();
//                              strQuantity = saleEntities.Quantity.ToString();
                                foreach (DataGridViewRow r in dgvListSales.Rows)
                                {
                                    if (r.Cells[2].Value != null)
                                    {
                                        strProduct = r.Cells[2].Value.ToString().Trim();
                                       
                                    }
                                    if (r.Cells[6].Value != null)
                                    {
                                        strprice = r.Cells[6].Value.ToString().Trim();
                                    }

                                }
                                // strDiplay = Conversion.convertToUnSign(strProduct.Substring(0,20)) ;
                                string strDiplay = Conversion.convertToUnSign(strProduct);
                                string strPrice1 = "Gia: " + Conversion.GetCurrency(strprice);
                                PoleDisplay(strDiplay, strPrice1);
                               
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show(Properties.rsfSales.Sale4.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfSales.Sale5.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        txtCustomerCode.Focus();
                        txtCustomerCode.Select();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Sự kiện dataBindingComplete. Thay đổi màu nền 1 dòng datagridview. 
        /// Nếu số lượng bán lớn hơn số lượng tồn kho sẽ có màu vàng.
        /// </summary>
        private void dgvListSales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Thay đổi màu nền của 1 dòng trên datagridview.
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvListSales.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    DataGridViewCellStyle bgcolorYellow = dgvListSales.DefaultCellStyle.Clone();
                    bgcolorYellow.BackColor = Color.Yellow;
                    foreach (DataGridViewRow r in dgvListSales.Rows)
                    {
                        int inventory = Convert.ToInt32(Conversion.Replaces(r.Cells["clnINVENTORY"].Value.ToString())) - Convert.ToInt32(r.Cells["clnQUANTITY"].Value);
                        r.DefaultCellStyle = (inventory >= 0) ? bgcolor : bgcolorYellow;
                        // căn lề phải cho các cell là số
                        for (int i = 4; i <= 12; i++)
                        {
                            r.Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
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
        /// Người tạo Luannv – 27/09/2013 : Bind lại dữ liệu thanh toán. 
        /// </summary>
        private void dgvListSales_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                BindToControl();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Thay đổi số lượng sản phẩm đang được chọn trong danh sách sản phẩm bán.         
        /// </summary>
        private void btnF2_Click(object sender, EventArgs e)
        {
            EventChangeQuantity();
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý khi có 1 phím chỉ định được nhấn.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.F2)
                {
                    EventChangeQuantity();
                }
                if (keyData == Keys.F3)
                {
                    OpenCusManage();
                }
                if (keyData == Keys.F4)
                {
                    txtCustomerCode.Focus();
                    txtCustomerCode.Select(0,txtCustomerCode.Text.Length);
                }
                if (keyData == Keys.F5)
                {
                    txtSalesCode.Focus();
                    txtSalesCode.Select(0,txtSalesCode.Text.Length);
                }
                if (keyData == Keys.F8)
                {
                    EventPayment();
                }
                if (keyData == Keys.F9)
                {
                    EventChangePrice();
                }
                if (keyData == Keys.F10)
                {
                    EventSpecialDiscount();
                }
                if (keyData == Keys.F11)
                {
                    EventCoupon();
                }
                if (keyData == Keys.F12)
                {
                    DialogResult result = MessageBox.Show(Properties.rsfSales.Sale1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        ResetControl();
                    }
                }
                if (keyData == Keys.Escape)
                {
                    DialogResult result = MessageBox.Show(Properties.rsfSales.Sale2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                if (keyData == (Keys.Alt|Keys.S))
                {
                    EventChangeQuantity();
                }
                if (keyData == (Keys.Alt | Keys.A))
                {
                    OpenCusManage();
                }
                if (keyData == (Keys.Alt | Keys.T))
                {
                    EventPayment();
                }
                if (keyData == (Keys.Alt | Keys.Y))
                {
                    EventChangePrice();
                }
                if (keyData == (Keys.Alt | Keys.C))
                {
                    EventSpecialDiscount();
                }
                if (keyData == (Keys.Alt | Keys.P))
                {
                    EventCoupon();
                }
                if (keyData == (Keys.Alt | Keys.H))
                {
                    DialogResult result = MessageBox.Show(Properties.rsfSales.Sale1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        ResetControl();
                    }
                }
                if (keyData == (Keys.Alt | Keys.G))
                {
                    DialogResult result = MessageBox.Show(Properties.rsfSales.Sale2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("ProcessCmdKey - error: " + ex.Message);
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Button click- Tìm kiếm khách hàng theo mã nhập vào.         
        /// </summary>
        private void btnCustormerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int dept = (!chkAllCustomer.Checked) ? UserImformation.DeptNumber : 0;
                if (txtCustomerCode.Text.Trim() != "")
                {
                    SaleEntities saleEn = Sale.SearchCustomerWithPurchase(txtCustomerCode.Text, dept, sqlDac, translate);
                    if (saleEn != null)
                    {
                        txtCustomerName.Text = saleEn.CusName;
                        txtCustomerCode.Text = saleEn.CusCode;
                        rtfAdress.Text = saleEn.CusAdress;
                        lblCusGroup.Text = saleEn.CusCode;
                        txtPurchase.Text = Conversion.GetCurrency(saleEn.CusPurchase.ToString());
                        txtSalesCode.Focus();
                        this.Text = saleEn.CusName;
                        this.DSSMenuTab.Text = saleEn.CusName;

                        //Hiển thị thông tin khách hàng ra pole
                        strCusName = saleEn.CusName;
                        strCusAdress = saleEn.CusAdress;
                        //System.Threading.Thread.Sleep(1000);
                        string strDisCus = "KH:" + Conversion.convertToUnSign(strCusName);
                        
                        PoleDisplayOneRow(strDisCus);
                        
                    }
                    else
                    {
                        txtCustomerName.Text = "";
                        rtfAdress.Text = "";
                    }
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : textbox enter- Tìm kiếm khách hàng theo mã nhập vào.         
        /// </summary>
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int dept = (!chkAllCustomer.Checked) ? UserImformation.DeptNumber : 0;
                    if (txtCustomerCode.Text.Trim() != "")
                    {
                        SaleEntities saleEn = Sale.SearchCustomerWithPurchase(txtCustomerCode.Text.Trim(), dept, sqlDac, translate);
                        if (saleEn != null)
                        {
                            txtCustomerName.Text = saleEn.CusName;
                            txtCustomerCode.Text = saleEn.CusCode;
                            rtfAdress.Text = saleEn.CusAdress;
                            lblCusGroup.Text = saleEn.CusCode;
                            txtPurchase.Text = Conversion.GetCurrency(saleEn.CusPurchase.ToString());
                            txtSalesCode.Focus();
                            this.Text = saleEn.CusName;
                            this.DSSMenuTab.Text = saleEn.CusName;


                        }
                        else
                        {
                            txtCustomerName.Text = "";
                            rtfAdress.Text = "";
                        }

                        //Hiển thị thông tin ra pole
                        strCusName = saleEn.CusName;
                        strCusAdress = saleEn.CusAdress;
                        string strDisCus = "KH:"+ Conversion.convertToUnSign(strCusName);
                        PoleDisplayOneRow(strDisCus);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Button click- Mở màn hình quản lý khách hàng.         
        /// </summary>
        //frmCustomerManagement frmCusMana;
        private void btnF3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenCusManage();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Button click- Mở popup thanh toán hóa đơn.         
        /// </summary>
        private void btnF8_Click(object sender, EventArgs e)
        {
            try
            {
                EventPayment();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Button Click - Thay đổi giá sản phẩm bán.  
        /// </summary>
        private void btnF9_Click(object sender, EventArgs e)
        {
            try
            {
                EventChangePrice();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Button Click - Chiết khấu ĐB. 
        /// Nếu chưa có sản phẩm nào trong danh sách bán sẽ thông báo cho người dùng. Đã có sản phẩm  mở popup chiết khấu.        
        /// </summary>
        private void btnF10_Click(object sender, EventArgs e)
        {
            try
            {
                EventSpecialDiscount();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Button Click - Giảm giá sản phẩm theo phiếu giảm giá.    
        /// </summary>
        private void btnF11_Click(object sender, EventArgs e)
        {
            try
            {
                EventCoupon();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Button Click - Hủy đơn hàng.     
        /// </summary>
        private void btnF12_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(Properties.rsfSales.Sale1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    ResetControl();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Button Click - Đóng giao diện bán hàng.     
        /// </summary>
        private void btnEsc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(Properties.rsfSales.Sale2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Lưu file log đã đóng form.     
        /// </summary>
        private void frmSale_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Sự kiện click event search trên menu tab.     
        /// </summary>
        private void frmSale_evSearch(object sender, EventArgs e)
        {
            try
            {
                frmCustomerSearch frmCusSearch = new frmCustomerSearch(translate);
                frmCusSearch.StartPosition = FormStartPosition.CenterScreen;
                frmCusSearch.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 28/10/2013 : Gán số tự tự dòng cho datagirdview     
        /// </summary>
        private void dgvListSales_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                var rowIdx = (e.RowIndex + 1).ToString();

                var centerFormat = new StringFormat()
                {
                    // right alignment might actually make more sense for numbers
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 28/10/2013 : Set định dạng tiền tệ cho column giá.     
        /// </summary>
        private void dgvListSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6) //Column ColB
                {
                    if (e.Value != null)
                    {
                        e.CellStyle.Format = "#,###";
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 28/10/2013 : Set Menu.     
        /// </summary>
        private void frmSale_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 28/10/2013 : Chặn các ký tự nhập vào textbox không hợp lệ     
        /// </summary>
        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// Người tạo Luannv – 28/10/2013 : Chọn nhân viên mặc định cho các dòng dữ liệu bán hàng    
        /// </summary>
        private void dgvListSales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                ComboBox ocmb = e.Control as ComboBox;
                if (ocmb != null && ocmb.Items.Count > 0)
                {
                    ocmb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
       
    }
}

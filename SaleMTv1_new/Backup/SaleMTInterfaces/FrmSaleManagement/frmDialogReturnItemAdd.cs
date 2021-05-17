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
using System.Data.SqlClient;
using SaleMTCommon;
using SaleMTBusiness.SaleManagement;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmDialogReturnItemAdd : Form
    {
        #region Declaration
        private const int TYPE_CODE_INVENT = 8;
        private const string SAL_CODE = "SAL.";
        private const string RETURN_REMARK = "RETURN ITEM";

        #region member
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private string reasons = Properties.rsfMasterCode.Reaseons.ToString();
        private bool addOrEdit;
        private ReturnItemEntities returnItemEn;
        private bool added = false;
        private string cusCode;
        private const string PRE_ITR = "ITR.";
        #endregion 

        #region properties
        public ReturnItemEntities ReturnItemEn
        {
            get { return returnItemEn; }
            set { returnItemEn = value; }
        }
        public bool AddOrEdit
        {
            get { return addOrEdit; }
            set { addOrEdit = value; }
        }
        public bool Added
        {
            get { return added; }
            set { added = value; }
        }        
        public string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; }
        }
        #endregion

        #endregion

        #region Contructor
       
        public frmDialogReturnItemAdd(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmDialogReturnItemAdd.groupBox1.Text"];
            this.label6.Text = translate["frmDialogReturnItemAdd.label6.Text"];
            this.label5.Text = translate["frmDialogReturnItemAdd.label5.Text"];
            this.label4.Text = translate["frmDialogReturnItemAdd.label4.Text"];
            this.label3.Text = translate["frmDialogReturnItemAdd.label3.Text"];
            this.label2.Text = translate["frmDialogReturnItemAdd.label2.Text"];
            this.btnSearch.Text = translate["frmDialogReturnItemAdd.btnSearch.Text"];
            this.label1.Text = translate["frmDialogReturnItemAdd.label1.Text"];
            this.btnSave.Text = translate["frmDialogReturnItemAdd.btnSave.Text"];
            this.btnClose.Text = translate["frmDialogReturnItemAdd.btnClose.Text"];
            this.clnProductCode.HeaderText = translate["frmDialogReturnItemAdd.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["frmDialogReturnItemAdd.clnProductName.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmDialogReturnItemAdd.clnQuantity.HeaderText"];
            this.clnPriceSale.HeaderText = translate["frmDialogReturnItemAdd.clnPriceSale.HeaderText"];
            this.clnCashReturn.HeaderText = translate["frmDialogReturnItemAdd.clnCashReturn.HeaderText"];
            this.clnCode.HeaderText = translate["frmDialogReturnItemAdd.clnCode.HeaderText"];
            this.clnREASON.HeaderText = translate["frmDialogReturnItemAdd.clnREASON.HeaderText"];
            this.clnMASTER_CODE.HeaderText = translate["frmDialogReturnItemAdd.clnMASTER_CODE.HeaderText"];
            this.Text = translate["frmDialogReturnItemAdd.Text"];
        }	

        #endregion

        #region Method/Function
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Clear các control.
        /// </summary>
        private void ResetControl()
        {
            try
            {
                if (dgvDetailsBill.Rows.Count > 0)
                {
                    for (int i = dgvDetailsBill.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvDetailsBill.Rows[i].IsNewRow)
                        {
                            dgvDetailsBill.Rows.RemoveAt(i);
                        }
                    }
                }
                txtBillCode.Text = "";
                rtfReasons.Text = "";
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Tìm kiếm hóa đơn theo mã hóa đơn nhập vào.
        /// </summary>
        private void SearchBill()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", txtBillCode.Text.Trim());
                para[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM",Conversion.FirstDayTime(Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer())));
                para[2] = posdb_vnmSqlDAC.newInParam("@DATETO",Conversion.LastDayTime(sqlDac.GetDateTimeServer()));
                para[3] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", CusCode);
                DataTable dtBill = new DataTable();
                dtBill = sqlDac.GetDataTable("SALES_EXPORTS_SearchBill", para);

                
                // Có 1 hóa đơn
                if (dtBill.Rows.Count == 1)
                {
                    txtBillCode.Text = dtBill.Rows[0]["EXPORT_CODE"].ToString();
                    txtTotalCashReturn.Text = Conversion.GetCurrency(dtBill.Rows[0]["TOTAL_PAYMENTS"].ToString());
                    BindDetailsBill(txtBillCode.Text);
                }
                else
                {
                    frmDialogSalesBillSearch dialogSearchBill = new frmDialogSalesBillSearch(translate);
                    dialogSearchBill.CusCode = this.CusCode;
                    if (dtBill.Rows.Count > 1)
                    {
                        dialogSearchBill.DtBills = dtBill;                        
                    }
                    // Không tìm thấy dữ liệu mở dialog tìm kiếm hóa đơn theo ngày.
                    else
                    {
                        MessageBox.Show(Properties.rsfSales.NotItem.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                        
                        dialogSearchBill.DtBills = null;                        
                    }
                    dialogSearchBill.StartPosition = FormStartPosition.CenterScreen;
                    dialogSearchBill.MaximizeBox = false;
                    dialogSearchBill.MinimizeBox = false;
                    dialogSearchBill.ShowIcon = true;
                    dialogSearchBill.ShowDialog();
                    if (dialogSearchBill.SaleCode != null && dialogSearchBill.SaleCode != "")
                    {
                        txtBillCode.Text = dialogSearchBill.SaleCode;
                        txtTotalCashReturn.Text = Conversion.GetCurrency(dialogSearchBill.SaleAmount.ToString());
                        BindDetailsBill(txtBillCode.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchBill': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load combobox phản hồi của khách hàng.
        /// </summary>
        private void LoadReasons()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", reasons) };
                DataTable dtReasons = new DataTable();
                dtReasons = sqlDac.GetDataTable("MASTER_DATA_Read_Reasons", para);
                if (dtReasons.Rows.Count > 0)
                {
                    cboReasons.DataSource = dtReasons;
                    cboReasons.DisplayMember = "MASTER_NAME";
                    cboReasons.ValueMember = "MASTER_CODE";
                    cboReasons.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadReasons': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Bind dữ liệu chi tiết các sản phẩm của hóa đơn.
        /// </summary>
        private void BindDetailsBill(string exportCode)
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", exportCode) };               
                DataTable dtDetailsBill = new DataTable();
                dtDetailsBill = sqlDac.GetDataTable("SALES_EXPORTS_ITEMS_SearchDetailsBill", para);
                if (dtDetailsBill.Rows.Count > 0)
                {
                    //for (int i = 0; i < dtDetailsBill.Rows.Count; i++)
                    //{
                    //    dtDetailsBill.Rows[i]["PRICE_SALES"] = Conversion.GetCurrency(Conversion.Replaces(dtDetailsBill.Rows[i]["PRICE_SALES"].ToString()));
                    //    dtDetailsBill.Rows[i]["TOTAL_AMOUNT"] = Conversion.GetCurrency(Conversion.Replaces(dtDetailsBill.Rows[i]["PRICE_SALES"].ToString()));
                    //}
                    dgvDetailsBill.AutoGenerateColumns = false;
                    dgvDetailsBill.DataSource = dtDetailsBill;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindDetailsBill': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu dữ liệu chi tiết sản phẩm trả lại.
        /// </summary>
        private void SaveDetailsItemReturn(string returnCode)
        { 
            try
            {
                int count = dgvDetailsBill.Rows.Count;
                // lưu thông tin chi tiết trả hàng
                string prefixDetails = PRE_ITR + UserImformation.DeptCode + "." + sqlDac.GetDateTimeServer().ToString("yy") + ".";
                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow r = dgvDetailsBill.Rows[i];
                    string detailsCode;
                    if (AddOrEdit)
                    {
                        detailsCode = sqlDac.GetAutoCode("ITEM_RETURN_DETAIL", "ITEM_RETURN_DETAIL_CODE", prefixDetails);
                    }
                    else
                    {
                        detailsCode = (r.Cells["clnCode"].Value != null) ? r.Cells["clnCode"].Value.ToString() : "";
                    }
                    ITEM_RETURN_DETAIL itemDetails = new ITEM_RETURN_DETAIL();
                    int quantity = (r.Cells["clnQuantity"].Value != null) ? Convert.ToInt32(r.Cells["clnQuantity"].Value) : 0;
                    itemDetails.ITEM_RETURN_DETAIL_CODE = detailsCode;
                    itemDetails.RETURN_CODE = returnCode;
                    itemDetails.PRODUCT_ID = (r.Cells["clnProductCode"].Value != null) ? r.Cells["clnProductCode"].Value.ToString() : "";
                    itemDetails.INPUT_DATE = dtpTime.Value;
                    itemDetails.PRICE_PRODUCT = (r.Cells["clnCashReturn"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnCashReturn"].Value.ToString())) : 0;
                    itemDetails.PRICE_PRODUCT_SALE = (r.Cells["clnPriceSale"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnPriceSale"].Value.ToString())) : 0;
                    itemDetails.MASTER_CODE = cboReasons.SelectedValue.ToString();
                    itemDetails.EVENT_ID = WriteLogEvent.SaveEventStack("ITEM_RETURN_DETAIL", "", (AddOrEdit) ? 1 : 2);
                    itemDetails.QUANTITY = quantity;
                    itemDetails.REASON = rtfReasons.Text;
                    itemDetails.ZONE_CODE = "";
                    itemDetails.P_ID = "";
                    itemDetails.Save(AddOrEdit);
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveDetailsItemReturn': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu dữ liệu tồn kho.
        /// </summary>
        private void SaveInventory(string returnCode)
        {
            try
            {
                int count = dgvDetailsBill.Rows.Count;
                // lưu tồn kho
                for (int i = 0; i < count; i++)
                {
                    int quantity = (dgvDetailsBill.Rows[i].Cells["clnQuantity"].Value != null) ? Convert.ToInt32(dgvDetailsBill.Rows[i].Cells["clnQuantity"].Value) : 0;
                    INVENTORY_TEMP invent = new INVENTORY_TEMP();
                    invent.INVENTORY_ID = Guid.NewGuid();
                    invent.CREATED_DATE = sqlDac.GetDateTimeServer();
                    invent.PRODUCT_ID = (dgvDetailsBill.Rows[i].Cells["clnProductCode"].Value != null) ? dgvDetailsBill.Rows[i].Cells["clnProductCode"].Value.ToString() : "";
                    invent.AMOUNT = quantity;
                    invent.TYPE_CODE = TYPE_CODE_INVENT;
                    invent.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                    invent.GENERATE_CODE = returnCode;
                    invent.EVENT_ID = WriteLogEvent.SaveEventStack("INVENTORY_TEMP", "", 1);
                    invent.Save(true);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveInventory': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu thông tin trả hàng.
        /// </summary>
        private void SaveItemReturn(string returnCode)
        {
            try
            {
                // lưu Item_return
                ITEM_RETURN item = new ITEM_RETURN();
                item.CUSTOMER_ID = this.CusCode;
                item.RETURN_CODE = returnCode;
                item.RETURN_DATE = dtpTime.Value;
                item.INPUT_DATE = dtpDate.Value;
                item.INVOICE_CODE = txtBillCode.Text.Trim();
                item.EMPLOYEE_ID = UserImformation.UserName;
                item.PRICE_ITEM_RETURN = (float)Convert.ToDouble(Conversion.Replaces(txtTotalCashReturn.Text));
                item.TRANSFER_SHIFT_CODE = UserImformation.ShiftCode;
                item.STORE_CODE = UserImformation.DeptCode+"@"+UserImformation.StoreCode+"@"+UserImformation.BusinessTypeCode;
                item.EVENT_ID = WriteLogEvent.SaveEventStack("ITEM_RETURN", "", 1);
                item.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveItemReturn': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu thông tin doanh thu âm.
        /// </summary>
        private string SaveSaleExport(string invoiceCode)
        {
            string saleCode = "";
            try
            {
                // lấy thông tin hoa đơn
                SALES_EXPORTS sale = new SALES_EXPORTS();
                sale = SALES_EXPORTS.ReadByEXPORT_CODE(invoiceCode)[0];
                // set lại giá trị số tiền
                string date = sqlDac.GetDateTimeServer().ToString("yy/MM/dd").Replace("/", "");
                string prifix = SAL_CODE + UserImformation.DeptCode + date;
                saleCode = sqlDac.GetAutoCode("SALES_EXPORTS", "EXPORT_CODE", prifix);
                sale.EXPORT_DATE = sqlDac.GetDateTimeServer();
                sale.INPUT_DATE = sqlDac.GetDateTimeServer();
                sale.EXPORT_CODE = saleCode;
                sale.TOTAL_AMOUNT = -sale.TOTAL_AMOUNT;
                sale.TOTAL_PAYMENTS = -sale.TOTAL_PAYMENTS;
                sale.TOTAL_PAID = -sale.TOTAL_PAID;
                sale.TOTAL_DISCOUNT = -sale.TOTAL_DISCOUNT;
                sale.TOTAL_PROMOTION = -sale.TOTAL_PROMOTION;
                sale.TOTAL_REBATE = -sale.TOTAL_REBATE;
                sale.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_EXPORTS", "", 1);
                sale.TRANSFER_SHIFT_CODE = UserImformation.ShiftCode;
                sale.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveInventory': " + ex.Message);
            }
            return saleCode;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu chi tiết thông tin hóa đơn.
        /// </summary>
        private void SaveSaleExportItem(string saleCode, string returnCode)
        {
            try
            {     
                SqlParameter[] para = {posdb_vnmSqlDAC.newInParam("@EXPORT_CODE",txtBillCode.Text.Trim())};
                DataTable dtItem = sqlDac.GetDataTable("SALES_EXPORTS_ITEMS_SearchDetailsBill",para);
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    DataRow r = dtItem.Rows[i];

                    double amount = Convert.ToDouble(r["AMOUNT"].ToString());
                    if (amount > 0)
                    {

                        SALES_EXPORTS_ITEMS saleItem = new SALES_EXPORTS_ITEMS();
                        saleItem.ID = Guid.NewGuid();
                        saleItem.EXPORT_DATE = sqlDac.GetDateTimeServer();
                        saleItem.INPUT_DATE = sqlDac.GetDateTimeServer();
                        saleItem.EXPORT_CODE = saleCode;
                        saleItem.PRODUCT_ID = r["PRODUCT_ID"].ToString();
                        saleItem.BARCODE = r["BARCODE"].ToString();
                        saleItem.QUANTITY = (r["QUANTITY"].ToString().Trim() != "") ? -Convert.ToInt32(r["QUANTITY"].ToString()) : 0;
                        saleItem.AMOUNT = (r["AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["AMOUNT"].ToString()) : 0;
                        saleItem.PRICE_DEFAULT = (r["PRICE_DEFAULT"].ToString().Trim() != "") ? Convert.ToSingle(r["PRICE_DEFAULT"].ToString()) : 0;
                        saleItem.PRICE_SALES = (r["PRICE_SALES"].ToString().Trim() != "") ? Convert.ToSingle(r["PRICE_SALES"].ToString()) : 0;
                        saleItem.DISCOUNT = (r["DISCOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["DISCOUNT"].ToString()) : 0;
                        saleItem.PROMOTION = (r["PROMOTION"].ToString().Trim() != "") ? -Convert.ToSingle(r["PROMOTION"].ToString()) : 0;
                        saleItem.REBATE = (r["REBATE"].ToString().Trim() != "") ? -Convert.ToSingle(r["REBATE"].ToString()) : 0;
                        saleItem.REMARK = r["REMARK"].ToString();
                        saleItem.OUTPUT_TYPE = r["OUTPUT_TYPE"].ToString();
                        saleItem.EMPLOYEE_ID = r["EMPLOYEE_ID"].ToString();
                        saleItem.ZONE_CODE = r["ZONE_CODE"].ToString();
                        saleItem.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_EXPORTS_ITEMS", "", 1);
                        saleItem.TOTAL_AMOUNT = (r["TOTAL_AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["TOTAL_AMOUNT"].ToString()) : 0;
                        saleItem.RETURN_CODE = returnCode;
                        saleItem.DELIVERY_DATE = sqlDac.GetDateTimeServer();
                        saleItem.REBATE_BY_CUSTOMER_CARD = (r["REBATE_BY_CUSTOMER_CARD"].ToString().Trim() != "") ? -Convert.ToSingle(r["REBATE_BY_CUSTOMER_CARD"].ToString()) : 0;
                        saleItem.MA_KHO = r["MA_KHO"].ToString();
                        saleItem.QUANTITY_EXPORTED = (r["QUANTITY_EXPORTED"].ToString().Trim() != "") ? -Convert.ToInt32(r["QUANTITY_EXPORTED"].ToString()) : 0;
                        saleItem.P_ID = "";
                        saleItem.Save(true);
                    }
                    else
                    {
                        SALE_PROMOTION_GIFTS saleGift = new SALE_PROMOTION_GIFTS();
                        saleGift.EXPORT_CODE = saleCode;
                        saleGift.PRODUCT_ID = r["PRODUCT_ID"].ToString();
                        saleGift.PRODUCT_PRICE = (r["PRICE_DEFAULT"].ToString().Trim() != "") ? Convert.ToSingle(r["PRICE_DEFAULT"].ToString()) : 0;
                        saleGift.QUANTITY = (r["QUANTITY"].ToString().Trim() != "") ? -Convert.ToInt32(r["QUANTITY"].ToString()) : 0;
                        saleGift.EVENT_ID = WriteLogEvent.SaveEventStack("SALE_PROMOTION_GIFTS", "", 1);
                        saleGift.Save(true);
                    }
                    
                }  
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveSaleExportItem': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lưu chi tiết thanh toan hóa đơn giảm doanh thu.
        /// </summary>
        private void SaveSalePayment(string saleCode)
        {
            try
            {
                //khai báo biến lịch sử thanh toán
                Guid autoId = Guid.Empty;
                Guid autoIdNew = Guid.Empty;
                // lưu lịch sử thanh toán
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", txtBillCode.Text.Trim()) };
                DataTable dtItem = sqlDac.GetDataTable("SALES_PAYMENT_ReadByExportCode", para);
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    DataRow r = dtItem.Rows[i];
                    autoId = (Guid)r["AUTO_ID"];
                    autoIdNew = Guid.NewGuid();
                    SALES_PAYMENT_HISTORY saleItem = new SALES_PAYMENT_HISTORY();
                    saleItem.AUTO_ID = autoIdNew;
                    saleItem.EXPORT_CODE = saleCode;
                    saleItem.PAYING_DATE = sqlDac.GetDateTimeServer();
                    saleItem.PAYING_TIMES = 1;
                    saleItem.NEXT_PAYING_DUE_DATE = sqlDac.GetDateTimeServer();
                    saleItem.AMOUNT = (r["AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["AMOUNT"].ToString()) : 0;
                    saleItem.BALANCE = (r["BALANCE"].ToString().Trim() != "") ? Convert.ToSingle(r["BALANCE"].ToString()) : 0;
                    saleItem.REMARK = RETURN_REMARK;
                    saleItem.CASHIER_ACCOUNT = UserImformation.UserName;
                    saleItem.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY", "", 1);
                    saleItem.TOTAL_RECEIVED = (r["TOTAL_RECEIVED"].ToString().Trim() != "") ? -Convert.ToSingle(r["TOTAL_RECEIVED"].ToString()) : 0;
                    saleItem.REFUND = (r["REFUND"].ToString().Trim() != "") ? -Convert.ToSingle(r["REFUND"].ToString()) : 0;
                    saleItem.TRANSFER_SHIFT_CODE = UserImformation.ShiftCode;
                    saleItem.Save(true);
                }

                // lưu chi tiết thanh toán
                if (autoId != Guid.Empty)
                {
                    SqlParameter[] para1 = { posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", autoId) };
                    DataTable dtItem1 = sqlDac.GetDataTable("SALES_PAYMENT_HISTORY_DETAIL_ReadBySalesPayment", para1);
                    for (int i = 0; i < dtItem1.Rows.Count; i++)
                    {
                        DataRow r = dtItem1.Rows[i];
                        SALES_PAYMENT_HISTORY_DETAIL saleItem = new SALES_PAYMENT_HISTORY_DETAIL();
                        saleItem.AUTO_ID = Guid.NewGuid();
                        saleItem.SALES_PAYMENT_HISTORY_ID = autoIdNew;
                        saleItem.CURRENCY_ID = r["CURRENCY_ID"].ToString();
                        saleItem.RATE = (r["RATE"].ToString().Trim() != "") ? -Convert.ToSingle(r["RATE"].ToString()) : 1;
                        saleItem.MONEYS = (r["MONEYS"].ToString().Trim() != "") ? -Convert.ToSingle(r["MONEYS"].ToString()) : 0;
                        saleItem.AMOUNT = (r["AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["AMOUNT"].ToString()) : 0;
                        saleItem.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY_DETAIL", "", 1);
                        saleItem.Save(true);
                    }
                }
                // lưu chi tiết thanh toán card
                if (autoId != Guid.Empty)
                {
                    SqlParameter[] para2 = { posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", autoId) };
                    DataTable dtItem2 = sqlDac.GetDataTable("SALES_PAYMENT_HISTORY_DETAIL_CARD_ReadBySalesPayment", para2);
                    for (int i = 0; i < dtItem2.Rows.Count; i++)
                    {
                        DataRow r = dtItem2.Rows[i];
                        SALES_PAYMENT_HISTORY_DETAIL_CARD saleItem = new SALES_PAYMENT_HISTORY_DETAIL_CARD();
                        saleItem.AUTO_ID = Guid.NewGuid();
                        saleItem.SALES_PAYMENT_HISTORY_ID = autoIdNew;
                        saleItem.CARD_CODE = r["CARD_CODE"].ToString();
                        saleItem.CARD_TYPE = r["CARD_TYPE"].ToString();                        
                        saleItem.AMOUNT = (r["AMOUNT"].ToString().Trim() != "") ? Convert.ToSingle(r["AMOUNT"].ToString()) : 0;
                        saleItem.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY_DETAIL_CARD", "", 1);
                        saleItem.PERCENT_AMOUNT = (r["PERCENT_AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["PERCENT_AMOUNT"].ToString()) : 0;
                        saleItem.TOTAL_DISCOUNT_AMOUNT = (r["TOTAL_DISCOUNT_AMOUNT"].ToString().Trim() != "") ? -Convert.ToSingle(r["TOTAL_DISCOUNT_AMOUNT"].ToString()) : 0;
                        
                        saleItem.Save(true);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveSalePayment': " + ex.Message);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : load form.
        /// </summary>
        private void frmDialogReturnItemAdd_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                dtpDate.Value = sqlDac.GetDateTimeServer();
                dtpTime.Value = sqlDac.GetDateTimeServer();
                LoadReasons();
                if (AddOrEdit)
                {
                    txtBillCode.Enabled = true;
                    txtBillCode.Focus();
                }
                else
                {
                    if (ReturnItemEn != null)
                    {
                        ResetControl();
                        txtBillCode.Enabled = false;
                        txtBillCode.Text = ReturnItemEn.BillCode;
                        cboReasons.SelectedValue = ReturnItemEn.DtProduct.Rows[0]["MASTER_CODE"].ToString();
                        rtfReasons.Text = ReturnItemEn.DtProduct.Rows[0]["REASON"].ToString();
                        dgvDetailsBill.AutoGenerateColumns = false;
                        dgvDetailsBill.DataSource = ReturnItemEn.DtProduct;
                        txtTotalCashReturn.Text = Conversion.GetCurrency(returnItemEn.TotalMoneyReturn.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click tìm kiếm hóa đơn.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBill();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click lưu dữ liệu.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtfReasons.Text.Trim() == "")
                {
                    MessageBox.Show(Properties.rsfSales.ItemReturn3, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    // số lượng sản phẩm trả
                    int count = dgvDetailsBill.Rows.Count;
                    string prefix = PRE_ITR + UserImformation.DeptCode + "." + sqlDac.GetDateTimeServer().ToString("yy") + ".";
                    string returnCode = (AddOrEdit) ? sqlDac.GetAutoCode("ITEM_RETURN", "RETURN_CODE", prefix) : returnItemEn.ItemReturnCode;
                    
                    if (AddOrEdit)
                    {
                        // lưu Item_return
                        SaveItemReturn(returnCode);
                        // lưu tồn kho
                        SaveInventory(returnCode);                        
                        // lưu thông tin doanh thu âm
                        string saleCode = SaveSaleExport(txtBillCode.Text.Trim());
                        // lưu chi tiết hóa đơn âm
                        SaveSaleExportItem(saleCode,returnCode);
                        // lưu lịch sử thanh toán âm
                        SaveSalePayment(saleCode);
                    }
                    // lưu thông tin chi tiết trả hàng
                    SaveDetailsItemReturn(returnCode);
                    
                    // Thông báo thao tác thành công.
                    string mesage = (AddOrEdit) ? Properties.rsfSales.CreateSuccess.ToString() : Properties.rsfSales.EditSuccess.ToString();
                    MessageBox.Show(mesage, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Added = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click đóng form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        /// Người tạo Luannv – 07/10/2013 : Lưu file log form đã đóng.
        /// </summary>
        private void frmDialogReturnItemAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed. ");
        }
        #endregion
        

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTCommon;


namespace SaleMTBusiness.SaleManagement
{
    class Payment
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string USE_GIFT = "USED";
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion

        #region Contructor
        public Payment()
        {
            //
        }
        #endregion

        #region method/function

        #region private method
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : lưu dữ liệu thanh toán chi tiết bằng VND . 
        /// </summary>
        private static void PaymentVND(Guid paymentID, float money, float amount)
        {
            SALES_PAYMENT_HISTORY_DETAIL slPayDetails = new SALES_PAYMENT_HISTORY_DETAIL();
            try
            {
                slPayDetails.AUTO_ID = Guid.NewGuid();
                slPayDetails.SALES_PAYMENT_HISTORY_ID = paymentID;
                slPayDetails.MONEYS = money;
                slPayDetails.RATE = 1;
                slPayDetails.AMOUNT = amount;
                slPayDetails.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY_DETAIL", "", 1);
                slPayDetails.CURRENCY_ID = "VND";
                slPayDetails.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'PaymentVND' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : lưu dữ liệu thanh toán chi tiết bằng thẻ Visa,master.. . 
        /// </summary>
        private static void PaymentVisa(Guid paymentID, float moneyCard, string card)
        {
            SALES_PAYMENT_HISTORY_DETAIL_CARD slPayDetailsCard = new SALES_PAYMENT_HISTORY_DETAIL_CARD();
            try
            {
                slPayDetailsCard.AUTO_ID = Guid.NewGuid();
                slPayDetailsCard.SALES_PAYMENT_HISTORY_ID = paymentID;
                slPayDetailsCard.CARD_CODE = card;
                slPayDetailsCard.CARD_TYPE = card;
                slPayDetailsCard.AMOUNT = moneyCard;
                slPayDetailsCard.PERCENT_AMOUNT = 0;
                slPayDetailsCard.TOTAL_DISCOUNT_AMOUNT = 0;
                slPayDetailsCard.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY_DETAIL_CARD", "", 1);
                slPayDetailsCard.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'PaymentVisa' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : lưu dữ liệu thanh toán chi tiết bằng ngoại tệ . 
        /// </summary>
        private static void PaymentCurrency(Guid paymentID, float money, float rate, string curren, float amount)
        {
            SALES_PAYMENT_HISTORY_DETAIL slPayDetails = new SALES_PAYMENT_HISTORY_DETAIL();
            try
            {
                slPayDetails.AUTO_ID = Guid.NewGuid();
                slPayDetails.SALES_PAYMENT_HISTORY_ID = paymentID;
                slPayDetails.MONEYS = money;
                slPayDetails.RATE = rate;
                slPayDetails.CURRENCY_ID = curren;
                slPayDetails.AMOUNT = amount;
                slPayDetails.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY_DETAIL", "", 1);
                slPayDetails.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'PaymentCurrency' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : lưu dữ liệu thanh toán hóa đơn. 
        /// </summary>
        private static Guid SalesPayment(SALES_EXPORTS SaleExport, float totalPay, float refund, float received, string remark)
        {
            SALES_PAYMENT_HISTORY slPayment = new SALES_PAYMENT_HISTORY();
            Guid guidTemp = Guid.NewGuid();
            try
            {
                slPayment.AUTO_ID = guidTemp;
                slPayment.EXPORT_CODE = SaleExport.EXPORT_CODE;
                slPayment.PAYING_DATE = sqlDac.GetDateTimeServer();
                slPayment.NEXT_PAYING_DUE_DATE = sqlDac.GetDateTimeServer();
                slPayment.AMOUNT = totalPay;
                slPayment.PAYING_TIMES = 1;
                slPayment.REFUND = refund;
                slPayment.REMARK = remark;
                slPayment.TOTAL_RECEIVED = received;
                slPayment.TRANSFER_SHIFT_CODE = UserImformation.ShiftCode;
                slPayment.BALANCE = 0;
                slPayment.CASHIER_ACCOUNT = UserImformation.UserName;
                slPayment.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_PAYMENT_HISTORY", "", 1);
                slPayment.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SalesPayment' : " + ex.Message);
            }
            return guidTemp;
        }
        #endregion

        #region pulic method
        /// <summary>
        /// Người tạo Luannv – 29/10/2013 : Update phiếu quà tăng.
        /// </summary>
        public static void UpdateVoucherGift(string[] giftCode, posdb_vnmSqlDAC sqlDac)
        {
            try
            {
                for (int i = 0; i < giftCode.Length; i++)
                {
                    if (giftCode[i] != null && giftCode[i].ToString().Trim() != "")
                    {
                        // lấy về thông tin của phiếu giảm giá
                        VOUCHER_GIFT_ITEMS gift = new VOUCHER_GIFT_ITEMS();
                        gift = VOUCHER_GIFT_ITEMS.ReadByITEM_NO(giftCode[i].ToString())[0];
                        // Set lại giá trị các cột status.
                        gift.STATUS = USE_GIFT;
                        gift.STORE_CODE_USED = UserImformation.DeptCode;
                        gift.BALANCE = 0;
                        gift.Save(false);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'UpdateVoucherGift': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Lấy thông tin in hóa đơn đỏ của khách hàng hiện tại.
        /// </summary>
        public static DataRow GetRedInvoice(string cusId, posdb_vnmSqlDAC sqlDac)
        {

            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusId);
                para[1] = posdb_vnmSqlDAC.newInParam("@DATETO", Conversion.stringToDateTime("9999/01/01"));
                para[2] = posdb_vnmSqlDAC.newInParam("@DATEFROM", Conversion.stringToDateTime("1900/01/01"));
                DataTable dtRedInvoice = new DataTable();
                dtRedInvoice = sqlDac.GetDataTable("RED_INVOICE_PRINT_ReadByCustomerID", para);
                if (dtRedInvoice.Rows.Count > 0)
                {
                    DataRow dr = dtRedInvoice.Rows[dtRedInvoice.Rows.Count - 1];
                    return dr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetRedInvoice' : " + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Lấy thông tin phiếu quà tặng.
        /// </summary>
        public static DataTable GetVoucherGift(string itemNo, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtVoucher = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@ITEM_NO", itemNo) };
                dtVoucher = sqlDac.GetDataTable("VOUCHER_GIFT_ITEMS_Read", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetVoucherGift' : " + ex.Message);
            }
            return dtVoucher;
        }
        /// <summary>
        /// Người tạo Luannv – 05/10/2013 : Lấy dữ liệu loại tiền tệ.
        /// </summary>
        public static DataTable GetCurrency(posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtCurrency = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@CURRENCY_ID", null) };
                dtCurrency = sqlDac.GetDataTable("CURRENCY_Read", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetCurrency' : " + ex.Message);
            }
            return dtCurrency;
        }
        /// <summary>
        /// Người tạo Luannv – 05/10/2013 : Lấy dữ liệu loại tiền tệ.
        /// </summary>
        public static DataTable GetCardType(string cardCode, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtCardType = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", cardCode) };
                dtCardType = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetCardType' : " + ex.Message);
            }
            return dtCardType;
        }
        /// <summary>
        /// Người tạo Luannv – 05/10/2013 : Thanh toán đơn hàng.
        /// </summary>
        public static void Pay(PaymentEntities payEn, DataGridView dgvVisaCard, SALES_EXPORTS saleExport)
        {
            try
            {
                // Lưu dữ liệu vào bảng SALES_PAYMENT_HISTORY
                Guid saleId = SalesPayment(saleExport, payEn.TotalPay, payEn.Refund, payEn.TotalReceived, payEn.Remarks);
                // Lưu dữ liệu vào bảng SALES_PAYMENT_HISTORY_DETAIL
                
                // thanh toán mở rộng ngoại tệ
                if (dgvVisaCard.Rows.Count > 0)
                {
                    float otherAmount = 0;
                    float otherMoney = 0;
                    float rate = 1;
                    string currency = "";
                    for (int i = 0; i < dgvVisaCard.Rows.Count; i++)
                    {
                        if (dgvVisaCard.Rows[i].Cells["clnIntoMoney"].Value != null && dgvVisaCard.Rows[i].Cells["clnExchangeRate"].Value != null && dgvVisaCard.Rows[i].Cells["clnCurrency"].Value != null && dgvVisaCard.Rows[i].Cells["clnAmount"].Value != null)
                        {
                            otherAmount = (float)Convert.ToDouble(Conversion.Replaces(dgvVisaCard.Rows[i].Cells["clnIntoMoney"].Value.ToString()));
                            otherMoney = (float)Convert.ToDouble(Conversion.Replaces(dgvVisaCard.Rows[i].Cells["clnAmount"].Value.ToString()));
                            rate = (float)Convert.ToDouble(Conversion.Replaces(dgvVisaCard.Rows[i].Cells["clnExchangeRate"].Value.ToString()));
                            currency = dgvVisaCard.Rows[i].Cells["clnCurrency"].Value.ToString();
                            PaymentCurrency(saleId, otherMoney, otherMoney, currency, otherAmount);
                        }
                    }
                }
                    // thanh toán mở rộng visa, master
                if (payEn.MoneyCard != 0)
                    PaymentVisa(saleId, payEn.MoneyCard, payEn.CardType);                   
                
                // thanh toán trực tiếp tiền vnđ
                if(payEn.Money != 0)
                    Payment.PaymentVND(saleId, payEn.Amount, payEn.Money);
                
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 06/10/2013 : Lấy dữ liệu in hóa đơn tạm.
        /// </summary>
        public static DataSet GetDataSetBill(SalePaymentEntities salePayEn,PaymentEntities payEn, posdb_vnmSqlDAC sqlDac)
        {
            DataSet dsResult = new DataSet();
            try
            {

                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@EXPORT_CODE",salePayEn.SaleExport.EXPORT_CODE) };
                dsResult = sqlDac.GetDataSet("Print_SalesTempBill", para);
                dsResult.Tables[0].TableName = "Total";
                dsResult.Tables[1].TableName = "Invoice";
                dsResult.Tables[2].TableName = "PROMOTION_GIFT";


                DataTable dtStore = dsResult.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                //
                DataTable dtStoreLogo = dsResult.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);

                dsResult = SetValueBill(dsResult, salePayEn,payEn);

            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
            return dsResult;
        }
        /// <summary>
        /// Người tạo Luannv – 06/10/2013 : Gán dữ liệu in hóa đơn tạm.
        /// </summary>
        private static DataSet SetValueBill(DataSet ds, SalePaymentEntities salePayEn,PaymentEntities payEn)
        {
            DataSet dsResult = new DataSet();
            try
            {
                SALES_EXPORTS saleExport = salePayEn.SaleExport;
                CUSTOMERS cus = salePayEn.Customer;
                PRODUCTS[] product = salePayEn.Product;
                SALES_EXPORTS_ITEMS[] item = salePayEn.SaleExportItem;
                SALE_PROMOTION_GIFTS[] gift = salePayEn.SalePromotionGift;
                PRODUCTS[] proGift = salePayEn.Product_Gift;
                // Thông tin hóa đơn
                ds.Tables["Total"].Rows.Clear();
                int sd = ds.Tables["Total"].Columns.Count;
                DataRow drTotal = ds.Tables["Total"].NewRow();
                drTotal["EXPORT_CODE"] = saleExport.EXPORT_CODE;
                drTotal["EXPORT_DATE"] = saleExport.EXPORT_DATE;
                drTotal["TOTAL_AMOUNT"] = salePayEn.CusPurchase + saleExport.TOTAL_PAYMENTS;
                drTotal["TOTAL_DISCOUNT"] = -(saleExport.TOTAL_DISCOUNT + saleExport.TOTAL_PROMOTION + saleExport.TOTAL_REBATE);
                drTotal["SUB_TOTAL"] = saleExport.TOTAL_AMOUNT;
                drTotal["TOTAL_PAID"] = saleExport.TOTAL_PAID;
                drTotal["BALANCE"] = saleExport.BALANCE;
                drTotal["FULL_NAME"] = cus.FIRST_NAME;
                drTotal["EMPLOYEE"] = UserImformation.UserName;
                drTotal["NEXT_PAYING_DUE_DATE"] = 0;
                drTotal["SAVING"] = "";
                drTotal["TOTAL"] = saleExport.TOTAL_PAYMENTS;
                drTotal["BARCODE_STRING"] = salePayEn.Customer.ADDRESS;
                drTotal["BARCODE_IMAGE"] = "";
                drTotal["RECEIPT_DATE"] = saleExport.INPUT_DATE;
                drTotal["TOTAL_RECEIVED"] = payEn.TotalReceived;
                drTotal["REFUND"] = payEn.Refund;
                //drTotal["TOTAL_BILL_AMOUNT"] = salePayEn.CusPurchase;
                ds.Tables["Total"].Rows.Add(drTotal);
                //Chi tiết sản phẩm của hóa đơn
                ds.Tables["Invoice"].Rows.Clear();
                for (int i = 0; i < item.Length; i++)
                {
                    DataRow drInvoice = ds.Tables["Invoice"].NewRow();
                    drInvoice["STT"] = i;
                    drInvoice["PRODUCT_NAME"] = product[i].PRODUCT_NAME;
                    drInvoice["UNIT"] = product[i].UNIT_NAME;
                    drInvoice["QUANTITY"] = item[i].QUANTITY;
                    drInvoice["PRICE"] = item[i].PRICE_DEFAULT;
                    drInvoice["REBATE"] = item[i].REBATE * -1;
                    drInvoice["TOTAL_AMOUNT"] = item[i].AMOUNT;
                    drInvoice["PRODUCT_ID"] = item[i].PRODUCT_ID;
                    drInvoice["PROMOTION"] = item[i].PROMOTION * -1;
                    drInvoice["DISCOUNT"] = item[i].DISCOUNT * -1;
                    drInvoice["P_ID"] = "";
                    ds.Tables["Invoice"].Rows.Add(drInvoice);
                }
                //Thông tin sản phẩm khuyến mại
                ds.Tables["PROMOTION_GIFT"].Rows.Clear();
                if (gift != null)
                {
                    for (int i = 0; i < gift.Length; i++)
                    {

                        if (gift[i] != null && gift[i].QUANTITY.Value > 0)
                        {
                            DataRow drGift = ds.Tables["PROMOTION_GIFT"].NewRow();
                            drGift["PRODUCT_ID"] = gift[i].PRODUCT_ID;
                            drGift["PRODUCT_NAME"] = proGift[i].PRODUCT_NAME;
                            drGift["QUANTITY"] = gift[i].QUANTITY;
                            drGift["STT"] = i + 1;
                            drGift["EXPORT_CODE"] = saleExport.EXPORT_CODE;
                            ds.Tables["PROMOTION_GIFT"].Rows.Add(drGift);
                        }
                    }
                }
                dsResult = ds;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
            return dsResult;
        }
        ///// <summary>
        ///// Người tạo Thanhdh – 27/09/2013 : In hóa đơn đỏ
        ///// </summary>
        //private void RedInvoicePrint(SalePaymentEntities salePayEn)
        //{
        //    try
        //    {
        //        List<RedInvoiceProductEntities> plist = new List<RedInvoiceProductEntities>();
        //        foreach (RedInvoiceProductEntities p in salePayEn.RedProduct)
        //        {
        //            plist.Add(p);
        //        }
        //        string text = Receipt.RedInvoiceXML(plist);

        //        RED_INVOICE_PRINT red = new RED_INVOICE_PRINT();
        //        red.AUTO_ID = System.Guid.NewGuid();
        //        red.CREATE_DATE = sqlDac.GetDateTimeServer();
        //        red.CUSTOMER_ID = salePayEn.Customer.CUSTOMER_ID;
        //        red.EVENT_ID = null;
        //        red.INVOICE_INFO = text;
        //        red.INVOICE_NO = salePayEn.ExportCode;
        //        red.LIST_INVOICE = salePayEn.ExportCode; 
        //        red.OFFICE_ADDRESS = salePayEn.ComAdress;
        //        red.OFFICE_WORKING = salePayEn.ComName;
        //        red.PAYMENT_TYPE = null;
        //        red.PRINT_DATE = sqlDac.GetDateTimeServer();
        //        red.REMARKS = salePayEn.RedRemark;
        //        red.TAX_CODE = salePayEn.ComTax;
        //        red.TOTAL_MONEY = Convert.ToDecimal(salePayEn.CashSales);
        //        red.TOTAL_QUANTITY = salePayEn.TotalQuantity;
        //        red.USER_CREATE = UserImformation.UserName;
        //        red.Save(true);

        //        RedInvoicePrintEntities print = new RedInvoicePrintEntities();
        //        print.AutoID = red.AUTO_ID.ToString();

        //        //if (listcode.Count > 0)
        //        //{
        //        //    string query = "update SALES_EXPORTS set USED_RED_INVOIDE = 1 where EXPORT_CODE = @EXPORT_CODE";
        //        //    foreach (string code in listcode)
        //        //    {
        //        //        SqlParameter[] sqlPara = new SqlParameter[1];
        //        //        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, code);
        //        //        sqlDac.InlineSql_ExecuteNonQuery(query, sqlPara);
        //        //    }
        //        //}
        //        Receipt.PrintRedInvoice(print);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error 'RedInvoicePrint' : " + ex.Message);
        //    }
        //}
        #endregion

        #endregion
    }
}

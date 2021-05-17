using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTInterfaces.FrmSaleManagement;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data;
using System.Windows.Forms;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTInterfaces.PrintBill;

namespace SaleMTBusiness.SaleManagement
{
    public class Sale
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SALES_SPECIAL_DISCOUNT saleSpecial;
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private const string SAL_CODE = "SAL.";
        private const string COU_USE = "USED";
        private const string COU_WAIT = "WAITING";
        private const string COU_CAN = "CANCEL";
        private const string CUS = "CUS.";
        private const string CURRENCY = "VND";
        private const string FOR_PRODUCT_PROMOTION = "Selected";
        private const int VAT = 10;
        private const int INVENT_TYPE_SALE = 5;// bán hàng
        private const int INVENT_TYPE_GIFT = 13;// hàng khuyến mại
        #endregion

        #region Contructor
        public Sale()
        {
            //
        }
        #endregion

        #region Method/Function

        #region private method

        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Gán các giá trị vào các member của đối tượng SALES_EXPORTS.
        /// </summary>
        private static string SetValueSale_Export(frmDialogPayment dialogPay, posdb_vnmSqlDAC sqlDac, DataGridView dgvListSales, SaleEntities saleEn)
        {
            // Sales_export
            string exportCode = "";
            try
            {
                string date = sqlDac.GetDateTimeServer().ToString("yy/MM/dd").Replace("/", "");
                string prifix = SAL_CODE + UserImformation.DeptCode + date;
                exportCode = sqlDac.GetAutoCode("SALES_EXPORTS", "EXPORT_CODE", prifix);
                string employeeCode = (dgvListSales.Rows[0].Cells["clnEmployee"].Value != null) ? dgvListSales.Rows[0].Cells["clnEmployee"].Value.ToString() : "";
                dialogPay.SalePayEn.SaleExport = new SALES_EXPORTS();
                dialogPay.SalePayEn.SaleExport.EXPORT_CODE = exportCode;
                dialogPay.SalePayEn.SaleExport.EXPORT_DATE = sqlDac.GetDateTimeServer();
                dialogPay.SalePayEn.SaleExport.INPUT_DATE = saleEn.Datetime;
                dialogPay.SalePayEn.SaleExport.TOTAL_AMOUNT = (float)Convert.ToDouble(Conversion.Replaces(saleEn.Amount));
                dialogPay.SalePayEn.SaleExport.TOTAL_DISCOUNT = (float)Convert.ToDouble(Conversion.Replaces(saleEn.SpecialDiscount));
                dialogPay.SalePayEn.SaleExport.ACCOUNT = UserImformation.UserName;
                dialogPay.SalePayEn.SaleExport.CUSTOMER_ID = saleEn.CusCode;
                dialogPay.SalePayEn.SaleExport.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                dialogPay.SalePayEn.SaleExport.CURRENCY_ID = CURRENCY;
                dialogPay.SalePayEn.SaleExport.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_EXPORTS", "", 1);
                dialogPay.SalePayEn.SaleExport.TOTAL_PROMOTION = (float)Convert.ToDouble(Conversion.Replaces(saleEn.Promotion));
                dialogPay.SalePayEn.SaleExport.TOTAL_PAYMENTS = (float)Convert.ToDouble(Conversion.Replaces(saleEn.TotalPay));
                dialogPay.SalePayEn.SaleExport.TOTAL_PAID = (float)Convert.ToDouble(Conversion.Replaces(saleEn.TotalPay));
                dialogPay.SalePayEn.SaleExport.BALANCE = 0;
                dialogPay.SalePayEn.SaleExport.TRANSFER_SHIFT_CODE = UserImformation.ShiftCode;
                dialogPay.SalePayEn.SaleExport.IS_BARTER = false;
                dialogPay.SalePayEn.SaleExport.TOTAL_REBATE = (float)Convert.ToDouble(Conversion.Replaces(saleEn.Discount));
                dialogPay.SalePayEn.SaleExport.TOTAL_NUMBER_MARK = 0;
                dialogPay.SalePayEn.SaleExport.USED_RED_INVOIDE = false;
                dialogPay.SalePayEn.SaleExport.CUSTOMER_NUMBER_MARK = 0;
                dialogPay.SalePayEn.SaleExport.CUSTOMER_CARD_DISCOUNT_PERCENT = 0;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueSale_Export' : " + ex.Message);
            }

            return exportCode;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Gán các giá trị vào các entities item details.
        /// </summary>
        private static void SetValueItemDetails(frmDialogPayment dialogPay, string saleCode, DataGridView dgvListSales, SaleEntities saleEn)
        {
            try
            {
                int count = dgvListSales.Rows.Count;
                int countGift = 0;
                if(saleEn.DtPromotionGift != null)
                    countGift = saleEn.DtPromotionGift.Rows.Count;

                dialogPay.SalePayEn.SaleExportItem = new SALES_EXPORTS_ITEMS[count];

                dialogPay.SalePayEn.Inventory = new INVENTORY_TEMP[count + countGift];
                dialogPay.SalePayEn.RedProduct = new RedInvoiceProductEntities[count];
                dialogPay.SalePayEn.Product = new PRODUCTS[count];
                // lấy thông tin employee 
                string employee = "";
                for(int i= 0;i< count;i++)
                {
                    DataGridViewRow r = dgvListSales.Rows[i];
                    employee = (r.Cells["clnEmployee"].Value != null) ? r.Cells["clnEmployee"].Value.ToString() : "";
                    if (employee != "")
                        break;
                }
                // kiểm tra nếu employee = rỗng lấy nhân viên đầu tiên trong bảng nhân viên
                if (employee == "")
                {
                    DataTable dtEm =  Sale.GetEmployeeInfo(UserImformation.DeptNumber, sqlDac);
                    if(dtEm.Rows.Count > 0)
                    {
                        employee = dtEm.Rows[0]["EMPLOYEE_ID"].ToString().Trim();
                    }
                }


                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow r = dgvListSales.Rows[i];
                    string productid = (r.Cells["clnProduct_id"].Value != null) ? r.Cells["clnProduct_id"].Value.ToString() : "";
                    string barCode = (r.Cells["clnBarCode"].Value != null) ? r.Cells["clnBarCode"].Value.ToString() : "";
                    string productName = (r.Cells["clnPRODUCT_NAME"].Value != null) ? r.Cells["clnPRODUCT_NAME"].Value.ToString() : "";
                    string unit = (r.Cells["clnUNIT_NAME"].Value != null) ? r.Cells["clnUNIT_NAME"].Value.ToString() : "";
                    int quantity = (dgvListSales.Rows[i].Cells["clnQuantity"].Value != null) ? Convert.ToInt32(dgvListSales.Rows[i].Cells["clnQuantity"].Value) : 0;
                    float price = (r.Cells["clnPrice"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnPrice"].Value.ToString())) : 0;
                    float intoMoney = (r.Cells["clnIntoMoney"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnIntoMoney"].Value.ToString())) : 0;
                    float coupon = (r.Cells["clnCoupons"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnCoupons"].Value.ToString())) : 0;
                    float promotion = (r.Cells["clnPromotion"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnPromotion"].Value.ToString())) : 0;
                    string remark = (r.Cells["clnRemarks"].Value != null) ? r.Cells["clnRemarks"].Value.ToString() : "";
                    
                    float totalPay = (r.Cells["clnPayment"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnPayment"].Value.ToString())) : 0;
                    float speDiscount = (r.Cells["clnSpecialDiscount"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnSpecialDiscount"].Value.ToString())) : 0;
                    float cusDiscount = (r.Cells["clnCustomerCard"].Value != null) ? (float)Convert.ToDouble(Conversion.Replaces(r.Cells["clnCustomerCard"].Value.ToString())) : 0;
                    // thông tin export item clnSpecialDiscount
                    
                    dialogPay.SalePayEn.SaleExportItem[i] = new SALES_EXPORTS_ITEMS();
                    dialogPay.SalePayEn.SaleExportItem[i].ID = Guid.NewGuid();
                    dialogPay.SalePayEn.SaleExportItem[i].EXPORT_DATE = sqlDac.GetDateTimeServer();
                    dialogPay.SalePayEn.SaleExportItem[i].INPUT_DATE = saleEn.Datetime;
                    dialogPay.SalePayEn.SaleExportItem[i].EXPORT_CODE = saleCode;
                    dialogPay.SalePayEn.SaleExportItem[i].PRODUCT_ID = productid;
                    dialogPay.SalePayEn.SaleExportItem[i].BARCODE = barCode;
                    dialogPay.SalePayEn.SaleExportItem[i].QUANTITY = quantity;
                    dialogPay.SalePayEn.SaleExportItem[i].AMOUNT = intoMoney;
                    dialogPay.SalePayEn.SaleExportItem[i].REBATE = coupon;
                    dialogPay.SalePayEn.SaleExportItem[i].DISCOUNT = speDiscount;
                    dialogPay.SalePayEn.SaleExportItem[i].PROMOTION = promotion;
                    dialogPay.SalePayEn.SaleExportItem[i].REMARK = remark;
                    dialogPay.SalePayEn.SaleExportItem[i].EMPLOYEE_ID = employee;                    
                    dialogPay.SalePayEn.SaleExportItem[i].EVENT_ID = WriteLogEvent.SaveEventStack("SALES_EXPORTS_ITEMS", "", 1);
                    dialogPay.SalePayEn.SaleExportItem[i].DELIVERY_DATE = saleEn.Datetime;
                    dialogPay.SalePayEn.SaleExportItem[i].QUANTITY_EXPORTED = 0;
                    dialogPay.SalePayEn.SaleExportItem[i].TOTAL_AMOUNT = totalPay;
                    dialogPay.SalePayEn.SaleExportItem[i].PRICE_DEFAULT = price;
                    dialogPay.SalePayEn.SaleExportItem[i].PRICE_SALES = price;
                    dialogPay.SalePayEn.SaleExportItem[i].REBATE_BY_CUSTOMER_CARD = cusDiscount;
                    // thông tin inventory
                    
                    dialogPay.SalePayEn.Inventory[i] = new INVENTORY_TEMP();
                    dialogPay.SalePayEn.Inventory[i].INVENTORY_ID = Guid.NewGuid();
                    dialogPay.SalePayEn.Inventory[i].CREATED_DATE = sqlDac.GetDateTimeServer();
                    dialogPay.SalePayEn.Inventory[i].PRODUCT_ID = productid;
                    dialogPay.SalePayEn.Inventory[i].AMOUNT = -quantity;
                    dialogPay.SalePayEn.Inventory[i].TYPE_CODE = INVENT_TYPE_SALE;
                    dialogPay.SalePayEn.Inventory[i].STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                    dialogPay.SalePayEn.Inventory[i].GENERATE_CODE = saleCode;
                    dialogPay.SalePayEn.Inventory[i].EVENT_ID = WriteLogEvent.SaveEventStack("INVENTORY_TEMP", "", 1);
                    //thong tin hóa đơn đỏ
                    dialogPay.SalePayEn.RedProduct[i] = new RedInvoiceProductEntities();
                    dialogPay.SalePayEn.RedProduct[i].ProductID = productid;

                    PRODUCTS pro = new PRODUCTS();
                    pro = PRODUCTS.ReadByPRODUCT_ID(dialogPay.SalePayEn.RedProduct[i].ProductID)[0];

                    dialogPay.SalePayEn.RedProduct[i].ProductName = productName;
                    dialogPay.SalePayEn.RedProduct[i].Unit = unit;
                    dialogPay.SalePayEn.RedProduct[i].Cat = pro.RED_INVOICE_CAT;
                    dialogPay.SalePayEn.RedProduct[i].Quantity = quantity;
                    dialogPay.SalePayEn.RedProduct[i].PriceSale = price;
                    dialogPay.SalePayEn.RedProduct[i].PriceTotal = intoMoney;
                    dialogPay.SalePayEn.RedProduct[i].Vat = VAT;
                    dialogPay.SalePayEn.RedProduct[i].Remark = remark;
                    // thông tin sản phẩm
                    dialogPay.SalePayEn.Product[i] = new PRODUCTS();
                    dialogPay.SalePayEn.Product[i].PRODUCT_ID = productid;
                    dialogPay.SalePayEn.Product[i].PRODUCT_NAME = productName;
                    dialogPay.SalePayEn.Product[i].UNIT_NAME = unit;
                }
                if (saleEn.DtPromotionGift != null)
                {
                    for (int i = 0; i < saleEn.DtPromotionGift.Rows.Count; i++)
                    {
                        DataRow r = saleEn.DtPromotionGift.Rows[i];
                        dialogPay.SalePayEn.Inventory[i + count] = new INVENTORY_TEMP();
                        dialogPay.SalePayEn.Inventory[i + count].INVENTORY_ID = Guid.NewGuid();
                        dialogPay.SalePayEn.Inventory[i + count].CREATED_DATE = sqlDac.GetDateTimeServer();
                        dialogPay.SalePayEn.Inventory[i + count].PRODUCT_ID = r["PRODUCT_ID_GIFTS"].ToString();
                        dialogPay.SalePayEn.Inventory[i + count].AMOUNT = -Convert.ToInt32(r["QUANTITY_GIFTS"]);
                        dialogPay.SalePayEn.Inventory[i + count].TYPE_CODE = INVENT_TYPE_GIFT;
                        dialogPay.SalePayEn.Inventory[i + count].STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                        dialogPay.SalePayEn.Inventory[i + count].GENERATE_CODE = saleCode;
                        dialogPay.SalePayEn.Inventory[i + count].EVENT_ID = WriteLogEvent.SaveEventStack("INVENTORY_TEMP", "", 1);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueItemDetails': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Set giá trị update lại trạng thái phiếu giảm giá.
        /// </summary>
        private static void SetValueCouponUsed(frmDialogPayment dialogPay, SaleEntities saleEn)
        {
            try
            {
                if (saleEn.ListCoupon.Count > 0)
                {
                    dialogPay.SalePayEn.Coupon = new COUPONS[saleEn.ListCoupon.Count];
                    for (int i = 0; i < saleEn.ListCoupon.Count; i++)
                    {
                        // lấy về thông tin của phiếu giảm giá
                        dialogPay.SalePayEn.Coupon[i] = new COUPONS();
                        dialogPay.SalePayEn.Coupon[i] = COUPONS.ReadByCOUPON_NO(saleEn.ListCoupon[i].ToString())[0];
                        // Set lại giá trị các cột status,customer, dept_used
                        dialogPay.SalePayEn.Coupon[i].COUPON_STATUS = COU_USE;
                        dialogPay.SalePayEn.Coupon[i].CUSTOMER_ID = saleEn.CusCode;
                        dialogPay.SalePayEn.Coupon[i].STORE_CODE_USED = UserImformation.DeptCode;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueCouponUsed': " + ex.Message);
            }
        }       
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Gán các giá trị vào các member của đối tượng Customer.
        /// </summary>
        private static void SetValueCustomer(frmDialogPayment dialogPay, SaleEntities saleEn)
        {
            try
            {
                dialogPay.SalePayEn.Customer = new CUSTOMERS();
                dialogPay.SalePayEn.Customer.FIRST_NAME = saleEn.CusName;
                dialogPay.SalePayEn.Customer.CUSTOMER_ID = saleEn.CusCode;
                dialogPay.SalePayEn.Customer.ADDRESS = saleEn.CusAdress;               
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueCustomer': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Gán các giá trị vào các member của đối tượng SALES_SPECIAL_DISCOUNT.
        /// </summary>
        private static void SetValueSale_Special_Discount(frmDialogPayment dialogPay, string saleCode)
        {
            try
            {                
                dialogPay.SalePayEn.SaleDiscount = new SALES_SPECIAL_DISCOUNT();
                dialogPay.SalePayEn.SaleDiscount.ID = Guid.NewGuid();
                dialogPay.SalePayEn.SaleDiscount.EXPORT_CODE = saleCode;
                dialogPay.SalePayEn.SaleDiscount.DISCOUNT_TYPE = saleSpecial.DISCOUNT_TYPE;
                dialogPay.SalePayEn.SaleDiscount.DISCOUNT_PECENT = saleSpecial.DISCOUNT_PECENT;
                dialogPay.SalePayEn.SaleDiscount.DISCOUNT_AMOUNT = (saleSpecial.TOTAL_DISCOUNT_AMOUNT == 0) ? saleSpecial.TOTAL_DISCOUNT_AMOUNT : 0;
                dialogPay.SalePayEn.SaleDiscount.FOR_PRODUCT = saleSpecial.FOR_PRODUCT;
                dialogPay.SalePayEn.SaleDiscount.DISCOUNT_RESULT = 0;
                dialogPay.SalePayEn.SaleDiscount.REMARK = saleSpecial.REMARK;
                dialogPay.SalePayEn.SaleDiscount.DISCOUNT_BY = saleSpecial.DISCOUNT_BY;
                dialogPay.SalePayEn.SaleDiscount.EVENT_ID = WriteLogEvent.SaveEventStack("SALES_SPECIAL_DISCOUNT", "", 1);
                dialogPay.SalePayEn.SaleDiscount.TOTAL_DISCOUNT_AMOUNT = saleSpecial.TOTAL_DISCOUNT_AMOUNT;
                dialogPay.SalePayEn.SaleDiscount.AUTHENTICATION_BY = saleSpecial.AUTHENTICATION_BY;
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueSale_Special_Discount': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 2/11/2013 : Gán các giá trị vào các member của đối tượng SALE_PROMOTION.
        /// </summary>
        private static void SetValuePromotion(frmDialogPayment dialogPay, SaleEntities saleEn,string saleCode)
        {
            try
            {
                if (saleEn.DtPromotionMoney != null && saleEn.DtPromotionMoney.Rows.Count > 0)
                {
                    dialogPay.SalePayEn.SalePromotion = new SALE_PROMOTION[saleEn.DtPromotionMoney.Rows.Count];
                    for (int i = 0; i < saleEn.DtPromotionMoney.Rows.Count; i++)
                    {
                        DataRow r = saleEn.DtPromotionMoney.Rows[i];
                        dialogPay.SalePayEn.SalePromotion[i] = new SALE_PROMOTION();
                        dialogPay.SalePayEn.SalePromotion[i].ID = Guid.NewGuid();
                        dialogPay.SalePayEn.SalePromotion[i].EXPORT_CODE = saleCode;
                        dialogPay.SalePayEn.SalePromotion[i].PROGRAM_NO = r["PROMOTION_DETAIL_NO"].ToString();
                        dialogPay.SalePayEn.SalePromotion[i].PROGRAM_TYPE = r["GROUP_TYPE"].ToString();
                        dialogPay.SalePayEn.SalePromotion[i].QUANTITY_MIN = Convert.ToInt32(r["QUANTITY_MIN"]);
                        dialogPay.SalePayEn.SalePromotion[i].QUANTITY_MAX = Convert.ToInt32(r["QUANTITY_MAX"]);
                        dialogPay.SalePayEn.SalePromotion[i].AMOUNT_MIN = 0;
                        dialogPay.SalePayEn.SalePromotion[i].AMOUNT_MAX = 0;
                        dialogPay.SalePayEn.SalePromotion[i].FOR_PRODUCTS = FOR_PRODUCT_PROMOTION;
                        dialogPay.SalePayEn.SalePromotion[i].NUMBER_MARK = 0;
                        dialogPay.SalePayEn.SalePromotion[i].CUSTOMER_ID = saleEn.CusCode;
                        dialogPay.SalePayEn.SalePromotion[i].CUSTOMER_NUMBER_MARK_BEFORE = 0;
                        dialogPay.SalePayEn.SalePromotion[i].CUSTOMER_GROUP_CODE = saleEn.CusGroup;
                        dialogPay.SalePayEn.SalePromotion[i].DISCOUNT_RESULT = 0;
                        dialogPay.SalePayEn.SalePromotion[i].NUMBER_MARK_RESULT = 0;
                        dialogPay.SalePayEn.SalePromotion[i].EVENT_ID = WriteLogEvent.SaveEventStack("SALE_PROMOTION", "", 1);
                        dialogPay.SalePayEn.SalePromotion[i].DISCOUNT_ON = r["DISCOUNT_ON_ENG"].ToString();
                        dialogPay.SalePayEn.SalePromotion[i].DISCOUNT_VALUE = (float)Convert.ToDouble(r["DISCOUNT_VALUE"].ToString());
                        dialogPay.SalePayEn.SalePromotion[i].QUANTITY_BUY = Convert.ToInt32(r["QUANTITY"]);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueCustomer': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 2/11/2013 : Gán các giá trị vào các member của đối tượng SALE_PROMOTION_GIFT.
        /// </summary>
        private static void SetValuePromotionGift(frmDialogPayment dialogPay, SaleEntities saleEn, string saleCode)
        {
            try
            {
                if (saleEn.DtPromotionGift != null && saleEn.DtPromotionGift.Rows.Count > 0)
                {
                    dialogPay.SalePayEn.SalePromotionGift = new SALE_PROMOTION_GIFTS[saleEn.DtPromotionGift.Rows.Count];
                    dialogPay.SalePayEn.Product_Gift = new PRODUCTS[saleEn.DtPromotionGift.Rows.Count];
                    for (int i = 0; i < saleEn.DtPromotionGift.Rows.Count; i++)
                    {
                        DataRow r = saleEn.DtPromotionGift.Rows[i];
                        int sl = Convert.ToInt32(r["QUANTITY_GIFTS"]);
                        if (r["QUANTITY_GIFTS"].ToString() != "" && sl > 0)
                        {                            
                            dialogPay.SalePayEn.SalePromotionGift[i] = new SALE_PROMOTION_GIFTS();
                            dialogPay.SalePayEn.SalePromotionGift[i].EXPORT_CODE = saleCode;
                            dialogPay.SalePayEn.SalePromotionGift[i].PRODUCT_ID = r["PRODUCT_ID_GIFTS"].ToString();
                            dialogPay.SalePayEn.SalePromotionGift[i].QUANTITY = (r["QUANTITY_GIFTS"].ToString() != "") ? Convert.ToInt32(r["QUANTITY_GIFTS"]) : 0;
                            dialogPay.SalePayEn.SalePromotionGift[i].EVENT_ID = WriteLogEvent.SaveEventStack("SALE_PROMOTION_GIFTS", "", 1);
                            dialogPay.SalePayEn.SalePromotionGift[i].PRODUCT_PRICE = (float)Convert.ToDouble(r["PriceBuy"]);
                            //thông tin sản phẩm
                            dialogPay.SalePayEn.Product_Gift[i] = new PRODUCTS();
                            dialogPay.SalePayEn.Product_Gift[i].PRODUCT_NAME = r["PRODUCT_NAME"].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SetValueCustomer': " + ex.Message);
            }
        }
        #endregion

        #region pulic static method
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Kiểm tra các sản phẩm mua có được hưởng khuyến mại không.
        /// </summary>
        public static DataSet GetPromotion(posdb_vnmSqlDAC sqlDac, DataGridView dgvListSales, DateTime date, string cusCode)
        {
            DataSet dsReturn = new DataSet();
            try
            {
                DataTable dtProduct = ((DataTable)dgvListSales.DataSource).Copy();
                dtProduct.Columns.Remove("BARCODE");
                dtProduct.Columns.Remove("PRODUCT_NAME");
                dtProduct.Columns.Remove("UNIT_NAME");
                dtProduct.Columns.Remove("CATEGORY");
                dtProduct.Columns.Remove("INVENTORY");
                dtProduct.Columns.Remove("INTOMONEY");
                dtProduct.Columns.Remove("COUPONS");
                dtProduct.Columns.Remove("CUSTOMERCARD");
                dtProduct.Columns.Remove("PROMOTION");
                dtProduct.Columns.Remove("SPECIALDISCOUNT");
                dtProduct.Columns.Remove("PAYMENT");
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@saleProducts",SqlDbType.Structured, dtProduct);
                para[1] = posdb_vnmSqlDAC.newInParam("@inputDate", date);
                para[2] = posdb_vnmSqlDAC.newInParam("@storeCode", UserImformation.DeptNumber);
                para[3] = posdb_vnmSqlDAC.newInParam("@cusCode", cusCode);
                dsReturn = sqlDac.GetDataSet("Get_PROMOTIONS_Data", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckPromotion' : " + ex.Message);
            }

            return dsReturn;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Show dialog nhập số lượng bán.
        /// </summary>
        public static int ShowInputQuantity(int input)
        {
            int quantity = 0;
            try
            {
                frmDialogQuantity dialogQuantity = new frmDialogQuantity();
                dialogQuantity.Input = input;
                dialogQuantity.StartPosition = FormStartPosition.CenterScreen;
                dialogQuantity.ShowDialog();
                quantity = dialogQuantity.Quantity;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return quantity;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Show dialog chọn sản phẩm để bán.
        /// </summary>
        public static SaleEntities showProducts(string strProductCode, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                
                    // show những sản phẩm tìm được theo mã nhập vào
                frmDialogSales dialogSales = new frmDialogSales(translate);
                    SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", strProductCode) };
                    DataTable dtSales = sqlDac.GetDataTable("PRODUCTS_Sales_Query", para);
                    if (dtSales.Rows.Count == 1)
                    {
                        saleEn.ProductCode = dtSales.Rows[0]["PRODUCT_ID"].ToString();
                        saleEn.Quantity = ShowInputQuantity(0);
                    }
                    else if (dtSales.Rows.Count > 1)
                    {
                        dialogSales.datatableSales = dtSales;
                        dialogSales.MaximizeBox = false;
                        dialogSales.MinimizeBox = false;
                        dialogSales.ShowIcon = true;
                        dialogSales.StartPosition = FormStartPosition.CenterScreen;
                        dialogSales.ShowDialog();
                        // trả về mã sản phẩm đã chọn
                        string salesCode = dialogSales.SalesCode;
                        if (salesCode != "" && salesCode != null)
                        {
                            saleEn.ProductCode = salesCode;
                            saleEn.Quantity = ShowInputQuantity(0);
                        }
                    }
                    else
                    {                        
                        saleEn = null;
                    }
               
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return saleEn;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Tìm kiếm khách hàng theo mã khách hàng.
        /// </summary>
        public static SaleEntities SearchCustomer(string cusCode, int deptCode, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                if (cusCode.Length > 0)
                {
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode);

                    DataTable dtCus = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    if (dtCus.Rows.Count == 1)
                    {
                        saleEn.CusName = dtCus.Rows[0]["LAST_NAME"].ToString() + " " + dtCus.Rows[0]["FIRST_NAME"].ToString();
                        saleEn.CusCode = dtCus.Rows[0]["CUSTOMER_ID"].ToString();
                        saleEn.CusAdress = dtCus.Rows[0]["ADDRESS"].ToString();
                        saleEn.CusGroup = dtCus.Rows[0]["CUSTOMER_GROUP_CODE"].ToString();
                        saleEn.CusPurchase = Convert.ToDouble(dtCus.Rows[0]["Purchase"].ToString());
                    }
                    else
                    {
                        dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                        dialogSearch.DtCustormer = dtCus;
                        dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                        dialogSearch.ShowDialog();
                        if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                        {
                            saleEn.CusName = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                            saleEn.CusCode = dialogSearch.Customer.CUSTOMER_ID;
                            saleEn.CusAdress = dialogSearch.Customer.ADDRESS;
                            saleEn.CusGroup = dialogSearch.Customer.CUSTOMER_GROUP_CODE;
                            saleEn.CusPurchase = Convert.ToDouble(dialogSearch.Customer.MONEY.Value);
                        }
                        else
                        {
                            saleEn = null;
                        }
                    }
                }
                else
                {
                    saleEn = null;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SearchCustomer': " + ex.Message);
            }
            return saleEn;
        }
        public static SaleEntities SearchCustomerWithPurchase(string cusCode, int deptCode, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                if (cusCode.Length > 0)
                {
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode);

                    DataTable dtCus = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    if (dtCus.Rows.Count == 1)
                    {
                        saleEn.CusName = dtCus.Rows[0]["LAST_NAME"].ToString() + " " + dtCus.Rows[0]["FIRST_NAME"].ToString();
                        saleEn.CusCode = dtCus.Rows[0]["CUSTOMER_ID"].ToString();
                        saleEn.CusAdress = dtCus.Rows[0]["ADDRESS"].ToString();
                        saleEn.CusGroup = dtCus.Rows[0]["CUSTOMER_GROUP_CODE"].ToString();
                        saleEn.CusPurchase = Convert.ToDouble(dtCus.Rows[0]["Purchase"].ToString());
                    }
                    else
                    {
                        dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                        dialogSearch.DtCustormer = dtCus;
                        dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                        dialogSearch.ShowDialog();
                        if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                        {
                            saleEn.CusName = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                            saleEn.CusCode = dialogSearch.Customer.CUSTOMER_ID;
                            saleEn.CusAdress = dialogSearch.Customer.ADDRESS;
                            saleEn.CusGroup = dialogSearch.Customer.CUSTOMER_GROUP_CODE;
                            saleEn.CusPurchase = Convert.ToDouble(dialogSearch.Customer.MONEY.Value);
                        }
                        else
                        {
                            saleEn = null;
                        }
                    }
                }
                else
                {
                    saleEn = null;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SearchCustomer': " + ex.Message);
            }
            return saleEn;
        }
        public static SaleEntities CheckCustomerDefault(string cusCode, int deptCode, posdb_vnmSqlDAC sqlDac)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                if (cusCode.Length > 0)
                {
                    SqlParameter[] paraSearch = new SqlParameter[1];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                    //paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode);

                    //DataTable dtCus = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    DataTable dtCus = sqlDac.GetDataTable("CUSTOMERS_Read", paraSearch);
                    if (dtCus.Rows.Count == 1)
                    {
                        saleEn.CusName = dtCus.Rows[0]["LAST_NAME"].ToString() + " " + dtCus.Rows[0]["FIRST_NAME"].ToString();
                        saleEn.CusCode = dtCus.Rows[0]["CUSTOMER_ID"].ToString();
                        saleEn.CusAdress = dtCus.Rows[0]["ADDRESS"].ToString();
                        saleEn.CusGroup = dtCus.Rows[0]["CUSTOMER_GROUP_CODE"].ToString();
                        //saleEn.CusPurchase = Convert.ToDouble(dtCus.Rows[0]["Purchase"].ToString());
                        saleEn.CusPurchase = Convert.ToDouble(dtCus.Rows[0]["MONEY"].ToString());
                    }
                    else
                    {                        
                       saleEn = null;                        
                    }
                }
                else
                {
                    saleEn = null;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SearchCustomer': " + ex.Message);
            }
            return saleEn;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Load khách hàng mặc định.
        /// </summary>
        public static SaleEntities GetDefaultCustomer()
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                saleEn.CusCode = DefaultCustomer.CusCode;
                saleEn.CusName = DefaultCustomer.CusName;
                saleEn.CusAdress = DefaultCustomer.CusAdress;
                saleEn.CusGroup = DefaultCustomer.CusGroup;
                saleEn.CusPurchase = Convert.ToDouble(DefaultCustomer.Purchase);
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetDefaultCustomer': " + ex.Message);
            }
            return saleEn;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Định nghĩa Datatable sản phẩm bán.
        /// </summary>
        public static void CreateDatable(DataTable dTable)
        {
            try
            {
                dTable.Columns.Add("BARCODE", typeof(string));
                dTable.Columns.Add("PRODUCT_ID", typeof(string));
                dTable.Columns.Add("PRODUCT_NAME", typeof(string));
                dTable.Columns.Add("UNIT_NAME", typeof(string));
                dTable.Columns.Add("QUANTITY", typeof(int));
                dTable.Columns.Add("CATEGORY", typeof(string));
                dTable.Columns.Add("INVENTORY", typeof(string));
                dTable.Columns.Add("PRICE", typeof(double));
                dTable.Columns.Add("INTOMONEY", typeof(string));
                dTable.Columns.Add("COUPONS", typeof(string));
                dTable.Columns.Add("CUSTOMERCARD", typeof(string));
                dTable.Columns.Add("PROMOTION", typeof(string));
                dTable.Columns.Add("SPECIALDISCOUNT", typeof(string));
                dTable.Columns.Add("PAYMENT", typeof(string));
            }
            catch (Exception ex)
            {
                log.Error(" Error 'CreateDatable': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Thêm 1 dòng vào DataTable.
        /// </summary>
        public static DataTable AddRowDatatable(string salesCode, int quantity, DataTable dtSale, posdb_vnmSqlDAC sqlDac)
        {
            try
            {
                DataTable dTableNew = new DataTable();
                string storeCode = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                SqlParameter[] paraSales = new SqlParameter[2];
                paraSales[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", salesCode);
                paraSales[1] = posdb_vnmSqlDAC.newInParam("@STORE_CODE", storeCode);
                dTableNew = sqlDac.GetDataTable("PRODUCTS_Sales_QuerybyProductID", paraSales);
                if (dTableNew.Rows.Count > 0)
                {
                    string productCode = dTableNew.Rows[0]["PRODUCT_ID"].ToString();
                    DataRow[] rCheck = dtSale.Select("PRODUCT_ID = '" + productCode + "'");
                    if (rCheck.Length > 0)
                    {
                        int oldQuantity = Convert.ToInt32(rCheck[0]["QUANTITY"]);
                        rCheck[0]["QUANTITY"] = oldQuantity + quantity;
                        double price = Convert.ToDouble(Conversion.Replaces(rCheck[0]["PRICE"].ToString()));
                        rCheck[0]["INTOMONEY"] = Conversion.GetCurrency((price * (oldQuantity + quantity)).ToString());
                        rCheck[0]["PAYMENT"] = Conversion.GetCurrency((price * (oldQuantity + quantity)).ToString());
                    }
                    else
                    {
                        double price = Convert.ToDouble(dTableNew.Rows[0]["PRICE"]);
                        DataRow dRow = dtSale.NewRow();
                        dRow["BARCODE"] = dTableNew.Rows[0]["BARCODE"];
                        dRow["PRODUCT_ID"] = productCode;
                        dRow["PRODUCT_NAME"] = dTableNew.Rows[0]["PRODUCT_NAME"];
                        dRow["UNIT_NAME"] = dTableNew.Rows[0]["UNIT_NAME"];
                        dRow["QUANTITY"] = quantity;
                        dRow["CATEGORY"] = dTableNew.Rows[0]["CATEGORY"];
                        dRow["INVENTORY"] = Conversion.GetCurrency(dTableNew.Rows[0]["INVENTORY"].ToString());
                        dRow["PRICE"] = price;
                        dRow["INTOMONEY"] = Conversion.GetCurrency((price * quantity).ToString());
                        dRow["COUPONS"] = "0";
                        dRow["CUSTOMERCARD"] = "0";
                        dRow["PROMOTION"] = "0";
                        dRow["SPECIALDISCOUNT"] = "0";
                        dRow["PAYMENT"] = Conversion.GetCurrency((price * quantity).ToString());
                        dtSale.Rows.Add(dRow);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetDatetable': " + ex.Message);
            }
            return dtSale;
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Lấy thông tin các nhân viên của cửa hàng.
        /// </summary>
        public static DataTable GetEmployeeInfo(int deptCode, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtEmployee = new DataTable();
            try
            {
                SqlParameter[] paraDept_Code = { posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode) };
                dtEmployee = sqlDac.GetDataTable("EMPLOYEE_INFO_Search", paraDept_Code);
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetEmployeeInfo': " + ex.Message);
            }
            return dtEmployee;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Mở giao diện xử lý chiết khấu.
        /// </summary>
        public static SaleEntities SpecialDiscounting(DataTable dtSale, float totalPay, Dictionary<string, string> translate)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                frmDialogSpecialDiscount dialogDiscount = new frmDialogSpecialDiscount(translate);
                dialogDiscount.DtProduct = dtSale;
                dialogDiscount.StartPosition = FormStartPosition.CenterScreen;
                dialogDiscount.ShowDialog();
                if (dialogDiscount.SaleSpecial != null)
                {
                    saleEn.StringMoney = Conversion.GetCurrency(dialogDiscount.SaleSpecial.TOTAL_DISCOUNT_AMOUNT.Value.ToString());
                    saleEn.Money = dialogDiscount.SaleSpecial.TOTAL_DISCOUNT_AMOUNT.Value;
                    saleEn.Percent = dialogDiscount.SaleSpecial.DISCOUNT_PECENT.Value;
                    saleEn.DtspecialDiscount = dialogDiscount.DtChooseProduct;

                    saleSpecial = dialogDiscount.SaleSpecial;

                    if (dialogDiscount.SaleSpecial.DISCOUNT_PECENT != 0)
                    {
                        foreach (DataRow r in dtSale.Rows)
                        {
                            string productCode = r["PRODUCT_ID"].ToString();
                            DataRow[] dRow = dialogDiscount.DtChooseProduct.Select("PRODUCT_ID = '" + productCode + "'");
                            if (dRow.Length > 0)
                            {
                                float moneys = (float)Convert.ToDouble(Conversion.Replaces(dRow[0]["INTOMONEY"].ToString()));
                                r["SPECIALDISCOUNT"] = Conversion.GetCurrency((dialogDiscount.SaleSpecial.DISCOUNT_PECENT.Value * (moneys / 100)).ToString());
                            }
                        }
                    }
                    else
                    {
                        float totaldis = 0;
                        for (int i = 0; i < dtSale.Rows.Count;i++ )
                        {
                            DataRow r = dtSale.Rows[i];
                            string productCode = r["PRODUCT_ID"].ToString();
                            DataRow[] dRow = dialogDiscount.DtChooseProduct.Select("PRODUCT_ID = '" + productCode + "'");
                            if (dRow.Length > 0)
                            {
                                float moneys = (float)Convert.ToDouble(Conversion.Replaces(dRow[0]["INTOMONEY"].ToString()));
                                float rate = moneys / totalPay;
                                float discount = 0;
                                if (i == dtSale.Rows.Count - 1)
                                {
                                    discount = dialogDiscount.SaleSpecial.TOTAL_DISCOUNT_AMOUNT.Value - totaldis;
                                }
                                else
                                {
                                    discount = (float)Math.Round(Convert.ToDecimal(dialogDiscount.SaleSpecial.TOTAL_DISCOUNT_AMOUNT.Value * rate), 0);
                                    totaldis = totaldis + discount;
                                }
                                r["SPECIALDISCOUNT"] = Conversion.GetCurrency(discount.ToString());
                            }
                        }
                    }

                }
                else
                {
                    saleEn = null;
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'SpecialDiscounting': " + ex.Message);
            }
            return saleEn;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Tính toán số tiền khách hàng phải thanh toán.
        /// </summary>
        public static SaleEntities CalPayment(DataTable dtSale, float disPercent, float couPercent,DataTable dt)
        {
            SaleEntities saleEn = new SaleEntities();
            try
            {
                if (dtSale.Rows.Count > 0)
                {                    
                    double amount = 0;
                    double discount = 0;
                    double promotion = 0;
                    double specialDisCount = 0;
                    
                    for (int i = 0; i < dtSale.Rows.Count; i++)
                    {
                        if (dtSale.Rows[i].RowState != DataRowState.Detached)
                        {
                            int quantity = Convert.ToInt32(Conversion.Replaces(dtSale.Rows[i]["QUANTITY"].ToString()));
                            double price = Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["PRICE"].ToString()));
                            string productCode = dtSale.Rows[i]["PRODUCT_ID"].ToString();

                            if (disPercent > 0)// nếu chiết khấu đặc biệt theo % > 0 tính lại tiền chiết khấu
                            {
                                if (dt != null)
                                {
                                    DataRow[] dRow = dt.Select("PRODUCT_ID = '" + productCode + "'");
                                    if (dRow.Length > 0)
                                    {
                                        dtSale.Rows[i]["SPECIALDISCOUNT"] = Conversion.GetCurrency(((quantity * price * disPercent) / 100).ToString());
                                    }                                    
                                }
                                //dtSale.Rows[i]["SPECIALDISCOUNT"] = Conversion.GetCurrency(((quantity * price * disPercent) / 100).ToString());
                            }
                            if (couPercent > 0)// nếu giảm giá theo % > 0 tính lại tiền được giảm giá
                                dtSale.Rows[i]["COUPONS"] = Conversion.GetCurrency(((quantity * price * couPercent) / 100).ToString());
                            // lấy giá trị giảm giá chiết khấu, khuyến mại mới nhất
                            double coupon = Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["COUPONS"].ToString()));
                            double card = Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["CUSTOMERCARD"].ToString()));
                            double pro = Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["PROMOTION"].ToString()));
                            double spe = Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["SPECIALDISCOUNT"].ToString()));
                            // xử lý update thành tiền trên lưới
                            dtSale.Rows[i]["INTOMONEY"] = Conversion.GetCurrency((quantity * price).ToString());
                            dtSale.Rows[i]["PAYMENT"] = Conversion.GetCurrency(((quantity * price) - coupon - card - pro - spe).ToString());
                            // tính tổng số tiền được giảm
                            amount = amount + Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["INTOMONEY"].ToString()));
                            discount = discount + Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["COUPONS"].ToString()));
                            discount = discount + Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["CUSTOMERCARD"].ToString()));
                            promotion = promotion + Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["PROMOTION"].ToString()));
                            specialDisCount = specialDisCount + Convert.ToDouble(Conversion.Replaces(dtSale.Rows[i]["SPECIALDISCOUNT"].ToString()));
                        }
                    }
                    saleEn.Amount = Conversion.GetCurrency(amount.ToString());
                    saleEn.Discount = Conversion.GetCurrency(discount.ToString());
                    saleEn.Promotion = Conversion.GetCurrency(promotion.ToString());
                    saleEn.SpecialDiscount = Conversion.GetCurrency(specialDisCount.ToString());
                    saleEn.TotalPay = Conversion.GetCurrency((amount - discount - promotion - specialDisCount).ToString());
                }
                else
                {
                    saleEn = null;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'CalPayment': " + ex.Message);
            }
            return saleEn;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Kiểm tra tồn kho có đủ hàng để bán không.
        /// </summary>
        public static string CheckInventory(DataGridView dgvListSales)
        {
            string listError = "";
            try
            {
                foreach (DataGridViewRow r in dgvListSales.Rows)
                {
                    string proCode = r.Cells["clnPRODUCT_ID"].Value.ToString();
                    int quantity = Convert.ToInt32(r.Cells["clnQUANTITY"].Value);
                    int inventory = Convert.ToInt32(Conversion.Replaces(r.Cells["clnINVENTORY"].Value.ToString()));
                    if (inventory < quantity)
                    {
                        listError = listError + " \n " + "Mã hàng: " + proCode + " | Số lượng bán: " + quantity.ToString() + " | Số lượng còn: " + inventory.ToString(); 
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'CheckInventory': " + ex.Message);
            }
            return listError;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Mở giao diện xử lý thanh toán.
        /// </summary>
        public static bool Paymenting(SaleEntities saleEn, DataGridView dgvListSales, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            bool paymented = false;
            try
            {
                frmDialogPayment dialogPay = new frmDialogPayment(translate);
                dialogPay.SalePayEn = new SalePaymentEntities();
                dialogPay.SalePayEn.CashSales = Convert.ToDouble(Conversion.Replaces((saleEn.Amount)));
                dialogPay.SalePayEn.Discount = Convert.ToDouble(Conversion.Replaces((saleEn.Discount)));
                dialogPay.SalePayEn.SpecialDiscount = Convert.ToDouble(Conversion.Replaces(saleEn.SpecialDiscount));
                dialogPay.SalePayEn.Promotion = Convert.ToDouble(Conversion.Replaces(saleEn.Promotion));                
                dialogPay.SalePayEn.StrXML = saleEn.StrXml;
                dialogPay.SalePayEn.CusPurchase = saleEn.CusPurchase;
                // lấy tổng số lượng
                int totalQuantity = 0;
                for (int i = 0; i < dgvListSales.Rows.Count; i++)
                {
                    totalQuantity = totalQuantity + Convert.ToInt32(dgvListSales.Rows[i].Cells["clnQuantity"].Value);                    
                }
                dialogPay.SalePayEn.TotalQuantity = totalQuantity;

                string exportCode = SetValueSale_Export(dialogPay, sqlDac, dgvListSales, saleEn);
                // set giá trị các entities Item details
                SetValueItemDetails(dialogPay, exportCode, dgvListSales, saleEn);                
                //Set giá trị chiết khấu đặc biệt
                if (saleEn.SpecialDiscount != "0" && saleEn.SpecialDiscount.Length > 0)
                {
                    SetValueSale_Special_Discount(dialogPay, exportCode);
                }
                //Set giá trị thông tin sử dụng phiếu giảm giá
                SetValueCouponUsed(dialogPay, saleEn);
                // Set giá trị thông tin khách hàng
                SetValueCustomer(dialogPay, saleEn);
                // set giá trị thông tin khuyến mãi tiền hoặc phần trăm đơn hàng
                SetValuePromotion(dialogPay, saleEn, exportCode);
                // set giá trị thông tin khuyến mãi tặng phẩm
                SetValuePromotionGift(dialogPay, saleEn, exportCode);
                // Mở giao diện thanh toán
                dialogPay.StartPosition = FormStartPosition.CenterScreen;
                dialogPay.ShowDialog();
                paymented = dialogPay.Paymented;
            }
            catch (Exception ex)
            {
                log.Error("Error 'Paymenting' : " + ex.Message);
            }
            return paymented;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Mở giao diện xử lý thanh toán.
        /// </summary>
        public static bool ChangePrice(DataTable dtSale, string productCode, bool changePrice, Dictionary<string, string> translate)
        {
            bool check = false;
            try
            {
                // kiểm tra quyền thay đổi giá
                frmDialogAuthentication dialogAuthen = new frmDialogAuthentication(translate);
                if (!changePrice)
                {
                    dialogAuthen.authenEn = new AuthenticationEntities();
                    dialogAuthen.authenEn.ChangePriceRight = true;
                    dialogAuthen.authenEn.DiscountRight = false;
                    dialogAuthen.StartPosition = FormStartPosition.CenterScreen;
                    dialogAuthen.Text = "Kiểm tra quyền thay đổi giá sản phẩm";
                    dialogAuthen.ShowDialog();
                }
                else
                {
                    dialogAuthen.authenEn = new AuthenticationEntities();
                    dialogAuthen.authenEn.Check = true;
                }
                // sau khi kiểm tra quyền được phép mở dialog thay đổi giá
                if (dialogAuthen.authenEn != null)
                {
                    if (dialogAuthen.authenEn.Check)
                    {
                        check = true;
                        foreach (DataRow r in dtSale.Rows)
                        {
                            if (r["PRODUCT_ID"].ToString() == productCode)
                            {
                                frmDialogChangePrice dialogPrice = new frmDialogChangePrice();
                                dialogPrice.PriceIn = Conversion.Replaces(r["Price"].ToString());
                                dialogPrice.StartPosition = FormStartPosition.CenterScreen;
                                dialogPrice.ShowDialog();
                                if (dialogPrice.PriceOut != null)
                                {
                                    r["Price"] = Convert.ToDouble(Conversion.Replaces(dialogPrice.PriceOut));
                                    float price = (float)Convert.ToDouble(Conversion.Replaces(dialogPrice.PriceOut));
                                    int quantity = Convert.ToInt32(Conversion.Replaces(r["QUANTITY"].ToString()));
                                    r["INTOMONEY"] = Conversion.GetCurrency((price * quantity).ToString());
                                    r["PAYMENT"] = Conversion.GetCurrency((price * quantity).ToString());
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'ChangePrice' : " + ex.Message);
            }
            return check;
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Kiểm tra phiếu giảm giá.
        /// </summary>
        public static DataTable CheckDiscount(string disCode, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@COUPON_NO", disCode) };
                dt = sqlDac.GetDataTable("VOUCHERS_ReadByCouponsCode", para);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return dt;
        }
        #endregion

        #endregion

    }
}

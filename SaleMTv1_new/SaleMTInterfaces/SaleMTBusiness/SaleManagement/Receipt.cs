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
    public class Receipt
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constant
        private const string SALES_INVOICE_REPORT_PATH = "\\Reports\\rptSalesInvoice.rpt";
        private const string RED_INVOICE_REPORT_PATH = "\\Reports\\rptRedInvoice.rpt";
        #endregion

        #region Contructor
        public Receipt()
        {            
        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin hóa đơn
        /// </summary>
        public static DataTable GetSaleExport(string cusID, string exportCode, int used, DateTime dateFrom, DateTime dateTo)
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDac = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[5];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", SqlDbType.VarChar, "%" + cusID + "%");
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@DATETO", SqlDbType.DateTime, dateTo);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dateFrom);
                sqlPara[3] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, "%" + exportCode + "%");
                switch (used)
                {
                    case 0:
                        sqlPara[4] = posdb_vnmSqlDAC.newInParam("@USED_RED_INVOIDE", SqlDbType.Bit, null);
                        break;
                    case 1:
                        sqlPara[4] = posdb_vnmSqlDAC.newInParam("@USED_RED_INVOIDE", SqlDbType.Bit, 1);
                        break;
                    case 2:
                        sqlPara[4] = posdb_vnmSqlDAC.newInParam("@USED_RED_INVOIDE", SqlDbType.Bit, 0);
                        break;
                }
                dt = SqlDac.GetDataTable("SALES_EXPORTS_ReadByCustomerID", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetSaleExport' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin hóa đơn đỏ
        /// </summary>
        public static DataTable GetRedInvoice(string cusID, DateTime dateFrom, DateTime dateTo)
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDac = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[3];
                if (cusID == "" || cusID == null)
                {
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", SqlDbType.VarChar, null);
                }
                else
                {
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", SqlDbType.VarChar, cusID);
                }
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@DATETO", SqlDbType.DateTime, dateTo);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dateFrom);
                dt = SqlDac.GetDataTable("RED_INVOICE_PRINT_ReadByCustomerID", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetRedInvoice' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Chi tiết hóa đơn
        /// </summary>
        public static ReceiptEntities GetSaleDetail(ReceiptEntities receipt)
        {
            try
            {
                string exportCode = receipt.ExportCode;
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                DataTable dt = SqlDAC.GetDataTable("SALES_PAYMENT_HISTORY_Read", para);
                if (dt.Rows.Count > 0)
                {
                    receipt.PaymentTime = Convert.ToInt32(dt.Rows[0]["PAYING_TIMES"]);
                    receipt.PaymentDate = (DateTime)dt.Rows[0]["PAYING_DATE"];
                    receipt.PaymentCashier = dt.Rows[0]["CASHIER_ACCOUNT"].ToString();
                    receipt.PaymentAmount = float.Parse(dt.Rows[0]["AMOUNT"].ToString());
                    receipt.PaymentTotal = float.Parse(dt.Rows[0]["TOTAL_RECEIVED"].ToString());
                    receipt.PaymentRefund = float.Parse(dt.Rows[0]["REFUND"].ToString());
                    receipt.PaymentBalance = float.Parse(dt.Rows[0]["BALANCE"].ToString());
                    receipt.PaymentID = dt.Rows[0]["AUTO_ID"].ToString();
                    receipt.ListPayments = GetReceiptPayment(dt.Rows[0]["AUTO_ID"].ToString());
                    receipt.ListCards = GetReceiptCard(dt.Rows[0]["AUTO_ID"].ToString());
                }
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                dt = SqlDAC.GetDataTable("SALES_SPECIAL_DISCOUNT_Read", para);
                if (dt.Rows.Count > 0)
                {
                    receipt.DiscountTerm = dt.Rows[0]["DISCOUNT_TERM_CODE"].ToString();
                    receipt.DiscountType = dt.Rows[0]["DISCOUNT_TYPE"].ToString().Equals("SPE") ? "Chiết khấu đặc biệt" : "Chiết khấu thời điểm";
                    receipt.DiscountBy = dt.Rows[0]["DISCOUNT_BY"].ToString();
                    receipt.DiscountAuth = dt.Rows[0]["AUTHENTICATION_BY"].ToString();
                    receipt.DiscountAmount = float.Parse(dt.Rows[0]["DISCOUNT_AMOUNT"].ToString());
                    receipt.DiscountPercent = float.Parse(dt.Rows[0]["DISCOUNT_PECENT"].ToString());
                    receipt.DiscountTotal = float.Parse(dt.Rows[0]["TOTAL_DISCOUNT_AMOUNT"].ToString());
                    receipt.DiscountID = dt.Rows[0]["ID"].ToString();
                }
                receipt.ListItems = GetReceiptItem(exportCode);
                receipt.ListGifts = GetReceiptGift(exportCode);
                receipt.ListPromos = GetReceiptPromotion(exportCode);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetSaleDetail' : " + ex.Message);
            }
            return receipt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Xử lí xóa hóa đơn
        /// </summary>
        public static void DeleteSaleExport(string exportCode)
        {
            try
            {
                ReceiptEntities receipt = new ReceiptEntities();
                receipt.ExportCode = exportCode;
                receipt = GetSaleDetail(receipt);

                posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[1];

                if (receipt.PaymentID != null && receipt.PaymentID != "")
                {
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", SqlDbType.UniqueIdentifier, new Guid(receipt.PaymentID));
                    sqlDac.Execute("SALES_PAYMENT_HISTORY_DETAIL_DeleteByPaymentID", sqlPara);
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", SqlDbType.UniqueIdentifier, new Guid(receipt.PaymentID));
                    sqlDac.Execute("SALES_PAYMENT_HISTORY_DETAIL_CARD_DeleteByPaymentID", sqlPara);
                }
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@GenerateCode", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("Inventory_Temp_DeleteByGenerateCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALE_PROMOTION_GIFTS_DeleteByExportCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALE_PROMOTION_DeleteByExportCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALES_SPECIAL_DISCOUNT_DeleteByExportCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALES_PAYMENT_HISTORY_DeleteByExportCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALES_EXPORTS_ITEMS_DeleteByExportCode", sqlPara);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, receipt.ExportCode);
                sqlDac.Execute("SALES_EXPORTS_Delete", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'DeleteSaleExport' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn đỏ
        /// </summary>
        public static void PrintRedInvoice(RedInvoicePrintEntities redinvoice,bool print)
        {
            try
            {
                posdb_vnmSqlDAC SqlDac = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@AutoId",SqlDbType.VarChar,redinvoice.AutoID);
                DataSet ds = SqlDac.GetDataSet("Red_Invoice_Print_ByAutoId", sqlPara);
                ds.Tables[0].TableName = "Company_Info";
                ds.Tables[1].TableName = "Detail";
                ds.Tables[2].TableName = "Products";

                string query = "select INVOICE_NO,(select (LAST_NAME+' '+FIRST_NAME) from CUSTOMERS where CUSTOMERS.CUSTOMER_ID = RED_INVOICE_PRINT.CUSTOMER_ID) as NAME from RED_INVOICE_PRINT where AUTO_ID ='"+redinvoice.AutoID+"'";
                DataSet ds1 = SqlDac.InlineSql_Execute(query, null);

                List<Formula> listFormula = new List<Formula>();
                Formula f1 = new Formula();
                f1.FormulaName = "InvoiceNo";
                f1.FormulaValue = ds1.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                listFormula.Add(f1);
                Formula f2 = new Formula();
                f2.FormulaName = "InvoiceText";
                f2.FormulaValue = "Số HĐ:";
                listFormula.Add(f2);
                Formula f3 = new Formula();
                f3.FormulaName = "NguoiMuaHang";
                f3.FormulaValue = "";
                listFormula.Add(f3);

                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RED_INVOICE_REPORT_PATH;
                frm.ds = ds;
                if (print == false)
                {
                    frm.listFormula = listFormula;
                }
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintRedInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Chuyển danh sách sản phẩm sang XML
        /// </summary>
        public static string RedInvoiceXML(List<RedInvoiceProductEntities> productlist)
        {
            string xml = "<ROOT>    ";
            foreach (RedInvoiceProductEntities p in productlist)
            {
                string product = "  <Product ProductId = '" + p.ProductID + "' ProductName= '" + p.ProductName + "' Unit='" + p.Unit + "' Quantity='" + p.Quantity + "' PriceSale='" + p.PriceSale + "' TotalPrice='" + p.PriceTotal + "' Remark='" + p.Remark + "' ></Product>   ";
                xml += product;
            }
            xml += "     </ROOT>";
            return xml;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn
        /// </summary>
        public static void PrintInvoice(ReceiptEntities receipt)
        {
            try
            {
                string address = "";
                double totalbillamount = 0;
                posdb_vnmSqlDAC SqlDac = new posdb_vnmSqlDAC();
                string sqlQuery = "select ISNULL(TOTAL_BILL_AMOUNT,0) TOTAL_BILL_AMOUNT,ISNULL(ADDRESS,'') ADDRESS from CUSTOMERS where CUSTOMER_ID in (select CUSTOMER_ID from SALES_EXPORTS where EXPORT_CODE = '"+receipt.ExportCode +"')";
                DataTable dtCus = SqlDac.InlineSql_Execute(sqlQuery, null).Tables[0];
                if (dtCus.Rows.Count > 0)
                {
                    address = dtCus.Rows[0]["ADDRESS"].ToString();
                    totalbillamount = double.Parse(dtCus.Rows[0]["TOTAL_BILL_AMOUNT"].ToString());
                }
                totalbillamount += receipt.PaymentAmount;

                DataSet ds = new DataSet();
                DataTable dtTotal = ds.Tables.Add("Total");
                dtTotal.Columns.Add("EXPORT_CODE", typeof(string));
                dtTotal.Columns.Add("EXPORT_DATE", typeof(DateTime));
                dtTotal.Columns.Add("TOTAL_AMOUNT", typeof(float));
                dtTotal.Columns.Add("TOTAL_DISCOUNT", typeof(float));
                dtTotal.Columns.Add("SUB_TOTAL", typeof(float));
                dtTotal.Columns.Add("TOTAL_PAID", typeof(float));
                dtTotal.Columns.Add("BALANCE", typeof(float));
                dtTotal.Columns.Add("FULL_NAME", typeof(string));
                dtTotal.Columns.Add("EMPLOYEE", typeof(string));
                dtTotal.Columns.Add("NEXT_PAYING_DUE_DATE", typeof(string));
                dtTotal.Columns.Add("SAVING", typeof(float));
                dtTotal.Columns.Add("TOTAL", typeof(float));
                dtTotal.Columns.Add("BARCODE_STRING", typeof(string));
                dtTotal.Columns.Add("BARCODE_IMAGE", typeof(string));
                dtTotal.Columns.Add("RECEIPT_DATE", typeof(DateTime));
                dtTotal.Columns.Add("TOTAL_RECEIVED", typeof(float));
                dtTotal.Columns.Add("REFUND", typeof(float));
                DataRow rowTotal = dtTotal.NewRow();
                rowTotal["EXPORT_CODE"] = receipt.ExportCode;
                rowTotal["EXPORT_DATE"] = receipt.ExportDate;
                //rowTotal["TOTAL_AMOUNT"] = receipt.TotalAmount;
                rowTotal["TOTAL_AMOUNT"] = totalbillamount;
                rowTotal["TOTAL_DISCOUNT"] = receipt.TotalDiscount * -1;
                rowTotal["SUB_TOTAL"] = receipt.TotalAmount;
                rowTotal["TOTAL_PAID"] = receipt.TotalPayment;
                rowTotal["BALANCE"] = receipt.PaymentBalance;
                rowTotal["FULL_NAME"] = receipt.CustomerLastName + " " + receipt.CustomerFirstName;
                rowTotal["EMPLOYEE"] = UserImformation.UserName;
                rowTotal["NEXT_PAYING_DUE_DATE"] = receipt.ExportDate;
                rowTotal["SAVING"] = 0;
                rowTotal["TOTAL"] = receipt.PaymentAmount;
                rowTotal["BARCODE_STRING"] = address;
                rowTotal["BARCODE_IMAGE"] = "";
                rowTotal["RECEIPT_DATE"] = receipt.ExportDate;
                rowTotal["TOTAL_RECEIVED"] = receipt.PaymentTotal;
                rowTotal["REFUND"] = receipt.PaymentRefund;
                dtTotal.Rows.Add(rowTotal);


                DataTable dtInvoice = ds.Tables.Add("Invoice");
                dtInvoice.Columns.Add("STT", typeof(string));
                dtInvoice.Columns.Add("PRODUCT_NAME", typeof(string));
                dtInvoice.Columns.Add("UNIT", typeof(string));
                dtInvoice.Columns.Add("QUANTITY", typeof(int));
                dtInvoice.Columns.Add("PRICE", typeof(float));
                dtInvoice.Columns.Add("REBATE", typeof(float));
                dtInvoice.Columns.Add("TOTAL_AMOUNT", typeof(float));
                dtInvoice.Columns.Add("PRODUCT_ID", typeof(string));
                dtInvoice.Columns.Add("PROMOTION", typeof(float));
                dtInvoice.Columns.Add("DISCOUNT", typeof(float));
                dtInvoice.Columns.Add("P_ID", typeof(string));
                foreach (ReceiptItemEntities item in receipt.ListItems)
                {
                    DataRow rowInvoice = dtInvoice.NewRow();
                    rowInvoice["STT"] = "";
                    rowInvoice["PRODUCT_NAME"] = item.ProductName;
                    rowInvoice["UNIT"] = item.UnitName;
                    rowInvoice["QUANTITY"] = item.Quantity;
                    rowInvoice["PRICE"] = item.PriceSale;
                    rowInvoice["REBATE"] = item.Rebate * -1;
                    rowInvoice["TOTAL_AMOUNT"] = item.Amount;
                    rowInvoice["PRODUCT_ID"] = item.ProductID;
                    rowInvoice["PROMOTION"] = item.Promotion * -1;
                    rowInvoice["DISCOUNT"] = item.Discount * -1;
                    rowInvoice["P_ID"] = item.PID;
                    dtInvoice.Rows.Add(rowInvoice);
                }

                DataTable dtPromo = ds.Tables.Add("PROMOTION_GIFT");
                dtPromo.Columns.Add("PRODUCT_ID", typeof(string));
                dtPromo.Columns.Add("PRODUCT_NAME", typeof(string));
                dtPromo.Columns.Add("QUANTITY", typeof(int));
                dtPromo.Columns.Add("STT", typeof(string));
                dtPromo.Columns.Add("EXPORT_CODE", typeof(string));
                foreach (ReceiptGiftEntities gift in receipt.ListGifts)
                {
                    if (gift.Quantity > 0)
                    {
                        DataRow rowPromo = dtPromo.NewRow();
                        rowPromo["PRODUCT_ID"] = gift.ProductID;
                        rowPromo["PRODUCT_NAME"] = gift.ProductName;
                        rowPromo["QUANTITY"] = gift.Quantity;
                        rowPromo["STT"] = "";
                        rowPromo["EXPORT_CODE"] = gift.ExportCode;
                        dtPromo.Rows.Add(rowPromo);
                    }
                }

                DataTable dtStoreInfo = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStoreInfo);

                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);

                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = SALES_INVOICE_REPORT_PATH;
                frm.ds = ds;
                if ("0".Equals(AppConfigFileSettings.isPrintPreview))
                {
                    frm.Print(1);
                }
                else
                {
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintInvoice' : " + ex.Message);
            }
        }
        //
        private static string ToString(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str + "đồng chẵn";
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin thanh toán thẻ
        /// </summary>
        private static List<ReceiptCardEntities> GetReceiptCard(string paymentID)
        {
            List<ReceiptCardEntities> list = new List<ReceiptCardEntities>();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", SqlDbType.VarChar, paymentID);
                DataTable dt = SqlDAC.GetDataTable("SALES_PAYMENT_HISTORY_DETAIL_CARD_Read", para);
                foreach (DataRow row in dt.Rows)
                {
                    ReceiptCardEntities card = new ReceiptCardEntities();
                    card.ID = row["AUTO_ID"].ToString();
                    card.CardName = row["MASTER_NAME"].ToString();
                    card.CardAmount = float.Parse(row["AMOUNT"].ToString());
                    list.Add(card);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptCard' : " + ex.Message);
            }
            return list;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin thanh toán
        /// </summary>
        private static List<ReceiptPaymentEntities> GetReceiptPayment(string paymentID)
        {
            List<ReceiptPaymentEntities> list = new List<ReceiptPaymentEntities>();

            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", SqlDbType.VarChar, paymentID);
                DataTable dt = SqlDAC.GetDataTable("SALES_PAYMENT_HISTORY_DETAIL_Read", para);
                foreach (DataRow row in dt.Rows)
                {
                    ReceiptPaymentEntities payment = new ReceiptPaymentEntities();
                    payment.ID = row["AUTO_ID"].ToString();
                    payment.PaymentCurrency = row["CURRENCY_ID"].ToString();
                    payment.PaymentAmount = float.Parse(row["AMOUNT"].ToString());
                    payment.PaymentRate = float.Parse(row["RATE"].ToString());
                    payment.PaymentMoney = float.Parse(row["MONEYS"].ToString());
                    list.Add(payment);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptPayment' : " + ex.Message);
            }
            return list;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách sản phẩm trong hóa đơn
        /// </summary>
        private static List<ReceiptItemEntities> GetReceiptItem(string exportCode)
        {
            List<ReceiptItemEntities> list = new List<ReceiptItemEntities>();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                DataTable dt = SqlDAC.GetDataTable("SALES_EXPORTS_ITEMS_SearchDetails", para);
                foreach (DataRow row in dt.Rows)
                {
                    ReceiptItemEntities item = new ReceiptItemEntities();
                    item.ID = row["ID"].ToString();
                    item.ProductID = row["PRODUCT_ID"].ToString();
                    item.ProductName = row["PRODUCT_NAME"].ToString();
                    item.PrintName = row["PRODUCT_NAME_PRINT"].ToString();
                    item.UnitName = row["UNIT_NAME"].ToString();
                    item.Quantity = (int)row["QUANTITY"];
                    item.PriceSale = float.Parse(row["PRICE_SALES"].ToString());
                    item.Amount = float.Parse(row["AMOUNT"].ToString());
                    item.TotalAmount = float.Parse(row["TOTAL_AMOUNT"].ToString());
                    item.TotalDiscount = float.Parse(row["DISCOUNT"].ToString()) + float.Parse(row["REBATE"].ToString()) + float.Parse(row["PROMOTION"].ToString());
                    item.Remark = row["REMARK"].ToString();
                    item.PID = row["P_ID"].ToString();
                    item.Rebate = float.Parse(row["REBATE"].ToString());
                    item.Discount = float.Parse(row["DISCOUNT"].ToString());
                    item.Promotion = float.Parse(row["PROMOTION"].ToString());
                    item.RedInvoiceCat = row["RED_INVOICE_CAT"] != null ? row["RED_INVOICE_CAT"].ToString() : "";
                    item.RealPrice = float.Parse(row["REAL_PRICE"].ToString());
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptItem' : " + ex.Message);
            }
            return list;
        }
        public static DataTable GetReceiptItemDataTable(string exportCode)
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                dt = SqlDAC.GetDataTable("SALES_EXPORTS_ITEMS_SearchDetails", para);
                dt.Columns.Add("TOTALDISCOUNT", typeof(float), "DISCOUNT+REBATE+PROMOTION");
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptItemDataTable' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách quà tặng
        /// </summary>
        private static List<ReceiptGiftEntities> GetReceiptGift(string exportCode)
        {
            List<ReceiptGiftEntities> list = new List<ReceiptGiftEntities>();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                DataTable dt = SqlDAC.GetDataTable("SALE_PROMOTION_GIFTS_Read", para);
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["QUANTITY"]) > 0)
                    {
                        ReceiptGiftEntities gift = new ReceiptGiftEntities();
                        gift.ProductID = row["PRODUCT_ID"].ToString();
                        gift.ProductName = row["PRODUCT_NAME"].ToString();
                        gift.PrintName = row["PRODUCT_NAME_PRINT"].ToString();
                        gift.Quantity = Convert.ToInt32(row["QUANTITY"]);
                        gift.ExportCode = exportCode;
                        list.Add(gift);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptGift' : " + ex.Message);
            }
            return list;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy chương trình khuyến mãi
        /// </summary>
        private static List<ReceiptPromotionEntities> GetReceiptPromotion(string exportCode)
        {
            List<ReceiptPromotionEntities> list = new List<ReceiptPromotionEntities>();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, exportCode);
                DataTable dt = SqlDAC.GetDataTable("SALE_PROMOTION_Read", para);
                foreach (DataRow row in dt.Rows)
                {
                    ReceiptPromotionEntities promo = new ReceiptPromotionEntities();
                    promo.ID = row["ID"].ToString();
                    promo.ProgramName = row["PROMOTION_DETAIL_NAME"].ToString();
                    promo.ProgramNO = row["PROGRAM_NO"].ToString();
                    list.Add(promo);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetReceiptPromotion' : " + ex.Message);
            }
            return list;
        }
        #endregion
    }
}

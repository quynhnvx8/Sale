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
using System.Globalization;


namespace SaleMTBusiness.SaleManagement
{
    class reCashPayment
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

       
            //Tạo dataset
        public static DataSet GetDataSetBill(CASH_PAYMENT cashPayment, posdb_vnmSqlDAC sqlDac)
        {
            DataSet dsResult = new DataSet();
            try
            {

                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@CASH_PAYMENT_ID", cashPayment.CASH_PAYMENT_ID) };
                //dsResult = sqlDac.GetDataSet("printCashPayment", para);
                //dsResult.Tables[0].TableName = "CashPayment";

                DataTable dt = sqlDac.GetDataTable("printCashPayment", para);

                DataTable cashPay = dsResult.Tables.Add("CashPayMent");
                cashPay.Columns.Add("CashPaymentId", typeof(string));
                cashPay.Columns.Add("CashPaymentTo", typeof(string));
                cashPay.Columns.Add("EmployeeId", typeof(string));
                cashPay.Columns.Add("CashTypeCode", typeof(string));
                cashPay.Columns.Add("Amount", typeof(string));
                cashPay.Columns.Add("DatePayment", typeof(string));
                cashPay.Columns.Add("Remark", typeof(string));
                cashPay.Columns.Add("ReadAmount", typeof(string));
                DataRow dtRow = cashPay.NewRow();
                dtRow["CashPaymentId"] = dt.Rows[0]["CashPaymentId"].ToString();
                dtRow["CashPaymentTo"] = dt.Rows[0]["CashPaymentTo"].ToString();
                dtRow["EmployeeId"] = dt.Rows[0]["EmployeeId"].ToString();
                dtRow["CashTypeCode"] = dt.Rows[0]["CashTypeCode"].ToString();
                dtRow["Amount"] = Conversion.GetCurrency(dt.Rows[0]["Amount"].ToString()) + " VNĐ";
                dtRow["DatePayment"] = dt.Rows[0]["DatePayment"].ToString();
                dtRow["Remark"] = dt.Rows[0]["Remark"].ToString();
                dtRow["ReadAmount"] = Conversion.ToString(float.Parse(dt.Rows[0]["Amount"].ToString()));
                cashPay.Rows.Add(dtRow);

                DataTable dtStore = dsResult.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                //
                DataTable dtStoreLogo = dsResult.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);
                
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
            return dsResult;
        }

        
        private static DataSet SetValueBill(DataSet ds)
        {
            DataSet dsResult = new DataSet();
            return dsResult;
        }

        }
    }
    
   


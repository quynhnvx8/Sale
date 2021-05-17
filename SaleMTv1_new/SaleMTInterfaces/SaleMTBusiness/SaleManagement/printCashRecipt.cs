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
    class printCashRecipt
    {
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        public static DataSet GetDataSetBill(CASH_RECEIPT cashReceipt, posdb_vnmSqlDAC sqlDac)
        {
            
            DataSet dsResult = new DataSet();
            try
            {

                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@CASH_RECEIPT_ID", cashReceipt.CASH_RECEIPT_ID) };
                //dsResult = sqlDac.GetDataSet("printCashReceipt", para);
                //dsResult.Tables[0].TableName = "CashReceipt";
                DataTable dt = sqlDac.GetDataTable("printCashReceipt", para);

                DataTable cashRec = dsResult.Tables.Add("CashReceipt");
                cashRec.Columns.Add("CashReceiptId", typeof(string));
                cashRec.Columns.Add("CashReceiptFrom", typeof(string));
                cashRec.Columns.Add("EmployeeId", typeof(string));
                cashRec.Columns.Add("CashTypeCode", typeof(string));
                cashRec.Columns.Add("Amount", typeof(string));
                cashRec.Columns.Add("DatePayment", typeof(string));
                cashRec.Columns.Add("Remark", typeof(string));
                cashRec.Columns.Add("ReadAmount", typeof(string));
                DataRow dtRow = cashRec.NewRow();
                dtRow["CashReceiptId"] = dt.Rows[0]["CashReceiptId"].ToString();
                dtRow["CashReceiptFrom"] = dt.Rows[0]["CashReceiptFrom"].ToString();
                dtRow["EmployeeId"] = dt.Rows[0]["EmployeeId"].ToString();
                dtRow["CashTypeCode"] = dt.Rows[0]["CashTypeCode"].ToString();
                dtRow["Amount"] = Conversion.GetCurrency(dt.Rows[0]["Amount"].ToString()) + " VNĐ";
                dtRow["DatePayment"] = dt.Rows[0]["DatePayment"].ToString();
                dtRow["Remark"] = dt.Rows[0]["Remark"].ToString();
                dtRow["ReadAmount"] = Conversion.ToString(float.Parse(dt.Rows[0]["Amount"].ToString()));
                cashRec.Rows.Add(dtRow);
                
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

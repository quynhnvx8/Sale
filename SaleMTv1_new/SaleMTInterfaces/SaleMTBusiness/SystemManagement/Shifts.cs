using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaleMTInterfaces.PrintBill;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;

namespace SaleMTBusiness.SystemManagement
{
    public class Shifts
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private const string RPT_PATH = "\\Reports\\rptTransferShiftDetail.rpt";
        private const string COM_NAME = "00";
        private const string TRA_CODE = "TRA.";
        #endregion

        #region method
        #region private method
        /// <summary>
        /// Người tạo Luannv – 03/11/2013 : Get dataset dữ liệu ca làm việc.
        /// </summary>
        private static DataSet GetDsTransferShift(string shiftCode)
        {
            DataSet ds = new DataSet();
            try
            {
                string shift = shiftCode.Substring(shiftCode.Length - 2, 2);

                string shiftDate = shiftCode.Substring(0, shiftCode.Length - 8);
                shiftDate = shiftDate.Substring(shiftDate.Length - 8);
                shiftDate = shiftDate.Replace(".", "/");
                DateTime date = DateTime.ParseExact(shiftDate, "dd/MM/yy", null);
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@TransferShiftCode", shiftCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@TransferShiftDate", date);
                para[2] = posdb_vnmSqlDAC.newInParam("@Shift", shift);
                ds = sqlDac.GetDataSet("sp_transfershiftdetail", para);
                ds.Tables[0].TableName = "Transfer";
                ds.Tables[1].TableName = "SaleExport";
                ds.Tables[2].TableName = "CashPayment";
                ds.Tables[3].TableName = "CashReceipt";
                ds.Tables[4].TableName = "WarrantyPayment";
                ds.Tables[5].TableName = "GiftPromotion";
                ds.Tables[6].TableName = "ItemReturn";
                ds.Tables[7].TableName = "Coupon";
                ds.Tables[8].TableName = "VoucherSale";
                ds.Tables[9].TableName = "SalePayment";
                ds.Tables[10].TableName = "Payment";
                // add thêm 2 bảng thông tin cửa hàng và logo
                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                //
                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetDsTransferShift': " + ex.Message);
            }
            return ds;
        }
        #endregion
        #region public method
        /// <summary>
        /// Người tạo Luannv – 03/11/2013 : in dữ liệu ca làm việc.
        /// </summary>
        public static void PrintDataShift(string shiftCode)
        {
            try
            {
                DataSet dsSaleTemp = GetDsTransferShift(shiftCode);
                dsSaleTemp.DataSetName = "transferShiftDetail";
                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;
                frm.ds = dsSaleTemp;
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintDataShift': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 03/11/2013 : Kết ca làm việc.
        /// </summary>
        public static void EndShift(string transferCode)
        {
            try
            {
                TRANSFER_SHIFT tra = new TRANSFER_SHIFT();
                tra = TRANSFER_SHIFT.ReadByTRANSFER_SHIFT_CODE(transferCode)[0];
                tra.ISFINISH = true;
                tra.Save(false);
            }
            catch (Exception ex)
            {
                log.Error("Error 'EndShift': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 03/11/2013 : insert dữ liệu ca làm việc mới.
        /// </summary>
        public static string CreateNewShift()
        {
            string tranCode = "";
            try
            {
                DateTime date = Convert.ToDateTime(sqlDac.GetDateTimeServer().Date);
                TRANSFER_SHIFT tra = new TRANSFER_SHIFT();
                string dateCurrent = sqlDac.GetDateTimeServer().ToString("dd.MM.yy");
                string prefixTran = TRA_CODE + UserImformation.DeptCode + "." + dateCurrent + ".";
                tranCode = sqlDac.GetAutoCode("TRANSFER_SHIFT", "TRANSFER_SHIFT_CODE", prefixTran);
                tra.TRANSFER_SHIFT_CODE = tranCode;
                tra.DATE_SHIFT = date;
                tra.STORECODE = UserImformation.DeptCode;
                tra.TRANSFER_BY = UserImformation.UserName.ToUpper();
                tra.DATE_TIME_TRANSFER = sqlDac.GetDateTimeServer();
                tra.ISFINISH = false;
                tra.ACCOUNT = UserImformation.UserName.ToUpper();
                tra.COMPUTER_NAME = COM_NAME;
                tra.EVENT_ID = WriteLogEvent.SaveEventStack("TRANSFER_SHIFT", "", 1);
                tra.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'CreateNewShift': " + ex.Message);
            }
            return tranCode;
        }
        #endregion
        #endregion
    }
}

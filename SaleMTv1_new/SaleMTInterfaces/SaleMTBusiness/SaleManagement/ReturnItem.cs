using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTInterfaces.FrmSaleManagement;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using SaleMTCommon;
using SaleMTInterfaces.PrintBill;

namespace SaleMTBusiness.SaleManagement
{
    public class ReturnItem
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string RPT_PATH = "\\Reports\\rptItemReturn.rpt";
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 06/10/2013 : Lấy dữ liệu in hóa đơn tạm.
        /// </summary>
        private static DataSet GetDataSetBill(posdb_vnmSqlDAC sqlDac,string returnCode)
        {
            DataSet dsResult = new DataSet();
            try
            {

                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@RETURN_CODE", returnCode) };
                dsResult = sqlDac.GetDataSet("Print_ItemReturn", para);
                dsResult.Tables[1].TableName = "ItemReturn";
                dsResult.Tables[0].TableName = "ItemReturnCode";
                // thông tin cửa hàng
                DataTable dtStore = dsResult.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                // Logo cửa hàng
                DataTable dtStoreLogo = dsResult.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);

            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
            return dsResult;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Tìm kiếm khách hàng theo mã khách hàng.
        /// </summary>
        public static CUSTOMERS SearchCustomer(string cusCode, int deptCode, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            CUSTOMERS cusEn = new CUSTOMERS();
            try
            {                
                SqlParameter[] paraSearch = new SqlParameter[2];
                paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode);

                dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                dialogSearch.DtCustormer = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                dialogSearch.ShowDialog();
                if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                {
                    cusEn = dialogSearch.Customer;
                }
                else
                {
                    cusEn = null;
                }                
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SearchCustomer': " + ex.Message);
            }
            return cusEn;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lấy địa chỉ khởi tạo khách hàng .
        /// </summary>
        public static string GetPlaceCreate(int deptCode, posdb_vnmSqlDAC sqlDac)
        {
            string place = "";
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode) };
                DataTable dtTemp = new DataTable();
                dtTemp = sqlDac.GetDataTable("GetPlaceCreateCustomer", para);
                if (dtTemp.Rows.Count > 0)
                {
                    place = dtTemp.Rows[0]["Place"].ToString();
                }                
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetPlaceCreate': " + ex.Message);
            }
            return place;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Trả về bảng dữ liệu trả hàng.
        /// </summary>
        public static DataTable FindItemReturn(string cusCode,posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = {posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID",cusCode) };
                dtResult = sqlDac.GetDataTable("ITEM_RETURN_FindByCustomer", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'FindItemReturn': " + ex.Message);
            }
            return dtResult;

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lấy dữ liệu tồn kho.
        /// </summary>
        public static DataTable GetInventory(string proId,string genCode,int typeCode, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@GENERATE_CODE", genCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", proId);
                para[2] = posdb_vnmSqlDAC.newInParam("@TYPE_CODE", typeCode);
                dtResult = sqlDac.GetDataTable("INVENTORY_TEMP_SearchByGENNERATECODE", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetInventory': " + ex.Message);
            }
            return dtResult;

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Trả về bảng chi tiết đợt trả hàng.
        /// </summary>
        public static DataTable FindDetailsItemReturn(string returnCode, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@RETURN_CODE", returnCode) };
                dtResult = sqlDac.GetDataTable("ITEM_RETURN_DETAIL_FindByRETURN_CODE", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'FindDetailsItemReturn': " + ex.Message);
            }
            return dtResult;

        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : In hóa đơn tạm . 
        /// </summary>
        public static void PrintItemReturn(posdb_vnmSqlDAC sqlDac, string returnCode)
        {
            try
            {
                DataSet dsItemReturn = GetDataSetBill(sqlDac, returnCode);
                dsItemReturn.DataSetName = "dsItemReturn";
                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = RPT_PATH;
                frm.ds = dsItemReturn;
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintItemReturn': " + ex.Message);
            }
        }

        #endregion
    }
}

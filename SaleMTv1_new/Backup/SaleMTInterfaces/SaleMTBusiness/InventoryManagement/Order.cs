using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleMTInterfaces;
using SaleMTCommon;


namespace SaleMTBusiness.InventoryManagement
{
    public class Order
    {
        #region Declaration
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Method

        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Tìm kiếm đơn đặt hàng.
        /// </summary>
        public static DataTable SearchOrder(OrderEntities orderEn)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string procedure = "ORDER_PRODUCTS_Search";
                SqlParameter[] para = new SqlParameter[3];
                // Paramaters
                para[0] = posdb_vnmSqlDAC.newInParam("@ORDER_CODE", SqlDbType.VarChar, (orderEn.OrderCode != "") ? orderEn.OrderCode : null);
                para[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, orderEn.DateFrom);
                para[2] = posdb_vnmSqlDAC.newInParam("@DATETo", SqlDbType.DateTime, orderEn.DateTo);
                
                dataTable = sqlDac.GetDataTable(procedure, para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchOrder': " + ex.Message);
            }
            return dataTable;
        }
        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Tìm kiếm chi tiết đơn đặt hàng.
        /// </summary>
        public static DataTable SearchOrderDetails(OrderEntities orderEn)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string procedure = "ORDER_PRODUCT_DETAIL_Read";
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@ORDER_CODE", SqlDbType.VarChar, orderEn.OrderCode) };
                dataTable = sqlDac.GetDataTable(procedure, para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchOrderDetails': " + ex.Message);
            }
            return dataTable;
        }
        /// <summary>
        /// Người tạo Luannv – 19/10/2013: Dataset in hóa đơn đặt hàng.
        /// </summary>
        public static DataSet GetDatasetBill(OrderEntities orderEn)
        {
            DataSet ds = new DataSet();
            try
            {
                string procedure = "ORDER_PRODUCT_DETAIL_Print";
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@ORDER_CODE", SqlDbType.VarChar, orderEn.OrderCode) };
                ds = sqlDac.GetDataSet(procedure, para);
                ds.Tables[0].TableName = "Products";

                DataTable dtCompany = ds.Tables.Add("Company");
                Print.AddUserCompanyInfo(dtCompany);

                DataTable dtDetail = ds.Tables.Add("Detail");
                dtDetail.Columns.Add("OrderCode", typeof(string));
                dtDetail.Columns.Add("OrderDate", typeof(string));
                dtDetail.Columns.Add("Store", typeof(string));
                dtDetail.Columns.Add("Remarks", typeof(string));
                // Thông tin hóa đơn
                SqlParameter[] para1 = { posdb_vnmSqlDAC.newInParam("@ORDER_CODE", SqlDbType.VarChar, orderEn.OrderCode) };
                DataTable dtInfo = new DataTable();
                dtInfo = sqlDac.GetDataTable("ORDER_PRODUCTS_Read", para1);
                if (dtInfo.Rows.Count > 0)
                {
                    DataRow dRow = dtDetail.NewRow();
                    dRow["OrderCode"] = dtInfo.Rows[0]["ORDER_CODE"].ToString();
                    dRow["OrderDate"] = dtInfo.Rows[0]["ORDER_DATE"].ToString();
                    dRow["Store"] = dtInfo.Rows[0]["Store"].ToString();
                    dRow["Remarks"] = dtInfo.Rows[0]["REMARKS"].ToString(); 
                    dtDetail.Rows.Add(dRow);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetDatasetBill': " + ex.Message);
            }
            return ds;
        }

        #endregion

    }
}

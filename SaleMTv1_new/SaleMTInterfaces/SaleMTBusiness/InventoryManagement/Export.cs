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
using SaleMTInterfaces.Properties;

namespace SaleMTBusiness.InventoryManagement
{
    public class Export
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constant
        private const string EXPORT_PRODUCT_REPORT_PATH = "\\Reports\\rptExportProductStore.rpt";
        #endregion

        #region Contructor
        public Export()
        {            
        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Lấy danh sách xuất hàng
        /// </summary>
        public static DataTable GetExportList(string exportType, DateTime dateFrom, DateTime dateTo, string storeid)
        {
            DataTable dtTable = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                string proc = "EXPORT_PRODUCT_STORE_ReadDetail";
                SqlParameter[] sqlPara;
                sqlPara = new SqlParameter[4];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dateFrom);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATETO", SqlDbType.DateTime, dateTo);
                sqlPara[3] = posdb_vnmSqlDAC.newInParam("EXPORT_TYPE_CODE", SqlDbType.VarChar, exportType);
                dtTable = SqlDAC.GetDataTable(proc, sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetExportList' : " + ex.Message);
            }
            return dtTable;
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Lấy thông tin xuất hàng
        /// </summary>
        public static DataTable GetExportInfo(string storeid)
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                string proc = "EXPORT_PRODUCT_STORE_Read";
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid);
                dt = SqlDAC.GetDataTable(proc, sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetExportInfo' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Lấy thông tin chi tiết hóa đơn
        /// </summary>
        public static DataTable GetExportDetail(string storeid)
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                string proc = "Export_Product_Store_Detail_GetByExportStoreId";
                SqlParameter[] sqlParaDetail = new SqlParameter[1];
                sqlParaDetail[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid);
                dt = SqlDAC.GetDataTable(proc, sqlParaDetail);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetExportDetail' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Lấy tồn kho
        /// </summary>
        public static DataTable GetInventoryTemp()
        {
            DataTable dt = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                string query = "select INVENTORY_TEMP.PRODUCT_ID as ProductId,SUM(AMOUNT) as Quantity, PRODUCT_NAME as ProductName, PRODUCTS.UNIT_NAME as Unit, (PRODUCTS.PRICE * 1.1) as Price, INVENTORY_TEMP.P_ID from INVENTORY_TEMP join PRODUCTS on INVENTORY_TEMP.PRODUCT_ID = PRODUCTS.PRODUCT_ID group by INVENTORY_TEMP.PRODUCT_ID , PRODUCT_NAME, P_ID,PRODUCTS.UNIT_NAME,PRODUCTS.PRICE having SUM(AMOUNT) <> 0 order by INVENTORY_TEMP.PRODUCT_ID";
                SqlParameter[] sqlPara = new SqlParameter[1] {posdb_vnmSqlDAC.newInParam("1",SqlDbType.VarChar,"1")};
                DataSet ds = SqlDAC.InlineSql_Execute(query, sqlPara);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetInventoryTemp' : " + ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : In đơn xuất hàng
        /// </summary>
        public static void PrintInvoice(string storeid)
        {
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara;               
                DataSet ds = new DataSet();

                DataTable dtDetail = ds.Tables.Add("Detail");
                dtDetail.Columns.Add("ExportStoreId", typeof(string));
                dtDetail.Columns.Add("DateExport", typeof(DateTime));
                dtDetail.Columns.Add("ExportTo", typeof(string));
                dtDetail.Columns.Add("CreateBy", typeof(string));
                dtDetail.Columns.Add("Remarks", typeof(string));
                dtDetail.Columns.Add("InvoiceNo", typeof(string));
                dtDetail.Columns.Add("SoNoiBo", typeof(string));
                dtDetail.Columns.Add("SoPO", typeof(string));
                dtDetail.Columns.Add("OrderDate", typeof(DateTime));
                dtDetail.Columns.Add("SoTienDC", typeof(float));
                dtDetail.Columns.Add("GhiChuDC", typeof(string));
                sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_CODE", SqlDbType.VarChar, storeid) };
                DataTable dtd = SqlDAC.GetDataTable("Export_Product_Store_GetByExportStoreID", sqlPara);
                DataRow rowDetail = dtDetail.NewRow();
                rowDetail["ExportStoreId"] = dtd.Rows[0]["ExportStoreId"].ToString();
                rowDetail["DateExport"] = DateTime.Parse(dtd.Rows[0]["DateExport"].ToString());
                rowDetail["ExportTo"] = dtd.Rows[0]["ExportTo"].ToString();
                rowDetail["CreateBy"] = dtd.Rows[0]["CreateBy"].ToString();
                rowDetail["Remarks"] = dtd.Rows[0]["Remarks"].ToString();
                rowDetail["InvoiceNo"] = dtd.Rows[0]["InvoiceNo"].ToString();
                rowDetail["SoNoiBo"] = dtd.Rows[0]["SoNoiBo"].ToString();
                rowDetail["OrderDate"] = DateTime.Parse(dtd.Rows[0]["OrderDate"].ToString());
                rowDetail["SoPO"] = dtd.Rows[0]["SoPO"].ToString();
                rowDetail["GhiChuDC"] = dtd.Rows[0]["GhiChuDC"].ToString();
                rowDetail["SoTienDC"] = float.Parse(dtd.Rows[0]["SoTienDC"].ToString());
                rowDetail["GhiChuDC"] = dtd.Rows[0]["GhiChuDC"].ToString();
                dtDetail.Rows.Add(rowDetail);
                
                DataTable dtProduct = ds.Tables.Add("Products");
                dtProduct.Columns.Add("ProductId", typeof(string));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("ShortName", typeof(string));
                dtProduct.Columns.Add("Unit", typeof(string));
                dtProduct.Columns.Add("Quantity", typeof(int));
                dtProduct.Columns.Add("Price", typeof(float));
                dtProduct.Columns.Add("Total", typeof(float));
                dtProduct.Columns.Add("TypeName", typeof(string));
                sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid) };
                DataTable dtp1 = SqlDAC.GetDataTable("Export_Product_Store_Detail_GetByExportStoreId", sqlPara);
                foreach (DataRow row in dtp1.Rows)
                {
                    DataRow rowProduct = dtProduct.NewRow();
                    rowProduct["ProductId"] = row["ProductId"].ToString();
                    rowProduct["ProductName"] = row["ProductName"].ToString();
                    rowProduct["ShortName"] = row["ShortName"].ToString();
                    rowProduct["Unit"] = row["Unit"].ToString();
                    rowProduct["Quantity"] = int.Parse(row["Quantity"].ToString());
                    rowProduct["Price"] = float.Parse(row["Price"].ToString());
                    rowProduct["Total"] = float.Parse(row["Total"].ToString());
                    rowProduct["TypeName"] = row["TypeName"].ToString();
                    dtProduct.Rows.Add(rowProduct);
                }

                DataTable dtStoreInfo = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStoreInfo);
                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);

                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = EXPORT_PRODUCT_REPORT_PATH;
                frm.ds = ds;
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Xóa đơn xuất hàng
        /// </summary>
        public static void DeleteInvoice(string storeid)
        {
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                DataRow row = GetExportInfo(storeid).Rows[0];
                string epsevent = row["EVENT_ID"].ToString();
                string epsdevent = row["EPSDeventid"].ToString();
                string itevent = row["ITeventid"].ToString();

                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@GenerateCode", SqlDbType.VarChar, storeid);
                SqlDAC.Execute("Inventory_Temp_DeleteByGenerateCode", sqlPara);
                CreateEvent(itevent, "INVENTORY_TEMP", "", 3);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid);
                SqlDAC.Execute("EXPORT_PRODUCT_STORE_DETAIL_DeleteByExportID", sqlPara);
                CreateEvent(epsdevent, "EXPORT_PRODUCT_STORE_DETAIL", "", 3);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, storeid);
                SqlDAC.Execute("EXPORT_PRODUCT_STORE_Delete", sqlPara);
                CreateEvent(epsevent, "EXPORT_PRODUCT_STORE", "", 3);

                MessageBox.Show(rsfExportManagement.Export7.ToString(), "Thông báo", MessageBoxButtons.OK,
                                                               MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex)
            {
                log.Error("Error 'DeleteInvoice' : " + ex.Message);                
            }
        }
        public static void CreateEvent(string id, string table, string col, int type)
        {
            try
            {
                string proc = "BK_EVENT_STACK_TABLE_Create";
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[10];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EVENT_ID", SqlDbType.VarChar, id);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@EVENT_TYPE", SqlDbType.Int, type);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@TABLE_OBJECT", SqlDbType.VarChar, table);
                sqlPara[3] = posdb_vnmSqlDAC.newInParam("@TARGET_COLUMN", SqlDbType.Text, col);
                sqlPara[4] = posdb_vnmSqlDAC.newInParam("@DATE_CREATE", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                sqlPara[5] = posdb_vnmSqlDAC.newInParam("@RELATIVE_EVENT", SqlDbType.VarChar, "");
                sqlPara[6] = posdb_vnmSqlDAC.newInParam("@IS_SEND_SERVER", SqlDbType.Bit, 0);
                sqlPara[7] = posdb_vnmSqlDAC.newInParam("@DATE_SYNCHROUS", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                sqlPara[8] = posdb_vnmSqlDAC.newInParam("@QUERY_BUILDER", SqlDbType.NText, null);
                sqlPara[9] = posdb_vnmSqlDAC.newInParam("@QUERY_BUILDER_SERVER", SqlDbType.NText, null);
                SqlDAC.Execute(proc, sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetAutoCode' : " + ex.Message);
            }
        }
        public static string GetAutoCode(string table, string col, string prefix)
        {
            string result = "";
            try
            {
                SqlParameter[] para = new SqlParameter[3];
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                para[0] = posdb_vnmSqlDAC.newInParam("@Col", col);
                para[1] = posdb_vnmSqlDAC.newInParam("@Table", table);
                para[2] = posdb_vnmSqlDAC.newInParam("@Prefix", prefix);
                DataTable datatable = SqlDAC.GetDataTable("GetAutoCode", para);
                result = datatable.Rows[0]["code"].ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetAutoCode' : " + ex.Message);
            }
            return result;
        }
        #endregion
    }
}

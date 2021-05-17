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
    public class SOImport
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constant
        private const string IMPORT_PRODUCT_REPORT_PATH = "\\rptImportProducts.rpt";
        #endregion

        #region Contructor
        public SOImport()
        {            
        }
        #endregion

        #region Method
        public static DataTable GetImportList(string importType, DateTime dateFrom, DateTime dateTo,string invoiceCode)
        {
            DataTable dtTable = new DataTable();
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara;
                sqlPara = new SqlParameter[4];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoiceCode);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dateFrom);
                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATETO", SqlDbType.DateTime, dateTo);
                sqlPara[3] = posdb_vnmSqlDAC.newInParam("@IMPORT_TYPE", SqlDbType.VarChar, importType);
                dtTable = SqlDAC.GetDataTable("EXPORT_PRODUCTS_ReadDetail", sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetImportList' : " + ex.Message);
            }
            return dtTable;
        }
        public static DataTable GetImportInfo(string invoiceCode)
        {
            DataTable dt = new DataTable();
            try
            {
                string proc = "Export_Products_GetByInvoiceCode";
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoiceCode);
                dt = SqlDAC.GetDataTable(proc, sqlPara);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetImportInfo' : " + ex.Message);
            }
            return dt;
        }
        public static DataTable GetImportDetail(string invoiceCode, string pricetype)
        {
            DataTable dt = new DataTable();
            try
            {
                float f = 0;
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                SqlParameter[] sqlParaDetail = new SqlParameter[2];
                sqlParaDetail[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoiceCode);
                sqlParaDetail[1] = posdb_vnmSqlDAC.newInParam(pricetype, SqlDbType.Float, f);
                dt = SqlDAC.GetDataTable("Export_Detail_GetList_By_InvoiceCode_Pos", sqlParaDetail);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetImportDetail' : " + ex.Message);
            }
            return dt;
        }
        //In đơn nhập hàng
        public static void PrintInvoice(string invoiceCode)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtDetail = ds.Tables.Add("Detail");
                dtDetail.Columns.Add("InvoiceCode", typeof(string));
                dtDetail.Columns.Add("DateExport", typeof(DateTime));
                dtDetail.Columns.Add("DeptCode", typeof(string));
                dtDetail.Columns.Add("RemarksExport", typeof(string));
                dtDetail.Columns.Add("DateImport", typeof(DateTime));
                dtDetail.Columns.Add("ImportCode", typeof(string));
                dtDetail.Columns.Add("RemarksImport", typeof(string));
                dtDetail.Columns.Add("SoNoiBo", typeof(string));
                dtDetail.Columns.Add("OrderDate", typeof(DateTime));
                dtDetail.Columns.Add("RedInvoiceNo", typeof(string));
                dtDetail.Columns.Add("GhiChuDC", typeof(string));
                dtDetail.Columns.Add("SoTienDC", typeof(float));
                dtDetail.Columns.Add("POCONumber", typeof(string));
                dtDetail.Columns.Add("ImportType", typeof(string));
                DataRow rowDetail = dtDetail.NewRow();
                DataTable dtd = GetImportInfo(invoiceCode);
                rowDetail["InvoiceCode"] = dtd.Rows[0]["InvoiceCode"].ToString();
                rowDetail["DateExport"] = DateTime.Parse(dtd.Rows[0]["DateExport"].ToString());
                rowDetail["DeptCode"] = "";
                rowDetail["RemarksExport"] = dtd.Rows[0]["RemarksExport"].ToString();
                rowDetail["DateImport"] = DateTime.Parse(dtd.Rows[0]["DateImport"].ToString());
                rowDetail["ImportCode"] = dtd.Rows[0]["ImportCode"].ToString();
                rowDetail["RemarksImport"] = dtd.Rows[0]["RemarksImport"].ToString();
                rowDetail["SoNoiBo"] = dtd.Rows[0]["SoNoiBo"].ToString();
                rowDetail["OrderDate"] = DateTime.Parse(dtd.Rows[0]["OrderDate"].ToString());
                rowDetail["RedInvoiceNo"] = dtd.Rows[0]["RedInvoiceNo"].ToString();
                rowDetail["GhiChuDC"] = dtd.Rows[0]["GhiChuDC"].ToString();
                rowDetail["SoTienDC"] = float.Parse(dtd.Rows[0]["SoTienDC"].ToString());
                rowDetail["POCONumber"] = dtd.Rows[0]["POCONumber"].ToString();
                rowDetail["ImportType"] = dtd.Rows[0]["ImportType"].ToString();
                dtDetail.Rows.Add(rowDetail);

                DataTable dtProduct = ds.Tables.Add("Products");
                dtProduct.Columns.Add("ProductId", typeof(string));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("ShortName", typeof(string));
                dtProduct.Columns.Add("Unit", typeof(string));
                dtProduct.Columns.Add("Quantity", typeof(int));
                dtProduct.Columns.Add("Price", typeof(float));
                dtProduct.Columns.Add("Total", typeof(float));
                dtProduct.Columns.Add("Type", typeof(string));
                dtProduct.Columns.Add("TypeName", typeof(string));

                DataTable dtp1 = GetImportDetail(invoiceCode, "@PRODUCT_PRICE1");
                foreach (DataRow row in dtp1.Rows)
                {
                    DataRow rowProduct = dtProduct.NewRow();
                    rowProduct["ProductId"] = row["ProductId"].ToString();
                    rowProduct["ProductName"] = row["ProductName"].ToString();
                    rowProduct["ShortName"] = row["ShortName"].ToString();
                    rowProduct["Unit"] = row["Unit"].ToString();
                    rowProduct["Quantity"] = int.Parse(row["Quantity"].ToString());
                    rowProduct["Price"] = float.Parse(row["ProductPrice"].ToString());
                    rowProduct["Total"] = float.Parse(row["TotalPrice"].ToString());
                    rowProduct["Type"] = "Hàng bán";
                    rowProduct["TypeName"] = row["CAT"].ToString();
                    dtProduct.Rows.Add(rowProduct);
                }
                DataTable dtp2 = GetImportDetail(invoiceCode, "@PRODUCT_PRICE0");
                foreach (DataRow row in dtp2.Rows)
                {
                    DataRow rowProduct = dtProduct.NewRow();
                    rowProduct["ProductId"] = row["ProductId"].ToString();
                    rowProduct["ProductName"] = row["ProductName"].ToString();
                    rowProduct["ShortName"] = row["ShortName"].ToString();
                    rowProduct["Unit"] = row["Unit"].ToString();
                    rowProduct["Quantity"] = row["Quantity"].ToString();
                    rowProduct["Price"] = row["ProductPrice"].ToString();
                    rowProduct["Total"] = row["TotalPrice"].ToString();
                    rowProduct["Type"] = "Hàng khuyến mãi";
                    rowProduct["TypeName"] = row["CAT"].ToString();
                    dtProduct.Rows.Add(rowProduct);
                }

                DataTable dtStoreInfo = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStoreInfo);
                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);

                frmReportView frm = new frmReportView();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.path = IMPORT_PRODUCT_REPORT_PATH;
                frm.ds = ds;
                frm.Show();
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintInvoice' : " + ex.Message);
            }
        }
        //Xóa đơn nhập hàng
        public static void DeleteInvoice(string invoiceCode)
        {
            try
            {
                posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
                DataRow row = GetImportInfo(invoiceCode).Rows[0];
                string sohd = row["RedInvoiceNo"].ToString();
                string poco = row["POCONumber"].ToString();
                string epevent = row["EPeventid"].ToString();
                string edevent = row["EDeventid"].ToString();
                string itevent = row["ITeventid"].ToString();

                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@GenerateCode", SqlDbType.VarChar, invoiceCode);
                SqlDAC.Execute("Inventory_Temp_DeleteByGenerateCode", sqlPara);
                CreateEvent(itevent, "INVENTORY_TEMP", "", 3);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoiceCode);
                SqlDAC.Execute("EXPORT_DETAIL_DeleteByInvoiceCode", sqlPara);
                CreateEvent(edevent, "EXPORT_DETAIL", "", 3);
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoiceCode);
                SqlDAC.Execute("EXPORT_PRODUCTS_Delete", sqlPara);
                CreateEvent(epevent, "EXPORT_PRODUCTS", "", 3);

                if (!string.IsNullOrEmpty(sohd))
                {
                    string query = "delete CN_HoaDon where SoHD = @SoHD";
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SoHD", SqlDbType.VarChar, sohd);
                    SqlDAC.InlineSql_ExecuteNonQuery(query, sqlPara);
                }
                if (!string.IsNullOrEmpty(poco))
                {
                    string query = "update PO_DVKH set IsActive = 1 where POCONumber = @POCONumber";
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@POCONumber", SqlDbType.VarChar, poco);
                    SqlDAC.InlineSql_ExecuteNonQuery(query, sqlPara);
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'DeleteInvoice' : " + ex.Message);
            }
        }
        //Nhập tồn kho đầu kì
        public static void InventoryImport(List<InventoryImportEntities> plist)
        {
            try
            {
                foreach (InventoryImportEntities p in plist)
                {
                    string invEvent = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", "HAITHANH-PC-CH40171-13");
                    INVENTORY_TEMP invTemp = new INVENTORY_TEMP();
                    invTemp.INVENTORY_ID = System.Guid.NewGuid();
                    invTemp.CREATED_DATE = p.CreatedDate;
                    invTemp.PRODUCT_ID = p.ProductID.ToUpper();
                    invTemp.P_ID = "";
                    invTemp.AMOUNT = p.ProductQuantity;
                    invTemp.TYPE_CODE = 0;
                    invTemp.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                    invTemp.ZONE_CODE = "";
                    invTemp.GENERATE_CODE = "";
                    invTemp.EVENT_ID = invEvent;
                    invTemp.WAREHOUSE = null;
                    invTemp.Save(true);
                    CreateEvent(invEvent, "INVENTORY_TEMP", "", 1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'InventoryImport' : " + ex.Message);
            }
        }
        public static void ErrorImport(List<InventoryImportEntities> plist)
        {
            try
            {
 
            }
            catch (Exception ex)
            {
                log.Error("Error 'ErrorImport' : " + ex.Message);
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

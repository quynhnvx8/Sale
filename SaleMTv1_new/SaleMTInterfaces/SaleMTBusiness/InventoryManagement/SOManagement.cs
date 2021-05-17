using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleMTCommon;
using SaleMTInterfaces.FrmInventoryManagement;
using System.Windows.Forms;
using SaleMTBusiness.InventoryManagement;
using SaleMTDataAccessLayer.SaleMTObj;

namespace SaleMTBusiness.InventoryManagement
{
    public class SOManagement
    {
        #region Declaration
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Trả về table SO .
        /// </summary>
        public static DataTable GetListSO(SOEntities soEn)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string procedure = "PO_DVKH_GetListSO";
                SqlParameter[] para = new SqlParameter[2];
                // Paramaters
                para[0] = posdb_vnmSqlDAC.newInParam("@SoNo", soEn.SoNo);
                para[1] = posdb_vnmSqlDAC.newInParam("@ListProduct",soEn.ListProduct);    
                dataTable = sqlDac.GetDataTable(procedure, para);    
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetListSO': " + ex.Message);
            }
            return dataTable;
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Trả về table Catagory .
        /// </summary>
        public static DataTable GetListCatagory()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string procedure = "DEV_IN_DM_NHOMVATTU_SearchForSO";
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@NhomVT_ID", null) };
                dataTable = sqlDac.GetDataTable(procedure, para);                
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetListCatagory': " + ex.Message);
            }
            return dataTable;
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Tìm kiếm sản phẩm. 
        /// </summary>
        public static DataTable GetListProduct(SOEntities soEn)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", (soEn.ProId != "") ? soEn.ProId : null);
                para[1] = posdb_vnmSqlDAC.newInParam("@PRODUCT_NAME", (soEn.ProName != "") ? soEn.ProName : null);
                para[2] = posdb_vnmSqlDAC.newInParam("@ACTIVE",soEn.Active);
                para[3] = posdb_vnmSqlDAC.newInParam("@CATEGORY", (soEn.Category != "") ? soEn.Category : null);
                dtResult = sqlDac.GetDataTable("PRODUCTS_FilterSO", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetListProduct':" + ex.Message);
            }
            return dtResult;
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013:show dialog chọn sản phẩm .
        /// </summary>
        public static SOEntities ShowChoseProduct(Dictionary<string, string> translate)
        {
            SOEntities soEn = new SOEntities();
            try
            {
                dlgChooseProduct dlgChoose = new dlgChooseProduct(translate);
                dlgChoose.StartPosition = FormStartPosition.CenterScreen;
                dlgChoose.ShowDialog();
                if (dlgChoose.SoEnResult != null && dlgChoose.SoEnResult.ListProduct != "")
                {
                    soEn.ListProduct = dlgChoose.SoEnResult.ListProduct;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ShowChoseProduct': " + ex.Message);
            }
            return soEn;
        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : add sản phẩm.
        /// </summary>
        public static void AddProduct(DataTable dtProduct, DataTable dtItem)
        {
            try
            {
                dtProduct.Rows.Clear();
                foreach (DataRow r in dtItem.Rows)
                {
                    DataRow dr = dtProduct.NewRow();
                    dr["PRODUCT_ID"] = r["PRODUCT_ID"];
                    dr["PRODUCT_NAME"] = r["PRODUCT_NAME"];
                    dtProduct.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddProduct': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : add sản phẩm.
        /// </summary>
        public static void AddProductFromList(DataTable dtProduct, List<SOImportEntities> lstItem)
        {
            try
            {
                dtProduct.Rows.Clear();
                for (int i = 0; i < lstItem.Count;i++ )
                {
                    SOImportEntities so = lstItem[i];
                    DataRow dr = dtProduct.NewRow();
                    dr["PRODUCT_ID"] = so.ProductId;
                    dr["PRODUCT_NAME"] = so.ProductName;
                    dtProduct.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddProductFromList': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013:Tạo bảng product.
        /// </summary>
        public static DataTable CreateTable(DataTable dtProduct)
        {            
            try
            {
                dtProduct.Columns.Add("PRODUCT_ID", typeof(string));
                dtProduct.Columns.Add("PRODUCT_NAME", typeof(string));
            }
            catch (Exception ex)
            {
                log.Error("Error 'CreateTable': " + ex.Message);
            }
            return dtProduct;
        }
        /// <summary>
        /// Người tạo Luannv – 01/11/2013 : lưu sản phẩm.
        /// </summary>
        public static void SavePO(DataTable dtProduct)
        {
            try
            {
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    int quantity = Convert.ToInt32(dtProduct.Rows[i]["QuantitySuspend"].ToString());                    
                    PO_DVKH po = new PO_DVKH();
                    po = PO_DVKH.ReadByAutoId(Convert.ToInt32(dtProduct.Rows[i]["AutoId"].ToString()))[0];
                    po.QuantitySuspend = quantity;
                    po.Save(false);
                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SavePO': " + ex.Message);
            }

        }
        #endregion
    }
}

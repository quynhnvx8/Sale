using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTInterfaces.FrmInventoryManagement;
using System.Windows.Forms;
using System.Data;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleMTCommon;

namespace SaleMTBusiness.InventoryManagement
{
    public class CheckInventory
    {
        #region Declaration

        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Method/Function

        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Showdialog tìm kiếm sản phẩm. 
        /// </summary>
        public static CheckInventoryEntities ShowProductSearch(string proCode, Dictionary<string, string> translate)
        {
            CheckInventoryEntities inventEn = new CheckInventoryEntities();
            try
            {
                DataTable dtSearch = SearchProduct(proCode, false);
                if (dtSearch.Rows.Count == 1)
                {
                    inventEn.ProductID = dtSearch.Rows[0]["PRODUCT_ID"].ToString();
                    inventEn.ProductName = dtSearch.Rows[0]["PRODUCT_NAME"].ToString();
                    inventEn.Price = Conversion.GetCurrency(dtSearch.Rows[0]["PRICE"].ToString());
                    inventEn.ShortName = dtSearch.Rows[0]["SHORT_NAME"].ToString();
                }
                else if (dtSearch.Rows.Count > 1)
                {
                    frmDialogSearchInventory dialogSearchInvent = new frmDialogSearchInventory(translate);
                    dialogSearchInvent.InvenEn = new CheckInventoryEntities();
                    dialogSearchInvent.InvenEn.ProCode = proCode;
                    dialogSearchInvent.InvenEn.DtSearch = dtSearch;
                    dialogSearchInvent.StartPosition = FormStartPosition.CenterScreen;
                    dialogSearchInvent.ShowDialog();
                    if (dialogSearchInvent.InvenEn.ProductID != null)
                    {
                        inventEn = dialogSearchInvent.InvenEn;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ShowProductSearch':" + ex.Message);
            }
            return inventEn;
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Tìm kiếm sản phẩm. 
        /// </summary>
        public static DataTable SearchProduct(string proCode,Boolean status)
        {
            DataTable dtResult = new DataTable();
            try
            {
                string productId = (status) ? proCode : "";
                string productName = (!status) ? proCode : "";
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", productId);
                para[1] = posdb_vnmSqlDAC.newInParam("@PRODUCT_NAME", productName);
                dtResult = sqlDac.GetDataTable("PRODUCTS_SearchByCodeOrName", para);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchProduct':" + ex.Message);
            }
            return dtResult;
        }
        #endregion
    }
}

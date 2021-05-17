using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;
using SaleMTInterfaces.FrmSaleManagement;
using System.Windows.Forms;
using System.Data;
using SaleMTCommon;

namespace SaleMTBusiness.CustomerManagement
{
    public class CustomerManager
    {
        #region Declaration
        private static posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Tìm kiếm đầy đủ thông tin khách hàng theo mã khách hàng truyền vào.
        /// </summary>
        public static CUSTOMERS GetFullEntitiesCustomer(CUSTOMERS cusEn)
        {
            CUSTOMERS cus = new CUSTOMERS();
            List<CUSTOMERS> list = posdb_vnmSqlDAC.ReadById<CUSTOMERS>(cusEn, "CUSTOMERS");
            if (list != null && list.Count > 0)
            {
                cus = list[0];
            }
            return cus;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Tìm kiếm khách hàng theo mã khách hàng.
        /// </summary>
        public static CUSTOMERS SearchCustomer(string cusCode, int deptCode, posdb_vnmSqlDAC sqlDac, Dictionary<string, string> translate)
        {
            CUSTOMERS cusResult = new CUSTOMERS();
            try
            {
                SqlParameter[] paraSearch = new SqlParameter[2];
                paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode);

                DataTable dtTemp = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                if (dtTemp.Rows.Count == 1)
                {
                    cusResult.CUSTOMER_ID = dtTemp.Rows[0]["CUSTOMER_ID"].ToString();
                    cusResult.FIRST_NAME = dtTemp.Rows[0]["FIRST_NAME"].ToString();
                    cusResult.LAST_NAME = dtTemp.Rows[0]["LAST_NAME"].ToString();
                    cusResult.ADDRESS = dtTemp.Rows[0]["ADDRESS"].ToString();
                    cusResult.MOBILE_PHONE = dtTemp.Rows[0]["MOBILE_PHONE"].ToString();
                    if (dtTemp.Rows[0]["DATE_OF_BIRTH"].ToString() != "")
                    {
                        cusResult.DATE_OF_BIRTH = Conversion.stringToDateTime(dtTemp.Rows[0]["DATE_OF_BIRTH"].ToString());
                    }
                    else
                    {
                        cusResult.DATE_OF_BIRTH = null;
                    }
                    cusResult.ID_NO = dtTemp.Rows[0]["ID_NO"].ToString();
                    cusResult.EMAIL_ADDRESS = dtTemp.Rows[0]["EMAIL_ADDRESS"].ToString();
                    cusResult.DEPT_CODE = (int)dtTemp.Rows[0]["DEPT_CODE"];
                    // lấy full dữ liệu khách hàng
                    cusResult = GetFullEntitiesCustomer(cusResult);
                }
                else
                {
                    dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                    dialogSearch.DtCustormer = dtTemp;
                    dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                    dialogSearch.ShowDialog();
                    if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                    {
                        CUSTOMERS cusEn = dialogSearch.Customer;
                        cusResult = GetFullEntitiesCustomer(cusEn);
                    }
                    else
                    {
                        cusResult = null;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'SearchCustomer': " + ex.Message);
            }
            return cusResult;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load dữ liệu master code cho các combobox.
        /// </summary>
        public static void LoadMasterCode(ComboBox cboMaster,string prifix)
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", prifix) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);
                DataTable dt = new DataTable();
                dt = dtMaster.Copy();
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.NewRow();

                    r["MASTER_CODE"] = -1;
                    r["MASTER_NAME"] = "";

                    dt.Rows.InsertAt(r,0);
                    cboMaster.DataSource = dt;
                    cboMaster.DisplayMember = "MASTER_NAME";
                    cboMaster.ValueMember = "MASTER_CODE";
                    cboMaster.SelectedIndex = -1;
                }
                //if (dtMaster.Rows.Count > 0)
                //{
                //    cboMaster.DataSource = dtMaster;
                //    cboMaster.DisplayMember = "MASTER_NAME";
                //    cboMaster.ValueMember = "MASTER_CODE";
                //    cboMaster.SelectedIndex = -1;
                //}

            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadMasterCode': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load dữ liệu loại thẻ khách hàng.
        /// </summary>
        public static void LoadCardType(ComboBox cboCardType, string prifix)
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", prifix) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_CardType", para);
                DataTable dt = new DataTable();
                dt = dtMaster.Copy();
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.NewRow();

                    r["MASTER_CODE"] = -1;
                    r["MASTER_NAME"] = "";

                    dt.Rows.InsertAt(r, 0);
                    cboCardType.DataSource = dt;
                    cboCardType.DisplayMember = "MASTER_NAME";
                    cboCardType.ValueMember = "MASTER_CODE";
                    cboCardType.SelectedIndex = -1;
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadCardType': " + ex.Message);
            }
        }
        public static void LoadMasterCodeByParent(ComboBox cboMaster, string prifix,string parent)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[2];
                para[0] = posdb_vnmSqlDAC.newInParam("@MASTER_CODE", prifix);
                para[1] = posdb_vnmSqlDAC.newInParam("@PARENT_CODE", parent);
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_Parent", para);
                if (dtMaster.Rows.Count <= 0)
                {
                    DataRow dr = dtMaster.NewRow();
                    dr["MASTER_NAME"] = "";
                    dr["MASTER_CODE"] = "";
                    dtMaster.Rows.Add(dr);
                }                
                cboMaster.DataSource = dtMaster;
                cboMaster.DisplayMember = "MASTER_NAME";
                cboMaster.ValueMember = "MASTER_CODE";
                cboMaster.SelectedIndex = -1;
                

            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadMasterCode': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load lịch sử mua hàng.
        /// </summary>
        public static DataTable LoadTranferHistory(string cusCode)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", null);
                para[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM", null);
                para[2] = posdb_vnmSqlDAC.newInParam("@DATETO", null);
                para[3] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", cusCode);
                dtResult = sqlDac.GetDataTable("SALES_EXPORTS_SearchBill", para);
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTranferHistory': " + ex.Message);
            }
            return dtResult;
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load chi tiết sản phẩm.
        /// </summary>
        public static DataTable LoadTranferDetailsHistory(string saleCode)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", saleCode) };
                dtResult = sqlDac.GetDataTable("SALES_EXPORTS_ITEMS_SearchDetailsBill", para);
                
                dtResult.Columns.Add("PRICE", typeof(string));
                dtResult.Columns.Add("TOTAL", typeof(string));
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    dtResult.Rows[i]["PRICE"] = Conversion.GetCurrency(dtResult.Rows[i]["PRICE_SALES"].ToString());
                    dtResult.Rows[i]["TOTAL"] = Conversion.GetCurrency(dtResult.Rows[i]["AMOUNT"].ToString());
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTranferDetailsHistory': " + ex.Message);
            }
            return dtResult;
        }
        #endregion
    }
}

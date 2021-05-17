using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using System.Text.RegularExpressions;


namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmCheckInventory : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructor
        public frmCheckInventory(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxSanPham.Text = translate["frmCheckInventory.gbxSanPham.Text"];
            this.btnCheck.Text = translate["frmCheckInventory.btnCheck.Text"];
            this.label4.Text = translate["frmCheckInventory.label4.Text"];
            this.label3.Text = translate["frmCheckInventory.label3.Text"];
            this.label2.Text = translate["frmCheckInventory.label2.Text"];
            this.label1.Text = translate["frmCheckInventory.label1.Text"];
            this.gpxTonKho.Text = translate["frmCheckInventory.gpxTonKho.Text"];
            this.StoreName.HeaderText = translate["frmCheckInventory.StoreName.HeaderText"];
            this.StoreCode.HeaderText = translate["frmCheckInventory.StoreCode.HeaderText"];
            this.StoreLocation.HeaderText = translate["frmCheckInventory.StoreLocation.HeaderText"];
            this.Quantity.HeaderText = translate["frmCheckInventory.Quantity.HeaderText"];
            this.StoreAddress.HeaderText = translate["frmCheckInventory.StoreAddress.HeaderText"];
            this.StoreTel.HeaderText = translate["frmCheckInventory.StoreTel.HeaderText"];
            this.StoreFax.HeaderText = translate["frmCheckInventory.StoreFax.HeaderText"];
            this.btnExit.Text = translate["frmCheckInventory.btnExit.Text"];
            this.Text = translate["frmCheckInventory.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Kiểm tra/lấy thông tin sản phẩm
        /// </summary>
        private bool ProductLoad(string productID)
        {
            try
            {
                txtProductCode.Text = productID;
                List<PRODUCTS> pList = PRODUCTS.ReadByPRODUCT_ID(productID);
                if (pList.Count > 0)
                {
                    txtProductName.Text = pList[0].PRODUCT_NAME;
                    txtShortName.Text = pList[0].SHORT_NAME;
                    txtProductPrice.Text = Conversion.GetCurrency((pList[0].PRICE * 1.1).ToString());
                    dgvInventory.DataSource = GridLoad(productID);
                    return true;
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'ProductLoad' : " + ex.Message);
            }
            return false;
        }
        private void ProductCheck()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductCode.Text.Trim()))
                {
                    if (!ProductLoad(txtProductCode.Text.Trim()))
                    {
                        frmDialogProductSearch frmSearch = new frmDialogProductSearch(txtProductCode.Text.Trim(), translate);
                        if (frmSearch.ShowDialog(this) == DialogResult.OK)
                        {
                            string productID = frmSearch.ProductID;
                            frmSearch.Dispose();
                            ProductLoad(productID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ProductCheck' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Tạo grid tồn kho
        /// </summary>
        private DataTable GridLoad(string productID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StoreName", typeof(string));
            dt.Columns.Add("StoreCode", typeof(string));
            dt.Columns.Add("StoreLocation", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("StoreAddress", typeof(string));
            dt.Columns.Add("StoreTel", typeof(string));
            dt.Columns.Add("StoreFax", typeof(string));
            try
            {                
                string sqlQuery = "select SUM(AMOUNT) as Quantity, STORE_CODE from INVENTORY_TEMP where PRODUCT_ID=@PRODUCT_ID group by STORE_CODE";
                SqlParameter[] sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, productID) };
                DataSet ds = SqlDAC.InlineSql_Execute(sqlQuery, sqlPara);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow storeRow = dt.NewRow();
                    storeRow["Quantity"] = row["Quantity"].ToString();
                    string[] split = Regex.Split(row["STORE_CODE"].ToString(), "@");
                    //
                    sqlQuery = "select * from DEPT where STORE_CODE = @STORE_CODE";
                    sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@STORE_CODE", SqlDbType.VarChar, split[0]) };
                    ds = SqlDAC.InlineSql_Execute(sqlQuery, sqlPara);
                    storeRow["StoreName"] = ds.Tables[0].Rows[0]["DEPT_NAME"].ToString();
                    storeRow["StoreAddress"] = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                    storeRow["StoreTel"] = ds.Tables[0].Rows[0]["TEL"].ToString();
                    storeRow["StoreFax"] = ds.Tables[0].Rows[0]["TEL"].ToString();                    
                    //
                    sqlQuery = "select * from MASTER_DATA where MASTER_CODE = @MASTER_CODE";
                    sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", SqlDbType.VarChar, split[2]) };
                    ds = SqlDAC.InlineSql_Execute(sqlQuery, sqlPara);
                    storeRow["StoreLocation"] = ds.Tables[0].Rows[0]["MASTER_NAME"].ToString();
                    //
                    sqlQuery = "select * from MASTER_DATA where MASTER_CODE = @MASTER_CODE";
                    sqlPara = new SqlParameter[] { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", SqlDbType.VarChar, split[1]) };
                    ds = SqlDAC.InlineSql_Execute(sqlQuery, sqlPara);
                    storeRow["StoreCode"] = ds.Tables[0].Rows[0]["MASTER_NAME"].ToString();
                    //                    
                    dt.Rows.Add(storeRow);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GridLoad' : " + ex.Message);
            }
            return dt;
        }
        //
        private string GetLocation(int deptParent)
        {
            string location = "";
            try
            {
                if(listDept == null)
                    listDept = DEPT.ReadAll();
                bool flag = true;
                while (flag)
                {
                    foreach(DEPT dept in listDept)
                    {
                        if (dept.DEPT_CODE == deptParent)
                        {
                            if (dept.DEPT_NAME == "VNM")
                            {
                                flag = false;
                                break;
                            }
                            else
                            {
                                location += dept.DEPT_NAME + " ";
                                deptParent = (int)dept.DEPT_PARENT;
                                break;
                            }
                        }
                    }
                }
                //FindLocation(ref location, deptParent);                
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetLocation' : " + ex.Message);
            }
            return location;
        }
        List<DEPT> listDept;
        private void FindLocation(ref string location, int deptparent)
        {
            foreach (DEPT d in listDept)
            {
                if (d.DEPT_CODE == deptparent && d.DEPT_NAME != "VNM" )
                {
                    location += d.DEPT_NAME + " ";
                    FindLocation(ref location, (int)d.DEPT_PARENT);
                    return;
                }
            }
        }
        #endregion

        #region Event
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ProductCheck();
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            ProductCheck();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion        
    }
}

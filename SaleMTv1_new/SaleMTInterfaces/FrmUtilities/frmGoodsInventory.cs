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
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using SaleMTBusiness.InventoryManagement;
using SaleMTInterfaces.FrmCustomerEmployee;
using SaleMTInterfaces.FrmInventoryManagement;
namespace SaleMTInterfaces.FrmUtilities
{
    /// <summary>
    /// Người tạo Luannv - 04/11/2013 : form kiểm kê hàng
    /// </summary>
    public partial class frmGoodsInventory : TabForm
    {
        #region Declaration
        private const string TITLE_EXPORT = "Kiểm kê hàng";
        private const string KKI_CODE = "KKI.";
        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        private List<string> listPro = new List<string>();
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool all = true;
        private bool[] status;
        #endregion

        #region Contructor
        

        public frmGoodsInventory(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            dgvProduct.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvProduct_EditingControlShowing);
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox4.Text = translate["frmGoodsInventory.groupBox4.Text"];
            this.colCAT.HeaderText = translate["frmGoodsInventory.colCAT.HeaderText"];
            this.colPRODUCT_GROUP.HeaderText = translate["frmGoodsInventory.colPRODUCT_GROUP.HeaderText"];
            this.colPRODUCT_ID.HeaderText = translate["frmGoodsInventory.colPRODUCT_ID.HeaderText"];
            this.colPRODUCT_NAME.HeaderText = translate["frmGoodsInventory.colPRODUCT_NAME.HeaderText"];
            this.colQUANTITY.HeaderText = translate["frmGoodsInventory.colQUANTITY.HeaderText"];
            this.colPRODUCT_PRICE.HeaderText = translate["frmGoodsInventory.colPRODUCT_PRICE.HeaderText"];
            this.colTotalMoney.HeaderText = translate["frmGoodsInventory.colTotalMoney.HeaderText"];
            this.colQuantityIvent.HeaderText = translate["frmGoodsInventory.colQuantityIvent.HeaderText"];
            this.colQuantityOdd.HeaderText = translate["frmGoodsInventory.colQuantityOdd.HeaderText"];
            this.colTotalQuantity.HeaderText = translate["frmGoodsInventory.colTotalQuantity.HeaderText"];
            this.colDifferen.HeaderText = translate["frmGoodsInventory.colDifferen.HeaderText"];
            this.colUNIT1.HeaderText = translate["frmGoodsInventory.colUNIT1.HeaderText"];
            this.colPRICE.HeaderText = translate["frmGoodsInventory.colPRICE.HeaderText"];
            this.colUNIT_SLQD.HeaderText = translate["frmGoodsInventory.colUNIT_SLQD.HeaderText"];
            this.label2.Text = translate["frmGoodsInventory.label2.Text"];
            this.label3.Text = translate["frmGoodsInventory.label3.Text"];
            this.btnClose.Text = translate["frmGoodsInventory.btnClose.Text"];
            this.btnExportDC.Text = translate["frmGoodsInventory.btnExportDC.Text"];
            this.btnExportExcel.Text = translate["frmGoodsInventory.btnExportExcel.Text"];
            this.btnImportDC.Text = translate["frmGoodsInventory.btnImportDC.Text"];
            this.btnInventory.Text = translate["frmGoodsInventory.btnInventory.Text"];
            this.gbxlistTK.Text = translate["frmGoodsInventory.gbxlistTK.Text"];
            this.Column1.HeaderText = translate["frmGoodsInventory.Column1.HeaderText"];
            this.lblDate.Text = translate["frmGoodsInventory.lblDate.Text"];
            this.btnSearch.Text = translate["frmGoodsInventory.btnSearch.Text"];
            this.Text = translate["frmGoodsInventory.Text"];
        }	

        #endregion

        #region Method
        /// <sumary>
        /// Người tạo Luannv - 17/02/2014: Lưu dữ liệu kiểm kê
        /// </sumary>
        private void SaveKK()
        {
            try
            {
                string code = sqlDac.GetAutoCode("Table_KIEMKE", "MAKK", KKI_CODE + sqlDac.GetDateTimeServer().ToString("yyyyMMdd") + ".");
                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    DataGridViewRow r = dgvProduct.Rows[i];

                    string name = (r.Cells[3].Value != null) ? r.Cells[3].Value.ToString().Trim() : "";
                    if (name != "Tổng cộng:")
                    {
                        Table_KIEMKE tableKK = new Table_KIEMKE();
                        tableKK.MAKK = code;
                        tableKK.CAT = (r.Cells[0].Value.ToString() != "") ? r.Cells[0].Value.ToString() : "";
                        tableKK.PRODUCT_GROUP = r.Cells[1].Value.ToString();
                        tableKK.PRODUCT_ID = r.Cells[2].Value.ToString();
                        tableKK.PRODUCT_NAME = r.Cells[3].Value.ToString();
                        tableKK.QUANTITY = (r.Cells[4].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[4].Value.ToString()) : 0;
                        tableKK.PRODUCT_PRICE = (r.Cells[5].Value.ToString() != "") ? (float)Convert.ToDouble(r.Cells[5].Value.ToString()) : 0;
                        tableKK.TOTAL_MONEY = (r.Cells[6].Value.ToString() != "") ? (float)Convert.ToDouble(r.Cells[6].Value.ToString()) : 0;
                        tableKK.SL_PACKET = (r.Cells[7].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[7].Value.ToString()) : 0;
                        tableKK.SL_LE = (r.Cells[8].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[8].Value.ToString()) : 0;
                        tableKK.TOTAL_INPUT = (r.Cells[9].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[9].Value.ToString()) : 0;
                        tableKK.SL_LECH = (r.Cells[10].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[10].Value.ToString()) : 0;
                        tableKK.DVT_PACKET = r.Cells[11].Value.ToString();
                        tableKK.SLQUYDOI = (r.Cells[12].Value.ToString() != "") ? (long)Convert.ToDecimal(r.Cells[12].Value.ToString()) : 0;
                        tableKK.DVT_LE = r.Cells[13].Value.ToString();
                        tableKK.CREATE_DATE = sqlDac.GetDateTimeServer();
                        tableKK.CREATE_BY = UserImformation.UserName;
                        tableKK.STORE_CODE = UserImformation.DeptCode;
                        tableKK.Save(true);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <sumary>
        /// Người tạo Luannv - 17/02/2014: Kiểm tra đã có bản kiểm kê lưu trong ngày chưa
        /// </sumary>
        private bool CheckKK()
        {
            bool ch = true;
            try
            {
                string sql = "select isNull(COUNT(*),0) countKK from Table_KIEMKE where  CONVERT(date,CREATE_DATE) = CONVERT(date,getdate())";
                DataTable dt = sqlDac.InlineSql_Execute(sql, null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int kk = Convert.ToInt32(dt.Rows[0]["countKK"].ToString());
                    ch = (kk > 0);
                }
                else
                {
                    ch = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return ch;
        }

        /// <sumary>
        /// Người tạo Luannv - 17/02/2014: Kiểm tra đã có bản kiểm kê lưu trong ngày chưa
        /// </sumary>
        private void DeleteKKCurrent()
        {
            try
            {
                string sql = "delete Table_KIEMKE where  CONVERT(date,CREATE_DATE) = CONVERT(date,getdate())";
                sqlDac.InlineSql_ExecuteNonQuery(sql, null);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Khởi tạo vị trí và size cho các panel chính trong form
        /// </summary>
        private void LoadControl()
        {
            try
            {
                txtProduct.Size = new Size(880,23);

                pnlLeft.Visible = true;
                pnlLeftLage.Location = new Point(0, 0);
                pnlLeftLage.Visible = false;
                pnlLeftLage.Size = new Size(200, 655);
                panCenter.Location = new Point(24, 0);
                panCenter.Size = new Size(1227, 660);               
                //
                panRight.Visible = false;
                panRight.Location = new Point(995, 0);
                pnlRight.Visible = true;
                //
                pnlStoreListPar.Size = new Size(184, 25);
                pnlPlacePar.Size = new Size(184, 25);
                pnlPlacePar.Location = new Point(3,40);
                pnlShopPar.Size = new Size(184, 25);
                pnlShopPar.Location = new Point(3, 64);
                //
                btnExportDC.Enabled = false;
                btnImportDC.Enabled = false;
                btnExportExcel.Enabled = false;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel thông tin cửa hàng bên trái
        /// </summary>
        private void ResizeLeft()
        {
            try
            {
                bool visible = pnlLeft.Visible;
                if (visible)
                {
                    pnlLeft.Visible = false;
                    pnlLeftLage.Visible = true;
                    panCenter.Location = new Point(200, 0);
                    panCenter.Size = new Size(panCenter.Size.Width - 176, 635);
                    txtProduct.Size = new Size(txtProduct.Size.Width - 176,23);
                }
                else
                {
                    pnlLeft.Visible = true;
                    pnlLeftLage.Visible = false;
                    panCenter.Location = new Point(24, 0);
                    panCenter.Size = new Size(panCenter.Size.Width + 176, 635);
                    txtProduct.Size = new Size(txtProduct.Size.Width +176, 23);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel tìm kiếm các đợt kiểm kê bên phải
        /// </summary>
        private void ResizeRight()
        {
            try
            {
                bool visible = pnlRight.Visible;
                if (visible)
                {
                    pnlRight.Visible = false;
                    panRight.Visible = true;
                    panCenter.Size = new Size(panCenter.Size.Width - 176, 635);
                    txtProduct.Size = new Size(txtProduct.Size.Width - 176, 23);
                }
                else
                {
                    pnlRight.Visible = true;
                    panRight.Visible = false;
                    panCenter.Size = new Size(panCenter.Size.Width + 176, 635);
                    txtProduct.Size = new Size(txtProduct.Size.Width + 176, 23);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel chuỗi cửa hàng
        /// </summary>
        private void ResizeStoreList()
        {
            try
            {
                if (pnlStoreListPar.Size.Height == 25)
                {
                    btnStorelist.ImageIndex = 1;
                    pnlStoreListPar.Size = new Size(184, 175);
                    pnlPlacePar.Location = new Point(3, 15 + 175);
                    pnlShopPar.Location = new Point(3, 15 + 175+pnlPlacePar.Size.Height);
                }
                else
                {
                    btnStorelist.ImageIndex = 0;
                    pnlStoreListPar.Size = new Size(184, 25);
                    pnlPlacePar.Location = new Point(3, 15 + 25);
                    pnlShopPar.Location = new Point(3, 15 + 25 + pnlPlacePar.Size.Height);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel vị trí
        /// </summary>
        private void ResizePlace()
        {
            try
            {
                if (pnlPlacePar.Size.Height == 25)
                {
                    btnPlace.ImageIndex = 1;
                    pnlPlacePar.Size = new Size(184, 175);
                    pnlShopPar.Location = new Point(3,15 + pnlStoreListPar.Size.Height+175);
                }
                else
                {
                    btnPlace.ImageIndex = 0;
                    pnlPlacePar.Size = new Size(184, 25);
                    pnlShopPar.Location = new Point(3, 15 + pnlStoreListPar.Size.Height + 25);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel thông tin cửa hàng
        /// </summary>
        private void ResizeShop()
        {
            try
            {
                if (pnlShopPar.Size.Height == 25)
                {
                    btnShop.ImageIndex = 1;
                    pnlShopPar.Size = new Size(184, 175);                    
                }
                else
                {
                    btnShop.ImageIndex = 0;
                    pnlShopPar.Size = new Size(184, 25);                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở xuất điều chỉnh từ kết quả kiểm kê
        /// </summary>
        frmGoodsDelivery frmGoodDe;
        private void OpenGoodDelivery()
        {
            try
            {
                // khởi tạo datatable
                DataTable dtOuput = ((DataTable)dgvProduct.DataSource).Copy();
                DataTable dtOuputPro = new DataTable();
                dtOuputPro.Columns.Add("ProductId", typeof(string));
                dtOuputPro.Columns.Add("Quantity", typeof(int));
                dtOuputPro.Columns.Add("Price", typeof(float));
                dtOuputPro.Columns.Add("ProductName", typeof(string));
                dtOuputPro.Columns.Add("Unit", typeof(string));
                dtOuputPro.Columns.Add("P_ID", typeof(string));
                DataRow[] dr = dtOuput.Select("Differen < 0 and PRODUCT_NAME <> 'Tổng cộng:' ");
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        DataRow r = dtOuputPro.NewRow();
                        r["ProductId"] = dr[i]["PRODUCT_ID"].ToString();
                        r["Quantity"] = Math.Abs(Convert.ToInt32(dr[i]["Differen"]));
                        r["Price"] = dr[i]["PRODUCT_PRICE"];
                        r["ProductName"] = dr[i]["PRODUCT_NAME"].ToString();
                        r["Unit"] = dr[i]["UNIT_SLQD"].ToString();
                        r["P_ID"] = "";
                        dtOuputPro.Rows.Add(r);
                    }
                }
                //
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                frmGoodDe = new frmGoodsDelivery(true, dtOuputPro, translate);
                frmGoodDe.MdiParent = parMain;
                Control[] control = parMain.Controls.Find("tlsTab", false);
                foreach (Control ctrol in control)
                {
                    if (ctrol is ToolStrip)
                    {
                        ToolStrip toolStrip = (ToolStrip)ctrol;
                        frmGoodDe.DSSMenuBar = toolStrip;
                        toolStrip.Items.Add(frmGoodDe.DSSMenuTab);
                        frmGoodDe.ListButton = toolStrip.Items;
                    }
                }
                parMain.mnuNewActive();
                frmGoodDe.Show();
                frmGoodDe.DSSMenuTab.Text = frmGoodDe.Text;

            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenGoodReceipt': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở nhập điều chỉnh từ kết quả kiểm kê
        /// </summary>
        frmGoodsReceipt frmGoodre;
        private void OpenGoodReceipt()
        {  
            try
            {
                // khởi tạo datatable
                DataTable dtInput = ((DataTable)dgvProduct.DataSource).Copy();
                DataTable dtInputPro = new DataTable();
                dtInputPro.Columns.Add("ProductId", typeof(string));
                dtInputPro.Columns.Add("Quantity", typeof(int));
                dtInputPro.Columns.Add("ProductPrice", typeof(float));
                dtInputPro.Columns.Add("ProductName", typeof(string));
                dtInputPro.Columns.Add("Unit", typeof(string));
                dtInputPro.Columns.Add("TotalPrice", typeof(float));
                dtInputPro.Columns.Add("SaleOrderNumber", typeof(string));
                dtInputPro.Columns.Add("VAT", typeof(float));
                dtInputPro.Columns.Add("P_ID", typeof(string));
                DataRow[] dr = dtInput.Select("Differen > 0 and PRODUCT_NAME <> 'Tổng cộng:' ");
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        DataRow r = dtInputPro.NewRow();
                        r["ProductId"] = dr[i]["PRODUCT_ID"].ToString();
                        r["Quantity"] = Math.Abs(Convert.ToInt32(dr[i]["Differen"]));
                        r["ProductPrice"] = Math.Abs(Convert.ToDouble(dr[i]["PRODUCT_PRICE"]));
                        r["ProductName"] = dr[i]["PRODUCT_NAME"].ToString();
                        r["Unit"] = dr[i]["UNIT_SLQD"].ToString();
                        r["TotalPrice"] = Math.Abs(Convert.ToInt32(dr[i]["Differen"]) * Convert.ToDouble(dr[i]["PRODUCT_PRICE"]));
                        r["SaleOrderNumber"] = "";
                        r["VAT"] = Convert.ToDouble(dr[i]["PRODUCT_PRICE"])*1.1;
                        r["P_ID"] = "";
                        dtInputPro.Rows.Add(r);
                    }
                }
                //
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                frmGoodre = new frmGoodsReceipt(true, dtInputPro, translate);
                frmGoodre.MdiParent = parMain;
                Control[] control = parMain.Controls.Find("tlsTab", false);
                foreach (Control ctrol in control)
                {
                    if (ctrol is ToolStrip)
                    {
                        ToolStrip toolStrip = (ToolStrip)ctrol;
                        frmGoodre.DSSMenuBar = toolStrip;
                        toolStrip.Items.Add(frmGoodre.DSSMenuTab);
                        frmGoodre.ListButton = toolStrip.Items;
                    }
                }
                parMain.mnuNewActive();
                frmGoodre.Show();
                frmGoodre.DSSMenuTab.Text = frmGoodre.Text;
               
            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenGoodReceipt': " + ex.Message);
            }        
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Tìm kiếm dữ liệu tồn kho
        /// </summary>
        private void SearchPro(string listProduct)
        {
            string proc = "Inventory_Temp_KK_New";
            SqlParameter[] paraPro = new SqlParameter[3];
            paraPro[0] = posdb_vnmSqlDAC.newInParam("@Product", listProduct);
            paraPro[1] = posdb_vnmSqlDAC.newInParam("@CreateTo", Conversion.LastDayTime(dtpDateTo.Value));
            paraPro[2] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", UserImformation.DeptCode+"@"+UserImformation.StoreCode+"@"+UserImformation.BusinessTypeCode);
            DataTable dtPro = new DataTable();
            dtPro = sqlDac.GetDataTable(proc, paraPro);
            if (dtPro.Rows.Count > 0)
            {
                
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = dtPro;
            }

            
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Nhập số lượng kiểm kê
        /// </summary>
        private void ChangeQuantiy(int rowindex, int cellindex)
        {
            try
            {
                if (cellindex == 7 || cellindex == 8)
                {
                    int col = 7;
                    if (cellindex == 7)
                        col = 8;
                    if (cellindex == 8)
                        col = 7;

                    double x = 0;
                    double y = 0;
                    double quanConvert = 0;
                    double quantity = 0;
                    if (dgvProduct.Rows[rowindex].Cells[4].Value.ToString() != null && dgvProduct.Rows[rowindex].Cells[4].Value.ToString() != "")
                        quantity = Convert.ToDouble(dgvProduct.Rows[rowindex].Cells[4].Value.ToString());
                    if (dgvProduct.Rows[rowindex].Cells[12].Value.ToString() != null && dgvProduct.Rows[rowindex].Cells[12].Value.ToString() != "")
                        quanConvert = Convert.ToDouble(dgvProduct.Rows[rowindex].Cells[12].Value.ToString());
                    if (dgvProduct.CurrentCell.EditedFormattedValue != null && dgvProduct.CurrentCell.EditedFormattedValue.ToString() != "")
                        x = Convert.ToDouble(dgvProduct.CurrentCell.EditedFormattedValue.ToString());
                    if (dgvProduct.Rows[rowindex].Cells[col].Value.ToString() != null && dgvProduct.Rows[rowindex].Cells[col].Value.ToString() != "")
                        y = Convert.ToDouble(dgvProduct.Rows[rowindex].Cells[col].Value.ToString());

                    if (col == 7)
                    {
                        dgvProduct.Rows[rowindex].Cells["colDifferen"].Value =  ((y * quanConvert) + x) - quantity ;
                        dgvProduct.Rows[rowindex].Cells["colTotalQuantity"].Value = (y * quanConvert) + x;                        
                    }
                    else
                    {
                        dgvProduct.Rows[rowindex].Cells["colDifferen"].Value = ((x * quanConvert) + y) - quantity;
                        dgvProduct.Rows[rowindex].Cells["colTotalQuantity"].Value = (x * quanConvert) + y;
                        
                    }
                    CalculatorTotal();
                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: tính lại giá trị dòng tổng cộng
        /// </summary>
        private void CalculatorTotal()
        {
            try
            {

                DataTable dt = (DataTable)dgvProduct.DataSource;
                DataRow[] row = dt.Select("Nhom = 1");
                DataRow[] rowTotal = dt.Select("Nhom <> 1");
                int SLPac = 0;
                int SLLe = 0;
                int SLTong = 0;
                int SLLech = 0;
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i]["QuantityIvent"] != null)
                        SLPac = (row[i]["QuantityIvent"].ToString().Trim() != "") ? SLPac + Convert.ToInt32(row[i]["QuantityIvent"]) : SLPac;
                    if (row[i]["QuantityOdd"] != null)
                        SLLe = (row[i]["QuantityOdd"].ToString().Trim() != "") ? SLLe + Convert.ToInt32(row[i]["QuantityOdd"]) : SLLe;
                    if (row[i]["TotalQuantity"] != null)
                        SLTong = (row[i]["TotalQuantity"].ToString().Trim() != "") ? SLTong + Convert.ToInt32(row[i]["TotalQuantity"]) : SLTong;
                    if (row[i]["Differen"] != null)
                        SLLech = (row[i]["Differen"].ToString().Trim() != "") ? SLLech + Convert.ToInt32(row[i]["Differen"]) : SLLech;
                }
                // gán lại giá trị
                for (int i = 0; i < rowTotal.Length; i++)
                {
                    rowTotal[i]["QuantityIvent"] = SLPac;
                    rowTotal[i]["QuantityOdd"] = SLLe;
                    rowTotal[i]["TotalQuantity"] = SLTong;
                    rowTotal[i]["Differen"] = SLLech;
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Set trạng thái menu
        /// </summary>
        private void SetMenu(bool excel,bool save)
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool[] active = { false, save, false, false, false, false, excel, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
                //lvwEmployeeSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Export dữ liệu kiểm kê ra file excel
        /// </summary>
        private void ExportExcel()
        {
            try
            {
                if (dgvProduct.Rows.Count > 0)
                {
                    string fileName = TITLE_EXPORT + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")+".xls";

                    Export ex = new Export();
                    ex.InfoCompany = true;
                    ex.InfoStore = true;
                    ex.StrTitle = TITLE_EXPORT.ToUpper();
                    ex.ExportGridReportToExcel(dgvProduct, fileName,3);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu chuỗi cửa hàng
        /// </summary>
        private void LoadTreListStore()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE",STO_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_LIST_STORE_CODE);
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.StoreCode)
                            childNode.Checked = true;
                    }                    
                    this.trvStoreList.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadMasterCode': " + ex.Message);
            }
            //node goc dau tien
            
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu vị trí
        /// </summary>
        private void LoadTrePlace()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", LOC_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_PALCE_CODE);
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.BusinessTypeCode)
                            childNode.Checked = true;
                    }
                    this.trvPlace.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadMasterCode': " + ex.Message);
            }
            //node goc dau tien

        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu cửa hàng
        /// </summary>p
        private void LoadTreShop()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber) };
                DataTable dtMaster = sqlDac.GetDataTable("GetTreeDeptCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode[] childNode = new TreeNode[dtMaster.Rows.Count];
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        childNode[i] = new TreeNode(dtMaster.Rows[i]["name"].ToString());                        
                    }                     
                    for (int i = 0; i < childNode.Length-1; i++)
                    {
                        childNode[i].Nodes.Add(childNode[i + 1]);
                        if (i >= childNode.Length - 2)
                        {
                            childNode[i].Checked = true;
                            childNode[i + 1].Checked = true;
                        }
                    }                    
                    this.trvShop.Nodes.Add(childNode[0]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadMasterCode': " + ex.Message);
            }
            //node goc dau tien

        }
        
        #endregion

        #region Event

        #region Event process in form
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: form load.
        /// </summary>
        private void frmKiemKeHang_Load(object sender, EventArgs e)
        {
            try
            {
                SetMenu(false,false);
                LoadControl();
                LoadTreListStore();
                LoadTrePlace();
                LoadTreShop();
                trvStoreList.ExpandAll();
                trvShop.ExpandAll();
                trvPlace.ExpandAll();
                dtpDateTo.Value = sqlDac.GetDateTimeServer();
                dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Tìm kiếm sản phẩm
        /// </summary>
        private void txtPro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    CheckInventoryEntities inventEn = CheckInventory.ShowProductSearch(txtPro.Text.Trim(), translate);
                    if (inventEn != null)
                    {
                        int check = listPro.FindIndex(s => s == inventEn.ProductID);
                        if (check == -1)
                        {
                            listPro.Add(inventEn.ProductID);
                            string listCode = (txtProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                            txtProduct.Text = txtProduct.Text.Trim() + listCode;
                        }
                        txtPro.Text = "";
                        txtPro.Focus();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: mở giao diện tìm kiếm sản phẩm nâng cao
        /// </summary>
        private void btnBrowe_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn = SOManagement.ShowChoseProduct(translate);
                txtProduct.Text = soEn.ListProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Xóa toàn bộ list sản phẩm đã chọn
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                txtProduct.Text = "";
                listPro.Clear();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Tìm kiếm dữ liệu tồn kho.
        /// </summary>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
                SearchPro(txtProduct.Text.Trim());
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Sự kiện nhập số liệu kiểm kê nếu thay đổi focus vào 1 cell khác.
        /// </summary>
        private void dgvProduct_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChangeQuantiy(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Sự kiện nhập số liệu kiểm kê nếu thay đổi focus vào 1 row khác
        /// </summary>
        private void dgvProduct_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChangeQuantiy(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở giao diện xuất điều chỉnh.
        /// </summary>
        private void btnExportDC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateTo.Value.Date >= sqlDac.GetDateTimeServer().Date)
                {
                    if (all)
                    {
                        OpenGoodDelivery();
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfUtilities.GoodInventory3, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.rsfUtilities.GoodInventory4, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Xuất dữ liệu kiểm kê ra excel
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Lưu dữ liệu kiểm kê.
        /// </summary>
        private void frmGoodsInventory_evSave(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Rows.Count > 0)
                {
                    DialogResult re = MessageBox.Show(Properties.rsfUtilities.GoodInventory1, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (re == DialogResult.Yes)
                    {
                        if (CheckKK())
                        {
                            DialogResult re1 = MessageBox.Show(Properties.rsfUtilities.GoodInventory6, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (re1 == DialogResult.Yes)
                            {
                                DeleteKKCurrent();
                                SaveKK();
                            }
                        }
                        else
                        {
                            SaveKK();
                        }
                        
                        MessageBox.Show(Properties.rsfUtilities.GoodInventory, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Order1, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Xuất dữ liệu kiểm kê ra excel
        /// </summary>
        private void frmGoodsInventory_evExportExcel(object sender, EventArgs e)
        {
            try
            {
                ExportExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }        
        
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Xử lý màu nền các cell trong gridview thông tin kiểm kê
        /// </summary>
        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // 
                all = true;
                //
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvProduct.Font, FontStyle.Bold);

                    int i = 0;
                    bool input = false;
                    bool ouput = false;
                    //bool all = true;
                    foreach (DataGridViewRow r in dgvProduct.Rows)
                    {
                        string name = r.Cells[3].Value.ToString().Trim();
                        i++;
                        if (i % 2 == 0 && name != "Tổng cộng:")
                        {
                            r.DefaultCellStyle = bgcolor;
                            // sau khi set màu cả dòng . set riêng màu cột số lượng chênh lệch
                            r.Cells[10].Style.BackColor = Color.FromArgb(255, 224, 192);
                        }

                        if (r.Cells[10].Value != null && r.Cells[10].Value.ToString() != "")
                        {
                            int odd = 0;
                            int pac = 0;
                            int check = Convert.ToInt32(r.Cells[10].Value);
                            if(r.Cells[8].Value != null && r.Cells[8].Value.ToString().Trim() !="")
                                odd = 1;
                            if(r.Cells[7].Value != null && r.Cells[7].Value.ToString().Trim() !="")
                                pac = 1;
                            // kiểm tra nếu có 1 dòng chưa nhập kiểm kê set biến all = false
                            //20/02 fix lại ko bắt buộc nhập hết các sản phẩm kiểm kê set all = true
                            if (odd == 0 && pac == 0)
                                all = true;
                            if (check > 0 && name != "Tổng cộng:")// chênh lệch > 0 đổi màu vàng
                            {
                                r.Cells[10].Style.BackColor = Color.FromArgb(255, 255, 0);
                                input = true;
                            }
                            else if (check < 0 && name != "Tổng cộng:")// kiểm tra có sản phẩm nào chênh lệch < 0 đổi màu xanh
                            {
                                if (r.Cells[9].Value != null && r.Cells[9].Value.ToString().Trim() != "")
                                    r.Cells[10].Style.BackColor = Color.FromArgb(158, 239, 109);
                                ouput = true;
                            }
                            else
                            {
                                r.Cells[10].Style.BackColor = Color.FromArgb(255, 224, 192);
                            }
                        }
                        // nếu là dòng tổng cộng thì in đậm
                        if (name == "Tổng cộng:")
                        {
                            r.DefaultCellStyle = bgcolor1;
                        }
                    }
                    // enable button nhập xuất điều chỉnh
                    //if (dtpDateTo.Value.Date >= sqlDac.GetDateTimeServer().Date)
                    //{
                    //    if (all)
                    //    {
                            btnExportDC.Enabled = ouput;
                            btnImportDC.Enabled = input;
                    //    }
                    //    else
                    //    {
                    //        btnExportDC.Enabled = false;
                    //        btnImportDC.Enabled = false;
                    //    }
                    //}
                    // nếu số dòng lớn hơn 0 enable dòng xuất dữ liệu excel
                    bool excel = (dgvProduct.Rows.Count > 0);
                    btnExportExcel.Enabled = excel;
                    SetMenu(excel, excel);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Tạo STT cho datagirdview
        /// </summary>
        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở giao diện nhập điều chỉnh
        /// </summary>
        private void btnImportDC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateTo.Value.Date >= sqlDac.GetDateTimeServer().Date)
                {
                    if (all)
                    {
                        OpenGoodReceipt();
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfUtilities.GoodInventory2, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.rsfUtilities.GoodInventory5, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Tìm kiếm dữ liệu tồn kho
        /// </summary>
        private void frmGoodsInventory_evSearch(object sender, EventArgs e)
        {
            try
            {
                SearchPro(txtProduct.Text.Trim());
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Tạo sự kiện Keypress cho datagirdview . 
        /// </summary>
        private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvProductCell_KeyPress);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Chặn các ký tự không hợp lệ nhập vào cell kiểm kê. 
        /// </summary>
        private void dgvProductCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvProduct.CurrentCell.ColumnIndex == 7 || dgvProduct.CurrentCell.ColumnIndex == 8)
                {
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Hide or show panel left
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở panel giao diện thông tin cửa hàng
        /// </summary>
        private void btnD_Click(object sender, EventArgs e)
        {            
            try
            {
                ResizeLeft();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở panel thông tin cửa hàng
        /// </summary>
        private void panLeft_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeLeft();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng panel thông tin cửa hàng
        /// </summary>
        private void btnLeftLage_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeLeft();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng panel thông tin cửa hàng
        /// </summary>
        private void pnlTopStore_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeLeft();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region hide or show child panel in panel left
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel chuỗi cửa hàng
        /// </summary>
        private void btnStorelist_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeStoreList();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel chuỗi cửa hàng
        /// </summary>
        private void pnlStoreList_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeStoreList();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel vị trí
        /// </summary>
        private void btnPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel vị trí
        /// </summary>
        private void pnlPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel cửa hàng
        /// </summary>
        private void pnlShop_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng/mở panel cửa hàng
        /// </summary>
        private void btnShop_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }


        


        #endregion

        private void frmGoodsInventory_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }

        
      
        #endregion

        private void btnRightLage_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeRight();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeRight();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DateCreate", dtpDate.Value) };
                dgvlistInven.AutoGenerateColumns = false;
                dgvlistInven.DataSource = sqlDac.GetDataTable("Table_KIEMKE_Search", para);

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvlistInven_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (dgvlistInven.CurrentRow.Cells[0].Value != null && dgvlistInven.CurrentRow.Cells[0].Value.ToString() != "")
                    {
                        string code = dgvlistInven.CurrentRow.Cells[0].Value.ToString();
                        SqlParameter[] para = new SqlParameter[3];
                        para[0] = posdb_vnmSqlDAC.newInParam("@MAKK", code);
                        para[1] = posdb_vnmSqlDAC.newInParam("@CreateTo", Conversion.LastDayTime(sqlDac.GetDateTimeServer()));
                        para[2] = posdb_vnmSqlDAC.newInParam("@LIST_STORE_CODE", UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode);
                        dgvProduct.AutoGenerateColumns = false;
                        dgvProduct.DataSource = sqlDac.GetDataTable("Table_KIEMKE_FindByMaKK", para);
                    }
                }
                //
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void pnlRight_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeRight();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    }
}

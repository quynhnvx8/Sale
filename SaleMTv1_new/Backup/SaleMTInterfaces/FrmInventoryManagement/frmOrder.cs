using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTBusiness;
using System.Data.SqlClient;
using SaleMTCommon;
using SaleMTInterfaces;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTBusiness.InventoryManagement;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Net.NetworkInformation;
using SaleMTSync;

/// <summary>
/// Người tạo Luannv – 20/09/2013 : Form đặt hàng.
/// </summary>

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmOrder : TabForm
    {
        #region Declaration
        private const string RPT_PATH = "\\Reports\\rptOrderProduct.rpt";
        private const string IMPORT_PATH = "D:\\ftp_client\\Import";
        private const string EXPORT_PATH = "D:\\ftp_client\\Export";
        private MenuProcess mnuProcess = new MenuProcess();
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool[] status;
        private bool scan = true;
        //private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;


        #endregion

        #region Contructors
        public frmOrder(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.btnSearch.Text = translate["frmOrder.btnSearch.Text"];
            this.btnSendOrder.Text = translate["frmOrder.btnSendOrder.Text"];
            this.gbxDanhSach.Text = translate["frmOrder.gbxDanhSach.Text"];
            this.columnHeader1.Text = translate["frmOrder.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmOrder.columnHeader2.Text"];
            this.btnSoManagement.Text = translate["frmOrder.btnSoManagement.Text"];
            this.btnCreateAutoOrder.Text = translate["frmOrder.btnCreateAutoOrder.Text"];
            this.gbxSanPham.Text = translate["frmOrder.gbxSanPham.Text"];
            this.label18.Text = translate["frmOrder.label18.Text"];
            this.clnProductId.HeaderText = translate["frmOrder.clnProductId.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmOrder.clnQuantity.HeaderText"];
            this.clnProductPrice.HeaderText = translate["frmOrder.clnProductPrice.HeaderText"];
            this.clnProductName.HeaderText = translate["frmOrder.clnProductName.HeaderText"];
            this.clnUnit.HeaderText = translate["frmOrder.clnUnit.HeaderText"];
            this.clnTotalMoney.HeaderText = translate["frmOrder.clnTotalMoney.HeaderText"];
            this.Column1.HeaderText = translate["frmOrder.Column1.HeaderText"];
            this.label17.Text = translate["frmOrder.label17.Text"];
            this.label16.Text = translate["frmOrder.label16.Text"];
            this.label3.Text = translate["frmOrder.label3.Text"];
            this.label2.Text = translate["frmOrder.label2.Text"];
            this.label1.Text = translate["frmOrder.label1.Text"];
            this.gbxTTDatHang.Text = translate["frmOrder.gbxTTDatHang.Text"];
            this.label11.Text = translate["frmOrder.label11.Text"];
            this.label9.Text = translate["frmOrder.label9.Text"];
            this.txtTTDatHang.Text = translate["frmOrder.txtTTDatHang.Text"];
            this.Text = translate["frmOrder.Text"];
        }	

        #endregion

        #region Method/Function
        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Tìm kiếm đơn đặt hàng.
        /// </summary>
        protected void LoadOrder()
        {
            try
            {
                OrderEntities orderEn = new OrderEntities();
                orderEn.OrderCode = txtOrderCodeSearch.Text.Trim();
                orderEn.DateFrom = (dtpDateFrom.Checked) ? Conversion.FirstDayTime(dtpDateFrom.Value) : Convert.ToDateTime("1900/01/01");
                orderEn.DateTo = (dtpDateTo.Checked) ? Conversion.LastDayTime(dtpDateTo.Value) : Convert.ToDateTime("9999/01/01");

                DataTable dataTable = Order.SearchOrder(orderEn);
                if (dataTable.Rows.Count > 0)
                {
                    lvwOrders.Items.Clear();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        lvwOrders.Items.Add(dataTable.Rows[i]["ORDER_DATE"].ToString());
                        lvwOrders.Items[i].SubItems.Add(dataTable.Rows[i]["ORDER_CODE"].ToString());
                        lvwOrders.Items[i].SubItems.Add(dataTable.Rows[i]["REMARKS"].ToString());
                        if (i % 2 == 0)
                        {
                            lvwOrders.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                        }
                    }
                    if (lvwOrders.Items.Count > 0)
                    {
                        lvwOrders.Items[0].Selected = true;
                        lvwOrders.Focus();
                    }
                }
                else
                {
                    lvwOrders.Items.Clear();
                    MessageBox.Show(Properties.rsfSales.NotItem, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadOrder': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Load chi tiết sản phẩm theo mã đơn đặt hàng.
        /// </summary>
        protected void LoadOrderDetails()
        {
            try
            {
                ListView.SelectedListViewItemCollection item = lvwOrders.SelectedItems;
                if (item.Count > 0)
                {
                    OrderEntities orderEn = new OrderEntities();

                    txtOrderCode.Text = item[0].SubItems[1].Text;
                    dtpOrderDate.Value = Conversion.stringToDateTime(item[0].Text);
                    rtfRemarks.Text = item[0].SubItems[2].Text;
                    orderEn.OrderCode = item[0].SubItems[1].Text.Trim();

                    dgvProducts.AutoGenerateColumns = false;
                    dgvProducts.DataSource = Order.SearchOrderDetails(orderEn);
                }
                else
                {
                    dgvProducts.DataSource = null;
                }
                CalculatorToTal();
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadOrderDetails': " + ex.Message);
            }
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Thiết lập lại giá trị rỗng cho các Control.
        /// </summary>
        protected void ResetControls()
        {
            try
            {
                txtOrderCode.Text = "";
                dtpOrderDate.Value = sqlDac.GetDateTimeServer();
                rtfRemarks.Text = "";
                if (dgvProducts.Rows.Count > 1)
                {
                    for (int i = dgvProducts.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvProducts.Rows[i].IsNewRow)
                        {
                            dgvProducts.Rows.RemoveAt(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetControls': " + ex.Message);
            }
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Set khóa các Control.
        /// </summary>
        protected void EnableControls()
        {
            try
            {
                txtOrderCode.Enabled = false;
                dtpOrderDate.Enabled = false;
                rtfRemarks.Enabled = false;
                btnCreateAutoOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'EnableControls': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : In hóa đơn đặt hàng . 
        /// </summary>
        private void Print()
        {
            try
            {
                OrderEntities orderEn = new OrderEntities();
                ListView.SelectedListViewItemCollection item = lvwOrders.SelectedItems;
                if (item.Count > 0)
                {
                    orderEn.OrderCode = item[0].SubItems[1].Text.Trim();
                    DataSet dsOrderBill = Order.GetDatasetBill(orderEn);
                    dsOrderBill.DataSetName = "dsReport";
                    PrintBill.frmReportView frm = new PrintBill.frmReportView();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.path = RPT_PATH;
                    frm.ds = dsOrderBill;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Print': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Tính toán tổng số tiền.
        /// </summary>
        private void CalculatorToTal()
        {

            try
            {
                if (dgvProducts.Rows.Count > 0)
                {
                    double amount = 0;
                    double quantity = 0;
                    for (int i = 0; i < dgvProducts.Rows.Count; i++)
                    {
                        quantity = quantity + Convert.ToDouble(Conversion.Replaces(dgvProducts.Rows[i].Cells["clnQuantity"].Value.ToString()));
                        amount = amount + Convert.ToDouble(Conversion.Replaces(dgvProducts.Rows[i].Cells["clnTotalMoney"].Value.ToString()));
                    }
                    lblCount.Text = dgvProducts.Rows.Count.ToString();
                    lblQuantity.Text = Conversion.GetCurrency(quantity.ToString());
                    lblTotalMoney.Text = Conversion.GetCurrency(amount.ToString());
                    // Thay đổi lại màu nền cho chính xác                    
                    DataGridViewCellStyle bgcolor = dgvProducts.DefaultCellStyle.Clone();
                    DataGridViewCellStyle bgcolorWhite = dgvProducts.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    bgcolorWhite.BackColor = Color.FromArgb(255, 255, 255);
                    int index = 0;
                    foreach (DataGridViewRow r in dgvProducts.Rows)
                    {
                        index++;
                        r.DefaultCellStyle = (index % 2 == 0) ? bgcolor : bgcolorWhite;
                    }

                }
                else
                {
                    lblCount.Text = "0";
                    lblQuantity.Text = "0";
                    lblTotalMoney.Text = "0";
                }

            }
            catch (Exception ex)
            {
                log.Error(" Error 'CalculatorToTal': " + ex.Message);
            }
        }
        private void ImportXML()
        {
            try
            {
                scan = true;
                while (scan)
                {
                    string[] filePath = GetPath();

                    List<PO_FORECAST> listForeCast = new List<PO_FORECAST>();
                    List<PO_DVKH> listDVKH = new List<PO_DVKH>();
                    List<PO_SAFETY_STOCK> listSafety = new List<PO_SAFETY_STOCK>();
                    List<PO_SAFETY_STOCK_DETAIL> listSafetyDetail = new List<PO_SAFETY_STOCK_DETAIL>();
                    List<PO_SALES_DAY> listSalesDay = new List<PO_SALES_DAY>();

                    DataSet dsForecast = new DataSet();
                    if (filePath[0] != null)
                        dsForecast.ReadXml(filePath[0]);
                    DataSet dsSO = new DataSet();
                    if (filePath[1] != null)
                        dsSO.ReadXml(filePath[1]);
                    DataSet dsPO = new DataSet();
                    if (filePath[2] != null)
                        dsPO.ReadXml(filePath[2]);
                    DataSet dsSF = new DataSet();
                    if (filePath[3] != null)
                        dsSF.ReadXml(filePath[3]);
                    DataSet dsSFD = new DataSet();
                    if (filePath[4] != null)
                        dsSFD.ReadXml(filePath[4]);
                    DataSet dsSD = new DataSet();
                    if (filePath[5] != null)
                        dsSD.ReadXml(filePath[5]);

                    if (dsForecast.Tables.Count > 0)
                    {
                        DataTable dt = dsForecast.Tables[0];
                        string listProduct = "";
                        string listYear = "";
                        string listMonth = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["SITE_CODE"].ToString().Equals(UserImformation.DeptCode))
                            {
                                string[] split = Regex.Split(row["PERIOD"].ToString(), "-");
                                listProduct += listProduct == "" ? row["ITEM_NO"].ToString() : "," + row["ITEM_NO"].ToString();
                                listYear += listYear == "" ? split[0] : "," + split[0];
                                listMonth += listMonth == "" ? split[1] : "," + split[1];
                                PO_FORECAST poForeCast = new PO_FORECAST();
                                poForeCast.PRODUCT_ID = row["ITEM_NO"].ToString();
                                poForeCast.QUANTITY = int.Parse(row["QTY"].ToString());
                                poForeCast.STORE_CODE = row["SITE_CODE"].ToString();
                                poForeCast.YEAR = int.Parse(split[0]);
                                poForeCast.MONTH = int.Parse(split[1]);
                                listForeCast.Add(poForeCast);
                            }
                        }
                        SqlParameter[] sqlPara = new SqlParameter[4];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", SqlDbType.VarChar, UserImformation.DeptCode);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ListYear", SqlDbType.VarChar, listYear);
                        sqlPara[2] = posdb_vnmSqlDAC.newInParam("@ListMonth", SqlDbType.VarChar, listMonth);
                        sqlPara[3] = posdb_vnmSqlDAC.newInParam("@ListProductId", SqlDbType.VarChar, listProduct);
                        sqlDac.Execute("PO_FORECAST_CheckExistAndDelete", sqlPara);
                    }
                    if (dsSF.Tables.Count > 0)
                    {
                        DataTable dt = dsSF.Tables[0];
                        string listCat = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            listCat += listCat == "" ? row["CAT"].ToString() : "," + row["CAT"].ToString();
                            PO_SAFETY_STOCK poSafety = new PO_SAFETY_STOCK();
                            poSafety.STORE_CODE = row["DISTCODE"].ToString();
                            poSafety.CAT = row["CAT"].ToString();
                            poSafety.MINSF = int.Parse(row["MINSF"].ToString());
                            poSafety.LEAD = int.Parse(row["LEAD"].ToString());
                            poSafety.CALENDAR_D = row["CALENDAR_D"].ToString();
                            poSafety.PERCENTAGE = int.Parse(row["PERCENTAGE"].ToString());
                            listSafety.Add(poSafety);
                        }
                        SqlParameter[] sqlPara = new SqlParameter[2];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", SqlDbType.VarChar, UserImformation.DeptCode);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ListCat", SqlDbType.VarChar, listCat);
                        sqlDac.Execute("PO_SAFETY_STOCK_CheckExistAndDelete", sqlPara);
                    }
                    if (dsSFD.Tables.Count > 0)
                    {
                        DataTable dt = dsSFD.Tables[0];
                        string listProduct = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            listProduct += listProduct == "" ? row["SKU"].ToString() : "," + row["SKU"].ToString();
                            PO_SAFETY_STOCK_DETAIL poSafetyDetail = new PO_SAFETY_STOCK_DETAIL();
                            poSafetyDetail.STORE_CODE = row["DISTCODE"].ToString();
                            poSafetyDetail.PRODUCT_ID = row["SKU"].ToString();
                            poSafetyDetail.CAT = row["CAT"].ToString();
                            poSafetyDetail.MINSF = int.Parse(row["MINSF"].ToString());
                            poSafetyDetail.LEAD = int.Parse(row["LEAD"].ToString());
                            poSafetyDetail.CALENDAR_D = row["CALENDAR_D"].ToString();
                            poSafetyDetail.PERCENTAGE = int.Parse(row["PERCENTAGE"].ToString());
                            listSafetyDetail.Add(poSafetyDetail);
                        }
                        SqlParameter[] sqlPara = new SqlParameter[2];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", SqlDbType.VarChar, UserImformation.DeptCode);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ListProduct", SqlDbType.VarChar, listProduct);
                        sqlDac.Execute("PO_SAFETY_STOCK_DETAIL_CheckExistAndDelete", sqlPara);
                    }

                    if (dsSD.Tables.Count > 0)
                    {
                        DataTable dt = dsSD.Tables[0];
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 1; i <= 12; i++)
                            {
                                PO_SALES_DAY poSalesDay = new PO_SALES_DAY();
                                poSalesDay.STORE_CODE = row["DISTCODE"].ToString();
                                poSalesDay.YEAR = sqlDac.GetDateTimeServer().Year;
                                string month = i < 10 ? "T0" + i : "T" + i;
                                poSalesDay.MONTH = i;
                                poSalesDay.SALES_DAY = int.Parse(row[month].ToString());
                                listSalesDay.Add(poSalesDay);

                                SqlParameter[] sqlPara = new SqlParameter[3];
                                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@StoreCode", SqlDbType.VarChar, UserImformation.DeptCode);
                                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Year", SqlDbType.Int, sqlDac.GetDateTimeServer().Year);
                                sqlPara[2] = posdb_vnmSqlDAC.newInParam("@Month", SqlDbType.Int, i);
                                sqlDac.Execute("PO_SALES_DAY_CheckExistAndDelete", sqlPara);
                            }
                        }
                    }

                    if (dsSO.Tables.Count > 0)
                    {
                        DataTable dt = dsSO.Tables[0];
                        string listProduct = "";
                        string listSO = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            listProduct += listProduct == "" ? row["ItemCode"].ToString() : "," + row["ItemCode"].ToString();
                            listSO += listSO == "" ? row["SaleOrderNumber"].ToString() : "," + row["SaleOrderNumber"].ToString();
                            PO_DVKH poDVKH = new PO_DVKH();
                            poDVKH.DistCode = row["DistCode"].ToString();
                            poDVKH.CreateBy = UserImformation.UserName;
                            poDVKH.CreateDate = sqlDac.GetDateTimeServer();
                            poDVKH.DataType = "SO";
                            poDVKH.IsActive = false;
                            poDVKH.ItemCode = row["ItemCode"].ToString();
                            poDVKH.ItemDescr = row["ItemDescr"].ToString();
                            poDVKH.LineTotal = float.Parse(row["LineTotal"].ToString());
                            poDVKH.OrderDate = DateTime.Parse("1753-01-01 00:00:00.000");
                            poDVKH.POCONumber = row["POCONumber"].ToString();
                            poDVKH.PONumber = row["PONumber"].ToString();
                            poDVKH.Price = decimal.Parse(row["Price"].ToString());
                            poDVKH.Quantity = float.Parse(row["Quantity"].ToString());
                            poDVKH.QuantitySuspend = null;
                            poDVKH.SaleOrderNumber = row["SaleOrderNumber"].ToString();
                            poDVKH.SiteID = row["SiteID"].ToString();
                            poDVKH.SoNoiBo = null;
                            poDVKH.UOM = row["UOM"].ToString();
                            listDVKH.Add(poDVKH);
                        }
                        SqlParameter[] sqlPara = new SqlParameter[3];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@ListSaleOrderNumber", SqlDbType.VarChar, listSO);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ListProductId", SqlDbType.VarChar, listProduct);
                        sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DateType", SqlDbType.VarChar, "SO");
                        sqlDac.Execute("PO_DVKH_CheckExistAndDelete", sqlPara);
                    }
                    if (dsPO.Tables.Count >= 4)
                    {
                        DataTable dtHeader = dsPO.Tables[1];
                        DataTable dtDetail = dsPO.Tables[3];
                        string listProduct = "";
                        string listSO = "";
                        foreach (DataRow rowHeader in dtHeader.Rows)
                        {
                            foreach (DataRow rowDetail in dtDetail.Rows)
                            {
                                if (rowHeader["POCONumber"].ToString().Equals(rowDetail["POCONumber"].ToString()))
                                {
                                    string[] split = Regex.Split(rowDetail["POCONumber"].ToString(), "_");
                                    listProduct += listProduct == "" ? rowDetail["ItemCode"].ToString() : "," + rowDetail["ItemCode"].ToString();
                                    listSO += listSO == "" ? rowDetail["SaleOrderNumber"].ToString() : "," + rowDetail["SaleOrderNumber"].ToString();
                                    PO_DVKH poDVKH = new PO_DVKH();
                                    poDVKH.DistCode = rowDetail["DistCode"].ToString();
                                    poDVKH.CreateBy = UserImformation.UserName;
                                    poDVKH.CreateDate = sqlDac.GetDateTimeServer();
                                    poDVKH.DataType = "PO";
                                    poDVKH.IsActive = true;
                                    poDVKH.ItemCode = rowDetail["ItemCode"].ToString();
                                    poDVKH.ItemDescr = rowDetail["ItemDescr"].ToString();
                                    poDVKH.LineTotal = float.Parse(rowDetail["LineTotal"].ToString());
                                    poDVKH.OrderDate = DateTime.Parse(rowHeader["OrderDate"].ToString());
                                    poDVKH.POCONumber = split[0];
                                    poDVKH.PONumber = rowDetail["PONumber"].ToString();
                                    poDVKH.Price = decimal.Parse(rowDetail["Price"].ToString());
                                    poDVKH.Quantity = float.Parse(rowDetail["Quantity"].ToString());
                                    poDVKH.QuantitySuspend = null;
                                    poDVKH.SaleOrderNumber = rowDetail["SaleOrderNumber"].ToString();
                                    poDVKH.SiteID = rowDetail["SiteID"].ToString();
                                    poDVKH.SoNoiBo = split[1];
                                    poDVKH.UOM = rowDetail["UOM"].ToString();
                                    listDVKH.Add(poDVKH);
                                }
                            }
                        }
                        SqlParameter[] sqlPara = new SqlParameter[3];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@ListSaleOrderNumber", SqlDbType.VarChar, listSO);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ListProductId", SqlDbType.VarChar, listProduct);
                        sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DateType", SqlDbType.VarChar, "PO");
                        sqlDac.Execute("PO_DVKH_CheckExistAndDelete", sqlPara);
                    }
                    //
                    foreach (PO_FORECAST poForeCast in listForeCast)
                        poForeCast.Save(true);
                    foreach (PO_DVKH poDVKH in listDVKH)
                        poDVKH.Save(true);
                    foreach (PO_SAFETY_STOCK poSafety in listSafety)
                        poSafety.Save(true);
                    foreach (PO_SAFETY_STOCK_DETAIL poSafetyDetail in listSafetyDetail)
                        poSafetyDetail.Save(true);
                    foreach (PO_SALES_DAY poSalesDay in listSalesDay)
                        poSalesDay.Save(true);
                    foreach (string file in filePath)
                    {
                        if (file != null && file != "")
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            File.Delete(file);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'ImportXML' : " + ex.Message);
            }
        }
        private string[] GetPath()
        {
            string[] path = new string[6];
            try
            {
                string[] xmlFiles = System.IO.Directory.GetFiles(UserImformation.ClientImportPath, "*.xml");
                foreach (string file in xmlFiles)
                {
                    path[0] = file.Contains(UserImformation.DeptCode + "_Imp_Forecast_") ? file : path[0];
                    path[1] = file.Contains(UserImformation.DeptCode + "_Imp_SO_") ? file : path[1];
                    path[2] = file.Contains(UserImformation.DeptCode + "_Imp_PO_") ? file : path[2];
                    path[3] = file.Contains(UserImformation.DeptCode + "_Imp_Safetystock_") && !file.Contains("_Imp_Safetystock_details_") ? file : path[3];
                    path[4] = file.Contains(UserImformation.DeptCode + "_Imp_Safetystock_details_") ? file : path[4];
                    path[5] = file.Contains(UserImformation.DeptCode + "_Imp_SalesDay_") ? file : path[5];                    
                }
                if ((path[0] == null || path[0] == "") && (path[1] == null || path[1] == "") && (path[2] == null || path[2] == "") &&
                    (path[3] == null || path[3] == "") && (path[4] == null || path[4] == "") && (path[5] == null || path[5] == ""))
                {
                    scan = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetPath' : " + ex.Message);
            }
            return path;
        }
        /// <summary>
        /// Người tạo thanhdh – 27/11/2013 : Gửi đơn hàng lên server
        /// </summary>
        private void UploadOrder()
        {
            try
            {
                List<string> listFileName = new List<string>();
                string[] xmlFiles = System.IO.Directory.GetFiles(UserImformation.ClientExportPath, "*.xml");
                foreach (string xml in xmlFiles)
                {
                    if (xml.Contains("Exp_PO_"))
                    {
                        listFileName.Add(Path.GetFileName(xml));
                    }
                }

                SaleMTCommon.frmProcessFTP download = new SaleMTCommon.frmProcessFTP();
                download.ListFiles = listFileName;
                download.IsUpload = true;
                download.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'UploadOrder' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo thanhdh – 29/11/2013 : Xuất đơn hàng ra xml
        /// </summary>
        private void ExportOrder()
        {
            try
            {
                SqlParameter[] sqlPara = new SqlParameter[2];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@TranferShift", UserImformation.ShiftCode);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Date", sqlDac.GetDateTimeServer());
                DataTable dt = sqlDac.GetDataTable("GetXML_OrderProducts_FTP", sqlPara);
                if (dt.Rows.Count > 0)
                {
                    string xml = "<PO> ";
                    double total = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        sqlPara = new SqlParameter[1] { posdb_vnmSqlDAC.newInParam("@ORDER_CODE", row["orderCode"].ToString()) };
                        DataTable dtDetail = sqlDac.GetDataTable("Order_Product_Detail_ListByOrderCode", sqlPara);
                        if (dtDetail.Rows.Count > 0)
                        {
                           string xmlDetail = "";
                           foreach(DataRow rowDetail in dtDetail.Rows)
                           {
                               double linetotal = int.Parse(rowDetail["Quantity"].ToString()) * double.Parse(rowDetail["ProductPrice"].ToString());
                               total += linetotal;
                               xmlDetail += "<Line> <DistCode>" + UserImformation.DeptCode + "</DistCode> <PONumber>" + row["orderCode"].ToString() + "</PONumber> <ItemCode>" + rowDetail["ProductId"].ToString() + "</ItemCode> <ItemDescr>" + rowDetail["ProductName"].ToString() + "</ItemDescr> <UOM>" + rowDetail["Unit"].ToString() + "</UOM> <SiteID>KHOCHINH</SiteID> <Quantity>" + rowDetail["Quantity"].ToString() + "</Quantity> <Price>" + rowDetail["ProductPrice"].ToString() + "</Price> <LineTotal>" + linetotal.ToString() + "</LineTotal> <RequestDate>" + DateTime.Parse(row["orderDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "</RequestDate> <VERSION>1</VERSION> <PLANQTY>0</PLANQTY> </Line> ";
                           }
                           string xmlNewPO = "<NewPO> <POHeader> <DistCode>" + UserImformation.DeptCode + "</DistCode> <PONumber>" + row["orderCode"].ToString() + "</PONumber> <BillToLocation>" + UserImformation.StoreAdress + "</BillToLocation> <ShipToLocation>1</ShipToLocation> <OrderDate>" + DateTime.Parse(row["orderDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "</OrderDate> <Status>O</Status> <Total>" + total.ToString() + "</Total> <PaymentTerm>" + row["Remarks"].ToString() + " </PaymentTerm> </POHeader> <PODetail> " + xmlDetail + "</PODetail> </NewPO> ";
                           xml += xmlNewPO;
                        }                        
                    }
                    xml += "</PO>";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    xmlDoc.Save(UserImformation.ClientExportPath + "Exp_PO_" + UserImformation.DeptCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");

                    string sqlQuery = "insert into SyncTimestamp values (@SyncObjectName,@SyncDateTime)";
                    sqlPara = new SqlParameter[2];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SyncObjectName", "OrderProductsFTP");
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@SyncDateTime", sqlDac.GetDateTimeServer());
                    sqlDac.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportOrder' : " + ex.Message);
            }
        }    
        private void SetControl(bool enable)
        {
            try
            {
                txtOrderCode.Enabled = enable;
                rtfRemarks.Enabled = enable;
                //dtpOrderDate.Value = (enable)? sqlDac.GetDateTimeServer():null;
                btnCreateAutoOrder.Enabled = enable;
                txtOrderCodeSearch.Enabled = !enable;
                dtpDateFrom.Enabled = !enable;
                dtpDateTo.Enabled = !enable;
                btnSearch.Enabled = !enable;
                btnSoManagement.Enabled = !enable;
                btnSendOrder.Enabled = !enable;
                lvwOrders.Enabled = !enable;
                dgvProducts.AllowUserToDeleteRows = enable;

                //bindingcontroldetails
                if (lvwOrders.Items.Count > 0)
                {
                    ListViewItem item = lvwOrders.SelectedItems[0];
                    txtOrderCode.Text = item.SubItems[1].Text;
                    dtpOrderDate.Value = Conversion.stringToDateTime(item.SubItems[0].Text);
                    rtfRemarks.Text = item.SubItems[2].Text;

                    OrderEntities orderEn = new OrderEntities();
                    orderEn.OrderCode = item.SubItems[1].Text.Trim();
                    dgvProducts.AutoGenerateColumns = false;
                    dgvProducts.DataSource = Order.SearchOrderDetails(orderEn);
                }
                else
                {
                    for (int i = dgvProducts.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvProducts.Rows[i].IsNewRow)
                        {
                            dgvProducts.Rows.RemoveAt(i);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Set menu điều khiển.
        /// </summary>
        private void SetMenu(bool add, bool can, bool save)
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool[] active = { add, save, false, can, true, true, false, false, false, false, true, true };
                status = active;
                parMain.ActiveMenu(active);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        
        #endregion

        #region Event
        /// <summary>
        ///Người tạo Luannv – 20/09/2013: load form.
        /// </summary>
        private void frmOrder_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                SetMenu(true, false, false);
                EnableControls();
                ResetControls();
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dgvProducts.AllowUserToDeleteRows = false;
                dtpDateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpOrderDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
                this.clnProductPrice.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.clnTotalMoney.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.clnQuantity.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;

                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmOrderProducts' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkInsert = checkInsert == false? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()):checkInsert;
                        //checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                        checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                    }
                }
                
                
           
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        ///Người tạo Luannv – 20/09/2013: Sự kiện click nút tìm kiếm.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                LoadOrder();
                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Sự kiện thay đổi chọn 1 dòng dữ liệu trên Listview.
        /// </summary>
        private void lvwOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load orders details of a orders.
            try
            {
                ResetControls();
                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/09/2013: Thay đổi màu nền của các dòng dữ liệu trên DataGridView.
        /// </summary>
        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Changed background of datagridview.
            if (e.ListChangedType != ListChangedType.ItemDeleted)
            {
                DataGridViewCellStyle bgcolor = dgvProducts.DefaultCellStyle.Clone();
                bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                int i = 0;
                foreach (DataGridViewRow r in dgvProducts.Rows)
                {
                    i++;
                    if (i % 2 == 0)
                    {
                        r.DefaultCellStyle = bgcolor;
                    }

                    r.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    r.Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    r.Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013: Sự kiện click nút thêm mới .
        /// </summary>
        private void frmOrder_evAddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    txtOrderCode.Focus();
                    SetMenu(false, true, true);
                    txtOrderCode.Enabled = false;
                    rtfRemarks.Enabled = true;
                    //dtpOrderDate.Enabled = true;               
                    btnCreateAutoOrder.Enabled = true;
                    txtOrderCodeSearch.Enabled = false;
                    dtpDateFrom.Enabled = false;
                    dtpDateTo.Enabled = false;
                    btnSearch.Enabled = false;
                    btnSoManagement.Enabled = false;
                    btnSendOrder.Enabled = false;
                    lvwOrders.Enabled = false;
                    dgvProducts.AllowUserToDeleteRows = true;

                    txtOrderCode.Text = "";
                    dtpOrderDate.Value = sqlDac.GetDateTimeServer();
                    rtfRemarks.Text = "";
                    for (int i = dgvProducts.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvProducts.Rows[i].IsNewRow)
                        {
                            dgvProducts.Rows.RemoveAt(i);
                        }
                    }
                    rtfRemarks.Focus();
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013: Sự kiện click nút hủy bỏ thao tác .
        /// </summary>
        private void frmOrder_evCancel(object sender, EventArgs e)
        {
            try
            {
                SetControl(false);
                SetMenu(true, false, false);
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013: Sự kiện click nút lưu dữ liệu .
        /// </summary>
        private void frmOrder_evSave(object sender, EventArgs e)
        {
            try
            {
                if (checkUpdate)
                {
                    if (dgvProducts.Rows.Count > 0)
                    {
                        DialogResult re = MessageBox.Show(Properties.rsfInventoryImport.Order.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (re == DialogResult.Yes)
                        {
                            DataTable dtTemp = ((DataTable)dgvProducts.DataSource).Copy();
                            string sql = "Select distinct ISNULL(RED_INVOICE_CAT,0) CAT from PRODUCTS order by ISNULL(RED_INVOICE_CAT,0)";
                            DataTable dtCAT = sqlDac.InlineSql_Execute(sql, null).Tables[0];
                            for (int c = 0; c < dtCAT.Rows.Count; c++)
                            {
                                string cat = dtCAT.Rows[c]["CAT"].ToString().Trim();


                                DataRow[] drRow = dtTemp.Select("RED_INVOICE_CAT = '" + cat + "'");
                                if (drRow.Length > 0)
                                {
                                    ORDER_PRODUCTS order = new ORDER_PRODUCTS();
                                    string orderCode = sqlDac.GetAutoCode("ORDER_PRODUCTS", "ORDER_CODE", "");
                                    order.ORDER_CODE = orderCode;
                                    order.ORDER_DATE = Convert.ToDateTime(dtpOrderDate.Value);
                                    order.CREATE_DATE = sqlDac.GetDateTimeServer();
                                    order.CREATE_BY = UserImformation.UserName;
                                    order.EVENT_ID = WriteLogEvent.SaveEventStack("ORDER_PRODUCTS", "", 1);
                                    order.REMARKS = rtfRemarks.Text.Trim();
                                    order.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                                    order.UPDATE_BY = "";
                                    order.UPDATE_DATE = null;
                                    order.Save(true);
                                    // Lưu dữ liệu chi tiết đơn hàng
                                    for (int i = 0; i < drRow.Length; i++)
                                    {
                                        ORDER_PRODUCT_DETAIL orderDetail = new ORDER_PRODUCT_DETAIL();
                                        orderDetail.AUTO_ID = Guid.NewGuid();
                                        orderDetail.ORDER_CODE = orderCode;
                                        orderDetail.PRODUCT_ID = drRow[i]["ProductId"].ToString();
                                        orderDetail.PRODUCT_PRICE = (float)Convert.ToDouble(drRow[i]["ProductPrice"].ToString());
                                        orderDetail.QUANTITY = Convert.ToInt32(drRow[i]["Quantity"].ToString());
                                        orderDetail.EVENT_ID = WriteLogEvent.SaveEventStack("ORDER_PRODUCT_DETAIL", "", 1);
                                        orderDetail.Save(true);
                                    }
                                    // sau khi lưu add thêm item vào listview
                                    int index = lvwOrders.Items.Count;
                                    lvwOrders.Items.Add(dtpOrderDate.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                                    lvwOrders.Items[index].SubItems.Add(orderCode);
                                    lvwOrders.Items[index].SubItems.Add(rtfRemarks.Text.Trim());
                                    lvwOrders.Items[index].Selected = true;
                                }
                            }
                            SetControl(false);
                            SetMenu(true, false, false);
                            MessageBox.Show(Properties.rsfInventoryImport.Order2, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfInventoryImport.Order1, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013: Sự kiện click nút xóa dữ liệu .
        /// </summary>
        private void frmOrder_evDelete(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    ListView.SelectedListViewItemCollection item = lvwOrders.SelectedItems;
                    int index = lvwOrders.FocusedItem.Index;
                    if (item.Count > 0)
                    {
                        string orderCode = item[0].SubItems[1].Text.Trim();
                        DialogResult re = MessageBox.Show(Properties.rsfSales.QuestionDelete, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (re == DialogResult.Yes)
                        {
                            SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@ORDER_CODE", orderCode) };
                            sqlDac.Execute("ORDER_PRODUCT_DETAIL_DeleteByOrderCode", para);


                            lvwOrders.Items.Remove(item[0]);
                            MessageBox.Show(Properties.rsfSales.DeleteSuccess.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                 MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            if (lvwOrders.Items.Count > index)
                            {
                                lvwOrders.Items[index].Selected = true;
                            }
                            else
                            {
                                lvwOrders.Items[lvwOrders.Items.Count - 1].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfSales.NotItem.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                 MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 10/10/2013: Sự kiện click in hóa đơn đặt hàng.
        /// </summary>
        private void frmOrder_evPrint(object sender, EventArgs e)
        {
            try
            {
                Print();
                //if (checkPrint)
                //{
                    
                //}
                //else
                //{
                //    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        ///Người tạo Luannv – 20/10/2013: Mở giao diện quản lý SO.
        /// </summary>
        private void btnSoManagement_Click(object sender, EventArgs e)
        {
            try
            {
                frmSOManagement dialogSO = new frmSOManagement(translate);
                dialogSO.StartPosition = FormStartPosition.CenterScreen;
                dialogSO.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Print': " + ex.Message);
            }
        }
        /// <summary>
        ///Người tạo Luannv – 20/10/2013: Tạo PO tự động.
        /// </summary>
        private void btnCreateAutoOrder_Click(object sender, EventArgs e)
        {
            try
            {
                downLoadFtp();
                ImportXML();

                frmDialogReportF1 frmReport = new frmDialogReportF1(translate);
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                if (frmReport.ShowDialog(this) == DialogResult.OK)
                {
                    dgvProducts.AutoGenerateColumns = false;
                    dgvProducts.DataSource = frmReport.DTAutoPO;
                    CalculatorToTal();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void dgvProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                CalculatorToTal();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvProducts_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                CalculatorToTal();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                CalculatorToTal();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                CalculatorToTal();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void downLoadFtp()
        {
            try
            {
                SaleMTCommon.Ftp ftpClient = new SaleMTCommon.Ftp(UserImformation.FtpServer,
                        UserImformation.FtpUser, UserImformation.FtpPassword);
                string[] detailDirectoryListing = ftpClient.directoryListSimple(UserImformation.FtpImportPath);
                int intStoreCodeInd;
                List<string> listFileName = new List<string>();
                for (int i = 0; i < detailDirectoryListing.Count(); i++)
                {
                    if (detailDirectoryListing[i].Contains(UserImformation.DeptCode))
                    {
                        intStoreCodeInd = detailDirectoryListing[i].IndexOf(UserImformation.DeptCode);
                        if (intStoreCodeInd >= 0) {
                            listFileName.Add(detailDirectoryListing[i]);
                        }                        
                    }
                }
                SaleMTCommon.frmProcessFTP download = new SaleMTCommon.frmProcessFTP();
                download.ListFiles = listFileName;
                download.IsUpload = false;
                download.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error downLoadFtp: " + ex.Message);
            }
        }
		private void btnSendOrder_Click(object sender, EventArgs e)
        {
            ExportOrder();
            UploadOrder();
        }

        private void frmOrder_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}

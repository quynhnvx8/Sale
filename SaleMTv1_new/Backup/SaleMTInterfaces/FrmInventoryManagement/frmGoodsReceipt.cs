using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTInterfaces.FrmUtilities;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.InventoryManagement;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmGoodsReceipt : TabForm
    {
        #region Declaration
        private ListViewColumnSorter lvwColumnSorter;
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        bool add = false;
        bool edit = false;
        string sohds;
        string epeventid;
        string edeventid;
        string iteventid;
        DateTime dFrom;
        DateTime dTo;
        string sID;
        int sType;
        bool crossload = false;
        DataTable crossdt = new DataTable();
        private bool[] status;
        //private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        #endregion

        #region Constructor
        public frmGoodsReceipt(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        
            this.evAddNew += new System.EventHandler(this.AddNew);
            this.evSave += new System.EventHandler(this.Save);
            this.evEdit += new System.EventHandler(this.Edit);
            this.evDelete += new System.EventHandler(this.Delete);
            this.evCancel += new System.EventHandler(this.Cancel);
            this.evPrint += new System.EventHandler(this.Print);
            
            cboImportTypeSearch.SelectedIndex = 0;

            lvwColumnSorter = new ListViewColumnSorter();
            lvwImportGoods.ListViewItemSorter = lvwColumnSorter;
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label19.Text = translate["frmGoodsReceipt.label19.Text"];
            this.tabPage1.Text = translate["frmGoodsReceipt.tabPage1.Text"];
            this.label21.Text = translate["frmGoodsReceipt.label21.Text"];
            this.label18.Text = translate["frmGoodsReceipt.label18.Text"];
            this.label9.Text = translate["frmGoodsReceipt.label9.Text"];
            this.label8.Text = translate["frmGoodsReceipt.label8.Text"];
            this.label7.Text = translate["frmGoodsReceipt.label7.Text"];
            this.tabPage2.Text = translate["frmGoodsReceipt.tabPage2.Text"];
            this.label20.Text = translate["frmGoodsReceipt.label20.Text"];
            this.label23.Text = translate["frmGoodsReceipt.label23.Text"];
            this.ProductIdKM.HeaderText = translate["frmGoodsReceipt.ProductIdKM.HeaderText"];
            this.QuantityKM.HeaderText = translate["frmGoodsReceipt.QuantityKM.HeaderText"];
            this.ProductPriceKM.HeaderText = translate["frmGoodsReceipt.ProductPriceKM.HeaderText"];
            this.ProductNameKM.HeaderText = translate["frmGoodsReceipt.ProductNameKM.HeaderText"];
            this.UnitKM.HeaderText = translate["frmGoodsReceipt.UnitKM.HeaderText"];
            this.SaleOrderNumberKM.HeaderText = translate["frmGoodsReceipt.SaleOrderNumberKM.HeaderText"];
            this.VATKM.HeaderText = translate["frmGoodsReceipt.VATKM.HeaderText"];
            this.P_IDKM.HeaderText = translate["frmGoodsReceipt.P_IDKM.HeaderText"];
            this.groupBox4.Text = translate["frmGoodsReceipt.groupBox4.Text"];
            this.columnHeader1.Text = translate["frmGoodsReceipt.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmGoodsReceipt.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmGoodsReceipt.columnHeader3.Text"];
            this.columnHeader4.Text = translate["frmGoodsReceipt.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmGoodsReceipt.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmGoodsReceipt.columnHeader6.Text"];
            this.btnBarcodeScan.Text = translate["frmGoodsReceipt.btnBarcodeScan.Text"];
            this.btnSearch.Text = translate["frmGoodsReceipt.btnSearch.Text"];
            this.gbxDathang.Text = translate["frmGoodsReceipt.gbxDathang.Text"];
            this.chkInsert.Text = translate["frmGoodsReceipt.chkInsert.Text"];
            this.label25.Text = translate["frmGoodsReceipt.label25.Text"];
            this.label17.Text = translate["frmGoodsReceipt.label17.Text"];
            this.label16.Text = translate["frmGoodsReceipt.label16.Text"];
            this.label15.Text = translate["frmGoodsReceipt.label15.Text"];
            this.label14.Text = translate["frmGoodsReceipt.label14.Text"];
            this.label13.Text = translate["frmGoodsReceipt.label13.Text"];
            this.label12.Text = translate["frmGoodsReceipt.label12.Text"];
            this.label11.Text = translate["frmGoodsReceipt.label11.Text"];
            this.label6.Text = translate["frmGoodsReceipt.label6.Text"];
            this.label5.Text = translate["frmGoodsReceipt.label5.Text"];
            this.label4.Text = translate["frmGoodsReceipt.label4.Text"];
            this.label10.Text = translate["frmGoodsReceipt.label10.Text"];
            this.label3.Text = translate["frmGoodsReceipt.label3.Text"];
            this.label2.Text = translate["frmGoodsReceipt.label2.Text"];
            this.label1.Text = translate["frmGoodsReceipt.label1.Text"];
            this.ProductId.HeaderText = translate["frmGoodsReceipt.ProductId.HeaderText"];
            this.Quantity.HeaderText = translate["frmGoodsReceipt.Quantity.HeaderText"];
            this.ProductPrice.HeaderText = translate["frmGoodsReceipt.ProductPrice.HeaderText"];
            this.colProductName.HeaderText = translate["frmGoodsReceipt.colProductName.HeaderText"];
            this.Unit.HeaderText = translate["frmGoodsReceipt.Unit.HeaderText"];
            this.TotalPrice.HeaderText = translate["frmGoodsReceipt.TotalPrice.HeaderText"];
            this.SaleOrderNumber.HeaderText = translate["frmGoodsReceipt.SaleOrderNumber.HeaderText"];
            this.VAT.HeaderText = translate["frmGoodsReceipt.VAT.HeaderText"];
            this.P_ID.HeaderText = translate["frmGoodsReceipt.P_ID.HeaderText"];
            this.Text = translate["frmGoodsReceipt.Text"];
        }

        public frmGoodsReceipt(bool load, DataTable dt, Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            this.evAddNew += new System.EventHandler(this.AddNew);
            this.evSave += new System.EventHandler(this.Save);
            this.evEdit += new System.EventHandler(this.Edit);
            this.evDelete += new System.EventHandler(this.Delete);
            this.evCancel += new System.EventHandler(this.Cancel);
            this.evPrint += new System.EventHandler(this.Print);
            cboImportTypeSearch.SelectedIndex = 0;

            lvwColumnSorter = new ListViewColumnSorter();
            lvwImportGoods.ListViewItemSorter = lvwColumnSorter;

            crossload = load;
            crossdt = dt;
        }

        #endregion

        #region Method
        //Tìm kiếm mã nhập hàng
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm kiếm hóa đơn
        /// </summary>
        protected void SearchInvoiceCode(DateTime dateFrom, DateTime dateTo, string id, int type, bool search)
        {
            try
            {
                string invoiceCode = null;
                if (!string.IsNullOrEmpty(id))
                {
                    invoiceCode = id.Trim();
                    invoiceCode = "%" + invoiceCode + "%";
                }

                string importType = null;
                switch (type)
                {
                    case 1:
                        importType = "IMT.0001";
                        break;
                    case 2:
                        importType = "IMT.0002";
                        break;
                    case 3:
                        importType = "IMT.0003";
                        break;
                }

                DataTable dtTable = Import.GetImportList(importType, dateFrom, dateTo, invoiceCode);
                lvwImportGoods.Items.Clear();
                lvwColumnSorter = new ListViewColumnSorter();
                lvwImportGoods.ListViewItemSorter = lvwColumnSorter;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    double price = double.Parse(dtTable.Rows[i]["DetailPrice"].ToString());
                    DateTime dateImport = dtTable.Rows[i]["DATE_IMPORT"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtTable.Rows[i]["DATE_IMPORT"];
                    
                    ListViewItem lvItem = new ListViewItem(dateImport.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                    lvItem.SubItems.Add(dtTable.Rows[i]["RED_INVOICE_NO"].ToString());
                    lvItem.SubItems.Add(dtTable.Rows[i]["SoNoiBo"].ToString());
                    lvItem.SubItems.Add(dtTable.Rows[i]["DeltailQuantity"].ToString());
                    lvItem.SubItems.Add(price.ToString(AppConfigFileSettings.strOptCurency));
                    lvItem.SubItems.Add(dtTable.Rows[i]["INVOICE_CODE"].ToString());
                    lvwImportGoods.Items.Add(lvItem);

                    //lvwImportGoods.Items.Add(dtTable.Rows[i]["DATE_IMPORT"].ToString());
                    //lvwImportGoods.Items.Add(dateImport.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                    //lvwImportGoods.Items[i].SubItems.Add(dtTable.Rows[i]["RED_INVOICE_NO"].ToString());
                    //lvwImportGoods.Items[i].SubItems.Add(dtTable.Rows[i]["SoNoiBo"].ToString());
                    //lvwImportGoods.Items[i].SubItems.Add(dtTable.Rows[i]["DeltailQuantity"].ToString());
                    //lvwImportGoods.Items[i].SubItems.Add(price.ToString("#,0"));
                    //lvwImportGoods.Items[i].SubItems.Add(dtTable.Rows[i]["INVOICE_CODE"].ToString());
                    if (i % 2 == 0)
                    {
                        lvwImportGoods.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                    else
                    {
                        lvwImportGoods.Items[i].BackColor = Color.White;
                    }
                }
                if (lvwImportGoods.Items.Count > 0)
                {
                    lvwImportGoods.Items[0].Selected = true;
                }
                else
                {
                    txtGoodsCode.Text = "";
                    txtContract.Text = "";
                    txtInternal.Text = "";
                    txtPO.Text = "";
                    txtNote.Text = "";
                    txtContent.Text = "";
                    txtAmount.Text = "0";
                    dtImportDate.Value = SqlDAC.GetDateTimeServer();
                    dtpTime.Value = SqlDAC.GetDateTimeServer();
                    dtpDateCreate.Value = SqlDAC.GetDateTimeServer();
                    DataTable dtProduct = dgvProduct.DataSource as DataTable;
                    DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                    dtProduct.Rows.Clear();
                    dtPromotion.Rows.Clear();
                    LoadTotal(0);
                    edit = false;
                }
                if(dtTable.Rows.Count<=0 && search == true)
                    MessageBox.Show(Properties.rsfImportManagement.Import12.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchInvoiceCode' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin hóa đơn
        /// </summary>
        protected void LoadInvoice(string invoiceCode)
        {
            try
            {
                //Thông tin hóa đơn
                DataTable dt = Import.GetImportInfo(invoiceCode);
                DataRow dtRow = dt.Rows[0];
                switch (dtRow["IMPORT_TYPE"].ToString())
                {
                    case "IMT.0001":
                        cbxImportType.SelectedIndex = 0;
                        break;
                    case "IMT.0002":
                        cbxImportType.SelectedIndex = 1;
                        break;
                    case "IMT.0003":
                        cbxImportType.SelectedIndex = 2;
                        break;
                }
                chkInsert.Visible = dtRow["IMPORT_TYPE"].ToString().Equals("IMT.0001") ? true : false;
                DateTime dateImport = dtRow["DateImport"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtRow["DateImport"];
                DateTime dateOrder = dtRow["OrderDate"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtRow["OrderDate"];

                chkInsert.Checked = (bool)dtRow["IS_IMPORT_DEBT_SALE"];
                dtpDateCreate.Value = dateOrder;
                dtImportDate.Value = dateImport;
                dtpTime.Value = dateImport;

                txtGoodsCode.Text = dtRow["InvoiceCode"].ToString();
                txtContract.Text = dtRow["RedInvoiceNo"].ToString();
                txtInternal.Text = dtRow["SoNoiBo"].ToString();
                txtPO.Text = dtRow["POCONumber"].ToString();
                txtNote.Text = dtRow["RemarksImport"].ToString();
                txtContent.Text = dtRow["GhiChuDC"].ToString();

                sohds = dtRow["RedInvoiceNo"].ToString();
                epeventid = dtRow["EPeventid"].ToString();
                edeventid = dtRow["EDeventid"].ToString();
                iteventid = dtRow["ITeventid"].ToString();

                //txtSoTien.Text = "0";
                float dSoTien = float.Parse(dtRow["SoTienDC"].ToString());
                if (dSoTien <= 0)
                {
                    cboAdjustType.SelectedIndex = 0;
                    txtAmount.Text = (dSoTien * -1).ToString(AppConfigFileSettings.strOptCurency);
                }
                else
                {
                    cboAdjustType.SelectedIndex = 1;
                    txtAmount.Text = dSoTien.ToString(AppConfigFileSettings.strOptCurency);
                }

                //Thông tin sản phẩm
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = Import.GetImportDetail(invoiceCode, "@PRODUCT_PRICE1");

                dgvPromotion.AutoGenerateColumns = false;
                dgvPromotion.DataSource = Import.GetImportDetail(invoiceCode, "@PRODUCT_PRICE0");

                LoadTotal(dSoTien);
                edit = true;

            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Hiển thị tổng số tiền, số lượng,...
        /// </summary>
        private void LoadTotal(float dSoTien)
        {
            try
            {
                int sumCount = 0;
                int sumCountKM = 0;
                int sumSLKM = 0;
                int sumSL = 0;
                double sumTong = 0;
                double sumVAT = 0;
                for (int i = 0; i < dgvProduct.RowCount; i++)
                {
                    if (dgvProduct.Rows[i].Cells[1].Value != DBNull.Value && dgvProduct.Rows[i].Cells[5].Value != DBNull.Value
                        && dgvProduct.Rows[i].Cells[1].Value != null && dgvProduct.Rows[i].Cells[5].Value != null
                        && dgvProduct.Rows[i].Cells[1].Value.ToString() != "" && dgvProduct.Rows[i].Cells[5].Value.ToString() != "")
                    {
                        sumSL += Convert.ToInt32(dgvProduct.Rows[i].Cells[1].Value);
                        sumTong += double.Parse(dgvProduct.Rows[i].Cells[5].Value.ToString());
                    }
                    if (dgvProduct.Rows[i].Cells["colProductName"].Value != null && dgvProduct.Rows[i].Cells["colProductName"].Value.ToString() != "")
                        sumCount += 1;
                }
                for (int i = 0; i < dgvPromotion.RowCount; i++)
                {
                    if (dgvPromotion.Rows[i].Cells[1].Value != DBNull.Value)
                    {
                        sumSLKM += Convert.ToInt32(dgvPromotion.Rows[i].Cells[1].Value);
                    }
                    if (dgvPromotion.Rows[i].Cells["ProductNameKM"].Value != null && dgvPromotion.Rows[i].Cells["ProductNameKM"].Value.ToString() != "")
                        sumCountKM += 1;
                }

                if (dSoTien != 0)
                {
                    sumTong += dSoTien;
                }

                sumVAT = sumTong * (double)1.1;

                //lblTongSLKM.Text = sumSLKM.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec))));
                //lblTongSL.Text = sumSL.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec))));
                lblTongSLKM.Text = sumSLKM.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber);
                lblTongSL.Text = sumSL.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber);
                lblTongTT.Text = sumTong.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                lblTongVAT.Text = sumVAT.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                //lblSoDong.Text = dgvSanPham.RowCount.ToString();
                //foreach (DataGridViewRow row in dgvSanPham.Rows)
                //{
                //    if (row.Cells["ProductName"].Value != null && row.Cells["ProductName"].Value.ToString() != "")
                //        sumCount += 1;
                //}
                //foreach (DataGridViewRow row in dgvKhuyenMai.Rows)
                //{
                //    if (row.Cells["ProductNameKM"].Value != null && row.Cells["ProductNameKM"].Value.ToString() != "")
                //        sumCountKM += 1;
                //}
                lblSoDong.Text = sumCount.ToString("#,0");
                lblSoDongKM.Text = sumCountKM.ToString("#,0");
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTotal' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thêm/sửa hóa đơn
        /// </summary>
        private void EditInvoice(string invoiceCode)
        {
            try
            {
                if (CheckValidate())
                {
                    DateTime importDate = new DateTime(dtImportDate.Value.Year, dtImportDate.Value.Month, dtImportDate.Value.Day, dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second);
                    float tong = 0;
                    float totalprice = 0;
                    int totalquantity = 0;
                    string code = cbxImportType.SelectedIndex == 0 ? "IMP." + UserImformation.DeptCode + "." + SqlDAC.GetDateTimeServer().ToString("yy") + "." : "EDC." + UserImformation.DeptCode + "." + SqlDAC.GetDateTimeServer().ToString("yy") + ".";
                    string invoice = add == false ? invoiceCode : Import.GetAutoCode("EXPORT_PRODUCTS", "INVOICE_CODE", code);

                    //Xóa EXPORT_DETAIL, INVENTORY_TEMP
                    if (add == false)
                    {
                        string proc = "EXPORT_DETAIL_DeleteByInvoiceCode";
                        SqlParameter[] sqlPara = new SqlParameter[1];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, invoice);
                        SqlDAC.Execute(proc, sqlPara);
                        Import.CreateEvent(edeventid, "EXPORT_DETAIL", "", 3);

                        proc = "Inventory_Temp_DeleteByGenerateCode";
                        sqlPara = new SqlParameter[1];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@GenerateCode", SqlDbType.VarChar, invoice);
                        SqlDAC.Execute(proc, sqlPara);
                        Import.CreateEvent(iteventid, "INVENTORY_TEMP", "", 3);
                    }

                    //Tạo mới EXPORT_DETAIL, INVENTORY_TEMP
                    string detailevent = Import.GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy")+"-");
                    Import.CreateEvent(detailevent, "EXPORT_DETAIL", "", 1);
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                            row.Cells["ProductId"].Value.ToString() != "")
                        {                            
                            EXPORT_DETAIL detail = new EXPORT_DETAIL();
                            detail.INVOICE_CODE = invoice;
                            detail.PRODUCT_ID = row.Cells["ProductId"].Value.ToString();
                            detail.PRODUCT_PRICE = float.Parse(row.Cells["ProductPrice"].Value.ToString());
                            detail.QUANTITY = int.Parse(row.Cells["Quantity"].Value.ToString());
                            detail.PRODUCT_PRICE_VAT = float.Parse(row.Cells["VAT"].Value.ToString());
                            detail.PRICE_SALE = float.Parse(row.Cells["VAT"].Value.ToString());
                            detail.SaleOrderNumber = row.Cells["SaleOrderNumber"].Value != null ? row.Cells["SaleOrderNumber"].Value.ToString() : "";
                            detail.ID = System.Guid.NewGuid();
                            detail.DISCOUNT = 0;
                            detail.TOTAL_PRICE = 0;
                            detail.UNIT_PRICE = 0;
                            detail.P_ID = row.Cells["P_ID"].Value != null ? row.Cells["P_ID"].Value.ToString() : "";
                            detail.DISCOUNT_TYPE = null;
                            detail.EVENT_ID = detailevent;
                            tong += (detail.QUANTITY * detail.PRODUCT_PRICE);
                            totalquantity += detail.QUANTITY;
                            totalprice += (detail.QUANTITY * detail.PRODUCT_PRICE);
                            detail.Save(true);
                        }
                    }
                    foreach (DataGridViewRow row in dgvPromotion.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductIdKM"].Value != null &&
                            row.Cells["ProductIdKM"].Value.ToString() != "")
                        {
                            EXPORT_DETAIL detail = new EXPORT_DETAIL();
                            detail.INVOICE_CODE = invoice;
                            detail.PRODUCT_ID = row.Cells["ProductIdKM"].Value.ToString();
                            detail.PRODUCT_PRICE = 0;
                            detail.QUANTITY = int.Parse(row.Cells["QuantityKM"].Value.ToString());
                            detail.PRODUCT_PRICE_VAT = 0;
                            detail.PRICE_SALE = 0;
                            detail.SaleOrderNumber = row.Cells["SaleOrderNumberKM"].Value != null ? row.Cells["SaleOrderNumberKM"].Value.ToString() : "";
                            detail.ID = System.Guid.NewGuid();
                            detail.DISCOUNT = 0;
                            detail.TOTAL_PRICE = 0;
                            detail.UNIT_PRICE = 0;
                            detail.P_ID = row.Cells["P_IDKM"].Value != null ? row.Cells["P_IDKM"].Value.ToString() : "";
                            detail.DISCOUNT_TYPE = null;
                            detail.EVENT_ID = detailevent;
                            totalquantity += detail.QUANTITY;
                            detail.Save(true);
                        }
                    }

                    string tempevent = Import.GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy") + "-");
                    Import.CreateEvent(tempevent, "INVENTORY_TEMP", "", 1);
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                            row.Cells["ProductId"].Value.ToString() != "")
                        {
                            INVENTORY_TEMP temp = new INVENTORY_TEMP();
                            temp.INVENTORY_ID = System.Guid.NewGuid();
                            //temp.CREATED_DATE = SqlDAC.GetDateTimeServer();
                            temp.CREATED_DATE = importDate;
                            temp.PRODUCT_ID = row.Cells["ProductId"].Value.ToString();
                            temp.P_ID = row.Cells["P_ID"].Value != null ? row.Cells["P_ID"].Value.ToString() : "";
                            temp.AMOUNT = int.Parse(row.Cells["Quantity"].Value.ToString());
                            temp.TYPE_CODE = 1;
                            temp.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                            temp.ZONE_CODE = "";
                            temp.GENERATE_CODE = invoice;
                            temp.EVENT_ID = tempevent;
                            temp.WAREHOUSE = null;
                            temp.Save(true);
                        }
                    }
                    foreach (DataGridViewRow row in dgvPromotion.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductIdKM"].Value != null &&
                            row.Cells["ProductIdKM"].Value.ToString() != "")
                        {
                            INVENTORY_TEMP temp = new INVENTORY_TEMP();
                            temp.INVENTORY_ID = System.Guid.NewGuid();
                            //temp.CREATED_DATE = SqlDAC.GetDateTimeServer();
                            temp.CREATED_DATE = importDate;
                            temp.PRODUCT_ID = row.Cells["ProductIdKM"].Value.ToString();
                            temp.P_ID = row.Cells["P_IDKM"].Value != null ? row.Cells["P_IDKM"].Value.ToString() : "";
                            temp.AMOUNT = int.Parse(row.Cells["QuantityKM"].Value.ToString());
                            temp.TYPE_CODE = 1;
                            temp.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                            temp.ZONE_CODE = "";
                            temp.GENERATE_CODE = invoice;
                            temp.EVENT_ID = tempevent;
                            temp.WAREHOUSE = null;
                            temp.Save(true);
                        }
                    }

                    //
                    float tiendc = cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text);
                    //float tongvat = (float)((tong + tiendc) * 1.1);
                    float tongvat = (float)Math.Round((tong + tiendc) * 1.1);
                    string productevent = add == false ? epeventid : Import.GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy") + "-");
                    Import.CreateEvent(productevent, "EXPORT_PRODUCTS", "", add == true ? 1 : 2);

                    //Sửa EXPORT_PRODUCT, CN_HOADON, PO_DVKH
                    EXPORT_PRODUCTS export_product = new EXPORT_PRODUCTS();
                    export_product.INVOICE_CODE = invoice;
                    export_product.DATE_IMPORT = importDate;
                    export_product.DATE_EXPORT = importDate;
                    export_product.REMARKS_IMPORT = txtNote.Text;
                    if (add == true)
                    {
                        export_product.WAREHOUSE_EXPORT = null;
                        export_product.WAREHOUSE_IMPORT = null;
                        export_product.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                        export_product.SUPPLIER = null;
                        export_product.EMPLOYEE_ID = null;
                        export_product.REMARKS_EXPORT = "";
                        export_product.STATUS_IMPORT = true;
                        export_product.USER_IMPORT = UserImformation.UserName;
                        export_product.EXPORT_TYPE = null;
                        export_product.DELIVERY_STATUS = false;
                        export_product.DELIVERY_DATE = Convert.ToDateTime("1753-01-01 00:00:00.000");
                        export_product.INVOICE_IMPORT = null;
                        export_product.ORDER_ID = null;
                        export_product.IS_IMPORT_DEBT = true;
                        export_product.CREATE_DATE = SqlDAC.GetDateTimeServer();
                        export_product.USER_CREATE = null;
                        export_product.DELIVERY_BY = null;
                        export_product.DISCOUNT_TYPE = null;
                        export_product.DISCOUNT = 0;
                        export_product.EMPLOYEE_IMPORT = null;
                        export_product.IS_IMPORT_DC = cbxImportType.SelectedIndex == 0 ? false : true;
                        export_product.STATUS_EXPORT = cbxImportType.SelectedIndex == 0 ? false : true;
                        export_product.EVENT_ID = productevent;
                        export_product.IMPORT_CODE = invoice;
                        export_product.IS_IMPORT_DEBT_SALE = chkInsert.Checked;
                        export_product.GHICHUDC = null;
                        export_product.SoNoiBo = null;
                        export_product.POCONumber = null;
                        export_product.OrderDate = Convert.ToDateTime("1753-01-01 00:00:00.000");
                        export_product.SOTIENDC = 0;
                        export_product.RED_INVOICE_NO = "";
                        switch (cbxImportType.SelectedIndex)
                        {
                            case 0:
                                export_product.IMPORT_TYPE = "IMT.0001";
                                break;
                            case 1:
                                export_product.IMPORT_TYPE = "IMT.0002";
                                break;
                            case 2:
                                export_product.IMPORT_TYPE = "IMT.0003";
                                break;
                        }
                    }
                    else
                    {
                        export_product.STATUS_IMPORT = true;
                        export_product.IS_IMPORT_DC = cbxImportType.SelectedIndex == 0 ? false : true;
                        export_product.STATUS_EXPORT = cbxImportType.SelectedIndex == 0 ? false : true;
                    }

                    if (cbxImportType.SelectedIndex == 0)
                    {
                        export_product.GHICHUDC = txtContent.Text;
                        export_product.SoNoiBo = txtInternal.Text;
                        export_product.POCONumber = txtPO.Text;
                        export_product.OrderDate = dtpDateCreate.Value;
                        export_product.SOTIENDC = tiendc;
                        export_product.RED_INVOICE_NO = txtContract.Text.Trim();

                        string p = add == false ? "CN_HoaDon_UpdateSoHD" : "CN_HoaDon_Create";
                        int a = add == false ? 14 : 13;
                        SqlParameter[] para = new SqlParameter[a];
                        para[0] = posdb_vnmSqlDAC.newInParam("@SoHD", SqlDbType.VarChar, txtContract.Text.Trim());
                        para[1] = posdb_vnmSqlDAC.newInParam("@NgayHD", SqlDbType.DateTime, dtpDateCreate.Value);
                        para[2] = posdb_vnmSqlDAC.newInParam("@NgayTT", SqlDbType.DateTime, dtpDateCreate.Value.AddDays(15));
                        para[3] = posdb_vnmSqlDAC.newInParam("@GhiChuDC", SqlDbType.NVarChar, txtContent.Text);
                        para[4] = posdb_vnmSqlDAC.newInParam("@SoPO", SqlDbType.VarChar, txtPO.Text);
                        para[5] = posdb_vnmSqlDAC.newInParam("@SoNoiBo", SqlDbType.VarChar, txtInternal.Text);
                        para[6] = posdb_vnmSqlDAC.newInParam("@STIENDC", SqlDbType.Float, tiendc);
                        para[7] = posdb_vnmSqlDAC.newInParam("@SoTien", SqlDbType.Float, Math.Round(tongvat));
                        para[8] = posdb_vnmSqlDAC.newInParam("@ConLai", SqlDbType.Float, Math.Round(tongvat));
                        para[9] = posdb_vnmSqlDAC.newInParam("@DaTT", SqlDbType.Float, 0);
                        para[10] = posdb_vnmSqlDAC.newInParam("@Loai", SqlDbType.Bit, 1);
                        para[11] = posdb_vnmSqlDAC.newInParam("@GhiChu", SqlDbType.NVarChar, "");
                        para[12] = posdb_vnmSqlDAC.newInParam("@MaCH", SqlDbType.VarChar, UserImformation.DeptCode);
                        if (add == false)
                            para[13] = posdb_vnmSqlDAC.newInParam("@SoHDS", SqlDbType.VarChar, sohds);
                        SqlDAC.Execute(p, para);

                        if (add == true)
                        {
                            string sqlQuery = "update PO_DVKH set IsActive = 0 where POCONumber = @POCONumber and IsActive =1";
                            SqlParameter[] sqlPara = new SqlParameter[1];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@POCONumber", SqlDbType.VarChar, txtPO.Text);
                            SqlDAC.InlineSql_ExecuteNonQuery(sqlQuery, sqlPara);
                        }
                    }
                    export_product.Save(add);

                    //
                    string msg = add == true ? Properties.rsfImportManagement.Import3.ToString() : Properties.rsfImportManagement.Import4.ToString();
                    MessageBox.Show(msg, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    if (add == true)
                    {
                        ListViewItem lvItem = new ListViewItem(importDate.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                        lvItem.SubItems.Add(txtContract.Text.Trim());
                        lvItem.SubItems.Add(txtInternal.Text.Trim());
                        lvItem.SubItems.Add(totalquantity.ToString());
                        lvItem.SubItems.Add((totalprice * 1.1).ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));                        
                        lvItem.SubItems.Add(invoice);                        
                        int n = lvwImportGoods.Items.Add(lvItem).Index;                        
                        lvwImportGoods.Items[n].Selected = true;
                        for (int i = 0; i < lvwImportGoods.Items.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                lvwImportGoods.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                            }
                            else
                            {
                                lvwImportGoods.Items[i].BackColor = Color.White;
                            }
                        }
                    }
                    add = false;
                    FormSearch();
                    LoadInvoice(invoice);
                    //SearchInvoiceCode(dFrom, dTo, sID, sType, false);
                    this.ActiveControl = txtGoodsCodeSearch;
                    frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                    //main.SaveEvent();
                    main.ActiveMenu(new bool[] { true, false, true, false, true, true, false, false, false, false, true, true });
                    status = new bool[] { true, false, true, false, true, true, false, false, false, false, true, true };
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'EditInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Kiểm tra nhập liệu
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                //foreach (DataGridViewRow row in dgvProduct.Rows)
                //{                    
                //    int i;
                //    float f;
                //    bool resultInt = int.TryParse(row.Cells["Quantity"].Value.ToString(), out i);
                //    bool resultFloat = float.TryParse(row.Cells["ProductPrice"].Value.ToString(), out f);
                //    if (resultInt == false || resultFloat == false)
                //        return false;
                //}
                //foreach (DataGridViewRow row in dgvPromotion.Rows)
                //{
                //    int i;
                //    float f;
                //    bool resultInt = int.TryParse(row.Cells["QuantityKM"].Value.ToString(), out i);
                //    bool resultFloat = float.TryParse(row.Cells["ProductPriceKM"].Value.ToString(), out f);
                //    if (resultInt == false || resultFloat == false)
                //        return false;
                //}

                LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
                if (txtContract.ReadOnly == false && (txtContract.Text == null || txtContract.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfImportManagement.Import5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtInternal.ReadOnly == false && (txtInternal.Text == null || txtInternal.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfImportManagement.Import6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtPO.ReadOnly == false && (txtPO.Text == null || txtPO.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfImportManagement.Import7.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dtImportDate.Value.Date > DateTime.Now)
                {
                    MessageBox.Show(Properties.rsfImportManagement.Import8.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtContract.ReadOnly == false)
                {
                    string query = "select * from EXPORT_PRODUCTS where RED_INVOICE_NO = @RED_INVOICE_NO AND INVOICE_CODE != @INVOICE_CODE";
                    SqlParameter[] sqlPara = new SqlParameter[2];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_NO", SqlDbType.VarChar, txtContract.Text.Trim());
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", SqlDbType.VarChar, txtGoodsCode.Text);
                    DataSet ds = SqlDAC.InlineSql_Execute(query, sqlPara);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(Properties.rsfImportManagement.Import9.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                if (int.Parse(lblSoDong.Text) == 0 && int.Parse(lblSoDongKM.Text) == 0)
                {
                    MessageBox.Show(Properties.rsfImportManagement.Import10.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                else
                {
                    int e = 0;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                            row.Cells["ProductId"].Value.ToString() != "")
                        {
                            flag = true;
                        }
                        if (row.ErrorText != null && row.ErrorText != "")
                        {
                            e += 1;
                        }
                    }
                    foreach (DataGridViewRow row in dgvPromotion.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductIdKM"].Value != null &&
                            row.Cells["ProductIdKM"].Value.ToString() != "")
                        {
                            flag = true;
                        }
                        if (row.ErrorText != null && row.ErrorText != "")
                        {
                            e += 1;
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show(Properties.rsfImportManagement.Import10.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    else
                    {
                        if (e > 0)
                        {
                            var confirmMsg = MessageBox.Show(string.Format(Properties.rsfImportManagement.Import11.ToString(), e), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (confirmMsg == DialogResult.Yes)
                                return true;
                            else
                                return false;
                        }
                        else
                            return true;
                    }
                }               
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckValidate' : " + ex.Message);
            }
            return true;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách PO
        /// </summary>
        private void ImportPO()
        {
            try
            {
                frmDialogImport FormImport = new frmDialogImport(translate);
                FormImport.StartPosition = FormStartPosition.CenterScreen;
                FormImport.WindowState = FormWindowState.Maximized;
                if (FormImport.ShowDialog(this) == DialogResult.OK)
                {
                    DataTable dtProduct = dgvProduct.DataSource as DataTable;
                    DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                    dtProduct.Rows.Clear();
                    dtPromotion.Rows.Clear();
                    txtContract.Text = "";
                    txtNote.Text = "";
                    txtContent.Text = "";
                    txtAmount.Text = "0";
                    dtImportDate.Value = SqlDAC.GetDateTimeServer();
                    dtpTime.Value = SqlDAC.GetDateTimeServer();

                    dtpDateCreate.Value = FormImport.ORDERDATE;
                    txtInternal.Text = FormImport.SONOIBO;
                    txtPO.Text = FormImport.SOPO;

                    DataTable dthangnhap = FormImport.DTHN;
                    DataTable dthangkm = FormImport.DTHKM;
                    foreach (DataRow row in dthangnhap.Rows)
                    {
                        DataRow dr = dtProduct.NewRow();
                        dr["ProductId"] = row["ItemCode"];
                        dr["Quantity"] = int.Parse(row["Quantity"].ToString());
                        dr["ProductPrice"] = float.Parse(row["Price"].ToString());
                        dr["ProductName"] = row["ItemName"];
                        dr["Unit"] = row["UNIT_NAME"];
                        dr["TotalPrice"] = float.Parse(row["Amount"].ToString());
                        dr["SaleOrderNumber"] = row["SaleOrderNumber"];
                        dr["VAT"] = float.Parse(row["Price"].ToString()) * 1.1;
                        dr["P_ID"] = "";
                        dtProduct.Rows.Add(dr);
                    }
                    foreach (DataRow row in dthangkm.Rows)
                    {
                        DataRow dr = dtPromotion.NewRow();
                        dr["ProductId"] = row["ItemCode"];
                        dr["Quantity"] = int.Parse(row["Quantity"].ToString());
                        dr["ProductPrice"] = float.Parse(row["Price"].ToString());
                        dr["ProductName"] = row["ItemName"];
                        dr["Unit"] = row["UNIT_NAME"];
                        dr["SaleOrderNumber"] = row["SaleOrderNumber"];
                        dr["VAT"] = float.Parse(row["Price"].ToString()) * 1.1;
                        dr["P_ID"] = "";
                        dtPromotion.Rows.Add(dr);
                    }
                    LoadTotal(0);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ImportPO' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách mã hàng đã quét
        /// </summary>
        private void ImportBarcodeScan()
        {
            try
            {
                frmBarcodeScaner FormScanner = new frmBarcodeScaner(true);
                if (FormScanner.ShowDialog(this) == DialogResult.OK)
                {
                    DataTable dt = FormScanner.DTProduct;
                    foreach (DataRow rowX in dt.Rows)
                    {
                        foreach (DataRow rowY in dt.Rows)
                        {
                            if ((int)rowX["Quantity"] > 0)
                            {
                                if (rowX["ProductID"].ToString().Equals(rowY["ProductID"].ToString()) && rowX != rowY)
                                {
                                    rowX["Quantity"] = (int)rowX["Quantity"] + (int)rowY["Quantity"];
                                    rowY["Quantity"] = 0;
                                    rowX["TotalPrice"] = (int)rowX["Quantity"] * (float)rowX["Price"];
                                }
                            }
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        if ((int)row["Quantity"] > 0)
                        {
                            DataTable dtProduct = dgvProduct.DataSource as DataTable;
                            DataRow dr = dtProduct.NewRow();
                            dr["ProductId"] = row["ProductID"];
                            dr["Quantity"] = row["Quantity"];
                            dr["ProductPrice"] = row["Price"];
                            dr["ProductName"] = row["ProductName"];
                            dr["Unit"] = row["UnitName"];
                            dr["TotalPrice"] = row["TotalPrice"];
                            dr["SaleOrderNumber"] = "";
                            dr["VAT"] = (float)row["Price"]*1.1;
                            dr["P_ID"] = "";
                            dtProduct.Rows.Add(dr);
                        }
                    }
                    LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ImportBarcodeScan' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Điều chỉnh trạng thái các control trên form
        /// </summary>
        private void FormAdd()
        {
            try
            {
                this.ActiveControl = txtContract;
                txtGoodsCodeSearch.Enabled = false;
                cboImportTypeSearch.Enabled = false;
                dtpDateTo.Enabled = false;
                dtpDateFrom.Enabled = false;
                btnSearch.Enabled = false;
                lvwImportGoods.Enabled = false;

                txtGoodsCode.Text = "";
                txtContract.Text = "";
                txtInternal.Text = "";
                txtPO.Text = "";
                txtNote.Text = "";
                txtContent.Text = "";
                txtAmount.Text = "0";
                dtImportDate.Value = SqlDAC.GetDateTimeServer();
                dtpTime.Value = SqlDAC.GetDateTimeServer();
                dtpDateCreate.Value = SqlDAC.GetDateTimeServer();
                DataTable dtProduct = dgvProduct.DataSource as DataTable;
                DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                dtProduct.Rows.Clear();
                dtPromotion.Rows.Clear();
                LoadTotal(0);

                btnImport.Enabled = true;
                btnBarcodeScan.Enabled = false;
                txtPO.ReadOnly = false;
                txtContent.ReadOnly = false;
                txtNote.ReadOnly = false;
                txtContract.ReadOnly = false;
                txtInternal.ReadOnly = false;
                txtAmount.ReadOnly = false;
                dtpDateCreate.Enabled = true;
                cboAdjustType.Enabled = true;
                cboAdjustType.SelectedIndex = 0;
                cbxImportType.Enabled = true;
                cbxImportType.SelectedIndex = 0;
                chkInsert.Enabled = true;
                chkInsert.Checked = true;
                chkInsert.Visible = true;
                dgvProduct.AllowUserToAddRows = true;
                dgvProduct.AllowUserToDeleteRows = true;
                dgvProduct.ReadOnly = false;
                dgvProduct.Columns[3].ReadOnly = true;
                dgvProduct.Columns[4].ReadOnly = true;
                dgvProduct.Columns[5].ReadOnly = true;
                dgvPromotion.AllowUserToAddRows = true;
                dgvPromotion.AllowUserToDeleteRows = true;
                dgvPromotion.ReadOnly = false;
                dgvPromotion.Columns[2].ReadOnly = true;
                dgvPromotion.Columns[3].ReadOnly = true;
                dgvPromotion.Columns[4].ReadOnly = true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'FormAdd' : " + ex.Message);
            }
        }
        private void FormSearch()
        {
            try
            {
                txtGoodsCodeSearch.Enabled = true;
                cboImportTypeSearch.Enabled = true;
                dtpDateTo.Enabled = true;
                dtpDateFrom.Enabled = true;
                btnSearch.Enabled = true;
                lvwImportGoods.Enabled = true;

                btnBarcodeScan.Enabled = false;
                btnImport.Enabled = false;
                txtPO.ReadOnly = true;
                txtContent.ReadOnly = true;
                txtNote.ReadOnly = true;
                txtContract.ReadOnly = true;
                txtInternal.ReadOnly = true;
                txtAmount.ReadOnly = true;
                dtpDateCreate.Enabled = false;
                cboAdjustType.Enabled = false;
                cbxImportType.Enabled = false;
                chkInsert.Enabled = false;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.AllowUserToDeleteRows = false;
                dgvProduct.ReadOnly = true;
                dgvPromotion.AllowUserToAddRows = false;
                dgvPromotion.AllowUserToDeleteRows = false;
                dgvPromotion.ReadOnly = true;

                edit = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'FormSearch' : " + ex.Message);                                
            }
        }
        private void FormEdit()
        {
            try
            {
                txtGoodsCodeSearch.Enabled = false;
                cboImportTypeSearch.Enabled = false;
                dtpDateTo.Enabled = false;
                dtpDateFrom.Enabled = false;
                btnSearch.Enabled = false;
                lvwImportGoods.Enabled = false;

                if (cbxImportType.SelectedIndex == 1 || cbxImportType.SelectedIndex == 2)
                {
                    txtNote.ReadOnly = false;
                    dgvProduct.AllowUserToAddRows = true;
                    dgvProduct.AllowUserToDeleteRows = true;
                    dgvProduct.ReadOnly = false;
                    dgvProduct.Columns[3].ReadOnly = true;
                    dgvProduct.Columns[4].ReadOnly = true;
                    dgvProduct.Columns[5].ReadOnly = true;
                }
                if (cbxImportType.SelectedIndex == 0)
                {
                    dtpDateCreate.Enabled = true;
                    txtContract.ReadOnly = false;
                    txtInternal.ReadOnly = false;
                    txtPO.ReadOnly = false;
                    txtContent.ReadOnly = false;
                    txtNote.ReadOnly = false;
                    txtAmount.ReadOnly = false;
                    cboAdjustType.Enabled = true;
                    dgvProduct.AllowUserToAddRows = true;
                    dgvProduct.AllowUserToDeleteRows = true;
                    dgvProduct.ReadOnly = false;
                    dgvProduct.Columns[3].ReadOnly = true;
                    dgvProduct.Columns[4].ReadOnly = true;
                    dgvProduct.Columns[5].ReadOnly = true;
                    dgvPromotion.AllowUserToAddRows = true;
                    dgvPromotion.AllowUserToDeleteRows = true;
                    dgvPromotion.ReadOnly = false;
                    dgvPromotion.Columns[2].ReadOnly = true;
                    dgvPromotion.Columns[3].ReadOnly = true;
                    dgvPromotion.Columns[4].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'FormEdit' : " + ex.Message);
            }
        }
        //
        private void SettingSetup()
        {
            //DataGridViewCellStyle stylePrice = this.ProductPrice.DefaultCellStyle;
            //stylePrice.Format = "#,#";
        }
        #endregion

        #region Event
        private void frmGoodsReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                SettingSetup();
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(new bool[] { true, false, true, false, true, true, false, false, false, false, true, true });
                status = new bool[] { true, false, true, false, true, true, false, false, false, false, true, true };
                DateTime dt = SqlDAC.GetDateTimeServer();
                dtpDateFrom.Value = new DateTime(dt.Year, dt.Month, 1);
                dtpDateTo.Value = dt;
                dtImportDate.Value = dt;
                dtpTime.Value = dt;
                dtpDateCreate.Value = dt;
                this.ActiveControl = txtGoodsCodeSearch;

                dFrom = (dtpDateFrom.Checked) ? dtpDateFrom.Value.Date : Convert.ToDateTime("1900/01/01");
                dTo = (dtpDateTo.Checked) ? dtpDateTo.Value.Date.AddMinutes(1439) : Convert.ToDateTime("9999/01/01");
                sType = cboImportTypeSearch.SelectedIndex;
                sID = txtGoodsCodeSearch.Text;

                DataTable dtProduct = new DataTable();
                dtProduct.Columns.Add("ProductId", typeof(string));
                dtProduct.Columns.Add("Quantity", typeof(int));
                dtProduct.Columns.Add("ProductPrice", typeof(float));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("Unit", typeof(string));
                dtProduct.Columns.Add("TotalPrice", typeof(float));
                dtProduct.Columns.Add("SaleOrderNumber", typeof(string));
                dtProduct.Columns.Add("VAT", typeof(float));
                dtProduct.Columns.Add("P_ID", typeof(string));
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = dtProduct;

                DataTable dtPromotion = new DataTable();
                dtPromotion.Columns.Add("ProductId", typeof(string));
                dtPromotion.Columns.Add("Quantity", typeof(int));
                dtPromotion.Columns.Add("ProductPrice", typeof(float));
                dtPromotion.Columns.Add("ProductName", typeof(string));
                dtPromotion.Columns.Add("Unit", typeof(string));
                dtPromotion.Columns.Add("SaleOrderNumber", typeof(string));
                dtPromotion.Columns.Add("VAT", typeof(float));
                dtPromotion.Columns.Add("P_ID", typeof(string));
                dgvPromotion.AutoGenerateColumns = false;
                dgvPromotion.DataSource = dtPromotion;

                if (crossload == true)
                {
                    main.ActiveMenu(new bool[] { false, true, false, true, false, false, false, false, false, false, true, true });
                    status = new bool[] { false, true, false, true, false, false, false, false, false, false, true, true };
                    //main.AddEvent();
                    FormAdd();
                    add = true;

                    cbxImportType.SelectedIndex = 1;
                    dgvProduct.DataSource = crossdt;
                    LoadTotal(0);
                }

                dtpDateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpDateCreate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtImportDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpTime.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
                this.ProductPrice.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.ProductPriceKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.TotalPrice.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.VAT.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.VATKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.Quantity.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
                this.QuantityKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;

                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmImportProducts' ";
                DataSet ds = SqlDAC.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkInsert = checkInsert == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()) : checkInsert;
                        //checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                        checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmImportManagement_Load' : " + ex.Message);
            }
        }
        private void lvwImportGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string invoiceCode = null;
                ListView.SelectedListViewItemCollection selected = lvwImportGoods.SelectedItems;
                foreach (ListViewItem i in selected)
                {
                    invoiceCode = i.SubItems[5].Text;
                    //cbxLoaiNhapDetail.ResetText();
                    LoadInvoice(invoiceCode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'lvDanhSach_SelectedIndexChanged' : " + ex.Message);
            }
        }
        private void cbxImportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxImportType.SelectedIndex == 0)
                {
                    label9.Visible = true;
                    lblTongVAT.Visible = true;
                }
                else
                {
                    label9.Visible = false;
                    lblTongVAT.Visible = false;
                }

                if (add == true)
                {
                    if (cbxImportType.SelectedIndex == 0)
                    {
                        chkInsert.Enabled = true;
                        chkInsert.Checked = true;
                        chkInsert.Visible = true;
                        txtContract.ReadOnly = false;
                        txtInternal.ReadOnly = false;
                        txtPO.ReadOnly = false;
                        txtContent.ReadOnly = false;
                        txtAmount.ReadOnly = false;
                        cboAdjustType.Enabled = true;
                        dtpDateCreate.Enabled = true;
                        dgvPromotion.AllowUserToAddRows = true;
                        dgvPromotion.AllowUserToDeleteRows = true;
                        dgvPromotion.ReadOnly = false;
                        dgvPromotion.Columns[2].ReadOnly = true;
                        dgvPromotion.Columns[3].ReadOnly = true;
                        dgvPromotion.Columns[4].ReadOnly = true;
                        btnImport.Enabled = true;
                        btnBarcodeScan.Enabled = false;
                    }
                    if (cbxImportType.SelectedIndex == 1 || cbxImportType.SelectedIndex == 2)
                    {
                        chkInsert.Enabled = false;
                        chkInsert.Checked = false;
                        chkInsert.Visible = false;
                        txtContract.ReadOnly = true;
                        txtInternal.ReadOnly = true;
                        txtPO.ReadOnly = true;
                        txtContent.ReadOnly = true;
                        txtAmount.ReadOnly = true;
                        cboAdjustType.Enabled = false;
                        dtpDateCreate.Enabled = false;
                        dgvPromotion.AllowUserToAddRows = false;
                        dgvPromotion.AllowUserToDeleteRows = false;
                        dgvPromotion.ReadOnly = true;
                        btnImport.Enabled = false;
                        btnBarcodeScan.Enabled = true;

                        txtContract.Text = "";
                        txtInternal.Text = "";
                        txtPO.Text = "";
                        txtContent.Text = "";
                        txtAmount.Text = "0";
                        DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                        dtPromotion.Rows.Clear();
                        LoadTotal(0);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'cbxLoaiNhapDetail_SelectedIndexChanged' : " + ex.Message);
            }
        }
        //
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dFrom = (dtpDateFrom.Checked) ? dtpDateFrom.Value.Date : Convert.ToDateTime("1900/01/01");
            dTo = (dtpDateTo.Checked) ? dtpDateTo.Value.Date.AddMinutes(1439) : Convert.ToDateTime("9999/01/01");
            sType = cboImportTypeSearch.SelectedIndex;
            sID = txtGoodsCodeSearch.Text;
            SearchInvoiceCode(dFrom, dTo, sID, sType, true);
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportPO();
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Các sự kiện thêm/sửa/xóa/hủy/in
        /// </summary>
        private void AddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                    main.ActiveMenu(new bool[] { false, true, false, true, false, false, false, false, false, false, true, true });
                    status = new bool[] { false, true, false, true, false, false, false, false, false, false, true, true };
                    //main.AddEvent();
                    FormAdd();
                    add = true;
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddNew' : " + ex.Message);
            }
        }
        private void Edit(object sender, EventArgs e)
        {
            try
            {
                if (checkUpdate)
                {
                    if (edit == true)
                    {
                        frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                        main.ActiveMenu(new bool[] { false, true, false, true, false, false, false, false, false, false, true, true });
                        status = new bool[] { false, true, false, true, false, false, false, false, false, false, true, true };
                        //main.EditEvent();
                        FormEdit();
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Edit' : " + ex.Message);
            }
        }
        private void Save(object sender, EventArgs e)
        {
            dgvProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvPromotion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            EditInvoice(txtGoodsCode.Text);
        }
        private void Cancel(object sender, EventArgs e)
        {
            try
            {
                add = false;
                FormSearch();
                if (txtGoodsCode.Text != null && txtGoodsCode.Text.Trim() != "")
                {
                    LoadInvoice(txtGoodsCode.Text);
                }
                else
                {
                    if (lvwImportGoods.SelectedItems.Count > 0)
                    {
                        LoadInvoice(lvwImportGoods.SelectedItems[0].SubItems[5].Text);
                    }
                    else
                    {
                        DataTable dtProduct = new DataTable();
                        dtProduct.Columns.Add("ProductId", typeof(string));
                        dtProduct.Columns.Add("Quantity", typeof(int));
                        dtProduct.Columns.Add("ProductPrice", typeof(float));
                        dtProduct.Columns.Add("ProductName", typeof(string));
                        dtProduct.Columns.Add("Unit", typeof(string));
                        dtProduct.Columns.Add("TotalPrice", typeof(float));
                        dtProduct.Columns.Add("SaleOrderNumber", typeof(string));
                        dtProduct.Columns.Add("VAT", typeof(float));
                        dtProduct.Columns.Add("P_ID", typeof(string));
                        dgvProduct.AutoGenerateColumns = false;
                        dgvProduct.DataSource = dtProduct;

                        DataTable dtPromotion = new DataTable();
                        dtPromotion.Columns.Add("ProductId", typeof(string));
                        dtPromotion.Columns.Add("Quantity", typeof(int));
                        dtPromotion.Columns.Add("ProductPrice", typeof(float));
                        dtPromotion.Columns.Add("ProductName", typeof(string));
                        dtPromotion.Columns.Add("Unit", typeof(string));
                        dtPromotion.Columns.Add("SaleOrderNumber", typeof(string));
                        dtPromotion.Columns.Add("VAT", typeof(float));
                        dtPromotion.Columns.Add("P_ID", typeof(string));
                        dgvPromotion.AutoGenerateColumns = false;
                        dgvPromotion.DataSource = dtPromotion;

                        txtGoodsCode.Text = "";
                        txtContract.Text = "";
                        txtInternal.Text = "";
                        txtPO.Text = "";
                        txtNote.Text = "";
                        txtContent.Text = "";
                        txtAmount.Text = "0";
                        dtImportDate.Value = SqlDAC.GetDateTimeServer();
                        dtpTime.Value = SqlDAC.GetDateTimeServer();
                        dtpDateCreate.Value = SqlDAC.GetDateTimeServer();
                        //DataTable dtProduct = dgvProduct.DataSource as DataTable;
                        //DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                        //dtProduct.Rows.Clear();
                        //dtPromotion.Rows.Clear();
                        LoadTotal(0);
                        if (lvwImportGoods.Items.Count > 0)
                            lvwImportGoods.Items[lvwImportGoods.Items.Count-1].Selected = true;
                    }
                }
                this.ActiveControl = txtGoodsCodeSearch;
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(new bool[] { true, false, true, false, true, true, false, false, false, false, true, true });
                status = new bool[] { true, false, true, false, true, true, false, false, false, false, true, true };
                //main.CancelEvent();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cancel' : " + ex.Message);
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    if (edit == true)
                    {
                        var confirmMsg = MessageBox.Show(Properties.rsfImportManagement.Import1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (confirmMsg == DialogResult.Yes)
                        {
                            Import.DeleteInvoice(txtGoodsCode.Text);
                            int index = lvwImportGoods.SelectedItems[0].Index;
                            lvwImportGoods.Items.RemoveAt(index);
                            for (int i = 0; i < lvwImportGoods.Items.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    lvwImportGoods.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                                }
                                else
                                {
                                    lvwImportGoods.Items[i].BackColor = Color.White;
                                }
                            }
                            txtGoodsCode.Text = "";
                            txtContract.Text = "";
                            txtInternal.Text = "";
                            txtPO.Text = "";
                            txtNote.Text = "";
                            txtContent.Text = "";
                            txtAmount.Text = "0";
                            dtImportDate.Value = SqlDAC.GetDateTimeServer();
                            dtpTime.Value = SqlDAC.GetDateTimeServer();
                            dtpDateCreate.Value = SqlDAC.GetDateTimeServer();
                            DataTable dtProduct = dgvProduct.DataSource as DataTable;
                            DataTable dtPromotion = dgvPromotion.DataSource as DataTable;
                            dtProduct.Rows.Clear();
                            dtPromotion.Rows.Clear();
                            LoadTotal(0);
                            //SearchInvoiceCode(dFrom, dTo, sID, sType, false);
                            FormSearch();
                            //if (lvwImportGoods.Items.Count > 0)
                            //    lvwImportGoods.Items[lvwImportGoods.Items.Count - 1].Selected = true;
                            index = index > 0 ? index - 1 : 0;
                            if (lvwImportGoods.Items.Count > index)
                            {
                                lvwImportGoods.Items[index].Selected = true;
                            }
                        }
                    }
                    this.ActiveControl = txtGoodsCodeSearch;
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Delete' : " + ex.Message);
            }
        }
        private void Print(object sender, EventArgs e)
        {
            if (edit == true)
            {
                Import.PrintInvoice(txtGoodsCode.Text);
            }
          
        }

        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thêm/sửa/xóa sản phẩm trên gridview sản phẩm
        /// </summary>
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "ProductPrice" || dgvProduct.Columns[e.ColumnIndex].Name == "Quantity")
                    {
                        float price = 0;
                        float quantity = 1;
                        if (dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value == null 
                            || dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value.ToString(),out price))
                            dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value = 0;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;

                        if (quantity == 0)
                        {
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                            quantity = 1;
                        }

                        dgvProduct.Rows[e.RowIndex].Cells["TotalPrice"].Value = price * quantity;
                        LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
                    }
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "ProductId")
                    {
                        if (dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value != null && !dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString().Equals(""))
                        {
                            string proc = "PRODUCTS_Read";
                            SqlParameter[] sqlPara = new SqlParameter[1];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString());
                            DataTable tb = SqlDAC.GetDataTable(proc, sqlPara);
                            if (tb.Rows.Count > 0)
                            {
                                dgvProduct.Rows[e.RowIndex].Cells["colProductName"].Value = tb.Rows[0]["PRODUCT_NAME"].ToString();
                                dgvProduct.Rows[e.RowIndex].Cells["ProductPrice"].Value = cbxImportType.SelectedIndex == 0 ? float.Parse(tb.Rows[0]["PRICE"].ToString()) : float.Parse(tb.Rows[0]["PRICEDEV"].ToString());
                                dgvProduct.Rows[e.RowIndex].Cells["Unit"].Value = tb.Rows[0]["UNIT_NAME"].ToString();
                                dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "" ? 1 : dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value;
                                dgvProduct.Rows[e.RowIndex].Cells["VAT"].Value = cbxImportType.SelectedIndex == 0 ? float.Parse(tb.Rows[0]["PRICE"].ToString()) * 1.1 : float.Parse(tb.Rows[0]["PRICEDEV"].ToString());
                                dgvProduct.Rows[e.RowIndex].ErrorText = string.Empty;
                            }
                            else
                            {
                                dgvProduct.Rows[e.RowIndex].ErrorText = "Sản phẩm không hợp lệ";
                                frmDialogProductSearch FormTKMH = new frmDialogProductSearch(dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString().Trim(), translate);
                                if (FormTKMH.ShowDialog(this) == DialogResult.OK)
                                {
                                    dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value = FormTKMH.ProductID;
                                }
                            }
                        }
                        else
                        {
                            dgvProduct.Rows[e.RowIndex].ErrorText = "Sản phẩm không hợp lệ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvSanPham_CellValueChanged' : " + ex.Message);                
            }
        }
        private void dgvProduct_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvSanPham_UserDeletedRow' : " + ex.Message);
            }
        }
        private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            //e.Control.TextChanged -= new EventHandler(Column1_TextChanged);
            if (dgvProduct.CurrentCell.ColumnIndex == 1 || dgvProduct.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    //e.Control.TextChanged += new EventHandler(Column1_TextChanged);
                }
            }
        }
        private void dgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            e.Cancel = false;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thêm/sửa/xóa sản phẩm trên gridview khuyến mãi
        /// </summary>
        private void dgvPromotion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvPromotion.Columns[e.ColumnIndex].Name == "ProductPriceKM" || dgvPromotion.Columns[e.ColumnIndex].Name == "QuantityKM")
                    {
                        if (dgvPromotion.Rows[e.RowIndex].Cells["ProductPriceKM"].Value == DBNull.Value || dgvPromotion.Rows[e.RowIndex].Cells["ProductPriceKM"].Value == null)
                            dgvPromotion.Rows[e.RowIndex].Cells["ProductPriceKM"].Value = 0;
                        if (dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value == DBNull.Value || dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value == null)
                            dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value = 1;

                        float quantity = 0;
                        float.TryParse(dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value.ToString(),out quantity);
                        if (quantity == 0)
                        {
                            dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value = 1;
                            quantity = 1;
                        }
                        LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
                    }
                    if (dgvPromotion.Columns[e.ColumnIndex].Name == "ProductIdKM")
                    {
                        if (!dgvPromotion.Rows[e.RowIndex].Cells["ProductIdKM"].Value.ToString().Equals(""))
                        {
                            string proc = "PRODUCTS_Read";
                            SqlParameter[] sqlPara = new SqlParameter[1];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, dgvPromotion.Rows[e.RowIndex].Cells["ProductIdKM"].Value.ToString());
                            DataTable tb = SqlDAC.GetDataTable(proc, sqlPara);
                            if (tb.Rows.Count > 0)
                            {
                                dgvPromotion.Rows[e.RowIndex].Cells["ProductNameKM"].Value = tb.Rows[0]["PRODUCT_NAME"].ToString();
                                dgvPromotion.Rows[e.RowIndex].Cells["ProductPriceKM"].Value = 0;
                                dgvPromotion.Rows[e.RowIndex].Cells["UnitKM"].Value = tb.Rows[0]["UNIT_NAME"].ToString();
                                dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value = dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value == null || dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value.ToString() == "" ? 1 : dgvPromotion.Rows[e.RowIndex].Cells["QuantityKM"].Value;
                                dgvPromotion.Rows[e.RowIndex].Cells["VATKM"].Value = 0;
                                dgvPromotion.Rows[e.RowIndex].ErrorText = string.Empty;
                            }
                            else
                            {
                                dgvPromotion.Rows[e.RowIndex].ErrorText = "Sản phẩm không hợp lệ";
                                frmDialogProductSearch FormTKMH = new frmDialogProductSearch(dgvPromotion.Rows[e.RowIndex].Cells["ProductIdKM"].Value.ToString(), translate);
                                if (FormTKMH.ShowDialog(this) == DialogResult.OK)
                                {
                                    dgvPromotion.Rows[e.RowIndex].Cells["ProductIdKM"].Value = FormTKMH.ProductID;
                                }
                            }
                        }
                        else
                        {
                            dgvPromotion.Rows[e.RowIndex].ErrorText = "Sản phẩm không hợp lệ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvKhuyenMai_CellValueChanged' : " + ex.Message);
            }
        }
        private void dgvPromotion_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvKhuyenMai_UserDeletedRow' : " + ex.Message);
            }
        }
        private void dgvPromotion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvPromotion.CurrentCell.ColumnIndex == 1 || dgvPromotion.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void dgvPromotion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dgvPromotion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            e.Cancel = false;
        }
        //                
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    txtAmount.Text = "0";
                }
                LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
            }
            catch (Exception ex)
            {
                log.Error("Error 'txtSoTien_TextChanged' : " + ex.Message);
                txtAmount.Text = "0";
            }
        }
        private void cboAdjustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtAmount != null && txtAmount.Text != "")
            {
                LoadTotal(cboAdjustType.SelectedIndex == 0 ? float.Parse(txtAmount.Text) * -1 : float.Parse(txtAmount.Text));
            }
        }
        private void lvwImportGoods_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwImportGoods.Sort();
            for (int i = 0; i < lvwImportGoods.Items.Count; i++)
            {
                if (i % 2 == 0)
                    {
                        lvwImportGoods.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                    else
                    {
                        lvwImportGoods.Items[i].BackColor = Color.White;
                    }
            }
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Cho phep dau cham
            //if (!char.IsControl(e.KeyChar)
            //        && !char.IsDigit(e.KeyChar)
            //            && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }
        private void Column1_TextChanged(object sender, EventArgs e)
        {
            //TextBox tb = sender as TextBox;
            //try
            //{
            //    int n = int.Parse(tb.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error");
            //}
        }
        private void dgvSanPham_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void dgvProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
        }
        private void btnBarcodeScan_Click(object sender, EventArgs e)
        {
            ImportBarcodeScan();
        }
        private void txtAmount_Leave(object sender, EventArgs e)
        {
            float amount = 0;
            if (float.TryParse(txtAmount.Text, out amount))
            {
                txtAmount.Text = amount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
            }
            else
            {
                txtAmount.Text = "0";
            }
        }
        #endregion

        private void frmGoodsReceipt_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }

        


    }
}

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
using System.Globalization;


namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmGoodsDelivery : TabForm
    {
        #region Declaration
        private ListViewColumnSorter lvwColumnSorter;
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Conversion cvn = new Conversion();
        bool add = false;
        bool edit = false;
        string epsEventId;
        string epsdEventId;
        string itEventId;
        DateTime dFrom;
        DateTime dTo;
        string sID;
        int sType;
        bool crossload = false;
        DataTable crossdt = new DataTable();
        float oldtotal = 0;
        private bool[] status;
        //check quyen
        //private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        #endregion

        #region Constructor
        public frmGoodsDelivery(Dictionary<string, string> language)
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
            lvwColumnSorter = new ListViewColumnSorter();
            lvwExportPro.ListViewItemSorter = lvwColumnSorter;
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label19.Text = translate["frmGoodsDelivery.label19.Text"];
            this.gbxSanPham.Text = translate["frmGoodsDelivery.gbxSanPham.Text"];
            this.label18.Text = translate["frmGoodsDelivery.label18.Text"];
            this.label17.Text = translate["frmGoodsDelivery.label17.Text"];
            this.label16.Text = translate["frmGoodsDelivery.label16.Text"];
            this.gbxDanhSach.Text = translate["frmGoodsDelivery.gbxDanhSach.Text"];
            this.NgayXuat.Text = translate["frmGoodsDelivery.NgayXuat.Text"];
            this.MaXuat.Text = translate["frmGoodsDelivery.MaXuat.Text"];
            this.SoLuongT.Text = translate["frmGoodsDelivery.SoLuongT.Text"];
            this.ThanhTien.Text = translate["frmGoodsDelivery.ThanhTien.Text"];
            this.btnInventory.Text = translate["frmGoodsDelivery.btnInventory.Text"];
            this.btnCodeScaner.Text = translate["frmGoodsDelivery.btnCodeScaner.Text"];
            this.btnSearch.Text = translate["frmGoodsDelivery.btnSearch.Text"];
            this.gbxTTXuat.Text = translate["frmGoodsDelivery.gbxTTXuat.Text"];
            this.cbxDebt.Text = translate["frmGoodsDelivery.cbxDebt.Text"];
            this.label13.Text = translate["frmGoodsDelivery.label13.Text"];
            this.label15.Text = translate["frmGoodsDelivery.label15.Text"];
            this.label12.Text = translate["frmGoodsDelivery.label12.Text"];
            this.label14.Text = translate["frmGoodsDelivery.label14.Text"];
            this.label11.Text = translate["frmGoodsDelivery.label11.Text"];
            this.label10.Text = translate["frmGoodsDelivery.label10.Text"];
            this.label9.Text = translate["frmGoodsDelivery.label9.Text"];
            this.label8.Text = translate["frmGoodsDelivery.label8.Text"];
            this.label7.Text = translate["frmGoodsDelivery.label7.Text"];
            this.label6.Text = translate["frmGoodsDelivery.label6.Text"];
            this.label5.Text = translate["frmGoodsDelivery.label5.Text"];
            this.label4.Text = translate["frmGoodsDelivery.label4.Text"];
            this.label3.Text = translate["frmGoodsDelivery.label3.Text"];
            this.label2.Text = translate["frmGoodsDelivery.label2.Text"];
            this.label1.Text = translate["frmGoodsDelivery.label1.Text"];
            this.ProductId.HeaderText = translate["frmGoodsDelivery.ProductId.HeaderText"];
            this.Quantity.HeaderText = translate["frmGoodsDelivery.Quantity.HeaderText"];
            this.Price.HeaderText = translate["frmGoodsDelivery.Price.HeaderText"];
            this.colProductName.HeaderText = translate["frmGoodsDelivery.colProductName.HeaderText"];
            this.Unit.HeaderText = translate["frmGoodsDelivery.Unit.HeaderText"];
            this.P_ID.HeaderText = translate["frmGoodsDelivery.P_ID.HeaderText"];
            this.Text = translate["frmGoodsDelivery.Text"];
        }

        public frmGoodsDelivery(bool load, DataTable dt, Dictionary<string, string> language)
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
            lvwColumnSorter = new ListViewColumnSorter();
            lvwExportPro.ListViewItemSorter = lvwColumnSorter;
            crossload = load;
            crossdt = dt;
        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm kiếm hóa đơn
        /// </summary>
        protected void SearchInvoiceCode(DateTime dateFrom, DateTime dateTo, string id, int type,bool search)
        {
            try
            {
                string storeid = null;
                if (!string.IsNullOrEmpty(id))
                {
                    storeid = id.Trim();
                    storeid = "%" + storeid + "%";
                }

                string exportType = null;
                switch (type)
                {
                    case 1:
                        exportType = "ETY.0001";
                        break;
                    case 2:
                        exportType = "ETY.0002";
                        break;
                    case 3:
                        exportType = "ETY.0003";
                        break;
                }

                DataTable dtTable = ExportProcess.GetExportList(exportType, dateFrom, dateTo, storeid);
                lvwExportPro.Items.Clear();
                lvwColumnSorter = new ListViewColumnSorter();
                lvwExportPro.ListViewItemSorter = lvwColumnSorter;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    double price = double.Parse(dtTable.Rows[i]["DetailPrice"].ToString());
                    DateTime dateExport = dtTable.Rows[i]["DATE_EXPORT"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtTable.Rows[i]["DATE_EXPORT"];
                    ListViewItem lvItem = new ListViewItem(dateExport.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                    lvItem.SubItems.Add(dtTable.Rows[i]["EXPORT_STORE_ID"].ToString());
                    lvItem.SubItems.Add(dtTable.Rows[i]["DeltailQuantity"].ToString());
                    lvItem.SubItems.Add(price.ToString(AppConfigFileSettings.strOptCurency, new CultureInfo("vi-VN")));
                    lvwExportPro.Items.Add(lvItem);
                    //lvwExportPro.Items.Add(dtTable.Rows[i]["DATE_EXPORT"].ToString());
                    //lvwExportPro.Items[i].SubItems.Add(dtTable.Rows[i]["EXPORT_STORE_ID"].ToString());
                    //lvwExportPro.Items[i].SubItems.Add(dtTable.Rows[i]["DeltailQuantity"].ToString());
                    //lvwExportPro.Items[i].SubItems.Add(price.ToString("#,0", new CultureInfo("vi-VN")));
                    if (i % 2 == 0)
                    {
                        lvwExportPro.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                    else
                    {
                        lvwExportPro.Items[i].BackColor = Color.White;
                    }
                }
                if (lvwExportPro.Items.Count > 0)
                {
                    lvwExportPro.Items[0].Selected = true;
                }
                else
                {
                    txtExportCode.Text = "";
                    txtContract.Text = "";
                    txtInternal.Text = "";
                    txtPONo.Text = "";
                    txtNote.Text = "";
                    txtContent.Text = "";
                    txtMoney.Text = "0";
                    dtpExportDate.Value = SqlDAC.GetDateTimeServer();
                    dtpExportTime.Value = SqlDAC.GetDateTimeServer();
                    dtpContractDate.Value = SqlDAC.GetDateTimeServer();
                    DataTable dtProduct = dgvProduct.DataSource as DataTable;
                    dtProduct.Rows.Clear();
                    LoadTotal(0);
                    edit = false;
                }
                if(dtTable.Rows.Count <=0 && search == true)
                    MessageBox.Show(Properties.rsfExportManagement.Export8.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
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
        protected void LoadInvoice(string storeid)
        {
            try
            {
                //Thông tin xuất hàng
                DataTable dt = ExportProcess.GetExportInfo(storeid);
                DataRow dtRow = dt.Rows[0];
                switch (dtRow["EXPORT_TYPE_CODE"].ToString())
                {
                    case "ETY.0001":
                        cboExportType.SelectedIndex = 0;
                        break;
                    case "ETY.0002":
                        cboExportType.SelectedIndex = 1;
                        break;
                    case "ETY.0003":
                        cboExportType.SelectedIndex = 2;
                        break;
                }
                cbxDebt.Visible = dtRow["EXPORT_TYPE_CODE"].ToString().Equals("ETY.0002") ? true : false;
                cbxDebt.Checked = dtRow["IS_IMPORT_DEBT"] as bool? ?? false;
                DateTime dateExport = dtRow["DATE_EXPORT"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtRow["DATE_EXPORT"];
                DateTime dateOrder = dtRow["ORDER_DATE"].ToString().Equals("1/1/1753 12:00:00 AM") ? SqlDAC.GetDateTimeServer() : (DateTime)dtRow["ORDER_DATE"];
                dtpExportDate.Value = dateExport;
                dtpExportTime.Value = dateExport;
                dtpContractDate.Value = dateOrder;

                txtExportCode.Text = dtRow["EXPORT_STORE_ID"].ToString();
                txtContract.Text = dtRow["INVOICE_NO"].ToString();
                txtInternal.Text = dtRow["SO_NOI_BO"].ToString();
                txtPONo.Text = dtRow["POCO_NUMBER"].ToString();
                txtNote.Text = dtRow["REMARKS"].ToString();
                txtContent.Text = dtRow["GHICHUDC"].ToString();

                epsEventId = dtRow["EVENT_ID"].ToString();
                epsdEventId = dtRow["EPSDeventid"].ToString();
                itEventId = dtRow["ITeventid"].ToString();

                float dSoTien = float.Parse(dtRow["SOTIENDC"].ToString());
                if (dSoTien <= 0)
                {
                    cboTypeAdjust.SelectedIndex = 0;
                    txtMoney.Text = (dSoTien * -1).ToString(AppConfigFileSettings.strOptCurency);
                }
                else
                {
                    cboTypeAdjust.SelectedIndex = 1;
                    txtMoney.Text = dSoTien.ToString(AppConfigFileSettings.strOptCurency);
                }

                //Thông tin sản phẩm            
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = ExportProcess.GetExportDetail(storeid);

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
                int sumSL = 0;
                double sumTong = 0;
                for (int i = 0; i < dgvProduct.RowCount; i++)
                {
                    if (dgvProduct.Rows[i].Cells["Quantity"].Value != DBNull.Value && dgvProduct.Rows[i].Cells["Price"].Value != DBNull.Value
                        && dgvProduct.Rows[i].Cells["Quantity"].Value != null && dgvProduct.Rows[i].Cells["Price"].Value != null
                        && dgvProduct.Rows[i].Cells["Quantity"].Value.ToString() != "" && dgvProduct.Rows[i].Cells["Price"].Value.ToString() != "")
                    {
                        sumSL += int.Parse(dgvProduct.Rows[i].Cells["Quantity"].Value.ToString());
                        sumTong += int.Parse(dgvProduct.Rows[i].Cells["Quantity"].Value.ToString()) * double.Parse(dgvProduct.Rows[i].Cells["Price"].Value.ToString());
                    }
                    if (dgvProduct.Rows[i].Cells["colProductName"].Value != null && dgvProduct.Rows[i].Cells["colProductName"].Value.ToString() != "")
                        sumCount += 1;
                }
                //if (dSoTien != 0)
                //{
                //    sumTong += dSoTien;
                //}

                lblTongSL.Text = sumSL.ToString(AppConfigFileSettings.strOptNumber);
                lblTongTT.Text = sumTong.ToString(AppConfigFileSettings.strOptCurency);
                lblDong.Text = sumCount.ToString("#,0");
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTotal' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thêm/sửa hóa đơn
        /// </summary>
        private void EditInvoice(string storeid)
        {
            try
            {
                if (CheckValidate())
                {
                    DateTime exportDate = new DateTime(dtpExportDate.Value.Year, dtpExportDate.Value.Month, dtpExportDate.Value.Day, dtpExportTime.Value.Hour, dtpExportTime.Value.Minute, dtpExportTime.Value.Second);
                    float tong = 0;
                    float totalprice = 0;
                    int totalquantity = 0;
                    string id = "";
                    string ida = "";
                    string idb = "";
                    string msg = "";
                    string sql = "";
                    SqlParameter[] sqlPara;

                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                                                    row.Cells["ProductId"].Value.ToString() != "")
                        {
                            int quantity = 0;
                            foreach (DataGridViewRow rowQ in dgvProduct.Rows)
                            {
                                if (rowQ.ErrorText == "" && rowQ.Cells["ProductId"].Value != null &&
                                    rowQ.Cells["ProductId"].Value.ToString() != "" && rowQ.Cells["ProductId"].Value.ToString().Equals(row.Cells["ProductId"].Value.ToString()))
                                {
                                    quantity += int.Parse(rowQ.Cells["Quantity"].Value.ToString());
                                }
                            }
                            //
                            sql = "select SUM(Amount) as Quantity from INVENTORY_TEMP where PRODUCT_ID = @PRODUCT_ID";
                            if (add == false)
                            {
                                sql = "select SUM(Amount) as Quantity from INVENTORY_TEMP where PRODUCT_ID = @PRODUCT_ID and GENERATE_CODE <> '"+txtExportCode.Text.Trim() +"'";
                            }
                            sqlPara = new SqlParameter[1];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, row.Cells["ProductId"].Value.ToString());
                            DataSet ds = SqlDAC.InlineSql_Execute(sql, sqlPara);
                            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                            {
                                                                                                
                                if (int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString()) < quantity)
                                {
                                    if (!id.Contains(row.Cells["ProductId"].Value.ToString()))
                                    {
                                        id += id.Equals("") ? row.Cells["ProductId"].Value.ToString() : ", " + row.Cells["ProductId"].Value.ToString();
                                    }
                                }
                            }
                            if (cboExportType.SelectedIndex == 1)
                            {
                                sql = "select * from EXPORT_DETAIL where PRODUCT_ID = @PRODUCT_ID and INVOICE_CODE in (select INVOICE_CODE from EXPORT_PRODUCTS where RED_INVOICE_NO = @RED_INVOICE_NO)";
                                sqlPara = new SqlParameter[2];
                                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, row.Cells["ProductId"].Value.ToString());
                                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_NO", SqlDbType.VarChar, txtContract.Text.Trim());
                                ds = SqlDAC.InlineSql_Execute(sql, sqlPara);
                                if (ds.Tables[0].Rows.Count <= 0)
                                {
                                    if (!idb.Contains(row.Cells["ProductId"].Value.ToString()))
                                    {
                                        idb += idb.Equals("") ? row.Cells["ProductId"].Value.ToString() : ", " + row.Cells["ProductId"].Value.ToString();
                                    }
                                }
                                else
                                {
                                    sql = "select SUM(AMOUNT) as Quantity from INVENTORY_TEMP where PRODUCT_ID = @PRODUCT_ID and GENERATE_CODE in (select INVOICE_CODE from EXPORT_PRODUCTS where RED_INVOICE_NO = @RED_INVOICE_NO)";
                                    sqlPara = new SqlParameter[2];
                                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, row.Cells["ProductId"].Value.ToString());
                                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_NO", SqlDbType.VarChar, txtContract.Text.Trim());
                                    ds = SqlDAC.InlineSql_Execute(sql, sqlPara);
                                    int i = ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "" ? int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString()) : 0;
                                    //
                                    sql = "select SUM(AMOUNT) as Quantity from INVENTORY_TEMP where PRODUCT_ID = @PRODUCT_ID and GENERATE_CODE in (select EXPORT_STORE_ID from EXPORT_PRODUCT_STORE where INVOICE_NO = @INVOICE_NO)";
                                    if (add == false)
                                    {
                                        sql = "select SUM(AMOUNT) as Quantity from INVENTORY_TEMP where PRODUCT_ID = @PRODUCT_ID and GENERATE_CODE in (select EXPORT_STORE_ID from EXPORT_PRODUCT_STORE where INVOICE_NO = @INVOICE_NO and EXPORT_STORE_ID <> '"+txtExportCode.Text.Trim() +"')";
                                    }
                                    sqlPara = new SqlParameter[2];
                                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, row.Cells["ProductId"].Value.ToString());
                                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@INVOICE_NO", SqlDbType.VarChar, txtContract.Text.Trim());
                                    ds = SqlDAC.InlineSql_Execute(sql, sqlPara);
                                    int e = ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "" ? int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString()) : 0;
                                    if (i + e < quantity)
                                    {
                                        if (!ida.Contains(row.Cells["ProductId"].Value.ToString()))
                                        {
                                            ida += ida.Equals("") ? row.Cells["ProductId"].Value.ToString() : ", " + row.Cells["ProductId"].Value.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!idb.Equals(""))
                    {
                        msg += string.Format(Properties.rsfExportManagement.Export3.ToString(), idb, txtContract.Text.Trim());
                    }
                    if (!ida.Equals(""))
                    {
                        msg += Environment.NewLine + string.Format(Properties.rsfExportManagement.Export2.ToString(), ida);
                    }
                    if (!msg.Equals(""))
                    {
                        MessageBox.Show(msg, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (!id.Equals(""))
                    {
                        MessageBox.Show(string.Format(Properties.rsfExportManagement.Export1.ToString(), id), translate["Msg.TitleDialog"],
                                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }



                    string invoice = add == false ? storeid : GetAutoCode("EXPORT_PRODUCT_STORE", "EXPORT_STORE_ID", "EXS." + UserImformation.DeptCode + "." + SqlDAC.GetDateTimeServer().ToString("yy") + ".");

                    //Xóa EXPORT_PRODUCT_STORE_DETAIL, INVENTORY_TEMP
                    if (add == false)
                    {
                        sql = "delete EXPORT_PRODUCT_STORE_DETAIL where EXPORT_STORE_ID = @EXPORT_STORE_ID";
                        sqlPara = new SqlParameter[1];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_STORE_ID", SqlDbType.VarChar, invoice);
                        SqlDAC.InlineSql_ExecuteNonQuery(sql, sqlPara);
                        CreateEvent(epsdEventId, "EXPORT_PRODUCT_STORE_DETAIL", "", 3);

                        sql = "delete INVENTORY_TEMP where GENERATE_CODE = @GENERATE_CODE";
                        sqlPara = new SqlParameter[1];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@GENERATE_CODE", SqlDbType.VarChar, invoice);
                        SqlDAC.InlineSql_ExecuteNonQuery(sql, sqlPara);
                        CreateEvent(itEventId, "INVENTORY_TEMP", "", 3);
                    }
                    //Tạo mới EXPORT_PRODUCT_STORE_DETAIL, INVENTORY_TEMP
                    string detailevent = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy")+"-");
                    CreateEvent(detailevent, "EXPORT_PRODUCT_STORE_DETAIL", "", 1);
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                            row.Cells["ProductId"].Value.ToString() != "")
                        {
                            EXPORT_PRODUCT_STORE_DETAIL detail = new EXPORT_PRODUCT_STORE_DETAIL();
                            detail.ID = System.Guid.NewGuid();
                            detail.EXPORT_STORE_ID = invoice;
                            detail.PRODUCT_ID = row.Cells["ProductId"].Value.ToString();
                            detail.P_ID = row.Cells["P_ID"].Value != null ? row.Cells["P_ID"].Value.ToString() : "";
                            detail.QUANTITY = int.Parse(row.Cells["Quantity"].Value.ToString());
                            detail.PRODUCT_PRICE = float.Parse(row.Cells["Price"].Value.ToString());
                            detail.EVENT_ID = detailevent;
                            detail.PRODUCT_PRICE_VAT = 0;
                            detail.Save(true);
                            tong += (int)detail.QUANTITY * (float)detail.PRODUCT_PRICE;
                            totalquantity += (int)detail.QUANTITY;
                            totalprice += ((int)detail.QUANTITY * (float)detail.PRODUCT_PRICE);
                        }
                    }
                    string tempevent = GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy") + "-");
                    CreateEvent(tempevent, "INVENTORY_TEMP", "", 1);
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.ErrorText == "" && row.Cells["ProductId"].Value != null &&
                            row.Cells["ProductId"].Value.ToString() != "")
                        {
                            INVENTORY_TEMP temp = new INVENTORY_TEMP();
                            temp.INVENTORY_ID = System.Guid.NewGuid();
                            //temp.CREATED_DATE = SqlDAC.GetDateTimeServer();
                            temp.CREATED_DATE = exportDate;
                            temp.PRODUCT_ID = row.Cells["ProductId"].Value.ToString();
                            temp.P_ID = row.Cells["P_ID"].Value != null ? row.Cells["P_ID"].Value.ToString() : "";
                            temp.AMOUNT = int.Parse(row.Cells["Quantity"].Value.ToString()) * -1;
                            temp.TYPE_CODE = 4;
                            temp.STORE_CODE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                            temp.ZONE_CODE = "";
                            temp.GENERATE_CODE = invoice;
                            temp.EVENT_ID = tempevent;
                            temp.WAREHOUSE = null;
                            temp.Save(true);
                        }
                    }

                    //
                    float tiendc = cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text);
                    float tongvat = (float)((tong + tiendc) * 1.1);
                    string productevent = add == false ? epsEventId : GetAutoCode("BK_EVENT_STACK_TABLE", "EVENT_ID", System.Environment.MachineName + "-" + UserImformation.DeptCode + "-" + SqlDAC.GetDateTimeServer().ToString("yy") + "-");
                    CreateEvent(productevent, "EXPORT_PRODUCT_STORE", "", add == true ? 1 : 2);

                    //Sửa EXPORT_PRODUCT_STORE
                    EXPORT_PRODUCT_STORE exs = new EXPORT_PRODUCT_STORE();
                    exs.EXPORT_STORE_ID = invoice;
                    exs.DATE_EXPORT = exportDate;
                    exs.REMARKS = txtNote.Text;
                    exs.UPDATE_BY = add == true ? null : UserImformation.UserName;
                    exs.DATE_UPDATE = add == true ? DateTime.Parse("1753-01-01") : DateTime.Now;

                    if (add == true)
                    {
                        exs.INVOICE_CODE = null;
                        exs.FROM_STORE = UserImformation.DeptCode + "@" + UserImformation.StoreCode + "@" + UserImformation.BusinessTypeCode;
                        exs.EXPORT_TYPE = cboExportType.SelectedIndex == 1 ? 1 : 3;
                        exs.EXPORT_TO = null;
                        exs.CREATE_BY = UserImformation.UserName;
                        exs.DATE_CREATE = SqlDAC.GetDateTimeServer();
                        exs.EVENT_ID = productevent;
                        exs.IS_IMPORT_DEBT = cbxDebt.Checked;
                        exs.EMPLOYEE_ID = null;
                        exs.INVOICE_NO = "";
                        exs.POCO_NUMBER = "";
                        exs.SO_NOI_BO = "";
                        exs.ORDER_DATE = DateTime.Parse("1753-01-01");
                        exs.SOTIENDC = 0;
                        exs.GHICHUDC = "";
                        switch (cboExportType.SelectedIndex)
                        {
                            case 0:
                                exs.EXPORT_TYPE_CODE = "ETY.0001";
                                break;
                            case 1:
                                exs.EXPORT_TYPE_CODE = "ETY.0002";
                                break;
                            case 2:
                                exs.EXPORT_TYPE_CODE = "ETY.0003";
                                break;
                        }
                    }
                    if (cboExportType.SelectedIndex == 1)
                    {
                        exs.INVOICE_NO = txtContract.Text;
                        exs.POCO_NUMBER = txtPONo.Text;
                        exs.SO_NOI_BO = txtInternal.Text;
                        exs.ORDER_DATE = dtpContractDate.Value;
                        exs.SOTIENDC = tiendc;
                        exs.GHICHUDC = txtContent.Text;
                    }
                    exs.Save(add);
                    //
                    if (cboExportType.SelectedIndex == 1)
                    {
                        if (add == true)
                        {
                            CN_HOADON_Update(txtContract.Text.Trim(), 0, tongvat);
                        }
                        else
                        {
                            CN_HOADON_Update(txtContract.Text.Trim(), oldtotal, tongvat);
                        }
                    }
                    //
                    msg = add == true ? Properties.rsfExportManagement.Export4.ToString() : Properties.rsfExportManagement.Export5.ToString();
                    MessageBox.Show(msg, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    if (add == true)
                    {
                        ListViewItem lvItem = new ListViewItem(exportDate.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour));
                        lvItem.SubItems.Add(invoice);
                        lvItem.SubItems.Add(totalquantity.ToString());
                        lvItem.SubItems.Add(totalprice.ToString(AppConfigFileSettings.strOptCurency));
                        int n = lvwExportPro.Items.Add(lvItem).Index;
                        lvwExportPro.Items[n].Selected = true;
                        for (int i = 0; i < lvwExportPro.Items.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                lvwExportPro.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                            }
                            else
                            {
                                lvwExportPro.Items[i].BackColor = Color.White;
                            }
                        }
                    }
                    add = false;
                    FormSearch();
                    LoadInvoice(invoice);
                    //SearchInvoiceCode(dFrom, dTo, sID, sType,false);
                    this.ActiveControl = txtExportCodeSearch;
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
                LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
                if (txtContract.ReadOnly == false && (txtContract.Text == null || txtContract.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfExportManagement.SoHD.ToString(),translate["Msg.TitleDialog"],MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtInternal.ReadOnly == false && (txtInternal.Text == null || txtInternal.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfExportManagement.SoNoiBo.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtPONo.ReadOnly == false && (txtPONo.Text == null || txtPONo.Text.Trim() == ""))
                {
                    MessageBox.Show(Properties.rsfExportManagement.SoPo.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                float f = 0;
                float.TryParse(txtMoney.Text, out f);
                if (txtContent.ReadOnly == false && (txtContent.Text == null || txtContent.Text.Trim() == "") && f > 0)
                {
                    MessageBox.Show(Properties.rsfExportManagement.DienGiai.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dtpExportDate.Value.Date > DateTime.Now)
                {
                    MessageBox.Show(Properties.rsfExportManagement.NgayNhap.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtContract.ReadOnly == false && txtInternal.ReadOnly == false && txtPONo.ReadOnly == false && dtpContractDate.Enabled == true)
                {
                    string query = "select * from EXPORT_PRODUCTS where RED_INVOICE_NO = @RED_INVOICE_NO";
                    SqlParameter[] sqlPara = new SqlParameter[1];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_NO", SqlDbType.VarChar, txtContract.Text.Trim());
                    DataSet ds = SqlDAC.InlineSql_Execute(query, sqlPara);
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfExportManagement.Export10.ToString(), txtContract.Text.Trim()), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);                        
                        return false;
                    }
                    else
                    {
                        DateTime od = (DateTime)ds.Tables[0].Rows[0]["OrderDate"];
                        string snb = ds.Tables[0].Rows[0]["SoNoiBo"].ToString();
                        string po = ds.Tables[0].Rows[0]["POCONumber"].ToString();
                        if (od.Date != dtpContractDate.Value.Date)
                        {
                            MessageBox.Show(Properties.rsfExportManagement.cNgayHD.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return false;
                        }
                        if (!snb.Equals(txtInternal.Text.Trim()))
                        {
                            MessageBox.Show(Properties.rsfExportManagement.cSoNoiBo.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return false;
                        }
                        if (!po.Equals(txtPONo.Text.Trim()))
                        {
                            MessageBox.Show(Properties.rsfExportManagement.cSoPo.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return false;
                        }
                    }
                }
                if (int.Parse(lblDong.Text) == 0)
                {
                    MessageBox.Show(Properties.rsfExportManagement.SanPham.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
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
                    if (flag == false)
                    {
                        MessageBox.Show(Properties.rsfExportManagement.SanPham.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    else
                    {
                        if (e > 0)
                        {                            
                            var confirmMsg = MessageBox.Show(string.Format(Properties.rsfExportManagement.Export11.ToString(), e), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
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
                            dr["Price"] = row["Price"];
                            dr["ProductName"] = row["ProductName"];
                            dr["Unit"] = row["UnitName"];
                            dr["P_ID"] = "";
                            dtProduct.Rows.Add(dr);
                        }
                    }
                    LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
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
                txtExportCodeSearch.Enabled = false;
                cboExportTypeCode.Enabled = false;
                dtpDateTo.Enabled = false;
                dtpDateFrom.Enabled = false;
                btnSearch.Enabled = false;
                lvwExportPro.Enabled = false;
                btnInventory.Enabled = true;
                btnCodeScaner.Enabled = true;

                txtExportCode.Text = "";
                txtContract.Text = "";
                txtInternal.Text = "";
                txtPONo.Text = "";
                txtNote.Text = "";
                txtContent.Text = "";
                txtMoney.Text = "0";
                dtpExportDate.Value = SqlDAC.GetDateTimeServer();
                dtpExportTime.Value = SqlDAC.GetDateTimeServer();
                dtpContractDate.Value = SqlDAC.GetDateTimeServer();
                DataTable dtProduct = dgvProduct.DataSource as DataTable;
                dtProduct.Rows.Clear();
                LoadTotal(0);

                txtPONo.ReadOnly = true;
                txtContent.ReadOnly = true;
                txtNote.ReadOnly = false;
                txtContract.ReadOnly = true;
                txtInternal.ReadOnly = true;
                txtMoney.ReadOnly = true;
                dtpContractDate.Enabled = false;
                cboTypeAdjust.Enabled = false;
                cboTypeAdjust.SelectedIndex = 0;
                cboExportType.Enabled = true;
                cboExportType.SelectedIndex = 0;
                cbxDebt.Enabled = false;
                cbxDebt.Checked = false;
                cbxDebt.Visible = false;
                dgvProduct.AllowUserToAddRows = true;
                dgvProduct.AllowUserToDeleteRows = true;
                dgvProduct.ReadOnly = false;
                dgvProduct.Columns[3].ReadOnly = true;
                dgvProduct.Columns[4].ReadOnly = true;
                this.ActiveControl = txtContract;
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
                txtExportCodeSearch.Enabled = true;
                cboExportTypeCode.Enabled = true;
                dtpDateTo.Enabled = true;
                dtpDateFrom.Enabled = true;
                btnSearch.Enabled = true;
                lvwExportPro.Enabled = true;
                btnInventory.Enabled = false;
                btnCodeScaner.Enabled = false;

                txtPONo.ReadOnly = true;
                txtContent.ReadOnly = true;
                txtNote.ReadOnly = true;
                txtContract.ReadOnly = true;
                txtInternal.ReadOnly = true;
                txtMoney.ReadOnly = true;
                dtpContractDate.Enabled = false;
                cboTypeAdjust.Enabled = false;
                cboExportType.Enabled = false;
                cbxDebt.Enabled = false;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.AllowUserToDeleteRows = false;
                dgvProduct.ReadOnly = true;

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
                txtExportCodeSearch.Enabled = false;
                cboExportTypeCode.Enabled = false;
                dtpDateTo.Enabled = false;
                dtpDateFrom.Enabled = false;
                btnSearch.Enabled = false;
                lvwExportPro.Enabled = false;
                btnInventory.Enabled = true;
                btnCodeScaner.Enabled = true;

                dgvProduct.AllowUserToAddRows = true;
                dgvProduct.AllowUserToDeleteRows = true;
                dgvProduct.ReadOnly = false;
                dgvProduct.Columns[3].ReadOnly = true;
                dgvProduct.Columns[4].ReadOnly = true;
                txtNote.ReadOnly = false;

                if (cboExportType.SelectedIndex == 1)
                {
                    dtpContractDate.Enabled = true;
                    txtContract.ReadOnly = false;
                    txtInternal.ReadOnly = false;
                    txtPONo.ReadOnly = false;
                    txtContent.ReadOnly = false;
                    txtMoney.ReadOnly = false;
                    cboTypeAdjust.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'FormEdit' : " + ex.Message);
            }
        }
        //
        private void CN_HOADON_Update(string sohd,float oldtotal, float newtotal)
        {
            try
            {                
                SqlParameter[] para = new SqlParameter[1] { posdb_vnmSqlDAC.newInParam("@SoHD", SqlDbType.VarChar, sohd) };
                DataTable dt = SqlDAC.GetDataTable("CN_HoaDon_Read", para);

                if (dt.Rows.Count > 0)
                {
                    float conlai = float.Parse(dt.Rows[0]["ConLai"].ToString());
                    conlai = conlai + oldtotal - newtotal;
                    string query = "update CN_HoaDon set ConLai = @ConLai where SoHD = @SoHD";
                    para = new SqlParameter[2];
                    para[0] = posdb_vnmSqlDAC.newInParam("@SoHD", SqlDbType.VarChar, sohd);
                    para[1] = posdb_vnmSqlDAC.newInParam("@ConLai", SqlDbType.Float, conlai);
                    SqlDAC.InlineSql_ExecuteNonQuery(query, para);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'CN_HOADON_Update' : " + ex.Message);
            }
        }
        //Tạo EVENT_log, autoID
        private void CreateEvent(string id, string table, string col, int type)
        {
            try
            {
                string proc = "BK_EVENT_STACK_TABLE_Create";
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
                log.Error("Error 'CreateEvent' : " + ex.Message);
            }
        }
        public string GetAutoCode(string table, string col, string prefix)
        {
            string result = "";
            try
            {
                SqlParameter[] para = new SqlParameter[3];
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

        #region Event
        private void frmGoodsDelivery_Load(object sender, EventArgs e)
        {
            try
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(new bool[] { true, false, true, false, true, true, false, false, false, false, true, true });
                status = new bool[] { true, false, true, false, true, true, false, false, false, false, true, true };
                DateTime dt = SqlDAC.GetDateTimeServer();
                dtpDateFrom.Value = new DateTime(dt.Year, dt.Month, 1);
                dtpDateTo.Value = dt;
                dtpExportDate.Value = dt;
                dtpExportTime.Value = dt;
                dtpContractDate.Value = dt;
                this.ActiveControl = txtExportCodeSearch;

                dFrom = (dtpDateFrom.Checked) ? dtpDateFrom.Value.Date : Convert.ToDateTime("1900/01/01");
                dTo = (dtpDateTo.Checked) ? dtpDateTo.Value.Date.AddMinutes(1439) : Convert.ToDateTime("9999/01/01");
                sType = cboExportTypeCode.SelectedIndex;
                sID = txtExportCodeSearch.Text;

                DataTable dtProduct = new DataTable();
                dtProduct.Columns.Add("ProductId", typeof(string));
                dtProduct.Columns.Add("Quantity", typeof(int));
                dtProduct.Columns.Add("Price", typeof(float));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("Unit", typeof(string));
                dtProduct.Columns.Add("P_ID", typeof(string));
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = dtProduct;
                if (crossload == true)
                {
                    main.ActiveMenu(new bool[] { false, true, false, true, false, false, false, false, false, false, true, true });
                    status = new bool[] { false, true, false, true, false, false, false, false, false, false, true, true };
                    FormAdd();
                    add = true;

                    cboExportType.SelectedIndex = 0;
                    dgvProduct.DataSource = crossdt;
                    LoadTotal(0);
                }

                dtpContractDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpDateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpExportDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
                dtpExportTime.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
                this.Price.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
                this.Quantity.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;

                //Check quyen 
                
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmExportToStore' ";
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
                log.Error("Error 'frmXuatHang_Load' : " + ex.Message);
            }
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
                        float f = cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text);
                        oldtotal = (float.Parse(lblTongTT.Text) + f) * (float)1.1;
                        frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                        main.ActiveMenu(new bool[] { false, true, false, true, false, false, false, false, false, false, true, true });
                        status = new bool[] { false, true, false, true, false, false, false, false, false, false, true, true };
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
            EditInvoice(txtExportCode.Text);
        }
        private void Cancel(object sender, EventArgs e)
        {
            try
            {
                add = false;
                FormSearch();
                if (txtExportCode.Text != null && txtExportCode.Text.Trim() != "")
                {
                    LoadInvoice(txtExportCode.Text);
                }
                else
                {
                    if (lvwExportPro.SelectedItems.Count > 0)
                    {
                        LoadInvoice(lvwExportPro.SelectedItems[0].SubItems[1].Text);
                    }
                    else
                    {                        
                        DataTable dtProduct = new DataTable();
                        dtProduct.Columns.Add("ProductId", typeof(string));
                        dtProduct.Columns.Add("Quantity", typeof(int));
                        dtProduct.Columns.Add("Price", typeof(float));
                        dtProduct.Columns.Add("ProductName", typeof(string));
                        dtProduct.Columns.Add("Unit", typeof(string));
                        dtProduct.Columns.Add("P_ID", typeof(string));
                        dgvProduct.AutoGenerateColumns = false;
                        dgvProduct.DataSource = dtProduct;

                        //DataTable dtProduct = dgvProduct.DataSource as DataTable;                        
                        //dtProduct.Rows.Clear();
                        txtExportCode.Text = "";
                        txtContract.Text = "";
                        txtInternal.Text = "";
                        txtPONo.Text = "";
                        txtNote.Text = "";
                        txtContent.Text = "";
                        txtMoney.Text = "0";
                        dtpExportDate.Value = SqlDAC.GetDateTimeServer();
                        dtpExportTime.Value = SqlDAC.GetDateTimeServer();
                        dtpContractDate.Value = SqlDAC.GetDateTimeServer();
                        LoadTotal(0);
                        if (lvwExportPro.Items.Count > 0)
                            lvwExportPro.Items[0].Selected = true;
                    }
                }
                this.ActiveControl = txtExportCodeSearch;                
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(new bool[] { true, false, true, false, true, true, false, false, false, false, true, true });
                status = new bool[] { true, false, true, false, true, true, false, false, false, false, true, true };
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
                        float f = cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text);
                        oldtotal = (float.Parse(lblTongTT.Text) + f) * (float)1.1;

                        var confirmMsg = MessageBox.Show(Properties.rsfExportManagement.Export6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (confirmMsg == DialogResult.Yes)
                        {
                            ExportProcess.DeleteInvoice(txtExportCode.Text);
                            if (cboExportType.SelectedIndex == 1)
                            {
                                CN_HOADON_Update(txtContract.Text.Trim(), oldtotal, 0);
                            }
                            int index = lvwExportPro.SelectedItems[0].Index;
                            lvwExportPro.Items.RemoveAt(index);
                            for (int i = 0; i < lvwExportPro.Items.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    lvwExportPro.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                                }
                                else
                                {
                                    lvwExportPro.Items[i].BackColor = Color.White;
                                }
                            }
                            txtExportCode.Text = "";
                            txtContract.Text = "";
                            txtInternal.Text = "";
                            txtPONo.Text = "";
                            txtNote.Text = "";
                            txtContent.Text = "";
                            txtMoney.Text = "0";
                            dtpExportDate.Value = SqlDAC.GetDateTimeServer();
                            dtpExportTime.Value = SqlDAC.GetDateTimeServer();
                            dtpContractDate.Value = SqlDAC.GetDateTimeServer();
                            DataTable dtProduct = dgvProduct.DataSource as DataTable;
                            dtProduct.Rows.Clear();
                            LoadTotal(0);
                            //SearchInvoiceCode(dFrom, dTo, sID, sType,false);
                            FormSearch();
                            //if (lvwExportPro.Items.Count > 0)
                            //    lvwExportPro.Items[0].Selected = true;
                            index = index > 0 ? index - 1 : 0;
                            if (lvwExportPro.Items.Count > index)
                            {
                                lvwExportPro.Items[index].Selected = true;
                            }
                        }
                    }
                    this.ActiveControl = txtExportCodeSearch;
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
                ExportProcess.PrintInvoice(txtExportCode.Text);
            }
        
        }
        //
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách tồn kho
        /// </summary>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.DataSource = ExportProcess.GetInventoryTemp();
                LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
                //if (dgvProduct.RowCount > 0)
                //{
                //    foreach (DataGridViewRow row in dgvProduct.Rows)
                //    {
                //        if (row.Cells["Quantity"].Value != null && row.Cells["Quantity"].Value != DBNull.Value && row.Cells["Quantity"].Value.ToString() != "")
                //        {
                //            if (int.Parse(row.Cells["Quantity"].Value.ToString()) < 0)
                //                dgvProduct.Rows[row.Index].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Red };
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnInventory_Click' : " + ex.Message);
            }
        }
        //
        private void btnCodeScaner_Click(object sender, EventArgs e)
        {
            ImportBarcodeScan();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dFrom = (dtpDateFrom.Checked) ? dtpDateFrom.Value.Date : Convert.ToDateTime("1900/01/01");
                dTo = (dtpDateTo.Checked) ? dtpDateTo.Value.Date.AddMinutes(1439) : Convert.ToDateTime("9999/01/01");
                sType = cboExportTypeCode.SelectedIndex;
                sID = txtExportCodeSearch.Text;
                SearchInvoiceCode(dFrom, dTo, sID, sType,true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnTimKiem_Click' : " + ex.Message);
            }
        }
        private void lvwExportPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string storeid = null;
                ListView.SelectedListViewItemCollection selected = lvwExportPro.SelectedItems;
                foreach (ListViewItem i in selected)
                {
                    storeid = i.SubItems[1].Text;
                    LoadInvoice(storeid);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'lvDanhSach_SelectedIndexChanged' : " + ex.Message);
            }
        }
        private void cboExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (add == true)
                {
                    if (cboExportType.SelectedIndex == 1)
                    {
                        cbxDebt.Visible = true;
                        cbxDebt.Enabled = true;
                        cbxDebt.Checked = true;
                        txtContract.ReadOnly = false;
                        txtInternal.ReadOnly = false;
                        txtPONo.ReadOnly = false;
                        txtContent.ReadOnly = false;
                        txtMoney.ReadOnly = false;
                        cboTypeAdjust.Enabled = true;
                        dtpContractDate.Enabled = true;
                    }
                    if (cboExportType.SelectedIndex == 0 || cboExportType.SelectedIndex == 2)
                    {
                        cbxDebt.Visible = false;
                        cbxDebt.Enabled = false;
                        cbxDebt.Checked = false;
                        txtContract.ReadOnly = true;
                        txtInternal.ReadOnly = true;
                        txtPONo.ReadOnly = true;
                        txtContent.ReadOnly = true;
                        txtMoney.ReadOnly = true;
                        cboTypeAdjust.Enabled = false;
                        dtpContractDate.Enabled = false;

                        txtContract.Text = "";
                        txtInternal.Text = "";
                        txtPONo.Text = "";
                        txtContent.Text = "";
                        txtMoney.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'cbxLoaiXuatDetail_SelectedIndexChanged' : " + ex.Message);
            }
        }
        //
        private void lvwExportPro_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lvwExportPro.Sort();
            for (int i = 0; i < lvwExportPro.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lvwExportPro.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                }
                else
                {
                    lvwExportPro.Items[i].BackColor = Color.White;
                }
            }
        }
        private void dgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvProduct.RowCount > 0)
            {
                //dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;                
                e.Cancel = false;
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thêm/sửa/xóa sản phẩm trên gridview
        /// </summary>
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "Quantity" || dgvProduct.Columns[e.ColumnIndex].Name == "Price")
                    {
                        float price = 0;
                        float quantity = 1;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null
                            ||dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()==""|| !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Price"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Price"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["Price"].Value.ToString() == ""||!float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Price"].Value.ToString(), out price))
                            dgvProduct.Rows[e.RowIndex].Cells["Price"].Value = 0;

                        if (quantity == 0)
                        {
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                            quantity = 1;
                        }

                        LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
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
                                float price = float.Parse(tb.Rows[0]["PRICE"].ToString()) * (float)1.1;
                                dgvProduct.Rows[e.RowIndex].Cells["colProductName"].Value = tb.Rows[0]["PRODUCT_NAME"].ToString();
                                dgvProduct.Rows[e.RowIndex].Cells["Price"].Value = cboExportType.SelectedIndex != 1 ? float.Parse(tb.Rows[0]["PRICEDEV"].ToString()) : float.Parse(tb.Rows[0]["PRICE"].ToString());
                                dgvProduct.Rows[e.RowIndex].Cells["Unit"].Value = tb.Rows[0]["UNIT_NAME"].ToString();
                                dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "" ? 1 : dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value;
                                dgvProduct.Rows[e.RowIndex].ErrorText = string.Empty;
                            }
                            else
                            {
                                dgvProduct.Rows[e.RowIndex].ErrorText = "Sản phẩm không hợp lệ";
                                frmDialogProductSearch FormTKMH = new frmDialogProductSearch(dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString(), translate);
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
                LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
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
        //
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMoney.Text == null || txtMoney.Text.Trim() == "")
                {
                    txtMoney.Text = "0";
                }
                //LoadTotal(cboTypeAdjust.SelectedIndex == 0 ? float.Parse(txtMoney.Text) * -1 : float.Parse(txtMoney.Text));
                //txtSoTien.Text = Conversion.GetCurrency(txtSoTien.Text);
            }
            catch (Exception ex)
            {
                log.Error("Error 'txtMoney_TextChanged' : " + ex.Message);
                txtMoney.Text = "0";
            }
        }
        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {
                        if (row.Cells["Quantity"].Value != null && row.Cells["Quantity"].Value != DBNull.Value && row.Cells["Quantity"].Value.ToString() != "")
                        {
                            if (int.Parse(row.Cells["Quantity"].Value.ToString()) < 0)
                                dgvProduct.Rows[row.Index].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Red };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void txtMoney_Leave(object sender, EventArgs e)
        {
            float money = 0;
            if (float.TryParse(txtMoney.Text, out money))
            {
                txtMoney.Text = money.ToString(AppConfigFileSettings.strOptCurency);
            }
            else
            {
                txtMoney.Text = "0";
            }
        }
        #endregion        

        private void frmGoodsDelivery_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }




        
    }
}

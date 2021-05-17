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
using SaleMTBusiness.InventoryManagement;
using System.Text.RegularExpressions;
using System.IO;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmDialogImport : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DataTable dtHN;
        DataTable dtHKM;
        string soPO;
        string soNoiBo;
        DateTime orderDate;
        frmProgress progressExcel = new frmProgress();
        bool excel = false;
        bool detail = false;
        #endregion 

        #region Contructor
        public frmDialogImport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.btnDownloadPO.Text = translate["frmDialogImport.btnDownloadPO.Text"];
            this.tabPage3.Text = translate["frmDialogImport.tabPage3.Text"];
            this.SaleOrderNumber.HeaderText = translate["frmDialogImport.SaleOrderNumber.HeaderText"];
            this.ItemCode.HeaderText = translate["frmDialogImport.ItemCode.HeaderText"];
            this.ItemName.HeaderText = translate["frmDialogImport.ItemName.HeaderText"];
            this.Price.HeaderText = translate["frmDialogImport.Price.HeaderText"];
            this.Quantity.HeaderText = translate["frmDialogImport.Quantity.HeaderText"];
            this.Amount.HeaderText = translate["frmDialogImport.Amount.HeaderText"];
            this.Unit.HeaderText = translate["frmDialogImport.Unit.HeaderText"];
            this.tabPage4.Text = translate["frmDialogImport.tabPage4.Text"];
            this.SaleOrderNumberKM.HeaderText = translate["frmDialogImport.SaleOrderNumberKM.HeaderText"];
            this.ItemCodeKM.HeaderText = translate["frmDialogImport.ItemCodeKM.HeaderText"];
            this.ItemNameKM.HeaderText = translate["frmDialogImport.ItemNameKM.HeaderText"];
            this.PriceKM.HeaderText = translate["frmDialogImport.PriceKM.HeaderText"];
            this.QuantityKM.HeaderText = translate["frmDialogImport.QuantityKM.HeaderText"];
            this.AmountKM.HeaderText = translate["frmDialogImport.AmountKM.HeaderText"];
            this.UnitKM.HeaderText = translate["frmDialogImport.UnitKM.HeaderText"];
            this.POCONumber.HeaderText = translate["frmDialogImport.POCONumber.HeaderText"];
            this.SoNoiBo.HeaderText = translate["frmDialogImport.SoNoiBo.HeaderText"];
            this.OrderDate.HeaderText = translate["frmDialogImport.OrderDate.HeaderText"];
            this.tabPage2.Text = translate["frmDialogImport.tabPage2.Text"];
            this.chkDetail.Text = translate["frmDialogImport.chkDetail.Text"];
            this.btnSearch.Text = translate["frmDialogImport.btnSearch.Text"];
            this.btnClose.Text = translate["frmDialogImport.btnClose.Text"];
            this.btnExcel.Text = translate["frmDialogImport.btnExcel.Text"];
            this.groupBox2.Text = translate["frmDialogImport.groupBox2.Text"];
            this.label4.Text = translate["frmDialogImport.label4.Text"];
            this.label3.Text = translate["frmDialogImport.label3.Text"];
            this.label2.Text = translate["frmDialogImport.label2.Text"];
            this.label1.Text = translate["frmDialogImport.label1.Text"];
            this.btnImport.Text = translate["frmDialogImport.btnImport.Text"];
            this.btnExportExcel.Text = translate["frmDialogImport.btnExportExcel.Text"];
            this.btnExit.Text = translate["frmDialogImport.btnExit.Text"];
            this.Column1.HeaderText = translate["frmDialogImport.Column1.HeaderText"];
            this.SaleOrderNumberCol.HeaderText = translate["frmDialogImport.SaleOrderNumberCol.HeaderText"];
            this.ItemCodeCol.HeaderText = translate["frmDialogImport.ItemCodeCol.HeaderText"];
            this.PONO.HeaderText = translate["frmDialogImport.PONO.HeaderText"];
            this.SOQuantityCol.HeaderText = translate["frmDialogImport.SOQuantityCol.HeaderText"];
            this.POQuantityCol.HeaderText = translate["frmDialogImport.POQuantityCol.HeaderText"];
            this.SOPOCol.HeaderText = translate["frmDialogImport.SOPOCol.HeaderText"];
            this.NameCol.HeaderText = translate["frmDialogImport.NameCol.HeaderText"];
            this.UnitCol.HeaderText = translate["frmDialogImport.UnitCol.HeaderText"];
            this.PriceCol.HeaderText = translate["frmDialogImport.PriceCol.HeaderText"];
            this.Text = translate["frmDialogImport.Text"];
        }	

        #endregion

        #region Property
        public DataTable DTHN
        {
            set { dtHN = value; }
            get { return dtHN; }
        }
        public DataTable DTHKM
        {
            set { dtHKM = value; }
            get { return dtHKM; }
        }
        public string SOPO
        {
            set { soPO = value; }
            get { return soPO; }
        }
        public string SONOIBO
        {
            set { soNoiBo = value; }
            get { return soNoiBo; }
        }
        public DateTime ORDERDATE
        {
            set { orderDate = value; }
            get { return orderDate; }
        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách PO
        /// </summary>
        private void LoadPO()
        {
            try
            {
                string sql = "select distinct POCONumber, SoNoiBo, OrderDate from PO_DVKH where IsActive = @IsActive AND DataType = 'PO' order by POCONumber asc";
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@IsActive", SqlDbType.Bit, 1);
                DataSet ds = SqlDAC.InlineSql_Execute(sql, sqlPara);
                dgvPO.AutoGenerateColumns = false;
                dgvPO.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadPO' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin PO
        /// </summary>
        private void LoadTotal()
        {
            try
            {
                int sumSLKM = 0;
                int sumSL = 0;
                int sumTong = 0;

                for (int i = 0; i < dgvHangNhap.RowCount; i++)
                {
                    if (dgvHangNhap.Rows[i].Cells["Quantity"].Value != DBNull.Value && dgvHangNhap.Rows[i].Cells["Amount"].Value != DBNull.Value)
                    {
                        sumSL += Convert.ToInt32(dgvHangNhap.Rows[i].Cells["Quantity"].Value);
                        sumTong += Convert.ToInt32(dgvHangNhap.Rows[i].Cells["Amount"].Value);
                    }
                }
                for (int i = 0; i < dgvHangKhuyenMai.RowCount; i++)
                {
                    if (dgvHangKhuyenMai.Rows[i].Cells["QuantityKM"].Value != DBNull.Value)
                    {
                        sumSLKM += Convert.ToInt32(dgvHangKhuyenMai.Rows[i].Cells["QuantityKM"].Value);
                    }
                }
                tabPage3.Text = "Hàng nhập (SL : " + sumSL + " / T.Tiền : " + sumTong + ")";
                tabPage4.Text = "Hàng khuyến mãi (SL : " + sumSLKM + ")";
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTotal' : " + ex.Message);
            }
        }
        //
        private string ProductList()
        {
            string productlist = "";
            try
            {
                if (!string.IsNullOrEmpty(txtProductList.Text.Trim()))
                {
                    //string[] split = Regex.Split(txtProductList.Text.Trim(), ",");
                    //foreach (string p in split)
                    //{
                    //    productlist += productlist == null ? "'" + p + "'" : "," + "'" + p + "'";
                    //}
                    productlist += productlist == null ? txtProductList.Text.Trim() : "," + txtProductList.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
                {
                    productlist += productlist != null ? "," + txtProduct.Text.Trim() : txtProduct.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ProductList' : " + ex.Message);
            }
            return productlist;
        }
        //
        private void SaveExcel()
        {
            try
            {
                //float i = 100 / (float)dgvSOPO.Rows.Count;
                DataTable dt = new DataTable();
                dt.Columns.Add("SO NO.", typeof(string));
                dt.Columns.Add("MÃ SP", typeof(string));
                if (detail == true)
                {
                    dt.Columns.Add("PO NO.", typeof(string));
                }
                dt.Columns.Add("SL SO", typeof(int));
                dt.Columns.Add("SL PO", typeof(int));
                dt.Columns.Add("SO - PO", typeof(int));
                dt.Columns.Add("TÊN SP", typeof(string));
                dt.Columns.Add("ĐVT", typeof(string));
                dt.Columns.Add("GIÁ", typeof(double));
                foreach (DataGridViewRow row in dgvSOPO.Rows)
                {
                    //if (backgroundWorker1.CancellationPending == true)
                    //    return;
                    DataRow dtRow = dt.NewRow();
                    dtRow["SO NO."] = row.Cells["SaleOrderNumberCol"].Value != null ? row.Cells["SaleOrderNumberCol"].Value.ToString() : "";
                    dtRow["MÃ SP"] = row.Cells["ItemCodeCol"].Value != null ? row.Cells["ItemCodeCol"].Value.ToString() : "";
                    if (detail == true)
                    {
                        dtRow["PO NO."] = row.Cells["PONO"].Value != null ? row.Cells["PONO"].Value.ToString() : "";
                    }
                    dtRow["SL SO"] = row.Cells["SOQuantityCol"].Value != null ? row.Cells["SOQuantityCol"].Value.ToString() : "";
                    dtRow["SL PO"] = row.Cells["POQuantityCol"].Value != null ? row.Cells["POQuantityCol"].Value.ToString() : "";
                    dtRow["SO - PO"] = row.Cells["SOPOCol"].Value != null ? row.Cells["SOPOCol"].Value.ToString() : "";
                    dtRow["TÊN SP"] = row.Cells["NameCol"].Value != null ? row.Cells["NameCol"].Value.ToString() : "";
                    dtRow["ĐVT"] = row.Cells["UnitCol"].Value != null ? row.Cells["UnitCol"].Value.ToString() : "";
                    dtRow["GIÁ"] = row.Cells["PriceCol"].Value != null ? row.Cells["PriceCol"].Value.ToString() : "";
                    dt.Rows.Add(dtRow);
                    //backgroundWorker1.ReportProgress(Convert.ToInt32(i * (float)(row.Index + 1)));
                    //System.Threading.Thread.Sleep(20);
                }
                //DateTime d = SqlDAC.GetDateTimeServer();
                //string filename = "Import_Filled_" + d.ToString("yyyyMMdd_HHmmss") + ".xls";
                //if (backgroundWorker1.CancellationPending != true)
                //{
                //    SaleMTCommon.Export expExcel = new SaleMTCommon.Export();
                //    expExcel.InfoCompany = true;
                //    expExcel.InfoStore = true;
                //    expExcel.StrTitle = "SO SÁNH SO - PO";
                //    expExcel.ExportToExcel(dt, filename);
                //}
                ExportExcel exN = new ExportExcel();
                exN.InfoCompany = true;
                exN.InfoStore = true;
                exN.StrTitle = "SO SÁNH SO - PO";
                exN.Dt = dt;
                exN.CaseEx = 5;
                exN.FileNames = "Import_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                exN.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveExcel' : " + ex.Message);
            }
        }
        //
        private void POExcel()
        {
            try
            {
                //float i = 100 / (float)dgvHangNhap.Rows.Count;
                DataTable dt = new DataTable();
                dt.Columns.Add("SO NO", typeof(string));
                dt.Columns.Add("MÃ SẢN PHẨM", typeof(string));
                dt.Columns.Add("TÊN SẢN PHẨM", typeof(string));
                dt.Columns.Add("GIÁ", typeof(double));
                dt.Columns.Add("SỐ LƯỢNG", typeof(int));
                dt.Columns.Add("THÀNH TIỀN", typeof(double));
                foreach (DataGridViewRow row in dgvHangNhap.Rows)
                {
                    //if (backgroundWorker1.CancellationPending == true)
                    //    return;
                    DataRow dtRow = dt.NewRow();
                    dtRow["SO NO"] = row.Cells["SaleOrderNumber"].Value != null ? row.Cells["SaleOrderNumber"].Value.ToString() : "";
                    dtRow["MÃ SẢN PHẨM"] = row.Cells["ItemCode"].Value != null ? row.Cells["ItemCode"].Value.ToString() : "";
                    dtRow["TÊN SẢN PHẨM"] = row.Cells["ItemName"].Value != null ? row.Cells["ItemName"].Value.ToString() : "";
                    dtRow["GIÁ"] = row.Cells["Price"].Value != null ? row.Cells["Price"].Value.ToString() : "";
                    dtRow["SỐ LƯỢNG"] = row.Cells["Quantity"].Value != null ? row.Cells["Quantity"].Value.ToString() : "";
                    dtRow["THÀNH TIỀN"] = row.Cells["Amount"].Value != null ? row.Cells["Amount"].Value.ToString() : "";
                    dt.Rows.Add(dtRow);
                    //backgroundWorker1.ReportProgress(Convert.ToInt32(i * (float)(row.Index + 1)));
                    //System.Threading.Thread.Sleep(20);
                }
                //DateTime d = SqlDAC.GetDateTimeServer();
                //string filename = "_Filled_" + d.ToString("yyyyMMdd_HHmmss") + ".xls";
                //if (backgroundWorker1.CancellationPending != true)
                //{
                //    SaleMTCommon.Export expExcel = new SaleMTCommon.Export();
                //    expExcel.InfoCompany = true;
                //    expExcel.InfoStore = true;
                //    expExcel.StrTitle = "DANH SÁCH DỮ LIỆU";
                //    expExcel.ExportToExcel(dt, filename);
                //}
                ExportExcel exN = new ExportExcel();
                exN.InfoCompany = true;
                exN.InfoStore = true;
                exN.StrTitle = "DANH SÁCH DỮ LIỆU";
                exN.Dt = dt;
                exN.CaseEx = 5;
                exN.FileNames = "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                exN.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error 'POExcel' : " + ex.Message);
            }
        }
        //
        private void DownloadPO()
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
                        if (intStoreCodeInd >= 0)
                        {
                            listFileName.Add(detailDirectoryListing[i]);
                        }
                    }
                }
                SaleMTCommon.frmProcessFTP download = new SaleMTCommon.frmProcessFTP();
                download.ListFiles = listFileName;
                download.IsUpload = false;
                download.ShowDialog();

                //
                string path = "";
                string[] xmlFiles = System.IO.Directory.GetFiles(UserImformation.ClientImportPath, "*.xml");
                foreach (string file in xmlFiles)
                {
                    //path = file.Contains(UserImformation.DeptCode + "_Imp_PO_") ? file : path;
                    if (file.Contains(UserImformation.DeptCode + "_Imp_PO_"))
                    {
                        path = file;
                        List<PO_DVKH> listDVKH = new List<PO_DVKH>();
                        DataSet dsPO = new DataSet();
                        dsPO.ReadXml(path);

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
                                        poDVKH.CreateDate = SqlDAC.GetDateTimeServer();
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
                            SqlDAC.Execute("PO_DVKH_CheckExistAndDelete", sqlPara);
                        }
                        //
                        foreach (PO_DVKH poDVKH in listDVKH)
                            poDVKH.Save(true);
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }


                    if (file.Contains(UserImformation.DeptCode + "_Imp_SO_"))
                    {
                        path = file;
                        List<PO_DVKH> listDVKH = new List<PO_DVKH>();
                        DataSet dsSO = new DataSet();
                        dsSO.ReadXml(path);

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
                                poDVKH.CreateDate = SqlDAC.GetDateTimeServer();
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
                            SqlDAC.Execute("PO_DVKH_CheckExistAndDelete", sqlPara);
                        }
                        //
                        foreach (PO_DVKH poDVKH in listDVKH)
                            poDVKH.Save(true);
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }
                }                    
                //
                LoadPO();
            }
            catch (Exception ex)
            {
                log.Error("Error 'DownloadPO' : " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void frmNhapHangImport_Load(object sender, EventArgs e)
        {
            DateTime dt = SqlDAC.GetDateTimeServer();
            dtpDateFrom.Value = new DateTime(dt.Year, dt.Month, 1);
            dtpDateTo.Value = dt;
            LoadPO();
            this.OrderDate.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.Price.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.PriceKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.Quantity.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
            this.QuantityKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
            this.Amount.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.AmountKM.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.SOQuantityCol.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
            this.POQuantityCol.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
            this.SOPOCol.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;
            this.PriceCol.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
        }
        private void dgvPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
            {
                soPO = dgvPO.Rows[e.RowIndex].Cells["POCONumber"].Value.ToString();
                soNoiBo = dgvPO.Rows[e.RowIndex].Cells["SoNoiBo"].Value.ToString();
                orderDate = DateTime.Parse(dgvPO.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString());

                string proc = "PO_DVKH_GetListPODetail";
                SqlParameter[] sqlPara = new SqlParameter[2];

                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PONumber", SqlDbType.VarChar, soPO);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Price2", SqlDbType.Decimal, 0);
                DataTable dtHangNhap = new DataTable();
                dtHangNhap = SqlDAC.GetDataTable(proc, sqlPara);
                dgvHangNhap.AutoGenerateColumns = false;
                dgvHangNhap.DataSource = dtHangNhap;

                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PONumber", SqlDbType.VarChar, soPO);
                sqlPara[1] = posdb_vnmSqlDAC.newInParam("@Price1", SqlDbType.Decimal, 0);
                DataTable dtHangKhuyenMai = new DataTable();
                dtHangKhuyenMai = SqlDAC.GetDataTable(proc, sqlPara);
                dgvHangKhuyenMai.AutoGenerateColumns = false;
                dgvHangKhuyenMai.DataSource = dtHangKhuyenMai;

                LoadTotal();
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dgvHangNhap.Rows.Count > 0 || dgvHangKhuyenMai.Rows.Count > 0)
            {
                dtHN = dgvHangNhap.DataSource as DataTable;
                dtHKM = dgvHangKhuyenMai.DataSource as DataTable;
                this.DialogResult = DialogResult.OK;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            dlgChooseProduct dlgChoose = new dlgChooseProduct(translate);
            dlgChoose.StartPosition = FormStartPosition.CenterScreen;
            dlgChoose.ShowDialog();
            if (dlgChoose.SoEnResult != null)
            {
                txtProductList.Text = dlgChoose.SoEnResult.ListProduct;
            }
        }
        private void lblProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
                    {
                        string p = "";
                        List<PRODUCTS> listP = PRODUCTS.ReadByPRODUCT_ID(txtProduct.Text.Trim());
                        if (listP.Count > 0)
                        {
                            p = txtProduct.Text.Trim().ToUpper();
                            txtProduct.Text = "";
                        }
                        else
                        {
                            frmDialogProductSearch frmProduct = new frmDialogProductSearch(txtProduct.Text.Trim(), translate);
                            if (frmProduct.ShowDialog(this) == DialogResult.OK)
                            {
                                p = frmProduct.ProductID.ToUpper();
                                txtProduct.Text = "";
                            }
                        }
                        if (!txtProductList.Text.Contains(p) && p != "")
                            txtProductList.Text += txtProductList.Text != "" ? "," + p : p;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error : 'lblProduct_KeyDown'" + ex.Message);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductList.Text = "";
            txtProduct.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDetail.Checked == false)
                {
                    detail = false;
                    this.PONO.Visible = false;
                    string soNumber = string.IsNullOrEmpty(txtSO.Text.Trim()) ? null : "%" + txtSO.Text.Trim() + "%";
                    string listProduct = ProductList();
                    SqlParameter[] sqlPara = new SqlParameter[4];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SALEORDERNUMBER", SqlDbType.VarChar, soNumber);
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@LIST_PRODUCT", SqlDbType.VarChar, listProduct);
                    sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dtpDateFrom.Value.Date);
                    sqlPara[3] = posdb_vnmSqlDAC.newInParam("@DATETo", SqlDbType.DateTime, dtpDateTo.Value.Date.AddMinutes(1439));

                    DataTable dt = SqlDAC.GetDataTable("PO_DVKH_GetSOPO", sqlPara);
                    dt.Columns.Add("SOPO", typeof(int), "SOQuantity - POQuantity");
                    groupBox2.Text = dt.Rows.Count > 0 ? "Tổng cộng: " + dt.Rows.Count + " dòng dữ liệu khác nhau" : "Không có dữ liệu khác nhau";
                    btnExcel.Enabled = dt.Rows.Count > 0 ? true : false;
                    dgvSOPO.AutoGenerateColumns = false;
                    dgvSOPO.DataSource = dt;
                }
                else if (chkDetail.Checked == true)
                {
                    detail = true;
                    this.PONO.Visible = true;
                    string soNumber = string.IsNullOrEmpty(txtSO.Text.Trim()) ? null : "%" + txtSO.Text.Trim() + "%";
                    string listProduct = ProductList();
                    SqlParameter[] sqlPara = new SqlParameter[4];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@SALEORDERNUMBER", SqlDbType.VarChar, soNumber);
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@LIST_PRODUCT", SqlDbType.VarChar, listProduct);
                    sqlPara[2] = posdb_vnmSqlDAC.newInParam("@DATEFROM", SqlDbType.DateTime, dtpDateFrom.Value.Date);
                    sqlPara[3] = posdb_vnmSqlDAC.newInParam("@DATETo", SqlDbType.DateTime, dtpDateTo.Value.Date.AddMinutes(1439));

                    DataTable dt = SqlDAC.GetDataTable("PO_DVKH_GetSOPODetail", sqlPara);
                    dt.Columns.Add("SOPO", typeof(int), "SOQuantity - POQuantityTemp");
                    groupBox2.Text = dt.Rows.Count > 0 ? "Tổng cộng: " + dt.Rows.Count + " dòng dữ liệu khác nhau" : "Không có dữ liệu khác nhau";
                    btnExcel.Enabled = dt.Rows.Count > 0 ? true : false;
                    dgvSOPO.AutoGenerateColumns = false;
                    dgvSOPO.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnSearch_Click' : " + ex.Message);
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSOPO.DataSource != null && dgvSOPO.Rows.Count > 0)
                {
                    SaveExcel();
                }
                //if (backgroundWorker1.IsBusy != true)
                //{
                //    if (dgvSOPO.DataSource != null && dgvSOPO.Rows.Count > 0)
                //    {
                //        excel = true;
                //        backgroundWorker1.RunWorkerAsync();
                //        progressExcel = new frmProgress();
                //        progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundCancel);
                //        progressExcel.StartPosition = FormStartPosition.CenterScreen;
                //        progressExcel.ShowDialog(this);
                        
                //    }
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnExcel_Click' : " + ex.Message);
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHangNhap.DataSource != null && dgvHangNhap.Rows.Count > 0)
                {
                    POExcel();
                }
                //if (backgroundWorker1.IsBusy != true)
                //{
                //    if (dgvHangNhap.DataSource != null && dgvHangNhap.Rows.Count > 0)
                //    {
                //        excel = false;
                //        backgroundWorker1.RunWorkerAsync();
                //        progressExcel = new frmProgress();
                //        progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundCancel);
                //        progressExcel.StartPosition = FormStartPosition.CenterScreen;
                //        progressExcel.ShowDialog(this);
                        
                //    }
                //}
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnExcel_Click' : " + ex.Message);
            }
        }
        private void dgvSOPO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    int i = 0;
                    foreach (DataGridViewRow r in dgvSOPO.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            DataGridViewCellStyle bgcolor = dgvSOPO.DefaultCellStyle.Clone();
                            bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                            bgcolor.ForeColor = Color.MidnightBlue;
                            r.DefaultCellStyle = bgcolor;
                        }
                        if (r.Cells["SOPOCol"].Value != null && (int)r.Cells["SOPOCol"].Value < 0)
                        {
                            DataGridViewCellStyle bgcolor = dgvSOPO.DefaultCellStyle.Clone();
                            bgcolor.BackColor = Color.Yellow;
                            bgcolor.ForeColor = Color.Red;
                            r.Cells["SOPOCol"].Style = bgcolor;
                        }
                        if (r.Cells["SOPOCol"].Value != null && (int)r.Cells["SOPOCol"].Value > 0)
                        {
                            DataGridViewCellStyle bgcolor = dgvSOPO.DefaultCellStyle.Clone();
                            bgcolor.BackColor = i % 2 == 0 ? Color.FromArgb(224, 223, 227) : Color.White;
                            bgcolor.ForeColor = Color.Red;
                            r.Cells["SOPOCol"].Style = bgcolor;
                        }
                        if (r.Cells["SOPOCol"].Value != null && (int)r.Cells["SOPOCol"].Value == 0)
                        {
                            DataGridViewCellStyle bgcolor = dgvSOPO.DefaultCellStyle.Clone();
                            bgcolor.BackColor = Color.Green;
                            r.Cells["SOPOCol"].Style = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void dgvPO_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void BackgroundCancel(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                progressExcel.Close();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (excel == true)
            {
                SaveExcel();
            }
            else
            {
                POExcel();
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressExcel.Message = "Exporting " + e.ProgressPercentage.ToString() + " of 100%";
            progressExcel.Progress = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressExcel.Close();
        }
        #endregion        

        private void btnDownloadPO_Click(object sender, EventArgs e)
        {
            DownloadPO();
        }
        
    }
}

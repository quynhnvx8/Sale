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
using SaleMTInterfaces.FrmInventoryManagement;


namespace SaleMTInterfaces.FrmUtilities
{
    public partial class frmBarcodeScaner : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtProduct = new DataTable();
        private bool groupExcel = false;
        frmProgress progressExcel = null;
        #endregion

        #region Property
        public DataTable DTProduct
        {
            get { return dtProduct; }            
        }
        #endregion

        #region Contructor
        public frmBarcodeScaner(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        public frmBarcodeScaner(bool ok)
        {
            InitializeComponent();
            btnOK.Enabled = ok;
        }

        private void initLanguage()
        {
            this.label1.Text = translate["frmBarcodeScaner.label1.Text"];
            this.label14.Text = translate["frmBarcodeScaner.label14.Text"];
            this.groupBox3.Text = translate["frmBarcodeScaner.groupBox3.Text"];
            this.label7.Text = translate["frmBarcodeScaner.label7.Text"];
            this.btnExportData.Text = translate["frmBarcodeScaner.btnExportData.Text"];
            this.btnExportGroup.Text = translate["frmBarcodeScaner.btnExportGroup.Text"];
            this.btnDelete.Text = translate["frmBarcodeScaner.btnDelete.Text"];
            this.btnClose.Text = translate["frmBarcodeScaner.btnClose.Text"];
            this.BarCode.HeaderText = translate["frmBarcodeScaner.BarCode.HeaderText"];
            this.ProductID.HeaderText = translate["frmBarcodeScaner.ProductID.HeaderText"];
            this.colProductName.HeaderText = translate["frmBarcodeScaner.colProductName.HeaderText"];
            this.UnitName.HeaderText = translate["frmBarcodeScaner.UnitName.HeaderText"];
            this.Quantity.HeaderText = translate["frmBarcodeScaner.Quantity.HeaderText"];
            this.Price.HeaderText = translate["frmBarcodeScaner.Price.HeaderText"];
            this.TotalPrice.HeaderText = translate["frmBarcodeScaner.TotalPrice.HeaderText"];
            this.Text = translate["frmBarcodeScaner.Text"];
        }	

        #endregion

        #region Method
        private void AddPriceList()
        {
            try
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = "Bảng giá hệ thống POS";
                item.Value = 1;
                cbxPrice.Items.Add(item);
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddPriceList' : " + ex.Message);
            }
        }
        private void SearchProduct(int type, string id)
        {
            try
            {
                if (cbxPrice.SelectedIndex < 1)
                {
                    MessageBox.Show(Properties.rsfSales.BarCode1, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (type == 1)
                    {
                        SqlParameter[] sqlPara = new SqlParameter[1] { posdb_vnmSqlDAC.newInParam("@BARCODE", SqlDbType.VarChar, id) };
                        DataTable dt = sqlDac.GetDataTable("PRODUCTS_SearchBarCode", sqlPara);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dtProduct.NewRow();
                            row["BarCode"] = dt.Rows[0]["BARCODE"].ToString();
                            row["ProductID"] = dt.Rows[0]["PRODUCT_ID"].ToString();
                            row["ProductName"] = dt.Rows[0]["PRODUCT_NAME"].ToString();
                            row["UnitName"] = dt.Rows[0]["UNIT_NAME"].ToString();
                            row["Quantity"] = 1;
                            row["Price"] = dt.Rows[0]["PriceDEV"] != null && dt.Rows[0]["PriceDEV"] != DBNull.Value ? float.Parse(dt.Rows[0]["PriceDEV"].ToString()) : 0;
                            row["TotalPrice"] = float.Parse(row["Price"].ToString());
                            row["ShortName"] = dt.Rows[0]["SHORT_NAME"].ToString();
                            dtProduct.Rows.Add(row);
                            txtBarScaner.Text = "";
                            txtGoodsCode.Text = "";
                            this.ActiveControl = txtBarScaner;
                        }
                        else
                        {
                            MessageBox.Show(Properties.rsfSales.BarCode2, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            this.ActiveControl = txtBarScaner;
                        }
                    }
                    if (type == 2)
                    {
                        if(!LoadProduct(id))
                        {
                            frmDialogProductSearch frmSearch = new frmDialogProductSearch(id, translate);
                            if (frmSearch.ShowDialog(this) == DialogResult.OK)
                            {
                                string productID = frmSearch.ProductID;
                                frmSearch.Dispose();
                                LoadProduct(productID);
                            }
                            else
                            {
                                txtGoodsCode.Text = "";
                                this.ActiveControl = txtGoodsCode;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchProduct' : " + ex.Message);
            }
        }
        private bool LoadProduct(string id)
        {
            bool f = false;
            try
            {
                //List<PRODUCTS> listP = PRODUCTS.ReadByPRODUCT_ID(id);

                string proc = "PRODUCTS_Read";
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, id);
                DataTable tb = sqlDac.GetDataTable(proc, sqlPara);

                if (tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["BARCODE"] != null && tb.Rows[0]["BARCODE"] != DBNull.Value && tb.Rows[0]["BARCODE"].ToString() != "")
                    {
                        DataRow row = dtProduct.NewRow();
                        row["BarCode"] = tb.Rows[0]["BARCODE"];
                        row["ProductID"] = tb.Rows[0]["PRODUCT_ID"];
                        row["ProductName"] = tb.Rows[0]["PRODUCT_NAME"];
                        row["UnitName"] = tb.Rows[0]["UNIT_NAME"];
                        row["Quantity"] = 1;
                        row["Price"] = tb.Rows[0]["PriceDEV"] != null && tb.Rows[0]["PriceDEV"] != DBNull.Value? float.Parse(tb.Rows[0]["PriceDEV"].ToString()) : 0;
                        row["TotalPrice"] = float.Parse(row["Price"].ToString());
                        row["ShortName"] = tb.Rows[0]["SHORT_NAME"];
                        dtProduct.Rows.Add(row);
                        txtBarScaner.Text = "";
                        txtGoodsCode.Text = "";
                        this.ActiveControl = txtGoodsCode;
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfSales.BarCode3, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    f = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadProduct' : " + ex.Message);
            }
            return f;
        }
        private void SaveExcel()
        {
            try
            {
                //float i = 100 / (float)dtProduct.Rows.Count;
                //float j = i;
                DataTable dt = new DataTable();
                dt.Columns.Add("MÃ VẠCH", typeof(string));
                dt.Columns.Add("MÃ HÀNG", typeof(string));
                dt.Columns.Add("TÊN HÀNG", typeof(string));
                dt.Columns.Add("VIẾT TẮT", typeof(string));
                dt.Columns.Add("SỐ LƯỢNG", typeof(int));
                dt.Columns.Add("ĐƠN VỊ TÍNH", typeof(string));
                dt.Columns.Add("GIÁ", typeof(double));
                dt.Columns.Add("THÀNH TIỀN", typeof(double));
                foreach (DataRow row in dtProduct.Rows)
                {
                    //if (backgroundWorker1.CancellationPending == true)
                    //    return;
                    DataRow dtRow = dt.NewRow();
                    dtRow["MÃ VẠCH"] = row["BarCode"] != null ? row["BarCode"].ToString() : "";
                    dtRow["MÃ HÀNG"] = row["ProductID"] != null ? row["ProductID"].ToString() : "";
                    dtRow["TÊN HÀNG"] = row["ProductName"] != null ? row["ProductName"].ToString() : "";
                    dtRow["VIẾT TẮT"] = row["ShortName"] != null ? row["ShortName"].ToString() : "";
                    dtRow["SỐ LƯỢNG"] = row["Quantity"] != null ? row["Quantity"].ToString() : "";
                    dtRow["ĐƠN VỊ TÍNH"] = row["UnitName"] != null ? row["UnitName"].ToString() : "";
                    dtRow["GIÁ"] = row["Price"] != null ? row["Price"].ToString() : "";
                    dtRow["THÀNH TIỀN"] = row["TotalPrice"] != null ? row["TotalPrice"].ToString() : "";
                    dt.Rows.Add(dtRow);
                    //backgroundWorker1.ReportProgress(Convert.ToInt32(j));
                    //j += i;
                    //System.Threading.Thread.Sleep(20);
                }
                if (groupExcel == true)
                {
                    for (int x = 0; x < dt.Rows.Count;x++)
                    {
                        for (int y = 0; y < dt.Rows.Count; y++)
                        {
                            if (x != y)
                            {
                                if (dt.Rows[x]["MÃ HÀNG"].ToString().Equals(dt.Rows[y]["MÃ HÀNG"].ToString()) && dt.Rows[x]["MÃ VẠCH"].ToString().Equals(dt.Rows[y]["MÃ VẠCH"].ToString()) && int.Parse(dt.Rows[x]["SỐ LƯỢNG"].ToString()) > 0 && int.Parse(dt.Rows[y]["SỐ LƯỢNG"].ToString()) > 0)
                                {
                                    dt.Rows[x]["SỐ LƯỢNG"] = int.Parse(dt.Rows[x]["SỐ LƯỢNG"].ToString()) + int.Parse(dt.Rows[y]["SỐ LƯỢNG"].ToString());
                                    dt.Rows[y]["SỐ LƯỢNG"] = "0";
                                }
                            }
                        }
                    }

                    for (int z = dt.Rows.Count - 1; z >= 0; z--)
                    {                        
                        DataRow dr = dt.Rows[z];
                        if (dr["SỐ LƯỢNG"] != null && dr["SỐ LƯỢNG"].ToString() != "" && int.Parse(dr["SỐ LƯỢNG"].ToString()) < 1)
                        {
                            dr.Delete();
                        }
                    }
                }

                //DateTime d = sqlDac.GetDateTimeServer();
                //string filename = "DanhSachSanPham_Filled_" + d.ToString("yyyyMMdd_HHmmss") + ".xls";
                //if (backgroundWorker1.CancellationPending != true)
                //{
                //    SaleMTCommon.Export expExcel = new SaleMTCommon.Export();
                //    expExcel.InfoCompany = true;
                //    expExcel.InfoStore = true;
                //    expExcel.StrTitle = "DANH SÁCH SẢN PHẨM";
                //    expExcel.ExportToExcel(dt, filename);
                //}
                ExportExcel exN = new ExportExcel();
                exN.InfoCompany = true;
                exN.InfoStore = true;
                exN.StrTitle = "DANH SÁCH SẢN PHẨM";
                exN.Dt = dt;
                exN.CaseEx = 5;
                exN.FileNames = "DanhSachSanPham_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                exN.ExportExcels();
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveExcel' : " + ex.Message);
            }
        }
        private void SaveAttemp()
        {
            try
            {
                if (dgvProduct.Rows.Count > 0)
                {
                    SaveExcel();
                    //if (backgroundWorker1.IsBusy != true)
                    //{
                    //    backgroundWorker1.RunWorkerAsync();
                    //    progressExcel = new frmProgress();
                    //    progressExcel.Canceled += new EventHandler<EventArgs>(BackgroundCancel);
                    //    progressExcel.StartPosition = FormStartPosition.CenterScreen;
                    //    progressExcel.Show();
                        
                    //}
                }
                else
                {
                    MessageBox.Show(Properties.rsfSales.BarCode4, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnViewData_Click' : " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvProduct.RowCount > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dtProduct.Clear();
                txtGoodsCode.Text = "";
                txtBarScaner.Text = "";
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnDelete_Click' : " + ex.Message);
            }
        }
        private void btnViewData_Click(object sender, EventArgs e)
        {
            groupExcel = false;
            SaveAttemp();
        }
        private void btnExportGroup_Click(object sender, EventArgs e)
        {
            groupExcel = true;
            SaveAttemp();
        }
        private void frmBarcodeScaner_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtBarScaner;
                AddPriceList();

                dtProduct.Columns.Add("BarCode", typeof(string));
                dtProduct.Columns.Add("ProductID", typeof(string));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("UnitName", typeof(string));
                dtProduct.Columns.Add("Quantity", typeof(int));
                dtProduct.Columns.Add("Price", typeof(float));
                dtProduct.Columns.Add("TotalPrice", typeof(float));
                dtProduct.Columns.Add("ShortName", typeof(string));
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = dtProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmBarcodeScaner_Load' : " + ex.Message);
            }
        }
        private void txtBarScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBarScaner.Text.Trim()!="")
            {
                SearchProduct(1, txtBarScaner.Text.Trim()); 
            } 
        }
        private void txtGoodsCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtGoodsCode.Text.Trim()!="")
            {
                SearchProduct(2,txtGoodsCode.Text.Trim()); 
            }
        }
        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvProduct.Rows)
                    {
                        i++;
                        if (i % 2 != 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "Quantity")
                    {
                        float quantity = 1;
                        float price = 0;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Price"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Price"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["Price"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Price"].Value.ToString(), out price))
                            dgvProduct.Rows[e.RowIndex].Cells["Price"].Value = 0;
                        if (quantity == 0)
                        {
                            quantity = 1;
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                        }
                        dgvProduct.Rows[e.RowIndex].Cells["TotalPrice"].Value = price * quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvProduct_CellValueChanged' : " + ex.Message);
            }
        }
        private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvProduct.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
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
        private void dgvProduct_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }
        private void dgvProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvProduct.ClearSelection();
            dgvProduct.Rows[e.RowIndex].Selected = true;
        }
        private void dgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
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
            SaveExcel();
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
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
  
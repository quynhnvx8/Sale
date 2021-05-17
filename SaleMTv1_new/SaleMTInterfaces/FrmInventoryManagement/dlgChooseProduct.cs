using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTBusiness.InventoryManagement;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    /// <summary>
    /// Người tạo Luannv - 21/10/2013 : Dialog chọn sản phẩm.
    /// </summary>
    public partial class dlgChooseProduct : Form
    {
        #region Declararion
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private DataTable dtProducts = new DataTable();
        private DataTable dtChoosed = new DataTable();
        private DataTable dtAuto =new DataTable();
        private SOEntities soEnResult;

        public SOEntities SoEnResult
        {
            get { return soEnResult; }
            set { soEnResult = value; }
        }
        #endregion

        #region Contructor
        public dlgChooseProduct(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["dlgChooseProduct.groupBox1.Text"];
            this.columnHeader2.Text = translate["dlgChooseProduct.columnHeader2.Text"];
            this.columnHeader1.Text = translate["dlgChooseProduct.columnHeader1.Text"];
            this.clnProductCode.HeaderText = translate["dlgChooseProduct.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["dlgChooseProduct.clnProductName.HeaderText"];
            this.lblTotalProduct.Text = translate["dlgChooseProduct.lblTotalProduct.Text"];
            this.label1.Text = translate["dlgChooseProduct.label1.Text"];
            this.groupBox2.Text = translate["dlgChooseProduct.groupBox2.Text"];
            this.lblTotalChoosed.Text = translate["dlgChooseProduct.lblTotalChoosed.Text"];
            this.clnProduct_Id.HeaderText = translate["dlgChooseProduct.clnProduct_Id.HeaderText"];
            this.clnProduct_name.HeaderText = translate["dlgChooseProduct.clnProduct_name.HeaderText"];
            this.btnClose.Text = translate["dlgChooseProduct.btnClose.Text"];
            this.btnSave.Text = translate["dlgChooseProduct.btnSave.Text"];
            this.tabPage2.Text = translate["dlgChooseProduct.tabPage2.Text"];
            this.Text = translate["dlgChooseProduct.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Load nhóm sản phẩm.
        /// </summary>
        private void LoadCatagory()
        {
            try
            {
                cboCatagory.DataSource = SOManagement.GetListCatagory();
                cboCatagory.DisplayMember = "TenNhom";
                cboCatagory.ValueMember = "MaNhom";
                if (cboCatagory.Items.Count > 0)
                    cboCatagory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadCatagory': " + ex.Message);
            }
        } 
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Chọn sản phẩm.
        /// </summary>
        private void ChooseProduct()
        {
            try
            {
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                {
                    string proCode = row.Cells["clnProductCode"].Value.ToString();
                    //check
                    DataRow[] rCheck = dtChoosed.Select("PRODUCT_ID = '" + proCode + "'");
                    if (rCheck.Length <= 0)
                    {
                        DataRow dr = dtChoosed.NewRow();
                        dr["PRODUCT_ID"] = proCode;
                        dr["PRODUCT_NAME"] = row.Cells["clnProductName"].Value.ToString();
                        dtChoosed.Rows.Add(dr);
                        lblCountChoosed.Text = dtChoosed.Rows.Count.ToString();
                    }
                    foreach (DataRow r in dtProducts.Select("PRODUCT_ID = '" + proCode + "'"))
                    {
                        dtProducts.Rows.Remove(r);
                        lblCountProduct.Text = dtProducts.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ChooseProduct': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : add item vào listview đã chọn .
        /// </summary>
        private void BindDataSource()
        {
            try
            {
                dtProducts = SOManagement.CreateTable(dtProducts);
                dtChoosed = SOManagement.CreateTable(dtChoosed);                

                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = dtProducts;
                dgvChoosedProduct.AutoGenerateColumns = false;
                dgvChoosedProduct.DataSource = dtChoosed;

                dtAuto = SOManagement.CreateTable(dtAuto);
                SOEntities soEn = new SOEntities();
                soEn.ProId = "";
                soEn.ProName = "";
                soEn.Active = false;
                soEn.Category = "";
                dtAuto = SOManagement.GetListProduct(soEn);
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindDataSource': " + ex.Message);
            }
        }        
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : Autocomplete textboxCode.
        /// </summary>
        private void AutoAddItemCode()
        {
            try
            {
                lvwAutoCode.Items.Clear();
                DataRow[] arrAuto = dtAuto.Select("PRODUCT_ID like '" + txtProductCode.Text.Trim() + "%'");
                if (arrAuto.Length > 0)
                {
                    foreach (DataRow dr in arrAuto)
                    {
                        lvwAutoCode.Items.Add(dr["PRODUCT_ID"].ToString());
                    }
                }
                else
                {
                    pnlAutoCode.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoAddItemCode': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : Autocomplete textboxCode.
        /// </summary>
        private void AutoAddItemName()
        {
            try
            {
                lvwAutoName.Items.Clear();
                DataRow[] arrAuto = dtAuto.Select("PRODUCT_NAME like '" + txtProductName.Text.Trim() + "%'");
                if (arrAuto.Length > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in arrAuto)
                    {
                        lvwAutoName.Items.Add(dr["PRODUCT_NAME"].ToString());
                        if (i % 2 == 0)
                        {
                            lvwAutoName.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                        }
                        i++;
                    }
                }
                else
                {
                    pnlAutoName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AutoAddItemName': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : Chọn mã sản phẩm .
        /// </summary>
        private void ChooseCode()
        {
            try
            {
                ListView.SelectedListViewItemCollection item = lvwAutoCode.SelectedItems;
                string code = item[0].Text.Trim();
                DataRow[] rowCheck = dtProducts.Select("PRODUCT_ID = '" + code + "'");
                if (rowCheck.Length <= 0)
                {
                    DataRow[] row = dtAuto.Select("PRODUCT_ID = '" + code + "'");
                    if (row.Length > 0)
                    {
                        DataRow rowadd = dtProducts.NewRow();
                        rowadd["PRODUCT_ID"] = row[0]["PRODUCT_ID"].ToString();
                        rowadd["PRODUCT_NAME"] = row[0]["PRODUCT_NAME"].ToString();
                        dtProducts.Rows.Add(rowadd);
                    }
                }
                txtProductCode.Text = "";
                pnlAutoCode.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'ChooseCode': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 21/10/2013 : Chọn tên sản phẩm .
        /// </summary>
        private void ChooseName()
        {
            try
            {
                txtProductName.Text = lvwAutoName.Items[0].Text.Trim();
                pnlAutoName.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'ChooseName': " + ex.Message);
            }

        }
        
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : form load.
        /// </summary>
        private void dlgChooseProduct_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                LoadCatagory();
                BindDataSource();
                pnlAutoCode.Visible = false;
                pnlAutoName.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : chọn sản phẩm.
        /// </summary>
        private void btnChose_Click(object sender, EventArgs e)
        {
            try
            {
                ChooseProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Tìm kiếm sản phẩm.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn.ProId = "";
                soEn.ProName = txtProductName.Text.Trim();
                soEn.Active = false;
                soEn.Category = "";
                SOManagement.AddProduct(dtProducts, SOManagement.GetListProduct(soEn));
                lblCountProduct.Text = dtProducts.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Xóa từng sản phẩm trong danh sách đã chọn.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvChoosedProduct.SelectedRows)
                {
                    string proCode = row.Cells["clnProduct_Id"].Value.ToString();
                    foreach (DataRow r in dtChoosed.Select("PRODUCT_ID = '" + proCode + "'"))
                    {
                        dtChoosed.Rows.Remove(r);
                        lblCountChoosed.Text = dtChoosed.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Tìm kiếm sản phẩm theo loại sản phẩm.
        /// </summary>
        private void cboCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn.ProId = "";
                soEn.ProName = "";
                soEn.Active = false;
                soEn.Category = (cboCatagory.Text != "Tất cả") ? cboCatagory.SelectedValue.ToString() : "";
                SOManagement.AddProduct(dtProducts, SOManagement.GetListProduct(soEn));
                lblCountProduct.Text = dtProducts.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Xóa toàn bộ danh sách sản phẩm đã chọn.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChoosedProduct.Rows.Count > 0)
                {
                    for (int i = dgvChoosedProduct.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvChoosedProduct.Rows[i].IsNewRow)
                        {
                            dgvChoosedProduct.Rows.RemoveAt(i);
                        }
                    }
                }
                lblCountChoosed.Text = "0";
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }        
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện TextChanged autocomplete lọc sản phẩm theo mã sp.
        /// </summary>
        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text.Trim() != "")
            {
                pnlAutoCode.Visible = true;
                AutoAddItemCode();
            }
            else
            {
                pnlAutoCode.Visible = false;
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện KeyDown Chuyển focus sang listview auto complete.
        /// </summary>
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40)
                {
                    lvwAutoCode.Focus();
                    lvwAutoCode.Items[0].Selected = true;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (lvwAutoCode.Items.Count > 0)
                    {
                        string code = lvwAutoCode.Items[0].Text.Trim();
                        DataRow[] rowCheck = dtProducts.Select("PRODUCT_ID = '" + code + "'");
                        if (rowCheck.Length <= 0)
                        {
                            DataRow[] row = dtAuto.Select("PRODUCT_ID = '" + code + "'");
                            if (row.Length > 0)
                            {
                                DataRow rowadd = dtProducts.NewRow();
                                rowadd["PRODUCT_ID"] = row[0]["PRODUCT_ID"].ToString();
                                rowadd["PRODUCT_NAME"] = row[0]["PRODUCT_NAME"].ToString();
                                dtProducts.Rows.Add(rowadd);
                            }
                        }
                        txtProductCode.Text = "";
                        pnlAutoCode.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện TextChanged autocomplete lọc sản phẩm theo tên sp.
        /// </summary>
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() != "")
            {
                pnlAutoName.Visible = true;
                AutoAddItemName();
            }
            else
            {
                pnlAutoName.Visible = false;
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện KeyDown Chuyển focus sang listview auto complete.
        /// </summary>
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40)
                {
                    lvwAutoName.Focus();
                    lvwAutoName.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện Nhấn enter để chọn sản phẩm trong list autocomplete.
        /// </summary>
        private void lvwAutoCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    ChooseCode();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện click đúp chuột để chọn sản phẩm trong list autocomplete.
        /// </summary>
        private void lvwAutoCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ChooseCode();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện click đúp chuột để chọn sản phẩm trong list autocomplete.
        /// </summary>
        private void lvwAutoName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ChooseName();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Sự kiện Nhấn enter để chọn sản phẩm trong list autocomplete.
        /// </summary>
        private void lvwAutoName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    ChooseName();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Đóng form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error:" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Đồng ý chọn danh sách sản phẩm.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                soEnResult = new SOEntities();
                soEnResult.ListProduct = "";
                string listCode;
                for (int i = 0; i < dgvChoosedProduct.Rows.Count; i++)
                {
                    listCode = dgvChoosedProduct.Rows[i].Cells["clnProduct_Id"].Value.ToString();
                    listCode = (soEnResult.ListProduct != "") ? "," + listCode : listCode;
                    soEnResult.ListProduct = soEnResult.ListProduct + listCode;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error:" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Mở dialog Import danh sách sản phẩm từ file excel.
        /// </summary>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                dlgSOImport dlgImport = new dlgSOImport(translate);
                dlgImport.DtProduct = dtAuto;
                dlgImport.StartPosition = FormStartPosition.CenterScreen;
                dlgImport.ShowDialog();
                if (dlgImport.ListResult != null && dlgImport.ListResult.Count > 0)
                {
                    SOManagement.AddProductFromList(dtChoosed, dlgImport.ListResult);
                }
                lblCountChoosed.Text =  dtChoosed.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                log.Error("Error:" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 21/10/2013 : Ghi file log đóng form
        /// </summary>
        private void dlgChooseProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý các phím tắt trên form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                try
                {
                    ChooseProduct();
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.F5 error: " + ex.Message);
                }
            }            
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Export exEn = new Export();
                exEn.StrTitle = "DANH SÁCH SẢN PHẨM";
                exEn.InfoStore = true;
                exEn.InfoCompany = true;
                exEn.ExportToExcel(dtProducts, "List_product_Filled_" + sqlDac.GetDateTimeServer().ToString("ddMMyyyy_HHmmss")+".xls");
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        
    }
}

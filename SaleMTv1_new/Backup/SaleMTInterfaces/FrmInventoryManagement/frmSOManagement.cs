using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTCommon;
using SaleMTBusiness.InventoryManagement;
using SaleMTDataAccessLayer.SaleMTObj;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmSOManagement : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<string> listPro = new List<string>();
        #endregion

        #region Contructor
      
        public frmSOManagement(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            dgvProduct.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvProduct_EditingControlShowing);
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label4.Text = translate["frmSOManagement.label4.Text"];
            this.label1.Text = translate["frmSOManagement.label1.Text"];
            this.btnSearch.Text = translate["frmSOManagement.btnSearch.Text"];
            this.clnId.HeaderText = translate["frmSOManagement.clnId.HeaderText"];
            this.clnSONo.HeaderText = translate["frmSOManagement.clnSONo.HeaderText"];
            this.clnProductID.HeaderText = translate["frmSOManagement.clnProductID.HeaderText"];
            this.clnProductName.HeaderText = translate["frmSOManagement.clnProductName.HeaderText"];
            this.clnPRICE.HeaderText = translate["frmSOManagement.clnPRICE.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmSOManagement.clnQuantity.HeaderText"];
            this.clnTOTAL.HeaderText = translate["frmSOManagement.clnTOTAL.HeaderText"];
            this.clnQuantitySuspend.HeaderText = translate["frmSOManagement.clnQuantitySuspend.HeaderText"];
            this.btnSave.Text = translate["frmSOManagement.btnSave.Text"];
            this.btnExportExcel.Text = translate["frmSOManagement.btnExportExcel.Text"];
            this.btnExit.Text = translate["frmSOManagement.btnExit.Text"];
            this.Text = translate["frmSOManagement.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Tìm kiếm SO.
        /// </summary>
        private void SearchSO()
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn.SoNo = txtSO.Text.Trim();
                soEn.ListProduct = txtListProduct.Text.Trim();
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = SOManagement.GetListSO(soEn);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchSO': " + ex.Message);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Form load.
        /// </summary>
        private void frmSOManagement_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Tìm kiếm SO.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchSO();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Thay đổi màu backgroud và căn lề dgvProduct.
        /// </summary>
        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    foreach (DataGridViewRow r in dgvProduct.Rows)
                    {
                        r.Cells["clnQuantitySuspend"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        r.Cells["clnQuantitySuspend"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        r.Cells["clnPRICE"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        r.Cells["clnTOTAL"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        r.Cells["clnQuantity"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Tìm kiếm sản phầm từ mã nhập vào.
        /// </summary>
        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    //CheckInventoryEntities inventEn = CheckInventory.ShowProductSearch(txtProduct.Text.Trim());
                    //if (inventEn != null)
                    //{
                    //    int check = listPro.FindIndex(s => s == inventEn.ProductID);
                    //    if (check == -1)
                    //    {
                    //        listPro.Add(inventEn.ProductID);
                    //        string listCode = (txtListProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                    //        txtListProduct.Text = txtListProduct.Text.Trim() + listCode;
                    //        txtProduct.Text = "";
                    //    }
                    //}

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
                        if (!txtListProduct.Text.Contains(p) && p != "")
                            txtListProduct.Text += txtListProduct.Text != "" ? "," + p : p;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Xóa list sản phẩm đã chọn.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtListProduct.Text = "";
                txtProduct.Text = "";
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Mở giao diện chọn sản phẩm.
        /// </summary>
        private void btnBrowe_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn = SOManagement.ShowChoseProduct(translate);
                txtListProduct.Text = soEn.ListProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Đóng form.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
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
        /// Người tạo Luannv – 20/10/2013: Ghi file log form đã đóng.
        /// </summary>
        private void frmSOManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 20/10/2013: Export dữ liệu ra excel.
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dtExport = (DataTable)dgvProduct.DataSource;
                //if (dtExport != null && dtExport.Rows.Count > 0)
                //{
                //    Export exEn = new Export();
                //    exEn.StrTitle = "DANH SÁCH DỮ LIỆU";
                //    exEn.InfoCompany = true;
                //    exEn.InfoStore = true;

                //    exEn.ExportToExcel(dtExport, "_Filled_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xls");
                //}

                if (dgvProduct.DataSource != null && dgvProduct.RowCount > 0)
                {
                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = "DANH SÁCH DỮ LIỆU";
                    exN.Dgv = this.dgvProduct;
                    exN.CaseEx = 7;
                    exN.FileNames = "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    exN.ExportExcels();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 25/10/2013 : Tạo sự kiện Keypress cho datagirdview dgvProduct. 
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
        /// Người tạo Luannv – 25/10/2013 : Chặn các ký tự không hợp lệ nhập vào cell số lượng treo. 
        /// </summary>
        private void dgvProductCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgvProduct.CurrentCell.ColumnIndex == 7)
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Rows.Count > 0)
                {
                    int value = Convert.ToInt32(dgvProduct.CurrentCell.EditedFormattedValue);
                    dgvProduct.CurrentCell.Value = value;
                    dgvProduct.EndEdit();
                    DataTable dt = (DataTable)dgvProduct.DataSource;
                    SOManagement.SavePO(dt);
                    MessageBox.Show(Properties.rsfInventoryImport.SO.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        
        
    }
}

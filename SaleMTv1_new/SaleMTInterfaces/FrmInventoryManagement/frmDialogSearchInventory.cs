using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTBusiness.InventoryManagement;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    /// <summary>
    /// Người tạo Luannv – 17/10/2013 : Tìm và chọn sản phẩm muốn kiểm tra tồn kho. 
    /// </summary>
    public partial class frmDialogSearchInventory : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();

        private CheckInventoryEntities invenEn;

        public CheckInventoryEntities InvenEn
        {
            get { return invenEn; }
            set { invenEn = value; }
        }
        #endregion

        #region Contructor
        public frmDialogSearchInventory(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.btnSearch.Text = translate["frmDialogSearchInventory.btnSearch.Text"];
            this.rdbProductName.Text = translate["frmDialogSearchInventory.rdbProductName.Text"];
            this.rdbProductCode.Text = translate["frmDialogSearchInventory.rdbProductCode.Text"];
            this.groupBox3.Text = translate["frmDialogSearchInventory.groupBox3.Text"];
            this.clnProductCode.HeaderText = translate["frmDialogSearchInventory.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["frmDialogSearchInventory.clnProductName.HeaderText"];
            this.clnPrice.HeaderText = translate["frmDialogSearchInventory.clnPrice.HeaderText"];
            this.clnShortName.HeaderText = translate["frmDialogSearchInventory.clnShortName.HeaderText"];
            this.btnOK.Text = translate["frmDialogSearchInventory.btnOK.Text"];
            this.btnClose.Text = translate["frmDialogSearchInventory.btnClose.Text"];
            this.Text = translate["frmDialogSearchInventory.Text"];
        }	

        #endregion

        #region Mothod/Function
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Load danh sách sản phẩm. 
        /// </summary>
        private void LoadProduct()
        {
            try
            {
                dgvListProduct.AutoGenerateColumns = false;
                dgvListProduct.DataSource = CheckInventory.SearchProduct(txtProductCode.Text.Trim(), rdbProductCode.Checked);
                if (dgvListProduct.Rows.Count > 0)
                    dgvListProduct.Rows[0].Cells[0].Selected = true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadProduct':" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Lựa chọn sản phẩm. 
        /// </summary>
        private void ChooseProduct()
        {
            try
            {
                DataGridViewRow row = dgvListProduct.CurrentCell.OwningRow;
                invenEn = new CheckInventoryEntities();
                invenEn.ProductID = row.Cells["clnProductCode"].Value.ToString();
                invenEn.ProductName = row.Cells["clnProductName"].Value.ToString();
                invenEn.Price = Conversion.GetCurrency(row.Cells["clnPrice"].Value.ToString());
                invenEn.ShortName = row.Cells["clnShortName"].Value.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error 'ChooseProduct':" + ex.Message);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Form load. 
        /// </summary>
        private void frmDialogSearchInventory_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Form started.");
                txtProductCode.Text = invenEn.ProCode;
                if (invenEn.ProCode != null && invenEn.ProCode != "")
                {
                    char c = Convert.ToChar(invenEn.ProCode.Substring(0, 1));                   
                    rdbProductCode.Checked = Char.IsDigit(c);
                    rdbProductName.Checked = !Char.IsDigit(c);                    
                }
                if (this.InvenEn.DtSearch != null)
                {
                    dgvListProduct.AutoGenerateColumns = false;
                    dgvListProduct.DataSource = this.InvenEn.DtSearch;
                    if (dgvListProduct.Rows.Count > 0)
                        dgvListProduct.Rows[0].Cells[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error :"+ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Thay đổi màu nền các dòng trên lưới. 
        /// </summary>
        private void dgvListProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvListProduct.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvListProduct.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
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
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Tìm kiếm sản phẩm theo mã nhập vào. 
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Tìm kiếm sản phẩm theo mã hàng. 
        /// </summary>
        private void rdbProductCode_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Tìm kiếm sản phẩm theo tên hàng. 
        /// </summary>
        private void rdbProductName_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Chọn sản phẩm. 
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ChooseProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Click để chọn sản phẩm. 
        /// </summary>
        private void dgvListProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChooseProduct();
            }
            catch (Exception ex)
            {
                log.Error("Error :" + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Nhấn enter để chọn sản phẩm. 
        /// </summary>
        private void dgvListProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    ChooseProduct();
                }
                catch (Exception ex)
                {
                    log.Error("Error :" + ex.Message);
                }
            }
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Xử lý khi nhấn phím enter hoặc Escape.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Enter)
                {
                    ChooseProduct();
                }
                if (keyData == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("ProcessCmdKey - error: " + ex.Message);
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : Đóng form. 
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Người tạo Luannv – 17/10/2013 : ghi log form đã đóng. 
        /// </summary>
        private void frmDialogSearchInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Form closed.");
        }
        #endregion
        
    }
}

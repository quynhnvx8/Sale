using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 03/10/2013 : Chọn sản phẩm chiết khấu.
    /// </summary>
    public partial class frmDialogDiscountProduct : Form
    {
        #region declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtProduct;
        public DataTable DtProduct
        {
            get { return dtProduct; }
            set { dtProduct = value; }
        }
      
        public frmDialogDiscountProduct(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmDialogDiscountProduct.groupBox1.Text"];
            this.clnChose.HeaderText = translate["frmDialogDiscountProduct.clnChose.HeaderText"];
            this.clnProductCode.HeaderText = translate["frmDialogDiscountProduct.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["frmDialogDiscountProduct.clnProductName.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmDialogDiscountProduct.clnQuantity.HeaderText"];
            this.clnPrice.HeaderText = translate["frmDialogDiscountProduct.clnPrice.HeaderText"];
            this.clnPriceSales.HeaderText = translate["frmDialogDiscountProduct.clnPriceSales.HeaderText"];
            this.clnIntoMoney.HeaderText = translate["frmDialogDiscountProduct.clnIntoMoney.HeaderText"];
            this.chkChose.Text = translate["frmDialogDiscountProduct.chkChose.Text"];
            this.btnOK.Text = translate["frmDialogDiscountProduct.btnOK.Text"];
            this.btnClose.Text = translate["frmDialogDiscountProduct.btnClose.Text"];
            this.Text = translate["frmDialogDiscountProduct.Text"];
        }	

        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 03/10/2013 : Load form : bind dữ liệu danh sách sản phẩm bán vào Datagridview.
        /// </summary>
        private void frmDialogDiscountProduct_Load(object sender, EventArgs e)
        {
            log.Debug("Notice: form started !.");
            try
            {
                chkChose.Checked = true;
                if (DtProduct.Rows.Count > 0)
                {
                    dgvProduct.AutoGenerateColumns = false;
                    dgvProduct.DataSource = DtProduct;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 03/10/2013 : Sự kiện thay đổi checked checkbox . Bỏ chọn hoặc chọn toàn bộ sản phẩm .
        /// </summary>
        private void chkChose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chkChose.Checked)
                    {
                        chk.Value = true;
                    }
                    else
                    {
                        chk.Value = false;
                    }
                }
                dgvProduct.EndEdit();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }        
        /// <summary>
        /// Người tạo Luannv – 03/10/2013 : Thay đổi màu nên từng dòng datagridview và check chọn.
        /// </summary>
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                        // set check chọn = true
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                        chk.Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 03/10/2013 : Button click - Trả về kết quả lựa chọn sản phẩm chiết khấu.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvProduct.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvProduct.Rows[i].Cells[0];
                        bool check = Convert.ToBoolean(chk.Value);
                        if (!check)
                        {
                            DtProduct.Rows.RemoveAt(i); 
                        }
                    }
                }
                else
                {
                    for (int i = DtProduct.Rows.Count - 1; i >= 0; i--)
                    {
                        DtProduct.Rows.RemoveAt(i);                        
                    }
                }
                int kt1 = DtProduct.Rows.Count;                
                this.Close();
                log.Debug("Notice: form closed .");
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 03/10/2013 : Close form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý khi nhấn phím ESC đóng form.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
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
        /// Người tạo Luannv – 27/09/2013 : Ghi file log form đã đóng.         
        /// </summary>
        private void frmDialogDiscountProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Debug("Notice: form closed.");
        }
        #endregion
        
    }
}

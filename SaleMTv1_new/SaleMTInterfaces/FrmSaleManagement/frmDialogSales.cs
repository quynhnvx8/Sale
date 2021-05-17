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
    /// Người tạo Luannv – 01/10/2013 : Tìm kiếm sản phẩm  .
    /// </summary>
    public partial class frmDialogSales : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DataTable datatableSales;
        private string salesCode;
        public string SalesCode
        {
            get { return salesCode; }
            set { salesCode = value; }
        }
        #endregion

        #region Contructor
       
        public frmDialogSales(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.clnProductCode.HeaderText = translate["frmDialogSales.clnProductCode.HeaderText"];
            this.clnBarCode.HeaderText = translate["frmDialogSales.clnBarCode.HeaderText"];
            this.clnProductName.HeaderText = translate["frmDialogSales.clnProductName.HeaderText"];
            this.Text = translate["frmDialogSales.Text"];
        }	

        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : form load .
        /// </summary>
        private void frmDialogSales_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                dgvProductSales.DataSource = datatableSales;
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 :enter xác nhận chọn sản phẩm .
        /// </summary>
        private void dgvProductSales_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow row = dgvProductSales.CurrentCell.OwningRow;
                    salesCode = row.Cells["clnProductCode"].Value.ToString();
                    this.Close();
                    //log.Debug("Notice: form closed");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 :click đúp xác nhận chọn sản phẩm .
        /// </summary>
        private void dgvProductSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null)
                {
                    DataGridViewRow row = dgvProductSales.CurrentCell.OwningRow;
                    salesCode = row.Cells["clnProductCode"].Value.ToString();
                    this.Close();
                    //log.Debug("Notice: form closed");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
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
        #endregion
    }
}

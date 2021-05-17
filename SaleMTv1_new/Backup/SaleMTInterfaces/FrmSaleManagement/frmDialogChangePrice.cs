using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 02/10/2013 : Nhập giá bán .
    /// </summary>
    public partial class frmDialogChangePrice: Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string priceIn;
        public string PriceIn
        {
            get { return priceIn; }
            set { priceIn = value; }
        }
        private string priceOut;
        public string PriceOut
        {
            get { return priceOut; }
            set { priceOut = value; }
        }
        #endregion

        #region Contructor
        public frmDialogChangePrice()
        {
            InitializeComponent();
        }

        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : form load .
        /// </summary>
        private void frmDialogPrice_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                txtPrice.Focus();
                txtPrice.Text = Conversion.GetCurrency(Conversion.Replaces(PriceIn.ToString()));
                txtPrice.SelectAll();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Nhấn enter để xác nhận số lượng nhập vào.
        /// </summary>
        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPrice.Text.Trim().Length > 0)
                    {
                        this.PriceOut = txtPrice.Text;
                        this.Close();                        
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn các ký tự không hợp lệ .
        /// </summary>
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtPrice.Text.Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Ghi log form đã đóng .
        /// </summary>
        private void frmDialogQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Ghi log form đã đóng .
        /// </summary>
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text.Trim().Length > 0)
                {
                    txtPrice.Text = Conversion.GetCurrency(Conversion.Replaces(txtPrice.Text));
                    txtPrice.SelectionStart = txtPrice.Text.Trim().Length;
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

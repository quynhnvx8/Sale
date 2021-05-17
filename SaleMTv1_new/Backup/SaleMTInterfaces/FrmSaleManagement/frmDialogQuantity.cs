using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 01/10/2013 : Nhập số lượng .
    /// </summary>
    public partial class frmDialogQuantity : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int quantity;
        private int input;

        public int Input
        {
            get { return input; }
            set { input = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public frmDialogQuantity()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : form load .
        /// </summary>
        private void frmDialogQuantity_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                txtQuantity.Focus();
                txtQuantity.Text = (Input != 0) ? Input.ToString() : "1";
                txtQuantity.SelectAll();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Nhấn enter để xác nhận số lượng nhập vào.
        /// </summary>
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtQuantity.Text.Trim().Length > 0)
                    {
                        this.Quantity = Convert.ToInt32(txtQuantity.Text);
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
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtQuantity.Text.Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                    int check = Convert.ToInt32(txtQuantity.Text.Trim());
                    if (txtQuantity.Text.Length > 3)
                    {
                        if (Char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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
        /// Người tạo Luannv – 27/09/2013 : Xử lý khi nhấn phím ESC đóng form.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape)
                {
                    Quantity = Input;
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
        /// Người tạo Luannv – 01/10/2013 : Ghi log form đã đóng .
        /// </summary>
        private void frmDialogQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        #endregion

        
    }
}

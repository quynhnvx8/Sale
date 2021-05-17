using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmDialogSuportPayment : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string money;

        public string Money
        {
            get { return money; }
            set { money = value; }
        }
        #endregion
        public frmDialogSuportPayment()
        {
            InitializeComponent();
        }


        private void frmDialogSuportPayment_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                txtMoney.Text = "0";
                txtMoney.Select();
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn10000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp+10000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn20000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 20000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn50000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 50000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn100000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 100000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn200000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 200000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn500000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 500000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 200).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 500).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 1000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn2000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 2000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btn5000_Click(object sender, EventArgs e)
        {
            try
            {
                double temp = Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                txtMoney.Text = Conversion.GetCurrency((temp + 5000).ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtMoney.Text = "0";
                txtMoney.Select();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Money = txtMoney.Text.Trim();
                this.Close();
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

        private void frmDialogSuportPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
    }
}

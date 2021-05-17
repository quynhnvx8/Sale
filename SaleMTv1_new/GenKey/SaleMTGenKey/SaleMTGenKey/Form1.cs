using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTGenKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdChapnhan_Click(object sender, EventArgs e)
        {
            try
            {
                txtReg.Text = SaleMTDataAccessLayer.SaleMTDAL.SaleMTEncrypt.EncryptX2(txtMamay.Text);
            }
            catch
            {

            }

        }
    }
}

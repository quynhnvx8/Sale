using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SaleAD.FrmProductManagement
{
    public partial class frmPrice : Form
    {
        public frmPrice()
        {
            InitializeComponent();
        }

        private void frmPrice_Load(object sender, EventArgs e)
        {

        }
                
        FrmProductManagement.frmViewPriceHistory frmHis;
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            frmHis = new frmViewPriceHistory();
            frmHis.StartPosition = FormStartPosition.CenterScreen;
            frmHis.ShowDialog();

        }
        FrmProductManagement.frmViewPrice frmviewPri;
        private void btnViewPrice_Click(object sender, EventArgs e)
        {
            frmviewPri = new frmViewPrice();
            frmviewPri.StartPosition = FormStartPosition.CenterScreen;
            frmviewPri.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleAD
{
    public partial class SaleAD : Form
    {
        public SaleAD()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cấuHìnhCơSởDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        
        private void dữLiệuHeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        FrmOptionData.frmSystemData frmsys;
        private void dữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsys = new global::SaleAD.FrmOptionData.frmSystemData();
            frmsys.Show();
        }
        FrmProductManagement.frmProductManagements frmProduct;
        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct = new global::SaleAD.FrmProductManagement.frmProductManagements();
            frmProduct.Show();
        }
        FrmProductManagement.frmPrice frmPrice;
        private void đơnGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrice = new global::SaleAD.FrmProductManagement.frmPrice();
            frmPrice.Show();
        }
    }
}

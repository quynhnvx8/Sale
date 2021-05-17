using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SaleMTInterfaces.FrmUtilities
{
    public partial class frmCheckProduct : Form
    {
       

        public frmCheckProduct(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.tabPSanPham.Text = translate["frmCheckProduct.tabPSanPham.Text"];
            this.btnClose.Text = translate["frmCheckProduct.btnClose.Text"];
            this.btnSave.Text = translate["frmCheckProduct.btnSave.Text"];
            this.btnCancel.Text = translate["frmCheckProduct.btnCancel.Text"];
            this.btnF5.Text = translate["frmCheckProduct.btnF5.Text"];
            this.groupBox2.Text = translate["frmCheckProduct.groupBox2.Text"];
            this.columnHeader1.Text = translate["frmCheckProduct.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmCheckProduct.columnHeader2.Text"];
            this.label2.Text = translate["frmCheckProduct.label2.Text"];
            this.btnImport.Text = translate["frmCheckProduct.btnImport.Text"];
            this.groupBox1.Text = translate["frmCheckProduct.groupBox1.Text"];
            this.btnSearch.Text = translate["frmCheckProduct.btnSearch.Text"];
            this.btnExcel.Text = translate["frmCheckProduct.btnExcel.Text"];
            this.label1.Text = translate["frmCheckProduct.label1.Text"];
            this.label7.Text = translate["frmCheckProduct.label7.Text"];
            this.Text = translate["frmCheckProduct.Text"];
        }	

    }
}

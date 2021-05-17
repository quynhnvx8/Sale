using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmDiscountVoucherReceipt : TabForm
    {
        public frmDiscountVoucherReceipt(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxPhieuGG.Text = translate["frmDiscoutVoucherReceipt.gbxPhieuGG.Text"];
            this.label7.Text = translate["frmDiscoutVoucherReceipt.label7.Text"];
            this.gbxDanhSach.Text = translate["frmDiscoutVoucherReceipt.gbxDanhSach.Text"];
            this.btnVoucherSearch.Text = translate["frmDiscoutVoucherReceipt.btnVoucherSearch.Text"];
            this.gbxPhieuGiamGia.Text = translate["frmDiscoutVoucherReceipt.gbxPhieuGiamGia.Text"];
            this.btnTaiVe.Text = translate["frmDiscoutVoucherReceipt.btnTaiVe.Text"];
            this.label12.Text = translate["frmDiscoutVoucherReceipt.label12.Text"];
            this.label5.Text = translate["frmDiscoutVoucherReceipt.label5.Text"];
            this.label11.Text = translate["frmDiscoutVoucherReceipt.label11.Text"];
            this.label10.Text = translate["frmDiscoutVoucherReceipt.label10.Text"];
            this.label6.Text = translate["frmDiscoutVoucherReceipt.label6.Text"];
            this.label4.Text = translate["frmDiscoutVoucherReceipt.label4.Text"];
            this.label3.Text = translate["frmDiscoutVoucherReceipt.label3.Text"];
            this.label2.Text = translate["frmDiscoutVoucherReceipt.label2.Text"];
            this.label1.Text = translate["frmDiscoutVoucherReceipt.label1.Text"];
            this.Text = translate["frmDiscoutVoucherReceipt.Text"];
        }	

        private void btnVoucherSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiVe_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmDiscountVoucherDelivery : TabForm
    {
        public frmDiscountVoucherDelivery(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label3.Text = translate["frmDiscoutVoucherDelivery.label3.Text"];
            this.label2.Text = translate["frmDiscoutVoucherDelivery.label2.Text"];
            this.label1.Text = translate["frmDiscoutVoucherDelivery.label1.Text"];
            this.btnSearchVoucher.Text = translate["frmDiscoutVoucherDelivery.btnSearchVoucher.Text"];
            this.gbxDanhSach.Text = translate["frmDiscoutVoucherDelivery.gbxDanhSach.Text"];
            this.gbxPhieuGiamGia.Text = translate["frmDiscoutVoucherDelivery.gbxPhieuGiamGia.Text"];
            this.btnChonPhieu.Text = translate["frmDiscoutVoucherDelivery.btnChonPhieu.Text"];
            this.label10.Text = translate["frmDiscoutVoucherDelivery.label10.Text"];
            this.gbxTTPhieuXuatGG.Text = translate["frmDiscoutVoucherDelivery.gbxTTPhieuXuatGG.Text"];
            this.rbnExportStore.Text = translate["frmDiscoutVoucherDelivery.rbnExportStore.Text"];
            this.rbnExportWasehouse.Text = translate["frmDiscoutVoucherDelivery.rbnExportWasehouse.Text"];
            this.label9.Text = translate["frmDiscoutVoucherDelivery.label9.Text"];
            this.label8.Text = translate["frmDiscoutVoucherDelivery.label8.Text"];
            this.label7.Text = translate["frmDiscoutVoucherDelivery.label7.Text"];
            this.label6.Text = translate["frmDiscoutVoucherDelivery.label6.Text"];
            this.label5.Text = translate["frmDiscoutVoucherDelivery.label5.Text"];
            this.label4.Text = translate["frmDiscoutVoucherDelivery.label4.Text"];
            this.Text = translate["frmDiscoutVoucherDelivery.Text"];
        }	


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbxTTPhieuXuatGG_Enter(object sender, EventArgs e)
        {

        }
    }
}

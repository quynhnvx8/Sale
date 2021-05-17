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
    public partial class frmGiftReceipt : TabForm
    {
        public frmGiftReceipt(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gpxPhieuQuaTang.Text = translate["frmGiftReceipt.gpxPhieuQuaTang.Text"];
            this.label12.Text = translate["frmGiftReceipt.label12.Text"];
            this.label11.Text = translate["frmGiftReceipt.label11.Text"];
            this.label10.Text = translate["frmGiftReceipt.label10.Text"];
            this.gbxPhieuTang.Text = translate["frmGiftReceipt.gbxPhieuTang.Text"];
            this.btnSearchGift.Text = translate["frmGiftReceipt.btnSearchGift.Text"];
            this.gpxThongTinPT.Text = translate["frmGiftReceipt.gpxThongTinPT.Text"];
            this.btnTaiVe.Text = translate["frmGiftReceipt.btnTaiVe.Text"];
            this.label9.Text = translate["frmGiftReceipt.label9.Text"];
            this.label8.Text = translate["frmGiftReceipt.label8.Text"];
            this.label7.Text = translate["frmGiftReceipt.label7.Text"];
            this.label6.Text = translate["frmGiftReceipt.label6.Text"];
            this.label5.Text = translate["frmGiftReceipt.label5.Text"];
            this.label4.Text = translate["frmGiftReceipt.label4.Text"];
            this.label3.Text = translate["frmGiftReceipt.label3.Text"];
            this.label2.Text = translate["frmGiftReceipt.label2.Text"];
            this.label1.Text = translate["frmGiftReceipt.label1.Text"];
            this.Text = translate["frmGiftReceipt.Text"];
        }	

        private void btnSearchGift_Click(object sender, EventArgs e)
        {

        }
    }
}

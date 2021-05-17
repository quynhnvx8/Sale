using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmSellGiftVoucher : TabForm
    {
        public frmSellGiftVoucher(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label13.Text = translate["frmSellGiftVoucher.label13.Text"];
            this.label12.Text = translate["frmSellGiftVoucher.label12.Text"];
            this.label11.Text = translate["frmSellGiftVoucher.label11.Text"];
            this.label10.Text = translate["frmSellGiftVoucher.label10.Text"];
            this.label9.Text = translate["frmSellGiftVoucher.label9.Text"];
            this.label8.Text = translate["frmSellGiftVoucher.label8.Text"];
            this.gbxDanhSachPhieu.Text = translate["frmSellGiftVoucher.gbxDanhSachPhieu.Text"];
            this.gbxDanhSachBanPhieu.Text = translate["frmSellGiftVoucher.gbxDanhSachBanPhieu.Text"];
            this.gbxDanhSachKH.Text = translate["frmSellGiftVoucher.gbxDanhSachKH.Text"];
            this.columnHeader1.Text = translate["frmSellGiftVoucher.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmSellGiftVoucher.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmSellGiftVoucher.columnHeader3.Text"];
            this.gbxTimKiem.Text = translate["frmSellGiftVoucher.gbxTimKiem.Text"];
            this.btnGiftVoucherSearch.Text = translate["frmSellGiftVoucher.btnGiftVoucherSearch.Text"];
            this.label7.Text = translate["frmSellGiftVoucher.label7.Text"];
            this.label6.Text = translate["frmSellGiftVoucher.label6.Text"];
            this.label5.Text = translate["frmSellGiftVoucher.label5.Text"];
            this.label4.Text = translate["frmSellGiftVoucher.label4.Text"];
            this.label3.Text = translate["frmSellGiftVoucher.label3.Text"];
            this.label2.Text = translate["frmSellGiftVoucher.label2.Text"];
            this.label1.Text = translate["frmSellGiftVoucher.label1.Text"];
            this.Text = translate["frmSellGiftVoucher.Text"];
        }	

    }
}

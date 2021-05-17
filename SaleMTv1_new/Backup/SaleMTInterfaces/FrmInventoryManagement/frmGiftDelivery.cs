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
    public partial class frmGiftDelivery : TabForm
    {
        public frmGiftDelivery(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxPTangQua.Text = translate["frmGiftDelivery.gbxPTangQua.Text"];
            this.btnChooseGift.Text = translate["frmGiftDelivery.btnChooseGift.Text"];
            this.label12.Text = translate["frmGiftDelivery.label12.Text"];
            this.label11.Text = translate["frmGiftDelivery.label11.Text"];
            this.label10.Text = translate["frmGiftDelivery.label10.Text"];
            this.gbxDanhSach.Text = translate["frmGiftDelivery.gbxDanhSach.Text"];
            this.btnGiftSearch.Text = translate["frmGiftDelivery.btnGiftSearch.Text"];
            this.gpxXuatPT.Text = translate["frmGiftDelivery.gpxXuatPT.Text"];
            this.rbnExportStore.Text = translate["frmGiftDelivery.rbnExportStore.Text"];
            this.rbnExportWasehouse.Text = translate["frmGiftDelivery.rbnExportWasehouse.Text"];
            this.label9.Text = translate["frmGiftDelivery.label9.Text"];
            this.label8.Text = translate["frmGiftDelivery.label8.Text"];
            this.label7.Text = translate["frmGiftDelivery.label7.Text"];
            this.label6.Text = translate["frmGiftDelivery.label6.Text"];
            this.label5.Text = translate["frmGiftDelivery.label5.Text"];
            this.label4.Text = translate["frmGiftDelivery.label4.Text"];
            this.label3.Text = translate["frmGiftDelivery.label3.Text"];
            this.label2.Text = translate["frmGiftDelivery.label2.Text"];
            this.label1.Text = translate["frmGiftDelivery.label1.Text"];
            this.Text = translate["frmGiftDelivery.Text"];
        }	

    }
}

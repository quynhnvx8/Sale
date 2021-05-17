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
    public partial class frmExportDiscountVoucher : TabForm
    {
        public frmExportDiscountVoucher(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.gbxDanhSachKH.Text = translate["frmExportDiscountVoucher.gbxDanhSachKH.Text"];
            this.columnHeader1.Text = translate["frmExportDiscountVoucher.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmExportDiscountVoucher.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmExportDiscountVoucher.columnHeader3.Text"];
            this.gbxTimKiem.Text = translate["frmExportDiscountVoucher.gbxTimKiem.Text"];
            this.btnDiscountVoucherSearch.Text = translate["frmExportDiscountVoucher.btnDiscountVoucherSearch.Text"];
            this.label13.Text = translate["frmExportDiscountVoucher.label13.Text"];
            this.label11.Text = translate["frmExportDiscountVoucher.label11.Text"];
            this.label9.Text = translate["frmExportDiscountVoucher.label9.Text"];
            this.label10.Text = translate["frmExportDiscountVoucher.label10.Text"];
            this.label8.Text = translate["frmExportDiscountVoucher.label8.Text"];
            this.label7.Text = translate["frmExportDiscountVoucher.label7.Text"];
            this.label6.Text = translate["frmExportDiscountVoucher.label6.Text"];
            this.label5.Text = translate["frmExportDiscountVoucher.label5.Text"];
            this.label4.Text = translate["frmExportDiscountVoucher.label4.Text"];
            this.label3.Text = translate["frmExportDiscountVoucher.label3.Text"];
            this.label2.Text = translate["frmExportDiscountVoucher.label2.Text"];
            this.label1.Text = translate["frmExportDiscountVoucher.label1.Text"];
            this.gbxDanhSachPhieu.Text = translate["frmExportDiscountVoucher.gbxDanhSachPhieu.Text"];
            this.gbxDanhSachXuatPhieu.Text = translate["frmExportDiscountVoucher.gbxDanhSachXuatPhieu.Text"];
            this.Text = translate["frmExportDiscountVoucher.Text"];
        }	

    }
}

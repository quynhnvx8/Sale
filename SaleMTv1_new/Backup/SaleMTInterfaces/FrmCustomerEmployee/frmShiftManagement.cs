using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;

namespace SaleMTInterfaces.FrmCustomerEmployee
{
    public partial class frmShiftManagement : TabForm
    {
        public frmShiftManagement(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.gbxDanhSachNV.Text = translate["frmShiftManagement.gbxDanhSachNV.Text"];
            this.btnView.Text = translate["frmShiftManagement.btnView.Text"];
            this.chkAllEmployee.Text = translate["frmShiftManagement.chkAllEmployee.Text"];
            this.columnHeader1.Text = translate["frmShiftManagement.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmShiftManagement.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmShiftManagement.columnHeader3.Text"];
            this.gbxShift.Text = translate["frmShiftManagement.gbxShift.Text"];
            this.label1.Text = translate["frmShiftManagement.label1.Text"];
            this.label27.Text = translate["frmShiftManagement.label27.Text"];
            this.label42.Text = translate["frmShiftManagement.label42.Text"];
            this.gbxLich.Text = translate["frmShiftManagement.gbxLich.Text"];
            this.Text = translate["frmShiftManagement.Text"];
        }	

    }
}

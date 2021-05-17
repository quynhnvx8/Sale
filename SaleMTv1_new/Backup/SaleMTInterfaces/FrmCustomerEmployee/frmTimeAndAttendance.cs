using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SaleMTInterfaces.FrmCustomerEmployee
{
    public partial class frmTimeAndAttendance : Form
    {
        public frmTimeAndAttendance(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label42.Text = translate["frmTimeEndAttendance.label42.Text"];
            this.label20.Text = translate["frmTimeEndAttendance.label20.Text"];
            this.gbxThongTinNV.Text = translate["frmTimeEndAttendance.gbxThongTinNV.Text"];
            this.label4.Text = translate["frmTimeEndAttendance.label4.Text"];
            this.label3.Text = translate["frmTimeEndAttendance.label3.Text"];
            this.label1.Text = translate["frmTimeEndAttendance.label1.Text"];
            this.label31.Text = translate["frmTimeEndAttendance.label31.Text"];
            this.label28.Text = translate["frmTimeEndAttendance.label28.Text"];
            this.label2.Text = translate["frmTimeEndAttendance.label2.Text"];
            this.Text = translate["frmTimeEndAttendance.Text"];
        }	

    }
}

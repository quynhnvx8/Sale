using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTInterfaces.FrmHelp
{
    public partial class frmAbout : Form
    {
        public frmAbout(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label2.Text = translate["frmAbout.label2.Text"];
            this.label1.Text = translate["frmAbout.label1.Text"];
            this.Text = translate["frmAbout.Text"];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }	

    }
}

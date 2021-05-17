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
    public partial class frmAppInfo : Form
    {
        public frmAppInfo(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.label2.Text = translate["frmAppInfo.label2.Text"];
            this.label1.Text = translate["frmAppInfo.label1.Text"];
            this.Text = translate["frmAppInfo.Text"];
        }	

    }
}

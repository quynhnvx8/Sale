using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmChangePass : TabForm
    {
        #region Declaration
        #endregion
        #region Contructor
        public frmChangePass(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.lblMKcu.Text = translate["frmChangePass.lblMKcu.Text"];
            this.lblMKmoi.Text = translate["frmChangePass.lblMKmoi.Text"];
            this.lblXacNhanMK.Text = translate["frmChangePass.lblXacNhanMK.Text"];
            this.Text = translate["frmChangePass.Text"];
        }	

        #endregion
        #region Method
        #endregion
        #region Event
        #endregion
    }
}

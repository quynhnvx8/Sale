using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using SaleMTInterfaces.PrintBill;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using SaleMTInterfaces.FrmReporter.FrmReportSale;


namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmCreateReasion : Form
    {
        #region Constructor
        public frmCreateReasion(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label1.Text = translate["frmCreateReasion.label1.Text"];
            this.btnSave.Text = translate["frmCreateReasion.btnSave.Text"];
            this.Text = translate["frmCreateReasion.Text"];

        }
        #endregion

        #region Methods
        public string Titlle;
        //private frmCreateReasion cReasion;
        //public frmCreateReasion CreateReasion
        //{
        //    get { return cReasion; }
        //    set { cReasion = value; }
        //}
        //Luu trang thai check
      
        public void InsertReasion(string title)
        {
            //string s;
            frmProductReportSearch frm = new frmProductReportSearch(translate);
            
            

            REPORT_CONDITIONS reCon = new REPORT_CONDITIONS();
            reCon.CATEGORY = frm.listProGroupTag;
            reCon.ACCOUNT = UserImformation.UserName;
            reCon.LIST_COLUMN = frm.ListResionTag;
            reCon.AUTO_ID = Guid.NewGuid();
            reCon.TITLE = title;
            reCon.REPORT = "frmReportSale";
            reCon.LIST_GROUP = null;
            reCon.ATTRIBUTE = "";
            reCon.Save(true);

        }
        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            Titlle = txtReasionName.Text;
            MessageBox.Show(Properties.rsfPayment.CashPayment1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
        #endregion

    }
}

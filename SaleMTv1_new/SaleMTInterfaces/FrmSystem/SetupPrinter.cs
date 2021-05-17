using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmSetupPrinter : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        
        public frmSetupPrinter(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.chkCheck.Text = translate["SetupPrint.chkCheck.Text"];
            this.groupBox1.Text = translate["SetupPrint.groupBox1.Text"];
            this.label2.Text = translate["SetupPrint.label2.Text"];
            this.label1.Text = translate["SetupPrint.label1.Text"];
            this.groupBox2.Text = translate["SetupPrint.groupBox2.Text"];
            this.label4.Text = translate["SetupPrint.label4.Text"];
            this.label3.Text = translate["SetupPrint.label3.Text"];
            this.btnSave.Text = translate["SetupPrint.btnSave.Text"];
            this.btnClose.Text = translate["SetupPrint.btnClose.Text"];
            this.Text = translate["SetupPrint.Text"];
        }	

        private void frmSetupPrinter_Load(object sender, EventArgs e)
        {
            try
            {
                cbPrintName2.Items.Add("");
                cbPrintName4.Items.Add("");
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cbPrintName1.Items.Add(printer);
                    cbPrintName2.Items.Add(printer);
                    cbPrintName3.Items.Add(printer);
                    cbPrintName4.Items.Add(printer);
                }
                cbPrintName2.SelectedIndex = 0;
                cbPrintName3.SelectedIndex = 0;

                string isPrintPreview, printerReport1, printerReport2, printerBill1, printerBill2;
                isPrintPreview = AppConfigFileSettings.isPrintPreview;
                printerReport1 = AppConfigFileSettings.printerReport1;
                printerReport2 = AppConfigFileSettings.printerReport2;
                printerBill1 = AppConfigFileSettings.printerBill1;
                printerBill2 = AppConfigFileSettings.printerBill2;

                if (isPrintPreview == null)
                {
                    isPrintPreview = AppConfigFileSettings.appSaleMTSetting["isPrintPreview"];
                    printerReport1 = AppConfigFileSettings.appSaleMTSetting["printerReport1"];
                    printerReport2 = AppConfigFileSettings.appSaleMTSetting["printerReport2"];
                    printerBill1 = AppConfigFileSettings.appSaleMTSetting["printerBill1"];
                    printerBill2 = AppConfigFileSettings.appSaleMTSetting["printerBill2"];
                }
                chkCheck.Checked = "1".Equals(isPrintPreview);

                //cbPrintName1.Text = printerReport1;
                //cbPrintName2.Text = printerReport2;
                //cbPrintName3.Text = printerBill1;
                //cbPrintName4.Text = printerBill2;

                cbPrintName1.Text = printerBill1;
                cbPrintName2.Text = printerBill2;
                cbPrintName3.Text = printerReport1;
                cbPrintName4.Text = printerReport2;
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmSetupPrinter_Load' : " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string isPrintPreview, printerReport1, printerReport2, printerBill1, printerBill2;
                isPrintPreview = chkCheck.Checked ? "1" : "0";
                //printerReport1 = cbPrintName1.Text;
                //printerReport2 = cbPrintName2.Text;
                //printerBill1 = cbPrintName3.Text;
                //printerBill2 = cbPrintName4.Text;

                printerBill1 = cbPrintName1.Text;
                printerBill2 = cbPrintName2.Text;
                printerReport1 = cbPrintName3.Text;
                printerReport2 = cbPrintName4.Text;

                AppConfigFileSettings.isPrintPreview = isPrintPreview;
                AppConfigFileSettings.printerReport1 = printerReport1;
                AppConfigFileSettings.printerReport2 = printerReport2;
                AppConfigFileSettings.printerBill1 = printerBill1;
                AppConfigFileSettings.printerBill2 = printerBill2;

                SortedList<string, string> appSetting = new SortedList<string, string>();
                appSetting.Add("isPrintPreview", isPrintPreview);
                appSetting.Add("printerReport1", printerReport1);
                appSetting.Add("printerReport2", printerReport2);
                appSetting.Add("printerBill1", printerBill1);
                appSetting.Add("printerBill2", printerBill2);
                AppConfigFileSettings.UpdateAppSettings(appSetting);
                MessageBox.Show(Properties.Resources.SystemSetupPrinter.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmSetupPrinter_Load' : " + ex.Message);
            }
        }
    }
}

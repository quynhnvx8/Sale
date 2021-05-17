using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.ReportSource;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;



namespace SaleMTInterfaces.PrintBill
{
    public partial class frmReportView : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();

        public string path;
        public DataSet ds;

        ReportDocument rp = new ReportDocument();
        public List<Formula> listFormula;
        #endregion

        #region Contructor
        public frmReportView()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        public void SetFormula()
        {
            if (listFormula != null && listFormula.Count > 0)
            {
                foreach (Formula f in listFormula)
                {
                    rp.DataDefinition.FormulaFields[f.FormulaName].Text = "'" + f.FormulaValue + "'";
                }
            }
        }

        private void ShowPrint(string spath)
        {
            try
            {               
                //ReportDocument rp = new ReportDocument();
                rp.Load(spath);
                rp.SetDataSource(ds);
                SetFormula();
                crystalReportViewer1.ReportSource = rp;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        /// <summary>         
        /// Người tạo Thanvn – (18/11/2013): In không xem trước.
        /// </summary>
        public void Print(int iCopies) {
            try
            {
                string printer1, printer2;
                printer1 = AppConfigFileSettings.printerBill1;
                printer2 = AppConfigFileSettings.printerBill2;
                path = Application.StartupPath + path;
                ReportDocument rp = new ReportDocument();
                rp.Load(path);
                rp.SetDataSource(ds);
                //crystalReportViewer1.ReportSource = rp;
                if (! "".Equals(printer1)) {
                    rp.PrintOptions.PrinterName = printer1;
                    rp.PrintToPrinter(iCopies, true, 0, 0);   
                }
                if (! "".Equals(printer2))
                {
                    rp.PrintOptions.PrinterName = printer2;
                    rp.PrintToPrinter(iCopies, true, 0, 0);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #region Event
        private void frmReportView_Load(object sender, EventArgs e)
        {
            try
            {                
                path = Application.StartupPath + path;
                ShowPrint(path);

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
    }

    public class Formula
    {
        public string FormulaName {get; set;}
        public string FormulaValue {get; set;}
    }
}

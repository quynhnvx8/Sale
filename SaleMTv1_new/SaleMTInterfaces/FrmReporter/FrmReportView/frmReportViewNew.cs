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
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTCommon;


namespace SaleMTInterfaces.FrmReporter.FrmReportView
{
    public partial class frmReportViewNew : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public frmReportViewNew(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            

        }
        //Các biến khai báo
        
            //private cmdPara = collection
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();

        //@DeptCode truyen theo account

        public  DataSet ds = new DataSet();
        public string StoreName, Path;


        public void SetINFBC(string strStoreName, string strPath)
        {
            try
            {
                StoreName = strStoreName;
                Path = strPath;
               
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }              
        
     private void frmReportView_Load(object sender, EventArgs e)
        {
            try
            {
                Path = Application.StartupPath + Path;
                ShowReport(ds.Tables[0], Path);

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

     private void ShowReport(DataTable dt, string spath) 
     {
         try
         {
             ReportDocument rp = new ReportDocument();
             rp.Load(spath);
             
                rp.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rp;
             CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinitions define = rp.DataDefinition.FormulaFields;
             for (int i = 0; i < define.Count; i++)
             {
                 if (translate.ContainsKey(define[i].Name.ToString()))
                     define[i].Text = "\"" + translate[define[i].Name.ToString()] + "\"";
             }

         }
         catch (Exception ex)
         {
             log.Error("Error: " + ex.Message);
         }
     }

     private void frmReportView_KeyDown(object sender, KeyEventArgs e)
     {
         try
         {
             if (e.KeyCode == Keys.Escape)
             {
                 this.Close();
             }
         }
         catch (Exception ex)
         {
             log.Error("Error: " + ex.Message);
         }
     }
    

    }
}

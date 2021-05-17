using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using SaleMTBusiness.SystemManagement;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class OptionFTP : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        
        #endregion
        public OptionFTP()
        {
            InitializeComponent();
        }


        private void ShowInfo()
        {
            this.txtHostIm.Text = ConfigurationManager.AppSettings["FTPHost"].ToString();
            this.txtHostEx.Text = ConfigurationManager.AppSettings["FTPHost"].ToString();
            this.txtUserNameIm.Text = ConfigurationManager.AppSettings["FTPUserName"].ToString();
            this.txtUserNamEx.Text = ConfigurationManager.AppSettings["FTPUserName"].ToString();
            this.txtPassIm.Text = ConfigurationManager.AppSettings["FTPPassWord"].ToString();
            this.txtPassEx.Text = ConfigurationManager.AppSettings["FTPPassWord"].ToString();
            this.txtPortIm.Text = ConfigurationManager.AppSettings["FTPPort"].ToString();
            this.txtPortEx.Text = ConfigurationManager.AppSettings["FTPPort"].ToString();
            this.txtLocalIm.Text = ConfigurationManager.AppSettings["LocalImport"].ToString();
            this.txtLocalEx.Text = ConfigurationManager.AppSettings["LocalExport"].ToString();
        }

        private void CreateFTPInfo()
        { 
            
        }

        private void chkSSLEx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void OptionFTP_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
    }
}

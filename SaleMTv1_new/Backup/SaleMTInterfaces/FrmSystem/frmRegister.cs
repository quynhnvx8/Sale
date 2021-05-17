using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmRegister : Form
    {
      
        public frmRegister(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.lblNVHienthi.Text = translate["frmRegister.lblNVHienthi.Text"];
            this.cmdGiupdo.Text = translate["frmRegister.cmdGiupdo.Text"];
            this.cmdThoat.Text = translate["frmRegister.cmdThoat.Text"];
            this.cmdChapnhan.Text = translate["frmRegister.cmdChapnhan.Text"];
            this.lblgiaima.Text = translate["frmRegister.lblgiaima.Text"];
            this.lblmadangky.Text = translate["frmRegister.lblmadangky.Text"];
        }	

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string strSucess = "Bạn đã đăng ký thành công!";
        private const string strFail = "Bạn cần liên hệ với nhà sản xuất!";
        private string licPath;
        public string LicPath
        {
            set
            {
                licPath = value;
            }
            get
            {
                return licPath;
            }
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdChapnhan_Click(object sender, EventArgs e)
        {
            try
            {
                string inf = SaleMTDataAccessLayer.SaleMTDAL.SaleMTEncrypt.EncryptX2(txtMamay.Text);
                string reg = txtReg.Text;
                if (inf == reg)
                {
                    MessageBox.Show(strSucess);
                    string fPath = licPath;
                    if (System.IO.File.Exists(fPath))
                    {
                        System.IO.File.Delete(fPath);
                    }
                    System.IO.File.WriteAllText(fPath, reg);
                    SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.isReg = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(strFail);                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error cmdChapnhan_Click: " + ex.Message);
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                string inf;
                inf = SaleMTCommon.FingerPrint.Value();
                txtMamay.Text = inf;
            }
            catch (Exception ex)
            {
                log.Error("Error frmRegister_Load: " + ex.Message);
            }
        }
    }
}

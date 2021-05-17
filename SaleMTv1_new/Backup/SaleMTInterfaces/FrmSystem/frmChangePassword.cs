using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTCommon;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Security.Cryptography; 

namespace SaleMTInterfaces.FrmSystem
{
    public partial class frmChangePassword : Form
    {
        
        public frmChangePassword(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label1.Text = translate["frmChangePassword.label1.Text"];
            this.btnClose.Text = translate["frmChangePassword.btnClose.Text"];
            this.label2.Text = translate["frmChangePassword.label2.Text"];
            this.label3.Text = translate["frmChangePassword.label3.Text"];
            this.btnSave.Text = translate["frmChangePassword.btnSave.Text"];
            this.Text = translate["frmChangePassword.Text"];
        }	

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPw,newPw,conPw;
                oldPw = txtOldPass.Text.Trim();
                newPw = txtNewPass.Text.Trim();
                conPw = txtConfirm.Text.Trim();
                if("".Equals(oldPw)){
                    MessageBox.Show(Properties.Resources.ChangePw2.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                    txtOldPass.Focus();
                    return;
                }
                if ("".Equals(newPw))
                {
                    MessageBox.Show(Properties.Resources.ChangePw3.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                    txtNewPass.Focus();
                    return;
                }
                if (newPw.Length < 6 || newPw.Length > 20) {
                    MessageBox.Show(Properties.Resources.ChangePw1.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                    txtNewPass.Focus();
                    return;
                }
                if (newPw != conPw) {
                    MessageBox.Show(Properties.Resources.ChangePw4.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                    txtConfirm.Focus();
                    return;
                }

                string proc = "USERS_Read";
                SqlParameter[] paraLogin;
                paraLogin = new SqlParameter[2];
                paraLogin[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", UserImformation.UserName);
                oldPw += UserImformation.UserName.ToLower();
                paraLogin[1] = posdb_vnmSqlDAC.newInParam("@Pw", SaleMTEncrypt.GetMd5Hash(MD5.Create(), oldPw));
                DataTable dtLogin = new DataTable();
                dtLogin = sqlDac.GetDataTable(proc, paraLogin);
                if (dtLogin.Rows.Count == 0)
                {
                    MessageBox.Show(Properties.Resources.ChangePw5.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                    txtOldPass.Text = "";
                    txtNewPass.Text = "";
                    txtConfirm.Text = "";
                    txtOldPass.Focus();
                    return;
                }
                paraLogin = new SqlParameter[2];
                paraLogin[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", UserImformation.UserName);
                newPw += UserImformation.UserName.ToLower();
                paraLogin[1] = posdb_vnmSqlDAC.newInParam("@Pw", SaleMTEncrypt.GetMd5Hash(MD5.Create(), newPw));
                sqlDac.InlineSql_ExecuteNonQuery("Update USERS set PASSWORD=@Pw where  ACCOUNT=@ACCOUNT", paraLogin);
                MessageBox.Show(Properties.Resources.SystemSetupPrinter.ToString(), Properties.rsfSales.Notice, MessageBoxButtons.OK);
                this.Close();
            }
            catch(Exception ex) {
                log.Error("Error 'Save pass': " + ex.Message);
            }            
        }

        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSave_Click(sender, e);
            }
        }
    }
}

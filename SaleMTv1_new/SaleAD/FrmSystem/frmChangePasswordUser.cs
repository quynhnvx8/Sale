using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleAD.SaleMTObjAdmin;


namespace SaleAD.FrmSystem
{
    public partial class frmChangePasswordUser : Form
    {
        rdodb_KTSqlDAC sqlDAC = new rdodb_KTSqlDAC();
        

        public frmChangePasswordUser(string acc, Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();

            textBox1.Text = acc;
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        

        private void initLanguage()
        {
            this.button1.Text = translate["frmChangePass.button1.Text"];
            this.button2.Text = translate["frmChangePass.button2.Text"];
            this.label1.Text = translate["frmChangePass.label1.Text"];
            this.label2.Text = translate["frmChangePass.label2.Text"];
            this.label3.Text = translate["frmChangePass.label3.Text"];            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(textBox3.Text))
            {
                SqlParameter[] sqlPara = new SqlParameter[2];
                sqlPara[0] = rdodb_KTSqlDAC.newInParam("@ACCOUNT", textBox1.Text.Trim());
                sqlPara[1] = rdodb_KTSqlDAC.newInParam("@PASSWORD", SaleMTEncrypt.GetMd5Hash(MD5.Create(), textBox2.Text.Trim() + textBox1.Text.ToLower().Trim()));

                sqlDAC.InlineSql_ExecuteNonQuery("update USERS set PASSWORD = @PASSWORD where ACCOUNT = @ACCOUNT", sqlPara);
                MessageBox.Show(translate["Msg.UpdateSuccess"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show(translate["Msg.PasswordNotSame"], translate["Msg.TitleDialog"] , 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}

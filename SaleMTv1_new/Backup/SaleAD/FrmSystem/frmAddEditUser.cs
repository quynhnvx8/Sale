using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleAD.SaleMTObjAdmin;
using System.Security.Cryptography;


namespace SaleAD.FrmSystem
{
    public partial class frmAddEditUser : Form
    {
        private rdodb_KTSqlDAC sqlDac = new rdodb_KTSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool add = true;

       

        public frmAddEditUser(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();

            rbtShop.Checked = true;
            cbxPermissionChangePrice.Checked = false;
            cbxPermissionDiscount.Checked = false;
            txtDiscountMoney.Enabled = false;
            txtDiscountPercent.Enabled = false;
            add = true;
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        

        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmAddEditUser.groupBox1.Text"];
            this.cbxPermissionChangePrice.Text = translate["frmAddEditUser.cbxPermissionChangePrice.Text"];
            this.cbxPermissionDiscount.Text = translate["frmAddEditUser.cbxPermissionDiscount.Text"];
            this.rbtAdmin.Text = translate["frmAddEditUser.rbtAdmin.Text"];
            this.rbtShop.Text = translate["frmAddEditUser.rbtShop.Text"];
            this.label9.Text = translate["frmAddEditUser.label9.Text"];
            this.label8.Text = translate["frmAddEditUser.label8.Text"];
            this.label7.Text = translate["frmAddEditUser.label7.Text"];
            this.label6.Text = translate["frmAddEditUser.label6.Text"];
            this.label5.Text = translate["frmAddEditUser.label5.Text"];
            this.label4.Text = translate["frmAddEditUser.label4.Text"];
            this.label3.Text = translate["frmAddEditUser.label3.Text"];
            this.label2.Text = translate["frmAddEditUser.label2.Text"];
            this.label1.Text = translate["frmAddEditUser.label1.Text"];
            this.button1.Text = translate["frmAddEditUser.button1.Text"];
            this.button2.Text = translate["frmAddEditUser.button2.Text"];
            this.Text = translate["frmAddEditUser.Text"];
        }	


        public frmAddEditUser(string acc)
        {
            InitializeComponent();
            txtUser.Text = acc;
            txtPassword.Text = "0123456789";
            txtPasswordConfirm.Text = "0123456789";
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            txtPasswordConfirm.Enabled = false;
            LoadUserInfo(acc);
            add = false;
        }

        private void LoadUserInfo(string acc)
        {
            List<USERS> listUsers = USERS.ReadByACCOUNT(acc);
            if (listUsers.Count > 0)
            {
                USERS user = listUsers[0];
                txtFirstName.Text = user.FIRSTNAME;
                txtLastName.Text = user.LASTNAME;
                txtEmail.Text = user.EMAIL;
                txtPhone.Text = user.PHONE;
                txtRemark.Text = user.REMARK;
                if (user.USER_GROUP != null && user.USER_GROUP == 1)
                {
                    rbtShop.Checked = true;
                }
                else
                {
                    rbtAdmin.Checked = true;
                }
                if (user.CHANGE_PRICE != null && user.CHANGE_PRICE == true)
                {
                    cbxPermissionChangePrice.Checked = true;
                }
                else
                {
                    cbxPermissionChangePrice.Checked = false;
                }
                if (user.DISCOUNT != null && user.DISCOUNT == true)
                {
                    cbxPermissionDiscount.Checked = true;
                    txtDiscountMoney.Enabled = true;
                    txtDiscountPercent.Enabled = true;
                }
                else
                {
                    cbxPermissionDiscount.Checked = false;
                    txtDiscountMoney.Enabled = false;
                    txtDiscountPercent.Enabled = false;
                }
                txtDiscountMoney.Text = user.DISCOUNT_MONEY.ToString();
                txtDiscountPercent.Text = user.DISCOUNT_PERCENT.ToString();
            }
 
        }

        private bool CheckValid()
        {
            bool ok = true;

            if (!txtPassword.Text.Trim().Equals(txtPasswordConfirm.Text.Trim()))
            {
                MessageBox.Show(translate["Msg.PasswordNotSame"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ok = false;
            }
            if (txtUser.Text.Trim() == "" || txtPassword.Text.Trim()=="" || txtPasswordConfirm.Text.Trim()=="" || txtFirstName.Text.Trim()=="" || txtLastName.Text.Trim()=="")
            {
                MessageBox.Show(translate["Msg.Mandatory"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ok = false;
            }
            if ((txtDiscountPercent.Text.Trim() == "" || txtDiscountMoney.Text.Trim() == "") && cbxPermissionDiscount.Checked==true)
            {
                MessageBox.Show(translate["Msg.PercentDiscount"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ok = false;
            }
            
            return ok;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                USERS user = new USERS();
                if (add == true)
                {
                    user.ACCOUNT = txtUser.Text.Trim();
                    user.PASSWORD = SaleMTEncrypt.GetMd5Hash(MD5.Create(), txtPassword.Text.Trim() + txtUser.Text.ToLower().Trim());
                    user.CREATEDATE = DateTime.Now;
                }
                else
                {
                    List<USERS> listUser = USERS.ReadByACCOUNT(txtUser.Text.Trim());
                    if (listUser.Count > 0)
                    {
                        user = listUser[0];
                    }
                }
                user.FIRSTNAME = txtFirstName.Text.Trim();
                user.LASTNAME = txtLastName.Text.Trim();
                user.PHONE = txtPhone.Text.Trim();
                user.EMAIL = txtEmail.Text.Trim();
                user.REMARK = txtRemark.Text.Trim();
                user.USER_GROUP = rbtShop.Checked ? 1 : 2;
                user.CHANGE_PRICE = cbxPermissionChangePrice.Checked;
                if (cbxPermissionDiscount.Checked)
                {
                    user.DISCOUNT = true;
                    user.DISCOUNT_MONEY = double.Parse(txtDiscountMoney.Text.Trim());
                    user.DISCOUNT_PERCENT = double.Parse(txtDiscountPercent.Text.Trim());
                }
                else
                {
                    user.DISCOUNT = false;
                    user.DISCOUNT_MONEY = 0;
                    user.DISCOUNT_PERCENT = 0;
                }
                user.Save(add);
                MessageBox.Show(translate["Msg.UpdateSuccess"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void cbxPermissionDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPermissionDiscount.Checked == true)
            {
                txtDiscountMoney.Enabled = true;
                txtDiscountPercent.Enabled = true;
            }
            else
            {
                txtDiscountMoney.Enabled = false;
                txtDiscountPercent.Enabled = false;
            }
        }

        private void txtDiscountMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && txtDiscountPercent.Text.Length > 1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

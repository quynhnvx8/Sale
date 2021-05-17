using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTBusiness.SaleManagement;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 02/10/2013 : Form kiểm tra quyền chiết khấu hóa đơn .
    /// </summary>
    public partial class frmDialogAuthentication : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Ciphertext_AES aes = new Ciphertext_AES();
        public AuthenticationEntities authenEn;        
        #endregion

        #region Contructor
      
        public frmDialogAuthentication(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label1.Text = translate["frmDialogAuthentication.label1.Text"];
            this.btnCheck.Text = translate["frmDialogAuthentication.btnCheck.Text"];
            this.label2.Text = translate["frmDialogAuthentication.label2.Text"];
            this.btnClose.Text = translate["frmDialogAuthentication.btnClose.Text"];
        }	

        #endregion

        #region method/function
        private void SaveUsersDept()
        {
            SqlParameter[] paraDept = new SqlParameter[2];
            paraDept[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", txtUser.Text.Trim());
            paraDept[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
            DataTable dtDept = sqlDac.GetDataTable("USER_DEPT_Read", paraDept);
            if (dtDept.Rows.Count == 0)
            {
                USER_DEPT userDept = new USER_DEPT();
                userDept.ID = Guid.NewGuid();
                userDept.ACCOUNT = txtUser.Text.Trim();
                userDept.DEPT_CODE = UserImformation.DeptNumber;
                userDept.IDROLE = null;
                userDept.WAREHOUSE_CODE = null;
                userDept.SEGMENT = null;
                userDept.PERMISSION_TYPE = "STORE";
                userDept.Save(true);
            } 
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Form load .
        /// </summary>
        private void frmDialogAuthentication_Load(object sender, EventArgs e)
        {
            //log.Debug("Notice: Form started !.");
            txtUser.Focus();
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Button click : Check quyền chiết khấu .
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text.Trim().Length == 0)
                {                    
                    MessageBox.Show(Properties.rsfSales.Authentication.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if (txtPass.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Properties.rsfSales.Authentication1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (authenEn != null)
                    {
                        string pw = txtPass.Text.Trim()+ txtUser.Text.Trim();
                        string password = EncryptDecryptText.EncryptAndEncode(pw); 
                        SqlParameter[] para = new SqlParameter[4];
                        para[0] = posdb_vnmSqlDAC.newInParam("@ACCOUNT", txtUser.Text.Trim());
                        para[1] = posdb_vnmSqlDAC.newInParam("@PASSWORD", password);
                        para[2] = posdb_vnmSqlDAC.newInParam("@DISCOUNT", false);
                        para[3] = posdb_vnmSqlDAC.newInParam("@CHANGE_PRICE", false);
                        DataTable dtAuthen = new DataTable();
                        dtAuthen = sqlDac.GetDataTable("USERS_Authentication", para);
                        if (dtAuthen.Rows.Count > 0)
                        {
                            bool discount = Convert.ToBoolean(dtAuthen.Rows[0]["DISCOUNT"].ToString());
                            bool changePrice = Convert.ToBoolean(dtAuthen.Rows[0]["CHANGE_PRICE"].ToString());
                            if (authenEn.DiscountRight == true && discount == false)
                            {
                                MessageBox.Show(string.Format(Properties.rsfSales.Authentication5,txtUser.Text.Trim()),
                                Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else if (authenEn.ChangePriceRight == true && changePrice == false)
                            {
                                MessageBox.Show(string.Format(Properties.rsfSales.Authentication4,txtUser.Text.Trim()),
                                Properties.rsfSales.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                // Kiểm tra nếu User chưa liên kết quyền chiết khấu,thay đổi giá cho cửa hàng hiện tại thì thêm mới liên kết
                                SaveUsersDept();
                                // Gán giá trị entities trả về
                                authenEn = new AuthenticationEntities();
                                authenEn.Check = true;
                                authenEn.Users = txtUser.Text.Trim();
                                authenEn.MaxMoney = Convert.ToDouble(dtAuthen.Rows[0]["DISCOUNT_MONEY"].ToString());
                                authenEn.MaxPercent = Convert.ToInt32(dtAuthen.Rows[0]["DISCOUNT_PERCENT"].ToString());
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show(Properties.rsfSales.Authentication2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            txtPass.Text = "";
                            txtPass.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Button click : Đóng form .
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Người tạo Luannv – 27/09/2013 : Xử lý khi nhấn phím ESC đóng form.         
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("ProcessCmdKey - error: " + ex.Message);
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// Người tạo Luannv – 02/10/2013 : Ghi file log form đã đóng .
        /// </summary>
        private void frmDialogAuthentication_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        #endregion

        

    }
}

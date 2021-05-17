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

using SaleMTCommon;
using SaleMTBusiness.SaleManagement;


namespace SaleMTInterfaces.FrmSaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 01/10/2013 : Chiết khấu hóa đơn bán hàng .
    /// </summary>
    public partial class frmDialogSpecialDiscount : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private const string FOR_PRO_YES = "-2";
        private const string FOR_PRO_NO = "-1";
        private const string DIS_TYPE_TIM = "TIM";
        private const string DIS_TYPE_SPE = "SPE";

        private DataTable dtDiscountTime;
        private DataTable dtProduct;
        private DataTable dtChooseProduct;
        private SALES_SPECIAL_DISCOUNT saleSpecial;

        public SALES_SPECIAL_DISCOUNT SaleSpecial
        {
            get { return saleSpecial; }
            set { saleSpecial = value; }
        }

        public DataTable DtProduct
        {
            get { return dtProduct; }
            set { dtProduct = value; }
        }

        public DataTable DtChooseProduct
        {
            get { return dtChooseProduct; }
            set { dtChooseProduct = value; }
        }
        #endregion

        #region Contructor
        
        public frmDialogSpecialDiscount(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.rdbTime.Text = translate["frmDialogSpecialDiscount.rdbTime.Text"];
            this.rdbSpecial.Text = translate["frmDialogSpecialDiscount.rdbSpecial.Text"];
            this.label4.Text = translate["frmDialogSpecialDiscount.label4.Text"];
            this.label3.Text = translate["frmDialogSpecialDiscount.label3.Text"];
            this.label2.Text = translate["frmDialogSpecialDiscount.label2.Text"];
            this.label1.Text = translate["frmDialogSpecialDiscount.label1.Text"];
            this.btnOk.Text = translate["frmDialogSpecialDiscount.btnOk.Text"];
            this.btnClose.Text = translate["frmDialogSpecialDiscount.btnClose.Text"];
            this.label5.Text = translate["frmDialogSpecialDiscount.label5.Text"];
            this.label6.Text = translate["frmDialogSpecialDiscount.label6.Text"];
            this.Text = translate["frmDialogSpecialDiscount.Text"];
        }	

        #endregion

        #region Method/Function
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Load loại chiết khấu .
        /// </summary>
        private void LoadDiscountType()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@NhomVT_ID", null) };
                DataTable dtDiscountType = new DataTable();
                dtDiscountType = sqlDac.GetDataTable("DEV_IN_DM_NHOMVATTU_Read", para);
                if (dtDiscountType.Rows.Count > 0)
                {
                    cboDiscountType.DataSource = dtDiscountType;
                    cboDiscountType.DisplayMember = "TenNhom";
                    cboDiscountType.ValueMember = "MaNhom";
                    cboDiscountType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadDiscountType': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Load người chiết khấu .
        /// </summary>
        private void LoadDiscounBy()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@ACCOUNT", null) };
                DataTable dtDiscountBy = new DataTable();
                dtDiscountBy = sqlDac.GetDataTable("USERS_DiscountSearch", para);
                if (dtDiscountBy.Rows.Count > 0)
                {
                    cboDiscountBy.DataSource = dtDiscountBy;
                    cboDiscountBy.DisplayMember = "FULLNAME";
                    cboDiscountBy.ValueMember = "ACCOUNT";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'LoadDiscounBy': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Load chiết khấu thời điểm .
        /// </summary>
        private void LoadDiscountTime()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber) };
                dtDiscountTime = new DataTable();
                dtDiscountTime = sqlDac.GetDataTable("DISCOUNT_TERM_Search", para);
                if (dtDiscountTime.Rows.Count > 0)
                {
                    cboDiscountTime.DataSource = dtDiscountTime;
                    cboDiscountTime.DisplayMember = "DISCOUNT_NAME";
                    cboDiscountTime.ValueMember = "DISCOUNT_CODE";
                    cboDiscountTime.SelectedIndex = 0;
                    DataRow[] rTermCode = dtDiscountTime.Select("DISCOUNT_CODE = '" + cboDiscountTime.SelectedValue.ToString().Trim() + "'");
                    txtDiscountTime.Text = (rTermCode.Length > 0) ? rTermCode[0]["DISCOUNT_AMOUNT"].ToString() : "0";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'LoadDiscountTime': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Tính tổng số tiền chiết khấu .
        /// </summary>
        private float GetTotalDiscount(DataTable dt, float percentDiscount)
        {
            float total = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (cboDiscountType.Text.ToString() == "Theo sản phẩm" || cboDiscountType.Text.ToString() == "Tất cả")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            float intoMoney = (float)Convert.ToDouble(Conversion.Replaces(dt.Rows[i]["INTOMONEY"].ToString()));
                            total = total + (percentDiscount * intoMoney);
                        }
                    }
                    else
                    {
                        string category = cboDiscountType.SelectedValue.ToString();
                        DataRow[] dRow = dt.Select("CATEGORY = '" + category + "'");
                        for (int i = 0; i < dRow.Length; i++)
                        {
                            float intoMoney = (float)Convert.ToDouble(Conversion.Replaces(dRow[i]["INTOMONEY"].ToString()));
                            total = total + (percentDiscount * intoMoney);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetTotalDiscount': " + ex.Message);
            }
            return total;
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Show or hide Panel discount .
        /// </summary>
        private void PanelVisible()
        {
            try
            {
                pnlSpecial.Visible = rdbSpecial.Checked;
                pnlTime.Visible = rdbTime.Checked;
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetTotalDiscount': " + ex.Message);
            }
        }
        #endregion

        #region Event 
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Form load .
        /// </summary>
        private void frmDialogSpecialDiscount_Load(object sender, EventArgs e)
        {
            //log.Debug("Notice: form started.");
            try
            { 
                rdbSpecial.Checked = true;
                LoadDiscountType();
                LoadDiscounBy();
                txtPercent.Text = "%";
                txtMoney.Text = "$";
                PanelVisible();
                LoadDiscountTime();
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : chọn tiêu điểm txtPercent.
        /// </summary>
        private void txtPercent_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtPercent.Text.Trim() == "%")
                {
                    txtPercent.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Hủy tiêu điểm txtPercent.
        /// </summary>
        private void txtPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPercent.Text.Trim().Length == 0)
                {
                    txtPercent.Text = "%";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chọn tiêu điểm txtMoney.
        /// </summary>
        private void txtMoney_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtMoney.Text.Trim() == "$")
                {
                    txtMoney.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Hủy tiêu điểm txtMoney.
        /// </summary>
        private void txtMoney_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMoney.Text.Trim().Length == 0)
                {
                    txtMoney.Text = "$";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn các ký tự không hợp lệ txtMoney.
        /// </summary>
        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtMoney.Text.Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn các ký tự không hợp lệ txtPercent.
        /// </summary>
        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtPercent.Text.Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                    int per = Convert.ToInt32(txtPercent.Text+e.KeyChar);
                    if (per > 99)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Tự động định dạng kiểu tiền tệ khi nhập vào textbox.
        /// </summary>
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMoney.Text.Trim().Length > 0 && txtMoney.Text.Trim() != "0" && txtMoney.Text.Trim() != "$")
                {
                    txtMoney.Text = Conversion.GetCurrency(Conversion.Replaces(txtMoney.Text));
                    txtMoney.SelectionStart = txtMoney.Text.Trim().Length;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Nếu chọn loại chiết khấu = theo sản phẩm mở dialog chọn sản phẩm chiết khấu.
        /// </summary>
        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDiscountType.Text.ToString() == "Theo sản phẩm")
                {
                    frmDialogDiscountProduct dialogDiscountProduct = new frmDialogDiscountProduct(translate);
                    DataTable dt = new DataTable();
                    dt = DtProduct.Copy();
                    dialogDiscountProduct.DtProduct = dt;
                    dialogDiscountProduct.StartPosition = FormStartPosition.CenterScreen;
                    dialogDiscountProduct.ShowDialog();
                    this.DtChooseProduct = dialogDiscountProduct.DtProduct;
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Hủy chiết khấu.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //log.Debug("Notice: form closed.");
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý chiết khấu.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Chiết khấu đặc biệt
            try
            {
                DtChooseProduct = (DtChooseProduct == null) ? DtProduct : DtChooseProduct;
                if (rdbSpecial.Checked)
                {
                    if (txtPercent.Text.Trim() != "%" && txtMoney.Text.Trim() != "$")
                    {
                        MessageBox.Show(Properties.rsfSales.SpecialDiscount.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (txtPercent.Text.Trim() == "%" && txtMoney.Text.Trim() == "$")
                    {
                        MessageBox.Show(Properties.rsfSales.SpecialDiscount1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (cboDiscountBy.SelectedIndex < 0)
                    {
                        MessageBox.Show(Properties.rsfSales.SpecialDiscount2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (txtRemarks.Text.Trim().Length == 0)
                    {
                        MessageBox.Show(Properties.rsfSales.SpecialDiscount3.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        saleSpecial = new SALES_SPECIAL_DISCOUNT();

                        frmDialogAuthentication dialogAuthen = new frmDialogAuthentication(translate);
                        dialogAuthen.authenEn = new AuthenticationEntities();
                        dialogAuthen.authenEn.ChangePriceRight = true;
                        dialogAuthen.authenEn.DiscountRight = false;
                        dialogAuthen.StartPosition = FormStartPosition.CenterScreen;
                        dialogAuthen.Text = "Đăng nhập quyền chiết khấu đặc biệt";
                        dialogAuthen.ShowDialog();
                        if (dialogAuthen.authenEn.Check)
                        {
                            // Kiểm tra quyền chiết khấu tối đa
                            float per = (txtPercent.Text.Trim() != "%") ? (float)Convert.ToDouble(txtPercent.Text) : 0;
                            float mon = (txtMoney.Text.Trim() != "$") ? (float)Convert.ToDouble(Conversion.Replaces(txtMoney.Text)) : 0;
                            string[] maxmon = { dialogAuthen.authenEn.Users, dialogAuthen.authenEn.MaxMoney.ToString() };
                            string[] maxper = { dialogAuthen.authenEn.Users, dialogAuthen.authenEn.MaxPercent.ToString() };
                            if (mon > dialogAuthen.authenEn.MaxMoney)
                            {
                                MessageBox.Show(string.Format(Properties.rsfSales.SpecialDiscount5, maxmon), Properties.rsfSales.Notice,
                                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else if (per > dialogAuthen.authenEn.MaxPercent)
                            {
                                MessageBox.Show(string.Format(Properties.rsfSales.SpecialDiscount7, maxper), Properties.rsfSales.Notice,
                                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                saleSpecial.AUTHENTICATION_BY = dialogAuthen.authenEn.Users;
                                saleSpecial.DISCOUNT_BY = UserImformation.UserName;
                                saleSpecial.REMARK = txtRemarks.Text;
                                saleSpecial.DISCOUNT_TYPE = DIS_TYPE_SPE;
                                // chiết khấu theo %
                                if (txtPercent.Text.Trim() != "%")
                                {
                                    float percentDiscount = (float)(Convert.ToDouble(txtPercent.Text) / 100);

                                    saleSpecial.TOTAL_DISCOUNT_AMOUNT = GetTotalDiscount(DtChooseProduct, percentDiscount);
                                    saleSpecial.DISCOUNT_PECENT = (float)Convert.ToDouble(txtPercent.Text);
                                    saleSpecial.FOR_PRODUCT = (cboDiscountType.Text.ToString() == "Theo sản phẩm") ? FOR_PRO_YES : FOR_PRO_NO;
                                    saleSpecial.DISCOUNT_AMOUNT = 0;
                                }
                                else // chiết khấu theo số tiền .
                                {
                                    saleSpecial.TOTAL_DISCOUNT_AMOUNT = (float)Convert.ToDouble(Conversion.Replaces(txtMoney.Text));
                                    saleSpecial.DISCOUNT_PECENT = 0;
                                    saleSpecial.FOR_PRODUCT = (cboDiscountType.Text.ToString() == "Theo sản phẩm") ? FOR_PRO_YES : FOR_PRO_NO;
                                    saleSpecial.DISCOUNT_AMOUNT = 0;
                                }
                                this.Close();
                            }
                        }

                    }
                }
                else // chiết khấu thời điểm
                {
                    float percentDiscount = (float)(Convert.ToDouble(txtDiscountTime.Text) / 100);
                    saleSpecial = new SALES_SPECIAL_DISCOUNT();
                    saleSpecial.TOTAL_DISCOUNT_AMOUNT = GetTotalDiscount(DtProduct, percentDiscount);
                    saleSpecial.DISCOUNT_PECENT = (float)Convert.ToDouble(txtDiscountTime.Text);
                    saleSpecial.DISCOUNT_BY = UserImformation.UserName;
                    saleSpecial.FOR_PRODUCT = FOR_PRO_NO;
                    saleSpecial.DISCOUNT_AMOUNT = 0;
                    saleSpecial.REMARK = "";                    
                    saleSpecial.DISCOUNT_TYPE = DIS_TYPE_TIM;
                    saleSpecial.DISCOUNT_TERM_CODE = cboDiscountTime.SelectedValue.ToString().Trim();
                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
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
        /// Người tạo Luannv – 01/10/2013 : Chọn loại chiết khấu là chiết khấu đặc biệt .
        /// </summary>
        private void rdbSpecial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PanelVisible();
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chọn loại chiết khấu là chiết khấu thời điểm .
        /// </summary>
        private void rdbTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PanelVisible();
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Thay đổi lựa chọn chiết khấu thời điểm .
        /// </summary>
        private void cboDiscountTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDiscountTime.SelectedIndex != -1)
                {
                    //txtDiscountTime.Text = cboDiscountTime.SelectedValue.ToString();
                    DataRow[] rTermCode = dtDiscountTime.Select("DISCOUNT_CODE = '" + cboDiscountTime.SelectedValue.ToString().Trim() + "'");
                    txtDiscountTime.Text = (rTermCode.Length > 0) ? rTermCode[0]["DISCOUNT_AMOUNT"].ToString() : "0";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn không cho nhập vào textbox % chiết khấu thời điểm .
        /// </summary>
        private void txtDiscountTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                log.Error(" Error: " + ex.Message);
            }
        }
        #endregion
    }
}

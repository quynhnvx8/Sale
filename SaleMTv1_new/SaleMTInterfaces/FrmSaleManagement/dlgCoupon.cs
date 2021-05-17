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
using SaleMTBusiness.SaleManagement;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class dlgCoupon : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private List<string> lstCoupon = new List<string>();

        public List<string> LstCoupon
        {
            get { return lstCoupon; }
            set { lstCoupon = value; }
        }
        private double percent;

        public double Percent
        {
            get { return percent; }
            set { percent = value; }
        }
        #endregion

        #region Contructor
        

        public dlgCoupon(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["dlgCoupon.groupBox1.Text"];
            this.btnClose.Text = translate["dlgCoupon.btnClose.Text"];
            this.btnOK.Text = translate["dlgCoupon.btnOK.Text"];
            this.columnHeader1.Text = translate["dlgCoupon.columnHeader1.Text"];
            this.columnHeader2.Text = translate["dlgCoupon.columnHeader2.Text"];
            this.columnHeader3.Text = translate["dlgCoupon.columnHeader3.Text"];
            this.columnHeader4.Text = translate["dlgCoupon.columnHeader4.Text"];
            this.columnHeader5.Text = translate["dlgCoupon.columnHeader5.Text"];
            this.btnAdd.Text = translate["dlgCoupon.btnAdd.Text"];
            this.Text = translate["dlgCoupon.Text"];
        }	

        #endregion

        #region Method
        private void BindCoupon(string couCode,bool reload)
        {
            try
            {
                DataTable dt = Sale.CheckDiscount(couCode, sqlDac);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["COUPON_STATUS"].ToString().Trim() == "USED")
                    {
                        if (!reload)
                        {
                            MessageBox.Show(Properties.rsfSales.Coupon2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                                 MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else if (dt.Rows[0]["COUPON_STATUS"].ToString().Trim() == "WAITING")
                    {
                        if (!reload)
                        MessageBox.Show(Properties.rsfSales.Coupon3.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                                 MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else if (dt.Rows[0]["COUPON_STATUS"].ToString().Trim() == "CANCEL")
                    {
                        if (!reload)
                        MessageBox.Show(Properties.rsfSales.Coupon4.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                                 MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        //check tồn tại
                        bool check = true;
                        for (int i = 0; i < lvwlistDiscount.Items.Count; i++)
                        {
                            if (lvwlistDiscount.Items[i].SubItems[3].Text.Trim()==dt.Rows[0]["COUPON_NO"].ToString())
                            {
                                check = false;
                            }
                        }
                        if (check)
                        {
                            int count = lvwlistDiscount.Items.Count;
                            lvwlistDiscount.Items.Add(dt.Rows[0]["VOUCHER_NAME"].ToString());
                            lvwlistDiscount.Items[count].SubItems.Add(dt.Rows[0]["FROM_DATE"].ToString());
                            lvwlistDiscount.Items[count].SubItems.Add(dt.Rows[0]["TO_DATE"].ToString());
                            lvwlistDiscount.Items[count].SubItems.Add(dt.Rows[0]["COUPON_NO"].ToString());
                            lvwlistDiscount.Items[count].SubItems.Add(dt.Rows[0]["COUPON_PERCENT"].ToString());
                            lvwlistDiscount.Items[count].Selected = true;
                        }
                    }
                }
                else
                {
                    if (!reload)
                    MessageBox.Show(Properties.rsfSales.Coupon1.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                         MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindCoupon': " + ex.Message);
            }
        }
        #endregion

        #region event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BindCoupon(txtDiscountCode.Text.Trim(),false);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void dlgDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                txtDiscountCode.Focus();
                if (lstCoupon.Count > 0)
                {
                    for (int i = 0; i < lstCoupon.Count; i++)
                    { 
                        BindCoupon(lstCoupon[i].ToString(),true);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.percent = 0;
                ListView.ListViewItemCollection item = lvwlistDiscount.Items;
                if (item.Count > 0)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        this.percent = this.percent + Convert.ToDouble(item[i].SubItems[4].Text.Trim());
                        //check tồn tại
                        bool check = true;
                        for (int j = 0; j < lstCoupon.Count; j++)
                        {
                            if (lstCoupon[j].ToString() == item[i].SubItems[3].Text.Trim())
                            {
                                check = false;
                            }
                        }
                        if (check)
                            lstCoupon.Add(item[i].SubItems[3].Text.Trim());
                    }
                    
                }
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwlistDiscount.Items.Count > 0)
                {
                    DialogResult re = MessageBox.Show(Properties.rsfSales.Coupon.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (re == DialogResult.Yes)
                    {
                        lvwlistDiscount.Items.Clear();
                        this.percent = 0;
                        this.lstCoupon.Clear();
                    }
                    else
                    {
                        ListView.ListViewItemCollection item = lvwlistDiscount.Items;
                        if (item.Count > 0)
                        {
                            for (int i = 0; i < item.Count; i++)
                            {
                                this.percent = this.percent + Convert.ToDouble(item[i].SubItems[4].Text.Trim());
                                ////check tồn tại
                                //bool check = true;
                                //for (int j = 0; j < lstCoupon.Count; j++)
                                //{
                                //    if (lstCoupon[j].ToString() == item[i].SubItems[3].Text.Trim())
                                //    {
                                //        check = false;
                                //    }
                                //}  
                              
                            }
                            this.Close();
                        }
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void lvwlistDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListView.SelectedListViewItemCollection item = lvwlistDiscount.SelectedItems;
                if (item.Count > 0)
                {
                    lvwlistDiscount.Items.Remove(item[0]);
                }
            }
        }

        private void txtDiscountCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BindCoupon(txtDiscountCode.Text.Trim(), false);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

    }
}

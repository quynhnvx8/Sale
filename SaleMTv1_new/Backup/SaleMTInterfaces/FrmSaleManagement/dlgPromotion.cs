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
using System.Reflection;
using System.Data.SqlClient;
using System.IO;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class dlgPromotion : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataSet dsPromotion;
        private double discount;
        private List<string> lstProPercent = new List<string>();

        public List<string> LstProPercent
        {
            get { return lstProPercent; }
            set { lstProPercent = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public DataSet DsPromotion
        {
            get { return dsPromotion; }
            set { dsPromotion = value; }
        }
        #endregion

        #region Contructor
        
        public dlgPromotion(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.tabNum.Text = translate["dlgPromotion.tabNum.Text"];
            this.groupBox1.Text = translate["dlgPromotion.groupBox1.Text"];
            this.colProCode.Text = translate["dlgPromotion.colProCode.Text"];
            this.colProName.Text = translate["dlgPromotion.colProName.Text"];
            this.colDateFrom.Text = translate["dlgPromotion.colDateFrom.Text"];
            this.colDateTo.Text = translate["dlgPromotion.colDateTo.Text"];
            this.colNumMin.Text = translate["dlgPromotion.colNumMin.Text"];
            this.colNumMax.Text = translate["dlgPromotion.colNumMax.Text"];
            this.columnHeader7.Text = translate["dlgPromotion.columnHeader7.Text"];
            this.columnHeader8.Text = translate["dlgPromotion.columnHeader8.Text"];
            this.columnHeader9.Text = translate["dlgPromotion.columnHeader9.Text"];
            this.columnHeader10.Text = translate["dlgPromotion.columnHeader10.Text"];
            this.columnHeader11.Text = translate["dlgPromotion.columnHeader11.Text"];
            this.btnOK.Text = translate["dlgPromotion.btnOK.Text"];
            this.btnClose.Text = translate["dlgPromotion.btnClose.Text"];
            this.Text = translate["dlgPromotion.Text"];
        }	

        #endregion

        #region Method/Function
        //Load chuong trinh khuyen mai theo ma san pham
        private void LoadPromotion()
        {
            try
            {
                if (this.dsPromotion.Tables[0].Rows.Count > 0)
                {
                    DataTable dtPromotion = dsPromotion.Tables[0];
                    lvwProgram.Items.Clear();
                    for (int i = 0; i < dtPromotion.Rows.Count; i++)
                    {
                        lvwProgram.Items.Add(dtPromotion.Rows[i]["PROMOTION_DETAIL_NO"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["PROMOTION_DETAIL_NAME"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["FROM_DATE"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["TO_DATE"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["QUANTITY_MIN"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["QUANTITY_MAX"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["DISCOUNT_ON"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["DISCOUNT_VALUE"].ToString());
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["QUANTITY"].ToString());
                        lvwProgram.Items[i].SubItems.Add(Conversion.GetCurrency(dtPromotion.Rows[i]["Amount"].ToString()));
                        lvwProgram.Items[i].SubItems.Add(Conversion.GetCurrency(dtPromotion.Rows[i]["Discount_Amount"].ToString()));
                        lvwProgram.Items[i].SubItems.Add(dtPromotion.Rows[i]["PRODUCT_ID"].ToString());
                    }
                    if (lvwProgram.Items.Count > 0)
                    {
                        lvwProgram.Items[0].Selected = true;
                        lvwProgram.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadPromotion': " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void dlgPromotion_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPromotion();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.ListViewItemCollection item = lvwProgram.Items;
                discount = 0;
                if (item.Count > 0)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        double value = Convert.ToDouble(Conversion.Replaces(item[i].SubItems[7].Text.Trim()));
                        if (value > 0)
                        {
                            discount = discount + Convert.ToDouble(Conversion.Replaces(item[i].SubItems[10].Text.Trim()));
                            bool check = true;
                            
                            for (int j = 0; j < lstProPercent.Count; j++)
                            {
                                if (lstProPercent[j].ToString() == item[i].SubItems[11].Text.Trim())
                                {
                                    check = false;
                                }
                            }
                            if (check)
                                lstProPercent.Add(item[i].SubItems[11].Text.Trim());
                        }
                    }
                    this.Close();   
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Xử lý các phím tắt trên form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                try
                {
                    ListView.ListViewItemCollection item = lvwProgram.Items;
                    discount = 0;
                    if (item.Count > 0)
                    {
                        for (int i = 0; i < item.Count; i++)
                        {
                            double value = Convert.ToDouble(Conversion.Replaces(item[i].SubItems[7].Text.Trim()));
                            if (value > 0)
                            {
                                discount = discount + Convert.ToDouble(Conversion.Replaces(item[i].SubItems[10].Text.Trim()));
                                bool check = true;

                                for (int j = 0; j < lstProPercent.Count; j++)
                                {
                                    if (lstProPercent[j].ToString() == item[i].SubItems[11].Text.Trim())
                                    {
                                        check = false;
                                    }
                                }
                                if (check)
                                    lstProPercent.Add(item[i].SubItems[11].Text.Trim());
                            }
                        }
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("ProcessCmdKey - Keys.Enter: " + ex.Message);
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    }
}

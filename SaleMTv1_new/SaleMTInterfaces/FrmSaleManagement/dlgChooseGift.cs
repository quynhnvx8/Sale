using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTBusiness.SaleManagement;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class dlgChooseGift : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string FOR_TYPE2 = "2";
        private const string FOR_TYPE1 = "1";
        private int countPro=0;
        private StringBuilder strXml;

        public StringBuilder StrXml
        {
            get { return strXml; }
            set { strXml = value; }
        }
        private DataTable dtGift;

        public DataTable DtGift
        {
            get { return dtGift; }
            set { dtGift = value; }
        }
        #endregion

        #region Contructor
        
        public dlgChooseGift(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label1.Text = translate["dlgChooseGift.label1.Text"];
            this.btnOK.Text = translate["dlgChooseGift.btnOK.Text"];
            this.btnClose.Text = translate["dlgChooseGift.btnClose.Text"];
            this.grbGift2.Text = translate["dlgChooseGift.grbGift2.Text"];
            this.columnHeader1.Text = translate["dlgChooseGift.columnHeader1.Text"];
            this.columnHeader2.Text = translate["dlgChooseGift.columnHeader2.Text"];
            this.columnHeader3.Text = translate["dlgChooseGift.columnHeader3.Text"];
            this.columnHeader4.Text = translate["dlgChooseGift.columnHeader4.Text"];
            this.columnHeader5.Text = translate["dlgChooseGift.columnHeader5.Text"];
            this.columnHeader6.Text = translate["dlgChooseGift.columnHeader6.Text"];
            this.colProCode.Text = translate["dlgChooseGift.colProCode.Text"];
            this.colProName.Text = translate["dlgChooseGift.colProName.Text"];
            this.colQuantity.Text = translate["dlgChooseGift.colQuantity.Text"];
            this.colTK.Text = translate["dlgChooseGift.colTK.Text"];
            this.colProgramPro.Text = translate["dlgChooseGift.colProgramPro.Text"];
            this.colProgramCode.Text = translate["dlgChooseGift.colProgramCode.Text"];
            this.grbGift1.Text = translate["dlgChooseGift.grbGift1.Text"];
            this.Text = translate["dlgChooseGift.Text"];
        }	

        #endregion

        #region Method
        private void LoadGift()
        {
            try
            {
                if (dtGift != null)
                {
                    DataRow[] row1 = dtGift.Select("FOR_TYPE = '" + FOR_TYPE1 + "'");
                    if (row1.Length > 0)
                    {
                        for (int i = 0; i < row1.Length; i++)
                        {
                            string isBul = row1[i]["isBundle"].ToString().Trim();
                             if (isBul.Trim() != "True")
                             {
                                 lvwGift1.Items.Add(row1[i]["PRODUCT_ID_GIFTS"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PRODUCT_NAME"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["QUANTITY_GIFTS"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["INVENTORY"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PROMOTION_DETAIL_NO"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PROMOTION_DETAIL_NAME"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["isBundle"].ToString());
                                 countPro = countPro + Convert.ToInt32(row1[i]["QUANTITY_REG"].ToString());
                             }
                             else
                             {
                                 double tk = Convert.ToDouble(row1[i]["INVENTORY"].ToString());
                                 double sl = Convert.ToDouble(row1[i]["QUANTITY_GIFTS"].ToString());
                                 //kiểm tra nếu tồn kho < 0 set = 0
                                 countPro = countPro + Convert.ToInt32(row1[i]["QUANTITY_REG"].ToString());
                                 if (tk < sl)
                                 {
                                     row1[i]["QUANTITY_GIFTS"] = 0;
                                 }
                                 

                                 lvwGift1.Items.Add(row1[i]["PRODUCT_ID_GIFTS"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PRODUCT_NAME"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["QUANTITY_GIFTS"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(tk.ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PROMOTION_DETAIL_NO"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["PROMOTION_DETAIL_NAME"].ToString());
                                 lvwGift1.Items[i].SubItems.Add(row1[i]["isBundle"].ToString());
                                 
                             }
                        }
                    }
                    DataRow[] row2 = dtGift.Select("FOR_TYPE = '" + FOR_TYPE2 + "'");
                    if (row2.Length > 0)
                    {
                        for (int i = 0; i < row2.Length; i++)
                        {
                            string isBul = row2[i]["isBundle"].ToString().Trim();
                            if (isBul.Trim() != "True")
                            {
                                lvwGift2.Items.Add(row2[i]["PRODUCT_ID_GIFTS"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PRODUCT_NAME"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["QUANTITY_GIFTS"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["INVENTORY"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PROMOTION_DETAIL_NO"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PROMOTION_DETAIL_NAME"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["isBundle"].ToString());
                                countPro = countPro + Convert.ToInt32(row2[i]["QUANTITY_REG"].ToString());
                            }
                            else
                            {
                                double tk2 = Convert.ToDouble(row2[i]["INVENTORY"].ToString());
                                double sl2 = Convert.ToDouble(row2[i]["QUANTITY_GIFTS"].ToString());
                                countPro = countPro + Convert.ToInt32(row2[i]["QUANTITY_REG"].ToString());
                                if (tk2 < sl2)
                                {
                                    row2[i]["QUANTITY_GIFTS"] = 0;
                                }

                                lvwGift2.Items.Add(row2[i]["PRODUCT_ID_GIFTS"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PRODUCT_NAME"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["QUANTITY_GIFTS"].ToString());
                                lvwGift2.Items[i].SubItems.Add(tk2.ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PROMOTION_DETAIL_NO"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["PROMOTION_DETAIL_NAME"].ToString());
                                lvwGift2.Items[i].SubItems.Add(row2[i]["isBundle"].ToString());
                                
                            }
                        }
                    }

                    // xử lý focus
                    if (lvwGift1.Items.Count > 0)
                    {
                        lvwGift1.Items[0].Selected = true;
                        lvwGift1.Focus();
                    }
                    else if (lvwGift2.Items.Count > 0)
                    {
                        lvwGift2.Items[0].Selected = true;
                        lvwGift2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void ChangeQuantity1()
        {
            try
            {
                int quantity = 0;
                ListView.SelectedListViewItemCollection item1 = lvwGift1.SelectedItems;
                if (item1.Count > 0)
                {
                    string isBul = item1[0].SubItems[6].Text.ToString().Trim();
                    if (isBul.Trim() != "True")
                    {
                        quantity = Convert.ToInt32(item1[0].SubItems[2].Text.Trim());
                        quantity = Sale.ShowInputQuantity(quantity);
                        item1[0].SubItems[2].Text = quantity.ToString();
                        // xử lý thay đổi số lượng tại datatable source
                        DataRow[] row = dtGift.Select("PRODUCT_ID_GIFTS = '" + item1[0].Text + "' and PROMOTION_DETAIL_NO = '" + item1[0].SubItems[4].Text + "'");
                        if (row.Length > 0)
                        {
                            row[0]["QUANTITY_GIFTS"] = quantity;
                        }
                    }
                    else
                    {
                        MessageBox.Show(translate["Msg.NoPermissionQty"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                    }
                }               
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void ChangeQuantity2()
        {
            try
            {
                int quantity = 0;
                ListView.SelectedListViewItemCollection item2 = lvwGift2.SelectedItems;               
                if (item2.Count > 0)
                {
                    string isBul = item2[0].SubItems[6].Text.ToString().Trim();
                    if (isBul.Trim() != "True")
                    {
                        quantity = Convert.ToInt32(item2[0].SubItems[2].Text.Trim());
                        quantity = Sale.ShowInputQuantity(quantity);
                        item2[0].SubItems[2].Text = quantity.ToString();
                        // xử lý thay đổi số lượng tại datatable source
                        DataRow[] row = dtGift.Select("PRODUCT_ID_GIFTS = '" + item2[0].Text + "' and PROMOTION_DETAIL_NO = '" + item2[0].SubItems[4].Text + "'");
                        if (row.Length > 0)
                        {
                            row[0]["QUANTITY_GIFTS"] = quantity;
                                
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show(translate["Msg.NoPermissionQty"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void Choosed()
        {
            try
            {
                int count = 0;
                string listError = "";
                strXml = new StringBuilder();
                strXml.Append("SL       -     Mã      -        Tên SP                                         \n");
                strXml.Append("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                
                foreach (ListViewItem item in lvwGift1.Items)
                {
                    int quantity = Convert.ToInt32(item.SubItems[2].Text.Trim());
                    int inventory = Convert.ToInt32(item.SubItems[3].Text.Trim());
                    string program = "";
                    program = item.SubItems[4].Text + " (" + item.SubItems[5].Text + ")";
                    count = int.Parse(dtGift.Compute("Sum(QUANTITY_GIFTS)", "FOR_TYPE=1 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'").ToString());
                    object ob = dtGift.Compute("Sum(QUANTITY_GIFTS)", "FOR_TYPE=2 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'");
                    int countNew=0;
                    if (int.TryParse(ob.ToString(), out countNew))
                    {
                        countNew = int.Parse(ob.ToString());
                    }
                    countPro = int.Parse(dtGift.Compute("Sum(QUANTITY)", "FOR_TYPE=1 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'").ToString()); 
                    //check số lượng
                    if (count > countPro && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion1, program),
                            Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    else if (count < countPro && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion3, program),
                         Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                         MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    else if (countNew > 0 && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion5, program),
                             Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                             MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    if (quantity <= inventory || quantity == 0)
                    {
                        if (quantity > 0)
                        {
                            strXml.Append(quantity.ToString() + "            " + item.Text + "             " + item.SubItems[1].Text + "\n");
                            strXml.Append("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                            //count = count + quantity;
                        }
                    }
                    else
                    {
                        listError = listError + "," + item.Text;
                    }

                }
                foreach (ListViewItem item in lvwGift2.Items)
                {
                    int quantity = Convert.ToInt32(item.SubItems[2].Text.Trim());
                    int inventory = Convert.ToInt32(item.SubItems[3].Text.Trim()); 
                    string program = "";
                    program = item.SubItems[4].Text + " (" + item.SubItems[5].Text + ")";
                    count = int.Parse(dtGift.Compute("Sum(QUANTITY_GIFTS)", "FOR_TYPE=2 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'").ToString());
                    object ob = dtGift.Compute("Sum(QUANTITY_GIFTS)", "FOR_TYPE=1 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'");
                    int countNew = 0;
                    if (int.TryParse(ob.ToString(), out countNew))
                    {
                        countNew = int.Parse(ob.ToString());
                    }
                    countPro = int.Parse(dtGift.Compute("Sum(QUANTITY)", "FOR_TYPE=2 AND PROMOTION_DETAIL_NO='"
                        + item.SubItems[4].Text + "'").ToString()); 
                    //check số lượng
                    if (count > countPro && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion1, program),
                            Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    else if (count < countPro && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion3, program),
                         Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                         MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    else if (countNew > 0 && count > 0)
                    {
                        MessageBox.Show(string.Format(Properties.rsfSales.Promotion5, program),
                             Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                             MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        strXml = null;
                        return;
                    }
                    if (quantity <= inventory || quantity == 0)
                    {
                        if (quantity > 0 )
                        {
                            strXml.Append(quantity.ToString() + "            " + item.Text + "             " + item.SubItems[1].Text + "\n");
                            strXml.Append("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                            //count = count + quantity;
                        }
                    }
                    else
                    {
                        listError = listError + "," + item.Text;
                    }
                }
                //string program = "";
                
                //if (lvwGift1.Items.Count > 0)
                //    program = lvwGift1.Items[0].SubItems[4].Text + " (" + lvwGift1.Items[0].SubItems[5].Text + ")";
                //else if (lvwGift2.Items.Count > 0)
                //    program = lvwGift2.Items[0].SubItems[4].Text + " (" + lvwGift2.Items[0].SubItems[5].Text + ")";
                //else
                //    program = "";
                ////check số lượng
                //if (count > countPro && count > 0)
                //{
                //    MessageBox.Show(string.Format(Properties.rsfSales.Promotion1,program) ,
                //        Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                //                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    return;
                //}
                //else if (count < countPro && count > 0)
                //{
                //    MessageBox.Show(string.Format(Properties.rsfSales.Promotion3, program),
                //     Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                //                                     MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    return;
                //}
                //check tôn kho
                if (listError != "")
                {
                    MessageBox.Show(string.Format(Properties.rsfSales.Promotion4,listError),
                        Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    strXml = null;
                    return;
                }
                else
                {
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Event

        private void dlgChooseGift_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGift();
                if (dtGift.Select("FOR_TYPE = '" + FOR_TYPE2 + "'").Length <= 0)
                {
                    grbGift1.Size = new Size(703, 275);
                    grbGift2.Visible = false;
                }
                StrXml = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void lvwGift1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F2)
                {
                    ChangeQuantity1();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void lvwGift2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F2)
                {
                    ChangeQuantity2();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Xử lý các phím tắt trên form.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Choosed();
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
                    Choosed();
                }
                catch (Exception ex)
                {
                    log.Error("Error: " + ex.Message);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

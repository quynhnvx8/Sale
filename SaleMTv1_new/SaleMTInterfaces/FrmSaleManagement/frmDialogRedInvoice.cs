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
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using System.Xml.Serialization;
using System.IO;
using SaleMTInterfaces.FrmInventoryManagement;



namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmDialogRedInvoice : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string listinvoice = "";
        List<string> listcode = new List<string>();
        private bool printed;
        private bool isnew;
        private Guid autoid;
        private string customerid = "";
        private string invoiceno = "";
        #endregion

        #region Property
        public bool Printed
        {
            get { return printed; }
            set { printed = value; }
        }
        #endregion

        #region Contructor
        public frmDialogRedInvoice(List<ReceiptEntities> receiptlist, Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();

            lblRealTotal.Text = "0";
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductRIC", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitName", typeof(string));
            dt.Columns.Add("PriceSale", typeof(float));
            dt.Columns.Add("PriceTotal", typeof(float));
            dt.Columns.Add("VAT", typeof(float));
            dt.Columns.Add("Remark", typeof(string));
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = dt;

            LoadData(receiptlist);
            txtCusID.ReadOnly = true;
            btnCustomerSearch.Visible = false;     
            initLanguage();
        }
        public frmDialogRedInvoice(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();

            lblRealTotal.Text = "0";
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductRIC", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitName", typeof(string));
            dt.Columns.Add("PriceSale", typeof(float));
            dt.Columns.Add("PriceTotal", typeof(float));
            dt.Columns.Add("VAT", typeof(float));
            dt.Columns.Add("Remark", typeof(string));
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = dt;
            initLanguage();
        }

        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmDialogRedInvoice.groupBox1.Text"];
            this.label15.Text = translate["frmDialogRedInvoice.label15.Text"];
            this.label9.Text = translate["frmDialogRedInvoice.label9.Text"];
            this.label8.Text = translate["frmDialogRedInvoice.label8.Text"];
            this.label7.Text = translate["frmDialogRedInvoice.label7.Text"];
            this.label5.Text = translate["frmDialogRedInvoice.label5.Text"];
            this.label6.Text = translate["frmDialogRedInvoice.label6.Text"];
            this.label3.Text = translate["frmDialogRedInvoice.label3.Text"];
            this.label4.Text = translate["frmDialogRedInvoice.label4.Text"];
            this.label2.Text = translate["frmDialogRedInvoice.label2.Text"];
            this.label1.Text = translate["frmDialogRedInvoice.label1.Text"];
            this.groupBox2.Text = translate["frmDialogRedInvoice.groupBox2.Text"];
            this.label14.Text = translate["frmDialogRedInvoice.label14.Text"];
            this.label12.Text = translate["frmDialogRedInvoice.label12.Text"];
            this.label11.Text = translate["frmDialogRedInvoice.label11.Text"];
            this.label10.Text = translate["frmDialogRedInvoice.label10.Text"];
            this.btnPrint.Text = translate["frmDialogRedInvoice.btnPrint.Text"];
            this.btnClose.Text = translate["frmDialogRedInvoice.btnClose.Text"];
            this.ProductID.HeaderText = translate["frmDialogRedInvoice.ProductID.HeaderText"];
            this.colProductName.HeaderText = translate["frmDialogRedInvoice.colProductName.HeaderText"];
            this.ProductRIC.HeaderText = translate["frmDialogRedInvoice.ProductRIC.HeaderText"];
            this.Quantity.HeaderText = translate["frmDialogRedInvoice.Quantity.HeaderText"];
            this.UnitName.HeaderText = translate["frmDialogRedInvoice.UnitName.HeaderText"];
            this.PriceSale.HeaderText = translate["frmDialogRedInvoice.PriceSale.HeaderText"];
            this.PriceTotal.HeaderText = translate["frmDialogRedInvoice.PriceTotal.HeaderText"];
            this.VAT.HeaderText = translate["frmDialogRedInvoice.VAT.HeaderText"];
            this.Remark.HeaderText = translate["frmDialogRedInvoice.Remark.HeaderText"];
            this.Text = translate["frmDialogRedInvoice.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm khách hàng
        /// </summary>
        private void SearchCustomer()
        {
            try
            {
                if (txtCusID.Text.Trim().Length > 0)
                {
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCusID.Text.Trim());
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
                    DataTable dt = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);

                    if (dt.Rows.Count == 1)
                    {
                        customerid = dt.Rows[0]["CUSTOMER_ID"].ToString();
                        txtCusID.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
                        txtCusName.Text = dt.Rows[0]["LAST_NAME"].ToString() + " " + dt.Rows[0]["FIRST_NAME"].ToString();
                        List<CUSTOMERS> cus = CUSTOMERS.ReadByCUSTOMER_ID(customerid);
                        if (cus.Count > 0)
                        {
                            txtCompanyName.Text = cus[0].WORKING_OFFICE;
                            txtCompanyAddress.Text = cus[0].OFFICE_ADDRESS;
                            txtTaxCode.Text = cus[0].TAX_CODE;
                        }
                    }
                    else
                    {
                        dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                        dialogSearch.DtCustormer = dt;
                        dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                        dialogSearch.ShowDialog();
                        if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                        {
                            txtCusName.Text = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                            txtCusID.Text = dialogSearch.Customer.CUSTOMER_ID;
                            customerid = dialogSearch.Customer.CUSTOMER_ID;
                            List<CUSTOMERS> cus = CUSTOMERS.ReadByCUSTOMER_ID(customerid);
                            if (cus.Count > 0)
                            {
                                txtCompanyName.Text = cus[0].WORKING_OFFICE;
                                txtCompanyAddress.Text = cus[0].OFFICE_ADDRESS;
                                txtTaxCode.Text = cus[0].TAX_CODE;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchCustomer' : " + ex.Message);
            }
        }
        private void LoadData(List<ReceiptEntities> receiptlist)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductID", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("ProductRIC", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("UnitName", typeof(string));
                dt.Columns.Add("PriceSale", typeof(float));
                dt.Columns.Add("PriceTotal", typeof(float));
                dt.Columns.Add("VAT", typeof(float));
                dt.Columns.Add("Remark", typeof(string));
                if (receiptlist.Count > 0)
                {
                    float sum = 0;
                    customerid = receiptlist[0].CustomerID;
                    txtCusID.Text = receiptlist[0].CustomerID;
                    txtCusName.Text = receiptlist[0].CustomerLastName + " " + receiptlist[0].CustomerFirstName;
                    foreach (ReceiptEntities receipt1 in receiptlist)
                    {
                        foreach (ReceiptItemEntities item1 in receipt1.ListItems)
                        {
                            foreach (ReceiptEntities receipt2 in receiptlist)
                            {
                                foreach (ReceiptItemEntities item2 in receipt2.ListItems)
                                {
                                    if (item1.ProductID.Equals(item2.ProductID) && item1 != item2)
                                    {
                                        item1.Quantity += item2.Quantity;
                                        item2.Quantity = 0;
                                        item1.Amount += item2.Amount;
                                        item2.Amount = 0;
                                    }
                                }
                            }
                        }
                    }
                    foreach (ReceiptEntities receipt in receiptlist)
                    {
                        foreach (ReceiptItemEntities item in receipt.ListItems)
                        {
                            //dgvProduct.Rows.Add(item.ProductID, item.ProductName, item.RedInvoiceCat, item.Quantity.ToString(), item.UnitName, item.PriceSale.ToString(), item.TotalAmount.ToString(), (item.PriceSale * 0.1).ToString(), item.Remark);
                            if (item.Quantity > 0)
                            {
                                DataRow row = dt.NewRow();
                                row["ProductID"] = item.ProductID;
                                row["ProductName"] = item.ProductName;
                                row["ProductRIC"] = item.RedInvoiceCat;
                                row["Quantity"] = item.Quantity;
                                row["UnitName"] = item.UnitName;
                                row["PriceSale"] = item.RealPrice;
                                row["PriceTotal"] = item.RealPrice * item.Quantity;
                                row["VAT"] = item.RealPrice * item.Quantity * 0.1;
                                //row["PriceSale"] = item.RealPrice / 1.1;
                                //row["PriceTotal"] = (item.RealPrice / 1.1) * item.Quantity;
                                //row["VAT"] = (item.RealPrice / 1.1) * item.Quantity * 0.1;
                                //row["Remark"] = item.Remark;
                                row["Remark"] = GetConvFact(item.ProductID,item.Quantity);
                                dt.Rows.Add(row);
                                sum += item.Amount;
                            }
                        }
                        listinvoice += receipt.ExportCode + " ";
                        listcode.Add(receipt.ExportCode);
                    }

                    dgvProduct.AutoGenerateColumns = false;
                    dgvProduct.DataSource = dt;
                    lblRealTotal.Text = sum.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                    LoadTotal();
                    //
                    List<CUSTOMERS> cus = CUSTOMERS.ReadByCUSTOMER_ID(receiptlist[0].CustomerID);
                    if (cus.Count > 0)
                    {
                        txtCompanyName.Text = cus[0].WORKING_OFFICE;
                        txtCompanyAddress.Text = cus[0].OFFICE_ADDRESS;
                        txtTaxCode.Text = cus[0].TAX_CODE;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadData' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tính tổng
        /// </summary>
        private void LoadTotal()
        {
            try
            {
                int sumSL = 0;
                float sumTong = 0;
                for (int i = 0; i < dgvProduct.RowCount; i++)
                {
                    if (dgvProduct.Rows[i].Cells[6].Value != DBNull.Value && dgvProduct.Rows[i].Cells[7].Value != DBNull.Value && dgvProduct.Rows[i].Cells[3].Value != DBNull.Value && dgvProduct.Rows[i].Cells[1].Value != DBNull.Value && dgvProduct.Rows[i].Cells[0].Value != DBNull.Value
                        && dgvProduct.Rows[i].Cells[6].Value != null && dgvProduct.Rows[i].Cells[7].Value != null && dgvProduct.Rows[i].Cells[3].Value != null && dgvProduct.Rows[i].Cells[1].Value != null && dgvProduct.Rows[i].Cells[0].Value != null
                        && dgvProduct.Rows[i].Cells[6].Value.ToString() != "" && dgvProduct.Rows[i].Cells[7].Value.ToString() != "" && dgvProduct.Rows[i].Cells[3].Value.ToString() != "" && dgvProduct.Rows[i].Cells[1].Value.ToString() != "" && dgvProduct.Rows[i].Cells[0].Value.ToString() != "")
                    {
                        sumSL += Convert.ToInt32(dgvProduct.Rows[i].Cells[3].Value);
                        sumTong += float.Parse(dgvProduct.Rows[i].Cells[6].Value.ToString());
                    }
                }
                lblQuantity.Text = sumSL.ToString();
                //lblMoney.Text = sumTong.ToString();
                //lblVAT.Text = (sumTong * 0.1).ToString();
                //lblTotal.Text = (sumTong * 1.1).ToString();
                lblMoney.Text = Convert.ToInt32(sumTong).ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                lblVAT.Text = Convert.ToInt32(sumTong * 0.1).ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
                lblTotal.Text = Convert.ToInt32(sumTong * 1.1).ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency);
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTotal' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Kiểm tra nhập liệu
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                if (txtInvoiceNo.Text == null || txtInvoiceNo.Text.Trim() == "")
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtTaxCode.Text == null || txtTaxCode.Text.Trim() == "")
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt3.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtCompanyName.Text == null || txtCompanyName.Text.Trim() == "")
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (txtCompanyAddress.Text == null || txtCompanyAddress.Text.Trim() == "")
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dgvProduct.RowCount > 17)
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt15.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                                  MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (lblTotal.Text == null || lblTotal.Text == "" || float.Parse(lblTotal.Text) <= 0)
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dgvProduct != null && dgvProduct.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row1 in dgvProduct.Rows)
                    {
                        foreach (DataGridViewRow row2 in dgvProduct.Rows)
                        {
                            //if (row1.Index != row2.Index && row1.Cells["ProductRIC"].Value != DBNull.Value && row1.Cells["ProductRIC"].Value != null && row1.Cells["ProductRIC"].Value.ToString() != ""
                            //    && row2.Cells["ProductRIC"].Value != DBNull.Value && row2.Cells["ProductRIC"].Value != null && row2.Cells["ProductRIC"].Value.ToString() != "")
                            if (row1.Index != row2.Index && row1.Cells["ProductRIC"].Value != DBNull.Value && row1.Cells["ProductRIC"].Value != null
                                && row2.Cells["ProductRIC"].Value != DBNull.Value && row2.Cells["ProductRIC"].Value != null)
                                if (!row1.Cells["ProductRIC"].Value.ToString().Equals(row2.Cells["ProductRIC"].Value.ToString()))
                                {
                                    MessageBox.Show(Properties.rsfReceipts.Receipt8.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                    return false;

                                }
                            //if (row1.Index != row2.Index && row1.Cells["ProductRIC"].Value != DBNull.Value && row1.Cells["ProductRIC"].Value != null 
                            //    && row2.Cells["ProductRIC"].Value != DBNull.Value && row2.Cells["ProductRIC"].Value != null)
                            //    if (!row1.Cells["ProductRIC"].Value.ToString().Equals(row2.Cells["ProductRIC"].Value.ToString()))
                            //    {
                            //        MessageBox.Show(Properties.rsfReceipts.Receipt8.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                            //                                   MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            //        return false;

                            //    }
                        }
                    }
                }
                if (float.Parse(lblRealTotal.Text) != float.Parse(lblTotal.Text))
                {
                    var confirmMsg = MessageBox.Show(String.Format(Properties.rsfReceipts.Receipt7.ToString(), lblTotal.Text, lblRealTotal.Text), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (confirmMsg == DialogResult.No)
                        return false;
                }
                                
                string query = "select * from RED_INVOICE_PRINT where INVOICE_NO = @INVOICE_NO";
                SqlParameter[] sqlPara = new SqlParameter[1];
                sqlPara[0] = posdb_vnmSqlDAC.newInParam("@INVOICE_NO", SqlDbType.VarChar, txtInvoiceNo.Text.Trim());
                DataSet ds = sqlDac.InlineSql_Execute(query, sqlPara);
                if (ds.Tables[0].Rows.Count > 0 && !invoiceno.Equals(txtInvoiceNo.Text.Trim()))
                {
                    MessageBox.Show(string.Format(Properties.rsfReceipts.Receipt9.ToString(),txtInvoiceNo.Text.Trim()), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                              MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckValidate' : " + ex.Message);
            }
            return true;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn đỏ
        /// </summary>
        private void RedInvoicePrint()
        {
            try
            {
                List<RedInvoiceProductEntities> plist = new List<RedInvoiceProductEntities>();
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    if (row.Cells["colProductName"].Value != null && row.Cells["colProductName"].Value.ToString().Trim() != "" && row.Cells["colProductName"].Value != DBNull.Value
                        && row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString().Trim() != "" && row.Cells["ProductID"].Value != DBNull.Value
                        && row.Cells["Quantity"].Value != null && row.Cells["Quantity"].Value.ToString().Trim() != "" && row.Cells["Quantity"].Value != DBNull.Value
                        && row.Cells["PriceSale"].Value != null && row.Cells["PriceSale"].Value.ToString().Trim() != "" && row.Cells["PriceSale"].Value != DBNull.Value
                        && row.Cells["PriceTotal"].Value != null && row.Cells["PriceTotal"].Value.ToString().Trim() != "" && row.Cells["PriceTotal"].Value != DBNull.Value
                        && row.Cells["VAT"].Value != null && row.Cells["VAT"].Value.ToString().Trim() != "" && row.Cells["VAT"].Value != DBNull.Value)
                    {
                        RedInvoiceProductEntities product = new RedInvoiceProductEntities();
                        product.ProductID = row.Cells["ProductID"].Value.ToString();
                        product.ProductName = row.Cells["colProductName"].Value.ToString();
                        product.Cat = row.Cells["ProductRIC"].Value != null ? row.Cells["ProductRIC"].Value.ToString() : "";
                        product.PriceSale = float.Parse(row.Cells["PriceSale"].Value.ToString());
                        product.PriceTotal = float.Parse(row.Cells["PriceTotal"].Value.ToString());
                        product.Vat = float.Parse(row.Cells["VAT"].Value.ToString());
                        product.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        product.Remark = row.Cells["Remark"].Value != null ? row.Cells["Remark"].Value.ToString() : "";
                        product.Unit = row.Cells["UnitName"].Value != null ? row.Cells["UnitName"].Value.ToString() : "";
                        plist.Add(product);
                    }
                }
                string text = Receipt.RedInvoiceXML(plist);

                RED_INVOICE_PRINT red = new RED_INVOICE_PRINT();
                red.AUTO_ID = isnew == true ? System.Guid.NewGuid() : autoid;
                red.CREATE_DATE = sqlDac.GetDateTimeServer();
                red.CUSTOMER_ID = customerid;
                red.EVENT_ID = null;
                red.INVOICE_INFO = text;
                red.INVOICE_NO = txtInvoiceNo.Text.Trim();
                red.LIST_INVOICE = listinvoice;
                red.OFFICE_ADDRESS = txtCompanyAddress.Text;
                red.OFFICE_WORKING = txtCompanyName.Text;
                red.PAYMENT_TYPE = cbxPaymentType.SelectedIndex.ToString();
                red.PRINT_DATE = dtpPrintDate.Value;
                red.REMARKS = txtRemark.Text;
                red.TAX_CODE = txtTaxCode.Text;
                red.TOTAL_MONEY = decimal.Parse(lblMoney.Text);
                red.TOTAL_QUANTITY = int.Parse(lblQuantity.Text);
                red.USER_CREATE = DefaultCustomer.PersonPtrint;
                red.Save(isnew);
                isnew = false;
                autoid = red.AUTO_ID;
                printed = listinvoice != "" ? true : false;
                invoiceno = txtInvoiceNo.Text.Trim();
                RedInvoicePrintEntities print = new RedInvoicePrintEntities();
                print.AutoID = red.AUTO_ID.ToString();
                if (listcode.Count > 0)
                {
                    string query = "update SALES_EXPORTS set USED_RED_INVOIDE = 1, RED_INVOIDE_COMPANYNAME = @RED_INVOIDE_COMPANYNAME, RED_INVOICE_TAXCODE = @RED_INVOICE_TAXCODE, RED_INVOICE_ADDRESS = @RED_INVOICE_ADDRESS, RED_INVOICE_REMARK=@RED_INVOICE_REMARK where EXPORT_CODE = @EXPORT_CODE";
                    foreach (string code in listcode)
                    {
                        SqlParameter[] sqlPara = new SqlParameter[5];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", SqlDbType.VarChar, code);
                        sqlPara[1] = posdb_vnmSqlDAC.newInParam("@RED_INVOIDE_COMPANYNAME", SqlDbType.NVarChar, txtCompanyName.Text);
                        sqlPara[2] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_TAXCODE", SqlDbType.VarChar, txtTaxCode.Text);
                        sqlPara[3] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_ADDRESS", SqlDbType.NVarChar, txtCompanyAddress.Text);
                        sqlPara[4] = posdb_vnmSqlDAC.newInParam("@RED_INVOICE_REMARK", SqlDbType.NVarChar, txtRemark.Text);
                        sqlDac.InlineSql_ExecuteNonQuery(query, sqlPara);
                    }
                }
                if (customerid != "")
                {
                    string query = "update CUSTOMERS set WORKING_OFFICE=@WORKING_OFFICE, OFFICE_ADDRESS=@OFFICE_ADDRESS, TAX_CODE=@TAX_CODE where CUSTOMER_ID=@CUSTOMER_ID";
                    SqlParameter[] sqlPara = new SqlParameter[4];
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", SqlDbType.VarChar, customerid);
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@WORKING_OFFICE", SqlDbType.NVarChar, txtCompanyName.Text);
                    sqlPara[2] = posdb_vnmSqlDAC.newInParam("@OFFICE_ADDRESS", SqlDbType.NVarChar, txtCompanyAddress.Text);
                    sqlPara[3] = posdb_vnmSqlDAC.newInParam("@TAX_CODE", SqlDbType.NVarChar, txtTaxCode.Text);
                    sqlDac.InlineSql_ExecuteNonQuery(query, sqlPara);
                }
                Receipt.PrintRedInvoice(print,true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'RedInvoicePrint' : " + ex.Message);
            }
        }
        //
        private string GetConvFact(string productId, int amount)
        {
            string proc = "Conv_fact_product";
            SqlParameter[] para;
            para = new SqlParameter[1];
            para[0] = posdb_vnmSqlDAC.newInParam("@product", productId);
            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, para);

            string strCon = "";
            if (dt.Rows.Count > 0)
            {
                int conv = int.Parse(dt.Rows[0]["CONV_FACT"].ToString());
                if (conv > amount)
                {
                    strCon = "0T" + amount.ToString();
                }
                else if (conv == amount)
                {
                    strCon = "1T0";
                }
                else if ( conv < amount)
                {
                    int a = (amount / conv);
                    int b = (amount - (a * conv));
                    strCon = a + "T" + b;
                }
            }
            return strCon;
        }

        #endregion

        #region Event
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Thao tác thêm sửa xóa trên gridview
        /// </summary>
        private void dgvProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "Quantity" || dgvProduct.Columns[e.ColumnIndex].Name == "PriceSale")
                    {
                        float price = 0;
                        float quantity = 1;
                        if (dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value.ToString(), out price))
                            dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value = 0;
                        if (dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null
                            || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "" || !float.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out quantity))
                            dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;

                        //if (quantity == 0)
                        //{
                        //    dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                        //    quantity = 1;
                        //}

                        dgvProduct.Rows[e.RowIndex].Cells["PriceTotal"].Value = price * quantity;
                        dgvProduct.Rows[e.RowIndex].Cells["VAT"].Value = price * quantity * 0.1;
                        dgvProduct.Rows[e.RowIndex].Cells["Remark"].Value = GetConvFact(dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString(), int.Parse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()));
                        LoadTotal();
                    }
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "ProductID")
                    {
                        if (dgvProduct.Rows[e.RowIndex].Cells["ProductID"].Value != null && dgvProduct.Rows[e.RowIndex].Cells["ProductID"].Value != DBNull.Value)
                        {
                            string proc = "PRODUCTS_Read";
                            SqlParameter[] sqlPara = new SqlParameter[1];
                            sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString());
                            DataTable tb = sqlDac.GetDataTable(proc, sqlPara);
                            if (tb.Rows.Count > 0)
                            {
                                dgvProduct.Rows[e.RowIndex].Cells["colProductName"].Value = tb.Rows[0]["PRODUCT_NAME"].ToString();
                                //dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value = float.Parse(tb.Rows[0]["PRICEDEV"].ToString()) / 1.1;
                                dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value = float.Parse(tb.Rows[0]["PRICE1"].ToString());
                                dgvProduct.Rows[e.RowIndex].Cells["UnitName"].Value = tb.Rows[0]["UNIT_NAME"].ToString();
                                if (dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value == null || dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString() == "")
                                    dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                                dgvProduct.Rows[e.RowIndex].Cells["PriceTotal"].Value = float.Parse(dgvProduct.Rows[e.RowIndex].Cells["PriceSale"].Value.ToString()) * float.Parse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                                dgvProduct.Rows[e.RowIndex].Cells["VAT"].Value = float.Parse(dgvProduct.Rows[e.RowIndex].Cells["PriceTotal"].Value.ToString()) * 0.1;
                                dgvProduct.Rows[e.RowIndex].Cells["ProductRIC"].Value = tb.Rows[0]["RED_INVOICE_CAT"].ToString();
                                dgvProduct.Rows[e.RowIndex].Cells["Remark"].Value = GetConvFact(dgvProduct.Rows[e.RowIndex].Cells["ProductId"].Value.ToString(),int.Parse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()));
                            }
                            else
                            {
                                frmDialogProductSearch FormTKMH = new frmDialogProductSearch(dgvProduct.Rows[e.RowIndex].Cells["ProductID"].Value.ToString(), translate);
                                if (FormTKMH.ShowDialog(this) == DialogResult.OK)
                                {
                                    dgvProduct.Rows[e.RowIndex].Cells["ProductID"].Value = FormTKMH.ProductID;
                                }
                            }
                        }
                        LoadTotal();
                    }
                    if (dgvProduct.Columns[e.ColumnIndex].Name == "colProductName")
                    {
                        LoadTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'dgvProduct_CellValueChanged' : " + ex.Message);
            }
        }
        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvProduct.CurrentCell.ColumnIndex == 3 || dgvProduct.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void dgvProduct_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadTotal();
        }
        private void dgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            e.Cancel = false;
        }
        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Cho phep dau cham
            //if (!char.IsControl(e.KeyChar)
            //        && !char.IsDigit(e.KeyChar)
            //            && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (CheckValidate())
            {
                RedInvoicePrint();
            }
        }
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }
        private void txtCusID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCustomer();
            }
        }
        private void frmDialogRedInvoice_Load(object sender, EventArgs e)
        {
            dtpPrintDate.Value = sqlDac.GetDateTimeServer();
            dgvProduct.Columns[2].ReadOnly = true;
            dgvProduct.Columns[6].ReadOnly = true;
            dgvProduct.Columns[7].ReadOnly = true;
            printed = false;
            isnew = true;
            cbxPaymentType.SelectedIndex = 0;
            this.ActiveControl = txtInvoiceNo;
        }        
        #endregion                

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

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


namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmManageReceipt : TabForm
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string CustomerID;
        private string InvoiceCode;
        private int SelectedIndex;
        private DateTime DateFrom;
        private DateTime DateTo;
        private bool[] status;
        private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        #endregion

        #region Contructor
        public frmManageReceipt(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.gbxDanhSach.Text = translate["frmManagerReceive.gbxDanhSach.Text"];
            this.btnInvoicesRedPrint.Text = translate["frmManagerReceive.btnInvoicesRedPrint.Text"];
            this.btnInvoicesManage.Text = translate["frmManagerReceive.btnInvoicesManage.Text"];
            this.btnInvoicePrint.Text = translate["frmManagerReceive.btnInvoicePrint.Text"];
            this.btnDeleteInvoice.Text = translate["frmManagerReceive.btnDeleteInvoice.Text"];
            this.btnGoPage.Text = translate["frmManagerReceive.btnGoPage.Text"];
            this.lblTotalRow.Text = translate["frmManagerReceive.lblTotalRow.Text"];
            this.lblPage.Text = translate["frmManagerReceive.lblPage.Text"];
            this.label7.Text = translate["frmManagerReceive.label7.Text"];
            this.tabPage1.Text = translate["frmManagerReceive.tabPage1.Text"];
            this.PRODUCT_ID.HeaderText = translate["frmManagerReceive.PRODUCT_ID.HeaderText"];
            this.P_ID.HeaderText = translate["frmManagerReceive.P_ID.HeaderText"];
            this.PRODUCT_NAME.HeaderText = translate["frmManagerReceive.PRODUCT_NAME.HeaderText"];
            this.PRODUCT_NAME_PRINT.HeaderText = translate["frmManagerReceive.PRODUCT_NAME_PRINT.HeaderText"];
            this.UNIT_NAME.HeaderText = translate["frmManagerReceive.UNIT_NAME.HeaderText"];
            this.Quantity.HeaderText = translate["frmManagerReceive.Quantity.HeaderText"];
            this.PRICE_SALES.HeaderText = translate["frmManagerReceive.PRICE_SALES.HeaderText"];
            this.Amount.HeaderText = translate["frmManagerReceive.Amount.HeaderText"];
            this.TotalDiscount.HeaderText = translate["frmManagerReceive.TotalDiscount.HeaderText"];
            this.TotalAmount.HeaderText = translate["frmManagerReceive.TotalAmount.HeaderText"];
            this.Remark.HeaderText = translate["frmManagerReceive.Remark.HeaderText"];
            this.columnHeader20.Text = translate["frmManagerReceive.columnHeader20.Text"];
            this.columnHeader21.Text = translate["frmManagerReceive.columnHeader21.Text"];
            this.columnHeader22.Text = translate["frmManagerReceive.columnHeader22.Text"];
            this.columnHeader23.Text = translate["frmManagerReceive.columnHeader23.Text"];
            this.columnHeader24.Text = translate["frmManagerReceive.columnHeader24.Text"];
            this.columnHeader25.Text = translate["frmManagerReceive.columnHeader25.Text"];
            this.columnHeader26.Text = translate["frmManagerReceive.columnHeader26.Text"];
            this.columnHeader27.Text = translate["frmManagerReceive.columnHeader27.Text"];
            this.columnHeader28.Text = translate["frmManagerReceive.columnHeader28.Text"];
            this.columnHeader30.Text = translate["frmManagerReceive.columnHeader30.Text"];
            this.columnHeader29.Text = translate["frmManagerReceive.columnHeader29.Text"];
            this.tabPage2.Text = translate["frmManagerReceive.tabPage2.Text"];
            this.columnHeader1.Text = translate["frmManagerReceive.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmManagerReceive.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmManagerReceive.columnHeader3.Text"];
            this.columnHeader4.Text = translate["frmManagerReceive.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmManagerReceive.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmManagerReceive.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmManagerReceive.columnHeader7.Text"];
            this.columnHeader8.Text = translate["frmManagerReceive.columnHeader8.Text"];
            this.columnHeader9.Text = translate["frmManagerReceive.columnHeader9.Text"];
            this.columnHeader10.Text = translate["frmManagerReceive.columnHeader10.Text"];
            this.tabPage3.Text = translate["frmManagerReceive.tabPage3.Text"];
            this.columnHeader11.Text = translate["frmManagerReceive.columnHeader11.Text"];
            this.columnHeader12.Text = translate["frmManagerReceive.columnHeader12.Text"];
            this.columnHeader13.Text = translate["frmManagerReceive.columnHeader13.Text"];
            this.columnHeader14.Text = translate["frmManagerReceive.columnHeader14.Text"];
            this.columnHeader15.Text = translate["frmManagerReceive.columnHeader15.Text"];
            this.columnHeader16.Text = translate["frmManagerReceive.columnHeader16.Text"];
            this.columnHeader17.Text = translate["frmManagerReceive.columnHeader17.Text"];
            this.tabPage4.Text = translate["frmManagerReceive.tabPage4.Text"];
            this.label8.Text = translate["frmManagerReceive.label8.Text"];
            this.groupBox1.Text = translate["frmManagerReceive.groupBox1.Text"];
            this.columnHeader18.Text = translate["frmManagerReceive.columnHeader18.Text"];
            this.columnHeader19.Text = translate["frmManagerReceive.columnHeader19.Text"];
            this.columnHeader31.Text = translate["frmManagerReceive.columnHeader31.Text"];
            this.columnHeader32.Text = translate["frmManagerReceive.columnHeader32.Text"];
            this.btnSearch.Text = translate["frmManagerReceive.btnSearch.Text"];
            this.btnExit.Text = translate["frmManagerReceive.btnExit.Text"];
            this.gbxThongTinHD.Text = translate["frmManagerReceive.gbxThongTinHD.Text"];
            this.label6.Text = translate["frmManagerReceive.label6.Text"];
            this.label5.Text = translate["frmManagerReceive.label5.Text"];
            this.label4.Text = translate["frmManagerReceive.label4.Text"];
            this.label3.Text = translate["frmManagerReceive.label3.Text"];
            this.label2.Text = translate["frmManagerReceive.label2.Text"];
            this.label1.Text = translate["frmManagerReceive.label1.Text"];
            this.colSelect.HeaderText = translate["frmManagerReceive.colSelect.HeaderText"];
            this.EXPORT_CODE.HeaderText = translate["frmManagerReceive.EXPORT_CODE.HeaderText"];
            this.TRANSFER_SHIFT_CODE.HeaderText = translate["frmManagerReceive.TRANSFER_SHIFT_CODE.HeaderText"];
            this.CUSTOMER_ID.HeaderText = translate["frmManagerReceive.CUSTOMER_ID.HeaderText"];
            this.FIRST_NAME.HeaderText = translate["frmManagerReceive.FIRST_NAME.HeaderText"];
            this.LAST_NAME.HeaderText = translate["frmManagerReceive.LAST_NAME.HeaderText"];
            this.EXPORT_DATE.HeaderText = translate["frmManagerReceive.EXPORT_DATE.HeaderText"];
            this.TOTAL_AMOUNT.HeaderText = translate["frmManagerReceive.TOTAL_AMOUNT.HeaderText"];
            this.TOTAL_DISCOUNT.HeaderText = translate["frmManagerReceive.TOTAL_DISCOUNT.HeaderText"];
            this.TOTAL_PAYMENTS.HeaderText = translate["frmManagerReceive.TOTAL_PAYMENTS.HeaderText"];
            this.USED_RED_INVOIDE.HeaderText = translate["frmManagerReceive.USED_RED_INVOIDE.HeaderText"];
            this.Column11.HeaderText = translate["frmManagerReceive.Column11.HeaderText"];
            this.Column12.HeaderText = translate["frmManagerReceive.Column12.HeaderText"];
            this.Column13.HeaderText = translate["frmManagerReceive.Column13.HeaderText"];
            this.Column14.HeaderText = translate["frmManagerReceive.Column14.HeaderText"];
            this.Column15.HeaderText = translate["frmManagerReceive.Column15.HeaderText"];
            this.Column17.HeaderText = translate["frmManagerReceive.Column17.HeaderText"];
            this.Text = translate["frmManagerReceive.Text"];
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
                if (txtCustomerCode.Text.Trim().Length > 0)
                {
                    //List<CUSTOMERS> listCus = CUSTOMERS.ReadByCUSTOMER_ID(txtCustomerCode.Text.Trim());
                    //if (listCus.Count > 0)
                    //{
                    //    txtCustomerName.Text = listCus[0].LAST_NAME + " " + listCus[0].FIRST_NAME;
                    //    txtCustomerCode.Text = listCus[0].CUSTOMER_ID;
                    //}
                    //else
                    //{
                    //    SqlParameter[] paraSearch = new SqlParameter[2];
                    //    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCustomerCode.Text.Trim());
                    //    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);

                    //    dlgSearchCustomer dialogSearch = new dlgSearchCustomer();
                    //    dialogSearch.DtCustormer = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    //    dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                    //    dialogSearch.ShowDialog();
                    //    if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                    //    {
                    //        txtCustomerName.Text = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                    //        txtCustomerCode.Text = dialogSearch.Customer.CUSTOMER_ID;
                    //        //CustomerID = dialogSearch.Customer.CUSTOMER_ID;
                    //    }
                    //}
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCustomerCode.Text.Trim());
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
                    DataTable dt = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    if (dt.Rows.Count == 1)
                    {
                        txtCustomerName.Text = dt.Rows[0]["LAST_NAME"].ToString() + " " + dt.Rows[0]["FIRST_NAME"].ToString();
                        txtCustomerCode.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
                    }
                    else
                    {
                        dlgSearchCustomer dialogSearch = new dlgSearchCustomer(translate);
                        dialogSearch.DtCustormer = dt;
                        dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                        dialogSearch.ShowDialog();
                        if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                        {
                            txtCustomerName.Text = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                            txtCustomerCode.Text = dialogSearch.Customer.CUSTOMER_ID;
                            //CustomerID = dialogSearch.Customer.CUSTOMER_ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchCustomer' : " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Chia trang cho girdview
        /// </summary>
        private void DoPaging()
        {
            try
            {
                DataTable gridTable = (DataTable)dgvInvoiceList.DataSource;
                int row = gridTable.Rows.Count;
                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = row % pageSize != 0 ? row / pageSize + 1 : row / pageSize;
                int currentPage = Convert.ToInt32(lblCurrentPage.Text) > pageCount ? pageCount : Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * pageSize) - pageSize + 1;
                int lastRow = currentPage * pageSize;
                lblTotalPage.Text = pageCount.ToString();
                lblCurrentPage.Text = currentPage.ToString();
                gridTable.DefaultView.RowFilter = "STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString();

                if (row > pageSize)
                {
                    btnFirst.Enabled = (currentPage > 1);
                    btnPrev.Enabled = (currentPage > 1);
                    btnNext.Enabled = (currentPage < pageCount);
                    btnLast.Enabled = (currentPage < pageCount);
                }
                if (dgvInvoiceList.Rows.Count > 0)
                {
                    dgvInvoiceList.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'DoPaging' : " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Load dữ liệu chi tiết của mỗi hóa đơn
        /// </summary>
        private void BindingItem(List<ReceiptItemEntities> listitem)
        {
            try
            {
                lvItem.Items.Clear();
                if (listitem != null)
                {
                    for (int i = 0; i < listitem.Count; i++)
                    {
                        lvItem.Items.Add(listitem[i].ProductID);
                        lvItem.Items[i].SubItems.Add(listitem[i].PID);
                        lvItem.Items[i].SubItems.Add(listitem[i].ProductName);
                        lvItem.Items[i].SubItems.Add(listitem[i].PrintName);
                        lvItem.Items[i].SubItems.Add(listitem[i].UnitName);
                        lvItem.Items[i].SubItems.Add(listitem[i].Quantity.ToString());
                        lvItem.Items[i].SubItems.Add(listitem[i].PriceSale.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvItem.Items[i].SubItems.Add(listitem[i].Amount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvItem.Items[i].SubItems.Add(listitem[i].TotalDiscount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvItem.Items[i].SubItems.Add(listitem[i].TotalAmount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvItem.Items[i].SubItems.Add(listitem[i].Remark);
                        if (i % 2 != 0)
                        {
                            lvItem.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindingItem' : " + ex.Message);
            }
        }
        private void BindingPayment(ReceiptEntities receipt)
        {
            try
            {
                lvPayment.Items.Clear();
                lvPayment.Items.Add(receipt.PaymentTime.ToString());
                lvPayment.Items[0].SubItems.Add("");
                lvPayment.Items[0].SubItems.Add("");
                lvPayment.Items[0].SubItems.Add("");
                lvPayment.Items[0].SubItems.Add(receipt.PaymentAmount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvPayment.Items[0].SubItems.Add(receipt.PaymentTotal.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvPayment.Items[0].SubItems.Add(receipt.PaymentBalance.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvPayment.Items[0].SubItems.Add(receipt.PaymentRefund.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvPayment.Items[0].SubItems.Add(receipt.PaymentCashier);
                lvPayment.Items[0].SubItems.Add(receipt.PaymentDate.ToShortDateString());
                lvPayment.Items[0].BackColor = Color.Gray;
                lvPayment.Items[0].ForeColor = Color.Blue;
                lvPayment.Items[0].Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                int i = 1;
                if (receipt.ListPayments != null)
                {
                    foreach (ReceiptPaymentEntities payment in receipt.ListPayments)
                    {
                        lvPayment.Items.Add("");
                        lvPayment.Items[i].SubItems.Add(payment.PaymentCurrency);
                        lvPayment.Items[i].SubItems.Add(payment.PaymentRate.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvPayment.Items[i].SubItems.Add(payment.PaymentMoney.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add(payment.PaymentAmount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        i += 1;
                    }
                }
                if (receipt.ListCards != null)
                {
                    foreach (ReceiptCardEntities card in receipt.ListCards)
                    {
                        lvPayment.Items.Add("");
                        lvPayment.Items[i].SubItems.Add(card.CardName);
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add(card.CardAmount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        lvPayment.Items[i].SubItems.Add("");
                        i += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindingPayment' : " + ex.Message);
            }

        }
        private void BindingDiscount(ReceiptEntities receipt)
        {
            try
            {
                lvDiscount.Items.Clear();
                lvDiscount.Items.Add(receipt.DiscountTerm);
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountType);
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountAmount.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountPercent.ToString());
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountTotal.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency));
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountBy);
                lvDiscount.Items[0].SubItems.Add(receipt.DiscountAuth);
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindingDiscount' : " + ex.Message);
            }
        }
        private void BindingGift(List<ReceiptGiftEntities> listgift)
        {
            try
            {
                lvPromotion.Items.Clear();
                if (listgift != null)
                {
                    int i = 0;
                    foreach (ReceiptGiftEntities gift in listgift)
                    {
                        lvPromotion.Items.Add(gift.ProductID);
                        lvPromotion.Items[i].SubItems.Add(gift.ProductName);
                        lvPromotion.Items[i].SubItems.Add(gift.PrintName);
                        lvPromotion.Items[i].SubItems.Add(gift.Quantity.ToString());
                        i += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindingGift' : " + ex.Message);
            }
        }
        private void BindingPromo(List<ReceiptPromotionEntities> listpromo)
        {
            try
            {
                string p = "";
                if (listpromo != null)
                {
                    foreach (ReceiptPromotionEntities promo in listpromo)
                    {
                        p += promo.ProgramName + "(" + promo.ProgramNO + "), ";
                    }
                }
                lblPromo.Text = p;
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindingPromo' : " + ex.Message);
            }
        }
        private void LoadData()
        {
            try
            {
                ReceiptEntities receipt = new ReceiptEntities();
                receipt.CustomerID = dgvInvoiceList.SelectedRows[0].Cells["CUSTOMER_ID"].Value.ToString();
                receipt.ExportCode = dgvInvoiceList.SelectedRows[0].Cells["EXPORT_CODE"].Value.ToString();
                receipt = Receipt.GetSaleDetail(receipt);
                dgvItems.AutoGenerateColumns = false;
                dgvItems.DataSource = Receipt.GetReceiptItemDataTable(dgvInvoiceList.SelectedRows[0].Cells["EXPORT_CODE"].Value.ToString());
                //BindingItem(receipt.ListItems);
                BindingPayment(receipt);
                BindingDiscount(receipt);
                BindingGift(receipt.ListGifts);
                BindingPromo(receipt.ListPromos);
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadData' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy selected checkbox
        /// </summary>
        private List<ReceiptEntities> SelectedCollect()
        {
            List<ReceiptEntities> listreceipt = new List<ReceiptEntities>();
            try
            {
                if (dgvInvoiceList != null && dgvInvoiceList.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvInvoiceList.Rows)
                    {
                        DataGridViewCheckBoxCell select = (DataGridViewCheckBoxCell)row.Cells["colSelect"];
                        if (Convert.ToBoolean(select.Value) == true)
                        {
                            ReceiptEntities receipt = new ReceiptEntities();
                            receipt.CustomerID = row.Cells["CUSTOMER_ID"].Value.ToString();
                            receipt.ExportCode = row.Cells["EXPORT_CODE"].Value.ToString();
                            receipt.CustomerFirstName = row.Cells["FIRST_NAME"].Value.ToString();
                            receipt.CustomerLastName = row.Cells["LAST_NAME"].Value.ToString();
                            receipt = Receipt.GetSaleDetail(receipt);
                            listreceipt.Add(receipt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SelectedCollect' : " + ex.Message);
            }
            return listreceipt;
        }
        #endregion

        #region Event
        private void dgvInvoiceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                LoadData();
            }
        }
        private void dgvInvoiceList_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                LoadData();
            }
        }
        private void dgvInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInvoiceList.CommitEdit(DataGridViewDataErrorContexts.Commit);            
            //dgvInvoiceList.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            dgvInvoiceList.CancelEdit();
        }
        private void dgvInvoiceList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selected = (DataGridViewCheckBoxCell)dgvInvoiceList.Rows[e.RowIndex].Cells["colSelect"];
                    DataGridViewCheckBoxCell used = (DataGridViewCheckBoxCell)dgvInvoiceList.Rows[e.RowIndex].Cells["USED_RED_INVOIDE"];
                    if (Convert.ToBoolean(selected.Value) == true && Convert.ToBoolean(used.Value) == true)
                    {
                        MessageBox.Show(Properties.rsfReceipts.Receipt14.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        selected.Value = selected.FalseValue;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnSearch_Click' : " + ex.Message);
            }
              
        }
        //
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCustomer();
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm khách hàng 
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvInvoiceList.DataSource = Receipt.GetSaleExport(txtCustomerCode.Text, txtInvoicesCode.Text, cboInvoices.SelectedIndex, dtpDateFrom.Value.Date, dtpDateTo.Value.Date.AddMinutes(1439));
                lblTotalRow.Text = "Tổng: " + dgvInvoiceList.Rows.Count + " dòng";
                lblCurrentPage.Text = dgvInvoiceList.Rows.Count > 0 ? "1" : "0";
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                DoPaging();
                InvoiceCode = txtInvoicesCode.Text;
                SelectedIndex = cboInvoices.SelectedIndex;
                DateTo = dtpDateTo.Value.Date.AddMinutes(1439);
                DateFrom = dtpDateFrom.Value.Date;
                CustomerID = txtCustomerCode.Text;
                if (dgvInvoiceList.RowCount <= 0)
                {
                    MessageBox.Show(Properties.rsfReceipts.Receipt11.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                                  MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    dgvItems.DataSource = null;
                    lvPayment.Items.Clear();
                    lvDiscount.Items.Clear();
                    lvPromotion.Items.Clear();
                    lblPromo.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnSearch_Click' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Xóa hóa đơn
        /// </summary>
        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkDelete)
                {
                    if (dgvInvoiceList != null && dgvInvoiceList.Rows.Count > 0 && dgvInvoiceList.SelectedRows.Count > 0)
                    {
                        //string id = dgvInvoiceList.SelectedRows[0].Cells["CUSTOMER_ID"].Value.ToString();
                        //if (UserImformation.ShiftCode.Equals(dgvInvoiceList.SelectedRows[0].Cells["TRANSFER_SHIFT_CODE"].Value.ToString()))
                        //{
                            string exportCode = dgvInvoiceList.SelectedRows[0].Cells["EXPORT_CODE"].Value.ToString();
                            var confirmMsg = MessageBox.Show(String.Format(Properties.rsfReceipts.Receipt1.ToString(), exportCode), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (confirmMsg == DialogResult.Yes)
                            {
                                Receipt.DeleteSaleExport(exportCode);
                                //foreach (DataGridViewRow row in dgvInvoiceList.SelectedRows)
                                //{
                                //    if (!row.IsNewRow)
                                //        dgvInvoiceList.Rows.Remove(row);
                                //}
                                dgvInvoiceList.DataSource = Receipt.GetSaleExport(CustomerID, InvoiceCode, SelectedIndex, DateFrom, DateTo);
                                lblTotalRow.Text = "Tổng: " + dgvInvoiceList.Rows.Count + " dòng";
                                lblCurrentPage.Text = dgvInvoiceList.Rows.Count > 0 ? lblCurrentPage.Text : "0";
                                btnLast.Enabled = false;
                                btnFirst.Enabled = false;
                                btnNext.Enabled = false;
                                btnPrev.Enabled = false;
                                DoPaging();
                            }
                       
                    }                    
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnDeleteInvoice_Click' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn
        /// </summary>
        private void btnInvoicePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkPrint)
                {
                    if (dgvInvoiceList != null && dgvInvoiceList.Rows.Count > 0 && dgvInvoiceList.SelectedRows.Count > 0)
                    {
                        ReceiptEntities receipt = new ReceiptEntities();
                        receipt.CustomerID = dgvInvoiceList.SelectedRows[0].Cells["CUSTOMER_ID"].Value.ToString();
                        receipt.ExportCode = dgvInvoiceList.SelectedRows[0].Cells["EXPORT_CODE"].Value.ToString();
                        receipt.ExportDate = DateTime.Parse(dgvInvoiceList.SelectedRows[0].Cells["EXPORT_DATE"].Value.ToString());
                        receipt.TotalAmount = float.Parse(dgvInvoiceList.SelectedRows[0].Cells["TOTAL_AMOUNT"].Value.ToString());
                        receipt.TotalDiscount = float.Parse(dgvInvoiceList.SelectedRows[0].Cells["TOTAL_DISCOUNT"].Value.ToString());
                        receipt.TotalPayment = float.Parse(dgvInvoiceList.SelectedRows[0].Cells["TOTAL_PAYMENTS"].Value.ToString());
                        receipt.CustomerLastName = dgvInvoiceList.SelectedRows[0].Cells["LAST_NAME"].Value.ToString();
                        receipt.CustomerFirstName = dgvInvoiceList.SelectedRows[0].Cells["FIRST_NAME"].Value.ToString();
                        receipt = Receipt.GetSaleDetail(receipt);
                        Receipt.PrintInvoice(receipt);
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnInvoicePrint_Click' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn đỏ
        /// </summary>
        private void btnInvoicesRedPrint_Click(object sender, EventArgs e)
        {
            try
            {
                List<ReceiptEntities> selected = SelectedCollect();
                frmDialogRedInvoice f = null;
                bool difCus = false;
                if (selected.Count > 0)
                {
                    foreach (ReceiptEntities receipt1 in selected)
                    {
                        foreach (ReceiptEntities receipt2 in selected)
                            if (!receipt1.CustomerID.Equals(receipt2.CustomerID))
                                difCus = true;
                    }
                    if (difCus == false)
                    {
                        f = new frmDialogRedInvoice(selected, translate);
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfReceipts.Receipt13.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                                                                                  MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    f = new frmDialogRedInvoice(translate);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
                if (f != null && f.Printed == true)
                {
                    dgvInvoiceList.DataSource = Receipt.GetSaleExport(CustomerID, InvoiceCode, SelectedIndex, DateFrom, DateTo);
                    lblTotalRow.Text = "Tổng: " + dgvInvoiceList.Rows.Count + " dòng";
                    lblCurrentPage.Text = dgvInvoiceList.Rows.Count > 0 ? lblCurrentPage.Text : "0";
                    btnLast.Enabled = false;
                    btnFirst.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrev.Enabled = false;
                    DoPaging();
                }

            }
            catch (Exception ex)
            {
                log.Error("Error 'btnInvoicesRedPrint_Click' : " + ex.Message);
            }
        }
        //
        private void btnInvoicesManage_Click(object sender, EventArgs e)
        {
            frmDialogRedInvoiceMng frm = new frmDialogRedInvoiceMng(translate);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = "1";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Fatal("Error: " + ex.Message);
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = lblTotalPage.Text;
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Fatal("Error: " + ex.Message);
            }
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage - 1).ToString();
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Fatal("Error: " + ex.Message);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage + 1).ToString();
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Fatal("Error: " + ex.Message);
            }
        }
        private void cboRowOnPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoiceList.Rows.Count > 1)
                {
                    lblCurrentPage.Text = "1";
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void btnGoPage_Click(object sender, EventArgs e)
        {
            try
            {
                int pageGo = Convert.ToInt32(txtPageGo.Text);
                int pageCount = Convert.ToInt32(lblTotalPage.Text);
                if (pageGo >= 1 && pageGo <= pageCount)
                {
                    lblCurrentPage.Text = txtPageGo.Text;
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void txtPageGo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (txtPageGo.Text.Trim().Length < 1)
                    {
                        e.Handled = (e.KeyChar != '0') ? false : true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void txtPageGo_TextChanged(object sender, EventArgs e)
        {
            if (txtPageGo.Text == null || txtPageGo.Text.Trim() == "")
            {
                txtPageGo.Text = "1";
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //DataGridViewCellStyle bgcolor = dgvInvoiceList.DefaultCellStyle.Clone();
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvItems.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void dgvInvoiceList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //DataGridViewCellStyle bgcolor = dgvInvoiceList.DefaultCellStyle.Clone();
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvInvoiceList.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void frmManageReceipt_Load(object sender, EventArgs e)
        {
            DateTime dt = sqlDac.GetDateTimeServer();
            dtpDateFrom.Value = new DateTime(dt.Year, dt.Month, 1);
            dtpDateTo.Value = dt;
            cboRowOnPage.SelectedIndex = 0;
            cboInvoices.SelectedIndex = 0;
            dgvInvoiceList.AutoGenerateColumns = false;
            dgvInvoiceList.Columns[1].ReadOnly = true;
            dgvInvoiceList.Columns[2].ReadOnly = true;
            dgvInvoiceList.Columns[3].ReadOnly = true;
            dgvInvoiceList.Columns[4].ReadOnly = true;
            dgvInvoiceList.Columns[5].ReadOnly = true;
            dgvInvoiceList.Columns[6].ReadOnly = true;
            dgvInvoiceList.Columns[7].ReadOnly = true;
            dgvInvoiceList.Columns[8].ReadOnly = true;
            dgvInvoiceList.Columns[9].ReadOnly = true;
            dgvInvoiceList.Columns[10].ReadOnly = true;
            dgvInvoiceList.Columns[11].ReadOnly = true;
            dgvInvoiceList.Columns[12].ReadOnly = true;
            dgvInvoiceList.Columns[13].ReadOnly = true;
            dgvInvoiceList.Columns[14].ReadOnly = true;
            dgvInvoiceList.Columns[15].ReadOnly = true;
            dgvInvoiceList.Columns[16].ReadOnly = true;

            frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
            main.ActiveMenu(new bool[] { false, false, false, false, false, false, false, false, false, false, true, true });
            status = new bool[] { false, false, false, false, false, false, false, false, false, false, true, true };

            dtpDateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.EXPORT_DATE.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            this.TOTAL_AMOUNT.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TOTAL_DISCOUNT.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TOTAL_PAYMENTS.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.PRICE_SALES.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.Amount.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TotalDiscount.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TotalAmount.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;            
            this.Quantity.DefaultCellStyle.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber;

            //Check quyền
            string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmInvoiceManagement' ";
            DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    checkInsert = checkInsert == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()) : checkInsert;
                    checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                    checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                    checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                }
            }
        }
        #endregion                

        private void frmManageReceipt_Activated(object sender, EventArgs e)
        {
            if (status != null && status.Length == 12)
            {
                frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                main.ActiveMenu(status);
            }
        }
    }
}

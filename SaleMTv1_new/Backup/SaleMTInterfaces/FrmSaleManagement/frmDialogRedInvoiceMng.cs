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

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmDialogRedInvoiceMng : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool bPrint;
        private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;
        #endregion

        #region Contructor
       
        public frmDialogRedInvoiceMng(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmDialogRedInvoiceMng.groupBox1.Text"];
            this.label4.Text = translate["frmDialogRedInvoiceMng.label4.Text"];
            this.label3.Text = translate["frmDialogRedInvoiceMng.label3.Text"];
            this.label2.Text = translate["frmDialogRedInvoiceMng.label2.Text"];
            this.label1.Text = translate["frmDialogRedInvoiceMng.label1.Text"];
            this.groupBox2.Text = translate["frmDialogRedInvoiceMng.groupBox2.Text"];
            this.btnLoad.Text = translate["frmDialogRedInvoiceMng.btnLoad.Text"];
            this.btnPrint.Text = translate["frmDialogRedInvoiceMng.btnPrint.Text"];
            this.btnView.Text = translate["frmDialogRedInvoiceMng.btnView.Text"];
            this.btnDelete.Text = translate["frmDialogRedInvoiceMng.btnDelete.Text"];
            this.btnClose.Text = translate["frmDialogRedInvoiceMng.btnClose.Text"];
            this.INVOICE_NO.HeaderText = translate["frmDialogRedInvoiceMng.INVOICE_NO.HeaderText"];
            this.OFFICE_WORKING.HeaderText = translate["frmDialogRedInvoiceMng.OFFICE_WORKING.HeaderText"];
            this.OFFICE_ADDRESS.HeaderText = translate["frmDialogRedInvoiceMng.OFFICE_ADDRESS.HeaderText"];
            this.TAX_CODE.HeaderText = translate["frmDialogRedInvoiceMng.TAX_CODE.HeaderText"];
            this.TOTAL_QUANTITY.HeaderText = translate["frmDialogRedInvoiceMng.TOTAL_QUANTITY.HeaderText"];
            this.TOTAL_MONEY.HeaderText = translate["frmDialogRedInvoiceMng.TOTAL_MONEY.HeaderText"];
            this.VAT.HeaderText = translate["frmDialogRedInvoiceMng.VAT.HeaderText"];
            this.TOTAL.HeaderText = translate["frmDialogRedInvoiceMng.TOTAL.HeaderText"];
            this.PRINT_DATE.HeaderText = translate["frmDialogRedInvoiceMng.PRINT_DATE.HeaderText"];
            this.REMARKS.HeaderText = translate["frmDialogRedInvoiceMng.REMARKS.HeaderText"];
            this.AUTO_ID.HeaderText = translate["frmDialogRedInvoiceMng.AUTO_ID.HeaderText"];
            this.CREATE_DATE.HeaderText = translate["frmDialogRedInvoiceMng.CREATE_DATE.HeaderText"];
            this.USER_CREATE.HeaderText = translate["frmDialogRedInvoiceMng.USER_CREATE.HeaderText"];
            this.PAYMENT_TYPE.HeaderText = translate["frmDialogRedInvoiceMng.PAYMENT_TYPE.HeaderText"];
            this.CUSTOMER_ID.HeaderText = translate["frmDialogRedInvoiceMng.CUSTOMER_ID.HeaderText"];
            this.LIST_INVOICE.HeaderText = translate["frmDialogRedInvoiceMng.LIST_INVOICE.HeaderText"];
            this.Text = translate["frmDialogRedInvoiceMng.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : In hóa đơn đỏ
        /// </summary>
        private void PrintRedInvoice()
        {
            try
            {
                if (dgvRedInvoiceList != null && dgvRedInvoiceList.Rows.Count > 0 && dgvRedInvoiceList.SelectedRows.Count > 0)
                {
                    RedInvoicePrintEntities print = new RedInvoicePrintEntities();
                    print.AutoID = dgvRedInvoiceList.SelectedRows[0].Cells["AUTO_ID"].Value.ToString();
                    Receipt.PrintRedInvoice(print, bPrint);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintRedInvoice' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Tìm thông tin khách hàng
        /// </summary>
        private void SearchCustomer()
        {
            try
            {
                if (txtCusID.Text.Trim().Length > 0)
                {
                    //List<CUSTOMERS> listCus = CUSTOMERS.ReadByCUSTOMER_ID(txtCusID.Text.Trim());
                    //if (listCus.Count > 0)
                    //{
                    //    txtCusName.Text = listCus[0].LAST_NAME + " " + listCus[0].FIRST_NAME;
                    //    txtCusID.Text = listCus[0].CUSTOMER_ID;
                    //}
                    //else
                    //{
                    //    SqlParameter[] paraSearch = new SqlParameter[2];
                    //    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCusID.Text.Trim());
                    //    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", 327);

                    //    dlgSearchCustomer dialogSearch = new dlgSearchCustomer();
                    //    dialogSearch.DtCustormer = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    //    dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                    //    dialogSearch.ShowDialog();
                    //    if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                    //    {
                    //        txtCusName.Text = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                    //        txtCusID.Text = dialogSearch.Customer.CUSTOMER_ID;
                    //    }
                    //}
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCusID.Text.Trim());
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", UserImformation.DeptNumber);
                    DataTable dt = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    if (dt.Rows.Count == 1)
                    {
                        txtCusName.Text = dt.Rows[0]["LAST_NAME"].ToString() + " " + dt.Rows[0]["FIRST_NAME"].ToString();
                        txtCusID.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
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
        #endregion

        #region Event
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRedInvoiceList.DataSource = Receipt.GetRedInvoice(txtCusID.Text, dtpFromDate.Value, dtpToDate.Value.Date.AddMinutes(1439));
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnLoad_Click' : " + ex.Message);
            }
        }
        private void DialogRedInvoiceMng_Load(object sender, EventArgs e)
        {
            dgvRedInvoiceList.AutoGenerateColumns = false;
            DateTime dt = sqlDac.GetDateTimeServer();
            dtpFromDate.Value = new DateTime(dt.Year, dt.Month, 1);
            dtpToDate.Value = dt;
            string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmWarrantyReportCreatDay' ";
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
        private void dgvRedInvoiceList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = dgvRedInvoiceList.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvRedInvoiceList.Rows)
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

        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Xóa thông tin khách hàng
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    if (dgvRedInvoiceList != null && dgvRedInvoiceList.Rows.Count > 0 && dgvRedInvoiceList.SelectedRows.Count > 0)
                    {
                        var confirmMsg = MessageBox.Show(Properties.rsfReceipts.Receipt10.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (confirmMsg == DialogResult.Yes)
                        {
                            string autoid = dgvRedInvoiceList.SelectedRows[0].Cells["AUTO_ID"].Value.ToString();
                            RED_INVOICE_PRINT rip = new RED_INVOICE_PRINT();
                            rip.AUTO_ID = new Guid(autoid);
                            rip.Delete();
                            dgvRedInvoiceList.DataSource = Receipt.GetRedInvoice(txtCusID.Text, dtpFromDate.Value, dtpToDate.Value.Date.AddMinutes(1439));
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
                log.Error("Error 'btnDelete_Click' : " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bPrint = false;
            PrintRedInvoice();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (checkPrint)
            {
                bPrint = true;
                PrintRedInvoice();
            }
            else
            {
                MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtCusID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCustomer();
            }
        }
        #endregion        
    }
}

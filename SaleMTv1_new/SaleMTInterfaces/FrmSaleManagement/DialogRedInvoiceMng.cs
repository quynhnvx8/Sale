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
    public partial class DialogRedInvoiceMng : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Contructor
        public DialogRedInvoiceMng()
        {
            InitializeComponent();
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
                    Receipt.PrintRedInvoice(print);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'PrintRedInvoice' : " + ex.Message);
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

        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm thông tin khách hàng
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCusID.Text.Trim().Length > 0)
                {
                    SqlParameter[] paraSearch = new SqlParameter[2];
                    paraSearch[0] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", txtCusID.Text.Trim());
                    paraSearch[1] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", 327);

                    dlgSearchCustomer dialogSearch = new dlgSearchCustomer();
                    dialogSearch.DtCustormer = sqlDac.GetDataTable("CUSTOMERS_Search", paraSearch);
                    dialogSearch.StartPosition = FormStartPosition.CenterScreen;
                    dialogSearch.ShowDialog();
                    if (dialogSearch.Customer.CUSTOMER_ID != "" && dialogSearch.Customer.CUSTOMER_ID != null)
                    {
                        txtCusName.Text = dialogSearch.Customer.LAST_NAME + " " + dialogSearch.Customer.FIRST_NAME;
                        txtCusID.Text = dialogSearch.Customer.CUSTOMER_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnSearch_Click' : " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRedInvoiceList.DataSource = Receipt.GetRedInvoice(txtCusID.Text, dtpFromDate.Value, dtpToDate.Value);
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnLoad_Click' : " + ex.Message);
            }
        }

        private void DialogRedInvoiceMng_Load(object sender, EventArgs e)
        {
            dgvRedInvoiceList.AutoGenerateColumns = false;
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
                if (dgvRedInvoiceList != null && dgvRedInvoiceList.Rows.Count > 0 && dgvRedInvoiceList.SelectedRows.Count > 0)
                {
                    var confirmMsg = MessageBox.Show(Properties.rsfReceipts.Receipt10.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (confirmMsg == DialogResult.Yes)
                    {
                        string autoid = dgvRedInvoiceList.SelectedRows[0].Cells["AUTO_ID"].Value.ToString();
                        RED_INVOICE_PRINT rip = new RED_INVOICE_PRINT();
                        rip.AUTO_ID = new Guid(autoid);
                        rip.Delete();
                        dgvRedInvoiceList.DataSource = Receipt.GetRedInvoice(txtCusID.Text, dtpFromDate.Value, dtpToDate.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'btnDelete_Click' : " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            PrintRedInvoice();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintRedInvoice();
        }
        #endregion
    }
}

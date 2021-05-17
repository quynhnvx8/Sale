using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmDialogSalesBillSearch : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private string saleCode;
        private float saleAmount;        
        private string cusCode;
        private DataTable dtBills;

        public DataTable DtBills
        {
            get { return dtBills; }
            set { dtBills = value; }
        }

        public string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; }
        }
        public float SaleAmount
        {
            get { return saleAmount; }
            set { saleAmount = value; }
        }
        public string SaleCode
        {
            get { return saleCode; }
            set { saleCode = value; }
        }

        #endregion

        #region Contructor
        
        public frmDialogSalesBillSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmDialogSaleBillSearch.groupBox1.Text"];
            this.btnSearch.Text = translate["frmDialogSaleBillSearch.btnSearch.Text"];
            this.label2.Text = translate["frmDialogSaleBillSearch.label2.Text"];
            this.label1.Text = translate["frmDialogSaleBillSearch.label1.Text"];
            this.groupBox2.Text = translate["frmDialogSaleBillSearch.groupBox2.Text"];
            this.clnSaleCode.HeaderText = translate["frmDialogSaleBillSearch.clnSaleCode.HeaderText"];
            this.clnSaleDate.HeaderText = translate["frmDialogSaleBillSearch.clnSaleDate.HeaderText"];
            this.clnTotalAmount.HeaderText = translate["frmDialogSaleBillSearch.clnTotalAmount.HeaderText"];
            this.btnOK.Text = translate["frmDialogSaleBillSearch.btnOK.Text"];
            this.btnClose.Text = translate["frmDialogSaleBillSearch.btnClose.Text"];
            this.Text = translate["frmDialogSaleBillSearch.Text"];
        }	

        #endregion    
    
        #region Method/Function
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Tìm kiếm hóa đơn theo ngày và khách hàng đã chọn.
        /// </summary>
        private void SearchBill()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[4];
                para[0] = posdb_vnmSqlDAC.newInParam("@EXPORT_CODE", null);
                para[1] = posdb_vnmSqlDAC.newInParam("@DATEFROM", Conversion.FirstDayTime(dtpDateFrom.Value));
                para[2] = posdb_vnmSqlDAC.newInParam("@DATETO", Conversion.LastDayTime(dtpDateTo.Value));
                para[3] = posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", CusCode);
                dgvListBill.AutoGenerateColumns = false;
                dgvListBill.DataSource = sqlDac.GetDataTable("SALES_EXPORTS_SearchBill", para);
                if (dgvListBill.Rows.Count > 0)
                {
                    dgvListBill.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show(Properties.rsfSales.NotItem.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchBill': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Lựa chọn hóa đơn khác hàng muốn trả lại hàng.
        /// </summary>
        private void ChoseBill()
        {
            try
            {
                if (dgvListBill.Rows.Count > 0)
                {
                    DataGridViewRow rd = dgvListBill.CurrentRow;
                    SaleCode = rd.Cells["clnSaleCode"].Value.ToString();
                    SaleAmount = (float)Convert.ToDouble(rd.Cells["clnTotalAmount"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ChoseBill': " + ex.Message);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : form load.
        /// </summary>
        private void frmDialogSalesBillSearch_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                dtpDateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpDateTo.Value = sqlDac.GetDateTimeServer();
                if (this.dtBills != null)
                {
                    dgvListBill.AutoGenerateColumns = false;
                    dgvListBill.DataSource = this.dtBills;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : sự kiện click nút tìm kiếm.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBill();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click đúp vào lưới hóa đơn để chọn hóa đơn.
        /// </summary>
        private void dgvListBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChoseBill();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click Ok để chọn hóa đơn.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ChoseBill();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện nhấn phím enter để chọn hóa đơn.
        /// </summary>
        private void dgvListBill_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ChoseBill();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
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
        /// Người tạo Luannv – 07/10/2013 : Lưu file log form đã đóng.
        /// </summary>
        private void frmDialogSalesBillSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Error(" Form closed.");
        }
        #endregion

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

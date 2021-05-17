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

namespace SaleMTInterfaces.FrmInventoryManagement
{
    public partial class frmDialogProductSearch : Form
    {
        #region Declaration
        string productID;
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructor
        public frmDialogProductSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        public frmDialogProductSearch(string ProductSearch, Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            int i = 2;
            txtSearch.Text = ProductSearch;
            
            if(ProductSearch.Length > 0 && char.IsDigit(ProductSearch[0]))
            {
                i = 1;
                rdbMaHang.Checked = true;
            }
            SearchID(txtSearch.Text, i);
        }

        private void initLanguage()
        {
            this.btnSearch.Text = translate["frmDialogProductSearch.btnSearch.Text"];
            this.rdbTenHang.Text = translate["frmDialogProductSearch.rdbTenHang.Text"];
            this.rdbMaHang.Text = translate["frmDialogProductSearch.rdbMaHang.Text"];
            this.groupBox2.Text = translate["frmDialogProductSearch.groupBox2.Text"];
            this.PRODUCT_ID.HeaderText = translate["frmDialogProductSearch.PRODUCT_ID.HeaderText"];
            this.PRODUCT_NAME.HeaderText = translate["frmDialogProductSearch.PRODUCT_NAME.HeaderText"];
            this.btnOK.Text = translate["frmDialogProductSearch.btnOK.Text"];
            this.btnExit.Text = translate["frmDialogProductSearch.btnExit.Text"];
            this.Text = translate["frmDialogProductSearch.Text"];
        }	

        #endregion

        #region Property
        public string ProductID
        {
            set { productID = value; }
            get { return productID; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Người tạo Thanhdh – 30/09/2013 : Tìm sản phẩm theo mã
        /// </summary>
        private void SearchID(string search,int type)
        {
            try
            {
                string proc = "PRODUCTS_Search";
                SqlParameter[] sqlPara = new SqlParameter[2];
                if (type == 1)
                {
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, search);
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ACTIVE", SqlDbType.Bit, 1);
                }
                if (type == 2)
                {
                    sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_NAME", SqlDbType.NVarChar, search);
                    sqlPara[1] = posdb_vnmSqlDAC.newInParam("@ACTIVE", SqlDbType.Bit, 1);
                }
                DataTable tableProduct = SqlDAC.GetDataTable(proc, sqlPara);
                grvDanhSach.AutoGenerateColumns = false;
                grvDanhSach.DataSource = tableProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error 'SearchID' : " + ex.Message);
            }
        }
        private void ChooseProduct()
        {
            if (grvDanhSach.Rows.Count != 0)
            {
                productID = grvDanhSach.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdbMaHang.Checked)
            {
                SearchID(txtSearch.Text, 1);
            }
            else
            {
                SearchID(txtSearch.Text, 2);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ChooseProduct();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void grvDanhSach_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void grvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChooseProduct();
        }
        private void grvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    ChooseProduct();
                }
                catch (Exception ex)
                {
                    log.Error("Error : grvDanhSach_KeyDown" + ex.Message);
                }
            }
        }
        private void grvDanhSach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = grvDanhSach.DefaultCellStyle.Clone();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in grvDanhSach.Rows)
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
        private void rdbTenHang_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rdbTenHang_Click(object sender, EventArgs e)
        {
            SearchID(txtSearch.Text, 2);
        }
        private void rdbMaHang_Click(object sender, EventArgs e)
        {
            SearchID(txtSearch.Text, 1);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Enter)
                {
                    ChooseProduct();
                }
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
        #endregion

        private void frmDialogProductSearch_Load(object sender, EventArgs e)
        {
            this.ActiveControl = grvDanhSach;
        }
    }
}

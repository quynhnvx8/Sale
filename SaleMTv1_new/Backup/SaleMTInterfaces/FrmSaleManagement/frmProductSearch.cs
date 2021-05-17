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
    public partial class frmProductSearch : Form
    {
        #region Declaration
        string productID;
        private posdb_vnmSqlDAC SqlDAC = new posdb_vnmSqlDAC();
        #endregion

        #region Constructor
        public frmProductSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnSearch.Text = translate["frmProductSearch.btnSearch.Text"];
            this.rdbTenHang.Text = translate["frmProductSearch.rdbTenHang.Text"];
            this.rdbMaHang.Text = translate["frmProductSearch.rdbMaHang.Text"];
            this.groupBox2.Text = translate["frmProductSearch.groupBox2.Text"];
            this.PRODUCT_ID.HeaderText = translate["frmProductSearch.PRODUCT_ID.HeaderText"];
            this.PRODUCT_NAME.HeaderText = translate["frmProductSearch.PRODUCT_NAME.HeaderText"];
            this.btnOK.Text = translate["frmProductSearch.btnOK.Text"];
            this.btnExit.Text = translate["frmProductSearch.btnExit.Text"];
            this.Text = translate["frmProductSearch.Text"];
        }

        public frmProductSearch(string ProductSearch, Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            txtSearch.Text = ProductSearch;
            SearchID(txtSearch.Text, 2);
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
        private void SearchID(string search,int type)
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
            if (grvDanhSach.Rows.Count != 0)
            {
                productID = grvDanhSach.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
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
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                productID = grvDanhSach.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}

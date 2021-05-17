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
using System.IO;
using System.Data.OleDb;
using SaleMTBusiness.InventoryManagement;
using System.Data.SqlClient;

namespace SaleMTInterfaces.FrmUtilities
{
    public partial class dlgImportProduct : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtReturn;

        public DataTable DtReturn
        {
            get { return dtReturn; }
            set { dtReturn = value; }
        }
        #endregion

        #region Contructor
        
        public dlgImportProduct(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["dlgImportProduct.groupBox1.Text"];
            this.btnImportExcel.Text = translate["dlgImportProduct.btnImportExcel.Text"];
            this.btnBegin.Text = translate["dlgImportProduct.btnBegin.Text"];
            this.label3.Text = translate["dlgImportProduct.label3.Text"];
            this.label2.Text = translate["dlgImportProduct.label2.Text"];
            this.groupBox2.Text = translate["dlgImportProduct.groupBox2.Text"];
            this.ProductCode.HeaderText = translate["dlgImportProduct.ProductCode.HeaderText"];
            this.Quantity.HeaderText = translate["dlgImportProduct.Quantity.HeaderText"];
            this.lblStatus.Text = translate["dlgImportProduct.lblStatus.Text"];
            this.btnClose.Text = translate["dlgImportProduct.btnClose.Text"];
            this.btnOK.Text = translate["dlgImportProduct.btnOK.Text"];
            this.lblSum.Text = translate["dlgImportProduct.lblSum.Text"];
            this.Text = translate["dlgImportProduct.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Tìm, lấy đường dẫn file excel
        /// </summary>
        private void OpenExcel()
        {
            try
            {
                OpenFileDialog openExcel = new OpenFileDialog();
                openExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openExcel.Multiselect = false;
                openExcel.ValidateNames = true;
                openExcel.DereferenceLinks = false; // Will return .lnk in shortcuts.
                openExcel.Filter = "Excel |*.xls|All files |*.*";
                openExcel.FileOk += new System.ComponentModel.CancelEventHandler(OpenKeywordsFileDialog_FileOk);
                var dialogResult = openExcel.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtPath.Text = openExcel.FileName;
                    List<string> sheet = GetSheet(openExcel.FileName);
                    cboSheet.Items.Clear();
                    foreach (string s in sheet)
                    {
                        cboSheet.Items.Add(s);
                    }
                    if (sheet.Count > 0)
                        cboSheet.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'OpenExcel' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy thông tin file excel
        /// </summary>
        private void LoadExcel()
        {
            try
            {
                if (CheckValidate())
                {
                    lblStatus.Text = "Lấy dữ liệu";
                    this.Refresh();
                    string sqlQuery = string.Format("select * from [{0}$]", cboSheet.SelectedItem.ToString());
                    OleDbConnection objConnection = new OleDbConnection();
                    objConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtPath.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";");
                    objConnection.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, objConnection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ds.Tables[0].DefaultView.RowFilter = "ProductCode <> '' AND ProductCode is not null";
                    lblStatus.Text = "Hoàn tất lấy dữ liệu";
                    this.Refresh();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int n;
                        bool result = int.TryParse(ds.Tables[0].Rows[i]["Quantity"].ToString(), out n);
                        if (result == false)
                            ds.Tables[0].Rows.RemoveAt(i);
                    }
                    lblStatus.Text = "Hiền thị dữ liệu";
                    this.Refresh();
                    dgvInventory.DataSource = ds.Tables[0];
                    if (dgvInventory.RowCount > 0)
                        lblCount.Text = dgvInventory.RowCount.ToString();
                    objConnection.Close();
                    objConnection.Dispose();
                    pbrProcess.Value = 100;
                    lblStatus.Text = "Hoàn tất";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadExcel' : " + ex.Message);
                MessageBox.Show(Properties.rsfInventoryImport.Inventory4, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Kiểm tra và lưu thông tin từ file excel
        /// </summary>
        private void SaveExcel()
        {
            try
            {
                if (dgvInventory.DataSource != null && dgvInventory.RowCount > 0)
                {
                    List<InventoryImportEntities> errorList = new List<InventoryImportEntities>();
                    List<InventoryImportEntities> okList = new List<InventoryImportEntities>();
                    foreach (DataGridViewRow row in dgvInventory.Rows)
                    {
                        string proc = "PRODUCTS_Read";
                        SqlParameter[] sqlPara = new SqlParameter[1];
                        sqlPara[0] = posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", SqlDbType.VarChar, row.Cells["ProductCode"].Value.ToString());
                        DataTable tb = sqlDac.GetDataTable(proc, sqlPara);
                        if (tb.Rows.Count <= 0)
                        {
                            InventoryImportEntities p = new InventoryImportEntities();
                            p.ProductID = row.Cells["ProductCode"].Value.ToString();
                            p.ProductQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                            errorList.Add(p);
                        }
                        else
                        {
                            InventoryImportEntities p = new InventoryImportEntities();
                            p.ProductID = row.Cells["ProductCode"].Value.ToString();
                            p.ProductQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                            okList.Add(p);
                        }
                    }
                    if (errorList.Count > 0)
                    {
                        var confirmMsg = MessageBox.Show(string.Format(Properties.rsfInventoryImport.Inventory6.ToString(), errorList.Count.ToString()), translate["Msg.TitleDialog"],
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (confirmMsg == DialogResult.Yes)
                        {
                            Import.ErrorImport(errorList);
                        }
                    }
                    if (okList.Count > 0)
                    {
                        Import.InventoryImport(okList);
                        MessageBox.Show(Properties.rsfInventoryImport.Inventory7.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveExcel' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Lấy danh sách sheet
        /// </summary>
        private List<string> GetSheet(string path)
        {
            List<string> sheetlist = new List<string>();
            try
            {
                OleDbConnection objConnection = new OleDbConnection();
                objConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";");
                objConnection.Open();
                DataTable dtSchema = objConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                objConnection.Close();
                objConnection.Dispose();

                foreach (DataRow row in dtSchema.Rows)
                {
                    string s = row[2].ToString();
                    sheetlist.Add(s.Remove(s.Length - 1));
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetSheet' : " + ex.Message);
            }
            return sheetlist;
        }
        /// <summary>
        /// Người tạo Thanhdh – 27/09/2013 : Kiểm tra nhập liệu
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                dgvInventory.DataSource = null;
                lblCount.Text = "0";
                lblStatus.Text = "";
                pbrProcess.Value = 0;
                if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory2.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (cboSheet.Items.Count <= 0)
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory3.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (!File.Exists(txtPath.Text.Trim()))
                {
                    MessageBox.Show(string.Format(Properties.rsfInventoryImport.Inventory1.ToString(), txtPath.Text.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error 'CheckValidate' : " + ex.Message);
                return false;
            }
        }
        private void ResetForm()
        {
            try
            {
                txtPath.Text = "";
                lblCount.Text = "0";
                lblStatus.Text = "";
                pbrProcess.Value = 0;
                cboSheet.Items.Clear();
                dgvInventory.DataSource = null;
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetForm' : " + ex.Message);                
            }
        }
        #endregion

        #region Event
        private void frmInputOpeningStock_Load(object sender, EventArgs e)
        {
            dgvInventory.AutoGenerateColumns = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtReturn = (DataTable)dgvInventory.DataSource;
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetForm' : " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenExcel();
        }
        private void OpenKeywordsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog fileDialog = sender as OpenFileDialog;
            string selectedFile = fileDialog.FileName;
            if (string.IsNullOrEmpty(selectedFile) || selectedFile.Contains(".lnk"))
            {
                MessageBox.Show("Please select a valid Excel File", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
            }
            return;
        }
        private void btnBegin_Click(object sender, EventArgs e)
        {
            LoadExcel();
        }
        #endregion

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductCode", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));
                
                ExportExcel ex = new ExportExcel();
                ex.ExportSample(dt, "COMPARE_PRODUCT_IMPORT.xls");
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetForm' : " + ex.Message);
            }
        }
    }
}

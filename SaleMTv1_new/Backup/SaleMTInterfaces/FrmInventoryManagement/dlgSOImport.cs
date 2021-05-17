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
using System.Data.SqlClient;
using SaleMTBusiness.InventoryManagement;

namespace SaleMTInterfaces.FrmInventoryManagement
{
    /// <summary>
    /// Người tạo Luannv  – 22/10/2013 : form import sản phẩm từ file excel    
    /// </summary>
    public partial class dlgSOImport : Form
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string ERROR_TITLE = "Mã hàng không thể import";
        private DataTable dtProduct = new DataTable();
        private List<SOImportEntities> listResult = new List<SOImportEntities>();

        public List<SOImportEntities> ListResult
        {
            get { return listResult; }
            set { listResult = value; }
        }

        public DataTable DtProduct
        {
            get { return dtProduct; }
            set { dtProduct = value; }
        }
        #endregion

        #region Contructor
        public dlgSOImport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.groupBox1.Text = translate["dlgSOImport.groupBox1.Text"];
            this.btnImportExcel.Text = translate["dlgSOImport.btnImportExcel.Text"];
            this.btnBegin.Text = translate["dlgSOImport.btnBegin.Text"];
            this.label2.Text = translate["dlgSOImport.label2.Text"];
            this.groupBox2.Text = translate["dlgSOImport.groupBox2.Text"];
            this.clnProductCode.HeaderText = translate["dlgSOImport.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["dlgSOImport.clnProductName.HeaderText"];
            this.btnOK.Text = translate["dlgSOImport.btnOK.Text"];
            this.btnClose.Text = translate["dlgSOImport.btnClose.Text"];
            this.label5.Text = translate["dlgSOImport.label5.Text"];
            this.Text = translate["dlgSOImport.Text"];
        }	

        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Tìm, lấy đường dẫn file excel
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
        /// Người tạo Luannv  – 22/10/2013 : Lấy thông tin file excel
        /// </summary>
        private void LoadExcel()
        {
            try
            {
                if (CheckValidate())
                {                    
                    lblStatus.Text = "Lấy dữ liệu";
                    string sqlQuery = string.Format("select * from [{0}$]", cboSheet.SelectedItem.ToString());
                    OleDbConnection objConnection = new OleDbConnection();
                    objConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtPath.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";");
                    objConnection.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, objConnection);                    
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ds.Tables[0].DefaultView.RowFilter = "ProductCode <> '' AND ProductCode is not null";
                    lblStatus.Text = "Hoàn tất";
                    dgvProducts.DataSource = ds.Tables[0];
                    if (dgvProducts.RowCount > 0)
                        lblCount.Text = dgvProducts.RowCount.ToString();                    
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadExcel' : " + ex.Message);
                MessageBox.Show(Properties.rsfInventoryImport.Inventory4, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Người tạo luannv – 23/10/2013 : Kiểm tra và lưu thông tin từ file excel
        /// </summary>
        private void SaveExcel()
        {
            try
            {
                if (dgvProducts.DataSource != null && dgvProducts.RowCount > 0)
                {
                    prgSOImport.Visible = true;
                    DataTable errorList = new DataTable();
                    errorList.Columns.Add("ProductCode", typeof(string));
                    errorList.Columns.Add("ProductName", typeof(string));
                    List<SOImportEntities> okList = new List<SOImportEntities>();
                    prgSOImport.Value = 0;
                    for (int i = 0; i < dgvProducts.Rows.Count; i++)
                    {
                        // xử lý process
                        decimal t = i * 100 / dgvProducts.Rows.Count;
                        if (i == dgvProducts.Rows.Count - 1)
                            t = 100;
                        prgSOImport.Value = int.Parse(Math.Round(t, 0).ToString());
                        // kiểm tra sp có tồn tại không.
                        string proCode = dgvProducts.Rows[i].Cells["clnProductCode"].Value.ToString();
                        DataRow[] check = dtProduct.Select("PRODUCT_ID = '" + proCode + "'");
                        if (check.Length > 0)
                        {
                            SOImportEntities p = new SOImportEntities();
                            p.ProductId = check[0]["PRODUCT_ID"].ToString();
                            p.ProductName = check[0]["PRODUCT_NAME"].ToString();
                            okList.Add(p);
                        }
                        else
                        {
                            DataRow r = errorList.NewRow();
                            r["ProductCode"] = dgvProducts.Rows[i].Cells["clnProductCode"].Value.ToString();
                            r["ProductName"] = dgvProducts.Rows[i].Cells["clnProductName"].Value.ToString();
                            errorList.Rows.Add(r);
                        }
                    }

                    if (errorList.Rows.Count > 0)
                    {
                        var confirmMsg = MessageBox.Show(string.Format(Properties.rsfInventoryImport.Inventory6.ToString(), errorList.Rows.Count.ToString()), Properties.rsfSales.Notice.ToString(),
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (confirmMsg == DialogResult.Yes)
                        {
                            Export ex = new Export();
                            ex.InfoCompany = true;
                            ex.InfoStore = true;
                            ex.StrTitle = ERROR_TITLE.ToUpper();
                            ex.ExportToExcel(errorList, ERROR_TITLE + "import_Filled_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xls");
                        }
                    }
                    this.ListResult = okList;
                    ResetForm();                    
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'SaveExcel' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Lấy danh sách sheet
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
        /// Người tạo Luannv  – 22/10/2013 : Kiểm tra nhập liệu
        /// </summary>
        private bool CheckValidate()
        {
            try
            {
                dgvProducts.DataSource = null;
                lblCount.Text = "0";
                lblStatus.Text = "";
                if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory2.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (cboSheet.Items.Count <= 0)
                {
                    MessageBox.Show(Properties.rsfInventoryImport.Inventory3.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Reset control        
        /// </summary>
        private void ResetForm()
        {
            try
            {
                txtPath.Text = "";
                lblCount.Text = "0";
                lblStatus.Text = "";
                cboSheet.Items.Clear();
                //dgvProducts.DataSource = null;
                dgvProducts.Rows.Clear();
                prgSOImport.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
  
        #region Event
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : load form        
        /// </summary>
        private void frmInventoryImport_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: form started.");
                dgvProducts.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Chọn dữ liệu        
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveExcel();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Đóng form        
        /// </summary>
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
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Mở dialog chọn file excel import       
        /// </summary>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Sự kiện hủy chọn file excel        
        /// </summary>
        private void OpenKeywordsFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Đọc file excel.        
        /// </summary>
        private void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                LoadExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : ghi file log form đã đóng.        
        /// </summary>
        private void dlgSOImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed");
        }
        /// <summary>
        /// Người tạo Luannv  – 22/10/2013 : Tạo mẫu import sản phẩm        
        /// </summary>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Export ex = new Export();
                string fileName = "LIST_PRODUCT_IMPORT.xls";                
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductCode", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                ex.ExportSample(dt, fileName);
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion       
        
    }
}

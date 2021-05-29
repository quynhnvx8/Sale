using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTCommon;
using SaleMTBusiness.InventoryManagement;

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    /// <summary>
    /// Người tạo Luannv - 05/11/2013: Form báo cáo hàng trả lại
    /// </summary>
    public partial class frmItemReturnReport : Form
    {
        #region Declaration
        private List<string> listPro = new List<string>();
        private const string NODE_REASON_CODE = "Lý do trả hàng";
        private const string REPORT_TITLE = "Báo cáo danh sách hàng trả lại";
        private string reasons = Properties.rsfMasterCode.Reaseons.ToString();
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string StoreName, Path;
        #endregion

        #region Contructor
        public frmItemReturnReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmItemReturnReport.groupBox1.Text"];
            this.label2.Text = translate["frmItemReturnReport.label2.Text"];
            this.label4.Text = translate["frmItemReturnReport.label4.Text"];
            this.label1.Text = translate["frmItemReturnReport.label1.Text"];
            this.btnPrint.Text = translate["frmItemReturnReport.btnPrint.Text"];
            this.btnExport.Text = translate["frmItemReturnReport.btnExport.Text"];
            this.btnExit.Text = translate["frmItemReturnReport.btnExit.Text"];
            this.groupBox2.Text = translate["frmItemReturnReport.groupBox2.Text"];
            this.btnSearch.Text = translate["frmItemReturnReport.btnSearch.Text"];
            this.groupBox4.Text = translate["frmItemReturnReport.groupBox4.Text"];
            this.Column1.HeaderText = translate["frmItemReturnReport.Column1.HeaderText"];
            this.Column2.HeaderText = translate["frmItemReturnReport.Column2.HeaderText"];
            this.Column3.HeaderText = translate["frmItemReturnReport.Column3.HeaderText"];
            this.Column4.HeaderText = translate["frmItemReturnReport.Column4.HeaderText"];
            this.Column5.HeaderText = translate["frmItemReturnReport.Column5.HeaderText"];
            this.colQuan.HeaderText = translate["frmItemReturnReport.colQuan.HeaderText"];
            this.colPrice.HeaderText = translate["frmItemReturnReport.colPrice.HeaderText"];
            this.ColTotal.HeaderText = translate["frmItemReturnReport.ColTotal.HeaderText"];
            this.ColTotalReturn.HeaderText = translate["frmItemReturnReport.ColTotalReturn.HeaderText"];
            this.Column10.HeaderText = translate["frmItemReturnReport.Column10.HeaderText"];
            this.Column11.HeaderText = translate["frmItemReturnReport.Column11.HeaderText"];
            this.Column12.HeaderText = translate["frmItemReturnReport.Column12.HeaderText"];
            this.Text = translate["frmItemReturnReport.Text"];

        }
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load combobox phản hồi của khách hàng.
        /// </summary>
        private void LoadReasons()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", reasons) };
                DataTable dtReasons = new DataTable();
                dtReasons = sqlDac.GetDataTable("MASTER_DATA_Read_Reasons", para);
                if (dtReasons.Rows.Count > 0)
                {                    
                    TreeNode trNode = new TreeNode(NODE_REASON_CODE);
                    for (int i = 0; i < dtReasons.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text = dtReasons.Rows[i]["MASTER_NAME"].ToString();
                        childNode.Tag = dtReasons.Rows[i]["MASTER_CODE"].ToString();
                        trNode.Nodes.Add(childNode);                        
                    }
                    this.trvReasons.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadReasons': " + ex.Message);
            }
        }
        public void SetINFBC(string strStoreName, string strPath)
        {
            try
            {
                StoreName = strStoreName;
                Path = strPath;

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }
        private DataSet FillDataset(string store)
        {
            DataSet ds = new DataSet();
            try
            {
                string masterCode = "";
                foreach(TreeNode node in trvReasons.Nodes)
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    if (node.Nodes[i].Checked)
                    {
                        masterCode = masterCode + "," + node.Nodes[i].Tag.ToString();
                    }
                }
                SqlParameter[] para = new SqlParameter[5];
                para[0] = posdb_vnmSqlDAC.newInParam("@Product", txtProduct.Text.Trim());
                para[1] = posdb_vnmSqlDAC.newInParam("@DeptCode",  UserImformation.DeptCode );
                para[2] = posdb_vnmSqlDAC.newInParam("@MasterCode", masterCode);
                para[3] = posdb_vnmSqlDAC.newInParam("@FromDate", dtpdateFrom.Value.ToString("yyyy/MM/dd"));
                para[4] = posdb_vnmSqlDAC.newInParam("@ToDate", dtpdateTo.Value.ToString("yyyy/MM/dd"));

                ds = sqlDac.GetDataSet(store, para);
                ds.DataSetName = "dsItemReturnReport";
                ds.Tables[0].TableName = "ItemReturn";     
                // 
                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                //
                DataTable dtStoreLogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtStoreLogo);
                //add thêm bảng date
                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));
                dtDate.Columns.Add("CuaHangTruong", typeof(string));
                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["ToDate"] = dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                drDate["CuaHangTruong"] = "";
                dtDate.Rows.Add(drDate);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return ds;
        }
        #endregion

        #region Event form process
        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                dtpdateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                LoadReasons();
                dgvListItem.ColumnHeadersVisible = false;

                dtpdateFrom.CustomFormat = AppConfigFileSettings.strOptDate;
                dtpdateTo.CustomFormat = AppConfigFileSettings.strOptDate;

                colPrice.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                colQuan.DefaultCellStyle.Format = AppConfigFileSettings.strOptNumber;
                ColTotal.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
                ColTotalReturn.DefaultCellStyle.Format = AppConfigFileSettings.strOptCurency;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }

        private void frmReportSale_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.ProcessTabKey(true);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SOEntities soEn = new SOEntities();
                soEn = SOManagement.ShowChoseProduct(translate);
                txtProduct.Text = soEn.ListProduct;
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                txtProduct.Text = "";
                listPro.Clear();
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtCodeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    CheckInventoryEntities inventEn = CheckInventory.ShowProductSearch(txtCodeProduct.Text.Trim(), translate);
                    if (inventEn != null)
                    {
                        int check = listPro.FindIndex(s => s == inventEn.ProductID);
                        if (check == -1)
                        {
                            listPro.Add(inventEn.ProductID);
                            string listCode = (txtProduct.Text.Trim() != "") ? "," + inventEn.ProductID : inventEn.ProductID;
                            txtProduct.Text = txtProduct.Text.Trim() + listCode;
                        }
                        txtCodeProduct.Text = "";
                        txtCodeProduct.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        DataTable dtExcel = new DataTable();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListItem.AutoGenerateColumns = false;
                dgvListItem.DataSource = FillDataset("ItemReturnReport_Search").Tables[0];
                dtExcel = FillDataset("ItemReturnReport_Search").Tables[0].Copy();

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC(StoreName, Path);
                frm.ds = FillDataset("ItemReturnReport");
                frm.IsMdiContainer = true;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvListItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgRed = new DataGridViewCellStyle();
                    bgRed.ForeColor = Color.Red;

                    int i = 0;
                    foreach (DataGridViewRow r in dgvListItem.Rows)
                    {                        
                        string name = r.Cells[0].Value.ToString().Trim();
                        i++;
                        if (i % 2 == 0)                        
                            r.DefaultCellStyle = bgcolor;  
                        if (name != "")
                        {
                            if (name != "Tổng cộng:")                                
                                r.Cells[0].Style.BackColor = Color.FromArgb(173, 216, 230);
                            if (name == "Tổng cộng:")
                                r.DefaultCellStyle = bgRed;
                        }
                    }                   
                }
                btnExport.Enabled = (dgvListItem.Rows.Count > 0);
                dgvListItem.ColumnHeadersVisible = (dgvListItem.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Temp = FillDataset("ItemReturnReport_Excel").Tables[0];
                
                ExportExcel ex = new ExportExcel();
                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = REPORT_TITLE.ToUpper();
                ex.StrDate = "TỪ NGÀY: " + dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + "   ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                
                ex.CaseEx = 8;
                ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.Dt = Temp;
                ex.ExportExcels();
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
    }
}

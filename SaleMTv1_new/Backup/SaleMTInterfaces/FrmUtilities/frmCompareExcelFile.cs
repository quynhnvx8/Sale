using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmUtilities
{
    /// <summary>
    /// Người tạo Luannv - 05/11/2013: So sánh số lượng giữa 2 file excel
    /// </summary>
    public partial class frmCompareExcelFile : Form
    {
        #region Declaration
        private const string TITLE_EXPORT = "So sánh số lượng từ 2 file excel";
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Contructor
        
        public frmCompareExcelFile(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.STT.HeaderText = translate["frmCompareExcelFile.STT.HeaderText"];
            this.clnProductCode.HeaderText = translate["frmCompareExcelFile.clnProductCode.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmCompareExcelFile.clnQuantity.HeaderText"];
            this.STTB.HeaderText = translate["frmCompareExcelFile.STTB.HeaderText"];
            this.clnProductCodeB.HeaderText = translate["frmCompareExcelFile.clnProductCodeB.HeaderText"];
            this.clnQuantityB.HeaderText = translate["frmCompareExcelFile.clnQuantityB.HeaderText"];
            this.btnImportB.Text = translate["frmCompareExcelFile.btnImportB.Text"];
            this.gbxDuLieu.Text = translate["frmCompareExcelFile.gbxDuLieu.Text"];
            this.STTK.HeaderText = translate["frmCompareExcelFile.STTK.HeaderText"];
            this.MaSPK.HeaderText = translate["frmCompareExcelFile.MaSPK.HeaderText"];
            this.SoLuongK.HeaderText = translate["frmCompareExcelFile.SoLuongK.HeaderText"];
            this.GhiChu.HeaderText = translate["frmCompareExcelFile.GhiChu.HeaderText"];
            this.btnCompare.Text = translate["frmCompareExcelFile.btnCompare.Text"];
            this.btnClose.Text = translate["frmCompareExcelFile.btnClose.Text"];
            this.lblTotal.Text = translate["frmCompareExcelFile.lblTotal.Text"];
            this.Text = translate["frmCompareExcelFile.Text"];
        }	

        #endregion

        #region method
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Export kết quả so sánh ra file excel
        /// </summary>
        private void ExportExcel()
        {
            try
            {
                if (dgvCompare.Rows.Count > 0)
                {
                    DataTable dtEx = Conversion.ConvertDataGridVewToDataTable(dgvCompare);
                    dtEx.Columns.Remove("STT");

                    string fileName = TITLE_EXPORT + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

                    Export ex = new Export();
                    ex.InfoCompany = true;
                    ex.InfoStore = true;
                    ex.StrTitle = TITLE_EXPORT.ToUpper();
                    ex.ExportToExcel(dtEx, fileName);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'ExportExcel': " + ex.Message);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Import file excel 1
        /// </summary>
        private void btnImportA_Click(object sender, EventArgs e)
        {
            try
            {
                dlgImportProduct dlgImport = new dlgImportProduct(translate);
                dlgImport.StartPosition = FormStartPosition.CenterScreen;
                dlgImport.ShowDialog();
                if (dlgImport.DtReturn != null)
                {
                    dgvFileA.AutoGenerateColumns = false;
                    dgvFileA.DataSource = dlgImport.DtReturn;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Import file excel 2
        /// </summary>
        private void btnImportB_Click(object sender, EventArgs e)
        {
            try
            {
                dlgImportProduct dlgImport = new dlgImportProduct(translate);
                dlgImport.StartPosition = FormStartPosition.CenterScreen;
                dlgImport.ShowDialog();
                if (dlgImport.DtReturn != null)
                {
                    dgvFileB.AutoGenerateColumns = false;
                    dgvFileB.DataSource = dlgImport.DtReturn;
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: form load
        /// </summary>
        private void frmCompareExcelFile_Load(object sender, EventArgs e)
        {
            try
            {
                btnExcel.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Thay đổi màu nền datagirdview file 1
        /// </summary>
        private void dgvFileA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvFileA.Rows)
                    {
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                        r.Cells[0].Value = i + 1;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Thay đổi màu nền datagirdview file 2
        /// </summary>
        private void dgvFileB_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvFileB.Rows)
                    {
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                        r.Cells[0].Value = i + 1;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Đóng form
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
        /// Người tạo Luannv - 05/11/2013: Export kết quả so sánh ra file excel
        /// </summary>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: So sánh 2 file excel
        /// </summary>
        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtA = (DataTable)dgvFileA.DataSource;
                DataTable dtB = (DataTable)dgvFileB.DataSource;
                DataTable dtCompare = new DataTable();
                dtCompare.Columns.Add("ProductCode", typeof(string));
                dtCompare.Columns.Add("Quantity", typeof(int));
                dtCompare.Columns.Add("Remarks", typeof(string));
                // lặp lần 1
                for (int i = 0; i < dtA.Rows.Count; i++)
                {
                    string code = dtA.Rows[i]["ProductCode"].ToString().Trim();
                    if (code != "")
                    {
                        int quantityA = (dtA.Rows[i]["Quantity"].ToString().Trim() != "") ? Convert.ToInt32(dtA.Rows[i]["Quantity"].ToString()) : 0;
                        DataRow[] r = dtB.Select("ProductCode = '" + code + "'");
                        if (r.Length > 0)
                        {
                            int quantityB = (r[0]["Quantity"].ToString().Trim() != "") ? Convert.ToInt32(r[0]["Quantity"]) : 0;
                            if (quantityA != quantityB)
                            {
                                DataRow rCompa = dtCompare.NewRow();
                                rCompa["ProductCode"] = code;
                                rCompa["Quantity"] = quantityA - quantityB;
                                rCompa["Remarks"] = "";
                                dtCompare.Rows.Add(rCompa);
                            }
                        }
                        else
                        {
                            DataRow rCompa = dtCompare.NewRow();
                            rCompa["ProductCode"] = code;
                            rCompa["Quantity"] = quantityA;
                            rCompa["Remarks"] = "Chỉ có trong A";
                            dtCompare.Rows.Add(rCompa);
                        }
                    }
                }
                // lặp lần 2 để tìm các sản phẩm chỉ có trong B
                for (int i = 0; i < dtB.Rows.Count; i++)
                {
                    string code = dtB.Rows[i]["ProductCode"].ToString().Trim();
                    if (code != "")
                    {
                        int quantityB = (dtB.Rows[i]["Quantity"].ToString().Trim() != "") ? Convert.ToInt32(dtB.Rows[i]["Quantity"].ToString()) : 0;
                        DataRow[] r = dtA.Select("ProductCode = '" + code + "'");
                        if (r.Length <= 0)
                        {
                            DataRow rCompa = dtCompare.NewRow();
                            rCompa["ProductCode"] = code;
                            rCompa["Quantity"] = quantityB;
                            rCompa["Remarks"] = "Chỉ có trong B";
                            dtCompare.Rows.Add(rCompa);
                        }
                    }
                }
                if (dtCompare.Rows.Count > 0)
                {
                    dgvCompare.AutoGenerateColumns = false;
                    dgvCompare.DataSource = dtCompare;
                }
                lblTotal.Text = "Tổng cộng: " + dgvCompare.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Thay đổi màu nền datagirdview kết quả so sánh
        /// </summary>
        private void dgvCompare_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvCompare.Rows)
                    {
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                        r.Cells[0].Value = i + 1;
                        i++;
                    }
                }
                if (dgvCompare.Rows.Count > 0)
                    btnExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        #endregion

       
    }
}

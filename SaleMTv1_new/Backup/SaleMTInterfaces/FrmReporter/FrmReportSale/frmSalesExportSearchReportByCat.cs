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

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmSalesExportSearchReportByCat : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();
        DataSet ds = new DataSet();
        #endregion

        #region Constructor
        public frmSalesExportSearchReportByCat(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboRows.Text = "20";
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnDownList.Text = translate["frmSalesExportSearchReportByCat.btnDownList.Text"];
            this.btnPrint.Text = translate["frmSalesExportSearchReportByCat.btnPrint.Text"];
            this.btnExit.Text = translate["frmSalesExportSearchReportByCat.btnExit.Text"];
            this.btnExport.Text = translate["frmSalesExportSearchReportByCat.btnExport.Text"];
            this.label2.Text = translate["frmSalesExportSearchReportByCat.label2.Text"];
            this.btnSeach.Text = translate["frmSalesExportSearchReportByCat.btnSeach.Text"];
            this.label1.Text = translate["frmSalesExportSearchReportByCat.label1.Text"];
            this.groupBox2.Text = translate["frmSalesExportSearchReportByCat.groupBox2.Text"];
            this.lblPage.Text = translate["frmSalesExportSearchReportByCat.lblPage.Text"];
            this.lblScount.Text = translate["frmSalesExportSearchReportByCat.lblScount.Text"];
            this.btnChoosePage.Text = translate["frmSalesExportSearchReportByCat.btnChoosePage.Text"];
            this.label6.Text = translate["frmSalesExportSearchReportByCat.label6.Text"];
            this.STT.HeaderText = translate["frmSalesExportSearchReportByCat.STT.HeaderText"];
            this.Text = translate["frmSalesExportSearchReportByCat.Text"];
        }	

        #endregion

        #region Constant
        private int rows;
        public string StoreName, Path, dateFrom, dateTo;
                
        string DeptCode, FromDate, ToDate;
        int PageSize = 20; int PageIndex = 1;

        DataTable dtExcel;

        //private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        //private const string NODE_PALCE_CODE = "Vị trí";
        //private const string NODE_SHOP_CODE = "Cửa hàng";
        //private const string LOC_CODE = "LOC.";
        //private const string STO_CODE = "STO.";
        #endregion

        #region Methods
        private void ImportPara()
         {
             try
             {
                 DeptCode = UserImformation.DeptCode;
                 dateFrom = Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss");
                 dateTo = Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd HH:mm:ss");
                 PageIndex = 1;
                 PageSize = 20;
                 FromDate = dtpdateFrom.Value.ToString("dd/MM/yyyy");
                 ToDate = dtpdateTo.Value.ToString("dd/MM/yyyy");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
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
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }

        }

       
        //Tim kiem
        private void SearchCat()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@FromDate", Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss"));
                para[2] = posdb_vnmSqlDAC.newInParam("@ToDate", Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd HH:mm:ss"));
                para[3] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                para[4] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);

                ds = sqlDac.GetDataSet("rptReport_SalesExportSearchReportByCat", para);
                ds.DataSetName = "dsEntryInventoryProduct_Sale";
                
                ds.Tables[0].TableName = "SalesExportByDate_ByCat";

                dtExcel = new DataTable();
                dtExcel = ds.Tables[3].Copy();
               
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(Properties.rsfReport.Coupon.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvCAT.DataSource = null;
                }
                DataTable dtTem = new DataTable();

                rows = ds.Tables[0].Rows.Count;
                lblScount.Text = "Tổng: " + rows.ToString() + " dòng";

                dtTem = ds.Tables[0].Copy();
                
                
                dgvCAT.AutoGenerateColumns = true;
                dgvCAT.DataSource = dtTem;

                for (int j = 0; j < dtTem.Columns.Count; j++)
                {
                    string colName;
                    colName = dtTem.Columns[j].ColumnName.ToString();
                    if (dgvCAT.Columns.Contains(colName))
                    {
                        dgvCAT.Columns[j].HeaderText = colName;
                        if (dtTem.Columns.Contains(colName))
                        {
                            if (dtTem.Columns[colName].DataType.FullName.ToLower().Contains("double") ||
                                dtTem.Columns[colName].DataType.FullName.ToLower().Contains("int") ||
                                dtTem.Columns[colName].DataType.FullName.ToLower().Contains("decimal"))
                            {
                                dgvCAT.Columns[colName].DefaultCellStyle.Format = "N0";
                                dgvCAT.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvCAT.Columns[colName].InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
                }

                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        private void FillDataset()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@FromDate", Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss"));
                para[2] = posdb_vnmSqlDAC.newInParam("@ToDate", Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd HH:mm:ss"));
                para[3] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                para[4] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);

                ds = sqlDac.GetDataSet("rptReport_SalesExportSearchReportByCat", para);
                ds.DataSetName = "dsEntryInventoryProduct_Sale";
                

                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));

                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = dtpdateFrom.Value.ToString("dd/MM/yyyy");
                drDate["ToDate"] = dtpdateTo.Value.ToString("dd/MM/yyyy");

                dtDate.Rows.Add(drDate);
                ds.Tables[2].TableName = "SalesExportByDate_ByCat";

                DataTable dtStore = ds.Tables.Add("StoreInfo");
                Print.AddUserInfo(dtStore);
                DataTable dtlogo = ds.Tables.Add("StoreLogo");
                Print.AddLogo(dtlogo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        private void DoPaning()
        {
            try
            {
                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

                int s = Convert.ToInt32(cboRows.SelectedItem.ToString()) * Convert.ToInt32(lblCurrentPage.Text) + 1;
                int rowOnPage = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                DataTable gridTable = (DataTable)dgvCAT.DataSource;
                gridTable.DefaultView.RowFilter = "STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString(); //+ ") or (STT = 0 )" + "or STT =" + s.ToString();

                //gridTable.DefaultView.RowFilter = "STT =" + (gridTable.Rows.Count - 1)
                //            + " OR (STT >= 0 and STT <= 20)";

                if (currentPage == 0)
                {
                    btnTopPage.Enabled = false;
                    btnPrev.Enabled = false;
                }
                if (currentPage == pageCount)
                {
                    btnNext.Enabled = false;
                    btnEndPage.Enabled = false;
                }

                if (rows > pageSize)
                {
                    btnTopPage.Enabled = (currentPage > 1);
                    btnPrev.Enabled = (currentPage > 1);
                    btnNext.Enabled = (currentPage < pageCount);
                    btnEndPage.Enabled = (currentPage < pageCount);
                }
                if (dgvCAT.Rows.Count > 0)
                {
                    dgvCAT.Rows[0].Cells[0].Selected = true;
                    btnExport.Enabled = true;
                    btnChoosePage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: Dopaning " + ex.Message);
            }
        }

        private void ExportExcel()
        {
            try
            {
                if (dgvCAT.Rows.Count > 0)
                {
                    //DataTable dtEx = Conversion.ConvertDataGridVewToDataTable(dgvCAT);

                    //string fileName = "" + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    //string date = "TỪ NGÀY: " + dateFrom + " ĐẾN NGÀY: " + dateTo;
                    //Export ex = new Export();
                    //ex.InfoCompany = true;
                    //ex.InfoStore = true;
                    //ex.StrTitle = "06.03.BÁO CÁO BÁN HÀNG THEO CAT".ToUpper();

                    //ex.StrDate = date.ToUpper();
                    //ex.ExportToExcel(dtEx,fileName);

                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = "06.03.BÁO CÁO BÁN HÀNG THEO CAT";
                    exN.Dt = this.dtExcel;
                    exN.CaseEx = 3;
                    exN.FileNames = "" + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                    //int[] col = { 0 };
                    //exN.ArrSum = col;
                    //exN.RSumQuantity = 0;
                    exN.StrDate = "TỪ NGÀY: " + dtpdateFrom.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) + " ĐẾN NGÀY: " + dtpdateTo.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate);
                    exN.ExportExcels();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region Event
        private void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                //ImportPara();
                SearchCat();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void frmReportSale_Load(object sender, EventArgs e)
        {
            try
            {
                dateFrom = Conversion.GetDateFormat(dtpdateFrom.Value);
                
                this.ActiveControl = dtpdateFrom;

                btnChoosePage.Enabled = false;
                btnEndPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnTopPage.Enabled = false;
                btnExport.Enabled = false;

                dtpdateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpdateTo.Value = sqlDac.GetDateTimeServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
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
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        

        private void dgvCAT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //dgvCAT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvCAT.Font, FontStyle.Bold);

                    foreach (DataGridViewColumn c in dgvCAT.Columns)
                    {
                        c.DefaultCellStyle.Format = "#,0";
                        c.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    int i = 0;

                    foreach (DataGridViewRow r in dgvCAT.Rows)
                    {
                        if (r.Cells["STT"].Value != null)
                        {
                            string name = r.Cells["STT"].Value.ToString().Trim();
                            i++;
                            if (i % 2 == 0 && name != "")
                            {
                                r.DefaultCellStyle = bgcolor;

                            }
                            // nếu là dòng tổng cộng thì in đậm
                            //if (name == "")
                            //{
                            //    r.DefaultCellStyle = bgcolor1;
                            //}
                        }

                    }

                }
                dgvCAT.ColumnHeadersVisible = (dgvCAT.Rows.Count > 0);
                btnExport.Enabled = (dgvCAT.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
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

        private void cboRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCAT.Rows.Count > 1)
                {
                    lblCurrentPage.Text = "1";
                    DoPaning();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage + 1).ToString();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage - 1).ToString();
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnEndPage_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = lblTotalPage.Text;
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnChoosePage_Click(object sender, EventArgs e)
        {
            try
            {
                int pageGo = Convert.ToInt32(txtGoPage.Text);
                int pageCount = Convert.ToInt32(lblTotalPage.Text);
                if (pageGo >= 1 && pageGo <= pageCount)
                {
                    lblCurrentPage.Text = txtGoPage.Text;
                    DoPaning();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //ImportPara();
                FillDataset();

                FrmReporter.FrmReportView.frmReportViewNew frm = new FrmReporter.FrmReportView.frmReportViewNew(translate);
                frm.SetINFBC(StoreName, Path);
                frm.ds = ds;
                frm.IsMdiContainer = true;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
       
        private void btnTopPage_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = "1";
                DoPaning();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

          
    }
}

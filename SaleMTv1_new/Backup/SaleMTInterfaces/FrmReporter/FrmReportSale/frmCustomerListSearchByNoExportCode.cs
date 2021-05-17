using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmCustomerListSearchByNoExportCode : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private int rows;
        #endregion

        #region Constructor
        
        public frmCustomerListSearchByNoExportCode(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboRows.Text = "20";
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmCustomerListSearchByNoExportCode.groupBox1.Text"];
            this.btnPrint.Text = translate["frmCustomerListSearchByNoExportCode.btnPrint.Text"];
            this.btnExit.Text = translate["frmCustomerListSearchByNoExportCode.btnExit.Text"];
            this.btnExport.Text = translate["frmCustomerListSearchByNoExportCode.btnExport.Text"];
            this.btnSeach.Text = translate["frmCustomerListSearchByNoExportCode.btnSeach.Text"];
            this.label1.Text = translate["frmCustomerListSearchByNoExportCode.label1.Text"];
            this.groupBox2.Text = translate["frmCustomerListSearchByNoExportCode.groupBox2.Text"];
            this.CUSTOMER_ID.HeaderText = translate["frmCustomerListSearchByNoExportCode.CUSTOMER_ID.HeaderText"];
            this.CUSTOMER_NAME.HeaderText = translate["frmCustomerListSearchByNoExportCode.CUSTOMER_NAME.HeaderText"];
            this.ADDRESSS.HeaderText = translate["frmCustomerListSearchByNoExportCode.ADDRESSS.HeaderText"];
            this.lblCount.Text = translate["frmCustomerListSearchByNoExportCode.lblCount.Text"];
            this.btnChoosePage.Text = translate["frmCustomerListSearchByNoExportCode.btnChoosePage.Text"];
            this.lblPage.Text = translate["frmCustomerListSearchByNoExportCode.lblPage.Text"];
            this.label6.Text = translate["frmCustomerListSearchByNoExportCode.label6.Text"];
            this.Text = translate["frmCustomerListSearchByNoExportCode.Text"];

        }
        #endregion

        #region Constant
        //posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        Conversion sqlcommon = new Conversion();
        DataSet ds = new DataSet();
        public string StoreName, Path, dateFrom, dateTo;
       
        string DeptCode, FromDate, ToDate;
        int PageSize, PageIndex;

        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        private const string RE_TITLE = "06.07.BÁO CÁO DANH SÁCH KHÁCH HÀNG KHÔNG CÓ GIAO DỊCH";
        #endregion

        #region Methods
        private void ImportPara()
         {
             try
             {
                 DeptCode = ","+ UserImformation.DeptCode ;
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

        private void DoPaning()
        {
            //phân trang
            try
            {
                DataTable gridTable = (DataTable)dgvListCus.DataSource;

                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

                int rowOnPage = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                gridTable.DefaultView.RowFilter = "STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString();

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
                if (dgvListCus.Rows.Count > 0)
                {
                    dgvListCus.Rows[0].Cells[0].Selected = true;
                    btnExport.Enabled = true;
                    btnChoosePage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: DoPaing" + ex.Message);
            }
        }

        //SearchCus
        
        private void SearchCus()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[5];
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@FromDate", dateFrom);
                para[2] = posdb_vnmSqlDAC.newInParam("@ToDate", dateTo);
                para[3] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                para[4] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);

                ds = sqlDac.GetDataSet("rptReport_CustomerListSearchReportByNoExportCode", para);
                ds.DataSetName = "dsEntryInventoryProduct_Sale";
                //ds.Tables[0].TableName = "Date";
                ds.Tables[2].TableName = "SalesExportByDate_NoExport";
                //ds.Tables[4].TableName = "StoreInfo";
                //ds.Tables[5].TableName = "StoreLogo";
                //load data vào lưới
                
                if (ds.Tables[2].Rows.Count == 0)
                {
                    MessageBox.Show(Properties.rsfReport.Coupon.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvListCus.DataSource = null;
                }
                DataTable tem = ds.Tables[2].Copy();

                tem.Columns.Add("STT", typeof(int));
                for (int i = 0; i < tem.Rows.Count; i++)
                {
                    tem.Rows[i]["STT"] = i + 1;
                }
                dgvListCus.AutoGenerateColumns = false;
                dgvListCus.DataSource = tem;
                btnExport.Enabled = true;
                //Tổng số dòng

                rows = ds.Tables[2].Rows.Count;
                lblCount.Text = "Tổng: " + rows.ToString() + " dòng";
                lblCurrentPage.Text = (rows > 0) ? "1" : "0";
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
                para[0] = posdb_vnmSqlDAC.newInParam("@DeptCode", DeptCode);
                para[1] = posdb_vnmSqlDAC.newInParam("@FromDate", dateFrom);
                para[2] = posdb_vnmSqlDAC.newInParam("@ToDate", dateTo);
                para[3] = posdb_vnmSqlDAC.newInParam("@PageSize", PageSize);
                para[4] = posdb_vnmSqlDAC.newInParam("@PageIndex", PageIndex);

                ds = sqlDac.GetDataSet("rptReport_CustomerListSearchReportByNoExportCode", para);
                ds.DataSetName = "dsEntryInventoryProduct_Sale";
                

                DataTable dtDate = ds.Tables.Add("Date");
                dtDate.Columns.Add("FromDate", typeof(string));
                dtDate.Columns.Add("ToDate", typeof(string));

                DataRow drDate = dtDate.NewRow();
                drDate["FromDate"] = FromDate;
                drDate["ToDate"] = ToDate;

                dtDate.Rows.Add(drDate);
                ds.Tables[2].TableName = "SalesExportByDate_NoExport";

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

        //load du lieu vao treview listShop
        private void LoadTreListStore()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", STO_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_LIST_STORE_CODE);
                    trNode.Expand();
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.StoreCode)
                        {
                            childNode.Checked = true;
                            //childNode.Expand();
                        }
                    }
                    this.treStoreList.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreListStore': " + ex.Message);
            }

        }

        private void LoadTrePlace()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", LOC_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_PALCE_CODE);
                    trNode.Expand();
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);

                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.BusinessTypeCode)
                        {
                            childNode.Checked = true;

                        }
                    }
                    this.trePlace.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTrePlace': " + ex.Message);
            }
            //node goc dau tien

        }

        private void LoadTreShop()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DeptCode", UserImformation.DeptNumber) };
                DataTable dtMaster = sqlDac.GetDataTable("GetTreeDeptCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode[] childNode = new TreeNode[dtMaster.Rows.Count];

                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        childNode[i] = new TreeNode(dtMaster.Rows[i]["name"].ToString());
                        childNode[i].Expand();
                    }
                    for (int i = 0; i < childNode.Length - 1; i++)
                    {
                        childNode[i].Nodes.Add(childNode[i + 1]);
                        if (i >= childNode.Length - 2)
                        {
                            childNode[i].Checked = true;
                            childNode[i + 1].Checked = true;

                        }
                    }
                    this.treStore.Nodes.Add(childNode[0]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreShop': " + ex.Message);
            }
            //node goc dau tien

        }

        //Ham an hien cac tab
        private void DisplayTab()
        {
            try
            {
                if (pnlStoreList.Size.Height == 26)
                {
                    btnStoreList.ImageIndex = 0;
                    pnlStoreList.Size = new Size(217, 139);
                    pnlPlace.Location = new Point(3, 15 + 139);
                    pnlStore.Location = new Point(3, 15 + 139 + pnlStoreS.Size.Height);
                }
                else
                {
                    btnStoreList.ImageIndex = 1;
                    pnlStoreList.Size = new Size(217, 26);
                    pnlPlace.Location = new Point(3, 15 + 26);
                    pnlStore.Location = new Point(3, 15 + 26 + pnlPlace.Size.Height);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: DisplayTab" + ex.Message);
            }
        }

        private void ResizePlace()
        {
            try
            {
                if (pnlPlace.Size.Height == 26)
                {
                    btnPlace.ImageIndex = 0;
                    pnlPlace.Size = new Size(217, 139);
                    pnlStore.Location = new Point(3, 15 + pnlStoreList.Size.Height + 139);
                }
                else
                {
                    btnPlace.ImageIndex = 1;
                    pnlPlace.Size = new Size(217, 26);
                    pnlStore.Location = new Point(3, 15 + pnlStoreList.Size.Height + 26);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void ResizeShop()
        {
            try
            {
                if (pnlStore.Size.Height == 26)
                {
                    btnStore.ImageIndex = 0;
                    pnlStore.Size = new Size(217, 369);
                }
                else
                {
                    btnStore.ImageIndex = 1;
                    pnlStore.Size = new Size(217, 26);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }

        private void LoadControl()
        {
            try
            {
                pnlStoreList.Size = new Size(217, 26);
                pnlPlace.Size = new Size(217, 26);
                pnlPlace.Location = new Point(4, 41);
                pnlStore.Size = new Size(217, 26);
                pnlStore.Location = new Point(4, 67);
                treStoreList.Enabled = false;
                trePlace.Enabled = false;
                treStore.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }

        }

        
        #endregion

        #region Event
        private void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                SearchCus();
                DoPaning();
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
                MessageBox.Show(translate["Msg.Error"] + ": " + ex.Message);
            }
        }

        private void btnStoreList_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTab();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void dgvListCus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //dgvListCus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvListCus.Font, FontStyle.Bold);

                    int i = 0;

                    foreach (DataGridViewRow r in dgvListCus.Rows)
                    {
                        if (r.Cells["CUSTOMER_ID"].Value != null)
                        {
                            string name = r.Cells["CUSTOMER_ID"].Value.ToString().Trim();
                            i++;
                            if (i % 2 == 0)
                            {
                                r.DefaultCellStyle = bgcolor;

                            }

                        }

                    }

                }
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
                if (dgvListCus.Rows.Count > 1)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPara();
                SearchCus();
                DataTable dtExcel = ds.Tables[3].Copy();
                ExportExcel ex = new ExportExcel();

                ex.InfoCompany = true;
                ex.InfoStore = true;
                ex.StrTitle = RE_TITLE.ToUpper();
                ex.StrDate = "TỪ NGÀY: "+ dtpdateFrom.Value.ToString("dd/MM/yyyy") +" ĐẾN NGÀY: " + dtpdateTo.Value.ToString("dd/MM/yyyy");
                ex.Dt = dtExcel;
                ex.FileNames = this.Text + "_Filled_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                ex.CaseEx = 3;                
                ex.ArrSum = null;
                ex.ExportExcels();
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void frmCustomerListSearchByNoExportCode_Load(object sender, EventArgs e)
        {
            try
            {
                dateFrom = Conversion.GetDateFormat(dtpdateFrom.Value);
                LoadTreListStore();
                LoadTrePlace();
                LoadTreShop();
                LoadControl();
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
                ImportPara();
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
        #endregion

    }
}

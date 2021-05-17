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
using System.Globalization;

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmInvoicher : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        DataTable dtExcel = new DataTable();
        #endregion

        #region Constant
        private int rows;
        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        public string StoreName, Path, dateFrom, dateTo, DeptCode, ToDate, DateI;
        float From, To;
        public int type = 0;
        #endregion

        #region Constructor
        public frmInvoicher(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboRows.Text = "20";
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.lblScount.Text = translate["frmInvoicher.lblScount.Text"];
            this.btnChoosePage.Text = translate["frmInvoicher.btnChoosePage.Text"];
            this.lblPage.Text = translate["frmInvoicher.lblPage.Text"];
            this.label6.Text = translate["frmInvoicher.label6.Text"];
            this.groupBox2.Text = translate["frmInvoicher.groupBox2.Text"];
            this.STT.HeaderText = translate["frmInvoicher.STT.HeaderText"];
            this.groupBox1.Text = translate["frmInvoicher.groupBox1.Text"];
            this.chkFromInvoi.Text = translate["frmInvoicher.chkFromInvoi.Text"];
            this.btnExit.Text = translate["frmInvoicher.btnExit.Text"];
            this.btnExport.Text = translate["frmInvoicher.btnExport.Text"];
            this.label2.Text = translate["frmInvoicher.label2.Text"];
            this.btnSeach.Text = translate["frmInvoicher.btnSeach.Text"];
            this.label1.Text = translate["frmInvoicher.label1.Text"];
            this.Text = translate["frmInvoicher.Text"];

        }
        
        #endregion

        #region Methods
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
        private void SetGT()
        {
            try
            {
                From = (txtFrom.Text.Trim() != "") ? float.Parse(Conversion.Replaces(txtFrom.Text)) : 0;
                To = (txtTo.Text.Trim() != "") ? float.Parse(Conversion.Replaces(txtTo.Text)) : 0;

                dateFrom = Conversion.FirstDayTime(dtpdateFrom.Value).ToString("yyyy/MM/dd HH:mm:ss");
                dateTo = Conversion.LastDayTime(dtpdateTo.Value).ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                log.Error("Error: SetGT" + ex.Message);
            }
        }

        //check
        private void checkInvoiFrom()
        {
            try
            {
                if (chkFromInvoi.Checked)
                {
                    txtFrom.ReadOnly = false;
                    return;
                }
                else
                {
                    txtFrom.ReadOnly = true;
                    txtFrom.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void checkInvoiTo()
        {
            try
            {
                if (chkToinvoi.Checked)
                {
                    txtTo.ReadOnly = false;
                    return;
                }
                else
                {
                    txtTo.ReadOnly = true;
                    txtTo.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
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
                    //this.treStoreList.Nodes.Add(trNode);
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
                    //this.trePlace.Nodes.Add(trNode);
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
                    //this.treStore.Nodes.Add(childNode[0]);
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
            //if (pnlStoreList.Size.Height == 26)
            //{
            //    btnStoreList.ImageIndex = 0;
            //    pnlStoreList.Size = new Size(217, 139);
            //    pnlPlace.Location = new Point(3, 15 + 139);
            //    pnlStore.Location = new Point(3, 15 + 139 + pnlStoreS.Size.Height);
            //}
            //else
            //{
            //    btnStoreList.ImageIndex = 1;
            //    pnlStoreList.Size = new Size(217, 26);
            //    pnlPlace.Location = new Point(3, 15 + 26);
            //    pnlStore.Location = new Point(3, 15 + 26 + pnlPlace.Size.Height);
            //}
        }

        private void ResizePlace()
        {
            try
            {
                //if (pnlPlace.Size.Height == 26)
                //{
                //    btnPlace.ImageIndex = 0;
                //    pnlPlace.Size = new Size(217, 139);
                //    pnlStore.Location = new Point(3, 15 + pnlStoreList.Size.Height + 139);
                //}
                //else
                //{
                //    btnPlace.ImageIndex = 1;
                //    pnlPlace.Size = new Size(217, 26);
                //    pnlStore.Location = new Point(3, 15 + pnlStoreList.Size.Height + 26);
                //}
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
                //if (pnlStore.Size.Height == 26)
                //{
                //    btnStore.ImageIndex = 0;
                //    pnlStore.Size = new Size(217, 369);
                //}
                //else
                //{
                //    btnStore.ImageIndex = 1;
                //    pnlStore.Size = new Size(217, 26);
                //}
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
                //pnlStoreList.Size = new Size(217, 26);
                //pnlPlace.Size = new Size(217, 26);
                //pnlPlace.Location = new Point(4, 41);
                //pnlStore.Size = new Size(217, 26);
                //pnlStore.Location = new Point(4, 67);
                //treStoreList.Enabled = false;
                //trePlace.Enabled = false;
                //treStore.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }

        }

        private string GetCurrency(string money)
        {
            string mReturn = "";
            try
            {
                if (money.Trim().Length > 0)
                {
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    mReturn = double.Parse(money).ToString("###,###,###,###,###", cul.NumberFormat);
                }
                mReturn = (mReturn.Length > 0) ? mReturn : "";
            }
            catch (Exception ex)
            {
                log.Error("Error 'GetCurrency': " + ex.Message);
            }
            return mReturn;
        }

        private void DoPaning()
        {
            DataTable gridTable = (DataTable)dgvCusTotalInvoi.DataSource;

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
            if (dgvCusTotalInvoi.Rows.Count > 0)
            {
                dgvCusTotalInvoi.Rows[0].Cells[0].Selected = true;
                btnExport.Enabled = true;
                btnChoosePage.Enabled = true;
            }
        }

        //load luoi
        private void loadGrid()
        {
            try
            {
                if (From > To && To > 0 && From >0)
                {
                    MessageBox.Show(Properties.rsfPayment.Invoicher01.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFrom.Focus();
                }

                SetGT();
                string proc = "Customer_total_Invoicher";
                SqlParameter[] para = new SqlParameter[5];
                para[0] = posdb_vnmSqlDAC.newInParam("@DateFrom", dateFrom);
                para[1] = posdb_vnmSqlDAC.newInParam("@DateTo", dateTo);
                para[2] = posdb_vnmSqlDAC.newInParam("@type", type);
                para[3] = posdb_vnmSqlDAC.newInParam("@From", From);
                para[4] = posdb_vnmSqlDAC.newInParam("@To", To);
                DataTable dtCus = new DataTable();
                dtCus = sqlDac.GetDataTable(proc, para);
                dtExcel = dtCus.Copy();

                if (dtCus.Rows.Count == 0)
                {
                    MessageBox.Show(Properties.rsfReport.Coupon.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //add them STT
                DataTable tem = dtCus.Copy();

                tem.Columns.Add("STT", typeof(int));
                for (int i = 0; i < tem.Rows.Count; i++)
                {
                    tem.Rows[i]["STT"] = i + 1;
                }

                rows = dtCus.Rows.Count;

                dgvCusTotalInvoi.DataSource = tem;

                for (int j = 0; j < tem.Columns.Count; j++)
                {
                    string colName;
                    colName = tem.Columns[j].ColumnName.ToString();
                    if (dgvCusTotalInvoi.Columns.Contains(colName))
                    {
                        dgvCusTotalInvoi.Columns[j].HeaderText = colName;
                        if (tem.Columns.Contains(colName))
                        {
                            if (tem.Columns[colName].DataType.FullName.ToLower().Contains("double") ||
                                tem.Columns[colName].DataType.FullName.ToLower().Contains("int") ||
                                tem.Columns[colName].DataType.FullName.ToLower().Contains("decimal"))
                            {
                                dgvCusTotalInvoi.Columns[colName].DefaultCellStyle.Format = "N0";
                                dgvCusTotalInvoi.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvCusTotalInvoi.Columns[colName].InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
                }

                lblScount.Text = "Tổng: " + rows.ToString() + "dòng";
                //lblCurrentPage.Text = (rows > 0) ? "1" : "0";
                int pageSize = Convert.ToInt32(cboRows.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void ExportExcel()
        {
            try
            {
                if (dgvCusTotalInvoi.Rows.Count > 0)
                {
                   
                    ExportExcel exN = new ExportExcel();
                    exN.InfoCompany = true;
                    exN.InfoStore = true;
                    exN.StrTitle = "06.05.BÁO CÁO BÁN HÀNG THEO HÓA ĐƠN";
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
                dgvCusTotalInvoi.DataSource = null;
                loadGrid();
                DoPaning();
                
                for (int i = 0; i < dgvCusTotalInvoi.Columns.Count; i++)
                {
                    dgvCusTotalInvoi.Columns["STT"].Visible = false;
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
                if (dgvCusTotalInvoi.Rows.Count > 1)
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

        private void dgvCusTotalInvoi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //dgvCusTotalInvoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    
                    //dgvCusTotalInvoi.dis

                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);

                    DataGridViewCellStyle bgcolor1 = new DataGridViewCellStyle();
                    bgcolor1.BackColor = Color.FromArgb(210, 180, 140);
                    bgcolor1.Font = new Font(dgvCusTotalInvoi.Font, FontStyle.Bold);

                    foreach (DataGridViewColumn col in dgvCusTotalInvoi.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    int i = 0;

                    foreach (DataGridViewRow r in dgvCusTotalInvoi.Rows)
                    {
                        if (r.Cells["STT"].Value != null)
                        {
                            string name = r.Cells["STT"].Value.ToString().Trim();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmInvoicher_Load(object sender, EventArgs e)
        {
            try
            {
                btnChoosePage.Enabled = false;
                btnEndPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnTopPage.Enabled = false;
                btnExport.Enabled = false;

                LoadTreListStore();
                LoadTrePlace();
                LoadTreShop();
                LoadControl();

                dtpdateFrom.Value = Conversion.GetFirstDayOfMonth(sqlDac.GetDateTimeServer());
                dtpdateTo.Value = sqlDac.GetDateTimeServer();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkFromInvoi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkInvoiFrom();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void chkToinvoi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkInvoiTo();
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

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtFrom.Text = GetCurrency(Conversion.Replaces(txtFrom.Text));
                txtFrom.SelectionStart = txtFrom.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void txtMoneyTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTo.Text = GetCurrency(Conversion.Replaces(txtTo.Text));
                txtTo.SelectionStart = txtTo.Text.Trim().Length;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion
    }
}

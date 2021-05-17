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
using System.Collections;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using SaleMTInterfaces.FrmCustomerEmployee;


namespace SaleMTInterfaces.FrmCustomerEmployee
{
    public partial class frmSearchEmployeeName : Form
    {
        #region Constant
        private string ROW1 = "20";
        int CurPage = 1;
        int pageSize = 20;
        int pagerows = 0;
        int sCount = 0;
        #endregion

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private string textName;
        
        public string TextName
        {
            get { return textName; }
            set { textName = value; }
        }
        #endregion

        #region Contrustor
        
        public frmSearchEmployeeName(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
            cboRows.Text = ROW1;
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.groupBox1.Text = translate["frmSearchEmployeeName.groupBox1.Text"];
            this.btnChoosePage.Text = translate["frmSearchEmployeeName.btnChoosePage.Text"];
            this.lblPage.Text = translate["frmSearchEmployeeName.lblPage.Text"];
            this.label1.Text = translate["frmSearchEmployeeName.label1.Text"];
            this.colEmployeeCode.Text = translate["frmSearchEmployeeName.colEmployeeCode.Text"];
            this.colEmploeeName.Text = translate["frmSearchEmployeeName.colEmploeeName.Text"];
            this.colEmployeeFisrtName.Text = translate["frmSearchEmployeeName.colEmployeeFisrtName.Text"];
            this.colRoom.Text = translate["frmSearchEmployeeName.colRoom.Text"];
            this.btnOK.Text = translate["frmSearchEmployeeName.btnOK.Text"];
            this.btnClose.Text = translate["frmSearchEmployeeName.btnClose.Text"];
            this.Text = translate["frmSearchEmployeeName.Text"];
        }	

        #endregion

        #region methods
        //Tim kiem nhan vien theo text truyen vao
        public void searchEmName(string textName)
        {
            try
            {
                string proc = "EMPLOYEE_INFO_SearchName";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@Name", SqlDbType.VarChar, textName);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvwSearchEmName.Items.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());
                    lvwSearchEmName.Items[i].SubItems.Add(dt.Rows[i]["FIRST_NAME"].ToString());
                    lvwSearchEmName.Items[i].SubItems.Add(dt.Rows[i]["LAST_NAME"].ToString());
                    lvwSearchEmName.Items[i].SubItems.Add(GetPlaceCreate(327));
                }
                if (dt.Rows.Count < pageSize)
                {
                    btnEndPage.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrev.Enabled = false;
                    btnTopPage.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        DataTable dtPan = new DataTable();
        private void Resion(int curPage)
        {
            try
            {
                if (curPage != 0)
                {
                    if (curPage == 1)
                    {
                        btnPrev.Enabled = false;
                        btnTopPage.Enabled = false;
                        btnNext.Enabled = true;
                        btnEndPage.Enabled = true;
                        return;
                    }

                    if (curPage == Convert.ToInt32(Math.Ceiling(dtPan.Rows.Count / (decimal)pageSize)))
                    {
                        btnEndPage.Enabled = false;
                        btnNext.Enabled = false;
                        btnPrev.Enabled = true;
                        btnTopPage.Enabled = true;
                        return;
                    }
                    if (curPage >= 1 && curPage <= Convert.ToInt32(Math.Ceiling(dtPan.Rows.Count / (decimal)pageSize)))
                    {
                        btnNext.Enabled = true;
                        btnEndPage.Enabled = true;
                        btnPrev.Enabled = true;
                        btnTopPage.Enabled = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //Hàm load thông tin nhân viên va phan trang listview
        
        private void loadEm(int curPage)
        {
            try
            {
                string proc = "EMPLOYEE_INFO_SearchName";
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@Name", SqlDbType.VarChar, textName);
                DataTable dt = new DataTable();
                dt = sqlDac.GetDataTable(proc, para);
                dtPan = dt.Copy();

                int pageSize = Convert.ToInt32(cboRows.Text);
                if (dt.Rows.Count < pageSize)
                {
                    btnEndPage.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrev.Enabled = false;
                    btnTopPage.Enabled = false;
                }

                pagerows = Convert.ToInt32(Math.Ceiling(dt.Rows.Count / (double)pageSize));

                lvwSearchEmName.Items.Clear();
                int j = 0;
                for (int i = (curPage - 1) * pageSize; i < curPage * pageSize; i++)
                {
                    if (i < dt.Rows.Count && curPage <= Convert.ToInt32(Math.Ceiling(dt.Rows.Count / (double)pageSize)) && curPage > 0)
                    {
                        lvwSearchEmName.Items.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());
                        lvwSearchEmName.Items[j].SubItems.Add(dt.Rows[i]["FIRST_NAME"].ToString());
                        lvwSearchEmName.Items[j].SubItems.Add(dt.Rows[i]["LAST_NAME"].ToString());
                        lvwSearchEmName.Items[j].SubItems.Add(GetPlaceCreate(327));

                        if (j % 2 == 0)
                        {
                            lvwSearchEmName.Items[j].BackColor = Color.FromArgb(224, 223, 227);
                        }
                        j++;
                    }
                }
                sCount = dt.Rows.Count;
                lblPage.Text = curPage.ToString() + "/" + Math.Ceiling(dt.Rows.Count / (double)pageSize).ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private string GetPlaceCreate(int deptCode)
        {
            string storeName = "";
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@DEPT_CODE", deptCode) };
                DataTable dtTemp = new DataTable();
                dtTemp = sqlDac.GetDataTable("GetPlaceCreateCustomer", para);
                if (dtTemp.Rows.Count > 0)
                {
                    storeName = dtTemp.Rows[0]["Place"].ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetPlaceCreate': " + ex.Message);
            }
            return storeName;
        }

        
        #endregion

        #region Event
        private void lvwSearchEmName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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

        private void frmSearchEmployeeName_Load(object sender, EventArgs e)
        {
            try
            {
                searchEmName(textName);
                if (lvwSearchEmName.Items.Count > 0)
                {
                    CurPage = 1;
                    loadEm(CurPage);
                    lblPage.Text = "Trang " + CurPage.ToString() + "/" + pagerows.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        

        private void lvwSearchEmName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                searchEmName(textName);
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnChoosePage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtGoPage.Text) > Math.Ceiling(sCount / (double)pageSize))
            {
                MessageBox.Show("Không có trang " + txtGoPage.Text, translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            { 
                int cur = Convert.ToInt32(txtGoPage.Text);
                loadEm(cur);
            }
            //if (Convert.ToInt32(txtGoPage.Text) == 1)
            //{
            //    searchEmName(textName);
            //    return;
            //}
            if (Convert.ToInt32(txtGoPage.Text) == 0)
            {
                lvwSearchEmName.Items.Clear(); 
                return;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwSearchEmName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchEmName(textName);
                this.Close();
            }
        }

        private void btnEndPage_Click(object sender, EventArgs e)
        {
            try
            {
                CurPage = Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize));
                Resion(CurPage);
                loadEm(CurPage);
                lblPage.Text = "Trang " + CurPage.ToString() + "/" + CurPage.ToString();

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
                CurPage = 1;
                Resion(CurPage);
                loadEm(CurPage);
                int sPage = Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize));
                lblPage.Text = "Trang " + CurPage.ToString() + "/" + sPage.ToString();
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
                loadEm(CurPage - 1);
                Resion(CurPage - 1);
                int sPage = Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize));
                lblPage.Text = "Trang " + (CurPage - 1).ToString() + "/" + sPage.ToString();
                CurPage--;
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
                loadEm(CurPage + 1);
                Resion(CurPage + 1);
                int sPage = Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize));
                lblPage.Text = "Trang " + (CurPage + 1).ToString() + "/" + sPage.ToString();
                CurPage++;
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
                pageSize = Convert.ToInt32(cboRows.Text);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
   
    }
}

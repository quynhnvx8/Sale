using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTCommon;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using SaleMTBusiness.SaleManagement;
using SaleMTInterfaces.PrintBill;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using SaleMTInterfaces.FrmReporter.FrmReportSale;


namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmProductReportSearch : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion

        #region Constructor
       
        public frmProductReportSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            cboReasion.SelectedValue = "";
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.label1.Text = translate["frmProductReportSearch.label1.Text"];
            this.tabReasion.Text = translate["frmProductReportSearch.tabReasion.Text"];
            this.groupBox2.Text = translate["frmProductReportSearch.groupBox2.Text"];
            this.groupBox1.Text = translate["frmProductReportSearch.groupBox1.Text"];
            this.groupBox3.Text = translate["frmProductReportSearch.groupBox3.Text"];
            this.btnClose.Text = translate["frmProductReportSearch.btnClose.Text"];
            this.btnSave.Text = translate["frmProductReportSearch.btnSave.Text"];
            this.btnInsert.Text = translate["frmProductReportSearch.btnInsert.Text"];
            this.btnOK.Text = translate["frmProductReportSearch.btnOK.Text"];
            this.Text = translate["frmProductReportSearch.Text"];
        }	

        #endregion

        #region  Constant
        public DataTable dtListCol;
        public string treGroup = "Nhóm sản phẩm ";
        public string listProGroup = "***Nhóm sản phẩm ";
        public string listReasion = "*** Danh sách cột ";
        public string listProGroupTag = "";
        public string ListResionTag = "";
        public string listProGroupTagNew = "";
        public string ListResionTagNew = "";
        public string Title = "";
        string id = "";
        #endregion

        #region Methods
        //Load cây nhóm sản phẩm
        private void LoadTreProductGroup()
        {
            string proc = "treProductGroup";
            DataTable dtGroup = new DataTable();
            dtGroup = sqlDac.GetDataTable(proc, null);

            TreeNode trNode = new TreeNode(treGroup);
            trNode.ImageIndex = 0;
            //trNode.Expand();
            for (int i = 0; i < dtGroup.Rows.Count; i++)
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = dtGroup.Rows[i]["GroupName"].ToString();
                childNode.Tag = dtGroup.Rows[i]["GroupCode"].ToString();
                childNode.Name = dtGroup.Rows[i]["TenSeg"].ToString();
                childNode.ImageIndex = 0;
                
                trNode.Nodes.Add(childNode);
            }
            this.treProductGroups.Nodes.Add(trNode);
            
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Hàm xử lý sự kiện khi check vào một node bất kỳ trên treeview 
        /// </summary>
        private void checkNode(TreeNode nodeNow)
        {
            foreach (TreeNode childNode in nodeNow.Nodes)
            {
                
                childNode.Checked = nodeNow.Checked;
                //s += s != "" ? "," + nodeNow.Tag.ToString() : nodeNow.Tag.ToString();
                checkNode(childNode);
                //listProGroupTagNew += s;
            }
            
        }

        //Lay ma seg
        private void GetIdSeg(TreeNode nodeNow, ArrayList arId)
        {
            //Neu node hien tai dc check thi add id vao mang
            if (nodeNow.Checked == true)
            {
                arId.Add(nodeNow.Tag);
            }
            //goi ham lay id cua cac node con
            foreach (TreeNode childNode in nodeNow.Nodes)
            {
                GetIdSeg(childNode, arId);
            }
        }

        //hien thi tat ca cac node dc check
        private void ShowGroup(string title)
        {
            string proc = "SaveComboboxConditions";
            SqlParameter[] paraShow;
            paraShow = new SqlParameter[1];
            paraShow[0] = posdb_vnmSqlDAC.newInParam("@AutoId", title);
            DataTable dtCbo = new DataTable();
            dtCbo = sqlDac.GetDataTable(proc, paraShow);

            treProductGroups.Nodes[0].Checked = false;
            
            for (int i = 0; i < dtCbo.Rows.Count; i++)
            {
                treProductGroups.Nodes[0].Expand();
                treProductGroups.Nodes[0].Nodes[i].Checked = true;  
            }
            //this.treProductGroups.Nodes.Add(trNode);
    
        }
        
        //Load dieu kien vao combobox dieu kien
        private void LoadReasion(string autoId)
        {
            string proc = "REPORT_CONDITIONS_ReadCbo";
            SqlParameter[] paraRea;
            paraRea = new SqlParameter[1];
            paraRea[0] = posdb_vnmSqlDAC.newInParam("@AUTO_ID", autoId);
            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, paraRea);

            cboReasion.DataSource = dt;
            cboReasion.DisplayMember = "TITLE";
            cboReasion.ValueMember = "AUTO_ID";
            cboReasion.Text = "";
        }

        private void SaveResion()
        {
            //string strName = "";
            string sList = "";
            for (int i = 0; i < treProductGroups.Nodes[0].Nodes.Count; i++)
            {
                if (treProductGroups.Nodes[0].Nodes[i].Checked)
                {

                    sList += sList != "" ? "," + treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString() : treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString();
                }
            }
            listProGroupTagNew += sList;

            FrmReporter.FrmReportSale.frmCreateReasion frm = new frmCreateReasion(translate);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            REPORT_CONDITIONS reCon = new REPORT_CONDITIONS();
            if (frm.Titlle != null)
            {
                reCon.CATEGORY = listProGroupTagNew;
                reCon.ACCOUNT = UserImformation.UserName;
                reCon.LIST_COLUMN = ListResionTagNew;
                reCon.AUTO_ID = Guid.NewGuid();
                reCon.TITLE = frm.Titlle;
                reCon.REPORT = "frmReportSale";
                reCon.LIST_GROUP = null;
                reCon.ATTRIBUTE = "";
                reCon.Save(true);

                //cboReasion.Text = frm.Titlle;
                MessageBox.Show(Properties.rsfPayment.CashPayment1.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        #region Event
        private void frmProductReportSearch_Load(object sender, EventArgs e)
        {
            LoadTreProductGroup();
            
            //LoadCheckList();
            LoadReasion(null);
        }

        private void treProductGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkNode(e.Node);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SaveResion();  
        }

        private void chkChooseAll_CheckedChanged(object sender, EventArgs e)
        {
            //CheckAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string s = "";
            //string str = "";
            //string strName = "";
            string sList = "";
            for (int i = 0; i < treProductGroups.Nodes[0].Nodes.Count; i++)
            {
                if (treProductGroups.Nodes[0].Nodes[i].Checked)
                {
                    s += s != "" ? "," + treProductGroups.Nodes[0].Nodes[i].Text.ToString() : treProductGroups.Nodes[0].Nodes[i].Text.ToString();
                    sList += sList != "" ? "," + treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString() : treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString();
                }        
            }
            listProGroupTag += sList;
            
            
            listProGroup += ":" + s;
            
            this.Close();
        }

        private void cboReasion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string id = cboReasion.SelectedText != null ? cboReasion.SelectedText.ToString() : "";
            DataRow row = ((DataRowView)cboReasion.SelectedItem).Row;
            id = row["AUTO_ID"].ToString();
            
            if (id != null && id != "")
            {
                
                ShowGroup(id);
                //CheckColumn(id);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCol_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string strName = "";
            string sList = "";
            for (int i = 0; i < treProductGroups.Nodes[0].Nodes.Count; i++)
            {
                if (treProductGroups.Nodes[0].Nodes[i].Checked)
                {

                    sList += sList != "" ? "," + treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString() : treProductGroups.Nodes[0].Nodes[i].Tag.ToString() + "||" + treProductGroups.Nodes[0].Nodes[i].Name.ToString();
                }
            }
            listProGroupTagNew += sList;

            //if (chkCol.CheckedItems.Count > 0)
            //{
            //    for (int i = 0; i < chkCol.CheckedItems.Count; i++)
            //    {

            //        strName += strName != "" ? "," + dtListCol.Rows[i]["ColumnName"].ToString() : dtListCol.Rows[i]["ColumnName"].ToString();
            //    }

            //    ListResionTagNew += strName;

            //}

            
            Guid guid = new Guid(id);

            REPORT_CONDITIONS reCon = new REPORT_CONDITIONS();
            reCon.CATEGORY = listProGroupTagNew;
            reCon.ACCOUNT = UserImformation.UserName;
            reCon.LIST_COLUMN = ListResionTagNew;
            reCon.AUTO_ID = guid;
            reCon.TITLE = cboReasion.Text.ToString();
            reCon.REPORT = "frmReportSale";
            reCon.LIST_GROUP = null;
            reCon.ATTRIBUTE = "";
            reCon.Save(false);
            MessageBox.Show(Properties.rsfPayment.CashPayment6.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            FrmReportSale.frmDeleteResion frmDe = new frmDeleteResion(translate);
            frmDe.StartPosition = FormStartPosition.CenterParent;
            frmDe.ShowDialog();
            LoadReasion(null);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data.SqlClient;
using SaleAD.SaleMTObjAdmin;


namespace SaleAD.FrmSystem
{
    public partial class FrmGroupUser : Form
    {
        private rdodb_KTSqlDAC sqlDac = new rdodb_KTSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string userDept = "";

        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        public FrmGroupUser(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }

        private void initLanguage()
        {
            this.tabUsers.Text = translate["FrmGroupUser.tabUsers.Text"];
            this.rbtGroupManagement.Text = translate["FrmGroupUser.rbtGroupManagement.Text"];
            this.rbtGroupStore.Text = translate["FrmGroupUser.rbtGroupStore.Text"];
            this.label5.Text = translate["FrmGroupUser.label5.Text"];
            this.btnUpdateStore.Text = translate["FrmGroupUser.btnUpdateStore.Text"];
            this.btnCloseTabUser.Text = translate["FrmGroupUser.btnCloseTabUser.Text"];
            this.btnChangePass.Text = translate["FrmGroupUser.btnChangePass.Text"];
            this.btnDeleteTabUser.Text = translate["FrmGroupUser.btnDeleteTabUser.Text"];
            this.btnInsertTabUser.Text = translate["FrmGroupUser.btnInsertTabUser.Text"];
            this.groupBox2.Text = translate["FrmGroupUser.groupBox2.Text"];
            this.columnHeader1.Text = translate["FrmGroupUser.columnHeader1.Text"];
            this.columnHeader2.Text = translate["FrmGroupUser.columnHeader2.Text"];
            this.groupBox1.Text = translate["FrmGroupUser.groupBox1.Text"];
            this.ACCOUNT.HeaderText = translate["FrmGroupUser.ACCOUNT.HeaderText"];
            this.Column2.HeaderText = translate["FrmGroupUser.Column2.HeaderText"];
            this.Column3.HeaderText = translate["FrmGroupUser.Column3.HeaderText"];
            this.Column4.HeaderText = translate["FrmGroupUser.Column4.HeaderText"];
            this.Column5.HeaderText = translate["FrmGroupUser.Column5.HeaderText"];
            this.Column6.HeaderText = translate["FrmGroupUser.Column6.HeaderText"];
            this.Column7.HeaderText = translate["FrmGroupUser.Column7.HeaderText"];
            this.btnStore.Text = translate["FrmGroupUser.btnStore.Text"];
            this.label9.Text = translate["FrmGroupUser.label9.Text"];
            this.label6.Text = translate["FrmGroupUser.label6.Text"];
            this.label7.Text = translate["FrmGroupUser.label7.Text"];
            this.label8.Text = translate["FrmGroupUser.label8.Text"];
            this.label4.Text = translate["FrmGroupUser.label4.Text"];
            this.label3.Text = translate["FrmGroupUser.label3.Text"];
            this.label2.Text = translate["FrmGroupUser.label2.Text"];
            this.label1.Text = translate["FrmGroupUser.label1.Text"];
            this.tabGroup.Text = translate["FrmGroupUser.tabGroup.Text"];
            this.btnClose.Text = translate["FrmGroupUser.btnClose.Text"];
            this.btnDelete.Text = translate["FrmGroupUser.btnDelete.Text"];
            this.btnSave.Text = translate["FrmGroupUser.btnSave.Text"];
            this.btnInsert.Text = translate["FrmGroupUser.btnInsert.Text"];
            this.label11.Text = translate["FrmGroupUser.label11.Text"];
            this.label10.Text = translate["FrmGroupUser.label10.Text"];
            this.tabPage3.Text = translate["FrmGroupUser.tabPage3.Text"];
            this.btnStoreTab3.Text = translate["FrmGroupUser.btnStoreTab3.Text"];
            this.label12.Text = translate["FrmGroupUser.label12.Text"];
            this.Text = translate["FrmGroupUser.Text"];
        }	


        #region Method

        private void LoadUserList()
        {
            string sql = "select * from users";
            DataSet ds = sqlDac.InlineSql_Execute(sql, null);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = ds.Tables[0];
        }
        private void LoadUserInfo(string acc)
        {
            
        }
        private void LoadUserDept(string acc)
        {
            lvwShop.Items.Clear();
            DataSet ds = sqlDac.InlineSql_Execute("select * from USER_DEPT where ACCOUNT = '" + acc + "'", null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string dept = dr["DEPT_CODE"].ToString();
                    userDept = dept;
                    string location = LoadUserLocation(dept);
                    ListViewItem lvItem = new ListViewItem(acc);
                    lvItem.SubItems.Add(location);
                    lvwShop.Items.Add(lvItem);
                }
            }
            for (int i = 0; i < lvwShop.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lvwShop.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                }
                else
                {
                    lvwShop.Items[i].BackColor = Color.White;
                }
            }
        }
        private string LoadUserLocation(string deptCode)
        {
            string location = "";
            int currentDept = int.Parse(deptCode);
            bool flag = true;
            List<DEPT> deptList = DEPT.ReadAll();
            while (flag)
            {
                foreach (DEPT dept in deptList)
                {
                    if (dept.DEPT_CODE == currentDept)
                    {
                        if (dept.DEPT_PARENT == null || dept.DEPT_PARENT <= 0)
                        {
                            location = dept.DEPT_NAME + location;
                            flag = false;
                        }
                        else
                        {
                            location = "-->" + dept.DEPT_NAME + location;
                            currentDept = (int)dept.DEPT_PARENT;
                        }
                        break;
                    }
                }
            }
            return location;                                
        }            

        #endregion

        #region Event

        private void FrmGroupUser_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }
        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    //DataGridViewCellStyle bgcolor = dgvInvoiceList.DefaultCellStyle.Clone();
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dgvUsers.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dgvUsers.DataSource as DataTable;
            dt.DefaultView.RowFilter = "ACCOUNT like '%" + txtSearchName.Text + "%'";
        }

        #endregion

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.RowCount > 0)
            {
                string acc = dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString();
                LoadUserInfo(acc);
                frmAddEditUser frmShow = new frmAddEditUser(acc);
                frmShow.StartPosition = FormStartPosition.CenterScreen;
                frmShow.ShowDialog();
                LoadUserList();
            }
        }

        private void btnDeleteTabUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string msg = translate["Msg.MustBeSelected"] + " '" + dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString() + "' ?";
                DialogResult dr = MessageBox.Show(msg, translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    SqlParameter[] sqlPara = new SqlParameter[] { rdodb_KTSqlDAC.newInParam("@ACCOUNT", dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString()) };
                    sqlDac.Execute("USERS_DeleteUser", sqlPara);
                    LoadUserList();                    
                }
            }
            else
            {
                MessageBox.Show(translate["Msg.MustBeSelected"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (dgvUsers.RowCount > 0)
            {
                frmChangePasswordUser frmShow = new frmChangePasswordUser(dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString(), translate);
                frmShow.StartPosition = FormStartPosition.CenterScreen;
                frmShow.ShowDialog();
            }
        }

        private void btnInsertTabUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmShow = new frmAddEditUser(translate);
            frmShow.StartPosition = FormStartPosition.CenterScreen;
            frmShow.ShowDialog();
            LoadUserList();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers != null && dgvUsers.RowCount > 0 && dgvUsers.SelectedRows.Count > 0)
            {                
                LoadUserDept(dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString());
            }
        }

        private void btnUpdateStore_Click(object sender, EventArgs e)
        {
            if (dgvUsers.RowCount > 0 && dgvUsers.SelectedRows.Count > 0 && userDept != "")
            {
                frmShopSelect frmShow = new frmShopSelect(userDept,dgvUsers.SelectedRows[0].Cells["ACCOUNT"].Value.ToString());
                frmShow.StartPosition = FormStartPosition.CenterScreen;
                frmShow.ShowDialog();
            }
        }
        
    }
}

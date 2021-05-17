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
    public partial class frmShopSelect : Form
    {
        private rdodb_KTSqlDAC sqlDac = new rdodb_KTSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string deptCode = "";
        string userName = "";

        public frmShopSelect(string userDept,string acc)
        {
            InitializeComponent();
            deptCode = userDept;
            userName = acc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Nodes.Count <= 0)
            {
                string deptChange = node.Tag.ToString();
                string sql = "update USER_DEPT set DEPT_CODE =" + deptChange.Trim() + " where ACCOUNT ='" + userName.Trim() + "'";
                sqlDac.InlineSql_ExecuteNonQuery(sql, null);
                
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShopSelect_Load(object sender, EventArgs e)
        {
            DataSet ds = sqlDac.InlineSql_Execute("Select dept_code, dept_name, dept_parent, zone_code from DEPT", null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["dept_parent"] == null || (int)dr["dept_parent"] <= 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = dr["dept_name"].ToString();
                        node.Tag = dr["dept_code"].ToString();
                        
                        LoadTreeNode(node, ds.Tables[0]);

                        treeView1.Nodes.Add(node);                        
                    }
                }
            }

            treeView1.SelectedNode = SearchTreeNode(treeView1.Nodes, deptCode);
        }

        private void LoadTreeNode(TreeNode node, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["dept_parent"].ToString() == node.Tag.ToString() && (dr["zone_code"] == null||dr["zone_code"].ToString()==""))
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dr["dept_name"].ToString();
                    childNode.Tag = dr["dept_code"].ToString();

                    node.Nodes.Add(childNode);
                    LoadTreeNode(childNode, dt);
                }
            }
        }

        private TreeNode SearchTreeNode(TreeNodeCollection nodes, string dept)
        {
            TreeNode foundNode = null;

            foreach (TreeNode node in nodes)
            {
                if (node.Tag.ToString() == dept)
                {
                    foundNode = node;
                }
                else
                {
                    TreeNode childNode = SearchTreeNode(node.Nodes, dept);
                    if (childNode != null)
                        foundNode = childNode;
                }
            }

            return foundNode;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Nodes.Count <= 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

    }
}

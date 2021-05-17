using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTBusiness;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;

namespace SaleMTInterfaces.FrmReporter
{
    public partial class frmEmployeeSearchReport : Form
    {
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        public frmEmployeeSearchReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxToChuc.Text = translate["frmEmployeeSearchReport.gbxToChuc.Text"];
            this.btnEmployeeSearch.Text = translate["frmEmployeeSearchReport.btnEmployeeSearch.Text"];
            this.gbxNhanVien.Text = translate["frmEmployeeSearchReport.gbxNhanVien.Text"];
            this.columnHeader1.Text = translate["frmEmployeeSearchReport.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmEmployeeSearchReport.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmEmployeeSearchReport.columnHeader3.Text"];
            this.groupBox3.Text = translate["frmEmployeeSearchReport.groupBox3.Text"];
            this.columnHeader4.Text = translate["frmEmployeeSearchReport.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmEmployeeSearchReport.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmEmployeeSearchReport.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmEmployeeSearchReport.columnHeader7.Text"];
            this.btnOK.Text = translate["frmEmployeeSearchReport.btnOK.Text"];
            this.btnCancel.Text = translate["frmEmployeeSearchReport.btnCancel.Text"];
            this.Text = translate["frmEmployeeSearchReport.Text"];


        }
        //Người tạo: hieppd - 04/10/2013: Hàm load dữ liệu vào treeview Tổ chức
        private void loadTreeview()
        {
            string proc = "treEmployee";
            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, null);
            //Tìm và tạo mới các node con mức 0 để add vào treeview và gọi đệ quy hàm tạo mới node con cho node mức 0
            foreach (DataRow drNow in dt.Rows)
            {
                if (Convert.ToInt32(drNow["dept_parent"]) == -1)
                {
                    TreeNode node = new TreeNode();
                    node.Text = drNow["dept_name"].ToString();
                    node.Tag = drNow["dept_code"].ToString();

                    //gọi hàm tạo mới node con cho node mức 0
                    newChildNode(node, dt);
                    treOrganization.Nodes.Add(node);
                }
            }
        }

        //Hàm tạo mới các node con cho một node
        void newChildNode(TreeNode nowNode, DataTable dt)
        { 
            //lấy ra detp_code của node hiện tại và tìm hết các node con của node hiện tại
            foreach (DataRow drNow in dt.Rows)
            {
                string idnowNode = nowNode.Tag.ToString();
                //Nếu node đang duyệt có dept_parent = dept_code của node hiện tại thì nó là con của lớp hiện tại
                if (drNow["dept_parent"].ToString() == idnowNode)
                { 
                    //Tạo node con
                    TreeNode childNode = new TreeNode();
                    childNode.Text = drNow["dept_name"].ToString();
                    childNode.Tag = drNow["dept_code"].ToString();
                    //add vào node hiện tại
                    nowNode.Nodes.Add(childNode);
                    //gọi đệ quy node con hiện tại
                    newChildNode(childNode, dt);
                    
                }
            }
        }

        private void frmEmployeeSearch_Load(object sender, EventArgs e)
        {
            loadTreeview();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}

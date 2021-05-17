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
    public partial class frmEmployeeSearch : Form
    {
        #region Const
        int pageSize = 15;
        int curPage = 1;
        int sCount = 0;
        #endregion

        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private string emCode;
        
        public string EmCode
        {
            get { return emCode; }
            set { emCode = value; }
        }
        #endregion

        #region Contructors
        public frmEmployeeSearch(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxToChuc.Text = translate["frmEmployeeSearch.gbxToChuc.Text"];
            this.btnEmployeeSearch.Text = translate["frmEmployeeSearch.btnEmployeeSearch.Text"];
            this.gbxNhanVien.Text = translate["frmEmployeeSearch.gbxNhanVien.Text"];
            this.lblPage.Text = translate["frmEmployeeSearch.lblPage.Text"];
            this.lblRowlist.Text = translate["frmEmployeeSearch.lblRowlist.Text"];
            this.columnHeader1.Text = translate["frmEmployeeSearch.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmEmployeeSearch.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmEmployeeSearch.columnHeader3.Text"];
            this.groupBox3.Text = translate["frmEmployeeSearch.groupBox3.Text"];
            this.columnHeader4.Text = translate["frmEmployeeSearch.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmEmployeeSearch.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmEmployeeSearch.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmEmployeeSearch.columnHeader7.Text"];
            this.btnOK.Text = translate["frmEmployeeSearch.btnOK.Text"];
            this.btnCancel.Text = translate["frmEmployeeSearch.btnCancel.Text"];
            this.tabPage1.Text = translate["frmEmployeeSearch.tabPage1.Text"];
            this.Text = translate["frmEmployeeSearch.Text"];
        }	

        #endregion

        #region Method/Function

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Load treeview
        /// + 
        /// 
        /// </summary>
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
                    //add node vao treeview
                    treOrganization.Nodes.Add(node);
                    treOrganization.ImageList = imgTreeview; 
                }
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Hàm tào mới các node con cho một node  
        /// </summary>
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
                    //storeName =storeName + "-->" + nowNode.Text.ToString() + "-->" + childNode.Text.ToString()+"-->";
                    //MessageBox.Show(storeName);
                }
            }

        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tìm kiếm nhân viên theo một deptcode trả về một datatable
        /// </summary>
        private DataTable searchEm(int deptCode)
        {
            DataTable dt = new DataTable();
            try
            {
                string proc = "EMPLOYEE_INFO_searchTreeview";
                
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", SqlDbType.Int, deptCode);
                dt = sqlDac.GetDataTable(proc, para);   
            }
                
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
            return dt;

        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tạo mảng chứa Id của các node  
        /// </summary>
        private void getidNode(TreeNode nodeNow, ArrayList arId)
        {
            try
            {
                //Neu node hien tai dc check thi add id vao mang
                if (nodeNow.Checked == true)
                {
                    arId.Add(nodeNow.Tag);
                }
                //goi ham lay id cua cac node con
                foreach (TreeNode childNode in nodeNow.Nodes)
                {
                    getidNode(childNode, arId);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tạo mới một datatable chứa tất cả các thông tin của nhân viên tìm được 
        /// </summary> 
        DataTable dtAllEm;
        //gộp tất cả table của 1 deptcode vào một datatable
        private void getData()
        {
            try
            {
                ArrayList arId = new ArrayList();
                //duyet va lay ra cac id cua node muc 0 tren treeview
                foreach (TreeNode node in treOrganization.Nodes)
                {
                    getidNode(node, arId);
                }
                //tao cau truc cua datatale all
                dtAllEm = new DataTable();
                DataColumn dc = new DataColumn("EMPLOYEE_ID");
                dtAllEm.Columns.Add(dc);
                dc = new DataColumn("DEPT_CODE");
                dtAllEm.Columns.Add(dc);
                dc = new DataColumn("FIRST_NAME");
                dtAllEm.Columns.Add(dc);
                dc = new DataColumn("LAST_NAME");
                dtAllEm.Columns.Add(dc);
                dc = new DataColumn("EVENT_ID");
                dtAllEm.Columns.Add(dc);

                //add du lieu vao bang dtAll dong thoi sap xep thu tu theo employee_id
                foreach (object objId in arId)
                {
                    int deptCode;
                    deptCode = Convert.ToInt32(objId);
                    DataTable dtTemp = searchEm(deptCode);
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        dtAllEm.Rows.Add(new object[] { dtTemp.Rows[i]["EMPLOYEE_ID"], dtTemp.Rows[i]["DEPT_CODE"], dtTemp.Rows[i]["FIRST_NAME"], dtTemp.Rows[i]["LAST_NAME"], dtTemp.Rows[i]["EVENT_ID"] });
                        DataView dv = dtAllEm.DefaultView;
                        dv.Sort = "EMPLOYEE_ID";
                        dtAllEm = dv.ToTable();
                    }
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Xử lý phân trang  
        /// </summary>
        private void DisplayCurPage(int curPage)
        {
            try
            {
                if (curPage > Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double)pageSize)))
                {
                    return ;
                }
                
                lvwEmployee.Items.Clear();
                int j = 0;
                if (dtAllEm.Rows.Count > 0)
                {
                    for (int i = (curPage - 1) * pageSize; i <= curPage * pageSize; i++)
                    {
                        if (i < dtAllEm.Rows.Count)
                        {
                            lvwEmployee.Items.Add(dtAllEm.Rows[i]["EMPLOYEE_ID"].ToString());
                            lvwEmployee.Items[j].SubItems.Add(dtAllEm.Rows[i]["FIRST_NAME"].ToString());
                            lvwEmployee.Items[j].SubItems.Add(dtAllEm.Rows[i]["LAST_NAME"].ToString());
                            lvwEmployee.Items[j].SubItems.Add(dtAllEm.Rows[i]["DEPT_CODE"].ToString());

                            if (j % 2 == 0)
                            {
                                lvwEmployee.Items[j].BackColor = Color.FromArgb(224, 223, 227);
                            }
                            j++;
                            
                        }
                    }    
                }

                sCount = dtAllEm.Rows.Count;
                lblRowlist.Text = "Tổng cộng:" + sCount.ToString();
                lblPage.Text = "{" + curPage.ToString() + "}" + "/" + "{" + Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double)pageSize)).ToString() + "}" + " trang";
                curPage++;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
    
        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Điều khiển sự hiển thị của các nút sau khi phân trang
        /// </summary>
        private void Reasion(int pageNum)
            {
                try
                {
                    if (pageNum != 0)
                    {
                        if (pageNum == 1)
                        {
                            btnBack.Enabled = false;
                            btnTopPage.Enabled = false;
                            btnNext.Enabled = true;
                            btnEndPage.Enabled = true;
                            return;
                        }

                        if (pageNum == Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (decimal)pageSize)))
                        {
                            btnEndPage.Enabled = false;
                            btnNext.Enabled = false;
                            btnBack.Enabled = true;
                            btnTopPage.Enabled = true;
                            return;
                        }
                        if (pageNum >= 1 && pageNum <= Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (decimal)pageSize)))
                        {
                            btnNext.Enabled = true;
                            btnEndPage.Enabled = true;
                            btnBack.Enabled = true;
                            btnTopPage.Enabled = true;
                            return;
                        }
                    }
                    else

                        return;
                }
                catch (Exception ex)
                {
                    log.Error("Error: " + ex.Message);
                }
            }
           
        //Gan thuoc tinh check cho cac node trong treeview

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Hàm xử lý sự kiện khi check vào một node bất kỳ trên treeview 
        /// </summary>
        private void checkNode(TreeNode nodeNow)
        { 
            foreach(TreeNode childNode in nodeNow.Nodes)
            {
                childNode.Checked = nodeNow.Checked;
                checkNode(childNode);
            }
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Chọn nhân viên
        /// </summary>
        private void ChooseEm()
        {
            try
            {
                ListView.SelectedListViewItemCollection list = lvwEmployee.SelectedItems;
                foreach (ListViewItem item in list)
                {
                    //Lấy giá trị của deptcode truyền vào hàm lấy ra chuỗi cửa hàng
                    int deptcode = Convert.ToInt32(item.SubItems[3].Text);

                    //Add thông tin được chọn vào listview employeechoose
                    ListViewItem itemChoose = new ListViewItem(item.SubItems[0].Text);
                    itemChoose.SubItems.Add(item.SubItems[1].Text);
                    itemChoose.SubItems.Add(item.SubItems[2].Text);
                    itemChoose.SubItems.Add(GetPlaceCreate(deptcode));
                    lvwEmployeeChoose.Items.Add(itemChoose);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        //lay chuoi cua hang
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

        #region Event
        //Load form tim kiem nhan vien
        private void frmEmployeeSearch_Load(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(storeName);
                loadTreeview();
                if (lvwEmployee.Items.Count == 0)
                {
                    lblPage.Text = "{1}/{1}" + " trang";
                    lblRowlist.Text = "Tổng cộng:" + "  0";
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
                
        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getData();
                DisplayCurPage(1);
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        
        //bat su kien sau khi check
        private void treOrganization_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkNode(e.Node);
        }

                
        //Xử lý nút down: add dữ liệu từ lsvEmployee xuống lvwEmployeeChoose
        private void btnDown_Click(object sender, EventArgs e)
        {
            ChooseEm();    
        }
        
        //Bắt sự kiện selectedchange
        string iList = "";
        private void lvwEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            iList = lvwEmployee.FocusedItem.Text;
            ListViewItem Item = lvwEmployee.FocusedItem;
        }

        //Su kien next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            Reasion(curPage+1);
            DisplayCurPage(curPage+1);
            curPage++;
        }

        //su kien ve dau trang
        private void btnTopPage_Click(object sender, EventArgs e)
        {
            curPage = 1;
            Reasion(curPage);
            DisplayCurPage(curPage);
        }

        //Su kien back lai trang truoc
        private void btnBack_Click(object sender, EventArgs e)
        {
            Reasion(curPage-1);
            DisplayCurPage(curPage - 1);
            curPage--;
        }

        //Bat su kien nut tro ve trang cuoi
        private void btnEndPage_Click(object sender, EventArgs e)
        {
            curPage = Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize));
            Reasion(curPage);
            DisplayCurPage(curPage);
        }

        //Bat su kien nut Huy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwEmployeeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        #endregion

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Sự kiện click nút OK 
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast = lvwEmployee.SelectedItems;
            this.EmCode = breakfast[0].SubItems[0].Text;
            this.Close();
        }
        
        //Click đúp vào một dòng trên listview
        private void lvwEmployee_DoubleClick(object sender, EventArgs e)
        {
            ChooseEm();
        }

        private void lvwEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChooseEm();
            }
        }
        #endregion

        

        
    }
}





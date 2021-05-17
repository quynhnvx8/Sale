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

namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    public partial class frmEmployeeSearchSale : Form
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
        //private ListViewColumnSorter lvwColumnSorter;

        public string EmCode
        {
            get { return emCode; }
            set { emCode = value; }
        }
        #endregion

        #region Contructors
        public frmEmployeeSearchSale(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.gbxToChuc.Text = translate["frmEmployeeSearchSale.gbxToChuc.Text"];
            this.btnEmployeeSearch.Text = translate["frmEmployeeSearchSale.btnEmployeeSearch.Text"];
            this.gbxNhanVien.Text = translate["frmEmployeeSearchSale.gbxNhanVien.Text"];
            this.lblPage.Text = translate["frmEmployeeSearchSale.lblPage.Text"];
            this.lblRowlist.Text = translate["frmEmployeeSearchSale.lblRowlist.Text"];
            this.columnHeader1.Text = translate["frmEmployeeSearchSale.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmEmployeeSearchSale.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmEmployeeSearchSale.columnHeader3.Text"];
            this.groupBox3.Text = translate["frmEmployeeSearchSale.groupBox3.Text"];
            this.columnHeader4.Text = translate["frmEmployeeSearchSale.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmEmployeeSearchSale.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmEmployeeSearchSale.columnHeader6.Text"];
            this.columnHeader7.Text = translate["frmEmployeeSearchSale.columnHeader7.Text"];
            this.btnOK.Text = translate["frmEmployeeSearchSale.btnOK.Text"];
            this.btnCancel.Text = translate["frmEmployeeSearchSale.btnCancel.Text"];
            this.tabPage1.Text = translate["frmEmployeeSearchSale.tabPage1.Text"];
            this.Text = translate["frmEmployeeSearchSale.Text"];

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
                    this.treOrganization.Nodes.Add(childNode[0]);
                    this.treOrganization.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreShop': " + ex.Message);
            }


        }


        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tìm kiếm nhân viên theo một deptcode trả về một datatable
        /// </summary>
        private DataTable searchEm(int deptCode)
        {
           
                string proc = "EMPLOYEE_INFO_searchTreeview";
                DataTable dt = new DataTable();
                SqlParameter[] para;
                para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@DEPT_CODE", SqlDbType.Int, deptCode);
                dt = sqlDac.GetDataTable(proc, para);
                return dt;

                //lvwEmployee.Items.Clear();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    lvwEmployee.Items.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());
                //    lvwEmployee.Items[i].SubItems.Add(dt.Rows[i]["LAST_NAME"].ToString());
                //    lvwEmployee.Items[i].SubItems.Add(dt.Rows[i]["FIRST_NAME"].ToString());
                //}   
        }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tạo mảng chứa Id của các node  
        /// </summary>
        private void getidNode(TreeNode nodeNow, ArrayList arId)
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

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Tạo mới một datatable chứa tất cả các thông tin của nhân viên tìm được 
        /// </summary> 
        DataTable dtAllEm;
        //gộp tất cả table của 1 deptcode vào một datatable
        private void getData()
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

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Xử lý phân trang  
        /// </summary>
        

        void DisplayCurPage(int curPage)
            {
                if (curPage > Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double) pageSize)))
                {
                    return;    
                }
                lvwEmployee.Items.Clear();
                int j = 0;
                
                for (int i = (curPage - 1) * pageSize; i <= curPage * pageSize; i++)
                {
                    if (i < dtAllEm.Rows.Count && i > 0)
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
                    //btnTopPage.Enabled = (curPage > 1);
                    //btnEndPage.Enabled = (curPage > 1);
                    //btnNext.Enabled = (curPage < Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double)pageSize)));
                    //btnBack.Enabled = (curPage < Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double)pageSize)));
                    
                }

                sCount = dtAllEm.Rows.Count;
                lblRowlist.Text = "Tổng cộng:" + sCount.ToString();
                //curPage ++;
                lblPage.Text = "{"+curPage.ToString()+"}" + "/" + "{"+Convert.ToInt32(Math.Ceiling(dtAllEm.Rows.Count / (double)pageSize)).ToString()+"}" + " trang";
                curPage++;
                
            }

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Điều khiển sự hiển thị của các nút sau khi phân trang
        /// </summary>
        private void Reasion(int pageNum)
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
            //MessageBox.Show(storeName);
            LoadTreShop();
            treOrganization.Enabled = false;
            if (lvwEmployee.Items.Count == 0)
            {
                lblPage.Text = "{0}/{1}" + " trang";
                lblRowlist.Text = "Tổng cộng:" + "  0";
            }

        }
        #endregion

        
        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
           
            getData();
            DisplayCurPage(1);
            //MessageBox.Show(storeName);
        }
        
        //bat su kien sau khi check
        private void treOrganization_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkNode(e.Node);
        }

        //Ham lay du lieu tu cac not bat ky tren treeview sang listview 
        private void getDataChoose()
        {
            string proc = "EMPLOYEE_INFO_chooseEmployee";
            SqlParameter[] para;
            para = new SqlParameter[1];
            para[0] = posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", SqlDbType.VarChar, iList);
            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, para);

            lvwEmployeeChoose.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvwEmployeeChoose.Items.Add(dt.Rows[i]["EMPLOYEE_ID"].ToString());
                lvwEmployeeChoose.Items[i].SubItems.Add(dt.Rows[i]["FIRST_NAME"].ToString());
                lvwEmployeeChoose.Items[i].SubItems.Add(dt.Rows[i]["LAST_NAME"].ToString());    
            }
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
            Reasion(1);
            DisplayCurPage(1);
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
            Reasion(Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize)));
            DisplayCurPage(Convert.ToInt32(Math.Ceiling(sCount / (double)pageSize)));
        }

        //Bat su kien nut Huy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwEmployeeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListView.SelectedListViewItemCollection breakfast = lvwEmployeeChoose.SelectedItems;
            //foreach (ListViewItem item in breakfast)
            //{

            //    ChooseEm();
            //}
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

        /// <summary>
        /// Người tạo Hieppd – 10/10/2013 : Sự kiện ColumnClick: Sắp xếp một cột bất kỳ trên listview theo thứ tự tăng hoặc giảm  
        /// </summary>
        private void lvwEmployee_ColumnClick(object sender, ColumnClickEventArgs e)
        {
           
        }

    }
}

/// <summary>
///  
/// 
///  
/// </summary>




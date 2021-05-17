using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTInterfaces.SaleMTTabForm;
using SaleMTBusiness.SaleManagement;
using SaleMTDataAccessLayer.SaleMTObj;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using SaleMTInterfaces;
using SaleMTBusiness.CustomerManagement;
using System.Data.SqlClient;

namespace SaleMTInterfaces.FrmSaleManagement
{
    public partial class frmReturnItems : TabForm
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();        
        private List<CUSTOMERS> listCus = new List<CUSTOMERS>();
        private bool[] status;
        private const int TYPE_CODE_INVENT = 8;

        private bool checkPrint = false;
        private bool checkInsert = false;
        private bool checkUpdate = false;
        private bool checkDelete = false;

        #endregion

        #region Contructor
        public frmReturnItems(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        private void initLanguage()
        {
            this.groupBox5.Text = translate["frmReturnItems.groupBox5.Text"];
            this.label11.Text = translate["frmReturnItems.label11.Text"];
            this.label10.Text = translate["frmReturnItems.label10.Text"];
            this.label9.Text = translate["frmReturnItems.label9.Text"];
            this.groupBox4.Text = translate["frmReturnItems.groupBox4.Text"];
            this.clnDetailsCode.HeaderText = translate["frmReturnItems.clnDetailsCode.HeaderText"];
            this.clnMASTER_CODE.HeaderText = translate["frmReturnItems.clnMASTER_CODE.HeaderText"];
            this.clnREASON.HeaderText = translate["frmReturnItems.clnREASON.HeaderText"];
            this.clnProductCode.HeaderText = translate["frmReturnItems.clnProductCode.HeaderText"];
            this.clnProductName.HeaderText = translate["frmReturnItems.clnProductName.HeaderText"];
            this.clnQuantity.HeaderText = translate["frmReturnItems.clnQuantity.HeaderText"];
            this.clnReturnMoney.HeaderText = translate["frmReturnItems.clnReturnMoney.HeaderText"];
            this.groupBox3.Text = translate["frmReturnItems.groupBox3.Text"];
            this.columnHeader4.Text = translate["frmReturnItems.columnHeader4.Text"];
            this.columnHeader5.Text = translate["frmReturnItems.columnHeader5.Text"];
            this.columnHeader6.Text = translate["frmReturnItems.columnHeader6.Text"];
            this.groupBox1.Text = translate["frmReturnItems.groupBox1.Text"];
            this.columnHeader1.Text = translate["frmReturnItems.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmReturnItems.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmReturnItems.columnHeader3.Text"];
            this.gbxTim.Text = translate["frmReturnItems.gbxTim.Text"];
            this.btnCustomerSearch.Text = translate["frmReturnItems.btnCustomerSearch.Text"];
            this.label1.Text = translate["frmReturnItems.label1.Text"];
            this.label8.Text = translate["frmReturnItems.label8.Text"];
            this.label7.Text = translate["frmReturnItems.label7.Text"];
            this.label6.Text = translate["frmReturnItems.label6.Text"];
            this.label5.Text = translate["frmReturnItems.label5.Text"];
            this.label4.Text = translate["frmReturnItems.label4.Text"];
            this.label3.Text = translate["frmReturnItems.label3.Text"];
            this.label2.Text = translate["frmReturnItems.label2.Text"];
            this.Text = translate["frmReturnItems.Text"];
        }	

        #endregion

        #region mothod/function
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Clear các control .
        /// </summary>
        private void ResetControl()
        {
            try
            {
                if (dgvItemReturnDetails.Rows.Count > 0)
                {
                    for (int i = dgvItemReturnDetails.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!dgvItemReturnDetails.Rows[i].IsNewRow)
                        {
                            dgvItemReturnDetails.Rows.RemoveAt(i);
                        }
                    }
                }
                if(lvwDelivery.Items.Count <= 0)
                    lvwDelivery.View = View.LargeIcon;
                if(dgvItemReturnDetails.Rows.Count <= 0)
                    dgvItemReturnDetails.ColumnHeadersVisible = false;

                txtCashReturn.Text = "0";
                rtfFeedback.Text = "";
                txtReason.Text = "";
            }
            catch (Exception ex)
            {
                log.Error("Error 'ResetControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán giá trị thông tin khách hàng vào các control .
        /// </summary>
        private void SetValueControlText(CUSTOMERS cus)
        {
            try
            {
                txtCustomerCode.Text = cus.CUSTOMER_ID;
                txtCustomerName.Text = cus.LAST_NAME + " " + cus.FIRST_NAME;
                txtDateOfBirth.Text = (cus.DATE_OF_BIRTH != null) ? cus.DATE_OF_BIRTH.Value.ToString(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate) : "";
                txtIdentityCard.Text = cus.ID_NO;
                txtPhoneNumber.Text = cus.MOBILE_PHONE;
                txtEmail.Text = cus.EMAIL_ADDRESS;
                int deptCode = (cus.DEPT_CODE.HasValue) ? cus.DEPT_CODE.Value : 0;
                txtPlaces.Text = ReturnItem.GetPlaceCreate(deptCode, sqlDac);
            }
            catch (Exception ex)
            {
                log.Error("Error 'SetValueControlText': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán danh sách các đợt trả hàng của khách hàng đã chọn .
        /// </summary>
        private void BindItemReturn(CUSTOMERS cus)
        {
            try
            {
                //bind vào lưới danh sách các đợt trả hàng
                DataTable dtReturn = ReturnItem.FindItemReturn(cus.CUSTOMER_ID, sqlDac);
                lvwDelivery.Items.Clear();                
                if (dtReturn.Rows.Count > 0)
                {
                    for (int i = 0; i < dtReturn.Rows.Count; i++)
                    {
                        lvwDelivery.Items.Add(dtReturn.Rows[i]["RETURN_CODE"].ToString());
                        lvwDelivery.Items[i].SubItems.Add(dtReturn.Rows[i]["RETURN_DATE"].ToString());
                        lvwDelivery.Items[i].SubItems.Add(dtReturn.Rows[i]["INVOICE_CODE"].ToString());
                        lvwDelivery.Items[i].SubItems.Add(dtReturn.Rows[i]["PRICE_ITEM_RETURN"].ToString());
                        lvwDelivery.Items[i].SubItems.Add(dtReturn.Rows[i]["TRANSFER_SHIFT_CODE"].ToString());
                        if (i % 2 == 0)
                        {
                            lvwDelivery.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                        }
                    }
                    lvwDelivery.Items[0].Selected = true;
                    lvwDelivery.Focus();
                    lvwDelivery.View = View.Details;
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindItemReturn': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán chi tiết các sản phẩm trả lại theo đợt trả hàng đã chọn .
        /// </summary>
        private void BindDetailsItemReturn()
        {
            try
            {
                ResetControl();
                ListView.SelectedListViewItemCollection breakfast = lvwDelivery.SelectedItems;
                if (breakfast.Count > 0)
                {
                    ListViewItem item = breakfast[0];
                    SetMenu();
                    string returnCode = item.SubItems[0].Text.Trim();
                    DataTable dtDetails = ReturnItem.FindDetailsItemReturn(returnCode, sqlDac);
                    if (dtDetails.Rows.Count > 0)
                    {
                        dgvItemReturnDetails.AutoGenerateColumns = false;
                        dgvItemReturnDetails.DataSource = dtDetails;
                        txtReason.Text = dtDetails.Rows[0]["MASTER_NAME"].ToString();
                        rtfFeedback.Text = dtDetails.Rows[0]["REASON"].ToString();
                        txtCashReturn.Text = Conversion.GetCurrency(item.SubItems[3].Text.ToString());
                    }
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindItemReturn': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load dữ liệu theo khách hàng .
        /// </summary>
        private void LoadData(CUSTOMERS cus)
        {
            try
            {
                SetValueControlText(cus);
                //thêm khách hàng vào lưới
                bool check = true;
                for (int i = 0; i < listCus.Count; i++)
                {
                    if (listCus[i].CUSTOMER_ID == cus.CUSTOMER_ID)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    //thêm vào list<T>
                    listCus.Add(cus);
                    // thêm vào listview
                    int count = lvwCustomer.Items.Count;
                    lvwCustomer.Items.Add(cus.CUSTOMER_ID);
                    lvwCustomer.Items[count].SubItems.Add(cus.LAST_NAME);
                    lvwCustomer.Items[count].SubItems.Add(cus.FIRST_NAME);
                    lvwCustomer.Items[count].Selected = true;
                    if (count % 2 == 0)
                    {
                        lvwCustomer.Items[count].BackColor = Color.FromArgb(224, 223, 227);
                    }
                    
                }
                //hiện header cho listview và datagridview
                lvwDelivery.View = View.Details;
                dgvItemReturnDetails.ColumnHeadersVisible = true;
                
            }
            catch (Exception ex)
            {
                log.Error("Error 'BindToControl': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load chi tiết dữ liệu trả hàng theo khách hàng .
        /// </summary>
        private void LoadDetailsData()
        {
            try
            {
                // Load orders details of a orders.
                ListView.SelectedListViewItemCollection breakfast = lvwCustomer.SelectedItems;
                if (breakfast.Count > 0)
                {
                    ListViewItem item = breakfast[0];
                    string cusCode = item.SubItems[0].Text;
                    for (int i = 0; i < listCus.Count; i++)
                    {
                        if (listCus[i].CUSTOMER_ID == cusCode)
                        {
                            CUSTOMERS cus = new CUSTOMERS();
                            cus = listCus[i];
                            //Set value thông tin khách hàng.
                            SetValueControlText(cus);
                            //bind vào lưới danh sách các đợt trả hàng.
                            BindItemReturn(cus);
                            //bind chi tiết trả hàng.
                            BindDetailsItemReturn();
                            break;
                        }
                    }
                    //hiện header cho listview và datagridview
                    lvwDelivery.View = View.Details;
                    dgvItemReturnDetails.ColumnHeadersVisible = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadDetailsData': " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Set menu điều khiển tại form main .
        /// </summary>
        private void SetMenu()
        {
            try
            {
                frmSaleMTMain parMain = (frmSaleMTMain)this.MdiParent;
                bool edit = (lvwDelivery.SelectedItems.Count > 0) ? true : false;
                bool delete = (lvwDelivery.SelectedItems.Count > 0) ? true : false;
                bool print = (lvwDelivery.SelectedItems.Count > 0) ? true : false;
                bool[] active = { true, false, edit, false, delete, print, false, false, true, false, true, true };
                parMain.ActiveMenu(active);
                status = active;
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        
        #endregion

        #region Event

        #region menu event
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click thêm mới .
        /// </summary>
        private void frmReturnItems_evAddNew(object sender, EventArgs e)
        {
            try
            {
                if (checkInsert)
                {
                    SetMenu();
                    if (lvwCustomer.Items.Count > 0)
                    {
                        ListView.SelectedListViewItemCollection breakfast = lvwCustomer.SelectedItems;
                        if (breakfast.Count > 0)
                        {
                            ListViewItem item = breakfast[0];
                            string cusCode = item.SubItems[0].Text;
                            if (cusCode != null && cusCode != "")
                            {
                                frmDialogReturnItemAdd dialogAdd = new frmDialogReturnItemAdd(translate);
                                dialogAdd.CusCode = cusCode;
                                dialogAdd.AddOrEdit = true;
                                dialogAdd.StartPosition = FormStartPosition.CenterScreen;
                                dialogAdd.ShowDialog();
                                if (dialogAdd.Added)
                                {
                                    LoadDetailsData();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng chọn khách hàng.", Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.rsfSales.ItemReturn.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click sửa dữ liệu đã chọn .
        /// </summary>
        private void frmReturnItems_evEdit(object sender, EventArgs e)
        {
            try
            {
                if (checkUpdate)
                {
                    ListView.SelectedListViewItemCollection breakfast = lvwDelivery.SelectedItems;
                    if (breakfast.Count > 0)
                    {
                        //
                        ListViewItem item = breakfast[0];
                        string cusCode = item.SubItems[0].Text;
                        if (item.SubItems[4].Text.Trim() == UserImformation.ShiftCode)
                        {
                            // set value entities
                            ReturnItemEntities returnItemEn = new ReturnItemEntities();
                            returnItemEn.DtProduct = (DataTable)dgvItemReturnDetails.DataSource;
                            returnItemEn.ItemReturnCode = item.SubItems[0].Text;
                            returnItemEn.BillCode = item.SubItems[2].Text;
                            returnItemEn.TotalMoneyReturn = item.SubItems[3].Text;
                            //bật dialog
                            frmDialogReturnItemAdd dialogAdd = new frmDialogReturnItemAdd(translate);
                            dialogAdd.AddOrEdit = false;
                            dialogAdd.ReturnItemEn = returnItemEn;
                            dialogAdd.StartPosition = FormStartPosition.CenterScreen;
                            dialogAdd.ShowDialog();
                            if (dialogAdd.Added)
                            {
                                lvwDelivery.Items[0].Selected = true;
                                LoadDetailsData();
                            }
                        }
                        else
                        {
                            MessageBox.Show(Properties.rsfSales.ItemReturn4, Properties.rsfSales.Notice, MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        SetMenu();
                        MessageBox.Show(Properties.rsfSales.ItemReturn.ToString(), Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click xóa dữ liệu đã chọn .
        /// </summary>
        private void frmReturnItems_evDelete(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete)
                {
                    DialogResult re = MessageBox.Show(Properties.rsfSales.ItemReturn5, Properties.rsfSales.Notice, MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (re == DialogResult.Yes)
                    {
                        ListView.SelectedListViewItemCollection breakfast = lvwDelivery.SelectedItems;
                        if (breakfast.Count > 0)
                        {
                            // xóa đơn trả hàng
                            ITEM_RETURN item = new ITEM_RETURN();
                            string returnCode = breakfast[0].SubItems[0].Text;
                            item.RETURN_CODE = returnCode;
                            item.Delete();
                            //xóa chi tiết đơn trả hàng và inventory
                            foreach (DataGridViewRow r in dgvItemReturnDetails.Rows)
                            {
                                // xóa chi tiết đơn trả hàng
                                string itemDetailsCode = (r.Cells["clnDetailsCode"].Value != null) ? r.Cells["clnDetailsCode"].Value.ToString().Trim() : "";
                                ITEM_RETURN_DETAIL itemDetails = new ITEM_RETURN_DETAIL();
                                itemDetails.ITEM_RETURN_DETAIL_CODE = itemDetailsCode;
                                itemDetails.Delete();
                                // xóa inventory
                                string proId = (r.Cells["clnProductCode"].Value != null) ? r.Cells["clnProductCode"].Value.ToString().Trim() : "";
                                DataTable dtInvent = ReturnItem.GetInventory(proId, returnCode, TYPE_CODE_INVENT, sqlDac);
                                if (dtInvent.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtInvent.Rows.Count; i++)
                                    {
                                        INVENTORY_TEMP invent = new INVENTORY_TEMP();
                                        invent.INVENTORY_ID = (Guid)dtInvent.Rows[i]["INVENTORY_ID"];
                                        invent.Delete();
                                    }
                                }
                            }
                            //xóa sale_export âm
                            SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@RETURN_CODE", returnCode) };
                            sqlDac.Execute("SALES_EXPORTS_ITEMS_DeleteByReturnCode", para);
                            // xóa dòng dữ liệu trên list view
                            lvwDelivery.Items.Remove(breakfast[0]);
                        }
                        if (lvwDelivery.Items.Count > 0)
                        {
                            lvwDelivery.Items[0].Selected = true;
                            txtCustomerSearch.Focus();
                            LoadDetailsData();
                        }
                        else
                        {
                            ResetControl();
                            SetMenu();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click print hóa đơn trả hàng .
        /// </summary>
        private void frmReturnItems_evPrint(object sender, EventArgs e)
        {
            
            try
            {
                ListView.SelectedListViewItemCollection breakfast = lvwDelivery.SelectedItems;
                if (breakfast.Count > 0)
                {
                    ListViewItem item = breakfast[0];
                    string returnCode = item.SubItems[0].Text;
                    ReturnItem.PrintItemReturn(sqlDac, returnCode);
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Mở popup tìm kiếm khách hàng nâng cao .
        /// </summary>
        private void frmReturnItems_evSearch(object sender, EventArgs e)
        {
            try
            {
                frmCustomerSearch frmcus = new frmCustomerSearch(translate);
                frmcus.StartPosition = FormStartPosition.CenterScreen;
                frmcus.ShowDialog();
                if (frmcus.Customer != null)
                {
                    LoadData(frmcus.Customer);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion

        #region control event
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Actived form .
        /// </summary>
        private void frmReturnItems_Activated(object sender, EventArgs e)
        {
            try
            {
                //SetMenu();
                if (status != null && status.Length == 12)
                {
                    frmSaleMTMain main = (frmSaleMTMain)(this.MdiParent);
                    main.ActiveMenu(status);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Load form .
        /// </summary>
        private void frmReturnItems_Load(object sender, EventArgs e)
        {
            try
            {
                //log.Debug("Notice: Form started.");
                listCus.Clear();                
                lvwDelivery.View = View.LargeIcon;
                dgvItemReturnDetails.ColumnHeadersVisible = false;

                //Check quyền
                string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReturnsProduct' ";
                DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkInsert = checkInsert == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_INSERT"].ToString()) : checkInsert;
                        checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        checkUpdate = checkUpdate == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_UPDATE"].ToString()) : checkUpdate;
                        checkDelete = checkDelete == false ? bool.Parse(ds.Tables[0].Rows[0]["PER_DELETE"].ToString()) : checkDelete;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện click tìm kiếm khách hàng .
        /// </summary>
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CUSTOMERS cus = new CUSTOMERS();
                int dept = (chkSearchAll.Checked) ? 0 : UserImformation.DeptNumber;
                cus = CustomerManager.SearchCustomer(txtCustomerSearch.Text.Trim(), dept, sqlDac, translate);
                if (cus != null)
                {
                    LoadData(cus);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }

        }
        /// <summary>
        /// Người tạo Luannv – 27/10/2013 : Enter tìm kiếm khách hàng.
        /// </summary>
        private void txtCustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    CUSTOMERS cus = new CUSTOMERS();
                    int dept = (chkSearchAll.Checked) ? 0 : UserImformation.DeptNumber;
                    cus = CustomerManager.SearchCustomer(txtCustomerSearch.Text.Trim(), dept, sqlDac, translate);
                    if (cus != null)
                    {
                        LoadData(cus);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện thay đổi lựa chọn khách hàng .
        /// </summary>
        private void lvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDetailsData();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện thay đổi lựa chọn các đợt trả hàng .
        /// </summary>
        private void lvwDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                BindDetailsItemReturn();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }        
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Sự kiện đóng form hoàn thành ghi vào file log.
        /// </summary>
        private void frmReturnItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            //log.Debug("Notice: form closed.");
        }
        #endregion

        private void dgvItemReturnDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {               
                dgvItemReturnDetails.ColumnHeadersVisible = (dgvItemReturnDetails.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        

        
       
        #endregion

        

        
    }
}

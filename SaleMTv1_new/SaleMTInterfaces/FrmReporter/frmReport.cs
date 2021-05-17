using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using  Connection;
using SaleMTDataAccessLayer.SaleMTDAL ;
using SaleMTCommon;


namespace SaleMTInterfaces.FrmReporter
{
    public partial class frmReport : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        bool checkPrint = false;
        #endregion
        #region Contructor

        public frmReport(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.btnOpen.Text = translate["frmReport.btnOpen.Text"];
            this.btnClose.Text = translate["frmReport.btnClose.Text"];
            this.Text = translate["frmReport.Text"];

        }
        #endregion
        //int idBaoCao;
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();

        //static string strconn = @"Server=192.168.1.90,1444; database=posdb_vnmabc; User ID=sa; Pwd=123; Connect Timeout=100;";
        private string str = "";
        private DataRow od;

                //SqlConnection conn = new SqlConnection(strconn);

        DataSet ds = new DataSet();

        private void CaseReport(string reportId)
        { 
            try
            {
                if (reportId == "frmSalesReportSale")//Báo cáo bán hàng
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmReportSale frm = new FrmReporter.FrmReportSale.frmReportSale(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmSalesReportByCustomerSale")
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesReportByCustomer' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmSalesReportByCustomerSale frm = new FrmReporter.FrmReportSale.frmSalesReportByCustomerSale(translate);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                //Hệ thống báo cáo 04
                else if (reportId == "rptImportProductsSale")//04.01
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReportImport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmReportProductsSale frm = new FrmReporter.FrmReportSale.frmReportProductsSale(translate);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "rptExportProductsStoreSale")//04.02
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReportExport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.rptExportProductsStoreSale frm = new FrmReporter.FrmReportSale.rptExportProductsStoreSale(translate);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmInventoryReportSale")//04.03
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmInventoryReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmInventoryReportSale frm = new FrmReporter.FrmReportSale.frmInventoryReportSale(translate);
                        
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmEntryInventoryProductReportSale")//04.04
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmEntryInventoryProduct_Sale' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmEntryInventoryProductReportSale frm = new FrmReporter.FrmReportSale.frmEntryInventoryProductReportSale(translate);
                        
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmSalePROMOTIONGIFTS")//04.05
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalePromotionGift' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmSalePromotionGifts frm = new FrmReporter.FrmReportSale.frmSalePromotionGifts(translate);
                        
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmCompareImportProductReport")//04.06
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReportImport_Compare' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmCompareImportProductReport frm = new FrmReporter.FrmReportSale.frmCompareImportProductReport(translate);
                        
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmLiablityReport")//05.01
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmReportProducts_Zone' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportDiscount.frmLiablityReport frm = new FrmReporter.FrmReportDiscount.frmLiablityReport(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmSalesExportSearchReportByCat")//06.03
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesExportByDate_ByCat' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmSalesExportSearchReportByCat frm = new FrmReporter.FrmReportSale.frmSalesExportSearchReportByCat(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmCustomerListSearchByNoExportCode")//06.07
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmSalesExportByDate_NoExport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmCustomerListSearchByNoExportCode frm = new FrmReporter.FrmReportSale.frmCustomerListSearchByNoExportCode(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                // báo cáo hàng trả lại
                else if (reportId == "frmItemReturnReport")//Báo cáo bán hàng
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmItemReturnDateReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmItemReturnReport frm = new FrmReporter.FrmReportSale.frmItemReturnReport(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                // báo cáo thu chi
                else if (reportId == "CashReport")//Báo cáo bán hàng
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCashReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmCashReport frm = new FrmReporter.FrmReportSale.frmCashReport(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (((DataRow)od)["Report_Id"].ToString() == "frmInvoicher")//06.07
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmVoucherReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmInvoicher frm = new FrmReporter.FrmReportSale.frmInvoicher(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (((DataRow)od)["Report_Id"].ToString() == "frmInvoicherManagement")//06.07
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmWarrantyReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }

                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmInvoicherManagement frm = new FrmReporter.FrmReportSale.frmInvoicherManagement(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (((DataRow)od)["Report_Id"].ToString() == "frmListCustomerReport")//06.07
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCustomersListReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportSale.frmListCustomerReport frm = new FrmReporter.FrmReportSale.frmListCustomerReport(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                // Hệ thống báo cáo 3.0
                else if (reportId == "frmVoucherStatus")//3.02 Tình trạng phiếu tặng
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "')";//and IDRESOURCE = '' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportDiscount.frmVoucherStatus frm = new FrmReporter.FrmReportDiscount.frmVoucherStatus(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());

                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }
                else if (reportId == "frmCouponStatus")//3.04 Tình trạng phiếu giảm giá
                {
                    checkPrint = false;
                    string strQuery = "select * from PERMISSIONS where IDRole in (select IDROLE from MEMBERS where ACCOUNT ='" + UserImformation.UserName + "') and IDRESOURCE = 'frmCouponsReport' ";
                    DataSet ds = sqlDac.InlineSql_Execute(strQuery, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            checkPrint = checkPrint == false ? bool.Parse(ds.Tables[0].Rows[i]["PER_PRINT"].ToString()) : checkPrint;
                        }
                    }
                    if (checkPrint)
                    {
                        FrmReporter.FrmReportDiscount.frmCouponStatus frm = new FrmReporter.FrmReportDiscount.frmCouponStatus(translate);
                        //frm.IsMdiContainer = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = ((DataRow)od)["TenBaoCao"].ToString();
                        frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());

                        frm.ShowDialog();
                    }
                    else
                    {
                        showDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void LoadTreeView()
        {
            string str = "Select IdBaocao, MaBaocao,  TenBaocao, MaCha, DuongDan, Storein, StoreXem, Report_Id, Columns  From Dm_BaoCao Where Active = 1 Order by MaBaocao";
            //SqlDataAdapter adapter = new SqlDataAdapter(str, conn );
            ds = new DataSet();
            //adapter.Fill(ds);
            //SqlParameter[] para = new SqlParameter[0];
            ds = sqlDac.InlineSql_Execute(str, null);
            //for (int i = 0; i < ds.Tables [0].Rows.Count ; i++)
            //{
             
                foreach (DataRow drNow in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(drNow["MaCha"]) == 1)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = drNow["TenBaocao"].ToString();
                        node.Tag = drNow;

                        //gọi hàm tạo mới node con cho node mức 0
                        newChildNode(node, ds.Tables[0]);
                        node.ImageIndex = 0;
                        treeView1.Nodes.Add(node);
                        //break;
                    }
                    
                //}


            }           
        }
        //Hàm tạo mới các node con cho một node
        void newChildNode(TreeNode nowNode, DataTable dt)
        {
            //lấy ra detp_code của node hiện tại và tìm hết các node con của node hiện tại
            foreach (DataRow drNow in dt.Rows)
            {
                DataRow idnowNode = (DataRow)nowNode.Tag;
                //Nếu node đang duyệt có MaCha = MaBaoCao của node hiện tại thì nó là con của lớp hiện tại
                if (drNow["MaCha"].ToString() == ((DataRow)idnowNode)["MaBaoCao"].ToString())
                {
                    //Tạo node con
                    TreeNode childNode = new TreeNode();
                    childNode.Text = drNow["TenBaoCao"].ToString();
                    childNode.ImageIndex = drNow["MaCha"].ToString().Length==4 ? 2:1;
                    childNode.SelectedImageIndex = childNode.ImageIndex;
                    childNode.Tag = drNow;
                    //add vào node hiện tại
                    nowNode.Nodes.Add(childNode);
                    //gọi đệ quy node con hiện tại
                    newChildNode(childNode, dt);
                    //childNode.ImageIndex = 2;
                }
                
            }
        }
        
        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTreeView();
                treeView1.ExpandAll();

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }


        }

        private void treeView1_Click(object sender, EventArgs e)
        {       
            

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            od = (DataRow)treeView1.SelectedNode.Tag;
            str = treeView1.SelectedNode.Text;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                CaseReport(((DataRow)od)["Report_Id"].ToString());
                //if (((DataRow)od)["Report_Id"].ToString() == "frmSalesReportSale")//Báo cáo bán hàng
                //{
                //    FrmReporter.FrmReportSale.frmReportSale  frm = new FrmReporter.FrmReportSale.frmReportSale();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmSalesReportByCustomerSale")
                //{
                //    FrmReporter.FrmReportSale.frmSalesReportByCustomerSale frm = new FrmReporter.FrmReportSale.frmSalesReportByCustomerSale();                    
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                ////Hệ thống báo cáo 04
                //else if (((DataRow)od)["Report_Id"].ToString() == "rptImportProductsSale")//04.01
                //{
                //    FrmReporter.FrmReportSale.frmReportProductsSale frm = new FrmReporter.FrmReportSale.frmReportProductsSale();                    
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "rptExportProductsStoreSale")//04.02
                //{
                //    FrmReporter.FrmReportSale.rptExportProductsStoreSale frm = new FrmReporter.FrmReportSale.rptExportProductsStoreSale();                    
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmInventoryReportSale")//04.03
                //{
                //    FrmReporter.FrmReportSale.frmInventoryReportSale frm = new FrmReporter.FrmReportSale.frmInventoryReportSale();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmEntryInventoryProductReportSale")//04.04
                //{
                //    FrmReporter.FrmReportSale.frmEntryInventoryProductReportSale frm = new FrmReporter.FrmReportSale.frmEntryInventoryProductReportSale();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmSalePROMOTIONGIFTS")//04.05
                //{
                //    FrmReporter.FrmReportSale.frmSalePROMOTIONGIFTS frm = new FrmReporter.FrmReportSale.frmSalePROMOTIONGIFTS();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmCompareImportProductReport")//04.06
                //{
                //    FrmReporter.FrmReportSale.frmCompareImportProductReport frm = new FrmReporter.FrmReportSale.frmCompareImportProductReport();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmSalesExportSearchReportByCat")//06.03
                //{
                //    FrmReporter.FrmReportSale.frmSalesExportSearchReportByCat frm = new FrmReporter.FrmReportSale.frmSalesExportSearchReportByCat();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmCustomerListSearchByNoExportCode")//06.07
                //{
                //    FrmReporter.FrmReportSale.frmCustomerListSearchByNoExportCode frm = new FrmReporter.FrmReportSale.frmCustomerListSearchByNoExportCode();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}
                //// báo cáo hàng trả lại
                //else if (((DataRow)od)["Report_Id"].ToString() == "frmItemReturnReport")//Báo cáo bán hàng
                //{
                //    FrmReporter.FrmReportSale.frmItemReturnReport frm = new FrmReporter.FrmReportSale.frmItemReturnReport();
                //    //frm.IsMdiContainer = true;
                //    frm.SetINFBC(((DataRow)od)["Storein"].ToString(), ((DataRow)od)["DuongDan"].ToString());
                //    frm.ShowDialog();
                //}

            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReport_KeyDown(object sender, KeyEventArgs e)
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
                log.Error("Error: " + ex.Message);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                CaseReport(((DataRow)od)["Report_Id"].ToString());
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void showDialog()
        {
            MessageBox.Show(translate["Msg.PermissionDialog"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

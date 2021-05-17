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
    public partial class frmDeleteResion : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion

        #region Constructor
        public frmDeleteResion(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.Resion.Text = translate["frmDeleteResion.Resion.Text"];
            this.btnExit.Text = translate["frmDeleteResion.btnExit.Text"];
            this.btnDelete.Text = translate["frmDeleteResion.btnDelete.Text"];
            this.Text = translate["frmDeleteResion.Text"];

        }
        #endregion

        #region Constant
        string id = "";
        string autoId = "";
        #endregion

        #region Methods
        //load danh sách các điều kiện
        private void LoadResion()
        {
            string proc = "REPORT_CONDITIONS_ReadCbo";

            DataTable dt = new DataTable();
            dt = sqlDac.GetDataTable(proc, null);


            //ResetControl();

            //Lấy dữ liệu vào Listview
            lvwResion.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TITLE"].ToString() != "")
                {
                    lvwResion.Items.Add(dt.Rows[i]["TITLE"].ToString());
                    lvwResion.Items[i].SubItems.Add(dt.Rows[i]["AUTO_ID"].ToString());
                    if (i % 2 == 0)
                    {
                        lvwResion.Items[i].BackColor = Color.FromArgb(224, 223, 227);
                    }
                }
            }
        }
        #endregion

        #region Event
        private void frmDeleteResion_Load(object sender, EventArgs e)
        {
            LoadResion();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwResion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in lvwResion.CheckedItems)
            //{
            //    id = lvwResion.FocusedItem.Text;
            //    autoId = item.SubItems[1].Text.ToString();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            if (id != string.Empty)
                {
                   
                    if (MessageBox.Show(Properties.rsfPayment.CashPayment4.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lvwResion.Items.Remove(lvwResion.Items[id]);
                        string proc = "REPORT_CONDITIONS_Delete";
                        SqlParameter[] para;
                        para = new SqlParameter[1];
                        para[0] = posdb_vnmSqlDAC.newInParam("@AUTO_ID", SqlDbType.VarChar, autoId);
                        sqlDac.Execute(proc, para);

                        MessageBox.Show(Properties.rsfPayment.CashPayment5.ToString(), translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             
                    } 
                }
            LoadResion();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void lvwResion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void lvwResion_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in lvwResion.CheckedItems)
            {
                id = lvwResion.FocusedItem.Text;
                autoId = item.SubItems[1].Text.ToString();
            }
        }

        private void lvwResion_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in lvwResion.SelectedItems)
            {
                Item.Checked = true;
            }
        }
        #endregion
    }
}

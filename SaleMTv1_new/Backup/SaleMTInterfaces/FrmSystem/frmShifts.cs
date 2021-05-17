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
using SaleMTBusiness.SystemManagement;

namespace SaleMTInterfaces.FrmSystem
{
    /// <summary>
    /// Người tạo Luannv – 2/11/2013 : Kiểm tra kết ca   
    /// </summary>
    public partial class frmShifts : Form
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private bool shiftChecked;

        public bool ShiftChecked
        {
            get { return shiftChecked; }
            set { shiftChecked = value; }
        }
        private DataTable dtShifts;

        public DataTable DtShifts
        {
            get { return dtShifts; }
            set { dtShifts = value; }
        }
        #endregion
        #region Contructor
      
        public frmShifts(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.grbShifts.Text = translate["frmShips.grbShifts.Text"];
            this.columnHeader1.Text = translate["frmShips.columnHeader1.Text"];
            this.columnHeader2.Text = translate["frmShips.columnHeader2.Text"];
            this.columnHeader3.Text = translate["frmShips.columnHeader3.Text"];
            this.btnPrint.Text = translate["frmShips.btnPrint.Text"];
            this.btnOkShifts.Text = translate["frmShips.btnOkShifts.Text"];
            this.btnContinute.Text = translate["frmShips.btnContinute.Text"];
            this.Text = translate["frmShips.Text"];
        }	

        #region Method
        private void AddItem()
        {
            try
            {
                if (dtShifts.Rows.Count > 0)
                {
                    for (int i = 0; i < dtShifts.Rows.Count; i++)
                    {
                        lvwListShift.Items.Add(dtShifts.Rows[i]["SHIFT_NAME"].ToString());
                        lvwListShift.Items[i].SubItems.Add(dtShifts.Rows[i]["DATE_SHIFT"].ToString());
                        lvwListShift.Items[i].SubItems.Add(dtShifts.Rows[i]["TRANSFER_BY"].ToString());
                        lvwListShift.Items[i].SubItems.Add(dtShifts.Rows[i]["TRANSFER_SHIFT_CODE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'AddItem': " + ex.Message);
            }
        }
        #endregion
        #endregion
        #region Event
        private void frmShifts_Load(object sender, EventArgs e)
        {
            try
            {
                if (dtShifts != null)
                {
                    AddItem();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
        #endregion

        private void btnOkShifts_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwListShift.Items.Count; i++)
                {
                    Shifts.EndShift(lvwListShift.Items[i].SubItems[3].Text.Trim());
                    this.shiftChecked = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwListShift.Items.Count > 1)
                {
                    ListView.SelectedListViewItemCollection item = lvwListShift.SelectedItems;
                    if (item.Count > 0)
                    {
                        Shifts.PrintDataShift(item[0].SubItems[3].Text.Trim());
                    }
                }
                else
                {
                    Shifts.PrintDataShift(lvwListShift.Items[0].SubItems[3].Text.Trim());
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Error : " + ex.Message);
            }
        }
    }
}


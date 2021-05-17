using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Windows;

namespace SaleMTCommon
{
    public partial class ctlInfoStore : UserControl
    {
        private const string TITLE_EXPORT = "Kiểm kê hàng";
        private const string NODE_LIST_STORE_CODE = "Chuỗi cửa hàng";
        private const string NODE_PALCE_CODE = "Vị trí";
        private const string NODE_SHOP_CODE = "Cửa hàng";
        private const string LOC_CODE = "LOC.";
        private const string STO_CODE = "STO.";
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ctlInfoStore()
        {
            InitializeComponent();
        }

        #region method
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu chuỗi cửa hàng
        /// </summary>
        private void LoadTreListStore()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", STO_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_LIST_STORE_CODE);
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.StoreCode)
                            childNode.Checked = true;
                    }
                    this.trvStoreList.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreListStore': " + ex.Message);
            }
            //node goc dau tien

        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu vị trí
        /// </summary>
        private void LoadTrePlace()
        {
            try
            {
                SqlParameter[] para = { posdb_vnmSqlDAC.newInParam("@MASTER_CODE", LOC_CODE) };
                DataTable dtMaster = sqlDac.GetDataTable("MASTER_DATA_Read_ByPrifix_MasterCode", para);


                if (dtMaster.Rows.Count > 0)
                {
                    TreeNode trNode = new TreeNode(NODE_PALCE_CODE);
                    for (int i = 0; i < dtMaster.Rows.Count; i++)
                    {
                        TreeNode childNode = new TreeNode(dtMaster.Rows[i]["MASTER_NAME"].ToString());
                        trNode.Nodes.Add(childNode);
                        if (dtMaster.Rows[i]["MASTER_CODE"].ToString().Trim() == UserImformation.BusinessTypeCode)
                            childNode.Checked = true;
                    }
                    this.trvPlace.Nodes.Add(trNode);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTrePlace': " + ex.Message);
            }
            //node goc dau tien

        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Load dữ liệu cửa hàng
        /// </summary>p
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
                    this.trvShop.Nodes.Add(childNode[0]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadTreShop': " + ex.Message);
            }
            //node goc dau tien

        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel chuỗi cửa hàng
        /// </summary>
        private void ResizeStoreList()
        {
            try
            {
                if (pnlStoreListPar.Size.Height == 25)
                {
                    btnStorelist.ImageIndex = 1;
                    pnlStoreListPar.Size = new System.Drawing.Size(195, 175);
                    pnlPlacePar.Location = new System.Drawing.Point(0, 0 + 175);
                    pnlShopPar.Location = new System.Drawing.Point(0, 0 + 175 + pnlPlacePar.Size.Height);
                    toolStripButton2.Image = imgUpDown.Images[1];
                }
                else
                {
                    btnStorelist.ImageIndex = 0;
                    pnlStoreListPar.Size = new System.Drawing.Size(195, 25);
                    pnlPlacePar.Location = new System.Drawing.Point(0, 0 + 25);
                    pnlShopPar.Location = new System.Drawing.Point(0, 0 + 25 + pnlPlacePar.Size.Height);
                    toolStripButton2.Image = imgUpDown.Images[0];
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel vị trí
        /// </summary>
        private void ResizePlace()
        {
            try
            {
                if (pnlPlacePar.Size.Height == 25)
                {
                    btnPlace.ImageIndex = 1;
                    pnlPlacePar.Size = new System.Drawing.Size(195, 175);
                    pnlShopPar.Location = new System.Drawing.Point(0, 0 + pnlStoreListPar.Size.Height + 175);
                    toolStripButton1.Image = imgUpDown.Images[1];
                }
                else
                {
                    btnPlace.ImageIndex = 0;
                    pnlPlacePar.Size = new System.Drawing.Size(195, 25);
                    pnlShopPar.Location = new System.Drawing.Point(0, 0 + pnlStoreListPar.Size.Height + 25);
                    toolStripButton1.Image = imgUpDown.Images[0];
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv - 05/11/2013: Mở hoặc ẩn panel thông tin cửa hàng
        /// </summary>
        private void ResizeShop()
        {
            try
            {
                /*
                if (pnlShopPar.Size.Height == 25)
                {
                    btnShop.ImageIndex = 1;
                    //pnlShopPar.Size = new System.Drawing.Size(195, 175);
                    trvShop.Visible = false;
                }
                else
                {
                    btnShop.ImageIndex = 0;
                    pnlShopPar.Size = new System.Drawing.Size(195, 25);
                }*/
                if (trvShop.Visible)
                {
                    btnShop.ImageIndex = 1;                    
                    trvShop.Visible = false;
                    toolStripButton3.Image = imgUpDown.Images[1];
                }
                else
                {
                    btnShop.ImageIndex = 0;
                    trvShop.Visible = true;
                    toolStripButton3.Image = imgUpDown.Images[0];
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'LoadControl': " + ex.Message);
            }
        }
        #endregion

        private void btnStorelist_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeStoreList();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void pnlStoreList_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeStoreList();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void ctlInfoStore_Load(object sender, EventArgs e)
        {
            try
            {

                pnlStoreListPar.Size = new System.Drawing.Size(195, 25);
                pnlPlacePar.Size = new System.Drawing.Size(195, 25);
                pnlPlacePar.Location = new System.Drawing.Point(0, 25);
                pnlShopPar.Size = new System.Drawing.Size(195, 25);
                pnlShopPar.Location = new System.Drawing.Point(0, 50);
                //
                LoadTreListStore();
                LoadTrePlace();
                LoadTreShop();
                trvStoreList.ExpandAll();
                trvShop.ExpandAll();
                trvPlace.ExpandAll();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void pnlPlace_Click(object sender, EventArgs e)
        {
            try
            {
                ResizePlace();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void pnlShop_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeShop();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            btnStorelist_Click(sender, e);            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            btnPlace_Click(sender, e);            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            btnShop_Click(sender, e);            
        }
    }
}

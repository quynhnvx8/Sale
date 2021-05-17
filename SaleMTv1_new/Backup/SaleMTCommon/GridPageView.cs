using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Data.SqlClient;




namespace SaleMTCommon
{
    public partial class GridPageView : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static private Dictionary<string, string> translate = new Dictionary<string, string>();

        public GridPageView(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
        }
        public DataTable dtSource;
        public DataTable dtColInfo;
        public DataTable dtTotal;
        public string colTotal;
        private int rows;
        public void GridPageView_Load()
        {
            try {
                rows = dtSource.Rows.Count;
                string colName;
                //Ngày 02/12/13 : Hiệp thêm điều kiện khi load lưới: nếu tìm thấy dữ liệu mới hiển thị dòng tổng cộng
                if (rows == 0)
                {
                    MessageBox.Show(translate["Msg.DataNotFound"], translate["Msg.TitleDialog"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.DataSource = null;
                }
                if (rows > 0)
                {
                    DataRow drSum = dtSource.NewRow();
                    DataRow drSumEnd = dtSource.NewRow();
                    drSum["STT"] = "0";
                    foreach (DataColumn dc in dtTotal.Columns)
                    {
                        if (dtSource.Columns.Contains(dc.ColumnName))
                        {
                            drSum[dc.ColumnName] = dtTotal.Rows[0][dc.ColumnName];
                            drSumEnd[dc.ColumnName] = dtTotal.Rows[0][dc.ColumnName];
                        }
                    }
                    drSumEnd["STT"] = dtSource.Rows.Count + 1;
                    if (dtSource.Columns.Contains(colTotal))
                    {
                        drSumEnd[colTotal] = "Tổng cộng: ";
                        drSum[colTotal] = "Tổng cộng: ";
                    }
                    dtSource.Rows.Add(drSum);
                    dtSource.Rows.Add(drSumEnd);
                    dtSource.AcceptChanges();

                    dtSource.DefaultView.RowFilter = "STT =" + (dtSource.Rows.Count - 1)
                            + " OR (STT >= 0 and STT <= 20)";
                    dtSource.DefaultView.Sort = "STT";

                    dataGridView1.DataSource = dtSource;

                    dataGridView1.AutoGenerateColumns = true;
                }
                
                lblTotalRow.Text = "Tổng: " + rows.ToString() + " dòng";
                cboRowOnPage.SelectedIndex = 0;
                lblCurrentPage.Text = (rows > 0) ? "1" : "0";
                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();
                btnLast.Enabled = !(dataGridView1.Rows.Count <= 1);
                btnFirst.Enabled = !(dataGridView1.Rows.Count <= 1);
                btnNext.Enabled = !(dataGridView1.Rows.Count <= 1);
                btnPrev.Enabled = !(dataGridView1.Rows.Count <= 1);
                int iDisplayIndex = 0;
                foreach (DataRow dr in dtColInfo.Rows) {
                    colName = dr["col"].ToString();
                    if (dataGridView1.Columns.Contains(colName))
                    {
                        dataGridView1.Columns[colName].HeaderText = dr["Header"].ToString();
                        if (dtSource.Columns.Contains(colName))
                        {
                            if (dtSource.Columns[colName].DataType.FullName.ToLower().Contains("double") ||
                                dtSource.Columns[colName].DataType.FullName.ToLower().Contains("int") ||
                                dtSource.Columns[colName].DataType.FullName.ToLower().Contains("decimal"))
                            {
                                dataGridView1.Columns[colName].DefaultCellStyle.Format = "N0";
                                // luân thêm căn lề phải cho các cột số
                                dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView1.Columns[colName].InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }                            
                        }
                        dataGridView1.Columns[colName].DisplayIndex = iDisplayIndex;
                        iDisplayIndex++;
                        if (int.Parse(dr["index"].ToString()) == 0) {
                            dataGridView1.Columns[colName].Visible = false;
                            }
                    }
                }

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(210, 180, 140);
                style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                dataGridView1.Rows[0].DefaultCellStyle = style;
                dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle = style;
            }catch{
                
            }
        }

        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        private void DoPaging()
        {
            try
            {
                int pageSize = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int pageCount = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lblTotalPage.Text = pageCount.ToString();

                int rowOnPage = Convert.ToInt32(cboRowOnPage.SelectedItem.ToString());
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                int firstRow = (currentPage * rowOnPage) - rowOnPage + 1;
                int lastRow = currentPage * rowOnPage;
                DataTable gridTable = (DataTable)dataGridView1.DataSource;
                gridTable.DefaultView.RowFilter = "STT=0 or STT=" + (gridTable .Rows.Count-1)
                    + " OR (STT >= " + firstRow.ToString() + " and STT <= " + lastRow.ToString() + ")";
                gridTable.DefaultView.Sort = "STT";

                btnFirst.Enabled = (currentPage > 1);
                btnPrev.Enabled = (currentPage > 1);
                btnNext.Enabled = (currentPage < pageCount);
                btnLast.Enabled = (currentPage < pageCount);
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Cells[0].Selected = true;
                }
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(210, 180, 140);
                style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                dataGridView1.Rows[0].DefaultCellStyle = style;
                dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle = style;
            }
            catch (Exception ex)
            {
                log.Error("Error 'DoPaging': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Xử lý phân trang  .
        /// </summary>
        /// 

        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Trở về trang đầu  .
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = "1";
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Trở về trang trước  .
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage - 1).ToString();
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chuyển sang trang kế tiếp  .
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPage = Convert.ToInt32(lblCurrentPage.Text);
                lblCurrentPage.Text = (currentPage + 1).ToString();
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chuyển đến trang cuối  .
        /// </summary>
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                lblCurrentPage.Text = lblTotalPage.Text;
                DoPaging();
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Chặn các ký tự không hợp lệ  .
        /// </summary>
        /// 
        private void btnGoPage_Click(object sender, EventArgs e)
        {
            try
            {
                int pageGo = Convert.ToInt32(txtPageGo.Text);
                int pageCount = Convert.ToInt32(lblTotalPage.Text);
                if (pageGo >= 1 && pageGo <= pageCount)
                {
                    lblCurrentPage.Text = txtPageGo.Text;
                    DoPaging();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Thay đổi màu nền từng dòng trên Datagridview  .
        /// </summary>
        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Changed background of datagridview.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    DataGridViewCellStyle bgcolor = new DataGridViewCellStyle();
                    bgcolor.BackColor = Color.FromArgb(224, 223, 227);
                    int i = 0;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        i++;
                        if (i % 2 == 0)
                        {
                            r.DefaultCellStyle = bgcolor;
                        }
                    }
                    //Ngày 02/12/13 Hiệp sửa: Không cho sort theo column
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 01/10/2013 : Đóng form tìm kiếm khách hàng  .
        /// </summary>
    }
}

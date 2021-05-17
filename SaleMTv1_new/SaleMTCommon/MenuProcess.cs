using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTCommon
{
    /// <summary>
    /// Người tạo Luannv – 24/09/2013:Các hàm xử lý cho các sự kiện Addnew, Save, delete, edit.
    /// </summary>
    public class MenuProcess
    {
        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion

        #region Method form        
       
        /// <summary>
        /// Người tạo Luannv – 24/09/2013:.
        /// </summary>
        public void setControlAdd(Form frm, string name, bool boo)
        {
            try
            {
                Control control = frm.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    if (control is DateTimePicker)
                    {
                        DateTimePicker dtpTemp = (DateTimePicker)control;
                        dtpTemp.Value = DateTime.Now;
                        control.Enabled = boo;
                    }
                    else if (control is DataGridView)
                    {
                        DataGridView dgvControl = (DataGridView)control;
                        if (dgvControl.Rows.Count > 1)
                        {
                            for (int i = dgvControl.Rows.Count - 1; i >= 0; i--)
                            {
                                if (!dgvControl.Rows[i].IsNewRow)
                                {
                                    dgvControl.Rows.RemoveAt(i);
                                }
                            }
                        }
                        control.Enabled = boo;
                    }
                    else if (control is ListView)
                    {
                        control.Enabled = boo;
                    }
                    else if (control is Button)
                    {
                        control.Enabled = boo;
                    }
                    else
                    {
                        control.Text = "";
                        control.Enabled = boo;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 24/09/2013:Gán dữ liệu chi tiết vào các control.
        /// </summary>
        public void bindingControlDetails(Form frm, string name, string[] strName)
        {
            try
            {
                Control control = frm.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    if (control is ListView)
                    {
                        ListView lvwTemp = (ListView)control;
                        if (lvwTemp.Items.Count > 0)
                        {
                            ListViewItem item = lvwTemp.SelectedItems[0];
                            for (int i = 0; i < strName.Length; i++)
                            {
                                Control controlBinding = frm.Controls.Find(strName[i], true).FirstOrDefault();
                                if (controlBinding != null)
                                {
                                    if (controlBinding is DateTimePicker)
                                    {
                                        DateTimePicker dtpTemp = (DateTimePicker)controlBinding;
                                        dtpTemp.Value = Conversion.stringToDateTime(item.SubItems[i].Text);
                                    }
                                    else
                                    {
                                        controlBinding.Text = item.SubItems[i].Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 24/09/2013:Gán dữ liệu chi tiết vào control Datagridview.
        /// </summary>
        public void bindingSourceDetails(Form frm, string name, string procedure, string paraName, string paraValueControl)
        {
            try
            {
                Control control = frm.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    if (control is DataGridView)
                    {
                        Control paraValue = frm.Controls.Find(paraValueControl, true).FirstOrDefault();
                        SqlParameter para = posdb_vnmSqlDAC.newInParam(paraName, paraValue.Text);
                        SqlParameter[] paramater = {para};                        
                        DataGridView dgvTemp = (DataGridView)control;
                        dgvTemp.DataSource = sqlDac.GetDataTable(procedure, paramater);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 24/09/2013:Lấy dữ liệu từ các control trong form 
        /// </summary>
        public object GetValueControl(Form frm, string name)
        {
            object result = null;
            try
            {
                Control control = frm.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    if (control is DateTimePicker)
                    {
                        DateTimePicker dtpTemp = (DateTimePicker)control;
                        result = dtpTemp.Value;
                    }
                    else
                    {
                        result = control.Text;
                    } 
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SaleMTCommon
{
    /// <summary>
    /// Người tạo Luannv – 06/10/2013 : Các phương thức hỗ trợ in hóa đơn.
    /// </summary>
    public class Print
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Method
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán giá trị thông tin cửa hàng vào datatable .
        /// </summary>
        public static void AddUserInfo(DataTable dtAdd)
        {
            try
            {
                dtAdd.Columns.Add("StoreName", typeof(string));
                dtAdd.Columns.Add("Address", typeof(string));
                dtAdd.Columns.Add("Tel", typeof(string));
                dtAdd.Columns.Add("Fax", typeof(string));
                DataRow dRow = dtAdd.NewRow();
                dRow["StoreName"] = UserImformation.DeptName;
                dRow["Address"] = UserImformation.StoreAdress;
                dRow["Tel"] = UserImformation.StoreTelePhone;
                dRow["Fax"] = UserImformation.StoreFax;
                dtAdd.Rows.Add(dRow);
            }
            catch (Exception ex)
            {
                log.Error("Error: "+ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán logo cửa hàng vào datatable.
        /// </summary>
        public static void AddLogo(DataTable dtLogo)
        {
            try
            {
                dtLogo.Columns.Add("Image", typeof(string));
                DataRow dRowLogo = dtLogo.NewRow();
                dRowLogo["Image"] = UserImformation.Logo;
                dtLogo.Rows.Add(dRowLogo);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Luannv – 07/10/2013 : Gán giá trị thông tin công ty .
        /// </summary>
        public static void AddUserCompanyInfo(DataTable dtAdd)
        {
            try
            {
                dtAdd.Columns.Add("CompanyName", typeof(string));
                dtAdd.Columns.Add("Address", typeof(string));
                dtAdd.Columns.Add("Tel", typeof(string));
                dtAdd.Columns.Add("Fax", typeof(string));
                DataRow dRow = dtAdd.NewRow();
                dRow["CompanyName"] = UserImformation.CompanyName;
                dRow["Address"] = UserImformation.CompanyAdress;
                dRow["Tel"] = UserImformation.CompanyTelePhone;
                dRow["Fax"] = UserImformation.CompanyFax;
                dtAdd.Rows.Add(dRow);
            }
            catch (Exception ex)
            {
                log.Error("Error: " + ex.Message);
            }
        }
        #endregion
    }
}

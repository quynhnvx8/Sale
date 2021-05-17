using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTDataAccessLayer.SaleMTDAL;
using System.Data;
using SaleMTDataAccessLayer.SaleMTObj;
using System.Windows.Forms;
using System.Data.SqlClient;
using SaleMTCommon;

namespace SaleMTBusiness.SaleManagement
{
    class CashDeposit
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion
        /// <summary>
        /// Người tạo Huy : Thêm 1 dòng vào Data.
        /// </summary>
        public static void CashdepositPayment(string MaTT, DateTime Ngay, Boolean Loai, double SoTien, string DienGiai, string MaCH, double POS)
        {
            CN_NopTienTT  slPayDetails = new CN_NopTienTT ();
            try
            {
                slPayDetails.MaTT = MaTT;
                slPayDetails.Ngay = Ngay;
                slPayDetails.Loai = Loai;
                slPayDetails.SoTien = SoTien;
                slPayDetails.DienGiai = DienGiai;
                slPayDetails.MaCH = MaCH;
                slPayDetails.POS = POS;
                slPayDetails.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit PaymentVND' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Huy : Update 1 dòng vào Data.
        /// </summary>
        public static void CashdepositPaymentUpdate(string MaTT, DateTime Ngay, Boolean Loai, double SoTien, string DienGiai, string MaCH, double POS)
        {
            CN_NopTienTT slPayDetails = new CN_NopTienTT();
            try
            {
                slPayDetails.MaTT = MaTT;
                slPayDetails.Ngay = Ngay;
                slPayDetails.Loai = Loai;
                slPayDetails.SoTien = SoTien;
                slPayDetails.DienGiai = DienGiai;
                slPayDetails.MaCH = MaCH;
                slPayDetails.POS = POS;
                slPayDetails.Save(false);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit PaymentVND' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Huy : Delete 1 dòng vào Data.
        /// </summary>
        public static void CashdepositDelete(string MaTT)
        {
            CN_NopTienTT slPayDetails = new CN_NopTienTT();
            try
            {
                slPayDetails.MaTT = MaTT;                
                slPayDetails.Delete();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Cash deposit PaymentVND' : " + ex.Message);
            }
        }
        public static void CreateDatable(DataTable dTable)
        {
            try
            {
                dTable.Columns.Add("Ma", typeof(string));
                dTable.Columns.Add("Ngay",typeof(DateTime ));
                dTable.Columns.Add("DienGiai", typeof(string));
                dTable.Columns.Add("SoTien", typeof(double ));
                dTable.Columns.Add("POS", typeof(float));
                dTable.Columns.Add("TongCong", typeof(double));
                
            }
            catch (Exception ex)
            {
                log.Error(" Error 'CreateDatable': " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Huy : Add 1 dòng vào Grid.
        /// </summary>
        public static DataTable AddRowDatatable(string MaTT, DataTable dtSale, posdb_vnmSqlDAC sqlDac)
        {
            try
            {
                DataTable dTableNew = new DataTable();
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@Ma", MaTT);
                dTableNew = sqlDac.GetDataTable("CashDeposit_ById", para);
                if (dTableNew.Rows.Count > 0)
                {
                    Double  SoTien =Convert.ToDouble(dTableNew.Rows[0]["SoTien"]);
                    Double POS = Convert.ToDouble(dTableNew.Rows[0]["POS"]);
                    Double TongCong = Convert.ToDouble(dTableNew.Rows[0]["TongCong"]); 
                    DataRow dRow = dtSale.NewRow();
                    dRow["Ma"] = dTableNew.Rows[0]["Ma"];
                    dRow["Ngay"] = dTableNew.Rows[0]["Ngay"];
                    dRow["DienGiai"] = dTableNew.Rows[0]["DienGiai"];
                    dRow["SoTien"] = SoTien;
                    dRow["POS"] = POS;
                    dRow["TongCong"] = TongCong;
                    dtSale.Rows.Add(dRow);                    
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'GetDatetable': " + ex.Message);
            }
            return dtSale;
        }    


        
    }
}

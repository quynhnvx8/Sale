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
    class InputOpeningLiablity
    {
        #region Declaration
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        #endregion
        /// <summary>
        /// Người tạo Huy : Thêm 1 dòng vào Data.
        /// </summary>
        public static void InputOpeningLiablityInSert(string SoHD, DateTime NgayHD, string MaCH, DateTime NgayTT, 
            float SoTien, float DaTT, Boolean Loai, string GhiChu, string SoPO, string SoNoiBo, float ConLai, float STIENDC, string GhiChuDC)
        {
            CN_HoaDon slPayDetails = new CN_HoaDon();
            try
            {
                slPayDetails.SoHD = SoHD;
                slPayDetails.NgayHD = NgayHD;
                slPayDetails.MaCH = MaCH;
                slPayDetails.NgayTT = NgayTT;
                slPayDetails.SoTien = SoTien;
                slPayDetails.DaTT = DaTT;
                slPayDetails.Loai = Loai;
                slPayDetails.GhiChu = GhiChu;
                slPayDetails.SoPO = SoPO;
                slPayDetails.SoNoiBo = SoNoiBo;
                slPayDetails.ConLai = ConLai;
                slPayDetails.STIENDC = STIENDC;
                slPayDetails.GhiChuDC = GhiChuDC;
                slPayDetails.Save(true);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Input Opening Liablity insert' : " + ex.Message);
            }
        }

        /// <summary>
        /// Người tạo Huy : update 1 dòng vào Data.
        /// </summary>
        public static void InputOpeningLiablityUpdate(string SoHD, DateTime NgayHD, string MaCH, DateTime NgayTT,
            float SoTien, float DaTT, Boolean Loai, string GhiChu, string SoPO, string SoNoiBo, float ConLai, float STIENDC, string GhiChuDC)
        {
            CN_HoaDon slPayDetails = new CN_HoaDon();
            try
            {
                slPayDetails.SoHD = SoHD;
                slPayDetails.NgayHD = NgayHD;
                slPayDetails.MaCH = MaCH;
                slPayDetails.NgayTT = NgayTT;
                slPayDetails.SoTien = SoTien;
                slPayDetails.DaTT = DaTT;
                slPayDetails.Loai = Loai;
                slPayDetails.GhiChu = GhiChu;
                slPayDetails.SoPO = SoPO;
                slPayDetails.SoNoiBo = SoNoiBo;
                slPayDetails.ConLai = ConLai;
                slPayDetails.STIENDC = STIENDC;
                slPayDetails.GhiChuDC = GhiChuDC;
                slPayDetails.Save(false);
            }
            catch (Exception ex)
            {
                log.Error("Error 'Input Opening Liablity update' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Huy : Delete 1 dòng vào Data.
        /// </summary>
        public static void InputOpeningLiablityDelete(string SoHD)
        {
            CN_HoaDon slPayDetails = new CN_HoaDon();
            try
            {
                slPayDetails.SoHD = SoHD;
                slPayDetails.Delete();
            }
            catch (Exception ex)
            {
                log.Error("Error 'Input Opening Liablity delete' : " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Huy : Load datatable.
        /// </summary>
        public static DataTable LoadDatable(posdb_vnmSqlDAC sqlDac)
        {
            DataTable dTableNew = new DataTable();
            try
            {                
                SqlParameter[] para = new SqlParameter[0];
                dTableNew = sqlDac.GetDataTable("Input_Opening_Liablity", para);                

            }
            catch (Exception ex)
            {
                log.Error(" Error 'CreateDatable': " + ex.Message);
            }
            return dTableNew;
        }

        /// <summary>
        /// Người tạo Huy : Load datatable.
        /// </summary>
        public static DataTable LoadDatableCheckInvoice(string SoHoaDon, posdb_vnmSqlDAC sqlDac)
        {
            DataTable dTableNew = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = posdb_vnmSqlDAC.newInParam("@SoHoaDon", SoHoaDon);
                dTableNew = sqlDac.GetDataTable("Check_Invoice_Input_Opening_Liablity", para);

            }
            catch (Exception ex)
            {
                log.Error(" Error 'CreateDatable': " + ex.Message);
            }
            return dTableNew;
        }

    }
    
}

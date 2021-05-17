using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CN_HoaDon
    {
        #region members
        string soHD;
        DateTime ngayHD;
        string maCH;
        DateTime ngayTT;
        float soTien;
        float daTT;
        bool loai;
        string ghiChu;
        string soPO;
        string soNoiBo;
        float? conLai;
        float? sTIENDC;
        string ghiChuDC;

        #endregion members
        #region Properties
        [PKSqlColumn("SoHD", SqlDbType.VarChar, null)]
        public string SoHD
        {
            get { return soHD; }
            set { soHD = value; }
        }
        [SqlColumn("NgayHD", SqlDbType.DateTime)]
        public DateTime NgayHD
        {
            get { return ngayHD; }
            set { ngayHD = value; }
        }
        [StringSqlColumn("MaCH")]
        public string MaCH
        {
            get { return maCH; }
            set { maCH = value; }
        }
        [SqlColumn("NgayTT", SqlDbType.DateTime)]
        public DateTime NgayTT
        {
            get { return ngayTT; }
            set { ngayTT = value; }
        }
        [SqlColumn("SoTien", SqlDbType.Float)]
        public float SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        [SqlColumn("DaTT", SqlDbType.Float)]
        public float DaTT
        {
            get { return daTT; }
            set { daTT = value; }
        }
        [SqlColumn("Loai", SqlDbType.Bit)]
        public bool Loai
        {
            get { return loai; }
            set { loai = value; }
        }
        [SqlColumn("GhiChu", SqlDbType.NVarChar)]
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        [StringSqlColumn("SoPO")]
        public string SoPO
        {
            get { return soPO; }
            set { soPO = value; }
        }
        [StringSqlColumn("SoNoiBo")]
        public string SoNoiBo
        {
            get { return soNoiBo; }
            set { soNoiBo = value; }
        }
        [SqlColumn("ConLai", SqlDbType.Float)]
        public float? ConLai
        {
            get { return conLai; }
            set { conLai = value; }
        }
        [SqlColumn("STIENDC", SqlDbType.Float)]
        public float? STIENDC
        {
            get { return sTIENDC; }
            set { sTIENDC = value; }
        }
        [SqlColumn("GhiChuDC", SqlDbType.NVarChar)]
        public string GhiChuDC
        {
            get { return ghiChuDC; }
            set { ghiChuDC = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CN_HoaDon() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CN_HoaDon> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CN_HoaDon>("CN_HoaDon");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CN_HoaDon",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CN_HoaDon");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inSoHD"></param>
        public static List<CN_HoaDon> ReadBySoHD(string inSoHD)
        {
            return posdb_vnmSqlDAC.ReadByParams<CN_HoaDon>("CN_HoaDon", posdb_vnmSqlDAC.newInParam("@SoHD", inSoHD));
        }
        #endregion DAC Methods
    }
}

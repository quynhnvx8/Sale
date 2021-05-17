using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CN_NopTienTT
    {
        #region members
        string maTT;
        DateTime ngay;
        bool loai;
        double soTien;
        string dienGiai;
        string maCH;
        double? pOS;

        #endregion members
        #region Properties
        [PKSqlColumn("MaTT", SqlDbType.VarChar, null)]
        public string MaTT
        {
            get { return maTT; }
            set { maTT = value; }
        }
        [SqlColumn("Ngay", SqlDbType.DateTime)]
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        [SqlColumn("Loai", SqlDbType.Bit)]
        public bool Loai
        {
            get { return loai; }
            set { loai = value; }
        }
        [SqlColumn("SoTien", SqlDbType.Float)]
        public double SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        [SqlColumn("DienGiai", SqlDbType.NVarChar)]
        public string DienGiai
        {
            get { return dienGiai; }
            set { dienGiai = value; }
        }
        [StringSqlColumn("MaCH")]
        public string MaCH
        {
            get { return maCH; }
            set { maCH = value; }
        }
        [SqlColumn("POS", SqlDbType.Float)]
        public double? POS
        {
            get { return pOS; }
            set { pOS = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CN_NopTienTT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CN_NopTienTT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CN_NopTienTT>("CN_NopTienTT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CN_NopTienTT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CN_NopTienTT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inMaTT"></param>
        public static List<CN_NopTienTT> ReadByMaTT(string inMaTT)
        {
            return posdb_vnmSqlDAC.ReadByParams<CN_NopTienTT>("CN_NopTienTT", posdb_vnmSqlDAC.newInParam("@MaTT", inMaTT));
        }
        #endregion DAC Methods
    }

}

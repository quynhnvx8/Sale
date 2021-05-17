using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class IN_SEG_NHOMVT_PHUTHUOC
    {
        #region members
        string tenSeg;
        int chieuDai;
        string segPhuThuoc;

        #endregion members
        #region Properties
        [PKSqlColumn("TenSeg", SqlDbType.VarChar, null)]
        public string TenSeg
        {
            get { return tenSeg; }
            set { tenSeg = value; }
        }
        [SqlColumn("ChieuDai", SqlDbType.Int)]
        public int ChieuDai
        {
            get { return chieuDai; }
            set { chieuDai = value; }
        }
        [SqlColumn("SegPhuThuoc", SqlDbType.Char)]
        public string SegPhuThuoc
        {
            get { return segPhuThuoc; }
            set { segPhuThuoc = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public IN_SEG_NHOMVT_PHUTHUOC() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<IN_SEG_NHOMVT_PHUTHUOC> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<IN_SEG_NHOMVT_PHUTHUOC>("IN_SEG_NHOMVT_PHUTHUOC");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "IN_SEG_NHOMVT_PHUTHUOC",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "IN_SEG_NHOMVT_PHUTHUOC");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inTenSeg"></param>
        public static List<IN_SEG_NHOMVT_PHUTHUOC> ReadByTenSeg(string inTenSeg)
        {
            return posdb_vnmSqlDAC.ReadByParams<IN_SEG_NHOMVT_PHUTHUOC>("IN_SEG_NHOMVT_PHUTHUOC", posdb_vnmSqlDAC.newInParam("@TenSeg", inTenSeg));
        }
        #endregion DAC Methods
    }
}

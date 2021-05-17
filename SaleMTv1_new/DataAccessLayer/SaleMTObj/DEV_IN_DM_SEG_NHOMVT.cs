using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEV_IN_DM_SEG_NHOMVT : IDataModel
    {
        #region members
        string maSegCha;
        string maSeg;
        string tenSeg;
        string moTa;
        string active;
        int id;

        #endregion members
        #region Properties
        [StringSqlColumn("MaSegCha")]
        public string MaSegCha
        {
            get { return maSegCha; }
            set { maSegCha = value; }
        }
        [StringSqlColumn("MaSeg")]
        public string MaSeg
        {
            get { return maSeg; }
            set { maSeg = value; }
        }
        [StringSqlColumn("TenSeg")]
        public string TenSeg
        {
            get { return tenSeg; }
            set { tenSeg = value; }
        }
        [SqlColumn("MoTa", SqlDbType.NVarChar)]
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }
        [SqlColumn("Active", SqlDbType.Char)]
        public string Active
        {
            get { return active; }
            set { active = value; }
        }
        [PKSqlColumn("Id", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion Properties
        #region IsNew()
        public bool IsNew()
        {
            return id == 0;
        }

        #endregion IsNew()
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DEV_IN_DM_SEG_NHOMVT() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public DEV_IN_DM_SEG_NHOMVT(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEV_IN_DM_SEG_NHOMVT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEV_IN_DM_SEG_NHOMVT>("DEV_IN_DM_SEG_NHOMVT");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<DEV_IN_DM_SEG_NHOMVT>(this, "DEV_IN_DM_SEG_NHOMVT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEV_IN_DM_SEG_NHOMVT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEV_IN_DM_SEG_NHOMVT");
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEV_IN_DM_NHOMVATTU : IDataModel
    {
        #region members
        int id;
        string maNhom;
        string tenNhom;
        string ghiChu;
        string active;

        #endregion members
        #region Properties
        [PKSqlColumn("NhomVT_ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("MaNhom")]
        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
        [SqlColumn("TenNhom", SqlDbType.NVarChar)]
        public string TenNhom
        {
            get { return tenNhom; }
            set { tenNhom = value; }
        }
        [SqlColumn("GhiChu", SqlDbType.NVarChar)]
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        [SqlColumn("Active", SqlDbType.Char)]
        public string Active
        {
            get { return active; }
            set { active = value; }
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
        public DEV_IN_DM_NHOMVATTU() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public DEV_IN_DM_NHOMVATTU(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEV_IN_DM_NHOMVATTU> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEV_IN_DM_NHOMVATTU>("DEV_IN_DM_NHOMVATTU");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<DEV_IN_DM_NHOMVATTU>(this, "DEV_IN_DM_NHOMVATTU");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEV_IN_DM_NHOMVATTU",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEV_IN_DM_NHOMVATTU");
        }
        #endregion DAC Methods
    }
}
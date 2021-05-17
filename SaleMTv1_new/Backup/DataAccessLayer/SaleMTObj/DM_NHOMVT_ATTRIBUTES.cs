using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DM_NHOMVT_ATTRIBUTES
    {
        #region members
        string maNhom;
        string iD_PRODUCT_ATTRIBUTERS;
        bool? iS_VALUED;

        #endregion members
        #region Properties
        [PKSqlColumn("MaNhom", SqlDbType.VarChar, null)]
        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
        [PKSqlColumn("ID_PRODUCT_ATTRIBUTERS", SqlDbType.NVarChar, null)]
        public string ID_PRODUCT_ATTRIBUTERS
        {
            get { return iD_PRODUCT_ATTRIBUTERS; }
            set { iD_PRODUCT_ATTRIBUTERS = value; }
        }
        [SqlColumn("IS_VALUED", SqlDbType.Bit)]
        public bool? IS_VALUED
        {
            get { return iS_VALUED; }
            set { iS_VALUED = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DM_NHOMVT_ATTRIBUTES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DM_NHOMVT_ATTRIBUTES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DM_NHOMVT_ATTRIBUTES>("DM_NHOMVT_ATTRIBUTES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DM_NHOMVT_ATTRIBUTES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DM_NHOMVT_ATTRIBUTES");
        }
        #endregion DAC Methods
    }
}
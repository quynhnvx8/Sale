using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class RETURNS_PRODUCT_DETAIL
    {
        #region members
        Guid iD;
        string rETURNS_ID;
        string pRODUCT_ID;
        string p_ID;
        int? qUANTITY;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("RETURNS_ID")]
        public string RETURNS_ID
        {
            get { return rETURNS_ID; }
            set { rETURNS_ID = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [StringSqlColumn("P_ID")]
        public string P_ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public RETURNS_PRODUCT_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<RETURNS_PRODUCT_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<RETURNS_PRODUCT_DETAIL>("RETURNS_PRODUCT_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "RETURNS_PRODUCT_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "RETURNS_PRODUCT_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<RETURNS_PRODUCT_DETAIL> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<RETURNS_PRODUCT_DETAIL>("RETURNS_PRODUCT_DETAIL", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PERMISSION_INVENTORY
    {
        #region members
        Guid iD;
        string aCCOUNT;
        string sTORE_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
        public string ACCOUNT
        {
            get { return aCCOUNT; }
            set { aCCOUNT = value; }
        }
        [SqlColumn("STORE_CODE", SqlDbType.NVarChar)]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PERMISSION_INVENTORY() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PERMISSION_INVENTORY> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PERMISSION_INVENTORY>("PERMISSION_INVENTORY");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PERMISSION_INVENTORY",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PERMISSION_INVENTORY");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<PERMISSION_INVENTORY> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<PERMISSION_INVENTORY>("PERMISSION_INVENTORY", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}
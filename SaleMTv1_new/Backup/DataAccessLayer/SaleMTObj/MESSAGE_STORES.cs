using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MESSAGE_STORES
    {
        #region members
        Guid iD;
        DateTime iNPUT_DATE;
        string mESSAGE_ID;
        string sTORE_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("MESSAGE_ID", SqlDbType.NVarChar)]
        public string MESSAGE_ID
        {
            get { return mESSAGE_ID; }
            set { mESSAGE_ID = value; }
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
        public MESSAGE_STORES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MESSAGE_STORES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MESSAGE_STORES>("MESSAGE_STORES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MESSAGE_STORES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MESSAGE_STORES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<MESSAGE_STORES> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<MESSAGE_STORES>("MESSAGE_STORES", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

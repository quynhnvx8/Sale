using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class USER_CHAT
    {
        #region members
        Guid iD;
        string fROM_USER;
        string tO_USER;
        string cONTENT_MESS;
        DateTime? dATETIME_SENT;
        bool? iSREAD;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("FROM_USER", SqlDbType.NVarChar)]
        public string FROM_USER
        {
            get { return fROM_USER; }
            set { fROM_USER = value; }
        }
        [SqlColumn("TO_USER", SqlDbType.NVarChar)]
        public string TO_USER
        {
            get { return tO_USER; }
            set { tO_USER = value; }
        }
        [SqlColumn("CONTENT_MESS", SqlDbType.NVarChar)]
        public string CONTENT_MESS
        {
            get { return cONTENT_MESS; }
            set { cONTENT_MESS = value; }
        }
        [SqlColumn("DATETIME_SENT", SqlDbType.DateTime)]
        public DateTime? DATETIME_SENT
        {
            get { return dATETIME_SENT; }
            set { dATETIME_SENT = value; }
        }
        [SqlColumn("ISREAD", SqlDbType.Bit)]
        public bool? ISREAD
        {
            get { return iSREAD; }
            set { iSREAD = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public USER_CHAT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<USER_CHAT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<USER_CHAT>("USER_CHAT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "USER_CHAT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "USER_CHAT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<USER_CHAT> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<USER_CHAT>("USER_CHAT", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class UPDATE_SQL_SCRIPT
    {
        #region members
        Guid aUTO_ID;
        string fILE_NAME;
        bool? sTATUS_UPDATE;
        string qUERY_BUIDER;
        DateTime? cREATE_DATE;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [SqlColumn("FILE_NAME", SqlDbType.NVarChar)]
        public string FILE_NAME
        {
            get { return fILE_NAME; }
            set { fILE_NAME = value; }
        }
        [SqlColumn("STATUS_UPDATE", SqlDbType.Bit)]
        public bool? STATUS_UPDATE
        {
            get { return sTATUS_UPDATE; }
            set { sTATUS_UPDATE = value; }
        }
        [SqlColumn("QUERY_BUIDER", SqlDbType.NText)]
        public string QUERY_BUIDER
        {
            get { return qUERY_BUIDER; }
            set { qUERY_BUIDER = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public UPDATE_SQL_SCRIPT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<UPDATE_SQL_SCRIPT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<UPDATE_SQL_SCRIPT>("UPDATE_SQL_SCRIPT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "UPDATE_SQL_SCRIPT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "UPDATE_SQL_SCRIPT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<UPDATE_SQL_SCRIPT> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<UPDATE_SQL_SCRIPT>("UPDATE_SQL_SCRIPT", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

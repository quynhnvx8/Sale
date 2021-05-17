using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class UPDATE_SQL_SCRIPT_ERROR
    {
        #region members
        Guid aUTO_ID;
        string eRROR_TEXT;
        DateTime? dATE_EFFECT;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [SqlColumn("ERROR_TEXT", SqlDbType.NText)]
        public string ERROR_TEXT
        {
            get { return eRROR_TEXT; }
            set { eRROR_TEXT = value; }
        }
        [SqlColumn("DATE_EFFECT", SqlDbType.DateTime)]
        public DateTime? DATE_EFFECT
        {
            get { return dATE_EFFECT; }
            set { dATE_EFFECT = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public UPDATE_SQL_SCRIPT_ERROR() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<UPDATE_SQL_SCRIPT_ERROR> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<UPDATE_SQL_SCRIPT_ERROR>("UPDATE_SQL_SCRIPT_ERROR");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "UPDATE_SQL_SCRIPT_ERROR",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "UPDATE_SQL_SCRIPT_ERROR");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<UPDATE_SQL_SCRIPT_ERROR> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<UPDATE_SQL_SCRIPT_ERROR>("UPDATE_SQL_SCRIPT_ERROR", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

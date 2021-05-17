using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MEMBERS
    {
        #region members
        string aCCOUNT;
        string iDROLE;

        #endregion members
        #region Properties
        [PKSqlColumn("ACCOUNT", SqlDbType.NVarChar, null)]
        public string ACCOUNT
        {
            get { return aCCOUNT; }
            set { aCCOUNT = value; }
        }
        [PKSqlColumn("IDROLE", SqlDbType.VarChar, null)]
        public string IDROLE
        {
            get { return iDROLE; }
            set { iDROLE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MEMBERS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MEMBERS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MEMBERS>("MEMBERS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MEMBERS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MEMBERS");
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class ROLES
    {
        #region members
        string iDROLE;
        string dESCRIPTION;

        #endregion members
        #region Properties
        [PKSqlColumn("IDROLE", SqlDbType.VarChar, null)]
        public string IDROLE
        {
            get { return iDROLE; }
            set { iDROLE = value; }
        }
        [SqlColumn("DESCRIPTION", SqlDbType.NVarChar)]
        public string DESCRIPTION
        {
            get { return dESCRIPTION; }
            set { dESCRIPTION = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public ROLES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<ROLES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<ROLES>("ROLES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "ROLES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "ROLES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inIDROLE"></param>
        public static List<ROLES> ReadByIDROLE(string inIDROLE)
        {
            return posdb_vnmSqlDAC.ReadByParams<ROLES>("ROLES", posdb_vnmSqlDAC.newInParam("@IDROLE", inIDROLE));
        }
        #endregion DAC Methods
    }
}

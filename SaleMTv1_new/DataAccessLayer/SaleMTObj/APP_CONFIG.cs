using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class APP_CONFIG
    {
        #region members
        string nAME;
        string pARAMETER;
        string rEMARK;

        #endregion members
        #region Properties
        [PKSqlColumn("NAME", SqlDbType.NVarChar, null)]
        public string NAME
        {
            get { return nAME; }
            set { nAME = value; }
        }
        [SqlColumn("PARAMETER", SqlDbType.NVarChar)]
        public string PARAMETER
        {
            get { return pARAMETER; }
            set { pARAMETER = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public APP_CONFIG() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<APP_CONFIG> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<APP_CONFIG>("APP_CONFIG");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "APP_CONFIG", isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "APP_CONFIG");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inNAME"></param>
        public static List<APP_CONFIG> ReadByNAME(string inNAME)
        {
            return posdb_vnmSqlDAC.ReadByParams<APP_CONFIG>("APP_CONFIG", posdb_vnmSqlDAC.newInParam("@NAME", inNAME));
        }
        #endregion DAC Methods
    }
}

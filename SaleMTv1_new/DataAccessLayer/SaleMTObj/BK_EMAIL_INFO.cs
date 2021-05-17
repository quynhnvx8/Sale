using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class BK_EMAIL_INFO
    {
        #region members
        string eMAIL_ADDRESS;
        string pASSWORD;

        #endregion members
        #region Properties
        [PKSqlColumn("EMAIL_ADDRESS", SqlDbType.VarChar, null)]
        public string EMAIL_ADDRESS
        {
            get { return eMAIL_ADDRESS; }
            set { eMAIL_ADDRESS = value; }
        }
        [StringSqlColumn("PASSWORD")]
        public string PASSWORD
        {
            get { return pASSWORD; }
            set { pASSWORD = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public BK_EMAIL_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<BK_EMAIL_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<BK_EMAIL_INFO>("BK_EMAIL_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "BK_EMAIL_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "BK_EMAIL_INFO");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inEMAIL_ADDRESS"></param>
        public static List<BK_EMAIL_INFO> ReadByEMAIL_ADDRESS(string inEMAIL_ADDRESS)
        {
            return posdb_vnmSqlDAC.ReadByParams<BK_EMAIL_INFO>("BK_EMAIL_INFO", posdb_vnmSqlDAC.newInParam("@EMAIL_ADDRESS", inEMAIL_ADDRESS));
        }
        #endregion DAC Methods
    }
}

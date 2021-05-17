using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class POLICIES
    {
        #region members
        string pOLICY_ID;
        string pOLICY_NAME;
        int? pRIORITY;
        bool? iS_TOTAL;

        #endregion members
        #region Properties
        [PKSqlColumn("POLICY_ID", SqlDbType.VarChar, null)]
        public string POLICY_ID
        {
            get { return pOLICY_ID; }
            set { pOLICY_ID = value; }
        }
        [SqlColumn("POLICY_NAME", SqlDbType.NVarChar)]
        public string POLICY_NAME
        {
            get { return pOLICY_NAME; }
            set { pOLICY_NAME = value; }
        }
        [SqlColumn("PRIORITY", SqlDbType.Int)]
        public int? PRIORITY
        {
            get { return pRIORITY; }
            set { pRIORITY = value; }
        }
        [SqlColumn("IS_TOTAL", SqlDbType.Bit)]
        public bool? IS_TOTAL
        {
            get { return iS_TOTAL; }
            set { iS_TOTAL = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public POLICIES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<POLICIES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<POLICIES>("POLICIES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "POLICIES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "POLICIES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inPOLICY_ID"></param>
        public static List<POLICIES> ReadByPOLICY_ID(string inPOLICY_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<POLICIES>("POLICIES", posdb_vnmSqlDAC.newInParam("@POLICY_ID", inPOLICY_ID));
        }
        #endregion DAC Methods
    }
}

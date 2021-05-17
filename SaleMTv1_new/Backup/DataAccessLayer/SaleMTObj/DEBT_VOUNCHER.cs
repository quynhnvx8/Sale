using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEBT_VOUNCHER
    {
        #region members
        Guid iD;
        string oRDER_ID;
        string hOST_ID;
        string cLIENT_ID;
        bool? iS_ROOT;
        float? tOTAL_MONEY;
        string cURRENCY_ID;
        float? eXCHANGE_RATE;
        DateTime? dATE_CREATE;
        int? dEBT_TYPE;
        string oRDER_BY;
        int? sTATUS;
        bool? iS_FIRST_AMOUNT;
        string rEMARK;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("ORDER_ID")]
        public string ORDER_ID
        {
            get { return oRDER_ID; }
            set { oRDER_ID = value; }
        }
        [StringSqlColumn("HOST_ID")]
        public string HOST_ID
        {
            get { return hOST_ID; }
            set { hOST_ID = value; }
        }
        [StringSqlColumn("CLIENT_ID")]
        public string CLIENT_ID
        {
            get { return cLIENT_ID; }
            set { cLIENT_ID = value; }
        }
        [SqlColumn("IS_ROOT", SqlDbType.Bit)]
        public bool? IS_ROOT
        {
            get { return iS_ROOT; }
            set { iS_ROOT = value; }
        }
        [SqlColumn("TOTAL_MONEY", SqlDbType.Float)]
        public float? TOTAL_MONEY
        {
            get { return tOTAL_MONEY; }
            set { tOTAL_MONEY = value; }
        }
        [StringSqlColumn("CURRENCY_ID")]
        public string CURRENCY_ID
        {
            get { return cURRENCY_ID; }
            set { cURRENCY_ID = value; }
        }
        [SqlColumn("EXCHANGE_RATE", SqlDbType.Float)]
        public float? EXCHANGE_RATE
        {
            get { return eXCHANGE_RATE; }
            set { eXCHANGE_RATE = value; }
        }
        [SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
        public DateTime? DATE_CREATE
        {
            get { return dATE_CREATE; }
            set { dATE_CREATE = value; }
        }
        [SqlColumn("DEBT_TYPE", SqlDbType.Int)]
        public int? DEBT_TYPE
        {
            get { return dEBT_TYPE; }
            set { dEBT_TYPE = value; }
        }
        [StringSqlColumn("ORDER_BY")]
        public string ORDER_BY
        {
            get { return oRDER_BY; }
            set { oRDER_BY = value; }
        }
        [SqlColumn("STATUS", SqlDbType.Int)]
        public int? STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [SqlColumn("IS_FIRST_AMOUNT", SqlDbType.Bit)]
        public bool? IS_FIRST_AMOUNT
        {
            get { return iS_FIRST_AMOUNT; }
            set { iS_FIRST_AMOUNT = value; }
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
        public DEBT_VOUNCHER() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEBT_VOUNCHER> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEBT_VOUNCHER>("DEBT_VOUNCHER");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEBT_VOUNCHER",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEBT_VOUNCHER");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<DEBT_VOUNCHER> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<DEBT_VOUNCHER>("DEBT_VOUNCHER", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

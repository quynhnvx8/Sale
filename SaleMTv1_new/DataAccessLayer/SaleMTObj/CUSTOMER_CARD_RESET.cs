using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CUSTOMER_CARD_RESET
    {
        #region members
        Guid iD;
        string cARD_NO;
        DateTime? iSSUE_DATE;
        DateTime? eXPIRATION_DATE;
        bool? iS_USED;
        string cUSTOMER_ID;
        string cUSTOMER_TYPE_CODE;
        string rEMARK;
        string cREATE_BY;
        DateTime? cREATE_DATE;
        int? dEPT_CODE;
        string rEASON_NOT_USED;
        string sTORE_CODE;
        Guid rowguid;
        int? nUMBER_MARK;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("CARD_NO")]
        public string CARD_NO
        {
            get { return cARD_NO; }
            set { cARD_NO = value; }
        }
        [SqlColumn("ISSUE_DATE", SqlDbType.DateTime)]
        public DateTime? ISSUE_DATE
        {
            get { return iSSUE_DATE; }
            set { iSSUE_DATE = value; }
        }
        [SqlColumn("EXPIRATION_DATE", SqlDbType.DateTime)]
        public DateTime? EXPIRATION_DATE
        {
            get { return eXPIRATION_DATE; }
            set { eXPIRATION_DATE = value; }
        }
        [SqlColumn("IS_USED", SqlDbType.Bit)]
        public bool? IS_USED
        {
            get { return iS_USED; }
            set { iS_USED = value; }
        }
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [StringSqlColumn("CUSTOMER_TYPE_CODE")]
        public string CUSTOMER_TYPE_CODE
        {
            get { return cUSTOMER_TYPE_CODE; }
            set { cUSTOMER_TYPE_CODE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
        public string CREATE_BY
        {
            get { return cREATE_BY; }
            set { cREATE_BY = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("DEPT_CODE", SqlDbType.Int)]
        public int? DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }
        [SqlColumn("REASON_NOT_USED", SqlDbType.NVarChar)]
        public string REASON_NOT_USED
        {
            get { return rEASON_NOT_USED; }
            set { rEASON_NOT_USED = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("rowguid", SqlDbType.UniqueIdentifier)]
        public Guid Rowguid
        {
            get { return rowguid; }
            set { rowguid = value; }
        }
        [SqlColumn("NUMBER_MARK", SqlDbType.Int)]
        public int? NUMBER_MARK
        {
            get { return nUMBER_MARK; }
            set { nUMBER_MARK = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CUSTOMER_CARD_RESET() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CUSTOMER_CARD_RESET> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CUSTOMER_CARD_RESET>("CUSTOMER_CARD_RESET");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CUSTOMER_CARD_RESET",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CUSTOMER_CARD_RESET");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<CUSTOMER_CARD_RESET> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<CUSTOMER_CARD_RESET>("CUSTOMER_CARD_RESET", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inrowguid"></param>
        public static List<CUSTOMER_CARD_RESET> ReadByrowguid(Guid inrowguid)
        {
            return posdb_vnmSqlDAC.ReadByParams<CUSTOMER_CARD_RESET>("CUSTOMER_CARD_RESET", posdb_vnmSqlDAC.newInParam("@rowguid", inrowguid));
        }
        #endregion DAC Methods
    }
}

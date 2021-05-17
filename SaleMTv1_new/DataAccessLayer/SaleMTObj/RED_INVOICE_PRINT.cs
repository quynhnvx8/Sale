using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class RED_INVOICE_PRINT
    {
        #region members
        Guid aUTO_ID;
        string oFFICE_WORKING;
        string oFFICE_ADDRESS;
        string tAX_CODE;
        string iNVOICE_INFO;
        int? tOTAL_QUANTITY;
        decimal? tOTAL_MONEY;
        string eVENT_ID;
        DateTime? pRINT_DATE;
        DateTime? cREATE_DATE;
        string uSER_CREATE;
        string rEMARKS;
        string cUSTOMER_ID;
        string pAYMENT_TYPE;
        string lIST_INVOICE;
        string iNVOICE_NO;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [SqlColumn("OFFICE_WORKING", SqlDbType.NVarChar)]
        public string OFFICE_WORKING
        {
            get { return oFFICE_WORKING; }
            set { oFFICE_WORKING = value; }
        }
        [SqlColumn("OFFICE_ADDRESS", SqlDbType.NVarChar)]
        public string OFFICE_ADDRESS
        {
            get { return oFFICE_ADDRESS; }
            set { oFFICE_ADDRESS = value; }
        }
        [StringSqlColumn("TAX_CODE")]
        public string TAX_CODE
        {
            get { return tAX_CODE; }
            set { tAX_CODE = value; }
        }
        [SqlColumn("INVOICE_INFO", SqlDbType.NText)]
        public string INVOICE_INFO
        {
            get { return iNVOICE_INFO; }
            set { iNVOICE_INFO = value; }
        }
        [SqlColumn("TOTAL_QUANTITY", SqlDbType.Int)]
        public int? TOTAL_QUANTITY
        {
            get { return tOTAL_QUANTITY; }
            set { tOTAL_QUANTITY = value; }
        }
        [SqlColumn("TOTAL_MONEY", SqlDbType.Decimal)]
        public decimal? TOTAL_MONEY
        {
            get { return tOTAL_MONEY; }
            set { tOTAL_MONEY = value; }
        }
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("PRINT_DATE", SqlDbType.DateTime)]
        public DateTime? PRINT_DATE
        {
            get { return pRINT_DATE; }
            set { pRINT_DATE = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("USER_CREATE", SqlDbType.NVarChar)]
        public string USER_CREATE
        {
            get { return uSER_CREATE; }
            set { uSER_CREATE = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [StringSqlColumn("PAYMENT_TYPE")]
        public string PAYMENT_TYPE
        {
            get { return pAYMENT_TYPE; }
            set { pAYMENT_TYPE = value; }
        }
        [SqlColumn("LIST_INVOICE", SqlDbType.NVarChar)]
        public string LIST_INVOICE
        {
            get { return lIST_INVOICE; }
            set { lIST_INVOICE = value; }
        }
        [StringSqlColumn("INVOICE_NO")]
        public string INVOICE_NO
        {
            get { return iNVOICE_NO; }
            set { iNVOICE_NO = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public RED_INVOICE_PRINT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<RED_INVOICE_PRINT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<RED_INVOICE_PRINT>("RED_INVOICE_PRINT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "RED_INVOICE_PRINT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "RED_INVOICE_PRINT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<RED_INVOICE_PRINT> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<RED_INVOICE_PRINT>("RED_INVOICE_PRINT", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

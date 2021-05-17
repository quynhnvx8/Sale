using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class SALES_PAYMENT_HISTORY
    {
        #region members
        Guid aUTO_ID;
        string eXPORT_CODE;
        DateTime pAYING_DATE;
        int? pAYING_TIMES;
        DateTime? dELIVERY_DATE;
        string dELIVERY_ADDRESS;
        string dELIVERY_METHOD;
        DateTime? nEXT_PAYING_DUE_DATE;
        float aMOUNT;
        float bALANCE;
        string rEMARK;
        string cASHIER_ACCOUNT;
        string eVENT_ID;
        float? tOTAL_RECEIVED;
        float? rEFUND;
        string tRANSFER_SHIFT_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [StringSqlColumn("EXPORT_CODE")]
        public string EXPORT_CODE
        {
            get { return eXPORT_CODE; }
            set { eXPORT_CODE = value; }
        }
        [SqlColumn("PAYING_DATE", SqlDbType.DateTime)]
        public DateTime PAYING_DATE
        {
            get { return pAYING_DATE; }
            set { pAYING_DATE = value; }
        }
        [SqlColumn("PAYING_TIMES", SqlDbType.Int)]
        public int? PAYING_TIMES
        {
            get { return pAYING_TIMES; }
            set { pAYING_TIMES = value; }
        }
        [SqlColumn("DELIVERY_DATE", SqlDbType.DateTime)]
        public DateTime? DELIVERY_DATE
        {
            get { return dELIVERY_DATE; }
            set { dELIVERY_DATE = value; }
        }
        [SqlColumn("DELIVERY_ADDRESS", SqlDbType.NVarChar)]
        public string DELIVERY_ADDRESS
        {
            get { return dELIVERY_ADDRESS; }
            set { dELIVERY_ADDRESS = value; }
        }
        [StringSqlColumn("DELIVERY_METHOD")]
        public string DELIVERY_METHOD
        {
            get { return dELIVERY_METHOD; }
            set { dELIVERY_METHOD = value; }
        }
        [SqlColumn("NEXT_PAYING_DUE_DATE", SqlDbType.DateTime)]
        public DateTime? NEXT_PAYING_DUE_DATE
        {
            get { return nEXT_PAYING_DUE_DATE; }
            set { nEXT_PAYING_DUE_DATE = value; }
        }
        [SqlColumn("AMOUNT", SqlDbType.Float)]
        public float AMOUNT
        {
            get { return aMOUNT; }
            set { aMOUNT = value; }
        }
        [SqlColumn("BALANCE", SqlDbType.Float)]
        public float BALANCE
        {
            get { return bALANCE; }
            set { bALANCE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("CASHIER_ACCOUNT", SqlDbType.NVarChar)]
        public string CASHIER_ACCOUNT
        {
            get { return cASHIER_ACCOUNT; }
            set { cASHIER_ACCOUNT = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("TOTAL_RECEIVED", SqlDbType.Float)]
        public float? TOTAL_RECEIVED
        {
            get { return tOTAL_RECEIVED; }
            set { tOTAL_RECEIVED = value; }
        }
        [SqlColumn("REFUND", SqlDbType.Float)]
        public float? REFUND
        {
            get { return rEFUND; }
            set { rEFUND = value; }
        }
        [StringSqlColumn("TRANSFER_SHIFT_CODE")]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public SALES_PAYMENT_HISTORY() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<SALES_PAYMENT_HISTORY> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<SALES_PAYMENT_HISTORY>("SALES_PAYMENT_HISTORY");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "SALES_PAYMENT_HISTORY",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "SALES_PAYMENT_HISTORY");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<SALES_PAYMENT_HISTORY> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY>("SALES_PAYMENT_HISTORY", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inDELIVERY_METHOD"></param>
        public static List<SALES_PAYMENT_HISTORY> ReadByDELIVERY_METHOD(string inDELIVERY_METHOD)
        {
            object parameter = inDELIVERY_METHOD ?? string.Empty;
            return posdb_vnmSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY>("SALES_PAYMENT_HISTORY", posdb_vnmSqlDAC.newInParam("@DELIVERY_METHOD", parameter));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inCASHIER_ACCOUNT"></param>
        public static List<SALES_PAYMENT_HISTORY> ReadByCASHIER_ACCOUNT(string inCASHIER_ACCOUNT)
        {
            return posdb_vnmSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY>("SALES_PAYMENT_HISTORY", posdb_vnmSqlDAC.newInParam("@CASHIER_ACCOUNT", inCASHIER_ACCOUNT));
        }
        #endregion DAC Methods
    }
}

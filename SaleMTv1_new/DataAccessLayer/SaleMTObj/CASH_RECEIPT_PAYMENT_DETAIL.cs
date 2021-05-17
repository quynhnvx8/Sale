using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CASH_RECEIPT_PAYMENT_DETAIL
    {
        #region members
        Guid rECEIPT_PAYMENT_DETAIL_ID;
        string hOST_ID;
        string cLIENT_ID;
        string rECEIPT_PAYMENT_DETAIL_CODE;
        int? cASH_TYPE;
        float? aMOUNT;
        string cURRENCY_ID;
        float? eXCHANGE_RATE;
        string rECEIPT_FROM_PAYMENT_TO;
        DateTime? cREATED_DATE;
        string cREATED_BY;
        DateTime? iNPUT_DATE;
        string iNPUT_BY;
        string rEASON;
        string rEMARK;

        #endregion members
        #region Properties
        [PKSqlColumn("RECEIPT_PAYMENT_DETAIL_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid RECEIPT_PAYMENT_DETAIL_ID
        {
            get { return rECEIPT_PAYMENT_DETAIL_ID; }
            set { rECEIPT_PAYMENT_DETAIL_ID = value; }
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
        [StringSqlColumn("RECEIPT_PAYMENT_DETAIL_CODE")]
        public string RECEIPT_PAYMENT_DETAIL_CODE
        {
            get { return rECEIPT_PAYMENT_DETAIL_CODE; }
            set { rECEIPT_PAYMENT_DETAIL_CODE = value; }
        }
        [SqlColumn("CASH_TYPE", SqlDbType.Int)]
        public int? CASH_TYPE
        {
            get { return cASH_TYPE; }
            set { cASH_TYPE = value; }
        }
        [SqlColumn("AMOUNT", SqlDbType.Float)]
        public float? AMOUNT
        {
            get { return aMOUNT; }
            set { aMOUNT = value; }
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
        [SqlColumn("RECEIPT_FROM_PAYMENT_TO", SqlDbType.NVarChar)]
        public string RECEIPT_FROM_PAYMENT_TO
        {
            get { return rECEIPT_FROM_PAYMENT_TO; }
            set { rECEIPT_FROM_PAYMENT_TO = value; }
        }
        [SqlColumn("CREATED_DATE", SqlDbType.DateTime)]
        public DateTime? CREATED_DATE
        {
            get { return cREATED_DATE; }
            set { cREATED_DATE = value; }
        }
        [StringSqlColumn("CREATED_BY")]
        public string CREATED_BY
        {
            get { return cREATED_BY; }
            set { cREATED_BY = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime? INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [StringSqlColumn("INPUT_BY")]
        public string INPUT_BY
        {
            get { return iNPUT_BY; }
            set { iNPUT_BY = value; }
        }
        [SqlColumn("REASON", SqlDbType.NVarChar)]
        public string REASON
        {
            get { return rEASON; }
            set { rEASON = value; }
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
        public CASH_RECEIPT_PAYMENT_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CASH_RECEIPT_PAYMENT_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CASH_RECEIPT_PAYMENT_DETAIL>("CASH_RECEIPT_PAYMENT_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CASH_RECEIPT_PAYMENT_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CASH_RECEIPT_PAYMENT_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inRECEIPT_PAYMENT_DETAIL_ID"></param>
        public static List<CASH_RECEIPT_PAYMENT_DETAIL> ReadByRECEIPT_PAYMENT_DETAIL_ID(Guid inRECEIPT_PAYMENT_DETAIL_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<CASH_RECEIPT_PAYMENT_DETAIL>("CASH_RECEIPT_PAYMENT_DETAIL", posdb_vnmSqlDAC.newInParam("@RECEIPT_PAYMENT_DETAIL_ID", inRECEIPT_PAYMENT_DETAIL_ID));
        }
        #endregion DAC Methods
    }

}
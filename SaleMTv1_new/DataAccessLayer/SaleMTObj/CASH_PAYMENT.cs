using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CASH_PAYMENT
    {
        #region members
        string cASH_PAYMENT_ID;
        int dEPT_CODE;
        string cASH_TYPE_CODE;
        string cASH_TYPE_OTHER;
        string cASH_PAYMENT_TO;
        string cURRENCY_ID;
        float aMOUNT;
        DateTime dATE_PAYMENT;
        string eMPLOYEE_ID;
        string rEMARK;
        string eVENT_ID;
        string tRANSFER_SHIFT_CODE;
        float? eXCHANGE_RATE;

        #endregion members
        #region Properties
        [PKSqlColumn("CASH_PAYMENT_ID", SqlDbType.VarChar, null)]
        public string CASH_PAYMENT_ID
        {
            get { return cASH_PAYMENT_ID; }
            set { cASH_PAYMENT_ID = value; }
        }
        [SqlColumn("DEPT_CODE", SqlDbType.Int)]
        public int DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }
        [StringSqlColumn("CASH_TYPE_CODE")]
        public string CASH_TYPE_CODE
        {
            get { return cASH_TYPE_CODE; }
            set { cASH_TYPE_CODE = value; }
        }
        [SqlColumn("CASH_TYPE_OTHER", SqlDbType.NVarChar)]
        public string CASH_TYPE_OTHER
        {
            get { return cASH_TYPE_OTHER; }
            set { cASH_TYPE_OTHER = value; }
        }
        [SqlColumn("CASH_PAYMENT_TO", SqlDbType.NVarChar)]
        public string CASH_PAYMENT_TO
        {
            get { return cASH_PAYMENT_TO; }
            set { cASH_PAYMENT_TO = value; }
        }
        [StringSqlColumn("CURRENCY_ID")]
        public string CURRENCY_ID
        {
            get { return cURRENCY_ID; }
            set { cURRENCY_ID = value; }
        }
        [SqlColumn("AMOUNT", SqlDbType.Float)]
        public float AMOUNT
        {
            get { return aMOUNT; }
            set { aMOUNT = value; }
        }
        [SqlColumn("DATE_PAYMENT", SqlDbType.DateTime)]
        public DateTime DATE_PAYMENT
        {
            get { return dATE_PAYMENT; }
            set { dATE_PAYMENT = value; }
        }
        [StringSqlColumn("EMPLOYEE_ID")]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [StringSqlColumn("TRANSFER_SHIFT_CODE")]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
        }
        [SqlColumn("EXCHANGE_RATE", SqlDbType.Float)]
        public float? EXCHANGE_RATE
        {
            get { return eXCHANGE_RATE; }
            set { eXCHANGE_RATE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CASH_PAYMENT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CASH_PAYMENT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CASH_PAYMENT>("CASH_PAYMENT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CASH_PAYMENT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CASH_PAYMENT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inCASH_PAYMENT_ID"></param>
        public static List<CASH_PAYMENT> ReadByCASH_PAYMENT_ID(string inCASH_PAYMENT_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<CASH_PAYMENT>("CASH_PAYMENT", posdb_vnmSqlDAC.newInParam("@CASH_PAYMENT_ID", inCASH_PAYMENT_ID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inTRANSFER_SHIFT_CODE"></param>
        public static List<CASH_PAYMENT> ReadByTRANSFER_SHIFT_CODE(string inTRANSFER_SHIFT_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<CASH_PAYMENT>("CASH_PAYMENT", posdb_vnmSqlDAC.newInParam("@TRANSFER_SHIFT_CODE", inTRANSFER_SHIFT_CODE));
        }
        #endregion DAC Methods
    }
}

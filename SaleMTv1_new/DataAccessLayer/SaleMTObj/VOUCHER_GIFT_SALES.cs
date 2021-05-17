using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class VOUCHER_GIFT_SALES
    {
        #region members
        string iNVOICE_ID;
        string cUSTOMER_ID;
        string eMPLOYEE_ID;
        string sTORE_CODE;
        string aCCOUNT;
        DateTime? sALE_DATE;
        DateTime? iNPUT_DATE;
        string rEMARK;
        string eVENT_ID;
        float? tOTAL_AMOUNT;
        string tRANSFER_SHIFT_CODE;
        string iNVOICE_CODE_SALES;

        #endregion members
        #region Properties
        [PKSqlColumn("INVOICE_ID", SqlDbType.VarChar, null)]
        public string INVOICE_ID
        {
            get { return iNVOICE_ID; }
            set { iNVOICE_ID = value; }
        }
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [StringSqlColumn("EMPLOYEE_ID")]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
        public string ACCOUNT
        {
            get { return aCCOUNT; }
            set { aCCOUNT = value; }
        }
        [SqlColumn("SALE_DATE", SqlDbType.DateTime)]
        public DateTime? SALE_DATE
        {
            get { return sALE_DATE; }
            set { sALE_DATE = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime? INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
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
        [SqlColumn("TOTAL_AMOUNT", SqlDbType.Float)]
        public float? TOTAL_AMOUNT
        {
            get { return tOTAL_AMOUNT; }
            set { tOTAL_AMOUNT = value; }
        }
        [SqlColumn("TRANSFER_SHIFT_CODE", SqlDbType.NVarChar)]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
        }
        [SqlColumn("INVOICE_CODE_SALES", SqlDbType.NVarChar)]
        public string INVOICE_CODE_SALES
        {
            get { return iNVOICE_CODE_SALES; }
            set { iNVOICE_CODE_SALES = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public VOUCHER_GIFT_SALES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<VOUCHER_GIFT_SALES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<VOUCHER_GIFT_SALES>("VOUCHER_GIFT_SALES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "VOUCHER_GIFT_SALES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "VOUCHER_GIFT_SALES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inINVOICE_ID"></param>
        public static List<VOUCHER_GIFT_SALES> ReadByINVOICE_ID(string inINVOICE_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<VOUCHER_GIFT_SALES>("VOUCHER_GIFT_SALES", posdb_vnmSqlDAC.newInParam("@INVOICE_ID", inINVOICE_ID));
        }
        #endregion DAC Methods
    }
}
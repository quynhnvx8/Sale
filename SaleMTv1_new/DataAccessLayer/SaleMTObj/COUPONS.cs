using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class COUPONS
    {
        #region members
        string cOUPON_NO;
        string vOUCHER_NO;
        float? cOUPON_PERCENT;
        float? cOUPON_AMOUNT;
        string cOUPON_STATUS;
        string cUSTOMER_ID;
        string fOR_PRODUCTS;
        string rEASON_NOT_USED;
        string sTORE_CODE_USED;
        string sTORE_CODE;
        string eXPORT_CODE;
        bool? iS_EXPORTING;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("COUPON_NO", SqlDbType.VarChar, null)]
        public string COUPON_NO
        {
            get { return cOUPON_NO; }
            set { cOUPON_NO = value; }
        }
        [StringSqlColumn("VOUCHER_NO")]
        public string VOUCHER_NO
        {
            get { return vOUCHER_NO; }
            set { vOUCHER_NO = value; }
        }
        [SqlColumn("COUPON_PERCENT", SqlDbType.Float)]
        public float? COUPON_PERCENT
        {
            get { return cOUPON_PERCENT; }
            set { cOUPON_PERCENT = value; }
        }
        [SqlColumn("COUPON_AMOUNT", SqlDbType.Float)]
        public float? COUPON_AMOUNT
        {
            get { return cOUPON_AMOUNT; }
            set { cOUPON_AMOUNT = value; }
        }
        [StringSqlColumn("COUPON_STATUS")]
        public string COUPON_STATUS
        {
            get { return cOUPON_STATUS; }
            set { cOUPON_STATUS = value; }
        }
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [StringSqlColumn("FOR_PRODUCTS")]
        public string FOR_PRODUCTS
        {
            get { return fOR_PRODUCTS; }
            set { fOR_PRODUCTS = value; }
        }
        [SqlColumn("REASON_NOT_USED", SqlDbType.NVarChar)]
        public string REASON_NOT_USED
        {
            get { return rEASON_NOT_USED; }
            set { rEASON_NOT_USED = value; }
        }
        [StringSqlColumn("STORE_CODE_USED")]
        public string STORE_CODE_USED
        {
            get { return sTORE_CODE_USED; }
            set { sTORE_CODE_USED = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [StringSqlColumn("EXPORT_CODE")]
        public string EXPORT_CODE
        {
            get { return eXPORT_CODE; }
            set { eXPORT_CODE = value; }
        }
        [SqlColumn("IS_EXPORTING", SqlDbType.Bit)]
        public bool? IS_EXPORTING
        {
            get { return iS_EXPORTING; }
            set { iS_EXPORTING = value; }
        }
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public COUPONS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<COUPONS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<COUPONS>("COUPONS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "COUPONS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "COUPONS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inCOUPON_NO"></param>
        public static List<COUPONS> ReadByCOUPON_NO(string inCOUPON_NO)
        {
            return posdb_vnmSqlDAC.ReadByParams<COUPONS>("COUPONS", posdb_vnmSqlDAC.newInParam("@COUPON_NO", inCOUPON_NO));
        }
        #endregion DAC Methods
    }
}
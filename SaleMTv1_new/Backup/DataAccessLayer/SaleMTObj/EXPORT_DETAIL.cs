using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXPORT_DETAIL
    {
        #region members
        Guid iD;
        string iNVOICE_CODE;
        string pRODUCT_ID;
        string p_ID;
        float pRODUCT_PRICE;
        int qUANTITY;
        string eVENT_ID;
        float? dISCOUNT;
        string dISCOUNT_TYPE;
        float? tOTAL_PRICE;
        float? uNIT_PRICE;
        string saleOrderNumber;
        float? pRODUCT_PRICE_VAT;
        float? pRICE_SALE;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("INVOICE_CODE")]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [StringSqlColumn("P_ID")]
        public string P_ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }
        [SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
        public float PRODUCT_PRICE
        {
            get { return pRODUCT_PRICE; }
            set { pRODUCT_PRICE = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("DISCOUNT", SqlDbType.Float)]
        public float? DISCOUNT
        {
            get { return dISCOUNT; }
            set { dISCOUNT = value; }
        }
        [StringSqlColumn("DISCOUNT_TYPE")]
        public string DISCOUNT_TYPE
        {
            get { return dISCOUNT_TYPE; }
            set { dISCOUNT_TYPE = value; }
        }
        [SqlColumn("TOTAL_PRICE", SqlDbType.Float)]
        public float? TOTAL_PRICE
        {
            get { return tOTAL_PRICE; }
            set { tOTAL_PRICE = value; }
        }
        [SqlColumn("UNIT_PRICE", SqlDbType.Float)]
        public float? UNIT_PRICE
        {
            get { return uNIT_PRICE; }
            set { uNIT_PRICE = value; }
        }
        [StringSqlColumn("SaleOrderNumber")]
        public string SaleOrderNumber
        {
            get { return saleOrderNumber; }
            set { saleOrderNumber = value; }
        }
        [SqlColumn("PRODUCT_PRICE_VAT", SqlDbType.Float)]
        public float? PRODUCT_PRICE_VAT
        {
            get { return pRODUCT_PRICE_VAT; }
            set { pRODUCT_PRICE_VAT = value; }
        }
        [SqlColumn("PRICE_SALE", SqlDbType.Float)]
        public float? PRICE_SALE
        {
            get { return pRICE_SALE; }
            set { pRICE_SALE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public EXPORT_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXPORT_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXPORT_DETAIL>("EXPORT_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXPORT_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXPORT_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<EXPORT_DETAIL> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_DETAIL>("EXPORT_DETAIL", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

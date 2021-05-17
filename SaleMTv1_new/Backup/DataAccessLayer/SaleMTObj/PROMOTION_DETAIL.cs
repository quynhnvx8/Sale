using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PROMOTION_DETAIL
    {
        #region members
        string pROMOTION_DETAIL_NO;
        string pROMOTION_NO;
        string gROUP_TYPE;
        int qUANTITY_MIN;
        int qUANTITY_MAX;
        float aMOUNT_MIN;
        float aMOUNT_MAX;
        int qUANTITY_BUY;
        int? qUANTITY_DISCOUNT;
        bool? iS_USED_VALUE;
        string dISCOUNT_ON;
        float? dISCOUNT_VALUE;
        string oTHER_VALUE;
        string gIFT;
        int? qUANTITY_GIFT;
        string gIFT_TWO;
        int? qUANTITY_GIFT_TWO;
        int? nUMBER_MARK;
        string sTATUS;
        string rEASON_NOT_USED;
        string fOR_PRODUCTS;
        string pROMOTION_DETAIL_NAME;

        #endregion members
        #region Properties
        [PKSqlColumn("PROMOTION_DETAIL_NO", SqlDbType.VarChar, null)]
        public string PROMOTION_DETAIL_NO
        {
            get { return pROMOTION_DETAIL_NO; }
            set { pROMOTION_DETAIL_NO = value; }
        }
        [StringSqlColumn("PROMOTION_NO")]
        public string PROMOTION_NO
        {
            get { return pROMOTION_NO; }
            set { pROMOTION_NO = value; }
        }
        [StringSqlColumn("GROUP_TYPE")]
        public string GROUP_TYPE
        {
            get { return gROUP_TYPE; }
            set { gROUP_TYPE = value; }
        }
        [SqlColumn("QUANTITY_MIN", SqlDbType.Int)]
        public int QUANTITY_MIN
        {
            get { return qUANTITY_MIN; }
            set { qUANTITY_MIN = value; }
        }
        [SqlColumn("QUANTITY_MAX", SqlDbType.Int)]
        public int QUANTITY_MAX
        {
            get { return qUANTITY_MAX; }
            set { qUANTITY_MAX = value; }
        }
        [SqlColumn("AMOUNT_MIN", SqlDbType.Float)]
        public float AMOUNT_MIN
        {
            get { return aMOUNT_MIN; }
            set { aMOUNT_MIN = value; }
        }
        [SqlColumn("AMOUNT_MAX", SqlDbType.Float)]
        public float AMOUNT_MAX
        {
            get { return aMOUNT_MAX; }
            set { aMOUNT_MAX = value; }
        }
        [SqlColumn("QUANTITY_BUY", SqlDbType.Int)]
        public int QUANTITY_BUY
        {
            get { return qUANTITY_BUY; }
            set { qUANTITY_BUY = value; }
        }
        [SqlColumn("QUANTITY_DISCOUNT", SqlDbType.Int)]
        public int? QUANTITY_DISCOUNT
        {
            get { return qUANTITY_DISCOUNT; }
            set { qUANTITY_DISCOUNT = value; }
        }
        [SqlColumn("IS_USED_VALUE", SqlDbType.Bit)]
        public bool? IS_USED_VALUE
        {
            get { return iS_USED_VALUE; }
            set { iS_USED_VALUE = value; }
        }
        [StringSqlColumn("DISCOUNT_ON")]
        public string DISCOUNT_ON
        {
            get { return dISCOUNT_ON; }
            set { dISCOUNT_ON = value; }
        }
        [SqlColumn("DISCOUNT_VALUE", SqlDbType.Float)]
        public float? DISCOUNT_VALUE
        {
            get { return dISCOUNT_VALUE; }
            set { dISCOUNT_VALUE = value; }
        }
        [SqlColumn("OTHER_VALUE", SqlDbType.NVarChar)]
        public string OTHER_VALUE
        {
            get { return oTHER_VALUE; }
            set { oTHER_VALUE = value; }
        }
        [SqlColumn("GIFT", SqlDbType.NVarChar)]
        public string GIFT
        {
            get { return gIFT; }
            set { gIFT = value; }
        }
        [SqlColumn("QUANTITY_GIFT", SqlDbType.Int)]
        public int? QUANTITY_GIFT
        {
            get { return qUANTITY_GIFT; }
            set { qUANTITY_GIFT = value; }
        }
        [StringSqlColumn("GIFT_TWO")]
        public string GIFT_TWO
        {
            get { return gIFT_TWO; }
            set { gIFT_TWO = value; }
        }
        [SqlColumn("QUANTITY_GIFT_TWO", SqlDbType.Int)]
        public int? QUANTITY_GIFT_TWO
        {
            get { return qUANTITY_GIFT_TWO; }
            set { qUANTITY_GIFT_TWO = value; }
        }
        [SqlColumn("NUMBER_MARK", SqlDbType.Int)]
        public int? NUMBER_MARK
        {
            get { return nUMBER_MARK; }
            set { nUMBER_MARK = value; }
        }
        [StringSqlColumn("STATUS")]
        public string STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [SqlColumn("REASON_NOT_USED", SqlDbType.NVarChar)]
        public string REASON_NOT_USED
        {
            get { return rEASON_NOT_USED; }
            set { rEASON_NOT_USED = value; }
        }
        [StringSqlColumn("FOR_PRODUCTS")]
        public string FOR_PRODUCTS
        {
            get { return fOR_PRODUCTS; }
            set { fOR_PRODUCTS = value; }
        }
        [SqlColumn("PROMOTION_DETAIL_NAME", SqlDbType.NVarChar)]
        public string PROMOTION_DETAIL_NAME
        {
            get { return pROMOTION_DETAIL_NAME; }
            set { pROMOTION_DETAIL_NAME = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PROMOTION_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PROMOTION_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PROMOTION_DETAIL>("PROMOTION_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PROMOTION_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PROMOTION_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inPROMOTION_DETAIL_NO"></param>
        public static List<PROMOTION_DETAIL> ReadByPROMOTION_DETAIL_NO(string inPROMOTION_DETAIL_NO)
        {
            return posdb_vnmSqlDAC.ReadByParams<PROMOTION_DETAIL>("PROMOTION_DETAIL", posdb_vnmSqlDAC.newInParam("@PROMOTION_DETAIL_NO", inPROMOTION_DETAIL_NO));
        }
        #endregion DAC Methods
    }
}

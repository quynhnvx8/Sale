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
        int qUANTITY_MIN;
        float aMOUNT_MIN;
        string dISCOUNT_ON;
        float? dISCOUNT_VALUE;
        string gIFT;
        string promotionType;
        int? qUANTITY_GIFT;
        string gIFT_TWO;
        int? qUANTITY_GIFT_TWO;
        string pROMOTION_DETAIL_NAME;

        bool? Is_BUNDLE;

        int? by_SHOP;
        int? by_CUS;

        [SqlColumn("BY_SHOP", SqlDbType.Bit)]
        public int? BY_SHOP
        {
            get { return by_SHOP; }
            set { by_SHOP = value; }
        }
        [SqlColumn("BY_CUS", SqlDbType.Bit)]
        public int? BY_CUS
        {
            get { return by_CUS; }
            set { by_CUS = value; }
        }

        [SqlColumn("IS_BUNDLE", SqlDbType.Bit)]
        public bool? IS_BUNDLE
        {
            get { return Is_BUNDLE; }
            set { Is_BUNDLE = value; }
        }
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
        [SqlColumn("QUANTITY_MIN", SqlDbType.Int)]
        public int QUANTITY_MIN
        {
            get { return qUANTITY_MIN; }
            set { qUANTITY_MIN = value; }
        }
        
        [SqlColumn("AMOUNT_MIN", SqlDbType.Float)]
        public float AMOUNT_MIN
        {
            get { return aMOUNT_MIN; }
            set { aMOUNT_MIN = value; }
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
        [SqlColumn("GIFT", SqlDbType.NVarChar)]
        public string GIFT
        {
            get { return gIFT; }
            set { gIFT = value; }
        }

        [SqlColumn("PROMOTION_TYPE", SqlDbType.NVarChar)]
        public string PROMOTION_TYPE
        {
            get { return promotionType; }
            set { promotionType = value; }
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

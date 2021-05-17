using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class SALES_PAYMENT_HISTORY_DETAIL_CARD
    {
        #region members
        Guid aUTO_ID;
        Guid sALES_PAYMENT_HISTORY_ID;
        string cARD_CODE;
        string cARD_TYPE;
        float aMOUNT;
        string eVENT_ID;
        float? pERCENT_AMOUNT;
        float? tOTAL_DISCOUNT_AMOUNT;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [SqlColumn("SALES_PAYMENT_HISTORY_ID", SqlDbType.UniqueIdentifier)]
        public Guid SALES_PAYMENT_HISTORY_ID
        {
            get { return sALES_PAYMENT_HISTORY_ID; }
            set { sALES_PAYMENT_HISTORY_ID = value; }
        }
        [StringSqlColumn("CARD_CODE")]
        public string CARD_CODE
        {
            get { return cARD_CODE; }
            set { cARD_CODE = value; }
        }
        [StringSqlColumn("CARD_TYPE")]
        public string CARD_TYPE
        {
            get { return cARD_TYPE; }
            set { cARD_TYPE = value; }
        }
        [SqlColumn("AMOUNT", SqlDbType.Float)]
        public float AMOUNT
        {
            get { return aMOUNT; }
            set { aMOUNT = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("PERCENT_AMOUNT", SqlDbType.Float)]
        public float? PERCENT_AMOUNT
        {
            get { return pERCENT_AMOUNT; }
            set { pERCENT_AMOUNT = value; }
        }
        [SqlColumn("TOTAL_DISCOUNT_AMOUNT", SqlDbType.Float)]
        public float? TOTAL_DISCOUNT_AMOUNT
        {
            get { return tOTAL_DISCOUNT_AMOUNT; }
            set { tOTAL_DISCOUNT_AMOUNT = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public SALES_PAYMENT_HISTORY_DETAIL_CARD() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<SALES_PAYMENT_HISTORY_DETAIL_CARD> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<SALES_PAYMENT_HISTORY_DETAIL_CARD>("SALES_PAYMENT_HISTORY_DETAIL_CARD");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "SALES_PAYMENT_HISTORY_DETAIL_CARD",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "SALES_PAYMENT_HISTORY_DETAIL_CARD");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<SALES_PAYMENT_HISTORY_DETAIL_CARD> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY_DETAIL_CARD>("SALES_PAYMENT_HISTORY_DETAIL_CARD", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inSALES_PAYMENT_HISTORY_ID"></param>
        public static List<SALES_PAYMENT_HISTORY_DETAIL_CARD> ReadBySALES_PAYMENT_HISTORY_ID(Guid inSALES_PAYMENT_HISTORY_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY_DETAIL_CARD>("SALES_PAYMENT_HISTORY_DETAIL_CARD", posdb_vnmSqlDAC.newInParam("@SALES_PAYMENT_HISTORY_ID", inSALES_PAYMENT_HISTORY_ID));
        }
        #endregion DAC Methods
    }
}

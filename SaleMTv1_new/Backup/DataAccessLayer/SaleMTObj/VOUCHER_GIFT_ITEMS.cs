using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class VOUCHER_GIFT_ITEMS
    {
        #region members
        string iTEM_NO;
        string vOUCHER_GIFT_NO;
        float? iTEM_DENOMINATION;
        float? iTEM_REAL_DENOMINATION;
        float? bALANCE;
        string sTATUS;
        string lINK_CODE;
        string sTORE_CODE;
        string eXPORT_CODE;
        string sTORE_CODE_USED;
        DateTime? cREATE_DATE;
        bool? iS_EXPORTING;
        string rEASON_NOT_USED;
        string fOR_PRODUCTS;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("ITEM_NO", SqlDbType.VarChar, null)]
        public string ITEM_NO
        {
            get { return iTEM_NO; }
            set { iTEM_NO = value; }
        }
        [StringSqlColumn("VOUCHER_GIFT_NO")]
        public string VOUCHER_GIFT_NO
        {
            get { return vOUCHER_GIFT_NO; }
            set { vOUCHER_GIFT_NO = value; }
        }
        [SqlColumn("ITEM_DENOMINATION", SqlDbType.Float)]
        public float? ITEM_DENOMINATION
        {
            get { return iTEM_DENOMINATION; }
            set { iTEM_DENOMINATION = value; }
        }
        [SqlColumn("ITEM_REAL_DENOMINATION", SqlDbType.Float)]
        public float? ITEM_REAL_DENOMINATION
        {
            get { return iTEM_REAL_DENOMINATION; }
            set { iTEM_REAL_DENOMINATION = value; }
        }
        [SqlColumn("BALANCE", SqlDbType.Float)]
        public float? BALANCE
        {
            get { return bALANCE; }
            set { bALANCE = value; }
        }
        [StringSqlColumn("STATUS")]
        public string STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [StringSqlColumn("LINK_CODE")]
        public string LINK_CODE
        {
            get { return lINK_CODE; }
            set { lINK_CODE = value; }
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
        [StringSqlColumn("STORE_CODE_USED")]
        public string STORE_CODE_USED
        {
            get { return sTORE_CODE_USED; }
            set { sTORE_CODE_USED = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("IS_EXPORTING", SqlDbType.Bit)]
        public bool? IS_EXPORTING
        {
            get { return iS_EXPORTING; }
            set { iS_EXPORTING = value; }
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
        public VOUCHER_GIFT_ITEMS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<VOUCHER_GIFT_ITEMS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<VOUCHER_GIFT_ITEMS>("VOUCHER_GIFT_ITEMS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "VOUCHER_GIFT_ITEMS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "VOUCHER_GIFT_ITEMS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inITEM_NO"></param>
        public static List<VOUCHER_GIFT_ITEMS> ReadByITEM_NO(string inITEM_NO)
        {
            return posdb_vnmSqlDAC.ReadByParams<VOUCHER_GIFT_ITEMS>("VOUCHER_GIFT_ITEMS", posdb_vnmSqlDAC.newInParam("@ITEM_NO", inITEM_NO));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXPORT_PRODUCT_STORE_DETAIL
    {
        #region members
        Guid iD;
        string eXPORT_STORE_ID;
        string pRODUCT_ID;
        string p_ID;
        int? qUANTITY;
        float? pRODUCT_PRICE;
        string eVENT_ID;
        float? pRODUCT_PRICE_VAT;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("EXPORT_STORE_ID")]
        public string EXPORT_STORE_ID
        {
            get { return eXPORT_STORE_ID; }
            set { eXPORT_STORE_ID = value; }
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
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
        public float? PRODUCT_PRICE
        {
            get { return pRODUCT_PRICE; }
            set { pRODUCT_PRICE = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("PRODUCT_PRICE_VAT", SqlDbType.Float)]
        public float? PRODUCT_PRICE_VAT
        {
            get { return pRODUCT_PRICE_VAT; }
            set { pRODUCT_PRICE_VAT = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public EXPORT_PRODUCT_STORE_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXPORT_PRODUCT_STORE_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXPORT_PRODUCT_STORE_DETAIL>("EXPORT_PRODUCT_STORE_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXPORT_PRODUCT_STORE_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXPORT_PRODUCT_STORE_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<EXPORT_PRODUCT_STORE_DETAIL> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_STORE_DETAIL>("EXPORT_PRODUCT_STORE_DETAIL", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inPRODUCT_ID"></param>
        public static List<EXPORT_PRODUCT_STORE_DETAIL> ReadByPRODUCT_ID(string inPRODUCT_ID)
        {
            object parameter = inPRODUCT_ID ?? string.Empty;
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_STORE_DETAIL>("EXPORT_PRODUCT_STORE_DETAIL", posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", parameter));
        }
        #endregion DAC Methods
    }
}

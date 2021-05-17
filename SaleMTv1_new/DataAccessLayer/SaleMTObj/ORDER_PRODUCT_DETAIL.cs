using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class ORDER_PRODUCT_DETAIL
    {
        #region members
        Guid aUTO_ID;
        string oRDER_CODE;
        string pRODUCT_ID;
        float? pRODUCT_PRICE;
        int? qUANTITY;
        string eVENT_ID;

        #endregion members
        #region Properties
        [SqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [StringSqlColumn("ORDER_CODE")]
        public string ORDER_CODE
        {
            get { return oRDER_CODE; }
            set { oRDER_CODE = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
        public float? PRODUCT_PRICE
        {
            get { return pRODUCT_PRICE; }
            set { pRODUCT_PRICE = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
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
        public ORDER_PRODUCT_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<ORDER_PRODUCT_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<ORDER_PRODUCT_DETAIL>("ORDER_PRODUCT_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "ORDER_PRODUCT_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "ORDER_PRODUCT_DETAIL");
        }
        #endregion DAC Methods
    }
}

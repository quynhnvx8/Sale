using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXPORT_PRODUCT_ZONE_DETAIL
    {
        #region members
        Guid iD;
        string pRODUCT_ID;
        string p_ID;
        string iNVOICE_CODE;
        int qUANTITY;
        float? pRODUCT_PRICE;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
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
        [StringSqlColumn("INVOICE_CODE")]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int QUANTITY
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

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public EXPORT_PRODUCT_ZONE_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXPORT_PRODUCT_ZONE_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXPORT_PRODUCT_ZONE_DETAIL>("EXPORT_PRODUCT_ZONE_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXPORT_PRODUCT_ZONE_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXPORT_PRODUCT_ZONE_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<EXPORT_PRODUCT_ZONE_DETAIL> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_ZONE_DETAIL>("EXPORT_PRODUCT_ZONE_DETAIL", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inPRODUCT_ID"></param>
        public static List<EXPORT_PRODUCT_ZONE_DETAIL> ReadByPRODUCT_ID(string inPRODUCT_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_ZONE_DETAIL>("EXPORT_PRODUCT_ZONE_DETAIL", posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", inPRODUCT_ID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inINVOICE_CODE"></param>
        public static List<EXPORT_PRODUCT_ZONE_DETAIL> ReadByINVOICE_CODE(string inINVOICE_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_ZONE_DETAIL>("EXPORT_PRODUCT_ZONE_DETAIL", posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", inINVOICE_CODE));
        }
        #endregion DAC Methods
    }
}

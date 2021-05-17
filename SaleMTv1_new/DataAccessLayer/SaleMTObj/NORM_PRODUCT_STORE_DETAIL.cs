using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class NORM_PRODUCT_STORE_DETAIL
    {
        #region members
        string pRODUCT_ID;
        string sTORE_CODE;
        int? qUANTITY;
        Guid aUTO_ID;

        #endregion members
        #region Properties
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public NORM_PRODUCT_STORE_DETAIL() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<NORM_PRODUCT_STORE_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<NORM_PRODUCT_STORE_DETAIL>("NORM_PRODUCT_STORE_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "NORM_PRODUCT_STORE_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "NORM_PRODUCT_STORE_DETAIL");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<NORM_PRODUCT_STORE_DETAIL> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<NORM_PRODUCT_STORE_DETAIL>("NORM_PRODUCT_STORE_DETAIL", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

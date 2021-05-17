using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PO_FORECAST : IDataModel
    {
        #region members
        int id;
        string sTORE_CODE;
        int? yEAR;
        int? mONTH;
        string pRODUCT_ID;
        int? qUANTITY;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("YEAR", SqlDbType.Int)]
        public int? YEAR
        {
            get { return yEAR; }
            set { yEAR = value; }
        }
        [SqlColumn("MONTH", SqlDbType.Int)]
        public int? MONTH
        {
            get { return mONTH; }
            set { mONTH = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }

        #endregion Properties
        #region IsNew()
        public bool IsNew()
        {
            return id == 0;
        }

        #endregion IsNew()
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PO_FORECAST() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public PO_FORECAST(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PO_FORECAST> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PO_FORECAST>("PO_FORECAST");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<PO_FORECAST>(this, "PO_FORECAST");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PO_FORECAST",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PO_FORECAST");
        }
        #endregion DAC Methods
    }
}

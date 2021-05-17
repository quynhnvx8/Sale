using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PO_SAFETY_STOCK_DETAIL : IDataModel
    {
        #region members
        int id;
        string sTORE_CODE;
        string pRODUCT_ID;
        string cAT;
        int? mINSF;
        int? lEAD;
        string cALENDAR_D;
        int? pERCENTAGE;

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
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [StringSqlColumn("CAT")]
        public string CAT
        {
            get { return cAT; }
            set { cAT = value; }
        }
        [SqlColumn("MINSF", SqlDbType.Int)]
        public int? MINSF
        {
            get { return mINSF; }
            set { mINSF = value; }
        }
        [SqlColumn("LEAD", SqlDbType.Int)]
        public int? LEAD
        {
            get { return lEAD; }
            set { lEAD = value; }
        }
        [StringSqlColumn("CALENDAR_D")]
        public string CALENDAR_D
        {
            get { return cALENDAR_D; }
            set { cALENDAR_D = value; }
        }
        [SqlColumn("PERCENTAGE", SqlDbType.Int)]
        public int? PERCENTAGE
        {
            get { return pERCENTAGE; }
            set { pERCENTAGE = value; }
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
        public PO_SAFETY_STOCK_DETAIL() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public PO_SAFETY_STOCK_DETAIL(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PO_SAFETY_STOCK_DETAIL> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PO_SAFETY_STOCK_DETAIL>("PO_SAFETY_STOCK_DETAIL");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<PO_SAFETY_STOCK_DETAIL>(this, "PO_SAFETY_STOCK_DETAIL");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PO_SAFETY_STOCK_DETAIL",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PO_SAFETY_STOCK_DETAIL");
        }
        #endregion DAC Methods
    }
}

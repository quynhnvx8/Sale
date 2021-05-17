using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PO_SALES_DAY : IDataModel
    {
        #region members
        int id;
        string sTORE_CODE;
        int? yEAR;
        int? mONTH;
        int? sALES_DAY;

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
        [SqlColumn("SALES_DAY", SqlDbType.Int)]
        public int? SALES_DAY
        {
            get { return sALES_DAY; }
            set { sALES_DAY = value; }
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
        public PO_SALES_DAY() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public PO_SALES_DAY(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PO_SALES_DAY> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PO_SALES_DAY>("PO_SALES_DAY");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<PO_SALES_DAY>(this, "PO_SALES_DAY");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PO_SALES_DAY",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PO_SALES_DAY");
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEV_PRICEITEMS
    {
        #region members
        string product;
        DateTime startDate;
        
        DateTime? sTART_DATE1;
        DateTime? cREATE_DATE1;
        string uSER_CREATE1;
        decimal? pRICE1;

        int? iD;
       
        [SqlColumn("ID", SqlDbType.Int)]
        public int? ID
        {
            get { return iD; }
            set { iD = value; }
        }

        #endregion members
        #region Properties
        [StringSqlColumn("Product")]
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        [SqlColumn("StartDate", SqlDbType.DateTime)]
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        
        [SqlColumn("START_DATE1", SqlDbType.DateTime)]
        public DateTime? START_DATE1
        {
            get { return sTART_DATE1; }
            set { sTART_DATE1 = value; }
        }
        [SqlColumn("PRICE1", SqlDbType.Decimal)]
        public decimal? PRICE1
        {
            get { return pRICE1; }
            set { pRICE1 = value; }
        }
       
        [SqlColumn("CREATE_DATE1", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE1
        {
            get { return cREATE_DATE1; }
            set { cREATE_DATE1 = value; }
        }
        [SqlColumn("USER_CREATE1", SqlDbType.NVarChar)]
        public string USER_CREATE1
        {
            get { return uSER_CREATE1; }
            set { uSER_CREATE1 = value; }
        }
       

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DEV_PRICEITEMS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEV_PRICEITEMS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEV_PRICEITEMS>("DEV_PRICEITEMS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEV_PRICEITEMS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEV_PRICEITEMS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<DEV_PRICEITEMS> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<DEV_PRICEITEMS>("DEV_PRICEITEMS", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

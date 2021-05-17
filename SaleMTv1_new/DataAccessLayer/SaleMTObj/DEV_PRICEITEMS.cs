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
        float? unitCost;
        float? unitPriceRate;
        float? unitPrice;
        float? taxItem;
        float? unitPriceWithTax;
        DateTime? sTART_DATE0;
        float? pRICE0;
        DateTime? cREATE_DATE0;
        string uSER_CREATE0;
        DateTime? sTART_DATE1;
        decimal? pRICE1;
        string rEASON1;
        string rEMARK1;
        DateTime? cREATE_DATE1;
        string uSER_CREATE1;
        DateTime? sTART_DATE2;
        float? pRICE2;
        string rEASON2;
        string rEMARK2;
        DateTime? cREATE_DATE2;
        string uSER_CREATE2;
        DateTime? sTART_DATE3;
        float? pRICE3;
        string rEASON3;
        string rEMARK3;
        DateTime? cREATE_DATE3;
        string uSER_CREATE3;
        DateTime? sTART_DATE4;
        float? pRICE4;
        string rEASON4;
        string rEMARK4;
        DateTime? cREATE_DATE4;
        string uSER_CREATE4;
        Guid aUTO_ID;

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

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class ORDER_PRODUCT_STATUS
    {
        #region members
        Guid aUTO_ID;
        string oRDER_CODE;
        int sTATUS;
        string aPPROVE_BY;
        DateTime? aPPROVE_DATE;
        string rEMARKS;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
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
        [SqlColumn("STATUS", SqlDbType.Int)]
        public int STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [SqlColumn("APPROVE_BY", SqlDbType.NVarChar)]
        public string APPROVE_BY
        {
            get { return aPPROVE_BY; }
            set { aPPROVE_BY = value; }
        }
        [SqlColumn("APPROVE_DATE", SqlDbType.DateTime)]
        public DateTime? APPROVE_DATE
        {
            get { return aPPROVE_DATE; }
            set { aPPROVE_DATE = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public ORDER_PRODUCT_STATUS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<ORDER_PRODUCT_STATUS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<ORDER_PRODUCT_STATUS>("ORDER_PRODUCT_STATUS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "ORDER_PRODUCT_STATUS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "ORDER_PRODUCT_STATUS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<ORDER_PRODUCT_STATUS> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<ORDER_PRODUCT_STATUS>("ORDER_PRODUCT_STATUS", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

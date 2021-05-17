using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEV_PRICETABLES
    {
        #region members
        Guid aUTO_ID;
        string mASTER_CODE;
        string dEPT_CODE;
        string pRICE_TYPE;

        #endregion members
        #region Properties
        [PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
        public Guid AUTO_ID
        {
            get { return aUTO_ID; }
            set { aUTO_ID = value; }
        }
        [StringSqlColumn("MASTER_CODE")]
        public string MASTER_CODE
        {
            get { return mASTER_CODE; }
            set { mASTER_CODE = value; }
        }
        [StringSqlColumn("DEPT_CODE")]
        public string DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }
        [StringSqlColumn("PRICE_TYPE")]
        public string PRICE_TYPE
        {
            get { return pRICE_TYPE; }
            set { pRICE_TYPE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DEV_PRICETABLES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEV_PRICETABLES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEV_PRICETABLES>("DEV_PRICETABLES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEV_PRICETABLES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEV_PRICETABLES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inAUTO_ID"></param>
        public static List<DEV_PRICETABLES> ReadByAUTO_ID(Guid inAUTO_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<DEV_PRICETABLES>("DEV_PRICETABLES", posdb_vnmSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEV_MASTER_PRODUCT_ATTRIBUTES
    {
        #region members
        string iD;
        string nAME;
        string tYPE;
        string dM;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.VarChar, null)]
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("NAME", SqlDbType.NVarChar)]
        public string NAME
        {
            get { return nAME; }
            set { nAME = value; }
        }
        [StringSqlColumn("TYPE")]
        public string TYPE
        {
            get { return tYPE; }
            set { tYPE = value; }
        }
        [StringSqlColumn("DM")]
        public string DM
        {
            get { return dM; }
            set { dM = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DEV_MASTER_PRODUCT_ATTRIBUTES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEV_MASTER_PRODUCT_ATTRIBUTES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEV_MASTER_PRODUCT_ATTRIBUTES>("DEV_MASTER_PRODUCT_ATTRIBUTES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEV_MASTER_PRODUCT_ATTRIBUTES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEV_MASTER_PRODUCT_ATTRIBUTES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<DEV_MASTER_PRODUCT_ATTRIBUTES> ReadByID(string inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<DEV_MASTER_PRODUCT_ATTRIBUTES>("DEV_MASTER_PRODUCT_ATTRIBUTES", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

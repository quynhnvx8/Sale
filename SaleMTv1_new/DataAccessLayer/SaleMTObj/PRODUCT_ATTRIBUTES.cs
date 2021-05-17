using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PRODUCT_ATTRIBUTES
    {
        #region members
        string pRODUCT_ID;
        string cOLUMN_NAME;
        string cOLUMN_VALUE;

        #endregion members
        #region Properties
        [PKSqlColumn("PRODUCT_ID", SqlDbType.VarChar, null)]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [PKSqlColumn("COLUMN_NAME", SqlDbType.VarChar, null)]
        public string COLUMN_NAME
        {
            get { return cOLUMN_NAME; }
            set { cOLUMN_NAME = value; }
        }
        [StringSqlColumn("COLUMN_VALUE")]
        public string COLUMN_VALUE
        {
            get { return cOLUMN_VALUE; }
            set { cOLUMN_VALUE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PRODUCT_ATTRIBUTES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PRODUCT_ATTRIBUTES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PRODUCT_ATTRIBUTES>("PRODUCT_ATTRIBUTES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PRODUCT_ATTRIBUTES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PRODUCT_ATTRIBUTES");
        }
        #endregion DAC Methods
    }
}

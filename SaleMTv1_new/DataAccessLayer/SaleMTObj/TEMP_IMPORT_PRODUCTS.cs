using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class TEMP_IMPORT_PRODUCTS : IDataModel
    {
        #region members
        string pRODUCT_ID;
        string pRODUCT_NAME;
        int id;
        string cOMPUTER_NAME;

        #endregion members
        #region Properties
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [SqlColumn("PRODUCT_NAME", SqlDbType.NVarChar)]
        public string PRODUCT_NAME
        {
            get { return pRODUCT_NAME; }
            set { pRODUCT_NAME = value; }
        }
        [PKSqlColumn("AUTO_ID", SqlDbType.Decimal, null)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("COMPUTER_NAME")]
        public string COMPUTER_NAME
        {
            get { return cOMPUTER_NAME; }
            set { cOMPUTER_NAME = value; }
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
        public TEMP_IMPORT_PRODUCTS() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public TEMP_IMPORT_PRODUCTS(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<TEMP_IMPORT_PRODUCTS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<TEMP_IMPORT_PRODUCTS>("TEMP_IMPORT_PRODUCTS");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<TEMP_IMPORT_PRODUCTS>(this, "TEMP_IMPORT_PRODUCTS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "TEMP_IMPORT_PRODUCTS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "TEMP_IMPORT_PRODUCTS");
        }
        #endregion DAC Methods
    }
}

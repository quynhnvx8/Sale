using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PRODUCT_INFO
    {
        #region members
        string cODE1;
        string cODE2;
        string cODE3;

        #endregion members
        #region Properties
        [PKSqlColumn("CODE1", SqlDbType.VarChar, null)]
        public string CODE1
        {
            get { return cODE1; }
            set { cODE1 = value; }
        }
        [StringSqlColumn("CODE2")]
        public string CODE2
        {
            get { return cODE2; }
            set { cODE2 = value; }
        }
        [StringSqlColumn("CODE3")]
        public string CODE3
        {
            get { return cODE3; }
            set { cODE3 = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PRODUCT_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PRODUCT_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PRODUCT_INFO>("PRODUCT_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PRODUCT_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PRODUCT_INFO");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inCODE1"></param>
        public static List<PRODUCT_INFO> ReadByCODE1(string inCODE1)
        {
            return posdb_vnmSqlDAC.ReadByParams<PRODUCT_INFO>("PRODUCT_INFO", posdb_vnmSqlDAC.newInParam("@CODE1", inCODE1));
        }
        #endregion DAC Methods
    }
}

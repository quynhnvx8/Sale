using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DISCOUNT_DEPT
    {
        #region members
        string dISCOUNT_CODE;
        int dEPT_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("DISCOUNT_CODE", SqlDbType.VarChar, null)]
        public string DISCOUNT_CODE
        {
            get { return dISCOUNT_CODE; }
            set { dISCOUNT_CODE = value; }
        }
        [PKSqlColumn("DEPT_CODE",SqlDbType.Int, false)]
        public int DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DISCOUNT_DEPT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DISCOUNT_DEPT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DISCOUNT_DEPT>("DISCOUNT_DEPT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DISCOUNT_DEPT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DISCOUNT_DEPT");
        }
        #endregion DAC Methods
    }
}

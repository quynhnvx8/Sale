using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PROGRAM_CATEGORY
    {
        #region members
        string pROGRAM_NO;
        string cATEGORY_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("PROGRAM_NO", SqlDbType.VarChar, null)]
        public string PROGRAM_NO
        {
            get { return pROGRAM_NO; }
            set { pROGRAM_NO = value; }
        }
        [PKSqlColumn("CATEGORY_ID", SqlDbType.VarChar, null)]
        public string CATEGORY_ID
        {
            get { return cATEGORY_ID; }
            set { cATEGORY_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PROGRAM_CATEGORY() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PROGRAM_CATEGORY> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PROGRAM_CATEGORY>("PROGRAM_CATEGORY");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PROGRAM_CATEGORY",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PROGRAM_CATEGORY");
        }
        #endregion DAC Methods
    }
}

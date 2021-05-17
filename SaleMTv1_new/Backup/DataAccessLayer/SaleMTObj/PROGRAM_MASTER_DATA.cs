using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PROGRAM_MASTER_DATA
    {
        #region members
        string pROGRAM_NO;
        string mASTER_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("PROGRAM_NO", SqlDbType.VarChar, null)]
        public string PROGRAM_NO
        {
            get { return pROGRAM_NO; }
            set { pROGRAM_NO = value; }
        }
        [PKSqlColumn("MASTER_CODE", SqlDbType.VarChar, null)]
        public string MASTER_CODE
        {
            get { return mASTER_CODE; }
            set { mASTER_CODE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PROGRAM_MASTER_DATA() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PROGRAM_MASTER_DATA> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PROGRAM_MASTER_DATA>("PROGRAM_MASTER_DATA");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PROGRAM_MASTER_DATA",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PROGRAM_MASTER_DATA");
        }
        #endregion DAC Methods
    }
}

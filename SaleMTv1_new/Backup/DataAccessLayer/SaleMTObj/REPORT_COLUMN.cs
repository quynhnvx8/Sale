using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class REPORT_COLUMN
    {
        #region members
        string rEPORT_ID;
        string cOLUMNS;
        string cOLUMN_HEADER;

        #endregion members
        #region Properties
        [PKSqlColumn("REPORT_ID", SqlDbType.VarChar, null)]
        public string REPORT_ID
        {
            get { return rEPORT_ID; }
            set { rEPORT_ID = value; }
        }
        [SqlColumn("COLUMNS", SqlDbType.NText)]
        public string COLUMNS
        {
            get { return cOLUMNS; }
            set { cOLUMNS = value; }
        }
        [SqlColumn("COLUMN_HEADER", SqlDbType.NText)]
        public string COLUMN_HEADER
        {
            get { return cOLUMN_HEADER; }
            set { cOLUMN_HEADER = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public REPORT_COLUMN() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<REPORT_COLUMN> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<REPORT_COLUMN>("REPORT_COLUMN");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "REPORT_COLUMN",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "REPORT_COLUMN");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inREPORT_ID"></param>
        public static List<REPORT_COLUMN> ReadByREPORT_ID(string inREPORT_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<REPORT_COLUMN>("REPORT_COLUMN", posdb_vnmSqlDAC.newInParam("@REPORT_ID", inREPORT_ID));
        }
        #endregion DAC Methods
    }
}

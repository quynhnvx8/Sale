using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class REPORT_INFO
    {
        #region members
        string iD;
        string description;
        string parentID;
        string formName;
        int? reportGroup;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.NVarChar, null)]
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("Description", SqlDbType.NVarChar)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [SqlColumn("ParentID", SqlDbType.NVarChar)]
        public string ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        [SqlColumn("FormName", SqlDbType.NVarChar)]
        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }
        [SqlColumn("ReportGroup", SqlDbType.Int)]
        public int? ReportGroup
        {
            get { return reportGroup; }
            set { reportGroup = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public REPORT_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<REPORT_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<REPORT_INFO>("REPORT_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "REPORT_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "REPORT_INFO");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<REPORT_INFO> ReadByID(string inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<REPORT_INFO>("REPORT_INFO", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MAIL_TEMPLATE
    {
        #region members
        string mTEMPLATE_ID;
        string mTEMPLATE_TITLE;
        string mTEMPLATE_DESCRIPTION;
        string mTEMPLATE_CONTENT;
        string mLIST_PROPERTIES;
        bool? mIS_DEDICATED;

        #endregion members
        #region Properties
        [PKSqlColumn("mTEMPLATE_ID", SqlDbType.VarChar, null)]
        public string MTEMPLATE_ID
        {
            get { return mTEMPLATE_ID; }
            set { mTEMPLATE_ID = value; }
        }
        [SqlColumn("mTEMPLATE_TITLE", SqlDbType.NVarChar)]
        public string MTEMPLATE_TITLE
        {
            get { return mTEMPLATE_TITLE; }
            set { mTEMPLATE_TITLE = value; }
        }
        [SqlColumn("mTEMPLATE_DESCRIPTION", SqlDbType.NText)]
        public string MTEMPLATE_DESCRIPTION
        {
            get { return mTEMPLATE_DESCRIPTION; }
            set { mTEMPLATE_DESCRIPTION = value; }
        }
        [SqlColumn("mTEMPLATE_CONTENT", SqlDbType.NText)]
        public string MTEMPLATE_CONTENT
        {
            get { return mTEMPLATE_CONTENT; }
            set { mTEMPLATE_CONTENT = value; }
        }
        [SqlColumn("mLIST_PROPERTIES", SqlDbType.NVarChar)]
        public string MLIST_PROPERTIES
        {
            get { return mLIST_PROPERTIES; }
            set { mLIST_PROPERTIES = value; }
        }
        [SqlColumn("mIS_DEDICATED", SqlDbType.Bit)]
        public bool? MIS_DEDICATED
        {
            get { return mIS_DEDICATED; }
            set { mIS_DEDICATED = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MAIL_TEMPLATE() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MAIL_TEMPLATE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MAIL_TEMPLATE>("MAIL_TEMPLATE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MAIL_TEMPLATE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MAIL_TEMPLATE");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inmTEMPLATE_ID"></param>
        public static List<MAIL_TEMPLATE> ReadBymTEMPLATE_ID(string inmTEMPLATE_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<MAIL_TEMPLATE>("MAIL_TEMPLATE", posdb_vnmSqlDAC.newInParam("@mTEMPLATE_ID", inmTEMPLATE_ID));
        }
        #endregion DAC Methods
    }
}

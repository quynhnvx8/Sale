using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class BK_EVENT_STACK_TABLE : IDataModel
    {
        #region members
        string eVENT_ID;
        int? eVENT_TYPE;
        string tABLE_OBJECT;
        string tARGET_COLUMN;
        DateTime? dATE_CREATE;
        string rELATIVE_EVENT;
        bool? iS_SEND_SERVER;
        DateTime? dATE_SYNCHROUS;
        string qUERY_BUILDER;
        int id;
        string qUERY_BUILDER_SERVER;

        #endregion members
        #region Properties
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("EVENT_TYPE", SqlDbType.Int)]
        public int? EVENT_TYPE
        {
            get { return eVENT_TYPE; }
            set { eVENT_TYPE = value; }
        }
        [StringSqlColumn("TABLE_OBJECT")]
        public string TABLE_OBJECT
        {
            get { return tABLE_OBJECT; }
            set { tABLE_OBJECT = value; }
        }
        [SqlColumn("TARGET_COLUMN", SqlDbType.Text)]
        public string TARGET_COLUMN
        {
            get { return tARGET_COLUMN; }
            set { tARGET_COLUMN = value; }
        }
        [SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
        public DateTime? DATE_CREATE
        {
            get { return dATE_CREATE; }
            set { dATE_CREATE = value; }
        }
        [StringSqlColumn("RELATIVE_EVENT")]
        public string RELATIVE_EVENT
        {
            get { return rELATIVE_EVENT; }
            set { rELATIVE_EVENT = value; }
        }
        [SqlColumn("IS_SEND_SERVER", SqlDbType.Bit)]
        public bool? IS_SEND_SERVER
        {
            get { return iS_SEND_SERVER; }
            set { iS_SEND_SERVER = value; }
        }
        [SqlColumn("DATE_SYNCHROUS", SqlDbType.DateTime)]
        public DateTime? DATE_SYNCHROUS
        {
            get { return dATE_SYNCHROUS; }
            set { dATE_SYNCHROUS = value; }
        }
        [SqlColumn("QUERY_BUILDER", SqlDbType.NText)]
        public string QUERY_BUILDER
        {
            get { return qUERY_BUILDER; }
            set { qUERY_BUILDER = value; }
        }
        [PKSqlColumn("ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [SqlColumn("QUERY_BUILDER_SERVER", SqlDbType.NText)]
        public string QUERY_BUILDER_SERVER
        {
            get { return qUERY_BUILDER_SERVER; }
            set { qUERY_BUILDER_SERVER = value; }
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
        public BK_EVENT_STACK_TABLE() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public BK_EVENT_STACK_TABLE(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<BK_EVENT_STACK_TABLE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<BK_EVENT_STACK_TABLE>("BK_EVENT_STACK_TABLE");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<BK_EVENT_STACK_TABLE>(this, "BK_EVENT_STACK_TABLE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "BK_EVENT_STACK_TABLE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "BK_EVENT_STACK_TABLE");
        }
        #endregion DAC Methods
    }
}

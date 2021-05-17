using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class TEST_SYNCHRO
    {
        #region members
        string col_name;
        string values;
        string event_id;

        #endregion members
        #region Properties
        [StringSqlColumn("col_name")]
        public string Col_name
        {
            get { return col_name; }
            set { col_name = value; }
        }
        [StringSqlColumn("value")]
        public string Values
        {
            get { return values; }
            set { values = value; }
        }
        [StringSqlColumn("event_id")]
        public string Event_id
        {
            get { return event_id; }
            set { event_id = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public TEST_SYNCHRO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<TEST_SYNCHRO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<TEST_SYNCHRO>("TEST_SYNCHRO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "TEST_SYNCHRO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "TEST_SYNCHRO");
        }
        #endregion DAC Methods
    }
}

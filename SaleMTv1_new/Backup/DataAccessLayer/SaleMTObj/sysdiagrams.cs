using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class sysdiagrams : IDataModel
    {
        #region members
        string name;
        int principal_id;
        int id;
        int? version;
        byte[] definition;

        #endregion members
        #region Properties
        [SqlColumn("name", SqlDbType.NVarChar)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [SqlColumn("principal_id", SqlDbType.Int)]
        public int Principal_id
        {
            get { return principal_id; }
            set { principal_id = value; }
        }
        [PKSqlColumn("diagram_id", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [SqlColumn("version", SqlDbType.Int)]
        public int? Version
        {
            get { return version; }
            set { version = value; }
        }
        [SqlColumn("definition", SqlDbType.VarBinary)]
        public byte[] Definition
        {
            get { return definition; }
            set { definition = value; }
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
        public sysdiagrams() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public sysdiagrams(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<sysdiagrams> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<sysdiagrams>("sysdiagrams");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<sysdiagrams>(this, "sysdiagrams");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "sysdiagrams",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "sysdiagrams");
        }
        #endregion DAC Methods
    }
}

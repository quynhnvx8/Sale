using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class TEMP_01 : IDataModel
    {
        #region members
        string temp_ID;
        string temp_Name;
        string temp_Value;
        string computer_Name;
        int id;
        string temp_Price;

        #endregion members
        #region Properties
        [SqlColumn("Temp_ID", SqlDbType.NVarChar)]
        public string Temp_ID
        {
            get { return temp_ID; }
            set { temp_ID = value; }
        }
        [SqlColumn("Temp_Name", SqlDbType.NVarChar)]
        public string Temp_Name
        {
            get { return temp_Name; }
            set { temp_Name = value; }
        }
        [SqlColumn("Temp_Value", SqlDbType.NVarChar)]
        public string Temp_Value
        {
            get { return temp_Value; }
            set { temp_Value = value; }
        }
        [SqlColumn("Computer_Name", SqlDbType.NVarChar)]
        public string Computer_Name
        {
            get { return computer_Name; }
            set { computer_Name = value; }
        }
        [PKSqlColumn("AUTO_ID", SqlDbType.Decimal, null)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [SqlColumn("Temp_Price", SqlDbType.NVarChar)]
        public string Temp_Price
        {
            get { return temp_Price; }
            set { temp_Price = value; }
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
        public TEMP_01() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public TEMP_01(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<TEMP_01> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<TEMP_01>("TEMP_01");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<TEMP_01>(this, "TEMP_01");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "TEMP_01",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "TEMP_01");
        }
        #endregion DAC Methods
    }
}

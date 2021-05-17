using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DATA_CHANGED : IDataModel
    {
        #region members
        int id;
        string xMLContent;
        string storeCode;
        DateTime? cREATE_DATE;
        string iPAddress;
        string computerName;

        #endregion members
        #region Properties
        [PKSqlColumn("AutoId", SqlDbType.BigInt, 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [SqlColumn("XMLContent", SqlDbType.NText)]
        public string XMLContent
        {
            get { return xMLContent; }
            set { xMLContent = value; }
        }
        [StringSqlColumn("StoreCode")]
        public string StoreCode
        {
            get { return storeCode; }
            set { storeCode = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [StringSqlColumn("IPAddress")]
        public string IPAddress
        {
            get { return iPAddress; }
            set { iPAddress = value; }
        }
        [StringSqlColumn("ComputerName")]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
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
        public DATA_CHANGED() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public DATA_CHANGED(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DATA_CHANGED> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DATA_CHANGED>("DATA_CHANGED");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<DATA_CHANGED>(this, "DATA_CHANGED");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DATA_CHANGED",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DATA_CHANGED");
        }
        #endregion DAC Methods
    }
}

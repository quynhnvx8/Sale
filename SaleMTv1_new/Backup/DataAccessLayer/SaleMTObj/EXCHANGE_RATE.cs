using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXCHANGE_RATE : IDataModel
    {
        #region members
        int id;
        string cURRENCY_ID;
        DateTime eXCHANGE_DATE;
        float rATE;
        string rEMARK;

        #endregion members
        #region Properties
        [PKSqlColumn("EXCHANGE_ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("CURRENCY_ID")]
        public string CURRENCY_ID
        {
            get { return cURRENCY_ID; }
            set { cURRENCY_ID = value; }
        }
        [SqlColumn("EXCHANGE_DATE", SqlDbType.DateTime)]
        public DateTime EXCHANGE_DATE
        {
            get { return eXCHANGE_DATE; }
            set { eXCHANGE_DATE = value; }
        }
        [SqlColumn("RATE", SqlDbType.Float)]
        public float RATE
        {
            get { return rATE; }
            set { rATE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
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
        public EXCHANGE_RATE() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public EXCHANGE_RATE(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXCHANGE_RATE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXCHANGE_RATE>("EXCHANGE_RATE");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<EXCHANGE_RATE>(this, "EXCHANGE_RATE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXCHANGE_RATE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXCHANGE_RATE");
        }
        #endregion DAC Methods
    }
}

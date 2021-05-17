using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_EX_LENSESORDER_SERVICES
    {
        #region members
        Guid iD;
        string lENSESORDER_CODE;
        string sERVICE_CODE;
        float? pRICE;
        float? cUSTOMER_PRICE;
        string rEMARK;
        string eVENT_ID;
        Guid rowguid;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("LENSESORDER_CODE")]
        public string LENSESORDER_CODE
        {
            get { return lENSESORDER_CODE; }
            set { lENSESORDER_CODE = value; }
        }
        [StringSqlColumn("SERVICE_CODE")]
        public string SERVICE_CODE
        {
            get { return sERVICE_CODE; }
            set { sERVICE_CODE = value; }
        }
        [SqlColumn("PRICE", SqlDbType.Float)]
        public float? PRICE
        {
            get { return pRICE; }
            set { pRICE = value; }
        }
        [SqlColumn("CUSTOMER_PRICE", SqlDbType.Float)]
        public float? CUSTOMER_PRICE
        {
            get { return cUSTOMER_PRICE; }
            set { cUSTOMER_PRICE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("rowguid", SqlDbType.UniqueIdentifier)]
        public Guid Rowguid
        {
            get { return rowguid; }
            set { rowguid = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MASTER_EX_LENSESORDER_SERVICES() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_EX_LENSESORDER_SERVICES> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_EX_LENSESORDER_SERVICES>("MASTER_EX_LENSESORDER_SERVICES");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_EX_LENSESORDER_SERVICES",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_EX_LENSESORDER_SERVICES");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<MASTER_EX_LENSESORDER_SERVICES> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER_SERVICES>("MASTER_EX_LENSESORDER_SERVICES", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inrowguid"></param>
        public static List<MASTER_EX_LENSESORDER_SERVICES> ReadByrowguid(Guid inrowguid)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER_SERVICES>("MASTER_EX_LENSESORDER_SERVICES", posdb_vnmSqlDAC.newInParam("@rowguid", inrowguid));
        }
        #endregion DAC Methods
    }
}

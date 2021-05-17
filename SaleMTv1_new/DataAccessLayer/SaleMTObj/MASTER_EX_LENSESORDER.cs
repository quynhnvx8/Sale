using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_EX_LENSESORDER
    {
        #region members
        string lENSESORDER_CODE;
        string eXAMEYE_CODE;
        string cUSTOMER_ID;
        DateTime? dATE_ORDER;
        string pRODUCT_OD_ID;
        float? aMOUNT_OD;
        float? pRICE_OD;
        float? cUSTOMER_PRICE_OD;
        string pRODUCT_OS_ID;
        float? aMOUNT_OS;
        float? pRICE_OS;
        float? cUSTOMER_PRICE_OS;
        string rEMARK;
        string sTORE_CODE;
        DateTime? dATE_CREATE;
        string cREATE_BY;
        DateTime? dATE_UPDATE;
        string uPDATE_BY;
        string eVENT_ID;
        Guid rowguid;

        #endregion members
        #region Properties
        [PKSqlColumn("LENSESORDER_CODE", SqlDbType.VarChar, null)]
        public string LENSESORDER_CODE
        {
            get { return lENSESORDER_CODE; }
            set { lENSESORDER_CODE = value; }
        }
        [StringSqlColumn("EXAMEYE_CODE")]
        public string EXAMEYE_CODE
        {
            get { return eXAMEYE_CODE; }
            set { eXAMEYE_CODE = value; }
        }
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [SqlColumn("DATE_ORDER", SqlDbType.DateTime)]
        public DateTime? DATE_ORDER
        {
            get { return dATE_ORDER; }
            set { dATE_ORDER = value; }
        }
        [StringSqlColumn("PRODUCT_OD_ID")]
        public string PRODUCT_OD_ID
        {
            get { return pRODUCT_OD_ID; }
            set { pRODUCT_OD_ID = value; }
        }
        [SqlColumn("AMOUNT_OD", SqlDbType.Float)]
        public float? AMOUNT_OD
        {
            get { return aMOUNT_OD; }
            set { aMOUNT_OD = value; }
        }
        [SqlColumn("PRICE_OD", SqlDbType.Float)]
        public float? PRICE_OD
        {
            get { return pRICE_OD; }
            set { pRICE_OD = value; }
        }
        [SqlColumn("CUSTOMER_PRICE_OD", SqlDbType.Float)]
        public float? CUSTOMER_PRICE_OD
        {
            get { return cUSTOMER_PRICE_OD; }
            set { cUSTOMER_PRICE_OD = value; }
        }
        [StringSqlColumn("PRODUCT_OS_ID")]
        public string PRODUCT_OS_ID
        {
            get { return pRODUCT_OS_ID; }
            set { pRODUCT_OS_ID = value; }
        }
        [SqlColumn("AMOUNT_OS", SqlDbType.Float)]
        public float? AMOUNT_OS
        {
            get { return aMOUNT_OS; }
            set { aMOUNT_OS = value; }
        }
        [SqlColumn("PRICE_OS", SqlDbType.Float)]
        public float? PRICE_OS
        {
            get { return pRICE_OS; }
            set { pRICE_OS = value; }
        }
        [SqlColumn("CUSTOMER_PRICE_OS", SqlDbType.Float)]
        public float? CUSTOMER_PRICE_OS
        {
            get { return cUSTOMER_PRICE_OS; }
            set { cUSTOMER_PRICE_OS = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
        public DateTime? DATE_CREATE
        {
            get { return dATE_CREATE; }
            set { dATE_CREATE = value; }
        }
        [SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
        public string CREATE_BY
        {
            get { return cREATE_BY; }
            set { cREATE_BY = value; }
        }
        [SqlColumn("DATE_UPDATE", SqlDbType.DateTime)]
        public DateTime? DATE_UPDATE
        {
            get { return dATE_UPDATE; }
            set { dATE_UPDATE = value; }
        }
        [SqlColumn("UPDATE_BY", SqlDbType.NVarChar)]
        public string UPDATE_BY
        {
            get { return uPDATE_BY; }
            set { uPDATE_BY = value; }
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
        public MASTER_EX_LENSESORDER() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_EX_LENSESORDER> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_EX_LENSESORDER>("MASTER_EX_LENSESORDER");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_EX_LENSESORDER",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_EX_LENSESORDER");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inLENSESORDER_CODE"></param>
        public static List<MASTER_EX_LENSESORDER> ReadByLENSESORDER_CODE(string inLENSESORDER_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER>("MASTER_EX_LENSESORDER", posdb_vnmSqlDAC.newInParam("@LENSESORDER_CODE", inLENSESORDER_CODE));
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inrowguid"></param>
        public static List<MASTER_EX_LENSESORDER> ReadByrowguid(Guid inrowguid)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER>("MASTER_EX_LENSESORDER", posdb_vnmSqlDAC.newInParam("@rowguid", inrowguid));
        }
        #endregion DAC Methods
    }
}

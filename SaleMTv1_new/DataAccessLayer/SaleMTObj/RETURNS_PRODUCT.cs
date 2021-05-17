using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class RETURNS_PRODUCT
    {
        #region members
        string rETURNS_ID;
        string iNVOICE_CODE;
        DateTime? dATE_RETURNS;
        string sTORE_CODE;
        string zONE_CODE;
        string rEMARKS;
        string cREATE_BY;
        DateTime? dATE_CREATE;
        string uPDATE_BY;
        DateTime? dATE_UPDATE;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("RETURNS_ID", SqlDbType.VarChar, null)]
        public string RETURNS_ID
        {
            get { return rETURNS_ID; }
            set { rETURNS_ID = value; }
        }
        [StringSqlColumn("INVOICE_CODE")]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [SqlColumn("DATE_RETURNS", SqlDbType.DateTime)]
        public DateTime? DATE_RETURNS
        {
            get { return dATE_RETURNS; }
            set { dATE_RETURNS = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [StringSqlColumn("ZONE_CODE")]
        public string ZONE_CODE
        {
            get { return zONE_CODE; }
            set { zONE_CODE = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
        public string CREATE_BY
        {
            get { return cREATE_BY; }
            set { cREATE_BY = value; }
        }
        [SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
        public DateTime? DATE_CREATE
        {
            get { return dATE_CREATE; }
            set { dATE_CREATE = value; }
        }
        [SqlColumn("UPDATE_BY", SqlDbType.NVarChar)]
        public string UPDATE_BY
        {
            get { return uPDATE_BY; }
            set { uPDATE_BY = value; }
        }
        [SqlColumn("DATE_UPDATE", SqlDbType.DateTime)]
        public DateTime? DATE_UPDATE
        {
            get { return dATE_UPDATE; }
            set { dATE_UPDATE = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public RETURNS_PRODUCT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<RETURNS_PRODUCT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<RETURNS_PRODUCT>("RETURNS_PRODUCT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "RETURNS_PRODUCT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "RETURNS_PRODUCT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inRETURNS_ID"></param>
        public static List<RETURNS_PRODUCT> ReadByRETURNS_ID(string inRETURNS_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<RETURNS_PRODUCT>("RETURNS_PRODUCT", posdb_vnmSqlDAC.newInParam("@RETURNS_ID", inRETURNS_ID));
        }
        #endregion DAC Methods
    }
}

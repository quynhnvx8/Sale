using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class ORDER_PRODUCTS
    {
        #region members
        string oRDER_CODE;
        DateTime? oRDER_DATE;
        string sTORE_CODE;
        string rEMARKS;
        string cREATE_BY;
        DateTime? cREATE_DATE;
        string uPDATE_BY;
        DateTime? uPDATE_DATE;
        string eVENT_ID;
        

        #endregion members
        #region Properties
        [PKSqlColumn("ORDER_CODE", SqlDbType.VarChar, null)]
        public string ORDER_CODE
        {
            get { return oRDER_CODE; }
            set { oRDER_CODE = value; }
        }
        [SqlColumn("ORDER_DATE", SqlDbType.DateTime)]
        public DateTime? ORDER_DATE
        {
            get { return oRDER_DATE; }
            set { oRDER_DATE = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
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
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("UPDATE_BY", SqlDbType.NVarChar)]
        public string UPDATE_BY
        {
            get { return uPDATE_BY; }
            set { uPDATE_BY = value; }
        }
        [SqlColumn("UPDATE_DATE", SqlDbType.DateTime)]
        public DateTime? UPDATE_DATE
        {
            get { return uPDATE_DATE; }
            set { uPDATE_DATE = value; }
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
        public ORDER_PRODUCTS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<ORDER_PRODUCTS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<ORDER_PRODUCTS>("ORDER_PRODUCTS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "ORDER_PRODUCTS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "ORDER_PRODUCTS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inORDER_CODE"></param>
        public static List<ORDER_PRODUCTS> ReadByORDER_CODE(string inORDER_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<ORDER_PRODUCTS>("ORDER_PRODUCTS", posdb_vnmSqlDAC.newInParam("@ORDER_CODE", inORDER_CODE));
        }
        #endregion DAC Methods
    }
}

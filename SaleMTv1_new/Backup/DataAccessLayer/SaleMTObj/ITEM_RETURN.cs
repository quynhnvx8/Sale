using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class ITEM_RETURN
    {
        #region members
        string rETURN_CODE;
        DateTime iNPUT_DATE;
        DateTime rETURN_DATE;
        string iNVOICE_CODE;
        string cUSTOMER_ID;
        string eMPLOYEE_ID;
        float pRICE_ITEM_RETURN;
        string tRANSFER_SHIFT_CODE;
        string sTORE_CODE;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("RETURN_CODE", SqlDbType.VarChar, null)]
        public string RETURN_CODE
        {
            get { return rETURN_CODE; }
            set { rETURN_CODE = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("RETURN_DATE", SqlDbType.DateTime)]
        public DateTime RETURN_DATE
        {
            get { return rETURN_DATE; }
            set { rETURN_DATE = value; }
        }
        [StringSqlColumn("INVOICE_CODE")]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [SqlColumn("CUSTOMER_ID", SqlDbType.NVarChar)]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [StringSqlColumn("EMPLOYEE_ID")]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
        }
        [SqlColumn("PRICE_ITEM_RETURN", SqlDbType.Float)]
        public float PRICE_ITEM_RETURN
        {
            get { return pRICE_ITEM_RETURN; }
            set { pRICE_ITEM_RETURN = value; }
        }
        [SqlColumn("TRANSFER_SHIFT_CODE", SqlDbType.NVarChar)]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
        }
        [SqlColumn("STORE_CODE", SqlDbType.NVarChar)]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
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
        public ITEM_RETURN() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<ITEM_RETURN> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<ITEM_RETURN>("ITEM_RETURN");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "ITEM_RETURN",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "ITEM_RETURN");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inRETURN_CODE"></param>
        public static List<ITEM_RETURN> ReadByRETURN_CODE(string inRETURN_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<ITEM_RETURN>("ITEM_RETURN", posdb_vnmSqlDAC.newInParam("@RETURN_CODE", inRETURN_CODE));
        }
        #endregion DAC Methods
    }
}

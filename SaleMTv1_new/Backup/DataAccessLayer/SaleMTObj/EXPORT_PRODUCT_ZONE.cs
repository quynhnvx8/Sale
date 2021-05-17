using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXPORT_PRODUCT_ZONE
    {
        #region members
        string iNVOICE_CODE;
        DateTime? dATE_EXPORT;
        string sTORE_CODE;
        string zONE_CODE;
        string rAMARKS_EXPORT;
        string cREAT_BY;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("INVOICE_CODE", SqlDbType.VarChar, null)]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [SqlColumn("DATE_EXPORT", SqlDbType.DateTime)]
        public DateTime? DATE_EXPORT
        {
            get { return dATE_EXPORT; }
            set { dATE_EXPORT = value; }
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
        [SqlColumn("RAMARKS_EXPORT", SqlDbType.NVarChar)]
        public string RAMARKS_EXPORT
        {
            get { return rAMARKS_EXPORT; }
            set { rAMARKS_EXPORT = value; }
        }
        [SqlColumn("CREAT_BY", SqlDbType.NVarChar)]
        public string CREAT_BY
        {
            get { return cREAT_BY; }
            set { cREAT_BY = value; }
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
        public EXPORT_PRODUCT_ZONE() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXPORT_PRODUCT_ZONE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXPORT_PRODUCT_ZONE>("EXPORT_PRODUCT_ZONE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXPORT_PRODUCT_ZONE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXPORT_PRODUCT_ZONE");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inINVOICE_CODE"></param>
        public static List<EXPORT_PRODUCT_ZONE> ReadByINVOICE_CODE(string inINVOICE_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCT_ZONE>("EXPORT_PRODUCT_ZONE", posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", inINVOICE_CODE));
        }
        #endregion DAC Methods
    }
}

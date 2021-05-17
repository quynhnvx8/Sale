using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class IMPORT_PRODUCTS : IDataModel
    {
        #region members
        int id;
        string iMPORT_CODE;
        string iNVOICE_CODE;
        string pRODUCT_ID;
        int qUANTITY;
        DateTime? dATE_IMPORT;
        DateTime? dATE_CREATE;
        string rEMARKS;
        bool? sTATUS;
        int? dEPT_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("IMPORT_ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("IMPORT_CODE")]
        public string IMPORT_CODE
        {
            get { return iMPORT_CODE; }
            set { iMPORT_CODE = value; }
        }
        [StringSqlColumn("INVOICE_CODE")]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.Int)]
        public int QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [SqlColumn("DATE_IMPORT", SqlDbType.DateTime)]
        public DateTime? DATE_IMPORT
        {
            get { return dATE_IMPORT; }
            set { dATE_IMPORT = value; }
        }
        [SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
        public DateTime? DATE_CREATE
        {
            get { return dATE_CREATE; }
            set { dATE_CREATE = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [SqlColumn("STATUS", SqlDbType.Bit)]
        public bool? STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [SqlColumn("DEPT_CODE", SqlDbType.Int)]
        public int? DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
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
        public IMPORT_PRODUCTS() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public IMPORT_PRODUCTS(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<IMPORT_PRODUCTS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<IMPORT_PRODUCTS>("IMPORT_PRODUCTS");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<IMPORT_PRODUCTS>(this, "IMPORT_PRODUCTS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "IMPORT_PRODUCTS", isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "IMPORT_PRODUCTS");
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inPRODUCT_ID"></param>
        public static List<IMPORT_PRODUCTS> ReadByPRODUCT_ID(string inPRODUCT_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<IMPORT_PRODUCTS>("IMPORT_PRODUCTS", posdb_vnmSqlDAC.newInParam("@PRODUCT_ID", inPRODUCT_ID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inDEPT_CODE"></param>
        public static List<IMPORT_PRODUCTS> ReadByDEPT_CODE(int? inDEPT_CODE)
        {
            object parameter = inDEPT_CODE ?? 0;
            return posdb_vnmSqlDAC.ReadByParams<IMPORT_PRODUCTS>("IMPORT_PRODUCTS", posdb_vnmSqlDAC.newInParam("@DEPT_CODE", parameter));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class WAREHOUSE
    {
        #region members
        string wAREHOUSE_CODE;
        string wAREHOUSE_NAME;
        string wAREHOUSE_PARENT;
        string aDDRESS;
        string tEL;
        string fAX;
        string rEMARKS;
        int? wAREHOUSE_LEVEL;
        string pRICE_TABLE;
        bool? sTATUS;

        #endregion members
        #region Properties
        [PKSqlColumn("WAREHOUSE_CODE", SqlDbType.VarChar, null)]
        public string WAREHOUSE_CODE
        {
            get { return wAREHOUSE_CODE; }
            set { wAREHOUSE_CODE = value; }
        }
        [SqlColumn("WAREHOUSE_NAME", SqlDbType.NVarChar)]
        public string WAREHOUSE_NAME
        {
            get { return wAREHOUSE_NAME; }
            set { wAREHOUSE_NAME = value; }
        }
        [StringSqlColumn("WAREHOUSE_PARENT")]
        public string WAREHOUSE_PARENT
        {
            get { return wAREHOUSE_PARENT; }
            set { wAREHOUSE_PARENT = value; }
        }
        [SqlColumn("ADDRESS", SqlDbType.NVarChar)]
        public string ADDRESS
        {
            get { return aDDRESS; }
            set { aDDRESS = value; }
        }
        [StringSqlColumn("TEL")]
        public string TEL
        {
            get { return tEL; }
            set { tEL = value; }
        }
        [StringSqlColumn("FAX")]
        public string FAX
        {
            get { return fAX; }
            set { fAX = value; }
        }
        [StringSqlColumn("REMARKS")]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [SqlColumn("WAREHOUSE_LEVEL", SqlDbType.Int)]
        public int? WAREHOUSE_LEVEL
        {
            get { return wAREHOUSE_LEVEL; }
            set { wAREHOUSE_LEVEL = value; }
        }
        [StringSqlColumn("PRICE_TABLE")]
        public string PRICE_TABLE
        {
            get { return pRICE_TABLE; }
            set { pRICE_TABLE = value; }
        }
        [SqlColumn("STATUS", SqlDbType.Bit)]
        public bool? STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public WAREHOUSE() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<WAREHOUSE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<WAREHOUSE>("WAREHOUSE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "WAREHOUSE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "WAREHOUSE");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inWAREHOUSE_CODE"></param>
        public static List<WAREHOUSE> ReadByWAREHOUSE_CODE(string inWAREHOUSE_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<WAREHOUSE>("WAREHOUSE", posdb_vnmSqlDAC.newInParam("@WAREHOUSE_CODE", inWAREHOUSE_CODE));
        }
        #endregion DAC Methods
    }
}

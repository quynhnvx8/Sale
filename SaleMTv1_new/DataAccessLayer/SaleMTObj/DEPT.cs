using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DEPT
    {
        #region members
        int dEPT_CODE;
        string dEPT_NAME;
        string dEPT_NAME_LOCAL;
        int? dEPT_PARENT;
        string cOST_CENTER;
        int? sTATUS;
        string zONE_CODE;
        string sTORE_CODE;
        string aDDRESS;
        string tEL;
        string fAX;
        string rEMARK;
        string sTORE_TYPE_CODE;
        string sTORE_LOCATION_CODE;
        string mA_DON_VI;
        string mA_BO_PHAN;
        string mA_KHO;
        string mAKH;
        string pRICE;
        bool? aLLOW_EDIT_PRICE;
        int? tRUCTHUOC;

        #endregion members
        #region Properties
        [PKSqlColumn("DEPT_CODE", SqlDbType.Int,false)]
        public int DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }
        [SqlColumn("DEPT_NAME", SqlDbType.NVarChar)]
        public string DEPT_NAME
        {
            get { return dEPT_NAME; }
            set { dEPT_NAME = value; }
        }
        [SqlColumn("DEPT_NAME_LOCAL", SqlDbType.NVarChar)]
        public string DEPT_NAME_LOCAL
        {
            get { return dEPT_NAME_LOCAL; }
            set { dEPT_NAME_LOCAL = value; }
        }
        [SqlColumn("DEPT_PARENT", SqlDbType.Int)]
        public int? DEPT_PARENT
        {
            get { return dEPT_PARENT; }
            set { dEPT_PARENT = value; }
        }
        [StringSqlColumn("COST_CENTER")]
        public string COST_CENTER
        {
            get { return cOST_CENTER; }
            set { cOST_CENTER = value; }
        }
        [SqlColumn("STATUS", SqlDbType.Int)]
        public int? STATUS
        {
            get { return sTATUS; }
            set { sTATUS = value; }
        }
        [StringSqlColumn("ZONE_CODE")]
        public string ZONE_CODE
        {
            get { return zONE_CODE; }
            set { zONE_CODE = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("ADDRESS", SqlDbType.NVarChar)]
        public string ADDRESS
        {
            get { return aDDRESS; }
            set { aDDRESS = value; }
        }
        [SqlColumn("TEL", SqlDbType.NVarChar)]
        public string TEL
        {
            get { return tEL; }
            set { tEL = value; }
        }
        [SqlColumn("FAX", SqlDbType.NVarChar)]
        public string FAX
        {
            get { return fAX; }
            set { fAX = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [StringSqlColumn("STORE_TYPE_CODE")]
        public string STORE_TYPE_CODE
        {
            get { return sTORE_TYPE_CODE; }
            set { sTORE_TYPE_CODE = value; }
        }
        [StringSqlColumn("STORE_LOCATION_CODE")]
        public string STORE_LOCATION_CODE
        {
            get { return sTORE_LOCATION_CODE; }
            set { sTORE_LOCATION_CODE = value; }
        }
        [StringSqlColumn("MA_DON_VI")]
        public string MA_DON_VI
        {
            get { return mA_DON_VI; }
            set { mA_DON_VI = value; }
        }
        [StringSqlColumn("MA_BO_PHAN")]
        public string MA_BO_PHAN
        {
            get { return mA_BO_PHAN; }
            set { mA_BO_PHAN = value; }
        }
        [StringSqlColumn("MA_KHO")]
        public string MA_KHO
        {
            get { return mA_KHO; }
            set { mA_KHO = value; }
        }
        [StringSqlColumn("MAKH")]
        public string MAKH
        {
            get { return mAKH; }
            set { mAKH = value; }
        }
        [StringSqlColumn("PRICE")]
        public string PRICE
        {
            get { return pRICE; }
            set { pRICE = value; }
        }
        [SqlColumn("ALLOW_EDIT_PRICE", SqlDbType.Bit)]
        public bool? ALLOW_EDIT_PRICE
        {
            get { return aLLOW_EDIT_PRICE; }
            set { aLLOW_EDIT_PRICE = value; }
        }
        [SqlColumn("TRUCTHUOC", SqlDbType.Int)]
        public int? TRUCTHUOC
        {
            get { return tRUCTHUOC; }
            set { tRUCTHUOC = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DEPT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DEPT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DEPT>("DEPT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DEPT", isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DEPT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inDEPT_CODE"></param>
        public static List<DEPT> ReadByDEPT_CODE(int inDEPT_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<DEPT>("DEPT", posdb_vnmSqlDAC.newInParam("@DEPT_CODE", inDEPT_CODE));
        }
        #endregion DAC Methods
    }
}

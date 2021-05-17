using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class COMPANY_INFO
    {
        #region members
        string lANGUAGE;
        string cOMPANY_CODE;
        string cOMPANY_NAME;
        string pREFIX;
        string aDDRESS;
        string tEL;
        string fAX;
        string eMAIL_ADDRESS;
        string cOUNTRY_CODE;
        string eCONOMIC_COMPOSITION;
        string eCONOMIC_BRANCH;
        string sICODE;
        string hICODE;
        string pLACE_OF_WORK;
        string pICTURE_PATH;

        #endregion members
        #region Properties
        [PKSqlColumn("LANGUAGE", SqlDbType.NVarChar, null)]
        public string LANGUAGE
        {
            get { return lANGUAGE; }
            set { lANGUAGE = value; }
        }
        [PKSqlColumn("COMPANY_CODE", SqlDbType.VarChar, null)]
        public string COMPANY_CODE
        {
            get { return cOMPANY_CODE; }
            set { cOMPANY_CODE = value; }
        }
        [SqlColumn("COMPANY_NAME", SqlDbType.NVarChar)]
        public string COMPANY_NAME
        {
            get { return cOMPANY_NAME; }
            set { cOMPANY_NAME = value; }
        }
        [StringSqlColumn("PREFIX")]
        public string PREFIX
        {
            get { return pREFIX; }
            set { pREFIX = value; }
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
        [StringSqlColumn("EMAIL_ADDRESS")]
        public string EMAIL_ADDRESS
        {
            get { return eMAIL_ADDRESS; }
            set { eMAIL_ADDRESS = value; }
        }
        [StringSqlColumn("COUNTRY_CODE")]
        public string COUNTRY_CODE
        {
            get { return cOUNTRY_CODE; }
            set { cOUNTRY_CODE = value; }
        }
        [SqlColumn("ECONOMIC_COMPOSITION", SqlDbType.NVarChar)]
        public string ECONOMIC_COMPOSITION
        {
            get { return eCONOMIC_COMPOSITION; }
            set { eCONOMIC_COMPOSITION = value; }
        }
        [SqlColumn("ECONOMIC_BRANCH", SqlDbType.NVarChar)]
        public string ECONOMIC_BRANCH
        {
            get { return eCONOMIC_BRANCH; }
            set { eCONOMIC_BRANCH = value; }
        }
        [SqlColumn("SICODE", SqlDbType.NVarChar)]
        public string SICODE
        {
            get { return sICODE; }
            set { sICODE = value; }
        }
        [SqlColumn("HICODE", SqlDbType.NVarChar)]
        public string HICODE
        {
            get { return hICODE; }
            set { hICODE = value; }
        }
        [SqlColumn("PLACE_OF_WORK", SqlDbType.NVarChar)]
        public string PLACE_OF_WORK
        {
            get { return pLACE_OF_WORK; }
            set { pLACE_OF_WORK = value; }
        }
        [StringSqlColumn("PICTURE_PATH")]
        public string PICTURE_PATH
        {
            get { return pICTURE_PATH; }
            set { pICTURE_PATH = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public COMPANY_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<COMPANY_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<COMPANY_INFO>("COMPANY_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "COMPANY_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "COMPANY_INFO");
        }
        #endregion DAC Methods
    }
}

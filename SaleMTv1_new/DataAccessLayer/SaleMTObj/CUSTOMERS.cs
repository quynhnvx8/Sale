using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CUSTOMERS
    {
        #region members
        string cUSTOMER_ID;
        int? dEPT_CODE;
        string fIRST_NAME;
        string lAST_NAME;
        DateTime? dATE_OF_BIRTH;
        string pLACE_OF_BIRTH;
        string oCCUPATION_CODE;
        string oCCUPATION_OTHER;
        string mARITAL_STATUS;
        string sEX_CODE;
        string bLOOD_CODE;
        string rACE_CODE;
        string rELIGION_CODE;
        string cUSTOMER_GROUP_CODE;
        string iD_NO;
        DateTime? iD_NO_ISSUED_DATE;
        string iD_NO_ISSUED_PLACE;
        string pASSPORT_NO;
        DateTime? pASSPORT_NO_ISSUED_DATE;
        DateTime? pASSPORT_NO_EXPIRY_DATE;
        string pASSPORT_NO_ISSUED_PLACE;
        string tEL;
        string fAX;
        string mOBILE_PHONE;
        string eMAIL_ADDRESS;
        string cOUNTRY_CODE;
        string pROVINCE_CITY_CODE;
        string pROVINCE_CITY_OTHER;
        string dISTRICT_CODE;
        string dISTRICT_OTHER;
        string cOMMUNES_WARDS;
        string hOUSE_STREET;
        string aDDRESS;
        string wORKING_OFFICE;
        string oFFICE_ADDRESS;
        int? nUMBER_MARK;
        string aCTION_LOG;
        bool? iS_ACTIVE;
        string pICTURE_PATH;
        string rEMARK;
        DateTime? cREATE_DATE;
        string cREATE_BY;
        DateTime? uPDATE_DATE;
        string lAST_UPDATE_BY;
        string sTORE_CODE;
        string cUSTOMER_TYPE_CODE;
        float? mONEY;
        int? yEAR_OF_BIRTH;
        string tAX_CODE;
        string mACU;
        string bARCODE;
        string cOL_SEARCH;
        string eVENT_ID;
        bool? iS_PRIVATE;
        DateTime? cREATEDATECARD;

        #endregion members
        #region Properties
        [PKSqlColumn("CUSTOMER_ID", SqlDbType.VarChar, null)]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [SqlColumn("DEPT_CODE", SqlDbType.Int)]
        public int? DEPT_CODE
        {
            get { return dEPT_CODE; }
            set { dEPT_CODE = value; }
        }
        [SqlColumn("FIRST_NAME", SqlDbType.NVarChar)]
        public string FIRST_NAME
        {
            get { return fIRST_NAME; }
            set { fIRST_NAME = value; }
        }
        [SqlColumn("LAST_NAME", SqlDbType.NVarChar)]
        public string LAST_NAME
        {
            get { return lAST_NAME; }
            set { lAST_NAME = value; }
        }
        [SqlColumn("DATE_OF_BIRTH", SqlDbType.DateTime)]
        public DateTime? DATE_OF_BIRTH
        {
            get { return dATE_OF_BIRTH; }
            set { dATE_OF_BIRTH = value; }
        }
        [SqlColumn("PLACE_OF_BIRTH", SqlDbType.NVarChar)]
        public string PLACE_OF_BIRTH
        {
            get { return pLACE_OF_BIRTH; }
            set { pLACE_OF_BIRTH = value; }
        }
        [StringSqlColumn("OCCUPATION_CODE")]
        public string OCCUPATION_CODE
        {
            get { return oCCUPATION_CODE; }
            set { oCCUPATION_CODE = value; }
        }
        [SqlColumn("OCCUPATION_OTHER", SqlDbType.NVarChar)]
        public string OCCUPATION_OTHER
        {
            get { return oCCUPATION_OTHER; }
            set { oCCUPATION_OTHER = value; }
        }
        [StringSqlColumn("MARITAL_STATUS")]
        public string MARITAL_STATUS
        {
            get { return mARITAL_STATUS; }
            set { mARITAL_STATUS = value; }
        }
        [StringSqlColumn("SEX_CODE")]
        public string SEX_CODE
        {
            get { return sEX_CODE; }
            set { sEX_CODE = value; }
        }
        [StringSqlColumn("BLOOD_CODE")]
        public string BLOOD_CODE
        {
            get { return bLOOD_CODE; }
            set { bLOOD_CODE = value; }
        }
        [StringSqlColumn("RACE_CODE")]
        public string RACE_CODE
        {
            get { return rACE_CODE; }
            set { rACE_CODE = value; }
        }
        [StringSqlColumn("RELIGION_CODE")]
        public string RELIGION_CODE
        {
            get { return rELIGION_CODE; }
            set { rELIGION_CODE = value; }
        }
        [StringSqlColumn("CUSTOMER_GROUP_CODE")]
        public string CUSTOMER_GROUP_CODE
        {
            get { return cUSTOMER_GROUP_CODE; }
            set { cUSTOMER_GROUP_CODE = value; }
        }
        [StringSqlColumn("ID_NO")]
        public string ID_NO
        {
            get { return iD_NO; }
            set { iD_NO = value; }
        }
        [SqlColumn("ID_NO_ISSUED_DATE", SqlDbType.DateTime)]
        public DateTime? ID_NO_ISSUED_DATE
        {
            get { return iD_NO_ISSUED_DATE; }
            set { iD_NO_ISSUED_DATE = value; }
        }
        [SqlColumn("ID_NO_ISSUED_PLACE", SqlDbType.NVarChar)]
        public string ID_NO_ISSUED_PLACE
        {
            get { return iD_NO_ISSUED_PLACE; }
            set { iD_NO_ISSUED_PLACE = value; }
        }
        [StringSqlColumn("PASSPORT_NO")]
        public string PASSPORT_NO
        {
            get { return pASSPORT_NO; }
            set { pASSPORT_NO = value; }
        }
        [SqlColumn("PASSPORT_NO_ISSUED_DATE", SqlDbType.DateTime)]
        public DateTime? PASSPORT_NO_ISSUED_DATE
        {
            get { return pASSPORT_NO_ISSUED_DATE; }
            set { pASSPORT_NO_ISSUED_DATE = value; }
        }
        [SqlColumn("PASSPORT_NO_EXPIRY_DATE", SqlDbType.DateTime)]
        public DateTime? PASSPORT_NO_EXPIRY_DATE
        {
            get { return pASSPORT_NO_EXPIRY_DATE; }
            set { pASSPORT_NO_EXPIRY_DATE = value; }
        }
        [SqlColumn("PASSPORT_NO_ISSUED_PLACE", SqlDbType.NVarChar)]
        public string PASSPORT_NO_ISSUED_PLACE
        {
            get { return pASSPORT_NO_ISSUED_PLACE; }
            set { pASSPORT_NO_ISSUED_PLACE = value; }
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
        [StringSqlColumn("MOBILE_PHONE")]
        public string MOBILE_PHONE
        {
            get { return mOBILE_PHONE; }
            set { mOBILE_PHONE = value; }
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
        [StringSqlColumn("PROVINCE_CITY_CODE")]
        public string PROVINCE_CITY_CODE
        {
            get { return pROVINCE_CITY_CODE; }
            set { pROVINCE_CITY_CODE = value; }
        }
        [SqlColumn("PROVINCE_CITY_OTHER", SqlDbType.NVarChar)]
        public string PROVINCE_CITY_OTHER
        {
            get { return pROVINCE_CITY_OTHER; }
            set { pROVINCE_CITY_OTHER = value; }
        }
        [StringSqlColumn("DISTRICT_CODE")]
        public string DISTRICT_CODE
        {
            get { return dISTRICT_CODE; }
            set { dISTRICT_CODE = value; }
        }
        [SqlColumn("DISTRICT_OTHER", SqlDbType.NVarChar)]
        public string DISTRICT_OTHER
        {
            get { return dISTRICT_OTHER; }
            set { dISTRICT_OTHER = value; }
        }
        [SqlColumn("COMMUNES_WARDS", SqlDbType.NVarChar)]
        public string COMMUNES_WARDS
        {
            get { return cOMMUNES_WARDS; }
            set { cOMMUNES_WARDS = value; }
        }
        [SqlColumn("HOUSE_STREET", SqlDbType.NVarChar)]
        public string HOUSE_STREET
        {
            get { return hOUSE_STREET; }
            set { hOUSE_STREET = value; }
        }
        [SqlColumn("ADDRESS", SqlDbType.NVarChar)]
        public string ADDRESS
        {
            get { return aDDRESS; }
            set { aDDRESS = value; }
        }
        [SqlColumn("WORKING_OFFICE", SqlDbType.NVarChar)]
        public string WORKING_OFFICE
        {
            get { return wORKING_OFFICE; }
            set { wORKING_OFFICE = value; }
        }
        [SqlColumn("OFFICE_ADDRESS", SqlDbType.NVarChar)]
        public string OFFICE_ADDRESS
        {
            get { return oFFICE_ADDRESS; }
            set { oFFICE_ADDRESS = value; }
        }
        [SqlColumn("NUMBER_MARK", SqlDbType.Int)]
        public int? NUMBER_MARK
        {
            get { return nUMBER_MARK; }
            set { nUMBER_MARK = value; }
        }
        [SqlColumn("ACTION_LOG", SqlDbType.NText)]
        public string ACTION_LOG
        {
            get { return aCTION_LOG; }
            set { aCTION_LOG = value; }
        }
        [SqlColumn("IS_ACTIVE", SqlDbType.Bit)]
        public bool? IS_ACTIVE
        {
            get { return iS_ACTIVE; }
            set { iS_ACTIVE = value; }
        }
        [StringSqlColumn("PICTURE_PATH")]
        public string PICTURE_PATH
        {
            get { return pICTURE_PATH; }
            set { pICTURE_PATH = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
        public string CREATE_BY
        {
            get { return cREATE_BY; }
            set { cREATE_BY = value; }
        }
        [SqlColumn("UPDATE_DATE", SqlDbType.DateTime)]
        public DateTime? UPDATE_DATE
        {
            get { return uPDATE_DATE; }
            set { uPDATE_DATE = value; }
        }
        [SqlColumn("LAST_UPDATE_BY", SqlDbType.NVarChar)]
        public string LAST_UPDATE_BY
        {
            get { return lAST_UPDATE_BY; }
            set { lAST_UPDATE_BY = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [StringSqlColumn("CUSTOMER_TYPE_CODE")]
        public string CUSTOMER_TYPE_CODE
        {
            get { return cUSTOMER_TYPE_CODE; }
            set { cUSTOMER_TYPE_CODE = value; }
        }
        [SqlColumn("MONEY", SqlDbType.Float)]
        public float? MONEY
        {
            get { return mONEY; }
            set { mONEY = value; }
        }
        [SqlColumn("YEAR_OF_BIRTH", SqlDbType.Int)]
        public int? YEAR_OF_BIRTH
        {
            get { return yEAR_OF_BIRTH; }
            set { yEAR_OF_BIRTH = value; }
        }
        [StringSqlColumn("TAX_CODE")]
        public string TAX_CODE
        {
            get { return tAX_CODE; }
            set { tAX_CODE = value; }
        }
        [SqlColumn("MACU", SqlDbType.NVarChar)]
        public string MACU
        {
            get { return mACU; }
            set { mACU = value; }
        }
        [StringSqlColumn("BARCODE")]
        public string BARCODE
        {
            get { return bARCODE; }
            set { bARCODE = value; }
        }
        [SqlColumn("COL_SEARCH", SqlDbType.NVarChar)]
        public string COL_SEARCH
        {
            get { return cOL_SEARCH; }
            set { cOL_SEARCH = value; }
        }
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("IS_PRIVATE", SqlDbType.Bit)]
        public bool? IS_PRIVATE
        {
            get { return iS_PRIVATE; }
            set { iS_PRIVATE = value; }
        }
        [SqlColumn("CREATEDATECARD", SqlDbType.DateTime)]
        public DateTime? CREATEDATECARD
        {
            get { return cREATEDATECARD; }
            set { cREATEDATECARD = value; }
        }
        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CUSTOMERS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CUSTOMERS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CUSTOMERS>("CUSTOMERS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CUSTOMERS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CUSTOMERS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inCUSTOMER_ID"></param>
        public static List<CUSTOMERS> ReadByCUSTOMER_ID(string inCUSTOMER_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<CUSTOMERS>("CUSTOMERS", posdb_vnmSqlDAC.newInParam("@CUSTOMER_ID", inCUSTOMER_ID));
        }
        #endregion DAC Methods
    }
}

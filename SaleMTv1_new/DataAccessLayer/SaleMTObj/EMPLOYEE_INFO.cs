using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EMPLOYEE_INFO
    {
        #region members
        string eMPLOYEE_ID;
        int? dEPT_CODE;
        string fIRST_NAME;
        string lAST_NAME;
        string pOSITION_CODE;
        DateTime? dATE_OF_BIRTH;
        string mARRIED_STATUS;
        string sEX;
        string pLACE_OF_BIRTH;
        string iD_CARD;
        DateTime? iD_CARD_ISSUED_DATE;
        string iD_CARD_ISSUED_PLACE;
        string rESIDENT_ADDRESS;
        string rESIDENT_PHONE;
        string pERNAMENT_ADDRESS;
        string pERNAMENT_PHONE;
        string mOBILE;
        string eMAIL;
        string rEGION;
        string kNOWLEDGE;
        string mORE_INFO;
        DateTime? iNPUT_DATE;
        string wORKING_STATUS;
        DateTime? sTART_DATE;
        float? sALARY;
        DateTime? dATE_OFF;
        string pICTURE_PATH;
        string sTORE_CODE;
        string bARCODE;
        float? nORMS_DEBT_FOR;
        float? nORMS_DEBT_ALLOW;
        string eMPLOYEE_GROUP;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("EMPLOYEE_ID", SqlDbType.VarChar, null)]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
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
        [StringSqlColumn("POSITION_CODE")]
        public string POSITION_CODE
        {
            get { return pOSITION_CODE; }
            set { pOSITION_CODE = value; }
        }
        [SqlColumn("DATE_OF_BIRTH", SqlDbType.DateTime)]
        public DateTime? DATE_OF_BIRTH
        {
            get { return dATE_OF_BIRTH; }
            set { dATE_OF_BIRTH = value; }
        }
        [SqlColumn("MARRIED_STATUS", SqlDbType.NVarChar)]
        public string MARRIED_STATUS
        {
            get { return mARRIED_STATUS; }
            set { mARRIED_STATUS = value; }
        }
        [SqlColumn("SEX", SqlDbType.NVarChar)]
        public string SEX
        {
            get { return sEX; }
            set { sEX = value; }
        }
        [SqlColumn("PLACE_OF_BIRTH", SqlDbType.NVarChar)]
        public string PLACE_OF_BIRTH
        {
            get { return pLACE_OF_BIRTH; }
            set { pLACE_OF_BIRTH = value; }
        }
        [StringSqlColumn("ID_CARD")]
        public string ID_CARD
        {
            get { return iD_CARD; }
            set { iD_CARD = value; }
        }
        [SqlColumn("ID_CARD_ISSUED_DATE", SqlDbType.DateTime)]
        public DateTime? ID_CARD_ISSUED_DATE
        {
            get { return iD_CARD_ISSUED_DATE; }
            set { iD_CARD_ISSUED_DATE = value; }
        }
        [SqlColumn("ID_CARD_ISSUED_PLACE", SqlDbType.NVarChar)]
        public string ID_CARD_ISSUED_PLACE
        {
            get { return iD_CARD_ISSUED_PLACE; }
            set { iD_CARD_ISSUED_PLACE = value; }
        }
        [SqlColumn("RESIDENT_ADDRESS", SqlDbType.NVarChar)]
        public string RESIDENT_ADDRESS
        {
            get { return rESIDENT_ADDRESS; }
            set { rESIDENT_ADDRESS = value; }
        }
        [StringSqlColumn("RESIDENT_PHONE")]
        public string RESIDENT_PHONE
        {
            get { return rESIDENT_PHONE; }
            set { rESIDENT_PHONE = value; }
        }
        [SqlColumn("PERNAMENT_ADDRESS", SqlDbType.NVarChar)]
        public string PERNAMENT_ADDRESS
        {
            get { return pERNAMENT_ADDRESS; }
            set { pERNAMENT_ADDRESS = value; }
        }
        [StringSqlColumn("PERNAMENT_PHONE")]
        public string PERNAMENT_PHONE
        {
            get { return pERNAMENT_PHONE; }
            set { pERNAMENT_PHONE = value; }
        }
        [StringSqlColumn("MOBILE")]
        public string MOBILE
        {
            get { return mOBILE; }
            set { mOBILE = value; }
        }
        [StringSqlColumn("EMAIL")]
        public string EMAIL
        {
            get { return eMAIL; }
            set { eMAIL = value; }
        }
        [SqlColumn("REGION", SqlDbType.NVarChar)]
        public string REGION
        {
            get { return rEGION; }
            set { rEGION = value; }
        }
        [SqlColumn("KNOWLEDGE", SqlDbType.NVarChar)]
        public string KNOWLEDGE
        {
            get { return kNOWLEDGE; }
            set { kNOWLEDGE = value; }
        }
        [SqlColumn("MORE_INFO", SqlDbType.NVarChar)]
        public string MORE_INFO
        {
            get { return mORE_INFO; }
            set { mORE_INFO = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime? INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("WORKING_STATUS", SqlDbType.NVarChar)]
        public string WORKING_STATUS
        {
            get { return wORKING_STATUS; }
            set { wORKING_STATUS = value; }
        }
        [SqlColumn("START_DATE", SqlDbType.DateTime)]
        public DateTime? START_DATE
        {
            get { return sTART_DATE; }
            set { sTART_DATE = value; }
        }
        [SqlColumn("SALARY", SqlDbType.Float)]
        public float? SALARY
        {
            get { return sALARY; }
            set { sALARY = value; }
        }
        [SqlColumn("DATE_OFF", SqlDbType.DateTime)]
        public DateTime? DATE_OFF
        {
            get { return dATE_OFF; }
            set { dATE_OFF = value; }
        }
        [StringSqlColumn("PICTURE_PATH")]
        public string PICTURE_PATH
        {
            get { return pICTURE_PATH; }
            set { pICTURE_PATH = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [StringSqlColumn("BARCODE")]
        public string BARCODE
        {
            get { return bARCODE; }
            set { bARCODE = value; }
        }
        [SqlColumn("NORMS_DEBT_FOR", SqlDbType.Float)]
        public float? NORMS_DEBT_FOR
        {
            get { return nORMS_DEBT_FOR; }
            set { nORMS_DEBT_FOR = value; }
        }
        [SqlColumn("NORMS_DEBT_ALLOW", SqlDbType.Float)]
        public float? NORMS_DEBT_ALLOW
        {
            get { return nORMS_DEBT_ALLOW; }
            set { nORMS_DEBT_ALLOW = value; }
        }
        [SqlColumn("EMPLOYEE_GROUP", SqlDbType.NVarChar)]
        public string EMPLOYEE_GROUP
        {
            get { return eMPLOYEE_GROUP; }
            set { eMPLOYEE_GROUP = value; }
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
        public EMPLOYEE_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EMPLOYEE_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EMPLOYEE_INFO>("EMPLOYEE_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EMPLOYEE_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EMPLOYEE_INFO");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inEMPLOYEE_ID"></param>
        public static List<EMPLOYEE_INFO> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EMPLOYEE_INFO>("EMPLOYEE_INFO", posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", inEMPLOYEE_ID));
        }
        #endregion DAC Methods
    }
}

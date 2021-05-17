using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class WARRANTY
    {
        #region members
        string iD_NO_RECEIPT;
        DateTime? rECEIPT_DATE;
        DateTime? wARRANTY_RETURN_APPOINT_DATE;
        int? tYPE;
        string eMPLOYEE_ID;
        int? dEPT_CODE;
        string cUSTOMER_ID;
        string rEMARK;
        string wARRANTY_CARD;
        string wARRANTY_BARCODE;
        DateTime? cREATE_DATE;
        string eVENT_ID;
        string sTORE_CODE;
        float dEPOSIT;
        float bALANCE;
        string tRANSFER_SHIFT_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("ID_NO_RECEIPT", SqlDbType.VarChar, null)]
        public string ID_NO_RECEIPT
        {
            get { return iD_NO_RECEIPT; }
            set { iD_NO_RECEIPT = value; }
        }
        [SqlColumn("RECEIPT_DATE", SqlDbType.DateTime)]
        public DateTime? RECEIPT_DATE
        {
            get { return rECEIPT_DATE; }
            set { rECEIPT_DATE = value; }
        }
        [SqlColumn("WARRANTY_RETURN_APPOINT_DATE", SqlDbType.DateTime)]
        public DateTime? WARRANTY_RETURN_APPOINT_DATE
        {
            get { return wARRANTY_RETURN_APPOINT_DATE; }
            set { wARRANTY_RETURN_APPOINT_DATE = value; }
        }
        [SqlColumn("TYPE", SqlDbType.Int)]
        public int? TYPE
        {
            get { return tYPE; }
            set { tYPE = value; }
        }
        [StringSqlColumn("EMPLOYEE_ID")]
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
        [StringSqlColumn("CUSTOMER_ID")]
        public string CUSTOMER_ID
        {
            get { return cUSTOMER_ID; }
            set { cUSTOMER_ID = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("WARRANTY_CARD", SqlDbType.NVarChar)]
        public string WARRANTY_CARD
        {
            get { return wARRANTY_CARD; }
            set { wARRANTY_CARD = value; }
        }
        [SqlColumn("WARRANTY_BARCODE", SqlDbType.NVarChar)]
        public string WARRANTY_BARCODE
        {
            get { return wARRANTY_BARCODE; }
            set { wARRANTY_BARCODE = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("DEPOSIT", SqlDbType.Float)]
        public float DEPOSIT
        {
            get { return dEPOSIT; }
            set { dEPOSIT = value; }
        }
        [SqlColumn("BALANCE", SqlDbType.Float)]
        public float BALANCE
        {
            get { return bALANCE; }
            set { bALANCE = value; }
        }
        [StringSqlColumn("TRANSFER_SHIFT_CODE")]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public WARRANTY() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<WARRANTY> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<WARRANTY>("WARRANTY");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "WARRANTY",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "WARRANTY");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID_NO_RECEIPT"></param>
        public static List<WARRANTY> ReadByID_NO_RECEIPT(string inID_NO_RECEIPT)
        {
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY>("WARRANTY", posdb_vnmSqlDAC.newInParam("@ID_NO_RECEIPT", inID_NO_RECEIPT));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inEMPLOYEE_ID"></param>
        public static List<WARRANTY> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID)
        {
            object parameter = inEMPLOYEE_ID ?? string.Empty;
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY>("WARRANTY", posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", parameter));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inDEPT_CODE"></param>
        public static List<WARRANTY> ReadByDEPT_CODE(int? inDEPT_CODE)
        {
            object parameter = inDEPT_CODE ?? 0;
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY>("WARRANTY", posdb_vnmSqlDAC.newInParam("@DEPT_CODE", parameter));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inTRANSFER_SHIFT_CODE"></param>
        public static List<WARRANTY> ReadByTRANSFER_SHIFT_CODE(string inTRANSFER_SHIFT_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY>("WARRANTY", posdb_vnmSqlDAC.newInParam("@TRANSFER_SHIFT_CODE", inTRANSFER_SHIFT_CODE));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class WARRANTY_PAYMENT
    {
        #region members
        string iD;
        string iD_NO_RECEIPT;
        DateTime? dATE_PAYMENT;
        int? tIMES;
        float aMOUNT;
        string tRANSFER_SHIFT_CODE;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.VarChar, null)]
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("ID_NO_RECEIPT")]
        public string ID_NO_RECEIPT
        {
            get { return iD_NO_RECEIPT; }
            set { iD_NO_RECEIPT = value; }
        }
        [SqlColumn("DATE_PAYMENT", SqlDbType.DateTime)]
        public DateTime? DATE_PAYMENT
        {
            get { return dATE_PAYMENT; }
            set { dATE_PAYMENT = value; }
        }
        [SqlColumn("TIMES", SqlDbType.Int)]
        public int? TIMES
        {
            get { return tIMES; }
            set { tIMES = value; }
        }
        [SqlColumn("AMOUNT", SqlDbType.Float)]
        public float AMOUNT
        {
            get { return aMOUNT; }
            set { aMOUNT = value; }
        }
        [StringSqlColumn("TRANSFER_SHIFT_CODE")]
        public string TRANSFER_SHIFT_CODE
        {
            get { return tRANSFER_SHIFT_CODE; }
            set { tRANSFER_SHIFT_CODE = value; }
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
        public WARRANTY_PAYMENT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<WARRANTY_PAYMENT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<WARRANTY_PAYMENT>("WARRANTY_PAYMENT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "WARRANTY_PAYMENT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "WARRANTY_PAYMENT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<WARRANTY_PAYMENT> ReadByID(string inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY_PAYMENT>("WARRANTY_PAYMENT", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read By Foreign Key
        /// </summary>
        /// <param name="inID_NO_RECEIPT"></param>
        public static List<WARRANTY_PAYMENT> ReadByID_NO_RECEIPT(string inID_NO_RECEIPT)
        {
            object parameter = inID_NO_RECEIPT ?? string.Empty;
            return posdb_vnmSqlDAC.ReadByParams<WARRANTY_PAYMENT>("WARRANTY_PAYMENT", posdb_vnmSqlDAC.newInParam("@ID_NO_RECEIPT", parameter));
        }
        #endregion DAC Methods
    }
}

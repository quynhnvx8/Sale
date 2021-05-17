using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class BK_EVENT_CONFIG_ARG
    {
        #region members
        string sERVER_NAME;
        string dATABASE_NAME;
        string uSERNAME;
        string pASSWORD;
        string sCHEMA_NAME;
        float? tIMEOUT_CONNECT;
        float? iNTERVAL_SYNCHROUS;
        bool? iS_SHOW_ALERT;
        bool? iS_SYNCHROUS;
        bool? iS_AUTO_HIDE;
        float? iNTERVAL_CALL_SERVICE;
        float? iNTERVAL_EXE_QUERY;
        bool? iS_WIN_AUTHEN;

        #endregion members
        #region Properties
        [StringSqlColumn("SERVER_NAME")]
        public string SERVER_NAME
        {
            get { return sERVER_NAME; }
            set { sERVER_NAME = value; }
        }
        [StringSqlColumn("DATABASE_NAME")]
        public string DATABASE_NAME
        {
            get { return dATABASE_NAME; }
            set { dATABASE_NAME = value; }
        }
        [StringSqlColumn("USERNAME")]
        public string USERNAME
        {
            get { return uSERNAME; }
            set { uSERNAME = value; }
        }
        [StringSqlColumn("PASSWORD")]
        public string PASSWORD
        {
            get { return pASSWORD; }
            set { pASSWORD = value; }
        }
        [StringSqlColumn("SCHEMA_NAME")]
        public string SCHEMA_NAME
        {
            get { return sCHEMA_NAME; }
            set { sCHEMA_NAME = value; }
        }
        [SqlColumn("TIMEOUT_CONNECT", SqlDbType.Float)]
        public float? TIMEOUT_CONNECT
        {
            get { return tIMEOUT_CONNECT; }
            set { tIMEOUT_CONNECT = value; }
        }
        [SqlColumn("INTERVAL_SYNCHROUS", SqlDbType.Float)]
        public float? INTERVAL_SYNCHROUS
        {
            get { return iNTERVAL_SYNCHROUS; }
            set { iNTERVAL_SYNCHROUS = value; }
        }
        [SqlColumn("IS_SHOW_ALERT", SqlDbType.Bit)]
        public bool? IS_SHOW_ALERT
        {
            get { return iS_SHOW_ALERT; }
            set { iS_SHOW_ALERT = value; }
        }
        [SqlColumn("IS_SYNCHROUS", SqlDbType.Bit)]
        public bool? IS_SYNCHROUS
        {
            get { return iS_SYNCHROUS; }
            set { iS_SYNCHROUS = value; }
        }
        [SqlColumn("IS_AUTO_HIDE", SqlDbType.Bit)]
        public bool? IS_AUTO_HIDE
        {
            get { return iS_AUTO_HIDE; }
            set { iS_AUTO_HIDE = value; }
        }
        [SqlColumn("INTERVAL_CALL_SERVICE", SqlDbType.Float)]
        public float? INTERVAL_CALL_SERVICE
        {
            get { return iNTERVAL_CALL_SERVICE; }
            set { iNTERVAL_CALL_SERVICE = value; }
        }
        [SqlColumn("INTERVAL_EXE_QUERY", SqlDbType.Float)]
        public float? INTERVAL_EXE_QUERY
        {
            get { return iNTERVAL_EXE_QUERY; }
            set { iNTERVAL_EXE_QUERY = value; }
        }
        [SqlColumn("IS_WIN_AUTHEN", SqlDbType.Bit)]
        public bool? IS_WIN_AUTHEN
        {
            get { return iS_WIN_AUTHEN; }
            set { iS_WIN_AUTHEN = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public BK_EVENT_CONFIG_ARG() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<BK_EVENT_CONFIG_ARG> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<BK_EVENT_CONFIG_ARG>("BK_EVENT_CONFIG_ARG");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "BK_EVENT_CONFIG_ARG",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "BK_EVENT_CONFIG_ARG");
        }
        #endregion DAC Methods
    }
}
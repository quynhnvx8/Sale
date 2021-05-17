using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class SHIFT
    {
        #region members
        string sHIFT_CODE;
        string sHIFT_NAME;
        DateTime? tIME_START;
        DateTime? tIME_END;
        string rEMARK;

        #endregion members
        #region Properties
        [PKSqlColumn("SHIFT_CODE", SqlDbType.VarChar, null)]
        public string SHIFT_CODE
        {
            get { return sHIFT_CODE; }
            set { sHIFT_CODE = value; }
        }
        [SqlColumn("SHIFT_NAME", SqlDbType.NVarChar)]
        public string SHIFT_NAME
        {
            get { return sHIFT_NAME; }
            set { sHIFT_NAME = value; }
        }
        [SqlColumn("TIME_START", SqlDbType.DateTime)]
        public DateTime? TIME_START
        {
            get { return tIME_START; }
            set { tIME_START = value; }
        }
        [SqlColumn("TIME_END", SqlDbType.DateTime)]
        public DateTime? TIME_END
        {
            get { return tIME_END; }
            set { tIME_END = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public SHIFT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<SHIFT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<SHIFT>("SHIFT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "SHIFT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "SHIFT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inSHIFT_CODE"></param>
        public static List<SHIFT> ReadBySHIFT_CODE(string inSHIFT_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<SHIFT>("SHIFT", posdb_vnmSqlDAC.newInParam("@SHIFT_CODE", inSHIFT_CODE));
        }
        #endregion DAC Methods
    }
}

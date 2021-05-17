using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class VOUCHERS
    {
        #region members
        string vOUCHER_NO;
        string vOUCHER_NAME;
        DateTime? vOUCHER_DATE;
        DateTime? fROM_DATE;
        DateTime? tO_DATE;
        string rEMARK;
        string dISCOUNT_ON;
        DateTime? iNPUT_DATE;
        bool? iS_ADD_MORE;

        #endregion members
        #region Properties
        [PKSqlColumn("VOUCHER_NO", SqlDbType.VarChar, null)]
        public string VOUCHER_NO
        {
            get { return vOUCHER_NO; }
            set { vOUCHER_NO = value; }
        }
        [SqlColumn("VOUCHER_NAME", SqlDbType.NVarChar)]
        public string VOUCHER_NAME
        {
            get { return vOUCHER_NAME; }
            set { vOUCHER_NAME = value; }
        }
        [SqlColumn("VOUCHER_DATE", SqlDbType.DateTime)]
        public DateTime? VOUCHER_DATE
        {
            get { return vOUCHER_DATE; }
            set { vOUCHER_DATE = value; }
        }
        [SqlColumn("FROM_DATE", SqlDbType.DateTime)]
        public DateTime? FROM_DATE
        {
            get { return fROM_DATE; }
            set { fROM_DATE = value; }
        }
        [SqlColumn("TO_DATE", SqlDbType.DateTime)]
        public DateTime? TO_DATE
        {
            get { return tO_DATE; }
            set { tO_DATE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [StringSqlColumn("DISCOUNT_ON")]
        public string DISCOUNT_ON
        {
            get { return dISCOUNT_ON; }
            set { dISCOUNT_ON = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime? INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("IS_ADD_MORE", SqlDbType.Bit)]
        public bool? IS_ADD_MORE
        {
            get { return iS_ADD_MORE; }
            set { iS_ADD_MORE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public VOUCHERS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<VOUCHERS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<VOUCHERS>("VOUCHERS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "VOUCHERS", isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "VOUCHERS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inVOUCHER_NO"></param>
        public static List<VOUCHERS> ReadByVOUCHER_NO(string inVOUCHER_NO)
        {
            return posdb_vnmSqlDAC.ReadByParams<VOUCHERS>("VOUCHERS", posdb_vnmSqlDAC.newInParam("@VOUCHER_NO", inVOUCHER_NO));
        }
        #endregion DAC Methods
    }
}

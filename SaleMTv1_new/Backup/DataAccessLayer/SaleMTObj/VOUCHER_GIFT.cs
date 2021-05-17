using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class VOUCHER_GIFT
    {
        #region members
        string vOUCHER_GIFT_NO;
        string vOUCHER_GIFT_NAME;
        DateTime? vOUCHER_GIFT_DATE;
        string rEMARK;
        DateTime? iNPUT_DATE;
        bool? iS_STATUS;
        DateTime? fROM_DATE;
        DateTime? tO_DATE;
        int? dATE_VALUE;

        #endregion members
        #region Properties
        [PKSqlColumn("VOUCHER_GIFT_NO", SqlDbType.VarChar, null)]
        public string VOUCHER_GIFT_NO
        {
            get { return vOUCHER_GIFT_NO; }
            set { vOUCHER_GIFT_NO = value; }
        }
        [SqlColumn("VOUCHER_GIFT_NAME", SqlDbType.NVarChar)]
        public string VOUCHER_GIFT_NAME
        {
            get { return vOUCHER_GIFT_NAME; }
            set { vOUCHER_GIFT_NAME = value; }
        }
        [SqlColumn("VOUCHER_GIFT_DATE", SqlDbType.DateTime)]
        public DateTime? VOUCHER_GIFT_DATE
        {
            get { return vOUCHER_GIFT_DATE; }
            set { vOUCHER_GIFT_DATE = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime? INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("IS_STATUS", SqlDbType.Bit)]
        public bool? IS_STATUS
        {
            get { return iS_STATUS; }
            set { iS_STATUS = value; }
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
        [SqlColumn("DATE_VALUE", SqlDbType.Int)]
        public int? DATE_VALUE
        {
            get { return dATE_VALUE; }
            set { dATE_VALUE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public VOUCHER_GIFT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<VOUCHER_GIFT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<VOUCHER_GIFT>("VOUCHER_GIFT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "VOUCHER_GIFT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "VOUCHER_GIFT");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inVOUCHER_GIFT_NO"></param>
        public static List<VOUCHER_GIFT> ReadByVOUCHER_GIFT_NO(string inVOUCHER_GIFT_NO)
        {
            return posdb_vnmSqlDAC.ReadByParams<VOUCHER_GIFT>("VOUCHER_GIFT", posdb_vnmSqlDAC.newInParam("@VOUCHER_GIFT_NO", inVOUCHER_GIFT_NO));
        }
        #endregion DAC Methods
    }
}

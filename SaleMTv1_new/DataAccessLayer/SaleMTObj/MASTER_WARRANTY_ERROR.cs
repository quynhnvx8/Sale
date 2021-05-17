using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_WARRANTY_ERROR
    {
        #region members
        string wARRANTY_ERROR_CODE;
        string wARRANTY_ERROR_NAME;
        string rEMARK;
        float? wARRANTY_ERROR_PRICE;
        string pRODUCT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("WARRANTY_ERROR_CODE", SqlDbType.VarChar, null)]
        public string WARRANTY_ERROR_CODE
        {
            get { return wARRANTY_ERROR_CODE; }
            set { wARRANTY_ERROR_CODE = value; }
        }
        [SqlColumn("WARRANTY_ERROR_NAME", SqlDbType.NVarChar)]
        public string WARRANTY_ERROR_NAME
        {
            get { return wARRANTY_ERROR_NAME; }
            set { wARRANTY_ERROR_NAME = value; }
        }
        [SqlColumn("REMARK", SqlDbType.NVarChar)]
        public string REMARK
        {
            get { return rEMARK; }
            set { rEMARK = value; }
        }
        [SqlColumn("WARRANTY_ERROR_PRICE", SqlDbType.Float)]
        public float? WARRANTY_ERROR_PRICE
        {
            get { return wARRANTY_ERROR_PRICE; }
            set { wARRANTY_ERROR_PRICE = value; }
        }
        [StringSqlColumn("PRODUCT_ID")]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MASTER_WARRANTY_ERROR() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_WARRANTY_ERROR> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_WARRANTY_ERROR>("MASTER_WARRANTY_ERROR");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_WARRANTY_ERROR",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_WARRANTY_ERROR");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inWARRANTY_ERROR_CODE"></param>
        public static List<MASTER_WARRANTY_ERROR> ReadByWARRANTY_ERROR_CODE(string inWARRANTY_ERROR_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_WARRANTY_ERROR>("MASTER_WARRANTY_ERROR", posdb_vnmSqlDAC.newInParam("@WARRANTY_ERROR_CODE", inWARRANTY_ERROR_CODE));
        }
        #endregion DAC Methods
    }
}

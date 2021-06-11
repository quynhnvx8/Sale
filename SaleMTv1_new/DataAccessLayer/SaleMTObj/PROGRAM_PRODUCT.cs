using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PROGRAM_PRODUCT
    {
        #region members
        string pROGRAM_NO;
        string pRODUCT_ID;
        string pRODUCT_GIF_ID;
        int? pQTY;
        int? pQTY_GIF;
        float? mAMT;
        #endregion members
        #region Properties
        [PKSqlColumn("PROGRAM_NO", SqlDbType.VarChar, null)]
        public string PROGRAM_NO
        {
            get { return pROGRAM_NO; }
            set { pROGRAM_NO = value; }
        }
        [PKSqlColumn("PRODUCT_ID", SqlDbType.VarChar, null)]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }

        [PKSqlColumn("PRODUCT_GIF_ID", SqlDbType.VarChar, null)]
        public string PRODUCT_GIF_ID
        {
            get { return pRODUCT_GIF_ID; }
            set { pRODUCT_GIF_ID = value; }
        }

        [SqlColumn("QTY_GIF", SqlDbType.Int)]
        public int? QTY_GIF
        {
            get { return pQTY_GIF; }
            set { pQTY_GIF = value; }
        }

        [SqlColumn("QTY", SqlDbType.Int)]
        public int? QTY
        {
            get { return pQTY; }
            set { pQTY = value; }
        }

        [SqlColumn("AMT", SqlDbType.Float)]
        public float? AMT
        {
            get { return mAMT; }
            set { mAMT = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PROGRAM_PRODUCT() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PROGRAM_PRODUCT> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PROGRAM_PRODUCT>("PROGRAM_PRODUCT");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PROGRAM_PRODUCT",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PROGRAM_PRODUCT");
        }
        #endregion DAC Methods
    }
}

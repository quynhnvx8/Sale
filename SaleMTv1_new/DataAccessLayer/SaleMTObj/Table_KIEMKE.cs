using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class Table_KIEMKE : IDataModel
    {
        #region members
        int id;
        string mAKK;
        string cAT;
        string pRODUCT_GROUP;
        string pRODUCT_ID;
        string pRODUCT_NAME;
        long? qUANTITY;
        float? pRODUCT_PRICE;
        float? tOTAL_MONEY;
        long? sL_PACKET;
        long? sL_LE;
        long? tOTAL_INPUT;
        long? sL_LECH;
        string dVT_PACKET;
        long? sLQUYDOI;
        string dVT_LE;
        DateTime? cREATE_DATE;
        string cREATE_BY;
        string sTORE_CODE;
        string zONE_CODE;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.BigInt, 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [SqlColumn("MAKK", SqlDbType.NVarChar)]
        public string MAKK
        {
            get { return mAKK; }
            set { mAKK = value; }
        }
        [SqlColumn("CAT", SqlDbType.NVarChar)]
        public string CAT
        {
            get { return cAT; }
            set { cAT = value; }
        }
        [SqlColumn("PRODUCT_GROUP", SqlDbType.NVarChar)]
        public string PRODUCT_GROUP
        {
            get { return pRODUCT_GROUP; }
            set { pRODUCT_GROUP = value; }
        }
        [SqlColumn("PRODUCT_ID", SqlDbType.NVarChar)]
        public string PRODUCT_ID
        {
            get { return pRODUCT_ID; }
            set { pRODUCT_ID = value; }
        }
        [SqlColumn("PRODUCT_NAME", SqlDbType.NVarChar)]
        public string PRODUCT_NAME
        {
            get { return pRODUCT_NAME; }
            set { pRODUCT_NAME = value; }
        }
        [SqlColumn("QUANTITY", SqlDbType.BigInt)]
        public long? QUANTITY
        {
            get { return qUANTITY; }
            set { qUANTITY = value; }
        }
        [SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
        public float? PRODUCT_PRICE
        {
            get { return pRODUCT_PRICE; }
            set { pRODUCT_PRICE = value; }
        }
        [SqlColumn("TOTAL_MONEY", SqlDbType.Float)]
        public float? TOTAL_MONEY
        {
            get { return tOTAL_MONEY; }
            set { tOTAL_MONEY = value; }
        }
        [SqlColumn("SL_PACKET", SqlDbType.BigInt)]
        public long? SL_PACKET
        {
            get { return sL_PACKET; }
            set { sL_PACKET = value; }
        }
        [SqlColumn("SL_LE", SqlDbType.BigInt)]
        public long? SL_LE
        {
            get { return sL_LE; }
            set { sL_LE = value; }
        }
        [SqlColumn("TOTAL_INPUT", SqlDbType.BigInt)]
        public long? TOTAL_INPUT
        {
            get { return tOTAL_INPUT; }
            set { tOTAL_INPUT = value; }
        }
        [SqlColumn("SL_LECH", SqlDbType.BigInt)]
        public long? SL_LECH
        {
            get { return sL_LECH; }
            set { sL_LECH = value; }
        }
        [SqlColumn("DVT_PACKET", SqlDbType.NVarChar)]
        public string DVT_PACKET
        {
            get { return dVT_PACKET; }
            set { dVT_PACKET = value; }
        }
        [SqlColumn("SLQUYDOI", SqlDbType.BigInt)]
        public long? SLQUYDOI
        {
            get { return sLQUYDOI; }
            set { sLQUYDOI = value; }
        }
        [SqlColumn("DVT_LE", SqlDbType.NVarChar)]
        public string DVT_LE
        {
            get { return dVT_LE; }
            set { dVT_LE = value; }
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
        [SqlColumn("STORE_CODE", SqlDbType.NVarChar)]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [SqlColumn("ZONE_CODE", SqlDbType.NVarChar)]
        public string ZONE_CODE
        {
            get { return zONE_CODE; }
            set { zONE_CODE = value; }
        }

        #endregion Properties
        #region IsNew()
        public bool IsNew()
        {
            return id == 0;
        }

        #endregion IsNew()
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public Table_KIEMKE() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public Table_KIEMKE(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<Table_KIEMKE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<Table_KIEMKE>("Table_KIEMKE");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<Table_KIEMKE>(this, "Table_KIEMKE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "Table_KIEMKE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "Table_KIEMKE");
        }
        #endregion DAC Methods
    }
}

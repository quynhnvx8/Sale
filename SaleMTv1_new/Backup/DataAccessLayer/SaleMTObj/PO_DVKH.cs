using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class PO_DVKH 
    {
        #region members
        int autoId;
        string distCode;
        string pONumber;
        string pOCONumber;
        string itemCode;
        string itemDescr;
        string uOM;
        string siteID;
        float? quantity;
        decimal? price;
        float? lineTotal;
        string saleOrderNumber;
        DateTime? createDate;
        string createBy;
        DateTime? orderDate;
        string soNoiBo;
        bool? isActive;
        string dataType;
        int? quantitySuspend;

        #endregion members
        #region Properties
        [PKSqlColumn("AutoId", 0)]
        public int AutoId
        {
            get { return autoId; }
            set { autoId = value; }
        }
        [StringSqlColumn("DistCode")]
        public string DistCode
        {
            get { return distCode; }
            set { distCode = value; }
        }
        [StringSqlColumn("PONumber")]
        public string PONumber
        {
            get { return pONumber; }
            set { pONumber = value; }
        }
        [StringSqlColumn("POCONumber")]
        public string POCONumber
        {
            get { return pOCONumber; }
            set { pOCONumber = value; }
        }
        [StringSqlColumn("ItemCode")]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }
        [StringSqlColumn("ItemDescr")]
        public string ItemDescr
        {
            get { return itemDescr; }
            set { itemDescr = value; }
        }
        [StringSqlColumn("UOM")]
        public string UOM
        {
            get { return uOM; }
            set { uOM = value; }
        }
        [StringSqlColumn("SiteID")]
        public string SiteID
        {
            get { return siteID; }
            set { siteID = value; }
        }
        [SqlColumn("Quantity", SqlDbType.Float)]
        public float? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        [SqlColumn("Price", SqlDbType.Decimal)]
        public decimal? Price
        {
            get { return price; }
            set { price = value; }
        }
        [SqlColumn("LineTotal", SqlDbType.Float)]
        public float? LineTotal
        {
            get { return lineTotal; }
            set { lineTotal = value; }
        }
        [StringSqlColumn("SaleOrderNumber")]
        public string SaleOrderNumber
        {
            get { return saleOrderNumber; }
            set { saleOrderNumber = value; }
        }
        [SqlColumn("CreateDate", SqlDbType.DateTime)]
        public DateTime? CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        [SqlColumn("CreateBy", SqlDbType.NVarChar)]
        public string CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }
        [SqlColumn("OrderDate", SqlDbType.DateTime)]
        public DateTime? OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        [StringSqlColumn("SoNoiBo")]
        public string SoNoiBo
        {
            get { return soNoiBo; }
            set { soNoiBo = value; }
        }
        [SqlColumn("IsActive", SqlDbType.Bit)]
        public bool? IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        [StringSqlColumn("DataType")]
        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        [SqlColumn("QuantitySuspend", SqlDbType.Int)]
        public int? QuantitySuspend
        {
            get { return quantitySuspend; }
            set { quantitySuspend = value; }
        }

        #endregion Properties
       
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public PO_DVKH() { }
        

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<PO_DVKH> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<PO_DVKH>("PO_DVKH");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<PO_DVKH>(this, "PO_DVKH");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "PO_DVKH",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "PO_DVKH");
        }
        /// <summary>
        ///Read by IsActive Flag
        /// </summary>
        /// <param name="inIsActive">0: FALSE, 1: TRUE, 2:NULL</param>
        public static List<PO_DVKH> ReadByIsActive(bool? inIsActive) 
        {		
            object parameter = inIsActive.HasValue ? (inIsActive.Value ? 1 : 0) : 2;
		    return posdb_vnmSqlDAC.ReadByParams<PO_DVKH>("PO_DVKH", posdb_vnmSqlDAC.newInParam("@IsActive", parameter));
	    }
        public static List<PO_DVKH> ReadByAutoId(int autoId)
        {
            return posdb_vnmSqlDAC.ReadByParams<PO_DVKH>("PO_DVKH", posdb_vnmSqlDAC.newInParam("@AutoId", autoId));
        }
        #endregion DAC Methods
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class SALE_ORDERS
    {
        #region members
        Guid iD;
        string sale_Order_Parent_Code;
        string store_Code;
        string customerID;
        string productID;
        string description;
        DateTime deliveredOn;
        string priority;
        string createdBy;
        DateTime createdOn;
        DateTime reminderBegin;
        DateTime lastReminder;
        string eVENT_ID;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [SqlColumn("Sale_Order_Parent_Code", SqlDbType.NVarChar)]
        public string Sale_Order_Parent_Code
        {
            get { return sale_Order_Parent_Code; }
            set { sale_Order_Parent_Code = value; }
        }
        [StringSqlColumn("Store_Code")]
        public string Store_Code
        {
            get { return store_Code; }
            set { store_Code = value; }
        }
        [StringSqlColumn("CustomerID")]
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        [StringSqlColumn("ProductID")]
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        [SqlColumn("Description", SqlDbType.NVarChar)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [SqlColumn("DeliveredOn", SqlDbType.DateTime)]
        public DateTime DeliveredOn
        {
            get { return deliveredOn; }
            set { deliveredOn = value; }
        }
        [StringSqlColumn("Priority")]
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        [SqlColumn("CreatedBy", SqlDbType.NVarChar)]
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        [SqlColumn("CreatedOn", SqlDbType.DateTime)]
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        [SqlColumn("ReminderBegin", SqlDbType.DateTime)]
        public DateTime ReminderBegin
        {
            get { return reminderBegin; }
            set { reminderBegin = value; }
        }
        [SqlColumn("LastReminder", SqlDbType.DateTime)]
        public DateTime LastReminder
        {
            get { return lastReminder; }
            set { lastReminder = value; }
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
        public SALE_ORDERS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<SALE_ORDERS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<SALE_ORDERS>("SALE_ORDERS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "SALE_ORDERS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "SALE_ORDERS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<SALE_ORDERS> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<SALE_ORDERS>("SALE_ORDERS", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        #endregion DAC Methods
    }
}

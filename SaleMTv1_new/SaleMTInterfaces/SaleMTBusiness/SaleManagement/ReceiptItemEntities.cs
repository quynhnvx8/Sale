using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptItemEntities
    {
        #region member
        private string id;
        private string exportCode;
        private DateTime exportDate;
        private DateTime inputDate;

        private float priceSale;
        private float amount;
        private float totalamount;
        private float totaldiscount;
        private int quantity;
        private float realPrice;

        private string productID;
        private string productName;
        private string printName;
        private string barcode;
        private string unitName;
        private string remark;
        private string pID;
        private string redinvoiceCat;

        private float rebate;
        private float discount;
        private float promotion;
        #endregion
        #region Properties
        public float RealPrice
        {
            get { return realPrice; }
            set { realPrice = value; }
        }
        public float Rebate
        {
            get { return rebate; }
            set { rebate = value; }
        }
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public float Promotion
        {
            get { return promotion; }
            set { promotion = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string ExportCode
        {
            get { return exportCode; }
            set { exportCode = value; }
        }
        public DateTime ExportDate
        {
            get { return exportDate; }
            set { exportDate = value; }
        }
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public float PriceSale
        {
            get { return priceSale; }
            set { priceSale = value; }
        }
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public float TotalAmount
        {
            get { return totalamount; }
            set { totalamount = value; }
        }
        public float TotalDiscount
        {
            get { return totaldiscount; }
            set { totaldiscount = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string PrintName
        {
            get { return printName; }
            set { printName = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }
        public string PID
        {
            get { return pID; }
            set { pID = value; }
        }
        public string RedInvoiceCat
        {
            get { return redinvoiceCat; }
            set { redinvoiceCat = value; }
        }
        #endregion
    }
}

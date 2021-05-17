using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class RedInvoiceProductEntities
    {
        #region member
        private string productID;
        private string productName;
        private string unit;
        private string cat;
        private int quantity;
        private float priceSale;
        private float priceTotal;
        private float vat;
        private string remark;
        #endregion

        #region Properties
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
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public string Cat
        {
            get { return cat; }
            set { cat = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public float PriceSale
        {
            get { return priceSale; }
            set { priceSale = value; }
        }
        public float PriceTotal
        {
            get { return priceTotal; }
            set { priceTotal = value; }
        }
        public float Vat
        {
            get { return vat; }
            set { vat = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        #endregion
    }
}

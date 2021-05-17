using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptGiftEntities
    {
        #region member
        private string exportCode;

        private float priceSale;
        private int quantity;

        private string productID;
        private string productName;
        private string printName;
        private string barcode;
        private string unitName;
        private string remark;
        #endregion

        #region Properties
        public string ExportCode
        {
            get { return exportCode; }
            set { exportCode = value; }
        }
        public float PriceSale
        {
            get { return priceSale; }
            set { priceSale = value; }
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
        #endregion
    }
}

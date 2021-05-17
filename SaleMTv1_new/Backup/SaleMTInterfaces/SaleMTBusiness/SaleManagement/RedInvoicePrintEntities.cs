using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class RedInvoicePrintEntities
    {
        #region member
        private string autoID;
        private DateTime printDate;
        private DateTime createDate;

        private int totalQuantity;
        private float totalMoney;

        private string officeWorking;
        private string officeAddress;
        private string taxCode;
        private string userCreate;
        private string remark;
        private string customerID;
        private string paymentType;
        private string listInvoice;
        private string invoiceNO;

        private List<RedInvoiceProductEntities> productList;
        #endregion

        #region Properties
        public string AutoID
        {
            get { return autoID; }
            set { autoID = value; }
        }
        public DateTime PrintDate
        {
            get { return printDate; }
            set { printDate = value; }
        }
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        public int TotalQuantity
        {
            get { return totalQuantity; }
            set { totalQuantity = value; }
        }
        public float TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }
        public string OfficeWorking
        {
            get { return officeWorking; }
            set { officeWorking = value; }
        }
        public string OfficeAddress
        {
            get { return officeAddress; }
            set { officeAddress = value; }
        }
        public string TaxCode
        {
            get { return taxCode; }
            set { taxCode = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string UserCreate
        {
            get { return userCreate; }
            set { userCreate = value; }
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }
        public string ListInvoice
        {
            get { return listInvoice; }
            set { listInvoice = value; }
        }
        public string InvoiceNo
        {
            get { return invoiceNO; }
            set { invoiceNO = value; }
        }
        public List<RedInvoiceProductEntities> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }
        public float VAT
        {
            get 
            {
                return totalMoney * (float)0.1;
            }
        }
        public float TotalVAT
        {
            get
            {
                return totalMoney * (float)1.1;
            }
        }
        
        #endregion
    }
}

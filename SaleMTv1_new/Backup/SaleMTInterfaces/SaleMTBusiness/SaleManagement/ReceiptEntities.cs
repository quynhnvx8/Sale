using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptEntities
    {
        #region member
        private string exportCode;
        private DateTime exportDate;
        private DateTime inputDate;

        private float totalAmount;
        private float totalDiscount;
        private float totalPromotion;
        private float totalPayment;
        private float totalPaid;
        private float balance;

        private string customerFirtName;
        private string customerLastName;
        private string account;
        private string customerID;
        private string storeCode;
        private string currencyID;
        private string eventID;
        private string shiftCode;
        private string redinvoiceRemark;
        private string remark;

        private string redinvoiceTaxcode;
        private string redinvoiceAddress;
        private string redinvoiceCompany;        
        private bool usedRedInvoice;
        private bool selected;
        private List<ReceiptItemEntities> listItems;
        private List<ReceiptGiftEntities> listGifts;
        private List<ReceiptPaymentEntities> listPayments;
        private List<ReceiptCardEntities> listCards;
        private List<ReceiptPromotionEntities> listPromos;

        private int paymentTime;
        private DateTime paymentDate;
        private float paymentAmount;
        private float paymentRefund;
        private float paymentTotal;
        private float paymentBalance;
        private string paymentCashier;
        private string paymentID;

        private string discountTerm;
        private string discountType;
        private string discountBy;
        private string discountAuth;
        private float discountPercent;
        private float discountAmount;
        private float discountTotal;
        private string discountID;
        #endregion

        #region Properties
        public float TotalDiscount
        {
            get { return totalDiscount; }
            set { totalDiscount = value; }
        }
        public float TotalPromotion
        {
            get { return totalPromotion; }
            set { totalPromotion = value; }
        }
        public float TotalPaid
        {
            get { return totalPaid; }
            set { totalPaid = value; }
        }
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        public string DiscountID
        {
            get { return discountID; }
            set { discountID = value; }
        }
        public float DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }
        public float DiscountTotal
        {
            get { return discountTotal; }
            set { discountTotal = value; }
        }
        public float DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
        public string DiscountTerm
        {
            get { return discountTerm; }
            set { discountTerm = value; }
        }
        public string DiscountType
        {
            get { return discountType; }
            set { discountType = value; }
        }
        public string DiscountBy
        {
            get { return discountBy; }
            set { discountBy = value; }
        }
        public string DiscountAuth
        {
            get { return discountAuth; }
            set { discountAuth = value; }
        }
        public float PaymentBalance
        {
            get { return paymentBalance; }
            set { paymentBalance = value; }
        }
        public int PaymentTime
        {
            get { return paymentTime; }
            set { paymentTime = value; }
        }
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
        public float PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        public float PaymentRefund
        {
            get { return paymentRefund; }
            set { paymentRefund = value; }
        }
        public float PaymentTotal
        {
            get { return paymentTotal; }
            set { paymentTotal = value; }
        }
        public string PaymentCashier
        {
            get { return paymentCashier; }
            set { paymentCashier = value; }
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

        public float TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public float TotalPayment
        {
            get { return totalPayment; }
            set { totalPayment = value; }
        }

        public string CustomerFirstName
        {
            get { return customerFirtName; }
            set { customerFirtName = value; }
        }
        public string CustomerLastName
        {
            get { return customerLastName; }
            set { customerLastName = value; }
        }
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string StoreCode
        {
            get { return storeCode; }
            set { storeCode = value; }
        }
        public string CurrencyID
        {
            get { return currencyID; }
            set { currencyID = value; }
        }
        public string EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public string ShiftCode
        {
            get { return shiftCode; }
            set { shiftCode = value; }
        }
        public string RedInvoiceRemark
        {
            get { return redinvoiceRemark; }
            set { redinvoiceRemark = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string RedInvoiceTaxCode
        {
            get { return redinvoiceTaxcode; }
            set { redinvoiceTaxcode = value; }
        }
        public string RedInvoiceAddress
        {
            get { return redinvoiceAddress; }
            set { redinvoiceAddress = value; }
        }
        public string RedInvoiceCompany
        {
            get { return redinvoiceCompany; }
            set { redinvoiceCompany = value; }
        }
        public bool UsedRedInvoice
        {
            get { return usedRedInvoice; }
            set { usedRedInvoice = value; }
        }
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        public List<ReceiptItemEntities> ListItems
        {
            get { return listItems; }
            set { listItems = value; }
        }
        public List<ReceiptGiftEntities> ListGifts
        {
            get { return listGifts; }
            set { listGifts = value; }
        }
        public List<ReceiptPaymentEntities> ListPayments
        {
            get { return listPayments; }
            set { listPayments = value; }
        }
        public List<ReceiptCardEntities> ListCards
        {
            get { return listCards; }
            set { listCards = value; }
        }
        public List<ReceiptPromotionEntities> ListPromos
        {
            get { return listPromos; }
            set { listPromos = value; }
        }
        #endregion
    }
}

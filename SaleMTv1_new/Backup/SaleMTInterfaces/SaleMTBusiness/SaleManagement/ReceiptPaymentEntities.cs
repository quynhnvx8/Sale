using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptPaymentEntities
    {
        #region member
        private string id;
        private string paymentID;
        private string paymentCurrency;
        private float paymentRate;
        private float paymentMoney;
        private float paymentAmount;
        
        #endregion
        #region Properties
        
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        public string PaymentCurrency
        {
            get { return paymentCurrency; }
            set { paymentCurrency = value; }
        }
        public float PaymentRate
        {
            get { return paymentRate; }
            set { paymentRate = value; }
        }
        public float PaymentMoney
        {
            get { return paymentMoney; }
            set { paymentMoney = value; }
        }
        public float PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptCardEntities
    {
        #region member
        private string id;
        private string paymentID;
        private string cardName;
        private float cardAmount;

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
        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        public float CardAmount
        {
            get { return cardAmount; }
            set { cardAmount = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class PaymentEntities
    {
        
        private string remarks;
        private float money;
        private float totalPay;
        private float refund;
        private float totalReceived;
        private float moneyCard;
        private string cardType;        
        private float amount;
        private double cusPurchase;

        public double CusPurchase
        {
            get { return cusPurchase; }
            set { cusPurchase = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public float Money
        {
            get { return money; }
            set { money = value; }
        }       
        public float TotalPay
        {
            get { return totalPay; }
            set { totalPay = value; }
        }
        public float Refund
        {
            get { return refund; }
            set { refund = value; }
        }
        public float TotalReceived
        {
            get { return totalReceived; }
            set { totalReceived = value; }
        }
        public float MoneyCard
        {
            get { return moneyCard; }
            set { moneyCard = value; }
        }
        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }        

    }
}

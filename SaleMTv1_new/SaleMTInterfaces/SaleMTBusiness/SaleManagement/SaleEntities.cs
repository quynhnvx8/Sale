using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SaleMTBusiness.SaleManagement
{
    public class SaleEntities
    {
        // Product
        #region member
        private string productCode;
        private int quantity;
        // Customor
        private string cusCode;
        private string cusName;
        private string cusAdress;
        private string cusGroup;
        private double cusPurchase;        
        //Payment
        private string amount;
        private string totalPay;
        private string discount;
        private string specialDiscount;
        private string promotion;
        private DateTime datetime;
        //SpecialDiscount
        private float percent;
        private float money;
        private string stringMoney;
        private DataTable dtspecialDiscount;
        //promotion
        private StringBuilder strXml;
        private DataTable dtPromotionMoney;
        private DataTable dtPromotionGift;

        
        
        // Coupons
        private List<string> listCoupon;
        
        #endregion

        #region Properties
        // Product
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        // Customer
        public string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; }
        }
        public string CusName
        {
            get { return cusName; }
            set { cusName = value; }
        }
        public string CusAdress
        {
            get { return cusAdress; }
            set { cusAdress = value; }
        }
        public string CusGroup
        {
            get { return cusGroup; }
            set { cusGroup = value; }
        }
        public double CusPurchase
        {
            get { return cusPurchase; }
            set { cusPurchase = value; }
        }
        // Payment
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string TotalPay
        {
            get { return totalPay; }
            set { totalPay = value; }
        }
        public string Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public string SpecialDiscount
        {
            get { return specialDiscount; }
            set { specialDiscount = value; }
        }
        public string Promotion
        {
            get { return promotion; }
            set { promotion = value; }
        }
        public DateTime Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }
        //SpecialDiscount
        public float Percent
        {
            get { return percent; }
            set { percent = value; }
        }
        public float Money
        {
            get { return money; }
            set { money = value; }
        }
        public string StringMoney
        {
            get { return stringMoney; }
            set { stringMoney = value; }
        }
        public DataTable DtspecialDiscount
        {
            get { return dtspecialDiscount; }
            set { dtspecialDiscount = value; }
        }
        // Promotion
        public DataTable DtPromotionGift
        {
            get { return dtPromotionGift; }
            set { dtPromotionGift = value; }
        }

        public DataTable DtPromotionMoney
        {
            get { return dtPromotionMoney; }
            set { dtPromotionMoney = value; }
        }

        public StringBuilder StrXml
        {
            get { return strXml; }
            set { strXml = value; }
        }
        // Coupon
        public List<string> ListCoupon
        {
            get { return listCoupon; }
            set { listCoupon = value; }
        }
        #endregion
    }
}

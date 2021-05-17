using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleMTDataAccessLayer.SaleMTObj;

namespace SaleMTBusiness.SaleManagement
{
    public class SalePaymentEntities
    {
        private double cashSales;
        private double discount;
        private double specialDiscount;
        private double promotion;
        private string exportCode;
        private int totalQuantity;
        private double cusPurchase;

        private string comName;
        private string comAdress;
        private string comTax;
        private string redRemark;       
        

        private StringBuilder strXML;
        private SALES_EXPORTS saleExport;
        private SALES_EXPORTS_ITEMS[] saleExportItem;
        private INVENTORY_TEMP[] inventory;
        private SALES_SPECIAL_DISCOUNT saleDiscount;
        private TRANSFER_SHIFT tranfer;
        private USER_DEPT userDept;
        private PRODUCTS[] product;
        private COUPONS[] coupon;
        private VOUCHER_GIFT_ITEMS[] voucherGift;
        private CUSTOMERS customer;
        private RedInvoiceProductEntities[] redProduct;
        private SALE_PROMOTION[] salePromotion;
        private SALE_PROMOTION_GIFTS[] salePromotionGift;
        private PRODUCTS[] product_Gift;

        public PRODUCTS[] Product_Gift
        {
            get { return product_Gift; }
            set { product_Gift = value; }
        }

        public SALE_PROMOTION_GIFTS[] SalePromotionGift
        {
            get { return salePromotionGift; }
            set { salePromotionGift = value; }
        }

        public SALE_PROMOTION[] SalePromotion
        {
            get { return salePromotion; }
            set { salePromotion = value; }
        }

        public RedInvoiceProductEntities[] RedProduct
        {
            get { return redProduct; }
            set { redProduct = value; }
        }


        public double CashSales
        {
            get { return cashSales; }
            set { cashSales = value; }
        }
        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public double SpecialDiscount
        {
            get { return specialDiscount; }
            set { specialDiscount = value; }
        }
        public double Promotion
        {
            get { return promotion; }
            set { promotion = value; }
        }
        public int TotalQuantity
        {
            get { return totalQuantity; }
            set { totalQuantity = value; }
        }
        public string ExportCode
        {
            get { return exportCode; }
            set { exportCode = value; }
        }
        public double CusPurchase
        {
            get { return cusPurchase; }
            set { cusPurchase = value; }
        }
        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }
        public string ComAdress
        {
            get { return comAdress; }
            set { comAdress = value; }
        }
        public string ComTax
        {
            get { return comTax; }
            set { comTax = value; }
        }
        public string RedRemark
        {
            get { return redRemark; }
            set { redRemark = value; }
        }
        public StringBuilder StrXML
        {
            get { return strXML; }
            set { strXML = value; }
        }
        public SALES_EXPORTS SaleExport
        {
            get { return saleExport; }
            set { saleExport = value; }
        }
        public SALES_EXPORTS_ITEMS[] SaleExportItem
        {
            get { return saleExportItem; }
            set { saleExportItem = value; }
        }
        public INVENTORY_TEMP[] Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public SALES_SPECIAL_DISCOUNT SaleDiscount
        {
            get { return saleDiscount; }
            set { saleDiscount = value; }
        }
        public TRANSFER_SHIFT Tranfer
        {
            get { return tranfer; }
            set { tranfer = value; }
        }
        public USER_DEPT UserDept
        {
            get { return userDept; }
            set { userDept = value; }
        }
        public PRODUCTS[] Product
        {
            get { return product; }
            set { product = value; }
        }
        public CUSTOMERS Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public COUPONS[] Coupon
        {
            get { return coupon; }
            set { coupon = value; }
        }
        public VOUCHER_GIFT_ITEMS[] VoucherGift
        {
            get { return voucherGift; }
            set { voucherGift = value; }
        }
    }
}

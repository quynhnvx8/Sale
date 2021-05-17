using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    /// <summary>
    /// Người tạo Luannv – 02/10/2013 : Entities quyền chiết khấu hoặc thay đổi giá bán.
    /// </summary>
    public class AuthenticationEntities
    {
        #region member
        private bool check;
        private string users;
        private int maxPercent;
        private double maxMoney;
        private bool discountRight;
        #endregion
        #region properties
        public bool DiscountRight
        {
            get { return discountRight; }
            set { discountRight = value; }
        }
        private bool changePriceRight;

        public bool ChangePriceRight
        {
            get { return changePriceRight; }
            set { changePriceRight = value; }
        }
        public bool Check
        {
            get { return check; }
            set { check = value; }
        }
        public string Users
        {
            get { return users; }
            set { users = value; }
        }
        public int MaxPercent
        {
            get { return maxPercent; }
            set { maxPercent = value; }
        }
        public double MaxMoney
        {
            get { return maxMoney; }
            set { maxMoney = value; }
        }
        #endregion
    }
}

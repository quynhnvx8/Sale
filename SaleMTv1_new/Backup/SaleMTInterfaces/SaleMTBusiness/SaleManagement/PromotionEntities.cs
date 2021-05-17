using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class PromotionEntities
    {
        private double discount;

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        private StringBuilder xml;

        public StringBuilder Xml
        {
            get { return xml; }
            set { xml = value; }
        }
    }
}

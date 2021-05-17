using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.InventoryManagement
{
    public class OrderEntities
    {
        private string orderCode;
        private DateTime dateFrom;
        private DateTime dateTo;

        public DateTime DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
        }

        public DateTime DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }

        public string OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }
    }
}

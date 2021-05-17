using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SaleMTBusiness.SaleManagement
{
    public class ReturnItemEntities
    {
        private DataTable dtProduct;
        private string billCode;
        private string totalMoneyReturn;
        private string itemReturnCode;

        public string ItemReturnCode
        {
            get { return itemReturnCode; }
            set { itemReturnCode = value; }
        }

        public string TotalMoneyReturn
        {
            get { return totalMoneyReturn; }
            set { totalMoneyReturn = value; }
        }

        public string BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }

        public DataTable DtProduct
        {
            get { return dtProduct; }
            set { dtProduct = value; }
        }
    }
}

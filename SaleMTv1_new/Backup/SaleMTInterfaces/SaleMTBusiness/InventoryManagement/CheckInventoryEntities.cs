using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SaleMTBusiness.InventoryManagement
{
    public class CheckInventoryEntities
    {
        private string proCode;
        private string productID;
        private string productName;
        private string shortName;       
        private string price;
        private DataTable dtSearch;

        public DataTable DtSearch
        {
            get { return dtSearch; }
            set { dtSearch = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProCode
        {
            get { return proCode; }
            set { proCode = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.InventoryManagement
{
    public class SOImportEntities
    {
        private string productId;
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
    }
}

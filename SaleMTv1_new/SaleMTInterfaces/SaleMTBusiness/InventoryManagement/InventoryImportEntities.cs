using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.InventoryManagement
{
    public class InventoryImportEntities
    {
        private string productID;
        private int productQuantity;
        private DateTime createdDate;
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }
        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                createdDate = value;
            }
        }
    }
}

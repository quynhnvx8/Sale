using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.InventoryManagement
{
    public class SOEntities
    {
        private string soNo;
        private string listProduct;
        private string proId;
        private string proName;
        private Boolean active;
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public Boolean Active
        {
            get { return active; }
            set { active = value; }
        }

        public string ProName
        {
            get { return proName; }
            set { proName = value; }
        }

        public string ProId
        {
            get { return proId; }
            set { proId = value; }
        }

        public string ListProduct
        {
            get { return listProduct; }
            set { listProduct = value; }
        }

        public string SoNo
        {
            get { return soNo; }
            set { soNo = value; }
        }
    }
}

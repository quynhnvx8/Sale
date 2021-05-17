using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class SaleRedInvoicePrintEntities
    {
        private RedInvoiceProductEntities[] redPro;
        private string comName;
        private string comAdress;
        private string comTax;
        //private string remark;

        public string Remark
        {
            get { return Remark; }
            set { Remark = value; }
        }

        public string ComTax
        {
            get { return comTax; }
            set { comTax = value; }
        }

        public string ComAdress
        {
            get { return comAdress; }
            set { comAdress = value; }
        }

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }

        public RedInvoiceProductEntities[] RedPro
        {
            get { return redPro; }
            set { redPro = value; }
        }
    }
}

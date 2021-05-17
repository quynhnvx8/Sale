using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTCommon
{
    public class DefaultCustomer
    {
        private static string cusCode;
        private static string cusName;
        private static string cusAdress;
        private static string cusGroup;
        private static string personPtrint;
        private static double purchase;

        public static string CusGroup
        {
            get { return cusGroup; }
            set { cusGroup = value; }
        }

        public static string CusAdress
        {
            get { return cusAdress; }
            set { cusAdress = value; }
        }

        public static string CusName
        {
            get { return cusName; }
            set { cusName = value; }
        }

        public static string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; }
        }
        public static double Purchase
        {
            get { return purchase; }
            set { purchase = value; }
        }

        public static string PersonPtrint
        {
            get { return personPtrint; }
            set { personPtrint = value; }
        }

    }
}

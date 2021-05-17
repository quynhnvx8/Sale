using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace SaleMTCommon
{
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            string textX = listviewX.SubItems.Count >= ColumnToSort + 1 ? listviewX.SubItems[ColumnToSort].Text : "";
            string textY = listviewY.SubItems.Count >= ColumnToSort + 1 ? listviewY.SubItems[ColumnToSort].Text : "";
            //compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            compareResult = ObjectCompare.Compare(textX, textY);

            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            if (listviewX.SubItems.Count == 6 && listviewY.SubItems.Count == 6)
            {
                switch (ColumnToSort)
                {
                    case 0:
                        compareResult = ObjectCompare.Compare(DateTime.ParseExact(textX, format, provider), DateTime.ParseExact(textY, format, provider));
                        break;
                    case 3:
                        compareResult = ObjectCompare.Compare(int.Parse(Conversion.Replaces(textX)), int.Parse(Conversion.Replaces(textY)));
                        break;
                    case 4:
                        compareResult = ObjectCompare.Compare(float.Parse(Conversion.Replaces(textX)), float.Parse(Conversion.Replaces(textY)));
                        break;
                }
            }
            if (listviewX.SubItems.Count == 4 && listviewY.SubItems.Count == 4)
            {
                switch (ColumnToSort)
                {
                    case 0:
                        compareResult = ObjectCompare.Compare(DateTime.ParseExact(textX, format, provider), DateTime.ParseExact(textY, format, provider));
                        break;
                    case 2:
                        compareResult = ObjectCompare.Compare(int.Parse(Conversion.Replaces(textX)), int.Parse(Conversion.Replaces(textY)));
                        break;
                    case 3:
                        compareResult = ObjectCompare.Compare(float.Parse(Conversion.Replaces(textX)), float.Parse(Conversion.Replaces(textY)));
                        break;
                }
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }

}

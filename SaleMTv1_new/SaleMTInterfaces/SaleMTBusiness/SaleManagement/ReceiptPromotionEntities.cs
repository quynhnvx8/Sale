using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTBusiness.SaleManagement
{
    public class ReceiptPromotionEntities
    {
        #region member
        private string exportCode;
        private string programNO;
        private string programName;
        private string id;
        #endregion

        #region Properties
        public string ExportCode
        {
            get { return exportCode; }
            set { exportCode = value; }
        }
        public string ProgramNO
        {
            get { return programNO; }
            set { programNO = value; }
        }
        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}

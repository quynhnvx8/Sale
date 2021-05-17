using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EMPLOYEE_INFO_TEST
    {
        #region members
        string eMPLOYEE_ID;
        string fIRSTNAME;
        string sex_code;

        #endregion members
        #region Properties
        [PKSqlColumn("EMPLOYEE_ID", SqlDbType.VarChar, null)]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
        }
        [SqlColumn("FIRSTNAME", SqlDbType.NVarChar)]
        public string FIRSTNAME
        {
            get { return fIRSTNAME; }
            set { fIRSTNAME = value; }
        }
        [StringSqlColumn("sex_code")]
        public string Sex_code
        {
            get { return sex_code; }
            set { sex_code = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public EMPLOYEE_INFO_TEST() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EMPLOYEE_INFO_TEST> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EMPLOYEE_INFO_TEST>("EMPLOYEE_INFO_TEST");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EMPLOYEE_INFO_TEST",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EMPLOYEE_INFO_TEST");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inEMPLOYEE_ID"></param>
        public static List<EMPLOYEE_INFO_TEST> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID)
        {
            return posdb_vnmSqlDAC.ReadByParams<EMPLOYEE_INFO_TEST>("EMPLOYEE_INFO_TEST", posdb_vnmSqlDAC.newInParam("@EMPLOYEE_ID", inEMPLOYEE_ID));
        }
        #endregion DAC Methods
    }
}

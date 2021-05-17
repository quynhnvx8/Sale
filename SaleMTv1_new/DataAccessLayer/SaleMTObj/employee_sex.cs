using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class employee_sex
    {
        #region members
        string sex_code;
        string sex_name;

        #endregion members
        #region Properties
        [PKSqlColumn("sex_code", SqlDbType.VarChar, null)]
        public string Sex_code
        {
            get { return sex_code; }
            set { sex_code = value; }
        }
        [SqlColumn("sex_name", SqlDbType.NVarChar)]
        public string Sex_name
        {
            get { return sex_name; }
            set { sex_name = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public employee_sex() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<employee_sex> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<employee_sex>("employee_sex");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "employee_sex",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "employee_sex");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="insex_code"></param>
        public static List<employee_sex> ReadBysex_code(string insex_code)
        {
            return posdb_vnmSqlDAC.ReadByParams<employee_sex>("employee_sex", posdb_vnmSqlDAC.newInParam("@sex_code", insex_code));
        }
        #endregion DAC Methods
    }
}

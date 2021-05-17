using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_DATA
    {
        #region members
        string mASTER_CODE;
        string mASTER_NAME;
        string mASTER_GROUP;
        string rEMARKS;
        string pARENT_CODE;
        string fREE_FIELD1;
        string fREE_FIELD2;

        #endregion members
        #region Properties
        [PKSqlColumn("MASTER_CODE", SqlDbType.VarChar, null)]
        public string MASTER_CODE
        {
            get { return mASTER_CODE; }
            set { mASTER_CODE = value; }
        }
        [SqlColumn("MASTER_NAME", SqlDbType.NVarChar)]
        public string MASTER_NAME
        {
            get { return mASTER_NAME; }
            set { mASTER_NAME = value; }
        }
        [StringSqlColumn("MASTER_GROUP")]
        public string MASTER_GROUP
        {
            get { return mASTER_GROUP; }
            set { mASTER_GROUP = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [StringSqlColumn("PARENT_CODE")]
        public string PARENT_CODE
        {
            get { return pARENT_CODE; }
            set { pARENT_CODE = value; }
        }
        [SqlColumn("FREE_FIELD1", SqlDbType.NVarChar)]
        public string FREE_FIELD1
        {
            get { return fREE_FIELD1; }
            set { fREE_FIELD1 = value; }
        }
        [SqlColumn("FREE_FIELD2", SqlDbType.NVarChar)]
        public string FREE_FIELD2
        {
            get { return fREE_FIELD2; }
            set { fREE_FIELD2 = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MASTER_DATA() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_DATA> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_DATA>("MASTER_DATA");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_DATA",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_DATA");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inMASTER_CODE"></param>
        public static List<MASTER_DATA> ReadByMASTER_CODE(string inMASTER_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_DATA>("MASTER_DATA", posdb_vnmSqlDAC.newInParam("@MASTER_CODE", inMASTER_CODE));
        }
        #endregion DAC Methods
    }
}

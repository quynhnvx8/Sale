using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_EX_LENSESORDER_INFO
    {
        #region members
        Guid iD;
        string lENSESORDER_CODE;
        DateTime iNPUT_DATE;
        DateTime dATE;
        string lAB_ROOM;
        string sUPPLIER;
        string sTOCK_LENS;
        string rX_LAB;
        string oRDERED_BY;
        DateTime dUE_DATE;
        DateTime dELIVERY_DATE;
        string pD_LEFT;
        string pD_RIGHT;
        string pRISM;
        string sPHERE_OD;
        string cYLINDER_OD;
        string aXIS_OD;
        string aDD_OD;
        string sEG;
        string tHICKNESS_CT;
        string tHICKNESS_ET;
        string sPHERE_OS;
        string cYLINDER_OS;
        string aXIS_OS;
        string a_DBL_LEFT;
        string a_DBL_RIGHT;
        string b;
        string eD;
        string c_SIZE;
        string fRAME;
        string fRAME_MODEL;
        string fRAME_SIZE;
        string fRAME_COLOR;
        string fRAME_BC;
        string fRAME_CUS;
        string fRAME_CUS_REMARKS;
        string fITTING;
        string lENS_DESIGN;
        string iNDEXS;
        string mATERIALS;
        string lENS_COATING;
        string cOATING_COLOR;
        string tECHNICIAN;
        DateTime? dATE_RECEIVED;
        string bENCH_WORK_INSTRUCTION;
        string rEMARKS;
        string tECHNICIAN_REAMARKS;
        string eVENT_ID;
        Guid rowguid;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
        public Guid ID
        {
            get { return iD; }
            set { iD = value; }
        }
        [StringSqlColumn("LENSESORDER_CODE")]
        public string LENSESORDER_CODE
        {
            get { return lENSESORDER_CODE; }
            set { lENSESORDER_CODE = value; }
        }
        [SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
        public DateTime INPUT_DATE
        {
            get { return iNPUT_DATE; }
            set { iNPUT_DATE = value; }
        }
        [SqlColumn("DATE", SqlDbType.DateTime)]
        public DateTime DATE
        {
            get { return dATE; }
            set { dATE = value; }
        }
        [SqlColumn("LAB_ROOM", SqlDbType.NVarChar)]
        public string LAB_ROOM
        {
            get { return lAB_ROOM; }
            set { lAB_ROOM = value; }
        }
        [SqlColumn("SUPPLIER", SqlDbType.NVarChar)]
        public string SUPPLIER
        {
            get { return sUPPLIER; }
            set { sUPPLIER = value; }
        }
        [SqlColumn("STOCK_LENS", SqlDbType.NVarChar)]
        public string STOCK_LENS
        {
            get { return sTOCK_LENS; }
            set { sTOCK_LENS = value; }
        }
        [SqlColumn("RX_LAB", SqlDbType.NVarChar)]
        public string RX_LAB
        {
            get { return rX_LAB; }
            set { rX_LAB = value; }
        }
        [SqlColumn("ORDERED_BY", SqlDbType.NVarChar)]
        public string ORDERED_BY
        {
            get { return oRDERED_BY; }
            set { oRDERED_BY = value; }
        }
        [SqlColumn("DUE_DATE", SqlDbType.DateTime)]
        public DateTime DUE_DATE
        {
            get { return dUE_DATE; }
            set { dUE_DATE = value; }
        }
        [SqlColumn("DELIVERY_DATE", SqlDbType.DateTime)]
        public DateTime DELIVERY_DATE
        {
            get { return dELIVERY_DATE; }
            set { dELIVERY_DATE = value; }
        }
        [SqlColumn("PD_LEFT", SqlDbType.NVarChar)]
        public string PD_LEFT
        {
            get { return pD_LEFT; }
            set { pD_LEFT = value; }
        }
        [SqlColumn("PD_RIGHT", SqlDbType.NVarChar)]
        public string PD_RIGHT
        {
            get { return pD_RIGHT; }
            set { pD_RIGHT = value; }
        }
        [SqlColumn("PRISM", SqlDbType.NVarChar)]
        public string PRISM
        {
            get { return pRISM; }
            set { pRISM = value; }
        }
        [SqlColumn("SPHERE_OD", SqlDbType.NVarChar)]
        public string SPHERE_OD
        {
            get { return sPHERE_OD; }
            set { sPHERE_OD = value; }
        }
        [SqlColumn("CYLINDER_OD", SqlDbType.NVarChar)]
        public string CYLINDER_OD
        {
            get { return cYLINDER_OD; }
            set { cYLINDER_OD = value; }
        }
        [SqlColumn("AXIS_OD", SqlDbType.NVarChar)]
        public string AXIS_OD
        {
            get { return aXIS_OD; }
            set { aXIS_OD = value; }
        }
        [SqlColumn("ADD_OD", SqlDbType.NVarChar)]
        public string ADD_OD
        {
            get { return aDD_OD; }
            set { aDD_OD = value; }
        }
        [SqlColumn("SEG", SqlDbType.NVarChar)]
        public string SEG
        {
            get { return sEG; }
            set { sEG = value; }
        }
        [SqlColumn("THICKNESS_CT", SqlDbType.NVarChar)]
        public string THICKNESS_CT
        {
            get { return tHICKNESS_CT; }
            set { tHICKNESS_CT = value; }
        }
        [SqlColumn("THICKNESS_ET", SqlDbType.NVarChar)]
        public string THICKNESS_ET
        {
            get { return tHICKNESS_ET; }
            set { tHICKNESS_ET = value; }
        }
        [SqlColumn("SPHERE_OS", SqlDbType.NVarChar)]
        public string SPHERE_OS
        {
            get { return sPHERE_OS; }
            set { sPHERE_OS = value; }
        }
        [SqlColumn("CYLINDER_OS", SqlDbType.NVarChar)]
        public string CYLINDER_OS
        {
            get { return cYLINDER_OS; }
            set { cYLINDER_OS = value; }
        }
        [SqlColumn("AXIS_OS", SqlDbType.NVarChar)]
        public string AXIS_OS
        {
            get { return aXIS_OS; }
            set { aXIS_OS = value; }
        }
        [SqlColumn("A_DBL_LEFT", SqlDbType.NVarChar)]
        public string A_DBL_LEFT
        {
            get { return a_DBL_LEFT; }
            set { a_DBL_LEFT = value; }
        }
        [SqlColumn("A_DBL_RIGHT", SqlDbType.NVarChar)]
        public string A_DBL_RIGHT
        {
            get { return a_DBL_RIGHT; }
            set { a_DBL_RIGHT = value; }
        }
        [SqlColumn("B", SqlDbType.NVarChar)]
        public string B
        {
            get { return b; }
            set { b = value; }
        }
        [SqlColumn("ED", SqlDbType.NVarChar)]
        public string ED
        {
            get { return eD; }
            set { eD = value; }
        }
        [SqlColumn("C_SIZE", SqlDbType.NVarChar)]
        public string C_SIZE
        {
            get { return c_SIZE; }
            set { c_SIZE = value; }
        }
        [SqlColumn("FRAME", SqlDbType.NVarChar)]
        public string FRAME
        {
            get { return fRAME; }
            set { fRAME = value; }
        }
        [SqlColumn("FRAME_MODEL", SqlDbType.NVarChar)]
        public string FRAME_MODEL
        {
            get { return fRAME_MODEL; }
            set { fRAME_MODEL = value; }
        }
        [SqlColumn("FRAME_SIZE", SqlDbType.NVarChar)]
        public string FRAME_SIZE
        {
            get { return fRAME_SIZE; }
            set { fRAME_SIZE = value; }
        }
        [SqlColumn("FRAME_COLOR", SqlDbType.NVarChar)]
        public string FRAME_COLOR
        {
            get { return fRAME_COLOR; }
            set { fRAME_COLOR = value; }
        }
        [SqlColumn("FRAME_BC", SqlDbType.NVarChar)]
        public string FRAME_BC
        {
            get { return fRAME_BC; }
            set { fRAME_BC = value; }
        }
        [SqlColumn("FRAME_CUS", SqlDbType.NVarChar)]
        public string FRAME_CUS
        {
            get { return fRAME_CUS; }
            set { fRAME_CUS = value; }
        }
        [SqlColumn("FRAME_CUS_REMARKS", SqlDbType.NVarChar)]
        public string FRAME_CUS_REMARKS
        {
            get { return fRAME_CUS_REMARKS; }
            set { fRAME_CUS_REMARKS = value; }
        }
        [SqlColumn("FITTING", SqlDbType.NVarChar)]
        public string FITTING
        {
            get { return fITTING; }
            set { fITTING = value; }
        }
        [SqlColumn("LENS_DESIGN", SqlDbType.NVarChar)]
        public string LENS_DESIGN
        {
            get { return lENS_DESIGN; }
            set { lENS_DESIGN = value; }
        }
        [SqlColumn("INDEXS", SqlDbType.NVarChar)]
        public string INDEXS
        {
            get { return iNDEXS; }
            set { iNDEXS = value; }
        }
        [SqlColumn("MATERIALS", SqlDbType.NVarChar)]
        public string MATERIALS
        {
            get { return mATERIALS; }
            set { mATERIALS = value; }
        }
        [SqlColumn("LENS_COATING", SqlDbType.NVarChar)]
        public string LENS_COATING
        {
            get { return lENS_COATING; }
            set { lENS_COATING = value; }
        }
        [SqlColumn("COATING_COLOR", SqlDbType.NVarChar)]
        public string COATING_COLOR
        {
            get { return cOATING_COLOR; }
            set { cOATING_COLOR = value; }
        }
        [SqlColumn("TECHNICIAN", SqlDbType.NVarChar)]
        public string TECHNICIAN
        {
            get { return tECHNICIAN; }
            set { tECHNICIAN = value; }
        }
        [SqlColumn("DATE_RECEIVED", SqlDbType.DateTime)]
        public DateTime? DATE_RECEIVED
        {
            get { return dATE_RECEIVED; }
            set { dATE_RECEIVED = value; }
        }
        [SqlColumn("BENCH_WORK_INSTRUCTION", SqlDbType.NVarChar)]
        public string BENCH_WORK_INSTRUCTION
        {
            get { return bENCH_WORK_INSTRUCTION; }
            set { bENCH_WORK_INSTRUCTION = value; }
        }
        [SqlColumn("REMARKS", SqlDbType.NVarChar)]
        public string REMARKS
        {
            get { return rEMARKS; }
            set { rEMARKS = value; }
        }
        [SqlColumn("TECHNICIAN_REAMARKS", SqlDbType.NVarChar)]
        public string TECHNICIAN_REAMARKS
        {
            get { return tECHNICIAN_REAMARKS; }
            set { tECHNICIAN_REAMARKS = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("rowguid", SqlDbType.UniqueIdentifier)]
        public Guid Rowguid
        {
            get { return rowguid; }
            set { rowguid = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MASTER_EX_LENSESORDER_INFO() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_EX_LENSESORDER_INFO> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_EX_LENSESORDER_INFO>("MASTER_EX_LENSESORDER_INFO");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_EX_LENSESORDER_INFO",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_EX_LENSESORDER_INFO");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inID"></param>
        public static List<MASTER_EX_LENSESORDER_INFO> ReadByID(Guid inID)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER_INFO>("MASTER_EX_LENSESORDER_INFO", posdb_vnmSqlDAC.newInParam("@ID", inID));
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inrowguid"></param>
        public static List<MASTER_EX_LENSESORDER_INFO> ReadByrowguid(Guid inrowguid)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_LENSESORDER_INFO>("MASTER_EX_LENSESORDER_INFO", posdb_vnmSqlDAC.newInParam("@rowguid", inrowguid));
        }
        #endregion DAC Methods
    }
}

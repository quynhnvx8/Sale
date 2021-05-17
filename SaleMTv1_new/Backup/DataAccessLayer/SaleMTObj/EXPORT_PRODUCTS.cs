using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class EXPORT_PRODUCTS
    {
        #region members
        string iNVOICE_CODE;
        DateTime? dATE_EXPORT;
        string wAREHOUSE_EXPORT;
        string sTORE_CODE;
        string wAREHOUSE_IMPORT;
        string sUPPLIER;
        string eMPLOYEE_ID;
        string rEMARKS_EXPORT;
        bool sTATUS_EXPORT;
        DateTime? dATE_IMPORT;
        string iMPORT_CODE;
        string rEMARKS_IMPORT;
        bool sTATUS_IMPORT;
        string uSER_IMPORT;
        bool iS_IMPORT_DC;
        string eXPORT_TYPE;
        string eVENT_ID;
        bool? dELIVERY_STATUS;
        DateTime? dELIVERY_DATE;
        string iNVOICE_IMPORT;
        string oRDER_ID;
        bool? iS_IMPORT_DEBT;
        DateTime? cREATE_DATE;
        string uSER_CREATE;
        string dELIVERY_BY;
        string dISCOUNT_TYPE;
        decimal? dISCOUNT;
        bool? iS_IMPORT_DEBT_SALE;
        string eMPLOYEE_IMPORT;
        string rED_INVOICE_NO;
        string pOCONumber;
        string soNoiBo;
        DateTime? orderDate;
        float? sOTIENDC;
        string gHICHUDC;
        string iMPORT_TYPE;

        #endregion members
        #region Properties
        [PKSqlColumn("INVOICE_CODE", SqlDbType.VarChar, null)]
        public string INVOICE_CODE
        {
            get { return iNVOICE_CODE; }
            set { iNVOICE_CODE = value; }
        }
        [SqlColumn("DATE_EXPORT", SqlDbType.DateTime)]
        public DateTime? DATE_EXPORT
        {
            get { return dATE_EXPORT; }
            set { dATE_EXPORT = value; }
        }
        [StringSqlColumn("WAREHOUSE_EXPORT")]
        public string WAREHOUSE_EXPORT
        {
            get { return wAREHOUSE_EXPORT; }
            set { wAREHOUSE_EXPORT = value; }
        }
        [StringSqlColumn("STORE_CODE")]
        public string STORE_CODE
        {
            get { return sTORE_CODE; }
            set { sTORE_CODE = value; }
        }
        [StringSqlColumn("WAREHOUSE_IMPORT")]
        public string WAREHOUSE_IMPORT
        {
            get { return wAREHOUSE_IMPORT; }
            set { wAREHOUSE_IMPORT = value; }
        }
        [StringSqlColumn("SUPPLIER")]
        public string SUPPLIER
        {
            get { return sUPPLIER; }
            set { sUPPLIER = value; }
        }
        [StringSqlColumn("EMPLOYEE_ID")]
        public string EMPLOYEE_ID
        {
            get { return eMPLOYEE_ID; }
            set { eMPLOYEE_ID = value; }
        }
        [SqlColumn("REMARKS_EXPORT", SqlDbType.NVarChar)]
        public string REMARKS_EXPORT
        {
            get { return rEMARKS_EXPORT; }
            set { rEMARKS_EXPORT = value; }
        }
        [SqlColumn("STATUS_EXPORT", SqlDbType.Bit)]
        public bool STATUS_EXPORT
        {
            get { return sTATUS_EXPORT; }
            set { sTATUS_EXPORT = value; }
        }
        [SqlColumn("DATE_IMPORT", SqlDbType.DateTime)]
        public DateTime? DATE_IMPORT
        {
            get { return dATE_IMPORT; }
            set { dATE_IMPORT = value; }
        }
        [StringSqlColumn("IMPORT_CODE")]
        public string IMPORT_CODE
        {
            get { return iMPORT_CODE; }
            set { iMPORT_CODE = value; }
        }
        [SqlColumn("REMARKS_IMPORT", SqlDbType.NVarChar)]
        public string REMARKS_IMPORT
        {
            get { return rEMARKS_IMPORT; }
            set { rEMARKS_IMPORT = value; }
        }
        [SqlColumn("STATUS_IMPORT", SqlDbType.Bit)]
        public bool STATUS_IMPORT
        {
            get { return sTATUS_IMPORT; }
            set { sTATUS_IMPORT = value; }
        }
        [SqlColumn("USER_IMPORT", SqlDbType.NVarChar)]
        public string USER_IMPORT
        {
            get { return uSER_IMPORT; }
            set { uSER_IMPORT = value; }
        }
        [SqlColumn("IS_IMPORT_DC", SqlDbType.Bit)]
        public bool IS_IMPORT_DC
        {
            get { return iS_IMPORT_DC; }
            set { iS_IMPORT_DC = value; }
        }
        [StringSqlColumn("EXPORT_TYPE")]
        public string EXPORT_TYPE
        {
            get { return eXPORT_TYPE; }
            set { eXPORT_TYPE = value; }
        }
        [StringSqlColumn("EVENT_ID")]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("DELIVERY_STATUS", SqlDbType.Bit)]
        public bool? DELIVERY_STATUS
        {
            get { return dELIVERY_STATUS; }
            set { dELIVERY_STATUS = value; }
        }
        [SqlColumn("DELIVERY_DATE", SqlDbType.DateTime)]
        public DateTime? DELIVERY_DATE
        {
            get { return dELIVERY_DATE; }
            set { dELIVERY_DATE = value; }
        }
        [StringSqlColumn("INVOICE_IMPORT")]
        public string INVOICE_IMPORT
        {
            get { return iNVOICE_IMPORT; }
            set { iNVOICE_IMPORT = value; }
        }
        [StringSqlColumn("ORDER_ID")]
        public string ORDER_ID
        {
            get { return oRDER_ID; }
            set { oRDER_ID = value; }
        }
        [SqlColumn("IS_IMPORT_DEBT", SqlDbType.Bit)]
        public bool? IS_IMPORT_DEBT
        {
            get { return iS_IMPORT_DEBT; }
            set { iS_IMPORT_DEBT = value; }
        }
        [SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
        public DateTime? CREATE_DATE
        {
            get { return cREATE_DATE; }
            set { cREATE_DATE = value; }
        }
        [StringSqlColumn("USER_CREATE")]
        public string USER_CREATE
        {
            get { return uSER_CREATE; }
            set { uSER_CREATE = value; }
        }
        [StringSqlColumn("DELIVERY_BY")]
        public string DELIVERY_BY
        {
            get { return dELIVERY_BY; }
            set { dELIVERY_BY = value; }
        }
        [StringSqlColumn("DISCOUNT_TYPE")]
        public string DISCOUNT_TYPE
        {
            get { return dISCOUNT_TYPE; }
            set { dISCOUNT_TYPE = value; }
        }
        [SqlColumn("DISCOUNT", SqlDbType.Decimal)]
        public decimal? DISCOUNT
        {
            get { return dISCOUNT; }
            set { dISCOUNT = value; }
        }
        [SqlColumn("IS_IMPORT_DEBT_SALE", SqlDbType.Bit)]
        public bool? IS_IMPORT_DEBT_SALE
        {
            get { return iS_IMPORT_DEBT_SALE; }
            set { iS_IMPORT_DEBT_SALE = value; }
        }
        [StringSqlColumn("EMPLOYEE_IMPORT")]
        public string EMPLOYEE_IMPORT
        {
            get { return eMPLOYEE_IMPORT; }
            set { eMPLOYEE_IMPORT = value; }
        }
        [StringSqlColumn("RED_INVOICE_NO")]
        public string RED_INVOICE_NO
        {
            get { return rED_INVOICE_NO; }
            set { rED_INVOICE_NO = value; }
        }
        [StringSqlColumn("POCONumber")]
        public string POCONumber
        {
            get { return pOCONumber; }
            set { pOCONumber = value; }
        }
        [StringSqlColumn("SoNoiBo")]
        public string SoNoiBo
        {
            get { return soNoiBo; }
            set { soNoiBo = value; }
        }
        [SqlColumn("OrderDate", SqlDbType.DateTime)]
        public DateTime? OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        [SqlColumn("SOTIENDC", SqlDbType.Float)]
        public float? SOTIENDC
        {
            get { return sOTIENDC; }
            set { sOTIENDC = value; }
        }
        [SqlColumn("GHICHUDC", SqlDbType.NVarChar)]
        public string GHICHUDC
        {
            get { return gHICHUDC; }
            set { gHICHUDC = value; }
        }
        [StringSqlColumn("IMPORT_TYPE")]
        public string IMPORT_TYPE
        {
            get { return iMPORT_TYPE; }
            set { iMPORT_TYPE = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public EXPORT_PRODUCTS() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<EXPORT_PRODUCTS> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<EXPORT_PRODUCTS>("EXPORT_PRODUCTS");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "EXPORT_PRODUCTS",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "EXPORT_PRODUCTS");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inINVOICE_CODE"></param>
        public static List<EXPORT_PRODUCTS> ReadByINVOICE_CODE(string inINVOICE_CODE)
        {
            return posdb_vnmSqlDAC.ReadByParams<EXPORT_PRODUCTS>("EXPORT_PRODUCTS", posdb_vnmSqlDAC.newInParam("@INVOICE_CODE", inINVOICE_CODE));
        }
        #endregion DAC Methods
    }
}

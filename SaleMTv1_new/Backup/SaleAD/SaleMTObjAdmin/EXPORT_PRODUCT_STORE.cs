using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class EXPORT_PRODUCT_STORE {
	#region members
	string eXPORT_STORE_ID;
	string iNVOICE_CODE;
	DateTime? dATE_EXPORT;
	string fROM_STORE;
	int? eXPORT_TYPE;
	string eXPORT_TO;
	string rEMARKS;
	string cREATE_BY;
	DateTime? dATE_CREATE;
	string uPDATE_BY;
	DateTime? dATE_UPDATE;
	string eVENT_ID;
	bool? iS_IMPORT_DEBT;
	string eMPLOYEE_ID;
	string iNVOICE_NO;
	string pOCO_NUMBER;
	string sO_NOI_BO;
	DateTime? oRDER_DATE;
	float? sOTIENDC;
	string gHICHUDC;
	string eXPORT_TYPE_CODE;

	#endregion members
	#region Properties
	[PKSqlColumn("EXPORT_STORE_ID", SqlDbType.VarChar, null)]
	public string EXPORT_STORE_ID {
		get { return eXPORT_STORE_ID; }
		set{ eXPORT_STORE_ID = value; }
	}
	[StringSqlColumn("INVOICE_CODE")]
	public string INVOICE_CODE {
		get { return iNVOICE_CODE; }
		set{ iNVOICE_CODE = value; }
	}
	[SqlColumn("DATE_EXPORT", SqlDbType.DateTime)]
	public DateTime? DATE_EXPORT {
		get { return dATE_EXPORT; }
		set{ dATE_EXPORT = value; }
	}
	[StringSqlColumn("FROM_STORE")]
	public string FROM_STORE {
		get { return fROM_STORE; }
		set{ fROM_STORE = value; }
	}
	[SqlColumn("EXPORT_TYPE", SqlDbType.Int)]
	public int? EXPORT_TYPE {
		get { return eXPORT_TYPE; }
		set{ eXPORT_TYPE = value; }
	}
	[StringSqlColumn("EXPORT_TO")]
	public string EXPORT_TO {
		get { return eXPORT_TO; }
		set{ eXPORT_TO = value; }
	}
	[SqlColumn("REMARKS", SqlDbType.NVarChar)]
	public string REMARKS {
		get { return rEMARKS; }
		set{ rEMARKS = value; }
	}
	[SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
	public DateTime? DATE_CREATE {
		get { return dATE_CREATE; }
		set{ dATE_CREATE = value; }
	}
	[SqlColumn("UPDATE_BY", SqlDbType.NVarChar)]
	public string UPDATE_BY {
		get { return uPDATE_BY; }
		set{ uPDATE_BY = value; }
	}
	[SqlColumn("DATE_UPDATE", SqlDbType.DateTime)]
	public DateTime? DATE_UPDATE {
		get { return dATE_UPDATE; }
		set{ dATE_UPDATE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("IS_IMPORT_DEBT", SqlDbType.Bit)]
	public bool? IS_IMPORT_DEBT {
		get { return iS_IMPORT_DEBT; }
		set{ iS_IMPORT_DEBT = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[StringSqlColumn("INVOICE_NO")]
	public string INVOICE_NO {
		get { return iNVOICE_NO; }
		set{ iNVOICE_NO = value; }
	}
	[StringSqlColumn("POCO_NUMBER")]
	public string POCO_NUMBER {
		get { return pOCO_NUMBER; }
		set{ pOCO_NUMBER = value; }
	}
	[StringSqlColumn("SO_NOI_BO")]
	public string SO_NOI_BO {
		get { return sO_NOI_BO; }
		set{ sO_NOI_BO = value; }
	}
	[SqlColumn("ORDER_DATE", SqlDbType.DateTime)]
	public DateTime? ORDER_DATE {
		get { return oRDER_DATE; }
		set{ oRDER_DATE = value; }
	}
	[SqlColumn("SOTIENDC", SqlDbType.Float)]
	public float? SOTIENDC {
		get { return sOTIENDC; }
		set{ sOTIENDC = value; }
	}
	[SqlColumn("GHICHUDC", SqlDbType.NVarChar)]
	public string GHICHUDC {
		get { return gHICHUDC; }
		set{ gHICHUDC = value; }
	}
	[StringSqlColumn("EXPORT_TYPE_CODE")]
	public string EXPORT_TYPE_CODE {
		get { return eXPORT_TYPE_CODE; }
		set{ eXPORT_TYPE_CODE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public EXPORT_PRODUCT_STORE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<EXPORT_PRODUCT_STORE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<EXPORT_PRODUCT_STORE>("EXPORT_PRODUCT_STORE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "EXPORT_PRODUCT_STORE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "EXPORT_PRODUCT_STORE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEXPORT_STORE_ID"></param>
	public static List<EXPORT_PRODUCT_STORE> ReadByEXPORT_STORE_ID(string inEXPORT_STORE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<EXPORT_PRODUCT_STORE>("EXPORT_PRODUCT_STORE", rdodb_KTSqlDAC.newInParam("@EXPORT_STORE_ID", inEXPORT_STORE_ID));
	}
	#endregion DAC Methods 
 }
}

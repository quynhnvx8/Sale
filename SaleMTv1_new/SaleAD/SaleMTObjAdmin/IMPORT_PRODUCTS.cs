using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IMPORT_PRODUCTS {
	#region members
	Guid iD;
	string iMPORT_CODE;
	DateTime? dATE_IMPORT;
	string sTORE_EXPORT;
	string wAREHOUSE_EXPORT;
	string sUPPLIER_ID;
	string iNVOICE_CODE;
	string oRDER_CODE;
	string wAREHOUSE_IMPORT;
	string rEMARKS;
	string cURRENCY;
	float? eXCHANGE_RATE;
	string cREATE_BY;
	DateTime? dATE_CREATE;
	string uPDATE_BY;
	DateTime? dATE_UPDATE;
	string iMPORT_TYPE;
	string eMPLOYEE_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[StringSqlColumn("IMPORT_CODE")]
	public string IMPORT_CODE {
		get { return iMPORT_CODE; }
		set{ iMPORT_CODE = value; }
	}
	[SqlColumn("DATE_IMPORT", SqlDbType.DateTime)]
	public DateTime? DATE_IMPORT {
		get { return dATE_IMPORT; }
		set{ dATE_IMPORT = value; }
	}
	[StringSqlColumn("STORE_EXPORT")]
	public string STORE_EXPORT {
		get { return sTORE_EXPORT; }
		set{ sTORE_EXPORT = value; }
	}
	[StringSqlColumn("WAREHOUSE_EXPORT")]
	public string WAREHOUSE_EXPORT {
		get { return wAREHOUSE_EXPORT; }
		set{ wAREHOUSE_EXPORT = value; }
	}
	[StringSqlColumn("SUPPLIER_ID")]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[StringSqlColumn("INVOICE_CODE")]
	public string INVOICE_CODE {
		get { return iNVOICE_CODE; }
		set{ iNVOICE_CODE = value; }
	}
	[StringSqlColumn("ORDER_CODE")]
	public string ORDER_CODE {
		get { return oRDER_CODE; }
		set{ oRDER_CODE = value; }
	}
	[StringSqlColumn("WAREHOUSE_IMPORT")]
	public string WAREHOUSE_IMPORT {
		get { return wAREHOUSE_IMPORT; }
		set{ wAREHOUSE_IMPORT = value; }
	}
	[SqlColumn("REMARKS", SqlDbType.NVarChar)]
	public string REMARKS {
		get { return rEMARKS; }
		set{ rEMARKS = value; }
	}
	[SqlColumn("CURRENCY", SqlDbType.NVarChar)]
	public string CURRENCY {
		get { return cURRENCY; }
		set{ cURRENCY = value; }
	}
	[SqlColumn("EXCHANGE_RATE", SqlDbType.Float)]
	public float? EXCHANGE_RATE {
		get { return eXCHANGE_RATE; }
		set{ eXCHANGE_RATE = value; }
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
	[StringSqlColumn("IMPORT_TYPE")]
	public string IMPORT_TYPE {
		get { return iMPORT_TYPE; }
		set{ iMPORT_TYPE = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public IMPORT_PRODUCTS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IMPORT_PRODUCTS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IMPORT_PRODUCTS>("IMPORT_PRODUCTS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IMPORT_PRODUCTS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IMPORT_PRODUCTS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<IMPORT_PRODUCTS> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<IMPORT_PRODUCTS>("IMPORT_PRODUCTS", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

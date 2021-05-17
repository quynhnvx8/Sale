using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ORDER_PRODUCTS_SUPPLIER {
	#region members
	string oRDER_ID;
	string sUPPLIER_ID;
	DateTime? oRDER_DATE;
	string rEMARKS;
	DateTime? eXPECTED_DATE;
	string cREATE_BY;
	DateTime? dATE_CREATE;
	string sTATUS_EXPORT;

	#endregion members
	#region Properties
	[PKSqlColumn("ORDER_ID", SqlDbType.VarChar, null)]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[StringSqlColumn("SUPPLIER_ID")]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[SqlColumn("ORDER_DATE", SqlDbType.DateTime)]
	public DateTime? ORDER_DATE {
		get { return oRDER_DATE; }
		set{ oRDER_DATE = value; }
	}
	[SqlColumn("REMARKS", SqlDbType.NVarChar)]
	public string REMARKS {
		get { return rEMARKS; }
		set{ rEMARKS = value; }
	}
	[SqlColumn("EXPECTED_DATE", SqlDbType.DateTime)]
	public DateTime? EXPECTED_DATE {
		get { return eXPECTED_DATE; }
		set{ eXPECTED_DATE = value; }
	}
	[StringSqlColumn("CREATE_BY")]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("DATE_CREATE", SqlDbType.DateTime)]
	public DateTime? DATE_CREATE {
		get { return dATE_CREATE; }
		set{ dATE_CREATE = value; }
	}
	[SqlColumn("STATUS_EXPORT", SqlDbType.NVarChar)]
	public string STATUS_EXPORT {
		get { return sTATUS_EXPORT; }
		set{ sTATUS_EXPORT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ORDER_PRODUCTS_SUPPLIER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ORDER_PRODUCTS_SUPPLIER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ORDER_PRODUCTS_SUPPLIER>("ORDER_PRODUCTS_SUPPLIER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ORDER_PRODUCTS_SUPPLIER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ORDER_PRODUCTS_SUPPLIER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inORDER_ID"></param>
	public static List<ORDER_PRODUCTS_SUPPLIER> ReadByORDER_ID(string inORDER_ID) {
		return rdodb_KTSqlDAC.ReadByParams<ORDER_PRODUCTS_SUPPLIER>("ORDER_PRODUCTS_SUPPLIER", rdodb_KTSqlDAC.newInParam("@ORDER_ID", inORDER_ID));
	}
	#endregion DAC Methods 
 }
}

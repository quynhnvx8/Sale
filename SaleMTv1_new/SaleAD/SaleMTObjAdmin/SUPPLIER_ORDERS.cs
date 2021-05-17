using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SUPPLIER_ORDERS {
	#region members
	string oRDER_ID;
	string dESCRIPTION;
	DateTime? cREATED_DATE;
	string cREATED_BY;
	DateTime? iNPUT_DATE;

	#endregion members
	#region Properties
	[PKSqlColumn("ORDER_ID", SqlDbType.VarChar, null)]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[SqlColumn("DESCRIPTION", SqlDbType.NVarChar)]
	public string DESCRIPTION {
		get { return dESCRIPTION; }
		set{ dESCRIPTION = value; }
	}
	[SqlColumn("CREATED_DATE", SqlDbType.DateTime)]
	public DateTime? CREATED_DATE {
		get { return cREATED_DATE; }
		set{ cREATED_DATE = value; }
	}
	[StringSqlColumn("CREATED_BY")]
	public string CREATED_BY {
		get { return cREATED_BY; }
		set{ cREATED_BY = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime? INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SUPPLIER_ORDERS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SUPPLIER_ORDERS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SUPPLIER_ORDERS>("SUPPLIER_ORDERS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SUPPLIER_ORDERS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SUPPLIER_ORDERS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inORDER_ID"></param>
	public static List<SUPPLIER_ORDERS> ReadByORDER_ID(string inORDER_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SUPPLIER_ORDERS>("SUPPLIER_ORDERS", rdodb_KTSqlDAC.newInParam("@ORDER_ID", inORDER_ID));
	}
	#endregion DAC Methods 
 }
}

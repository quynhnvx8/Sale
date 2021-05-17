using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class NORM_WAREHOUSE {
	#region members
	Guid aUTO_ID;
	string wAREHOUSE_CODE;
	string cATEGORY;
	float? qUANTITY;
	float? aMOUNT;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[StringSqlColumn("WAREHOUSE_CODE")]
	public string WAREHOUSE_CODE {
		get { return wAREHOUSE_CODE; }
		set{ wAREHOUSE_CODE = value; }
	}
	[StringSqlColumn("CATEGORY")]
	public string CATEGORY {
		get { return cATEGORY; }
		set{ cATEGORY = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Float)]
	public float? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Float)]
	public float? AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public NORM_WAREHOUSE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<NORM_WAREHOUSE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<NORM_WAREHOUSE>("NORM_WAREHOUSE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "NORM_WAREHOUSE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "NORM_WAREHOUSE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<NORM_WAREHOUSE> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<NORM_WAREHOUSE>("NORM_WAREHOUSE", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

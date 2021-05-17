using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ZONE_PRICE {
	#region members
	Guid aUTO_ID;
	string sTORE_CODE;
	string zONE_CODE;
	float? pRICE;
	bool? pERCENT;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[StringSqlColumn("ZONE_CODE")]
	public string ZONE_CODE {
		get { return zONE_CODE; }
		set{ zONE_CODE = value; }
	}
	[SqlColumn("PRICE", SqlDbType.Float)]
	public float? PRICE {
		get { return pRICE; }
		set{ pRICE = value; }
	}
	[SqlColumn("PERCENT", SqlDbType.Bit)]
	public bool? PERCENT {
		get { return pERCENT; }
		set{ pERCENT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ZONE_PRICE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ZONE_PRICE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ZONE_PRICE>("ZONE_PRICE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ZONE_PRICE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ZONE_PRICE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<ZONE_PRICE> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<ZONE_PRICE>("ZONE_PRICE", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

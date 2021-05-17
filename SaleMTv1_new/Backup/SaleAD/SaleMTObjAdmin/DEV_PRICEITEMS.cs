using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEV_PRICEITEMS {
	#region members
	string product;
	DateTime startDate;
	float? unitCost;
	float? unitPriceRate;
	float? unitPrice;
	float? taxItem;
	float? unitPriceWithTax;
	DateTime? sTART_DATE0;
	float? pRICE0;
	DateTime? cREATE_DATE0;
	string uSER_CREATE0;
	DateTime? sTART_DATE1;
	decimal? pRICE1;
	string rEASON1;
	string rEMARK1;
	DateTime? cREATE_DATE1;
	string uSER_CREATE1;
	DateTime? sTART_DATE2;
	float? pRICE2;
	string rEASON2;
	string rEMARK2;
	DateTime? cREATE_DATE2;
	string uSER_CREATE2;
	DateTime? sTART_DATE3;
	float? pRICE3;
	string rEASON3;
	string rEMARK3;
	DateTime? cREATE_DATE3;
	string uSER_CREATE3;
	DateTime? sTART_DATE4;
	float? pRICE4;
	string rEASON4;
	string rEMARK4;
	DateTime? cREATE_DATE4;
	string uSER_CREATE4;
	Guid aUTO_ID;

	#endregion members
	#region Properties
	[StringSqlColumn("Product")]
	public string Product {
		get { return product; }
		set{ product = value; }
	}
	[SqlColumn("StartDate", SqlDbType.DateTime)]
	public DateTime StartDate {
		get { return startDate; }
		set{ startDate = value; }
	}
	[SqlColumn("UnitCost", SqlDbType.Float)]
	public float? UnitCost {
		get { return unitCost; }
		set{ unitCost = value; }
	}
	[SqlColumn("UnitPriceRate", SqlDbType.Float)]
	public float? UnitPriceRate {
		get { return unitPriceRate; }
		set{ unitPriceRate = value; }
	}
	[SqlColumn("UnitPrice", SqlDbType.Float)]
	public float? UnitPrice {
		get { return unitPrice; }
		set{ unitPrice = value; }
	}
	[SqlColumn("TaxItem", SqlDbType.Float)]
	public float? TaxItem {
		get { return taxItem; }
		set{ taxItem = value; }
	}
	[SqlColumn("UnitPriceWithTax", SqlDbType.Float)]
	public float? UnitPriceWithTax {
		get { return unitPriceWithTax; }
		set{ unitPriceWithTax = value; }
	}
	[SqlColumn("START_DATE0", SqlDbType.DateTime)]
	public DateTime? START_DATE0 {
		get { return sTART_DATE0; }
		set{ sTART_DATE0 = value; }
	}
	[SqlColumn("PRICE0", SqlDbType.Float)]
	public float? PRICE0 {
		get { return pRICE0; }
		set{ pRICE0 = value; }
	}
	[SqlColumn("CREATE_DATE0", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE0 {
		get { return cREATE_DATE0; }
		set{ cREATE_DATE0 = value; }
	}
	[SqlColumn("USER_CREATE0", SqlDbType.NVarChar)]
	public string USER_CREATE0 {
		get { return uSER_CREATE0; }
		set{ uSER_CREATE0 = value; }
	}
	[SqlColumn("START_DATE1", SqlDbType.DateTime)]
	public DateTime? START_DATE1 {
		get { return sTART_DATE1; }
		set{ sTART_DATE1 = value; }
	}
	[SqlColumn("PRICE1", SqlDbType.Decimal)]
	public decimal? PRICE1 {
		get { return pRICE1; }
		set{ pRICE1 = value; }
	}
	[StringSqlColumn("REASON1")]
	public string REASON1 {
		get { return rEASON1; }
		set{ rEASON1 = value; }
	}
	[SqlColumn("REMARK1", SqlDbType.NVarChar)]
	public string REMARK1 {
		get { return rEMARK1; }
		set{ rEMARK1 = value; }
	}
	[SqlColumn("CREATE_DATE1", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE1 {
		get { return cREATE_DATE1; }
		set{ cREATE_DATE1 = value; }
	}
	[SqlColumn("USER_CREATE1", SqlDbType.NVarChar)]
	public string USER_CREATE1 {
		get { return uSER_CREATE1; }
		set{ uSER_CREATE1 = value; }
	}
	[SqlColumn("START_DATE2", SqlDbType.DateTime)]
	public DateTime? START_DATE2 {
		get { return sTART_DATE2; }
		set{ sTART_DATE2 = value; }
	}
	[SqlColumn("PRICE2", SqlDbType.Float)]
	public float? PRICE2 {
		get { return pRICE2; }
		set{ pRICE2 = value; }
	}
	[StringSqlColumn("REASON2")]
	public string REASON2 {
		get { return rEASON2; }
		set{ rEASON2 = value; }
	}
	[SqlColumn("REMARK2", SqlDbType.NVarChar)]
	public string REMARK2 {
		get { return rEMARK2; }
		set{ rEMARK2 = value; }
	}
	[SqlColumn("CREATE_DATE2", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE2 {
		get { return cREATE_DATE2; }
		set{ cREATE_DATE2 = value; }
	}
	[SqlColumn("USER_CREATE2", SqlDbType.NVarChar)]
	public string USER_CREATE2 {
		get { return uSER_CREATE2; }
		set{ uSER_CREATE2 = value; }
	}
	[SqlColumn("START_DATE3", SqlDbType.DateTime)]
	public DateTime? START_DATE3 {
		get { return sTART_DATE3; }
		set{ sTART_DATE3 = value; }
	}
	[SqlColumn("PRICE3", SqlDbType.Float)]
	public float? PRICE3 {
		get { return pRICE3; }
		set{ pRICE3 = value; }
	}
	[StringSqlColumn("REASON3")]
	public string REASON3 {
		get { return rEASON3; }
		set{ rEASON3 = value; }
	}
	[SqlColumn("REMARK3", SqlDbType.NVarChar)]
	public string REMARK3 {
		get { return rEMARK3; }
		set{ rEMARK3 = value; }
	}
	[SqlColumn("CREATE_DATE3", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE3 {
		get { return cREATE_DATE3; }
		set{ cREATE_DATE3 = value; }
	}
	[SqlColumn("USER_CREATE3", SqlDbType.NVarChar)]
	public string USER_CREATE3 {
		get { return uSER_CREATE3; }
		set{ uSER_CREATE3 = value; }
	}
	[SqlColumn("START_DATE4", SqlDbType.DateTime)]
	public DateTime? START_DATE4 {
		get { return sTART_DATE4; }
		set{ sTART_DATE4 = value; }
	}
	[SqlColumn("PRICE4", SqlDbType.Float)]
	public float? PRICE4 {
		get { return pRICE4; }
		set{ pRICE4 = value; }
	}
	[StringSqlColumn("REASON4")]
	public string REASON4 {
		get { return rEASON4; }
		set{ rEASON4 = value; }
	}
	[SqlColumn("REMARK4", SqlDbType.NVarChar)]
	public string REMARK4 {
		get { return rEMARK4; }
		set{ rEMARK4 = value; }
	}
	[SqlColumn("CREATE_DATE4", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE4 {
		get { return cREATE_DATE4; }
		set{ cREATE_DATE4 = value; }
	}
	[SqlColumn("USER_CREATE4", SqlDbType.NVarChar)]
	public string USER_CREATE4 {
		get { return uSER_CREATE4; }
		set{ uSER_CREATE4 = value; }
	}
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEV_PRICEITEMS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEV_PRICEITEMS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEV_PRICEITEMS>("DEV_PRICEITEMS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEV_PRICEITEMS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEV_PRICEITEMS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<DEV_PRICEITEMS> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<DEV_PRICEITEMS>("DEV_PRICEITEMS", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

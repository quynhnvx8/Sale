using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEV_PRICETABLEITEMHISTORIES {
	#region members
	long priceTableItem;
	DateTime startDate;
	DateTime? endDate;
	float? defaultCurrencyPrice;
	string currency;
	float? exchangeRate;

	#endregion members
	#region Properties
	[PKSqlColumn("PriceTableItem", SqlDbType.BigInt, 0)]
	public long PriceTableItem {
		get { return priceTableItem; }
		set{ priceTableItem = value; }
	}
	[PKSqlColumn("StartDate", SqlDbType.DateTime, null)]
	public DateTime StartDate {
		get { return startDate; }
		set{ startDate = value; }
	}
	[SqlColumn("EndDate", SqlDbType.DateTime)]
	public DateTime? EndDate {
		get { return endDate; }
		set{ endDate = value; }
	}
	[SqlColumn("DefaultCurrencyPrice", SqlDbType.Float)]
	public float? DefaultCurrencyPrice {
		get { return defaultCurrencyPrice; }
		set{ defaultCurrencyPrice = value; }
	}
	[SqlColumn("Currency", SqlDbType.NVarChar)]
	public string Currency {
		get { return currency; }
		set{ currency = value; }
	}
	[SqlColumn("ExchangeRate", SqlDbType.Float)]
	public float? ExchangeRate {
		get { return exchangeRate; }
		set{ exchangeRate = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEV_PRICETABLEITEMHISTORIES() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEV_PRICETABLEITEMHISTORIES> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEV_PRICETABLEITEMHISTORIES>("DEV_PRICETABLEITEMHISTORIES");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEV_PRICETABLEITEMHISTORIES");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEV_PRICETABLEITEMHISTORIES");
	}
	#endregion DAC Methods 
 }
}

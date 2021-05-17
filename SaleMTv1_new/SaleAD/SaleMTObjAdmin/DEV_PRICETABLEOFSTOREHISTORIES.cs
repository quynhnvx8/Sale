using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEV_PRICETABLEOFSTOREHISTORIES {
	#region members
	string storeID;
	string priceTableId;
	DateTime startDate;
	DateTime? endDate;
	float? discount;

	#endregion members
	#region Properties
	[PKSqlColumn("StoreID", SqlDbType.NVarChar, null)]
	public string StoreID {
		get { return storeID; }
		set{ storeID = value; }
	}
	[PKSqlColumn("PriceTableId", SqlDbType.NVarChar, null)]
	public string PriceTableId {
		get { return priceTableId; }
		set{ priceTableId = value; }
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
	[SqlColumn("Discount", SqlDbType.Float)]
	public float? Discount {
		get { return discount; }
		set{ discount = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEV_PRICETABLEOFSTOREHISTORIES() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEV_PRICETABLEOFSTOREHISTORIES> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEV_PRICETABLEOFSTOREHISTORIES>("DEV_PRICETABLEOFSTOREHISTORIES");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEV_PRICETABLEOFSTOREHISTORIES");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEV_PRICETABLEOFSTOREHISTORIES");
	}
	#endregion DAC Methods 
 }
}

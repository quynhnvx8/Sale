using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEV_PRICETABLEOFSTORE {
	#region members
	string storeId;
	string priceTableId;
	float? discount;
	DateTime? startDate;

	#endregion members
	#region Properties
	[PKSqlColumn("StoreId", SqlDbType.NVarChar, null)]
	public string StoreId {
		get { return storeId; }
		set{ storeId = value; }
	}
	[PKSqlColumn("PriceTableId", SqlDbType.NVarChar, null)]
	public string PriceTableId {
		get { return priceTableId; }
		set{ priceTableId = value; }
	}
	[SqlColumn("Discount", SqlDbType.Float)]
	public float? Discount {
		get { return discount; }
		set{ discount = value; }
	}
	[SqlColumn("StartDate", SqlDbType.DateTime)]
	public DateTime? StartDate {
		get { return startDate; }
		set{ startDate = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEV_PRICETABLEOFSTORE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEV_PRICETABLEOFSTORE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEV_PRICETABLEOFSTORE>("DEV_PRICETABLEOFSTORE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEV_PRICETABLEOFSTORE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEV_PRICETABLEOFSTORE");
	}
	#endregion DAC Methods 
 }
}

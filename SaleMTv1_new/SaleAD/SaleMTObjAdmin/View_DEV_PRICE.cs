using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class View_DEV_PRICE {
	#region members
	string product;
	decimal? pRICE1;

	#endregion members
	#region Properties
	[StringSqlColumn("Product")]
	public string Product {
		get { return product; }
		set{ product = value; }
	}
	[SqlColumn("PRICE1", SqlDbType.Decimal)]
	public decimal? PRICE1 {
		get { return pRICE1; }
		set{ pRICE1 = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public View_DEV_PRICE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<View_DEV_PRICE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<View_DEV_PRICE>("View_DEV_PRICE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "View_DEV_PRICE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "View_DEV_PRICE");
	}
	#endregion DAC Methods 
 }
}

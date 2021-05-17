using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PRODUCT_PRICE {
	#region members
	string product_id;
	float? gia_vnm;
	float? gia_daily;

	#endregion members
	#region Properties
	[StringSqlColumn("product_id")]
	public string Product_id {
		get { return product_id; }
		set{ product_id = value; }
	}
	[SqlColumn("gia_vnm", SqlDbType.Float)]
	public float? Gia_vnm {
		get { return gia_vnm; }
		set{ gia_vnm = value; }
	}
	[SqlColumn("gia_daily", SqlDbType.Float)]
	public float? Gia_daily {
		get { return gia_daily; }
		set{ gia_daily = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PRODUCT_PRICE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PRODUCT_PRICE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PRODUCT_PRICE>("PRODUCT_PRICE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PRODUCT_PRICE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PRODUCT_PRICE");
	}
	#endregion DAC Methods 
 }
}

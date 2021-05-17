using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALE_PROMOTION_GIFTS {
	#region members
	string eXPORT_CODE;
	string pRODUCT_ID;
	int? qUANTITY;
	string eVENT_ID;
	float? pRODUCT_PRICE;

	#endregion members
	#region Properties
	[PKSqlColumn("EXPORT_CODE", SqlDbType.VarChar, null)]
	public string EXPORT_CODE {
		get { return eXPORT_CODE; }
		set{ eXPORT_CODE = value; }
	}
	[PKSqlColumn("PRODUCT_ID", SqlDbType.VarChar, null)]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
	public float? PRODUCT_PRICE {
		get { return pRODUCT_PRICE; }
		set{ pRODUCT_PRICE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALE_PROMOTION_GIFTS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALE_PROMOTION_GIFTS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALE_PROMOTION_GIFTS>("SALE_PROMOTION_GIFTS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALE_PROMOTION_GIFTS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALE_PROMOTION_GIFTS");
	}
	#endregion DAC Methods 
 }
}

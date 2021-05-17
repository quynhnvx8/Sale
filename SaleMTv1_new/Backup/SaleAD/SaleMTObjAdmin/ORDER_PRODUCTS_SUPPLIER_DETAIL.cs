using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ORDER_PRODUCTS_SUPPLIER_DETAIL {
	#region members
	Guid iD;
	string oRDER_ID;
	string pRODUCT_ID;
	int? qUANTITY;
	float? pRODUCT_PRICE;
	int? qUANTITY_EXPORT;
	float? uNIT_PRICE;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[StringSqlColumn("ORDER_ID")]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
	public float? PRODUCT_PRICE {
		get { return pRODUCT_PRICE; }
		set{ pRODUCT_PRICE = value; }
	}
	[SqlColumn("QUANTITY_EXPORT", SqlDbType.Int)]
	public int? QUANTITY_EXPORT {
		get { return qUANTITY_EXPORT; }
		set{ qUANTITY_EXPORT = value; }
	}
	[SqlColumn("UNIT_PRICE", SqlDbType.Float)]
	public float? UNIT_PRICE {
		get { return uNIT_PRICE; }
		set{ uNIT_PRICE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ORDER_PRODUCTS_SUPPLIER_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ORDER_PRODUCTS_SUPPLIER_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ORDER_PRODUCTS_SUPPLIER_DETAIL>("ORDER_PRODUCTS_SUPPLIER_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ORDER_PRODUCTS_SUPPLIER_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ORDER_PRODUCTS_SUPPLIER_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<ORDER_PRODUCTS_SUPPLIER_DETAIL> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<ORDER_PRODUCTS_SUPPLIER_DETAIL>("ORDER_PRODUCTS_SUPPLIER_DETAIL", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

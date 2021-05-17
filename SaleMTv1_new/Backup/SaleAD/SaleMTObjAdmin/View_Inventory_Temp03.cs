using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class View_Inventory_Temp03 {
	#region members
	string pRODUCT_ID;
	int? qUANTITY;
	string sTORE_CODE;

	#endregion members
	#region Properties
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
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public View_Inventory_Temp03() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<View_Inventory_Temp03> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<View_Inventory_Temp03>("View_Inventory_Temp03");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "View_Inventory_Temp03");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "View_Inventory_Temp03");
	}
	#endregion DAC Methods 
 }
}

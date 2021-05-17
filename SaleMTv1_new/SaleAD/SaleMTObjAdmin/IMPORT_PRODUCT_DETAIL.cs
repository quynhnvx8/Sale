using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IMPORT_PRODUCT_DETAIL {
	#region members
	Guid iD;
	Guid iMPORT_ID;
	string pRODUCT_ID;
	string p_ID;
	float? oLD_PRICE;
	float? sUPPLIER_PRICE;
	float? pRODUCT_PRICE;
	int? qUANTITY;
	float? aVERAGE_PRICE;
	float? nEW_AVERAGE_PRICE;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("IMPORT_ID", SqlDbType.UniqueIdentifier)]
	public Guid IMPORT_ID {
		get { return iMPORT_ID; }
		set{ iMPORT_ID = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[StringSqlColumn("P_ID")]
	public string P_ID {
		get { return p_ID; }
		set{ p_ID = value; }
	}
	[SqlColumn("OLD_PRICE", SqlDbType.Float)]
	public float? OLD_PRICE {
		get { return oLD_PRICE; }
		set{ oLD_PRICE = value; }
	}
	[SqlColumn("SUPPLIER_PRICE", SqlDbType.Float)]
	public float? SUPPLIER_PRICE {
		get { return sUPPLIER_PRICE; }
		set{ sUPPLIER_PRICE = value; }
	}
	[SqlColumn("PRODUCT_PRICE", SqlDbType.Float)]
	public float? PRODUCT_PRICE {
		get { return pRODUCT_PRICE; }
		set{ pRODUCT_PRICE = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("AVERAGE_PRICE", SqlDbType.Float)]
	public float? AVERAGE_PRICE {
		get { return aVERAGE_PRICE; }
		set{ aVERAGE_PRICE = value; }
	}
	[SqlColumn("NEW_AVERAGE_PRICE", SqlDbType.Float)]
	public float? NEW_AVERAGE_PRICE {
		get { return nEW_AVERAGE_PRICE; }
		set{ nEW_AVERAGE_PRICE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public IMPORT_PRODUCT_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IMPORT_PRODUCT_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IMPORT_PRODUCT_DETAIL>("IMPORT_PRODUCT_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IMPORT_PRODUCT_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IMPORT_PRODUCT_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<IMPORT_PRODUCT_DETAIL> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<IMPORT_PRODUCT_DETAIL>("IMPORT_PRODUCT_DETAIL", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

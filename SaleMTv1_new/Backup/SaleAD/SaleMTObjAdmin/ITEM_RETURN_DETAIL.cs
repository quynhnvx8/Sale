using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ITEM_RETURN_DETAIL {
	#region members
	string iTEM_RETURN_DETAIL_CODE;
	string rETURN_CODE;
	string pRODUCT_ID;
	DateTime iNPUT_DATE;
	float qUANTITY;
	float pRICE_PRODUCT;
	string mASTER_CODE;
	string rEASON;
	string eVENT_ID;
	string zONE_CODE;
	string p_ID;
	float? pRICE_PRODUCT_SALE;

	#endregion members
	#region Properties
	[PKSqlColumn("ITEM_RETURN_DETAIL_CODE", SqlDbType.NVarChar, null)]
	public string ITEM_RETURN_DETAIL_CODE {
		get { return iTEM_RETURN_DETAIL_CODE; }
		set{ iTEM_RETURN_DETAIL_CODE = value; }
	}
	[StringSqlColumn("RETURN_CODE")]
	public string RETURN_CODE {
		get { return rETURN_CODE; }
		set{ rETURN_CODE = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Float)]
	public float QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("PRICE_PRODUCT", SqlDbType.Float)]
	public float PRICE_PRODUCT {
		get { return pRICE_PRODUCT; }
		set{ pRICE_PRODUCT = value; }
	}
	[SqlColumn("MASTER_CODE", SqlDbType.NVarChar)]
	public string MASTER_CODE {
		get { return mASTER_CODE; }
		set{ mASTER_CODE = value; }
	}
	[SqlColumn("REASON", SqlDbType.NVarChar)]
	public string REASON {
		get { return rEASON; }
		set{ rEASON = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("ZONE_CODE", SqlDbType.NVarChar)]
	public string ZONE_CODE {
		get { return zONE_CODE; }
		set{ zONE_CODE = value; }
	}
	[SqlColumn("P_ID", SqlDbType.NVarChar)]
	public string P_ID {
		get { return p_ID; }
		set{ p_ID = value; }
	}
	[SqlColumn("PRICE_PRODUCT_SALE", SqlDbType.Float)]
	public float? PRICE_PRODUCT_SALE {
		get { return pRICE_PRODUCT_SALE; }
		set{ pRICE_PRODUCT_SALE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ITEM_RETURN_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ITEM_RETURN_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ITEM_RETURN_DETAIL>("ITEM_RETURN_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ITEM_RETURN_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ITEM_RETURN_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inITEM_RETURN_DETAIL_CODE"></param>
	public static List<ITEM_RETURN_DETAIL> ReadByITEM_RETURN_DETAIL_CODE(string inITEM_RETURN_DETAIL_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<ITEM_RETURN_DETAIL>("ITEM_RETURN_DETAIL", rdodb_KTSqlDAC.newInParam("@ITEM_RETURN_DETAIL_CODE", inITEM_RETURN_DETAIL_CODE));
	}
	#endregion DAC Methods 
 }
}

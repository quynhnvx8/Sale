using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALE_PROMOTION {
	#region members
	Guid iD;
	string eXPORT_CODE;
	string pROGRAM_NO;
	string pROGRAM_TYPE;
	int qUANTITY_MIN;
	int qUANTITY_MAX;
	float aMOUNT_MIN;
	float aMOUNT_MAX;
	string gIFT;
	int? gIFT_QUANTITY;
	string fOR_PRODUCTS;
	int? nUMBER_MARK;
	string cUSTOMER_ID;
	int? cUSTOMER_NUMBER_MARK_BEFORE;
	string cUSTOMER_GROUP_CODE;
	string cUSTOMER_CARD_NO;
	string cUSTOMER_CARD_TYPE;
	float? dISCOUNT_RESULT;
	int? nUMBER_MARK_RESULT;
	string eVENT_ID;
	string dISCOUNT_ON;
	float? dISCOUNT_VALUE;
	string gIFT_TWO;
	int? qUANTITY_BUY;
	int? qUANTITY_GIFT;
	int? qUANTITY_GIFT_TWO;
	string oTHER_VALUE;
	int? qUANTITY_DISCOUNT;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[StringSqlColumn("EXPORT_CODE")]
	public string EXPORT_CODE {
		get { return eXPORT_CODE; }
		set{ eXPORT_CODE = value; }
	}
	[StringSqlColumn("PROGRAM_NO")]
	public string PROGRAM_NO {
		get { return pROGRAM_NO; }
		set{ pROGRAM_NO = value; }
	}
	[StringSqlColumn("PROGRAM_TYPE")]
	public string PROGRAM_TYPE {
		get { return pROGRAM_TYPE; }
		set{ pROGRAM_TYPE = value; }
	}
	[SqlColumn("QUANTITY_MIN", SqlDbType.Int)]
	public int QUANTITY_MIN {
		get { return qUANTITY_MIN; }
		set{ qUANTITY_MIN = value; }
	}
	[SqlColumn("QUANTITY_MAX", SqlDbType.Int)]
	public int QUANTITY_MAX {
		get { return qUANTITY_MAX; }
		set{ qUANTITY_MAX = value; }
	}
	[SqlColumn("AMOUNT_MIN", SqlDbType.Float)]
	public float AMOUNT_MIN {
		get { return aMOUNT_MIN; }
		set{ aMOUNT_MIN = value; }
	}
	[SqlColumn("AMOUNT_MAX", SqlDbType.Float)]
	public float AMOUNT_MAX {
		get { return aMOUNT_MAX; }
		set{ aMOUNT_MAX = value; }
	}
	[SqlColumn("GIFT", SqlDbType.NVarChar)]
	public string GIFT {
		get { return gIFT; }
		set{ gIFT = value; }
	}
	[SqlColumn("GIFT_QUANTITY", SqlDbType.Int)]
	public int? GIFT_QUANTITY {
		get { return gIFT_QUANTITY; }
		set{ gIFT_QUANTITY = value; }
	}
	[StringSqlColumn("FOR_PRODUCTS")]
	public string FOR_PRODUCTS {
		get { return fOR_PRODUCTS; }
		set{ fOR_PRODUCTS = value; }
	}
	[SqlColumn("NUMBER_MARK", SqlDbType.Int)]
	public int? NUMBER_MARK {
		get { return nUMBER_MARK; }
		set{ nUMBER_MARK = value; }
	}
	[StringSqlColumn("CUSTOMER_ID")]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("CUSTOMER_NUMBER_MARK_BEFORE", SqlDbType.Int)]
	public int? CUSTOMER_NUMBER_MARK_BEFORE {
		get { return cUSTOMER_NUMBER_MARK_BEFORE; }
		set{ cUSTOMER_NUMBER_MARK_BEFORE = value; }
	}
	[StringSqlColumn("CUSTOMER_GROUP_CODE")]
	public string CUSTOMER_GROUP_CODE {
		get { return cUSTOMER_GROUP_CODE; }
		set{ cUSTOMER_GROUP_CODE = value; }
	}
	[StringSqlColumn("CUSTOMER_CARD_NO")]
	public string CUSTOMER_CARD_NO {
		get { return cUSTOMER_CARD_NO; }
		set{ cUSTOMER_CARD_NO = value; }
	}
	[StringSqlColumn("CUSTOMER_CARD_TYPE")]
	public string CUSTOMER_CARD_TYPE {
		get { return cUSTOMER_CARD_TYPE; }
		set{ cUSTOMER_CARD_TYPE = value; }
	}
	[SqlColumn("DISCOUNT_RESULT", SqlDbType.Float)]
	public float? DISCOUNT_RESULT {
		get { return dISCOUNT_RESULT; }
		set{ dISCOUNT_RESULT = value; }
	}
	[SqlColumn("NUMBER_MARK_RESULT", SqlDbType.Int)]
	public int? NUMBER_MARK_RESULT {
		get { return nUMBER_MARK_RESULT; }
		set{ nUMBER_MARK_RESULT = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[StringSqlColumn("DISCOUNT_ON")]
	public string DISCOUNT_ON {
		get { return dISCOUNT_ON; }
		set{ dISCOUNT_ON = value; }
	}
	[SqlColumn("DISCOUNT_VALUE", SqlDbType.Float)]
	public float? DISCOUNT_VALUE {
		get { return dISCOUNT_VALUE; }
		set{ dISCOUNT_VALUE = value; }
	}
	[SqlColumn("GIFT_TWO", SqlDbType.NVarChar)]
	public string GIFT_TWO {
		get { return gIFT_TWO; }
		set{ gIFT_TWO = value; }
	}
	[SqlColumn("QUANTITY_BUY", SqlDbType.Int)]
	public int? QUANTITY_BUY {
		get { return qUANTITY_BUY; }
		set{ qUANTITY_BUY = value; }
	}
	[SqlColumn("QUANTITY_GIFT", SqlDbType.Int)]
	public int? QUANTITY_GIFT {
		get { return qUANTITY_GIFT; }
		set{ qUANTITY_GIFT = value; }
	}
	[SqlColumn("QUANTITY_GIFT_TWO", SqlDbType.Int)]
	public int? QUANTITY_GIFT_TWO {
		get { return qUANTITY_GIFT_TWO; }
		set{ qUANTITY_GIFT_TWO = value; }
	}
	[SqlColumn("OTHER_VALUE", SqlDbType.NVarChar)]
	public string OTHER_VALUE {
		get { return oTHER_VALUE; }
		set{ oTHER_VALUE = value; }
	}
	[SqlColumn("QUANTITY_DISCOUNT", SqlDbType.Int)]
	public int? QUANTITY_DISCOUNT {
		get { return qUANTITY_DISCOUNT; }
		set{ qUANTITY_DISCOUNT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALE_PROMOTION() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALE_PROMOTION> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALE_PROMOTION>("SALE_PROMOTION");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALE_PROMOTION");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALE_PROMOTION");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<SALE_PROMOTION> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<SALE_PROMOTION>("SALE_PROMOTION", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

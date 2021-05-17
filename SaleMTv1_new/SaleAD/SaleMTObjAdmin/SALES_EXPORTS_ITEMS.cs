using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALES_EXPORTS_ITEMS {
	#region members
	Guid iD;
	DateTime eXPORT_DATE;
	DateTime iNPUT_DATE;
	string eXPORT_CODE;
	string pRODUCT_ID;
	string bARCODE;
	int qUANTITY;
	float aMOUNT;
	float pRICE_DEFAULT;
	float pRICE_SALES;
	float dISCOUNT;
	float? rEBATE;
	float? pROMOTION;
	string rEMARK;
	string oUTPUT_TYPE;
	string eMPLOYEE_ID;
	string zONE_CODE;
	string eVENT_ID;
	float? tOTAL_AMOUNT;
	string rETURN_CODE;
	DateTime? dELIVERY_DATE;
	float? rEBATE_BY_CUSTOMER_CARD;
	string mA_KHO;
	int? qUANTITY_EXPORTED;
	string p_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("EXPORT_DATE", SqlDbType.DateTime)]
	public DateTime EXPORT_DATE {
		get { return eXPORT_DATE; }
		set{ eXPORT_DATE = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[StringSqlColumn("EXPORT_CODE")]
	public string EXPORT_CODE {
		get { return eXPORT_CODE; }
		set{ eXPORT_CODE = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[StringSqlColumn("BARCODE")]
	public string BARCODE {
		get { return bARCODE; }
		set{ bARCODE = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Float)]
	public float AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}
	[SqlColumn("PRICE_DEFAULT", SqlDbType.Float)]
	public float PRICE_DEFAULT {
		get { return pRICE_DEFAULT; }
		set{ pRICE_DEFAULT = value; }
	}
	[SqlColumn("PRICE_SALES", SqlDbType.Float)]
	public float PRICE_SALES {
		get { return pRICE_SALES; }
		set{ pRICE_SALES = value; }
	}
	[SqlColumn("DISCOUNT", SqlDbType.Float)]
	public float DISCOUNT {
		get { return dISCOUNT; }
		set{ dISCOUNT = value; }
	}
	[SqlColumn("REBATE", SqlDbType.Float)]
	public float? REBATE {
		get { return rEBATE; }
		set{ rEBATE = value; }
	}
	[SqlColumn("PROMOTION", SqlDbType.Float)]
	public float? PROMOTION {
		get { return pROMOTION; }
		set{ pROMOTION = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[StringSqlColumn("OUTPUT_TYPE")]
	public string OUTPUT_TYPE {
		get { return oUTPUT_TYPE; }
		set{ oUTPUT_TYPE = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[StringSqlColumn("ZONE_CODE")]
	public string ZONE_CODE {
		get { return zONE_CODE; }
		set{ zONE_CODE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("TOTAL_AMOUNT", SqlDbType.Float)]
	public float? TOTAL_AMOUNT {
		get { return tOTAL_AMOUNT; }
		set{ tOTAL_AMOUNT = value; }
	}
	[StringSqlColumn("RETURN_CODE")]
	public string RETURN_CODE {
		get { return rETURN_CODE; }
		set{ rETURN_CODE = value; }
	}
	[SqlColumn("DELIVERY_DATE", SqlDbType.DateTime)]
	public DateTime? DELIVERY_DATE {
		get { return dELIVERY_DATE; }
		set{ dELIVERY_DATE = value; }
	}
	[SqlColumn("REBATE_BY_CUSTOMER_CARD", SqlDbType.Float)]
	public float? REBATE_BY_CUSTOMER_CARD {
		get { return rEBATE_BY_CUSTOMER_CARD; }
		set{ rEBATE_BY_CUSTOMER_CARD = value; }
	}
	[SqlColumn("MA_KHO", SqlDbType.NVarChar)]
	public string MA_KHO {
		get { return mA_KHO; }
		set{ mA_KHO = value; }
	}
	[SqlColumn("QUANTITY_EXPORTED", SqlDbType.Int)]
	public int? QUANTITY_EXPORTED {
		get { return qUANTITY_EXPORTED; }
		set{ qUANTITY_EXPORTED = value; }
	}
	[StringSqlColumn("P_ID")]
	public string P_ID {
		get { return p_ID; }
		set{ p_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALES_EXPORTS_ITEMS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALES_EXPORTS_ITEMS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALES_EXPORTS_ITEMS>("SALES_EXPORTS_ITEMS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALES_EXPORTS_ITEMS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALES_EXPORTS_ITEMS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<SALES_EXPORTS_ITEMS> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS_ITEMS>("SALES_EXPORTS_ITEMS", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inPRODUCT_ID"></param>
	public static List<SALES_EXPORTS_ITEMS> ReadByPRODUCT_ID(string inPRODUCT_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS_ITEMS>("SALES_EXPORTS_ITEMS", rdodb_KTSqlDAC.newInParam("@PRODUCT_ID", inPRODUCT_ID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inEMPLOYEE_ID"></param>
	public static List<SALES_EXPORTS_ITEMS> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS_ITEMS>("SALES_EXPORTS_ITEMS", rdodb_KTSqlDAC.newInParam("@EMPLOYEE_ID", inEMPLOYEE_ID));
	}
	#endregion DAC Methods 
 }
}

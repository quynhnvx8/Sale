using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALES_EXPORTS {
	#region members
	string eXPORT_CODE;
	DateTime eXPORT_DATE;
	DateTime iNPUT_DATE;
	float tOTAL_AMOUNT;
	float tOTAL_DISCOUNT;
	string aCCOUNT;
	string cUSTOMER_ID;
	string sTORE_CODE;
	string cURRENCY_ID;
	string eVENT_ID;
	float? tOTAL_PROMOTION;
	float? tOTAL_PAYMENTS;
	float? tOTAL_PAID;
	float? bALANCE;
	string tRANSFER_SHIFT_CODE;
	bool? iS_BARTER;
	float? tOTAL_REBATE;
	int? tOTAL_NUMBER_MARK;
	string oTHER_GIFT;
	string rED_INVOIDE_COMPANYNAME;
	string rED_INVOICE_TAXCODE;
	string rED_INVOICE_ADDRESS;
	bool? uSED_RED_INVOIDE;
	string maKH;
	int? cUSTOMER_NUMBER_MARK;
	string cUSTOMER_CARD_CODE;
	string cUSTOMER_LEVEL;
	float? cUSTOMER_CARD_DISCOUNT_PERCENT;
	string rED_INVOICE_REMARK;
	string rEMARK;

	#endregion members
	#region Properties
	[PKSqlColumn("EXPORT_CODE", SqlDbType.VarChar, null)]
	public string EXPORT_CODE {
		get { return eXPORT_CODE; }
		set{ eXPORT_CODE = value; }
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
	[SqlColumn("TOTAL_AMOUNT", SqlDbType.Float)]
	public float TOTAL_AMOUNT {
		get { return tOTAL_AMOUNT; }
		set{ tOTAL_AMOUNT = value; }
	}
	[SqlColumn("TOTAL_DISCOUNT", SqlDbType.Float)]
	public float TOTAL_DISCOUNT {
		get { return tOTAL_DISCOUNT; }
		set{ tOTAL_DISCOUNT = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[StringSqlColumn("CUSTOMER_ID")]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[StringSqlColumn("CURRENCY_ID")]
	public string CURRENCY_ID {
		get { return cURRENCY_ID; }
		set{ cURRENCY_ID = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("TOTAL_PROMOTION", SqlDbType.Float)]
	public float? TOTAL_PROMOTION {
		get { return tOTAL_PROMOTION; }
		set{ tOTAL_PROMOTION = value; }
	}
	[SqlColumn("TOTAL_PAYMENTS", SqlDbType.Float)]
	public float? TOTAL_PAYMENTS {
		get { return tOTAL_PAYMENTS; }
		set{ tOTAL_PAYMENTS = value; }
	}
	[SqlColumn("TOTAL_PAID", SqlDbType.Float)]
	public float? TOTAL_PAID {
		get { return tOTAL_PAID; }
		set{ tOTAL_PAID = value; }
	}
	[SqlColumn("BALANCE", SqlDbType.Float)]
	public float? BALANCE {
		get { return bALANCE; }
		set{ bALANCE = value; }
	}
	[StringSqlColumn("TRANSFER_SHIFT_CODE")]
	public string TRANSFER_SHIFT_CODE {
		get { return tRANSFER_SHIFT_CODE; }
		set{ tRANSFER_SHIFT_CODE = value; }
	}
	[SqlColumn("IS_BARTER", SqlDbType.Bit)]
	public bool? IS_BARTER {
		get { return iS_BARTER; }
		set{ iS_BARTER = value; }
	}
	[SqlColumn("TOTAL_REBATE", SqlDbType.Float)]
	public float? TOTAL_REBATE {
		get { return tOTAL_REBATE; }
		set{ tOTAL_REBATE = value; }
	}
	[SqlColumn("TOTAL_NUMBER_MARK", SqlDbType.Int)]
	public int? TOTAL_NUMBER_MARK {
		get { return tOTAL_NUMBER_MARK; }
		set{ tOTAL_NUMBER_MARK = value; }
	}
	[SqlColumn("OTHER_GIFT", SqlDbType.NVarChar)]
	public string OTHER_GIFT {
		get { return oTHER_GIFT; }
		set{ oTHER_GIFT = value; }
	}
	[SqlColumn("RED_INVOIDE_COMPANYNAME", SqlDbType.NVarChar)]
	public string RED_INVOIDE_COMPANYNAME {
		get { return rED_INVOIDE_COMPANYNAME; }
		set{ rED_INVOIDE_COMPANYNAME = value; }
	}
	[StringSqlColumn("RED_INVOICE_TAXCODE")]
	public string RED_INVOICE_TAXCODE {
		get { return rED_INVOICE_TAXCODE; }
		set{ rED_INVOICE_TAXCODE = value; }
	}
	[SqlColumn("RED_INVOICE_ADDRESS", SqlDbType.NVarChar)]
	public string RED_INVOICE_ADDRESS {
		get { return rED_INVOICE_ADDRESS; }
		set{ rED_INVOICE_ADDRESS = value; }
	}
	[SqlColumn("USED_RED_INVOIDE", SqlDbType.Bit)]
	public bool? USED_RED_INVOIDE {
		get { return uSED_RED_INVOIDE; }
		set{ uSED_RED_INVOIDE = value; }
	}
	[StringSqlColumn("MaKH")]
	public string MaKH {
		get { return maKH; }
		set{ maKH = value; }
	}
	[SqlColumn("CUSTOMER_NUMBER_MARK", SqlDbType.Int)]
	public int? CUSTOMER_NUMBER_MARK {
		get { return cUSTOMER_NUMBER_MARK; }
		set{ cUSTOMER_NUMBER_MARK = value; }
	}
	[StringSqlColumn("CUSTOMER_CARD_CODE")]
	public string CUSTOMER_CARD_CODE {
		get { return cUSTOMER_CARD_CODE; }
		set{ cUSTOMER_CARD_CODE = value; }
	}
	[StringSqlColumn("CUSTOMER_LEVEL")]
	public string CUSTOMER_LEVEL {
		get { return cUSTOMER_LEVEL; }
		set{ cUSTOMER_LEVEL = value; }
	}
	[SqlColumn("CUSTOMER_CARD_DISCOUNT_PERCENT", SqlDbType.Float)]
	public float? CUSTOMER_CARD_DISCOUNT_PERCENT {
		get { return cUSTOMER_CARD_DISCOUNT_PERCENT; }
		set{ cUSTOMER_CARD_DISCOUNT_PERCENT = value; }
	}
	[SqlColumn("RED_INVOICE_REMARK", SqlDbType.NVarChar)]
	public string RED_INVOICE_REMARK {
		get { return rED_INVOICE_REMARK; }
		set{ rED_INVOICE_REMARK = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALES_EXPORTS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALES_EXPORTS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALES_EXPORTS>("SALES_EXPORTS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALES_EXPORTS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALES_EXPORTS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEXPORT_CODE"></param>
	public static List<SALES_EXPORTS> ReadByEXPORT_CODE(string inEXPORT_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS>("SALES_EXPORTS", rdodb_KTSqlDAC.newInParam("@EXPORT_CODE", inEXPORT_CODE));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inACCOUNT"></param>
	public static List<SALES_EXPORTS> ReadByACCOUNT(string inACCOUNT) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS>("SALES_EXPORTS", rdodb_KTSqlDAC.newInParam("@ACCOUNT", inACCOUNT));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inCURRENCY_ID"></param>
	public static List<SALES_EXPORTS> ReadByCURRENCY_ID(string inCURRENCY_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_EXPORTS>("SALES_EXPORTS", rdodb_KTSqlDAC.newInParam("@CURRENCY_ID", inCURRENCY_ID));
	}
	#endregion DAC Methods 
 }
}

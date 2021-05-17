using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALES_SPECIAL_DISCOUNT {
	#region members
	Guid iD;
	string eXPORT_CODE;
	string dISCOUNT_TERM_CODE;
	string dISCOUNT_TYPE;
	float? dISCOUNT_PECENT;
	float? dISCOUNT_AMOUNT;
	string fOR_PRODUCT;
	float? dISCOUNT_RESULT;
	string rEMARK;
	string dISCOUNT_BY;
	string eVENT_ID;
	float? tOTAL_DISCOUNT_AMOUNT;
	string aUTHENTICATION_BY;

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
	[StringSqlColumn("DISCOUNT_TERM_CODE")]
	public string DISCOUNT_TERM_CODE {
		get { return dISCOUNT_TERM_CODE; }
		set{ dISCOUNT_TERM_CODE = value; }
	}
	[StringSqlColumn("DISCOUNT_TYPE")]
	public string DISCOUNT_TYPE {
		get { return dISCOUNT_TYPE; }
		set{ dISCOUNT_TYPE = value; }
	}
	[SqlColumn("DISCOUNT_PECENT", SqlDbType.Float)]
	public float? DISCOUNT_PECENT {
		get { return dISCOUNT_PECENT; }
		set{ dISCOUNT_PECENT = value; }
	}
	[SqlColumn("DISCOUNT_AMOUNT", SqlDbType.Float)]
	public float? DISCOUNT_AMOUNT {
		get { return dISCOUNT_AMOUNT; }
		set{ dISCOUNT_AMOUNT = value; }
	}
	[StringSqlColumn("FOR_PRODUCT")]
	public string FOR_PRODUCT {
		get { return fOR_PRODUCT; }
		set{ fOR_PRODUCT = value; }
	}
	[SqlColumn("DISCOUNT_RESULT", SqlDbType.Float)]
	public float? DISCOUNT_RESULT {
		get { return dISCOUNT_RESULT; }
		set{ dISCOUNT_RESULT = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("DISCOUNT_BY", SqlDbType.NVarChar)]
	public string DISCOUNT_BY {
		get { return dISCOUNT_BY; }
		set{ dISCOUNT_BY = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("TOTAL_DISCOUNT_AMOUNT", SqlDbType.Float)]
	public float? TOTAL_DISCOUNT_AMOUNT {
		get { return tOTAL_DISCOUNT_AMOUNT; }
		set{ tOTAL_DISCOUNT_AMOUNT = value; }
	}
	[SqlColumn("AUTHENTICATION_BY", SqlDbType.NVarChar)]
	public string AUTHENTICATION_BY {
		get { return aUTHENTICATION_BY; }
		set{ aUTHENTICATION_BY = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALES_SPECIAL_DISCOUNT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALES_SPECIAL_DISCOUNT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALES_SPECIAL_DISCOUNT>("SALES_SPECIAL_DISCOUNT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALES_SPECIAL_DISCOUNT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALES_SPECIAL_DISCOUNT");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<SALES_SPECIAL_DISCOUNT> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_SPECIAL_DISCOUNT>("SALES_SPECIAL_DISCOUNT", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inEXPORT_CODE"></param>
	public static List<SALES_SPECIAL_DISCOUNT> ReadByEXPORT_CODE(string inEXPORT_CODE) {
		object parameter = inEXPORT_CODE ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<SALES_SPECIAL_DISCOUNT>("SALES_SPECIAL_DISCOUNT", rdodb_KTSqlDAC.newInParam("@EXPORT_CODE", parameter));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inDISCOUNT_TERM_CODE"></param>
	public static List<SALES_SPECIAL_DISCOUNT> ReadByDISCOUNT_TERM_CODE(string inDISCOUNT_TERM_CODE) {
		object parameter = inDISCOUNT_TERM_CODE ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<SALES_SPECIAL_DISCOUNT>("SALES_SPECIAL_DISCOUNT", rdodb_KTSqlDAC.newInParam("@DISCOUNT_TERM_CODE", parameter));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inDISCOUNT_BY"></param>
	public static List<SALES_SPECIAL_DISCOUNT> ReadByDISCOUNT_BY(string inDISCOUNT_BY) {
		object parameter = inDISCOUNT_BY ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<SALES_SPECIAL_DISCOUNT>("SALES_SPECIAL_DISCOUNT", rdodb_KTSqlDAC.newInParam("@DISCOUNT_BY", parameter));
	}
	#endregion DAC Methods 
 }
}

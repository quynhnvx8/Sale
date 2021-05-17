using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEBT_RECEIPT_PAYMENT_VOUNCHER {
	#region members
	Guid iD;
	string pAYMENT_VOUNCHER_ID;
	string oRDER_ID;
	string sUPPLIER_ID;
	int? vOUNCHER_TYPE;
	float? aMOUNT_MONEY;
	string cURRENCY_ID;
	float? eXCHANGE_RATE;
	string cREATE_BY;
	DateTime? cREATE_DATE;
	string rEMARK;
	bool? iS_PRINT;
	DateTime? dATE_PRINT;
	string dOCUMENT_ATTACHED;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[StringSqlColumn("PAYMENT_VOUNCHER_ID")]
	public string PAYMENT_VOUNCHER_ID {
		get { return pAYMENT_VOUNCHER_ID; }
		set{ pAYMENT_VOUNCHER_ID = value; }
	}
	[StringSqlColumn("ORDER_ID")]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[StringSqlColumn("SUPPLIER_ID")]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[SqlColumn("VOUNCHER_TYPE", SqlDbType.Int)]
	public int? VOUNCHER_TYPE {
		get { return vOUNCHER_TYPE; }
		set{ vOUNCHER_TYPE = value; }
	}
	[SqlColumn("AMOUNT_MONEY", SqlDbType.Float)]
	public float? AMOUNT_MONEY {
		get { return aMOUNT_MONEY; }
		set{ aMOUNT_MONEY = value; }
	}
	[StringSqlColumn("CURRENCY_ID")]
	public string CURRENCY_ID {
		get { return cURRENCY_ID; }
		set{ cURRENCY_ID = value; }
	}
	[SqlColumn("EXCHANGE_RATE", SqlDbType.Float)]
	public float? EXCHANGE_RATE {
		get { return eXCHANGE_RATE; }
		set{ eXCHANGE_RATE = value; }
	}
	[StringSqlColumn("CREATE_BY")]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("IS_PRINT", SqlDbType.Bit)]
	public bool? IS_PRINT {
		get { return iS_PRINT; }
		set{ iS_PRINT = value; }
	}
	[SqlColumn("DATE_PRINT", SqlDbType.DateTime)]
	public DateTime? DATE_PRINT {
		get { return dATE_PRINT; }
		set{ dATE_PRINT = value; }
	}
	[SqlColumn("DOCUMENT_ATTACHED", SqlDbType.NVarChar)]
	public string DOCUMENT_ATTACHED {
		get { return dOCUMENT_ATTACHED; }
		set{ dOCUMENT_ATTACHED = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEBT_RECEIPT_PAYMENT_VOUNCHER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEBT_RECEIPT_PAYMENT_VOUNCHER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEBT_RECEIPT_PAYMENT_VOUNCHER>("DEBT_RECEIPT_PAYMENT_VOUNCHER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEBT_RECEIPT_PAYMENT_VOUNCHER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEBT_RECEIPT_PAYMENT_VOUNCHER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<DEBT_RECEIPT_PAYMENT_VOUNCHER> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<DEBT_RECEIPT_PAYMENT_VOUNCHER>("DEBT_RECEIPT_PAYMENT_VOUNCHER", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

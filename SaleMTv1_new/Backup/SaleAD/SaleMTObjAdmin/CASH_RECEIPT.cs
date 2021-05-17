using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class CASH_RECEIPT {
	#region members
	string cASH_RECEIPT_ID;
	int dEPT_CODE;
	string cASH_TYPE_CODE;
	string cASH_TYPE_OTHER;
	string cASH_RECEIPT_FROM;
	string cURRENCY_ID;
	float aMOUNT;
	DateTime dATE_RECEIPT;
	string eMPLOYEE_ID;
	string rEMARK;
	string eVENT_ID;
	string tRANSFER_SHIFT_CODE;
	float? eXCHANGE_RATE;

	#endregion members
	#region Properties
	[PKSqlColumn("CASH_RECEIPT_ID", SqlDbType.VarChar, null)]
	public string CASH_RECEIPT_ID {
		get { return cASH_RECEIPT_ID; }
		set{ cASH_RECEIPT_ID = value; }
	}
	[SqlColumn("DEPT_CODE", SqlDbType.Int)]
	public int DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
	}
	[StringSqlColumn("CASH_TYPE_CODE")]
	public string CASH_TYPE_CODE {
		get { return cASH_TYPE_CODE; }
		set{ cASH_TYPE_CODE = value; }
	}
	[SqlColumn("CASH_TYPE_OTHER", SqlDbType.NVarChar)]
	public string CASH_TYPE_OTHER {
		get { return cASH_TYPE_OTHER; }
		set{ cASH_TYPE_OTHER = value; }
	}
	[SqlColumn("CASH_RECEIPT_FROM", SqlDbType.NVarChar)]
	public string CASH_RECEIPT_FROM {
		get { return cASH_RECEIPT_FROM; }
		set{ cASH_RECEIPT_FROM = value; }
	}
	[StringSqlColumn("CURRENCY_ID")]
	public string CURRENCY_ID {
		get { return cURRENCY_ID; }
		set{ cURRENCY_ID = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Float)]
	public float AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}
	[SqlColumn("DATE_RECEIPT", SqlDbType.DateTime)]
	public DateTime DATE_RECEIPT {
		get { return dATE_RECEIPT; }
		set{ dATE_RECEIPT = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[StringSqlColumn("TRANSFER_SHIFT_CODE")]
	public string TRANSFER_SHIFT_CODE {
		get { return tRANSFER_SHIFT_CODE; }
		set{ tRANSFER_SHIFT_CODE = value; }
	}
	[SqlColumn("EXCHANGE_RATE", SqlDbType.Float)]
	public float? EXCHANGE_RATE {
		get { return eXCHANGE_RATE; }
		set{ eXCHANGE_RATE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public CASH_RECEIPT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<CASH_RECEIPT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<CASH_RECEIPT>("CASH_RECEIPT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "CASH_RECEIPT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "CASH_RECEIPT");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCASH_RECEIPT_ID"></param>
	public static List<CASH_RECEIPT> ReadByCASH_RECEIPT_ID(string inCASH_RECEIPT_ID) {
		return rdodb_KTSqlDAC.ReadByParams<CASH_RECEIPT>("CASH_RECEIPT", rdodb_KTSqlDAC.newInParam("@CASH_RECEIPT_ID", inCASH_RECEIPT_ID));
	}
	#endregion DAC Methods 
 }
}

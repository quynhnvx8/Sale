using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DISCOUNT_TERM {
	#region members
	string dISCOUNT_CODE;
	string dISCOUNT_NAME;
	DateTime? dATE_START;
	DateTime? dATE_END;
	float? dISCOUNT_AMOUNT;
	string dISCOUNT_CONDITION;
	string aCCOUNT;
	DateTime? cREATE_DATE;
	string dISCOUNT_STATUS;

	#endregion members
	#region Properties
	[PKSqlColumn("DISCOUNT_CODE", SqlDbType.VarChar, null)]
	public string DISCOUNT_CODE {
		get { return dISCOUNT_CODE; }
		set{ dISCOUNT_CODE = value; }
	}
	[SqlColumn("DISCOUNT_NAME", SqlDbType.NVarChar)]
	public string DISCOUNT_NAME {
		get { return dISCOUNT_NAME; }
		set{ dISCOUNT_NAME = value; }
	}
	[SqlColumn("DATE_START", SqlDbType.DateTime)]
	public DateTime? DATE_START {
		get { return dATE_START; }
		set{ dATE_START = value; }
	}
	[SqlColumn("DATE_END", SqlDbType.DateTime)]
	public DateTime? DATE_END {
		get { return dATE_END; }
		set{ dATE_END = value; }
	}
	[SqlColumn("DISCOUNT_AMOUNT", SqlDbType.Float)]
	public float? DISCOUNT_AMOUNT {
		get { return dISCOUNT_AMOUNT; }
		set{ dISCOUNT_AMOUNT = value; }
	}
	[SqlColumn("DISCOUNT_CONDITION", SqlDbType.NVarChar)]
	public string DISCOUNT_CONDITION {
		get { return dISCOUNT_CONDITION; }
		set{ dISCOUNT_CONDITION = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[StringSqlColumn("DISCOUNT_STATUS")]
	public string DISCOUNT_STATUS {
		get { return dISCOUNT_STATUS; }
		set{ dISCOUNT_STATUS = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DISCOUNT_TERM() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DISCOUNT_TERM> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DISCOUNT_TERM>("DISCOUNT_TERM");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DISCOUNT_TERM");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DISCOUNT_TERM");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inDISCOUNT_CODE"></param>
	public static List<DISCOUNT_TERM> ReadByDISCOUNT_CODE(string inDISCOUNT_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<DISCOUNT_TERM>("DISCOUNT_TERM", rdodb_KTSqlDAC.newInParam("@DISCOUNT_CODE", inDISCOUNT_CODE));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inACCOUNT"></param>
	public static List<DISCOUNT_TERM> ReadByACCOUNT(string inACCOUNT) {
		object parameter = inACCOUNT ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<DISCOUNT_TERM>("DISCOUNT_TERM", rdodb_KTSqlDAC.newInParam("@ACCOUNT", parameter));
	}
	#endregion DAC Methods 
 }
}

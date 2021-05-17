using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALES_PAYMENT_HISTORY_DETAIL {
	#region members
	Guid aUTO_ID;
	Guid sALES_PAYMENT_HISTORY_ID;
	string cURRENCY_ID;
	float rATE;
	float mONEYS;
	float aMOUNT;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[SqlColumn("SALES_PAYMENT_HISTORY_ID", SqlDbType.UniqueIdentifier)]
	public Guid SALES_PAYMENT_HISTORY_ID {
		get { return sALES_PAYMENT_HISTORY_ID; }
		set{ sALES_PAYMENT_HISTORY_ID = value; }
	}
	[StringSqlColumn("CURRENCY_ID")]
	public string CURRENCY_ID {
		get { return cURRENCY_ID; }
		set{ cURRENCY_ID = value; }
	}
	[SqlColumn("RATE", SqlDbType.Float)]
	public float RATE {
		get { return rATE; }
		set{ rATE = value; }
	}
	[SqlColumn("MONEYS", SqlDbType.Float)]
	public float MONEYS {
		get { return mONEYS; }
		set{ mONEYS = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Float)]
	public float AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALES_PAYMENT_HISTORY_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALES_PAYMENT_HISTORY_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALES_PAYMENT_HISTORY_DETAIL>("SALES_PAYMENT_HISTORY_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALES_PAYMENT_HISTORY_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALES_PAYMENT_HISTORY_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<SALES_PAYMENT_HISTORY_DETAIL> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY_DETAIL>("SALES_PAYMENT_HISTORY_DETAIL", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inCURRENCY_ID"></param>
	public static List<SALES_PAYMENT_HISTORY_DETAIL> ReadByCURRENCY_ID(string inCURRENCY_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SALES_PAYMENT_HISTORY_DETAIL>("SALES_PAYMENT_HISTORY_DETAIL", rdodb_KTSqlDAC.newInParam("@CURRENCY_ID", inCURRENCY_ID));
	}
	#endregion DAC Methods 
 }
}

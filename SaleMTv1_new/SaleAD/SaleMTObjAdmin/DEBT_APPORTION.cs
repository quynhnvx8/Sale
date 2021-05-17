using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEBT_APPORTION 
{
	#region members
	long id;
	string hOST_ID;
	string sUPPLIER_ID;
	string eMP_ID;
	string sUPPLIER_APPORTION_ID;
	float? aMOUNT_MONEY;
	string cURRENCY_ID;
	float? eXCHANGE_RATE;
	DateTime? cREATE_DATE;
	string cREATE_BY;
	string rEMARK;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.BigInt, 0)]
	public long Id {
		get { return id; }
		set{ id = value; }
	}
	[StringSqlColumn("HOST_ID")]
	public string HOST_ID {
		get { return hOST_ID; }
		set{ hOST_ID = value; }
	}
	[StringSqlColumn("SUPPLIER_ID")]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[StringSqlColumn("EMP_ID")]
	public string EMP_ID {
		get { return eMP_ID; }
		set{ eMP_ID = value; }
	}
	[StringSqlColumn("SUPPLIER_APPORTION_ID")]
	public string SUPPLIER_APPORTION_ID {
		get { return sUPPLIER_APPORTION_ID; }
		set{ sUPPLIER_APPORTION_ID = value; }
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
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[StringSqlColumn("CREATE_BY")]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}

	#endregion Properties
	#region IsNew()
	public bool IsNew() {
		return id == 0; 
	}

	#endregion IsNew()
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEBT_APPORTION() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public DEBT_APPORTION(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEBT_APPORTION> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEBT_APPORTION>("DEBT_APPORTION");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<DEBT_APPORTION>(this, "DEBT_APPORTION");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEBT_APPORTION");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEBT_APPORTION");
	}
	#endregion DAC Methods 
 }
}

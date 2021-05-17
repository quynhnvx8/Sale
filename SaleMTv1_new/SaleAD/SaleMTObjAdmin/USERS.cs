using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class USERS {
	#region members
	string aCCOUNT;
	string pASSWORD;
	DateTime? cREATEDATE;
	string fIRSTNAME;
	string lASTNAME;
	string pHONE;
	string eMAIL;
	string rEMARK;
	int? uSER_GROUP;
	bool? dISCOUNT;
	double dISCOUNT_MONEY;
	double dISCOUNT_PERCENT;
	bool? cHANGE_PRICE;

	#endregion members
	#region Properties
	[PKSqlColumn("ACCOUNT", SqlDbType.NVarChar, null)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("PASSWORD", SqlDbType.NVarChar)]
	public string PASSWORD {
		get { return pASSWORD; }
		set{ pASSWORD = value; }
	}
	[SqlColumn("CREATEDATE", SqlDbType.DateTime)]
	public DateTime? CREATEDATE {
		get { return cREATEDATE; }
		set{ cREATEDATE = value; }
	}
	[SqlColumn("FIRSTNAME", SqlDbType.NVarChar)]
	public string FIRSTNAME {
		get { return fIRSTNAME; }
		set{ fIRSTNAME = value; }
	}
	[SqlColumn("LASTNAME", SqlDbType.NVarChar)]
	public string LASTNAME {
		get { return lASTNAME; }
		set{ lASTNAME = value; }
	}
	[SqlColumn("PHONE", SqlDbType.NVarChar)]
	public string PHONE {
		get { return pHONE; }
		set{ pHONE = value; }
	}
	[SqlColumn("EMAIL", SqlDbType.NVarChar)]
	public string EMAIL {
		get { return eMAIL; }
		set{ eMAIL = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("USER_GROUP", SqlDbType.Int)]
	public int? USER_GROUP {
		get { return uSER_GROUP; }
		set{ uSER_GROUP = value; }
	}
	[SqlColumn("DISCOUNT", SqlDbType.Bit)]
	public bool? DISCOUNT {
		get { return dISCOUNT; }
		set{ dISCOUNT = value; }
	}
	[SqlColumn("DISCOUNT_MONEY", SqlDbType.Float)]
	public double DISCOUNT_MONEY {
		get { return dISCOUNT_MONEY; }
		set{ dISCOUNT_MONEY = value; }
	}
	[SqlColumn("DISCOUNT_PERCENT", SqlDbType.Float)]
	public double DISCOUNT_PERCENT {
		get { return dISCOUNT_PERCENT; }
		set{ dISCOUNT_PERCENT = value; }
	}
	[SqlColumn("CHANGE_PRICE", SqlDbType.Bit)]
	public bool? CHANGE_PRICE {
		get { return cHANGE_PRICE; }
		set{ cHANGE_PRICE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public USERS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<USERS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<USERS>("USERS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save(bool isNew) {
        rdodb_KTSqlDAC.Save(this, "USERS", isNew);
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "USERS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inACCOUNT"></param>
	public static List<USERS> ReadByACCOUNT(string inACCOUNT) {
		return rdodb_KTSqlDAC.ReadByParams<USERS>("USERS", rdodb_KTSqlDAC.newInParam("@ACCOUNT", inACCOUNT));
	}
	#endregion DAC Methods 
 }
}

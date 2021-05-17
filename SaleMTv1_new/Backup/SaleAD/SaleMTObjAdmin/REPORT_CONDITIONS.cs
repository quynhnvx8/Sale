using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class REPORT_CONDITIONS {
	#region members
	Guid aUTO_ID;
	string tITLE;
	string aCCOUNT;
	string rEPORT;
	string aTTRIBUTE;
	string cATEGORY;
	string lIST_COLUMN;
	string lIST_GROUP;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[SqlColumn("TITLE", SqlDbType.NVarChar)]
	public string TITLE {
		get { return tITLE; }
		set{ tITLE = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("REPORT", SqlDbType.NVarChar)]
	public string REPORT {
		get { return rEPORT; }
		set{ rEPORT = value; }
	}
	[SqlColumn("ATTRIBUTE", SqlDbType.NText)]
	public string ATTRIBUTE {
		get { return aTTRIBUTE; }
		set{ aTTRIBUTE = value; }
	}
	[SqlColumn("CATEGORY", SqlDbType.NText)]
	public string CATEGORY {
		get { return cATEGORY; }
		set{ cATEGORY = value; }
	}
	[SqlColumn("LIST_COLUMN", SqlDbType.NText)]
	public string LIST_COLUMN {
		get { return lIST_COLUMN; }
		set{ lIST_COLUMN = value; }
	}
	[SqlColumn("LIST_GROUP", SqlDbType.NText)]
	public string LIST_GROUP {
		get { return lIST_GROUP; }
		set{ lIST_GROUP = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public REPORT_CONDITIONS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<REPORT_CONDITIONS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<REPORT_CONDITIONS>("REPORT_CONDITIONS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "REPORT_CONDITIONS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "REPORT_CONDITIONS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<REPORT_CONDITIONS> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<REPORT_CONDITIONS>("REPORT_CONDITIONS", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class USER_DEPT {
	#region members
	Guid iD;
	string aCCOUNT;
	int? dEPT_CODE;
	string iDROLE;
	string wAREHOUSE_CODE;
	string sEGMENT;
	string pERMISSION_TYPE;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("DEPT_CODE", SqlDbType.Int)]
	public int? DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
	}
	[StringSqlColumn("IDROLE")]
	public string IDROLE {
		get { return iDROLE; }
		set{ iDROLE = value; }
	}
	[StringSqlColumn("WAREHOUSE_CODE")]
	public string WAREHOUSE_CODE {
		get { return wAREHOUSE_CODE; }
		set{ wAREHOUSE_CODE = value; }
	}
	[SqlColumn("SEGMENT", SqlDbType.NVarChar)]
	public string SEGMENT {
		get { return sEGMENT; }
		set{ sEGMENT = value; }
	}
	[StringSqlColumn("PERMISSION_TYPE")]
	public string PERMISSION_TYPE {
		get { return pERMISSION_TYPE; }
		set{ pERMISSION_TYPE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public USER_DEPT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<USER_DEPT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<USER_DEPT>("USER_DEPT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "USER_DEPT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "USER_DEPT");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<USER_DEPT> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<USER_DEPT>("USER_DEPT", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

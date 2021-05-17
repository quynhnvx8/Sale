using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_EMAIL_INFO {
	#region members
	string eMAIL_ADDRESS;
	string pASSWORD;
	string dISPLAY_NAME;

	#endregion members
	#region Properties
	[PKSqlColumn("EMAIL_ADDRESS", SqlDbType.VarChar, null)]
	public string EMAIL_ADDRESS {
		get { return eMAIL_ADDRESS; }
		set{ eMAIL_ADDRESS = value; }
	}
	[StringSqlColumn("PASSWORD")]
	public string PASSWORD {
		get { return pASSWORD; }
		set{ pASSWORD = value; }
	}
	[SqlColumn("DISPLAY_NAME", SqlDbType.NVarChar)]
	public string DISPLAY_NAME {
		get { return dISPLAY_NAME; }
		set{ dISPLAY_NAME = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_EMAIL_INFO() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_EMAIL_INFO> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_EMAIL_INFO>("BK_EMAIL_INFO");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_EMAIL_INFO");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_EMAIL_INFO");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEMAIL_ADDRESS"></param>
	public static List<BK_EMAIL_INFO> ReadByEMAIL_ADDRESS(string inEMAIL_ADDRESS) {
		return rdodb_KTSqlDAC.ReadByParams<BK_EMAIL_INFO>("BK_EMAIL_INFO", rdodb_KTSqlDAC.newInParam("@EMAIL_ADDRESS", inEMAIL_ADDRESS));
	}
	#endregion DAC Methods 
 }
}

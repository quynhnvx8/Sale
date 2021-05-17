using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PERMISSION_CHAT {
	#region members
	string aCCOUNT;
	string fRIENDS;

	#endregion members
	#region Properties
	[PKSqlColumn("ACCOUNT", SqlDbType.NVarChar, null)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[PKSqlColumn("FRIENDS", SqlDbType.NVarChar, null)]
	public string FRIENDS {
		get { return fRIENDS; }
		set{ fRIENDS = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PERMISSION_CHAT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PERMISSION_CHAT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PERMISSION_CHAT>("PERMISSION_CHAT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PERMISSION_CHAT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PERMISSION_CHAT");
	}
	#endregion DAC Methods 
 }
}

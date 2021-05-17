using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class MEMBERS {
	#region members
	string aCCOUNT;
	string iDROLE;

	#endregion members
	#region Properties
	[PKSqlColumn("ACCOUNT", SqlDbType.NVarChar, null)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[PKSqlColumn("IDROLE", SqlDbType.VarChar, null)]
	public string IDROLE {
		get { return iDROLE; }
		set{ iDROLE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public MEMBERS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<MEMBERS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<MEMBERS>("MEMBERS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "MEMBERS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "MEMBERS");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inACCOUNT"></param>
	public static List<MEMBERS> ReadByACCOUNT(string inACCOUNT) {
		return rdodb_KTSqlDAC.ReadByParams<MEMBERS>("MEMBERS", rdodb_KTSqlDAC.newInParam("@ACCOUNT", inACCOUNT));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inIDROLE"></param>
	public static List<MEMBERS> ReadByIDROLE(string inIDROLE) {
		return rdodb_KTSqlDAC.ReadByParams<MEMBERS>("MEMBERS", rdodb_KTSqlDAC.newInParam("@IDROLE", inIDROLE));
	}
	#endregion DAC Methods 
 }
}

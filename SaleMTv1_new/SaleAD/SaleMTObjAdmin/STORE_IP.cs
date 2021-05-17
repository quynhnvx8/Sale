using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class STORE_IP {
	#region members
	string sTORE_CODE;
	string iPADDRESS;
	string tEAMVIEWER_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("STORE_CODE", SqlDbType.VarChar, null)]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[StringSqlColumn("IPADDRESS")]
	public string IPADDRESS {
		get { return iPADDRESS; }
		set{ iPADDRESS = value; }
	}
	[StringSqlColumn("TEAMVIEWER_ID")]
	public string TEAMVIEWER_ID {
		get { return tEAMVIEWER_ID; }
		set{ tEAMVIEWER_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public STORE_IP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<STORE_IP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<STORE_IP>("STORE_IP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "STORE_IP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "STORE_IP");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inSTORE_CODE"></param>
	public static List<STORE_IP> ReadBySTORE_CODE(string inSTORE_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<STORE_IP>("STORE_IP", rdodb_KTSqlDAC.newInParam("@STORE_CODE", inSTORE_CODE));
	}
	#endregion DAC Methods 
 }
}

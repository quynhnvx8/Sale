using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class REPORT_PERMISSIONS {
	#region members
	Guid aUTO_ID;
	string rEPORT_ID;
	string aCCOUNT;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[StringSqlColumn("REPORT_ID")]
	public string REPORT_ID {
		get { return rEPORT_ID; }
		set{ rEPORT_ID = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public REPORT_PERMISSIONS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<REPORT_PERMISSIONS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<REPORT_PERMISSIONS>("REPORT_PERMISSIONS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "REPORT_PERMISSIONS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "REPORT_PERMISSIONS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<REPORT_PERMISSIONS> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<REPORT_PERMISSIONS>("REPORT_PERMISSIONS", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

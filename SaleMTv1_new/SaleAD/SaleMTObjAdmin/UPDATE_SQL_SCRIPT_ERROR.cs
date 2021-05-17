using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class UPDATE_SQL_SCRIPT_ERROR {
	#region members
	Guid aUTO_ID;
	string sTORE_CODE;
	string eRROR_TEXT;
	DateTime? dATE_EFFECT;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[SqlColumn("ERROR_TEXT", SqlDbType.NVarChar)]
	public string ERROR_TEXT {
		get { return eRROR_TEXT; }
		set{ eRROR_TEXT = value; }
	}
	[SqlColumn("DATE_EFFECT", SqlDbType.DateTime)]
	public DateTime? DATE_EFFECT {
		get { return dATE_EFFECT; }
		set{ dATE_EFFECT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public UPDATE_SQL_SCRIPT_ERROR() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<UPDATE_SQL_SCRIPT_ERROR> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<UPDATE_SQL_SCRIPT_ERROR>("UPDATE_SQL_SCRIPT_ERROR");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "UPDATE_SQL_SCRIPT_ERROR");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "UPDATE_SQL_SCRIPT_ERROR");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<UPDATE_SQL_SCRIPT_ERROR> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<UPDATE_SQL_SCRIPT_ERROR>("UPDATE_SQL_SCRIPT_ERROR", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

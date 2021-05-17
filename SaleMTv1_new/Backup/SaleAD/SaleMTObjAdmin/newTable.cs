using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class newTable {
	#region members
	string mASTER_CODE1;
	string mASTER_NAME1;

	#endregion members
	#region Properties
	[StringSqlColumn("MASTER_CODE1")]
	public string MASTER_CODE1 {
		get { return mASTER_CODE1; }
		set{ mASTER_CODE1 = value; }
	}
	[SqlColumn("MASTER_NAME1", SqlDbType.NVarChar)]
	public string MASTER_NAME1 {
		get { return mASTER_NAME1; }
		set{ mASTER_NAME1 = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public newTable() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<newTable> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<newTable>("newTable");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "newTable");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "newTable");
	}
	#endregion DAC Methods 
 }
}

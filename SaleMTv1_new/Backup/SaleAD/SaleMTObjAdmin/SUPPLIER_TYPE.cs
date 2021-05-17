using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SUPPLIER_TYPE {
	#region members
	Guid iD;
	string sUPPLIER_ID;
	string cOMPANY_TYPE;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("SUPPLIER_ID", SqlDbType.NVarChar)]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[SqlColumn("COMPANY_TYPE", SqlDbType.NVarChar)]
	public string COMPANY_TYPE {
		get { return cOMPANY_TYPE; }
		set{ cOMPANY_TYPE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SUPPLIER_TYPE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SUPPLIER_TYPE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SUPPLIER_TYPE>("SUPPLIER_TYPE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SUPPLIER_TYPE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SUPPLIER_TYPE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<SUPPLIER_TYPE> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<SUPPLIER_TYPE>("SUPPLIER_TYPE", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ORDER_PRODUCTS_HISTORY_PROPOS {
	#region members
	Guid iD;
	string oRDER_PRODUCTS_PRO_ID;
	DateTime? oRDER_HISTORY_DATE;
	DateTime? iNPUT_DATE;
	string oRDER_RESOLVE_TYPE;
	string oRDER_RESOLVE_REMARKS;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("ORDER_PRODUCTS_PRO_ID", SqlDbType.NVarChar)]
	public string ORDER_PRODUCTS_PRO_ID {
		get { return oRDER_PRODUCTS_PRO_ID; }
		set{ oRDER_PRODUCTS_PRO_ID = value; }
	}
	[SqlColumn("ORDER_HISTORY_DATE", SqlDbType.DateTime)]
	public DateTime? ORDER_HISTORY_DATE {
		get { return oRDER_HISTORY_DATE; }
		set{ oRDER_HISTORY_DATE = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime? INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("ORDER_RESOLVE_TYPE", SqlDbType.NVarChar)]
	public string ORDER_RESOLVE_TYPE {
		get { return oRDER_RESOLVE_TYPE; }
		set{ oRDER_RESOLVE_TYPE = value; }
	}
	[SqlColumn("ORDER_RESOLVE_REMARKS", SqlDbType.NVarChar)]
	public string ORDER_RESOLVE_REMARKS {
		get { return oRDER_RESOLVE_REMARKS; }
		set{ oRDER_RESOLVE_REMARKS = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ORDER_PRODUCTS_HISTORY_PROPOS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ORDER_PRODUCTS_HISTORY_PROPOS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ORDER_PRODUCTS_HISTORY_PROPOS>("ORDER_PRODUCTS_HISTORY_PROPOS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ORDER_PRODUCTS_HISTORY_PROPOS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ORDER_PRODUCTS_HISTORY_PROPOS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<ORDER_PRODUCTS_HISTORY_PROPOS> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<ORDER_PRODUCTS_HISTORY_PROPOS>("ORDER_PRODUCTS_HISTORY_PROPOS", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inORDER_PRODUCTS_PRO_ID"></param>
	public static List<ORDER_PRODUCTS_HISTORY_PROPOS> ReadByORDER_PRODUCTS_PRO_ID(string inORDER_PRODUCTS_PRO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<ORDER_PRODUCTS_HISTORY_PROPOS>("ORDER_PRODUCTS_HISTORY_PROPOS", rdodb_KTSqlDAC.newInParam("@ORDER_PRODUCTS_PRO_ID", inORDER_PRODUCTS_PRO_ID));
	}
	#endregion DAC Methods 
 }
}

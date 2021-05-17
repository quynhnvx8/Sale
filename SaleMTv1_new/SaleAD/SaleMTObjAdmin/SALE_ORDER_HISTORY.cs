using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALE_ORDER_HISTORY {
	#region members
	Guid sALE_ORDERS_HISTORY_CODE;
	Guid sALE_ORDER_CODE;
	string rESOLVE_TYPE;
	string rESOLVE_REMARKS;
	DateTime iNPUT_DATE;
	DateTime rESOLVE_TYPE_DATE;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("SALE_ORDERS_HISTORY_CODE", SqlDbType.UniqueIdentifier, null)]
	public Guid SALE_ORDERS_HISTORY_CODE {
		get { return sALE_ORDERS_HISTORY_CODE; }
		set{ sALE_ORDERS_HISTORY_CODE = value; }
	}
	[SqlColumn("SALE_ORDER_CODE", SqlDbType.UniqueIdentifier)]
	public Guid SALE_ORDER_CODE {
		get { return sALE_ORDER_CODE; }
		set{ sALE_ORDER_CODE = value; }
	}
	[SqlColumn("RESOLVE_TYPE", SqlDbType.NVarChar)]
	public string RESOLVE_TYPE {
		get { return rESOLVE_TYPE; }
		set{ rESOLVE_TYPE = value; }
	}
	[SqlColumn("RESOLVE_REMARKS", SqlDbType.NVarChar)]
	public string RESOLVE_REMARKS {
		get { return rESOLVE_REMARKS; }
		set{ rESOLVE_REMARKS = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("RESOLVE_TYPE_DATE", SqlDbType.DateTime)]
	public DateTime RESOLVE_TYPE_DATE {
		get { return rESOLVE_TYPE_DATE; }
		set{ rESOLVE_TYPE_DATE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SALE_ORDER_HISTORY() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALE_ORDER_HISTORY> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALE_ORDER_HISTORY>("SALE_ORDER_HISTORY");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALE_ORDER_HISTORY");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALE_ORDER_HISTORY");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inSALE_ORDERS_HISTORY_CODE"></param>
	public static List<SALE_ORDER_HISTORY> ReadBySALE_ORDERS_HISTORY_CODE(Guid inSALE_ORDERS_HISTORY_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<SALE_ORDER_HISTORY>("SALE_ORDER_HISTORY", rdodb_KTSqlDAC.newInParam("@SALE_ORDERS_HISTORY_CODE", inSALE_ORDERS_HISTORY_CODE));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALE_ORDERS_PARENT {
	#region members
	string sALE_ORDERS_PARENT_CODE;
	DateTime requestedOn;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("SALE_ORDERS_PARENT_CODE", SqlDbType.NVarChar, null)]
	public string SALE_ORDERS_PARENT_CODE {
		get { return sALE_ORDERS_PARENT_CODE; }
		set{ sALE_ORDERS_PARENT_CODE = value; }
	}
	[SqlColumn("RequestedOn", SqlDbType.DateTime)]
	public DateTime RequestedOn {
		get { return requestedOn; }
		set{ requestedOn = value; }
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
	public SALE_ORDERS_PARENT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALE_ORDERS_PARENT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALE_ORDERS_PARENT>("SALE_ORDERS_PARENT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALE_ORDERS_PARENT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALE_ORDERS_PARENT");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inSALE_ORDERS_PARENT_CODE"></param>
	public static List<SALE_ORDERS_PARENT> ReadBySALE_ORDERS_PARENT_CODE(string inSALE_ORDERS_PARENT_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<SALE_ORDERS_PARENT>("SALE_ORDERS_PARENT", rdodb_KTSqlDAC.newInParam("@SALE_ORDERS_PARENT_CODE", inSALE_ORDERS_PARENT_CODE));
	}
	#endregion DAC Methods 
 }
}

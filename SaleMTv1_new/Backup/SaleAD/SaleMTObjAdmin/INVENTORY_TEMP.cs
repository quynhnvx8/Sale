using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class INVENTORY_TEMP {
	#region members
	Guid iNVENTORY_ID;
	DateTime? cREATED_DATE;
	string pRODUCT_ID;
	string p_ID;
	int? aMOUNT;
	int? tYPE_CODE;
	string sTORE_CODE;
	string zONE_CODE;
	string gENERATE_CODE;
	string eVENT_ID;
	string wAREHOUSE;

	#endregion members
	#region Properties
	[PKSqlColumn("INVENTORY_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid INVENTORY_ID {
		get { return iNVENTORY_ID; }
		set{ iNVENTORY_ID = value; }
	}
	[SqlColumn("CREATED_DATE", SqlDbType.DateTime)]
	public DateTime? CREATED_DATE {
		get { return cREATED_DATE; }
		set{ cREATED_DATE = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[StringSqlColumn("P_ID")]
	public string P_ID {
		get { return p_ID; }
		set{ p_ID = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Int)]
	public int? AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}
	[SqlColumn("TYPE_CODE", SqlDbType.Int)]
	public int? TYPE_CODE {
		get { return tYPE_CODE; }
		set{ tYPE_CODE = value; }
	}
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[StringSqlColumn("ZONE_CODE")]
	public string ZONE_CODE {
		get { return zONE_CODE; }
		set{ zONE_CODE = value; }
	}
	[StringSqlColumn("GENERATE_CODE")]
	public string GENERATE_CODE {
		get { return gENERATE_CODE; }
		set{ gENERATE_CODE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[StringSqlColumn("WAREHOUSE")]
	public string WAREHOUSE {
		get { return wAREHOUSE; }
		set{ wAREHOUSE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public INVENTORY_TEMP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<INVENTORY_TEMP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<INVENTORY_TEMP>("INVENTORY_TEMP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "INVENTORY_TEMP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "INVENTORY_TEMP");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inINVENTORY_ID"></param>
	public static List<INVENTORY_TEMP> ReadByINVENTORY_ID(Guid inINVENTORY_ID) {
		return rdodb_KTSqlDAC.ReadByParams<INVENTORY_TEMP>("INVENTORY_TEMP", rdodb_KTSqlDAC.newInParam("@INVENTORY_ID", inINVENTORY_ID));
	}
	#endregion DAC Methods 
 }
}

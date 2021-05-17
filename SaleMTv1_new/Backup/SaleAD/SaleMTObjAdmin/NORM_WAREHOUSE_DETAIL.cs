using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class NORM_WAREHOUSE_DETAIL {
	#region members
	Guid aUTO_ID;
	string wAREHOUSE_CODE;
	string pRODUCT_ID;
	float? qUANTITY;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[StringSqlColumn("WAREHOUSE_CODE")]
	public string WAREHOUSE_CODE {
		get { return wAREHOUSE_CODE; }
		set{ wAREHOUSE_CODE = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Float)]
	public float? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public NORM_WAREHOUSE_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<NORM_WAREHOUSE_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<NORM_WAREHOUSE_DETAIL>("NORM_WAREHOUSE_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "NORM_WAREHOUSE_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "NORM_WAREHOUSE_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<NORM_WAREHOUSE_DETAIL> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<NORM_WAREHOUSE_DETAIL>("NORM_WAREHOUSE_DETAIL", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}

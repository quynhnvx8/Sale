using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PROMOTION_GIFTS {
	#region members
	string pROGRAM_NO;
	string pRODUCT_ID;
	int? qUANTITY;
	int? fOR_TYPE;

	#endregion members
	#region Properties
	[PKSqlColumn("PROGRAM_NO", SqlDbType.VarChar, null)]
	public string PROGRAM_NO {
		get { return pROGRAM_NO; }
		set{ pROGRAM_NO = value; }
	}
	[PKSqlColumn("PRODUCT_ID", SqlDbType.VarChar, null)]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("FOR_TYPE", SqlDbType.Int)]
	public int? FOR_TYPE {
		get { return fOR_TYPE; }
		set{ fOR_TYPE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PROMOTION_GIFTS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PROMOTION_GIFTS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PROMOTION_GIFTS>("PROMOTION_GIFTS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PROMOTION_GIFTS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PROMOTION_GIFTS");
	}
	#endregion DAC Methods 
 }
}

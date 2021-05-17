using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PROGRAM_PRODUCT {
	#region members
	string pROGRAM_NO;
	string pRODUCT_ID;
	int? fOR_TYPE;
	int? qUANTITY;

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
	[SqlColumn("FOR_TYPE", SqlDbType.Int)]
	public int? FOR_TYPE {
		get { return fOR_TYPE; }
		set{ fOR_TYPE = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Int)]
	public int? QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PROGRAM_PRODUCT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PROGRAM_PRODUCT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PROGRAM_PRODUCT>("PROGRAM_PRODUCT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PROGRAM_PRODUCT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PROGRAM_PRODUCT");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inPRODUCT_ID"></param>
	public static List<PROGRAM_PRODUCT> ReadByPRODUCT_ID(string inPRODUCT_ID) {
		return rdodb_KTSqlDAC.ReadByParams<PROGRAM_PRODUCT>("PROGRAM_PRODUCT", rdodb_KTSqlDAC.newInParam("@PRODUCT_ID", inPRODUCT_ID));
	}
	#endregion DAC Methods 
 }
}

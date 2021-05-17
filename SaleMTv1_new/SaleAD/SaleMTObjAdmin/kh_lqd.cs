using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_lqd {
	#region members
	string macu;
	string tenkh;
	string diachi;
	string cUSTOMER_ID;
	string cOL_SEARCH;
	string eVENT_ID;
	string mA_CU;

	#endregion members
	#region Properties
	[SqlColumn("macu", SqlDbType.NVarChar)]
	public string Macu {
		get { return macu; }
		set{ macu = value; }
	}
	[SqlColumn("tenkh", SqlDbType.NVarChar)]
	public string Tenkh {
		get { return tenkh; }
		set{ tenkh = value; }
	}
	[SqlColumn("diachi", SqlDbType.NVarChar)]
	public string Diachi {
		get { return diachi; }
		set{ diachi = value; }
	}
	[StringSqlColumn("CUSTOMER_ID")]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("COL_SEARCH", SqlDbType.NVarChar)]
	public string COL_SEARCH {
		get { return cOL_SEARCH; }
		set{ cOL_SEARCH = value; }
	}
	[StringSqlColumn("EVENT_ID")]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[StringSqlColumn("MA_CU")]
	public string MA_CU {
		get { return mA_CU; }
		set{ mA_CU = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public kh_lqd() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_lqd> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_lqd>("kh_lqd");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_lqd");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_lqd");
	}
	#endregion DAC Methods 
 }
}

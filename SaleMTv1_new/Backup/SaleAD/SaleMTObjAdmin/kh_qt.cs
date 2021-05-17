using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_qt {
	#region members
	string mA_CU;
	string tEN_KH;
	string dIA_CHI;
	string pHONE;
	string cUSTOMER_ID;
	string cOL_SEARCH;
	string eVENT_ID;
	string n_MA_CU;

	#endregion members
	#region Properties
	[SqlColumn("MA_CU", SqlDbType.NVarChar)]
	public string MA_CU {
		get { return mA_CU; }
		set{ mA_CU = value; }
	}
	[SqlColumn("TEN_KH", SqlDbType.NVarChar)]
	public string TEN_KH {
		get { return tEN_KH; }
		set{ tEN_KH = value; }
	}
	[SqlColumn("DIA_CHI", SqlDbType.NVarChar)]
	public string DIA_CHI {
		get { return dIA_CHI; }
		set{ dIA_CHI = value; }
	}
	[SqlColumn("PHONE", SqlDbType.NVarChar)]
	public string PHONE {
		get { return pHONE; }
		set{ pHONE = value; }
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
	[StringSqlColumn("N_MA_CU")]
	public string N_MA_CU {
		get { return n_MA_CU; }
		set{ n_MA_CU = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public kh_qt() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_qt> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_qt>("kh_qt");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_qt");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_qt");
	}
	#endregion DAC Methods 
 }
}

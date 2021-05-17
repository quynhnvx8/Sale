using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_nct {
	#region members
	string mACU;
	string tENKHACHHANG;
	string gIOITINH;
	DateTime? nGAYSINH;
	string cMND;
	DateTime? nGAYCAP;
	string nOICAP;
	string dIACHI;
	string qUAN;
	string tINH;
	string mATINH;
	string cUSTOMER_ID;
	string cOL_SEARCH;
	string eVENT_ID;
	string mA_CU;

	#endregion members
	#region Properties
	[PKSqlColumn("MACU", SqlDbType.NVarChar, null)]
	public string MACU {
		get { return mACU; }
		set{ mACU = value; }
	}
	[SqlColumn("TENKHACHHANG", SqlDbType.NVarChar)]
	public string TENKHACHHANG {
		get { return tENKHACHHANG; }
		set{ tENKHACHHANG = value; }
	}
	[StringSqlColumn("GIOITINH")]
	public string GIOITINH {
		get { return gIOITINH; }
		set{ gIOITINH = value; }
	}
	[SqlColumn("NGAYSINH", SqlDbType.DateTime)]
	public DateTime? NGAYSINH {
		get { return nGAYSINH; }
		set{ nGAYSINH = value; }
	}
	[StringSqlColumn("CMND")]
	public string CMND {
		get { return cMND; }
		set{ cMND = value; }
	}
	[SqlColumn("NGAYCAP", SqlDbType.DateTime)]
	public DateTime? NGAYCAP {
		get { return nGAYCAP; }
		set{ nGAYCAP = value; }
	}
	[SqlColumn("NOICAP", SqlDbType.NVarChar)]
	public string NOICAP {
		get { return nOICAP; }
		set{ nOICAP = value; }
	}
	[SqlColumn("DIACHI", SqlDbType.NVarChar)]
	public string DIACHI {
		get { return dIACHI; }
		set{ dIACHI = value; }
	}
	[SqlColumn("QUAN", SqlDbType.NVarChar)]
	public string QUAN {
		get { return qUAN; }
		set{ qUAN = value; }
	}
	[SqlColumn("TINH", SqlDbType.NVarChar)]
	public string TINH {
		get { return tINH; }
		set{ tINH = value; }
	}
	[SqlColumn("MATINH", SqlDbType.NVarChar)]
	public string MATINH {
		get { return mATINH; }
		set{ mATINH = value; }
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
	public kh_nct() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_nct> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_nct>("kh_nct");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_nct");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_nct");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inMACU"></param>
	public static List<kh_nct> ReadByMACU(string inMACU) {
		return rdodb_KTSqlDAC.ReadByParams<kh_nct>("kh_nct", rdodb_KTSqlDAC.newInParam("@MACU", inMACU));
	}
	#endregion DAC Methods 
 }
}

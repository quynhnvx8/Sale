using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_ndc {
	#region members
	string ma_KH;
	string ten_KH;
	string dia_Chi;
	string thanh_Pho;
	string dien_Thoai;
	string ngay_Tao;
	string mSThue;
	string cUSTOMER_ID;
	string cOL_SEARCH;
	string eVENT_ID;
	string mA_CU;

	#endregion members
	#region Properties
	[SqlColumn("Ma_KH", SqlDbType.NVarChar)]
	public string Ma_KH {
		get { return ma_KH; }
		set{ ma_KH = value; }
	}
	[SqlColumn("Ten_KH", SqlDbType.NVarChar)]
	public string Ten_KH {
		get { return ten_KH; }
		set{ ten_KH = value; }
	}
	[SqlColumn("Dia_Chi", SqlDbType.NVarChar)]
	public string Dia_Chi {
		get { return dia_Chi; }
		set{ dia_Chi = value; }
	}
	[SqlColumn("Thanh_Pho", SqlDbType.NVarChar)]
	public string Thanh_Pho {
		get { return thanh_Pho; }
		set{ thanh_Pho = value; }
	}
	[SqlColumn("Dien_Thoai", SqlDbType.NVarChar)]
	public string Dien_Thoai {
		get { return dien_Thoai; }
		set{ dien_Thoai = value; }
	}
	[SqlColumn("Ngay_Tao", SqlDbType.NVarChar)]
	public string Ngay_Tao {
		get { return ngay_Tao; }
		set{ ngay_Tao = value; }
	}
	[SqlColumn("MSThue", SqlDbType.NVarChar)]
	public string MSThue {
		get { return mSThue; }
		set{ mSThue = value; }
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
	public kh_ndc() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_ndc> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_ndc>("kh_ndc");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_ndc");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_ndc");
	}
	#endregion DAC Methods 
 }
}

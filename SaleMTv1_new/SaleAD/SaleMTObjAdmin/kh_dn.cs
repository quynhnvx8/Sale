using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_dn {
	#region members
	string sTT;
	string ma_cu;
	string ten;
	string mobile;
	string address;
	string first_name;
	string last_name;
	string customer_id;
	string col_search;
	string event_id;
	string n_ma_cu;

	#endregion members
	#region Properties
	[SqlColumn("STT", SqlDbType.NVarChar)]
	public string STT {
		get { return sTT; }
		set{ sTT = value; }
	}
	[SqlColumn("ma_cu", SqlDbType.NVarChar)]
	public string Ma_cu {
		get { return ma_cu; }
		set{ ma_cu = value; }
	}
	[SqlColumn("ten", SqlDbType.NVarChar)]
	public string Ten {
		get { return ten; }
		set{ ten = value; }
	}
	[SqlColumn("mobile", SqlDbType.NVarChar)]
	public string Mobile {
		get { return mobile; }
		set{ mobile = value; }
	}
	[SqlColumn("address", SqlDbType.NVarChar)]
	public string Address {
		get { return address; }
		set{ address = value; }
	}
	[SqlColumn("first_name", SqlDbType.NVarChar)]
	public string First_name {
		get { return first_name; }
		set{ first_name = value; }
	}
	[SqlColumn("last_name", SqlDbType.NVarChar)]
	public string Last_name {
		get { return last_name; }
		set{ last_name = value; }
	}
	[StringSqlColumn("customer_id")]
	public string Customer_id {
		get { return customer_id; }
		set{ customer_id = value; }
	}
	[SqlColumn("col_search", SqlDbType.NVarChar)]
	public string Col_search {
		get { return col_search; }
		set{ col_search = value; }
	}
	[StringSqlColumn("event_id")]
	public string Event_id {
		get { return event_id; }
		set{ event_id = value; }
	}
	[StringSqlColumn("n_ma_cu")]
	public string N_ma_cu {
		get { return n_ma_cu; }
		set{ n_ma_cu = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public kh_dn() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_dn> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_dn>("kh_dn");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_dn");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_dn");
	}
	#endregion DAC Methods 
 }
}

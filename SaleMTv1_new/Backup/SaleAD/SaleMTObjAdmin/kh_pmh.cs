using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class kh_pmh {
	#region members
	string macu;
	string tenkh;
	string sodt;
	string diachi;
	string customer_id;
	string col_search;
	string event_id;
	string ma_cu;

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
	[SqlColumn("sodt", SqlDbType.NVarChar)]
	public string Sodt {
		get { return sodt; }
		set{ sodt = value; }
	}
	[SqlColumn("diachi", SqlDbType.NVarChar)]
	public string Diachi {
		get { return diachi; }
		set{ diachi = value; }
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
	[StringSqlColumn("ma_cu")]
	public string Ma_cu {
		get { return ma_cu; }
		set{ ma_cu = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public kh_pmh() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<kh_pmh> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<kh_pmh>("kh_pmh");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "kh_pmh");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "kh_pmh");
	}
	#endregion DAC Methods 
 }
}

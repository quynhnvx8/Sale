using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DM_LOOKUP {
	#region members
	string maLook;
	string tenLook;
	string maDoiTuong;
	string tenDoiTuong;
	string ghiChu;
	string active;

	#endregion members
	#region Properties
	[SqlColumn("MaLook", SqlDbType.NVarChar)]
	public string MaLook {
		get { return maLook; }
		set{ maLook = value; }
	}
	[SqlColumn("TenLook", SqlDbType.NVarChar)]
	public string TenLook {
		get { return tenLook; }
		set{ tenLook = value; }
	}
	[SqlColumn("MaDoiTuong", SqlDbType.NVarChar)]
	public string MaDoiTuong {
		get { return maDoiTuong; }
		set{ maDoiTuong = value; }
	}
	[SqlColumn("TenDoiTuong", SqlDbType.NVarChar)]
	public string TenDoiTuong {
		get { return tenDoiTuong; }
		set{ tenDoiTuong = value; }
	}
	[SqlColumn("GhiChu", SqlDbType.NVarChar)]
	public string GhiChu {
		get { return ghiChu; }
		set{ ghiChu = value; }
	}
	[SqlColumn("Active", SqlDbType.Char)]
	public string Active {
		get { return active; }
		set{ active = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DM_LOOKUP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DM_LOOKUP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DM_LOOKUP>("DM_LOOKUP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DM_LOOKUP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DM_LOOKUP");
	}
	#endregion DAC Methods 
 }
}

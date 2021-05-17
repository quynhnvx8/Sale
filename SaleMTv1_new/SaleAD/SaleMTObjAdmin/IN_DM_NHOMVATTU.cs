using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IN_DM_NHOMVATTU : IDataModel {
	#region members
	int id;
	string maNhom;
	string tenNhom;
	string ghiChu;
	string active;

	#endregion members
	#region Properties
	[PKSqlColumn("NhomVT_ID", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[SqlColumn("MaNhom", SqlDbType.NVarChar)]
	public string MaNhom {
		get { return maNhom; }
		set{ maNhom = value; }
	}
	[SqlColumn("TenNhom", SqlDbType.NVarChar)]
	public string TenNhom {
		get { return tenNhom; }
		set{ tenNhom = value; }
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
	#region IsNew()
	public bool IsNew() {
		return id == 0; 
	}

	#endregion IsNew()
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public IN_DM_NHOMVATTU() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public IN_DM_NHOMVATTU(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IN_DM_NHOMVATTU> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IN_DM_NHOMVATTU>("IN_DM_NHOMVATTU");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<IN_DM_NHOMVATTU>(this, "IN_DM_NHOMVATTU");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IN_DM_NHOMVATTU");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IN_DM_NHOMVATTU");
	}
	#endregion DAC Methods 
 }
}

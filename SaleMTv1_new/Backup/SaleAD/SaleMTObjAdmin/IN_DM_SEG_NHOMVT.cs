using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IN_DM_SEG_NHOMVT : IDataModel {
	#region members
	int id;
	string maSegCha;
	string maSeg;
	string tenSeg;
	string moTa;
	string active;

	#endregion members
	#region Properties
	[PKSqlColumn("Id", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[SqlColumn("MaSegCha", SqlDbType.NVarChar)]
	public string MaSegCha {
		get { return maSegCha; }
		set{ maSegCha = value; }
	}
	[SqlColumn("MaSeg", SqlDbType.NVarChar)]
	public string MaSeg {
		get { return maSeg; }
		set{ maSeg = value; }
	}
	[SqlColumn("TenSeg", SqlDbType.NVarChar)]
	public string TenSeg {
		get { return tenSeg; }
		set{ tenSeg = value; }
	}
	[SqlColumn("MoTa", SqlDbType.NVarChar)]
	public string MoTa {
		get { return moTa; }
		set{ moTa = value; }
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
	public IN_DM_SEG_NHOMVT() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public IN_DM_SEG_NHOMVT(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IN_DM_SEG_NHOMVT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IN_DM_SEG_NHOMVT>("IN_DM_SEG_NHOMVT");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<IN_DM_SEG_NHOMVT>(this, "IN_DM_SEG_NHOMVT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IN_DM_SEG_NHOMVT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IN_DM_SEG_NHOMVT");
	}
	#endregion DAC Methods 
 }
}

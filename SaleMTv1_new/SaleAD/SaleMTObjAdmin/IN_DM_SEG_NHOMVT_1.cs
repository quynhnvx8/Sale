using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IN_DM_SEG_NHOMVT_1 : IDataModel {
	#region members
	string maSegCha;
	string maSeg;
	string tenSeg;
	string moTa;
	string active;
	int id;

	#endregion members
	#region Properties
	[StringSqlColumn("MaSegCha")]
	public string MaSegCha {
		get { return maSegCha; }
		set{ maSegCha = value; }
	}
	[StringSqlColumn("MaSeg")]
	public string MaSeg {
		get { return maSeg; }
		set{ maSeg = value; }
	}
	[StringSqlColumn("TenSeg")]
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
	[PKSqlColumn("Id", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
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
	public IN_DM_SEG_NHOMVT_1() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public IN_DM_SEG_NHOMVT_1(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IN_DM_SEG_NHOMVT_1> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IN_DM_SEG_NHOMVT_1>("IN_DM_SEG_NHOMVT_1");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<IN_DM_SEG_NHOMVT_1>(this, "IN_DM_SEG_NHOMVT_1");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IN_DM_SEG_NHOMVT_1");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IN_DM_SEG_NHOMVT_1");
	}
	#endregion DAC Methods 
 }
}

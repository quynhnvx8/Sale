using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DEV_IN_SEG_NHOMVT_PHUTHUOC {
	#region members
	string tenSeg;
	int chieuDai;
	string segPhuThuoc;
	bool isDeleted;
	string moTa;

	#endregion members
	#region Properties
	[PKSqlColumn("TenSeg", SqlDbType.VarChar, null)]
	public string TenSeg {
		get { return tenSeg; }
		set{ tenSeg = value; }
	}
	[SqlColumn("ChieuDai", SqlDbType.Int)]
	public int ChieuDai {
		get { return chieuDai; }
		set{ chieuDai = value; }
	}
	[SqlColumn("SegPhuThuoc", SqlDbType.Char)]
	public string SegPhuThuoc {
		get { return segPhuThuoc; }
		set{ segPhuThuoc = value; }
	}
	[SqlColumn("IsDeleted", SqlDbType.Bit)]
	public bool IsDeleted {
		get { return isDeleted; }
		set{ isDeleted = value; }
	}
	[SqlColumn("MoTa", SqlDbType.NVarChar)]
	public string MoTa {
		get { return moTa; }
		set{ moTa = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DEV_IN_SEG_NHOMVT_PHUTHUOC() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DEV_IN_SEG_NHOMVT_PHUTHUOC> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DEV_IN_SEG_NHOMVT_PHUTHUOC>("DEV_IN_SEG_NHOMVT_PHUTHUOC");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DEV_IN_SEG_NHOMVT_PHUTHUOC");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DEV_IN_SEG_NHOMVT_PHUTHUOC");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inTenSeg"></param>
	public static List<DEV_IN_SEG_NHOMVT_PHUTHUOC> ReadByTenSeg(string inTenSeg) {
		return rdodb_KTSqlDAC.ReadByParams<DEV_IN_SEG_NHOMVT_PHUTHUOC>("DEV_IN_SEG_NHOMVT_PHUTHUOC", rdodb_KTSqlDAC.newInParam("@TenSeg", inTenSeg));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class IN_SEG_NHOMVT_PHUTHUOC_1 {
	#region members
	string tenSeg;
	int chieuDai;
	string segPhuThuoc;
	bool isDeleted;

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

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public IN_SEG_NHOMVT_PHUTHUOC_1() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<IN_SEG_NHOMVT_PHUTHUOC_1> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<IN_SEG_NHOMVT_PHUTHUOC_1>("IN_SEG_NHOMVT_PHUTHUOC_1");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "IN_SEG_NHOMVT_PHUTHUOC_1");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "IN_SEG_NHOMVT_PHUTHUOC_1");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inTenSeg"></param>
	public static List<IN_SEG_NHOMVT_PHUTHUOC_1> ReadByTenSeg(string inTenSeg) {
		return rdodb_KTSqlDAC.ReadByParams<IN_SEG_NHOMVT_PHUTHUOC_1>("IN_SEG_NHOMVT_PHUTHUOC_1", rdodb_KTSqlDAC.newInParam("@TenSeg", inTenSeg));
	}
	#endregion DAC Methods 
 }
}

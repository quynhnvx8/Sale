using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class POS_CHILINHTINH {
	#region members
	byte[] auto_ID;
	string maDonVi;
	string maBoPhan;
	string soGiaoDich;
	int? sTT;
	string soKhoanMuc;
	string dienGiai;
	decimal? soTien;
	string post;
	DateTime? ngay;
	float? tyGia;
	string loaiTien;
	string phanLoai;
	string taiKhoanNH;

	#endregion members
	#region Properties
	[PKSqlColumn("Auto_ID", SqlDbType.Timestamp, null)]
	public byte[] Auto_ID {
		get { return auto_ID; }
		set{ auto_ID = value; }
	}
	[SqlColumn("MaDonVi", SqlDbType.NVarChar)]
	public string MaDonVi {
		get { return maDonVi; }
		set{ maDonVi = value; }
	}
	[SqlColumn("MaBoPhan", SqlDbType.NVarChar)]
	public string MaBoPhan {
		get { return maBoPhan; }
		set{ maBoPhan = value; }
	}
	[SqlColumn("SoGiaoDich", SqlDbType.NVarChar)]
	public string SoGiaoDich {
		get { return soGiaoDich; }
		set{ soGiaoDich = value; }
	}
	[SqlColumn("STT", SqlDbType.Int)]
	public int? STT {
		get { return sTT; }
		set{ sTT = value; }
	}
	[SqlColumn("SoKhoanMuc", SqlDbType.NVarChar)]
	public string SoKhoanMuc {
		get { return soKhoanMuc; }
		set{ soKhoanMuc = value; }
	}
	[SqlColumn("DienGiai", SqlDbType.NVarChar)]
	public string DienGiai {
		get { return dienGiai; }
		set{ dienGiai = value; }
	}
	[SqlColumn("SoTien", SqlDbType.Decimal)]
	public decimal? SoTien {
		get { return soTien; }
		set{ soTien = value; }
	}
	[SqlColumn("Post", SqlDbType.NChar)]
	public string Post {
		get { return post; }
		set{ post = value; }
	}
	[SqlColumn("Ngay", SqlDbType.DateTime)]
	public DateTime? Ngay {
		get { return ngay; }
		set{ ngay = value; }
	}
	[SqlColumn("TyGia", SqlDbType.Float)]
	public float? TyGia {
		get { return tyGia; }
		set{ tyGia = value; }
	}
	[StringSqlColumn("LoaiTien")]
	public string LoaiTien {
		get { return loaiTien; }
		set{ loaiTien = value; }
	}
	[StringSqlColumn("PhanLoai")]
	public string PhanLoai {
		get { return phanLoai; }
		set{ phanLoai = value; }
	}
	[StringSqlColumn("TaiKhoanNH")]
	public string TaiKhoanNH {
		get { return taiKhoanNH; }
		set{ taiKhoanNH = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public POS_CHILINHTINH() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<POS_CHILINHTINH> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<POS_CHILINHTINH>("POS_CHILINHTINH");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "POS_CHILINHTINH");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "POS_CHILINHTINH");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAuto_ID"></param>
	public static List<POS_CHILINHTINH> ReadByAuto_ID(byte[] inAuto_ID) {
		return rdodb_KTSqlDAC.ReadByParams<POS_CHILINHTINH>("POS_CHILINHTINH", rdodb_KTSqlDAC.newInParam("@Auto_ID", inAuto_ID));
	}
	#endregion DAC Methods 
 }
}

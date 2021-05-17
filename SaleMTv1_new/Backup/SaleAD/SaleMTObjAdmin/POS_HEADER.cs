using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class POS_HEADER {
	#region members
	byte[] auto_ID;
	string maDonVi;
	string maBoPhan;
	string loaiNX;
	string soGiaoDich;
	DateTime ngay;
	string dienGiai;
	string maKH;
	string maBoPhanNhan;
	string post;
	string loaiNghiepVu;
	string soHoaDon;
	string soSeri;
	string xuatHDRieng;
	string tenXuatHoaDon;
	string diaChi;
	string maSoThue;
	string ghiChuXuatHDRieng;
	string ghiChuHoaDon;

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
	[SqlColumn("LoaiNX", SqlDbType.NChar)]
	public string LoaiNX {
		get { return loaiNX; }
		set{ loaiNX = value; }
	}
	[StringSqlColumn("SoGiaoDich")]
	public string SoGiaoDich {
		get { return soGiaoDich; }
		set{ soGiaoDich = value; }
	}
	[SqlColumn("Ngay", SqlDbType.DateTime)]
	public DateTime Ngay {
		get { return ngay; }
		set{ ngay = value; }
	}
	[SqlColumn("DienGiai", SqlDbType.NVarChar)]
	public string DienGiai {
		get { return dienGiai; }
		set{ dienGiai = value; }
	}
	[SqlColumn("MaKH", SqlDbType.NVarChar)]
	public string MaKH {
		get { return maKH; }
		set{ maKH = value; }
	}
	[SqlColumn("MaBoPhanNhan", SqlDbType.NVarChar)]
	public string MaBoPhanNhan {
		get { return maBoPhanNhan; }
		set{ maBoPhanNhan = value; }
	}
	[SqlColumn("Post", SqlDbType.NChar)]
	public string Post {
		get { return post; }
		set{ post = value; }
	}
	[SqlColumn("LoaiNghiepVu", SqlDbType.NVarChar)]
	public string LoaiNghiepVu {
		get { return loaiNghiepVu; }
		set{ loaiNghiepVu = value; }
	}
	[SqlColumn("SoHoaDon", SqlDbType.NVarChar)]
	public string SoHoaDon {
		get { return soHoaDon; }
		set{ soHoaDon = value; }
	}
	[SqlColumn("SoSeri", SqlDbType.NVarChar)]
	public string SoSeri {
		get { return soSeri; }
		set{ soSeri = value; }
	}
	[SqlColumn("XuatHDRieng", SqlDbType.NChar)]
	public string XuatHDRieng {
		get { return xuatHDRieng; }
		set{ xuatHDRieng = value; }
	}
	[SqlColumn("TenXuatHoaDon", SqlDbType.NVarChar)]
	public string TenXuatHoaDon {
		get { return tenXuatHoaDon; }
		set{ tenXuatHoaDon = value; }
	}
	[SqlColumn("DiaChi", SqlDbType.NVarChar)]
	public string DiaChi {
		get { return diaChi; }
		set{ diaChi = value; }
	}
	[StringSqlColumn("MaSoThue")]
	public string MaSoThue {
		get { return maSoThue; }
		set{ maSoThue = value; }
	}
	[SqlColumn("GhiChuXuatHDRieng", SqlDbType.NVarChar)]
	public string GhiChuXuatHDRieng {
		get { return ghiChuXuatHDRieng; }
		set{ ghiChuXuatHDRieng = value; }
	}
	[SqlColumn("GhiChuHoaDon", SqlDbType.NVarChar)]
	public string GhiChuHoaDon {
		get { return ghiChuHoaDon; }
		set{ ghiChuHoaDon = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public POS_HEADER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<POS_HEADER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<POS_HEADER>("POS_HEADER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "POS_HEADER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "POS_HEADER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAuto_ID"></param>
	public static List<POS_HEADER> ReadByAuto_ID(byte[] inAuto_ID) {
		return rdodb_KTSqlDAC.ReadByParams<POS_HEADER>("POS_HEADER", rdodb_KTSqlDAC.newInParam("@Auto_ID", inAuto_ID));
	}
	#endregion DAC Methods 
 }
}

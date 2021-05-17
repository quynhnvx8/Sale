using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class OM_BangGia : IDataModel {
	#region members
	int id;
	string maBangGia;
	string tenBangGia;
	DateTime? tuNgay;
	DateTime? denNgay;
	string maVatTu;
	string dVT;
	decimal? donGiaGoc;
	decimal? donGia;
	string dangSuDung;
	string bangGiaCha;
	string maDonVi;
	string maBoPhan;
	decimal? hamLuong;
	decimal? donGiaVND;
	string loaiTien;
	decimal? tyGia;
	decimal? chietKhau;
	string tinhTrang;

	#endregion members
	#region Properties
	[PKSqlColumn("Id", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[SqlColumn("MaBangGia", SqlDbType.NVarChar)]
	public string MaBangGia {
		get { return maBangGia; }
		set{ maBangGia = value; }
	}
	[SqlColumn("TenBangGia", SqlDbType.NVarChar)]
	public string TenBangGia {
		get { return tenBangGia; }
		set{ tenBangGia = value; }
	}
	[SqlColumn("TuNgay", SqlDbType.DateTime)]
	public DateTime? TuNgay {
		get { return tuNgay; }
		set{ tuNgay = value; }
	}
	[SqlColumn("DenNgay", SqlDbType.DateTime)]
	public DateTime? DenNgay {
		get { return denNgay; }
		set{ denNgay = value; }
	}
	[SqlColumn("MaVatTu", SqlDbType.NVarChar)]
	public string MaVatTu {
		get { return maVatTu; }
		set{ maVatTu = value; }
	}
	[SqlColumn("DVT", SqlDbType.NVarChar)]
	public string DVT {
		get { return dVT; }
		set{ dVT = value; }
	}
	[SqlColumn("DonGiaGoc", SqlDbType.Decimal)]
	public decimal? DonGiaGoc {
		get { return donGiaGoc; }
		set{ donGiaGoc = value; }
	}
	[SqlColumn("DonGia", SqlDbType.Decimal)]
	public decimal? DonGia {
		get { return donGia; }
		set{ donGia = value; }
	}
	[SqlColumn("DangSuDung", SqlDbType.Char)]
	public string DangSuDung {
		get { return dangSuDung; }
		set{ dangSuDung = value; }
	}
	[SqlColumn("BangGiaCha", SqlDbType.NVarChar)]
	public string BangGiaCha {
		get { return bangGiaCha; }
		set{ bangGiaCha = value; }
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
	[SqlColumn("HamLuong", SqlDbType.Decimal)]
	public decimal? HamLuong {
		get { return hamLuong; }
		set{ hamLuong = value; }
	}
	[SqlColumn("DonGiaVND", SqlDbType.Decimal)]
	public decimal? DonGiaVND {
		get { return donGiaVND; }
		set{ donGiaVND = value; }
	}
	[SqlColumn("LoaiTien", SqlDbType.NVarChar)]
	public string LoaiTien {
		get { return loaiTien; }
		set{ loaiTien = value; }
	}
	[SqlColumn("TyGia", SqlDbType.Decimal)]
	public decimal? TyGia {
		get { return tyGia; }
		set{ tyGia = value; }
	}
	[SqlColumn("ChietKhau", SqlDbType.Decimal)]
	public decimal? ChietKhau {
		get { return chietKhau; }
		set{ chietKhau = value; }
	}
	[SqlColumn("TinhTrang", SqlDbType.NVarChar)]
	public string TinhTrang {
		get { return tinhTrang; }
		set{ tinhTrang = value; }
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
	public OM_BangGia() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public OM_BangGia(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<OM_BangGia> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<OM_BangGia>("OM_BangGia");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<OM_BangGia>(this, "OM_BangGia");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "OM_BangGia");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "OM_BangGia");
	}
	#endregion DAC Methods 
 }
}

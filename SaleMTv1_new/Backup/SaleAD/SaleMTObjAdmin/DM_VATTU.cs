using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DM_VATTU {
	#region members
	string vTID;
	string maVatTu;
	string tenVatTu;
	string dVT;
	string maNhom;
	string loaiVT;
	decimal? thueLPXD;
	string soTaiKhoanLPXD;
	decimal? thueVAT;
	string soTaiKhoanVAT;
	string dangSuDung;
	decimal? heSo;
	string dVT2;
	string quyCach;
	decimal? quyDoiKg;
	decimal? thueTTDB;
	string soTaiKhoanTTDB;
	string taiKhoanGV;
	string taiKhoanKho;
	string dungBOM;
	int? soNgayHetHan;
	int? soNgayTruocHan;
	string dungSerial;
	int? soNgayChoDoi;
	int? soNgayBaoHanh;
	decimal? dienTich;
	decimal? chieuCao;
	decimal? thoiGianNhapHang;
	decimal? thoiGianKiemNghiem;
	decimal? thoiGianXuLy;
	string luuKho;
	string giaCongNgoai;
	string maNV;
	string maVach;
	string maCu;
	string discriptionOfGoods;
	string unit;
	string model;
	string nguoiTao;
	DateTime? ngayTao;
	decimal? tyLeQuyDoi;
	string maXuong;
	decimal? soDiem;
	decimal? chiTieuHamLuong;
	string dVTHamLuong;
	decimal? chiTieuDoAm;
	string dVTDoAm;
	string baoBi;
	string maNCC;
	string maLoaiBB;
	string maBTP;
	decimal? tyLe;
	string maChatLuong;
	int? shelfLife;
	int? reAssay;
	decimal? factor1;
	decimal? factor2;
	decimal? factor3;
	decimal? factor4;
	string maSanXuat;
	string taDuoc;
	string tieuChuanSX;
	string dVTSX;
	string registrationNumber;
	string tieuChuanCL;
	string nguoiUpdate;
	DateTime? ngayUpdate;
	string maVatTu01;
	decimal? grossWeight;
	string khongHienCTGT;
	decimal? tyLeCK;
	string khoMacDinh;
	decimal? khoiLuongDVSX;
	string coKiemNghiem;
	decimal? thueNK;
	string loaiThuongHieu;
	string gioiTinh;
	string frameType;
	string lenMaterial;
	string doCongTrong;
	string namCollection;
	string frameMaterial;
	DateTime? expireUsingDate;
	string stype;
	string kichThuoc;
	string tuoiTho;
	string loaiTrong;
	string kieuDang;
	string lensGroup;
	string doCau;
	string doLoan;
	string doLao;
	string doVien;
	string doCan;
	string mauSac;
	string muc;
	string chietSuat;
	string maHang;
	string phuNhuom;
	string saleOff;

	#endregion members
	#region Properties
	[SqlColumn("VTID", SqlDbType.NVarChar)]
	public string VTID {
		get { return vTID; }
		set{ vTID = value; }
	}
	[SqlColumn("MaVatTu", SqlDbType.NVarChar)]
	public string MaVatTu {
		get { return maVatTu; }
		set{ maVatTu = value; }
	}
	[SqlColumn("TenVatTu", SqlDbType.NVarChar)]
	public string TenVatTu {
		get { return tenVatTu; }
		set{ tenVatTu = value; }
	}
	[SqlColumn("DVT", SqlDbType.NVarChar)]
	public string DVT {
		get { return dVT; }
		set{ dVT = value; }
	}
	[SqlColumn("MaNhom", SqlDbType.NVarChar)]
	public string MaNhom {
		get { return maNhom; }
		set{ maNhom = value; }
	}
	[SqlColumn("LoaiVT", SqlDbType.NVarChar)]
	public string LoaiVT {
		get { return loaiVT; }
		set{ loaiVT = value; }
	}
	[SqlColumn("ThueLPXD", SqlDbType.Decimal)]
	public decimal? ThueLPXD {
		get { return thueLPXD; }
		set{ thueLPXD = value; }
	}
	[SqlColumn("SoTaiKhoanLPXD", SqlDbType.NVarChar)]
	public string SoTaiKhoanLPXD {
		get { return soTaiKhoanLPXD; }
		set{ soTaiKhoanLPXD = value; }
	}
	[SqlColumn("ThueVAT", SqlDbType.Decimal)]
	public decimal? ThueVAT {
		get { return thueVAT; }
		set{ thueVAT = value; }
	}
	[SqlColumn("SoTaiKhoanVAT", SqlDbType.NVarChar)]
	public string SoTaiKhoanVAT {
		get { return soTaiKhoanVAT; }
		set{ soTaiKhoanVAT = value; }
	}
	[SqlColumn("DangSuDung", SqlDbType.Char)]
	public string DangSuDung {
		get { return dangSuDung; }
		set{ dangSuDung = value; }
	}
	[SqlColumn("HeSo", SqlDbType.Decimal)]
	public decimal? HeSo {
		get { return heSo; }
		set{ heSo = value; }
	}
	[SqlColumn("DVT2", SqlDbType.NVarChar)]
	public string DVT2 {
		get { return dVT2; }
		set{ dVT2 = value; }
	}
	[SqlColumn("QuyCach", SqlDbType.NVarChar)]
	public string QuyCach {
		get { return quyCach; }
		set{ quyCach = value; }
	}
	[SqlColumn("QuyDoiKg", SqlDbType.Decimal)]
	public decimal? QuyDoiKg {
		get { return quyDoiKg; }
		set{ quyDoiKg = value; }
	}
	[SqlColumn("ThueTTDB", SqlDbType.Decimal)]
	public decimal? ThueTTDB {
		get { return thueTTDB; }
		set{ thueTTDB = value; }
	}
	[SqlColumn("SoTaiKhoanTTDB", SqlDbType.NVarChar)]
	public string SoTaiKhoanTTDB {
		get { return soTaiKhoanTTDB; }
		set{ soTaiKhoanTTDB = value; }
	}
	[SqlColumn("TaiKhoanGV", SqlDbType.NVarChar)]
	public string TaiKhoanGV {
		get { return taiKhoanGV; }
		set{ taiKhoanGV = value; }
	}
	[SqlColumn("TaiKhoanKho", SqlDbType.NVarChar)]
	public string TaiKhoanKho {
		get { return taiKhoanKho; }
		set{ taiKhoanKho = value; }
	}
	[SqlColumn("DungBOM", SqlDbType.Char)]
	public string DungBOM {
		get { return dungBOM; }
		set{ dungBOM = value; }
	}
	[SqlColumn("SoNgayHetHan", SqlDbType.Int)]
	public int? SoNgayHetHan {
		get { return soNgayHetHan; }
		set{ soNgayHetHan = value; }
	}
	[SqlColumn("SoNgayTruocHan", SqlDbType.Int)]
	public int? SoNgayTruocHan {
		get { return soNgayTruocHan; }
		set{ soNgayTruocHan = value; }
	}
	[SqlColumn("DungSerial", SqlDbType.Char)]
	public string DungSerial {
		get { return dungSerial; }
		set{ dungSerial = value; }
	}
	[SqlColumn("SoNgayChoDoi", SqlDbType.Int)]
	public int? SoNgayChoDoi {
		get { return soNgayChoDoi; }
		set{ soNgayChoDoi = value; }
	}
	[SqlColumn("SoNgayBaoHanh", SqlDbType.Int)]
	public int? SoNgayBaoHanh {
		get { return soNgayBaoHanh; }
		set{ soNgayBaoHanh = value; }
	}
	[SqlColumn("DienTich", SqlDbType.Decimal)]
	public decimal? DienTich {
		get { return dienTich; }
		set{ dienTich = value; }
	}
	[SqlColumn("ChieuCao", SqlDbType.Decimal)]
	public decimal? ChieuCao {
		get { return chieuCao; }
		set{ chieuCao = value; }
	}
	[SqlColumn("ThoiGianNhapHang", SqlDbType.Decimal)]
	public decimal? ThoiGianNhapHang {
		get { return thoiGianNhapHang; }
		set{ thoiGianNhapHang = value; }
	}
	[SqlColumn("ThoiGianKiemNghiem", SqlDbType.Decimal)]
	public decimal? ThoiGianKiemNghiem {
		get { return thoiGianKiemNghiem; }
		set{ thoiGianKiemNghiem = value; }
	}
	[SqlColumn("ThoiGianXuLy", SqlDbType.Decimal)]
	public decimal? ThoiGianXuLy {
		get { return thoiGianXuLy; }
		set{ thoiGianXuLy = value; }
	}
	[SqlColumn("LuuKho", SqlDbType.Char)]
	public string LuuKho {
		get { return luuKho; }
		set{ luuKho = value; }
	}
	[SqlColumn("GiaCongNgoai", SqlDbType.Char)]
	public string GiaCongNgoai {
		get { return giaCongNgoai; }
		set{ giaCongNgoai = value; }
	}
	[SqlColumn("MaNV", SqlDbType.NVarChar)]
	public string MaNV {
		get { return maNV; }
		set{ maNV = value; }
	}
	[SqlColumn("MaVach", SqlDbType.NVarChar)]
	public string MaVach {
		get { return maVach; }
		set{ maVach = value; }
	}
	[SqlColumn("MaCu", SqlDbType.NVarChar)]
	public string MaCu {
		get { return maCu; }
		set{ maCu = value; }
	}
	[SqlColumn("DiscriptionOfGoods", SqlDbType.NVarChar)]
	public string DiscriptionOfGoods {
		get { return discriptionOfGoods; }
		set{ discriptionOfGoods = value; }
	}
	[SqlColumn("Unit", SqlDbType.NVarChar)]
	public string Unit {
		get { return unit; }
		set{ unit = value; }
	}
	[SqlColumn("Model", SqlDbType.NVarChar)]
	public string Model {
		get { return model; }
		set{ model = value; }
	}
	[SqlColumn("NguoiTao", SqlDbType.NVarChar)]
	public string NguoiTao {
		get { return nguoiTao; }
		set{ nguoiTao = value; }
	}
	[SqlColumn("NgayTao", SqlDbType.DateTime)]
	public DateTime? NgayTao {
		get { return ngayTao; }
		set{ ngayTao = value; }
	}
	[SqlColumn("TyLeQuyDoi", SqlDbType.Decimal)]
	public decimal? TyLeQuyDoi {
		get { return tyLeQuyDoi; }
		set{ tyLeQuyDoi = value; }
	}
	[SqlColumn("MaXuong", SqlDbType.NVarChar)]
	public string MaXuong {
		get { return maXuong; }
		set{ maXuong = value; }
	}
	[SqlColumn("SoDiem", SqlDbType.Decimal)]
	public decimal? SoDiem {
		get { return soDiem; }
		set{ soDiem = value; }
	}
	[SqlColumn("ChiTieuHamLuong", SqlDbType.Decimal)]
	public decimal? ChiTieuHamLuong {
		get { return chiTieuHamLuong; }
		set{ chiTieuHamLuong = value; }
	}
	[SqlColumn("DVTHamLuong", SqlDbType.NVarChar)]
	public string DVTHamLuong {
		get { return dVTHamLuong; }
		set{ dVTHamLuong = value; }
	}
	[SqlColumn("ChiTieuDoAm", SqlDbType.Decimal)]
	public decimal? ChiTieuDoAm {
		get { return chiTieuDoAm; }
		set{ chiTieuDoAm = value; }
	}
	[SqlColumn("DVTDoAm", SqlDbType.NVarChar)]
	public string DVTDoAm {
		get { return dVTDoAm; }
		set{ dVTDoAm = value; }
	}
	[SqlColumn("BaoBi", SqlDbType.Char)]
	public string BaoBi {
		get { return baoBi; }
		set{ baoBi = value; }
	}
	[SqlColumn("MaNCC", SqlDbType.NVarChar)]
	public string MaNCC {
		get { return maNCC; }
		set{ maNCC = value; }
	}
	[SqlColumn("MaLoaiBB", SqlDbType.NVarChar)]
	public string MaLoaiBB {
		get { return maLoaiBB; }
		set{ maLoaiBB = value; }
	}
	[SqlColumn("MaBTP", SqlDbType.NVarChar)]
	public string MaBTP {
		get { return maBTP; }
		set{ maBTP = value; }
	}
	[SqlColumn("TyLe", SqlDbType.Decimal)]
	public decimal? TyLe {
		get { return tyLe; }
		set{ tyLe = value; }
	}
	[SqlColumn("MaChatLuong", SqlDbType.NVarChar)]
	public string MaChatLuong {
		get { return maChatLuong; }
		set{ maChatLuong = value; }
	}
	[SqlColumn("ShelfLife", SqlDbType.Int)]
	public int? ShelfLife {
		get { return shelfLife; }
		set{ shelfLife = value; }
	}
	[SqlColumn("ReAssay", SqlDbType.Int)]
	public int? ReAssay {
		get { return reAssay; }
		set{ reAssay = value; }
	}
	[SqlColumn("Factor1", SqlDbType.Decimal)]
	public decimal? Factor1 {
		get { return factor1; }
		set{ factor1 = value; }
	}
	[SqlColumn("Factor2", SqlDbType.Decimal)]
	public decimal? Factor2 {
		get { return factor2; }
		set{ factor2 = value; }
	}
	[SqlColumn("Factor3", SqlDbType.Decimal)]
	public decimal? Factor3 {
		get { return factor3; }
		set{ factor3 = value; }
	}
	[SqlColumn("Factor4", SqlDbType.Decimal)]
	public decimal? Factor4 {
		get { return factor4; }
		set{ factor4 = value; }
	}
	[SqlColumn("MaSanXuat", SqlDbType.NVarChar)]
	public string MaSanXuat {
		get { return maSanXuat; }
		set{ maSanXuat = value; }
	}
	[SqlColumn("TaDuoc", SqlDbType.Char)]
	public string TaDuoc {
		get { return taDuoc; }
		set{ taDuoc = value; }
	}
	[SqlColumn("TieuChuanSX", SqlDbType.NVarChar)]
	public string TieuChuanSX {
		get { return tieuChuanSX; }
		set{ tieuChuanSX = value; }
	}
	[SqlColumn("DVTSX", SqlDbType.NVarChar)]
	public string DVTSX {
		get { return dVTSX; }
		set{ dVTSX = value; }
	}
	[SqlColumn("RegistrationNumber", SqlDbType.NVarChar)]
	public string RegistrationNumber {
		get { return registrationNumber; }
		set{ registrationNumber = value; }
	}
	[SqlColumn("TieuChuanCL", SqlDbType.NVarChar)]
	public string TieuChuanCL {
		get { return tieuChuanCL; }
		set{ tieuChuanCL = value; }
	}
	[SqlColumn("NguoiUpdate", SqlDbType.NVarChar)]
	public string NguoiUpdate {
		get { return nguoiUpdate; }
		set{ nguoiUpdate = value; }
	}
	[SqlColumn("NgayUpdate", SqlDbType.DateTime)]
	public DateTime? NgayUpdate {
		get { return ngayUpdate; }
		set{ ngayUpdate = value; }
	}
	[SqlColumn("MaVatTu01", SqlDbType.NVarChar)]
	public string MaVatTu01 {
		get { return maVatTu01; }
		set{ maVatTu01 = value; }
	}
	[SqlColumn("GrossWeight", SqlDbType.Decimal)]
	public decimal? GrossWeight {
		get { return grossWeight; }
		set{ grossWeight = value; }
	}
	[SqlColumn("KhongHienCTGT", SqlDbType.Char)]
	public string KhongHienCTGT {
		get { return khongHienCTGT; }
		set{ khongHienCTGT = value; }
	}
	[SqlColumn("TyLeCK", SqlDbType.Decimal)]
	public decimal? TyLeCK {
		get { return tyLeCK; }
		set{ tyLeCK = value; }
	}
	[SqlColumn("KhoMacDinh", SqlDbType.NVarChar)]
	public string KhoMacDinh {
		get { return khoMacDinh; }
		set{ khoMacDinh = value; }
	}
	[SqlColumn("KhoiLuongDVSX", SqlDbType.Decimal)]
	public decimal? KhoiLuongDVSX {
		get { return khoiLuongDVSX; }
		set{ khoiLuongDVSX = value; }
	}
	[SqlColumn("CoKiemNghiem", SqlDbType.Char)]
	public string CoKiemNghiem {
		get { return coKiemNghiem; }
		set{ coKiemNghiem = value; }
	}
	[SqlColumn("ThueNK", SqlDbType.Decimal)]
	public decimal? ThueNK {
		get { return thueNK; }
		set{ thueNK = value; }
	}
	[SqlColumn("LoaiThuongHieu", SqlDbType.NVarChar)]
	public string LoaiThuongHieu {
		get { return loaiThuongHieu; }
		set{ loaiThuongHieu = value; }
	}
	[SqlColumn("GioiTinh", SqlDbType.NVarChar)]
	public string GioiTinh {
		get { return gioiTinh; }
		set{ gioiTinh = value; }
	}
	[SqlColumn("FrameType", SqlDbType.NVarChar)]
	public string FrameType {
		get { return frameType; }
		set{ frameType = value; }
	}
	[SqlColumn("LenMaterial", SqlDbType.NVarChar)]
	public string LenMaterial {
		get { return lenMaterial; }
		set{ lenMaterial = value; }
	}
	[SqlColumn("DoCongTrong", SqlDbType.NVarChar)]
	public string DoCongTrong {
		get { return doCongTrong; }
		set{ doCongTrong = value; }
	}
	[SqlColumn("NamCollection", SqlDbType.NVarChar)]
	public string NamCollection {
		get { return namCollection; }
		set{ namCollection = value; }
	}
	[SqlColumn("FrameMaterial", SqlDbType.NVarChar)]
	public string FrameMaterial {
		get { return frameMaterial; }
		set{ frameMaterial = value; }
	}
	[SqlColumn("ExpireUsingDate", SqlDbType.DateTime)]
	public DateTime? ExpireUsingDate {
		get { return expireUsingDate; }
		set{ expireUsingDate = value; }
	}
	[SqlColumn("Stype", SqlDbType.NVarChar)]
	public string Stype {
		get { return stype; }
		set{ stype = value; }
	}
	[SqlColumn("KichThuoc", SqlDbType.NVarChar)]
	public string KichThuoc {
		get { return kichThuoc; }
		set{ kichThuoc = value; }
	}
	[SqlColumn("TuoiTho", SqlDbType.NVarChar)]
	public string TuoiTho {
		get { return tuoiTho; }
		set{ tuoiTho = value; }
	}
	[SqlColumn("LoaiTrong", SqlDbType.NVarChar)]
	public string LoaiTrong {
		get { return loaiTrong; }
		set{ loaiTrong = value; }
	}
	[SqlColumn("KieuDang", SqlDbType.NVarChar)]
	public string KieuDang {
		get { return kieuDang; }
		set{ kieuDang = value; }
	}
	[SqlColumn("LensGroup", SqlDbType.NVarChar)]
	public string LensGroup {
		get { return lensGroup; }
		set{ lensGroup = value; }
	}
	[SqlColumn("DoCau", SqlDbType.NVarChar)]
	public string DoCau {
		get { return doCau; }
		set{ doCau = value; }
	}
	[SqlColumn("DoLoan", SqlDbType.NVarChar)]
	public string DoLoan {
		get { return doLoan; }
		set{ doLoan = value; }
	}
	[SqlColumn("DoLao", SqlDbType.NVarChar)]
	public string DoLao {
		get { return doLao; }
		set{ doLao = value; }
	}
	[SqlColumn("DoVien", SqlDbType.NVarChar)]
	public string DoVien {
		get { return doVien; }
		set{ doVien = value; }
	}
	[SqlColumn("DoCan", SqlDbType.NVarChar)]
	public string DoCan {
		get { return doCan; }
		set{ doCan = value; }
	}
	[SqlColumn("MauSac", SqlDbType.NVarChar)]
	public string MauSac {
		get { return mauSac; }
		set{ mauSac = value; }
	}
	[SqlColumn("Muc", SqlDbType.NVarChar)]
	public string Muc {
		get { return muc; }
		set{ muc = value; }
	}
	[SqlColumn("ChietSuat", SqlDbType.NVarChar)]
	public string ChietSuat {
		get { return chietSuat; }
		set{ chietSuat = value; }
	}
	[SqlColumn("MaHang", SqlDbType.NVarChar)]
	public string MaHang {
		get { return maHang; }
		set{ maHang = value; }
	}
	[SqlColumn("PhuNhuom", SqlDbType.NVarChar)]
	public string PhuNhuom {
		get { return phuNhuom; }
		set{ phuNhuom = value; }
	}
	[SqlColumn("SaleOff", SqlDbType.NVarChar)]
	public string SaleOff {
		get { return saleOff; }
		set{ saleOff = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DM_VATTU() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DM_VATTU> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DM_VATTU>("DM_VATTU");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DM_VATTU");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DM_VATTU");
	}
	#endregion DAC Methods 
 }
}

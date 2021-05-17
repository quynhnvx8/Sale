using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DM_VATTU
    {
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
        string sDHanDung;
        float? giaBan;

        #endregion members
        #region Properties
        [StringSqlColumn("VTID")]
        public string VTID
        {
            get { return vTID; }
            set { vTID = value; }
        }
        [PKSqlColumn("MaVatTu", SqlDbType.VarChar, null)]
        public string MaVatTu
        {
            get { return maVatTu; }
            set { maVatTu = value; }
        }
        [StringSqlColumn("TenVatTu")]
        public string TenVatTu
        {
            get { return tenVatTu; }
            set { tenVatTu = value; }
        }
        [StringSqlColumn("DVT")]
        public string DVT
        {
            get { return dVT; }
            set { dVT = value; }
        }
        [StringSqlColumn("MaNhom")]
        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
        [StringSqlColumn("LoaiVT")]
        public string LoaiVT
        {
            get { return loaiVT; }
            set { loaiVT = value; }
        }
        [SqlColumn("ThueLPXD", SqlDbType.Decimal)]
        public decimal? ThueLPXD
        {
            get { return thueLPXD; }
            set { thueLPXD = value; }
        }
        [StringSqlColumn("SoTaiKhoanLPXD")]
        public string SoTaiKhoanLPXD
        {
            get { return soTaiKhoanLPXD; }
            set { soTaiKhoanLPXD = value; }
        }
        [SqlColumn("ThueVAT", SqlDbType.Decimal)]
        public decimal? ThueVAT
        {
            get { return thueVAT; }
            set { thueVAT = value; }
        }
        [StringSqlColumn("SoTaiKhoanVAT")]
        public string SoTaiKhoanVAT
        {
            get { return soTaiKhoanVAT; }
            set { soTaiKhoanVAT = value; }
        }
        [SqlColumn("DangSuDung", SqlDbType.Char)]
        public string DangSuDung
        {
            get { return dangSuDung; }
            set { dangSuDung = value; }
        }
        [SqlColumn("HeSo", SqlDbType.Decimal)]
        public decimal? HeSo
        {
            get { return heSo; }
            set { heSo = value; }
        }
        [StringSqlColumn("DVT2")]
        public string DVT2
        {
            get { return dVT2; }
            set { dVT2 = value; }
        }
        [StringSqlColumn("QuyCach")]
        public string QuyCach
        {
            get { return quyCach; }
            set { quyCach = value; }
        }
        [SqlColumn("QuyDoiKg", SqlDbType.Decimal)]
        public decimal? QuyDoiKg
        {
            get { return quyDoiKg; }
            set { quyDoiKg = value; }
        }
        [SqlColumn("ThueTTDB", SqlDbType.Decimal)]
        public decimal? ThueTTDB
        {
            get { return thueTTDB; }
            set { thueTTDB = value; }
        }
        [StringSqlColumn("SoTaiKhoanTTDB")]
        public string SoTaiKhoanTTDB
        {
            get { return soTaiKhoanTTDB; }
            set { soTaiKhoanTTDB = value; }
        }
        [StringSqlColumn("TaiKhoanGV")]
        public string TaiKhoanGV
        {
            get { return taiKhoanGV; }
            set { taiKhoanGV = value; }
        }
        [StringSqlColumn("TaiKhoanKho")]
        public string TaiKhoanKho
        {
            get { return taiKhoanKho; }
            set { taiKhoanKho = value; }
        }
        [SqlColumn("DungBOM", SqlDbType.Char)]
        public string DungBOM
        {
            get { return dungBOM; }
            set { dungBOM = value; }
        }
        [SqlColumn("SoNgayHetHan", SqlDbType.Int)]
        public int? SoNgayHetHan
        {
            get { return soNgayHetHan; }
            set { soNgayHetHan = value; }
        }
        [SqlColumn("SoNgayTruocHan", SqlDbType.Int)]
        public int? SoNgayTruocHan
        {
            get { return soNgayTruocHan; }
            set { soNgayTruocHan = value; }
        }
        [SqlColumn("DungSerial", SqlDbType.Char)]
        public string DungSerial
        {
            get { return dungSerial; }
            set { dungSerial = value; }
        }
        [SqlColumn("SoNgayChoDoi", SqlDbType.Int)]
        public int? SoNgayChoDoi
        {
            get { return soNgayChoDoi; }
            set { soNgayChoDoi = value; }
        }
        [SqlColumn("SoNgayBaoHanh", SqlDbType.Int)]
        public int? SoNgayBaoHanh
        {
            get { return soNgayBaoHanh; }
            set { soNgayBaoHanh = value; }
        }
        [SqlColumn("DienTich", SqlDbType.Decimal)]
        public decimal? DienTich
        {
            get { return dienTich; }
            set { dienTich = value; }
        }
        [SqlColumn("ChieuCao", SqlDbType.Decimal)]
        public decimal? ChieuCao
        {
            get { return chieuCao; }
            set { chieuCao = value; }
        }
        [SqlColumn("ThoiGianNhapHang", SqlDbType.Decimal)]
        public decimal? ThoiGianNhapHang
        {
            get { return thoiGianNhapHang; }
            set { thoiGianNhapHang = value; }
        }
        [SqlColumn("ThoiGianKiemNghiem", SqlDbType.Decimal)]
        public decimal? ThoiGianKiemNghiem
        {
            get { return thoiGianKiemNghiem; }
            set { thoiGianKiemNghiem = value; }
        }
        [SqlColumn("ThoiGianXuLy", SqlDbType.Decimal)]
        public decimal? ThoiGianXuLy
        {
            get { return thoiGianXuLy; }
            set { thoiGianXuLy = value; }
        }
        [SqlColumn("LuuKho", SqlDbType.Char)]
        public string LuuKho
        {
            get { return luuKho; }
            set { luuKho = value; }
        }
        [SqlColumn("GiaCongNgoai", SqlDbType.Char)]
        public string GiaCongNgoai
        {
            get { return giaCongNgoai; }
            set { giaCongNgoai = value; }
        }
        [StringSqlColumn("MaNV")]
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        [StringSqlColumn("MaVach")]
        public string MaVach
        {
            get { return maVach; }
            set { maVach = value; }
        }
        [StringSqlColumn("MaCu")]
        public string MaCu
        {
            get { return maCu; }
            set { maCu = value; }
        }
        [StringSqlColumn("DiscriptionOfGoods")]
        public string DiscriptionOfGoods
        {
            get { return discriptionOfGoods; }
            set { discriptionOfGoods = value; }
        }
        [StringSqlColumn("Unit")]
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        [StringSqlColumn("Model")]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        [StringSqlColumn("NguoiTao")]
        public string NguoiTao
        {
            get { return nguoiTao; }
            set { nguoiTao = value; }
        }
        [SqlColumn("NgayTao", SqlDbType.DateTime)]
        public DateTime? NgayTao
        {
            get { return ngayTao; }
            set { ngayTao = value; }
        }
        [SqlColumn("TyLeQuyDoi", SqlDbType.Decimal)]
        public decimal? TyLeQuyDoi
        {
            get { return tyLeQuyDoi; }
            set { tyLeQuyDoi = value; }
        }
        [StringSqlColumn("MaXuong")]
        public string MaXuong
        {
            get { return maXuong; }
            set { maXuong = value; }
        }
        [SqlColumn("SoDiem", SqlDbType.Decimal)]
        public decimal? SoDiem
        {
            get { return soDiem; }
            set { soDiem = value; }
        }
        [SqlColumn("ChiTieuHamLuong", SqlDbType.Decimal)]
        public decimal? ChiTieuHamLuong
        {
            get { return chiTieuHamLuong; }
            set { chiTieuHamLuong = value; }
        }
        [StringSqlColumn("DVTHamLuong")]
        public string DVTHamLuong
        {
            get { return dVTHamLuong; }
            set { dVTHamLuong = value; }
        }
        [SqlColumn("ChiTieuDoAm", SqlDbType.Decimal)]
        public decimal? ChiTieuDoAm
        {
            get { return chiTieuDoAm; }
            set { chiTieuDoAm = value; }
        }
        [StringSqlColumn("DVTDoAm")]
        public string DVTDoAm
        {
            get { return dVTDoAm; }
            set { dVTDoAm = value; }
        }
        [SqlColumn("BaoBi", SqlDbType.Char)]
        public string BaoBi
        {
            get { return baoBi; }
            set { baoBi = value; }
        }
        [StringSqlColumn("MaNCC")]
        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }
        [StringSqlColumn("MaLoaiBB")]
        public string MaLoaiBB
        {
            get { return maLoaiBB; }
            set { maLoaiBB = value; }
        }
        [StringSqlColumn("MaBTP")]
        public string MaBTP
        {
            get { return maBTP; }
            set { maBTP = value; }
        }
        [SqlColumn("TyLe", SqlDbType.Decimal)]
        public decimal? TyLe
        {
            get { return tyLe; }
            set { tyLe = value; }
        }
        [StringSqlColumn("MaChatLuong")]
        public string MaChatLuong
        {
            get { return maChatLuong; }
            set { maChatLuong = value; }
        }
        [SqlColumn("ShelfLife", SqlDbType.Int)]
        public int? ShelfLife
        {
            get { return shelfLife; }
            set { shelfLife = value; }
        }
        [SqlColumn("ReAssay", SqlDbType.Int)]
        public int? ReAssay
        {
            get { return reAssay; }
            set { reAssay = value; }
        }
        [SqlColumn("Factor1", SqlDbType.Decimal)]
        public decimal? Factor1
        {
            get { return factor1; }
            set { factor1 = value; }
        }
        [SqlColumn("Factor2", SqlDbType.Decimal)]
        public decimal? Factor2
        {
            get { return factor2; }
            set { factor2 = value; }
        }
        [SqlColumn("Factor3", SqlDbType.Decimal)]
        public decimal? Factor3
        {
            get { return factor3; }
            set { factor3 = value; }
        }
        [SqlColumn("Factor4", SqlDbType.Decimal)]
        public decimal? Factor4
        {
            get { return factor4; }
            set { factor4 = value; }
        }
        [StringSqlColumn("MaSanXuat")]
        public string MaSanXuat
        {
            get { return maSanXuat; }
            set { maSanXuat = value; }
        }
        [SqlColumn("TaDuoc", SqlDbType.Char)]
        public string TaDuoc
        {
            get { return taDuoc; }
            set { taDuoc = value; }
        }
        [StringSqlColumn("TieuChuanSX")]
        public string TieuChuanSX
        {
            get { return tieuChuanSX; }
            set { tieuChuanSX = value; }
        }
        [StringSqlColumn("DVTSX")]
        public string DVTSX
        {
            get { return dVTSX; }
            set { dVTSX = value; }
        }
        [StringSqlColumn("RegistrationNumber")]
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }
        [StringSqlColumn("TieuChuanCL")]
        public string TieuChuanCL
        {
            get { return tieuChuanCL; }
            set { tieuChuanCL = value; }
        }
        [StringSqlColumn("NguoiUpdate")]
        public string NguoiUpdate
        {
            get { return nguoiUpdate; }
            set { nguoiUpdate = value; }
        }
        [SqlColumn("NgayUpdate", SqlDbType.DateTime)]
        public DateTime? NgayUpdate
        {
            get { return ngayUpdate; }
            set { ngayUpdate = value; }
        }
        [StringSqlColumn("MaVatTu01")]
        public string MaVatTu01
        {
            get { return maVatTu01; }
            set { maVatTu01 = value; }
        }
        [SqlColumn("GrossWeight", SqlDbType.Decimal)]
        public decimal? GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        [SqlColumn("KhongHienCTGT", SqlDbType.Char)]
        public string KhongHienCTGT
        {
            get { return khongHienCTGT; }
            set { khongHienCTGT = value; }
        }
        [SqlColumn("TyLeCK", SqlDbType.Decimal)]
        public decimal? TyLeCK
        {
            get { return tyLeCK; }
            set { tyLeCK = value; }
        }
        [StringSqlColumn("KhoMacDinh")]
        public string KhoMacDinh
        {
            get { return khoMacDinh; }
            set { khoMacDinh = value; }
        }
        [SqlColumn("KhoiLuongDVSX", SqlDbType.Decimal)]
        public decimal? KhoiLuongDVSX
        {
            get { return khoiLuongDVSX; }
            set { khoiLuongDVSX = value; }
        }
        [SqlColumn("CoKiemNghiem", SqlDbType.Char)]
        public string CoKiemNghiem
        {
            get { return coKiemNghiem; }
            set { coKiemNghiem = value; }
        }
        [SqlColumn("ThueNK", SqlDbType.Decimal)]
        public decimal? ThueNK
        {
            get { return thueNK; }
            set { thueNK = value; }
        }
        [SqlColumn("SDHanDung", SqlDbType.Char)]
        public string SDHanDung
        {
            get { return sDHanDung; }
            set { sDHanDung = value; }
        }
        [SqlColumn("GiaBan", SqlDbType.Float)]
        public float? GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
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
        public static List<DM_VATTU> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DM_VATTU>("DM_VATTU");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DM_VATTU",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DM_VATTU");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inMaVatTu"></param>
        public static List<DM_VATTU> ReadByMaVatTu(string inMaVatTu)
        {
            return posdb_vnmSqlDAC.ReadByParams<DM_VATTU>("DM_VATTU", posdb_vnmSqlDAC.newInParam("@MaVatTu", inMaVatTu));
        }
        #endregion DAC Methods
    }
}

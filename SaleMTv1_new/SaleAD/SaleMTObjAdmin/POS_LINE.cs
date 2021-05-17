using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class POS_LINE {
	#region members
	byte[] auto_ID;
	string maDonVi;
	string maBoPhan;
	string soGiaoDich;
	int sTT;
	string maVatTu;
	decimal? soLuong;
	decimal? donGiaBan;
	decimal? giamGia;
	string maKho;

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
	public int STT {
		get { return sTT; }
		set{ sTT = value; }
	}
	[SqlColumn("MaVatTu", SqlDbType.NVarChar)]
	public string MaVatTu {
		get { return maVatTu; }
		set{ maVatTu = value; }
	}
	[SqlColumn("SoLuong", SqlDbType.Decimal)]
	public decimal? SoLuong {
		get { return soLuong; }
		set{ soLuong = value; }
	}
	[SqlColumn("DonGiaBan", SqlDbType.Decimal)]
	public decimal? DonGiaBan {
		get { return donGiaBan; }
		set{ donGiaBan = value; }
	}
	[SqlColumn("GiamGia", SqlDbType.Decimal)]
	public decimal? GiamGia {
		get { return giamGia; }
		set{ giamGia = value; }
	}
	[SqlColumn("MaKho", SqlDbType.NVarChar)]
	public string MaKho {
		get { return maKho; }
		set{ maKho = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public POS_LINE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<POS_LINE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<POS_LINE>("POS_LINE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "POS_LINE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "POS_LINE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAuto_ID"></param>
	public static List<POS_LINE> ReadByAuto_ID(byte[] inAuto_ID) {
		return rdodb_KTSqlDAC.ReadByParams<POS_LINE>("POS_LINE", rdodb_KTSqlDAC.newInParam("@Auto_ID", inAuto_ID));
	}
	#endregion DAC Methods 
 }
}

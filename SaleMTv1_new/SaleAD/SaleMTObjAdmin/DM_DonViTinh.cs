using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DM_DonViTinh {
	#region members
	string dVT;
	string moTa;
	int? doUuTien;

	#endregion members
	#region Properties
	[PKSqlColumn("DVT", SqlDbType.NVarChar, null)]
	public string DVT {
		get { return dVT; }
		set{ dVT = value; }
	}
	[SqlColumn("MoTa", SqlDbType.NVarChar)]
	public string MoTa {
		get { return moTa; }
		set{ moTa = value; }
	}
	[SqlColumn("DoUuTien", SqlDbType.Int)]
	public int? DoUuTien {
		get { return doUuTien; }
		set{ doUuTien = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public DM_DonViTinh() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DM_DonViTinh> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DM_DonViTinh>("DM_DonViTinh");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DM_DonViTinh");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DM_DonViTinh");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inDVT"></param>
	public static List<DM_DonViTinh> ReadByDVT(string inDVT) {
		return rdodb_KTSqlDAC.ReadByParams<DM_DonViTinh>("DM_DonViTinh", rdodb_KTSqlDAC.newInParam("@DVT", inDVT));
	}
	#endregion DAC Methods 
 }
}

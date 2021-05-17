using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SALE_TARGET : IDataModel {
	#region members
	int id;
	float? tARGETS;
	string aCCOUNT;
	DateTime? cREATE_DATE;
	int? mONTH;
	int? yEAR;
	int dEPT_CODE;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[SqlColumn("TARGETS", SqlDbType.Float)]
	public float? TARGETS {
		get { return tARGETS; }
		set{ tARGETS = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[SqlColumn("MONTH", SqlDbType.Int)]
	public int? MONTH {
		get { return mONTH; }
		set{ mONTH = value; }
	}
	[SqlColumn("YEAR", SqlDbType.Int)]
	public int? YEAR {
		get { return yEAR; }
		set{ yEAR = value; }
	}
	[SqlColumn("DEPT_CODE", SqlDbType.Int)]
	public int DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
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
	public SALE_TARGET() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public SALE_TARGET(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SALE_TARGET> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SALE_TARGET>("SALE_TARGET");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<SALE_TARGET>(this, "SALE_TARGET");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SALE_TARGET");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SALE_TARGET");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inACCOUNT"></param>
	public static List<SALE_TARGET> ReadByACCOUNT(string inACCOUNT) {
		return rdodb_KTSqlDAC.ReadByParams<SALE_TARGET>("SALE_TARGET", rdodb_KTSqlDAC.newInParam("@ACCOUNT", inACCOUNT));
	}
	#endregion DAC Methods 
 }
}

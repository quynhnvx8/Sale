using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class EMPLOYEE_ZONE_HISTORYS : IDataModel {
	#region members
	int id;
	string eMPLOYEE_ID;
	string zONE_CODE;
	DateTime? sTART_DATE;
	DateTime? eND_DATE;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[StringSqlColumn("ZONE_CODE")]
	public string ZONE_CODE {
		get { return zONE_CODE; }
		set{ zONE_CODE = value; }
	}
	[SqlColumn("START_DATE", SqlDbType.DateTime)]
	public DateTime? START_DATE {
		get { return sTART_DATE; }
		set{ sTART_DATE = value; }
	}
	[SqlColumn("END_DATE", SqlDbType.DateTime)]
	public DateTime? END_DATE {
		get { return eND_DATE; }
		set{ eND_DATE = value; }
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
	public EMPLOYEE_ZONE_HISTORYS() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public EMPLOYEE_ZONE_HISTORYS(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<EMPLOYEE_ZONE_HISTORYS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<EMPLOYEE_ZONE_HISTORYS>("EMPLOYEE_ZONE_HISTORYS");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<EMPLOYEE_ZONE_HISTORYS>(this, "EMPLOYEE_ZONE_HISTORYS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "EMPLOYEE_ZONE_HISTORYS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "EMPLOYEE_ZONE_HISTORYS");
	}
	#endregion DAC Methods 
 }
}

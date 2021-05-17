using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class EMPLOYEE_TIME_SHEET {
	#region members
	Guid iD;
	string bARCODE;
	string eMPLOYEE_ID;
	DateTime iNPUT_DATE;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("BARCODE", SqlDbType.NVarChar)]
	public string BARCODE {
		get { return bARCODE; }
		set{ bARCODE = value; }
	}
	[SqlColumn("EMPLOYEE_ID", SqlDbType.NVarChar)]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public EMPLOYEE_TIME_SHEET() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<EMPLOYEE_TIME_SHEET> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<EMPLOYEE_TIME_SHEET>("EMPLOYEE_TIME_SHEET");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "EMPLOYEE_TIME_SHEET");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "EMPLOYEE_TIME_SHEET");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<EMPLOYEE_TIME_SHEET> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<EMPLOYEE_TIME_SHEET>("EMPLOYEE_TIME_SHEET", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

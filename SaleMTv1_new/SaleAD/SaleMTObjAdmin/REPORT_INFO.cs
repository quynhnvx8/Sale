using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class REPORT_INFO {
	#region members
	string iD;
	string description;
	string parentID;
	string formName;
	int? reportGroup;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.NVarChar, null)]
	public string ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("Description", SqlDbType.NVarChar)]
	public string Description {
		get { return description; }
		set{ description = value; }
	}
	[SqlColumn("ParentID", SqlDbType.NVarChar)]
	public string ParentID {
		get { return parentID; }
		set{ parentID = value; }
	}
	[SqlColumn("FormName", SqlDbType.NVarChar)]
	public string FormName {
		get { return formName; }
		set{ formName = value; }
	}
	[SqlColumn("ReportGroup", SqlDbType.Int)]
	public int? ReportGroup {
		get { return reportGroup; }
		set{ reportGroup = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public REPORT_INFO() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<REPORT_INFO> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<REPORT_INFO>("REPORT_INFO");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "REPORT_INFO");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "REPORT_INFO");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<REPORT_INFO> ReadByID(string inID) {
		return rdodb_KTSqlDAC.ReadByParams<REPORT_INFO>("REPORT_INFO", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}

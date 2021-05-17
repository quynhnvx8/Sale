using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class EMPLOYEE_WORKING_TIME : IDataModel {
	#region members
	int id;
	string sHIFT_CODE;
	string eMPLOYEE_ID;
	DateTime? dATE_WORKING;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTOID", 0)]
	public int Id {
		get { return id; }
		set{ id = value; }
	}
	[StringSqlColumn("SHIFT_CODE")]
	public string SHIFT_CODE {
		get { return sHIFT_CODE; }
		set{ sHIFT_CODE = value; }
	}
	[StringSqlColumn("EMPLOYEE_ID")]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[SqlColumn("DATE_WORKING", SqlDbType.DateTime)]
	public DateTime? DATE_WORKING {
		get { return dATE_WORKING; }
		set{ dATE_WORKING = value; }
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
	public EMPLOYEE_WORKING_TIME() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public EMPLOYEE_WORKING_TIME(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<EMPLOYEE_WORKING_TIME> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<EMPLOYEE_WORKING_TIME>("EMPLOYEE_WORKING_TIME");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<EMPLOYEE_WORKING_TIME>(this, "EMPLOYEE_WORKING_TIME");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "EMPLOYEE_WORKING_TIME");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "EMPLOYEE_WORKING_TIME");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inSHIFT_CODE"></param>
	public static List<EMPLOYEE_WORKING_TIME> ReadBySHIFT_CODE(string inSHIFT_CODE) {
		object parameter = inSHIFT_CODE ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<EMPLOYEE_WORKING_TIME>("EMPLOYEE_WORKING_TIME", rdodb_KTSqlDAC.newInParam("@SHIFT_CODE", parameter));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inEMPLOYEE_ID"></param>
	public static List<EMPLOYEE_WORKING_TIME> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID) {
		object parameter = inEMPLOYEE_ID ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<EMPLOYEE_WORKING_TIME>("EMPLOYEE_WORKING_TIME", rdodb_KTSqlDAC.newInParam("@EMPLOYEE_ID", parameter));
	}
	#endregion DAC Methods 
 }
}

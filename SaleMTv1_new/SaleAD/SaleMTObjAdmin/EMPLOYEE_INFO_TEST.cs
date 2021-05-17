using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class EMPLOYEE_INFO_TEST {
	#region members
	string eMPLOYEE_ID;
	string fIRSTNAME;
	string sex_code;

	#endregion members
	#region Properties
	[PKSqlColumn("EMPLOYEE_ID", SqlDbType.VarChar, null)]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[SqlColumn("FIRSTNAME", SqlDbType.NVarChar)]
	public string FIRSTNAME {
		get { return fIRSTNAME; }
		set{ fIRSTNAME = value; }
	}
	[StringSqlColumn("sex_code")]
	public string Sex_code {
		get { return sex_code; }
		set{ sex_code = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public EMPLOYEE_INFO_TEST() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<EMPLOYEE_INFO_TEST> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<EMPLOYEE_INFO_TEST>("EMPLOYEE_INFO_TEST");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "EMPLOYEE_INFO_TEST");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "EMPLOYEE_INFO_TEST");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEMPLOYEE_ID"></param>
	public static List<EMPLOYEE_INFO_TEST> ReadByEMPLOYEE_ID(string inEMPLOYEE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<EMPLOYEE_INFO_TEST>("EMPLOYEE_INFO_TEST", rdodb_KTSqlDAC.newInParam("@EMPLOYEE_ID", inEMPLOYEE_ID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="insex_code"></param>
	public static List<EMPLOYEE_INFO_TEST> ReadBysex_code(string insex_code) {
		object parameter = insex_code ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<EMPLOYEE_INFO_TEST>("EMPLOYEE_INFO_TEST", rdodb_KTSqlDAC.newInParam("@sex_code", parameter));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class employee_sex {
	#region members
	string sex_code;
	string sex_name;

	#endregion members
	#region Properties
	[PKSqlColumn("sex_code", SqlDbType.VarChar, null)]
	public string Sex_code {
		get { return sex_code; }
		set{ sex_code = value; }
	}
	[SqlColumn("sex_name", SqlDbType.NVarChar)]
	public string Sex_name {
		get { return sex_name; }
		set{ sex_name = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public employee_sex() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<employee_sex> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<employee_sex>("employee_sex");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "employee_sex");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "employee_sex");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="insex_code"></param>
	public static List<employee_sex> ReadBysex_code(string insex_code) {
		return rdodb_KTSqlDAC.ReadByParams<employee_sex>("employee_sex", rdodb_KTSqlDAC.newInParam("@sex_code", insex_code));
	}
	#endregion DAC Methods 
 }
}

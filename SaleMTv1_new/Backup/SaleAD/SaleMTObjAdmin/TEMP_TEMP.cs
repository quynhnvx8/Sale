using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class TEMP_TEMP {
	#region members
	DateTime? cREATED_DATE;

	#endregion members
	#region Properties
	[SqlColumn("CREATED_DATE", SqlDbType.DateTime)]
	public DateTime? CREATED_DATE {
		get { return cREATED_DATE; }
		set{ cREATED_DATE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public TEMP_TEMP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<TEMP_TEMP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<TEMP_TEMP>("TEMP_TEMP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "TEMP_TEMP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "TEMP_TEMP");
	}
	#endregion DAC Methods 
 }
}

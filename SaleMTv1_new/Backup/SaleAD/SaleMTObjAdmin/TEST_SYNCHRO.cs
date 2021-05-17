using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class TEST_SYNCHRO {
	#region members
	string col_name;
	string value;
	string event_id;

	#endregion members
	#region Properties
	[StringSqlColumn("col_name")]
	public string Col_name {
		get { return col_name; }
		set{ col_name = value; }
	}
	[StringSqlColumn("value")]
	public string Value {
		get { return value; }
		set{ this.value = value; }
	}
	[StringSqlColumn("event_id")]
	public string Event_id {
		get { return event_id; }
		set{ event_id = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public TEST_SYNCHRO() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<TEST_SYNCHRO> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<TEST_SYNCHRO>("TEST_SYNCHRO");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "TEST_SYNCHRO");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "TEST_SYNCHRO");
	}
	#endregion DAC Methods 
 }
}

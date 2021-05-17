using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_EVENT_STACK_ERROR {
	#region members
	string eVENT_ID;
	string eRROR_TEXT;
	DateTime? dATE_EFFECT;

	#endregion members
	#region Properties
	[PKSqlColumn("EVENT_ID", SqlDbType.VarChar, null)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}
	[SqlColumn("ERROR_TEXT", SqlDbType.NText)]
	public string ERROR_TEXT {
		get { return eRROR_TEXT; }
		set{ eRROR_TEXT = value; }
	}
	[SqlColumn("DATE_EFFECT", SqlDbType.DateTime)]
	public DateTime? DATE_EFFECT {
		get { return dATE_EFFECT; }
		set{ dATE_EFFECT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_EVENT_STACK_ERROR() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_EVENT_STACK_ERROR> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_EVENT_STACK_ERROR>("BK_EVENT_STACK_ERROR");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_EVENT_STACK_ERROR");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_EVENT_STACK_ERROR");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEVENT_ID"></param>
	public static List<BK_EVENT_STACK_ERROR> ReadByEVENT_ID(string inEVENT_ID) {
		return rdodb_KTSqlDAC.ReadByParams<BK_EVENT_STACK_ERROR>("BK_EVENT_STACK_ERROR", rdodb_KTSqlDAC.newInParam("@EVENT_ID", inEVENT_ID));
	}
	#endregion DAC Methods 
 }
}

using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class MESSAGE {
	#region members
	string mESSAGE_ID;
	DateTime sEND_DATE;
	DateTime iNPUT_DATE;
	string aCCOUNT;
	string cONTENTS;
	string lEVELS;
	string cOLOR;

	#endregion members
	#region Properties
	[PKSqlColumn("MESSAGE_ID", SqlDbType.NVarChar, null)]
	public string MESSAGE_ID {
		get { return mESSAGE_ID; }
		set{ mESSAGE_ID = value; }
	}
	[SqlColumn("SEND_DATE", SqlDbType.DateTime)]
	public DateTime SEND_DATE {
		get { return sEND_DATE; }
		set{ sEND_DATE = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("CONTENTS", SqlDbType.NVarChar)]
	public string CONTENTS {
		get { return cONTENTS; }
		set{ cONTENTS = value; }
	}
	[SqlColumn("LEVELS", SqlDbType.NVarChar)]
	public string LEVELS {
		get { return lEVELS; }
		set{ lEVELS = value; }
	}
	[SqlColumn("COLOR", SqlDbType.NVarChar)]
	public string COLOR {
		get { return cOLOR; }
		set{ cOLOR = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public MESSAGE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<MESSAGE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<MESSAGE>("MESSAGE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "MESSAGE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "MESSAGE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inMESSAGE_ID"></param>
	public static List<MESSAGE> ReadByMESSAGE_ID(string inMESSAGE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<MESSAGE>("MESSAGE", rdodb_KTSqlDAC.newInParam("@MESSAGE_ID", inMESSAGE_ID));
	}
	#endregion DAC Methods 
 }
}
